//Please, if you use this, share the improvements

using System;
using System.Globalization;
using System.Text;

namespace AgOpenGPS
{
    #region NMEA_Sentence_Guide

    //$GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M ,  ,*47
    //   0     1      2      3    4      5 6  7  8   9    10 11  12 13  14
    //        Time      Lat       Lon

    /*
    GGA - essential fix data which provide 3D location and accuracy data.

     $GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,,*47

    Where:
         GGA          Global Positioning System Fix Data
         123519       Fix taken at 12:35:19 UTC
         4807.038,N   Latitude 48 deg 07.038' N
         01131.000,E  Longitude 11 deg 31.000' E
         1            Fix quality: 0 = invalid
                                   1 = GPS fix (SPS)
                                   2 = DGPS fix
                                   3 = PPS fix
                                   4 = Real Time Kinematic
                                   5 = Float RTK
                                   6 = estimated (dead reckoning) (2.3 feature)
                                   7 = Manual input mode
                                   8 = Simulation mode
     (7)    08           Number of satellites being tracked
     (8)    0.9          Horizontal dilution of position
         545.4,M      Altitude, Meters, above mean sea level
         46.9,M       Height of geoid (mean sea level) above WGS84
                          ellipsoid
         (empty field) time in seconds since last DGPS update
         (empty field) DGPS station ID number
         *47          the checksum data, always begins with *
     *
     *
   //$GPRMC,123519,A,4807.038,N,01131.000,E,022.4,084.4,230394,003.1,W*6A
   //  0      1    2   3      4    5      6   7     8     9     10   11
    //        Time      Lat        Lon       knots  Ang   Date  MagV

    Where:
         RMC          Recommended Minimum sentence C
         123519       Fix taken at 12:35:19 UTC
         A            Status A=active or V=Void.
         4807.038,N   Latitude 48 deg 07.038' N
         01131.000,E  Longitude 11 deg 31.000' E
         022.4        Speed over the ground in knots
         084.4        Track angle in degrees True
         230394       Date - 23rd of March 1994
         003.1,W      Magnetic Variation
         *6A          The checksum data, always begins with *
     *
   $GPVTG,054.7,T,034.4,M,005.5,N,010.2,K*48
     *
        VTG          Track made good and ground speed
        054.7,T      True track made good (degrees)
        034.4,M      Magnetic track made good
        005.5,N      Ground speed, knots
        010.2,K      Ground speed, Kilometers per hour
        *48          Checksum
        *
$PAOGI
 * * From GGA:
(1 , 2) 123519 Fix taken at 1219 UTC
(3 , 4) 4807.038,N Latitude 48 deg 07.038' N
(5, 6) 01131.000,E Longitude 11 deg 31.000' E
(7) 1 Fix quality: 0 = invalid
1 = GPS fix (SPS)
2 = DGPS fix
3 = PPS fix
4 = Real Time Kinematic
5 = Float RTK
6 = estimated (dead reckoning) (2.3 feature)
7 = Manual input mode
8 = Simulation mode
(8) 08 Number of satellites being tracked
(9) 0.9 Horizontal dilution of position
(10, 11) 545.4,M Altitude, Meters, above mean sea level
(12) 1.2 time in seconds since last DGPS update

From RMC or VTG:
(13) 022.4 Speed over the ground in knots (Or would you prefer KPH)
(14) 084.4 Track angle in degrees True

FROM IMU:
(15) XXX.xx IMU Heading in degrees True
(16) XXX.xx Roll angle in degrees (What is a positive roll, left leaning - left down, right up?)
(17) XXX.xx Pitch angle in degrees (Positive pitch = nose up)
(18) XXX.xx Yaw Rate in Degrees / second
(19) T/F IMU status - Valid IMU Fusion

*CHKSUM
*
*             /*       Time, yaw, tilt, range for moving baseline RTK
An example of the PTNL,AVR message string is:

$PTNL,AVR,181059.6,+149.4688,Yaw,+0.0134,Tilt,,,60.191,3,2.5,6*00

AVR message fields
Field	Meaning
0	Message ID $PTNL,AVR
1	UTC of vector fix
2	Yaw angle in degrees
3	Yaw
4	Tilt angle in degrees
5	Tilt
6	Reserved
7	Reserved
8	Range in meters
9	GPS quality indicator:
0: Fix not available or invalid
1: Autonomous GPS fix
2: Differential carrier phase solution RTK (Float)
3: Differential carrier phase solution RTK (Fix)
4: Differential code-based solution, DGPS
10	PDOP
11	Number of satellites used in solution
12	The checksum data, always begins with *
    */

