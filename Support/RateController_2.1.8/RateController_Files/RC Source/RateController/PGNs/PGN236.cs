using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateController
{
    public class PGN236
    {
        // vr data
        // 0    header Hi   128 0x80
        // 1    header Lo   129 0x81
        // 2    source      126 0x7E
        // 3    AGIO PGN    236 0xEC
        // 4    length      8
        // 5    sec 1/2
        // 6    sec 3/4
        // 7    sec 5/6
        // 8    sec 7/8
        // 9    sec 9/10
        // 10   sec 11/12
        // 11   sec 13/14
        // 12   sec 15/16
        // 13   CRC

        private int totalHeaderByteCount = 5;
        private DateTime ReceiveTime;
        private byte[] LastVals = new byte[16];
        private byte ID;
        private byte[] NewVals = new byte[16];
        private bool Changed;

        public class RateChangedArgs : EventArgs
        {
            public byte[] SecBytes { get; set; }
        }

        public event EventHandler<RateChangedArgs> RatesChanged;

        public void ParseByteData(byte[] Data)
        {
            if (Data.Length > totalHeaderByteCount)
            {
                if (Data.Length == Data[4] + totalHeaderByteCount + 1)
                {
                    if (GoodCRC(Data))
                    {
                        ID = 0;
                        for (int i = 0; i < 8; i++)
                        {
                            NewVals[ID] = (byte)(Data[5 + i] & 15);
                            ID++;
                            NewVals[ID] = (byte)(Data[5 + i] >> 8);
                            ID++;
                        }

                        Changed = false;
                        for (int i = 0; i < 16; i++)
                        {
                            if (LastVals[i] != NewVals[i])
                            {
                                Changed = true;
                                break;
                            }
                        }

                        if (Changed)
                        {
                            RateChangedArgs args = new RateChangedArgs();
                            args.SecBytes = NewVals;
                            RatesChanged?.Invoke(this, args);
                            LastVals = NewVals;
                        }

                        ReceiveTime = DateTime.Now;
                    }
                }
            }
        }

        private bool GoodCRC(byte[] Data)
        {
            int CK = 0;
            for (int i = 2; i < Data.Length - 1; i++)
            {
                CK += Data[i];
            }
            return ((byte)CK == Data[Data.Length - 1]);
        }

        public bool Connected()
        {
            return (DateTime.Now - ReceiveTime).TotalSeconds < 4;
        }
    }
}
