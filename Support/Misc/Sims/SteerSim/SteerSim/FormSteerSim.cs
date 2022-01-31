using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Globalization;
using System.IO.Ports;
using SteerSim.Properties;

namespace SteerSim
{
    public partial class FormSteerSim : Form
    {

        #region properties sim
        //Our two new nmea strings
        private readonly StringBuilder sbRMC = new StringBuilder();
        private StringBuilder sbGGA = new StringBuilder();
        private StringBuilder sbVTG = new StringBuilder();

        //The entire string to send out
        private StringBuilder sbSendText = new StringBuilder();

        //GPS related properties
        private int fixQuality = 3, sats = 7;
        private double HDOP = 0.9;
        private int altitude = 20;
        private char EW = 'W';
        private char NS = 'N';

        private double latitude = 53.436026;
        private double longitude = -111.160047;
        private double latDeg, latMinu, longDeg, longMinu, latNMEA, longNMEA;
        private double speed = 0.6, headingTrue, stepDistance = 0.5, steerAngle;
        private double degrees;

        //The checksum of an NMEA line
        private string sumStr = "";

        #endregion

        public static string portNameGPS = "***";
        public static int baudRateGPS = 115200;
        private string rawBuffer = "";

        private bool isConnected  = false;

        //used to decide to autoconnect section arduino this run
        public string recvGPSSentence = "GPS";

        //used to decide to autoconnect autosteer arduino this run
        public bool wasGPSConnectedLastRun = false;

        //serial port gps is connected to
        public SerialPort spGPS = new SerialPort(portNameGPS, baudRateGPS, Parity.None, 8, StopBits.One);

        #region GPS SerialPort --------------------------------------------------------------------------

        public void SendGPSPort(string nmea)
        {
            try
            {
                if (spGPS.IsOpen)
                {
                    spGPS.Write(nmea);
                }
            }
            catch (Exception)
            {
            }

        }
        public void OpenGPSPort()
        {

            if (spGPS.IsOpen)
            {
                //close it first
                CloseGPSPort();
            }


            if (!spGPS.IsOpen)
            {
                spGPS.PortName = portNameGPS;
                spGPS.BaudRate = baudRateGPS;
                spGPS.DataReceived += sp_DataReceivedGPS;
                spGPS.WriteTimeout = 1000;
            }

            try { spGPS.Open(); }
            catch (Exception)
            {
            }

            if (spGPS.IsOpen)
            {
                //discard any stuff in the buffers
                spGPS.DiscardOutBuffer();
                spGPS.DiscardInBuffer();

                Settings.Default.setPort_portNameGPS = portNameGPS;
                Settings.Default.setPort_baudRateGPS = baudRateGPS;
                Settings.Default.setPort_wasGPSConnected = true;
                Settings.Default.Save();
                lblCurrentPort.Text = portNameGPS;
                wasGPSConnectedLastRun = true;
                isConnected = true;
            }
        }
        public void CloseGPSPort()
        {
            {
                try { spGPS.Close(); }
                catch (Exception e)
                {
                    //WriteErrorLog("Closing GPS Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated?");
                }

                spGPS.Dispose();
            }
            lblCurrentPort.Text = "---";
            wasGPSConnectedLastRun = false;
            isConnected = false;
        }

        //called by the GPS delegate every time a chunk is rec'd
        private void ReceiveGPSPort(string sentence)
        {
            //rawBuffer += sentence;
            textBoxRcv.Text = sentence;
            //if (sentence.Length > 300) sentence = "";
        }

