
namespace AgOpenGPS
{
    public class CModuleComm
    {
        //copy of the mainform address
        //private FormGPS mf;

        //properties for relay control of sections and input lines, 8 bit bytes
        public byte[] relaySectionControl = new byte[numRelayControls];
        public string serialRecvRelayStr;

        //public double angularVelocity = 0;
        //public double imuHeading = 0;

        public static int numSteerDataItems = 8;
        public int sdHeaderHi = 0, sdHeaderLo=1, sdRelay=2, sdSpeed=3, sdDistanceHi=4,
                        sdDistanceLo=5, sdSteerAngleHi=6, sdSteerAngleLo=7;

        public static int numSteerSettingItems = 10;
        public int ssHeaderHi = 0, ssHeaderLo = 1, ssKp = 2, ssKi = 3, ssKd = 4,
                        ssKo = 5, ssSteerOffset = 6, ssMinPWM = 7, ssMaxIntegral = 8,
                        ssCountsPerDegree = 9;

        public static int numRelayControls = 1;

        //control for the auto steer module
        public byte[] autoSteerData = new byte[numSteerDataItems];
        public byte[] autoSteerSettings = new byte[numSteerSettingItems];
        public string serialRecvAutoSteerStr;

        //from autosteer module the a/d conversion of inclinometer
        public int rollRaw = 0;

        //for the workswitch
        public bool isWorkSwitchOn, isWorkSwitchActiveLow, isWorkSwitchEnabled;
        public int workSwitchValue = 0;

        //constructor
        public CModuleComm()
        {
            serialRecvAutoSteerStr = ",";
            serialRecvRelayStr = ",";

            //control all relays based on byte value, 1 means on, 0 means off
            relaySectionControl[0] = 0;

            //prefill the autosteer data
            autoSteerData[sdHeaderHi] = 127; //32766
            autoSteerData[sdHeaderLo] = (254);
            autoSteerData[sdRelay] = 0;
            autoSteerData[sdSpeed] = (0);
            autoSteerData[sdDistanceHi] = (125); //32020
            autoSteerData[sdDistanceLo] = 20;
            autoSteerData[sdSteerAngleHi] = (125); //32020
            autoSteerData[sdSteerAngleLo] = 20;

            //WorkSwitch logic
            isWorkSwitchEnabled = false;
            isWorkSwitchOn = false;

            //does a low, grounded out, mean on
            isWorkSwitchActiveLow = true;

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
        }
    }
}
