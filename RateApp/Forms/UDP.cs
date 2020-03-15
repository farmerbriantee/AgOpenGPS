using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RateApp
{
    public partial class FormRate
    {
        // Server socket
        private Socket serverSocket;

        IPEndPoint epAgOpen;

        // Data stream
        private byte[] buffer = new byte[1024];

        // Status delegate
        private delegate void UpdateStatusDelegate(int port, byte[] msg);
        private UpdateStatusDelegate updateStatusDelegate = null;


        private void LoadUDP()
        {
            try
            {
                // Initialise the delegate which updates the status
                updateStatusDelegate = new UpdateStatusDelegate(UpdateStatus);

                // Initialise the socket
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Initialise the IPEndPoint and listen on port 17777
                IPEndPoint server = new IPEndPoint(IPAddress.Loopback, 17777);

                //IP address and port of AgOpenServer
                //IPAddress zeroIP = IPAddress.Parse("127.0.0.1");
                epAgOpen = new IPEndPoint(IPAddress.Loopback, 15555);

                // Associate the socket with this IP address and port
                serverSocket.Bind(server);

                // Initialise the IPEndPoint for the client
                EndPoint client = new IPEndPoint(IPAddress.Loopback, 0);

                // Start listening for incoming data
                serverSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None,
                                                ref client, new AsyncCallback(ReceiveData), serverSocket);

                lblStatus.Text = "Listening";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error";
                MessageBox.Show("Load Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                // Get packet as byte array
                byte[] byteData = Encoding.ASCII.GetBytes("45,46,48");

                if (byteData.Length != 0)

                    // Send packet to the zero
                    serverSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epAgOpen, new AsyncCallback(SendData), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void UpdateStatus(int port, byte[] data)
        {
            if (data.Length != 10) return;

            if (data[0] == 127)
            {
                switch (data[1])
                {
                    //machine send back F8 248
                    case 250:
                        lblSect.Text = data[3].ToString();

                        if ((data[3] & 1) == 1) btnSec1.BackColor = Color.Green;
                        else btnSec1.BackColor = Color.Red;
                        if ((data[3] & 2) == 2) btnSec2.BackColor = Color.Green;
                        else btnSec2.BackColor = Color.Red;
                        if ((data[3] & 4) == 4) btnSec3.BackColor = Color.Green;
                        else btnSec3.BackColor = Color.Red;
                        if ((data[3] & 8) == 8) btnSec4.BackColor = Color.Green;
                        else btnSec4.BackColor = Color.Red;
                        if ((data[3] & 16) == 16) btnSec5.BackColor = Color.Green;
                        else btnSec5.BackColor = Color.Red;

                        break;

                    //autosteer send back  FD - 253
                    case 254:
                        lblSpeed.Text = ((double)(data[3])/4).ToString("N1");
                        break;
                }
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

                // Listen for more connections again...
                serverSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, 
                    ref epSender, new AsyncCallback(ReceiveData), serverSocket);

                //string text = Encoding.ASCII.GetString(localMsg);

                // Update status through a delegate
                int port = ((IPEndPoint)epSender).Port;
                Invoke(updateStatusDelegate, new object[] { port, localMsg });
            }
            catch (Exception)
            {
                //MessageBox.Show("ReceiveData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
