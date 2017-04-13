using System.Text;
using System;

namespace AgOpenGPS
{
    public class CModuleComm
    {
        //copy of the mainform address
        private FormGPS mf;

        //properties for relay control of sections and input lines, 8 bit bytes
        public byte[] relaySectionControl = new byte[1];
        //public byte[] relayInputLines = new byte[1];
        public string serialRecvRelayStr;
        public double rollAngle = 0, pitchAngle = 0;
        public double angularVelocity = 0;
        public double imuHeading = 0;

        //control for the auto steer module
        public byte[] autoSteerControl = new byte[6];
        public string serialRecvAutoSteerStr;
 
        //for the workswitch
        public bool isWorkSwitchOn, isWorkSwitchActiveLow, isWorkSwitchEnabled;
        public int workSwitchValue = 0;

        //constructor
        public CModuleComm(FormGPS f)
        {            
            this.mf = f;

            //control all relays based on byte value, 1 means on, 0 means off
            relaySectionControl[0] = 0;

            autoSteerControl[0] = (byte)0;
            autoSteerControl[1] = (byte)(0);

            autoSteerControl[2] = (byte)(125);
            autoSteerControl[3] = (byte)20;

            autoSteerControl[4] = (byte)(125);
            autoSteerControl[5] = (byte)20;

            //WorkSwitch logic
            isWorkSwitchEnabled = false;
            isWorkSwitchOn = false;

            //does a low, grounded out, mean on
            isWorkSwitchActiveLow = true;
        }
    }
}
