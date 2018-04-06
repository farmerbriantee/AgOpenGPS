//Please, if you use this, share the improvements

using AgOpenGPS.Properties;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace AgOpenGPS
{
    //the main form object
    public partial class FormGPS : Form
    {
        #region // Class Props and instances

        //maximum sections available
        private const int MAXSECTIONS = 13;

        //How many youturn functions
        public const int MAXFUNCTIONS = 8;

        //The base directory where AgOpenGPS will be stored and fields and vehicles branch from
        public string baseDirectory;

        //current directory of vehicle
        public string vehiclesDirectory, vehiclefileName = "";

        //current fields and field directory
        public string fieldsDirectory, currentFieldDirectory;

        //ABLines directory
        public string ablinesDirectory;

        //colors for sections and field background
        private byte redSections, grnSections, bluSections;

        public byte redField, grnField, bluField;

        //how many cm off line per big pixel
        public int lightbarCmPerPixel;

        //polygon mode for section drawing
        private bool isDrawPolygons;

        //Flag stuff
        public byte flagColor = 0;

        private bool leftMouseDownOnOpenGL = false; //mousedown event in opengl window
        private int flagNumberPicked = 0;

        //Is it in 2D or 3D, metric or imperial, display lightbar, display grid etc
        public bool isIn3D = true, isMetric = true, isLightbarOn = true, isGridOn, isSideGuideLines = true;

        public bool isPureDisplayOn = true, isSkyOn = true, isBigAltitudeOn = false;

        //bool for whether or not a job is active
        public bool isJobStarted = false, isAreaOnRight = true, isAutoSteerBtnOn;

        //master Manual and Auto, 3 states possible
        public enum btnStates { Off, Auto, On }

        public btnStates manualBtnState = btnStates.Off;
        public btnStates autoBtnState = btnStates.Off;

        //section button states
        public enum manBtn { Off, Auto, On }

        //if we are saving a file
        public bool isSavingFile = false, isLogNMEA = false;

        //Zoom variables
        public uint[] texture = new uint[3];

        //create the scene camera
        public CCamera camera = new CCamera();

        //create world grid
        public CWorldGrid worldGrid;

        //create instance of a stopwatch for timing of frames and NMEA hz determination
        private readonly Stopwatch swFrame = new Stopwatch();

        //Time to do fix position update and draw routine
        private double frameTime = 0;

        //For field saving in background
        private int saveCounter = 1;

        //used to update the screen status bar etc
        private int statusUpdateCounter = 1;

        private int fiveSecondCounter = 0;

        /// <summary>
        /// The NMEA class that decodes it
        /// </summary>
        public CNMEA pn;

        /// <summary>
        /// an array of sections, so far only 8 section + 1 fullWidth Section
        /// </summary>
        public CSection[] section = new CSection[MAXSECTIONS];

        /// <summary>
        /// AB Line object
        /// </summary>
        public CABLine ABLine;

        /// <summary>
        /// Contour Mode Instance
        /// </summary>
        public CContour ct;

        /// <summary>
        /// ABCurve instance
        /// </summary>
        public CABCurve curve;

        /// <summary>
        /// Auto Headland YouTurn
        /// </summary>
        public CYouTurn yt;

        /// <summary>
        /// Rate control Object
        /// </summary>
        public CDualRate rcd;

        /// <summary>
        /// Our vehicle including the tool
        /// </summary>
        public CVehicle vehicle;

        /// <summary>
        /// All the structs for recv and send of information out ports
        /// </summary>
        public CModuleComm mc;

        /// <summary>
        /// perimeter object for area calc
        /// </summary>
        public CPerimeter periArea;

        /// <summary>
        /// The outer boundary of the field
        /// </summary>
        public CBoundary boundz;

        /// <summary>
        /// The headland created
        /// </summary>
        public CHeadland hl;

        /// <summary>
        /// The entry and exit sequences, functions, actions
        /// </summary>
        public CSequence seq;

        /// <summary>
        /// The internal simulator
        /// </summary>
        public CSim sim;

        /// <summary>
        /// Resource manager for gloabal strings
        /// </summary>
        public ResourceManager _rm;

        /// <summary>
        /// AutoSteer class of properties
        /// </summary>
        public CAutoSteer ast;

        /// <summary>
        /// Heading, Roll, Pitch, GPS, Properties
        /// </summary>
        public CAHRS ahrs;

        /// <summary>
        /// Recorded Path
        /// </summary>
        public CRecordedPath recPath;

        /// <summary>
        /// Cart instance
        /// </summary>
        public CCart cart;

        #endregion // Class Props and instances

        // Constructor, Initializes a new instance of the "FormGPS" class.
        public FormGPS()
        {
            //winform initialization
            InitializeComponent();

            //build the gesture structures
            SetupStructSizes();

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

            //new instance of contour mode
            curve = new CABCurve(gl, this);

            //new instance of auto headland turn
            yt = new CYouTurn(gl, glBack, this);

            //module communication
            mc = new CModuleComm(this);

            //perimeter list object
            periArea = new CPerimeter(gl);

            //boundary object
            boundz = new CBoundary(gl, glBack, this);

            //headland object
            hl = new CHeadland(gl, this);

            //rate object for dual flowmeters
            rcd = new CDualRate(this);

            //headland entry/exit sequences
            seq = new CSequence(this);

            //nmea simulator built in.
            sim = new CSim(this);

            //all the autosteer objects
            ast = new CAutoSteer(this);

            //all the attitude, heading, roll, pitch reference system
            ahrs = new CAHRS(this);

            //A recorded path
            recPath = new CRecordedPath(gl, this);

            //An instance of dubins paths
            cart = new CCart(this);

            //start the stopwatch
            swFrame.Start();

            //resource for gloabal language strings
            _rm = new ResourceManager("AgOpenGPS.gStr", Assembly.GetExecutingAssembly());
        }

        //Initialize items before the form Loads or is visible
        private void FormGPS_Load(object sender, EventArgs e)
        {
            //tooltips of controls
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(btnABLine, "Set and configure\n an ABLine");

            if (Settings.Default.setF_workingDirectory == "Default")
                baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AgOpenGPS\\";
            else baseDirectory = Settings.Default.setF_workingDirectory + "\\AgOpenGPS\\";

            //get the fields directory, if not exist, create
            fieldsDirectory = baseDirectory + "Fields\\";
            string dir = Path.GetDirectoryName(fieldsDirectory);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

            //get the fields directory, if not exist, create
            vehiclesDirectory = baseDirectory + "Vehicles\\";
            dir = Path.GetDirectoryName(vehiclesDirectory);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

            //make sure current field directory exists, null if not
            currentFieldDirectory = Settings.Default.setF_CurrentDir;

            string curDir;
            if (currentFieldDirectory != "")
            {
                curDir = fieldsDirectory + currentFieldDirectory + "//";
                dir = Path.GetDirectoryName(curDir);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    currentFieldDirectory = "";
                    Settings.Default.setF_CurrentDir = "";
                    Settings.Default.Save();
                }
            }

            //grab the current vehicle filename - make sure it exists
            vehiclefileName = Vehicle.Default.setVehicle_Name;

            fixUpdateHz = Properties.Settings.Default.setPort_NMEAHz;
            fixUpdateTime = 1 / (double)fixUpdateHz;

            //get the abLines directory, if not exist, create
            ablinesDirectory = baseDirectory + "ABLines\\";
            dir = Path.GetDirectoryName(fieldsDirectory);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

            //set baud and port from last time run
            baudRateGPS = Settings.Default.setPort_baudRate;
            portNameGPS = Settings.Default.setPort_portNameGPS;

            //try and open
            SerialPortOpenGPS();

            //same for SectionRelay port
            portNameRelaySection = Settings.Default.setPort_portNameRateRelay;
            wasRateRelayConnectedLastRun = Settings.Default.setPort_wasRateRelayConnected;
            if (wasRateRelayConnectedLastRun) SerialPortRateRelayOpen();

            //same for AutoSteer port
            portNameAutoSteer = Settings.Default.setPort_portNameAutoSteer;
            wasAutoSteerConnectedLastRun = Settings.Default.setPort_wasAutoSteerConnected;
            if (wasAutoSteerConnectedLastRun) SerialPortAutoSteerOpen();

            //Set width of section and positions for each section
            SectionSetPosition();

            //Calculate total width and each section width
            SectionCalcWidths();

            //start udp server if required
            if (Properties.Settings.Default.setUDP_isOn) StartUDPServer();

            //set the correct zoom and grid
            camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
            SetZoom();

            //which heading source is being used
            headingFromSource = Settings.Default.setGPS_headingFromWhichSource;

            //triangle resolution is how far to next triangle point trigger distance
            camera.triangleResolution = Settings.Default.setDisplay_triangleResolution;

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

            //don't draw the back opengl to GDI - it still works tho
            //openGLControlBack.Visible = false;

            //clear the flags
            flagPts.Clear();
            btnFlag.Enabled = false;

            //workswitch stuff
            mc.isWorkSwitchEnabled = Settings.Default.setF_IsWorkSwitchEnabled;
            mc.isWorkSwitchActiveLow = Settings.Default.setF_IsWorkSwitchActiveLow;

            minFixStepDist = Settings.Default.setF_minFixStep;

            totalUserSquareMeters = Settings.Default.setF_UserTotalArea;
            userSquareMetersAlarm = Settings.Default.setF_UserTripAlarm;

            //space between points while recording a boundary
            boundaryTriggerDistance = Settings.Default.setF_boundaryTriggerDistance;

            //load the last used auto turn shape
            string fileAndDir = @".\YouTurnShapes\" + Properties.Settings.Default.setAS_youTurnShape;
            yt.LoadYouTurnShapeFromFile(fileAndDir);

            //sim.latitude = Settings.Default.setSim_lastLat;
            //sim.longitude = Settings.Default.setSim_lastLong;

            //load th elightbar resolution
            lightbarCmPerPixel = Properties.Settings.Default.setDisplay_lightbarCmPerPixel;

            // load all the gui elements in gui.designer.cs
            LoadGUI();
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
                        isSendConnected = false;
                        Settings.Default.setF_CurrentDir = currentFieldDirectory;
                        Settings.Default.Save();

                        FileSaveEverythingBeforeClosingField();

                        //shutdown and reset all module data
                        mc.ResetAllModuleCommValues();
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
            if (Width < 850 && tabControl1.Visible) HideTabControl();
            if (Width > 1100 && !tabControl1.Visible) HideTabControl();
        }

        // Procedures and Functions ---------------------------------------
        public uint LoadGLTextures()
        {
            OpenGL gl = openGLControl.OpenGL;
            //try
            //{
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
                ParticleTexture = new Texture();
                ParticleTexture.Create(gl, @".\Dependencies\landscape.png");
                texture[0] = ParticleTexture.TextureName;
            }
            catch (Exception e)
            {
                WriteErrorLog("Loading Landscape Textures" + e);
                MessageBox.Show("Texture File LANDSCAPE.PNG is Missing", e.Message);
            }

            try
            {
                //  Floor
                ParticleTexture = new Texture();
                ParticleTexture.Create(gl, @".\Dependencies\Floor.png");
                texture[1] = ParticleTexture.TextureName;
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
                // Initialise the delegate which updates the message received
                updateRecvMessageDelegate = UpdateRecvMessage;

                // Initialise the socket
                sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                recvSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Initialise the IPEndPoint for the server and listen on port 9999
                IPEndPoint recv = new IPEndPoint(IPAddress.Any, Properties.Settings.Default.setIP_thisPort);

                // Associate the socket with this IP address and port
                recvSocket.Bind(recv);

                // Initialise the send socket
                sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Initialise the IPEndPoint for the server to send on port 9998
                IPEndPoint server = new IPEndPoint(IPAddress.Any, 9998);
                sendSocket.Bind(server);

                // Initialise the IPEndPoint for the client - async listner client only!
                EndPoint client = new IPEndPoint(IPAddress.Any, 0);

                // Start listening for incoming data
                recvSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None,
                                                ref client, new AsyncCallback(ReceiveData), recvSocket);
                isSendConnected = true;
            }
            catch (Exception e)
            {
                WriteErrorLog("UDP Server" + e);
                MessageBox.Show("Load Error: " + e.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMakeContourFromBoundary_Click(object sender, EventArgs e)
        {
            if (!boundz.isSet) return;

            vec3 point = new vec3();

            //count the points from the boundary
            int ptCount = boundz.ptList.Count;

            //first find out which side is inside the boundary
            double oneSide = glm.PIBy2;
            point.easting = boundz.ptList[3].easting - (Math.Sin(oneSide + boundz.ptList[3].heading) * 2.0);
            point.northing = boundz.ptList[3].northing - (Math.Cos(oneSide + boundz.ptList[3].heading) * 2.0);

            if (boundz.IsPointInsideBoundary(point)) oneSide *= -1.0;

            //determine how wide a headland space
            double totalHeadWidth = vehicle.toolWidth * 0.46;

            ct.ptList = new List<vec3>();
            ct.stripList.Add(ct.ptList);

            for (int i = ptCount - 1; i >= 0; i--)
            {
                //calculate the point inside the boundary
                point.easting = boundz.ptList[i].easting - (Math.Sin(oneSide + boundz.ptList[i].heading) * totalHeadWidth);
                point.northing = boundz.ptList[i].northing - (Math.Cos(oneSide + boundz.ptList[i].heading) * totalHeadWidth);
                point.heading = boundz.ptList[i].heading - Math.PI;
                if (point.heading < -glm.twoPI) point.heading += glm.twoPI;

                //only add if inside actual field boundary
                ct.ptList.Add(point);
            }
        }

        private void btnRecPathPauseRecord_Click(object sender, EventArgs e)
        {
            if (recPath.isRecordOn)
            {
                recPath.isRecordOn = false;
                btnRecPathPauseRecord.Image = Properties.Resources.boundaryPause;
            }
            else if (isJobStarted)
            {
                recPath.isRecordOn = true;
                btnRecPathPauseRecord.Image = Properties.Resources.BoundaryRecord;
            }
        }

        private void btnCallCart_Click(object sender, EventArgs e)
        {
            if (cart.isCartOn && !cart.isCartCalled && !cart.isCartSentHome)
            {
                cart.CartCall();
                btnCallCart.Enabled = false;
                btnCartDone.Enabled = true;
            }
        }

        private void btnCartDone_Click(object sender, EventArgs e)
        {
            if (cart.isCartOn)
            {
                cart.isCartCalled = false;
                cart.isCartSentHome = true;
                btnCallCart.Enabled = true;
                btnCartDone.Enabled = false;
            }
        }

        private void btnCartOnOff_Click(object sender, EventArgs e)
        {
            if (cart.isCartOn)
            {
                btnCallCart.Enabled = false;
                btnCartDone.Enabled = false;
                cart.isCartOn = false;
                btnCartOnOff.Image = Resources.FlagRed;
            }
            else
            {
                btnCallCart.Enabled = true;
                btnCartDone.Enabled = false;
                cart.isCartOn = true;
                btnCartOnOff.Image = Resources.FlagGrn;
            }
        }

        private void btnOffsetBackward_Click(object sender, EventArgs e)
        {
            cart.offsetForward -= 0.5;
        }

        private void btnOffsetForward_Click(object sender, EventArgs e)
        {
            cart.offsetForward += 0.5;
        }

        private void btnOffsetInward_Click(object sender, EventArgs e)
        {
            cart.offsetOutward -= 0.5;
        }

        private void btnOffsetOutward_Click(object sender, EventArgs e)
        {
            cart.offsetOutward += 0.5;
        }

        private void btnDualRate_Click(object sender, EventArgs e)
        {
            if (!rcd.isSingleFlowMeter && vehicle.numOfSections % 2 != 0 && !rcd.isRateControlOn)
            {
                TimedMessageBox(3500, "Even # of Sections Only", "You Must Have an Even Number of Sections");
                return;
            }

            if (isJobStarted)
                {
                    rcd.isRateControlOn = !rcd.isRateControlOn;

                    if (rcd.isRateControlOn)
                    {
                        mc.relayRateSettings[mc.rsFlowCalFactorLeftHi] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberLeft >> 8);
                        mc.relayRateSettings[mc.rsFlowCalFactorLeftLo] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberLeft);
                        mc.relayRateSettings[mc.rsFlowCalFactorRightHi] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberRight >> 8);
                        mc.relayRateSettings[mc.rsFlowCalFactorRightLo] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberRight);
                        RateRelayOutToPort(mc.relayRateSettings, CModuleComm.numRelayRateSettingsItems);

                        //get the last saved rates from setting file - always stored in L/Ha
                        rcd.rateLeft = Properties.Settings.Default.setRate_rateLeft;
                        rcd.rateRight = Properties.Settings.Default.setRate_rateRight;
                        btnSelectSingleDualMeter.Enabled = false;

                        if (rcd.isSingleFlowMeter)
                        {
                            btnRateRightDn.Visible = false;
                            btnRateRightUp.Visible = false;
                            btnRateLeftDn.Visible = true;
                            btnRateLeftUp.Visible = true;
                            btnSelectRate1.Visible = true;
                            btnSelectRate2.Visible = true;

                            lblFlowRateRight.Visible = false;
                            lblRateAppliedActualRight.Visible = false;
                            lblRateSetpointRight.Visible = false;
                            lblFlowRight.Visible = false;

                            lblFlowRateLeft.Visible = true;
                            lblRateAppliedActualLeft.Visible = true;
                            lblRateSetpointLeft.Visible = true;
                            lblFlowLeft.Visible = true;
                        }
                        else
                        {
                            btnRateRightDn.Visible = true;
                            btnRateRightUp.Visible = true;
                            btnRateLeftDn.Visible = true;
                            btnRateLeftUp.Visible = true;

                            btnSelectRate1.Visible = false;
                            btnSelectRate2.Visible = false;

                            lblFlowRateRight.Visible = true;
                            lblRateAppliedActualRight.Visible = true;
                            lblRateSetpointRight.Visible = true;
                            lblFlowRight.Visible = true;

                            lblFlowRateLeft.Visible = true;
                            lblRateAppliedActualLeft.Visible = true;
                            lblRateSetpointLeft.Visible = true;
                            lblFlowLeft.Visible = true;
                        }

                        btnDualRate.Image = Properties.Resources.RateControlOn;
                        btnDualRate.Text = "On";

                        if (isMetric)
                        {
                            lblRateSetpointLeft.Text = (rcd.rateLeft).ToString("N1");
                            lblRateSetpointRight.Text = (rcd.rateRight).ToString("N1");
                        }
                        else
                        {
                            lblRateSetpointLeft.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
                            lblRateSetpointRight.Text = (rcd.rateRight * glm.LHa2galAc).ToString("N1");
                        }
                    }
                    else
                    {
                        btnRateRightDn.Visible = false;
                        btnRateRightUp.Visible = false;
                        btnRateLeftDn.Visible = false;
                        btnRateLeftUp.Visible = false;
                        btnSelectRate1.Visible = false;
                        btnSelectRate2.Visible = false;

                        lblFlowRateRight.Visible = false;
                        lblRateAppliedActualRight.Visible = false;
                        lblRateSetpointRight.Visible = false;
                        lblFlowRight.Visible = false;

                        lblFlowRateLeft.Visible = false;
                        lblRateAppliedActualLeft.Visible = false;
                        lblRateSetpointLeft.Visible = false;
                        lblFlowLeft.Visible = false;

                        btnSelectSingleDualMeter.Enabled = true;

                        btnDualRate.Image = Properties.Resources.RateControlOff;
                        btnDualRate.Text = "Off";
                        lblRateAppliedActualRight.Text = "-";
                        lblRateAppliedActualLeft.Text = "-";
                        lblFlowRateLeft.Text = "-";
                        lblFlowRateRight.Text = "-";

                        rcd.rateSetPointLeft = 0.0;
                        rcd.rateSetPointRight = 0.0;

                        mc.relayRateData[mc.rdRateSetPointLeftLo] = 0;
                        mc.relayRateData[mc.rdRateSetPointLeftHi] = 0;
                        mc.relayRateData[mc.rdRateSetPointRightLo] = 0;
                        mc.relayRateData[mc.rdRateSetPointRightHi] = 0;
                        RateRelayOutToPort(mc.relayRateData, CModuleComm.numRelayRateDataItems);
                    }
                }
                else { TimedMessageBox(1500, "Field not Open", "Start a Field First"); }
        }

        private void btnRateLeftUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (isMetric)
            {
                rcd.rateLeft++;
                lblRateSetpointLeft.Text = rcd.rateLeft.ToString("N1");
            }
            else
            {
                rcd.rateLeft++;
                lblRateSetpointLeft.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
            }
        }

        private void btnRateLeftDn_MouseDown(object sender, MouseEventArgs e)
        {
            if (isMetric)
            {
                rcd.rateLeft--;
                if (rcd.rateLeft < 2.0) rcd.rateLeft = 2.0;
                lblRateSetpointLeft.Text = rcd.rateLeft.ToString("N1");
            }
            else
            {
                rcd.rateLeft--;
                if (rcd.rateLeft < 2.0) rcd.rateLeft = 2.0;
                lblRateSetpointLeft.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
            }
        }

        private void btnRateRightUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (isMetric)
            {
                rcd.rateRight++;
                lblRateSetpointRight.Text = rcd.rateRight.ToString("N1");
            }
            else
            {
                rcd.rateRight++;
                lblRateSetpointRight.Text = (rcd.rateRight * glm.LHa2galAc).ToString("N1");
            }
        }

        private void btnRateRightDn_MouseDown(object sender, MouseEventArgs e)
        {
            if (isMetric)
            {
                rcd.rateRight--;
                if (rcd.rateRight < 2.0) rcd.rateRight = 2.0;
                lblRateSetpointRight.Text = rcd.rateRight.ToString("N1");
            }
            else
            {
                rcd.rateRight--;
                if (rcd.rateRight < 2.0) rcd.rateRight = 2.0;
                lblRateSetpointRight.Text = (rcd.rateRight * glm.LHa2galAc).ToString("N1");
            }
        }

        private void btnDualRateConfig_Click(object sender, EventArgs e)
        {
            var form = new FormDualRate(this);
            form.ShowDialog();
            btnSelectRate1.BackColor = Color.LightSkyBlue;
            btnSelectRate2.BackColor = Color.LightGray;
            if (isMetric)
            {
                lblRateSetpointLeft.Text = (rcd.rateLeft).ToString("N1");
                lblRateSetpointRight.Text = (rcd.rateRight).ToString("N1");
                btnSelectRate1.Text = Math.Round(rcd.rateLeft, 1).ToString();
                btnSelectRate2.Text = Math.Round(rcd.rateRight, 1).ToString();
            }
            else
            {
                lblRateSetpointLeft.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
                lblRateSetpointRight.Text = (rcd.rateRight * glm.LHa2galAc).ToString("N1");
                btnSelectRate1.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
                btnSelectRate2.Text = (rcd.rateRight * glm.LHa2galAc).ToString("N1");
            }
        }

        private void btnSelectRate1_Click(object sender, EventArgs e)
        {
            rcd.rateLeft = Settings.Default.setRate_rateLeft;
            rcd.isRate1Selected = true;
            btnSelectRate1.BackColor = Color.LightSkyBlue;
            btnSelectRate2.BackColor = Color.LightGray;
            if (isMetric)
            {
                lblRateSetpointLeft.Text = (rcd.rateLeft).ToString("N1");
            }
            else
            {
                lblRateSetpointLeft.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
            }
        }

        private void btnSelectRate2_Click(object sender, EventArgs e)
        {
            rcd.rateLeft = Settings.Default.setRate_rateRight;
            rcd.isRate1Selected = false;
            btnSelectRate2.BackColor = Color.LightSkyBlue;
            btnSelectRate1.BackColor = Color.LightGray;

            if (isMetric)
            {
                lblRateSetpointLeft.Text = (rcd.rateLeft).ToString("N1");
            }
            else
            {
                lblRateSetpointLeft.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
            }
        }

        private void btnSelectSingleDualMeter_Click(object sender, EventArgs e)
        {
            if (rcd.isSingleFlowMeter && vehicle.numOfSections % 2 != 0)
            {
                TimedMessageBox(3000, "Dual Flow Meters Needs Even # Sections", "Go to Vehicle Config and Select Even # of Sections");
                return;
            }

            rcd.isSingleFlowMeter = !rcd.isSingleFlowMeter;
            if (rcd.isSingleFlowMeter)
            {
                btnSelectSingleDualMeter.Image = Resources.FlowMeterSingle;
            }
            else
            {
                btnSelectSingleDualMeter.Image = Resources.FlowMeterDual;
            }

            Settings.Default.setRate_isSingleFlowMeter = rcd.isSingleFlowMeter;
            Settings.Default.Save();
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

        //show the UDP ethernet settings page
        private void SettingsUDP()
        {
            using (var form = new FormUDP(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //Clicked Save
                }
                else
                {
                    //Clicked X - No Save
                }
            }
        }

        //function to set section positions
        public void SectionSetPosition()
        {
            section[0].positionLeft = (double)Vehicle.Default.setSection_position1 + Vehicle.Default.setVehicle_toolOffset;
            section[0].positionRight = (double)Vehicle.Default.setSection_position2 + Vehicle.Default.setVehicle_toolOffset;

            section[1].positionLeft = (double)Vehicle.Default.setSection_position2 + Vehicle.Default.setVehicle_toolOffset;
            section[1].positionRight = (double)Vehicle.Default.setSection_position3 + Vehicle.Default.setVehicle_toolOffset;

            section[2].positionLeft = (double)Vehicle.Default.setSection_position3 + Vehicle.Default.setVehicle_toolOffset;
            section[2].positionRight = (double)Vehicle.Default.setSection_position4 + Vehicle.Default.setVehicle_toolOffset;

            section[3].positionLeft = (double)Vehicle.Default.setSection_position4 + Vehicle.Default.setVehicle_toolOffset;
            section[3].positionRight = (double)Vehicle.Default.setSection_position5 + Vehicle.Default.setVehicle_toolOffset;

            section[4].positionLeft = (double)Vehicle.Default.setSection_position5 + Vehicle.Default.setVehicle_toolOffset;
            section[4].positionRight = (double)Vehicle.Default.setSection_position6 + Vehicle.Default.setVehicle_toolOffset;

            section[5].positionLeft = (double)Vehicle.Default.setSection_position6 + Vehicle.Default.setVehicle_toolOffset;
            section[5].positionRight = (double)Vehicle.Default.setSection_position7 + Vehicle.Default.setVehicle_toolOffset;

            section[6].positionLeft = (double)Vehicle.Default.setSection_position7 + Vehicle.Default.setVehicle_toolOffset;
            section[6].positionRight = (double)Vehicle.Default.setSection_position8 + Vehicle.Default.setVehicle_toolOffset;

            section[7].positionLeft = (double)Vehicle.Default.setSection_position8 + Vehicle.Default.setVehicle_toolOffset;
            section[7].positionRight = (double)Vehicle.Default.setSection_position9 + Vehicle.Default.setVehicle_toolOffset;

            section[8].positionLeft = (double)Vehicle.Default.setSection_position9 + Vehicle.Default.setVehicle_toolOffset;
            section[8].positionRight = (double)Vehicle.Default.setSection_position10 + Vehicle.Default.setVehicle_toolOffset;

            section[9].positionLeft = (double)Vehicle.Default.setSection_position10 + Vehicle.Default.setVehicle_toolOffset;
            section[9].positionRight = (double)Vehicle.Default.setSection_position11 + Vehicle.Default.setVehicle_toolOffset;

            section[10].positionLeft = (double)Vehicle.Default.setSection_position11 + Vehicle.Default.setVehicle_toolOffset;
            section[10].positionRight = (double)Vehicle.Default.setSection_position12 + Vehicle.Default.setVehicle_toolOffset;

            section[11].positionLeft = (double)Vehicle.Default.setSection_position12 + Vehicle.Default.setVehicle_toolOffset;
            section[11].positionRight = (double)Vehicle.Default.setSection_position13 + Vehicle.Default.setVehicle_toolOffset;
        }

        //function to calculate the width of each section and update
        public void SectionCalcWidths()
        {
            for (int j = 0; j < MAXSECTIONS; j++)
            {
                section[j].sectionWidth = (section[j].positionRight - section[j].positionLeft);
                section[j].rpSectionPosition = 250 + (int)(Math.Round(section[j].positionLeft * 10, 0, MidpointRounding.AwayFromZero));
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
            vehicle.rpXPosition = 250 + (int)(Math.Round(vehicle.toolFarLeftPosition * 10, 0, MidpointRounding.AwayFromZero));
            vehicle.rpWidth = (int)(Math.Round(vehicle.toolWidth * 10, 0, MidpointRounding.AwayFromZero));
        }

        //request a new job
        public void JobNew()
        {
            //isGPSPositionInitialized = false;
            //offset = 0;
            AutoSteerSettingsOutToPort();
            isJobStarted = true;
            startCounter = 0;

            btnManualOffOn.Enabled = true;
            manualBtnState = btnStates.Off;
            btnManualOffOn.Image = Properties.Resources.ManualOff;

            btnSectionOffAutoOn.Enabled = true;
            autoBtnState = btnStates.Off;
            btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOff;

            btnSection1Man.BackColor = Color.Red;
            btnSection2Man.BackColor = Color.Red;
            btnSection3Man.BackColor = Color.Red;
            btnSection4Man.BackColor = Color.Red;
            btnSection5Man.BackColor = Color.Red;
            btnSection6Man.BackColor = Color.Red;
            btnSection7Man.BackColor = Color.Red;
            btnSection8Man.BackColor = Color.Red;
            btnSection9Man.BackColor = Color.Red;
            btnSection10Man.BackColor = Color.Red;
            btnSection11Man.BackColor = Color.Red;
            btnSection12Man.BackColor = Color.Red;

            btnABLine.Enabled = true;
            btnContour.Enabled = true;
            btnAutoSteer.Enabled = true;
            btnSnap.Enabled = true;
            btnCurve.Enabled = true;
            ABLine.abHeading = 0.00;

            btnRightYouTurn.Enabled = false;
            btnLeftYouTurn.Enabled = false;
            btnFlag.Enabled = true;

            if (recPath.isRecordOn)
            {
                recPath.isRecordOn = false;
                btnRecPathPauseRecord.Image = Properties.Resources.boundaryPause;
            }

            LineUpManualBtns();

            //update the menu
            fieldToolStripMenuItem.Text = gStr.gsCloseField;
        }

        //close the current job
        public void JobClose()
        {
            //rate control buttons
            if (rcd.isRateControlOn)
                btnDualRate.PerformClick();

            rcd.ShutdownRateControl();  //double dam sure its off

            btnRateRightDn.Visible = false;
            btnRateRightUp.Visible = false;
            btnRateLeftDn.Visible = false;
            btnRateLeftUp.Visible = false;
            btnSelectRate1.Visible = false;
            btnSelectRate2.Visible = false;

            lblFlowRateRight.Visible = false;
            lblRateAppliedActualRight.Visible = false;
            lblRateSetpointRight.Visible = false;
            lblFlowRight.Visible = false;

            lblFlowRateLeft.Visible = false;
            lblRateAppliedActualLeft.Visible = false;
            lblRateSetpointLeft.Visible = false;
            lblFlowLeft.Visible = false;

            btnDualRate.Image = Properties.Resources.RateControlOff;
            btnDualRate.Text = "Off";
            lblRateAppliedActualRight.Text = "-";
            lblRateAppliedActualLeft.Text = "-";
            lblFlowRateLeft.Text = "-";
            lblFlowRateRight.Text = "-";

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
            btnSection9Man.Enabled = false;
            btnSection10Man.Enabled = false;
            btnSection11Man.Enabled = false;
            btnSection12Man.Enabled = false;

            btnSection1Man.BackColor = Color.Silver;
            btnSection2Man.BackColor = Color.Silver;
            btnSection3Man.BackColor = Color.Silver;
            btnSection4Man.BackColor = Color.Silver;
            btnSection5Man.BackColor = Color.Silver;
            btnSection6Man.BackColor = Color.Silver;
            btnSection7Man.BackColor = Color.Silver;
            btnSection8Man.BackColor = Color.Silver;
            btnSection9Man.BackColor = Color.Silver;
            btnSection10Man.BackColor = Color.Silver;
            btnSection11Man.BackColor = Color.Silver;
            btnSection12Man.BackColor = Color.Silver;

            //job is closed
            isJobStarted = false;

            //clear the section lists
            for (int j = 0; j < MAXSECTIONS; j++)
            {
                //clean out the lists
                section[j].patchList?.Clear();
                section[j].triangleList?.Clear();
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
            isAutoSteerBtnOn = false;

            btnCurve.Enabled = false;
            curve.isCurveSet = false;

            ct.isContourBtnOn = false;
            ct.isContourOn = false;

            //curve line
            btnCurve.Image = Properties.Resources.CurveOff;
            curve.ResetCurveLine();
            curve.isCurveBtnOn = false;
            btnCurve.Enabled = false;

            //change images to reflect on off
            btnABLine.Image = Properties.Resources.ABLineOff;

            DisableYouTurnButtons();

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
            boundz.ResetBoundary();

            //reset headland
            hl.ResetHeadland();

            //update the menu
            fieldToolStripMenuItem.Text = gStr.gsStartNewField;

            //turn off top level buttons
            btnRightYouTurn.Enabled = false;
            btnLeftYouTurn.Enabled = false;

            //auto YouTurn shutdown
            yt.isYouTurnBtnOn = false;
            yt.ResetYouTurnAndSequenceEvents();
            youTurnProgressBar = 0;

            //turn off youturn...
            btnEnableAutoYouTurn.Enabled = false;
            yt.isYouTurnBtnOn = false;
            btnEnableAutoYouTurn.Image = Properties.Resources.YouTurnNo;

            ////turn off path record
            recPath.recList.Clear();
            if (recPath.isRecordOn)
            {
                recPath.isRecordOn = false;
                btnRecPathPauseRecord.Image = Properties.Resources.boundaryPause;
            }

            //reset all Port Module values
            mc.ResetAllModuleCommValues();

            //reset all Dew loop stuff
            yt.dew2Index = 0;
            yt.isDew2Set = false;
            yt.isDew4Set = false;
            yt.dew4Index = 0;
            yt.ResetYouTurnAndSequenceEvents();
            mc.autoSteerData[mc.sdYouTurnByte] = 0;
            mc.relayRateData[mc.rdYouTurnControlByte] = 0;
        }

        //bring up field dialog for new/open/resume
        private void JobNewOpenResume()
        {
            //bring up dialog if no job active, close job if one is

            if (!isJobStarted)
            {
                if (stripOnlineGPS.Value == 1)
                {
                    var form = new FormTimedMessage(3000, gStr.gsNoGPS, gStr.gsIsGPSOff);
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
                }
            }
        }

        //Does the logic to process section on off requests
        private void ProcessSectionOnOffRequests()
        {
            //if (pn.speed > 0.2)
            {
                for (int j = 0; j < vehicle.numOfSections + 1; j++)
                {
                    //Turn ON
                    //if requested to be on, set the timer to Max 10 (1 seconds) = 10 frames per second
                    if (section[j].sectionOnRequest && !section[j].sectionOnOffCycle)
                    {
                        section[j].sectionOnTimer = (int)(pn.speed * vehicle.toolLookAhead) + 1;
                        if (section[j].sectionOnTimer > fixUpdateHz + 3) section[j].sectionOnTimer = fixUpdateHz + 3;
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

        //called by you turn class to set control byte, click auto man buttons
        public void DoYouTurnSequenceEvent(int function, int action)
        {
            switch (function)
            {
                case 0: //should not be here - it means no function at all
                    TimedMessageBox(2000, "ID 0 ??????", "YouTurn fucked up");
                    break;

                case 1: //Manual button
                    if (action == 0) //turn auto off
                    {
                        if (manualBtnState != btnStates.Off)
                        {
                            btnManualOffOn.PerformClick();
                        }
                    }
                    else
                    {
                        if (manualBtnState != btnStates.On)
                        {
                            btnManualOffOn.PerformClick();
                        }
                    }
                    break;

                case 2: //Auto Button
                    if (action == 0) //turn auto off
                    {
                        if (autoBtnState != btnStates.Off)
                        {
                            btnSectionOffAutoOn.PerformClick();
                        }
                    }
                    else
                    {
                        if (autoBtnState != btnStates.Auto)
                        {
                            btnSectionOffAutoOn.PerformClick();
                        }
                    }
                    break;

                case 3: //Relay 1
                    if (action == 0)
                    {
                        TimedMessageBox(1000, yt.pos3, "Turn Off");
                        mc.relayRateData[mc.rdYouTurnControlByte] &= 0b11111110;
                    }
                    else
                    {
                        TimedMessageBox(1000, yt.pos3, "Turn On");
                        mc.relayRateData[mc.rdYouTurnControlByte] |= 0b00000001;
                    }
                    break;

                case 4: //Relay 2
                    if (action == 0)
                    {
                        TimedMessageBox(1000, yt.pos4, "Turn Off");
                        mc.relayRateData[mc.rdYouTurnControlByte] &= 0b11111101;
                    }
                    else
                    {
                        TimedMessageBox(1000, yt.pos4, "Turn On");
                        mc.relayRateData[mc.rdYouTurnControlByte] |= 0b00000010;
                    }
                    break;

                case 5: //Relay 3
                    if (action == 0)
                    {
                        TimedMessageBox(1000, yt.pos5, "Turn Off");
                        mc.relayRateData[mc.rdYouTurnControlByte] &= 0b11111011;
                    }
                    else
                    {
                        TimedMessageBox(1000, yt.pos5, "Turn On");
                        mc.relayRateData[mc.rdYouTurnControlByte] |= 0b00000100;
                    }
                    break;

                case 6: //Relay 4
                    if (action == 0)
                    {
                        TimedMessageBox(1000, yt.pos6, "Turn Off");
                        mc.relayRateData[mc.rdYouTurnControlByte] &= 0b11110111;
                    }
                    else
                    {
                        TimedMessageBox(1000, yt.pos6, "Turn On");
                        mc.relayRateData[mc.rdYouTurnControlByte] |= 0b00001000;
                    }
                    break;

                case 7: //Relay 5
                    if (action == 0)
                    {
                        TimedMessageBox(1000, yt.pos7, "Turn Off");
                        mc.relayRateData[mc.rdYouTurnControlByte] &= 0b11101111;
                    }
                    else
                    {
                        TimedMessageBox(1000, yt.pos7, "Turn On");
                        mc.relayRateData[mc.rdYouTurnControlByte] |= 0b00010000;
                    }
                    break;

                case 8: //Relay 6
                    if (action == 0)
                    {
                        TimedMessageBox(1000, yt.pos8, "Turn Off");
                        mc.relayRateData[mc.rdYouTurnControlByte] &= 0b11011111;
                    }
                    else
                    {
                        TimedMessageBox(1000, yt.pos8, "Turn On");
                        mc.relayRateData[mc.rdYouTurnControlByte] |= 0b00100000;
                    }
                    break;
            }

            //load the autosteer youturn byte also.
            mc.autoSteerData[mc.sdYouTurnByte] = mc.relayRateData[mc.rdYouTurnControlByte];
        }

        //take the distance from object and convert to camera data
        private void SetZoom()
        {
            //match grid to cam distance and redo perspective
            if (camera.camSetDistance <= -20000) camera.gridZoom = 2000;
            if (camera.camSetDistance >= -20000 && camera.camSetDistance < -10000) camera.gridZoom = 2000;
            if (camera.camSetDistance >= -10000 && camera.camSetDistance < -5000) camera.gridZoom = 1000;
            if (camera.camSetDistance >= -5000 && camera.camSetDistance < -2000) camera.gridZoom = 503;
            if (camera.camSetDistance >= -2000 && camera.camSetDistance < -1000) camera.gridZoom = 201.2;
            if (camera.camSetDistance >= -1000 && camera.camSetDistance < -500) camera.gridZoom = 100.6;
            if (camera.camSetDistance >= -500 && camera.camSetDistance < -250) camera.gridZoom = 50.3;
            if (camera.camSetDistance >= -250 && camera.camSetDistance < -150) camera.gridZoom = 25.15;
            if (camera.camSetDistance >= -150 && camera.camSetDistance < -50) camera.gridZoom = 10.06;
            if (camera.camSetDistance >= -50 && camera.camSetDistance < -1) camera.gridZoom = 5.03;
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
            if (ct.isContourOn) ct.StopContourLine(pivotAxlePos);

            //turn off all the sections
            for (int j = 0; j < vehicle.numOfSections + 1; j++)
            {
                if (section[j].isSectionOn) section[j].TurnSectionOff();
                section[j].sectionOnOffCycle = false;
                section[j].sectionOffRequest = false;
            }

            //FileSaveHeadland();
            FileSaveOuterBoundary();
            FileSaveSections();
            FileSaveContour();
            FileSaveFlagsKML();
            FileSaveRecPath();

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

        //message box pops up with info then goes away
        public void TimedMessageBox(int timeout, string s1, string s2)
        {
            var form = new FormTimedMessage(timeout, s1, s2);
            form.Show();
        }

        //pinch and rotate screen
    }//class FormGPS
}//namespace AgOpenGPS

/*The order is:
 *
 * The watchdog timer times out and runs this function tmrWatchdog_tick().
 * 50 times per second so statusUpdateCounter counts to 25 and updates strip menu etc at 2 hz
 * it also makes sure there is new sentences showing up otherwise it shows **** No GGA....
 * saveCounter ticks 2 x per second, used at end of draw routine every minute to save a backup of field
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
 * If field needs saving (1.5 minute since last time) field is saved
 * Now the program is "Done" and waits for the next watchdog trigger, determines if a new sentence is available etc
 * and starts all over from the top.
 */