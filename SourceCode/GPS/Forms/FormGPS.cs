//Please, if you use this, share the improvements

using AgOpenGPS.Properties;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
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

        //list of vec3 points of Dubins shortest path between 2 points - To be converted to RecPt
        public List<vec3> flagDubinsList = new List<vec3>();

        //maximum sections available
        private const int MAXSECTIONS = 17;

        //How many youturn functions
        public const int MAXFUNCTIONS = 8;

        //How many boundaries allowed
        public const int MAXBOUNDARIES = 6;

        //How many headlands allowed
        public const int MAXHEADS = 6;

        //The base directory where AgOpenGPS will be stored and fields and vehicles branch from
        public string baseDirectory;

        //current directory of vehicle
        public string vehiclesDirectory, vehicleFileName = "";

        //current directory of tools
        public string toolsDirectory, toolFileName = "";

        //current directory of Environments
        public string envDirectory, envFileName = "";

        //current fields and field directory
        public string fieldsDirectory, currentFieldDirectory;

        private bool leftMouseDownOnOpenGL; //mousedown event in opengl window
        public int flagNumberPicked = 0;

        //bool for whether or not a job is active
        public bool isJobStarted = false, isAutoSteerBtnOn, isLidarBtnOn = true;

        //if we are saving a file
        public bool isSavingFile = false, isLogNMEA = false, isLogElevation = false;

        //texture holders
        public uint[] texture = new uint[15];

        //the currentversion of software
        public string currentVersionStr, inoVersionStr;
        public int inoVersionInt;

        //create instance of a stopwatch for timing of frames and NMEA hz determination
        private readonly Stopwatch swFrame = new Stopwatch();

        //private readonly Stopwatch swDraw = new Stopwatch();
        //swDraw.Reset();
        //swDraw.Start();
        //swDraw.Stop();
        //label3.Text = ((double) swDraw.ElapsedTicks / (double) System.Diagnostics.Stopwatch.Frequency * 1000).ToString();

        //Time to do fix position update and draw routine
        private double frameTime = 0;

        //create instance of a stopwatch for timing of frames and NMEA hz determination
        private readonly Stopwatch swHz = new Stopwatch();

        //Time to do fix position update and draw routine
        private double HzTime = 5;

        //For field saving in background
        private int minuteCounter = 1;
        private int tenMinuteCounter = 1;

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

        public int pbarSteer, pbarMachine, pbarUDP;

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
        /// Our vehicle only
        /// </summary>
        public CVehicle vehicle;

        /// <summary>
        /// Just the tool attachment that includes the sections
        /// </summary>
        public CTool tool;
        
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
        public CHead hd;

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
        /// Most of the displayed field data for GUI
        /// </summary>
        public CFieldData fd;

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

            //ControlExtension.Draggable(panelSnap, true);
            ControlExtension.Draggable(oglZoom, true);
            //ControlExtension.Draggable(panelSim, true);

            setWorkingDirectoryToolStripMenuItem.Text = gStr.gsDirectories;
            enterSimCoordsToolStripMenuItem.Text = gStr.gsEnterSimCoords;
            topMenuLoadVehicle.Text = gStr.gsLoadVehicle;
            topMenuSaveVehicle.Text = gStr.gsSaveVehicle;
            aboutToolStripMenuItem.Text = gStr.gsAbout;
            shortcutKeysToolStripMenuItem.Text = gStr.gsShortcutKeys;
            menustripLanguage.Text = gStr.gsLanguage;
            topMenuLoadTool.Text = gStr.gsLoadTool;
            topMenuSaveTool.Text = gStr.gsSaveTool;
            topMenuLoadEnvironment.Text = gStr.gsLoadEnvironment;
            topMenuSaveEnvironment.Text = gStr.gsSaveEnvironment;
            gPSInfoToolStripMenuItem.Text = gStr.gsModuleInfo;
            showStartScreenToolStripMenuItem.Text = gStr.gsShowStartScreen;
            //Display Menu

            //settingsToolStripMenuItem.Text = gStr.gsDisplay;
            topMenuFileExplorer.Text = gStr.gsWindowsFileExplorer;
            optionsToolStripMenuItem.Text = gStr.gsOptions;

            simulatorOnToolStripMenuItem.Text = gStr.gsSimulatorOn;

            resetALLToolStripMenuItem.Text = gStr.gsResetAll;
            colorsToolStripMenuItem.Text = gStr.gsColors;
            lightbarToolStripMenuItem.Text = gStr.gsLightbarOn;
            topFieldViewToolStripMenuItem.Text = gStr.gsTopFieldView;
            toolToolStripMenu.Text = gStr.gsTool;

            resetEverythingToolStripMenuItem.Text = gStr.gsResetAllForSure;
            fileExplorerToolStripMenuItem.Text = gStr.gsWindowsFileExplorer;

            //Settings Menu
            toolstripYouTurnConfig.Text = gStr.gsUTurn;
            toolstripAutoSteerConfig.Text = gStr.gsAutoSteer;
            steerChartStripMenu.Text = gStr.gsSteerChart;
            toolstripVehicleConfig.Text = gStr.gsVehicle;
            toolstripDisplayConfig.Text = gStr.gsDataSources;
            toolstripUSBPortsConfig.Text = gStr.gsSerialPorts;
            toolstripUDPConfig.Text = gStr.gsUDP;
            toolStripNTRIPConfig.Text = gStr.gsNTRIP;

            //Tools Menu
            treePlantToolStrip.Text = gStr.gsTreePlanter;
            SmoothABtoolStripMenu.Text = gStr.gsSmoothABCurve;
            toolStripBtnMakeBndContour.Text = gStr.gsMakeBoundaryContours;
            boundariesToolStripMenuItem.Text = gStr.gsBoundary;
            headlandToolStripMenuItem.Text = gStr.gsHeadland;
            deleteContourPathsToolStripMenuItem.Text = gStr.gsDeleteContourPaths;
            deleteAppliedAreaToolStripMenuItem.Text = gStr.gsDeleteAppliedArea;
            deleteForSureToolStripMenuItem.Text = gStr.gsAreYouSure;
            webcamToolStrip.Text = gStr.gsWebCam;
            googleEarthFlagsToolStrip.Text = gStr.gsGoogleEarth;
            offsetFixToolStrip.Text = gStr.gsOffsetFix;
            moduleConfigToolStripMenuItem.Text = gStr.gsModuleConfiguration;

            //Recorded Path
            deletePathMenu.Text = gStr.gsDeletePath;
            recordPathMenu.Text = gStr.gsRecordStop;
            goPathMenu.Text = gStr.gsGoStop;
            pausePathMenu.Text = gStr.gsPauseResume;

            stripSectionColor.Text = Application.ProductVersion.ToString(CultureInfo.InvariantCulture);

            //NTRIP
            this.lblWatch.Text = "Wait GPS";
            NTRIPStartStopStrip.Text = gStr.gsNTRIPOff;

            //build the gesture structures
            SetupStructSizes();

            //create the world grid
            worldGrid = new CWorldGrid(this);

            //our vehicle made with gl object and pointer of mainform
            vehicle = new CVehicle(this);

            tool = new CTool(this);

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

            //headland object
            hd = new CHead( this);

            //nmea simulator built in.
            sim = new CSim(this);

            //all the autosteer objects
            ast = new CAutoSteer(this);

            //all the attitude, heading, roll, pitch reference system
            ahrs = new CAHRS(this);

            //fieldData all in one place
            fd = new CFieldData(this);

            //start the stopwatch
            //swFrame.Start();

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

            //get the tools directory, if not exist, create
            toolsDirectory = baseDirectory + "Tools\\";
            dir = Path.GetDirectoryName(toolsDirectory);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

            //get the tools directory, if not exist, create
            envDirectory = baseDirectory + "Environments\\";
            dir = Path.GetDirectoryName(envDirectory);
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
            vehicleFileName = Vehicle.Default.setVehicle_vehicleName;
            toolFileName = Vehicle.Default.setVehicle_toolName;
            envFileName = Vehicle.Default.setVehicle_envName;


            //get the abLines directory, if not exist, create
            ablinesDirectory = baseDirectory + "ABLines\\";
            dir = Path.GetDirectoryName(fieldsDirectory);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

            //set baud and port from last time run
            baudRateGPS = Settings.Default.setPort_baudRate;
            portNameGPS = Settings.Default.setPort_portNameGPS;

            //try and open
            SerialPortOpenGPS();

            if (spGPS.IsOpen)
            {
                simulatorOnToolStripMenuItem.Checked = false;
                panelSim.Visible = false;
                timerSim.Enabled = false;

                Settings.Default.setMenu_isSimulatorOn = simulatorOnToolStripMenuItem.Checked;
                Settings.Default.Save();
            }

            //same for SectionMachine port
            portNameMachine = Settings.Default.setPort_portNameMachine;
            wasRateMachineConnectedLastRun = Settings.Default.setPort_wasMachineConnected;
            if (wasRateMachineConnectedLastRun) SerialPortMachineOpen();

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
            if (Properties.Settings.Default.setUDP_isOn 
                && !Properties.Settings.Default.setUDP_isInterAppOn) StartUDPServer();

            if (Properties.Settings.Default.setUDP_isInterAppOn) StartLocalUDPServer();

            //start NTRIP if required
                if (Properties.Settings.Default.setNTRIP_isOn)
            {
                isNTRIP_RequiredOn = true;
            }
            else
            {
                isNTRIP_RequiredOn = false;
            }

            //remembered window position
            if (Settings.Default.setWindow_Maximized)
            {
                WindowState = FormWindowState.Normal;
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

            isRTK = Properties.Settings.Default.setGPS_isRTK;
        }

        //form is closing so tidy up and save settings
        private void FormGPS_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save, return, cancel save
            if (isJobStarted)
            {
                bool closing = true;
                int choice = SaveOrNot(closing);

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
                Settings.Default.setWindow_Maximized = false;
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

            Settings.Default.setDisplay_camPitch = camera.camPitch;
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

        public void LoadGLTextures()
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

            try
            {
                string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string text = Path.Combine(directoryName, "Dependencies\\images", "TurnCancel.png");
                if (File.Exists(text))
                {
                    using (Bitmap bitmap = new Bitmap(text))
                    {
                        GL.GenTextures(1, out texture[4]);
                        GL.BindTexture(TextureTarget.Texture2D, texture[4]);
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
                MessageBox.Show("Texture File TURNCANCEL.PNG is Missing", ex.Message);
            }

            try
            {
                string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string text = Path.Combine(directoryName, "Dependencies\\images", "TurnManual.png");
                if (File.Exists(text))
                {
                    using (Bitmap bitmap = new Bitmap(text))
                    {
                        GL.GenTextures(1, out texture[5]);
                        GL.BindTexture(TextureTarget.Texture2D, texture[5]);
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
                MessageBox.Show("Texture File TURNManual.PNG is Missing", ex.Message);
            }

            try
            {
                string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string text = Path.Combine(directoryName, "Dependencies\\images", "Compass.png");
                if (File.Exists(text))
                {
                    using (Bitmap bitmap = new Bitmap(text))
                    {
                        GL.GenTextures(1, out texture[6]);
                        GL.BindTexture(TextureTarget.Texture2D, texture[6]);
                        BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmap.Width, bitmap.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                        bitmap.UnlockBits(data);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9726);
                    }
                }
            }
            catch (Exception ex)
            {
                //WriteErrorLog("Loading Landscape Textures" + ex);
                MessageBox.Show("Texture File Compass.PNG is Missing", ex.Message);
            }

            try
            {
                string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string text = Path.Combine(directoryName, "Dependencies\\images", "Speedo.png");
                if (File.Exists(text))
                {
                    using (Bitmap bitmap = new Bitmap(text))
                    {
                        GL.GenTextures(1, out texture[7]);
                        GL.BindTexture(TextureTarget.Texture2D, texture[7]);
                        BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmap.Width, bitmap.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                        bitmap.UnlockBits(data);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
                    }
                }
            }
            catch (Exception ex)
            {
                //WriteErrorLog("Loading Landscape Textures" + ex);
                MessageBox.Show("Texture File Speedo.PNG is Missing", ex.Message);
            }

            try
            {
                string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string text = Path.Combine(directoryName, "Dependencies\\images", "SpeedoNedle.png");
                if (File.Exists(text))
                {
                    using (Bitmap bitmap = new Bitmap(text))
                    {
                        GL.GenTextures(1, out texture[8]);
                        GL.BindTexture(TextureTarget.Texture2D, texture[8]);
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
                MessageBox.Show("Texture File SpeedoNeedle.PNG is Missing", ex.Message);
            }

            try
            {
                string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string text = Path.Combine(directoryName, "Dependencies\\images", "Lift.png");
                if (File.Exists(text))
                {
                    using (Bitmap bitmap = new Bitmap(text))
                    {
                        GL.GenTextures(1, out texture[9]);
                        GL.BindTexture(TextureTarget.Texture2D, texture[9]);
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
                MessageBox.Show("Texture File Lift.PNG is Missing", ex.Message);
            }

            try
            {
                string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string text = Path.Combine(directoryName, "Dependencies\\images", "LandscapeNight.png");
                if (File.Exists(text))
                {
                    using (Bitmap bitmap = new Bitmap(text))
                    {
                        GL.GenTextures(1, out texture[10]);
                        GL.BindTexture(TextureTarget.Texture2D, texture[10]);
                        BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmap.Width, bitmap.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                        bitmap.UnlockBits(data);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
                    }
                }
            }
            catch (Exception ex)
            {
                //WriteErrorLog("Loading Landscape Textures" + ex);
                MessageBox.Show("Texture File LAndscapeNight.PNG is Missing", ex.Message);
            }

            try
            {
                string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string text = Path.Combine(directoryName, "Dependencies\\images", "Steer.png");
                if (File.Exists(text))
                {
                    using (Bitmap bitmap = new Bitmap(text))
                    {
                        GL.GenTextures(1, out texture[11]);
                        GL.BindTexture(TextureTarget.Texture2D, texture[11]);
                        BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmap.Width, bitmap.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                        bitmap.UnlockBits(data);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
                    }
                }
            }
            catch (Exception ex)
            {
                //WriteErrorLog("Loading Landscape Textures" + ex);
                MessageBox.Show("Texture File Steer.PNG is Missing", ex.Message);
            }

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

                sendSocket.EnableBroadcast = true;
                recvSocket.EnableBroadcast = true;

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
                //WriteErrorLog("UDP Server" + e);
                MessageBox.Show("Load Error: " + e.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void StartLocalUDPServer()
        {
            //inter App sockets
            try
            {
                // Initialise the delegate which updates the status
                updateStatusDelegate = new UpdateStatusDelegate(UpdateAppStatus);

                // Initialise the socket
                sendToAppSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Initialise the IPEndPoint for the server to send on port 15554
                IPEndPoint server = new IPEndPoint(IPAddress.Loopback, 15554);
                sendToAppSocket.Bind(server);

                // Initialise the client socket
                recvFromAppSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Initialise the IPEndPoint for and listen on port 15555
                IPEndPoint client = new IPEndPoint(IPAddress.Loopback, 15555);
                recvFromAppSocket.Bind(client);

                //Our external app address & port number
                epAppOne = new IPEndPoint(IPAddress.Loopback, 17777);
                //epAppTwo = new IPEndPoint(zeroIP, 16666);

                // Initialise the IPEndPoint for the client
                EndPoint clientEp = new IPEndPoint(IPAddress.Loopback, 0);

                // Start listening for incoming data
                recvFromAppSocket.BeginReceiveFrom(appBuffer, 0, appBuffer.Length, SocketFlags.None,
                                                ref clientEp, new AsyncCallback(ReceiveAppData), recvFromAppSocket);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    yt.ResetCreatedYouTurn();
                }
                else
                {
                    //make it turn the other way
                    yt.isYouTurnRight = true;
                    yt.isLastYouTurnRight = !yt.isLastYouTurnRight;
                    yt.ResetCreatedYouTurn();
                }
            }
            else
            {
                if (yt.isYouTurnBtnOn) btnAutoYouTurn.PerformClick();
            }
        }

        //dialog for requesting user to save or cancel
        public int SaveOrNot(bool closing)
        {
            using (var form = new FormSaveOrNot(closing))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK) return 0;      //Save and Exit
                if (result == DialogResult.Ignore) return 1;   //Ignore
                if (result == DialogResult.Yes) return 2;      //Save As
                return 3;  // oops something is really busted
            }
        }

        private void btnTestIsMapping_Click(object sender, EventArgs e)
        {
            isMapping = !isMapping;
            //if (isMapping) btnTestIsMapping.Text = "Mapping";
            //else btnTestIsMapping.Text = "No Map";
        }

        public void GetHeadland()
        {
            using (var form = new FormHeadland (this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                }
            }

            if (hd.headArr[0].hdLine.Count > 0)
            {
                hd.isOn = true;
                btnHeadlandOnOff.Image = Properties.Resources.HeadlandOn;
            }
            else
            {
                hd.isOn = false;
                btnHeadlandOnOff.Image = Properties.Resources.HeadlandOff;
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FormDisplayOptions(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                }
            }

        }

        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FormColor(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                }
            }
        }

        private void stripSectionColor_Click(object sender, EventArgs e)
        {
            using (var form = new FormColorPicker(this, sectionColorDay))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    sectionColorDay = form.useThisColor;
                }
            }

            Settings.Default.setDisplay_colorSectionsDay = sectionColorDay;
            Settings.Default.Save();

            stripSectionColor.BackColor = sectionColorDay;
        }

        private void keyboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            isKeyboardOn = !isKeyboardOn;
            keyboardToolStripMenuItem1.Checked = isKeyboardOn;
            Settings.Default.setDisplay_isKeyboardOn = isKeyboardOn;
            Settings.Default.Save();
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

        public void KeyboardToText(TextBox sender)
        {
            TextBox tbox = (TextBox)sender;
            tbox.BackColor = System.Drawing.Color.Red;
            using (var form = new FormKeyboard((string)tbox.Text))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tbox.Text = (string)form.ReturnString;
                }
            }
            tbox.BackColor = System.Drawing.Color.AliceBlue;
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
            //SendSteerSettingsOutAutoSteerPort();
            //SendArduinoSettingsOutToAutoSteerPort();
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
                    Application.Restart();
                    Environment.Exit(0);
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

            section[12].positionLeft = (double)Vehicle.Default.setSection_position13 + Vehicle.Default.setVehicle_toolOffset;
            section[12].positionRight = (double)Vehicle.Default.setSection_position14 + Vehicle.Default.setVehicle_toolOffset;

            section[13].positionLeft = (double)Vehicle.Default.setSection_position14 + Vehicle.Default.setVehicle_toolOffset;
            section[13].positionRight = (double)Vehicle.Default.setSection_position15 + Vehicle.Default.setVehicle_toolOffset;

            section[14].positionLeft = (double)Vehicle.Default.setSection_position15 + Vehicle.Default.setVehicle_toolOffset;
            section[14].positionRight = (double)Vehicle.Default.setSection_position16 + Vehicle.Default.setVehicle_toolOffset;

            section[15].positionLeft = (double)Vehicle.Default.setSection_position16 + Vehicle.Default.setVehicle_toolOffset;
            section[15].positionRight = (double)Vehicle.Default.setSection_position17 + Vehicle.Default.setVehicle_toolOffset;
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
            tool.toolWidth = Math.Abs(section[0].positionLeft) + Math.Abs(section[tool.numOfSections - 1].positionRight);

            //left and right tool position
            tool.toolFarLeftPosition = section[0].positionLeft;
            tool.toolFarRightPosition = section[tool.numOfSections - 1].positionRight;

            //now do the full width section
            section[tool.numOfSections].sectionWidth = tool.toolWidth;
            section[tool.numOfSections].positionLeft = tool.toolFarLeftPosition;
            section[tool.numOfSections].positionRight = tool.toolFarRightPosition;

            //find the right side pixel position
            tool.rpXPosition = 250 + (int)(Math.Round(tool.toolFarLeftPosition * 10, 0, MidpointRounding.AwayFromZero));
            tool.rpWidth = (int)(Math.Round(tool.toolWidth * 10, 0, MidpointRounding.AwayFromZero));
        }

        //request a new job
        public void JobNew()
        {
            if (Settings.Default.setMenu_isOGLZoomOn == 1)
            {
                oglZoom.BringToFront();
                oglZoom.Width = 300;
                oglZoom.Height = 300;
            }

                //SendSteerSettingsOutAutoSteerPort();
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
            btnSection13Man.BackColor = Color.Red;
            btnSection14Man.BackColor = Color.Red;
            btnSection15Man.BackColor = Color.Red;
            btnSection16Man.BackColor = Color.Red;

            btnSection1Man.Enabled = true;
            btnSection2Man.Enabled = true;
            btnSection3Man.Enabled = true;
            btnSection4Man.Enabled = true;
            btnSection5Man.Enabled = true;
            btnSection6Man.Enabled = true;
            btnSection7Man.Enabled = true;
            btnSection8Man.Enabled = true;
            btnSection9Man.Enabled = true;
            btnSection10Man.Enabled = true;
            btnSection11Man.Enabled = true;
            btnSection12Man.Enabled = true;
            btnSection13Man.Enabled = true;
            btnSection14Man.Enabled = true;
            btnSection15Man.Enabled = true;
            btnSection16Man.Enabled = true;


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


            LineUpManualBtns();

            //update the menu
            this.menustripLanguage.Enabled = false;
            layoutPanelRight.Enabled = true;
            //boundaryToolStripBtn.Enabled = true;
            toolStripBtnDropDownBoundaryTools.Enabled = true;
        }

        //close the current job
        public void JobClose()
        {
            //reset field offsets
            pn.fixOffset.easting = 0;
            pn.fixOffset.northing = 0;

            //turn off headland
            hd.isOn = false;
            btnHeadlandOnOff.Image = Properties.Resources.HeadlandOff;

            //make sure hydraulic lift is off
            mc.machineData[mc.mdHydLift] = 0;
            vehicle.isHydLiftOn = false;
            btnHydLift.Image = Properties.Resources.HydraulicLiftOff;

            //zoom gone
            oglZoom.SendToBack();

            //clean all the lines
            bnd.bndArr?.Clear();
            turn.turnArr?.Clear();
            hd.headArr[0].hdLine?.Clear();

            layoutPanelRight.Enabled = false;
            toolStripBtnDropDownBoundaryTools.Enabled = false;

            menustripLanguage.Enabled = true;
            isJobStarted = false;


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
            btnSection13Man.Enabled = false;
            btnSection14Man.Enabled = false;
            btnSection15Man.Enabled = false;
            btnSection16Man.Enabled = false;

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
            btnSection13Man.BackColor = Color.Silver;
            btnSection14Man.BackColor = Color.Silver;
            btnSection15Man.BackColor = Color.Silver;
            btnSection16Man.BackColor = Color.Silver;

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
            btnAutoYouTurn.Image = Properties.Resources.YouTurnNo;
            btnAutoYouTurn.Enabled = false;
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

            //reset all Port Module values
            mc.ResetAllModuleCommValues();
        }

        //bring up field dialog for new/open/resume
        private void JobNewOpenResume()
        {
            //bring up dialog if no job active, close job if one is
            if (!isJobStarted)
            {
                //if (toolStripBtnGPSStength.Image.Height == 64)
                //{
                //    var form = new FormTimedMessage(3000, gStr.gsNoGPS, gStr.gsGPSSourceOff);
                //    form.Show();
                //    return;
                //}

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
                    //boundaryToolStripBtn.Enabled = true;
                    toolStripBtnDropDownBoundaryTools.Enabled = true;
                }
                else
                {
                    layoutPanelRight.Enabled = false;
                    //boundaryToolStripBtn.Enabled = false;
                    toolStripBtnDropDownBoundaryTools.Enabled = false;
                }
            }

            //close the current job and ask how to or if to save
            else
            {
                bool closing = false;
                int choice = SaveOrNot(closing);
                switch (choice)
                {
                    //OK
                    case 0:
                        Settings.Default.setF_CurrentDir = currentFieldDirectory;
                        Settings.Default.Save();
                        FileSaveEverythingBeforeClosingField();
                        layoutPanelRight.Enabled = false;
                        //boundaryToolStripBtn.Enabled = false;
                        toolStripBtnDropDownBoundaryTools.Enabled = false;
                        break;

                    //Ignore and return
                    case 1:
                        break;

                    //Save As
                    case 2:
                        //close current field but remember last used like normal
                        Settings.Default.setF_CurrentDir = currentFieldDirectory;
                        Settings.Default.Save();
                        FileSaveEverythingBeforeClosingField();
                        layoutPanelRight.Enabled = false;
                        //boundaryToolStripBtn.Enabled = false;
                        toolStripBtnDropDownBoundaryTools.Enabled = false;

                        //ask for a directory name
                        using (var form2 = new FormSaveAs(this))
                        {
                            form2.ShowDialog();
                        }

                        break;
                }
            }
            //update GUI areas
        }

        //Does the logic to process section on off requests
        private void ProcessSectionOnOffRequests()
        {
            {
                for (int j = 0; j < tool.numOfSections + 1; j++)
                {
                    //SECTIONS - 


                    if (section[j].sectionOnRequest)
                        section[j].isSectionOn = true;

                    if (!section[j].sectionOffRequest) section[j].sectionOffTimer = (int)((double)fixUpdateHz * tool.turnOffDelay);

                    if (section[j].sectionOffTimer > 0) section[j].sectionOffTimer--;

                    if (section[j].sectionOffRequest & section[j].sectionOffTimer == 0)
                    {
                        if (section[j].isSectionOn) section[j].isSectionOn = false;
                    }

                    //MAPPING - 

                    //easy just turn it on
                    if (section[j].mappingOnRequest)
                    {
                        if (!section[j].isMappingOn && isMapping) section[j].TurnMappingOn(); //**************************************** un comment to enable mappping again
                    }

                    //turn off
                    double sped = 1 / ((pn.speed+5) * 0.2);
                    if (sped < 0.2) sped = 0.2;

                    //keep setting the timer so full when ready to turn off
                    if (!section[j].mappingOffRequest)
                        section[j].mappingOffTimer = (int)(fixUpdateHz * 1 * sped + ((double)fixUpdateHz * tool.turnOffDelay));

                    //decrement the off timer
                    if (section[j].mappingOffTimer > 0) section[j].mappingOffTimer--;

                    //if Off mapping timer is zero, turn off the section, reset everything
                    if (section[j].mappingOffTimer == 0 && section[j].mappingOffRequest)
                    {
                        if (section[j].isMappingOn) section[j].TurnMappingOff();
                        section[j].mappingOffRequest = false;
                    }

                    #region notes
                    //Turn ON
                    //if requested to be on, set the timer to Max 10 (1 seconds) = 10 frames per second
                    //if (section[j].sectionOnRequest && !section[j].sectionOnOffCycle)
                    //{
                    //    section[j].sectionOnTimer = (int)(pn.speed * section[j].lookAheadOn) + 1;
                    //    if (section[j].sectionOnTimer > fixUpdateHz + 3) section[j].sectionOnTimer = fixUpdateHz + 3;
                    //    section[j].sectionOnOffCycle = true;
                    //}

                    ////reset the ON request
                    //section[j].sectionOnRequest = false;

                    ////decrement the timer if not zero
                    //if (section[j].sectionOnTimer > 0)
                    //{
                    //    //turn the section ON if not and decrement timer
                    //    section[j].sectionOnTimer--;
                    //    if (!section[j].isSectionOn) section[j].isSectionOn = true;

                    //    //keep resetting the section OFF timer while the ON is active
                    //    //section[j].sectionOffTimer = (int)(fixUpdateHz * tool.toolTurnOffDelay);
                    //}
                    //if (!section[j].sectionOffRequest) 
                    //    section[j].sectionOffTimer = (int)(fixUpdateHz * tool.turnOffDelay);

                    ////decrement the off timer
                    //if (section[j].sectionOffTimer > 0 && section[j].sectionOnTimer == 0) section[j].sectionOffTimer--;

                    ////Turn OFF
                    ////if Off section timer is zero, turn off the section
                    //if (section[j].sectionOffTimer == 0 && section[j].sectionOnTimer == 0 && section[j].sectionOffRequest)
                    //{
                    //    if (section[j].isSectionOn) section[j].isSectionOn = false;
                    //    //section[j].sectionOnOffCycle = false;
                    //    section[j].sectionOffRequest = false;
                    //    //}
                    //}
                    //Turn ON
                    //if requested to be on, set the timer to Max 10 (1 seconds) = 10 frames per second
                    //if (section[j].mappingOnRequest && !section[j].mappingOnOffCycle)
                    //{
                    //    section[j].mappingOnTimer = (int)(fixUpdateHz * 1) + 1;
                    //    section[j].mappingOnOffCycle = true;
                    //}

                    ////reset the ON request
                    //section[j].mappingOnRequest = false;

                    //decrement the timer if not zero
                    #endregion notes
                }
            }
        }


        //take the distance from object and convert to camera data
        public void SetZoom()
        {
            //match grid to cam distance and redo perspective
            if (camera.camSetDistance <= -20000) camera.gridZoom = 2000;
            else if (camera.camSetDistance >= -20000 && camera.camSetDistance < -10000) camera.gridZoom = 2012*2;
            else if (camera.camSetDistance >= -10000 && camera.camSetDistance < -5000) camera.gridZoom = 1006 *2;
            else if (camera.camSetDistance >= -5000 && camera.camSetDistance < -2000) camera.gridZoom = 503 *2;
            else if (camera.camSetDistance >= -2000 && camera.camSetDistance < -1000) camera.gridZoom = 201.2 *2;
            else if (camera.camSetDistance >= -1000 && camera.camSetDistance < -500) camera.gridZoom = 100.6 *2;
            else if (camera.camSetDistance >= -500 && camera.camSetDistance < -250) camera.gridZoom = 50.3 *2;
            else if (camera.camSetDistance >= -250 && camera.camSetDistance < -150) camera.gridZoom = 25.15 *2;
            else if (camera.camSetDistance >= -150 && camera.camSetDistance < -50) camera.gridZoom = 10.06 *2;
            else if (camera.camSetDistance >= -50 && camera.camSetDistance < -1) camera.gridZoom = 5.03 *2;
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
            for (int j = 0; j < tool.numOfSections + 1; j++)
            {
                if (section[j].isMappingOn) section[j].TurnMappingOff();
                section[j].sectionOnOffCycle = false;
                section[j].sectionOffRequest = false;
            }

            //FileSaveHeadland();
            FileSaveBoundary();
            FileSaveSections();
            FileSaveContour();
            FileSaveFieldKML();

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
                //string strPath = Application.StartupPath;

                //Write out the error appending to existing
                File.AppendAllText(baseDirectory + "\\" + strFileName, strErrorText + " - " +
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
 * SectionControlToArduino() runs and spits out the port machine control based on sections on or off
 * If field needs saving (1.5 minute since last time) field is saved
 * Now the program is "Done" and waits for the next watchdog trigger, determines if a new sentence is available etc
 * and starts all over from the top.
 */