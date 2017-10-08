//Please, if you use this, share the improvements

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using SharpGL;
using AgOpenGPS.Properties;
using System.Globalization;


namespace AgOpenGPS
{
    //the main form object
    public partial class FormGPS : Form
    {
        #region // Class Props and instances
        //maximum sections available
        const int MAXSECTIONS = 9;

        //some test variables
        double testDouble = 0;
        bool testBool = false;
        int testInt = 0;

        //current directory of field;
        public string currentFieldDirectory = "", workingDirectory = "", vehiclefileName = "";

        //colors for sections and field background
        private byte redSections,grnSections,bluSections;
        public byte redField,grnField,bluField;

        //polygon mode for section drawing
        private bool isDrawPolygons = false;

        //for animated submenu
        private bool isMenuHid = true;

        //flag for free drive window to control autosteer
        public bool isInFreeDriveMode = false;

        //Flag stuff
        public byte flagColor = 0;
        private bool leftMouseDownOnOpenGL = false; //mousedown event in opengl window
        private int flagNumberPicked = 0;

        //Is it in 2D or 3D, metric or imperial, display lightbar, display grid
        public bool isIn3D = true, isMetric = true, isLightbarOn = true, isGridOn, isSideGuideLines = true;
        public bool isPureOn = true;

        //bool for whether or not a job is active
        public bool isJobStarted = false, isAreaOnRight = true, isAutoSteerBtnOn = false;

        //master Manual and Auto, 3 states possible
        public enum btnStates {Off,Auto,On};
        public btnStates manualBtnState = btnStates.Off;
        public btnStates autoBtnState = btnStates.Off;

        //section button states
        public enum manBtn { Off, Auto, On };

        //if we are saving a file
        public bool isSavingFile = false, isLogNMEA = false;

        //Zoom variables
        public double gridZoom;
        public double zoomValue = 15;
        public double triangleResolution = 1.0;
        private double previousZoom = 25;

        // Storage For Our Tractor, implement, background etc Textures
        Texture particleTexture;
        public uint[] texture = new uint[3];

        //create the scene camera
        public CCamera camera = new CCamera();

        //create world grid
        public CWorldGrid worldGrid;

        //create instance of a stopwatch for timing of frames and NMEA hz determination
        readonly Stopwatch swFrame = new Stopwatch();

        //Time to do fix position update and draw routine
        private double frameTime = 0;

        //For field saving in background
        private int saveCounter = 1;

        //used to update the screen status bar etc
        private int statusUpdateCounter = 1;

        //Parsing object of NMEA sentences
        public CNMEA pn;

        //create an array of sections, so far only 8 section + 1 fullWidth Section
        public CSection[] section = new CSection[MAXSECTIONS];

        //ABLine Instance
        public CABLine ABLine;

        //Contour mode Instance
        public CContour ct;

        //a brand new vehicle
        public CVehicle vehicle;

        //module communication object
        public CModuleComm mc;

        //perimeter object for area calc
        public CPerimeter periArea;

        //boundary instance
        public CBoundary boundary;

        #endregion

    // Main GPS Form ................................................................................

        // Constructor, Initializes a new instance of the "FormGPS" class.
        public FormGPS()
        {
            //winform initialization
            InitializeComponent();

            //create a new section and set left and right positions
            //created whether used or not, saves restarting program
            for (int j = 0; j < MAXSECTIONS; j++) section[j] = new CSection(this);

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            OpenGL glBack = openGLControlBack.OpenGL;

            //create the world grid
            worldGrid = new CWorldGrid(gl, this);

            //our vehicle made with gl object and pointer of mainform
            vehicle = new CVehicle(gl, this);

            //our NMEA parser
            pn = new CNMEA(this);

            //create the ABLine instance
            ABLine = new CABLine(gl, this);

            //new instance of contour mode
            ct = new CContour(gl, this);

            //module communication
            mc = new CModuleComm();

            //perimeter list object
            periArea = new CPerimeter(gl);

            //boundary object
            boundary = new CBoundary(gl, glBack, this);

            //start the stopwatch
            swFrame.Start();
        }

