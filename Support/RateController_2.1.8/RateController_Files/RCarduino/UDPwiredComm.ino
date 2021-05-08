#if(CommType == 1)
void SendUDPwired()
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

    //pwmSetting
    Temp = (byte)((pwmSetting[i] * 10) >> 8);
    toSend[i][8] = Temp;

    Temp = (byte)(pwmSetting[i] * 10);
    toSend[i][9] = Temp;

    //off to AOG
    ether.sendUdp(toSend[i], sizeof(toSend[i]), SourcePort, DestinationIP, DestinationPort);
  }
}
void ReceiveUDPwired(uint16_t dest_port, uint8_t src_ip[4], uint16_t src_port, byte* data, uint16_t len)

//void ReceiveUDPwired(uint16_t dest_port, uint8_t src_ip[IP_LEN], uint16_t src_port, byte* data, uint16_t len)
{
    PGN = data[0] << 8 | data[1];

    if (len > 9 && PGN == 32614)
    {
        byte tmp = data[2];

        if (ParseModID(tmp) == ModuleID)
        {
            byte SensorID = ParseSenID(tmp);
            if (SensorID < SensorCount)
            {
                RelayHi = data[3];
                RelayLo = data[4];

                // rate setting, 100 times actual
                UnSignedTemp = data[5] << 8 | data[6];
                float TmpSet = (float)UnSignedTemp * 0.01;

                // Meter Cal, 100 times actual
                UnSignedTemp = data[7] << 8 | data[8];
                MeterCal[SensorID] = (float)UnSignedTemp * 0.01;

                // command byte
                InCommand[SensorID] = data[9];
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
                CommTime[SensorID] = millis();
            }
        }
    }

    if (len > 9 && PGN == 32615)
    {
        byte tmp = data[2];
        if (ParseModID(tmp) == ModuleID)
        {
            byte SensorID = ParseSenID(tmp);
            if (SensorID < SensorCount)
            {
                VCN[SensorID] = data[3] << 8 | data[4];
                SendTime[SensorID] = data[5] << 8 | data[6];
                WaitTime[SensorID] = data[7] << 8 | data[8];
                VCNminPWM[SensorID] = data[9];

                watchdogTimer = 0;
                CommTime[SensorID] = millis();
            }
        }
    }

    if (len > 8 && PGN == 32616)
    {
        byte tmp = data[2];
        if (ParseModID(tmp) == ModuleID)
        {
            byte SensorID = ParseSenID(tmp);
            if (SensorID < SensorCount)
            {
                PIDkp[SensorID] = data[3];
                PIDminPWM[SensorID] = data[4];
                PIDLowMax[SensorID] = data[5];
                PIDHighMax[SensorID] = data[6];
                PIDdeadband[SensorID] = data[7];
                PIDbrakePoint[SensorID] = data[8];

                watchdogTimer = 0;
                CommTime[SensorID] = millis();
            }
        }
    }

    if (len > 3 && PGN == 32620)
    {
        // section switch IDs to arduino
        // 0    127
        // 1    108
        // 2    sec 0-3
        // 3    sec 4-7
        // 4    sec 8-11
        // 5    sec 12-15
        for (int i = 0; i < 4; i++)
        {
            SwitchBytes[i] = data[i + 2];
        }
        TranslateSwitchBytes();
    }
}
#endif
