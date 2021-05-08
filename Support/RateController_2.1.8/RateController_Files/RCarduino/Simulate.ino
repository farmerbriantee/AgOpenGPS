float ValveAdjust[] = {0.0, 0.0};  // % amount to open/close valve
float ValveOpen[] = {0.0, 0.0};     // % valve is open
float Pulses[] = {0.0, 0.0};
float ValveOpenTime[] = {4000, 4000}; // ms to fully open valve at max opening rate
float simUPM[] = {0.00, 0.00};    // simulated units per minute
float MaxRate[] = {100.0, 100.0}; // max rate of system in UPM
float ErrorRange[] = {4.0, 4.0}; // % random error in flow rate
float PulseTime[] = {0.0, 0.0};

unsigned long SimulateInterval[SensorCount];
unsigned long SimulateTimeLast[SensorCount];
float RandomError[] = {0.0, 0.0};

void SimulateValve(byte sMin, byte sMax, byte SensorID)
{
  SimulateInterval[SensorID] = millis() - SimulateTimeLast[SensorID];
  SimulateTimeLast[SensorID] = millis();

  if (FlowEnabled[SensorID])
  {
    float Range = sMax - sMin + 5;
    if (Range == 0 || pwmSetting[SensorID] == 0)
    {
      ValveAdjust[SensorID] = 0;
    }
    else
    {
      float Percent = (float)((abs(pwmSetting[SensorID]) - sMin + 5) / Range);
      if (pwmSetting[SensorID] < 0)
      {
        Percent *= -1;
      }

      ValveAdjust[SensorID] = (float)(Percent * (float)(SimulateInterval[SensorID] / ValveOpenTime[SensorID]) * 100.0);
    }

    ValveOpen[SensorID] += ValveAdjust[SensorID];
    if (ValveOpen[SensorID] < 0) ValveOpen[SensorID] = 0;
    if (ValveOpen[SensorID] > 100) ValveOpen[SensorID] = 100;
  }
  else
  {
    ValveOpen[SensorID] = 0;
  }

  simUPM[SensorID] = MaxRate[SensorID] * ValveOpen[SensorID] / 100.0;

  Pulses[SensorID] = (simUPM[SensorID] * MeterCal[SensorID]) / 60000.0;  // (Units/min * pulses/Unit) = pulses/min / 60000 = pulses/millisecond
  if (Pulses[SensorID] == 0)
  {
      if (SensorID == 0)
      {
          pulseCount0 = 0;
          pulseDuration0 = 0;
      }
      else
      {
          pulseCount1 = 0;
          pulseDuration1 = 0;
      }
  }
  else
  {
    PulseTime[SensorID] = 1.0 / Pulses[SensorID];	// milliseconds for each pulse

    RandomError[SensorID] = (100.0 - ErrorRange[SensorID]) + (random(ErrorRange[SensorID] * 2.0));
    PulseTime[SensorID] = (float)(PulseTime[SensorID] * RandomError[SensorID] / 100.0);

    if (SensorID == 0)
    {
        pulseCount0 = SimulateInterval[SensorID] / PulseTime[SensorID];	// milliseconds * pulses/millsecond = pulses

        // pulse duration is the time for one pulse
        pulseDuration0 = PulseTime[SensorID];
    }
    else
    {
        pulseCount1 = SimulateInterval[SensorID] / PulseTime[SensorID];	// milliseconds * pulses/millsecond = pulses

        // pulse duration is the time for one pulse
        pulseDuration1 = PulseTime[SensorID];
    }
  }
}

float MaxRPM = 100.0;
float PPR = 50;	// pulses per revolution
float SimRPM[] = {0.0, 0.0};
float SimTmp;

void SimulateMotor(byte sMin, byte sMax, byte SensorID)
{
    if (FlowEnabled[SensorID])
    {
        if (SensorID == 0)
        {
            if (FlowEnabled[SensorID])
            {
                SimulateInterval[SensorID] = millis() - SimulateTimeLast[SensorID];
                SimulateTimeLast[SensorID] = millis();

                SimRPM[SensorID] += ((pwmSetting[SensorID] / (float)sMax) * MaxRPM - SimRPM[SensorID]) * 0.25;	// update rpm
                RandomError[SensorID] = (100.0 - ErrorRange[SensorID]) + (random(ErrorRange[SensorID] * 2.0));
                SimRPM[SensorID] = SimRPM[SensorID] * RandomError[SensorID] / 100.0;
                if (SimRPM[SensorID] < sMin) SimRPM[SensorID] = (float)sMin;

                SimTmp = PPR * SimRPM[SensorID];

                if (SimTmp > 0)
                {
                    pulseDuration0 = 60000 / SimTmp;
                }
                else
                {
                    pulseDuration0 = 0;
                }

                pulseCount0 = SimRPM[SensorID] * PPR;
                pulseCount0 = pulseCount0 * (SimulateInterval[SensorID] / 60000.0);	// counts for time slice
            }
            else
            {
                pulseCount0 = 0;
            }
        }
        else
        {
            if (FlowEnabled[SensorID])
            {
                SimulateInterval[SensorID] = millis() - SimulateTimeLast[SensorID];
                SimulateTimeLast[SensorID] = millis();

                SimRPM[SensorID] += ((pwmSetting[SensorID] / (float)sMax) * MaxRPM - SimRPM[SensorID]) * 0.25;	// update rpm
                RandomError[SensorID] = (100.0 - ErrorRange[SensorID]) + (random(ErrorRange[SensorID] * 2.0));
                SimRPM[SensorID] = SimRPM[SensorID] * RandomError[SensorID] / 100.0;
                if (SimRPM[SensorID] < sMin) SimRPM[SensorID] = (float)sMin;

                SimTmp = PPR * SimRPM[SensorID];

                if (SimTmp > 0)
                {
                    pulseDuration1 = 60000 / SimTmp;
                }
                else
                {
                    pulseDuration1 = 0;
                }

                pulseCount1 = SimRPM[SensorID] * PPR;
                pulseCount1 = pulseCount1 * (SimulateInterval[SensorID] / 60000.0);	// counts for time slice
            }
            else
            {
                pulseCount1 = 0;
            }

        }
    }
}
