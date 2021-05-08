
int DoPID(byte sKP, float sError, float sSetPoint, byte sMinPWM,
    byte sLowMax, byte sHighMax, byte sBrakePoint, byte sDeadband, byte SensorID)
{
    int Result = 0;
    if (FlowEnabled[SensorID])
    {
        float ErrorPercent = abs(sError / sSetPoint);
        float ErrorBrake = (float)((float)(sBrakePoint / 100.0));
        float Max = (float)sHighMax;

        if (ErrorPercent > ((float)(sDeadband / 100.0)))
        {
            if (ErrorPercent <= ErrorBrake)
            {
                Max = (ErrorPercent / ErrorBrake) * sLowMax;
            }

            Result = (int)(sKP * sError);

            bool IsPositive = (Result > 0);
            Result = abs(Result);
            if (Result > Max) Result = (int)Max;
            if (Result < sMinPWM) Result = sMinPWM;
            if (!IsPositive) Result *= -1;
        }
    }
    return Result;
}

float LastPWM[SensorCount];
int ControlMotor(byte sKP, float sError, float sSetPoint, byte sMinPWM,
    byte sHighMax, byte sDeadband, byte SensorID)
{
    float Result = 0;
    float ErrorPercent = 0;

    if (FlowEnabled[SensorID])
    {
        Result = LastPWM[SensorID];
        ErrorPercent = abs(sError / sSetPoint) * 100.0;
        float Max = (float)sHighMax;

        if (ErrorPercent > (float)sDeadband)
        {
            Result += ((float)sKP / 255.0) * sError * 5.0;

            if (Result > Max) Result = Max;
            if (Result < sMinPWM) Result = (float)sMinPWM;
        }
    }

    LastPWM[SensorID] = Result;
    return (int)Result;
}
