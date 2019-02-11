using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Drawing;
using System.Globalization;

// Declare the delegate prototype to send data back to the form
delegate void UpdateRTCM_Data(byte[] data);

namespace AgOpenGPS
{
    public partial class FormGPS
    {

        private Socket clientSocket;                      // Server connection
        private byte[] casterRecBuffer = new byte[256];    // Recieved data buffer
        private event UpdateRTCM_Data updateRTCM_DataEvent;              // Add Message Event handler for Form

        //Send GGA back timer
        Timer tmr;

        private string mount;
        private string username;
        private string password;

        private string broadCasterIP;
        private int broadCasterPort;

        private int sendGGAInterval = 0;
        private string GGASentence;

        public uint tripBytes = 0;
        private int toUDP_Port = 0;
        private int NTRIP_Watchdog = 100;

        public bool isNTRIP_RequiredOn = false;
        public bool isNTRIP_Connected = false;
        public bool isNTRIP_Starting = false;
        public bool isNTRIP_Sending = false;

        private void NTRIPtick(object o, EventArgs e)
        {
            SendGGA();
        }

        private void ReconnectRequest()
        {
            //TimedMessageBox(2000, "NTRIP Not Connected", " Reconnect Request");
            ntripCounter = 10;
            isNTRIP_Connected = false;
            isNTRIP_Starting = false;
        }

        //set up connection to Caster
        public void StartNTRIP()
        {
            broadCasterIP = Properties.Settings.Default.setNTRIP_casterIP; //Select correct Address
            broadCasterPort = Properties.Settings.Default.setNTRIP_casterPort; //Select correct port (usually 80 or 2101)
            mount = Properties.Settings.Default.setNTRIP_mount; //Insert the correct mount
            username = Properties.Settings.Default.setNTRIP_userName; //Insert your username!
            password = Properties.Settings.Default.setNTRIP_userPassword; //Insert your password!
            toUDP_Port = Properties.Settings.Default.setNTRIP_sendToUDPPort; //send rtcm to which udp port
            sendGGAInterval = Properties.Settings.Default.setNTRIP_sendGGAInterval; //how often to send fixes
            if (tmr != null)
            {
                tmr.Dispose();
            }

            if (sendGGAInterval > 0)
            {
                this.tmr = new System.Windows.Forms.Timer();
                this.tmr.Interval = sendGGAInterval * 1000;
                this.tmr.Tick += new EventHandler(NTRIPtick);
            }


            //broadCasterIP = "89.216.55.251";
            //broadCasterPort = 9000;
            //mount = "MAX";
            //username = "pgivanovic";
            //password = "903742";
            //ggaSentence = "$GPGGA,092530.589,4516.371,N,01950.609,E,1,12,1.0, 0.0,M,0.0,M,,*66" + "\r\n";

            //toUDP_Port = Properties.Settings.Default.setNTRIP_sendToUDPPort; //send rtcm to which udp port
            //sendGGAInterval = Properties.Settings.Default.setNTRIP_sendGGAInterval; //how often to send fixes

            //// Add Message Event handler for Form decoupling from client socket thread
            updateRTCM_DataEvent = new UpdateRTCM_Data(OnAddMessage);

            try
            {
                // Close the socket if it is still open
                if (clientSocket != null && clientSocket.Connected)
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    System.Threading.Thread.Sleep(100);
                    clientSocket.Close();
                }

                // Create the socket object
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Define the Server address and port
                IPEndPoint epServer = new IPEndPoint(IPAddress.Parse(broadCasterIP), broadCasterPort);

                // Connect to server non-Blocking method
                clientSocket.Blocking = false;
                AsyncCallback onconnect = new AsyncCallback(OnConnect);
                clientSocket.BeginConnect(epServer, onconnect, clientSocket);
            }
            catch (Exception)
            {
                TimedMessageBox(1000, "NTRIP Not Connected, Retrying", " At Socket Connect ");
                ReconnectRequest();
                return;
            }

            //make sure connection is made
            System.Threading.Thread.Sleep(2000);

            //send the authourization info for Broadcaster

            // Check we are connected
            if (clientSocket == null || !clientSocket.Connected)
            {
                TimedMessageBox(2000, "NTRIP Not Connected", " At the StartNTRIP() ");
                ReconnectRequest();
                return;
            }

