float CurrentCounts0;
unsigned long LastPulse0;
unsigned long TimedCounts0;

unsigned long RateInterval0;
unsigned long RateTimeLast0;
float CurrentDuration0;
float PPM0;

volatile float pulseDuration0;
volatile bool pulseState0;
volatile float pulseCount0 = 0;
int MinPulseTime0;

float KalResult0 = 0;
float KalPc0 = 0.0;
float KalG0 = 0.0;
float KalP0 = 1.0;
float KalVariance0 = 0.01;	// larger is more filtering
float KalProcess0 = 0.005;	// smaller is more filtering

void PPM0isr()
{
    // measure time for one pulse
    static unsigned long pulseStart = 0;

    if (millis() - pulseStart > 5)
    {
        pulseState0 = !pulseState0;

        if (pulseState0)
        {
            pulseStart = millis();
        }
        else
        {
            pulseDuration0 = millis() - pulseStart;
            pulseCount0++;
            pulseStart = 0;
        }
    }
}

void GetUPM0()
{
    SetMinPulseTime0();

    // check for no PPM
    if (millis() - LastPulse0 > 4000)
    {
        pulseDuration0 = 0;
        CurrentDuration0 = 0;
        PPM0 = 0;
    }
    if (pulseCount0 > 0)
    {
        LastPulse0 = millis();
    }

    // accumulated total
    CurrentCounts0 = pulseCount0;
    pulseCount0 = 0;
    TotalPulses[0] += CurrentCounts0;

    // ppm
    if (MinPulseTime0 == 0)
    {
        // low ms/pulse, use pulses over time
        TimedCounts0 += CurrentCounts0;
        RateInterval0 = millis() - RateTimeLast0;
        if (RateInterval0 > 200)
        {
            RateTimeLast0 = millis();
            PPM0 = (60000.0 * TimedCounts0) / RateInterval0;
            TimedCounts0 = 0;
        }
    }
    else
    {
        // high ms/pulse, use time for one pulse
        if (pulseDuration0 > MinPulseTime0) CurrentDuration0 = pulseDuration0;
        if (CurrentDuration0 > 0) PPM0 = 60000.0 / CurrentDuration0;
    }

    // Kalmen filter
    KalPc0 = KalP0 + KalProcess0;
    KalG0 = KalPc0 / (KalPc0 + KalVariance0);
    KalP0 = (1.0 - KalG0) * KalPc0;
    KalResult0 = KalG0 * (PPM0 - KalResult0) + KalResult0;
    PPM0 = KalResult0;

    // units per minute
    if (MeterCal[0] > 0)
    {
        UPM[0] = PPM0 / MeterCal[0];
    }
    else
    {
        UPM[0] = 0;
    }
}

void SetMinPulseTime0()
{
    if (RateSetting[0] <= 0 || MeterCal[0] <= 0)
    {
        MinPulseTime0 = 5;
    }
    else
    {
        // ms/pulse = 60000 / ((units per minute) * (counts per unit))
        float Ms = RateSetting[0] * MeterCal[0];
        if (Ms > 0)
        {
            Ms = 60000.0 / Ms;
        }
        else
        {
            Ms = 0;
        }

        if (Ms < LowMsPulseTrigger[0])
        {
            // low ms/pulse
            MinPulseTime0 = 0;
        }
        else
        {
            // high ms/pulse
            MinPulseTime0 = 5;
        }
    }
}

