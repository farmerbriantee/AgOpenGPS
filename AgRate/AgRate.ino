  #define LED_PIN 13   
  #define   DIR_PIN    12  //PB4
  #define   PWM_PIN    11  //PB3  
  #define WORKSW_PIN 4  //PD4
  #define encAPin 2     ////int0 D2 pin 2 
    
  #define RELAY1_PIN 5  //PD5
  #define RELAY2_PIN 6  //PD6
  #define RELAY3_PIN 7  //PD7
  #define RELAY4_PIN 8  //PB0
  #define RELAY5_PIN 9  //PB1
   
  //loop time variables in microseconds
  const unsigned long LOOP_TIME = 200; //in msec = 5hz 
  unsigned long lastTime = LOOP_TIME;
  unsigned long currentTime = LOOP_TIME;
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
  byte relay = 0;
  byte uTurnRelay = 0;
  
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
  pinMode(RELAY1_PIN, OUTPUT); //configure RELAY1 for output //Pin 5
  pinMode(RELAY2_PIN, OUTPUT); //configure RELAY2 for output //Pin 6
  pinMode(RELAY3_PIN, OUTPUT); //configure RELAY3 for output //Pin 7
  pinMode(RELAY4_PIN, OUTPUT); //configure RELAY4 for output //Pin 8
  pinMode(RELAY5_PIN, OUTPUT); //configure RELAY5 for output //Pin 9
  //pinMode(RELAY6_PIN, OUTPUT); //configure RELAY6 for output //Pin 10
  //pinMode(RELAY7_PIN, OUTPUT); //configure RELAY7 for output //Pin A4
  //pinMode(RELAY8_PIN, OUTPUT); //configure RELAY8 for output //Pin A5
  
  //set up communication  
  Serial.begin(38400); 

  //attachInterrupt(0, ISR, mode); //below is preferred method - most compatible
  attachInterrupt(digitalPinToInterrupt(encAPin), pinChangeISR, CHANGE); 
  
  //PWM rate settings Adjust to desired PWM Rate
  //TCCR1B = TCCR1B & B11111000 | B00000010;    // set timer 1 divisor to     8 for PWM frequency of  3921.16 Hz
  TCCR1B = TCCR1B & B11111000 | B00000011;    // set timer 1 divisor to    64 for PWM frequency of   490.20 Hz (The DEFAULT)
} 

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
    if (relay && countsThisLoop)
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
    Serial.println( countsThisLoop );      
    //Serial.println( rateSetPoint );      
    Serial.flush();   // flush out buffer     
  } //end of timed loop
  
    //****************************************************************************************
    //This runs continuously, outside of the timed loop, keeps checking UART for new data  
    // header high/low, relay byte, speed byte, rateSetPoint hi/lo
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
      relay = Serial.read();   // read relay control from AgOpenGPS  
      relay = 255 - relay;   
      groundSpeed = Serial.read()>>2;  //actual speed times 4, single byte
  
      // sent as 100 times value in liters per minute
      rateSetPoint = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes
      rateSetPoint *= 0.01;

       uTurnRelay = Serial.read(); //read youTurn relay byte

      //reset watchdog as we just heard from AgOpenGPS
      watchdogTimer = 0;
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
}


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