        //keystrokes for easy and quick startup
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F))
            {
                JobNewOpenResume();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.G))
            {
                Form form = new FormGPSData(this);
                form.Show();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.S))
            {
                SettingsPageOpen(0);
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.P))
            {
                SettingsPageOpen(3);
                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Initialize items before the form Loads or is visible
        private void FormGPS_Load(object sender, EventArgs e)
        {
             //set the flag mark button to red dot
            btnFlag.Image = Properties.Resources.FlagRed;

            //get the working directory, if not exist, create
            workingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + "\\AgOpenGPS\\Fields\\";
            string dir = Path.GetDirectoryName(workingDirectory);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            { Directory.CreateDirectory(dir); }

            //set baud and port from last time run
            baudRateGPS = Settings.Default.setPort_baudRate;
            portNameGPS = Settings.Default.setPort_portNameGPS;

            //try and open
            SerialPortOpenGPS();

            //same for SectionRelay port
            portNameRelaySection = Settings.Default.setPort_portNameRelay;
            wasSectionRelayConnectedLastRun = Settings.Default.setPort_wasRelayConnected;
            if (wasSectionRelayConnectedLastRun) SerialPortRelayOpen();

            //same for AutoSteer port
            portNameAutoSteer = Settings.Default.setPort_portNameAutoSteer;
            wasAutoSteerConnectedLastRun = Settings.Default.setPort_wasAutoSteerConnected;
            if (wasAutoSteerConnectedLastRun) SerialPortAutoSteerOpen();

            //Set width of section and positions for each section
            SectionSetPosition();

            //Calculate total width and each section width
            SectionCalcWidths();

            isTCPServerOn = Settings.Default.setPort_isTCPOn;
            isUDPServerOn = Settings.Default.setPort_isUDPOn;

            //start servers or not
            if (isTCPServerOn) StartTCPServer();
            if (isUDPServerOn) StartUDPServer();

            //set the correct zoom and grid
            camera.camSetDistance = zoomValue * zoomValue * -1;
            SetZoom();

            //which cam source is being used
            isAtanCam = Settings.Default.setCam_isAtanCam;

            //triangle resolution is how far to next triangle point trigger distance
            triangleResolution = Settings.Default.setDisplay_triangleResolution;

            //remembered window position
            if (Settings.Default.setWindow_Maximized)
            {
                WindowState = FormWindowState.Maximized;
                Location = Settings.Default.setWindow_Location;
                Size = Settings.Default.setWindow_Size;
            }
            else if (Settings.Default.setWindow_Minimized)
            {
                //WindowState = FormWindowState.Minimized;
                Location = Settings.Default.setWindow_Location;
                Size = Settings.Default.setWindow_Size;
            }
            else
            {
                Location = Settings.Default.setWindow_Location;
                Size = Settings.Default.setWindow_Size;
            }

            //fix buttons
            btnSection1Man.Enabled = false;
            btnSection2Man.Enabled = false;
            btnSection3Man.Enabled = false;
            btnSection4Man.Enabled = false;
            btnSection5Man.Enabled = false;

            //metric settings
            isMetric = Settings.Default.setMenu_IsMetric;
            metricToolStrip.Checked = isMetric;

            if (isMetric)
            {
                lblSpeedUnits.Text = "kmh";
                metricToolStrip.Checked = true;
                imperialToolStrip.Checked = false;
            }
            else
            {
                lblSpeedUnits.Text = "mph";
                metricToolStrip.Checked = false;
                imperialToolStrip.Checked = true;
            }

            //area side settings
            isAreaOnRight = Settings.Default.setMenu_IsAreaRight;
            toolStripMenuAreaSide.Checked = isAreaOnRight;

            //set up grid and lightbar
            isGridOn = Settings.Default.setMenu_IsGridOn;
            gridToolStripMenuItem.Checked = isGridOn;

            //log NMEA 
            isLogNMEA = Settings.Default.setMenu_IsLogNMEA;
            logNMEAMenuItem.Checked = isLogNMEA;

            isLightbarOn = Settings.Default.setMenu_IsLightbarOn;
            lightbarToolStripMenuItem.Checked = isLightbarOn;

            isSideGuideLines = Settings.Default.setMenu_IsSideGuideLines;
            sideGuideLines.Checked = isSideGuideLines;

            isPureOn = Settings.Default.setMenu_isPureOn;
            pursuitLineToolStripMenuItem.Checked = isPureOn;

            openGLControlBack.Visible = false;

            //set previous job directory
            currentFieldDirectory = Settings.Default.setF_CurrentDir;
            vehiclefileName = Settings.Default.setVehicle_Name;

            //load up colors
            redField = (Settings.Default.setF_FieldColorR);
            grnField = (Settings.Default.setF_FieldColorG);
            bluField = (Settings.Default.setF_FieldColorB);

            redSections = Settings.Default.setF_SectionColorR;
            grnSections = Settings.Default.setF_SectionColorG;
            bluSections = Settings.Default.setF_SectionColorB;

            //clear the flags
            flagPts.Clear();
            btnFlag.Enabled = false;

            //workswitch stuff
            mc.isWorkSwitchEnabled = Settings.Default.setF_IsWorkSwitchEnabled;
            mc.isWorkSwitchActiveLow = Settings.Default.setF_IsWorkSwitchActiveLow;

            minFixStepDist = Settings.Default.setF_minFixStep;

            pitchZero = Settings.Default.setIMU_pitchZero;
            rollZero = Settings.Default.setIMU_rollZero;

            var point = new Point(140,95);
            panel1.Location = point;
            panel1.Width = 400;

            totalUserSquareMeters = Settings.Default.setF_UserTotalArea;
            userSquareMetersAlarm = Settings.Default.setF_UserTripAlarm;

            boundaryTriggerDistance = Settings.Default.setF_boundaryTriggerDistance;
        }

        //form is closing so tidy up and save settings
        private void FormGPS_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save, return, cancel save
            if (isJobStarted)
            {
                int choice = SaveOrNot();

                switch (choice)
                {
                    //OK
                    case 0:
                        Settings.Default.setF_CurrentDir = currentFieldDirectory;
                        Settings.Default.Save();
                        FileSaveEverythingBeforeClosingField();

                        //turn all relays off
                        mc.relaySectionControl[0] = 0;
                        SectionControlOutToPort();

                        mc.autoSteerData[mc.sdHeaderHi] = 127; //32766
                        mc.autoSteerData[mc.sdHeaderLo] = 254;
                        mc.autoSteerData[mc.sdRelay] = 0;
                        mc.autoSteerData[mc.sdSpeed] = 0;
                        mc.autoSteerData[mc.sdDistanceHi] = 125; //32020
                        mc.autoSteerData[mc.sdDistanceLo] = 20;
                        mc.autoSteerData[mc.sdSteerAngleHi] = 125; //32020
                        mc.autoSteerData[mc.sdSteerAngleLo] = 20;

                        //out serial to autosteer module  //indivdual classes load the distance and heading deltas 
                        AutoSteerDataOutToPort();
                        break;

                    //Ignore and return
                    case 1:
                        e.Cancel = true;
                        break;
                }
            }

            //save window settings
             if (WindowState == FormWindowState.Maximized)
            {
                Settings.Default.setWindow_Location = RestoreBounds.Location;
                Settings.Default.setWindow_Size = RestoreBounds.Size;
                Settings.Default.setWindow_Maximized = true;
                Settings.Default.setWindow_Minimized = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Settings.Default.setWindow_Location = Location;
                Settings.Default.setWindow_Size = Size;
                Settings.Default.setWindow_Maximized = false;
                Settings.Default.setWindow_Minimized = false;
            }
            else
            {
                Settings.Default.setWindow_Location = RestoreBounds.Location;
                Settings.Default.setWindow_Size = RestoreBounds.Size;
                Settings.Default.setWindow_Maximized = false;
                Settings.Default.setWindow_Minimized = true;
            }

            Settings.Default.setCam_pitch = camera.camPitch;
            Settings.Default.setF_UserTotalArea = totalUserSquareMeters;
            Settings.Default.setF_UserTripAlarm = userSquareMetersAlarm;

            Settings.Default.Save();
       }

        //called everytime window is resized, clean up button positions
        private void FormGPS_Resize(object sender, EventArgs e)
        {
            LineUpManualBtns();
        }

        // Procedures and Functions ---------------------------------------
        public uint LoadGLTextures()
        {
            OpenGL gl = openGLControl.OpenGL;
            //try
            //{
            //    //  Tractor
            //    particleTexture = new Texture();
            //    particleTexture.Create(gl, @".\Dependencies\Compass.png");
            //    texture[0] = particleTexture.TextureName;
            //}

            //catch (System.Exception excep)
            //{

            //    MessageBox.Show("Texture File Compass.png is Missing",excep.Message);
            //}

            try
            {
                //  Background
                particleTexture = new Texture();
                particleTexture.Create(gl, @".\Dependencies\landscape.png");
                texture[0] = particleTexture.TextureName;
            }
            catch (Exception e)
            {
                WriteErrorLog("Loading Landscape Textures" + e);

                MessageBox.Show("Texture File LANDSCAPE.PNG is Missing", e.Message);
            }

            try
            {
                //  Floor
                particleTexture = new Texture();
                particleTexture.Create(gl, @".\Dependencies\Floor.png");
                texture[1] = particleTexture.TextureName;
            }
            catch (Exception e)
            {
                WriteErrorLog("Loading Floor Texture" + e);

               MessageBox.Show("Texture File FLOOR.PNG is Missing", e.Message);
             }

            return texture[0];
        }// Load Bitmaps And Convert To Textures

        //start the UDP server
        private void StartUDPServer()
        {
            try
            {
                // Initialise the delegate which updates the status
                updateStatusDelegate = UpdateStatus;

                // Initialise the socket
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Initialise the IPEndPoint for the server and listen on port 9999
                IPEndPoint server = new IPEndPoint(IPAddress.Any, 9999);

                //IP address and port of MKR1000
                IPAddress zeroIP = IPAddress.Parse("192.168.1.12");
                epZero = new IPEndPoint(zeroIP, 8888);

                // Associate the socket with this IP address and port
                serverSocket.Bind(server);

                // Initialise the IPEndPoint for the client
                EndPoint client = new IPEndPoint(IPAddress.Any, 0);

                // Start listening for incoming data
                serverSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None,
                                                ref client, ReceiveData, serverSocket);

                //lblStatus.Text = "Listening";
            }
            catch (Exception e)
            {
                WriteErrorLog("UDP Server" + e);

                //lblStatus.Text = "Error";
                MessageBox.Show("Load Error: " + e.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //start the TCP Server
        private void StartTCPServer()
        {
                        // Welcome and Start listening
            //lblWelcome.Text="*** AgOpenGPS Server on Port 7777 Started: "+ DateTime.Now.ToString("G");

            const int nPortListen = 7777;

            // Determine the IPAddress of this machine
            IPAddress[] localIPAddress = null;
            //String strHostName = "";
            try
            {
                // NOTE: DNS lookups are nice and all but quite time consuming.
                //strHostName = Dns.GetHostName();
                IPHostEntry ipEntry = Dns.GetHostEntry(string.Empty);
                localIPAddress = ipEntry.AddressList;
            }
            catch (Exception e)
            {
                WriteErrorLog("TCP Server " + e);

                MessageBox.Show("Error trying to get local address "+ e.Message);
            }

            // Verify we got an IP address. Tell the user if we did
            if (localIPAddress == null || localIPAddress.Length < 1)
            {
                MessageBox.Show("Unable to get local address");
                return;
            }

            //lblListener.Text="Listening on " + strHostName.ToString() + "  " + localIPAddress[1].ToString() + " : " + nPortListen.ToString();
            // Create the listener socket in this machines IP address
            //listener.Bind(new IPEndPoint(localIPAddress[1], nPortListen));
            //listener.Bind(new IPEndPoint(IPAddress.Loopback, nPortListen)); // For use with localhost 127.0.0.1
            listener.Bind(new IPEndPoint(IPAddress.Any, nPortListen)); // For use with localhost 127.0.0.1

            //limit backlog
            listener.Listen(10);

            // Setup a callback to be notified of connection requests
            listener.BeginAccept(OnConnectRequest, listener);
        }

        //dialog for requesting user to save or cancel
        public int SaveOrNot()
        {
            using (var form = new FormSaveOrNot())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK) return 0;
                if (result == DialogResult.Ignore) return 1;
                if (result == DialogResult.Cancel) return 2;
                return 3;
            }
        }

        //show the communications window
        private void SettingsCommunications()
        {
            using (var form = new FormCommSet(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    fixUpdateTime = 1 / (double)fixUpdateHz;
                }
            }

            AutoSteerSettingsOutToPort();
        }

        //Open the dialog of tabbed settings
        private void SettingsPageOpen(int page)
        {
            using (var form = new FormSettings(this, page))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }

        //function to set section positions
        public void SectionSetPosition()
        {
            section[0].positionLeft = (double)Settings.Default.setSection_position1 + Settings.Default.setVehicle_toolOffset;
            section[0].positionRight = (double)Settings.Default.setSection_position2 + Settings.Default.setVehicle_toolOffset;

            section[1].positionLeft = (double)Settings.Default.setSection_position2 + Settings.Default.setVehicle_toolOffset;
            section[1].positionRight = (double)Settings.Default.setSection_position3 + Settings.Default.setVehicle_toolOffset;

            section[2].positionLeft = (double)Settings.Default.setSection_position3 + Settings.Default.setVehicle_toolOffset;
            section[2].positionRight = (double)Settings.Default.setSection_position4 + Settings.Default.setVehicle_toolOffset;

            section[3].positionLeft = (double)Settings.Default.setSection_position4 + Settings.Default.setVehicle_toolOffset;
            section[3].positionRight = (double)Settings.Default.setSection_position5 + Settings.Default.setVehicle_toolOffset;

            section[4].positionLeft = (double)Settings.Default.setSection_position5 + Settings.Default.setVehicle_toolOffset;
            section[4].positionRight = (double)Settings.Default.setSection_position6 + Settings.Default.setVehicle_toolOffset;

            section[5].positionLeft = (double)Settings.Default.setSection_position6 + Settings.Default.setVehicle_toolOffset;
            section[5].positionRight = (double)Settings.Default.setSection_position7 + Settings.Default.setVehicle_toolOffset;

            section[6].positionLeft = (double)Settings.Default.setSection_position7 + Settings.Default.setVehicle_toolOffset;
            section[6].positionRight = (double)Settings.Default.setSection_position8 + Settings.Default.setVehicle_toolOffset;

            section[7].positionLeft = (double)Settings.Default.setSection_position8 + Settings.Default.setVehicle_toolOffset;
            section[7].positionRight = (double)Settings.Default.setSection_position9 + Settings.Default.setVehicle_toolOffset;
        }

        //function to calculate the width of each section and update
        public void SectionCalcWidths()
        {
            for (int j = 0; j < MAXSECTIONS; j++)
            {
                section[j].sectionWidth = (section[j].positionRight - section[j].positionLeft);
                section[j].rpSectionPosition = 200 + (int)(Math.Round(section[j].positionLeft * 10, 0, MidpointRounding.AwayFromZero));
                section[j].rpSectionWidth = (int)(Math.Round(section[j].sectionWidth * 10, 0, MidpointRounding.AwayFromZero));
            }

            //calculate tool width based on extreme right and left values
            vehicle.toolWidth = Math.Abs(section[0].positionLeft) + Math.Abs(section[vehicle.numOfSections - 1].positionRight);

            //left and right tool position
            vehicle.toolFarLeftPosition = section[0].positionLeft;
            vehicle.toolFarRightPosition = section[vehicle.numOfSections - 1].positionRight;

            //now do the full width section
            section[vehicle.numOfSections].sectionWidth = vehicle.toolWidth;
            section[vehicle.numOfSections].positionLeft = vehicle.toolFarLeftPosition;
            section[vehicle.numOfSections].positionRight = vehicle.toolFarRightPosition;

            //find the right side pixel position
            vehicle.rpXPosition = 200 + (int)(Math.Round(vehicle.toolFarLeftPosition * 10, 0, MidpointRounding.AwayFromZero));
            vehicle.rpWidth = (int)(Math.Round(vehicle.toolWidth * 10, 0, MidpointRounding.AwayFromZero));
        }

        //force all the buttons same according to two main buttons
        private void ManualAllBtnsUpdate()
        {
            ManualBtnUpdate(0, btnSection1Man);
            ManualBtnUpdate(1, btnSection2Man);
            ManualBtnUpdate(2, btnSection3Man);
            ManualBtnUpdate(3, btnSection4Man);
            ManualBtnUpdate(4, btnSection5Man);
            ManualBtnUpdate(5, btnSection6Man);
            ManualBtnUpdate(6, btnSection7Man);
            ManualBtnUpdate(7, btnSection8Man);
        }

        //line up section On Off Auto buttons based on how many there are
        public void LineUpManualBtns()
        {
            const int top = 140;

            btnSection4Man.Top = Height - top;
            btnSection1Man.Top = Height - top;
            btnSection2Man.Top = Height - top;
            btnSection3Man.Top = Height - top;
            btnSection4Man.Top = Height - top;
            btnSection5Man.Top = Height - top;
            btnSection6Man.Top = Height - top;
            btnSection7Man.Top = Height - top;
            btnSection8Man.Top = Height - top;

            switch (vehicle.numOfSections)
            {
                case 1:
                    btnSection1Man.Left = Width / 2 - 40;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = false;
                    btnSection3Man.Visible = false;
                    btnSection4Man.Visible = false;
                    btnSection5Man.Visible = false;
                    btnSection6Man.Visible = false;
                    btnSection7Man.Visible = false;
                    btnSection8Man.Visible = false;
                    break;

                case 2:
                    btnSection1Man.Left = Width / 2 - 90;
                    btnSection2Man.Left = Width / 2+10;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = false;
                    btnSection4Man.Visible = false;
                    btnSection5Man.Visible = false;
                    btnSection6Man.Visible = false;
                    btnSection7Man.Visible = false;
                    btnSection8Man.Visible = false;
                     break;

                case 3:
                    btnSection1Man.Left = Width / 2 - 140;
                    btnSection2Man.Left = Width / 2 - 40;
                    btnSection3Man.Left = Width / 2 + 60;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = true;
                    btnSection4Man.Visible = false;
                    btnSection5Man.Visible = false;
                    btnSection6Man.Visible = false;
                    btnSection7Man.Visible = false;
                    btnSection8Man.Visible = false;
                    break;

                case 4:
                    btnSection1Man.Left = Width / 2 - 190;
                    btnSection2Man.Left = Width / 2 - 90;
                    btnSection3Man.Left = Width / 2 + 10;
                    btnSection4Man.Left = Width / 2 + 110;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = true;
                    btnSection4Man.Visible = true;
                    btnSection5Man.Visible = false;
                    btnSection6Man.Visible = false;
                    btnSection7Man.Visible = false;
                    btnSection8Man.Visible = false;
                    break;

                case 5:
                    btnSection1Man.Left = Width / 2 - 240;
                    btnSection2Man.Left = Width / 2 - 140;
                    btnSection3Man.Left = Width / 2 - 40;
                    btnSection4Man.Left = Width / 2 + 60;
                    btnSection5Man.Left = Width / 2 + 160;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = true;
                    btnSection4Man.Visible = true;
                    btnSection5Man.Visible = true;
                    btnSection6Man.Visible = false;
                    btnSection7Man.Visible = false;
                    btnSection8Man.Visible = false;
                    break;

                case 6:
                    btnSection1Man.Left = Width / 2 - 290;
                    btnSection2Man.Left = Width / 2 - 190;
                    btnSection3Man.Left = Width / 2 - 90;
                    btnSection4Man.Left = Width / 2 + 10;
                    btnSection5Man.Left = Width / 2 + 110;
                    btnSection6Man.Left = Width / 2 + 210;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = true;
                    btnSection4Man.Visible = true;
                    btnSection5Man.Visible = true;
                    btnSection6Man.Visible = true;
                    btnSection7Man.Visible = false;
                    btnSection8Man.Visible = false;
                    break;

                case 7:
                    btnSection1Man.Left = Width / 2 - 340;
                    btnSection2Man.Left = Width / 2 - 240;
                    btnSection3Man.Left = Width / 2 - 140;
                    btnSection4Man.Left = Width / 2 - 40;
                    btnSection5Man.Left = Width / 2 + 60;
                    btnSection6Man.Left = Width / 2 + 160;
                    btnSection7Man.Left = Width / 2 + 260;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = true;
                    btnSection4Man.Visible = true;
                    btnSection5Man.Visible = true;
                    btnSection6Man.Visible = true;
                    btnSection7Man.Visible = true;
                    btnSection8Man.Visible = false;

                    break;

                case 8:
                    btnSection1Man.Left = Width / 2 - 390;
                    btnSection2Man.Left = Width / 2 - 290;
                    btnSection3Man.Left = Width / 2 - 190;
                    btnSection4Man.Left = Width / 2 - 90;
                    btnSection5Man.Left = Width / 2 + 10;
                    btnSection6Man.Left = Width / 2 + 110;
                    btnSection7Man.Left = Width / 2 + 210;
                    btnSection8Man.Left = Width / 2 + 310;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = true;
                    btnSection4Man.Visible = true;
                    btnSection5Man.Visible = true;
                    btnSection6Man.Visible = true;
                    btnSection7Man.Visible = true;
                    btnSection8Man.Visible = true;
                    break;
            }

            if (isJobStarted)
            {
                switch (vehicle.numOfSections)
                {
                    case 1:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = false;
                        btnSection3Man.Enabled = false;
                        btnSection4Man.Enabled = false;
                        btnSection5Man.Enabled = false;
                        btnSection6Man.Enabled = false;
                        btnSection7Man.Enabled = false;
                        btnSection8Man.Enabled = false;
                        break;

                    case 2:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = false;
                        btnSection4Man.Enabled = false;
                        btnSection5Man.Enabled = false;
                        btnSection6Man.Enabled = false;
                        btnSection7Man.Enabled = false;
                        btnSection8Man.Enabled = false;
                        break;

                    case 3:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = false;
                        btnSection5Man.Enabled = false;
                        btnSection6Man.Enabled = false;
                        btnSection7Man.Enabled = false;
                        btnSection8Man.Enabled = false;
                        break;

                    case 4:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = true;
                        btnSection5Man.Enabled = false;
                        btnSection6Man.Enabled = false;
                        btnSection7Man.Enabled = false;
                        btnSection8Man.Enabled = false;
                        break;

                    case 5:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = true;
                        btnSection5Man.Enabled = true;
                        btnSection6Man.Enabled = false;
                        btnSection7Man.Enabled = false;
                        btnSection8Man.Enabled = false;
                        break;

                    case 6:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = true;
                        btnSection5Man.Enabled = true;
                        btnSection6Man.Enabled = true;
                        btnSection7Man.Enabled = false;
                        btnSection8Man.Enabled = false;
                        break;

                    case 7:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = true;
                        btnSection5Man.Enabled = true;
                        btnSection6Man.Enabled = true;
                        btnSection7Man.Enabled = true;
                        btnSection8Man.Enabled = false;
                        break;

                    case 8:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = true;
                        btnSection5Man.Enabled = true;
                        btnSection6Man.Enabled = true;
                        btnSection7Man.Enabled = true;
                        btnSection8Man.Enabled = true;
                        break;
                }
            }
        }

        //update individual btn based on state after push
        private void ManualBtnUpdate(int sectNumber, Button btn)
        {
            switch (section[sectNumber].manBtnState)
            {
                case manBtn.Off:
                    section[sectNumber].manBtnState = manBtn.Auto;
                    btn.Image = Properties.Resources.SectionAuto;
                    break;

                case manBtn.Auto:
                    section[sectNumber].manBtnState = manBtn.On;
                    btn.Image = Properties.Resources.SectionOn;
                    break;

                case manBtn.On:
                    section[sectNumber].manBtnState = manBtn.Off;
                    btn.Image = Properties.Resources.SectionOff;
                    break;
            }
        }

        //request a new job
        public void JobNew()
        {
            AutoSteerSettingsOutToPort();
            isJobStarted = true;
            startCounter = 0;

            btnManualOffOn.Enabled = true;
            manualBtnState = btnStates.Off;
            btnManualOffOn.Image = Properties.Resources.ManualOff;

            btnSectionOffAutoOn.Enabled = true;
            autoBtnState = btnStates.Off;
            btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOff;

            btnABLine.Enabled = true;
            btnContour.Enabled = true;
            btnAutoSteer.Enabled = true;
            btnSnap.Enabled = true;

            ABLine.abHeading = 0.00;

            btnFlag.Enabled = true;

            LineUpManualBtns();

            //update the menu
            fieldToolStripMenuItem.Text = "Close Field";
        }

        //close the current job
        public void JobClose()
        {
            //turn auto button off
            autoBtnState = btnStates.Off;
            btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOff;

            //turn section buttons all OFF and zero square meters
            for (int j = 0; j < MAXSECTIONS; j++)
            {
                section[j].isAllowedOn = false;
                section[j].manBtnState = manBtn.On;
             }

            //turn manual button off
            manualBtnState = btnStates.Off;
            btnManualOffOn.Image = Properties.Resources.ManualOff;

            //Update the button colors and text
            ManualAllBtnsUpdate();

            //enable disable manual buttons
            LineUpManualBtns();

            btnSection1Man.Enabled = false;
            btnSection2Man.Enabled = false;
            btnSection3Man.Enabled = false;
            btnSection4Man.Enabled = false;
            btnSection5Man.Enabled = false;
            btnSection6Man.Enabled = false;
            btnSection7Man.Enabled = false;
            btnSection8Man.Enabled = false;

            //job is closed
            isJobStarted = false;

            //clear the section lists
            for (int j = 0; j < MAXSECTIONS; j++)
            {
                //clean out the lists
                section[j].patchList.Clear();
                if (section[j].triangleList != null) section[j].triangleList.Clear();
            }

            //clear out the contour Lists
            ct.ResetContour();

            //clear the flags
            flagPts.Clear();
            btnFlag.Enabled = false;

            //reset the buttons
            btnABLine.Enabled = false;
            btnContour.Enabled = false;
            btnAutoSteer.Enabled = false;
            btnSnap.Enabled = false;

            ct.isContourBtnOn = false;
            ct.isContourOn = false;

            //change images to reflect on off
            btnABLine.Image = Properties.Resources.ABLineOff;
            btnContour.Image = Properties.Resources.ContourOff;
            btnAutoSteer.Image = Properties.Resources.AutoSteerOff;

            //fix ManualOffOnAuto buttons
            btnManualOffOn.Enabled = false;
            manualBtnState = btnStates.Off;
            btnManualOffOn.Image = Properties.Resources.ManualOff;

            //fix auto button
            btnSectionOffAutoOn.Enabled = false;
            autoBtnState = btnStates.Off;
            btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOff;

            //reset all the ABLine stuff
            ABLine.ResetABLine();

            //reset acre and distance counters
            totalSquareMeters = 0;

            //reset boundary
            boundary.ResetBoundary();

            //update the menu
            fieldToolStripMenuItem.Text = "Start Field";
        }

        //bring up field dialog for new/open/resume
        private void JobNewOpenResume()
        {
            //bring up dialog if no job active, close job if one is

            if (!isJobStarted)
            {
                if (stripOnlineGPS.Value == 1)
                {
                    var form = new FormTimedMessage(3000, "No GPS", "Is your GPS source off?");
                    form.Show();
                    return;
                }

                using (var form = new FormJob(this))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        //ask for a directory name
                        using (var form2 = new FormFieldDir(this))
                        { form2.ShowDialog(); }
                    }
                }

                Text = "AgOpenGPS - " + currentFieldDirectory;
            }

            //close the current job and ask how to or if to save
            else
            {
                int choice = SaveOrNot();
                switch (choice)
                {
                    //OK
                    case 0:
                        Settings.Default.setF_CurrentDir = currentFieldDirectory;
                        Settings.Default.Save();
                        FileSaveEverythingBeforeClosingField();
                        break;
                    //Ignore and return
                    case 1:
                        break;

                    ////Don't Save
                    //case 2:
                    //    JobClose();
                    //    Properties.Settings.Default.setCurrentDir = "";
                    //    Properties.Settings.Default.Save();
                    //    currentFieldDirectory = "";
                    //    break;
                }
            }
        }

        //Does the logic to process section on off requests
        private void ProcessSectionOnOffRequests()
        {
            //if (pn.speed > 0.2)
            {
                for (int j = 0; j < vehicle.numOfSections+1; j++)
                {
                    //Turn ON
                    //if requested to be on, set the timer to Max 10 (1 seconds) = 10 frames per second
                    if (section[j].sectionOnRequest && !section[j].sectionOnOffCycle)
                    {
                        section[j].sectionOnTimer = (int)(pn.speed * vehicle.toolLookAhead)+1;
                        if (section[j].sectionOnTimer > fixUpdateHz+3) section[j].sectionOnTimer = fixUpdateHz+3;
                        section[j].sectionOnOffCycle = true;
                    }

                    //reset the ON request
                    section[j].sectionOnRequest = false;

                    //decrement the timer if not zero
                    if (section[j].sectionOnTimer > 0)
                    {
                        //turn the section ON if not and decrement timer
                        section[j].sectionOnTimer--;
                        if (!section[j].isSectionOn) section[j].TurnSectionOn();

                        //keep resetting the section OFF timer while the ON is active
                        section[j].sectionOffTimer = (int)(fixUpdateHz * vehicle.toolTurnOffDelay);
                    }

                    if (!section[j].sectionOffRequest) section[j].sectionOffTimer = (int)(fixUpdateHz * vehicle.toolTurnOffDelay);

                    //decrement the off timer
                    if (section[j].sectionOffTimer > 0) section[j].sectionOffTimer--;

                    //Turn OFF
                    //if Off section timer is zero, turn off the section
                    if (section[j].sectionOffTimer == 0 && section[j].sectionOnTimer == 0 && section[j].sectionOffRequest)
                    {
                        if (section[j].isSectionOn) section[j].TurnSectionOff();
                        section[j].sectionOnOffCycle = false;
                        section[j].sectionOffRequest = false;
                    }
                }
            }
        }

        //take the distance from object and convert to camera data
        private void SetZoom()
        {
            //match grid to cam distance and redo perspective
            if (camera.camSetDistance <= -20000) gridZoom = 2000;
            if (camera.camSetDistance >= -20000 && camera.camSetDistance < -10000) gridZoom =   2000;
            if (camera.camSetDistance >= -10000 && camera.camSetDistance < -5000) gridZoom =    1000;
            if (camera.camSetDistance >= -5000 && camera.camSetDistance < -2000) gridZoom =     503;
            if (camera.camSetDistance >= -2000 && camera.camSetDistance < -1000) gridZoom =     201.2;
            if (camera.camSetDistance >= -1000 && camera.camSetDistance < -500) gridZoom =      100.6;
            if (camera.camSetDistance >= -500 && camera.camSetDistance < -250) gridZoom =       50.3;
            if (camera.camSetDistance >= -250 && camera.camSetDistance < -150) gridZoom =       25.15;
            if (camera.camSetDistance >= -150 && camera.camSetDistance < -50) gridZoom =         10.06;
            if (camera.camSetDistance >= -50 && camera.camSetDistance < -1) gridZoom = 5.03;
            //1.216 2.532

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            //  Create a perspective transformation.
            gl.Perspective(fovy, openGLControl.Width / (double)openGLControl.Height, 1, camDistanceFactor * camera.camSetDistance);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        //All the files that need to be saved when closing field or app
        private void FileSaveEverythingBeforeClosingField()
        {
            //turn off contour line if on
            if (ct.isContourOn) ct.StopContourLine();

            //turn off all the sections
            for (int j = 0; j < vehicle.numOfSections + 1; j++)
            {
                if (section[j].isSectionOn) section[j].TurnSectionOff();
                section[j].sectionOnOffCycle = false;
                section[j].sectionOffRequest = false;
            }

            FileSaveOuterBoundary();
            FileSaveField();
            FileSaveContour();
            FileSaveFlagsKML();

            JobClose();
            Text = "AgOpenGPS";
        }

        //function called by menu items to delete a selected flag
        private void DeleteSelectedFlag()
        {
            //delete selected flag and set selected to none
            flagPts.RemoveAt(flagNumberPicked - 1);
            flagNumberPicked = 0;

            // re-sort the id's based on how many flags left
            int flagCnt = flagPts.Count;
            if (flagCnt > 0)
            {
                for (int i = 0; i < flagCnt; i++) flagPts[i].ID = i + 1;
            }
        }

        //an error log called by all try catches
        public void WriteErrorLog(string strErrorText)
        {
            try
            {
                //set up file and folder if it doesn't exist
                const string strFileName = "Error Log.txt";
                string strPath = Application.StartupPath;

                //Write out the error appending to existing
                File.AppendAllText(strPath + "\\" + strFileName, strErrorText + " - " +
                    DateTime.Now.ToString() + "\r\n\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in WriteErrorLog: " + ex.Message, "Error Logging", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void TimedMessageBox(int timeout, string s1, string s2)
        {
            var form = new FormTimedMessage(timeout, s1, s2);
            form.Show();
        }

    // Buttons //-----------------------------------------------------------------------

        //auto steer off and on
        private void btnAutoSteer_Click(object sender, EventArgs e)
        {
            if (isAutoSteerBtnOn)
            {
                isAutoSteerBtnOn = false;
                btnAutoSteer.Image = Properties.Resources.AutoSteerOff;
            }
            else
            {
                if (ABLine.isABLineSet | ct.isContourBtnOn)
                {
                    isAutoSteerBtnOn = true;
                    btnAutoSteer.Image = Properties.Resources.AutoSteerOn;
                }
                else
                {
                    var form = new FormTimedMessage(2000, "Ooops, No Guidance Lines", "Turn on Contour or Make AB Line");
                    form.Show();
                }
            }
        }

        //ABLine
        private void btnABLine_Click(object sender, EventArgs e)
        {
            //if contour is on, turn it off
            if (ct.isContourBtnOn)
            {
                ct.isContourBtnOn = !ct.isContourBtnOn;
                btnContour.Image = Properties.Resources.ContourOff;
            }

            using (var form = new FormABLine(this))
            {
                ABLine.isABLineBeingSet = true;
                txtDistanceOffABLine.Visible = true;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ABLine.isABLineBeingSet = false;
                }

                //change image to reflect on off
                btnABLine.Image = Properties.Resources.ABLineOn;

                if (result == DialogResult.Cancel)
                {
                    ABLine.isABLineBeingSet = false;
                    txtDistanceOffABLine.Visible = false;
                    //change image to reflect on off
                    btnABLine.Image = Properties.Resources.ABLineOff;
                }
            }
        }

        //turn on contour guidance or off
        private void btnContour_Click(object sender, EventArgs e)
        {
            ct.isContourBtnOn = !ct.isContourBtnOn;
            btnContour.Image = ct.isContourBtnOn ? Properties.Resources.ContourOn : Properties.Resources.ContourOff;
        }

        //zoom up close and far away
        private void btnMinMax_Click(object sender, EventArgs e)
        {
            //keep a copy to go back to previous zoom
            if (zoomValue < 56)
            {
                previousZoom = zoomValue;
                zoomValue = 60;
            }
            else
            {
                zoomValue = previousZoom;
            }
            camera.camSetDistance = zoomValue * zoomValue * -1;
            SetZoom();
        }

        //button for Manual On Off of the sections
        private void btnManualOffOn_Click(object sender, EventArgs e)
        {
            switch (manualBtnState)
            {
                case btnStates.Off:
                    manualBtnState = btnStates.On;
                    btnManualOffOn.Image = Properties.Resources.ManualOn;

                    //if Auto is on, turn it off
                    autoBtnState = btnStates.Off;
                    btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOff;

                    //turn all the sections allowed and update to ON!! Auto changes to ON
                    for (int j = 0; j < vehicle.numOfSections; j++)
                    {
                        section[j].isAllowedOn = true;
                        section[j].manBtnState = manBtn.Auto;
                    }

                    ManualAllBtnsUpdate();
                    break;

                case btnStates.On:
                    manualBtnState = btnStates.Off;
                    btnManualOffOn.Image = Properties.Resources.ManualOff;

                    //turn section buttons all OFF or Auto if SectionAuto was on or off
                        for (int j = 0; j < vehicle.numOfSections; j++)
                        {
                            section[j].isAllowedOn = false;
                            section[j].manBtnState = manBtn.On;
                        }

                    //Update the button colors and text
                    ManualAllBtnsUpdate();
                    break;
            }
        }

        //button for Auto on-off, has the acres displayed
        private void btnSectionOffAutoOn_Click(object sender, EventArgs e)
        {
            switch (autoBtnState)
            {
                case btnStates.Off:
                    autoBtnState = btnStates.Auto;
                    btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOn;

                    //turn off manual if on
                    manualBtnState = btnStates.Off;
                    btnManualOffOn.Image = Properties.Resources.ManualOff;

                    //turn all the sections allowed and update to ON!! Auto changes to ON
                    for (int j = 0; j < vehicle.numOfSections; j++)
                    {
                        section[j].isAllowedOn = true;
                        section[j].manBtnState = manBtn.Off;
                    }

                    ManualAllBtnsUpdate();
                    break;

                case btnStates.Auto:
                    autoBtnState = btnStates.Off;

                    btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOff;

                    //turn section buttons all OFF or Auto if SectionAuto was on or off
                    for (int j = 0; j < vehicle.numOfSections; j++)
                    {
                        section[j].isAllowedOn = false;
                        section[j].manBtnState = manBtn.On;
                    }

                    //Update the button colors and text
                    ManualAllBtnsUpdate();
                    break;
            }
        }

        //individual buttons for sections
        private void btnSection1Man_Click(object sender, EventArgs e)
        {
            if (autoBtnState != btnStates.Auto)
            {
                //if auto is off just have on-off for choices of section buttons
                if (section[0].manBtnState == manBtn.Off) section[0].manBtnState = manBtn.Auto;
                ManualBtnUpdate(0, btnSection1Man);
                return;
            }

            ManualBtnUpdate(0, btnSection1Man);
        }
        private void btnSection2Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[1].manBtnState == manBtn.Off) section[1].manBtnState = manBtn.Auto;
                ManualBtnUpdate(1, btnSection2Man);
                return;
            }

            ManualBtnUpdate(1, btnSection2Man);
        }
        private void btnSection3Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[2].manBtnState == manBtn.Off) section[2].manBtnState = manBtn.Auto;
                ManualBtnUpdate(2, btnSection3Man);
                return;
            }

            ManualBtnUpdate(2, btnSection3Man);
        }
        private void btnSection4Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[3].manBtnState == manBtn.Off) section[3].manBtnState = manBtn.Auto;
                ManualBtnUpdate(3, btnSection4Man);
                return;
            }
            ManualBtnUpdate(3, btnSection4Man);
        }
        private void btnSection5Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[4].manBtnState == manBtn.Off) section[4].manBtnState = manBtn.Auto;
                ManualBtnUpdate(4, btnSection5Man);
                return;
            }

            ManualBtnUpdate(4, btnSection5Man);
        }
        private void btnSection6Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[5].manBtnState == manBtn.Off) section[5].manBtnState = manBtn.Auto;
                ManualBtnUpdate(5, btnSection6Man);
                return;
            }

            ManualBtnUpdate(5, btnSection6Man);
        }
        private void btnSection7Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[6].manBtnState == manBtn.Off) section[6].manBtnState = manBtn.Auto;
                ManualBtnUpdate(6, btnSection7Man);
                return;
            }

            ManualBtnUpdate(6, btnSection7Man);
        }
        private void btnSection8Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[7].manBtnState == manBtn.Off) section[7].manBtnState = manBtn.Auto;
                ManualBtnUpdate(7, btnSection8Man);
                return;
            }

            ManualBtnUpdate(7, btnSection8Man);
        }

        //The reset button on status bar for distance
        private void toolStripBtnResetDistance_ButtonClick(object sender, EventArgs e)
        {
            userDistance = 0;
            totalUserSquareMeters = 0;
        }

        //measure area button
        private void btnPerimeter_Click(object sender, EventArgs e)
        {
            if (periArea.isBtnPerimeterOn && periArea.periPtList.Count > 0)
            {
                periArea.isBtnPerimeterOn = false;
                //btnPerimeter.Text = "Paused";
                btnPerimeter.Image = Properties.Resources.PeriDone;
                return;
            }

            //periArea.isBtnPerimeterOn = !periArea.isBtnPerimeterOn;

            if (!periArea.isBtnPerimeterOn && periArea.periPtList.Count > 0)
              {
                  periArea.periPtList.Clear();
                  periArea.calcList.Clear();
                  //btnPerimeter.Text = "Cleared";
                  btnPerimeter.Image = Properties.Resources.PeriArea;
                  return;
              }

             if (!periArea.isBtnPerimeterOn && periArea.periPtList.Count == 0)
              {
                  //btnPerimeter.Text = "Logging";
                  btnPerimeter.Image = Properties.Resources.PeriDraw;
                  periArea.isBtnPerimeterOn = true;
              }
         }

        //The main flag marker button 
        private void btnFlag_Click(object sender, EventArgs e)
        {
            int nextflag = flagPts.Count + 1;
            CFlag flagPt = new CFlag(pn.latitude, pn.longitude, pn.easting, pn.northing, flagColor, nextflag);
            flagPts.Add(flagPt);
            FileSaveFlags();
        }

        //The zoom buttons in out
        private void btnZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
                  if (zoomValue <= 20) zoomValue += zoomValue*0.1;
                    else zoomValue += zoomValue*0.05;
                    camera.camSetDistance = zoomValue * zoomValue * -1;
                    SetZoom();
        }
        private void btnZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
               if (zoomValue <= 20)
               { if ((zoomValue -= zoomValue * 0.1) < 6.0) zoomValue = 6.0; }
                else  { if ((zoomValue -= zoomValue*0.05) < 6.0) zoomValue = 6.0; }

                camera.camSetDistance = zoomValue * zoomValue * -1;
                SetZoom();
        }

        //view tilt up down and saving in settings
        private void btnTiltUp_MouseDown(object sender, MouseEventArgs e)
        {
            camera.camPitch -= (camera.camPitch*0.03-1);
            if (camera.camPitch > 0) camera.camPitch = 0;
        }
        private void btnTiltDown_MouseDown(object sender, MouseEventArgs e)
        {
            camera.camPitch += (camera.camPitch*0.03-1);
            if (camera.camPitch < -80) camera.camPitch = -80;
        }

        //panel buttons
        private void btnMenuDrawer_Click(object sender, EventArgs e)
        {
            //make sure settings are sent
            AutoSteerSettingsOutToPort();

            if (isMenuHid)
            {
                btnMenuDrawer.Image = Properties.Resources.ArrowLeft;
                isMenuHid = false;
            }
            else
            {
                btnMenuDrawer.Image = Properties.Resources.ArrowRight;
                isMenuHid = true;
            }
        }
        private void HideMenu()
        {
            isMenuHid = true;
            btnMenuDrawer.Image = Properties.Resources.ArrowRight;
        }
        private void btnJob_Click(object sender, EventArgs e)
        {
            HideMenu();
            JobNewOpenResume();
        }
        private void btnSnap_Click(object sender, EventArgs e)
        {
            ABLine.SnapABLine();
            HideMenu();
        }
        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            HideMenu();
            SettingsPageOpen(0);
        }
        private void btnComm_Click(object sender, EventArgs e)
        {
            HideMenu();
            SettingsCommunications();
        }
        private void btnUnits_Click(object sender, EventArgs e)
        {
            HideMenu();
            isMetric = !isMetric;
            Settings.Default.setMenu_IsMetric = isMetric;
            Settings.Default.Save();
            if (isMetric)
            {
                lblSpeedUnits.Text = "kmh";
                metricToolStrip.Checked = true;
                imperialToolStrip.Checked = false;
            }
            else
            {
                lblSpeedUnits.Text = "mph";
                metricToolStrip.Checked = false;
                imperialToolStrip.Checked = true;
            }
        }
        private void btnGPSData_Click(object sender, EventArgs e)
        {
            HideMenu();
            Form form = new FormGPSData(this);
            form.Show();
        }
        private void btnAutoSteerConfig_Click(object sender, EventArgs e)
        {
            HideMenu();

            //check if window already exists
            Form fc = Application.OpenForms["FormSteer"];

            if (fc != null)
            {
                fc.Focus();
                return;
            }

            //
            Form form = new FormSteer(this);
            form.Show();
        }
        private void btnTripOdometer_Click(object sender, EventArgs e)
        {
            HideMenu();
            using (var form = new FormTrip(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }
        private void btnBoundary_Click(object sender, EventArgs e)
        {
            HideMenu();

            if (isJobStarted)
            {
                using (var form = new FormBoundary(this))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Form form2 = new FormBoundaryPlayer(this);
                        form2.Show();
                    }
                }
            }
            else { TimedMessageBox(3000, "Field not Open", "Start a Field First"); }
        }
        private void btnFileExplorer_Click(object sender, EventArgs e)
        {
            HideMenu();
            if (isJobStarted)
            {
                FileSaveFlagsKML();
            }
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                        "\\AgOpenGPS\\Fields\\" + currentFieldDirectory);
        }

        //private void btnFreeDrive_Click(object sender, EventArgs e)
        //{
        //    HideMenu();

        //    //make sure 
        //    if (isJobStarted)
        //    {
        //        var form = new FormTimedMessage(3000, "Ooops, Field is Currently Open", "**** Close Field First to Free Drive ****");
        //        form.Show();
        //        return;
        //    }

        //    Form formS = new FormDrive(this);
        //    formS.Show();

        //    //using (var form = new FormDrive(this))
        //    //{
        //    //    var result = form.ShowDialog();
        //    //}
        //}
   // Menu Items ------------------------------------------------------------------

        //File drop down items

        private void loadVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, "Ooops, Field Open", "Close Field First");
                form.Show();
                return;
            }
            FileOpenVehicle();
        }
        private void saveVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSaveVehicle();
        }
        private void fieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JobNewOpenResume();
        }

        //Help menu drop down items
        private void aboutToolStripMenuHelpAbout_Click(object sender, EventArgs e)
        {
            using (var form = new FormAbout())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }
        private void helpToolStripMenuHelpHelp_Click(object sender, EventArgs e)
        {
            //string appPath = Assembly.GetEntryAssembly().Location;
            //string filename = Path.Combine(Path.GetDirectoryName(appPath), "help.htm");
            Process.Start("help.htm");
        }

        //Options Drop down menu items
        private void resetALLToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                MessageBox.Show("Please Close the Field First.");
            }
            else
            {
                DialogResult result2 = MessageBox.Show("Really Reset Everything?", "Reset settings",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result2 == DialogResult.Yes)
                {
                    Settings.Default.Reset();
                    Settings.Default.Save();
                    MessageBox.Show("Program will exit. Please Restart");
                    Application.Exit();
                }
            }
        }
        private void logNMEAMenuItem_Click(object sender, EventArgs e)
        {
            isLogNMEA = !isLogNMEA;
            logNMEAMenuItem.Checked = isLogNMEA;
            Settings.Default.setMenu_IsLogNMEA = isLogNMEA;
            Settings.Default.Save();
        }
        private void lightbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isLightbarOn = !isLightbarOn;
            lightbarToolStripMenuItem.Checked = isLightbarOn;
            Settings.Default.setMenu_IsLightbarOn = isLightbarOn;
            Settings.Default.Save();
        }
        private void polygonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDrawPolygons = !isDrawPolygons;
            polygonsToolStripMenuItem.Checked = !polygonsToolStripMenuItem.Checked;
        }
        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isGridOn = !isGridOn;
            gridToolStripMenuItem.Checked = isGridOn;
            Settings.Default.setMenu_IsGridOn = isGridOn;
            Settings.Default.Save();
        }

        private void sideGuideLines_Click(object sender, EventArgs e)
        {
            isSideGuideLines = !isSideGuideLines;
            sideGuideLines.Checked = isSideGuideLines;
            Settings.Default.setMenu_IsSideGuideLines = isSideGuideLines;
            Settings.Default.Save();
        }

        private void pursuitLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isPureOn = !isPureOn;
            pursuitLineToolStripMenuItem.Checked = isPureOn;
            Settings.Default.setMenu_isPureOn = isPureOn;
            Settings.Default.Save();
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SettingsPageOpen(0);
        }
        private void communicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsCommunications();
        }
        private void metricToolStrip_Click(object sender, EventArgs e)
        {
            metricToolStrip.Checked = true;
            imperialToolStrip.Checked = false;
            isMetric = true;
            Settings.Default.setMenu_IsMetric = isMetric;
            Settings.Default.Save();
            //if (isMetric) lblSpeedUnits.Text = "Kmh";
            //else lblSpeedUnits.Text = "MPH";

        }
        private void imperialToolStrip_Click(object sender, EventArgs e)
        {
            metricToolStrip.Checked = false;
            imperialToolStrip.Checked = true;
            isMetric = false;
            Settings.Default.setMenu_IsMetric = isMetric;
            Settings.Default.Save();
            lblSpeedUnits.Text = isMetric ? "kmh" : "mph";
        }

        //Area button context menu items
        private void toolStripMenuAreaSide_Click(object sender, EventArgs e)
        {
            isAreaOnRight = !isAreaOnRight;
            Settings.Default.setMenu_IsAreaRight = isAreaOnRight;
            Settings.Default.Save();
        }
        //private void toolStripBtn2D3D_ButtonClick(object sender, EventArgs e)
        //{
        //    if (camera.camPitch > -90) camera.camPitch = -90;
        //    else camera.camPitch = -15;

        //    Properties.Settings.Default.setCam_pitch = camera.camPitch;
        //    Properties.Settings.Default.Save();
        //    SetZoom();
        //}

        //Tools drop down items
        private void explorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                FileSaveFlagsKML();
            }
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                            "\\AgOpenGPS\\Fields\\" + currentFieldDirectory);
        }
        private void webCamToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form form = new FormWebCam();
            form.Show();
        }
        private void googleEarthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                //save new copy of flags
                FileSaveFlagsKML();

                //Process.Start(@"C:\Program Files (x86)\Google\Google Earth\client\googleearth", workingDirectory + currentFieldDirectory + "\\Flags.KML");
                Process.Start(workingDirectory + currentFieldDirectory + "\\Flags.KML");
            }
            else
            {
                var form = new FormTimedMessage(2000, "Field Not Started", "Please Start a Field");
                form.Show();
            }
        }
        private void fieldViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //in the current application directory
            //string AOGViewer = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\AOG.exe";
            //Process.Start(AOGViewer);
            {
                var form = new FormTimedMessage(2000, "Not yet Implemented", "But soon....");
                form.Show();
            }
        }
        private void gPSDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new FormGPSData(this);
            form.Show();
        }
        private void variablesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new FormVariables(this);
            form.Show();
        }

        //The flag context menus
        private void toolStripMenuItemFlagRed_Click(object sender, EventArgs e)
        {
            flagColor = 0;
            btnFlag.Image = Properties.Resources.FlagRed;
        }
        private void toolStripMenuGrn_Click(object sender, EventArgs e)
        {
            flagColor = 1;
            btnFlag.Image = Properties.Resources.FlagGrn;
        }
        private void toolStripMenuYel_Click(object sender, EventArgs e)
        {
            flagColor = 2;
            btnFlag.Image = Properties.Resources.FlagYel;
        }
        private void toolStripMenuFlagDelete_Click(object sender, EventArgs e)
        {
            //delete selected flag and set selected to none
            DeleteSelectedFlag();
            FileSaveFlags();
        }
        private void toolStripMenuFlagDeleteAll_Click(object sender, EventArgs e)
        {
            flagNumberPicked = 0;
            flagPts.Clear();
            FileSaveFlags();
        }
        private void contextMenuStripFlag_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            toolStripMenuFlagDelete.Enabled = flagNumberPicked != 0;

            toolStripMenuFlagDeleteAll.Enabled = flagPts.Count > 0;
        }

        //OpenGL Window context Menu and functions
        private void deleteFlagToolOpenGLContextMenu_Click(object sender, EventArgs e)
        {
            //delete selected flag and set selected to none
            DeleteSelectedFlag();
        }
        private void contextMenuStripOpenGL_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //dont bring up menu if no flag selected
            if (flagNumberPicked == 0) e.Cancel = true;
        }
        private void googleEarthOpenGLContextMenu_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                //save new copy of kml with selected flag and view in GoogleEarth
                FileSaveSingleFlagKML(flagNumberPicked);

                //Process.Start(@"C:\Program Files (x86)\Google\Google Earth\client\googleearth", workingDirectory + currentFieldDirectory + "\\Flags.KML");
                Process.Start(workingDirectory + currentFieldDirectory + "\\Flag.KML");
            }
        }

        //setting color off Options Menu
        private void sectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //color picker for sections
            ColorDialog colorDlg = new ColorDialog
            {
                FullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = Color.FromArgb(255, redSections, grnSections, bluSections)
            };

            if (colorDlg.ShowDialog() != DialogResult.OK) return;

            redSections = colorDlg.Color.R;
            if (redSections > 253) redSections = 253;
            grnSections = colorDlg.Color.G;
            if (grnSections > 253) grnSections = 253;
            bluSections = colorDlg.Color.B;
            if (bluSections > 253) bluSections = 253;

            Settings.Default.setF_SectionColorR = redSections;
            Settings.Default.setF_SectionColorG = grnSections;
            Settings.Default.setF_SectionColorB = bluSections;
            Settings.Default.Save();
        }
        private void fieldToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //color picker for fields

            ColorDialog colorDlg = new ColorDialog
            {
                FullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = Color.FromArgb(255, Settings.Default.setF_FieldColorR,
                Settings.Default.setF_FieldColorG, Settings.Default.setF_FieldColorB)
            };

            if (colorDlg.ShowDialog() != DialogResult.OK) return;

            redField = colorDlg.Color.R;
            if (redField > 253) redField = 253;
            grnField = colorDlg.Color.G;
            if (grnField > 253) grnField = 253;
            bluField = colorDlg.Color.B;
            if (bluField > 253) bluField = 253;

            Settings.Default.setF_FieldColorR = redField;
            Settings.Default.setF_FieldColorG = grnField;
            Settings.Default.setF_FieldColorB = bluField;
            Settings.Default.Save();
        }

        //function mouse down in window for picking
        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //0 at bottom for opengl, 0 at top for windows, so invert Y value
                Point point = openGLControl.PointToClient(Cursor.Position);
                mouseX = point.X;
                mouseY = openGLControl.Height - point.Y;
                leftMouseDownOnOpenGL = true;
            }
      }

        #region Properties // ---------------------------------------------------------------------

        public string Zone { get { return Convert.ToString(pn.zone); } }
        public string FixNorthing { get { return Convert.ToString(Math.Round(pn.northing + pn.utmNorth, 2)); } }
        public string FixEasting { get { return Convert.ToString(Math.Round(pn.easting + pn.utmEast, 2)); } }
        public string Latitude { get { return Convert.ToString(Math.Round(pn.latitude,7)); } }
        public string Longitude { get { return Convert.ToString(Math.Round(pn.longitude, 7)); } }
        public string Altitude { get { return Convert.ToString(pn.altitude); } }
        public string AltitudeFeet { get { return Convert.ToString((int)(pn.altitude * 3.28084)); } }

        public string SatsTracked { get { return Convert.ToString(pn.satellitesTracked); } }
        public string HDOP { get { return Convert.ToString(pn.hdop); }  }
        public string NMEAHz { get { return Convert.ToString(fixUpdateHz); } }
        public string PassNumber { get { return Convert.ToString(ABLine.passNumber); } }
        public string Heading { get { return Convert.ToString(Math.Round(glm.toDegrees(fixHeading), 1)) + "\u00B0"; } }
        public string Status { get { if (pn.status == "A") return "Active"; else return "Void"; } }
        public string FixQuality { get
        {
            if (pn.fixQuality == 0) return "Invalid";
            else if (pn.fixQuality == 1) return "GPS fix";
            else if (pn.fixQuality == 2) return "DGPS fix";
            else if (pn.fixQuality == 3) return "PPS fix";
            else if (pn.fixQuality == 4) return "RTK fix";
            else if (pn.fixQuality == 5) return "Flt RTK";
            else if (pn.fixQuality == 6) return "Estimate";
            else if (pn.fixQuality == 7) return "Man IP";
            else if (pn.fixQuality == 8) return "Sim";
            else                         return "Unknown";    } }

        public string SpeedMPH
        {
            get
            {
                double spd = 0;
                for (int c = 0; c < 10; c++) spd += avgSpeed[c];
                spd *= 0.0621371;
                return Convert.ToString(Math.Round(spd, 1));
            }
        }
        public string SpeedKPH
        {
            get
            {
                double spd = 0;
                for (int c = 0; c < 10; c++) spd += avgSpeed[c];
                spd *= 0.1;
                return Convert.ToString(Math.Round(spd, 1));
            }
        }

        public string PeriAreaAcres { get { return Math.Round(periArea.area * 0.000247105, 2).ToString();  } }
        public string PeriAreaHectares { get { return Math.Round(periArea.area * 0.0001, 2).ToString();  } }

        public string GridFeet { get { return Math.Round(gridZoom * 3.28084, 0).ToString(); } }
        public string GridMeters { get { return Math.Round(gridZoom, 0).ToString(); } }

        public string Acres { get { if (totalSquareMeters < 404645) return Math.Round(totalSquareMeters * 0.00024710499815078974633856493327535, 2).ToString();
                                     else return Math.Round(totalSquareMeters * 0.00024710499815078974633856493327535, 1).ToString();  }  }

        public string Hectares { get { if (totalSquareMeters < 999900) return Math.Round(totalSquareMeters * 0.0001, 2).ToString();
                                        else return Math.Round(totalSquareMeters * 0.0001, 1).ToString(); }  }

        public string AcresUser { get { return Math.Round(totalUserSquareMeters * 0.00024710499815078974633856493327535, 2).ToString(); } }
        public string HectaresUser { get { return Math.Round(totalUserSquareMeters * 0.0001, 2).ToString(); } }

        public string FixHeading { get { return Math.Round(fixHeading, 4).ToString(); } }
        public string FixHeadingSection { get { return Math.Round(fixHeadingSection, 4).ToString(); } }

        public string LookAhead { get { return ((int)(section[0].sectionLookAhead)).ToString(); } }
        public string StepFixNum { get { return (currentStepFix).ToString(); } }
        public string CurrentStepDistance { get { return Math.Round(distanceCurrentStepFix, 3).ToString(); } }
        public string TotalStepDistance { get { return Math.Round(fixStepDist, 3).ToString(); } }

        public string WorkSwitchValue { get { return mc.workSwitchValue.ToString(); } }
        public string AgeDiff { get { return pn.ageDiff.ToString(); } }

        //public string FixHeadingSection { get { return Math.Round(fixHeadingSection, 4).ToString(); } }
        //public string FixHeadingSection { get { return Math.Round(fixHeadingSection, 4).ToString(); } }

