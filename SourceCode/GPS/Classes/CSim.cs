using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AgOpenGPS
{
    public class CSim
    {
        private readonly FormGPS mf;

        #region properties sim
        //Our two new nmea strings
        private readonly StringBuilder sbRMC = new StringBuilder();
        private readonly StringBuilder sbGGA = new StringBuilder();
        private readonly StringBuilder sbVTG = new StringBuilder();

        //The entire string to send out
        private readonly StringBuilder sbSendText = new StringBuilder();

        //GPS related properties
        private readonly int fixQuality = 3, sats = 7;
        private readonly double HDOP = 0.9;
        private readonly double altitude = 20.09876;
        private readonly char EW = 'W';
        private readonly char NS = 'N';

        public double latitude = 53.436026;
        public double longitude = -111.160047;
        private double latDeg, latMinu, longDeg, longMinu, latNMEA, longNMEA;
        public double speed = 0.6, headingTrue, stepDistance = 0.5, steerAngle;
        public double steerAngleScrollBar = 0;
        private double degrees;

        //The checksum of an NMEA line
        private string sumStr = "";

        #endregion

        public CSim(FormGPS _f)
        {
            mf = _f;
        }

        public void DoSimTick(double _st)
        {
            steerAngle = _st;
            double temp = (stepDistance * Math.Tan(steerAngle * 0.01745329252) / 3.3);
            headingTrue += temp;
            if (headingTrue > (2.0 * Math.PI)) headingTrue -= (2.0 * Math.PI);
            if (headingTrue < (0)) headingTrue += (2.0 * Math.PI);

            degrees = headingTrue * 57.2958;
            degrees = Math.Round(degrees, 1);
            //lblHeading.Text = degrees.ToString();

            //Calculate the next Lat Long based on heading and distance
            CalculateNewPostionFromBearingDistance(latitude, longitude, degrees, stepDistance / 1000.0);

            //calc the speed
            //speed = Math.Round(1.944 * stepDistance * (double)nudHz.Value, 1);
            speed = Math.Round(1.944 * stepDistance * 5.0, 1);
            //lblSpeed.Text = (Math.Round(1.852 * speed, 1)).ToString();

            BuildRMC();
            BuildGGA();
            BuildVTG();

            //send garbage for testing            
            //sbSendText.Append("$\r\n,4,4,,,,,,*\\\\\\\\\\\\\\\\\\");  
            //if (chkVTG.Checked) sbSendText.Append(sbVTG.ToString());
            //if (chkGGA.Checked) sbSendText.Append(sbGGA.ToString());
            //if (chkRMC.Checked) sbSendText.Append(sbRMC.ToString());

            sbSendText.Append(sbGGA.ToString());
            sbSendText.Append(sbVTG.ToString());
            mf.pn.rawBuffer += sbSendText.ToString();
            mf.recvSentenceSettings = mf.pn.rawBuffer;

            sbSendText.Clear();
        }

        public void CalculateNewPostionFromBearingDistance(double lat, double lng, double bearing, double distance)
        {
            const double R = 6371; // Earth Radius in Km

            double lat2 = Math.Asin((Math.Sin(Math.PI / 180 * lat) * Math.Cos(distance / R))
                + (Math.Cos(Math.PI / 180 * lat) * Math.Sin(distance / R) * Math.Cos(Math.PI / 180 * bearing)));

            double lon2 = (Math.PI / 180 * lng) + Math.Atan2(Math.Sin(Math.PI / 180 * bearing) * Math.Sin(distance / R)
                * Math.Cos(Math.PI / 180 * lat), Math.Cos(distance / R) - (Math.Sin(Math.PI / 180 * lat) * Math.Sin(lat2)));

            latitude = 180 / Math.PI * lat2;
            longitude = 180 / Math.PI * lon2;

            //convert to DMS from Degrees
            latMinu = latitude;
            longMinu = longitude;

            latDeg = (int)latitude;
            longDeg = (int)longitude;

            latMinu -= latDeg;
            longMinu -= longDeg;

            latMinu = Math.Round(latMinu * 60.0, 7);
            longMinu = Math.Round(longMinu * 60.0, 7);

            latDeg *= 100.0;
            longDeg *= 100.0;

            latNMEA = latMinu + latDeg;
            longNMEA = longMinu + longDeg;
        }

        //calculate the NMEA checksum to stuff at the end
        public void CalculateChecksum(string Sentence)
        {
            int sum = 0, inx;
            char[] sentence_chars = Sentence.ToCharArray();
            char tmp;
            // All character xor:ed results in the trailing hex checksum
            // The checksum calc starts after '$' and ends before '*'
            for (inx = 1; ; inx++)
            {
                tmp = sentence_chars[inx];
                // Indicates end of data and start of checksum
                if (tmp == '*')
                    break;
                sum ^= tmp;    // Build checksum
            }
            // Calculated checksum converted to a 2 digit hex string
            sumStr = String.Format("{0:X2}", sum);
        }

        private void BuildGGA()
        {
            sbGGA.Clear();
            sbGGA.Append("$GPGGA,");
            sbGGA.Append(DateTime.Now.ToString("HHmmss.00,", CultureInfo.InvariantCulture));
            sbGGA.Append(latNMEA.ToString(CultureInfo.InvariantCulture)).Append(',').Append(NS).Append(',');
            sbGGA.Append(Math.Abs(longNMEA).ToString(CultureInfo.InvariantCulture)).Append(',').Append(EW).Append(',');
            sbGGA.Append(fixQuality.ToString(CultureInfo.InvariantCulture)).Append(',').Append(sats.ToString(CultureInfo.InvariantCulture)).Append(',').Append(HDOP.ToString(CultureInfo.InvariantCulture)).Append(',').Append(altitude.ToString(CultureInfo.InvariantCulture));
            sbGGA.Append(",M,46.9,M,,,*");

            CalculateChecksum(sbGGA.ToString());
            sbGGA.Append(sumStr);
            sbGGA.Append("\r\n");

            /*
        $GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M ,  ,*47
           0     1      2      3    4      5 6  7  8   9    10 11  12 13  14
                Time      Lat       Lon     FixSatsOP Alt */
        }

        private void BuildVTG()
        {
            sbVTG.Clear();
            sbVTG.Append("$GPVTG,");
            sbVTG.Append((degrees).ToString(CultureInfo.InvariantCulture));
            sbVTG.Append(",T,034.4,M,");
            sbVTG.Append(speed.ToString(CultureInfo.InvariantCulture));
            sbVTG.Append(",N,");
            sbVTG.Append((speed * 1.852).ToString(CultureInfo.InvariantCulture));
            sbVTG.Append(",K*");

            CalculateChecksum(sbVTG.ToString());
            sbVTG.Append(sumStr);
            sbVTG.Append("\r\n");

            /*         $GPVTG,054.7,T,034.4,M,005.5,N,010.2,K*48   
               VTG          Track made good and ground speed
               054.7,T      True track made good (degrees)
               034.4,M      Magnetic track made good
               005.5,N      Ground speed, knots
               010.2,K      Ground speed, Kilometers per hour
               *48          Checksum
            */

        }

        private void BuildRMC()
        {
            sbRMC.Clear();
            sbRMC.Append("$GPRMC,");
            sbRMC.Append(DateTime.Now.ToString("HHmmss.00,", CultureInfo.InvariantCulture));

            //add the latitude
            sbRMC.Append("A,").Append(latNMEA.ToString(CultureInfo.InvariantCulture)).Append(',').Append(NS).Append(',');

            //add the longitude
            sbRMC.Append(Math.Abs(longNMEA).ToString(CultureInfo.InvariantCulture)).Append(',').Append(EW).Append(',');

            //add the speed and date
            sbRMC.Append(speed.ToString(CultureInfo.InvariantCulture)).Append(',').Append(degrees.ToString(CultureInfo.InvariantCulture)).Append(',').Append(DateTime.Now.ToString("ddMMyy", CultureInfo.InvariantCulture)).Append(",0,W*");

            //sbRMC.Clear();
            //sbRMC.Append("$GPRMC,105506.800,A,4016.1090,N,00730.8665,W,11.00,37.89.010517,,,D*");

            CalculateChecksum(sbRMC.ToString());
            sbRMC.Append(sumStr);
            sbRMC.Append("\r\n");
        }
    }
}
