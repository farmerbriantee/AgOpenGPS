   /*
    * This program only turns the relays for section control
    * On and Off. Connect to the Relay Port in AgOpenGPS
    */

    /*
    * The Orginalversion was downloades from Github: https://github.com/farmerbriantee/AgOpenGPS/blob/v4201/ArduinoCode/Machine_USB_4201/Machine_USB_4201.ino
    * This Version is just giving an short and ajustable Impuls when the sections are switched On or Off.
    * modified by hagre to assist forumsrequest https://agopengps.discourse.group/t/section-control-code-help/1817/3
    */
    #define TIMED_LOOPS_FOR_IMPULSE 3 // adjust as required, example: 3 * 200ms => 600ms +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    
  //loop time variables in microseconds

  #include <EEPROM.h> 
  #define EEP_Ident 0x4202  

    //Program counter reset
    void(* resetFunc) (void) = 0;

  //Variables for config - 0 is false  
  struct Config {
  byte raiseTime = 2;
  byte lowerTime = 4;
  byte enableToolLift = 0;
  byte isRelayActiveHigh = 0; //if zero, active low (default)
  
  };  Config aogConfig;   //4 bytes
  
  const byte LOOP_TIME = 200; //5hz
  unsigned long lastTime = LOOP_TIME;
  unsigned long currentTime = LOOP_TIME;
  unsigned long fifthTime = 0;
  unsigned int count = 0;

  //Comm checks
  byte watchdogTimer = 0; //make sure we are talking to AOG
  byte serialResetTimer = 0; //if serial buffer is getting full, empty it
  
   //Communication with AgOpenGPS
  bool isDataFound = false, isSettingFound = false, isAogConfigFound = false, isRelayActiveHigh = true;
  int header = 0, tempHeader = 0, temp, EEread = 0;

  //The variables used for storage
  byte relayHi=0, relayLo = 0, gpsSpeed = 0, tramline = 0, tree = 0, uTurn = 0, hydLift = 0; 

  byte raiseTimer = 0, lowerTimer = 0, lastTrigger = 0;
  
  //Raise and lower as D4 and D3
  #define RAISE 4
  #define LOWER 3
  
  int statusRelay0Old = 0;
  int statusRelay1Old = 0;
  int statusRelay2Old = 0;
  int statusRelay3Old = 0;
  int statusRelay4Old = 0;
  int statusRelay5Old = 0;
  int statusRelay6Old = 0;
  int statusRelay7Old = 0;

  int triggerSetRelay0Old = 0;
  int triggerSetRelay1Old = 0;
  int triggerSetRelay2Old = 0;
  int triggerSetRelay3Old = 0;
  int triggerSetRelay4Old = 0;
  int triggerSetRelay5Old = 0;
  int triggerSetRelay6Old = 0;
  int triggerSetRelay7Old = 0;

  int numberOfTriggerToReachTime = TIMED_LOOPS_FOR_IMPULSE;
 
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
  pinMode(LOWER, OUTPUT);
  pinMode(RAISE, OUTPUT);

  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
  pinMode(7, OUTPUT);
  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(12, OUTPUT);  
}