    #endregion NMEA_Sentence_Guide

    public class CNMEA
    {
        //WGS84 Lat Long
        public double latitude, longitude;

        public double latStart, lonStart;

        public double actualEasting, actualNorthing;
        public double zone;
        public double centralMeridian, convergenceAngle;

        public bool updatedGGA, updatedOGI, updatedRMC;

        public string rawBuffer = "";
        private string[] words;
        private string nextNMEASentence = "";
        public string fixFrom;

        //UTM coordinates
        //public double northing, easting;
        public vec2 fix = new vec2(0, 0);

        //used to offset the antenna position to compensate for drift
        public vec2 fixOffset = new vec2(0, 0);

        //other GIS Info
        public double altitude, speed;

        public double headingTrue, headingHDT, hdop, ageDiff;

        //imu
        public double nRoll, nPitch, nYaw, nAngularVelocity;

        public bool isValidIMU;
        public int fixQuality;
        public int satellitesTracked;
        public string status = "q";
        public DateTime utcDateTime;
        public char hemisphere = 'N';

        //UTM numbers are huge, these cut them way down.
        public int utmNorth, utmEast;

        public StringBuilder logNMEASentence = new StringBuilder();
        private readonly FormGPS mf;
        private int nmeaCntr = 0;

        public CNMEA(FormGPS f)
        {
            //constructor, grab the main form reference
            mf = f;
            fixFrom = Properties.Settings.Default.setGPS_fixFromWhichSentence;
            latStart = 0;
            lonStart = 0;
        }

        //ParseNMEA
        public void UpdateNorthingEasting()
        {
            double[] xy = DecDeg2UTM(latitude, longitude);
            //keep a copy of actual easting and northings
            actualEasting = xy[0];
            actualNorthing = xy[1];

            //if a field is open, the real one is subtracted from the integer
            fix.easting = xy[0] - utmEast + fixOffset.easting;
            fix.northing = xy[1] - utmNorth + fixOffset.northing;

            double east = fix.easting;
            double nort = fix.northing;

            //compensate for the fact the zones lines are a grid and the world is round
            fix.easting = (Math.Cos(-convergenceAngle) * east) - (Math.Sin(-convergenceAngle) * nort);
            fix.northing = (Math.Sin(-convergenceAngle) * east) + (Math.Cos(-convergenceAngle) * nort);

            //east = fix.easting;
            //nort = fix.northing;

            //go back again - programming reference
            //fix.easting = (Math.Cos(convergenceAngle) * east) - (Math.Sin(convergenceAngle) * nort);
            //fix.northing = (Math.Sin(convergenceAngle) * east) + (Math.Cos(convergenceAngle) * nort);
        }

