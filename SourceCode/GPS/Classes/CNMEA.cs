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
        public double actualEasting = 0, actualNorthing = 0;
        public double zone = 0;
 

        //other GIS Info
        public double altitude = 0, speed = 0;
        public double headingTrue = 0, hdop = 0, ageDiff = 0;

        public int fixQuality = 0;
        public int satellitesTracked = 0;
        public string status = "q";
        public DateTime utcDateTime;

        public char hemisphere = 'N';

        //UTM numbers are huge, these cut them way down.
        public int utmNorth = 0, utmEast = 0;

        public StringBuilder logNMEASentence = new StringBuilder();

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

                if (words[0] == "$GPGGA" | words[0] == "$GNGGA") ParseGGA(); 
                if (words[0] == "$GPVTG" | words[0] == "$GNVTG") ParseVTG();
                if (words[0] == "$GPRMC" | words[0] == "$GNRMC") ParseRMC();

            }// while still data
                   
        }

        public string currentNMEA_GGASentence = "";
        public string currentNMEA_RMCSentence = "";
        public string currentNMEA_VTGSentence = "";

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

                //save to log sentence if field is open and sections on and menu enabled
                //if (mf.isLogNMEA)
                //{
                //    currentNMEA_RMCSentence = "";
                //    currentNMEA_GGASentence = "";
                //    currentNMEA_VTGSentence = "";

                //    if (sentence.Contains("$GPGGA") | sentence.Contains("$GNGGA")) currentNMEA_GGASentence = sentence;
                //    if (sentence.Contains("$GPRMC") | sentence.Contains("$GNRMC")) currentNMEA_RMCSentence = sentence;
                //    if (sentence.Contains("$GPVTG") | sentence.Contains("$GNVTG")) currentNMEA_VTGSentence = sentence;
                //}

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
            
            double temp;

            //$GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M ,  ,*47
            //   0     1      2      3    4      5 6  7  8   9    10 11  12 13  14
            //        Time      Lat       Lon  

            //is the sentence GGA
            if (!String.IsNullOrEmpty(words[2]) & !String.IsNullOrEmpty(words[3])
                & !String.IsNullOrEmpty(words[4]) & !String.IsNullOrEmpty(words[5]))
            {

                //get latitude and convert to decimal degrees
                     double.TryParse(words[2].Substring(0, 2), out latitude);
                     double.TryParse(words[2].Substring(2), out temp);
                       temp *= 0.01666666666666666666666666666667;
                       latitude += temp;

      
                    if (words[3] == "S")
                    {
                        latitude *= -1;
                        hemisphere = 'S';
                    }
                    else hemisphere = 'N';
                

                //get longitude and convert to decimal degrees
                    double.TryParse(words[4].Substring(0, 3), out longitude);
                    double.TryParse(words[4].Substring(3), out temp);
                    longitude = longitude + temp * 0.01666666666666666666666666666667;

                 { if (words[5] == "W") longitude *= -1; }
                
                //calculate zone and UTM coords
                DecDeg2UTM();

                //fixQuality
                int.TryParse(words[6], out fixQuality);
 
                //satellites tracked
                int.TryParse(words[7], out satellitesTracked);
                
                //hdop
                double.TryParse(words[8], out hdop); 

                //altitude
                double.TryParse(words[9], out altitude);

                //age of differential
                double.TryParse(words[12], out ageDiff);

                theSent += nextNMEASentence;
                updatedGGA = true;
                mf.recvCounter = 0;
            }

        }

        private void ParseRMC()
        {
            double temp;
            //GPRMC parsing of the sentence 
            //make sure there aren't missing coords in sentence
            if (!String.IsNullOrEmpty(words[3]) & !String.IsNullOrEmpty(words[4])
                & !String.IsNullOrEmpty(words[5]) & !String.IsNullOrEmpty(words[6]))
            {
                //get latitude and convert to decimal degrees
                double.TryParse(words[3].Substring(0, 2), out latitude);
                double.TryParse(words[3].Substring(2), out temp);
                latitude = latitude + temp * 0.01666666666666666666666666666667;

                if (words[4] == "S")
                {
                        latitude *= -1;
                        hemisphere = 'S';
                }
                    else hemisphere = 'N';

                //get longitude and convert to decimal degrees
                double.TryParse(words[5].Substring(0, 3), out longitude);
                double.TryParse(words[5].Substring(3), out temp);
                longitude = longitude + temp * 0.01666666666666666666666666666667;

                if (words[6] == "W") longitude *= -1;

                //calculate zone and UTM coords
                DecDeg2UTM();


                //Convert from knots to kph for speed
                double.TryParse(words[7], out speed);
                speed = Math.Round(speed * 1.852, 1);

                //True heading
                double.TryParse(words[8], out headingTrue);
 
                //Status
                if (String.IsNullOrEmpty(words[2])) status = "z";
                else
                {
                    try { status = words[2]; }
                    catch (Exception e)
                    {
                        mf.WriteErrorLog("Parse RMC" + e.ToString());
                    }
                }

                theSent += nextNMEASentence;
                mf.recvCounter = 0;
                updatedRMC = true;

                mf.avgSpeed[mf.ringCounter] = speed;
                if (mf.ringCounter++ > 8) mf.ringCounter = 0;
            }
        }

        private void ParseVTG()
        {
            //$GPVTG,054.7,T,034.4,M,005.5,N,010.2,K*48
            //is the sentence GGA
            if (!String.IsNullOrEmpty(words[1]) & !String.IsNullOrEmpty(words[5]))
            {
                //kph for speed - knots read
                double.TryParse(words[5], out speed);
                speed = Math.Round(speed * 1.852, 1);

                //True heading
                double.TryParse(words[1], out headingTrue); 
                    
                updatedVTG = true;
                theSent += nextNMEASentence;

                mf.avgSpeed[mf.ringCounter] = speed;
                if (mf.ringCounter++ > 8) mf.ringCounter = 0;

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
                    if (tmp == '*') break;
                    sum = sum ^ tmp;    // Build checksum
                }
                // Calculated checksum converted to a 2 digit hex string
                string sum_str = String.Format("{0:X2}", sum);
 
            // Compare to checksum in sentence
            return sum_str.Equals(Sentence.Substring(inx + 1, 2));
            }
            catch (Exception e)
            {
                mf.WriteErrorLog("Validate Checksum" + e.ToString());
                return false;
            }
         }

        public double Distance(double northing1, double easting1, double northing2, double easting2)
        {
            return Math.Sqrt(
                Math.Pow((easting1 - easting2), 2) +
                Math.Pow((northing1 - northing2), 2));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////


        //private double pi = 3.141592653589793238462643383279502884197169399375;
        private double sm_a = 6378137.0;
        private double sm_b = 6356752.314;
        private double UTMScaleFactor = 0.9996;
        //private double UTMScaleFactor2 = 1.0004001600640256102440976390556;

        public void DecDeg2UTM()
        {
            zone = Math.Floor((longitude + 180.0) * 0.16666666666666666666666666666667) + 1;
            GeoUTMConverterXY(latitude * 0.01745329251994329576923690766743, 
                                longitude * 0.01745329251994329576923690766743);
        }

        //    return (degrees * 0.01745329251994329576923690766743);

        private double ArcLengthOfMeridian(double phi)
        {
            double alpha, beta, gamma, delta, epsilon, n;
            double result;
            n = (sm_a - sm_b) / (sm_a + sm_b);
            alpha = ((sm_a + sm_b) / 2.0) * (1.0 + (Math.Pow(n, 2.0) / 4.0) + (Math.Pow(n, 4.0) / 64.0));
            beta = (-3.0 * n / 2.0) + (9.0 * Math.Pow(n, 3.0) / 16.0) + (-3.0 * Math.Pow(n, 5.0) / 32.0);
            gamma = (15.0 * Math.Pow(n, 2.0) / 16.0)
                + (-15.0 * Math.Pow(n, 4.0) / 32.0);
            delta = (-35.0 * Math.Pow(n, 3.0) / 48.0)
                + (105.0 * Math.Pow(n, 5.0) / 256.0);
            epsilon = (315.0 * Math.Pow(n, 4.0) / 512.0);
            result = alpha
                * (phi + (beta * Math.Sin(2.0 * phi))
                    + (gamma * Math.Sin(4.0 * phi))
                    + (delta * Math.Sin(6.0 * phi))
                    + (epsilon * Math.Sin(8.0 * phi)));

            return result;
        }

        private double UTMCentralMeridian(double zone)
        {
            return ((-183.0 + (zone * 6.0)) * 0.01745329251994329576923690766743);
        }

        private double[] MapLatLonToXY(double phi, double lambda, double lambda0)
        {
            double[] xy = new double[2];
            double N, nu2, ep2, t, t2, l;
            double l3coef, l4coef, l5coef, l6coef, l7coef, l8coef;
            double tmp;
            ep2 = (Math.Pow(sm_a, 2.0) - Math.Pow(sm_b, 2.0)) / Math.Pow(sm_b, 2.0);
            nu2 = ep2 * Math.Pow(Math.Cos(phi), 2.0);
            N = Math.Pow(sm_a, 2.0) / (sm_b * Math.Sqrt(1 + nu2));
            t = Math.Tan(phi);
            t2 = t * t;
            tmp = (t2 * t2 * t2) - Math.Pow(t, 6.0);
            l = lambda - lambda0;
            l3coef = 1.0 - t2 + nu2;
            l4coef = 5.0 - t2 + 9 * nu2 + 4.0 * (nu2 * nu2);
            l5coef = 5.0 - 18.0 * t2 + (t2 * t2) + 14.0 * nu2 - 58.0 * t2 * nu2;
            l6coef = 61.0 - 58.0 * t2 + (t2 * t2) + 270.0 * nu2 - 330.0 * t2 * nu2;
            l7coef = 61.0 - 479.0 * t2 + 179.0 * (t2 * t2) - (t2 * t2 * t2);
            l8coef = 1385.0 - 3111.0 * t2 + 543.0 * (t2 * t2) - (t2 * t2 * t2);

            /* Calculate easting (x) */
            xy[0] = N * Math.Cos(phi) * l
                + (N / 6.0 * Math.Pow(Math.Cos(phi), 3.0) * l3coef * Math.Pow(l, 3.0))
                + (N / 120.0 * Math.Pow(Math.Cos(phi), 5.0) * l5coef * Math.Pow(l, 5.0))
                + (N / 5040.0 * Math.Pow(Math.Cos(phi), 7.0) * l7coef * Math.Pow(l, 7.0));

            /* Calculate northing (y) */
            xy[1] = ArcLengthOfMeridian(phi)
                + (t / 2.0 * N * Math.Pow(Math.Cos(phi), 2.0) * Math.Pow(l, 2.0))
                + (t / 24.0 * N * Math.Pow(Math.Cos(phi), 4.0) * l4coef * Math.Pow(l, 4.0))
                + (t / 720.0 * N * Math.Pow(Math.Cos(phi), 6.0) * l6coef * Math.Pow(l, 6.0))
                + (t / 40320.0 * N * Math.Pow(Math.Cos(phi), 8.0) * l8coef * Math.Pow(l, 8.0));

            return xy;
        }


        private void GeoUTMConverterXY(double lat, double lon)
        {
            double[] xy = MapLatLonToXY(lat, lon, (-183.0 + (zone * 6.0)) * 0.01745329251994329576923690766743);

            xy[0] = xy[0] * UTMScaleFactor + 500000.0;
            xy[1] = xy[1] * UTMScaleFactor;
            if (xy[1] < 0.0)
                xy[1] = xy[1] + 10000000.0;

            //keep a copy of actual easting and northings
            actualEasting = xy[0];
            actualNorthing = xy[1];

            easting = xy[0] - utmEast;
            northing = xy[1] - utmNorth;
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

//                    theSent = nextNMEASentence;

//                }//end $GPRMC
//#endregion $GPRMC