            // Read the message from the text box and send it
            try
            {
                string auth = ToBase64(username + ":" + password);

                BuildGGA();
                GGASentence = sbGGA.ToString();


                // Convert to byte array and send.
                //string str = "GET /SRG HTTP / 1.1\r\nUser - Agent: NTRIP LefebureNTRIPClient/ 20131124\r\nAccept: */*\r\nConnection: close\r\n";

                string str = "GET /" + mount + " HTTP/1.1\r\n";
                str += "User-Agent: NTRIP LefebureNTRIPClient/20131124\r\n";
                str += "Authorization: Basic " + auth + "\r\n"; //This line can be removed if no authorization is needed
                str += GGASentence; //this line can be removed if no position feedback is needed
                str += "Accept: */*\r\nConnection: close\r\n";
                str += "\r\n";

                Byte[] byteDateLine = Encoding.ASCII.GetBytes(str.ToCharArray());
                clientSocket.Send(byteDateLine, byteDateLine.Length, 0);

                //enable to periodically send GGA sentence to server.
                if (sendGGAInterval > 0)
                {
                    tmr.Enabled = true;
                }

                //say its connected
                isNTRIP_Connected = true;
                isNTRIP_Starting = false;
                btnStartStopNtrip.Text = "Stop";

            }
            catch (Exception)
            {
                //MessageBox.Show(this, ex.Message, "Send Message Failed!");
            }

        }

        public void OnAddMessage(byte[] data)
        {
            lblNtripBytes.Text = (tripBytes)/1000 +  " Kb";
            tripBytes += (uint)data.Length;

            NTRIP_Watchdog = 0;

            if (toUDP_Port == 0)
            {
                try
                {
                    if (sp.IsOpen)
                    {
                        sp.Write(data, 0, data.Length);
                    }
                }
                catch (Exception ex)
                {
                    WriteErrorLog("NTRIP Data Serial Send" + ex.ToString());
                }
            }
            else
            {
                try
                {
                    SendUDPMessageNTRIP(data, toUDP_Port);

                }
                catch (Exception ex)
                {
                    WriteErrorLog("NTRIP Data UDP Send" + ex.ToString());
                }
            }
        }

