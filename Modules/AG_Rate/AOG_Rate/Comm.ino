//#################################################################################
#if (Ethernet==0)  // Ethernet off = Serial/USB Mode
void transmitSerial(){
  
   //Send to agopenGPS
    Serial.print(rateAppliedLPMLeft); //100 x actual!
    Serial.print(",");
    Serial.print(rateAppliedLPMRight); //100 x actual!
    Serial.print(",");
    Serial.print((int)((float)accumulatedCountsLeft / (float)flowmeterCalFactorLeft +
      (float)accumulatedCountsRight / (float)flowmeterCalFactorRight));
    
    Serial.print(",");
    Serial.print(RelayToAOG[1]);
    Serial.print(",");
    Serial.print(RelayToAOG[0]);
    Serial.print(",");
    Serial.print(SectSWOffToAOG[1]);
    Serial.print(",");
    Serial.print(SectSWOffToAOG[0]);
    Serial.print(",");
    Serial.print(SectMainToAOG);
    Serial.println();
    // flush out buffer
    Serial.flush();
}

//#################################################################################
void receiveSerial(){
  //This runs continuously, outside of the timed loop, keeps checking UART for new data
  // header high/low, relay byte, speed byte, high distance, low distance, Steer high, steer low

if (Serial.available() > 0 && !isDataFound && !isSettingFound) //find the header,
  {
    int temp = Serial.read();
    header = tempHeader << 8 | temp;               //high,low bytes to make int
    tempHeader = temp;                             //save for next time
    if (header == 32762) isDataFound = true;     //Do we have a match?    (0x7FFA)
    if (header == 32760) isSettingFound = true;     //Do we have a match? (0x7FF8)
  }

  //DATA Header has been found, so the next 4 bytes are the data -- 127H + 250L = 32762 (0x7FFA)
  if (Serial.available() == 8 && isDataFound)
  {
    isDataFound = false;
    relayHi = Serial.read();   // read relay control from AgOpenGPS
    relayLo = Serial.read();   // read relay control from AgOpenGPS
    groundSpeed = Serial.read() >> 2;  //actual speed times 4, single byte

    // sent as 100 times value in liters per minute
    rateSetPointLeft = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes
    rateSetPointLeft *= 0.01;
    rateSetPointRight = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes
    rateSetPointRight *= 0.01;

    //UTurn byte
    uTurn = Serial.read();

    //reset watchdog as we just heard from AgOpenGPS
    watchdogTimer = 0;
  }

  //SETTINGS Header has been found,  6 bytes are the settings -- 127H + 248L = 32760 (0x7FF8)
  if (Serial.available() == 6 && isSettingFound)
  {
    isSettingFound = false;  //reset the flag

    //accumulated volume, 0 it if 32700 is sent
    float tempf = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes
    if (tempf == 32700)
    {
      accumulatedCountsLeft = 0;
      accumulatedCountsRight = 0;
    }

    //flow meter cal factor in counts per Liter
    flowmeterCalFactorLeft = ((float)(Serial.read() << 8 | Serial.read()));   //high,low bytes
    flowmeterCalFactorRight = ((float)(Serial.read() << 8 | Serial.read()));   //high,low bytes
  }
}
#endif //Serial/USB Mode

//#################################################################################
#if (EtherNet)
 void transmitEthernet(){
    //set up the pgn for returning data for AG_Rate
    toSend[0] = 0x7F;
    toSend[1] = 0xF9;
    //Build return data
    toSend[2] = rateAppliedLPMLeft; //100 x actual!;
    toSend[3] = rateAppliedLPMRight; //100 x actual!
    toSend[4] = (int)((float)accumulatedCountsLeft / flowmeterCalFactorLeft)
       + (int)((float)accumulatedCountsRight / flowmeterCalFactorRight);
    toSend[5] = RelayToAOG[1];  //if bit set -> AOG section forced ON
    toSend[6] = RelayToAOG[0];  //if bit set -> AOG section forced ON
    toSend[7] = SectSWOffToAOG[1]; //HiByte if bit set -> AOG section forced off
    toSend[8] = SectSWOffToAOG[0]; //LowByte if bit set -> AOG section forced off
    toSend[9] = SectMainToAOG; // Bits: AOG section control AUTO, Section control OFF, Rate L+R ...

    //off to AOG
    ether.sendUdp(toSend, sizeof(toSend), portMy, ipDestination, portDestination); 
      
    //print for debug
    Serial.print("Bytes to AOG: ");
    for (byte i = 0; i < 10; i++) {
      Serial.print(toSend[i]);
      Serial.print(",");
    }
    Serial.println();
    Serial.flush();   // flush out buffer
}

//#################################################################################
//callback when received packets
void udpRateRecv(uint16_t dest_port, uint8_t src_ip[IP_LEN], uint16_t src_port, byte *data, uint16_t len)
{
    //Rate Data
    if (data[0] == 0x7F && data[1] == 0xFA) //Data
    {
      relayHi = data[2];   // read relay control from AgOpenGPS
      relayLo = data[3];   // read relay control from AgOpenGPS
      
      groundSpeed = data[4] >> 2;  //actual speed times 4, single byte

      // sent as 100 times value in liters per minute 
      rateSetPointLeft = (float)(data[5] << 8 | data[6]);   //high,low bytes
      rateSetPointLeft *= 0.01;
      rateSetPointRight = (float)(data[7] << 8 | data[8]);   //high,low bytes
      rateSetPointRight *= 0.01;

      //UTurn byte
      uTurn = data[9];

      //reset watchdog as we just heard from AgOpenGPS
      watchdogTimer = 0;
    }

    //Rate settings
    if (data[0] == 0x7F && data[1] == 0xF8)
    {
      //accumulated volume, 0 it if 32700 is sent
      float tempf = (float)(data[2] << 8 | data[3]);   //high,low bytes
      if (tempf == 32700)
      {
        accumulatedCountsLeft = 0;
        accumulatedCountsRight = 0;
      }

      //flow meter cal factor in counts per Liter
      flowmeterCalFactorLeft = ((float)(data[4] << 8 | data[5]));   //high,low bytes
      flowmeterCalFactorRight = ((float)(data[6] << 8 | data[7]));   //high,low bytes 
    }
}
#endif //ethernet
