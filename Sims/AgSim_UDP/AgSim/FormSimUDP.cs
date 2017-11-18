using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Globalization;

namespace AgSimUDP
{
    public partial class FormSimUDP : Form
    {

        // Client socket
        private Socket clientSocket;

        // Client ip
        private string ipAddress;

        // Server End Point
        private EndPoint epServer;

        // Data buffer
        private byte[] buffer = new byte[256];

        // Display message delegate
        private delegate void DisplayMessageDelegate(string message);
        private DisplayMessageDelegate displayMessageDelegate = null;

        bool isConnected = false;

        #region properties sim
        //Our two new nmea strings
        StringBuilder sbRMC = new StringBuilder();
        StringBuilder sbGGA = new StringBuilder();
        StringBuilder sbVTG = new StringBuilder();

        //The entire string to send out
        StringBuilder sbSendText = new StringBuilder();

        //for left right buttons
        bool isTurnLeft = false;
        bool isTurnRight = false;
        int turnSpeed = 1;

        //GPS related properties
        int fixQuality = 3;
        int sats = 7;
        double HDOP = 0.9;
        int altitude = 20;
        double randLat = 0, randLon = 0;

        char EW = 'W';
        char NS = 'N';

        double latitude = 53.436026;
        double longitude = -110.160047;
        double stepDistance = 0.5;

        double latDeg = 0;
        double latMinu = 0;

        double longDeg = 0;
        double longMinu = 0;

        double latNMEA = 0;
        double longNMEA = 0;

        double speed = 0.6;

        double headingTrueSlide = 180.0;
        double headingTrue = 180.0;

        //The checksum of an NMEA line
        string sumStr = "";

        #endregion

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

        //Form constructor
        public FormSimUDP()
        {
            InitializeComponent();
        }

        //connect and set up UDP to broadcast
        private void FormSim_Load(object sender, EventArgs e)
        {
            // Initialise delegate
            displayMessageDelegate = new DisplayMessageDelegate(DisplayMessage);

            //try
            //{
            //    ipAddress = tboxIP.Text.Trim();

            //    // Initialise socket
            //    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //    // Initialise server IP
            //    IPAddress serverIP = IPAddress.Parse(ipAddress);

            //    // Initialise the IPEndPoint for the server and use port 30000
            //    epServer = new IPEndPoint(serverIP, (int)nudPort.Value);

            //    // Get packet as byte array
            //    byte[] data = Encoding.ASCII.GetBytes("Connecting");

            //    // Send data to server
            //    clientSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, epServer, new AsyncCallback(SendData), null);

            //    // Initialise data stream
            //    buffer = new byte[1024];

            //    timer1.Enabled = true;

            //    // Begin listening for broadcasts
            //    clientSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epServer, new AsyncCallback(ReceiveData), null);

            //    //start allowing nmea to be sent
            //    isConnected = true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Connection Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //calc the speed
            stepDistance = ((double)(tbarStepDistance.Value)) / 10.0 / (double)nudHz.Value;
            lblStep.Text = Convert.ToString(Math.Round(((double)(tbarStepDistance.Value)) / 10.0, 1));
            lblSpeed.Text = (Math.Round((1.852 * speed), 1)).ToString();

        }

