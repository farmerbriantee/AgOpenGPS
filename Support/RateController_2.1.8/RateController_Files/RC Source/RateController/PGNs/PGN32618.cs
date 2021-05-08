using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RateController
{
    public enum Switches { Auto, MasterOn, MasterOff, RateUp, RateDown, sw0, sw1, sw2, sw3 };

    public class PGN32618
    {
        // to Rate Controller from arduino switch box
        // 0   127
        // 1   106
        // 2   switches high            
        //      - bit 0 Auto
        //      - bit 1 MasterOn        
        //      - bit 2 MasterOff       
        //      - bit 3 RateUp          
        //      - bit 4 RateDown        
        // 3   switches low
        //      - bit 0 SW0
        //      - bit 1 SW1
        //      - bit 2 SW2
        //      - bit 3 SW3

        private const byte cByteCount = 4;
        private const byte HeaderHi = 127;
        private const byte HeaderLo = 106;

        FormStart mf;
        bool[] SW = new bool[9];
        int Tmp;

        private DateTime ReceiveTime;
        byte DataHi;
        byte DataLo;

        public class SwitchPGNargs : EventArgs
        {
            public bool[] Switches { get; set; }
        }

        public event EventHandler<SwitchPGNargs> SwitchPGNreceived;

        public PGN32618(FormStart CalledFrom)
        {
            mf = CalledFrom;
        }

        public void ParseByteData(byte[] Data)
        {
            bool Result = false;
            if (Data[0] == HeaderHi & Data[1] == HeaderLo & Data.Length >= cByteCount)
            {
                SW[0] = mf.Tls.BitRead(Data[3], 0);     // auto on
                SW[1] = mf.Tls.BitRead(Data[3], 1);     // master on
                SW[2] = mf.Tls.BitRead(Data[3], 2);     // master off
                SW[3] = mf.Tls.BitRead(Data[3], 3);     // rate up
                SW[4] = mf.Tls.BitRead(Data[3], 4);     // rate down
                SW[5] = mf.Tls.BitRead(Data[2], 0);     // s0
                SW[6] = mf.Tls.BitRead(Data[2], 1);     // s1
                SW[7] = mf.Tls.BitRead(Data[2], 2);     // s2
                SW[8] = mf.Tls.BitRead(Data[2], 3);     // s3

                ReceiveTime = DateTime.Now;
                Result = true;
            }
            if (Result)
            {
                SwitchPGNargs args = new SwitchPGNargs();
                args.Switches = SW;
                SwitchPGNreceived?.Invoke(this, args);
            }
        }

        public bool ParseStringData(string[] Data)
        {
            bool Result = false;
            if (Data.Length >= cByteCount)
            {
                int.TryParse(Data[0], out Tmp);
                if (Tmp == HeaderHi)
                {
                    int.TryParse(Data[1], out Tmp);
                    if (Tmp == HeaderLo)
                    {
                        byte.TryParse(Data[2],out  DataLo);
                        byte.TryParse(Data[3], out DataHi);

                        SW[0] = mf.Tls.BitRead(DataHi, 0);     // auto on
                        SW[1] = mf.Tls.BitRead(DataHi, 1);     // master on
                        SW[2] = mf.Tls.BitRead(DataHi, 2);     // master off
                        SW[3] = mf.Tls.BitRead(DataHi, 3);     // rate up
                        SW[4] = mf.Tls.BitRead(DataHi, 4);     // rate down
                        SW[5] = mf.Tls.BitRead(DataLo, 0);     // s0
                        SW[6] = mf.Tls.BitRead(DataLo, 1);     // s1
                        SW[7] = mf.Tls.BitRead(DataLo, 2);     // s2
                        SW[8] = mf.Tls.BitRead(DataLo, 3);     // s3

                        ReceiveTime = DateTime.Now;
                        Result = true;
                    }
                }
            }
            if (Result)
            {
                SwitchPGNargs args = new SwitchPGNargs();
                args.Switches = SW;
                SwitchPGNreceived?.Invoke(this, args);
            }
            return Result;
        }

        public bool Connected()
        {
            return ((DateTime.Now - ReceiveTime).TotalSeconds < 4);
        }
    }
}