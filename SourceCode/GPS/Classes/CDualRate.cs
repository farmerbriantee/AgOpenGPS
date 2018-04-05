using System;

namespace AgOpenGPS
{
    public class CDualRate
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        public double currentWidthLeft = 0;
        public double currentWidthRight = 0;

        //setpoints
        public double rateLeft;

        public double rateRight;
        public double rateSetPointLeft, rateSetPointRight;

        //coming back from module
        public double rateActualRight;

        public double rateActualLeft;
        public double dualVolumeActual;
        //9.35396 liters/hectare is 1 us gallon/acre

        public bool isRateControlOn, isRate1Selected;
        public bool isSingleFlowMeter;

        //added by MTZ8302 - Matthias Hammer Marbach a.N. Germany----------
        public byte RelayFromArduino = 0;

        public byte RelayFromArduinoOld = 0;
        public byte SectSWOffFromArduino = 0;
        public byte SectSWOffFromArduinoOld = 0;
        //end adds by MTZ8302-----------------------------------------------

        public CDualRate(FormGPS _f)
        {
            mf = _f;
            isSingleFlowMeter = Properties.Settings.Default.setRate_isSingleFlowMeter;
            rateLeft = Math.Round(Properties.Settings.Default.setRate_rateLeft, 1);
            rateRight = Math.Round(Properties.Settings.Default.setRate_rateRight, 1);
            isRate1Selected = true;
        }

        public void ShutdownRateControl()
        {
            mf.rcd.isRateControlOn = false;
            isRateControlOn = false;

            //turn all relays off
            mf.mc.relayRateData[mf.mc.rdHeaderHi] = 127; //32762
            mf.mc.relayRateData[mf.mc.rdHeaderLo] = 250;
            mf.mc.relayRateData[mf.mc.rdSectionControlByteHi] = 0;
            mf.mc.relayRateData[mf.mc.rdSectionControlByteLo] = 0;
            mf.mc.relayRateData[mf.mc.rdRateSetPointLeftHi] = 0;
            mf.mc.relayRateData[mf.mc.rdRateSetPointLeftLo] = 0;
            mf.mc.relayRateData[mf.mc.rdRateSetPointRightHi] = 0;
            mf.mc.relayRateData[mf.mc.rdRateSetPointRightLo] = 0;
            mf.mc.relayRateData[mf.mc.rdSpeedXFour] = 0;
            mf.RateRelayOutToPort(mf.mc.relayRateData, CModuleComm.numRelayRateDataItems);
        }

        public void CalculateRateLitersPerMinuteDual()
        {
            //determine current width based on sections off on
            currentWidthLeft = 0;
            currentWidthRight = 0;
            // is supersection on?
            if (mf.section[mf.vehicle.numOfSections].isSectionOn)
            {
                rateSetPointLeft = (mf.section[0].sectionWidth * mf.pn.speed) / 600 * rateLeft;
                rateSetPointRight = (mf.section[1].sectionWidth * mf.pn.speed) / 600 * rateRight;
                currentWidthLeft = mf.section[0].sectionWidth;
                currentWidthRight = mf.section[1].sectionWidth;
            }
            else
            {
                if (mf.section[0].isSectionOn)
                {
                    rateSetPointLeft = (mf.section[0].sectionWidth * mf.pn.speed) / 600 * rateLeft;
                    currentWidthLeft = mf.section[0].sectionWidth;
                }
                else rateSetPointLeft = 0;

                if (mf.section[1].isSectionOn)
                {
                    rateSetPointRight = (mf.section[1].sectionWidth * mf.pn.speed) / 600 * rateRight;
                    currentWidthRight = mf.section[1].sectionWidth;
                }
                else rateSetPointRight = 0;
            }
        }

        public void CalculateRateLitersPerMinuteSingle()
        {
            //determine current width based on sections off on
            currentWidthLeft = 0;
            // is supersection on?
            if (mf.section[mf.vehicle.numOfSections].isSectionOn)
            {
                currentWidthLeft = mf.vehicle.toolWidth;
            }

            //individual sections are possibly on
            else
            {
                for (int i = 0; i < mf.vehicle.numOfSections; i++)
                {
                    if (mf.section[i].isSectionOn) currentWidthLeft += mf.section[i].sectionWidth;
                }
            }

            // hectares/min to liters/min based on set rate
            rateSetPointLeft = (currentWidthLeft * mf.pn.speed) / 600 * rateLeft;
        }
    }
}