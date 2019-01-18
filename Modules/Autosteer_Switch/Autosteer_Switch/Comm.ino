//#################################################################################
#if (Ethernet==0)  // Ethernet off = Serial/USB Mode
void transmitSerial(){
 //Send to agopenGPS **** you must send 5 numbers ****
 Serial.print(steerAngleActual); //The actual steering angle in degrees
 Serial.print(",");
 Serial.print(steerAngleSetPoint);   //the pwm value to solenoids or motor
 Serial.print(",");

  // *******  if there is no gyro installed send 9999
  #if IMU_Installed
    Serial.print(IMU.euler.head);       //heading in degrees * 16
  #else
    Serial.print(9999);                 //No IMU installed
  #endif
    Serial.print(",");

    //*******  if no roll is installed, send 9999
  #if Inclinometer_Installed !=0
    Serial.print((int)XeRoll);          //roll in degrees * 16
  #else
    Serial.print(9999);                 //no Dogs installed
     //Serial.print(steeringPosition);  // Just for first Setup, to check the ADC output (comment out previous 2 lines to use this)
  #endif

    Serial.print(",");

    Serial.println(switchByte); //steering switch status

    Serial.flush();   // flush out buffer
}

//#################################################################################
void receiveSerial(){
  //This runs continuously, outside of the timed loop, keeps checking UART for new data
  // header high/low, relay byte, speed byte, high distance, low distance, Steer high, steer low
  
  if (Serial.available() > 0 && !isDataFound && !isSettingFound) //find the header, 127H + 254L = 32766
  {
    int temp = Serial.read();
    header = tempHeader << 8 | temp;               //high,low bytes to make int
    tempHeader = temp;                             //save for next time
    if (header == 32766) isDataFound = true;     //Do we have a match?
    if (header == 32764) isSettingFound = true;     //Do we have a match?
  }

  //Data Header has been found, so the next 6 bytes are the data
  if (Serial.available() > 6 && isDataFound)
  {
    isDataFound = false;
    relay = Serial.read();   // read relay control from AgOpenGPS
    speeed = Serial.read() >> 2;  //actual speed times 4, single byte

    //distance from the guidance line in mm
    distanceFromLine = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes

    //set point steer angle * 10 is sent
    steerAngleSetPoint = ((float)(Serial.read() << 8 | Serial.read()))*0.01; //high low bytes

    //auto Steer is off if 32020,Speed is too slow, motor pos or footswitch open
    if (distanceFromLine == 32020 | speeed < 1 | steerSwitch == 1)
      {
       watchdogTimer = 12; //turn off steering motor
       digitalWrite(LED_PIN, 0); //turn LED off
      }
    else          //valid conditions to turn on autosteer
      {
       digitalWrite(LED_PIN, 1);   //turn LED on
       watchdogTimer = 0;  //reset watchdog
       serialResetTimer = 0; //if serial buffer is getting full, empty it
      }

    //uturn byte read in
    uTurn = Serial.read();
  }

  //Settings Header has been found, 8 bytes are the settings
  if (Serial.available() > 7 && isSettingFound)
  {
    isSettingFound = false;  //reset the flag
    //change the factors as required for your own PID values
    steerSettings.Kp = (float)Serial.read() * 1.0;   // read Kp from AgOpenGPS
    steerSettings.Ki = (float)Serial.read() * 0.001;   // read Ki from AgOpenGPS
    steerSettings.Kd = (float)Serial.read() * 1.0;   // read Kd from AgOpenGPS
    steerSettings.Ko = (float)Serial.read() * 0.1;   // read Ko from AgOpenGPS
    byte offset = Serial.read();
    steerSettings.steeringPositionZero = (SteerPosZero-127) + offset;  //read steering zero offset
    steerZero = (SteerPosZero-127) + 2 * offset; //double offset for JRK
    steerSettings.minPWMValue = Serial.read(); //read the minimum amount of PWM for instant on
    steerSettings.maxIntegralValue = Serial.read()*0.1; //
    steerSettings.steerSensorCounts = Serial.read(); //sent as 10 times the setting displayed in AOG
    EEPROM.put(8, steerSettings);
  }
}
#endif //Serial/USB Mode

