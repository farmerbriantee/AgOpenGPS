using System;
using System.Globalization;
using System.Text;

namespace AgOpenGPS
{
    public class CSim
    {
        private readonly FormGPS mf;

        #region properties sim

        //Our two new nmea strings
        private readonly StringBuilder sbOGI = new StringBuilder();

        private readonly StringBuilder sbHDT = new StringBuilder();

        private readonly StringBuilder sbGGA = new StringBuilder();
        private readonly StringBuilder sbVTG = new StringBuilder();

        //The entire string to send out
        private readonly StringBuilder sbSendText = new StringBuilder();

        //GPS related properties
        private readonly int fixQuality = 5, sats = 12;

        private readonly double HDOP = 0.9;
        public double altitude = 300;
        private char EW = 'W';
        private char NS = 'N';

        public double latitude, longitude;

        private double latDeg, latMinu, longDeg, longMinu, latNMEA, longNMEA;
        public double speed = 0.6, headingTrue, stepDistance = 0.2, steerAngle;
        public double steerAngleScrollBar = 0;
        private double degrees;

        //The checksum of an NMEA line
        private string sumStr = "";

        #endregion properties sim

        public CSim(FormGPS _f)
        {
            mf = _f;
            latitude = Properties.Settings.Default.setGPS_SimLatitude;
            longitude = Properties.Settings.Default.setGPS_SimLongitude;
        }

        public void DoSimTick(double _st)
        {
            steerAngle = _st;
            double temp = (stepDistance * Math.Tan(steerAngle * 0.0165329252) / 3.3);
            headingTrue += temp;
            if (headingTrue > (2.0 * Math.PI)) headingTrue -= (2.0 * Math.PI);
            if (headingTrue < 0) headingTrue += (2.0 * Math.PI);

            degrees = headingTrue * 57.2958;
            degrees = Math.Round(degrees, 1);
            //lblHeading.Text = degrees.ToString();

            //Calculate the next Lat Long based on heading and distance
            CalculateNewPostionFromBearingDistance(latitude, longitude, degrees, stepDistance / 1000.0);

            //calc the speed
            //speed = Math.Round(1.944 * stepDistance * (double)nudHz.Value, 1);
            speed = Math.Round(1.944 * stepDistance * 5, 1);
            //lblSpeed.Text = (Math.Round(1.852 * speed, 1)).ToString();

            //BuildOGI();
            BuildGGA();
            BuildVTG();
            //BuildHDT();

            //send garbage for testing
            //sbSendText.Append("$\r\n,4,4,,,,,,*\\\\\\\\\\\\\\\\\\");
            //if (chkVTG.Checked) sbSendText.Append(sbVTG.ToString());
            //if (chkGGA.Checked) sbSendText.Append(sbGGA.ToString());
            //if (chkOGI.Checked) sbSendText.Append(sbOGI.ToString());

            sbSendText.Append(sbGGA.ToString());
            sbSendText.Append(sbVTG.ToString());
            //sbSendText.Append(sbHDT.ToString());

            //sbSendText.Append(sbOGI.ToString());
            mf.pn.rawBuffer += sbSendText.ToString();
            mf.recvSentenceSettings = sbSendText.ToString();

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

            if (latitude >= 0) NS = 'N';
            else NS = 'S';
            if (longitude >= 0) EW = 'E';
            else EW = 'W';
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
            sbGGA.Append(Math.Abs(latNMEA).ToString("0000.0000000", CultureInfo.InvariantCulture)).Append(',').Append(NS).Append(',');
            sbGGA.Append(Math.Abs(longNMEA).ToString("00000.0000000", CultureInfo.InvariantCulture)).Append(',').Append(EW).Append(',');
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
            sbVTG.Append("\n");

            /*         $GPVTG,054.7,T,034.4,M,005.5,N,010.2,K*48
               VTG          Track made good and ground speed
               054.7,T      True track made good (degrees)
               034.4,M      Magnetic track made good
               005.5,N      Ground speed, knots
               010.2,K      Ground speed, Kilometers per hour
               *48          Checksum
            */
        }

        private void BuildHDT()

        {
            sbHDT.Clear();
            sbHDT.Append("$GNHDT,");
            sbHDT.Append((degrees).ToString(CultureInfo.InvariantCulture));
            sbHDT.Append(",T*");

            CalculateChecksum(sbHDT.ToString());
            sbHDT.Append(sumStr);
            sbHDT.Append("\r\n");

            /*        Heading from True North
An example of the HDT string is:

$GNHDT,123.456,T*00

Heading from true north message fields
Field	Meaning
0	Message ID $GNHDT
1	Heading in degrees
2	T: Indicates heading relative to True North
3	The checksum data, always begins with *

            */
        }

        private void BuildOGI()
        {
            sbOGI.Clear();
            sbOGI.Append("$PAOGI,");

            sbOGI.Append(DateTime.Now.ToString("HHmmss.00,", CultureInfo.InvariantCulture));
            sbOGI.Append(Math.Abs(latNMEA).ToString("0000.0000000", CultureInfo.InvariantCulture)).Append(',').Append(NS).Append(',');
            sbOGI.Append(Math.Abs(longNMEA).ToString("0000.0000000", CultureInfo.InvariantCulture)).Append(',').Append(EW).Append(',');

            sbOGI.Append(fixQuality.ToString(CultureInfo.InvariantCulture)).Append(',')
                .Append(sats.ToString(CultureInfo.InvariantCulture))
                .Append(',').Append(HDOP.ToString(CultureInfo.InvariantCulture))
                .Append(',').Append(altitude.ToString(CultureInfo.InvariantCulture)).Append(",M,")
                .Append("1.2,")
                .Append(speed.ToString(CultureInfo.InvariantCulture)).Append(',')
                .Append((degrees).ToString(CultureInfo.InvariantCulture));

            sbOGI.Append(",0.11,0.12,359.9,5.0,T*");

            CalculateChecksum(sbOGI.ToString());
            sbOGI.Append(sumStr);
            sbOGI.Append("\r\n");
        }
    }
}