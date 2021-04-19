//Please, if you use this, share the improvements

using System;

namespace AgDiag
{
    public partial class FormLoop
    {
        //Latitude
        //public class CPGN_D0
        //{
        //    /// <summary>
        //    ///  Latitude Longitude 8 bytes as modified float
        //    ///  double lat = (encodedAngle / (0x7FFFFFFF / 90.0));
        //    ///  double lon = (encodedAngle / (0x7FFFFFFF / 180.0));
        //    /// </summary>
        //    public byte[] latLong = new byte[] { 0x80, 0x81, 0x7F, 0xD0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0xCC };


        //    public void LoadLatitudeLongitude(double lat, double lon)
        //    {

        //        int encodedAngle = (int)(lat * (0x7FFFFFFF / 90.0));
        //        //double angle = (encodedAngle / (0x7FFFFFFF / 90.0));

        //        byte[] lat6 = BitConverter.GetBytes(encodedAngle);
        //        Array.Copy(lat6, 0, latLong, 5, 4);

        //        encodedAngle = (int)(lon * (0x7FFFFFFF / 180.0));
        //        //double angle = (encodedAngle / (0x7FFFFFFF / 180.0));

        //        lat6 = BitConverter.GetBytes(encodedAngle);
        //        Array.Copy(lat6, 0, latLong, 9, 4);

        //        //crc = 0;
        //        //for (int i = 2; i < latLong.Length - 1; i++)
        //        //{
        //        //    crc += latLong[i];
        //        //}
        //        //latLong[latLong.Length - 1] = (byte)crc;
        //    }
        //}

        //AutoSteerData
        public class CPGN_FE
        {
            /// <summary>
            /// autoSteerData FE 254 speedHi=5 speedLo=6  status = 7 free = 8;
            /// steerAngleHi = 9 steerAngleLo = 10 tramControl = 11 sc1to8 = 12 sc9to16 = 13;
            /// </summary>
            public byte[] pgn = new byte[] { 0x80, 0x81, 0x7f, 0xFE, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0xCC };
            public int speedLo = 5;
            public int speedHi = 6;
            public int status = 7;
            public int steerAngleLo = 8;
            public int steerAngleHi = 9;
            //public int  = 10;
            public int sc1to8 = 11;
            public int sc9to16 = 12;

            public void Reset()
            {
            }
        }

        public class CPGN_FD
        {
            /// <summary>
            /// From steer module
            /// </summary>
            public byte[] pgn = new byte[] { 0x80, 0x81, 0x7f, 0xFD, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0xCC };
            public int actualLo = 5;
            public int actualHi = 6;
            public int headLo = 7;
            public int headHi = 8;
            public int rollLo = 9;
            public int rollHi = 10;
            public int switchStatus = 11;
            public int pwm = 12;

            public void Reset()
            {
            }
        }

        //AutoSteer Settings
        public class CPGN_FC
        {
            /// <summary>
            /// PGN - 252 - FC gainProportional=5 HighPWM=6  LowPWM = 7 MinPWM = 8 
            /// CountsPerDegree = 9 wasOffsetHi = 10 wasOffsetLo = 11 
            /// </summary>
            public byte[] pgn = new byte[] { 0x80, 0x81, 0x7f, 0xFC, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0xCC };
            public int gainProportional = 5;
            public int highPWM = 6;
            public int lowPWM = 7;
            public int minPWM = 8;
            public int countsPerDegree = 9;
            public int wasOffsetLo = 10;
            public int wasOffsetHi = 11;
            public int ackerman = 12;

            public CPGN_FC()
            {
            }
        }

        //Autosteer Board Config
        public class CPGN_FB
        {
            /// <summary>
            /// 
            /// PGN - 251 - FB 
            /// set0=5 maxPulse = 6 minSpeed = 7 ackermanFix = 8
            /// </summary>
            public byte[] pgn = new byte[] { 0x80, 0x81, 0x7f, 0xFB, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0xCC };
            public int set0 = 5;
            public int maxPulse = 6;
            public int minSpeed = 7;
            //public int = 8;
            //public int  = 9;
            //public int  = 10;
            //public int  = 11;
            //public int  = 12;

            public CPGN_FB()
            {
                pgn[set0] = 0;
                pgn[maxPulse] = 0;
                pgn[minSpeed] = 0;
            }
        }

        //Machine Data
        public class CPGN_EF
        {
            /// <summary>
            /// PGN - 239 - EF 
            /// uturn=5  tree=6  hydLift = 8 
            /// </summary>
            public byte[] pgn = new byte[] { 0x80, 0x81, 0x7f, 0xEF, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0xCC };
            public int uturn = 5;
            public int tree = 6;
            public int hydLift = 7;
            public int tram = 8;
            //public int  = 9;
            //public int  = 10;
            public int sc1to8 = 11;
            public int sc9to16 = 12;

            public CPGN_EF()
            {
            }

            public void Reset()
            {
            }
        }

        //Machine Config
        public class CPGN_EE
        {
            /// <summary>
            /// PGN - 238 - EE 
            /// raiseTime=5  lowerTime=6   enableHyd= 7 set0 = 8
            /// </summary>
            public byte[] pgn = new byte[] { 0x80, 0x81, 0x7f, 0xEF, 3, 0, 0, 0, 0xCC };
            public int raiseTime = 5;
            public int lowerTime = 6;
            public int enableHyd = 7;
            public int set0 = 8;
            //public int  = 9;
            //public int  = 10;
            //public int  = 11;
            //public int  = 12;

            public CPGN_EE()
            {
                //machineConfig[raiseTime] = Properties.Vehicle.Default.setArdMac_hydRaiseTime;
                //machineConfig[lowerTime] = Properties.Vehicle.Default.setArdMac_hydLowerTime;
                //machineConfig[enableHyd] = Properties.Vehicle.Default.setArdMac_isHydEnabled;
                //machineConfig[set0] = Properties.Vehicle.Default.setArdMac_setting0;
            }

            public void Reset()
            {
            }
        }


        //pgn instances

        /// <summary>
        /// autoSteerData - FE - 254 - 
        /// </summary>
        public CPGN_FE asData = new CPGN_FE();

        /// <summary>
        /// autoSteerReturn - FD - 253 - 
        /// </summary>
        public CPGN_FD asModule = new CPGN_FD();

        /// <summary>
        /// autoSteerSettings PGN - 252 - FC
        /// </summary>
        public CPGN_FC asSet = new CPGN_FC();

        /// <summary>
        /// autoSteerConfig PGN - 251 - FB
        /// </summary>
        public CPGN_FB asConfig = new CPGN_FB();


        /// <summary>
        /// machineData PGN - 239 - EF
        /// </summary>
        public CPGN_EF maData = new CPGN_EF();

        /// <summary>
        /// machineConfig PGN - 238 - EE
        /// </summary>
        public CPGN_EE maConfig = new CPGN_EE();


        ///// <summary>
        ///// LatitudeLongitude - D0 - 
        ///// </summary>
        //public CPGN_D0 p_D0 = new CPGN_D0();

    }
}

