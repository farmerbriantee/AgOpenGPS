using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgOpenGPS
{
    public class CRate
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        public int rate1;
        public int rate2;
        public double rateSetPoint;
        public double rateActual;
        public double volumeDelivered;
        //9.35396 liters/hectare is 1 us gallon/acre

        public bool isRateControlOn, isRate1Selected = true;

         public CRate(FormGPS _f)
        {
            mf = _f;
        }

        public void ShutdownRateControl()
        {
            mf.rc.isRateControlOn = false;
            isRateControlOn = false;
            isRate1Selected = true;

            //turn all relays off
            mf.mc.relayRateControl[mf.mc.rcHeaderHi] = 127; //32762
            mf.mc.relayRateControl[mf.mc.rcHeaderLo] = 250;
            mf.mc.relayRateControl[mf.mc.rcSectionControlByte] = 0;
            mf.mc.relayRateControl[mf.mc.rcRateSetPointHi] = 0;
            mf.mc.relayRateControl[mf.mc.rcRateSetPointLo] = 0;
            mf.mc.relayRateControl[mf.mc.rcSpeedXFour] = 0;
            mf.RateRelayControlOutToPort();
        }

        public void CalculateRateLitersPerMinute()
        {
            //determine current width based on sections off on
            double currentWidth = 0;

            // is supersection on?
            if (mf.section[mf.vehicle.numOfSections].isSectionOn)
            {
                currentWidth = mf.vehicle.toolWidth;
            }

            //individual sections are possibly on
            else
            {
                for (int i = 0; i < mf.vehicle.numOfSections; i++)
                {
                    if (mf.section[i].isSectionOn) currentWidth += mf.section[i].sectionWidth;
                }
            }

            // hectares/min to liters/min based on set rate
            if (isRate1Selected)
                rateSetPoint = (currentWidth * mf.pn.speed)/600 * rate1 * 0.1;
            else
                rateSetPoint = (currentWidth * mf.pn.speed) / 600 * rate2 * 0.1;
        }
    }
}
