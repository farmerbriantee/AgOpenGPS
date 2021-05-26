using System;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        //Latitude
        public class CPGN_D0
        {
            /// <summary>
            ///  Latitude Longitude 8 bytes as modified float
            ///  double lat = (encodedAngle / (0x7FFFFFFF / 90.0));
            ///  double lon = (encodedAngle / (0x7FFFFFFF / 180.0));
            /// </summary>
            public byte[] latLong = new byte[] { 0x80, 0x81, 0x7F, 0xD0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0xCC };


            public void LoadLatitudeLongitude(double lat, double lon)
            {
                
                int encodedAngle = (int)(lat * (0x7FFFFFFF / 90.0));
                //double angle = (encodedAngle / (0x7FFFFFFF / 90.0));

                byte[] lat6 = BitConverter.GetBytes(encodedAngle);
                Array.Copy(lat6, 0, latLong, 5, 4);

                encodedAngle = (int)(lon * (0x7FFFFFFF / 180.0));
                //double angle = (encodedAngle / (0x7FFFFFFF / 180.0));

                lat6 = BitConverter.GetBytes(encodedAngle);
                Array.Copy(lat6, 0, latLong, 9, 4);
            }
        }

        //AutoSteerData
        public class CPGN_FE
        {
            /// <summary>
            /// 8 bytes
            /// </summary>
            public byte[] pgn = new byte[] { 0x80, 0x81, 0x7f, 0xFE, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0xCC };
            public int speedLo = 5;
            public int speedHi = 6;
            public int status = 7;
            public int steerAngleLo = 8;
            public int steerAngleHi = 9;
            public int lineDistance  = 10;
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
                pgn[gainProportional] = Properties.Settings.Default.setAS_Kp;
                pgn[highPWM] = Properties.Settings.Default.setAS_highSteerPWM;
                pgn[lowPWM] = Properties.Settings.Default.setAS_lowSteerPWM;
                pgn[minPWM] = Properties.Settings.Default.setAS_minSteerPWM;
                pgn[countsPerDegree] = Properties.Settings.Default.setAS_countsPerDegree;
                pgn[wasOffsetHi] = unchecked((byte)(Properties.Settings.Default.setAS_wasOffset >> 8));;
                pgn[wasOffsetLo] = unchecked((byte)(Properties.Settings.Default.setAS_Kp));
                pgn[ackerman] = Properties.Settings.Default.setAS_ackerman;
            }

            public void Reset()
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
            public int set1 = 8;
            public int angVel  = 9;
            //public int  = 10;
            //public int  = 11;
            //public int  = 12;

            public CPGN_FB()
            {
                pgn[set0] = 0;
                pgn[maxPulse] = 0;
                pgn[minSpeed] = 0;
                pgn[set1] = 0;
                pgn[angVel] = 0;
            }

            public void Reset()
            {
            }
        }

        //Machine Data
        public class CPGN_EF
        {
            /// <summary>
            /// PGN - 239 - EF 
            /// uturn=5  tree=6  hydLift = 8 
            /// </summary>
            public byte[] pgn = new byte[] { 0x80, 0x81, 0x7f, 0xEF, 8, 0, 0, 0, 0, 0, 0, 0, 0,  0xCC };
            public int uturn = 5;
            public int tree = 6;
            public int hydLift = 7;
            public int tram = 8;
            //public int  = 9;
            //public int  = 10;
            public int  sc1to8= 11;
            public int  sc9to16= 12;

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
            public byte[] pgn = new byte[] { 0x80, 0x81, 0x7f, 0xEE, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0xCC };
            public int  raiseTime = 5;
            public int  lowerTime = 6;
            public int enableHyd = 7;
            public int set0 = 8;
            //public int  = 9;
            //public int  = 10;
            //public int  = 11;
            //public int  = 12;

            // PGN  - 127.239 0x7FEF
            int crc = 0;

            public CPGN_EE()
            {
                pgn[raiseTime] = Properties.Vehicle.Default.setArdMac_hydRaiseTime;
                pgn[lowerTime] = Properties.Vehicle.Default.setArdMac_hydLowerTime;
                pgn[enableHyd] = Properties.Vehicle.Default.setArdMac_isHydEnabled;
                pgn[set0] = Properties.Vehicle.Default.setArdMac_setting0;
            }

            public void MakeCRC()
            {
                crc = 0;
                for (int i = 2; i < pgn.Length - 1; i++)
                {
                    crc += pgn[i];
                }
                pgn[pgn.Length - 1] = (byte)crc;
            }

            public void Reset()
            {
            }
        }


        //pgn instances

        /// <summary>
        /// autoSteerData - FE - 254 - 
        /// </summary>
        public CPGN_FE p_254 = new CPGN_FE();

        /// <summary>
        /// autoSteerSettings PGN - 252 - FC
        /// </summary>
        public CPGN_FC p_252 = new CPGN_FC();

        /// <summary>
        /// autoSteerConfig PGN - 251 - FB
        /// </summary>
        public CPGN_FB p_251 = new CPGN_FB();


        /// <summary>
        /// machineData PGN - 239 - EF
        /// </summary>
        public CPGN_EF p_239 = new CPGN_EF();

        /// <summary>
        /// machineConfig PGN - 238 - EE
        /// </summary>
        public CPGN_EE p_238 = new CPGN_EE();


        /// <summary>
        /// LatitudeLongitude - D0 - 
        /// </summary>
        //public CPGN_D0 p_208 = new CPGN_D0();

    }
}
    