//#################################################################################
#if (EtherNet)
 void transmitEthernet(){
 //Build return data
    int temp;
    //actual steer angle
    temp = (100 * steerAngleActual);
    toSend[2] = (byte)(temp >> 8);
    toSend[3] = (byte)(temp);

#if IMU_Installed
    //imu heading --- * 16 in degrees
    temp = IMU.euler.head;
    toSend[4] = (byte)(temp >> 8);
    toSend[5] = (byte)(temp);
#else
    temp = 0;              //No IMU installed
    toSend[4] = (byte)(temp >> 8);
    toSend[5] = (byte)(temp);
#endif  

#if Inclinometer_Installed !=0
    //Vehicle roll --- * 16 in degrees
    temp = XeRoll;
    toSend[6] = (byte)(temp >> 8);
    toSend[7] = (byte)(temp);
#endif
        
    //switch byte
    toSend[8] = switchByte;

    //off to AOG
    ether.sendUdp(toSend, sizeof(toSend), portMy, ipDestination, portDestination); 
}

//#################################################################################
//callback when received packets
void udpSteerRecv(uint16_t dest_port, uint8_t src_ip[IP_LEN], uint16_t src_port, byte *data, uint16_t len)
{
  /* IPAddress src(src_ip[0],src_ip[1],src_ip[2],src_ip[3]); 
  Serial.print("dPort:");  Serial.print(dest_port);
  Serial.print("  sPort: ");  Serial.print(src_port); 
  Serial.print("  sIP: ");  ether.printIp(src_ip);  Serial.println("  end");*/

  //for (int i = 0; i < len; i++) {
    //Serial.print(data[i],HEX); Serial.print("\t"); } Serial.println(len);

    if (data[0] == 0x7F && data[1] == 0xFE) //Data
    {
      relay = data[2];   // read relay control from AgOpenGPS     
      speeed = data[3] >> 2;  //actual speed times 4, single byte
  
      //distance from the guidance line in mm
      distanceFromLine = (float)(data[4] << 8 | data[5]);   //high,low bytes     
  
      //set point steer angle * 10 is sent
      steerAngleSetPoint = ((float)(data[6] << 8 | data[7])); //high low bytes 
      steerAngleSetPoint *= 0.01;  

      if (distanceFromLine == 32020 | speeed < 1 | steerSwitch == 1)
      {
        watchdogTimer = 12;//turn off steering motor
        digitalWrite(LED_PIN, 0); //turn LED off
      }
      else          //valid conditions to turn on autosteer
      {
        digitalWrite(LED_PIN, 1);   //turn LED on
        watchdogTimer = 0;  //reset watchdog
      }
      uTurn = 0; // no uTurn byte with Ethernet Mode
      /*    
      Serial.print(steerAngleActual);   //the pwm value to solenoids or motor
      Serial.print(",");
      Serial.println(XeRoll);
       */
    }

    //autosteer settings
    if (data[0] == 0x7F && data[1] == 0xFC)
    {
      steerSettings.Kp = (float)data[2] * 1.0;       // read Kp from AgOpenGPS
      steerSettings.Ki = (float)data[3] * 0.001;     // read Ki from AgOpenGPS
      steerSettings.Kd = (float)data[4] * 1.0;       // read Kd from AgOpenGPS
      steerSettings.Ko = (float)data[5] * 0.1;       // read Ko from AgOpenGPS
      steerSettings.steeringPositionZero = (SteerPosZero-127) + data[6];//read steering zero offset  
      steerZero = (SteerPosZero-127) + 2 * data[6];  //double offset for JRK
      
      steerSettings.minPWMValue = data[7]; //read the minimum amount of PWM for instant on
      steerSettings.maxIntegralValue = data[8]*0.1; //
      steerSettings.steerSensorCounts = data[9]; //sent as 10 times the setting displayed in AOG
      
      EEPROM.put(8, steerSettings);
      
      //for (int i = 0; i < len; i++) {
        //Serial.print(data[i],HEX); Serial.print("\t"); } Serial.println("<--");
      // }
    }
}
#endif //ethernet
