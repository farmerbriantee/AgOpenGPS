using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace AgDiag
{
    public class CTraffic
    {
        public int cntrPGNFromAOG = 0;
        public int cntrPGNToAOG = 0;
     
        public int cntrUDPOut = 0;
        public int cntrUDPIn = 0;

        public bool isTrafficOn = true;

        public int enableCounter = 0;
    }
    public partial class FormLoop
    {
        // Server socket
        private Socket recvFromLoopBackSocket;
        private Socket sendToLoopBackSocket;

        CTraffic traffic = new CTraffic();

        IPEndPoint epAgIO;
        IPEndPoint epModule;


        // Data stream
        private byte[] buffer = new byte[1024];

        // Send and Recv socket for udp network
        private Socket sendSocket;
        private Socket recvSocket;
        private bool isUDPNetworkConnected;

        //list of bytes to send out serial ports
        private List<byte> serList = new List<byte>();

        //IP address and port of Auto Steer server
        IPAddress epIP = IPAddress.Parse("192.168.1.3");

        // Status delegate
        private delegate void UpdateRecvMessageDelegate(int port, byte[] msg);
        private UpdateRecvMessageDelegate updateRecvMessageDelegate = null;

        //initialize loopback and udp network
        private void LoadUDPNetwork()
        {
            try //udp network
            {
                // Initialise the delegate which updates the message received
                updateRecvMessageDelegate = ReceiveFromUDP;

                // Initialise the socket
                sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                sendSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);

                //module endpoint
                epModule = new IPEndPoint(epIP, 28888);

                //Initialize Recv socket
                recvSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                recvSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);

                // Modules send to this IP address and port
                recvSocket.Bind(new IPEndPoint(IPAddress.Any, 29999));

                // Initialise the IPEndPoint for async listener!
                EndPoint client = new IPEndPoint(IPAddress.Any, 0);

                // Start listening for incoming data
                recvSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref client, new AsyncCallback(ReceiveDataUDPAsync), recvSocket);
                isUDPNetworkConnected = true;
            }
            catch (Exception e)
            {
                //WriteErrorLog("UDP Server" + e);
                MessageBox.Show("Load Error: " + e.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadLoopback()
        { 
            try //loopback
            {
                // Initialise the socket
                sendToLoopBackSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                sendToLoopBackSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);

                //IP address and port that AgIO listens on, we send to it
                epAgIO = new IPEndPoint(IPAddress.Parse("127.255.255.255"), 17777);

                // Initialise the socket
                recvFromLoopBackSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // AgDiag listens on this port
                recvFromLoopBackSocket.Bind(new IPEndPoint(IPAddress.Any, 16666));

                // Initialise the IPEndPoint for the client
                EndPoint client = new IPEndPoint(IPAddress.Any, 0);

                // Start listening for incoming data
                recvFromLoopBackSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref client, new AsyncCallback(ReceiveDataLoopAsync), recvFromLoopBackSocket);

            }
            catch (Exception ex)
            {
                //lblStatus.Text = "Error";
                MessageBox.Show("Load Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //loopback functions
        #region Send And Receive

        public byte[] nmeaHeader = new byte[] { 0x80, 0x81, 0x7F, 0xCF };

        private void SendToLoopBackMessage(string message)
        {
            try
            {
                // Get packet as byte array
                byte[] byteData = Encoding.ASCII.GetBytes(message);

                //if (byteData.Length != 0)
                //{
                //    traffic.cntrPGNToAOG += byteData.Length;

                //    // Send packet to the zero
                //    sendToLoopBackSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epAgOpen,
                //            new AsyncCallback(SendDataLoopAsync), null);
                //}


                byte[] nmeaData = glm.Combine(nmeaHeader, byteData);

                if (nmeaData.Length != 0)
                {
                    traffic.cntrPGNToAOG += nmeaData.Length;

                    // Send packet to the zero
                    sendToLoopBackSocket.BeginSendTo(nmeaData, 0, nmeaData.Length, SocketFlags.None, epAgIO,
                            new AsyncCallback(SendDataLoopAsync), null);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Send Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendToLoopBackMessage(byte[] byteData)
        {
            try
            {
                if (byteData.Length != 0)
                {
                    traffic.cntrPGNToAOG += byteData.Length;

                    // Send packet to the zero
                    sendToLoopBackSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epAgIO, 
                        new AsyncCallback(SendDataLoopAsync), null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReceiveFromLoopBack(int port, byte[] data)
        {
            traffic.cntrPGNFromAOG += data.Length;


            if (data[0] == 0x80 && data[1] == 0x81)
            {
                switch (data[3])
                {
                    //the lat lon from AOG
                    case 0xD0:
                        {
                            int encAngle = BitConverter.ToInt32(data, 5);
                            currentLat = (encAngle / (0x7FFFFFFF / 90.0));

                            encAngle = BitConverter.ToInt32(data, 9);
                            currentLon = (encAngle / (0x7FFFFFFF / 180.0));

                            break;
                        }
                    case 253:
                        {
                            for (int i = 5; i < data.Length; i++)
                            {
                                asModule.pgn[i] = data[i];
                            }

                            break;
                        }
                    case 254:
                        {

                            for (int i = 5; i < data.Length; i++)
                            {
                                asData.pgn[i] = data[i];
                            }

                            break;
                        }
                    case 252:
                        {

                            for (int i = 5; i < data.Length; i++)
                            {
                                asSet.pgn[i] = data[i];
                            }

                            break;
                        }
                    case 251:
                        {

                            for (int i = 5; i < data.Length; i++)
                            {
                                asConfig.pgn[i] = data[i];
                            }

                            break;
                        }

                    default:
                        {
                            lblDefaultSends.Text = data.Length.ToString();
                            break;
                        }
                }
            }

            else
            {
                cntr += data.Length;
                lblDefaultSends.Text = cntr.ToString();
            }
        }

        int cntr;
        public void SendDataLoopAsync(IAsyncResult asyncResult)
        {
            try
            {
                sendToLoopBackSocket.EndSend(asyncResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SendData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private EndPoint epSender = new IPEndPoint(IPAddress.Any, 0);
        private void ReceiveDataLoopAsync(IAsyncResult asyncResult)
        {
            try
            {
                // Initialise the IPEndPoint for the clients

                // Receive all data
                int msgLen = recvFromLoopBackSocket.EndReceiveFrom(asyncResult, ref epSender);

                byte[] localMsg = new byte[msgLen];
                Array.Copy(buffer, localMsg, msgLen);

                // Listen for more connections again...
                recvFromLoopBackSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epSender, new AsyncCallback(ReceiveDataLoopAsync), recvFromLoopBackSocket);

                //string text = Encoding.ASCII.GetString(localMsg);

                // Update status through a delegate
                int port = ((IPEndPoint)epSender).Port;
                BeginInvoke((MethodInvoker)(() => ReceiveFromLoopBack(port, localMsg)));
            }
            catch (Exception)
            {
                //MessageBox.Show("ReceiveData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        //udp network functions
        public void SendUDPMessage(string message)
        {
            if (isUDPNetworkConnected)
            {
                try
                {
                    // Get packet as byte array to send
                    byte[] byteData = Encoding.ASCII.GetBytes(message);
                    if (byteData.Length != 0)
                        sendSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None,
                            epModule, new AsyncCallback(SendDataUDPAsync), null);

                    traffic.cntrUDPOut+=byteData.Length;
                }
                catch (Exception)
                {
                    //WriteErrorLog("Sending UDP Message" + e.ToString());
                    //MessageBox.Show("Send Error: " + e.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //sends byte array
        public void SendUDPMessage(byte[] byteData)
        {
            if (isUDPNetworkConnected)
            {
                try
                {
                    // Send packet to the zero
                    if (byteData.Length != 0)
                        sendSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None,
                            epModule, new AsyncCallback(SendDataUDPAsync), null);

                    traffic.cntrUDPOut+=byteData.Length;
                }
                catch (Exception)
                {
                    //WriteErrorLog("Sending UDP Message" + e.ToString());
                    //MessageBox.Show("Send Error: " + e.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ReceiveFromUDP(int port, byte[] data)
        {
            traffic.cntrUDPIn += data.Length;
        }

        private void SendDataUDPAsync(IAsyncResult asyncResult)
        {
            try
            {
                sendSocket.EndSend(asyncResult);
            }
            catch (Exception)
            {
                //WriteErrorLog(" UDP Send Data" + e.ToString());
                //MessageBox.Show("SendData Error: " + e.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReceiveDataUDPAsync(IAsyncResult asyncResult)
        {
            try
            {
                // Initialise the IPEndPoint for the client
                EndPoint epSender = new IPEndPoint(IPAddress.Any, 0);

                // Receive all data
                int msgLen = recvSocket.EndReceiveFrom(asyncResult, ref epSender);

                byte[] localMsg = new byte[msgLen];
                Array.Copy(buffer, localMsg, msgLen);

                // Listen for more connections again...
                recvSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epSender, new AsyncCallback(ReceiveDataUDPAsync), recvSocket);

                //string text =  Encoding.ASCII.GetString(localMsg);

                int port = ((IPEndPoint)epSender).Port;
                BeginInvoke((MethodInvoker)(() => ReceiveFromUDP(port, localMsg)));
            }
            catch (Exception)
            {
                //WriteErrorLog("UDP Recv data " + e.ToString());
                //MessageBox.Show("ReceiveData Error: " + e.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
