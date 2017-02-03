//Please, if you use this, share the improvements

using System;
using System.Collections.Generic;
using System.Linq;
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
         08           Number of satellites being tracked
         0.9          Horizontal dilution of position
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
    */


    #endregion NMEA_Sentence_Guide

    public class CNMEA
    {
        //WGS84 Lat Long
        public double latitude = 0, longitude = 0;

        public bool updatedGGA = false, updatedVTG = false, updatedRMC = false;

        public string rawBuffer = "";
        public string theSent = "";
        private string[] words;
        private string nextNMEASentence = "";

        //UTM coordinates
        public double northing = 0, easting = 0;
        public int zone = 0;
 

        //other GIS Info
        public double altitude = 0, speed = 0;
        public double headingTrue = 0, hdop = 0;

        public int fixQuality = 0;
        public int satellitesTracked = 0;
        public string status = "q";
        public DateTime utcDateTime;

        //UTM numbers are huge, these cut them way down.
        public int utmNorth = 0, utmEast = 0;

        private FormGPS mf;

        public CNMEA(FormGPS f)
        {
            //constructor, grab the main form reference
            this.mf = f;
        }

        //ParseNMEA
        public void ParseNMEA()
        {
            if (rawBuffer == null) return;
            bool stillData = true;

                int cr, dollar;
            //find end of a sentence
            cr = rawBuffer.IndexOf("\r\n");
            if (cr == -1) return; // No end found, wait for more data

            // Find start of next sentence
            dollar = rawBuffer.IndexOf("$");
            if (dollar == -1) return;

            //if the $ isn't first, get rid of the tail of corrupt sentence
            if (dollar >= cr) rawBuffer = rawBuffer.Substring(dollar);
            
            cr = rawBuffer.IndexOf("\r\n");
            if (cr == -1) return; // No end found, wait for more data
            dollar = rawBuffer.IndexOf("$");
            if (dollar == -1) return;

            //if the $ isn't first, get rid of the tail of corrupt sentence
            if (dollar >= cr) rawBuffer = rawBuffer.Substring(dollar);
 
            cr = rawBuffer.IndexOf("\r\n");
            dollar = rawBuffer.IndexOf("$");
            if (cr == -1 || dollar == -1) return;

            stillData = true;

            theSent = "";

            //now we have a complete sentence or more somewhere in the portData
            while (stillData)       
            {
                //extract the next NMEA single sentence
                nextNMEASentence = Parse();              
                if (nextNMEASentence == null) return;

                //parse them accordingly
                words = nextNMEASentence.Split(',');
                if (words.Length < 9) return;

                if (words[0] == "$GPGGA") ParseGGA();
                if (words[0] == "$GPVTG") ParseVTG();
                if (words[0] == "$GPRMC") ParseRMC();

            }// while still data
                   
        }
 
         // Returns a valid NMEA sentence from the pile from portData
        public string Parse()
        {

            string sentence;
            int start, end;
            do
            {
                //double check for valid sentence
                // Find start of next sentence
                start = rawBuffer.IndexOf("$");
                if (start == -1) return null;
                rawBuffer = rawBuffer.Substring(start);

                // Find end of sentence
                end = rawBuffer.IndexOf("\r\n");
                if (end == -1) return null;

                //the NMEA sentence to be parsed
                sentence = rawBuffer.Substring(0, end + 2);
              
                //remove the processed sentence from the rawBuffer
                rawBuffer = rawBuffer.Substring(end + 2);
            }

            //if sentence has valid checksum, its all good
            while (!ValidateChecksum(sentence));

            // Remove trailing checksum and \r\n and return
            sentence = sentence.Substring(0, sentence.IndexOf("*"));
            return sentence;
        }

        //The indivdual sentence parsing
        private void ParseGGA()
        {

            //$GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M ,  ,*47
            //   0     1      2      3    4      5 6  7  8   9    10 11  12 13  14
            //        Time      Lat       Lon  

            //is the sentence GGA
            if (words[2] != "" & words[3] != "" & words[4] != "" & words[5] != "")
            {

                //get latitude and convert to decimal degrees
                try
                {
                    latitude = double.Parse(words[2].Substring(0, 2));
                    latitude = latitude + double.Parse(words[2].Substring(2)) * 0.01666666666666666666666666666667;
                }
                catch (ArgumentNullException) { }

                try { if (words[3] == "S") latitude *= -1; }
                catch (ArgumentNullException) { }

                //get longitude and convert to decimal degrees
                try
                {
                    longitude = double.Parse(words[4].Substring(0, 3));
                    longitude = longitude + double.Parse(words[4].Substring(3)) * 0.01666666666666666666666666666667;
                }
                catch (ArgumentNullException) { }

                try { if (words[5] == "W") longitude *= -1; }
                catch (ArgumentNullException) { }

                //calculate zone and UTM coords
                DecDeg2UTM(latitude, longitude);


                //fixQuality
                if (words[6] == String.Empty) fixQuality = 0;
                else
                {
                    try { fixQuality = int.Parse(words[6]); }
                    catch (ArgumentNullException) { }
                }
                //satellites tracked
                if (words[7] == String.Empty) satellitesTracked = 0;
                else
                {
                    try { satellitesTracked = int.Parse(words[7]); }
                    catch (ArgumentNullException) { }
                }

                if (words[8] == String.Empty) hdop = 0.0;
                else
                {
                    try { hdop = double.Parse(words[8]); }
                    catch (ArgumentNullException) { }
                }

                //altitude
                if (words[9] == String.Empty) altitude = -1;
                else
                {
                    try { altitude = double.Parse(words[9]); }
                    catch (ArgumentNullException) { }
                }
                theSent += nextNMEASentence;
                updatedGGA = true;
                mf.recvCounter = 0;
            }

        }

        private void ParseRMC()
        {
            //GPRMC parsing of the sentence 
            //make sure there aren't missing coords in sentence
            if (words[7] != "" & words[8] != "" & words[2] != "")
            {
                //get latitude and convert to decimal degrees
                try
                {
                    latitude = double.Parse(words[3].Substring(0, 2));
                    latitude = latitude + double.Parse(words[3].Substring(2)) * 0.01666666666666666666666666666667;
                }
                catch (ArgumentNullException) { }

                try { if (words[4] == "S") latitude *= -1; }
                catch (ArgumentNullException) { }

                //get longitude and convert to decimal degrees
                try
                {
                    longitude = double.Parse(words[5].Substring(0, 3));
                    longitude = longitude + double.Parse(words[5].Substring(3)) * 0.01666666666666666666666666666667;
                }
                catch (ArgumentNullException) { }

                try { if (words[6] == "W") longitude *= -1; }
                catch (ArgumentNullException) { }

                //calculate zone and UTM coords
                DecDeg2UTM(latitude, longitude);


                //Convert from knots to kph for speed
                if (words[7] == String.Empty) speed = -1;
                else
                {
                    try { speed = double.Parse(words[7]) * 1.852; speed = Math.Round(speed, 1); }
                    catch (ArgumentNullException) { }
                }

                //True heading
                if (words[8] == String.Empty) headingTrue = -1;
                else
                {
                    try { headingTrue = double.Parse(words[8]); }
                    catch (ArgumentNullException) { }
                }

                //Status
                if (words[2] == String.Empty) status = "z";
                else
                {
                    try { status = words[2]; }
                    catch (ArgumentNullException) { }
                }
                theSent += nextNMEASentence;
                mf.recvCounter = 0;
                updatedRMC = true;
            }


        }

        private void ParseVTG()
        {
            //$GPVTG,054.7,T,034.4,M,005.5,N,010.2,K*48
            //is the sentence GGA
            if (words[1] != "" & words[5] != "")
            {
                //kph for speed - knots read
                if (words[5] == String.Empty) speed = -1;
                else
                {
                    try { speed = double.Parse(words[5]) * 1.852; speed = Math.Round(speed, 1); }
                    catch (ArgumentNullException) { }
                }

                //True heading
                if (words[1] == String.Empty) headingTrue = -1;
                else
                {
                    try { headingTrue = double.Parse(words[1]); }
                    catch (ArgumentNullException) { }
                }
                updatedVTG = true;
                theSent += nextNMEASentence;
            }



        }
        
        //checks the checksum against the string
        public bool ValidateChecksum(string Sentence)
        {
            int sum = 0, inx;

            try
            {
                char[] sentence_chars = Sentence.ToCharArray();
                char tmp;
                // All character xor:ed results in the trailing hex checksum
                // The checksum calc starts after '$' and ends before '*'
                for (inx = 1; ; inx++)
                {
                    if (inx >= sentence_chars.Length) // No checksum found
                        return false;
                    tmp = sentence_chars[inx];
                    // Indicates end of data and start of checksum
                    if (tmp == '*')
                        break;
                    sum = sum ^ tmp;    // Build checksum
                }
                // Calculated checksum converted to a 2 digit hex string
                string sum_str = String.Format("{0:X2}", sum);
 
            // Compare to checksum in sentence
            return sum_str.Equals(Sentence.Substring(inx + 1, 2));
            }
            catch (ArgumentNullException) { return false; }
         }

        public double Distance(double northing1, double easting1, double northing2, double easting2)
        {
            return Math.Sqrt(
                Math.Pow((easting1 - easting2), 2) +
                Math.Pow((northing1 - northing2), 2));
        }

        #region (DecDeg2UTM)   Decimal Degrees to UTM Function

        // Parameters for the WGS84 ellipsoid
        private const double WGS84_E2 = 0.006694379990197;
        private const double WGS84_E4 = WGS84_E2 * WGS84_E2;
        private const double WGS84_E6 = WGS84_E4 * WGS84_E2;
        private const double WGS84_SEMI_MAJOR_AXIS = 6378137.0;
        private const double WGS84_SEMI_MINOR_AXIS = 6356752.314245;
        // Parameters for UTM projection
        private const double UTM_LONGITUDE_OF_ORIGIN = 3.0 / 180 * Math.PI;
        private const double UTM_LATITUDE_OF_ORIGIN = 0;
        private const double UTM_FALSE_EASTING = 500000;
        private const double UTM_FALSE_NORTHING_N = 0;    // Northern hemisphere
        private const double UTM_FALSE_NORTHING_S = 10000000; // Southern hemisphere
        private const double UTM_SCALE_FACTOR = 0.9996;
        // Takes a position in latitude / longitude (WGS84) as input
        private void DecDeg2UTM(double latitude, double longitude)
        {
            // Normalize longitude into Zone, 6 degrees
            int int_zone = (int)(longitude / 6.0);
            if (longitude < 0)
                int_zone--;
            longitude -= (double)int_zone * 6.0;
            zone = int_zone + 31;    // UTM zone
            // Convert from decimal degrees to radians
            longitude = glm.radians(longitude);
            latitude = glm.radians(latitude);
            // Projection
            double M = WGS84_SEMI_MAJOR_AXIS * m_calc(latitude);
            double M_origin = WGS84_SEMI_MAJOR_AXIS * m_calc(UTM_LATITUDE_OF_ORIGIN);
            double A = (longitude - UTM_LONGITUDE_OF_ORIGIN) * Math.Cos(latitude);
            double A2 = A * A;
            double e2_prim = WGS84_E2 / (1 - WGS84_E2);
            double C = e2_prim * Math.Pow(Math.Cos(latitude), 2);
            double T = Math.Tan(latitude);
            T *= T;
            double v = WGS84_SEMI_MAJOR_AXIS / Math.Sqrt(1 - WGS84_E2 *
                Math.Pow(Math.Sin(latitude), 2));
            northing = UTM_SCALE_FACTOR * (M - M_origin + v * Math.Tan(latitude) * (
                A2 / 2 + (5 - T + 9 * C + 4 * C * C) * A2 * A2 / 24 +
                (61 - 58 * T + T * T + 600 * C - 330 * e2_prim) *
                A2 * A2 * A2 / 720));
            if (latitude < 0)
                northing += UTM_FALSE_NORTHING_S;
            easting = UTM_FALSE_EASTING + UTM_SCALE_FACTOR * v * (
                A + (1 - T + C) * A2 * A / 6 +
                (5 - 18 * T + T * T + 72 * C - 58 * e2_prim) * A2 * A2 * A / 120);

            northing -= utmNorth;
            easting -= utmEast;
        }
        // Returns position in UTM easting/northing/zone (in meters)
        private double m_calc(double lat)
        {
            return (1 - WGS84_E2 / 4 - 3 * WGS84_E4 / 64 - 5 * WGS84_E6 / 256) * lat -
                 (3 * WGS84_E2 / 8 + 3 * WGS84_E4 / 32 + 45 * WGS84_E6 / 1024) *
                 Math.Sin(2 * lat) + (15 * WGS84_E4 / 256 + 45 * WGS84_E6 / 1024) *
                 Math.Sin(4 * lat) - (35 * WGS84_E6 / 3072) * Math.Sin(6 * lat);
        }

        #endregion

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

//                    theSent = nextNMEASentence;

//                }//end $GPRMC
//#endregion $GPRMC