        public void SendGGA()
        {
            if (!isNTRIP_Connected) return;
            // Check we are connected
            if (clientSocket == null || !clientSocket.Connected)
            {
                TimedMessageBox(1000, "NTRIP Not Connected", " During Send $PGGGA");
                ReconnectRequest();

                return;
            }

            // Read the message from the text box and send it
            try
            {
                isNTRIP_Sending = true;
                //string str = "$GPGGA,092530.589,4516.371,N,01950.609,E,1,12,1.0, 0.0,M,0.0,M,,*66" + "\r\n"; //this line can be removed if no position feedback is needed
                BuildGGA();
                string str = sbGGA.ToString();

                Byte[] byteDateLine = Encoding.ASCII.GetBytes(str.ToCharArray());
                clientSocket.Send(byteDateLine, byteDateLine.Length, 0);
            }
            catch (Exception)
            {
                //MessageBox.Show(this, ex.Message, "Send Message Failed!");
            }
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
                    SetupRecieveCallback(sock);
                //else
                //    MessageBox.Show("Unable to connect to remote machine", "Connect Failed!");
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Unusual error during Connect!");
            }
        }

        public void OnRecievedData(IAsyncResult ar)
        {
            // Socket was the passed in object
            Socket sock = (Socket)ar.AsyncState;

            // Check if we got any data
            try
            {
                int nBytesRec = sock.EndReceive(ar);
                if (nBytesRec > 0)
                {
                    byte[] localMsg = new byte[nBytesRec];
                    Array.Copy(casterRecBuffer, localMsg, nBytesRec);

                    // Wrote the data to the List
                    string sRecieved = Encoding.ASCII.GetString(casterRecBuffer, 0, nBytesRec);

                    // WARNING : The following line is NOT thread safe. Invoke is
                    // m_lbRecievedData.Items.Add( sRecieved );
                    Invoke(updateRTCM_DataEvent, new object[] { localMsg });

                    // If the connection is still usable restablish the callback
                    SetupRecieveCallback(sock);
                }
                else
                {
                    // If no data was recieved then the connection is probably dead
                    Console.WriteLine("Client {0}, disconnected", sock.RemoteEndPoint);
                    sock.Shutdown(SocketShutdown.Both);
                    sock.Close();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show( this, ex.Message, "Unusual error druing Recieve!" );
            }
        }

        public void SetupRecieveCallback(Socket sock)
        {
            try
            {
                AsyncCallback recieveData = new AsyncCallback(OnRecievedData);
                sock.BeginReceive(casterRecBuffer, 0, casterRecBuffer.Length, SocketFlags.None, recieveData, sock);
            }
            catch (Exception)
            {
                //MessageBox.Show(this, ex.Message, "Setup Recieve Callback failed!");
            }
        }

        private string ToBase64(string str)
        {
            Encoding asciiEncoding = Encoding.ASCII;
            byte[] byteArray = new byte[asciiEncoding.GetByteCount(str)];
            byteArray = asciiEncoding.GetBytes(str);
            return Convert.ToBase64String(byteArray, 0, byteArray.Length);
        }

        private void ShutDownNTRIP()
        {
            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                System.Threading.Thread.Sleep(500);

                TimedMessageBox(2000, "NTRIP ShutDown", " Click Start to Resume");
                ReconnectRequest();

                //Also stop the requests now
                isNTRIP_RequiredOn = false;
            }

        }

        private void SettingsShutDownNTRIP()
        {
            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                System.Threading.Thread.Sleep(500);

                TimedMessageBox(2000, "NTRIP Restarting", "Resuming With New Settings");
                ReconnectRequest();

                //Continue to restart
                isNTRIP_RequiredOn = true;
            }
        }

        //calculate the NMEA checksum to stuff at the end
        public string CalculateChecksum(string Sentence)
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
            return String.Format("{0:X2}", sum);
        }

        private readonly StringBuilder sbGGA = new StringBuilder();

        private void BuildGGA()
        {
            double latitude = 0;
            double longitude = 0;

            if (Properties.Settings.Default.setNTRIP_isGGAManual)
            {
                latitude = Properties.Settings.Default.setNTRIP_manualLat;
                longitude = Properties.Settings.Default.setNTRIP_manualLon;
            }
            else
            {
                latitude = pn.latitude;
                longitude = pn.longitude;
            }
            //convert to DMS from Degrees
            double latMinu = latitude;
            double longMinu = longitude;

            double latDeg = (int)latitude;
            double longDeg = (int)longitude;

            latMinu -= latDeg;
            longMinu -= longDeg;

            latMinu = Math.Round(latMinu * 60.0, 7);
            longMinu = Math.Round(longMinu * 60.0, 7);

            latDeg *= 100.0;
            longDeg *= 100.0;

            double latNMEA = latMinu + latDeg;
            double longNMEA = longMinu + longDeg;

            char NS = 'W';
            char EW = 'N';
            if (pn.latitude >= 0) NS = 'N';
            else NS = 'S';
            if (pn.longitude >= 0) EW = 'E';
            else EW = 'W';

            sbGGA.Clear();
            sbGGA.Append("$GPGGA,");
            sbGGA.Append(DateTime.Now.ToString("HHmmss.00,", CultureInfo.InvariantCulture));
            sbGGA.Append(Math.Abs(latNMEA).ToString("0000.0000000", CultureInfo.InvariantCulture)).Append(',').Append(NS).Append(',');
            sbGGA.Append(Math.Abs(longNMEA).ToString("00000.0000000", CultureInfo.InvariantCulture)).Append(',').Append(EW).Append(',');
            sbGGA.Append("2,08,0.9,250");
            sbGGA.Append(",M,46.9,M,,,*");
            
            sbGGA.Append(CalculateChecksum(sbGGA.ToString()));
            sbGGA.Append("\r\n");
            /*
        $GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M ,  ,*47
           0     1      2      3    4      5 6  7  8   9    10 11  12 13  14
                Time      Lat       Lon     FixSatsOP Alt */
        }
    }
}




//public static void StartClient()
//{
//    // Connect to a remote device.  
//    try
//    {
//        // Establish the remote endpoint for the socket.  
//        // The name of the   
//        // remote device is "host.contoso.com".  
//        IPHostEntry ipHostInfo = Dns.GetHostEntry("RTK2Go.com");
//        IPAddress ipAddress = ipHostInfo.AddressList[0];
//        IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

//        // Create a TCP/IP socket.  
//        Socket client = new Socket(ipAddress.AddressFamily,
//            SocketType.Stream, ProtocolType.Tcp);

