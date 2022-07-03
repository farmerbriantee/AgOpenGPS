using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace AgIO
{
    public class CTraffic
    {
        public int cntrPGNFromAOG = 0;
        public int cntrPGNToAOG = 0;
     
        public int cntrGPSIn = 0;
        public int cntrGPSInBytes = 0;
        public int cntrGPSOut = 0;

        public int cntrIMUOut = 0;

        public int cntrSteerIn = 0;
        public int cntrSteerOut = 0;

        public int cntrMachineIn = 0;
        public int cntrMachineOut = 0;

        public uint helloFromMachine = 99, helloFromAutoSteer = 99, helloFromIMU = 99;
    }

    public partial class FormLoop
    {
        // loopback Socket
        private Socket loopBackSocket;
        private EndPoint endPointLoopBack = new IPEndPoint(IPAddress.Loopback, 0);

        // UDP Socket
        private Socket UDPSocket;
        private EndPoint endPointUDP = new IPEndPoint(IPAddress.Any, 0);
        
        public bool isUDPNetworkConnected;

        //2 endpoints for local and 2 udp
        private IPEndPoint epAgOpen = new IPEndPoint(IPAddress.Parse("127.255.255.255"), 15555);
        private IPEndPoint epAgVR = new IPEndPoint(IPAddress.Parse("127.255.255.255"), 16666);
        public IPEndPoint epModule = new IPEndPoint(IPAddress.Parse(
                Properties.Settings.Default.etIP_SubnetOne.ToString() + "." +
                Properties.Settings.Default.etIP_SubnetTwo.ToString() + "." +
                Properties.Settings.Default.etIP_SubnetThree.ToString() + ".255"), 8888);
        private IPEndPoint epNtrip;

        public IPEndPoint epModuleSet = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 8888);

        //class for counting bytes
        public CTraffic traffic = new CTraffic();

        //scan results placed here
        public string scanReturn = "Scanning...";
        
        // Data stream
        private byte[] buffer = new byte[1024];

        //used to send communication check pgn= C8 or 200
        private byte[] helloFromAgIO = { 0x80, 0x81, 0x7F, 200, 3, 56, 0, 0, 0x47 };

        public IPAddress ipCurrent;
        //initialize loopback and udp network
        public void LoadUDPNetwork()
        {
            helloFromAgIO[5] = 56;
            lblIP.Text = "";

            try //udp network
            {
                foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (IPA.AddressFamily == AddressFamily.InterNetwork)
                    {
                        string  data = IPA.ToString();
                        lblIP.Text += IPA.ToString() + "\r\n";
                    }
                }

                // Initialise the socket
                UDPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                UDPSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                UDPSocket.Bind(new IPEndPoint(IPAddress.Any, 9999));
                UDPSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endPointUDP,
                    new AsyncCallback(ReceiveDataUDPAsync), null);

                isUDPNetworkConnected = true;
                btnUDP.BackColor = Color.LimeGreen;

                //if (!isFound)
                //{
                //    MessageBox.Show("Network Address of Modules -> " + Properties.Settings.Default.setIP_localAOG+"[2 - 254] May not exist. \r\n"
                //    + "Are you sure ethernet is connected?\r\n" + "Go to UDP Settings to fix.\r\n\r\n", "Network Connection Error",
                //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    //btnUDP.BackColor = Color.Red;
                //    lblIP.Text = "Not Connected";
                //}
            }
            catch (Exception e)
            {
                //WriteErrorLog("UDP Server" + e);
                MessageBox.Show(e.Message, "Serious Network Connection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnUDP.BackColor = Color.Red;
                lblIP.Text = "Error";
            }
        }

        private void LoadLoopback()
        { 
            try //loopback
            {
                loopBackSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                loopBackSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                loopBackSocket.Bind(new IPEndPoint(IPAddress.Loopback, 17777));
                loopBackSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endPointLoopBack, 
                    new AsyncCallback(ReceiveDataLoopAsync), null);
            }
            catch (Exception ex)
            {
                //lblStatus.Text = "Error";
                MessageBox.Show("Load Error: " + ex.Message, "Loopback Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Send LoopBack

        private void SendToLoopBackMessageAOG(byte[] byteData)
        {
            traffic.cntrPGNToAOG += byteData.Length;
            SendDataToLoopBack(byteData, epAgOpen);
        }

        private void SendToLoopBackMessageVR(byte[] byteData)
        {
            SendDataToLoopBack(byteData, epAgVR);
        }

        private void SendDataToLoopBack(byte[] byteData, IPEndPoint endPoint)
        {
            try
            {
                if (byteData.Length != 0)
                {
                    // Send packet to AgVR
                    loopBackSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, endPoint,
                        new AsyncCallback(SendDataLoopAsync), null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("SendData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Receive LoopBack

        private void ReceiveFromLoopBack(byte[] data)
        {
            traffic.cntrPGNFromAOG += data.Length;

            //Send out to udp network
            SendUDPMessage(data, epModule);

            //send out to VR Loopback
            if (isPluginUsed) SendToLoopBackMessageVR(data);

            if (data[0] == 0x80 && data[1] == 0x81)
            {
                switch (data[3])
                {
                    case 0xFE: //254 AutoSteer Data
                        {
                            //serList.AddRange(data);
                            SendSteerModulePort(data, data.Length);
                            SendMachineModulePort(data, data.Length);
                            break;
                        }
                    case 0xFC: //252 steer settings
                        {
                            SendSteerModulePort(data, data.Length);
                            break;
                        }
                    case 0xFB: //251 steer config
                        {
                            SendSteerModulePort(data, data.Length);
                            break;
                        }
                    case 0xEF: //239 machine pgn
                        {
                            SendMachineModulePort(data, data.Length);
                            SendSteerModulePort(data, data.Length);
                            break;
                        }

                    case 0xEE: //238 machine config
                        {
                            SendMachineModulePort(data, data.Length);
                            SendSteerModulePort(data, data.Length);
                            break;
                        }

                    case 0xEC: //236 machine config
                        {
                            SendMachineModulePort(data, data.Length);
                            SendSteerModulePort(data, data.Length);
                            break;
                        }
                }
            }
        }

        private void ReceiveDataLoopAsync(IAsyncResult asyncResult)
        {
            try
            {
                // Receive all data
                int msgLen = loopBackSocket.EndReceiveFrom(asyncResult, ref endPointLoopBack);

                byte[] localMsg = new byte[msgLen];
                Array.Copy(buffer, localMsg, msgLen);

                // Listen for more connections again...
                loopBackSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endPointLoopBack, 
                    new AsyncCallback(ReceiveDataLoopAsync), null);

                BeginInvoke((MethodInvoker)(() => ReceiveFromLoopBack(localMsg)));
            }
            catch (Exception)
            {
                //MessageBox.Show("ReceiveData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK,
                //MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Send UDP

        public void SendUDPMessage(byte[] byteData, IPEndPoint endPoint)
        {
            if (isUDPNetworkConnected)
            {
                try
                {
                    // Send packet to the zero
                    if (byteData.Length != 0)
                    {
                        UDPSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None,
                           endPoint, new AsyncCallback(SendDataUDPAsync), null);
                        
                        if (byteData[0] == 0x80 && byteData[1] == 0x81)
                        {
                            if (byteData[3] == 254)
                                traffic.cntrSteerIn += byteData.Length;

                            if (byteData[3] == 239)
                                traffic.cntrMachineIn += byteData.Length;
                        }
                    }
                }
                catch (Exception)
                {
                    //WriteErrorLog("Sending UDP Message" + e.ToString());
                    //MessageBox.Show("Send Error: " + e.Message, "UDP Client", MessageBoxButtons.OK,
                    //MessageBoxIcon.Error);
                }
            }
        }

        private void SendDataUDPAsync(IAsyncResult asyncResult)
        {
            try
            {
                UDPSocket.EndSend(asyncResult);
            }
            catch (Exception)
            {
                //WriteErrorLog(" UDP Send Data" + e.ToString());
                //MessageBox.Show("SendData Error: " + e.Message, "UDP Server", MessageBoxButtons.OK,
                //MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Receive UDP

        private void ReceiveDataUDPAsync(IAsyncResult asyncResult)
        {
            try
            {
                // Receive all data
                int msgLen = UDPSocket.EndReceiveFrom(asyncResult, ref endPointUDP);

                byte[] localMsg = new byte[msgLen];
                Array.Copy(buffer, localMsg, msgLen);

                // Listen for more connections again...
                UDPSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endPointUDP, 
                    new AsyncCallback(ReceiveDataUDPAsync), null);

                BeginInvoke((MethodInvoker)(() => ReceiveFromUDP(localMsg)));

            }
            catch (Exception)
            {
                //WriteErrorLog("UDP Recv data " + e.ToString());
                //MessageBox.Show("ReceiveData Error: " + e.Message, "UDP Server", MessageBoxButtons.OK,
                //MessageBoxIcon.Error);
            }
        }

        private void ReceiveFromUDP(byte[] data)
        {
            try
            {
                if (data[0] == 0x80 && data[1] == 0x81)
                {
                    //module return via udp sent to AOG
                    SendToLoopBackMessageAOG(data);

                    //module data also sent to VR
                    if (isPluginUsed) SendToLoopBackMessageVR(data);

                    if (data[3] == 253)
                        traffic.cntrSteerOut += data.Length;

                    else if (data[3] == 237)
                        traffic.cntrMachineOut += data.Length;

                    else if (data[3] == 211)
                        traffic.cntrIMUOut += data.Length;

                    else if (data[3] == 126)
                    {
                        traffic.helloFromAutoSteer = 0;
                        if (isViewAdvanced)
                        {
                            double actualSteerAngle = (Int16)((data[6] << 8) + data[5]);
                            lblSteerAngle.Text = (actualSteerAngle * 0.01).ToString("N1");
                            lblWASCounts.Text = ((Int16)((data[8] << 8) + data[7])).ToString();

                            lblSwitchStatus.Text = ((data[9] & 2) == 2).ToString();
                            lblWorkSwitchStatus.Text = ((data[9] & 1) == 1).ToString();
                        }
                    }

                    else if (data[3] == 123)
                    {
                        traffic.helloFromMachine = 0;

                        if (isViewAdvanced)
                        {
                            lbl1To8.Text = Convert.ToString(data[5], 2).PadLeft(8, '0');
                            lbl9To16.Text = Convert.ToString(data[6], 2).PadLeft(8, '0');
                        }
                    }

                    else if (data[3] == 121)
                        traffic.helloFromIMU = 0;

                    //scan Reply
                    else if (data[3] == 203) //
                    {
                        if (data[2] == 123)
                        {
                            scanReturn += "Machine Module \r\n";
                            scanReturn += data[5].ToString() + "." + data[6].ToString() + "."
                                + data[7].ToString() + "." + data[8].ToString() + "\r\n\r\n";
                        }
                        else if (data[2] == 120)
                        {
                            scanReturn += "Panda Module \r\n";
                            scanReturn += data[5].ToString() + "." + data[6].ToString() + "."
                                + data[7].ToString() + "." + data[8].ToString() + "\r\n\r\n";
                        }

                        else if (data[2] == 126)
                        {
                            scanReturn += "Steer Module \r\n";
                            scanReturn += data[5].ToString() + "." + data[6].ToString() + "."
                                + data[7].ToString() + "." + data[8].ToString() + "\r\n\r\n";
                        }
                        else if (data[2] == 121)
                        {
                            scanReturn += "IMU Module \r\n";
                            scanReturn += data[5].ToString() + "." + data[6].ToString() + "."
                                + data[7].ToString() + "." + data[8].ToString() + "\r\n\r\n";
                        }
                    }

                } // end of pgns

                else if (data[0] == 36 && (data[1] == 71 || data[1] == 80 || data[1] == 75))
                {
                    traffic.cntrGPSOut += data.Length;
                    rawBuffer += Encoding.ASCII.GetString(data);
                    ParseNMEA(ref rawBuffer);
                }
            }
            catch
            {

            }
        }

        #endregion
    }
}
