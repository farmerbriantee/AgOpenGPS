#if(CommType == 2)
void SendUDPWifi()
{
  // PGN 32613
  // header
  for (int i = 0; i < SensorCount; i++)
  {
    toSend[i][0] = 127;
    toSend[i][1] = 101;

    toSend[i][2] = BuildModSenID(ModuleID, i);

    // rate applied, 100 X actual
    Temp = (int)(UPM[i] * 100) >> 8;
    toSend[i][3] = Temp;
    Temp = (UPM[i] * 100);
    toSend[i][4] = Temp;

    // accumulated quantity, 3 bytes
    long Units = TotalPulses[i] * 100.0 / MeterCal[i];
    Temp = Units >> 16;
    toSend[i][5] = Temp;
    Temp = Units >> 8;
    toSend[i][6] = Temp;
    Temp = Units;
    toSend[i][7] = Temp;

    // pwmSetting
    Temp = (byte)((pwmSetting[i] * 10) >> 8);
    toSend[i][8] = Temp;

    Temp = (byte)(pwmSetting[i] * 10);
    toSend[i][9] = Temp;

    //off to AOG
    UDPout.beginPacket(DestinationIP, DestinationPort);
    UDPout.write(toSend[i], sizeof(toSend[i]));
    UDPout.endPacket();
    UDPout.flush();
  }
}

void ReceiveUDPWifi()
{
  //delay(50);	// prevent wifi lockup
  int PacketSize = UDPin.parsePacket();	// get packet
  if (PacketSize)
  {
    int len = UDPin.read(InBuffer, 150);
    PGN = (InBuffer[0] << 8) | InBuffer[1];

    if (len > 9)
    {
      if (PGN == 32614)
      {
        byte tmp = InBuffer[2];
        if (ParseModID(tmp) == ModuleID)
        {
          byte SensorID = ParseSenID(tmp);
          if (SensorID < SensorCount)
          {
              RelayHi = InBuffer[3];
              RelayLo = InBuffer[4];

              // rate setting, 100 times actual
              UnSignedTemp = InBuffer[5] << 8 | InBuffer[6];
              float TmpSet = (float)UnSignedTemp * 0.01;

              // Meter Cal, 100 times actual
              UnSignedTemp = InBuffer[7] << 8 | InBuffer[8];
              MeterCal[SensorID] = (float)UnSignedTemp * 0.01;

              // command byte
              InCommand[SensorID] = InBuffer[9];
              if ((InCommand[SensorID] & 1) == 1) TotalPulses[SensorID] = 0;	// reset accumulated count

              ControlType[SensorID] = 0;
              if ((InCommand[SensorID] & 2) == 2) ControlType[SensorID] += 1;
              if ((InCommand[SensorID] & 4) == 4) ControlType[SensorID] += 2;

              SimulateFlow[SensorID] = ((InCommand[SensorID] & 8) == 8);

              UseVCN[SensorID] = ((InCommand[SensorID] & 16) == 16);

              AutoOn = ((InCommand[SensorID] & 32) == 32);
              if (AutoOn)
              {
                  RateSetting[SensorID] = TmpSet;
              }
              else
              {
                  NewRateFactor[SensorID] = TmpSet;
              }

              //reset watchdog as we just heard from AgOpenGPS
              watchdogTimer = 0;
              CommTime[SensorID] = true;
          }
        }
      }

      if (PGN == 32615)
      {
        byte tmp = InBuffer[2];
        if (ParseModID(tmp) == ModuleID)
        {
          byte SensorID = ParseSenID(tmp);
          if (SensorID < SensorCount)
          {
              VCN[SensorID] = InBuffer[3] << 8 | InBuffer[4];
              SendTime[SensorID] = InBuffer[5] << 8 | InBuffer[6];
              WaitTime[SensorID] = InBuffer[7] << 8 | InBuffer[8];
              VCNminPWM[SensorID] = InBuffer[9];

              watchdogTimer = 0;
              CommTime[SensorID] = true;
          }
        }
      }

      if (PGN == 32616)
      {
        byte tmp = InBuffer[2];
        if (ParseModID(tmp) == ModuleID)
        {
          byte SensorID = ParseSenID(tmp);
          if (SensorID < SensorCount)
          {
              PIDkp[SensorID] = InBuffer[3];
              PIDminPWM[SensorID] = InBuffer[4];
              PIDLowMax[SensorID] = InBuffer[5];
              PIDHighMax[SensorID] = InBuffer[6];
              PIDdeadband[SensorID] = InBuffer[7];
              PIDbrakePoint[SensorID] = InBuffer[8];

              watchdogTimer = 0;
              CommTime[SensorID] = true;
          }
        }
      }

      if (PGN == 32620)
      {
          // section switch IDs to arduino
          // 0    127
          // 1    108
          // 2    sec 0-3
          // 3    sec 4-7
          // 4    sec 8-11
          // 5    sec 12-16
          for (int i = 0; i < 4; i++)
          {
              SwitchBytes[i] = InBuffer[i + 2];
          }
          TranslateSwitchBytes();
      }

    }
  }
}

void CheckWifi()
{
  if (millis() - CheckTime > 5000)
  {
    Serial.println();
    ConnectionStatus = WiFi.status();
    Serial.println("Wifi status: " + String(ConnectionStatus));
    Serial.print("RSSI: ");
    Serial.println(WiFi.RSSI());

    if ((ConnectionStatus != WL_CONNECTED) || (WiFi.RSSI() <= -100) || (WiFi.RSSI() == 0))
    {
        Serial.print("Connecting to ");
        Serial.println(ssid);

      ConnectionStatus = WiFi.begin(ssid, pass);
      delay(5000);
      ReconnectCount++;
      ConnectedCount = 0;
    }
    else
    {
      ConnectedCount++;
      CheckTime = millis();
    }
    Serial.print("Reconnect count: ");
    Serial.println(ReconnectCount);
    Serial.print("Connected count: ");
    Serial.println(ConnectedCount);
    Serial.print("Minutes connected: ");
    Serial.println(ConnectedCount * 5 / 60);

    IPAddress ip = WiFi.localIP();
    Serial.print("IP Address: ");
    Serial.println(ip);
  }
}
#endif
