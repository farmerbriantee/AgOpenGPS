 /*
  * This program only turns the relays for section control
  * On and Off. Connect to the Relay Port in AgOpenGPS
  */

  /*
  * The Orginalversion was downloades from Github: https://github.com/farmerbriantee/AgOpenGPS/blob/v4201/ArduinoCode/Machine_USB_4201/Machine_USB_4201.ino
  * This Version is an modified upgrade of the orginal code.
  * You can select if the relays are set continously (normal) or just giving an short and ajustable Impuls when the sections are switched On or Off.
  * Edit by hagre to assist forumsrequest https://agopengps.discourse.group/t/section-control-code-help/1817/3
  * 
  * It is possibel to connect up to 16 relays/pins if you compile with an arduino MEGA2560 CPU (automatic selected)
  */

  #define OUTPUT_TO_RELAY_IS_NORMAL //comment out if impulse output is required 
  //#define OUTPUT_TO_RELAY_IS_IMPULSE //comment out if normal output is required

  //loop time variables in microseconds -----------------ADJUST AS REQUIRED
  unsigned long serialSendLoopTime = 200; //200 ms == 5hz //ms adjust as required
  unsigned long serialReciveMaxTime = 600; //600 ms adjust as required
  unsigned long watchDogTimerMaxReceiveWaitTime = 2000; //2000 ms make sure we are talking to AOG (receiving)
  unsigned long timeOfRelayImpuls = 200; //200 ms adjust as required //only required if #define OUTPUT_TO_RELAY_IS_IMPULSE

//------------------------------------------------------- END OF CUSTOM VARIABLES ------------------------------------------------------ 
  //sanitycheck
  #if !defined (OUTPUT_TO_RELAY_IS_IMPULSE) && !defined (OUTPUT_TO_RELAY_IS_NORMAL) 
    #error "ERROR: select at least one: OUTPUT_TO_RELAY_IS_IMPULSE or OUTPUT_TO_RELAY_IS_NORMAL"
  #endif
  #ifdef OUTPUT_TO_RELAY_IS_NORMAL
    #ifdef OUTPUT_TO_RELAY_IS_IMPULSE
      #error "ERROR: Do NOT select two: OUTPUT_TO_RELAY_IS_IMPULSE and OUTPUT_TO_RELAY_IS_NORMAL"
    #endif  
  #endif  

  //CPU or BOARD check to set number of avaliable PINS

  #if defined(__AVR_ATmega328P__) //UNO NANO
    #define NUM_OF_RELAYS 8
  #endif
  #if defined(__AVR_ATmega2560__) //ATMEGA2560
    #define NUM_OF_RELAYS 16
  #endif    

  //Raise and lower as D4 and D3
  #define RAISE_PIN 4
  #define LOWER_PIN 3
  
  //Variables for Ralay
  #define RELAY0_PIN 5
  #define RELAY1_PIN 6
  #define RELAY2_PIN 7
  #define RELAY3_PIN 8
  #define RELAY4_PIN 9
  #define RELAY5_PIN 10
  #define RELAY6_PIN 11
  #define RELAY7_PIN 12

  //if MEGA2560 is selected in the arduino IDE to compile
  #define RELAY8_PIN 22
  #define RELAY9_PIN 24
  #define RELAY10_PIN 26
  #define RELAY11_PIN 28
  #define RELAY12_PIN 30
  #define RELAY13_PIN 32
  #define RELAY14_PIN 34
  #define RELAY15_PIN 36

  #include <EEPROM.h> 
  #define EEP_Ident 0x4201  

  //Program counter reset
  void(* resetFunc) (void) = 0;

  //loop time variables in microseconds
  unsigned long lastSerialSendTime = 0;
  unsigned long lastSerialReceiveTime = 0;
  unsigned long currentTime = 0;
  unsigned long watchDogTimeLast = 0; //make sure we are talking to AOG
  unsigned long lastStrartingLiftTime = 0; //time of last change of Lift command
  unsigned long raiseTimeInMS = 0; //to calculate number only once if set
  unsigned long lowerTimeInMS = 0; //to calculate number only once if set

  //Variables for config - 0 is false  
  struct Config {
  byte raiseTime = 2;
  byte lowerTime = 4;
  byte enableToolLift = 0;
  byte isRelayActiveHigh = 0; //if zero, active low (default) 
  };  
  Config aogConfig;   //4 bytes 
  
  //Communication with AgOpenGP5
  bool isDataFound = false, isSettingFound = false, isAogConfigFound = false, isRelayActiveHigh = true;
  int header = 0, tempHeader = 0, temp, EEread = 0;

  //The variables used for storage
  byte relayHi=0, relayLo = 0, gpsSpeed = 0, tree = 0, uTurn = 0, hydLift = 0; 
  int lastHydrLift = 0, lowerRelay = 0, raiseRelay = 0;
  unsigned int relayHiAndLo = 0;

  //Variables for Ralay as Impulse
  byte statusOfRelay_Old[NUM_OF_RELAYS];
  int triggerIsSet_Relay[NUM_OF_RELAYS];
  unsigned long lastTimeTriggerWasSet_Relay[NUM_OF_RELAYS];
  int relayPins [] = {RELAY0_PIN, RELAY1_PIN, RELAY2_PIN, RELAY3_PIN, RELAY4_PIN, RELAY5_PIN, RELAY6_PIN, RELAY7_PIN, RELAY8_PIN, RELAY9_PIN, RELAY10_PIN, RELAY11_PIN, RELAY12_PIN, RELAY13_PIN, RELAY14_PIN, RELAY15_PIN};  