        public void ParseNMEA()
        {
            if (rawBuffer == null) return;

            //find end of a sentence
            int cr = rawBuffer.IndexOf("\n", StringComparison.Ordinal);
            if (cr == -1) return; // No end found, wait for more data

            // Find start of next sentence
            int dollar = rawBuffer.IndexOf("$", StringComparison.Ordinal);
            if (dollar == -1) return;

            //if the $ isn't first, get rid of the tail of corrupt sentence
            if (dollar >= cr) rawBuffer = rawBuffer.Substring(dollar);

            cr = rawBuffer.IndexOf("\n", StringComparison.Ordinal);
            if (cr == -1) return; // No end found, wait for more data
            dollar = rawBuffer.IndexOf("$", StringComparison.Ordinal);
            if (dollar == -1) return;

            //if the $ isn't first, get rid of the tail of corrupt sentence
            if (dollar >= cr) rawBuffer = rawBuffer.Substring(dollar);

            cr = rawBuffer.IndexOf("\n", StringComparison.Ordinal);
            dollar = rawBuffer.IndexOf("$", StringComparison.Ordinal);
            if (cr == -1 || dollar == -1) return;

            //mf.recvSentenceSettings = rawBuffer;

            //now we have a complete sentence or more somewhere in the portData
            while (true)
            {
                //extract the next NMEA single sentence
                nextNMEASentence = Parse();
                if (nextNMEASentence == null) return;

                //parse them accordingly
                words = nextNMEASentence.Split(',');
                if (words.Length < 3) return;

                if (words[0] == "$GPGGA" || words[0] == "$GNGGA") ParseGGA();
                if (words[0] == "$GPVTG" || words[0] == "$GNVTG") ParseVTG();
                if (words[0] == "$GPRMC" || words[0] == "$GNRMC") ParseRMC();
                if (words[0] == "$GPHDT" || words[0] == "$GNHDT") ParseHDT();
                if (words[0] == "$PAOGI") ParseOGI();
                if (words[0] == "$PTNL") ParseAVR();
                if (words[0] == "$GNTRA") ParseTRA();

            }// while still data
        }

        private double rollK, Pc, G, Xp, Zp, XeRoll;
        private double P = 1.0;
        private readonly double varRoll = 0.1; // variance, smaller, more faster filtering
        private readonly double varProcess = 0.0003;

        private void ParseAVR()
        {
            if (!String.IsNullOrEmpty(words[1]))
            {
                //True heading
                // 0 1 2 3 4 5 6 7 8 9
                // $PTNL,AVR,145331.50,+35.9990,Yaw,-7.8209,Tilt,-0.4305,Roll,444.232,3,1.2,17 * 03
                //Field
                // Meaning
                //0 Message ID $PTNL,AVR
                //1 UTC of vector fix
                //2 Yaw angle, in degrees
                //3 Yaw
                //4 Tilt angle, in degrees
                //5 Tilt
                //6 Roll angle, in degrees
                //7 Roll
                //8 Range, in meters
                //9 GPS quality indicator:
                // 0: Fix not available or invalid
                // 1: Autonomous GPS fix
                // 2: Differential carrier phase solution RTK(Float)
                // 3: Differential carrier phase solution RTK(Fix)
                // 4: Differential code-based solution, DGPS
                //10 PDOP
                //11 Number of satellites used in solution
                //12 The checksum data, always begins with *

                if (words[8] == "Roll")
                    double.TryParse(words[7], NumberStyles.Float, CultureInfo.InvariantCulture, out nRoll);
                else
                    double.TryParse(words[5], NumberStyles.Float, CultureInfo.InvariantCulture, out nRoll);

                if (mf.ahrs.isRollFromGPS)

                //input to the kalman filter
                {
                    //added by Andreas Ortner
                    rollK = nRoll;

                    //Kalman filter
                    Pc = P + varProcess;
                    G = Pc / (Pc + varRoll);
                    P = (1 - G) * Pc;
                    Xp = XeRoll;
                    Zp = Xp;
                    XeRoll = (G * (rollK - Zp)) + Xp;

                    mf.ahrs.rollX16 = (int)(XeRoll * 16);
                }
            }
        }

