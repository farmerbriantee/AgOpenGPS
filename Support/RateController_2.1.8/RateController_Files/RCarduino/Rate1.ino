float CurrentCounts1;
unsigned long LastPulse1;
unsigned long TimedCounts1;

unsigned long RateInterval1;
unsigned long RateTimeLast1;
float CurrentDuration1;
float PPM1;

volatile float pulseDuration1;
volatile bool pulseState1;
volatile float pulseCount1 = 0;
int MinPulseTime1;

float KalResult1 = 0;
float KalPc1 = 0.0;
float KalG1 = 0.0;
float KalP1 = 1.0;
float KalVariance1 = 0.01;	// larger is more filtering
float KalProcess1 = 0.005;	// smaller is more filtering

void PPM1isr()
{
    // measure time for one pulse
    static unsigned long pulseStart = 0;

    if (millis() - pulseStart > 5)
    {
        pulseState1 = !pulseState1;

        if (pulseState1)
        {
            pulseStart = millis();
        }
        else
        {
            pulseDuration1 = millis() - pulseStart;
            pulseCount1++;
            pulseStart = 1;
        }
    }
}

void GetUPM1()
{
    SetMinPulseTime1();

    // check for no PPM
    if (millis() - LastPulse1 > 4000)
    {
        pulseDuration1 = 0;
        CurrentDuration1 = 0;
        PPM1 = 0;
    }
    if (pulseCount1 > 0)
    {
        LastPulse1 = millis();
    }

    // accumulated total
    CurrentCounts1 = pulseCount1;
    pulseCount1 = 0;
    TotalPulses[1] += CurrentCounts1;

    // ppm
    if (MinPulseTime1 == 0)
    {
        // low ms/pulse, use pulses over time
        TimedCounts1 += CurrentCounts1;
        RateInterval1 = millis() - RateTimeLast1;
        if (RateInterval1 > 200)
        {
            RateTimeLast1 = millis();
            PPM1 = (60000.0 * TimedCounts1) / RateInterval1;
            TimedCounts1 = 0;
        }
    }
    else
    {
        // high ms/pulse, use time for one pulse
        if (pulseDuration1 > MinPulseTime1) CurrentDuration1 = pulseDuration1;
        if (CurrentDuration1 > 0) PPM1 = 60000.0 / CurrentDuration1;
    }

    // Kalmen filter
    KalPc1 = KalP1 + KalProcess1;
    KalG1 = KalPc1 / (KalPc1 + KalVariance1);
    KalP1 = (1.0 - KalG1) * KalPc1;
    KalResult1 = KalG1 * (PPM1 - KalResult1) + KalResult1;
    PPM1 = KalResult1;

    // units per minute
    if (MeterCal[1] > 0)
    {
        UPM[1] = PPM1 / MeterCal[1];
    }
    else
    {
        UPM[1] = 0;
    }
}

void SetMinPulseTime1()
{
    if (RateSetting[1] <= 0 || MeterCal[1] <= 0)
    {
        MinPulseTime1 = 5;
    }
    else
    {
        // ms/pulse = 60000 / ((units per minute) * (counts per unit))
        float Ms = RateSetting[1] * MeterCal[1];
        if (Ms > 0)
        {
            Ms = 60000.0 / Ms;
        }
        else
        {
            Ms = 0;
        }

        if (Ms < LowMsPulseTrigger[1])
        {
            // low ms/pulse
            MinPulseTime1 = 0;
        }
        else
        {
            // high ms/pulse
            MinPulseTime1 = 5;
        }
    }
}


