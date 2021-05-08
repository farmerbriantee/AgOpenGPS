
//PGN32613 to Rate Controller from Arduino
//0	HeaderHi		127
//1	HeaderLo		101
//2 Controller ID
//3	rate applied Hi		100 X actual
//4	rate applied Lo
//5	acc.Quantity byte 3		100 X actual
//6	acc.Quantity byte 2
//7	acc.Quantity byte 1
//8 PWM Hi
//9 PWM Lo

void SendSerial()
{
  for (int i = 0; i < SensorCount; i++)
  {
    // PGN 32613
    Serial.print(127);	// headerHi
    Serial.print(",");
    Serial.print(101);	// headerLo
    Serial.print(",");

    Serial.print(BuildModSenID(ModuleID, i));
    Serial.print(",");

    // rate applied, 100 X actual
    Temp = (int)(UPM[i] * 100) >> 8;
    Serial.print(Temp);
    Serial.print(",");
    Temp = (UPM[i] * 100);
    Serial.print(Temp);
    Serial.print(",");

    // accumulated quantity, 3 bytes
    long Units = TotalPulses[i] * 100.0 / MeterCal[i];
    Temp = Units >> 16;
    Serial.print(Temp);
    Serial.print(",");
    Temp = Units >> 8;
    Serial.print(Temp);
    Serial.print(",");
    Temp = Units;
    Serial.print(Temp);
    Serial.print(",");

    // pwmSetting
    Temp = (byte)((pwmSetting[i] * 10) >> 8);
    Serial.print(Temp);
    Serial.print(",");

    Temp = (byte)(pwmSetting[i] * 10);
    Serial.print(Temp);

    Serial.println();
    Serial.flush();   // flush out buffer
  }
}

//PGN32614 to Arduino from Rate Controller
//0	HeaderHi		127
//1	HeaderLo		102
//2 Controller ID
//3	relay Hi		8 - 15
//4	relay Lo		0 - 7
//5	rate set Hi		100 X actual
//6	rate set Lo		100 X actual
//7	Flow Cal Hi		100 X actual
//8	Flow Cal Lo		100 X actual
//9	Command
//- bit 0		reset acc.Quantity
//- bit 1, 2		valve type 0 - 3
//- bit 3		simulate flow
//
//PGN32615 to Arduino from Rate Controller
// 0 HeaderHi       127
// 1 HeaderLo       103
// 2 Controller ID
// 3 VCN Hi         Valve Cal Number
// 4 VCN Lo
// 5 Send Hi        ms sending pwm
// 6 Send Lo
// 7 Wait Hi        ms to wait before sending pwm again
// 8 Wait Lo
// 9 Min PWM

void ReceiveSerial()
{
    if (Serial.available() > 0 && !PGN32614Found && !PGN32615Found && !PGN32616Found
        && !PGN32619Found && !PGN32620Found) //find the header
    {
        LSB = Serial.read();
        PGN = MSB << 8 | LSB;               //high,low bytes to make int
        
        MSB = LSB;                          //save for next time
        PGN32614Found = (PGN == 32614);
        PGN32615Found = (PGN == 32615);
        PGN32616Found = (PGN == 32616);
        PGN32619Found = (PGN == 32619);
        PGN32620Found = (PGN == 32620);
    }

    if (Serial.available() > 7 && PGN32614Found)
    {
        PGN32614Found = false;
        byte tmp = Serial.read();
        if (ParseModID(tmp) == ModuleID)
        {
            byte SensorID = ParseSenID(tmp);
            if (SensorID < SensorCount)
            {
                RelayHi = Serial.read();
                RelayLo = Serial.read();

                // rate setting, 100 times actual
                UnSignedTemp = Serial.read() << 8 | Serial.read();
                float TmpSet = (float)(UnSignedTemp * 0.01);

                //Meter Cal, 100 times actual
                UnSignedTemp = Serial.read() << 8 | Serial.read();
                MeterCal[SensorID] = (float)(UnSignedTemp * 0.01);

                // command byte
                InCommand[SensorID] = Serial.read();
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

    if (Serial.available() > 7 && PGN32615Found)
    {
        PGN32615Found = false;

        byte tmp = Serial.read();
        if (ParseModID(tmp) == ModuleID)
        {
            byte SensorID = ParseSenID(tmp);
            if (SensorID < SensorCount)
            {
                VCN[SensorID] = Serial.read() << 8 | Serial.read();
                SendTime[SensorID] = Serial.read() << 8 | Serial.read();
                WaitTime[SensorID] = Serial.read() << 8 | Serial.read();
                VCNminPWM[SensorID] = Serial.read();

                watchdogTimer = 0;
                CommTime[SensorID] = millis();
            }
        }
    }

    if (Serial.available() > 7 && PGN32616Found)
    {
        PGN32616Found = false;
        byte tmp = Serial.read();
        if (ParseModID(tmp) == ModuleID)
        {
            byte SensorID = ParseSenID(tmp);
            if (SensorID < SensorCount)
            {
                PIDkp[SensorID] = Serial.read();
                PIDminPWM[SensorID] = Serial.read();
                PIDLowMax[SensorID] = Serial.read();
                PIDHighMax[SensorID] = Serial.read();
                PIDdeadband[SensorID] = Serial.read();
                PIDbrakePoint[SensorID] = Serial.read();

                watchdogTimer = 0;
                CommTime[SensorID] = millis();
            }
        }
    }

    if (Serial.available() > 4 && PGN32619Found)
    {
        // from Wemos D1 mini
        PGN32619Found = false;
        for (int i = 0; i < 5; i++)
        {
            WifiSwitches[i] = Serial.read();
        }
        Serial.println("");
        WifiSwitchesEnabled = true;
        WifiSwitchesTimer = millis();
        SetRelaysWifi();
    }

    if (Serial.available() > 3 && PGN32620Found)
    {
        // from rate controller
        PGN32620Found = false;
        for (int i = 0; i < 4; i++)
        {
            SwitchBytes[i] = Serial.read();
        }
        TranslateSwitchBytes();
    }

    //RelayHi = 0;
    //RelayLo = 7;
    //RateSetting = 10;
    //MeterCal = 120;

    //ControlType = 2;

    //SimulateFlow = 0;
    //UseVCN = 0;
    //watchdogTimer = 0;
    //ControllerConnected = true;

    //PIDkp = 80;
    //PIDminPWM = 5;
    //PIDLowMax = 150;
    //PIDHighMax = 200;
    //PIDdeadband = 3;
    //PIDbrakePoint = 20;
}