        // Returns a valid NMEA sentence from the pile from portData
        public string Parse()
        {
            string sentence;
            do
            {
                //double check for valid sentence
                // Find start of next sentence
                int start = rawBuffer.IndexOf("$", StringComparison.Ordinal);
                if (start == -1) return null;
                rawBuffer = rawBuffer.Substring(start);

                // Find end of sentence
                int end = rawBuffer.IndexOf("\n", StringComparison.Ordinal);
                if (end == -1) return null;

                //the NMEA sentence to be parsed
                sentence = rawBuffer.Substring(0, end + 1);

                //remove the processed sentence from the rawBuffer
                rawBuffer = rawBuffer.Substring(end + 1);
            }

            //if sentence has valid checksum, its all good
            while (!ValidateChecksum(sentence));

            //do we want to log? Grab before pieces are missing
            if (mf.isLogNMEA && nmeaCntr++ > 3)
            {
                logNMEASentence.Append(sentence);
                nmeaCntr = 0;
            }

            // Remove trailing checksum and \r\n and return
            sentence = sentence.Substring(0, sentence.IndexOf("*", StringComparison.Ordinal));

            return sentence;
        }

        //The indivdual sentence parsing
        private void ParseGGA()
        {
            //$GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M ,  ,*47
            //   0     1      2      3    4      5 6  7  8   9    10 11  12 13  14
            //        Time      Lat       Lon

            //is the sentence GGA
            if (!String.IsNullOrEmpty(words[2]) && !String.IsNullOrEmpty(words[3])
                && !String.IsNullOrEmpty(words[4]) && !String.IsNullOrEmpty(words[5]))
            {
                if (fixFrom == "GGA")
                {
                    //get latitude and convert to decimal degrees
                    int decim = words[2].IndexOf(".", StringComparison.Ordinal);
                    decim -= 2;
                    double.TryParse(words[2].Substring(0, decim), NumberStyles.Float, CultureInfo.InvariantCulture, out latitude);
                    double.TryParse(words[2].Substring(decim), NumberStyles.Float, CultureInfo.InvariantCulture, out double temp);
                    temp *= 0.01666666666666666666666666666667;
                    latitude += temp;
                    if (words[3] == "S")
                    {
                        latitude *= -1;
                        hemisphere = 'S';
                    }
                    else { hemisphere = 'N'; }

                    //get longitude and convert to decimal degrees
                    decim = words[4].IndexOf(".", StringComparison.Ordinal);
                    decim -= 2;
                    double.TryParse(words[4].Substring(0, decim), NumberStyles.Float, CultureInfo.InvariantCulture, out longitude);
                    double.TryParse(words[4].Substring(decim), NumberStyles.Float, CultureInfo.InvariantCulture, out temp);
                    longitude += temp * 0.01666666666666666666666666666667;

                    { if (words[5] == "W") longitude *= -1; }

                    //calculate zone and UTM coords
                    UpdateNorthingEasting();
                }

                //fixQuality
                int.TryParse(words[6], NumberStyles.Float, CultureInfo.InvariantCulture, out fixQuality);

                //satellites tracked
                int.TryParse(words[7], NumberStyles.Float, CultureInfo.InvariantCulture, out satellitesTracked);

                //hdop
                double.TryParse(words[8], NumberStyles.Float, CultureInfo.InvariantCulture, out hdop);

                //altitude
                double.TryParse(words[9], NumberStyles.Float, CultureInfo.InvariantCulture, out altitude);

                //age of differential
                double.TryParse(words[11], NumberStyles.Float, CultureInfo.InvariantCulture, out ageDiff);

                updatedGGA = true;
                mf.recvCounter = 0;
            }
        }

