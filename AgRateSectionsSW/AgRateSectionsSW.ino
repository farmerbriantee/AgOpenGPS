  #define LED_PIN 13   
  #define   DIR_PIN    12  //PB4
  #define   PWM_PIN    11  //PB3  
  #define WORKSW_PIN 3  //PD2
  #define encAPin 2     ////int0 D2 pin 2 
  #define BaudRate 38400   // Baudrate = speed of serial port eg. 38400 or 115200 if useing bluetooth module, you need to configure it to the Baudrate

  #define SectNum 7 // number of sections equiped max 7 
  boolean SectSprayONHIGH = true; // Output is HIGH when spraying, change to false when spraying on low signal
 
  int Relay_PIN[] = {4,5,6,7,8,9,10}; //arduino to sprayer when changed also change in Relays code (other Tab)

  boolean SectInputSW = true;  //true if section input switches are equiped
  #define SectSW_PIN0  A1      //Switches to arduino
  #define SectSW_PIN1  A2
  #define SectSW_PIN2  A3
  #define SectSW_PIN3  A4
  #define SectSW_PIN4  A5
  #define SectSW_PIN5  A6
  #define SectSW_PIN6  A7
   
  #define SectMainSW_PIN A0 //arduino to AOG auto toggle switch

  //values to decide position of section switch
  #define SectSWOFF 300 // analog in is lower than .. for off
  #define SectSWAUTOMin 350 // analog in is higher than .. for auto
  #define SectSWAUTOMax 700 // analog in is lower than .. for auto
  #define SectSWON 750 // analog in is higher than .. for on
  
  int SectSWVal[] = {0,0,0,0,0,0,0,0,0}; //value of analogRead
  
  //loop time variables in microseconds
  const unsigned long LOOP_TIME = 200; //in msec = 5hz 
  const unsigned long SectSWDelayTime = 1500; //time the arduino waits after manual Switch is used befor acception command from AOG in msec
  const unsigned long TimeoutContactFromAOG = 20000; //time the arduino waits before changing mode of main switch from "auto" to "all on" when not hearing anything from AOG
  unsigned long lastTime = LOOP_TIME;
  unsigned long currentTime = LOOP_TIME;
  unsigned long RelayFromAOGTime = LOOP_TIME;
  unsigned long SectSWlastTime = LOOP_TIME;
  unsigned long SectMainSWlastTime = LOOP_TIME;
  unsigned long SectSWcurrentTime = LOOP_TIME;
  unsigned int dT = 100;
  byte watchdogTimer = 0;

    //Kalman variables
  float rateK = 0;
  float Pc = 0.0;
  float G = 0.0;
  float P = 1.0;
  float Xp = 0.0;
  float Zp = 0.0;
  float XeRate = 0; //the filtered flowrate
  const float varRate = 100; // variance, smaller, more filtering
  const float varProcess = 10;

  //program flow
  bool isDataFound = false, isSettingFound = false;
  int header = 0, tempHeader = 0;

  //bit 0 is section 0
  byte RelayFromAOG = 0;
  byte RelayToAOG = 0;
  byte RelayOUT = 0;
  byte SectSWOffToAOG = 0;
  byte uTurnRelay = 0;
  boolean SectMainSWpressed = false;
  boolean SectAuto = false;
  boolean contactFromAOG = false;
  boolean BitVal = false;

  float groundSpeed = 0; //speed from AgOpenGPS is multiplied by 4
  float rateSetPoint = 0.0;
  float countsThisLoop = 0;
  float rateError = 0; //for PID
  int rateAppliedLPM = 0;
  
  unsigned long accumulatedCounts = 0;
  float flowmeterCalFactor = 50; 

  //the ISR counter
  volatile unsigned long pulseCount = 0, pulseDuration;
  bool state = false;

