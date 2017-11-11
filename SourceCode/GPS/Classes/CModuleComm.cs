
namespace AgOpenGPS
{
    public class CModuleComm
    {
        //copy of the mainform address
        private readonly FormGPS mf = null;

        //Recv string for RateRelay
        public string serialRecvRelayRateStr;

        //properties for rate control of sections and input lines, 8 bit bytes
        public static int numRelayRateControls = 6;
        public byte[] relayRateControl = new byte[numRelayRateControls];
        public int rcHeaderHi = 0, rcHeaderLo = 1, rcSectionControlByte = 2, rcSpeedXFour = 3,
                    rcRateSetPointHi = 4, rcRateSetPointLo = 5;
       //Recv for the auto steer module
        public string serialRecvAutoSteerStr;

        public static int numSteerDataItems = 8;
        public byte[] autoSteerData = new byte[numSteerDataItems];
        public int sdHeaderHi = 0, sdHeaderLo=1, sdRelay=2, sdSpeed=3, sdDistanceHi=4,
                        sdDistanceLo=5, sdSteerAngleHi=6, sdSteerAngleLo=7;

        public static int numSteerSettingItems = 10;
        public byte[] autoSteerSettings = new byte[numSteerSettingItems];
        public int ssHeaderHi = 0, ssHeaderLo = 1, ssKp = 2, ssKi = 3, ssKd = 4,
                        ssKo = 5, ssSteerOffset = 6, ssMinPWM = 7, ssMaxIntegral = 8,
                        ssCountsPerDegree = 9;

        //for the workswitch
        public bool isWorkSwitchOn, isWorkSwitchActiveLow, isWorkSwitchEnabled;
        public int workSwitchValue;

        //imu and roll inclinometer
        public int steerSwitchValue, gyroHeading=9999, prevGyroHeading = 9999;
        public int rollRaw=9999; //inclinometer ?

        //constructor
        public CModuleComm(FormGPS _f)
        {
            mf = _f;
            serialRecvAutoSteerStr = "Oops";
            serialRecvRelayRateStr = "Oops";

            //WorkSwitch logic
            isWorkSwitchEnabled = false;
            isWorkSwitchOn = false;

            //does a low, grounded out, mean on
            isWorkSwitchActiveLow = true;
        }

        public void ResetAllModuleCommValues()
        {
            //set up relayRate array
            relayRateControl[rcHeaderHi] = 127; //32762
            relayRateControl[rcHeaderLo] = 250;
            relayRateControl[rcSectionControlByte] = 0;
            relayRateControl[rcRateSetPointHi] = 0;
            relayRateControl[rcRateSetPointLo] = 0;
            relayRateControl[rcSpeedXFour] = 0;

            //prefill the autosteer data
            autoSteerData[sdHeaderHi] = 127; //32766
            autoSteerData[sdHeaderLo] = (254);
            autoSteerData[sdRelay] = 0;
            autoSteerData[sdSpeed] = (0);
            autoSteerData[sdDistanceHi] = (125); //32020
            autoSteerData[sdDistanceLo] = 20;
            autoSteerData[sdSteerAngleHi] = (125); //32020
            autoSteerData[sdSteerAngleLo] = 20;

            //prefill the autosteer settings from settings xml
            autoSteerSettings[ssHeaderHi] = 127;
            autoSteerSettings[ssHeaderLo] = 252; //32764 as header
            autoSteerSettings[ssKp] = Properties.Settings.Default.setAS_Kp;
            autoSteerSettings[ssKi] = Properties.Settings.Default.setAS_Ki;
            autoSteerSettings[ssKd] = Properties.Settings.Default.setAS_Kd;
            autoSteerSettings[ssKo] = Properties.Settings.Default.setAS_Ko;
            autoSteerSettings[ssSteerOffset] = Properties.Settings.Default.setAS_steerAngleOffset;
            autoSteerSettings[ssMinPWM] = Properties.Settings.Default.setAS_minSteerPWM;
            autoSteerSettings[ssMaxIntegral] = Properties.Settings.Default.setAS_maxIntegral;
            autoSteerSettings[ssCountsPerDegree] = Properties.Settings.Default.setAS_countsPerDegree;

            //spit out to rate/relay module
            mf.RateRelayControlOutToPort();

            //out serial to autosteer module  //indivdual classes load the distance and heading deltas 
            mf.AutoSteerDataOutToPort();
        }
    }
}