        private void ParseOGI()
        {
            //PAOGI parsing of the sentence
            //make sure there aren't missing coords in sentence
            if (!String.IsNullOrEmpty(words[2]) && !String.IsNullOrEmpty(words[3])
                && !String.IsNullOrEmpty(words[4]) && !String.IsNullOrEmpty(words[5]))
            {
                if (fixFrom == "OGI")
                {
                    //get latitude and convert to decimal degrees
                    double.TryParse(words[2].Substring(0, 2), NumberStyles.Float, CultureInfo.InvariantCulture, out latitude);
                    double.TryParse(words[2].Substring(2), NumberStyles.Float, CultureInfo.InvariantCulture, out double temp);
                    temp *= 0.01666666666666666666666666666667;
                    latitude += temp;
                    if (words[3] == "S")
                    {
                        latitude *= -1;
                        hemisphere = 'S';
                    }
                    else { hemisphere = 'N'; }

                    //get longitude and convert to decimal degrees
                    double.TryParse(words[4].Substring(0, 3), NumberStyles.Float, CultureInfo.InvariantCulture, out longitude);
                    double.TryParse(words[4].Substring(3), NumberStyles.Float, CultureInfo.InvariantCulture, out temp);
                    longitude += temp * 0.01666666666666666666666666666667;

                    { if (words[5] == "W") longitude *= -1; }

                    //calculate zone and UTM coords
                    UpdateNorthingEasting();
                }

                //fixQuality
                int.TryParse(words[6], NumberStyles.Float, CultureInfo.InvariantCulture, out fixQuality);

                //satellites tracked
                int.TryParse(words[7], NumberStyles.Float, CultureInfo.InvariantCulture, out satellitesTracked);

                //hdop
                double.TryParse(words[8], NumberStyles.Float, CultureInfo.InvariantCulture, out hdop);

                //altitude
                double.TryParse(words[9], NumberStyles.Float, CultureInfo.InvariantCulture, out altitude);

                //age of differential
                double.TryParse(words[11], NumberStyles.Float, CultureInfo.InvariantCulture, out ageDiff);

                //kph for speed - knots read
                double.TryParse(words[12], NumberStyles.Float, CultureInfo.InvariantCulture, out speed);
                speed = Math.Round(speed * 1.852, 1);

                //True heading
                double.TryParse(words[13], NumberStyles.Float, CultureInfo.InvariantCulture, out headingTrue);

                //roll
                double.TryParse(words[14], NumberStyles.Float, CultureInfo.InvariantCulture, out nRoll);
                if (mf.ahrs.isRollFromGPS) mf.ahrs.rollX16 = (int)(nRoll * 16);

                //pitch
                double.TryParse(words[15], NumberStyles.Float, CultureInfo.InvariantCulture, out nPitch);

                //yaw
                double.TryParse(words[16], NumberStyles.Float, CultureInfo.InvariantCulture, out nYaw);
                if (mf.ahrs.isHeadingFromPAOGI)
                {
                    mf.ahrs.correctionHeadingX16 = (int)(nYaw * 16);
                }

                //Angular velocity
                double.TryParse(words[17], NumberStyles.Float, CultureInfo.InvariantCulture, out nAngularVelocity);

                //is imu valid fusion
                isValidIMU = words[18] == "T";

                //update the watchdog
                mf.recvCounter = 0;
                updatedOGI = true;

                //average the speed
                mf.avgSpeed[mf.ringCounter] = speed;
                if (mf.ringCounter++ > 8) mf.ringCounter = 0;
            }
        }

        private void ParseVTG()
        {
            //$GPVTG,054.7,T,034.4,M,005.5,N,010.2,K*48
            //is the sentence GGA
            if (!String.IsNullOrEmpty(words[1]) && !String.IsNullOrEmpty(words[5]))
            {
                //kph for speed - knots read
                double.TryParse(words[5], NumberStyles.Float, CultureInfo.InvariantCulture, out speed);
                speed = Math.Round(speed * 1.852, 1);

                //True heading
                double.TryParse(words[1], NumberStyles.Float, CultureInfo.InvariantCulture, out headingTrue);

                //average the speeds for display, not calcs
                mf.avgSpeed[mf.ringCounter] = speed;
                if (mf.ringCounter++ > 8) mf.ringCounter = 0;
            }
        }

