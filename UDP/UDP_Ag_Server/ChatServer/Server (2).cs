using System;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Text;

namespace ChatServer
{
    public partial class Server : Form
    {
        #region Private Members

        //// Structure to store the client information
        //private struct Client
        //{
        //    public EndPoint endPoint;
        //    public string name;
        //}

        // Listing of clients
        //private ArrayList clientList;

        // Server socket
        private Socket serverSocket;

        IPEndPoint epZero;

        // Data stream
        private byte[] buffer = new byte[1024];

        // Status delegate
        private delegate void UpdateStatusDelegate(string status);
        private UpdateStatusDelegate updateStatusDelegate = null;

        #endregion

        #region Constructor

        public Server()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Server_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialise the delegate which updates the status
                updateStatusDelegate = new UpdateStatusDelegate(UpdateStatus);

                // Initialise the socket
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Initialise the IPEndPoint for the server and listen on port 9999
                IPEndPoint server = new IPEndPoint(IPAddress.Any,9999);

                //IP address and port of MKR1000
                IPAddress zeroIP = IPAddress.Parse("192.168.1.5");
                epZero = new IPEndPoint(zeroIP, 3333);

                // Associate the socket with this IP address and port
                serverSocket.Bind(server);

                // Initialise the IPEndPoint for the client
                EndPoint client = new IPEndPoint(IPAddress.Any, 0);

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
                    serverSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epZero, new AsyncCallback(SendData), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Listen for more connections again...
                serverSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epSender, new AsyncCallback(ReceiveData), epSender);

                string text = Encoding.ASCII.GetString(localMsg);

                // Update status through a delegate
                //Invoke(updateStatusDelegate, new object[] { text + " IP: " + epSender.ToString() + "\r\n" });
                Invoke(updateStatusDelegate, new object[] { text });
            }
            catch (Exception ex)
            {
                MessageBox.Show("ReceiveData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Other Methods

        private void UpdateStatus(string status)
        {
            //rtxtStatus.AppendText(status);
            rtxtStatus.Text = (status);
        }

        #endregion
        int book = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // Get packet as byte array
                byte[] byteData = Encoding.ASCII.GetBytes(book.ToString());
                book++;

                if (byteData.Length != 0)

                    // Send packet to the server
                    serverSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epZero, new AsyncCallback(SendData), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send Error: " + ex.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}