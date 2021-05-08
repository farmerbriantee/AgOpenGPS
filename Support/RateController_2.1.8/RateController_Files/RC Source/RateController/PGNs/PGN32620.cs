using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateController
{
    public class PGN32620
    {
        // section switch IDs to arduino, ex: byte 2, bits 0 and 1 give 4 choices for sec 0, bits 2 and 3 for sec 1, etc.
        // 0    127
        // 1    108
        // 2    sec 0-3
        // 3    sec 4-7
        // 4    sec 8-11
        // 5    sec 12-15

        private const byte cByteCount = 10;
        private const byte HeaderHi = 127;
        private const byte HeaderLo = 108;

        FormStart mf;
        byte[] Data = new byte[cByteCount];

        public PGN32620(FormStart CallingForm)
        {
            mf = CallingForm;
            Data[0] = 127;
            Data[1] = 108;
        }

        public void Send()
        {
            int ByteCount = 2;
            int BitCount = 0;
            for (int i = 0; i < 4; i++)
            {
                Data[i + 2] = 0;
            }

            foreach (clsSection Sec in mf.Sections.Items)
            {
                byte SwitchID = (byte)Sec.SwitchID;
                SwitchID = (byte)(SwitchID << BitCount);
                Data[ByteCount] |= SwitchID;
                BitCount += 2;

                if (BitCount > 6)
                {
                    ByteCount++;
                    BitCount = 0;
                }
            }

            mf.SendSerial(Data);
            mf.UDPnetwork.SendUDPMessage(Data);
        }
    }
}