        private void ParseHDT()
        {
            /* $GNHDT,123.456,T * 00

            Field Meaning
            0   Message ID $GNHDT
            1   Heading in degrees
            2   T: Indicates heading relative to True North
            3   The checksum data, always begins with *
                */

            if (!String.IsNullOrEmpty(words[1]))
            {
                //True heading
                double.TryParse(words[1], NumberStyles.Float, CultureInfo.InvariantCulture, out headingHDT);
            }
        }

        private void ParseTRA()  //tra contains hdt and roll for the ub482 receiver
        {
            if (!String.IsNullOrEmpty(words[1]))
            {

                double.TryParse(words[2], NumberStyles.Float, CultureInfo.InvariantCulture, out headingHDT);
                //  Console.WriteLine(headingHDT);
                double.TryParse(words[3], NumberStyles.Float, CultureInfo.InvariantCulture, out nRoll);
                // Console.WriteLine(nRoll);

                int trasolution;

                int.TryParse(words[5], NumberStyles.Float, CultureInfo.InvariantCulture, out trasolution);
                if (trasolution != 4) nRoll = 0;
                // Console.WriteLine(trasolution);
                if (mf.ahrs.isRollFromGPS)

                //input to the kalman filter
                {
                    ////added by Andreas Ortner
                    //rollK = nRoll;

                    ////Kalman filter
                    //Pc = P + varProcess;
                    //G = Pc / (Pc + varRoll);
                    //P = (1 - G) * Pc;
                    //Xp = XeRoll;
                    //Zp = Xp;
                    //XeRoll = (G * (rollK - Zp)) + Xp;

                    //mf.ahrs.rollX16 = (int)(XeRoll * 16);
                    mf.ahrs.rollX16 = (int)(nRoll * 16);
                }
            }
        }

        private void ParseRMC()
        {
            //GPRMC parsing of the sentence
            //make sure there aren't missing coords in sentence
            if (!String.IsNullOrEmpty(words[3]) && !String.IsNullOrEmpty(words[4])
                && !String.IsNullOrEmpty(words[5]) && !String.IsNullOrEmpty(words[6]))
            {
                if (fixFrom == "RMC")
                {
                    //get latitude and convert to decimal degrees
                    double.TryParse(words[3].Substring(0, 2), NumberStyles.Float, CultureInfo.InvariantCulture, out latitude);
                    double.TryParse(words[3].Substring(2), NumberStyles.Float, CultureInfo.InvariantCulture, out double temp);
                    latitude += temp * 0.01666666666666666666666666666667;

                    if (words[4] == "S")
                    {
                        latitude *= -1;
                        hemisphere = 'S';
                    }
                    else { hemisphere = 'N'; }

                    //get longitude and convert to decimal degrees
                    double.TryParse(words[5].Substring(0, 3), NumberStyles.Float, CultureInfo.InvariantCulture, out longitude);
                    double.TryParse(words[5].Substring(3), NumberStyles.Float, CultureInfo.InvariantCulture, out temp);
                    longitude += temp * 0.01666666666666666666666666666667;

                    if (words[6] == "W") longitude *= -1;

                    //calculate zone and UTM coords
                    UpdateNorthingEasting();
                }

                //Convert from knots to kph for speed
                double.TryParse(words[7], NumberStyles.Float, CultureInfo.InvariantCulture, out speed);
                speed = Math.Round(speed * 1.852, 1);

                //True heading
                double.TryParse(words[8], NumberStyles.Float, CultureInfo.InvariantCulture, out headingTrue);

                //Status
                if (String.IsNullOrEmpty(words[2]))
                {
                    status = "z";
                }
                else
                {
                    try { status = words[2]; }
                    catch (Exception e)
                    {
                        mf.WriteErrorLog("Parse RMC" + e);
                    }
                }

                mf.recvCounter = 0;
                updatedRMC = true;

                mf.avgSpeed[mf.ringCounter] = speed;
                if (mf.ringCounter++ > 8) mf.ringCounter = 0;
            }
        }