//        // Connect to the remote endpoint.  
//        client.BeginConnect(remoteEP,
//            new AsyncCallback(ConnectCallback), client);
//        connectDone.WaitOne();

//        //string msg = "GET /SRG HTTP/1.1\r\nUser-Agent: NTRIP LefebureNTRIPClient/20131124\r\nAccept: */*\r\nConnection: close\r\n"    
//        string msg = "GET /" + stream + " HTTP/1.1\r\n";
//        msg += "User-Agent: NTRIP LefebureNTRIPClient/20131124\r\n";
//        //msg += "Authorization: Basic " + auth + "\r\n"; //This line can be removed if no authorization is needed
//        //msg += "$GPGGA,141717.935,4827.720,N,01628.440,E,1,12,1.0,0.0,M,0.0,M,,*65" + "\r\n"; //this line can be removed if no position feedback is needed
//        msg += "Accept: */*\r\nConnection: close\r\n";
//        msg += "\r\n<EOF>";
//    }



//using System;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading;

//namespace AgOpenGPS
//{
//    /// <summary>
//    /// This is a simple example of how to request a NTRIP RTCM stream using C# Compact Framework,
//    /// and pass it to the GPS using iter.dk's PocketGpsLib (demo available from http://www.iter.dk)
//    /// Visit http://igs.ifag.de/index_ntrip.htm for more info on NTRIP
//    ///    
//    /// Note:
//    ///     This is not a complete application. Some additional
//    ///     programming is needed to implement into an application.
//    ///     Furthermore this doesn't work with all GPS receivers. Your GPS receiver
//    ///     must support DGPS via RTCM and this feature should be active.
//    ///     Garmin eTrex is one of the receivers that supports this feature.
//    ///     The eTrex should be set to RTCM/NMEA in SETUP -> INTERFACE -> I/O FORMAT (or similar)
//    ///     This _should_ work with RTK receivers as well, but it haven't been tested. Let me know if it does.
//    ///        
//    /// Best result:
//    ///     1.7m horisontal error during a 3 hour test (95% percentile)
//    ///     Using Garmin eTrex, GPRS connection (SonyEricsson T68i) and iPAQ h3870.
//    ///     Let me know of your testresults: http://www.iter.dk/contact.aspx
//    ///
//    /// 
//    /// 
//    /// (c) Morten Nielsen, 2004
//    /// http://www.iter.dk
//    /// v1.0
//    /// </summary>
//    public class CNtrip  //: System.Windows.Forms.Form
//    {

//        public string togps;
//        public Socket sckt;
//        //public static GPSHandler GPS;
//        private System.Windows.Forms.Timer tmr;
//        int BroadCasterPort;
//        string username;
//        string password;
//        string stream;
//        IPAddress BroadCasterIP;
//        private readonly FormGPS mf;

//        /// <summary>
//        /// Initialize
//        /// </summary>
//        public CNtrip(FormGPS f)

//        {
//            mf = f;
//            BroadCasterIP = IPAddress.Parse("69.75.31.235"); //Select correct Address
//            BroadCasterPort = 2101; //Select correct port (usually 80 or 2101)
//            stream = "SRG"; //Insert the correct stream
//            username = "xxxxx"; //Insert your username!
//            password = "xxxxx"; //Insert your password!

//            // GPS = new GPSHandler(this); //Initialize GPS handler
//            // GPS.NewGPSFix += new GPSHandler.NewGPSFixHandler(this.GPSEventHandler); //Hook up GPS data events to a handler
//            this.tmr = new System.Windows.Forms.Timer();
//            this.tmr.Interval = 300;
//            this.tmr.Tick += new EventHandler(NTRIPtick);
//        }

//        /// <summary>
//        /// Responds to sentence events from GPS receiver
//        /// </summary>
//        //  private void GPSEventHandler(object sender, GPSHandler.GPSEventArgs e)
//        //  {
//        //    if(e.TypeOfEvent==GPSEventType.GPGGA) //Global Positioning System Fix Data event
//        //      if(GPS.GGA.FixQuality ==FixQualityEnum.DGPS) //We are running DGPS mode!
//        //        {
//        //             //The following info can be added to a status window
//        //             //Seconds since last DGPS update: GPS.GGA.DGPSUpdate + " sec";
//        //             //DGPS Station ID: GPS.GGA.DGPSStationID;
//        //        }
//        //}

