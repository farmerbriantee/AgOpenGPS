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
        public double currentWidth = 0;

        //setpoints
        public double rate1;
        public double rate2;
        public double rateSetPoint;

        //coming back from module
        public double rateActual;
        public double volumeActual;
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
            mf.mc.relayRateData[mf.mc.rdHeaderHi] = 127; //32762
            mf.mc.relayRateData[mf.mc.rdHeaderLo] = 250;
            mf.mc.relayRateData[mf.mc.rdSectionControlByte] = 0;
            mf.mc.relayRateData[mf.mc.rdRateSetPointHi] = 0;
            mf.mc.relayRateData[mf.mc.rdRateSetPointLo] = 0;
            mf.mc.relayRateData[mf.mc.rdSpeedXFour] = 0;
            mf.RateRelayOutToPort(mf.mc.relayRateData, AgOpenGPS.CModuleComm.numRelayRateDataItems);
        }

        public void CalculateRateLitersPerMinute()
        {
            //determine current width based on sections off on
            currentWidth = 0;
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
                rateSetPoint = (currentWidth * mf.pn.speed)/600 * rate1;
            else
                rateSetPoint = (currentWidth * mf.pn.speed) / 600 * rate2;
        }
    }
}
