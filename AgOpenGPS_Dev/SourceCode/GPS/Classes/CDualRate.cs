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
        //MTZ8302 April 2018
        public int RelayFromArduinoLo = 0;

        public int RelayFromArduinoOldLo = 0;
        public int SectSWOffFromArduinoLo = 0;
        public int SectSWOffFromArduinoOldLo = 0;
        public int RelayFromArduinoHi = 0;
        public int RelayFromArduinoOldHi = 0;
        public int SectSWOffFromArduinoHi = 0;
        public int SectSWOffFromArduinoOldHi = 0;
        public int SectMainSWFromArduino = 0;
        public int SectMainSWFromArduinoOld = 0;
        public int RateStepsFromArudino = 0;
        public int RateStepsFromArduinoOld = 0;
        public bool RateStepsLeft = true;
        public bool RateUp = true;
        public bool RateStepsLeftOld = true;
        public bool RateUpOld = true;
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
            //return if not even or if single section
            //if (mf.vehicle.numOfSections % 2 != 0 | mf.vehicle.numOfSections == 1) return;

            int center = mf.vehicle.numOfSections >> 1;

            //determine current width based on sections off on
            currentWidthLeft = 0;
            currentWidthRight = 0;

            // is supersection on?
            if (mf.section[mf.vehicle.numOfSections].isSectionOn)
            {
                currentWidthLeft = mf.vehicle.toolWidth * 0.5;
                currentWidthRight = currentWidthLeft;
            }

            //add up each side
            else
            {
                for (int i = 0; i < center; i++)
                {
                    if (mf.section[i].isSectionOn) currentWidthLeft += mf.section[i].sectionWidth;
                }

                for (int i = center; i < center * 2; i++)
                {
                    if (mf.section[i].isSectionOn) currentWidthRight += mf.section[i].sectionWidth;
                }
            }

            //determine flow based on width and speed
            rateSetPointLeft = (currentWidthLeft * mf.pn.speed) / 600 * rateLeft;
            rateSetPointRight = (currentWidthRight * mf.pn.speed) / 600 * rateRight;
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