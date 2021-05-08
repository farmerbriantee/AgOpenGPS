
   /*
    * This program only turns the relays for section control
    * On and Off. Connect to the Relay Port in AgOpenGPS
    */
    
  //loop time variables in microseconds

  #include <EEPROM.h> 
  #define EEP_Ident 0x4310  

    //Program counter reset
    void(* resetFunc) (void) = 0;

  //Variables for config - 0 is false  
  struct Config {
  uint8_t raiseTime = 2;
  uint8_t lowerTime = 4;
  uint8_t enableToolLift = 0;
  uint8_t isRelayActiveHigh = 0; //if zero, active low (default)
  
  };  Config aogConfig;   //4 bytes
  
  const uint8_t LOOP_TIME = 200; //5hz
  uint32_t lastTime = LOOP_TIME;
  uint32_t currentTime = LOOP_TIME;
  uint32_t fifthTime = 0;
  uint16_t count = 0;

  //Comm checks
  uint8_t watchdogTimer = 0; //make sure we are talking to AOG
  uint8_t serialResetTimer = 0; //if serial buffer is getting full, empty it
  
   //Communication with AgOpenGPS
  int16_t temp, EEread = 0;

   //Parsing PGN
  bool isPGNFound = false, isHeaderFound = false;
  uint8_t pgn = 0, dataLength = 0, idx = 0;
  int16_t tempHeader = 0;
  
  uint8_t AOG[] = {0x80,0x81, 0x7f, 0xED, 8, 0, 0, 0, 0, 0,0,0,0, 0xCC };

  //The variables used for storage
  uint8_t relayHi=0, relayLo = 0, gpsSpeed = 0, tramline = 0, tree = 0, uTurn = 0, hydLift = 0; 
 
  uint8_t raiseTimer = 0, lowerTimer = 0, lastTrigger = 0;
  
  //Raise and lower as D4 and D3
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
  uint16_t time = currentTime;

  if (currentTime - lastTime >= LOOP_TIME)
  {
    lastTime = currentTime;

    //If connection lost to AgOpenGPS, the watchdog will count up 
    if (watchdogTimer++ > 250) watchdogTimer = 12;

    //clean out serial buffer to prevent buffer overflow
    if (serialResetTimer++ > 20)
    {
      while (Serial.available() > 0) uint8_t t = Serial.read();
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

        AOG[5] = aogConfig.isRelayActiveHigh;
        AOG[6] = (uint8_t)relayLo;
        AOG[7] = (uint8_t)97;
        
        
        //add the checksum
        int16_t CK_A = 0;
        for (uint8_t i = 2; i < sizeof(AOG)-1; i++)
        {
          CK_A = (CK_A + AOG[i]);
        }
        AOG[sizeof(AOG)-1] = CK_A;
        
        Serial.write(AOG,sizeof(AOG));  
   /*     
    //Send data back to agopenGPS
    Serial.print(127); //steering switch status
    Serial.print(",");
    Serial.print(248); //steering switch status
    Serial.print(",");   
    Serial.println(relayLo); //steering switch status
  
    Serial.print(",");   
    Serial.print(lowerTimer); //steering switch status
    Serial.print(",");     
    Serial.print(hydLift); //steering switch status
    Serial.print(",");     
    Serial.print(aogConfig.isRelayActiveHigh); //steering switch status
    Serial.print(",0,0,0,");  
    Serial.println(0); 
*/
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

  // Serial Receive
  //Do we have a match with 0x8081?    
  if (Serial.available() > 4 && !isHeaderFound && !isPGNFound) 
  {
    uint8_t temp = Serial.read();
    if (tempHeader == 0x80 && temp == 0x81) 
    {
      isHeaderFound = true;
      tempHeader = 0;        
    }
    else  
    {
      tempHeader = temp;     //save for next time
      return;    
    }
  }

  //Find Source, PGN, and Length
  if (Serial.available() > 2 && isHeaderFound && !isPGNFound)
  {
    Serial.read(); //The 7F or less
    pgn = Serial.read();
    dataLength = Serial.read();
    isPGNFound = true;
    idx=0;
  } 

  //The data package
  if (Serial.available() > dataLength && isHeaderFound && isPGNFound)
  {
    if (pgn == 239) // EF Machine Data
    {
      uTurn = Serial.read();  
      tree = Serial.read();
      
      hydLift = Serial.read();
      tramline = Serial.read();  //actual speed times 4, single uint8_t
      
      //just get the rest of bytes
      Serial.read();   //high,low bytes   
      Serial.read();  
      
      relayLo = Serial.read();          // read relay control from AgOpenGPS
      relayHi = Serial.read();
      
      //Bit 13 CRC
      Serial.read();
      
      //reset watchdog
      watchdogTimer = 0;
  
      //Reset serial Watchdog  
      serialResetTimer = 0;        
      
      //reset for next pgn sentence
      isHeaderFound = isPGNFound = false;
      pgn=dataLength=0;                  
    }
            
    else if (pgn==238) //EE Machine Settings 
    {         
      aogConfig.raiseTime = Serial.read();
      aogConfig.lowerTime = Serial.read();    
      aogConfig.enableToolLift = Serial.read();
      
      //set1 
      uint8_t sett = Serial.read();  //setting0     
      if (bitRead(sett,0)) aogConfig.isRelayActiveHigh = 1; else aogConfig.isRelayActiveHigh = 0;
      
      Serial.read();
      Serial.read();
      Serial.read();
      Serial.read();    

      //crc
      //udpData[13];        //crc
      Serial.read();
  
      //save in EEPROM and restart
      EEPROM.put(6, aogConfig);
      resetFunc();

      //reset for next pgn sentence
      isHeaderFound = isPGNFound = false;
      pgn=dataLength=0;
    }
    else
    {
      isHeaderFound = isPGNFound = false;
      pgn=dataLength=0;   
    }
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
    else //active high
    {
      if (lowerTimer) bitSet(PORTD, LOWER); //Digital Pin D3
      else bitClear(PORTD, LOWER); 
  
      if (raiseTimer) bitSet(PORTD, RAISE); //Digital Pin D4
      else bitClear(PORTD, RAISE); 
 
      if (bitRead(relayLo,0)) bitSet(PORTD, 5); //Digital Pin 5
      else bitClear(PORTD, 5); 
      if (bitRead(relayLo,1)) bitSet(PORTD, 6); //Digital Pin 6
      else bitClear(PORTD, 6); 
      if (bitRead(relayLo,2)) bitSet(PORTD, 7); //Digital Pin 7
      else bitClear(PORTD, 7); 
      if (bitRead(relayLo,3)) bitSet(PORTB, 0); //Digital Pin 8
      else bitClear(PORTB, 0); 
      if (bitRead(relayLo,4)) bitSet(PORTB, 1); //Digital Pin 9
      else bitClear(PORTB, 1); 
      if (bitRead(relayLo,5)) bitSet(PORTB, 2); //Digital Pin 10
      else bitClear(PORTB, 2); 
      if (bitRead(relayLo,6)) bitSet(PORTB, 3); //Digital Pin 11
      else bitClear(PORTB, 3); 
      if (bitRead(relayLo,7)) bitSet(PORTB, 4); //Digital Pin 12
      else bitClear(PORTB, 4); 
    }
  }
  
