using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RateController
{
    public class PGN234
    {
        // to AOG from Rate Controller
        // 0    HeaderHi    128
        // 1    HeaderLo    129
        // 2    source
        // 3    AGIO PGN    234 ss 0
        // 4    length
        // 5    swMain          ss 1
        //	    - bit 0		auto button on
        //	    - bit 1		auto button off
        //      - bits 2/3  rate change steps
        //      - bit 4     0-left, 1-right
        //      - bit 5     0-rate down, 1-rate up
        // 6    swReserve       ss 2
        // 7    swReserve2      ss 3
        // 8    swNumSections   ss 4
        // 9    swOnGr0         ss 5
        // 10   swOffGr0        ss 6
        // 11   swOnGr1         ss 7
        // 12   swOffGr1        ss 8
        // 13   CRC

        private FormStart mf;
        private byte[] cData = new byte[14];

        public PGN234(FormStart CalledFrom)
        {
            mf = CalledFrom;
            cData[0] = 128;
            cData[1] = 129;
            cData[2] = 0;
            cData[3] = 234;
            cData[4] = 8;
            cData[6] = 0;
            cData[7] = 0;
            cData[8] = 0;
        }

        public byte Command { set { cData[5] = value; } }

        public byte OnLo { set { cData[9] = value; } }

        public byte OffLo { set { cData[10] = value; } }

        public byte OnHi { set { cData[11] = value; } }

        public byte OffHi { set { cData[12] = value; } }

        public void Send()
        {
            cData[13] = CRC();
            mf.UDPagio.SendUDPMessage(cData);
        }

        private byte CRC()
        {
            int CK = 0;
            for (int i = 2; i < cData.Length - 1; i++)
            {
                CK += cData[i];
            }
            return (byte)CK;
        }
    }
}