void setup()
  {
    //set the baud rate
     Serial.begin(38400);  
     while (!Serial) { ; } // wait for serial port to connect. Needed for native USB
     
     EEPROM.get(0, EEread);              // read identifier
    
  if (EEread != EEP_Ident)   // check on first start and write EEPROM
  {           
    EEPROM.put(0, EEP_Ident);
    EEPROM.put(6, aogConfig);
  }
  else 
  { 
    EEPROM.get(6, aogConfig);
  }

  //set the pins to be outputs (pin numbers)
  pinMode(LOWER_PIN, OUTPUT);
  pinMode(RAISE_PIN, OUTPUT);

  for (int i=0; i < NUM_OF_RELAYS; i++){ //setting up all RelayPins as output
    pinMode (relayPins [i], OUTPUT);
    triggerIsSet_Relay[i] = 0;
    statusOfRelay_Old[i]= 0;
    lastTimeTriggerWasSet_Relay[i] = 0;
  } 

  currentTime = millis();  // setting up all times for the first loop
  lastSerialSendTime = currentTime;
  lastSerialReceiveTime =currentTime;
  watchDogTimeLast = currentTime;
  lastStrartingLiftTime = currentTime;

  //set for standard config
  raiseTimeInMS = aogConfig.raiseTime * 1000;
  lowerTimeInMS = aogConfig.lowerTime * 1000;
}

