using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;


namespace AgIO
{
    public partial class FormLoop
    {
        StateObject client = null;

        // State object for reading client data asynchronously
        public class StateObject
        {
            // Client  socket.
            public Socket workSocket = null;
            // Size of receive buffer.
            public const int BufferSize = 1024;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
        }

        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public void LoadTCPNetwork()
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(new IPEndPoint(IPAddress.Any, 11000));
                listener.Listen(5);
                System.Console.WriteLine("TCP server Start!");


                listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

                isUDPNetworkConnected = true;
                btnUDP.BackColor = Color.LimeGreen;

            }
            catch (Exception e)
            {
                System.Console.WriteLine("Bind Error: " + e.ToString(), "TCP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            System.Console.WriteLine("Client connected!");
            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            endPointUDP = handler.RemoteEndPoint;
            // Create the state object.
            client = new StateObject();
            client.workSocket = handler;
            handler.BeginReceive(client.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), null);
        }

        public void ReadCallback(IAsyncResult ar)
        {
            try
            {
                int bytesRead = client.workSocket.EndReceive(ar);

                if (bytesRead > 0)
                {
                    byte[] localMsg = new byte[bytesRead];
                    Array.Copy(client.buffer, localMsg, bytesRead);
                    BeginInvoke((MethodInvoker)(() => ReceiveFromUDP(localMsg)));
                }
                client.workSocket.BeginReceive(client.buffer, 0, StateObject.BufferSize, 0,
    new AsyncCallback(ReadCallback), null);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Read error: " + e.ToString(), "TCP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void SendTcp(byte[] byteData)
        {
            if (client != null)
            {
                try
                {
                    // Begin sending the data to the remote device.
                    client.workSocket.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), client.workSocket);
                }
                catch (Exception e)
                {
                    client.workSocket.Close();
                    client = null;
                    System.Console.WriteLine(e.ToString());
                }
            }
        }

        public void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);

            }
            catch (Exception e)
            {
                client.workSocket.Disconnect(false);
                client = null;
                //allDone.Reset();
                // Get the socket that handles the client request.
                Socket listener = (Socket)ar.AsyncState;
                listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                System.Console.WriteLine(e.ToString());
            }
        }
    }
}