void setup()
{
  pinMode(LED_PIN, OUTPUT); //configure LED for output
  
  if (SectInputSW) pinMode(SectMainSW_PIN, INPUT);
  if (SectInputSW)pinMode(SectSW_PIN0, INPUT);
  if (SectNum >= 2 && SectInputSW) pinMode(SectSW_PIN1, INPUT);
  if (SectNum >= 3 && SectInputSW) pinMode(SectSW_PIN2, INPUT);
  if (SectNum >= 4 && SectInputSW) pinMode(SectSW_PIN3, INPUT);
  if (SectNum >= 5 && SectInputSW) pinMode(SectSW_PIN4, INPUT);
  if (SectNum >= 6 && SectInputSW) pinMode(SectSW_PIN5, INPUT);
  if (SectNum >= 7 && SectInputSW) pinMode(SectSW_PIN6, INPUT);

  SectSWVal[0] = analogRead(SectSW_PIN0);
  SectSWVal[1] = analogRead(SectSW_PIN1);
  SectSWVal[2] = analogRead(SectSW_PIN2);
  SectSWVal[3] = analogRead(SectSW_PIN3);
  SectSWVal[4] = analogRead(SectSW_PIN4);
  SectSWVal[5] = analogRead(SectSW_PIN5);
  SectSWVal[6] = analogRead(SectSW_PIN6);

  SectSWVal[8] = analogRead(SectMainSW_PIN);
  for (int i=0 ; i<9; i++){SectSWVal[i] = 0;}

  
  for (int i=0 ; i<SectNum ; i++){
    pinMode(Relay_PIN[i], OUTPUT);
  }
  RelayOUT = 0;
  SetRelays;
  
  //set up communication  
  Serial.begin(BaudRate); 

  //attachInterrupt(0, ISR, mode); //below is preferred method - most compatible
  attachInterrupt(digitalPinToInterrupt(encAPin), pinChangeISR, CHANGE); 

  Serial.flush();   // flush out buffer 
  //PWM rate settings Adjust to desired PWM Rate
  //TCCR1B = TCCR1B & B11111000 | B00000010;    // set timer 1 divisor to     8 for PWM frequency of  3921.16 Hz
  TCCR1B = TCCR1B & B11111000 | B00000011;    // set timer 1 divisor to    64 for PWM frequency of   490.20 Hz (The DEFAULT)
} //end of setup

//------------------------------------------------------------------------------------------------------------------------------

void SectSWRead()
{
  SectSWcurrentTime = millis();

  SectSWOffToAOG = 0;

  if (SectSWcurrentTime > RelayFromAOGTime + TimeoutContactFromAOG) {contactFromAOG = false;}

  //waits for AOG to see switches used
  boolean timepassed = true;
  if (SectSWcurrentTime >= SectSWlastTime + SectSWDelayTime) {timepassed=true;} else timepassed=false;

  //looks if data from AOG or data of switches is newer
  boolean newData = false;
  if (SectSWlastTime + SectSWDelayTime < RelayFromAOGTime ) {newData=true;} else newData=false;
  
  //read switches
  SectSWVal[0] = analogRead(SectSW_PIN0);
  SectSWVal[1] = analogRead(SectSW_PIN1);
  SectSWVal[2] = analogRead(SectSW_PIN2);
  SectSWVal[3] = analogRead(SectSW_PIN3);
  SectSWVal[4] = analogRead(SectSW_PIN4);
  SectSWVal[5] = analogRead(SectSW_PIN5);
  SectSWVal[6] = analogRead(SectSW_PIN6);

  SectSWVal[8] = analogRead(SectMainSW_PIN);

  //AUTO toggle switch pressed, signal to AGO stays for SectSWDelayTime
  if (SectSWVal[8] > SectSWON) {SectAuto = true; SectMainSWpressed = true; SectMainSWlastTime = SectSWcurrentTime;}
  if (SectSWVal[8] < SectSWOFF) {SectAuto = false; SectMainSWpressed = true; SectMainSWlastTime = SectSWcurrentTime;}
  if (SectSWcurrentTime > SectMainSWlastTime + SectSWDelayTime) {SectMainSWpressed = false; SectAuto = true;}
 
  SectSWOffToAOG = 0;
  
  //set relay bytes
    for (int i=0;i<SectNum;i++){
      if (SectSWVal[i] > SectSWON){
   
        //manualy ON
        bitSet(RelayOUT,i);
        SectSWlastTime = SectSWcurrentTime;
      }//if
      else {
        
        if (SectSWVal[i] > SectSWAUTOMin && SectSWVal[i] < SectSWAUTOMax)  {
        // switch auto
           
            //use Data from AOG if delaytime after using a switch is passed (to wait for AOG to see switch was pressed) 
            if (timepassed && newData){BitVal = bitRead(RelayFromAOG,i); if (BitVal == 1) {bitSet(RelayOUT,i);} else bitClear(RelayOUT,i);}
           
            // switch auto but Main toggle toggled to off, works only for Delaytime to make AGO to see it, if disconnected would also be used (not newData)
            if (SectMainSWpressed && !SectAuto) {bitClear(RelayOUT,i);}

            //switch auto but no connection from AOG and Main switch is pressed ON
            if (SectMainSWpressed && SectAuto && ! contactFromAOG ) {bitSet(RelayOUT, i);}
          } //if
        else
        if (SectSWVal[i] < SectSWOFF){
      
          //switch OFF
          bitClear(RelayOUT,i);
          bitSet(SectSWOffToAOG, i);
        }//if
      }//else
    }//for
 

  //set RelayToAOG for Delay time to make AOG see the manual set
  if (SectSWcurrentTime > SectSWlastTime + SectSWDelayTime)  {RelayToAOG = 0;} else {RelayToAOG = RelayOUT;}
  if (SectMainSWpressed && SectAuto) {bitSet(RelayToAOG, 7);}
  if (SectMainSWpressed && ! SectAuto) {bitSet(SectSWOffToAOG, 7);}

}//end of SectSWRead


