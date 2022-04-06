using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AgDiag
{
    public class CTraffic
    {
        public int cntrPGNFromAOG = 0;
        public int cntrPGNToAOG = 0;
        public int counter = 0;
    }

    public partial class FormLoop
    {
        // LoopBack Socket
        private Socket loopBackSocket;

        CTraffic traffic = new CTraffic();

        //IP address and port that AgIO listens on, we send to it
        private IPEndPoint epAgIO = new IPEndPoint(IPAddress.Parse("127.255.255.255"), 17777);
        private IPEndPoint epAgOpenGPS = new IPEndPoint(IPAddress.Parse("127.255.255.255"), 15555);

        // Initialise the IPEndPoint for async listener!
        private EndPoint endPointLoopBack = new IPEndPoint(IPAddress.Loopback, 0);

        // Data stream
        private byte[] buffer = new byte[1024];

        private void LoadLoopback()
        { 
            try //loopback
            {
                // Initialise the socket
                loopBackSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                loopBackSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                loopBackSocket.Bind(new IPEndPoint(IPAddress.Loopback, 16666));
                loopBackSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endPointLoopBack, new AsyncCallback(ReceiveDataLoopAsync), null);
            }
            catch (Exception ex)
            {
                //lblStatus.Text = "Error";
                MessageBox.Show("Load Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //loopback functions
        #region Send And Receive
        private void SendToAgIO(byte[] byteData)
        {
            try
            {
                if (byteData.Length != 0)
                {
                    traffic.cntrPGNToAOG += byteData.Length;

                    // Send packet to the zero
                    loopBackSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epAgIO, new AsyncCallback(SendDataLoopAsync), null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendToAgOpenGPS(byte[] byteData)
        {
            try
            {
                if (byteData.Length != 0)
                {
                    traffic.cntrPGNToAOG += byteData.Length;

                    // Send packet to the zero
                    loopBackSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epAgOpenGPS, new AsyncCallback(SendDataLoopAsync), null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReceiveFromLoopBack(byte[] data)
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
                traffic.counter += data.Length;
                lblDefaultSends.Text = traffic.counter.ToString();
            }
        }

        public void SendDataLoopAsync(IAsyncResult asyncResult)
        {
            try
            {
                loopBackSocket.EndSend(asyncResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SendData Error: " + ex.Message, "LoopBack Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReceiveDataLoopAsync(IAsyncResult asyncResult)
        {
            try
            {
                // Initialise the IPEndPoint for the clients

                // Receive all data
                int msgLen = loopBackSocket.EndReceiveFrom(asyncResult, ref endPointLoopBack);

                byte[] localMsg = new byte[msgLen];
                Array.Copy(buffer, localMsg, msgLen);

                // Listen for more connections again...
                loopBackSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endPointLoopBack, new AsyncCallback(ReceiveDataLoopAsync), null);

                BeginInvoke((MethodInvoker)(() => ReceiveFromLoopBack(localMsg)));
            }
            catch (Exception)
            {
                //MessageBox.Show("ReceiveData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
