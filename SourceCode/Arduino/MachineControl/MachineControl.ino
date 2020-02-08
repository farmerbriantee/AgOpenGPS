
   /*
    * This program only turns the relays for section control
    * On and Off. Connect to the Relay Port in AgOpenGPS
    */
    
  //loop time variables in microseconds

  #include <EEPROM.h> 
  #define EEP_Ident 0xEDF7  

      //Variables for config - 0 is false  
   struct Config {
      byte raiseTime = 2;
      byte lowerTime = 4;
      byte enableToolLift = 0;
  };  Config aogConfig;   //3 bytes
  
  const byte LOOP_TIME = 200; //5hz
  unsigned long lastTime = LOOP_TIME;
  unsigned long currentTime = LOOP_TIME;
  unsigned long fifthTime = 0;
  unsigned int count = 0;

  //Comm checks
  byte watchdogTimer = 0; //make sure we are talking to AOG
  byte serialResetTimer = 0; //if serial buffer is getting full, empty it
  
   //Communication with AgOpenGPS
  bool isDataFound = false, isSettingFound = false, isAogConfigFound = false;
  int header = 0, tempHeader = 0, temp, EEread = 0;

  //The variables used for storage
  byte relayHi=0, relayLo = 0, gpsSpeed = 0, tramline = 0, tree = 0, uTurn = 0, hydLift = 0; 

  byte raiseTimer = 0, lowerTimer = 0, lastTrigger = 0;
  
  //define pin 5 as Section 1 control aka PortD bit 5, hence D5
  #define RAISE 4
  #define LOWER 3
 
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
  unsigned int time = currentTime;

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

    //section relays
    SetRelays();
    
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

    //countdown if not zero
    if (lowerTimer) lowerTimer--; 
    if (raiseTimer) raiseTimer--;

    //if anything wrong, shut off hydraulics, reset last
    if ((hydLift != 1 && hydLift != 2) || watchdogTimer > 10 ) //|| gpsSpeed < 2)
    {
      lowerTimer = 0;
      raiseTimer = 0;
      lastTrigger = 0;
    }
      
    if (lowerTimer) bitClear(PORTD, LOWER); //Digital Pin D3
    else bitSet(PORTD, LOWER); 

    if (raiseTimer) bitClear(PORTD, RAISE); //Digital Pin D4
    else bitSet(PORTD, RAISE); 

    //Send data back to agopenGPS **** you must send 5 words ****

    Serial.print(lowerTimer); //steering switch status
   Serial.print(",");
    
   Serial.print(raiseTimer); //steering switch status
    Serial.print(",");
    
   Serial.print(gpsSpeed); //steering switch status
    Serial.print(",");
    
   Serial.print(hydLift); //steering switch status
    Serial.print(",");
    
   Serial.print(lastTrigger); //steering switch status
    Serial.print(",");
    
   Serial.println(aogConfig.lowerTime); //steering switch status 
      
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
    
    Serial.read();   
    Serial.read();
    Serial.read();
    Serial.read();
    Serial.read();
  }
}

  void SetRelays(void)
 {
    if (bitRead(relayLo,0)) bitClear(PORTD, 5); //Digital Pin 5
    else bitSet(PORTD, 5); 
    if (bitRead(relayLo,1)) bitClear(PORTD, 6); //Digital Pin 6
    else bitSet(PORTD, 6); 
    if (bitRead(relayLo,2)) bitClear(PORTD, 7); //Digital Pin 7
    else bitSet(PORTD, 7); 
    if (bitRead(relayLo,3)) bitClear(PORTB, 0); //Digital Pin 8
    else bitSet(PORTB, 0); 
    if (bitRead(relayLo,4)) bitClear(PORTB, 1); //Digital Pin 9
    else bitSet(PORTB, 1); 
    if (bitRead(relayLo,5)) bitClear(PORTB, 2); //Digital Pin 10
    else bitSet(PORTB, 2); 
    if (bitRead(relayLo,6)) bitClear(PORTB, 3); //Digital Pin 11
    else bitSet(PORTB, 3); 
    if (bitRead(relayLo,7)) bitClear(PORTB, 4); //Digital Pin 12
    else bitSet(PORTB, 4); 
  }
  