void loop()
{
  //Loop triggers every 200 msec and sends back gyro heading, and roll, steer angle etc

  currentTime = millis();
  //unsigned int time = currentTime;

  if (currentTime - lastTime >= LOOP_TIME)
  {
    lastTime = currentTime;

    //If connection lost to AgOpenGPS, the watchdog will count up 
    if (watchdogTimer++ > 250) watchdogTimer = 12;

    //clean out serial buffer to prevent buffer overflow
    if (serialResetTimer++ > 20)
    {
      while (Serial.available() > 0) char t = Serial.read();
      serialResetTimer = 0;
    }

    if (watchdogTimer > 10) 
    {
      relayLo = 0;
      relayHi = 0;
    }
    
    //hydraulic lift

    if (hydLift != lastTrigger && (hydLift == 1 || hydLift == 2))
    {
      lastTrigger = hydLift;
      lowerTimer = 0;
      raiseTimer = 0;

      //200 msec per frame so 5 per second
      switch (hydLift)
      {
        //lower
        case 1:
          lowerTimer = aogConfig.lowerTime * 5;
        break;

        //raise
        case 2:
          raiseTimer = aogConfig.raiseTime * 5;     
        break;
      }
    }

    //countdown if not zero, make sure up only
    if (raiseTimer) 
    {
      raiseTimer--;
      lowerTimer = 0;
    }
    if (lowerTimer) lowerTimer--; 

    //if anything wrong, shut off hydraulics, reset last
    if ((hydLift != 1 && hydLift != 2) || watchdogTimer > 10 ) //|| gpsSpeed < 2)
    {
      lowerTimer = 0;
      raiseTimer = 0;
      lastTrigger = 0;
    }

    //section relays
    SetRelays();
    
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

   /* 
    Serial.print(",");
    
   Serial.print(gpsSpeed); //steering switch status
    Serial.print(",");
    
   Serial.print(hydLift); //steering switch status
    Serial.print(",");
    
   Serial.print(lastTrigger); //steering switch status
    Serial.print(",");
    
   Serial.println(aogConfig.lowerTime); //steering switch status 
   */
      
   Serial.flush();   // flush out buffer
   
  } //end of timed loop

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
    gpsSpeed = Serial.read() >> 2;  //actual speed times 4, single byte
    uTurn = Serial.read();  
    tree = Serial.read();
    hydLift = Serial.read();
    
    //just get the rest of bytes
    Serial.read();   //high,low bytes   
    Serial.read();  

    //reset watchdog
    watchdogTimer = 0;

    //Reset serial Watchdog  
    serialResetTimer = 0;
  }

   //Arduino Config Header has been found, so the next 8 bytes are the data
  if (Serial.available() > 7 && isAogConfigFound)
  {
    isAogConfigFound = false;

    aogConfig.raiseTime = Serial.read();
    aogConfig.lowerTime = Serial.read();    
    aogConfig.enableToolLift = Serial.read();
    
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
}

  void SetRelays(void)
 { 
    if (aogConfig.isRelayActiveHigh)
    {
      //active low
      if (lowerTimer) bitClear(PORTD, LOWER); //Digital Pin D3
      else bitSet(PORTD, LOWER); 
  
      if (raiseTimer) bitClear(PORTD, RAISE); //Digital Pin D4
      else bitSet(PORTD, RAISE); 

      //Relay0
      if (bitRead(relayLo,0) != bitRead(statusRelay0Old,0)){ //disired Status has since last loop
        statusRelay0Old = bitRead(relayLo,0); // save current status for the next loop to compare
        triggerSetRelay0Old = numberOfTriggerToReachTime; //set the counter to the desired time
        bitClear(PORTD, 5); //Digital Pin 5 On for Impulse
      }
      else if (triggerSetRelay0Old >= 1){ // if we have still somthing to count down
        triggerSetRelay0Old = triggerSetRelay0Old - 1;
        if (triggerSetRelay0Old == 0){ // reduce it by one and check if it was the last possible reduction
          bitSet(PORTD, 5); //Digital Pin 5 Off (opposite position)
        }
      }

      //Relay1
      if (bitRead(relayLo,1) != bitRead(statusRelay1Old,0)){ 
        statusRelay1Old = bitRead(relayLo,1); 
        triggerSetRelay1Old = numberOfTriggerToReachTime; 
        bitClear(PORTD, 6); 
      }
      else if (triggerSetRelay1Old >= 1){ 
        triggerSetRelay1Old = triggerSetRelay1Old - 1;
        if (triggerSetRelay1Old == 0){
          bitSet(PORTD, 6);
        }
      }
 
      //Relay2
      if (bitRead(relayLo,2) != bitRead(statusRelay2Old,0)){ 
        statusRelay2Old = bitRead(relayLo,2); 
        triggerSetRelay2Old = numberOfTriggerToReachTime; 
        bitClear(PORTD, 7); 
      }
      else if (triggerSetRelay2Old >= 1){ 
        triggerSetRelay2Old = triggerSetRelay2Old - 1;
        if (triggerSetRelay2Old == 0){
          bitSet(PORTD, 7); //
        }
      }

      //Relay3
      if (bitRead(relayLo,3) != bitRead(statusRelay3Old,0)){ 
        statusRelay3Old = bitRead(relayLo,3); 
        triggerSetRelay3Old = numberOfTriggerToReachTime; 
        bitClear(PORTB, 0); 
      }
      else if (triggerSetRelay3Old >= 1){
        triggerSetRelay3Old = triggerSetRelay3Old - 1; 
        if (triggerSetRelay3Old == 0){
          bitSet(PORTB, 0); 
        }
      }
  
      //Relay4
      if (bitRead(relayLo,4) != bitRead(statusRelay4Old,0)){ 
        statusRelay4Old = bitRead(relayLo,4); 
        triggerSetRelay4Old = numberOfTriggerToReachTime; 
        bitClear(PORTB, 1); 
      }
      else if (triggerSetRelay4Old >= 1){ 
        triggerSetRelay4Old = triggerSetRelay4Old - 1;
        if (triggerSetRelay4Old == 0){ 
          bitSet(PORTB, 1); 
        }
      }

      //Relay5
      if (bitRead(relayLo,5) != bitRead(statusRelay5Old,0)){ 
        statusRelay5Old = bitRead(relayLo,5); 
        triggerSetRelay5Old = numberOfTriggerToReachTime; 
        bitClear(PORTB, 2); 
      }
      else if (triggerSetRelay5Old >= 1){
        triggerSetRelay5Old = triggerSetRelay5Old - 1; 
        if (triggerSetRelay5Old == 0){ 
          bitSet(PORTB, 2); 
        }
      }

      //Relay6
      if (bitRead(relayLo,6) != bitRead(statusRelay6Old,0)){ 
        statusRelay6Old = bitRead(relayLo,6); 
        triggerSetRelay6Old = numberOfTriggerToReachTime; 
        bitClear(PORTB, 3); 
      }
      else if (triggerSetRelay6Old >= 1){ 
        triggerSetRelay6Old = triggerSetRelay6Old - 1;
        if (triggerSetRelay6Old == 0){ 
          bitSet(PORTB, 3); 
        }
      }

      //Relay7
      if (bitRead(relayLo,7) != bitRead(statusRelay7Old,0)){ 
        statusRelay7Old = bitRead(relayLo,7); 
        triggerSetRelay7Old = numberOfTriggerToReachTime; 
        bitClear(PORTB, 4); 
      }
      else if (triggerSetRelay7Old >= 1){ 
        triggerSetRelay7Old = triggerSetRelay7Old - 1;
        if (triggerSetRelay7Old == 0){ 
          bitSet(PORTB, 4); 
        }
      } 
    }
    else //active high
    {
      if (lowerTimer) bitSet(PORTD, LOWER); //Digital Pin D3
      else bitClear(PORTD, LOWER); 
  
      if (raiseTimer) bitSet(PORTD, RAISE); //Digital Pin D4
      else bitClear(PORTD, RAISE); 

      //Relay0
      if (bitRead(relayLo,0) != bitRead(statusRelay0Old,0)){ //disired Status has since last loop
        statusRelay0Old = bitRead(relayLo,0); // save current status for the next loop to compare
        triggerSetRelay0Old = numberOfTriggerToReachTime; //set the counter to the desired time
        bitSet(PORTD, 5); //Digital Pin 5 On for Impulse
      }
      else if (triggerSetRelay0Old >= 1){ // if we have still somthing to count down
        triggerSetRelay0Old = triggerSetRelay0Old - 1;
        if (triggerSetRelay0Old == 0){ // reduce it by one and check if it was the last possible reduction
          bitClear(PORTD, 5); //Digital Pin 5 Off (opposite position)
        }
      }

      //Relay1
      if (bitRead(relayLo,1) != bitRead(statusRelay1Old,0)){ 
        statusRelay1Old = bitRead(relayLo,1); 
        triggerSetRelay1Old = numberOfTriggerToReachTime; 
        bitSet(PORTD, 6); 
      }
      else if (triggerSetRelay1Old >= 1){ 
        triggerSetRelay1Old = triggerSetRelay1Old - 1;
        if (triggerSetRelay1Old == 0){
          bitClear(PORTD, 6);
        }
      }
 
      //Relay2
      if (bitRead(relayLo,2) != bitRead(statusRelay2Old,0)){ 
        statusRelay2Old = bitRead(relayLo,2); 
        triggerSetRelay2Old = numberOfTriggerToReachTime; 
        bitSet(PORTD, 7); 
      }
      else if (triggerSetRelay2Old >= 1){ 
        triggerSetRelay2Old = triggerSetRelay2Old - 1;
        if (triggerSetRelay2Old == 0){
          bitClear(PORTD, 7); //
        }
      }

      //Relay3
      if (bitRead(relayLo,3) != bitRead(statusRelay3Old,0)){ 
        statusRelay3Old = bitRead(relayLo,3); 
        triggerSetRelay3Old = numberOfTriggerToReachTime; 
        bitSet(PORTB, 0); 
      }
      else if (triggerSetRelay3Old >= 1){ 
        triggerSetRelay3Old = triggerSetRelay3Old - 1;
        if (triggerSetRelay3Old == 0){
          bitClear(PORTB, 0); 
        }
      }
  
      //Relay4
      if (bitRead(relayLo,4) != bitRead(statusRelay4Old,0)){ 
        statusRelay4Old = bitRead(relayLo,4); 
        triggerSetRelay4Old = numberOfTriggerToReachTime; 
        bitSet(PORTB, 1); 
      }
      else if (triggerSetRelay4Old >= 1){ 
        triggerSetRelay4Old = triggerSetRelay4Old - 1;
        if (triggerSetRelay4Old == 0){ 
          bitClear(PORTB, 1); 
        }
      }

      //Relay5
      if (bitRead(relayLo,5) != bitRead(statusRelay5Old,0)){ 
        statusRelay5Old = bitRead(relayLo,5); 
        triggerSetRelay5Old = numberOfTriggerToReachTime; 
        bitSet(PORTB, 2); 
      }
      else if (triggerSetRelay5Old >= 1){ 
        triggerSetRelay5Old = triggerSetRelay5Old - 1;
        if (triggerSetRelay5Old == 0){ 
          bitClear(PORTB, 2); 
        }
      }

      //Relay6
      if (bitRead(relayLo,6) != bitRead(statusRelay6Old,0)){ 
        statusRelay6Old = bitRead(relayLo,6); 
        triggerSetRelay6Old = numberOfTriggerToReachTime; 
        bitSet(PORTB, 3); 
      }
      else if (triggerSetRelay6Old >= 1){ 
        triggerSetRelay6Old = triggerSetRelay6Old - 1;
        if (triggerSetRelay6Old == 0){ 
          bitClear(PORTB, 3); 
        }
      }

      //Relay7
      if (bitRead(relayLo,7) != bitRead(statusRelay7Old,0)){ 
        statusRelay7Old = bitRead(relayLo,7); 
        triggerSetRelay7Old = numberOfTriggerToReachTime; 
        bitSet(PORTB, 4); 
      }
      else if (triggerSetRelay7Old >= 1){ 
        triggerSetRelay7Old = triggerSetRelay7Old - 1;
        if (triggerSetRelay7Old == 0){ 
          bitClear(PORTB, 4); 
        }
      } 
    }
  }
  
