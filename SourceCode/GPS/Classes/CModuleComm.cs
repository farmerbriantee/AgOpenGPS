using System.Text;

namespace AgOpenGPS
{
    public class CModuleComm
    {
        //copy of the mainform address
        private FormGPS mf;

        //properties for relay control of sections and input lines, 8 bit bytes
        public byte[] relaySectionControl = new byte[1];
        //public byte[] relayInputLines = new byte[1];

        //sentence recvd from section relay serial
        public string relaySerialRecvStr;

        public bool isWorkSwitchOn, isWorkSwitchActiveLow, isWorkSwitchEnabled;

        //constructor
        public CModuleComm(FormGPS f)
        {            
            this.mf = f;

            //control all relays based on byte value, 1 means on, 0 means off
            relaySectionControl[0] = 0;

            //WorkSwitch logic
            isWorkSwitchEnabled = false;
            isWorkSwitchOn = false;

            //does a low, grounded out, mean on
            isWorkSwitchActiveLow = true;
        }



    }
}
