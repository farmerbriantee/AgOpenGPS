using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net.Sockets;
using System.Net;


namespace AgSim
{
    public partial class FormSimIP : Form
    {

        // Declare the delegate prototype to send data back to the form
        delegate void AddMessage(string sNewMessage);

        private event AddMessage AddMessageEvent;	// Add Message Event handler for Form

        // TCP Attributes
        private Socket sock;						// Server connection
        private byte[] buffer = new byte[1024];	    // Received data buffer
        private bool isConnected = false;           // No send if not connected to server flag

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
        public FormSimIP()
        {
            InitializeComponent();

            // Add Message Event handler for Form decoupling from input thread
            AddMessageEvent = new AddMessage(OnAddMessage);

        }


        //threadsafe catch message displayed
        public void CatchErrorMessageBox(string text, string textTitle)
        {
            Invoke((Action)delegate
            {
                MessageBox.Show(text, textTitle);
            });
        }


        //Form closing so disconnect
        private void FormSim_FormClosing(object sender, FormClosingEventArgs e)
        {
            isConnected = false;

            if (sock != null && sock.Connected)
            {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }

        }

        //Send the string out to server
        private void SendNMEA()
        {
            // Check we are connected
            if (sock == null || !sock.Connected)
            {
                isConnected = false;
                MessageBox.Show("Must be connected to Send a message","AgSim IPAddress Client" );
                return;
            }

            // Read the message from the text box and send it
            try
            {
                // Convert to byte array and send.
                Byte[] byteDateLine = Encoding.ASCII.GetBytes(sbSendText.ToString().ToCharArray());
                sock.Send(byteDateLine, byteDateLine.Length, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Send Message Failed!");
                isConnected = false;
            }

        }


        // Set by NMEA Hz value. Send out repetitively.
        private void timer1_Tick(object sender, EventArgs e)
        {
            #region SimStuff
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
#endregion    

            //send garbage for testing            
            //sbSendText.Append("$\r\n,4,4,,,,,,*\\\\\\\\\\\\\\\\\\");  
            if (chkVTG.Checked)sbSendText.Append(sbVTG.ToString());
            if (chkGGA.Checked) sbSendText.Append(sbGGA.ToString());
            if (chkRMC.Checked) sbSendText.Append(sbRMC.ToString()); 

            //the text box showing the nmea string being sent
            txtNMEA.Text = sbSendText.ToString();

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
            longitude = 110.5;
 
        }
#endregion

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                // Close the socket if it is still open
                if (sock != null && sock.Connected)
                {
                    sock.Shutdown(SocketShutdown.Both);
                    System.Threading.Thread.Sleep(10);
                    sock.Close();
                }

                // Create the socket object
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Define the Server address and port
                IPEndPoint epServer = new IPEndPoint(IPAddress.Parse(tboxIP.Text), 7777);

                // Connect to server non-Blocking method
                sock.Blocking = false;
                AsyncCallback onconnect = new AsyncCallback(OnConnect);
                sock.BeginConnect(epServer, onconnect, sock);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Server Connection failed!");
            }
            Cursor.Current = cursor;
        }

        public void OnConnect(IAsyncResult ar)
        {
            // Socket was the passed in object
            Socket sock = (Socket)ar.AsyncState;

            // Check if we were sucessfull
            try
            {
                //sock.EndConnect( ar );
                if (sock.Connected)
                    SetupReceiveCallback(sock);
                else
                    CatchErrorMessageBox("Unable to connect to remote machine", "Connect Failed!");
            }
            catch (Exception ex)
            {
                CatchErrorMessageBox(ex.Message, "Unusual error during Connect!");
            }
        }

        public void OnReceivedData(IAsyncResult ar)
        {
            // Socket was the passed in object
            Socket sock = (Socket)ar.AsyncState;

            // Check if we got any data
            try
            {
                int nBytesRec = sock.EndReceive(ar);
                if (nBytesRec > 0)
                {
                    // Wrote the data to the List
                    string sReceived = Encoding.ASCII.GetString(buffer, 0, nBytesRec);

                    Invoke(AddMessageEvent, new string[] { sReceived });

                    // If the connection is still usable restablish the callback
                    SetupReceiveCallback(sock);
                }
                else
                {
                    // If no data was received then the connection is probably dead
                    CatchErrorMessageBox(sock.RemoteEndPoint.ToString(), "Disconnected from Server");
                    isConnected = false;
                    sock.Shutdown(SocketShutdown.Both);
                    sock.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show( this, ex.Message, "Unusual error during Receive!" );
            }
        }

        public void OnAddMessage(string sMessage)
        {
            //tboxReceive.AppendText(sMessage);
            tboxReceive.Text = sMessage;
            isConnected = true;
        }

        public void SetupReceiveCallback(Socket sock)
        {
            try
            {
                AsyncCallback receiveData = new AsyncCallback(OnReceivedData);
                sock.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, receiveData, sock);
            }
            catch (Exception ex)
            {
                CatchErrorMessageBox(ex.Message, "Setup Receive Callback failed!");
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            sock.Shutdown(SocketShutdown.Both);
            sock.Close();
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
            sbVTG.Append(360-headingTrue);
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

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
