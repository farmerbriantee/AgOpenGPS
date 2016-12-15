using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;


namespace AgSim
{
    public partial class FormSim : Form
    {
        //Our two new nmea strings
        StringBuilder sbRMC = new StringBuilder();
        StringBuilder sbGGA = new StringBuilder();
        StringBuilder sbVTG = new StringBuilder();

        StringBuilder sbSendText = new StringBuilder();

        //for left right buttons
        bool isTurnLeft = false;
        bool isTurnRight = false;
        int turnSpeed = 1;

        int fixQuality = 3;
        int sats = 7;
        double HDOP = 0.9;
        int altitude = 20;

        int portLineCounter = 0;
        char EW = 'W';
        char NS = 'N';

        double latitude = 53.5;
        double longitude = 110.5;
        double stepDistance = 0.2;

        double latDeg = 0;
        double latMinu = 0;

        double longDeg = 0;
        double longMinu = 0;

        double latNMEA = 0;
        double longNMEA = 0;

        double speed = 5;

        double headingTrueSlide = 180.0;
        double headingTrue = 180.0;

        //The checksum of an NMEA line
        string sumStr = "";

        public static string portName = "GPS";
        public static int baudRate = 4800;

        //serial port gps is connected to
        public SerialPort sp = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);

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


        #endregion NMEA_Sentence_Guide


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isTurnRight)
            {
                headingTrueSlide -= turnSpeed;
                if (headingTrueSlide >= 720) headingTrueSlide = 0;
                if (headingTrueSlide < 0) headingTrueSlide = 720;
                tbarHeading.Value = (int)headingTrueSlide;

            }

            if (isTurnLeft)
            {
                headingTrueSlide += turnSpeed;
                if (headingTrueSlide >= 720) headingTrueSlide = 0;
                if (headingTrueSlide < 0) headingTrueSlide = 720;
                tbarHeading.Value = (int)headingTrueSlide;

            }

            lblHeadingTrueSlide.Text = headingTrueSlide.ToString();
               if (headingTrueSlide >= 360) headingTrue = headingTrueSlide - 360;
                else headingTrue = headingTrueSlide;
 
             //Calculate the next Lat Long based on heading and distance
            calculateNewPostionFromBearingDistance(latitude, longitude, headingTrue, stepDistance/1000.0);
                
            //calc the speed
            speed = Math.Round((1.944 * stepDistance * (double)nudHz.Value),1);
            lblSpeed.Text = (Math.Round((1.852 * speed), 1)).ToString();

            BuildRMC();
            BuildGGA();
            BuildVTG();
 
            
            if (chkGGA.Checked) sbSendText.Append(sbGGA.ToString());
            
            //send garbage            
            //sbSendText.Append("$\r\n,4,4,,,,,,*\\\\\\\\\\\\\\\\\\");  
            if (chkVTG.Checked)sbSendText.Append(sbVTG.ToString());
            if (chkRMC.Checked) sbSendText.Append(sbRMC.ToString()); 

            if (sp.IsOpen)
            {
                try { sp.Write(sbSendText.ToString()); }
                catch (Exception exc) { if (!sp.IsOpen)MessageBox.Show(exc.Message, "Connection already terminated?"); }
            } 

            //the text box showing the nmea string
            txtNMEA.Text = sbSendText.ToString();
            sbSendText.Clear();
            portLineCounter++; 
        }
        void BuildGGA()
        {
            sbGGA.Clear();
            sbGGA.Append("$GPGGA,");
            sbGGA.Append(DateTime.Now.ToString("HHmmss,"));
            sbGGA.Append(latNMEA.ToString() + ',' + NS + ',');
            sbGGA.Append(longNMEA.ToString() + ',' + EW + ',');           
            sbGGA.Append(fixQuality.ToString()+','+sats.ToString()+','+HDOP.ToString()+','+altitude.ToString());
            sbGGA.Append(",M,46.9,M,,,*");

            CalculateChecksum(sbGGA.ToString());
            sbGGA.Append(sumStr);
            sbGGA.Append("\r\n");

            /*
        $GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M ,  ,*47
           0     1      2      3    4      5 6  7  8   9    10 11  12 13  14
                Time      Lat       Lon     FixSatsOP Alt */
        }

        void BuildVTG()
        {
            sbVTG.Clear();
            sbVTG.Append("$GPVTG,");
            sbVTG.Append(headingTrue);
            sbVTG.Append(",T,034.4,M,");
            sbVTG.Append(speed.ToString());
            sbVTG.Append(",N,");
            sbVTG.Append((speed * 1.852).ToString());
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

        void BuildRMC()
        {
            sbRMC.Clear();
            sbRMC.Append("$GPRMC,");
            sbRMC.Append(DateTime.Now.ToString("HHmmss,"));

            //add the latitude
            sbRMC.Append("A," + latNMEA.ToString() + ',' + NS + ',');

            //add the longitude
            sbRMC.Append(longNMEA.ToString() + ',' + EW + ',');

            //add the speed and date
            sbRMC.Append(speed.ToString() + ',' + headingTrue.ToString() + ',' + DateTime.Now.ToString("ddMMyy") + ",0,W*");

            CalculateChecksum(sbRMC.ToString());
            sbRMC.Append(sumStr);
            sbRMC.Append("\r\n");
        }

        public FormSim()
        {
            InitializeComponent();
        }

        private void FormSim_Load(object sender, EventArgs e)
        {
            //load the port box with valid port names
            cboxPort.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboxPort.Items.Add(s);
            }

            //check if GPS port is open or closed and set buttons accordingly
            if (sp.IsOpen)
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

            //set baud and port from last time run
            baudRate = Properties.Settings.Default.setting_baudRate;
            portName = Properties.Settings.Default.setting_portName;


            SerialPortOpen();
            cboxPort.Text = sp.PortName;
            cboxBaud.Text = sp.BaudRate.ToString();
        }

        public void SerialPortOpen()
        {
            if (!sp.IsOpen)
            {
                sp.PortName = portName;
                sp.BaudRate = baudRate;
                sp.WriteTimeout = 1000;
            }

            try { sp.Open(); }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Serial Port Active");

 
                //SettingsPageOpen(0);
            }

            if (sp.IsOpen)
            {
                btnOpenSerial.Enabled = false;
                btnCloseSerial.Enabled = true;

                //discard any stuff in the buffers
                sp.DiscardOutBuffer();
                sp.DiscardInBuffer();


                Properties.Settings.Default.setting_portName = portName;
                Properties.Settings.Default.setting_baudRate = baudRate;
                Properties.Settings.Default.Save();
            }
        }

        public void SerialPortClose()
        {
            if (sp.IsOpen)
            {
                try { sp.Close(); }
                catch (Exception exc) { MessageBox.Show(exc.Message, "Connection already terminated?"); }

                btnOpenSerial.Enabled = true;
                btnCloseSerial.Enabled = false;

                sp.Dispose();
            }

        }