        //checks the checksum against the string
        public bool ValidateChecksum(string Sentence)
        {
            int sum = 0;
            try
            {
                char[] sentenceChars = Sentence.ToCharArray();
                // All character xor:ed results in the trailing hex checksum
                // The checksum calc starts after '$' and ends before '*'
                int inx;
                for (inx = 1; ; inx++)
                {
                    if (inx >= sentenceChars.Length) // No checksum found
                        return false;
                    var tmp = sentenceChars[inx];
                    // Indicates end of data and start of checksum
                    if (tmp == '*') break;
                    sum ^= tmp;    // Build checksum
                }
                // Calculated checksum converted to a 2 digit hex string
                string sumStr = String.Format("{0:X2}", sum);

                // Compare to checksum in sentence
                return sumStr.Equals(Sentence.Substring(inx + 1, 2));
            }
            catch (Exception e)
            {
                mf.WriteErrorLog("Validate Checksum" + e);
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private const double sm_a = 6378137.0;

        private const double sm_b = 6356752.314;
        private const double UTMScaleFactor = 0.9996;
        //private double UTMScaleFactor2 = 1.0004001600640256102440976390556;

        private double ArcLengthOfMeridian(double phi)
        {
            const double n = (sm_a - sm_b) / (sm_a + sm_b);
            double alpha = ((sm_a + sm_b) / 2.0) * (1.0 + (Math.Pow(n, 2.0) / 4.0) + (Math.Pow(n, 4.0) / 64.0));
            double beta = (-3.0 * n / 2.0) + (9.0 * Math.Pow(n, 3.0) * 0.0625) + (-3.0 * Math.Pow(n, 5.0) / 32.0);
            double gamma = (15.0 * Math.Pow(n, 2.0) * 0.0625) + (-15.0 * Math.Pow(n, 4.0) / 32.0);
            double delta = (-35.0 * Math.Pow(n, 3.0) / 48.0) + (105.0 * Math.Pow(n, 5.0) / 256.0);
            double epsilon = (315.0 * Math.Pow(n, 4.0) / 512.0);
            return alpha * (phi + (beta * Math.Sin(2.0 * phi))
                    + (gamma * Math.Sin(4.0 * phi))
                    + (delta * Math.Sin(6.0 * phi))
                    + (epsilon * Math.Sin(8.0 * phi)));
        }

        private double[] MapLatLonToXY(double phi, double lambda, double lambda0)
        {
            double[] xy = new double[2];
            double ep2 = (Math.Pow(sm_a, 2.0) - Math.Pow(sm_b, 2.0)) / Math.Pow(sm_b, 2.0);
            double nu2 = ep2 * Math.Pow(Math.Cos(phi), 2.0);
            double n = Math.Pow(sm_a, 2.0) / (sm_b * Math.Sqrt(1 + nu2));
            double t = Math.Tan(phi);
            double t2 = t * t;
            double l = lambda - lambda0;
            double l3Coef = 1.0 - t2 + nu2;
            double l4Coef = 5.0 - t2 + (9 * nu2) + (4.0 * (nu2 * nu2));
            double l5Coef = 5.0 - (18.0 * t2) + (t2 * t2) + (14.0 * nu2) - (58.0 * t2 * nu2);
            double l6Coef = 61.0 - (58.0 * t2) + (t2 * t2) + (270.0 * nu2) - (330.0 * t2 * nu2);
            double l7Coef = 61.0 - (479.0 * t2) + (179.0 * (t2 * t2)) - (t2 * t2 * t2);
            double l8Coef = 1385.0 - (3111.0 * t2) + (543.0 * (t2 * t2)) - (t2 * t2 * t2);

            /* Calculate easting (x) */
            xy[0] = (n * Math.Cos(phi) * l)
                + (n / 6.0 * Math.Pow(Math.Cos(phi), 3.0) * l3Coef * Math.Pow(l, 3.0))
                + (n / 120.0 * Math.Pow(Math.Cos(phi), 5.0) * l5Coef * Math.Pow(l, 5.0))
                + (n / 5040.0 * Math.Pow(Math.Cos(phi), 7.0) * l7Coef * Math.Pow(l, 7.0));

            /* Calculate northing (y) */
            xy[1] = ArcLengthOfMeridian(phi)
                + (t / 2.0 * n * Math.Pow(Math.Cos(phi), 2.0) * Math.Pow(l, 2.0))
                + (t / 24.0 * n * Math.Pow(Math.Cos(phi), 4.0) * l4Coef * Math.Pow(l, 4.0))
                + (t / 720.0 * n * Math.Pow(Math.Cos(phi), 6.0) * l6Coef * Math.Pow(l, 6.0))
                + (t / 40320.0 * n * Math.Pow(Math.Cos(phi), 8.0) * l8Coef * Math.Pow(l, 8.0));

            return xy;
        }

        public double[] DecDeg2UTM(double latitude, double longitude)
        {
            //only calculate the zone once!
            if (!mf.isFirstFixPositionSet) zone = Math.Floor((longitude + 180.0) * 0.16666666666666666666666666666667) + 1;

            double[] xy = MapLatLonToXY(latitude * 0.01745329251994329576923690766743,
                                        longitude * 0.01745329251994329576923690766743,
                                        (-183.0 + (zone * 6.0)) * 0.01745329251994329576923690766743);

            xy[0] = (xy[0] * UTMScaleFactor) + 500000.0;
            xy[1] *= UTMScaleFactor;
            if (xy[1] < 0.0)
                xy[1] += 10000000.0;
            return xy;
        }
    }
}

//                #region $GPRMC

//                //GPRMC parsing of the sentence
//                //make sure there aren't missing coords in sentence
//                if (words[0] == "$GPRMC" & words[3] != "" & words[4] != "" & words[5] != "" & words[6] != "")
//                {
//                    //Status
//                    if (words[2] == String.Empty) status = "z";
//                    else
//                    {
//                        try { status = words[2]; }
//                        catch (ArgumentNullException) { }
//                    }

//                    //Date and Time
//                    if (words[1].Length != 0)
//                    {
//                        try
//                        {
//                            if (words[1].Length == 6)
//                            {
//                                // Only HHMMSS
//                                utcDateTime = new DateTime(
//                                    (int.Parse(words[9].Substring(4, 2)) + 2000),
//                                    int.Parse(words[9].Substring(2, 2)),
//                                    int.Parse(words[9].Substring(0, 2)),
//                                    int.Parse(words[1].Substring(0, 2)),
//                                    int.Parse(words[1].Substring(2, 2)),
//                                    int.Parse(words[1].Substring(4, 2)));
//                            }
//                            else
//                            {
//                                // HHMMSS.MS
//                                utcDateTime = new DateTime(
//                                    (int.Parse(words[9].Substring(4, 2)) + 2000),
//                                    int.Parse(words[9].Substring(2, 2)),
//                                    int.Parse(words[9].Substring(0, 2)),
//                                    int.Parse(words[1].Substring(0, 2)),
//                                    int.Parse(words[1].Substring(2, 2)),
//                                    int.Parse(words[1].Substring(4, 2)),
//                                    int.Parse(words[1].Substring(7)));
//                            }
//                        }
//                        catch (ArgumentNullException) { }
//                    }

//                    //update the receive counter that detects loss of communication
//                    mainForm.recvCounter = 0;
//                    //update that RMC data is newly updated
//                    updatedRMC = true;
//                }//end $GPRMC
//#endregion $GPRMC