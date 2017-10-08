using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;
using System.Collections;

using ChatApplication;

namespace ChatServer
{
    public partial class Server : Form
    {
        #region Private Members

        // Structure to store the client information
        private struct Client
        {
            public EndPoint endPoint;
            public string name;
        }

        // Listing of clients
        private ArrayList clientList;

        // Server socket
        private Socket serverSocket;

        // Data stream
        private byte[] dataStream = new byte[1024];

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
                // Initialise the ArrayList of connected clients
                this.clientList = new ArrayList();

                // Initialise the delegate which updates the status
                this.updateStatusDelegate = new UpdateStatusDelegate(this.UpdateStatus);

                // Initialise the socket
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Initialise the IPEndPoint for the server and listen on port 30000
                IPEndPoint server = new IPEndPoint(IPAddress.Any, 30000);

                // Associate the socket with this IP address and port
                serverSocket.Bind(server);

                // Initialise the IPEndPoint for the clients
                IPEndPoint clients = new IPEndPoint(IPAddress.Any, 0);

                // Initialise the EndPoint for the clients
                EndPoint epSender = (EndPoint)clients;

                // Start listening for incoming data
                serverSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref epSender, new AsyncCallback(ReceiveData), epSender);

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
                byte[] data;

                // Initialise a packet object to store the received data
                Packet receivedData = new Packet(this.dataStream);

                // Initialise a packet object to store the data to be sent
                Packet sendData = new Packet();

                // Initialise the IPEndPoint for the clients
                IPEndPoint clients = new IPEndPoint(IPAddress.Any, 0);

                // Initialise the EndPoint for the clients
                EndPoint epSender = (EndPoint)clients;

                // Receive all data
                serverSocket.EndReceiveFrom(asyncResult, ref epSender);

                // Start populating the packet to be sent
                sendData.ChatDataIdentifier = receivedData.ChatDataIdentifier;
                sendData.ChatName = receivedData.ChatName;

                switch (receivedData.ChatDataIdentifier)
                {
                    case DataIdentifier.Message:
                        sendData.ChatMessage = string.Format("{0}: {1}", receivedData.ChatName, receivedData.ChatMessage);
                        break;

                    case DataIdentifier.LogIn:
                        // Populate client object
                        Client client = new Client();
                        client.endPoint = epSender;
                        client.name = receivedData.ChatName;

                        // Add client to list
                        this.clientList.Add(client);

                        sendData.ChatMessage = string.Format("-- {0} is online --", receivedData.ChatName);
                        break;

                    case DataIdentifier.LogOut:
                        // Remove current client from list
                        foreach (Client c in this.clientList)
                        {
                            if (c.endPoint.Equals(epSender))
                            {
                                this.clientList.Remove(c);
                                break;
                            }
                        }

                        sendData.ChatMessage = string.Format("-- {0} has gone offline --", receivedData.ChatName);
                        break;
                }

                // Get packet as byte array
                data = sendData.GetDataStream();

                foreach (Client client in this.clientList)
                {
                    if (client.endPoint != epSender || sendData.ChatDataIdentifier != DataIdentifier.LogIn)
                    {
                        // Broadcast to all logged on users
                        serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, client.endPoint, new AsyncCallback(this.SendData), client.endPoint);
                    }
                }

                // Listen for more connections again...
                serverSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref epSender, new AsyncCallback(this.ReceiveData), epSender);

                // Update status through a delegate
                this.Invoke(this.updateStatusDelegate, new object[] { sendData.ChatMessage });
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
            rtxtStatus.Text += status + Environment.NewLine;
        }

        #endregion
    }
}