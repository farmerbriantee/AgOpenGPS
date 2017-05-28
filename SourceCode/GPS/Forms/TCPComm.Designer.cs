//Please, if you use this, share the improvements

using System.IO.Ports;
using System;
using System.Collections;
using System.Windows.Forms;
using SharpGL;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        // Attributes
        private ArrayList clientsList = new ArrayList();

        public bool isTCPServerOn = false;

        Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);



        // Callback used when a client requests a connection. 
        // Accept the connection, adding it to our list and setup to accept more connections.
        public void OnConnectRequest(IAsyncResult ar)
        {
            try
            {
                Socket listener = (Socket)ar.AsyncState;
                NewConnection(listener.EndAccept(ar));
                listener.BeginAccept(new AsyncCallback(OnConnectRequest), listener);
            }
            catch { }
        }

        // Add the given connection to our list of clients
        // Send a welcome to the new client, Setup a callback to receive data
        public void NewConnection(Socket sockClient)
        {
            CSocketClient client = new CSocketClient(sockClient);
            clientsList.Add(client);

            // Get current date and time.
            DateTime now = DateTime.Now;
            String strDateLine = "Welcome " + now.ToString("G") + "\n\r";

            //AppendToJoinLabel(client.Sock.RemoteEndPoint + " Welcome");

            // Convert to byte array and send.
            Byte[] byteDateLine = System.Text.Encoding.ASCII.GetBytes(strDateLine.ToCharArray());
            client.Sock.Send(byteDateLine, byteDateLine.Length, 0);

            client.SetupReceiveCallback(this);
        }

        // Get the new data and send it out to all other connections. 
        // Note: If no data was received the connection has probably died.
        public void OnReceivedData(IAsyncResult ar)
        {
            CSocketClient client = (CSocketClient)ar.AsyncState;
            byte[] clientData = client.GetReceivedData(ar);



            // If no data was received then the connection is probably dead
            if (clientData.Length < 1)
            {
                CatchErrorMessageBox(client.Sock.RemoteEndPoint.ToString() + "Connection Lost");
                client.Sock.Close();
                clientsList.Remove(client);
                return;
            }

            //valid data
            var str = Encoding.Default.GetString(clientData);
            AppendToTextBox(str);


            // Send the received data to all clients (including sender for echo)
            foreach (CSocketClient clientSend in clientsList)
            {
                try
                {
                    clientSend.Sock.Send(clientData);
                }
                catch
                {
                    // If the send fails the close the connection
                    CatchErrorMessageBox(client.Sock.RemoteEndPoint.ToString() + "failed to send");
                    clientSend.Sock.Close();
                    clientsList.Remove(client);
                    return;
                }
            }
            client.SetupReceiveCallback(this);
        }

        /// Provides a thread safe way to add data to recvSentence (main NMEA rec'd sentence)
        private void AppendToTextBox(string text)
        {
            Invoke((Action)delegate
            {
                //recvSentence.Append(text);
                pn.rawBuffer += text;
                //textBox1.Text = text;
            });
        }

        /// Provides a thread safe way to add label changes
        private void AppendToJoinLabel(string text)
        {
            Invoke((Action)delegate
            {
                //lblJoined.Text = text;
            });
        }


        //threadsafe catch message displayed
        public void CatchErrorMessageBox(string text)
        {
            Invoke((Action)delegate
            {
                WriteErrorLog("TCP Error" + text);

                MessageBox.Show(text, "Server Error: ");
            });
        }

        //form is closing so shut it down
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clean up
            //listener.Shutdown(SocketShutdown.Both);
            listener.Close();
            //GC.Collect();
            //GC.WaitForPendingFinalizers();

        }
    }

    // Class holding information and buffers for the Client socket connection
    internal class CSocketClient
    {
        private Socket sock;                      // Connection to the client
        private byte[] m_byBuff = new byte[256];     // Receive data buffer

        public CSocketClient(Socket sock)
        {
            this.sock = sock;
        }

        // Readonly access
        public Socket Sock { get { return sock; } }

        /// Setup the callback for received data and loss of connection
        public void SetupReceiveCallback(FormGPS app)
        {
            try
            {
                AsyncCallback receiveData = new AsyncCallback(app.OnReceivedData);
                sock.BeginReceive(m_byBuff, 0, m_byBuff.Length, SocketFlags.None, receiveData, this);
            }
            catch (Exception ex)
            {
                app.CatchErrorMessageBox(ex.Message);
            }
        }

        // Data has been received so we shall put it in an array and
        public byte[] GetReceivedData(IAsyncResult ar)
        {
            int nBytesRec = 0;
            try
            {
                nBytesRec = sock.EndReceive(ar);
            }
            catch { }
            byte[] byReturn = new byte[nBytesRec];
            Array.Copy(m_byBuff, byReturn, nBytesRec);

            return byReturn;
        }

    }//end class
}//end namespace


