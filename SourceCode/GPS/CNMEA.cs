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
    */


    #endregion NMEA_Sentence_Guide

    public class CNMEA
    {
        //WGS84 Lat Long
        public double latitude = 0;
        public double longitude = 0;

        public bool updatedGGA = false;
        public bool updatedVTG = false;
        public bool updatedRMC = false;

        private string rawBuffer="";
        private string[] words;

        //UTM coordinates
        public double northing = 0;
        public double easting = 0;
        public int zone = 0;
 

        //other GIS Info
        public double altitude = 0;
        public int fixQuality = 0;
        public string status = "q";
        public double speed = 0;
        public double headingTrue = 0;
        public DateTime utcDateTime;
        public int satellitesTracked = 0;
        public double hdop = 0;

        private FormGPS mainForm;

        public CNMEA(FormGPS f)
        {
            //constructor, grab the main form reference
            this.mainForm = f;
        }

        public double Distance(double northing1, double easting1, double
                northing2, double easting2)
        {
            return Math.Sqrt(
                Math.Pow((easting1 - easting2), 2) +
                Math.Pow((northing1 - northing2), 2));
        }


        public int ParseNMEA(string portData)
        {
            //returns......
            //return 0 - no data, invalid or incorrrect checksum etc
            //return 1 - valid data updated
            updatedGGA = false;
            updatedVTG = false;
            updatedRMC = false;

            // Add new data
            if (portData == null) return 0;  rawBuffer += portData; 

            //find end of a sentence
            int cr = rawBuffer.IndexOf("\r\n");
            if (cr == -1)  return 0; // No end found, wait for more data

            // Find start of next sentence
            cr = rawBuffer.IndexOf("$");
            if (cr == -1) return 0;

            //now we have a complete sentence or more somewhere in the portData
            bool stillData = true;

            while (stillData)       
            {
                string nextNMEASentence = Parse();
                if (nextNMEASentence == null) return 1;

                words = nextNMEASentence.Split(',');
            
                //GPRMC parsing of the sentence
                #region $GPRMC

                //make sure there aren't missing coords in sentence
                if (words[0] == "$GPRMC" & words[3] != "" & words[4] != "" & words[5] != "" & words[6] != "")
                {
                    //get latitude and convert to decimal degrees
                    try{ latitude = double.Parse(words[3].Substring(0, 2));
                         latitude = latitude + double.Parse(words[3].Substring(2)) / 60.0; }
                    catch (ArgumentNullException) { }

                    try { if (words[4] == "S") latitude *= -1; }
                    catch (ArgumentNullException) { }

                    //get longitude and convert to decimal degrees
                    try { longitude = double.Parse(words[5].Substring(0, 3)); 
                           longitude = longitude + double.Parse(words[5].Substring(3)) / 60.0; }
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

                    //Date and Time
                    if (words[1].Length != 0)
                    {
                        try
                        {
                            if (words[1].Length == 6)
                            {
                                // Only HHMMSS
                                utcDateTime = new DateTime(
                                    (int.Parse(words[9].Substring(4, 2)) + 2000),
                                    int.Parse(words[9].Substring(2, 2)),
                                    int.Parse(words[9].Substring(0, 2)),
                                    int.Parse(words[1].Substring(0, 2)),
                                    int.Parse(words[1].Substring(2, 2)),
                                    int.Parse(words[1].Substring(4, 2)));
                            }
                            else
                            {
                                // HHMMSS.MS
                                utcDateTime = new DateTime(
                                    (int.Parse(words[9].Substring(4, 2)) + 2000),
                                    int.Parse(words[9].Substring(2, 2)),
                                    int.Parse(words[9].Substring(0, 2)),
                                    int.Parse(words[1].Substring(0, 2)),
                                    int.Parse(words[1].Substring(2, 2)),
                                    int.Parse(words[1].Substring(4, 2)),
                                    int.Parse(words[1].Substring(7)));
                            }
                        }
                        catch (ArgumentNullException) { }
                    }

                    //update the receive counter that detects loss of communication
                    mainForm.recvCounter = 0;

                    //update that RMC data is newly updated
                    updatedRMC = true;

                }//end $GPRMC
#endregion $GPRMC

                #region $GPGGA

                //is the sentence GGA
                //if (words[0] == "$GPGGA" & words[2] != "" & words[3] != "" & words[4] != "" & words[5] != "")
                if (words[0] == "$GPGGA" )
                {
                    //altitude
                    if (words[9] == String.Empty) altitude = -1;
                    else
                    {
                        try { altitude = double.Parse(words[9]); }
                        catch (ArgumentNullException) { }
                    }

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

                    updatedGGA = true;

                }

            #endregion $GPGGA
                

            }// while still data

            //should never get here
            return 0;
                   
        }//ParseNMEA


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
                if (start == -1)
                {
                    // No start found
                    rawBuffer = null;
                    return null;
                }
                rawBuffer = rawBuffer.Substring(start);
                // Find end of sentence
                end = rawBuffer.IndexOf("\r\n");
                if (end == -1)
                {
                    // No end found, wait for more data
                    rawBuffer = null;
                    return null;
                }
                sentence = rawBuffer.Substring(0, end + 2);
                rawBuffer = rawBuffer.Substring(end + 2);
            }

            while (!ValidateChecksum(sentence));
            // Valid sentence found!
            // Remove trailing checksum and \r\n
            sentence = sentence.Substring(0, sentence.IndexOf("*"));
            // Split into fields and return array
            //return sentence.Split(",".ToCharArray());
            return sentence;
        }


        public bool ValidateChecksum(string Sentence)
        {
            int sum = 0, inx;
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
        // Returns position in UTM easting/northing/zone (in meters)
        private void DecDeg2UTM(double latitude, double longitude)
        {
            // Normalize longitude into Zone, 6 degrees
            int int_zone = (int)(longitude / 6.0);
            if (longitude < 0)
                int_zone--;
            longitude -= (double)int_zone * 6.0;
            zone = int_zone + 31;    // UTM zone
            // Convert from decimal degrees to radians
            longitude *= Math.PI / 180.0;
            latitude *= Math.PI / 180.0;
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

            northing -= 5000000;
            //easting -= 300000;
        }

        private double m_calc(double lat)
        {
            return (1 - WGS84_E2 / 4 - 3 * WGS84_E4 / 64 - 5 * WGS84_E6 / 256) * lat -
                 (3 * WGS84_E2 / 8 + 3 * WGS84_E4 / 32 + 45 * WGS84_E6 / 1024) *
                 Math.Sin(2 * lat) + (15 * WGS84_E4 / 256 + 45 * WGS84_E6 / 1024) *
                 Math.Sin(4 * lat) - (35 * WGS84_E6 / 3072) * Math.Sin(6 * lat);
        }


    }
}
