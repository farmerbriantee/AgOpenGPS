using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Diagnostics;

namespace RateController
{
    public class UDPComm
    {
        public bool isUDPSendConnected;
        private readonly FormStart mf;
        private byte[] buffer = new byte[1024];

        // local ports must be unique for each app on same pc and each class instance
        private int cReceivePort;
        private int cSendFromPort;
        private int cSendToPort;

        private bool cUpdateDestinationIP;
        private IPAddress epIP;
        private HandleDataDelegateObj HandleDataDelegate = null;

        private int PGN;
        private Socket recvSocket;
        private Socket sendSocket;

        public UDPComm(FormStart CallingForm, int ReceivePort, int SendToPort, int SendFromPort
            , string DestinationIP = "", bool UpdateDestinationIP = false)
        {
            mf = CallingForm;
            cReceivePort = ReceivePort;
            cSendToPort = SendToPort;
            cSendFromPort = SendFromPort;
            cUpdateDestinationIP = UpdateDestinationIP;

            if (DestinationIP == "")
            {
                SetEpIP(LocalIP());
            }
            else
            {
                epIP = IPAddress.Parse(DestinationIP);
            }

            NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(AddressChanged);
        }

        // Status delegate
        private delegate void HandleDataDelegateObj(int port, byte[] msg);

        public string BroadCastIP
        {
            get { return epIP.ToString(); }
            set
            {
                SetEpIP(value);
            }
        }

        public IPAddress GetBroadCastIP { get { return epIP; } }

        public string LocalIP()
        {
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    return endPoint.Address.ToString();
                }
            }
            catch (Exception)
            {
                return "127.0.0.1";
            }
        }

        //sends byte array
        public void SendUDPMessage(byte[] byteData)
        {
            if (isUDPSendConnected)
            {
                try
                {
                    IPEndPoint EndPt = new IPEndPoint(epIP, cSendToPort);

                    // Send packet to the zero
                    if (byteData.Length != 0)
                        sendSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, EndPt, new AsyncCallback(SendData), null);
                }
                catch (Exception)
                {
                }
            }
        }

        public string StartUDPServer()
        {
            try
            {
                // initialize the delegate which updates the message received
                HandleDataDelegate = HandleData;

                // initialize the receive socket
                recvSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Initialise the IPEndPoint for the server and port
                IPEndPoint recv = new IPEndPoint(IPAddress.Any, cReceivePort);

                // Associate the socket with this IP address and port
                recvSocket.Bind(recv);

                // initialize the send socket
                sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Initialise the IPEndPoint for the server to send on port
                IPEndPoint server = new IPEndPoint(IPAddress.Any, cSendFromPort);
                sendSocket.Bind(server);

                // Initialise the IPEndPoint for the client - async listner client only!
                EndPoint client = new IPEndPoint(IPAddress.Any, 0);

                // Start listening for incoming data
                recvSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref client, new AsyncCallback(ReceiveData), recvSocket);
                isUDPSendConnected = true;
                return LocalIP();
            }
            catch (Exception e)
            {
                mf.Tls.WriteErrorLog("UDP Server" + e);
                mf.Tls.TimedMessageBox("UDP start error: ", e.Message);
                return "";
            }
        }

        private void AddressChanged(object sender, EventArgs e)
        {
            if (cUpdateDestinationIP) SetEpIP(LocalIP());
        }

        private void HandleData(int Port, byte[] Data)
        {
            if (Data.Length > 1)
            {
                PGN = Data[0] << 8 | Data[1];
                if (PGN == 32897)
                {
                    // AGIO
                    // AutoSteer AGIO PGN
                    switch (Data[3])
                    {
                        case 0xFE:
                            mf.AutoSteerPGN.ParseByteData(Data);
                            break;
                    }
                }
                else
                {
                    switch (PGN)
                    {
                        case 32618:
                            mf.SwitchBox.ParseByteData(Data);
                            break;

                        case 32613:
                            foreach (clsProduct Prod in mf.Products.Items)
                            {
                                Prod.UDPcommFromArduino(Data);
                            }
                            break;
                    }
                }
            }
        }

        private void ReceiveData(IAsyncResult asyncResult)
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
                recvSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epSender, new AsyncCallback(ReceiveData), epSender);

                int port = ((IPEndPoint)epSender).Port;
                // Update status through a delegate
                mf.Invoke(HandleDataDelegate, new object[] { port, localMsg });
            }
            catch (Exception e)
            {
                mf.Tls.WriteErrorLog("UDP Recv data " + e.ToString());
                mf.Tls.TimedMessageBox("ReceiveData Error", e.Message);
            }
        }

        private void SendData(IAsyncResult asyncResult)
        {
            try
            {
                sendSocket.EndSend(asyncResult);
            }
            catch (Exception ex)
            {
                mf.Tls.WriteErrorLog(" UDP Send Data" + ex.ToString());
            }
        }

        private void SetEpIP(string IP)
        {
            string Result = "";
            string[] data = IP.Split('.');
            if (data.Length == 4)
            {
                Result = data[0] + "." + data[1] + "." + data[2] + ".255";
            }

            if (IPAddress.TryParse(Result, out IPAddress Tmp))
            {
                epIP = Tmp;
            }
            else
            {
                epIP = IPAddress.Parse("192.168.1.255");
            }
        }
    }
}