#endregion properties 

        //Timer runs at 40 hz and is THE clock of the whole program//
        private void tmrWatchdog_tick(object sender, EventArgs e)
        {
            //go see if data ready for draw and position updates
            tmrWatchdog.Enabled = false;
            ScanForNMEA();
            tmrWatchdog.Enabled = true;
            statusUpdateCounter++;

            if (isMenuHid) { if (panel1.Width > 30) panel1.Width -= 30; else panel1.Width = 0; }
            else { if (panel1.Width < 391) panel1.Width += 30; }

           //every third of a second update all status
            if (statusUpdateCounter > 0)
            {
                //reset the counter
                statusUpdateCounter = 0;

                //counter used for saving field in background
                saveCounter++;

                if (isMetric)  //metric or imperial
                {
                    //Hectares on the master section soft control and sections
                    btnSectionOffAutoOn.Text = Hectares;
                    btnPerimeter.Text = PeriAreaHectares;    //area button

                    //status strip values
                    stripDistance.Text = Convert.ToString((UInt16)(userDistance)) + " m";
                    stripAreaUser.Text = HectaresUser;
                    lblSpeed.Text = SpeedKPH;
                    stripAreaRate.Text = (Math.Round(vehicle.toolWidth * pn.speed / 10,2)).ToString();
                    stripEqWidth.Text = vehiclefileName + (Math.Round(vehicle.toolWidth,2)).ToString() + " m";
                    toolStripStatusLabelBoundaryArea.Text = boundary.areaHectare;
                }
                else
                {
                    //acres on the master section soft control and sections
                    btnSectionOffAutoOn.Text = Acres;
                    btnPerimeter.Text = PeriAreaAcres;    //area button

                    //status strip values
                    stripDistance.Text = Convert.ToString((UInt16)(userDistance * 3.28084)) + " ft";
                    stripAreaUser.Text = AcresUser;
                    lblSpeed.Text = SpeedMPH;
                    //stripGridZoom.Text = "Grid: " + GridFeet + " '";
                    stripAreaRate.Text = ((int)((vehicle.toolWidth * pn.speed / 10) * 2.47)).ToString();
                    stripEqWidth.Text = vehiclefileName + (Math.Round(vehicle.toolWidth * glm.m2ft, 2)).ToString() + " ft";
                    toolStripStatusLabelBoundaryArea.Text = boundary.areaAcre;
                }

                //lblDelta.Text = guidanceLineHeadingDelta.ToString();

                //non metric or imp fields
                stripHz.Text = NMEAHz+"Hz "+ (int)(frameTime);
                lblHeading.Text = Heading;
                btnABLine.Text = PassNumber;
                lblSteerAngle.Text = Convert.ToString((double)(guidanceLineSteerAngle) / 10);

                //stripRoll.Text = avgRoll + "\u00B0";
                //stripPitch.Text = avgPitch + "\u00B0";
                //stripAngularVel.Text = avgAngVel.ToString();
                //lblIMUHeading.Text = Math.Round(modcom.imuHeading, 1) + "\u00B0";

                //lblFix.Text = FixQuality;
                //lblAgeDiff.Text = AgeDiff;

                if (Math.Abs(userSquareMetersAlarm) < 0.1) stripAreaUser.BackColor = SystemColors.ControlLightLight;
                else
                {
                    stripAreaUser.BackColor = totalUserSquareMeters < userSquareMetersAlarm ? SystemColors.ControlLightLight
                                                                                                : Color.OrangeRed;
                }

                //up in the menu a few pieces of info
                if (isJobStarted)
                {
                    lblEasting.Text = "E: "+ Math.Round(pn.easting, 1).ToString();
                    lblNorthing.Text = "N: " + Math.Round(pn.northing, 1).ToString();
                }
                else
                {
                    lblEasting.Text = "E: " + ((int)pn.actualEasting).ToString();
                    lblNorthing.Text = "N: " + ((int)pn.actualNorthing).ToString();
                }

                lblZone.Text = pn.zone.ToString();

                //grab the Valid sentence
                //NMEASentence = recvSentenceSettings;// pn.currentNMEA_GGASentence + pn.currentNMEA_RMCSentence;

                tboxSentence.Text = recvSentenceSettings;
                //update the online indicator
                if (recvCounter > 50)
                {
                    stripOnlineGPS.Value = 1;
                    lblEasting.Text = "-";
                    lblNorthing.Text ="No GPS";
                    lblZone.Text = "-";
                    tboxSentence.Text = "** No Sentence Data **";
                }
                else  stripOnlineGPS.Value = 100;
            }
            //wait till timer fires again.        
        }
   }//class FormGPS
}//namespace AgOpenGPS

        /*The order is:
         * 
         * The watchdog timer times out and runs this function tmrWatchdog_tick.
         * 40 times per second so statusUpdateCounter updates strip menu etc at 2 hz
         * it also makes sure there is new sentences showing up otherwise it shows **** No GGA....
         * saveCounter ticks 1 up 40x per second, used at end of draw routine every minute to save a backup of field
         * then ScanForNMEA function checks for a complete sentence if contained in pn.rawbuffer
         * if not it comes right back and waits for next watchdog trigger and starts all over
         * if a new sentence is there, UpdateFix() is called
         * Right away CalculateLookAhead(), no skips, is called to determine lookaheads and trigger distances to save triangles plotted
         * Then UpdateFix() continues. 
         * Hitch, pivot, antenna locations etc and directions are figured out if trigDistance is triggered
         * When that is done, DoRender() is called on the visible OpenGL screen and its draw routine _draw is run
         * before triangles are drawn, frustum cull figures out how many of the triangles should be drawn 
         * When its all the way thru, it triggers the sectioncontrol Draw, its frustum cull, and determines if sections should be on
         * ProcessSectionOnOffRequests() runs and that does the section on off magic
         * SectionControlToArduino() runs and spits out the port relay control based on sections on or off
         * If field needs saving (1 minute since last time) field is saved
         * Now the program is "Done" and waits for the next watchdog trigger, determines if a new sentence is available etc
         * and starts all over from the top. 
         */



