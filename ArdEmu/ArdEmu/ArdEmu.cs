using System;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Text;
using System.Drawing;

namespace ArdEmu
{
    public partial class ArdEmu : Form
    {
        #region Private Members

        // Server socket
        private Socket serverSocket;

        IPEndPoint epAgOpen;

        // Data stream
        private byte[] buffer = new byte[1024];

        // Status delegate
        private delegate void UpdateStatusDelegate(int port, byte[] msg);
        private UpdateStatusDelegate updateStatusDelegate = null;

        #endregion

        #region Constructor

        public ArdEmu()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Server_Load(object sender, EventArgs e)
        {
            nud0.Value = Properties.Settings.Default.nud0;
            nud1.Value = Properties.Settings.Default.nud1;
            nud2.Value = Properties.Settings.Default.nud2;
            nud3.Value = Properties.Settings.Default.nud3;
            nud4.Value = Properties.Settings.Default.nud4;
            nud5.Value = Properties.Settings.Default.nud5;
            nud6.Value = Properties.Settings.Default.nud6;
            nud7.Value = Properties.Settings.Default.nud7;
            nud8.Value = Properties.Settings.Default.nud8;
            nud9.Value = Properties.Settings.Default.nud9;

            nudTimer.Value = Properties.Settings.Default.nudTimer;

            timer1.Interval = (int)(1.0 / (double)nudTimer.Value * 1000.0);

            try
            {
                // Initialise the delegate which updates the status
                updateStatusDelegate = new UpdateStatusDelegate(UpdateStatus);

                // Initialise the socket
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                serverSocket.EnableBroadcast = true;

                // Initialise the IPEndPoint and listen on port 8888
                IPEndPoint server = new IPEndPoint(IPAddress.Any, Properties.Settings.Default.setIP_thisPort);

                // Associate the socket with this IP address and port
                serverSocket.Bind(server);

                //IP address and port of AgOpenServer  port 9999 
                IPAddress zeroIP = IPAddress.Parse(Properties.Settings.Default.setIP_autoSteerIP);
                epAgOpen = new IPEndPoint(zeroIP, Properties.Settings.Default.setIP_autoSteerPort);

                // Initialise the IPEndPoint for the client
                EndPoint client = new IPEndPoint(IPAddress.Any, 0);

                // Start listening for incoming data
                serverSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, 
                                                ref client, new AsyncCallback(ReceiveData), serverSocket);
            }
            catch (Exception)
            {
                MessageBox.Show("UDP Network Not Connected - No Ethernet", "Serious Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                serverSocket.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                // Get packet as byte array
                byte[] byteData = Encoding.ASCII.GetBytes(txtMessage.Text.Trim() + ": ");

                if (byteData.Length != 0)

                    // Send packet to the zero
                    serverSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, 
                        epAgOpen, new AsyncCallback(SendData), null);
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region Send And Receive

        public void SendData(IAsyncResult asyncResult)
        {
            try
            {
                serverSocket.EndSend(asyncResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SendData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReceiveData(IAsyncResult asyncResult)
        {
            try
            {
                // Initialise the IPEndPoint for the clients
                EndPoint epSender = new IPEndPoint(IPAddress.Any, 0);
            
                // Receive all data
                int msgLen = serverSocket.EndReceiveFrom(asyncResult, ref epSender);

                byte[] localMsg = new byte[msgLen];
                Array.Copy(buffer, localMsg, msgLen);

                // Update status through a delegate
                int port = ((IPEndPoint)epSender).Port;
                Invoke(updateStatusDelegate, new object[] { port, localMsg });

                // Initialise the IPEndPoint for the clients
                epSender = new IPEndPoint(IPAddress.Any, 0);

                // Listen for more connections again...
                serverSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, 
                    ref epSender, new AsyncCallback(ReceiveData), serverSocket);

            }
            catch (Exception)
            {
               // MessageBox.Show("ReceiveData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Other Methods

        byte[] replyPGNToAOG = new byte[10] { 127, 253, 0, 0, 0, 0, 0, 0, 0, 0 };

        int steerCtr = 0;
        int machineCtr = 0;

        bool freeRun = true;

        private void UpdateStatus(int port, byte[] data)
        {
            if (data.Length != 10) return;

            if (freeRun)
            {

                if (data[0] == 127)
                {
                    switch (data[1])
                    {
                        //autosteer sent as FE - 254 return FD - 253
                        case 254:
                            lblSteer.Text = "Steer: " + (data[0].ToString() + "," + data[1].ToString()
                                + "," + data[2].ToString() + "," + data[3].ToString()
                                + "," + data[4].ToString() + "," + data[5].ToString()
                                + "," + data[6].ToString() + "," + data[7].ToString()
                                + "," + data[8].ToString() + "," + data[9].ToString()
                                + "\r\n");
                            if (steerCtr++ > 9999) steerCtr = 0;
                            lblSteerCtr.Text = steerCtr.ToString();

                            break;

                        // machine sent as FA - 250 return F8 - 248
                        case 250:
                            lblMachine.Text = "Machine: " + (data[0].ToString() + "," + data[1].ToString()
                                + "," + data[2].ToString() + "," + data[3].ToString()
                                + "," + data[4].ToString() + "," + data[5].ToString()
                                + "," + data[6].ToString() + "," + data[7].ToString()
                                + "," + data[8].ToString() + "," + data[9].ToString()
                                + "\r\n");

                            if (machineCtr++ > 9999) machineCtr = 0;
                            lblMachineCtr.Text = machineCtr.ToString();

                            break;

                        default:

                            if (rtxtStatus.TextLength > 500) rtxtStatus.Text = "";
                            rtxtStatus.AppendText(data[0].ToString() + "," + data[1].ToString()
                                + "," + data[2].ToString() + "," + data[3].ToString()
                                + "," + data[4].ToString() + "," + data[5].ToString()
                                + "," + data[6].ToString() + "," + data[7].ToString()
                                + "," + data[8].ToString() + "," + data[9].ToString()
                                + " -> ");
                            break;

                    }
                }
            }
        }

        #endregion

        int book = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // Get packet as byte array

                replyPGNToAOG[0] = (byte)nud0.Value;
                replyPGNToAOG[1] = (byte)nud1.Value;
                replyPGNToAOG[2] = (byte)nud2.Value;
                replyPGNToAOG[3] = (byte)nud3.Value;
                replyPGNToAOG[4] = (byte)nud4.Value;
                replyPGNToAOG[5] = (byte)nud5.Value;
                replyPGNToAOG[6] = (byte)nud6.Value;
                replyPGNToAOG[7] = (byte)nud7.Value;
                replyPGNToAOG[8] = (byte)nud8.Value;
                replyPGNToAOG[9] = (byte)nud9.Value;

                //book+=20;
                //if (book > 2500) book = 0;
                //autoSteerReply[3] = (byte)book;

                // Send packet to the server
                serverSocket.BeginSendTo(replyPGNToAOG, 0, replyPGNToAOG.Length, SocketFlags.None, 
                    epAgOpen, new AsyncCallback(SendData), null);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Send Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                button1.Text = "Send Off";
                button1.BackColor = Color.Red;
            }
            else
            {
                timer1.Enabled = true;
                button1.Text = "Send On";
                button1.BackColor = Color.Green;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)(1.0 / (double)nudTimer.Value * 1000.0);
        }

        private void ArdEmu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.nud0 = nud0.Value;
            Properties.Settings.Default.nud1 = nud1.Value;
            Properties.Settings.Default.nud2 = nud2.Value;
            Properties.Settings.Default.nud3 = nud3.Value;
            Properties.Settings.Default.nud4 = nud4.Value;
            Properties.Settings.Default.nud5 = nud5.Value;
            Properties.Settings.Default.nud6 = nud6.Value;
            Properties.Settings.Default.nud7 = nud7.Value;
            Properties.Settings.Default.nud8 = nud8.Value;
            Properties.Settings.Default.nud9 = nud9.Value;

            Properties.Settings.Default.nudTimer = nudTimer.Value;

            Properties.Settings.Default.Save();
        }

        private void btnUDPSettings_Click(object sender, EventArgs e)
        {
            using (var form = new FormUDP(this))
            {
                var result = form.ShowDialog();
            }
        }
    }
}