using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateController
{
    class PGN32615
    {
        // to Arduino from Rate Controller
        // 0 HeaderHi       127
        // 1 HeaderLo       232
        //2 Mod/Sen ID     0-15/0-15
        // 3 VCN Hi         Valve Cal Number
        // 4 VCN Lo
        // 5 Send Hi        ms sending pwm
        // 6 Send Lo
        // 7 Wait Hi        ms to wait before sending pwm again
        // 8 Wait Lo
        // 9 Min PWM

        public int VCN;
        public int SendTime;
        public int WaitTime;
        public byte MinPWM;
        private const byte cByteCount = 10;
        private const byte HeaderHi = 127;
        private const byte HeaderLo = 103;
        private readonly clsProduct Prod;

        public PGN32615(clsProduct CalledFrom)
        {
            Prod = CalledFrom;

            VCN = 743;
            SendTime = 200;
            WaitTime = 750;
            MinPWM = 145;
        }

        public byte[] Data()
        {
            byte[] Vals = new byte[cByteCount];
            Vals[0] = HeaderHi;
            Vals[1] = HeaderLo;
            Vals[2] = Prod.mf.Tls.BuildModSenID(Prod.ModuleID, Prod.SensorID);
            Vals[3] = (byte)(VCN >> 8);
            Vals[4] = (byte)VCN;
            Vals[5] = (byte)(SendTime >> 8);
            Vals[6] = (byte)SendTime;
            Vals[7] = (byte)(WaitTime >> 8);
            Vals[8] = (byte)WaitTime;
            Vals[9] = MinPWM;

            return Vals;
        }

        public void Send()
        {
            if (Prod.SimulationType == SimType.VirtualNano)
            {
                Prod.VirtualNano.ReceiveSerial(Data());
            }
            else
            {
                Prod.mf.SendSerial(Data());
                Prod.mf.UDPnetwork.SendUDPMessage(Data());
            }
        }

    }
}
