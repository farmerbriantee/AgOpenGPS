//Please, if you use this, share the improvements

using AgOpenGPS.Properties;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
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

        //How many boundaries allowed
        public const int MAXBOUNDARIES = 6;

        //How many headlands allowed
        public const int MAXHEADS = 6;

        //The base directory where AgOpenGPS will be stored and fields and vehicles branch from
        public string baseDirectory;

        //current directory of vehicle
        public string vehiclesDirectory, vehiclefileName = "";

        //current fields and field directory
        public string fieldsDirectory, currentFieldDirectory;

        private bool leftMouseDownOnOpenGL = false; //mousedown event in opengl window
        private int flagNumberPicked = 0;

        //bool for whether or not a job is active
        public bool isJobStarted = false, isAreaOnRight = true, isAutoSteerBtnOn, isLidarBtnOn = true;

        //if we are saving a file
        public bool isSavingFile = false, isLogNMEA = false, isLogElevation = false;

        //texture holders
        public uint[] texture = new uint[5];

        //create instance of a stopwatch for timing of frames and NMEA hz determination
        private readonly Stopwatch swFrame = new Stopwatch();

        //Time to do fix position update and draw routine
        private double frameTime = 0;

        //create instance of a stopwatch for timing of frames and NMEA hz determination
        private readonly Stopwatch swHz = new Stopwatch();

        //Time to do fix position update and draw routine
        private double HzTime = 5;

        //For field saving in background
        private int saveCounter = 1;

        //for the NTRIP CLient counting
        private int ntripCounter = 10;

        //whether or not to use Stanley control
        public bool isStanleyUsed = true;

        //used to update the screen status bar etc
        private int displayUpdateHalfSecondCounter = 0, displayUpdateOneSecondCounter = 0, displayUpdateOneFifthCounter = 0, displayUpdateThreeSecondCounter = 0;

        private int threeSecondCounter = 0, threeSeconds = 0;
        private int oneSecondCounter = 0, oneSecond = 0;
        private int oneHalfSecondCounter = 0, oneHalfSecond = 0;
        private int oneFifthSecondCounter = 0, oneFifthSecond = 0;

        public int pbarSteer, pbarRelay, pbarUDP;

        public double nudNumber = 0;

        //used by filePicker Form to return picked file and directory
        public string filePickerFileAndDirectory;

        //private int fiveSecondCounter = 0, fiveSeconds = 0;

        //the autoManual drive button. Assume in Auto
        public bool isInAutoDrive = true;

        /// <summary>
        /// create the scene camera
        /// </summary>
        public CCamera camera = new CCamera();

        /// <summary>
        /// create world grid
        /// </summary>
        public CWorldGrid worldGrid;

        /// <summary>
        /// The NMEA class that decodes it
        /// </summary>
        public CNMEA pn;

        /// <summary>
        /// an array of sections, so far 16 section + 1 fullWidth Section
        /// </summary>
        public CSection[] section;

        /// <summary>
        /// AB Line object
        /// </summary>
        public CABLine ABLine;

        /// <summary>
        /// TramLine class for boundary and settings
        /// </summary>
        public CTram tram;

        /// <summary>
        /// The grid for collision Avoidance
        /// </summary>
        public CMazeGrid mazeGrid;

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
        /// Our vehicle including the tool
        /// </summary>
        public CVehicle vehicle;

        /// <summary>
        /// All the structs for recv and send of information out ports
        /// </summary>
        public CModuleComm mc;

        /// <summary>
        /// The boundary object
        /// </summary>
        public CBoundary bnd;

        /// <summary>
        /// The boundary object
        /// </summary>
        public CTurn turn;

        /// <summary>
        /// The headland created
        /// </summary>
        //public CHeadland hl;

        /// <summary>
        /// array of headlands
        /// </summary>
        //public CHeadlandLines[] hlArr;

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
        /// Most of the displayed field data for GUI
        /// </summary>
        public CFieldData fd;

        /// <summary>
        /// GeoFence around everything you cannot cross
        /// </summary>
        public CGeoFence gf;

        /// <summary>
        /// Class containing workswitch functionality
        /// </summary>
        public CWorkSwitch workSwitch;

        /// <summary>
        /// Sound for approaching boundary
        /// </summary>
        public SoundPlayer sndBoundaryAlarm;

        /// <summary>
        /// The font class
        /// </summary>
        public CFont font;


        #endregion // Class Props and instances

        // Constructor, Initializes a new instance of the "FormGPS" class.
        public FormGPS()
        {
            //winform initialization
            InitializeComponent();

            //btnManualAutoDrive.Text = gStr.gsAbout;

            //ControlExtension.Draggable(panelSnap, true);
            ControlExtension.Draggable(oglZoom, true);
            ControlExtension.Draggable(panelSim, true);

            //file menu
            //fileToolStripMenuItem.Text = gStr.gsFile;
            setWorkingDirectoryToolStripMenuItem.Text = gStr.gsDirectories;
            enterSimCoordsToolStripMenuItem.Text = gStr.gsEnterSimCoords;
            loadVehicleToolStripMenuItem.Text = gStr.gsLoadVehicle;
            saveVehicleToolStripMenuItem.Text = gStr.gsSaveVehicle;
            fieldToolStripMenuItem.Text = gStr.gsField;
            aboutToolStripMenuItem.Text = gStr.gsAbout;
            shortcutKeysToolStripMenuItem.Text = gStr.gsShortcutKeys;
            menustripLanguage.Text = gStr.gsLanguage;

            //Display Menu
            //settingsToolStripMenuItem.Text = gStr.gsDisplay;
            resetALLToolStripMenuItem.Text = gStr.gsResetAll;
            colorsToolStripMenuItem.Text = gStr.gsColors;
            toolStripUnitsMenu.Text = gStr.gsUnits;
            sideGuideLines.Text = gStr.gsExtraGuides;
            gridToolStripMenuItem.Text = gStr.gsGridOn;
            lightbarToolStripMenuItem.Text = gStr.gsLightbarOn;
            logNMEAMenuItem.Text = gStr.gsLogNMEA;
            polygonsToolStripMenuItem.Text = gStr.gsPolygonsOn;
            pursuitLineToolStripMenuItem.Text = gStr.gsPursuitLine;
            skyToolStripMenu.Text = gStr.gsSkyOn;
            simulatorOnToolStripMenuItem.Text = gStr.gsSimulatorOn;
            metricToolStrip.Text = gStr.gsMetric;
            imperialToolStrip.Text = gStr.gsImperial;
            sectionToolStripMenuItem.Text = gStr.gsSection;
            fieldToolStripMenuItem.Text = gStr.gsField;

            //Settings Menu
            toolstripYouTurnConfig.Text = gStr.gsUTurn;
            toolstripAutoSteerConfig.Text = gStr.gsAutoSteer;
            toolStripAutoSteerChart.Text = gStr.gsSteerChart;
            toolstripVehicleConfig.Text = gStr.gsVehicle;
            toolstripDisplayConfig.Text = gStr.gsHeadingRoll;
            toolstripUSBPortsConfig.Text = gStr.gsSerialPorts;
            toolstripUDPConfig.Text = gStr.gsUDP;
            toolStripNTRIPConfig.Text = gStr.gsNTRIP;

            //Tools Menu
            treePlantToolStrip.Text = gStr.gsTreePlanter;
            SmoothABtoolStripMenu.Text = gStr.gsSmoothABCurve;
            toolStripBtnMakeBndContour.Text = gStr.gsMakeBoundaryContours;
            deleteContourPathsToolStripMenuItem.Text = gStr.gsDeleteContourPaths;
            toolStripDeleteApplied.Text = gStr.gsDeleteAppliedArea;
            toolStripAreYouSure.Text = gStr.gsAreYouSure;
            webcamToolStrip.Text = gStr.gsWebCam;

            //Recorded Path
            deletePathMenu.Text = gStr.gsDeletePath;
            recordPathMenu.Text = gStr.gsRecordStop;
            goPathMenu.Text = gStr.gsGoStop;
            pausePathMenu.Text = gStr.gsPauseResume;

            //NTRIP
            this.lblWatch.Text = gStr.gsWaitingForGPS;
            this.lblNTRIPSeconds.Text = gStr.gsNTRIPOff;


            //build the gesture structures
            SetupStructSizes();

            //create the world grid
            worldGrid = new CWorldGrid(this);

            //our vehicle made with gl object and pointer of mainform
            vehicle = new CVehicle(this);

            //create a new section and set left and right positions
            //created whether used or not, saves restarting program
            section = new CSection[MAXSECTIONS];
            for (int j = 0; j < MAXSECTIONS; j++) section[j] = new CSection(this);

            //our NMEA parser
            pn = new CNMEA(this);

            //create the ABLine instance
            ABLine = new CABLine(this);

            //new instance of contour mode
            ct = new CContour(this);

            //new instance of contour mode
            curve = new CABCurve(this);

            //instance of tram
            tram = new CTram(this);

            //new instance of auto headland turn
            yt = new CYouTurn(this);

            //module communication
            mc = new CModuleComm(this);

            //boundary object
            bnd = new CBoundary(this);

            //Turn object
            turn = new CTurn(this);

            //GeoFence
            gf = new CGeoFence(this);

            ////headland object
            //hl = new CHeadland(gl, this);

            ////headlands array
            //hlArr = new CHeadlandLines[MAXHEADS];
            //for (int j = 0; j < MAXHEADS; j++) hlArr[j] = new CHeadlandLines(gl, this);

            //headland entry/exit sequences
            seq = new CSequence(this);

            //nmea simulator built in.
            sim = new CSim(this);

            //all the autosteer objects
            ast = new CAutoSteer(this);

            //all the attitude, heading, roll, pitch reference system
            ahrs = new CAHRS(this);

            //A recorded path
            recPath = new CRecordedPath(this);

            //fieldData all in one place
            fd = new CFieldData(this);

            //The grid for obstacle avoidance
            mazeGrid = new CMazeGrid(this);

            //start the stopwatch
            swFrame.Start();

            //resource for gloabal language strings
            _rm = new ResourceManager("AgOpenGPS.gStr", Assembly.GetExecutingAssembly());

            // Add Message Event handler for Form decoupling from client socket thread
            updateRTCM_DataEvent = new UpdateRTCM_Data(OnAddMessage);

            // Access to workswitch functionality
            workSwitch = new CWorkSwitch(this);

            //access to font class
            font = new CFont(this);
        }

        private void ZoomByMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (camera.zoomValue <= 20) camera.zoomValue += camera.zoomValue * 0.02;
                else camera.zoomValue += camera.zoomValue * 0.01;
                if (camera.zoomValue > 120) camera.zoomValue = 120;
                camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
                SetZoom();
            }
            else
            {
                if (camera.zoomValue <= 20)
                { if ((camera.zoomValue -= camera.zoomValue * 0.02) < 6.0) camera.zoomValue = 6.0; }
                else { if ((camera.zoomValue -= camera.zoomValue * 0.01) < 6.0) camera.zoomValue = 6.0; }

                camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
                SetZoom();
            }
        }

        //Initialize items before the form Loads or is visible
        private void FormGPS_Load(object sender, EventArgs e)
        {
            this.MouseWheel += ZoomByMouseWheel;

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

            string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string wave = Path.Combine(directoryName, "Dependencies\\Audio", "Boundary.Wav");
            if (File.Exists(wave))
            {
                 sndBoundaryAlarm = new SoundPlayer(wave);
            }
            else
            {
                 sndBoundaryAlarm = new SoundPlayer(Properties.Resources.Alarm10);
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

            if (sp.IsOpen)
            {
                simulatorOnToolStripMenuItem.Checked = false;
                panelSim.Visible = false;
                timerSim.Enabled = false;

                Settings.Default.setMenu_isSimulatorOn = simulatorOnToolStripMenuItem.Checked;
                Settings.Default.Save();
            }

            //same for SectionRelay port
            portNameRelaySection = Settings.Default.setPort_portNameRelay;
            wasRateRelayConnectedLastRun = Settings.Default.setPort_wasRelayConnected;
            if (wasRateRelayConnectedLastRun) SerialPortRelayOpen();

            //same for AutoSteer port
            portNameAutoSteer = Settings.Default.setPort_portNameAutoSteer;
            wasAutoSteerConnectedLastRun = Settings.Default.setPort_wasAutoSteerConnected;
            if (wasAutoSteerConnectedLastRun) SerialPortAutoSteerOpen();

            //Set width of section and positions for each section
            SectionSetPosition();

            //Calculate total width and each section width
            SectionCalcWidths();

            //set the correct zoom and grid
            camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
            SetZoom();

            //which heading source is being used
            headingFromSource = Settings.Default.setGPS_headingFromWhichSource;

            //triangle resolution is how far to next triangle point trigger distance
            //triangleResolution = Settings.Default.setDisplay_triangleResolution;

            //start udp server if required
            if (Properties.Settings.Default.setUDP_isOn) StartUDPServer();

            //start NTRIP if required
            if (Properties.Settings.Default.setNTRIP_isOn)
            {
                isNTRIP_RequiredOn = true;
                btnStartStopNtrip.Text = gStr.gsStop;
            }
            else
            {
                isNTRIP_RequiredOn = false;
                btnStartStopNtrip.Text = gStr.gsStart;
            }

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
            mc.isWorkSwitchManual = Settings.Default.setF_IsWorkSwitchManual;

            minFixStepDist = Settings.Default.setF_minFixStep;

            fd.workedAreaTotalUser = Settings.Default.setF_UserTotalArea;
            fd.userSquareMetersAlarm = Settings.Default.setF_UserTripAlarm;

            //space between points while recording a boundary
            //boundaryTriggerDistance = Settings.Default.setF_boundaryTriggerDistance;

            //load the last used auto turn shape
            string fileAndDir = @".\Dependencies\YouTurnShapes\" + Properties.Settings.Default.setAS_youTurnShape;
            yt.LoadYouTurnShapeFromFile(fileAndDir);

            //sim.latitude = Settings.Default.setSim_lastLat;
            //sim.longitude = Settings.Default.setSim_lastLong;

            //load th elightbar resolution
            lightbarCmPerPixel = Properties.Settings.Default.setDisplay_lightbarCmPerPixel;

            // load all the gui elements in gui.designer.cs
            LoadGUI();

            //Stanley guidance
            isStanleyUsed = Properties.Vehicle.Default.setVehicle_isStanleyUsed;
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
                        isUDPSendConnected = false;
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
            Settings.Default.setF_UserTotalArea = fd.workedAreaTotalUser;
            Settings.Default.setF_UserTripAlarm = fd.userSquareMetersAlarm;

            //Settings.Default.setDisplay_panelSnapLocation = panelSnap.Location;
            Settings.Default.setDisplay_panelSimLocation = panelSim.Location;


            Settings.Default.Save();
        }

        //called everytime window is resized, clean up button positions
        private void FormGPS_Resize(object sender, EventArgs e)
        {
            LineUpManualBtns();
            FixPanelsAndMenus();
        }

        // Procedures and Functions ---------------------------------------

        public uint LoadGLTextures()
        {
            GL.Enable(EnableCap.Texture2D);
            try
            {
                string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string text = Path.Combine(directoryName, "Dependencies\\images", "Landscape.png");
                if (File.Exists(text))
                {
                    using (Bitmap bitmap = new Bitmap(text))
                    {
                        GL.GenTextures(1, out texture[0]);
                        GL.BindTexture(TextureTarget.Texture2D, texture[0]);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
                        BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                        bitmap.UnlockBits(bitmapData);
                    }
                }
            }
            catch (Exception ex)
            {
                //WriteErrorLog("Loading Landscape Textures" + ex);
                MessageBox.Show("Texture File LANDSCAPE.PNG is Missing", ex.Message);
            }

            try
            {
                string text2 = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Dependencies\\Images", "Floor.png");
                if (File.Exists(text2))
                {
                    using (Bitmap bitmap2 = new Bitmap(text2))
                    {
                        GL.GenTextures(1, out texture[1]);
                        GL.BindTexture(TextureTarget.Texture2D, texture[1]);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
                        BitmapData bitmapData2 = bitmap2.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData2.Width, bitmapData2.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData2.Scan0);
                        bitmap2.UnlockBits(bitmapData2);
                    }
                }
            }
            catch (Exception ex2)
            {
                //WriteErrorLog("Loading Floor Texture" + ex2);
                MessageBox.Show("Texture File FLOOR.PNG is Missing", ex2.Message);
            }

            try
            {
                string text2 = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Dependencies\\Images", "Font.png");
                if (File.Exists(text2))
                {
                    using (Bitmap bitmap = new Bitmap(text2))
                    {
                        GL.GenTextures(1, out texture[2]);
                        GL.BindTexture(TextureTarget.Texture2D, texture[2]);
                        BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmap.Width, bitmap.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                        bitmap.UnlockBits(data);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
                        
                        font.textureWidth = bitmap.Width; font.textureHeight = bitmap.Height;
                    }
                }
            }
            catch (Exception ex2)
            {
                //WriteErrorLog("Loading Floor Texture" + ex2);
                MessageBox.Show("Texture File Font.PNG is Missing", ex2.Message);
            }

            try
            {
                string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string text = Path.Combine(directoryName, "Dependencies\\images", "Turn.png");
                if (File.Exists(text))
                {
                    using (Bitmap bitmap = new Bitmap(text))
                    {
                        GL.GenTextures(1, out texture[3]);
                        GL.BindTexture(TextureTarget.Texture2D, texture[3]);
                        BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmap.Width, bitmap.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                        bitmap.UnlockBits(data);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
                    }
                }
            }
            catch (Exception ex)
            {
                //WriteErrorLog("Loading Landscape Textures" + ex);
                MessageBox.Show("Texture File TURN.PNG is Missing", ex.Message);
            }


            //return array of textures
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

                // Initialise the IPEndPoint for the server to send on port 9998
                IPEndPoint server = new IPEndPoint(IPAddress.Any, 9998);
                sendSocket.Bind(server);

                // Initialise the IPEndPoint for the client - async listner client only!
                EndPoint client = new IPEndPoint(IPAddress.Any, 0);

                // Start listening for incoming data
                recvSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None,
                                                ref client, new AsyncCallback(ReceiveData), recvSocket);
                isUDPSendConnected = true;
            }
            catch (Exception e)
            {
                WriteErrorLog("UDP Server" + e);
                MessageBox.Show("Load Error: " + e.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void boundariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            else { TimedMessageBox(3000, gStr.gsFieldNotOpen, gStr.gsStartNewField); }

        }

        private void toolStripBtnMakeBndContour_Click_1(object sender, EventArgs e)
        {
            //build all the contour guidance lines from boundaries, all of them. 
            using (var form = new FormMakeBndCon(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }

        private void deleteContourPathsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //FileCreateContour();
            ct.stripList?.Clear();
            ct.ptList?.Clear();
            ct.ctList?.Clear();
            contourSaveList?.Clear();
        }

        private void fileExplorerToolStripItem_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                FileSaveFlagsKML();
            }
            Process.Start(fieldsDirectory + currentFieldDirectory);
        }

        private void toolStripDeleteApplied_Click(object sender, EventArgs e)
        {
            //FileCreateContour();
            ct.stripList?.Clear();
            ct.ptList?.Clear();
            ct.ctList?.Clear();
            contourSaveList?.Clear();
        }

        private void toolStripAreYouSure_Click_1(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                DialogResult result3 = MessageBox.Show(gStr.gsDeleteAllContoursAndSections,
                    gStr.gsDeleteForSure,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (result3 == DialogResult.Yes)
                {
                    FileCreateContour();
                    FileCreateSections();
                    //FileCreateElevation();

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

                    //clear out the contour Lists
                    ct.StopContourLine(pivotAxlePos);
                    ct.ResetContour();
                    fd.workedAreaTotal = 0;

                    //clear the section lists
                    for (int j = 0; j < MAXSECTIONS; j++)
                    {
                        //clean out the lists
                        section[j].patchList?.Clear();
                        section[j].triangleList?.Clear();
                    }
                    patchSaveList?.Clear();

                }
                else TimedMessageBox(1500, gStr.gsNothingDeleted, gStr.gsActionHasBeenCancelled);
            }
        }

        private void boundaryToolStripBtn_Click(object sender, EventArgs e)
        {
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
            else { TimedMessageBox(3000, gStr.gsFieldNotOpen, gStr.gsStartNewField); }
        }

        private void toolStripBtnField_Click(object sender, EventArgs e)
        {
            JobNewOpenResume();
        }

        private void SmoothABtoolStripMenu_Click(object sender, EventArgs e)
        {
            if (isJobStarted && curve.isBtnCurveOn)
            {
                using (var form = new FormSmoothAB(this))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK) { }
                }
            }

            else
            {
                if (!isJobStarted) TimedMessageBox(2000, gStr.gsFieldNotOpen, gStr.gsStartNewField);
                else TimedMessageBox(2000, gStr.gsCurveNotOn, gStr.gsTurnABCurveOn);
            }
        }

        private void toolstripDisplayConfig_Click_1(object sender, EventArgs e)
        {
            using (var form = new FormIMU(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }

            if (Properties.Settings.Default.setAS_isAutoSteerAutoOn) btnAutoSteer.Text = "A";
            else btnAutoSteer.Text = "M";
        }

        private void toolstripUSBPortsConfig_Click_1(object sender, EventArgs e)
        {
            SettingsCommunications();
        }

        private void toolstripUDPConfig_Click_1(object sender, EventArgs e)
        {
            SettingsUDP();
        }

        private void toolStripNTRIPConfig_Click_1(object sender, EventArgs e)
        {
            SettingsNTRIP();
        }

        private void toolstripVehicleConfig_Click_1(object sender, EventArgs e)
        {
            using (var form = new FormSettings(this, 0))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (Properties.Settings.Default.setAS_isAutoSteerAutoOn) btnAutoSteer.Text = "A";
                    else btnAutoSteer.Text = "M";
                }
            }

        }

        private void toolstripYouTurnConfig_Click_1(object sender, EventArgs e)
        {
            var form = new FormYouTurn(this);
            form.ShowDialog();
            cboxpRowWidth.SelectedIndex = yt.rowSkipsWidth - 1;

        }

        private void toolstripAutoSteerConfig_Click_1(object sender, EventArgs e)
        {
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

        private void toolStripAutoSteerChart_Click_1(object sender, EventArgs e)
        {
            //check if window already exists
            Form fcg = Application.OpenForms["FormSteerGraph"];

            if (fcg != null)
            {
                fcg.Focus();
                return;
            }

            //
            Form formG = new FormSteerGraph(this);
            formG.Show();

        }


        private void twoDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camera.camFollowing = true;
            camera.camPitch = 0;

        }

        private void threeDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camera.camFollowing = true;
            camera.camPitch = -75;

        }

        private void northToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camera.camFollowing = false;
        }

        private void toolStripDropDownButtonDistance_Click(object sender, EventArgs e)
        {
            fd.distanceUser = 0;
            fd.workedAreaTotalUser = 0;
        }

        private void toolStripBatman_Click_1(object sender, EventArgs e)
        {
            //if (secondRowCounter < 8) return;
            Properties.Settings.Default.setDisplay_isBatmanOn = !Properties.Settings.Default.setDisplay_isBatmanOn;
            Properties.Settings.Default.Save();
            SwapBatmanPanels();

            //if (panelBatman.Visible)
            //{
            //    //if (panelSim.Left < 260) panelSim.Left = 260;
            //    //if (panelSnap.Left < 260) panelSnap.Left = 260;
            //}
        }


        private void toolStripBtnPower_ButtonClick(object sender, EventArgs e)
        {
            DialogResult result3 = MessageBox.Show(gStr.gsOff,
                                gStr.gsWaiting,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
            if (result3 == DialogResult.Yes) Close();
        }

        private void btnSaveAB_Click(object sender, EventArgs e)
        {
            panelEditAB.Visible = false;
            if (ABLine.isBtnABLineOn)
            {
                //index to last one. 
                int idx = ABLine.numABLineSelected - 1;

                if (idx >= 0)
                {

                    ABLine.lineArr[idx].heading = ABLine.abHeading;
                    //calculate the new points for the reference line and points
                    ABLine.lineArr[idx].origin.easting = ABLine.refPoint1.easting;
                    ABLine.lineArr[idx].origin.northing = ABLine.refPoint1.northing;

                    //sin x cos z for endpoints, opposite for additional lines
                    ABLine.lineArr[idx].ref1.easting = ABLine.lineArr[idx].origin.easting - (Math.Sin(ABLine.lineArr[idx].heading) * 2000.0);
                    ABLine.lineArr[idx].ref1.northing = ABLine.lineArr[idx].origin.northing - (Math.Cos(ABLine.lineArr[idx].heading) * 2000.0);
                    ABLine.lineArr[idx].ref2.easting = ABLine.lineArr[idx].origin.easting + (Math.Sin(ABLine.lineArr[idx].heading) * 2000.0);
                    ABLine.lineArr[idx].ref2.northing = ABLine.lineArr[idx].origin.northing + (Math.Cos(ABLine.lineArr[idx].heading) * 2000.0);
                }

                FileSaveABLines();
                ABLine.moveDistance = 0;
            }

            if (curve.isBtnCurveOn)
            {
                if (curve.refList.Count > 0)
                {
                    //array number is 1 less since it starts at zero
                    int idx = curve.numCurveLineSelected - 1;

                    //curve.curveArr[idx].Name = textBox1.Text.Trim();
                    if (idx >= 0)
                    {
                        curve.curveArr[idx].aveHeading = curve.aveLineHeading;
                        curve.curveArr[idx].curvePts.Clear();
                        //write out the Curve Points
                        foreach (var item in curve.refList)
                        {
                            curve.curveArr[idx].curvePts.Add(item);
                        }
                    }

                    //save entire list
                    FileSaveCurveLines();
                    curve.moveDistance = 0;
                }
            }
        }

        private void googleEarthFlagsToolStrip_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                //save new copy of flags
                FileSaveFlagsKML();

                //Process.Start(@"C:\Program Files (x86)\Google\Google Earth\client\googleearth", workingDirectory + currentFieldDirectory + "\\Flags.KML");
                Process.Start(fieldsDirectory + currentFieldDirectory + "\\Flags.KML");
            }
            else
            {
                var form = new FormTimedMessage(1500, gStr.gsFieldNotOpen, gStr.gsStartNewField);
                form.Show();
            }

        }

        private void treePlantToolStrip_Click(object sender, EventArgs e)
        {
            //check if window already exists
            Form fc = Application.OpenForms["FormTreePlant"];

            if (fc != null)
            {
                fc.Focus();
                return;
            }

            //
            Form form = new FormTreePlant(this);
            form.Show();

        }

        private void webcamToolStrip_Click(object sender, EventArgs e)
        {
            Form form = new FormWebCam();
            form.Show();

        }

        private void offsetFixToolStrip_Click(object sender, EventArgs e)
        {
            using (var form = new FormShiftPos(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }

        private void AutoSteerToolBtn_Click(object sender, EventArgs e)
        {
            //check if window already exists
            Form fc = Application.OpenForms["FormSteer"];

            if (fc != null)
            {
                fc.Focus();
                fc.Close();
                return;
            }

            //
            Form form = new FormSteer(this);
            form.Show();
        }

        private void vehicleToolStripBtn_Click(object sender, EventArgs e)
        {
            using (var form = new FormSettings(this, 0))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (Properties.Settings.Default.setAS_isAutoSteerAutoOn) btnAutoSteer.Text = "A";
                    else btnAutoSteer.Text = "M";
                }
            }
        }

        private void youTurnStripBtn_Click(object sender, EventArgs e)
        {
            var form = new FormYouTurn(this);
            form.ShowDialog();
            cboxpRowWidth.SelectedIndex = yt.rowSkipsWidth - 1;
        }

        private void toolStripBtnGPSStength_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormGPSData"];

            if (f != null)
            {
                f.Focus();
                f.Close();
                return;
            }

            Form form = new FormGPSData(this);
            form.Show();
        }

        private void btnABMenu_Click(object sender, EventArgs e)
        {
            if (ABLine.isBtnABLineOn || curve.isBtnCurveOn)
            {
                if (panelEditAB.Visible)
                    panelEditAB.Visible = false;
                else
                    panelEditAB.Visible = true;
            }
            else
            {
                    panelEditAB.Visible = false;
            }
        }

        private void btnEditAB_Click(object sender, EventArgs e)
        {
            panelEditAB.Visible = false;
            if (ABLine.numABLineSelected > 0 && ABLine.isBtnABLineOn)
            {

                Form form = new FormEditAB(this);
                form.Show();
            }

            else if (curve.numCurveLineSelected > 0 && curve.isBtnCurveOn)
            {
                Form form = new FormEditCurve(this);
                form.Show();
            }

            else
            {
                var form = new FormTimedMessage(1500, gStr.gsNoABLineActive, gStr.gsPleaseEnterABLine);
                return;
            }
        }

        private void btnTramMenu_Click(object sender, EventArgs e)
        {

            curve.isOkToAddPoints = false;
            panelEditAB.Visible = false;

            if (ct.isContourBtnOn) { if (ct.isContourBtnOn) btnContour.PerformClick(); }


            if (ABLine.numABLineSelected > 0 && ABLine.isBtnABLineOn)
            {
                //panelDrag.Visible = true;
                //panelDrag.Top = 80;
                //panelDrag.Left = 76;
                Form form99 = new FormTram(this);
                form99.Show();
                form99.Left = Width - 275;
                form99.Top = 100;

            }
            else if (curve.numCurveLineSelected > 0 && curve.isBtnCurveOn)
            {
                //panelDrag.Visible = true;
                //panelDrag.Top = 80;
                //panelDrag.Left = 76;
                Form form97 = new FormTramCurve(this);
                form97.Show();
                form97.Left = Width - 275;
                form97.Top = 100;
            }
            else
            {
                var form = new FormTimedMessage(1500, gStr.gsNoABLineActive, gStr.gsPleaseEnterABLine);
                form.Show();
                layoutPanelRight.Enabled = true;
                ABLine.isEditing = false;
                return;
            }
        }

        private void btnMoveDown_MouseDown(object sender, MouseEventArgs e)
        {
            offX += (Math.Sin(fixHeading) * 10);
            offY += (Math.Cos(fixHeading) * 10);
        }

        private void btnMoveUp_MouseDown(object sender, MouseEventArgs e)
        {
            offX -= (Math.Sin(fixHeading) * 10);
            offY -= (Math.Cos(fixHeading) * 10);
        }

        private void btnMoveLeft_MouseDown(object sender, MouseEventArgs e)
        {
            offY += (Math.Sin(-fixHeading) * 10);
            offX += (Math.Cos(-fixHeading) * 10);
        }

        private void btnMoveRight_MouseDown(object sender, MouseEventArgs e)
        {
            offY -= (Math.Sin(-fixHeading) * 10);
            offX -= (Math.Cos(-fixHeading) * 10);
        }

        private void btnMoveHome_Click(object sender, EventArgs e)
        {
            offX = 0;
            offY = 0;
        }

        private void toolStripBtnDrag_ButtonClick(object sender, EventArgs e)
        {
            if (panelDrag.Visible)
            {
                offX = 0;
                offY = 0;
                panelDrag.Visible = false;
            }
            else
            {
                panelDrag.Top = 80;
                panelDrag.Left = 76;
                panelDrag.Visible = true;
            }
        }               

        private void ZoomExtentsStripBtn_Click(object sender, EventArgs e)
        {
                if (camera.camSetDistance< -400) camera.camSetDistance = -75;
                else camera.camSetDistance = -3 * maxFieldDistance;
                if (camera.camSetDistance == 0) camera.camSetDistance = -2000;
                SetZoom();
        }

        private void FontToolBtn_Click(object sender, EventArgs e)
        {
            font.isFontOn = !font.isFontOn;
            if (font.isFontOn)
                FontToolBtn.Image = Properties.Resources.FontOn;
            else
                FontToolBtn.Image = Properties.Resources.FontOff;

        }

        private void topFieldViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isOGLZoomOn = !isOGLZoomOn;
            topFieldViewToolStripMenuItem.Checked = isOGLZoomOn;
            if (isOGLZoomOn)
            {
                oglZoom.Visible = true;
                oglZoom.Left = 80;
                oglZoom.Top = 80;
            }
            else oglZoom.Visible = false;

            Settings.Default.setDisplay_isOGLZoomOn = isOGLZoomOn;
            Settings.Default.Save();
        }

        private void oglMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point point = oglMain.PointToClient(Cursor.Position);
                if (point.Y < 120 && point.Y > 60)
                {
                    int middle = oglMain.Width / 2 + oglMain.Width /4;
                    if (point.X > middle - 60 && point.X < middle + 60)
                        SwapDirection();
                }
            }
        }
        public void SwapDirection()
        {
            if (!yt.isYouTurnTriggered)
            {
                //is it turning right already?
                if (yt.isYouTurnRight)
                {
                    yt.isYouTurnRight = false;
                    yt.isLastYouTurnRight = !yt.isLastYouTurnRight;
                    ResetTurnBtn();
                }
                else
                {
                    //make it turn the other way
                    yt.isYouTurnRight = true;
                    yt.isLastYouTurnRight = !yt.isLastYouTurnRight;
                    ResetTurnBtn();
                }
            }
        }

        private void BtnSaveFlag_Click(object sender, EventArgs e)
        {
            FileSaveFlagLog();
        }

        private void FileOpenFlagLog()
        {
            string fileAndD = fieldsDirectory + currentFieldDirectory + "\\Flag_" + (flagPts[flagNumberPicked - 1]).ID.ToString() + "_Log.rtf";
            if (File.Exists(fileAndD))
            {

                rtbFlag.LoadFile(fileAndD, RichTextBoxStreamType.PlainText);
            }
            else
            {
                rtbFlag.Text = "Flag Number " + (flagPts[flagNumberPicked - 1]).ID.ToString();
                rtbFlag.Text += "\r\n" + "Lat: " + (flagPts[flagNumberPicked - 1]).latitude.ToString();
                rtbFlag.Text += "\r\n" + "Long: " + (flagPts[flagNumberPicked - 1]).longitude.ToString();
             }

        }

        private void FileSaveFlagLog()
        {
            //rtbFlag.Text += "\r\n" + "Flag Last Saved";
            //rtbFlag.Text += "\r\n" + (DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss tt"));
            string fileAndD = fieldsDirectory + currentFieldDirectory + "\\Flag_" + (flagPts[flagNumberPicked - 1]).ID.ToString() + "_Log.rtf";
            rtbFlag.SaveFile(fileAndD, RichTextBoxStreamType.PlainText);

        }

        public void GetAB()
        {
            curve.isOkToAddPoints = false;

            if (ct.isContourBtnOn) { if (ct.isContourBtnOn) btnContour.PerformClick(); }


            using (var form = new FormABDraw(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                }
                ABLine.moveDistance = 0;
                curve.moveDistance = 0;
            }

            if (curve.isBtnCurveOn) btnCycleLines.Text = "Cu-" + curve.numCurveLineSelected;
            if (ABLine.isBtnABLineOn) btnCycleLines.Text = "AB-" + ABLine.numABLineSelected;
        }

        public void KeypadToNUD(NumericUpDown sender)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            nud.BackColor = System.Drawing.Color.Red;
            using (var form = new FormNumeric((double)nud.Minimum, (double)nud.Maximum, (double)nud.Value))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    nud.Value = (decimal)form.ReturnValue;
                }
            }
            nud.BackColor = System.Drawing.Color.AliceBlue;
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

        //show the UDP ethernet settings page
        private void SettingsNTRIP()
        {
            using (var form = new FormNtrip(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (isNTRIP_Connected)
                    {
                        SettingsShutDownNTRIP();
                    }
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
            //pn.latStart = pn.latitude;
            //pn.lonStart = pn.longitude;

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
            btnCurve.Enabled = true;
            btnMakeLinesFromBoundary.Enabled = true;
            btnCycleLines.Enabled = true;


            ABLine.abHeading = 0.00;
            btnAutoSteer.Enabled = true;

            DisableYouTurnButtons();
            btnFlag.Enabled = true;

            btnContourPriority.Image = Properties.Resources.Snap2;

            if (recPath.isRecordOn)
            {
                recPath.isRecordOn = false;
            }

            LineUpManualBtns();

            //update the menu
            fieldToolStripMenuItem.Text = gStr.gsCloseField;
            this.menustripLanguage.Enabled = false;
            layoutPanelRight.Enabled = true;
            boundaryToolStripBtn.Enabled = true;
            toolStripBtnDropDownBoundaryTools.Enabled = true;

        }

        //close the current job
        public void JobClose()
        {
            layoutPanelRight.Enabled = false;
            boundaryToolStripBtn.Enabled = false;
            toolStripBtnDropDownBoundaryTools.Enabled = false;

            menustripLanguage.Enabled = true;
            //job is closed
            isJobStarted = false;

            //reset the lat lon start pos
            pn.latStart = 0;
            pn.lonStart = 0;

            //turn section buttons all OFF
            for (int j = 0; j < MAXSECTIONS; j++)
            {
                section[j].isAllowedOn = false;
                section[j].manBtnState = manBtn.On;
            }

            //fix ManualOffOnAuto buttons
            btnManualOffOn.Enabled = false;
            manualBtnState = btnStates.Off;
            btnManualOffOn.Image = Properties.Resources.ManualOff;

            //fix auto button
            btnSectionOffAutoOn.Enabled = false;
            autoBtnState = btnStates.Off;
            btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOff;

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

            //clear the section lists
            for (int j = 0; j < MAXSECTIONS; j++)
            {
                //clean out the lists
                section[j].patchList?.Clear();
                section[j].triangleList?.Clear();
            }

            //clear the flags
            flagPts.Clear();
            btnFlag.Enabled = false;

            //ABLine
            btnABLine.Enabled = false;
            btnABLine.Image = Properties.Resources.ABLineOff;
            ABLine.isBtnABLineOn = false;
            ABLine.DeleteAB();
            ABLine.lineArr?.Clear();
            ABLine.numABLineSelected = 0;
            ABLine.tramArr?.Clear();
            ABLine.tramList?.Clear();


            //curve line
            btnCurve.Enabled = false;
            btnCurve.Image = Properties.Resources.CurveOff;
            curve.isBtnCurveOn = false;
            curve.isCurveSet = false;
            curve.ResetCurveLine();
            curve.curveArr?.Clear();
            curve.numCurveLineSelected = 0;
            curve.tramArr?.Clear();
            curve.tramList?.Clear();

            //clean up tram
            tram.displayMode = 0;
            tram.outArr?.Clear();

            //clear out contour and Lists
            btnContour.Enabled = false;
            //btnContourPriority.Enabled = false;
            btnContourPriority.Image = Properties.Resources.Snap2;
            ct.ResetContour();
            ct.isContourBtnOn = false;
            btnContour.Image = Properties.Resources.ContourOff;
            ct.isContourOn = false;

            btnMakeLinesFromBoundary.Enabled = false;
            btnCycleLines.Enabled = false;

            //AutoSteer
            btnAutoSteer.Enabled = false;
            isAutoSteerBtnOn = false;
            btnAutoSteer.Image = Properties.Resources.AutoSteerOff;

            //auto YouTurn shutdown
            yt.isYouTurnBtnOn = false;
            btnEnableAutoYouTurn.Image = Properties.Resources.YouTurnNo;
            btnEnableAutoYouTurn.Enabled = false;
            yt.ResetYouTurn();
            DisableYouTurnButtons();

            //reset acre and distance counters
            fd.workedAreaTotal = 0;

            //reset boundaries
            bnd.ResetBoundaries();

            //reset turn lines
            turn.ResetTurnLines();

            //reset GUI areas
            fd.UpdateFieldBoundaryGUIAreas();

            //reset headland
            //for (int i = 0; i < FormGPS.MAXHEADS; i++) hlArr[i].ResetHeadland();

            //update the menu
            fieldToolStripMenuItem.Text = gStr.gsStartNewField;

            ////turn off path record
            recPath.recList?.Clear();
            if (recPath.isRecordOn)
            {
                recPath.isRecordOn = false;
                recordPathMenu.Image = Properties.Resources.BoundaryRecord;
            }

            //reset all Port Module values
            mc.ResetAllModuleCommValues();
        }

        //bring up field dialog for new/open/resume
        private void JobNewOpenResume()
        {
            //bring up dialog if no job active, close job if one is
            if (!isJobStarted)
            {
                if (toolStripBtnGPSStength.Image.Height == 64)
                {
                    var form = new FormTimedMessage(3000, gStr.gsNoGPS, gStr.gsGPSSourceOff);
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

                if (isJobStarted)
                {
                    layoutPanelRight.Enabled = true;
                    boundaryToolStripBtn.Enabled = true;
                    toolStripBtnDropDownBoundaryTools.Enabled = true;
                }
                else
                {
                    layoutPanelRight.Enabled = false;
                    boundaryToolStripBtn.Enabled = false;
                    toolStripBtnDropDownBoundaryTools.Enabled = false;
                }
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
                        layoutPanelRight.Enabled = false;
                        boundaryToolStripBtn.Enabled = false;
                        toolStripBtnDropDownBoundaryTools.Enabled = false;
                        break;
                    //Ignore and return
                    case 1:
                        break;
                }
            }

            //update GUI areas
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
                        TimedMessageBox(1000, seq.pos3, gStr.gsTurnOff);
                        mc.machineControlData[mc.cnYouTurn] &= 0b11111110;
                    }
                    else
                    {
                        TimedMessageBox(1000, seq.pos3, gStr.gsTurnOn);
                        mc.machineControlData[mc.cnYouTurn] |= 0b00000001;
                    }
                    break;

                case 4: //Relay 2
                    if (action == 0)
                    {
                        TimedMessageBox(1000, seq.pos4, gStr.gsTurnOff);
                        mc.machineControlData[mc.cnYouTurn] &= 0b11111101;
                    }
                    else
                    {
                        TimedMessageBox(1000, seq.pos4, gStr.gsTurnOn);
                        mc.machineControlData[mc.cnYouTurn] |= 0b00000010;
                    }
                    break;

                case 5: //Relay 3
                    if (action == 0)
                    {
                        TimedMessageBox(1000, seq.pos5, gStr.gsTurnOff);
                        mc.machineControlData[mc.cnYouTurn] &= 0b11111011;
                    }
                    else
                    {
                        TimedMessageBox(1000, seq.pos5, gStr.gsTurnOn);
                        mc.machineControlData[mc.cnYouTurn] |= 0b00000100;
                    }
                    break;

                case 6: //Relay 4
                    if (action == 0)
                    {
                        TimedMessageBox(1000, seq.pos6, gStr.gsTurnOff);
                        mc.machineControlData[mc.cnYouTurn] &= 0b11110111;
                    }
                    else
                    {
                        TimedMessageBox(1000, seq.pos6, gStr.gsTurnOn);
                        mc.machineControlData[mc.cnYouTurn] |= 0b00001000;
                    }
                    break;

                case 7: //Relay 5
                    if (action == 0)
                    {
                        TimedMessageBox(1000, seq.pos7, gStr.gsTurnOff);
                        mc.machineControlData[mc.cnYouTurn] &= 0b11101111;
                    }
                    else
                    {
                        TimedMessageBox(1000, seq.pos7, gStr.gsTurnOn);
                        mc.machineControlData[mc.cnYouTurn] |= 0b00010000;
                    }
                    break;

                case 8: //Relay 6
                    if (action == 0)
                    {
                        TimedMessageBox(1000, seq.pos8, gStr.gsTurnOff);
                        mc.machineControlData[mc.cnYouTurn] &= 0b11011111;
                    }
                    else
                    {
                        TimedMessageBox(1000, seq.pos8, gStr.gsTurnOn);
                        mc.machineControlData[mc.cnYouTurn] |= 0b00100000;
                    }
                    break;
            }

            //load the autosteer youturn byte also.
            mc.autoSteerData[mc.sdYouTurnByte] = mc.machineControlData[mc.cnYouTurn];
        }


        //take the distance from object and convert to camera data
        public void SetZoom()
        {
            //match grid to cam distance and redo perspective
            if (camera.camSetDistance <= -20000) camera.gridZoom = 2000;
            else if (camera.camSetDistance >= -20000 && camera.camSetDistance < -10000) camera.gridZoom = 2012;
            else if (camera.camSetDistance >= -10000 && camera.camSetDistance < -5000) camera.gridZoom = 1006;
            else if (camera.camSetDistance >= -5000 && camera.camSetDistance < -2000) camera.gridZoom = 503;
            else if (camera.camSetDistance >= -2000 && camera.camSetDistance < -1000) camera.gridZoom = 201.2;
            else if (camera.camSetDistance >= -1000 && camera.camSetDistance < -500) camera.gridZoom = 100.6;
            else if (camera.camSetDistance >= -500 && camera.camSetDistance < -250) camera.gridZoom = 50.3;
            else if (camera.camSetDistance >= -250 && camera.camSetDistance < -150) camera.gridZoom = 25.15;
            else if (camera.camSetDistance >= -150 && camera.camSetDistance < -50) camera.gridZoom = 10.06;
            else if (camera.camSetDistance >= -50 && camera.camSetDistance < -1) camera.gridZoom = 5.03;
            //1.216 2.532

            oglMain.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView((float)fovy, oglMain.AspectRatio, 1f, (float)(camDistanceFactor * camera.camSetDistance));
            GL.LoadMatrix(ref mat);
            GL.MatrixMode(MatrixMode.Modelview);
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
            FileSaveBoundary();
            FileSaveSections();
            FileSaveContour();
            FileSaveFlagsKML();

            JobClose();
            Text = "AgOpenGPS";
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