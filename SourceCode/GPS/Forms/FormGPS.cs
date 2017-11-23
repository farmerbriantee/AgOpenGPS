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

namespace AgOpenGPS
{
    
    //the main form object
    public partial class FormGPS : Form
    {
        #region // Class Props and instances
        //maximum sections available
        private const int MAXSECTIONS = 9;

        //some test variables
        //double testDouble = 0;
        //bool testBool = false;
        //int testInt = 0;

        //current directory of field;
        public string currentFieldDirectory = "", workingDirectory = "", vehiclefileName = "";

        //colors for sections and field background
        private byte redSections,grnSections,bluSections;
        public byte redField,grnField,bluField;

        //polygon mode for section drawing
        private bool isDrawPolygons;

        //flag for free drive window to control autosteer
        public bool isInFreeDriveMode;

        //Flag stuff
        public byte flagColor = 0;
        private bool leftMouseDownOnOpenGL = false; //mousedown event in opengl window
        private int flagNumberPicked = 0;

        //Is it in 2D or 3D, metric or imperial, display lightbar, display grid
        public bool isIn3D = true, isMetric = true, isLightbarOn = true, isGridOn, isSideGuideLines = true;
        public bool isPureDisplayOn = true;

        //bool for whether or not a job is active
        public bool isJobStarted = false, isAreaOnRight = true, isAutoSteerBtnOn = false;

        //master Manual and Auto, 3 states possible
        public enum btnStates {Off,Auto,On}
        public btnStates manualBtnState = btnStates.Off;
        public btnStates autoBtnState = btnStates.Off;

        //section button states
        public enum manBtn { Off, Auto, On }

        //if we are saving a file
        public bool isSavingFile = false, isLogNMEA = false;

        //Zoom variables
        public double gridZoom;
        public double zoomValue = 15;
        public double triangleResolution = 1.0;
        private double previousZoom = 25;
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

        //Parsing object of NMEA sentences
        public CNMEA pn;

        //create an array of sections, so far only 8 section + 1 fullWidth Section
        public CSection[] section = new CSection[MAXSECTIONS];

        //ABLine Instance
        public CABLine ABLine;

        /// <summary>
        /// Contour Mode Instance
        /// </summary>
        public CContour ct;

        //Auto Headland Instance
        /// <summary>
        /// Auto Headland Turn
        /// </summary>
        public CYouTurn yt;

        /// <summary>
        /// Rate control Object
        /// </summary>
        public CRate rc;

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

            //new instance of auto headland turn
            yt = new CYouTurn(gl, this);

            //module communication
            mc = new CModuleComm(this);

            //perimeter list object
            periArea = new CPerimeter(gl);

            //boundary object
            boundary = new CBoundary(gl, glBack, this);

            //rate object
            rc = new CRate(this);

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

            if (keyData == (Keys.NumPad1))
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

            if (keyData == (Keys.C))
            {
                SettingsCommunications();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.A))
            {
                btnAutoSteer.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.D))
            {
                btnSectionOffAutoOn.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == (Keys.R))
            {
              
                mc.rkey = !mc.rkey;
                return true;    // indicate that you handled this keystroke turns roll on or off
            }
            if (keyData == (Keys.H))
            {

                mc.hkey = !mc.hkey;
                return true;    // indicate that you handled this keystroke turns heading from imu on or off
            }


            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Initialize items before the form Loads or is visible
        private void FormGPS_Load(object sender, EventArgs e)
        {
            //tooltips of controls
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(btnABLine, "Set and configure\n an ABLine");

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

            //don;t draw the back opengl to GDI - it still works tho
            openGLControlBack.Visible = false;

            //set previous job directory
            currentFieldDirectory = Settings.Default.setF_CurrentDir;
            vehiclefileName = Settings.Default.setVehicle_Name;

            //clear the flags
            flagPts.Clear();
            btnFlag.Enabled = false;

            //workswitch stuff
            mc.isWorkSwitchEnabled = Settings.Default.setF_IsWorkSwitchEnabled;
            mc.isWorkSwitchActiveLow = Settings.Default.setF_IsWorkSwitchActiveLow;

            minFixStepDist = Settings.Default.setF_minFixStep;

            pitchZero = Settings.Default.setIMU_pitchZero;
            rollZero = Settings.Default.setIMU_rollZero;

            totalUserSquareMeters = Settings.Default.setF_UserTotalArea;
            userSquareMetersAlarm = Settings.Default.setF_UserTripAlarm;

            //space between points while recording a boundary
            boundaryTriggerDistance = Settings.Default.setF_boundaryTriggerDistance;

            //load the last used auto turn shape
            string fileAndDir = @".\YouTurnShapes\" + Properties.Settings.Default.setAS_youTurnShape;
            yt.LoadYouTurnShapeFromFile(fileAndDir);

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
                // Initialise the delegate which updates the status
                updateStatusDelegate = UpdateStatus;

                // Initialise the socket
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Initialise the IPEndPoint for the server and listen on port 9999
                IPEndPoint server = new IPEndPoint(IPAddress.Any, 9999);

                //IP address and port of 8888 server
                IPAddress zeroIP = IPAddress.Parse("192.168.1.255");
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

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

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

            btnAutoYouTurn.Enabled = true;
            btnRightYouTurn.Enabled = true;
            btnLeftYouTurn.Enabled = true;

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

            btnAutoYouTurn.Enabled = false;
            btnRightYouTurn.Enabled = false;
            btnLeftYouTurn.Enabled = false;

            ct.isContourBtnOn = false;
            ct.isContourOn = false;

            //change images to reflect on off
            btnABLine.Image = Properties.Resources.ABLineOff;
            btnRightYouTurn.Visible = false;
            btnLeftYouTurn.Visible = false;
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

            //rate control buttons
            btnRate1Select.Visible = false;
            btnRate2Select.Visible = false;
            btnRate.Image = Properties.Resources.RateControlOff;
            rc.ShutdownRateControl();

            //auto YouTurn shutdown
            yt.isAutoYouTurnEnabled = false;
            yt.CancelYouTurn();
            autoTurnInProgressBar = 0;
            btnAutoYouTurn.Text = "Off";

            //reset all Port Module values
            mc.ResetAllModuleCommValues();
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