void loop()
{
  //Loop triggers every x msec and sends back some data
  currentTime = millis(); //to keep the calculation constant during one loop

  //****************************************************************************************
  //This runs continuously, outside of the timed loop, keeps checking UART for new data
        // PGN - 32762 - 127.250 0x7FFA
        //public int mdHeaderHi, mdHeaderLo = 1, mdSectionControlByteHi = 2, mdSectionControlByteLo = 3,
        //mdSpeedXFour = 4, mdUTurn = 5, mdTree = 6, mdHydLift = 7, md8 = 8, md9 = 9;
  if (Serial.available() > 0 && !isDataFound && !isAogConfigFound) //find the header, 127H + 254L = 32766
  {
    int temp = Serial.read();
    header = tempHeader << 8 | temp;                //high,low bytes to make int
    tempHeader = temp;                              //save for next time
    if (header == 32762) isDataFound = true;        //Do we have a match?
    if (header == 32760) isAogConfigFound = true;     //Do we have a match?
  }

  //Data Header has been found, so the next 6 bytes are the data
  if (Serial.available() > 7 && isDataFound)
  {
    isDataFound = false;
    relayHi = Serial.read();
    relayLo = Serial.read();          // read relay control from AgOpenGPS
    relayHiAndLo = relayHi << 8;
    relayHiAndLo = relayHiAndLo + relayLo; 
    gpsSpeed = Serial.read() >> 2;  //actual speed times 4, single byte
    uTurn = Serial.read();  
    tree = Serial.read();
    hydLift = Serial.read();
    
    //just get the rest of bytes
    Serial.read();   //high,low bytes   
    Serial.read();  

    //reset watchdog (Serial receive savetyTimer)
    watchDogTimeLast = currentTime;

    //Prevent serial buffer overflow 
    lastSerialReceiveTime = currentTime;
  }

   //Arduino Config Header has been found, so the next 8 bytes are the data
  if (Serial.available() > 7 && isAogConfigFound)
  {
    isAogConfigFound = false;

    aogConfig.raiseTime = Serial.read();
    aogConfig.lowerTime = Serial.read();    
    aogConfig.enableToolLift = Serial.read();
    raiseTimeInMS = aogConfig.raiseTime * 1000;
    lowerTimeInMS = aogConfig.lowerTime * 1000;
    
    //set1 
    byte sett = Serial.read();  //setting0     
    if (bitRead(sett,0)) aogConfig.isRelayActiveHigh = 1; else aogConfig.isRelayActiveHigh = 0;
    
    Serial.read();
    Serial.read();
    Serial.read();
    Serial.read();

    //save in EEPROM and restart
    EEPROM.put(6, aogConfig);
    
    resetFunc();
  }

  //If connection lost to AgOpenGPS, the watchdog will make the system save and switch off all relays
  if (currentTime - watchDogTimerMaxReceiveWaitTime >= watchDogTimeLast)
  {
    relayLo = 0;
    relayHi = 0;
    relayHiAndLo = 0;
    hydLift = 0;
    lastHydrLift = 0;
    lowerRelay = 0;
    raiseRelay = 0;
  }

  //clean out serial buffer to prevent buffer overflow
  if (currentTime - serialReciveMaxTime >= lastSerialReceiveTime)
  {
    while (Serial.available() > 0) 
    {
      char t = Serial.read();
    }
    lastSerialReceiveTime = currentTime;
  }

  //hydraulic lift
  if (aogConfig.enableToolLift) // onyl if toolift is activated
  {
    //Serial.print(" LIFT ENABLED ");
    if (hydLift != lastHydrLift && (hydLift == 1 || hydLift == 2))
    {
      lastHydrLift = hydLift;
      lastStrartingLiftTime = currentTime;
      switch (hydLift)
      {
        //lower
        case 1:
          lowerRelay = 1;
          raiseRelay = 0;
        break;
  
        //raise
        case 2:
          lowerRelay = 0;
          raiseRelay = 1;   
        break;
      }
    }
    
    if ((lastHydrLift == 1) && (currentTime - lowerTimeInMS >= lastStrartingLiftTime)) //end of lowering
    {
      lowerRelay = 0;
      raiseRelay = 0;
    }
    else if ((lastHydrLift == 2) && (currentTime - raiseTimeInMS >= lastStrartingLiftTime)) //end of raise
    {
      lowerRelay = 0;
      raiseRelay = 0;
    }
  }
  else //toolift is not activated
  {
    lowerRelay = 0;
    raiseRelay = 0;
  }

  SetRelays(); // OUTPUT all relays

  if (currentTime - serialSendLoopTime >= lastSerialSendTime) // Timing OK -> Serial Data end
  {
    lastSerialSendTime = currentTime;

    unsigned long timeCalculation = 0;
    int lowerTimer = 0;
    int raiseTimer = 0;
    if (raiseRelay == 1) {
      timeCalculation = lastStrartingLiftTime + raiseTimeInMS - currentTime;
      raiseTimer = timeCalculation / 1000;
    }
    else if (lowerRelay == 1) {
      timeCalculation = lastStrartingLiftTime + lowerTimeInMS - currentTime;
      lowerTimer = timeCalculation / 1000;
    }
 
    //Send data back to agopenGPS
    Serial.print(127); //steering switch status
    Serial.print(",");
    Serial.print(248); //steering switch status
    Serial.print(","); 
    Serial.print(raiseTimer); //steering switch status
    Serial.print(",");  
    Serial.print(lowerTimer); //steering switch status
    Serial.print(",");     
    Serial.print(hydLift); //steering switch status
    Serial.print(",");  
    Serial.print(aogConfig.isRelayActiveHigh); //steering switch status
    Serial.print(",0,0,0,");  
    Serial.println(0); 

    Serial.flush();   // flush out buffer 
  } //end of timed loop
}

  void SetRelays(void)
 { 
    byte activatePin, deactivatePin; 
    if (aogConfig.isRelayActiveHigh){ //active low
      activatePin = HIGH;
      deactivatePin = LOW;
    }
    else{
      activatePin = LOW;
      deactivatePin = HIGH;
    }
        
    if (lowerRelay) digitalWrite(LOWER_PIN, activatePin);
    else digitalWrite(LOWER_PIN, deactivatePin); 

    if (raiseRelay) digitalWrite(RAISE_PIN, activatePin);
    else digitalWrite(RAISE_PIN, deactivatePin);

    for (int i=0; i < NUM_OF_RELAYS; i++)
    {
      #ifdef OUTPUT_TO_RELAY_IS_IMPULSE 
        if (bitRead(relayHiAndLo,i) != bitRead(statusOfRelay_Old[i],0)) //disired Status has changed since last check
        { 
          statusOfRelay_Old[i] = bitRead(relayHiAndLo,i); // save current status for the next loop to compare
          triggerIsSet_Relay[i] = 1;
          lastTimeTriggerWasSet_Relay[i] = currentTime;
          digitalWrite (relayPins [i], activatePin);
        }
        if ((triggerIsSet_Relay[i] == 1) && (currentTime - timeOfRelayImpuls > lastTimeTriggerWasSet_Relay[i])){
          triggerIsSet_Relay[i] = 0;
          digitalWrite (relayPins [i], deactivatePin);
        }
      #endif
      #ifdef OUTPUT_TO_RELAY_IS_NORMAL 
        if (bitRead(relayHiAndLo,i)) digitalWrite (relayPins [i], activatePin);
        else digitalWrite (relayPins [i], deactivatePin);
      #endif
    }
  }
  