#region btns
 
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (isTurnRight)
            {
                isTurnRight = false;
                btnRight.ForeColor = Color.Black;
            }
            isTurnLeft = !isTurnLeft;
            if (isTurnLeft) btnLeft.ForeColor = Color.Red;
            else btnLeft.ForeColor = Color.Black;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (isTurnLeft)
            {
                isTurnLeft = false;
                btnLeft.ForeColor = Color.Black;
            }
            isTurnRight = !isTurnRight;
            if (isTurnRight) btnRight.ForeColor = Color.Red;
            else btnRight.ForeColor = Color.Black;
        }

       //lat, lng in degrees. Bearing in degrees. Distance in Km
        public void calculateNewPostionFromBearingDistance (double lat, double lng, double bearing, double distance) 
        {
            double R = 6371; // Earth Radius in Km

            double lat2 = Math.Asin(Math.Sin(Math.PI / 180 * lat) * Math.Cos(distance / R) + 
                Math.Cos(Math.PI / 180 * lat) * Math.Sin(distance / R) * Math.Cos(Math.PI / 180 * bearing));

            double lon2 = Math.PI / 180 * lng + Math.Atan2(Math.Sin( Math.PI / 180 * bearing) * Math.Sin(distance / R) * 
                Math.Cos( Math.PI / 180 * lat ), Math.Cos(distance / R) - Math.Sin( Math.PI / 180 * lat) * Math.Sin(lat2));

            latitude = 180 / Math.PI * lat2;
            longitude = 180 / Math.PI * lon2;

            //convert to DMS from Degrees
            latMinu = latitude;
            longMinu = longitude;

            latDeg = (int)latitude;
            longDeg = (int)longitude;

            latMinu -= latDeg;
            longMinu -= longDeg;

            latMinu = Math.Round(latMinu * 60.0,7);
            longMinu = Math.Round(longMinu * 60.0,7);

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
                sum = sum ^ tmp;    // Build checksum
            }
            // Calculated checksum converted to a 2 digit hex string
            sumStr = String.Format("{0:X2}", sum);
       }
        private void FormSim_FormClosing(object sender, FormClosingEventArgs e)
        {
            sp.Close();
            sp.Dispose();

        }

        private void nudHz_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32((1/nudHz.Value * 1000));
            stepDistance = ((double)(tbarStepDistance.Value)) / 10.0 / (double)nudHz.Value;
            lblStep.Text = Convert.ToString(Math.Round(((double)(tbarStepDistance.Value)) / 10.0, 1));
        }

         private void tbarStepDistance_Scroll(object sender, EventArgs e)
        {
            stepDistance = ((double)(tbarStepDistance.Value))/10.0 / (double)nudHz.Value;
            lblStep.Text = Convert.ToString(Math.Round(((double)(tbarStepDistance.Value)) / 10.0, 1));
            lblSpeed.Text = (Math.Round((1.852 * speed), 1)).ToString();
        }


        private void tbarHeading_Scroll(object sender, EventArgs e)
        {
            headingTrueSlide = tbarHeading.Value;
            if (headingTrueSlide >= 720) tbarHeading.Value = 0;
            if (headingTrueSlide <= 0) tbarHeading.Value = 720;
            if (headingTrueSlide >= 360) headingTrue = headingTrueSlide - 360;
            else headingTrue = headingTrueSlide;
            lblHeadingTrueSlide.Text = Convert.ToString(headingTrueSlide);
        }

        private void btnHead0_Click(object sender, EventArgs e)
        {
            headingTrueSlide = 0;
            tbarHeading.Value = 360;
            lblHeadingTrueSlide.Text = Convert.ToString(headingTrueSlide);
        }

        private void btnHead90_Click(object sender, EventArgs e)
        {
            headingTrueSlide = 90;
            tbarHeading.Value = 90;
            lblHeadingTrueSlide.Text = Convert.ToString(headingTrueSlide);
  
        }

        private void btnHead180_Click(object sender, EventArgs e)
        {
            headingTrueSlide = 180;
            tbarHeading.Value = 180;
            lblHeadingTrueSlide.Text = Convert.ToString(headingTrueSlide);
 
        }

        private void btnHead270_Click(object sender, EventArgs e)
        {
            headingTrueSlide = 270;
            tbarHeading.Value = 270;
            lblHeadingTrueSlide.Text = Convert.ToString(headingTrueSlide);
  
        }
#endregion

        private void btnOpenSerial_Click(object sender, EventArgs e)
        {
            SerialPortOpen();
        }

        private void btnCloseSerial_Click(object sender, EventArgs e)
        {
            SerialPortClose();
        }

        private void cboxPort_Leave(object sender, EventArgs e)
        {
            portName = cboxPort.Text;
        }

        private void cboxBaud_Leave(object sender, EventArgs e)
        {
            baudRate = Convert.ToInt32(cboxBaud.Text);
        }

        private void tbarTurnSpeed_Scroll(object sender, EventArgs e)
        {
            turnSpeed = tbarTurnSpeed.Value;
            lblTurnSpeed.Text = turnSpeed.ToString();
        }

        private void nudAltitude_ValueChanged(object sender, EventArgs e)
        {
            altitude = (int)nudAltitude.Value;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            stepDistance = 0.2;
            latitude = 53.5;
            longitude = 110.5;
 
        }

  
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

    }
}