//        /// <summary>
//        /// Fires when NTRIP start button is clicked
//        /// </summary>
//        public void btnNTRIP_Click()// (object sender, System.EventArgs e)
//        {
//            if (!tmr.Enabled)
//            {
//                StartNTRIP();
//                tmr.Enabled = true;
//            }
//            else
//            {
//                tmr.Enabled = false;
//                StopNTRIP();
//            }
//        }

//        /// <summary>
//        /// Opens the connection to the NTRIP server and starts receiving
//        /// </summary>
//        public void StartNTRIP()
//        {
//            //Connect to server
//            sckt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//            sckt.Blocking = true;
//            sckt.Connect(new IPEndPoint(BroadCasterIP, BroadCasterPort));
//            Thread.Sleep(500);

//            //Build request message
//            string auth = ToBase64(username + ":" + password);
//            string msg = "GET /" + stream + " HTTP/1.1\r\n";
//            msg += "User-Agent: NTRIP LefebureNTRIPClient/20131124\r\n";
//            //msg += "Authorization: Basic " + auth + "\r\n"; //This line can be removed if no authorization is needed
//            //msg += "$GPGGA,141717.935,4827.720,N,01628.440,E,1,12,1.0,0.0,M,0.0,M,,*65" + "\r\n"; //this line can be removed if no position feedback is needed
//            msg += "Accept: */*\r\nConnection: close\r\n";
//            msg += "\r\n";

//            //Send request
//            byte[] data = System.Text.Encoding.ASCII.GetBytes(msg);
//            sckt.Send(data);
//            Console.WriteLine(msg);
//            byte[] returndata = new byte[256];

//            Thread.Sleep(100); //Wait for response
//            sckt.Receive(returndata); //Get response
//            string responseData = System.Text.Encoding.ASCII.GetString(returndata, 0, returndata.Length);
//            ShowResponse(responseData);
//            Console.WriteLine(responseData);
//            //sckt.Blocking = false;
//        }

//        /// <summary>
//        /// Stops receiving data from the NTRIP server
//        /// </summary>
//        private void StopNTRIP()
//        {
//            sckt.Shutdown(SocketShutdown.Both);
//            sckt.Close();
//        }

//        /// <summary>
//        /// Fired when timer ticks.
//        /// Reads data from the NTRIP server and parses it to the GPS device.
//        /// </summary>
//        public void NTRIPtick(object o, EventArgs e)
//        {
//            byte[] returndata = new byte[256]; //clear buffer
//            sckt.Receive(returndata);
//            try
//            {

//                if (mf.sp.IsOpen)
//                {
//                    //    GPS.WriteToGPS(returndata); //Send RTCM data to GPS
//                    // string togps = System.Text.Encoding.UTF8.GetString(returndata);
//                    //mf.sp.WriteLine(togps);
//                    mf.sp.Write(returndata, 0, returndata.Length);
//                }


//            }
//            catch (System.Exception ex)
//            {

//                tmr.Enabled = false;
//                // GPS.Stop();
//                sckt.Shutdown(SocketShutdown.Both);
//                sckt.Close();
//                throw (new System.Exception(("Error sending to GPS:" + ex.Message)));
//            }
//            string responseData = System.Text.Encoding.ASCII.GetString(returndata, 0, returndata.Length);
//            ShowResponse(responseData);
//        }

//        /// <summary>
//        /// Display responsedata for debugging use
//        /// If the request is invalid (ie. invalid stream) a list of
//        /// available streams will be returned instead.
//        /// You should add code that handles any non-RTCM response. Refer to the NTRIP specification.
//        /// </summary>
//        /// <param name="strData"></param>
//        private void ShowResponse(string strData)
//        {
//            Console.WriteLine(strData);
//        }

//        /// <summary>
//        /// Apply AsciiEncoding to user name and password to obtain it as an array of bytes
//        /// </summary>
//        /// <param name="str">username:password</param>
//        /// <returns>Base64 encoded username/password</returns>
//        private string ToBase64(string str)
//        {
//            Encoding asciiEncoding = Encoding.ASCII;
//            byte[] byteArray = new byte[asciiEncoding.GetByteCount(str)];
//            byteArray = asciiEncoding.GetBytes(str);
//            return Convert.ToBase64String(byteArray, 0, byteArray.Length);
//        }
//    }
//}