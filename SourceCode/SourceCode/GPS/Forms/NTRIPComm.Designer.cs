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
        public bool isNTRIP_Connecting = false;
        public bool isNTRIP_Sending = false;
        public bool isRunGGAInterval = false;

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
            isNTRIP_Connecting = false;

            //if we had a timer already, kill it
            if (tmr != null)
            {
                tmr.Dispose();
            }
        }

        private void IncrementNTRIPWatchDog()
        {
            //increment once every second
            ntripCounter++;

            //Thinks is connected but not receiving anything
            if (NTRIP_Watchdog++ > 30 && isNTRIP_Connected) ReconnectRequest();

            //Once all connected set the timer GGA to NTRIP Settings
            if (sendGGAInterval > 0 && ntripCounter == 40) tmr.Interval = sendGGAInterval * 1000;
            
        }

        //set up connection to Caster
        public void StartNTRIP()
        {
            broadCasterIP = Properties.Settings.Default.setNTRIP_casterIP; //Select correct Address

            string actualIP = Properties.Settings.Default.setNTRIP_casterURL.Trim();
            try
            {
                IPAddress[] addresslist = Dns.GetHostAddresses(actualIP);
                broadCasterIP = addresslist[0].ToString().Trim();
            }
            catch (Exception)
            {
                TimedMessageBox(2500, gStr.gsNoIPLocated, gStr.gsCannotFind + Properties.Settings.Default.setNTRIP_casterURL);
            }
                                          
            broadCasterPort = Properties.Settings.Default.setNTRIP_casterPort; //Select correct port (usually 80 or 2101)
            mount = Properties.Settings.Default.setNTRIP_mount; //Insert the correct mount
            username = Properties.Settings.Default.setNTRIP_userName; //Insert your username!
            password = Properties.Settings.Default.setNTRIP_userPassword; //Insert your password!
            toUDP_Port = Properties.Settings.Default.setNTRIP_sendToUDPPort; //send rtcm to which udp port
            sendGGAInterval = Properties.Settings.Default.setNTRIP_sendGGAInterval; //how often to send fixes

            //if we had a timer already, kill it
            if (tmr != null)
            {
                tmr.Dispose();
            }

            //create new timer at fast rate to start
            if (sendGGAInterval > 0)
            {
                this.tmr = new System.Windows.Forms.Timer();
                this.tmr.Interval = 5000;
                this.tmr.Tick += new EventHandler(NTRIPtick);
            }

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
                TimedMessageBox(1000, gStr.gsNTRIPNotConnectedRetrying, gStr.gsAtSocketConnect);
                ReconnectRequest();
                return;
            }

            isNTRIP_Connecting = true;
            //make sure connection is made
            //System.Threading.Thread.Sleep(2000);
        }

        private void SendAuthorization()
        {

            //send the authourization info for Broadcaster

            // Check we are connected
            if (clientSocket == null || !clientSocket.Connected)
            {
                TimedMessageBox(2000, gStr.gsNTRIPNotConnected, " At the StartNTRIP() ");
                ReconnectRequest();
                return;
            }

            // Read the message from settings and send it
            try
            {
                //string str = "GET /SRG HTTP / 1.1\r\nUser - Agent: NTRIP LefebureNTRIPClient/ 20131124\r\nAccept: */*\r\nConnection: close\r\n";

                if (!Properties.Settings.Default.setNTRIP_isTCP)
                {
                    //encode user and password
                    string auth = ToBase64(username + ":" + password);

                    //grab location sentence
                    BuildGGA();
                    GGASentence = sbGGA.ToString();

                    //Build authorization string
                    string str = "GET /" + mount + " HTTP/1.1\r\n";
                    str += "User-Agent: NTRIP LefebureNTRIPClient/20131124\r\n";
                    str += "Authorization: Basic " + auth + "\r\n"; //This line can be removed if no authorization is needed
                                                                    //str += GGASentence; //this line can be removed if no position feedback is needed
                    str += "Accept: */*\r\nConnection: close\r\n";
                    str += "\r\n";

                    // Convert to byte array and send.
                    Byte[] byteDateLine = Encoding.ASCII.GetBytes(str.ToCharArray());
                    clientSocket.Send(byteDateLine, byteDateLine.Length, 0);

                    //enable to periodically send GGA sentence to server.
                    if (sendGGAInterval > 0) tmr.Enabled = true;
                }
                //say its connected
                isNTRIP_Connected = true;
                isNTRIP_Starting = false;
                isNTRIP_Connecting = false;

                btnStartStopNtrip.Text = gStr.gsStop;

            }
            catch (Exception)
            {
                //MessageBox.Show(this, ex.Message, "Send Message Failed!");
            }

        }

        public void OnAddMessage(byte[] data)
        {
            //update gui with stats
            tripBytes += (uint)data.Length;

            //reset watchdog since we have updated data
            NTRIP_Watchdog = 0;

            //serial send out GPS port
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

            //send out UDP Port
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
            //timer may have brought us here so return if not connected
            if (!isNTRIP_Connected)
                return;
            // Check we are connected
            if (clientSocket == null || !clientSocket.Connected)
            {
                TimedMessageBox(1000, gStr.gsNTRIPNotConnectedToSendGGA, gStr.gsRestartingAndReconnectingToCaster);
                ReconnectRequest();

                return;
            }

            // Read the message from the text box and send it
            try
            {
                isNTRIP_Sending = true;
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

                TimedMessageBox(2000, gStr.gsNTRIPOff, gStr.gsClickStartToResume);
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

                TimedMessageBox(2000, gStr.gsNTRIPRestarting, gStr.gsResumingWithNewSettings);
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
            if (latitude >= 0) NS = 'N';
            else NS = 'S';
            if (longitude >= 0) EW = 'E';
            else EW = 'W';

            sbGGA.Clear();
            sbGGA.Append("$GPGGA,");
            sbGGA.Append(DateTime.Now.ToString("HHmmss.00,", CultureInfo.InvariantCulture));
            sbGGA.Append(Math.Abs(latNMEA).ToString("0000.000", CultureInfo.InvariantCulture)).Append(',').Append(NS).Append(',');
            sbGGA.Append(Math.Abs(longNMEA).ToString("00000.000", CultureInfo.InvariantCulture)).Append(',').Append(EW);
            sbGGA.Append(",1,10,1,43.4,M,46.4,M,5,0*");

            sbGGA.Append(CalculateChecksum(sbGGA.ToString()));
            sbGGA.Append("\r\n");
            /*
        $GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,5,0*47
           0     1      2      3    4      5 6  7  8   9    10 11  12 13  14
                Time      Lat       Lon     FixSatsOP Alt */
        }
    }
}