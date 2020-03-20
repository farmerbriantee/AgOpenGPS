
   /*
    * This program only turns the relays for section control
    * On and Off. Connect to the Relay Port in AgOpenGPS
    */
    
  //ethercard 10,11,12,13  
  // Arduino Nano = 10 depending how CS of Ethernet Controller ENC28J60 is Connected
  #define CS_Pin 10 
  
  //define pin 5 as Section 1 control aka PortD bit 5, hence D5
  #define RAISE 4
  #define LOWER 5
  
  #include <EEPROM.h> 

  //this version
  #define EEP_Ident 0xEDC0  

    #include "EtherCard_AOG.h"
    #include <IPAddress.h> 
  
    //Array to send data back to AgOpenGPS
    byte toSend[] = {0,0,0,0,0,0,0,0,0,0};
  
    // ethernet interface ip address
    static byte myip[] = { 192,168,1,76 };
    // gateway ip address
    static byte gwip[] = { 192,168,1,1 };
    //DNS- you just need one anyway
    static byte myDNS[] = { 8,8,8,8 };
    //mask
    static byte mask[] = { 255,255,255,0 };
    //this is port of this autosteer module
    unsigned int portMy = 5555; 
  
    //sending back to where and which port
    static byte ipDestination[] = {192, 168, 1, 255};
    unsigned int portDestination = 9999; //AOG port that listens
    
    // ethernet mac address - must be unique on your network
    static byte mymac[] = { 0x70,0x69,0x67,0x20,0x30,0x30 };
    
    byte Ethernet::buffer[200]; // udp send and receive buffer

    //program counter form of reset
    void(* resetFunc) (void) = 0;

      //Variables for config - 0 is false  
   struct Config {
      byte raiseTime = 2;
      byte lowerTime = 4;
      byte enableToolLift = 0;
  };  Config aogConfig;   //3 bytes
  
  //loop time variables in microseconds
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
  
 
void setup()
  {
    //set the baud rate
     Serial.begin(38400);  
     
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

  pinMode(6, OUTPUT);
  pinMode(7, OUTPUT);
  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);

     if (ether.begin(sizeof Ethernet::buffer, mymac, CS_Pin) == 0)
      Serial.println(F("Failed to access Ethernet controller"));
  
    //set up connection
    ether.staticSetup(myip, gwip, myDNS, mask); 
    ether.printIp("IP:  ", ether.myip);
    ether.printIp("GW:  ", ether.gwip);
    ether.printIp("DNS: ", ether.dnsip);
  
    //set up the pgn for returning data for autosteer
    toSend[0] = 0x7F;
    toSend[1] = 0xF8;
    
    //register udpSerialPrint() to port 8888
    ether.udpServerListenOnPort(&udpMachineRecv, 8888);
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
      
    if (lowerTimer) bitClear(PORTD, LOWER); //Digital Pin D4
    else bitSet(PORTD, LOWER); 

    if (raiseTimer) bitClear(PORTD, RAISE); //Digital Pin D5
    else bitSet(PORTD, RAISE); 

    //nothing to really send back
    toSend[2] = hydLift;

    //off to AOG
    ether.sendUdp(toSend, sizeof(toSend), portMy, ipDestination, portDestination);

    //Send data back to agopenGPS **** you must send 5 words ****
/*
    Serial.print(relayHi); //steering switch status
   Serial.print(",");    
   Serial.print(relayLo); //steering switch status
    Serial.print(",");    
   Serial.println(gpsSpeed); //steering switch status
   
    Serial.print(",");    
   Serial.print(hydLift); //steering switch status
    Serial.print(",");    
   Serial.print(lastTrigger); //steering switch status
    Serial.print(",");    
   Serial.println(aogConfig.lowerTime); //steering switch status 
   */
      
   Serial.flush();   // flush out buffer   
   
  } //end of timed loop
  
   delay(10);     
    //this must be called for ethercard functions to work. Calls udpMachineRecv() defined way below.
    ether.packetLoop(ether.packetReceive()); 
}

  //****************************************************************************************

//callback when received packets
void udpMachineRecv(uint16_t dest_port, uint8_t src_ip[IP_LEN], uint16_t src_port, byte *data, uint16_t len)
{
  /* IPAddress src(src_ip[0],src_ip[1],src_ip[2],src_ip[3]); 
  Serial.print("dPort:");  Serial.print(dest_port);
  Serial.print("  sPort: ");  Serial.print(src_port); 
  Serial.print("  sIP: ");  ether.printIp(src_ip);  Serial.println("  end");*/

  //for (int i = 0; i < len; i++) {
  //Serial.print(data[i],HEX); Serial.print("\t"); } Serial.println(len);

  if (data[0] == 0x7F && data[1] == 0xFA) //Data
  {
    isDataFound = false;
    relayHi = data[2];
    relayLo = data[3];          // read relay control from AgOpenGPS
    gpsSpeed = data[4] >> 2;  //actual speed times 4, single byte
    uTurn = data[5];  
    tree = data[6];
    hydLift = data[7];

    //reset watchdog
    watchdogTimer = 0;

    //Reset serial Watchdog  
    serialResetTimer = 0;
  }

   //Arduino Config Header has been found, so the next 8 bytes are the data
  if (data[0] == 0x7F && data[1] == 0xF8) //Config
  { 
    aogConfig.raiseTime = data[2];
    aogConfig.lowerTime = data[3]; 
    aogConfig.enableToolLift = data[4];

    EEPROM.put(6, aogConfig);
    resetFunc();
  }
}

  void SetRelays(void)
 {
    if (bitRead(relayLo,0)) bitClear(PORTD, 6); //Digital Pin 6
    else bitSet(PORTD, 6); 
    if (bitRead(relayLo,1)) bitClear(PORTD, 7); //Digital Pin 7
    else bitSet(PORTD, 7); 
    if (bitRead(relayLo,2)) bitClear(PORTB, 0); //Digital Pin 8
    else bitSet(PORTB, 0); 
    if (bitRead(relayLo,3)) bitClear(PORTB, 1); //Digital Pin 9
    else bitSet(PORTB, 1); 
  }
  
