using System;
using System.Diagnostics;

namespace RateController
{
    public class PGN32613
    {
        // to Rate Controller from Arduino
        //0	HeaderHi		    127
        //1	HeaderLo		    101
        //2 Mod/Sen ID         0-15/0-15
        //3	rate applied Hi		100 X actual
        //4	rate applied Lo
        //5	acc.Quantity 3		100 X actual
        //6	acc.Quantity 2
        //7 acc.Quantity 1
        //8 PWM Hi
        //9 PWM Lo

        private const byte cByteCount = 10;
        private const byte HeaderHi = 127;
        private const byte HeaderLo = 101;
        private double cPWMsetting;

        private byte pwmHI;
        private byte pwmLo;
        private byte QuantityB1;
        private byte QuantityB2;
        private byte QuantityB3;
        private byte RateHi;
        private byte RateLo;
        private int Temp;
        private double cUPM;

        clsProduct Prod;

        private DateTime ReceiveTime;

        public PGN32613(clsProduct CalledFrom)
        {
            Prod = CalledFrom;
        }

        public bool ParseByteData(byte[] Data)
        {
            bool Result = false;
            if (Data[0] == HeaderHi & Data[1] == HeaderLo & Data.Length >= cByteCount)
            {
                int tmp = Prod.mf.Tls.ParseModID(Data[2]);
                if (Prod.ModuleID == tmp)
                {
                    tmp = Prod.mf.Tls.ParseSenID(Data[2]);
                    if (Prod.SensorID == tmp)
                    {
                        RateHi = Data[3];
                        RateLo = Data[4];
                        cUPM = (RateHi << 8 | RateLo) / 100.0;

                        QuantityB3 = Data[5];
                        QuantityB2 = Data[6];
                        QuantityB1 = Data[7];

                        pwmHI = Data[8];
                        pwmLo = Data[9];

                        cPWMsetting = (double)((Int16)(pwmHI << 8 | pwmLo)) / 10.0; // 2s complement math

                        ReceiveTime = DateTime.Now;
                        Result = true;
                    }
                }
            }
            return Result;
        }

        public bool ParseStringData(string[] Data)
        {
            bool Result = false;

            if (Data.Length >= cByteCount)
            {
                int.TryParse(Data[0], out Temp);

                if (Temp == HeaderHi)
                {
                    int.TryParse(Data[1], out Temp);
                    if (Temp == HeaderLo)
                    {
                        int.TryParse(Data[2], out Temp);
                        int tmp = Prod.mf.Tls.ParseModID((byte)Temp);
                        if (Prod.ModuleID == tmp)
                        {
                            tmp = Prod.mf.Tls.ParseSenID((byte)Temp);
                            if (Prod.SensorID == tmp)
                            {
                                // rate applied, 100 X actual
                                byte.TryParse(Data[3], out RateHi);
                                byte.TryParse(Data[4], out RateLo);
                                cUPM = (RateHi << 8 | RateLo) / 100.0;

                                // accumulated quantity
                                byte.TryParse(Data[5], out QuantityB3);
                                byte.TryParse(Data[6], out QuantityB2);
                                byte.TryParse(Data[7], out QuantityB1);

                                // pwmSetting
                                byte.TryParse(Data[8], out pwmHI);
                                byte.TryParse(Data[9], out pwmLo);

                                cPWMsetting = (double)((Int16)(pwmHI << 8 | pwmLo)) / 10.0;

                                ReceiveTime = DateTime.Now;
                                Result = true;
                            }
                        }
                    }
                }
            }
            return Result;
        }

        public double PWMsetting()
        {
            return cPWMsetting;
        }

        public double UPM()
        {
            return cUPM;
        }

        public double AccumulatedQuantity()
        {
            Temp = QuantityB3 << 16;
            Temp |= QuantityB2 << 8;
            Temp |= QuantityB1;
            return Temp / 100.0;
        }

        public bool Connected()
        {
            if (Prod.SimulationType == SimType.VirtualNano)
            {
                return true;
            }
            else
            {
                return ((DateTime.Now - ReceiveTime).TotalSeconds < 4);
            }
        }
    }
}