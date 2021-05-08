using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateController
{
    class PGN32616
    {
        // PID to Arduino from RateController
        // 0    127
        // 1    104
        // 2    Mod/Sen ID     0-15/0-15
        // 3    KP
        // 4    MinPWM
        // 5    LowMax
        // 6    HighMax
        // 7    Deadband
        // 8    BrakePoint
        // 9    -

        public byte KP;
        public byte MinPWM;
        public byte LowMax;

        public byte HighMax;
        public byte DeadBand;
        public byte BrakePoint;

        private const byte cByteCount = 10;
        private const byte HeaderHi = 127;
        private const byte HeaderLo = 104;
        private readonly clsProduct Prod;

        public PGN32616(clsProduct CalledFrom)
        {
            Prod = CalledFrom;

            KP = 20;
            MinPWM = 50;
            LowMax = 150;
            HighMax = 255;
            DeadBand = 3;
            BrakePoint = 2;
        }

        public void Send()
        {
            byte[] Data = new byte[cByteCount];
            Data[0] = HeaderHi;
            Data[1] = HeaderLo;
            Data[2] = Prod.mf.Tls.BuildModSenID(Prod.ModuleID, Prod.SensorID);
            Data[3] = KP;
            Data[4] = MinPWM;
            Data[5] = LowMax;
            Data[6] = HighMax;
            Data[7] = DeadBand;
            Data[8] = BrakePoint;

            if (Prod.SimulationType == SimType.VirtualNano)
            {
                Prod.VirtualNano.ReceiveSerial(Data);
            }
            else
            {
                Prod.mf.SendSerial(Data);
                Prod.mf.UDPnetwork.SendUDPMessage(Data);
            }
        }
    }
}