//------------------------------------------------------------------------------------------------------------------------------

void loop()
{ 
  currentTime = millis();
  unsigned int time = currentTime;

  if (currentTime - lastTime >= LOOP_TIME)
  {   
    dT = currentTime - lastTime;
    lastTime = currentTime;

    //reset ISR
    countsThisLoop = pulseCount;
    pulseCount = 0;     

    //increase the watchdog - reset in data recv.
    watchdogTimer ++;

    //clean out serial buffer
    if (watchdogTimer > 10)
    {
      while(Serial.available() > 0) char t = Serial.read();
      watchdogTimer = 0;
    }
    
    //accumulated counts from this cycle
    accumulatedCounts += countsThisLoop;
    
    //only if section(s) are on and there is flow
    if (countsThisLoop)
    {      
      rateK =  (float)pulseDuration * 0.000001;//what is current flowrate from meter
      
      if (rateK < .00001) rateK = 1.0;//prevent divide by zero
      else rateK = ((1.0/rateK)*60)/flowmeterCalFactor;
      
      //Kalman filter
      Pc = P + varProcess;
      G = Pc / (Pc + varRate);
      P = (1 - G) * Pc; Xp = XeRate; Zp = Xp;
      XeRate = G * (rateK - Zp) + Xp;       
      
      rateAppliedLPM = XeRate * 100; //fill in formatted rateApplied
    }   
    
    else
    {
      rateK = 1.0;
      rateAppliedLPM = 0;    
    }
  
    SetRelays();     
    
    //Do the PID - this placed in code depending on valve style
    rateError = rateSetPoint - rateK; 
    calcRatePID();
    motorDrive();   

    //Send to agopenGPS, once per second
    Serial.print(rateAppliedLPM); //100 x actual!
    Serial.print(","); 
    Serial.print( (int)((float)accumulatedCounts/flowmeterCalFactor) );
    Serial.print(","); 
    Serial.print( countsThisLoop );
    Serial.print(",");
    Serial.print(RelayToAOG);
    Serial.print(",");
    Serial.println(SectSWOffToAOG);

    
    //Serial.println( rateSetPoint );      
    Serial.flush();   // flush out buffer     
  } //end of timed loop
  
    //****************************************************************************************
    //This runs continuously, outside of the timed loop, keeps checking UART for new data  
    // header high/low, relay byte, speed byte, rateSetPoint hi/lo
     
     if (SectInputSW) {SectSWRead(); } else RelayOUT = RelayFromAOG; //checks if section switch is toggled
     
     if (Serial.available() > 0 && !isDataFound && !isSettingFound) //find the header, 
    {
      int temp = Serial.read();
      header = tempHeader << 8 | temp;               //high,low bytes to make int
      tempHeader = temp;                             //save for next time
      if (header == 32762) isDataFound = true;     //Do we have a match? 
      if (header == 32760) isSettingFound = true;     //Do we have a match? 
    }
    
    //DATA Header has been found, so the next 4 bytes are the data -- 127H + 250L = 32762
    if (Serial.available()==5 && isDataFound)
    {  
      isDataFound = false;    
      RelayFromAOG = Serial.read();   // read relay control from AgOpenGPS  
      groundSpeed = Serial.read()>>2;  //actual speed times 4, single byte
  
      // sent as 100 times value in liters per minute
      rateSetPoint = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes
      rateSetPoint *= 0.01;

       uTurnRelay = Serial.read(); //read youTurn relay byte

      //reset watchdog as we just heard from AgOpenGPS
      watchdogTimer = 0;
      RelayFromAOGTime = millis();
      contactFromAOG = true;
    }  
  
    //SETTINGS Header has been found,  4 bytes are the settings -- 127H + 248L = 32760
    if (Serial.available() == 4 && isSettingFound)
    {        
      isSettingFound = false;  //reset the flag

      //accumulated volume, 0 it if this is 32700 sent 
      float tempf = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes
      if (tempf == 32700) accumulatedCounts = 0;

      //flow meter cal factor in counts per Liter
      flowmeterCalFactor = ((float)(Serial.read() << 8 | Serial.read()));   //high,low bytes
    }
}//end of main

//------------------------------------------------------------------------------------------------------------------------------

 //ISR
  void pinChangeISR(){
    
    static unsigned long pulseStart = 0;
    pulseCount++;
    
    state = !state;    
    if(state)
    { 
      // interrupt pin has risen, a pulse has started
      pulseStart = micros(); // store the current microseconds
    }     
    else 
    {    //risen again
      pulseDuration = micros() - pulseStart; // get the pulse length
      pulseStart = 0;
    }
  }

