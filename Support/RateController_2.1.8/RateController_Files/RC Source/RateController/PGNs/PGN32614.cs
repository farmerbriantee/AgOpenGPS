
namespace RateController
{
    public class PGN32614
    {
        // to Arduino from Rate Controller
        //0	HeaderHi		127
        //1	HeaderLo		230
        //2 Mod/Sen ID     0-15/0-15
        //3	relay Hi		8-15
        //4	relay Lo		0-7
        //5	rate set Hi		100 X actual
        //6	rate set Lo		100 X actual
        //7	Flow Cal Hi		100 X actual
        //8	Flow Cal Lo		100 X actual
        //9	Command
        //	- bit 0		    reset acc.Quantity
        //	- bit 1,2		valve type 0-3
        //	- bit 3		    simulate flow
        //  - bit 4         0 UsePDI, 1 UseVCN 
        //  - bit 5         AutoOn

        private byte cCommand;
        private byte cFlowCalHi;
        private byte cFlowCalLo;
        private byte cRateSetHi;
        private byte cRateSetLo;
        private byte cRelayHi;
        private byte cRelayLo;

        private const byte cByteCount = 10;
        private const byte HeaderHi = 127;
        private const byte HeaderLo = 102;

        private readonly clsProduct Prod;

        public PGN32614(clsProduct CalledFrom)
        {
            Prod = CalledFrom;
        }

        public byte[] Data()
        {
            byte[] Vals = new byte[cByteCount];
            Vals[0] = HeaderHi;
            Vals[1] = HeaderLo;
            Vals[2] = Prod.mf.Tls.BuildModSenID(Prod.ModuleID, (byte)Prod.SensorID);
            Vals[3] = cRelayHi;
            Vals[4] = cRelayLo;
            Vals[5] = cRateSetHi;
            Vals[6] = cRateSetLo;
            Vals[7] = cFlowCalHi;
            Vals[8] = cFlowCalLo;
            Vals[9] = cCommand;
            return Vals;
        }

        public void Send()
        {
            int Temp = 0;
            cRelayHi = Prod.mf.Sections.SectionHi();
            cRelayLo = Prod.mf.Sections.SectionLo();

            if (Prod.mf.Sections.SwitchOn(Switches.Auto))
            {
                // send target rate
                Temp = (int)(Prod.TargetUPM() * 100.0);
                cRateSetHi = (byte)(Temp >> 8);
                cRateSetLo = (byte)Temp;
            }
            else
            {
                // send manual rate factor
                Temp = (int)(Prod.ManualRateFactor * 100.0);
                cRateSetHi = (byte)(Temp >> 8);
                cRateSetLo = (byte)Temp;
            }

            Temp = (int)(Prod.FlowCal * 100.0);
            cFlowCalHi = (byte)(Temp >> 8);
            cFlowCalLo = (byte)Temp;

            // command byte
            cCommand = 0;
            if (Prod.EraseApplied) cCommand |= 0b00000001;
            Prod.EraseApplied = false;

            switch (Prod.ValveType)
            {
                case 1:
                    cCommand &= 0b11111011; // clear bit 2
                    cCommand |= 0b00000010; // set bit 1
                    break;

                case 2:
                    cCommand |= 0b00000100; // set bit 2
                    cCommand &= 0b11111101; // clear bit 1
                    break;

                case 3:
                    cCommand |= 0b00000110; // set bit 2 and 1
                    break;

                default:
                    cCommand &= 0b11111001; // clear bit 2 and 1
                    break;
            }

            if (Prod.SimulationType != SimType.None) cCommand |= 0b00001000; else cCommand &= 0b11110111;

            if (Prod.UseVCN) cCommand |= 0b00010000; else cCommand &= 0b11101111;

            if (Prod.mf.Sections.SwitchOn(Switches.Auto)) cCommand |= 0b00100000;

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