        //serial port receive in its own thread
        private void sp_DataReceivedGPS(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spGPS.IsOpen)
            {
                try
                {
                    if (spGPS.BytesToRead > 200)
                    {
                        string sentence = spGPS.ReadExisting().ToString();
                        BeginInvoke((MethodInvoker)(() => ReceiveGPSPort(sentence)));
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        #endregion SerialPortGPS


        //Form constructor
        public FormSteerSim()
        {
            InitializeComponent();
        }

        private void FormSim_Load(object sender, EventArgs e)
        {
            //// Initialise delegate
            //displayMessageDelegate = new DisplayMessageDelegate(DisplayMessage);
            //set baud and port from last time run

            baudRateGPS = Settings.Default.setPort_baudRateGPS;
            portNameGPS = Settings.Default.setPort_portNameGPS;
            wasGPSConnectedLastRun = Settings.Default.setPort_wasGPSConnected;
            timer1.Interval = Settings.Default.set_nmeaHz;
            nudHz.Value = Settings.Default.set_nudHz;
            if (wasGPSConnectedLastRun)
            {
                OpenGPSPort();
            }

            cboxPort.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboxPort.Items.Add(s);
            }

            lblCurrentBaud.Text = spGPS.BaudRate.ToString();
            lblCurrentPort.Text = spGPS.PortName;

            if (spGPS.IsOpen)
            {
                cboxBaud.Enabled = false;
                cboxPort.Enabled = false;
                btnCloseSerial.Enabled = true;
                btnOpenSerial.Enabled = false;
            }
            else
            {
                cboxBaud.Enabled = true;
                cboxPort.Enabled = true;
                btnCloseSerial.Enabled = false;
                btnOpenSerial.Enabled = true;
            }

            //calc the speed
            stepDistance = ((double)(tbarStepDistance.Value)) / 10.0 / (double)nudHz.Value;
            lblStep.Text = Convert.ToString(Math.Round(((double)(tbarStepDistance.Value)) / 10.0, 1));
            lblSpeed.Text = (Math.Round(1.852 * speed, 1)).ToString();

            //nudSteerSimPort.Value = Properties.Settings.Default.set_thisPort;
            //tboxAgOpenIP.Text = Properties.Settings.Default.set_IP;
            //nudAgOpenPort.Value = Properties.Settings.Default.set_port;
        }

        private void FormSim_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void tbarSteerAngle_Scroll(object sender, EventArgs e)
        {
            steerAngle = (tbarSteerAngle.Value) * 0.1;
            lblSteerAngle.Text = steerAngle.ToString();
        }

        // Set by NMEA Hz value. Send out repetitively.
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (fromAOGSentence != null)
            //{
            //    int off;
            //    string[] words = fromAOGSentence.Split(',');
            //    int.TryParse(words[0], out quadCount);
            //    int.TryParse(words[1], out off);

            //    if (off == 32020) steerAngle = 0.0;
            //    else
            //    {
            //        steerAngle = (double)quadCount / 10.0;
            //        tbarSteerAngle.Value = 0;
            //    }
            //}

            steerAngle = tbarSteerAngle.Value * 0.1;
            lblSteerAngle.Text = Math.Round(steerAngle,1).ToString();

            //steerAngle = 0.31;

            double temp = (stepDistance * Math.Tan(steerAngle * 0.01745329252) / 3.3);
            headingTrue += temp;
            if (headingTrue > (2.0*Math.PI)) headingTrue -= (2.0 * Math.PI);
            if (headingTrue < (0)) headingTrue += (2.0 * Math.PI);

            degrees = headingTrue * 57.2958;
            degrees = Math.Round(degrees, 1);
            lblHeading.Text = degrees.ToString();

            //Calculate the next Lat Long based on heading and distance
            calculateNewPostionFromBearingDistance(latitude, longitude, degrees, stepDistance/1000.0);

            //calc the speed
            speed = Math.Round(1.944 * stepDistance * (double)nudHz.Value,1);
            lblSpeed.Text = (Math.Round(1.852 * speed, 1)).ToString();

            BuildRMC();
            BuildGGA();
            BuildVTG();

            //send garbage for testing            
            if (cboxGarbage.Checked) sbSendText.Append("$PoopTrashGGA\n\r\n*$*,4,4,,,,,,*77\r\n");  
            if (chkVTG.Checked)sbSendText.Append(sbVTG.ToString());
            if (cboxGarbage.Checked) sbSendText.Append("GGGGG,4,4,,,,,,*77\r\n");
            if (chkGGA.Checked) sbSendText.Append(sbGGA.ToString());
            if (chkRMC.Checked) sbSendText.Append(sbRMC.ToString());
            if (cboxGarbage.Checked) sbSendText.Append("*$GARBAGE,4,4,,,,,,*77\r\n");

            //the text box showing the nmea string being sent
            txtNMEA.Text = sbSendText.ToString();

            //only if connected then send otherwise shit storm of messageboxes will occur
            if (isConnected)
            {
                SendGPSPort(txtNMEA.Text);
            }

            sbSendText.Clear();
        }

       //lat, lng in degrees. Bearing in degrees. Distance in Km
        public void calculateNewPostionFromBearingDistance (double lat, double lng, double bearing, double distance)
        {
            const double R = 6371; // Earth Radius in Km

            double lat2 = Math.Asin((Math.Sin(Math.PI / 180 * lat) * Math.Cos(distance / R))
                + (Math.Cos(Math.PI / 180 * lat) * Math.Sin(distance / R) * Math.Cos(Math.PI / 180 * bearing)));

            double lon2 = (Math.PI / 180 * lng) + Math.Atan2(Math.Sin(Math.PI / 180 * bearing) * Math.Sin(distance / R)
                * Math.Cos(Math.PI / 180 * lat), Math.Cos(distance / R) - (Math.Sin( Math.PI / 180 * lat) * Math.Sin(lat2)));

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

        private void btnOpenSerial_Click(object sender, EventArgs e)
        {
            OpenGPSPort();
            if (spGPS.IsOpen)
            {
                cboxBaud.Enabled = false;
                cboxPort.Enabled = false;
                btnCloseSerial.Enabled = true;
                btnOpenSerial.Enabled = false;
                lblCurrentBaud.Text = spGPS.BaudRate.ToString();
                lblCurrentPort.Text = spGPS.PortName;
            }
            else
            {
                cboxBaud.Enabled = true;
                cboxPort.Enabled = true;
                btnCloseSerial.Enabled = false;
                btnOpenSerial.Enabled = true;
                MessageBox.Show("Not Connected");
            }
        }

        private void btnCloseSerial_Click(object sender, EventArgs e)
        {
            CloseGPSPort();
            if (spGPS.IsOpen)
            {
                cboxBaud.Enabled = false;
                cboxPort.Enabled = false;
                btnCloseSerial.Enabled = true;
                btnOpenSerial.Enabled = false;
            }
            else
            {
                cboxBaud.Enabled = true;
                cboxPort.Enabled = true;
                btnCloseSerial.Enabled = false;
                btnOpenSerial.Enabled = true;
            }
        }

        private void cboxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            spGPS.PortName = cboxPort.Text;
            portNameGPS = cboxPort.Text;
        }

        private void cboxBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
           spGPS.BaudRate = Convert.ToInt32(cboxBaud.Text);
            baudRateGPS = Convert.ToInt32(cboxBaud.Text);
        }

