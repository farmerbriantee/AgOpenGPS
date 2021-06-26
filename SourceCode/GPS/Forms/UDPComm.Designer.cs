using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Diagnostics;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        // - App Sockets  -----------------------------------------------------
        private Socket sendToAppSocket;
        private Socket recvFromAppSocket;

        //endpoints of modules
        private EndPoint epAgIO, epSender = new IPEndPoint(IPAddress.Any, 0);

        // Data stream
        private byte[] loopBuffer = new byte[1024];

        // Status delegate
        private double rollK = 0;
        private int udpWatchCounts = 0;
        public int udpWatchLimit = 70;

        private readonly Stopwatch udpWatch = new Stopwatch();

        private void ReceiveFromAgIO(byte[] data)
        {
            if (data[0] == 0x80 && data[1] == 0x81)
            {
                switch (data[3])
                {
                    case 0xD6:
                        {
                            if (udpWatch.ElapsedMilliseconds < udpWatchLimit)
                            {
                                udpWatchCounts++;
                                if (isLogNMEA) pn.logNMEASentence.Append("*** "
                                    + DateTime.UtcNow.ToString("ss.ff -> ", CultureInfo.InvariantCulture)
                                    + udpWatch.ElapsedMilliseconds + "\r\n");
                                return;
                            }
                            udpWatch.Reset();
                            udpWatch.Start();

                            double Lon = BitConverter.ToDouble(data, 5);
                            double Lat = BitConverter.ToDouble(data, 13);

                            if (Lon != double.MaxValue && Lat != double.MaxValue)
                            {
                                if (timerSim.Enabled)
                                    DisableSim();

                                pn.longitude = Lon;
                                pn.latitude = Lat;

                                pn.ConvertWGS84ToLocal(Lat, Lon, out pn.fix.northing, out pn.fix.easting);

                                //From dual antenna heading sentences
                                float temp = BitConverter.ToSingle(data, 21);
                                if (temp != float.MaxValue)
                                {
                                    pn.headingTrueDual = temp;
                                    if (ahrs.isDualAsIMU) ahrs.imuHeading = temp;
                                }

                                //from single antenna sentences (VTG,RMC)
                                temp = BitConverter.ToSingle(data, 25);
                                if (temp != float.MaxValue)
                                    pn.headingTrue = temp;

                                temp = BitConverter.ToSingle(data, 29);
                                if (temp != float.MaxValue)
                                {
                                    pn.speed = temp;
                                    if (temp < 0) pn.speed *= -1;
                                    pn.AverageTheSpeed();
                                }

                                //roll in degrees
                                temp = BitConverter.ToSingle(data, 33);
                                if (temp != float.MaxValue)
                                {
                                    if (ahrs.isRollInvert) temp *= -1;
                                    ahrs.imuRoll = temp - ahrs.rollZero;
                                }
                                if (temp == float.MinValue)
                                    ahrs.imuRoll = 0;                               

                                //altitude in meters
                                temp = BitConverter.ToSingle(data, 37);
                                if (temp != float.MaxValue)
                                    pn.altitude = temp;

                                ushort sats = BitConverter.ToUInt16(data, 41);
                                if (sats != ushort.MaxValue)
                                    pn.satellitesTracked = sats;

                                byte fix = data[43];
                                if (fix != byte.MaxValue)
                                    pn.fixQuality = fix;

                                ushort hdop = BitConverter.ToUInt16(data, 44);
                                if (hdop != ushort.MaxValue)
                                    pn.hdop = hdop * 0.01;

                                ushort age = BitConverter.ToUInt16(data, 46);
                                if (age != ushort.MaxValue)
                                    pn.age = age * 0.01;

                                sentenceCounter = 0;

                                if (isLogNMEA)
                                    pn.logNMEASentence.Append(
                                        DateTime.UtcNow.ToString("mm:ss.ff",CultureInfo.InvariantCulture)+ " " +
                                        Lat.ToString("N7") + " " + Lon.ToString("N7") + " " + 
                                        pn.speed.ToString("N1") + " " +
                                        pn.headingTrueDual.ToString("N1") + "\r\n"
                                        );

                                UpdateFixPosition();
                            }
                        }
                        break;

                    case 0xD3: //external IMU
                        {
                            if (data.Length != 14)
                                break;
                            if (ahrs.imuRoll > 25 || ahrs.imuRoll < -25) ahrs.imuRoll = 0;
                            //Heading
                            ahrs.imuHeading = (Int16)((data[6] << 8) + data[5]);
                            ahrs.imuHeading *= 0.1;
                            
                            //Roll
                            rollK = (Int16)((data[8] << 8) + data[7]);

                            if (ahrs.isRollInvert) rollK *= -0.1;
                            else rollK *= 0.1;
                            rollK -= ahrs.rollZero;                           
                            ahrs.imuRoll = ahrs.imuRoll * ahrs.rollFilter + rollK * (1 - ahrs.rollFilter);

                            //Angular velocity
                            ahrs.angVel = (Int16)((data[10] << 8) + data[9]);
                            ahrs.angVel /= -2;

                            //Log activity
                            //if (isLogNMEA)
                            //    pn.logNMEASentence.Append(
                            //        DateTime.UtcNow.ToString("HH:mm:ss.ff", CultureInfo.InvariantCulture) + " IMU " +
                            //        Math.Round(ahrs.imuRoll, 1).ToString("N1") + " " +
                            //        Math.Round(ahrs.imuHeading, 1).ToString("N1") + 
                            //        "\r\n"
                            //        );
                            break;
                        }
                    case 0xD4: //imu disconnect pgn
                        {
                            if (data[5] == 1)
                            {
                                ahrs.imuHeading = 99999;

                                ahrs.imuRoll = 88888;

                                ahrs.angVel = 0;
                            }
                            break;
                        }
                    case 253: //return from autosteer module
                        {
                            //Steer angle actual
                            if (data.Length != 14)
                                break;
                            mc.actualSteerAngleChart = (Int16)((data[6] << 8) + data[5]);
                            mc.actualSteerAngleDegrees = (double)mc.actualSteerAngleChart * 0.01;

                            //Heading
                            double head253 = (Int16)((data[8] << 8) + data[7]);
                            if (head253 != 9999)
                            {
                                ahrs.imuHeading = head253 * 0.1;
                            }

                            //Roll
                            rollK = (Int16)((data[10] << 8) + data[9]);
                            if (rollK != 8888)
                            {
                                if (ahrs.isRollInvert) rollK *= -0.1;
                                else rollK *= 0.1;
                                rollK -= ahrs.rollZero;
                                ahrs.imuRoll = ahrs.imuRoll * ahrs.rollFilter + rollK * (1 - ahrs.rollFilter);
                            }

                            //switch status
                            mc.steerSwitchValue = data[11];
                            mc.workSwitchValue = mc.steerSwitchValue & 1;
                            mc.steerSwitchValue = mc.steerSwitchValue & 2;

                            //the pink steer dot reset
                            steerModuleConnectedCounter = 0;

                            //Actual PWM
                            mc.pwmDisplay = data[12];

                            if (isLogNMEA)
                                pn.logNMEASentence.Append(
                                    DateTime.UtcNow.ToString("mm:ss.ff", CultureInfo.InvariantCulture) + " AS " +
                                    //Lat.ToString("N7") + " " + Lon.ToString("N7") + " " +
                                    //pn.speed.ToString("N1") + " " + Math.Round(ahrs.imuRoll, 1).ToString("N1") + " " +
                                    mc.actualSteerAngleDegrees.ToString("N1") + "\r\n"
                                    );

                            break;
                        }

                    #region Remote Switches
                    case 234://MTZ8302 Feb 2020
                        {
                            //Steer angle actual
                            if (data.Length != 14)
                                break;

                            Buffer.BlockCopy(data, 5, mc.ss, 1, 8);

                            DoRemoteSwitches();

                            break;
                        }
                     #endregion
                }
            }
        }

        //start the UDP server
        public void StartLoopbackServer()
        {
            try
            {
                // Initialise the socket
                sendToAppSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                //sendToAppSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                sendToAppSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                sendToAppSocket.Bind(new IPEndPoint(IPAddress.Loopback, 15550));

                // AOG sends to AgIO using this endpoint
                epAgIO = new IPEndPoint(IPAddress.Parse("127.255.255.255"), 17777);

                // Initialise the client socket
                recvFromAppSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // IPEndPoint for AOG  to listen on 
                recvFromAppSocket.Bind(new IPEndPoint(IPAddress.Loopback, 15555));

                // Initialise the IPEndPoint for the client
                EndPoint clientEp = new IPEndPoint(IPAddress.Any, 0);

                // Start listening for incoming data
                recvFromAppSocket.BeginReceiveFrom(loopBuffer, 0, loopBuffer.Length, SocketFlags.None, ref clientEp, new AsyncCallback(ReceiveAppData), recvFromAppSocket);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisableSim()
        {
            isFirstFixPositionSet = false;
            isGPSPositionInitialized = false;
            isFirstHeadingSet = false;
            startCounter = 0;
            panelSim.Visible = false;
            timerSim.Enabled = false;
            simulatorOnToolStripMenuItem.Checked = false;
            Properties.Settings.Default.setMenu_isSimulatorOn = simulatorOnToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
            return;
        }


        private void ReceiveAppData(IAsyncResult asyncResult)
        {
            try
            {
                // Initialise the IPEndPoint for the clients

                // Receive all data
                int msgLen = recvFromAppSocket.EndReceiveFrom(asyncResult, ref epSender);

                byte[] localMsg = new byte[msgLen];
                Array.Copy(loopBuffer, localMsg, msgLen);

                // Listen for more connections again...
                recvFromAppSocket.BeginReceiveFrom(loopBuffer, 0, loopBuffer.Length, SocketFlags.None, ref epSender, new AsyncCallback(ReceiveAppData), recvFromAppSocket);

                int Length = Math.Max((localMsg[4]) + 5, 5);
                if (localMsg.Length > Length)
                {
                    byte CK_A = 0;
                    for (int j = 2; j < Length; j++)
                    {
                        CK_A += localMsg[j];
                    }

                    if (localMsg[Length] == (byte)CK_A)
                        BeginInvoke((MethodInvoker)(() => ReceiveFromAgIO(localMsg)));
                }
            }
            catch (Exception)
            {
                // MessageBox.Show("ReceiveData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SendAsyncLoopData(IAsyncResult asyncResult)
        {
            try
            {
                sendToAppSocket.EndSend(asyncResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SendData Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SendPgnToLoop(byte[] byteData)
        {
            if (sendToAppSocket != null)
            {
                try
                {
                    int crc = 0;
                    for (int i = 2; i + 1 < byteData.Length; i++)
                    {
                        crc += byteData[i];
                    }
                    byteData[byteData.Length - 1] = (byte)crc;

                    if (byteData.Length != 0)
                        sendToAppSocket.BeginSendTo(byteData, 0, byteData.Length,
                            SocketFlags.None, epAgIO, new AsyncCallback(SendAsyncLoopData), null);
                }
                catch (Exception)
                {
                    //WriteErrorLog("Sending UDP Message" + e.ToString());
                    //MessageBox.Show("Send Error: " + e.Message, "UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //for moving and sizing borderless window
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                //drop shadow
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }

        #region keystrokes
        //keystrokes for easy and quick startup
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //reset Sim
            if (keyData == Keys.L)
            {
                btnResetSim.PerformClick();
                return true;
            }

            //speed up
            if (keyData == Keys.Up)
            {
                if (sim.stepDistance < 0.04 && sim.stepDistance > -0.04) sim.stepDistance += 0.002;
                else sim.stepDistance += 0.02;
                if (sim.stepDistance > 1.9) sim.stepDistance = 1.9;
                hsbarStepDistance.Value = (int)(sim.stepDistance * 5 * fixUpdateHz);
                return true;
            }

            //slow down
            if (keyData == Keys.Down)
            {
                if (sim.stepDistance < 0.04 && sim.stepDistance > -0.04) sim.stepDistance -= 0.002;
                else sim.stepDistance -= 0.02;
                if (sim.stepDistance < -0.35) sim.stepDistance = -0.35;
                hsbarStepDistance.Value = (int)(sim.stepDistance * 5 * fixUpdateHz);
                return true;
            }

            //Stop
            if (keyData == Keys.OemPeriod)
            {
                sim.stepDistance = 0;
                hsbarStepDistance.Value = 0;
                return true;
            }

            //turn right
            if (keyData == Keys.Right)
            {
                sim.steerAngle += 2;
                if (sim.steerAngle > 40) sim.steerAngle = 40;
                if (sim.steerAngle < -40) sim.steerAngle = -40;
                sim.steerAngleScrollBar = sim.steerAngle;
                btnResetSteerAngle.Text = sim.steerAngle.ToString();
                hsbarSteerAngle.Value = (int)(10 * sim.steerAngle) + 400;
                return true;
            }

            //turn left
            if (keyData == Keys.Left)
            {
                sim.steerAngle -= 2;
                if (sim.steerAngle > 40) sim.steerAngle = 40;
                if (sim.steerAngle < -40) sim.steerAngle = -40;
                sim.steerAngleScrollBar = sim.steerAngle;
                btnResetSteerAngle.Text = sim.steerAngle.ToString();
                hsbarSteerAngle.Value = (int)(10 * sim.steerAngle) + 400;
                return true;
            }

            //zero steering
            if (keyData == Keys.OemQuestion)
            {
                sim.steerAngle = 0.0;
                sim.steerAngleScrollBar = sim.steerAngle;
                btnResetSteerAngle.Text = sim.steerAngle.ToString();
                hsbarSteerAngle.Value = (int)(10 * sim.steerAngle) + 400;
                return true;
            }

            if (keyData == (Keys.F))
            {
                CloseCurrentJob();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.A)) //autosteer button on off
            {
                btnAutoSteer.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            //if (keyData == (Keys.S)) //open the steer chart
            //{
            //    toolstripAutoSteerConfig.PerformClick();
            //    return true;    // indicate that you handled this keystroke
            //}

            //if (keyData == (Keys.S)) //open the steer chart
            //{
            //    btnSnapToPivot.PerformClick();
            //    return true;    // indicate that you handled this keystroke
            //}

            if (keyData == (Keys.C)) //open the steer chart
            {
                steerChartStripMenu.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.V)) //open the vehicle Settings
            {
                //lblHz.Per.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.NumPad1)) //auto section on off
            {
                btnSectionOffAutoOn.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.N)) //auto section on off
            {
                btnSectionOffAutoOn.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.NumPad0)) //auto section on off
            {
                btnManualOffOn.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.M)) //auto section on off
            {
                btnManualOffOn.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.G)) // Flag click
            {
                btnFlag.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.P)) // Snap/Prioritu click
            {
                btnSnapToPivot.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.F11)) // Full Screen click
            {
                btnMaximizeMainForm.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Gesture

        // Private variables used to maintain the state of gestures
        ////private DrawingObject _dwo = new DrawingObject();
        //private Point _ptFirst = new Point();

        //private Point _ptSecond = new Point();
        //private int _iArguments = 0;

        //// One of the fields in GESTUREINFO structure is type of Int64 (8 bytes).
        //// The relevant gesture information is stored in lower 4 bytes. This
        //// bit mask is used to get 4 lower bytes from this argument.
        //private const Int64 ULL_ARGUMENTS_BIT_MASK = 0x00000000FFFFFFFF;

        ////-----------------------------------------------------------------------
        //// Multitouch/Touch glue (from winuser.h file)
        //// Since the managed layer between C# and WinAPI functions does not
        //// exist at the moment for multi-touch related functions this part of
        //// code is required to replicate definitions from winuser.h file.
        ////-----------------------------------------------------------------------
        //// Touch event window message constants [winuser.h]
        //private const int WM_GESTURENOTIFY = 0x011A;

        //private const int WM_GESTURE = 0x0119;

        //private const int GC_ALLGESTURES = 0x00000001;

        //// Gesture IDs
        //private const int GID_BEGIN = 1;

        //private const int GID_END = 2;
        //private const int GID_ZOOM = 3;
        //private const int GID_PAN = 4;
        //private const int GID_ROTATE = 5;
        //private const int GID_TWOFINGERTAP = 6;


        //private const int GID_PRESSANDTAP = 7;

        //// Gesture flags - GESTUREINFO.dwFlags
        //private const int GF_BEGIN = 0x00000001;

        //private const int GF_INERTIA = 0x00000002;
        //private const int GF_END = 0x00000004;

        ////
        //// Gesture configuration structure
        ////   - Used in SetGestureConfig and GetGestureConfig
        ////   - Note that any setting not included in either GESTURECONFIG.dwWant
        ////     or GESTURECONFIG.dwBlock will use the parent window's preferences
        ////     or system defaults.
        ////
        //// Touch API defined structures [winuser.h]
        //[StructLayout(LayoutKind.Sequential)]
        //private struct GESTURECONFIG
        //{
        //    public int dwID;    // gesture ID
        //    public int dwWant;  // settings related to gesture ID that are to be

        //    // turned on
        //    public int dwBlock; // settings related to gesture ID that are to be

        //    // turned off
        //}

        //[StructLayout(LayoutKind.Sequential)]
        //private struct POINTS
        //{
        //    public short x;
        //    public short y;
        //}

        ////
        //// Gesture information structure
        ////   - Pass the HGESTUREINFO received in the WM_GESTURE message lParam
        ////     into the GetGestureInfo function to retrieve this information.
        ////   - If cbExtraArgs is non-zero, pass the HGESTUREINFO received in
        ////     the WM_GESTURE message lParam into the GetGestureExtraArgs
        ////     function to retrieve extended argument information.
        ////
        //[StructLayout(LayoutKind.Sequential)]
        //private struct GESTUREINFO
        //{
        //    public int cbSize;           // size, in bytes, of this structure

        //    // (including variable length Args
        //    // field)
        //    public int dwFlags;          // see GF_* flags

        //    public int dwID;             // gesture ID, see GID_* defines
        //    public IntPtr hwndTarget;    // handle to window targeted by this

        //    // gesture
        //    [MarshalAs(UnmanagedType.Struct)]
        //    internal POINTS ptsLocation; // current location of this gesture

        //    public int dwInstanceID;     // internally used
        //    public int dwSequenceID;     // internally used
        //    public Int64 ullArguments;   // arguments for gestures whose

        //    // arguments fit in 8 BYTES
        //    public int cbExtraArgs;      // size, in bytes, of extra arguments,

        //    // if any, that accompany this gesture
        //}

        //// Currently touch/multitouch access is done through unmanaged code
        //// We must p/invoke into user32 [winuser.h]
        //[DllImport("user32")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //private static extern bool SetGestureConfig(IntPtr hWnd, int dwReserved, int cIDs, ref GESTURECONFIG pGestureConfig, int cbSize);

        //[DllImport("user32")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //private static extern bool GetGestureInfo(IntPtr hGestureInfo, ref GESTUREINFO pGestureInfo);

        //// size of GESTURECONFIG structure
        //private int _gestureConfigSize;

        //// size of GESTUREINFO structure
        //private int _gestureInfoSize;

        //[SecurityPermission(SecurityAction.Demand)]
        //private void SetupStructSizes()
        //{
        //    // Both GetGestureCommandInfo and GetTouchInputInfo need to be
        //    // passed the size of the structure they will be filling
        //    // we get the sizes upfront so they can be used later.
        //    _gestureConfigSize = Marshal.SizeOf(new GESTURECONFIG());
        //    _gestureInfoSize = Marshal.SizeOf(new GESTUREINFO());
        //}

        ////-------------------------------------------------------------
        //// Since there is no managed layer at the moment that supports
        //// event handlers for WM_GESTURENOTIFY and WM_GESTURE
        //// messages we have to override WndProc function
        ////
        //// in
        ////   m - Message object
        ////-------------------------------------------------------------

        //// Drag form without border definitions
        //private const int WM_NCHITTEST = 0x84;
        ////private const int HT_CAPTION = 0x2;

        //[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        //protected override void WndProc(ref Message m)
        //{
        //    bool handled = false;
        //    const int RESIZE_HANDLE_SIZE = 10;

        //    switch (m.Msg)
        //    {
        //        //case WM_GESTURENOTIFY:
        //        //    {
        //        //        // This is the right place to define the list of gestures
        //        //        // that this application will support. By populating
        //        //        // GESTURECONFIG structure and calling SetGestureConfig
        //        //        // function. We can choose gestures that we want to
        //        //        // handle in our application. In this app we decide to
        //        //        // handle all gestures.
        //        //        GESTURECONFIG gc = new GESTURECONFIG
        //        //        {
        //        //            dwID = 0,                // gesture ID
        //        //            dwWant = GC_ALLGESTURES, // settings related to gesture
        //        //                                     // ID that are to be turned on
        //        //            dwBlock = 0 // settings related to gesture ID that are
        //        //        };
        //        //        // to be

        //        //        // We must p/invoke into user32 [winuser.h]
        //        //        bool bResult = SetGestureConfig(
        //        //            Handle, // window for which configuration is specified
        //        //            0,      // reserved, must be 0
        //        //            1,      // count of GESTURECONFIG structures
        //        //            ref gc, // array of GESTURECONFIG structures, dwIDs
        //        //                    // will be processed in the order specified
        //        //                    // and repeated occurances will overwrite
        //        //                    // previous ones
        //        //            _gestureConfigSize // sizeof(GESTURECONFIG)
        //        //        );

        //        //        if (!bResult)
        //        //        {
        //        //            throw new Exception("Error in execution of SetGestureConfig");
        //        //        }
        //        //    }
        //        //    handled = true;
        //        //    break;

        //        //case WM_GESTURE:
        //        //    // The gesture processing code is implemented in
        //        //    // the DecodeGesture method
        //        //    handled = DecodeGesture(ref m);
        //        //    break;

        //        case WM_NCHITTEST:

        //            base.WndProc(ref m);

        //            if ((int)m.Result == 0x01/*HTCLIENT*/)
        //            {
        //                Point screenPoint = new Point(m.LParam.ToInt32());
        //                Point clientPoint = this.PointToClient(screenPoint);
        //                if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
        //                {
        //                    if (clientPoint.X <= RESIZE_HANDLE_SIZE)
        //                        m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
        //                    else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
        //                        m.Result = (IntPtr)12/*HTTOP*/ ;
        //                    else
        //                        m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
        //                }
        //                else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
        //                {
        //                    if (clientPoint.X <= RESIZE_HANDLE_SIZE)
        //                        m.Result = (IntPtr)10/*HTLEFT*/ ;
        //                    else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
        //                        m.Result = (IntPtr)2/*HTCAPTION*/ ;
        //                    else
        //                        m.Result = (IntPtr)11/*HTRIGHT*/ ;
        //                }
        //                else
        //                {
        //                    if (clientPoint.X <= RESIZE_HANDLE_SIZE)
        //                        m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
        //                    else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
        //                        m.Result = (IntPtr)15/*HTBOTTOM*/ ;
        //                    else
        //                        m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
        //                }
        //                return;

        //            }

        //            handled = false;
        //            //base.WndProc(ref m);

        //            // For window move
        //            //m.Result = (IntPtr)(HT_CAPTION);

        //            //return;

        //            break;

        //        default:
        //            handled = false;
        //            break;
        //    }

        //    //// Filter message back up to parents.
        //    //base.WndProc(ref m);

        //    //if (handled)
        //    //{
        //    //    // Acknowledge event if handled.
        //    //    try
        //    //    {
        //    //        m.Result = new System.IntPtr(1);
        //    //    }
        //    //    catch (Exception)
        //    //    {
        //    //    }
        //    //}
        //}

        //// Taken from GCI_ROTATE_ANGLE_FROM_ARGUMENT.
        //// Converts from "binary radians" to traditional radians.
        //static protected double ArgToRadians(Int64 arg)
        //{
        //    return (arg / 65535.0 * 4.0 * 3.14159265) - (2.0 * 3.14159265);
        //}

        //// Handler of gestures
        ////in:
        ////  m - Message object
        //private bool DecodeGesture(ref Message m)
        //{
        //    GESTUREINFO gi;

        //    try
        //    {
        //        gi = new GESTUREINFO();
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //    gi.cbSize = _gestureInfoSize;

        //    // Load the gesture information.
        //    // We must p/invoke into user32 [winuser.h]
        //    if (!GetGestureInfo(m.LParam, ref gi))
        //    {
        //        return false;
        //    }

        //    switch (gi.dwID)
        //    {
        //        case GID_BEGIN:
        //        case GID_END:
        //            break;

        //        case GID_ZOOM:
        //            switch (gi.dwFlags)
        //            {
        //                case GF_BEGIN:
        //                    _iArguments = (int)(gi.ullArguments & ULL_ARGUMENTS_BIT_MASK);
        //                    _ptFirst.X = gi.ptsLocation.x;
        //                    _ptFirst.Y = gi.ptsLocation.y;
        //                    _ptFirst = PointToClient(_ptFirst);
        //                    break;

        //                default:
        //                    // We read here the second point of the gesture. This
        //                    // is middle point between fingers in this new
        //                    // position.
        //                    _ptSecond.X = gi.ptsLocation.x;
        //                    _ptSecond.Y = gi.ptsLocation.y;
        //                    _ptSecond = PointToClient(_ptSecond);
        //                    {
        //                        // The zoom factor is the ratio of the new
        //                        // and the old distance. The new distance
        //                        // between two fingers is stored in
        //                        // gi.ullArguments (lower 4 bytes) and the old
        //                        // distance is stored in _iArguments.
        //                        double k = (double)(_iArguments)
        //                                    / (double)(gi.ullArguments & ULL_ARGUMENTS_BIT_MASK);
        //                        //lblX.Text = k.ToString();
        //                        camera.zoomValue *= k;
        //                        if (camera.zoomValue < 6.0) camera.zoomValue = 6;
        //                        camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
        //                        SetZoom();
        //                    }

        //                    // Now we have to store new information as a starting
        //                    // information for the next step in this gesture.
        //                    _ptFirst = _ptSecond;
        //                    _iArguments = (int)(gi.ullArguments & ULL_ARGUMENTS_BIT_MASK);
        //                    break;
        //            }
        //            break;

        //        //case GID_PAN:
        //        //    switch (gi.dwFlags)
        //        //    {
        //        //        case GF_BEGIN:
        //        //            _ptFirst.X = gi.ptsLocation.x;
        //        //            _ptFirst.Y = gi.ptsLocation.y;
        //        //            _ptFirst = PointToClient(_ptFirst);
        //        //            break;

        //        //        default:
        //        //            // We read the second point of this gesture. It is a
        //        //            // middle point between fingers in this new position
        //        //            _ptSecond.X = gi.ptsLocation.x;
        //        //            _ptSecond.Y = gi.ptsLocation.y;
        //        //            _ptSecond = PointToClient(_ptSecond);

        //        //            // We apply move operation of the object
        //        //            _dwo.Move(_ptSecond.X - _ptFirst.X, _ptSecond.Y - _ptFirst.Y);

        //        //            Invalidate();

        //        //            // We have to copy second point into first one to
        //        //            // prepare for the next step of this gesture.
        //        //            _ptFirst = _ptSecond;
        //        //            break;
        //        //    }
        //        //    break;

        //        case GID_ROTATE:
        //            switch (gi.dwFlags)
        //            {
        //                case GF_BEGIN:
        //                    _iArguments = 32768;
        //                    break;

        //                default:
        //                    // Gesture handler returns cumulative rotation angle. However we
        //                    // have to pass the delta angle to our function responsible
        //                    // to process the rotation gesture.
        //                    double k = ((int)(gi.ullArguments & ULL_ARGUMENTS_BIT_MASK) - _iArguments) * 0.01;
        //                    camera.camPitch -= k;
        //                    if (camera.camPitch < -74) camera.camPitch = -74;
        //                    if (camera.camPitch > 0) camera.camPitch = 0;
        //                    _iArguments = (int)(gi.ullArguments & ULL_ARGUMENTS_BIT_MASK);
        //                    break;
        //            }
        //            break;

        //            //case GID_TWOFINGERTAP:
        //            //    // Toggle drawing of diagonals
        //            //    _dwo.ToggleDrawDiagonals();
        //            //    Invalidate();
        //            //    break;

        //            //case GID_PRESSANDTAP:
        //            //    if (gi.dwFlags == GF_BEGIN)
        //            //    {
        //            //        // Shift drawing color
        //            //        _dwo.ShiftColor();
        //            //        Invalidate();
        //            //    }
        //            //    break;
        //    }

        //    return true;
        //}

        #endregion Gesture

    }
}
