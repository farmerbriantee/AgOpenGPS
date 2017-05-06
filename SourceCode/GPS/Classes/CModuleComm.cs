using System.Text;
using System;

namespace AgOpenGPS
{
    public class CModuleComm
    {
        //copy of the mainform address
        private FormGPS mf;

        //properties for relay control of sections and input lines, 8 bit bytes
        public byte[] relaySectionControl = new byte[numRelayControls];
        public string serialRecvRelayStr;
        public double rollAngle = 0, pitchAngle = 0;
        public double angularVelocity = 0;
        public double imuHeading = 0;

        public static int numSteerControls = 8;
        public static int numSteerSettings = 7;
        public static int numRelayControls = 1;

        //control for the auto steer module
        public byte[] autoSteerControl = new byte[numSteerControls];
        public byte[] autoSteerSettings = new byte[numSteerSettings];
        public string serialRecvAutoSteerStr;
 
        //for the workswitch
        public bool isWorkSwitchOn, isWorkSwitchActiveLow, isWorkSwitchEnabled;
        public int workSwitchValue = 0;

        //constructor
        public CModuleComm(FormGPS f)
        {            
            this.mf = f;

            serialRecvAutoSteerStr = ",";
            serialRecvRelayStr = ",";

            //control all relays based on byte value, 1 means on, 0 means off
            relaySectionControl[0] = 0;

            autoSteerControl[0] = (byte)127;
            autoSteerControl[1] = (byte)(254);
            autoSteerControl[2] = (byte)0;
            autoSteerControl[3] = (byte)(0);
            autoSteerControl[4] = (byte)(125);
            autoSteerControl[5] = (byte)20;
            autoSteerControl[6] = (byte)(125);
            autoSteerControl[7] = (byte)20;

            //WorkSwitch logic
            isWorkSwitchEnabled = false;
            isWorkSwitchOn = false;

            //does a low, grounded out, mean on
            isWorkSwitchActiveLow = true;

            autoSteerSettings[0] = (byte)127;
            autoSteerSettings[1] = (byte)252; //32764 as header

            autoSteerSettings[2] = Properties.Settings.Default.setAS_Kp;
            autoSteerSettings[3] = Properties.Settings.Default.setAS_Ki;
            autoSteerSettings[4] = Properties.Settings.Default.setAS_Kd;
            autoSteerSettings[5] = Properties.Settings.Default.setAS_Ko;
            autoSteerSettings[6] = Properties.Settings.Default.setAS_maxIntError;
        }
    }
}