        //changing the speed scrollbar
        private void tbarStepDistance_Scroll(object sender, EventArgs e)
        {
            stepDistance = ((double)(tbarStepDistance.Value))/10.0 / (double)nudHz.Value;
            lblStep.Text = Convert.ToString(Math.Round(((double)(tbarStepDistance.Value)) / 10.0, 1));
            lblSpeed.Text = (Math.Round(1.852 * speed, 1)).ToString();
        }

        private void btnScanPorts_Click(object sender, EventArgs e)
        {
            cboxPort.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboxPort.Items.Add(s);
            }
        }

        private void nudAltitude_ValueChanged(object sender, EventArgs e)
        {
            altitude = (int)nudAltitude.Value;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {  
            latitude = 53.436026;
            longitude = -111.160047;
            tbarStepDistance.Value = 5;
            stepDistance = ((double)(tbarStepDistance.Value)) / 10.0 / (double)nudHz.Value;

            //calc the speed
            speed = Math.Round(1.944 * stepDistance * (double)nudHz.Value, 1);
            lblSpeed.Text = (Math.Round(1.852 * speed, 1)).ToString();
            lblStep.Text = Convert.ToString(Math.Round(((double)(tbarStepDistance.Value)) / 10.0, 1));
        }

        private void nudHz_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32((1/nudHz.Value) * 990M);
            stepDistance = ((double)(tbarStepDistance.Value)) / 10.0 / (double)nudHz.Value;
            lblStep.Text = Convert.ToString(Math.Round(((double)(tbarStepDistance.Value)) / 10.0, 1));
            Settings.Default.set_nmeaHz = timer1.Interval;
            Settings.Default.set_nudHz = (int)nudHz.Value;   
            Settings.Default.Save();
        }

        private void btnSaveRestart_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.set_IP = tboxAgOpenIP.Text;
            //Properties.Settings.Default.set_port = (int)nudAgOpenPort.Value;
            //Properties.Settings.Default.set_thisPort = (int)nudSteerSimPort.Value;
            //Properties.Settings.Default.Save();

            Close();
        } 

        private void btnTbarReset_Click(object sender, EventArgs e)
        {
            tbarSteerAngle.Value = 0;
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
            sbGGA.Append(DateTime.UtcNow.ToString("HHmmss.fff,", CultureInfo.InvariantCulture));
            sbGGA.Append(latNMEA.ToString(CultureInfo.InvariantCulture)).Append(',').Append(NS).Append(',');
            sbGGA.Append(Math.Abs(longNMEA).ToString(CultureInfo.InvariantCulture)).Append(',').Append(EW).Append(',');
            sbGGA.Append(fixQuality.ToString(CultureInfo.InvariantCulture)).Append(',').Append(sats.ToString(CultureInfo.InvariantCulture)).Append(',').Append(HDOP.ToString(CultureInfo.InvariantCulture)).Append(',').Append(altitude.ToString(CultureInfo.InvariantCulture));
            sbGGA.Append(",M,46.9,M,37,1,*");

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
#region NMEA_Sentence_Guide

/*
$GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M ,  ,*47
   0     1      2      3    4      5 6  7  8   9    10 11  12 13  14
        Time      Lat       Lon     FixSatsOP Alt
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
$GPRMC,123519,A,4807.038,N,01131.000,E,022.4,084.4,230394,003.1,W*6A
 0      1    2   3      4    5      6   7     8     9     10   11
        Time      Lat        Lon       knots  Ang   Date  MagV

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

$GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M ,  ,*47
   0     1      2      3    4      5 6  7  8   9    10 11  12 13  14
        Time      Lat       Lon     FixSatsOP Alt


$GPRMC,123519,A,4807.038,N,01131.000,E,022.4,084.4,230394,003.1,W*6A
 0      1    2   3      4    5      6   7     8     9     10   11
        Time      Lat        Lon       knots  Ang   Date  MagV


$GPVTG,054.7,T,034.4,M,005.5,N,010.2,K*48
 *   
    VTG          Track made good and ground speed
    054.7,T      True track made good (degrees)
    034.4,M      Magnetic track made good
    005.5,N      Ground speed, knots
    010.2,K      Ground speed, Kilometers per hour
    *48          Checksum
 */

//$GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M ,  ,*47
//   0     1      2      3    4      5 6  7  8   9    10 11  12 13  14
//        Time      Lat       Lon  

/*
GGA - essential fix data which provide 3D location and accuracy data.

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