        //Form closing so disconnect
        private void FormSim_FormClosing(object sender, FormClosingEventArgs e)
        {
            isConnected = false;
            try
            {
                if (clientSocket != null)
                {
                    // Get packet as byte array
                    byte[] byteData = Encoding.ASCII.GetBytes("GoodBye");

                    // Send packet to the server
                    clientSocket.SendTo(byteData, 0, byteData.Length, SocketFlags.None, epServer);

                    // Close the socket
                    clientSocket.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Closing Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //asynchronous send data callback
        private void SendData(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send Data: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //asynchronous receive data callback
        private void ReceiveData(IAsyncResult ar)
        {
            try
            {
                // Receive all data
                clientSocket.EndReceive(ar);

                // Receive all data
                int msgLen = clientSocket.EndReceiveFrom(ar, ref epServer);

                byte[] localMsg = new byte[msgLen];
                Array.Copy(buffer, localMsg, msgLen);

                // Listen for more connections again...
                clientSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epServer, new AsyncCallback(ReceiveData), epServer);

                string text = Encoding.ASCII.GetString(localMsg);

                // Update display through a delegate
                if (text != null)
                    Invoke(displayMessageDelegate, new object[] { text });

                // Reset data stream
                buffer = new byte[1024];

                // Continue listening for broadcasts
                clientSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epServer, new AsyncCallback(ReceiveData), null);
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show("Receive Data: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //delegate access to thread
        private void DisplayMessage(string messge)
        {
            txtNMEA.AppendText(messge);
        }

        //Send the string out to server
        private void SendNMEA()
        {
            try
            {
                // Get packet as byte array
                byte[] byteData = Encoding.ASCII.GetBytes(sbSendText.ToString());

                if (byteData.Length != 0)

                    // Send packet to the server
                    clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epServer, new AsyncCallback(SendData), null);

                //not really necessary but does show what was in buffer that was sent
                txtNMEA.Text = (Encoding.ASCII.GetString(byteData));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            // Check we are connected


        }


        // Set by NMEA Hz value. Send out repetitively.
        private void timer1_Tick(object sender, EventArgs e)
        {
            #region SimStuff
            if (isTurnLeft)
            {
                headingTrueSlide -= turnSpeed;
                if (headingTrueSlide >= 720) headingTrueSlide = 0;
                if (headingTrueSlide < 0) headingTrueSlide = 720;
                tbarHeading.Value = (int)headingTrueSlide;

            }

            if (isTurnRight)
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
#endregion    

            //send garbage for testing            
            //sbSendText.Append("$\r\n,4,4,,,,,,*\\\\\\\\\\\\\\\\\\");  
            if (chkVTG.Checked)sbSendText.Append(sbVTG.ToString());
            if (chkGGA.Checked) sbSendText.Append(sbGGA.ToString());
            if (chkRMC.Checked) sbSendText.Append(sbRMC.ToString()); 

            //the text box showing the nmea string being sent
            //txtNMEA.Text = sbSendText.ToString();

            //only if connected then send otherwise shit storm of messageboxes will occur
            if (isConnected)
            {
                //label10.Text = (clientSocket.Poll(-1, SelectMode.SelectWrite)).ToString();
                SendNMEA();
            }

            sbSendText.Clear();
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

            int n = r.Next(0,3);
            randLat = n* 0.00001;
            if (cboxIsNoise.Checked) latMinu = Math.Round(latMinu * 60.0, 7) + randLat;
            else latMinu = Math.Round(latMinu * 60.0, 7);
            n = r.Next(0, 3);
            randLat = n * 0.00001;
            if (cboxIsNoise.Checked) longMinu = Math.Round(longMinu * 60.0, 7) + randLat;
            else longMinu = Math.Round(longMinu * 60.0, 7);

            latDeg *= 100.0;
            longDeg *= 100.0;

            latNMEA = latMinu + latDeg;
            longNMEA = longMinu + longDeg;
       }

        //random
         Random r = new Random();

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
            longitude = -110.5;

            //calc the speed
            speed = Math.Round((1.944 * stepDistance * (double)nudHz.Value), 1);
            lblSpeed.Text = (Math.Round((1.852 * speed), 1)).ToString();

 
        }
#endregion


       void BuildGGA()
        {
            sbGGA.Clear();
            sbGGA.Append("$GPGGA,");
            sbGGA.Append(DateTime.Now.ToString("HHmmss" +".00,", CultureInfo.InvariantCulture));
            sbGGA.Append(latNMEA.ToString(CultureInfo.InvariantCulture) + ',' + NS + ',');
            sbGGA.Append(Math.Abs(longNMEA).ToString(CultureInfo.InvariantCulture) + ',' + EW + ',');           
            sbGGA.Append(fixQuality.ToString(CultureInfo.InvariantCulture) +','+sats.ToString(CultureInfo.InvariantCulture) +','+
                HDOP.ToString(CultureInfo.InvariantCulture) +','+altitude.ToString(CultureInfo.InvariantCulture));
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
            sbVTG.Append((headingTrue).ToString(CultureInfo.InvariantCulture));
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

        void BuildRMC()
        {
            sbRMC.Clear();
            sbRMC.Append("$GPRMC,");
            sbRMC.Append(DateTime.Now.ToString("HHmmss" + ".00,", CultureInfo.InvariantCulture));

            //add the latitude
            sbRMC.Append("A," + latNMEA.ToString(CultureInfo.InvariantCulture) + ',' + NS + ',');

            //add the longitude
            sbRMC.Append(Math.Abs(longNMEA).ToString(CultureInfo.InvariantCulture) + ',' + EW + ',');

            //add the speed and date
            sbRMC.Append(speed.ToString(CultureInfo.InvariantCulture) + ',' + headingTrue.ToString(CultureInfo.InvariantCulture) + ',' + 
                DateTime.Now.ToString("ddMMyy", CultureInfo.InvariantCulture) + ",0,W*");

            //sbRMC.Clear();
            //sbRMC.Append("$GPRMC,105506.800,A,4016.1090,N,00730.8665,W,11.00,37.89.010517,,,D*");

            CalculateChecksum(sbRMC.ToString());
            sbRMC.Append(sumStr);
            sbRMC.Append("\r\n");
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (clientSocket != null)
            {
                // Get packet as byte array
                byte[] byteData = Encoding.ASCII.GetBytes("GoodBye");

                // Send packet to the server
                clientSocket.SendTo(byteData, 0, byteData.Length, SocketFlags.None, epServer);

                // Close the socket
                clientSocket.Close();
            }

            try
            {
                ipAddress = tboxIP.Text.Trim();

                // Initialise socket
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Initialise server IP
                IPAddress serverIP = IPAddress.Parse(ipAddress);

                // Initialise the IPEndPoint for the server and use port 30000
                epServer = new IPEndPoint(serverIP, (int)nudPort.Value);

                // Get packet as byte array
                byte[] data = Encoding.ASCII.GetBytes("Connecting");

                // Send data to server
                clientSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, epServer, new AsyncCallback(SendData), null);

                // Initialise data stream
                buffer = new byte[1024];

                timer1.Enabled = true;

                // Begin listening for broadcasts
                clientSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epServer, new AsyncCallback(ReceiveData), null);

                //start allowing nmea to be sent
                isConnected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
