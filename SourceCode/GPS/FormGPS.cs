//Please, if you use this, share the improvements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using System.Media;
using SharpGL.SceneGraph.Assets;
using System.Net;
using System.Net.Sockets;

//http://maps.google.com/maps?q=54.3%2C-111.10

namespace AgOpenGPS
{
    //the main form object
    public partial class FormGPS : Form
    {
        //maximum sections available
        const int MAXSECTIONS = 5;

        //polygon mode for section drawing
        bool isDrawPolygons = false;

        //Is it in 2D or 3D, metric or imperial, display lightbar, display grid
        public bool isIn3D = true, isMetric = true, isLightbarOn = true, isGridOn;

        //bool for whether or not a job is active
        public bool isJobStarted = false, isAreaOnRight = true;

        //master Manual and Auto, 3 states possible
        public enum btnStates {Off,Auto,On};
        public btnStates manualBtnState = btnStates.Off;
        public btnStates autoBtnState = btnStates.Off;

        //section button states
        public enum manBtn { Off, Auto, On };

        //if we are saving a file
        public bool isSavingFile = false;

        //Zoom variables
        public double gridZoom;
        public double zoomValue = 24;
        public double triangleResolution = 1.0;

        // Storage For Our Tractor, implement, background etc Textures
        Texture particleTexture;
        public uint[] texture = new uint[3];		

        //create the scene camera
        public CCamera camera = new CCamera();

        //create world grid
        CWorldGrid worldGrid;

        //create instance of a stopwatch for timing of frames and NMEA hz determination
        Stopwatch swFrame = new Stopwatch();

        //Time to do fix position update and draw routine
        double frameTime = 0;

        //For field saving in background
        int saveCounter = 1;

        //used to update the screen status bar etc
        int statusUpdateCounter = 1;

        //Parsing object of NMEA sentences
        public CNMEA pn;

        //create an array of sections, so far only 5 section
        public CSection[] section = new CSection[MAXSECTIONS];

        //ABLine Instance
        public CABLine ABLine;

        //Contour mode Instance
        public CContour ct;

        //a brand new vehicle
        public CVehicle vehicle;

        //module communication object
        public CModuleComm modcom;

        //perimeter object for area calc
        public CPerimeter periArea;

        //create a sound player object
        //System.Media.SoundPlayer player = new System.Media.SoundPlayer();

// Forms //................................................................................

        //All the forms related procedures

        /// Constructor, Initializes a new instance of the "FormGPS" class.
        public FormGPS()
        {
            //winform initialization
            InitializeComponent();

            //create a new section and set left and right positions
            //created whether used or not, saves restarting program
            for (int j = 0; j < MAXSECTIONS; j++) section[j] = new CSection(this);

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

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
            modcom = new CModuleComm(this);

            //perimeter list object
            periArea = new CPerimeter(gl, this);            

            //start the stopwatch
            swFrame.Start();
        }

        //Initialize items before the form Loads or is visible
        private void FormGPS_Load(object sender, EventArgs e)
        {
            #region settings //--------------------------------------------------------------------------

            //change 2D or 3D icon accordingly on button
            if (camera.camPitch == -15)  {
                this.btn2D3D.Image = global::AgOpenGPS.Properties.Resources.Icon_3D;   isIn3D = true;  }
            else  {
                this.btn2D3D.Image = global::AgOpenGPS.Properties.Resources.Icon_2D;   isIn3D = false; }

            //set baud and port from last time run
            baudRateGPS = Properties.Settings.Default.setPort_baudRate;
            portNameGPS = Properties.Settings.Default.setPort_portNameGPS;

            //is it in metric?
            isMetric = Properties.Settings.Default.setIsMetric;

            //Grid and lightbar settings
            isGridOn = Properties.Settings.Default.setIsGridOn;
            isLightbarOn = Properties.Settings.Default.setIsLightbarOn;

            //try and open, if not go to setting up port
            SerialPortOpenGPS();

            //same for SectionRelay port
            portNameRelaySection = Properties.Settings.Default.setPort_portNameRelay;
            wasSectionRelayConnectedLastRun = Properties.Settings.Default.setPort_wasRelayConnected;
            if (wasSectionRelayConnectedLastRun)  SerialPortRelayOpen();

            //Set width of section and positions for each section
            SectionSetPosition();

            //Calculate total width and each section width
            SectionCalcWidths();

            //start server
            //StartTCPServer();

            //start server
            StartUDPServer();

            //set the correct zoom and grid
            camera.camSetDistance = zoomValue * zoomValue * -1;
            SetZoom();

            //get the smoothing factors from settings
            delayCameraPrev = Properties.Settings.Default.setDisplay_delayCameraPrev;
            delayFixPrev = Properties.Settings.Default.setDisplay_delayFixPrev;

            //which cam source is being used
            isAtanCam = Properties.Settings.Default.setCam_isAtanCam;

            //triangle resolution is how far to next triangle point trigger distance
            triangleResolution = Properties.Settings.Default.setDisplay_triangleResolution;

            //remembered window position
            if (Properties.Settings.Default.setWindow_Maximized)
            {
                WindowState = FormWindowState.Maximized;
                Location = Properties.Settings.Default.setWindow_Location;
                Size = Properties.Settings.Default.setWindow_Size;
            }
            else if (Properties.Settings.Default.setWindow_Minimized)
            {
                //WindowState = FormWindowState.Minimized;
                Location = Properties.Settings.Default.setWindow_Location;
                Size = Properties.Settings.Default.setWindow_Size;
            }
            else
            {
                Location = Properties.Settings.Default.setWindow_Location;
                Size = Properties.Settings.Default.setWindow_Size;
            }
            #endregion

            btnSection1Man.Enabled = false;
            btnSection2Man.Enabled = false;
            btnSection3Man.Enabled = false;
            btnSection4Man.Enabled = false;
            btnSection5Man.Enabled = false;

            //metric settings
            isMetric = Properties.Settings.Default.setIsMetric;
            if (isMetric)
            {
                metricToolStripMenuItem.Checked = true;
                imperialToolStripMenuItem.Checked = false;
            }

            else
            {
                metricToolStripMenuItem.Checked = false;
                imperialToolStripMenuItem.Checked = true;
            }

            //area side settings
            isAreaOnRight = Properties.Settings.Default.setIsAreaRight;
            if (isAreaOnRight)
            {
                rightSideToolStripMenuItem.Checked = true;
                leftSideToolStripMenuItem.Checked = false;
            }

            else
            {
                rightSideToolStripMenuItem.Checked = false;
                leftSideToolStripMenuItem.Checked = true;
            }


            //set up grid and lightbar
            isGridOn = Properties.Settings.Default.setIsGridOn;
            gridToolStripMenuItem.Checked = isGridOn;

            isLightbarOn = Properties.Settings.Default.setIsLightbarOn;
            lightbarToolStripMenuItem.Checked = isLightbarOn;

            //flash no gpd no worky message
            var form = new FormTimedMessage(this, 1500, "Initializing GPS......", "If screen stays black, no GPS data");
            form.Show();
            return;
        }

        //start the UDP server
        private void StartUDPServer()
        {
            try
            {
                // Initialise the delegate which updates the status
                updateStatusDelegate = new UpdateStatusDelegate(UpdateStatus);

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
                                                ref client, new AsyncCallback(ReceiveData), serverSocket);

                //lblStatus.Text = "Listening";
            }
            catch (Exception ex)
            {
                //lblStatus.Text = "Error";
                MessageBox.Show("Load Error: " + ex.Message, "UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            String strHostName = "";
            try
            {
                // NOTE: DNS lookups are nice and all but quite time consuming.
                strHostName = Dns.GetHostName();
                IPHostEntry ipEntry = Dns.GetHostEntry(string.Empty);
                localIPAddress = ipEntry.AddressList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to get local address "+ ex.Message);
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
            listener.BeginAccept(new AsyncCallback(OnConnectRequest), listener); 
        }
 
        //form is closing so tidy up and save settings
        private void FormGPS_FormClosing(object sender, FormClosingEventArgs e)
        {
           //Do you want to save open Job?
            if (isJobStarted)
            {
                FileSaveField("Resume"); 
                FileSaveField("");
                //if (result2 == DialogResult.Cancel) e.Cancel = true;
            }

            //save window settings
             if (WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.setWindow_Location = RestoreBounds.Location;
                Properties.Settings.Default.setWindow_Size = RestoreBounds.Size;
                Properties.Settings.Default.setWindow_Maximized = true;
                Properties.Settings.Default.setWindow_Minimized = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.setWindow_Location = Location;
                Properties.Settings.Default.setWindow_Size = Size;
                Properties.Settings.Default.setWindow_Maximized = false;
                Properties.Settings.Default.setWindow_Minimized = false;
            }
            else
            {
                Properties.Settings.Default.setWindow_Location = RestoreBounds.Location;
                Properties.Settings.Default.setWindow_Size = RestoreBounds.Size;
                Properties.Settings.Default.setWindow_Maximized = false;
                Properties.Settings.Default.setWindow_Minimized = true;
            }
            Properties.Settings.Default.Save();
       }

        //called everytime window is resized, clean up button positions
        private void FormGPS_Resize(object sender, EventArgs e)
        {
            LineUpManualBtns();
        }

        //user touches right of left and changes zoom or camera angle
        private void openGLControl_Click(object sender, EventArgs e)
        {
            Point point = openGLControl.PointToClient(Cursor.Position);
            if (point.Y > Height / 3)
            {
                if (point.X > Width / 2 )
                {
                    if (zoomValue <= 30)
                    {
                        if ((zoomValue -= 1.5) < 6.0) zoomValue = 6.0;
                    }

                    else
                    {
                        if ((zoomValue -= 4.0) < 6.0) zoomValue = 6.0;
                    }
                    camera.camSetDistance = zoomValue * zoomValue * -1;
                    SetZoom();

                }

                else
                {
                    if (zoomValue <= 30) zoomValue += 1.5;
                    else zoomValue += 4.0;
                    camera.camSetDistance = zoomValue * zoomValue * -1;
                    SetZoom();
                }
            }

            else
            {
                if (isIn3D)
                {
                    if (point.X < Width / 2)
                    {

                        camera.camPitch += 5;
                        if (camera.camPitch > -5) camera.camPitch = -5;
                    }

                    else
                    {
                        camera.camPitch -= 5;
                        if (camera.camPitch < -30) camera.camPitch = -30;
                    }
                }
            }
        }

// Procedures and Functions //---------------------------------------

        // Load Bitmaps And Convert To Textures

        public uint LoadGLTextures()
        {
            OpenGL gl = openGLControl.OpenGL;
            try
            {
                //  Tractor
                particleTexture = new Texture();
                particleTexture.Create(gl, @".\Dependencies\Compass.png");
                texture[0] = particleTexture.TextureName;
            }

            catch (System.Exception excep)
            {

                MessageBox.Show("Texture File Compass.png is Missing",excep.Message);
            }

            try
            {
                //  Background
                particleTexture = new Texture();
                particleTexture.Create(gl, @".\Dependencies\landscape.png");
                texture[1] = particleTexture.TextureName;
            }

            catch (System.Exception excep)
            {

                MessageBox.Show("Texture File LANDSCAPE.PNG is Missing", excep.Message);
            }

            try
            {
                //  Floor
                particleTexture = new Texture();
                particleTexture.Create(gl, @".\Dependencies\Floor.png");
                texture[2] = particleTexture.TextureName;
            }

            catch (System.Exception excep)
            {
               MessageBox.Show("Texture File FLOOR.PNG is Missing", excep.Message);
             }


            return texture[0];
        }

        //dialog for requesting user to save or cancel
        public int SaveOrNot()
        {
            using (var form = new FormSaveOrNot(this))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK) return 0;
                if (result == DialogResult.Ignore) return 1;
                if (result == DialogResult.Cancel) return 2;
                return 3;                
            }
        }

        //Bring up the dialog that shows GPS info
        private void GPSDataFormShow()
        {
            using (var form = new FormGPSData(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }

        //Bring up the dialog that shows GPS info
        private void VariablesFormShow()
        {
            Form form = new FormVariables(this);
            form.Show();
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
            section[0].positionLeft = (double)Properties.Settings.Default.setSection_position1;
            section[0].positionRight = (double)Properties.Settings.Default.setSection_position2;

            section[1].positionLeft = (double)Properties.Settings.Default.setSection_position2;
            section[1].positionRight = (double)Properties.Settings.Default.setSection_position3;

            section[2].positionLeft = (double)Properties.Settings.Default.setSection_position3;
            section[2].positionRight = (double)Properties.Settings.Default.setSection_position4;

            section[3].positionLeft = (double)Properties.Settings.Default.setSection_position4;
            section[3].positionRight = (double)Properties.Settings.Default.setSection_position5;

            section[4].positionLeft = (double)Properties.Settings.Default.setSection_position5;
            section[4].positionRight = (double)Properties.Settings.Default.setSection_position6;
        }

        //function to calculate the width of each section and update
        public void SectionCalcWidths()
        {
            for (int j = 0; j < MAXSECTIONS; j++)
            section[j].sectionWidth = (section[j].positionRight - section[j].positionLeft);

            //calculate tool width based on extreme right and left values
            vehicle.toolWidth = Math.Abs(section[0].positionLeft) + Math.Abs(section[vehicle.numberOfSections - 1].positionRight);

            //left and right tool position
            vehicle.toolFarLeftPosition = section[0].positionLeft;
            vehicle.toolFarRightPosition = section[vehicle.numberOfSections - 1].positionRight;
        }

        //force all the buttons same according to two main buttons
        private void ManualAllBtnsUpdate()
        {
            ManualBtnUpdate(0, btnSection1Man);
            ManualBtnUpdate(1, btnSection2Man);
            ManualBtnUpdate(2, btnSection3Man);
            ManualBtnUpdate(3, btnSection4Man);
            ManualBtnUpdate(4, btnSection5Man);
        }

        //line up section On Off Auto buttons based on how many there are
        public void LineUpManualBtns()
        {
            int top = 120;

            switch (vehicle.numberOfSections)
            {
                    

                case 1:
                    btnSection1Man.Left = this.Width / 2 - 50;
                    btnSection1Man.Top = this.Height - top;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = false;
                    btnSection3Man.Visible = false;
                    btnSection4Man.Visible = false;
                    btnSection5Man.Visible = false;
                    break;

                case 2:
                    btnSection1Man.Left = this.Width / 2 - 100;
                    btnSection1Man.Top = this.Height - top;
                    btnSection2Man.Left = this.Width / 2;
                    btnSection2Man.Top = this.Height - top;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = false;
                    btnSection4Man.Visible = false;
                    btnSection5Man.Visible = false;
                     break;

                case 3:
                    btnSection1Man.Left = this.Width / 2 - 150;
                    btnSection1Man.Top = this.Height - top;
                    btnSection2Man.Left = this.Width / 2 - 50;
                    btnSection2Man.Top = this.Height - top;
                    btnSection3Man.Left = this.Width / 2 + 50;
                    btnSection3Man.Top = this.Height - top;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = true;
                    btnSection4Man.Visible = false;
                    btnSection5Man.Visible = false;
                    break;

                case 4:
                    btnSection1Man.Left = this.Width / 2 - 200;
                    btnSection1Man.Top = this.Height - top;
                    btnSection2Man.Left = this.Width / 2 - 100;
                    btnSection2Man.Top = this.Height - top;
                    btnSection3Man.Left = this.Width / 2;
                    btnSection3Man.Top = this.Height - top;
                    btnSection4Man.Left = this.Width / 2 + 100;
                    btnSection4Man.Top = this.Height - top;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = true;
                    btnSection4Man.Visible = true;
                    btnSection5Man.Visible = false;
                    break;

                case 5:
                    btnSection1Man.Left = this.Width / 2 - 250;
                    btnSection1Man.Top = this.Height - top;
                    btnSection2Man.Left = this.Width / 2 - 150;
                    btnSection2Man.Top = this.Height - top;
                    btnSection3Man.Left = this.Width / 2 - 50;
                    btnSection3Man.Top = this.Height - top;
                    btnSection4Man.Left = this.Width / 2 + 50;
                    btnSection4Man.Top = this.Height - top;
                    btnSection5Man.Left = this.Width / 2 + 150;
                    btnSection5Man.Top = this.Height - top;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = true;
                    btnSection4Man.Visible = true;
                    btnSection5Man.Visible = true;
                    break;

            }

            switch (vehicle.numberOfSections)
            {
                case 1:
                    btnSection1Man.Enabled = true;
                    btnSection2Man.Enabled = false;
                    btnSection3Man.Enabled = false;
                    btnSection4Man.Enabled = false;
                    btnSection5Man.Enabled = false;
                    break;

                case 2:
                    btnSection1Man.Enabled = true;
                    btnSection2Man.Enabled = true;
                    btnSection3Man.Enabled = false;
                    btnSection4Man.Enabled = false;
                    btnSection5Man.Enabled = false;
                    break;

                case 3:
                    btnSection1Man.Enabled = true;
                    btnSection2Man.Enabled = true;
                    btnSection3Man.Enabled = true;
                    btnSection4Man.Enabled = false;
                    btnSection5Man.Enabled = false;
                    break;

                case 4:
                    btnSection1Man.Enabled = true;
                    btnSection2Man.Enabled = true;
                    btnSection3Man.Enabled = true;
                    btnSection4Man.Enabled = true;
                    btnSection5Man.Enabled = false;
                    break;

                case 5:
                    btnSection1Man.Enabled = true;
                    btnSection2Man.Enabled = true;
                    btnSection3Man.Enabled = true;
                    btnSection4Man.Enabled = true;
                    btnSection5Man.Enabled = true;
                    break;
            }
        }

        //update individual btn based on state after push
        private void ManualBtnUpdate(int sectNumber, Button btn)
        {
            switch (section[sectNumber].manBtnState)
            {
                case manBtn.Off:
                    section[sectNumber].manBtnState = manBtn.Auto;
                    btn.Image = global::AgOpenGPS.Properties.Resources.SectionAuto;
                    break;

                case manBtn.Auto:
                    section[sectNumber].manBtnState = manBtn.On;
                    btn.Image = global::AgOpenGPS.Properties.Resources.SectionOn;
                    break;

                case manBtn.On:
                    section[sectNumber].manBtnState = manBtn.Off;
                    btn.Image = global::AgOpenGPS.Properties.Resources.SectionOff;
                    break;
            }
        }

        //request a new job
        public void JobNew()
        {            
            isJobStarted = true;

            //update button image to close
            btnNewJob.Image = global::AgOpenGPS.Properties.Resources.JobActive;

            btnManualOffOn.Enabled = true;
            manualBtnState = btnStates.Off;
            btnManualOffOn.Image = global::AgOpenGPS.Properties.Resources.ManualOff;
           
            btnSectionOffAutoOn.Enabled = true;
            autoBtnState = btnStates.Off;
            btnSectionOffAutoOn.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;
            
            btnABLine.Enabled = true;
            btnSnapToAB.Enabled = true;
            btnContour.Enabled = true;

            ABLine.abHeading = 0.00;

            LineUpManualBtns();
        }

        //close the current job
        public void JobClose()
        {
            //turn auto button off
            autoBtnState = btnStates.Off;
            btnSectionOffAutoOn.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;

            //turn section buttons all OFF and zero square meters
            for (int j = 0; j < MAXSECTIONS; j++)
            {
                section[j].isAllowedOn = false;
                section[j].manBtnState = manBtn.On;
                section[j].squareMetersSection=0;
             }

            //turn manual button off
            manualBtnState = btnStates.Off;
            btnManualOffOn.Image = global::AgOpenGPS.Properties.Resources.ManualOff;

            //Update the button colors and text
            ManualAllBtnsUpdate();

            //enable disable manual buttons
            LineUpManualBtns();

            btnSection1Man.Enabled = false;
            btnSection2Man.Enabled = false;
            btnSection3Man.Enabled = false;
            btnSection4Man.Enabled = false;
            btnSection5Man.Enabled = false;
           
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
            ct.stripList.Clear();
            if (ct.ptList != null) ct.ptList.Clear();
            if (ct.guideList != null) ct.guideList.Clear();

            //reset the buttons
            btnABLine.Enabled = false;
            btnSnapToAB.Enabled = false;
            btnContour.Enabled = false;

            ct.isContourBtnOn = false;
            ct.isContourOn = false;

            //change images to reflect on off
            this.btnABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineOff;
            this.btnContour.Image = global::AgOpenGPS.Properties.Resources.ContourOff;
            
            //fix ManualOffOnAuto buttons
            btnManualOffOn.Enabled = false;
            manualBtnState = btnStates.Off;
            btnManualOffOn.Image = global::AgOpenGPS.Properties.Resources.ManualOff;

            //fix auto button
            btnSectionOffAutoOn.Enabled = false;
            autoBtnState = btnStates.Off;
            btnSectionOffAutoOn.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;

            //change the job button image back to new Job
            btnNewJob.Image = global::AgOpenGPS.Properties.Resources.JobClosed;


            //reset all the ABLine stuff
            ABLine.refPoint1 = new vec3(0.2, 0.0, 0.2);
            ABLine.refPoint2 = new vec3(0.3, 0.0, 0.3);

            ABLine.refABLineP1 = new vec3(0.0, 0.0, 0.0);
            ABLine.refABLineP2 = new vec3(0.0, 0.0, 1.0);

            ABLine.currentABLineP1 = new vec3(0.0, 0.0, 0.0);
            ABLine.currentABLineP2 = new vec3(0.0, 0.0, 1.0);

            ABLine.abHeading = 0.0;
            ABLine.isABLineSet = false;
            ABLine.isABLineBeingSet = false;
            ABLine.passNumber = 0;

            //reset acre and distance counters
            totalDistance = 0;
            totalSquareMeters = 0;
        }

        //Does the logic to process section on off requests
        private void ProcessSectionOnOffRequests()
        {
            //if (pn.speed > 0.2)
            {
                for (int j = 0; j < vehicle.numberOfSections; j++)
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

        //build the byte for individual realy control
        private void BuildSectionRelayByte()
        {
            byte set = 1;
            byte reset = 254;
            modcom.relaySectionControl[0] = (byte)0;

            for (int j = 0; j < MAXSECTIONS; j++)
            {
                //set if on, reset bit if off
                if (section[j].isSectionOn) modcom.relaySectionControl[0] = (byte)(modcom.relaySectionControl[0] | set);
                else modcom.relaySectionControl[0] = (byte)(modcom.relaySectionControl[0] & reset);

                //move set and reset over 1 bit left
                set = (byte)(set << 1);
                reset = (byte)(reset << 1);
                reset = (byte)(reset + 1);
            }
        }

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
            gl.Perspective(fovy, (double)openGLControl.Width / (double)openGLControl.Height, 1, camDistanceFactor * camera.camSetDistance);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

// Buttons //-----------------------------------------------------------------------

        //new and close job (Field for user)
        private void btnNewJob_Click(object sender, EventArgs e)
        {
            //bring up dialog if no job active, close job if one is
            if (!isJobStarted)
            {
                using (var form = new FormJob(this))
                {
                    var result = form.ShowDialog();

                    //set the image on button accordingly
                    if (isJobStarted) btnNewJob.Image = global::AgOpenGPS.Properties.Resources.JobActive;
                    else btnNewJob.Image = global::AgOpenGPS.Properties.Resources.JobClosed;
                }
            }

            else
            {
                int choice = SaveOrNot();

                switch (choice)
                {
                    //OK
                    case 0:
                        FileSaveField("Resume");
                        FileSaveField("");
                        JobClose();
                        break;
                    //Ignore and return
                    case 1:
                        break;

                    //Don't Save
                    case 2:
                        FileSaveField("Resume");
                        JobClose();
                        break;
                }
            }            
        }

        //ABLine
        private void btnABLine_Click(object sender, EventArgs e)
        {
            using (var form = new FormABLine(this))
            {
                ABLine.isABLineBeingSet = true;
                txtDistanceOffABLine.Visible = true;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)  
                { 
                    ABLine.isABLineBeingSet = false;
                    btnSnapToAB.Enabled = true;
                }

                //change image to reflect on off
                this.btnABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineOn;

                if (result == DialogResult.Cancel)
                {
                    ABLine.isABLineBeingSet = false;
                    txtDistanceOffABLine.Visible = false;
                    btnSnapToAB.Enabled = false;
                    //change image to reflect on off
                    this.btnABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineOff;

                }

            }
        }

        private void btnABSnapToAB_Click(object sender, EventArgs e)
        {
            ABLine.snapABLine();
        }

        private void btnMinMax_Click(object sender, EventArgs e)
        {
            if (zoomValue < 40) zoomValue = 80;
            else zoomValue = 20;
            camera.camSetDistance = zoomValue * zoomValue * -1;
            SetZoom();

        }

        //2D and 3D toggle
        private void btn2D3D_Click(object sender, EventArgs e)
        {

            if (camera.camPitch == -15 | isIn3D)
            {
                camera.camPitch = -90;
                this.btn2D3D.Image = global::AgOpenGPS.Properties.Resources.Icon_2D;
                isIn3D = false;
                //player.SoundLocation = @".\Dependencies\TurnOn.wav";
                //player.Play();

            }
            else
            {
                camera.camPitch = -15;
                this.btn2D3D.Image = global::AgOpenGPS.Properties.Resources.Icon_3D;
                isIn3D = true;
                //player.SoundLocation = @".\Dependencies\TurnOff.wav";
                //player.Play();

            }

            Properties.Settings.Default.setCam_pitch = camera.camPitch;
            Properties.Settings.Default.Save();
            SetZoom();
        }

        //button for Manual On Off of the sections
        private void btnManualOffOn_Click(object sender, EventArgs e)
        {
            switch (manualBtnState)
            {
                case btnStates.Off:
                    manualBtnState = btnStates.On;
                    btnManualOffOn.Image = global::AgOpenGPS.Properties.Resources.ManualOn;

                    //if Auto is on, turn it off
                    autoBtnState = btnStates.Off;
                    btnSectionOffAutoOn.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;


                    //turn all the sections allowed and update to ON!! Auto changes to ON
                    for (int j = 0; j < vehicle.numberOfSections; j++)
                    {
                        section[j].isAllowedOn = true;
                        section[j].manBtnState = manBtn.Auto;
                    }

                    ManualAllBtnsUpdate();
                    break;

                case btnStates.On:
                    manualBtnState = btnStates.Off;
                    btnManualOffOn.Image = global::AgOpenGPS.Properties.Resources.ManualOff;

                    //turn section buttons all OFF or Auto if SectionAuto was on or off
                        for (int j = 0; j < vehicle.numberOfSections; j++)
                        {
                            section[j].isAllowedOn = false;
                            section[j].manBtnState = manBtn.On;
                        }

                    //Update the button colors and text
                    ManualAllBtnsUpdate();
                    break;
            }

        }

        private void btnSectionOffAutoOn_Click(object sender, EventArgs e)
        {
            switch (autoBtnState)
            {
                case btnStates.Off:
                    autoBtnState = btnStates.Auto;                    
                    btnSectionOffAutoOn.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOn;

                    //turn off manual if on
                    manualBtnState = btnStates.Off;
                    btnManualOffOn.Image = global::AgOpenGPS.Properties.Resources.ManualOff;
                
                    //turn all the sections allowed and update to ON!! Auto changes to ON
                    for (int j = 0; j < vehicle.numberOfSections; j++)
                    {
                        section[j].isAllowedOn = true;
                        section[j].manBtnState = manBtn.Off;
                    }

                    ManualAllBtnsUpdate();
                    break;

                case btnStates.Auto:
                    autoBtnState = btnStates.Off;
                    
                    btnSectionOffAutoOn.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;

                    //turn section buttons all OFF or Auto if SectionAuto was on or off
                    for (int j = 0; j < vehicle.numberOfSections; j++)
                    {
                        section[j].isAllowedOn = false;
                        section[j].manBtnState = manBtn.On;
                    }

                    //Update the button colors and text
                    ManualAllBtnsUpdate();
                    break;
            }

        }

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

        //Settings    
        private void btnSettings_Click(object sender, EventArgs e)
        {
             SettingsPageOpen(0);
        }

        private void stripBtnResetDistance_ButtonClick(object sender, EventArgs e)
        {
            userDistance = 0;
        }

        private void btnContour_Click(object sender, EventArgs e)
        {
            ct.isContourBtnOn = !ct.isContourBtnOn;
            if (ct.isContourBtnOn)
            {
                btnContour.Image = global::AgOpenGPS.Properties.Resources.ContourOn;
            }
            else
            {
                btnContour.Image = global::AgOpenGPS.Properties.Resources.ContourOff;
            }
        }

        private void btnPerimeter_Click(object sender, EventArgs e)
        {
            if (periArea.isBtnPerimeterOn && periArea.periList.Count > 0)
            {
                periArea.isBtnPerimeterOn = false;
                //btnPerimeter.Text = "Paused";
                btnPerimeter.Image = global::AgOpenGPS.Properties.Resources.PeriDone;
                return;
            }

            //periArea.isBtnPerimeterOn = !periArea.isBtnPerimeterOn;

            if (!periArea.isBtnPerimeterOn && periArea.periList.Count > 0)
              {
                  periArea.periList.Clear();
                  //btnPerimeter.Text = "Cleared";
                  btnPerimeter.Image = global::AgOpenGPS.Properties.Resources.PeriArea;
                  return;       
              }

             if (!periArea.isBtnPerimeterOn && periArea.periList.Count == 0)
              {
                  //btnPerimeter.Text = "Logging";
                  btnPerimeter.Image = global::AgOpenGPS.Properties.Resources.PeriDraw;
                  periArea.isBtnPerimeterOn = true;
              }
         }


// Menu items //------------------------------------------------------------------

        private void polygonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDrawPolygons = !isDrawPolygons;
            polygonsToolStripMenuItem.Checked = !polygonsToolStripMenuItem.Checked;
        }

        private void menuJobNew_Click(object sender, EventArgs e)
        {
            JobNew();
        }

        private void menuJobClose_Click(object sender, EventArgs e)
        {
            JobClose();
        }

        private void menuItemVehicleToolStrip_Click(object sender, EventArgs e)
        {
            SettingsPageOpen(0);
        }

        private void saveFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSaveField("");
        }

        private void menuItemCOMPortsToolStrip_Click(object sender, EventArgs e)
        {
            SettingsCommunications();
        }

        private void sectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsPageOpen(2);
        }

        private void gPSDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GPSDataFormShow();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FormAbout())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
 
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string appPath = Assembly.GetEntryAssembly().Location;
            //string filename = Path.Combine(Path.GetDirectoryName(appPath), "help.htm");
            Process.Start("help.htm");

        }
  
        private void variablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VariablesFormShow();
        }
       
        //load a vehicle
        private void loadVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOpenVehicle();
        }

        //save a vehicle
        private void saveVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSaveVehicle();
        }

        //menu item to reset the setting database
        private void resetALLToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult result2 = MessageBox.Show("Really Reset Everything?", "Reset settings",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result2 == DialogResult.Yes)
            {
                MessageBox.Show("Program will exit and reset");
                ResetAll();
            }
 
        }

        private void webCamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormWebCam();
            form.Show();
        }

        //is it metric selected
        private void metricToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isMetric = true;
            Properties.Settings.Default.setIsMetric = isMetric;
            Properties.Settings.Default.Save();
            metricToolStripMenuItem.Checked = true;
            imperialToolStripMenuItem.Checked = false;
        }

        //or imperial selected
        private void imperialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isMetric = false;
            Properties.Settings.Default.setIsMetric = isMetric;
            Properties.Settings.Default.Save();
            metricToolStripMenuItem.Checked = false;
            imperialToolStripMenuItem.Checked = true;
        }

        //which side is area line recorded on, right or left
        private void rightSideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isAreaOnRight = true;
            Properties.Settings.Default.setIsAreaRight = isAreaOnRight;
            Properties.Settings.Default.Save();
            rightSideToolStripMenuItem.Checked = true;
            leftSideToolStripMenuItem.Checked = false;
        }

        private void leftSideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isAreaOnRight = false;
            Properties.Settings.Default.setIsAreaRight = isAreaOnRight;
            Properties.Settings.Default.Save();
            rightSideToolStripMenuItem.Checked = false;
            leftSideToolStripMenuItem.Checked = true;
        }

        //turn grid on/off
        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isGridOn = !isGridOn;
            gridToolStripMenuItem.Checked = isGridOn;
            Properties.Settings.Default.setIsGridOn = isGridOn;
            Properties.Settings.Default.Save();
        }

        //turn Lighbar off on
        private void lightbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isLightbarOn = !isLightbarOn;
            lightbarToolStripMenuItem.Checked = isLightbarOn;
            Properties.Settings.Default.setIsLightbarOn = isLightbarOn;
            Properties.Settings.Default.Save();
        }
        
        #region Properties // ---------------------------------------------------------------------

        public string FixNorthing { get { return Convert.ToString(Math.Round(pn.northing, 2)); } }
        public string FixEasting { get { return Convert.ToString(Math.Round(pn.easting, 2)); } }
        public string Latitude { get { return Convert.ToString(Math.Round(pn.latitude,7)); } }
        public string Longitude { get { return Convert.ToString(Math.Round(pn.longitude,7)); } }
        public string SatsTracked { get { return Convert.ToString(pn.satellitesTracked); } }
        public string Altitude { get { return Convert.ToString(pn.altitude); }  }
        public string HDOP { get { return Convert.ToString(pn.hdop); }  }
        public string NMEAHz { get { return Convert.ToString(fixUpdateHz); } }
        public string PassNumber { get { return Convert.ToString(ABLine.passNumber); } }
        public string Heading { get { return Convert.ToString(Math.Round(glm.degrees(fixHeading), 1)); } }
        public string Status { get { if (pn.status == "A") return "Active"; else return "Void"; } }       
        public string FixQuality { get
        { 
            if (pn.fixQuality == 0) return "Invalid";  
            else if (pn.fixQuality == 1) return "GPS fix";  
            else if (pn.fixQuality == 2) return "DGPS fix";  
            else if (pn.fixQuality == 3) return "PPS fix";  
            else if (pn.fixQuality == 4) return "RTK fix";  
            else if (pn.fixQuality == 5) return "Float RTK";  
            else if (pn.fixQuality == 6) return "Estimated";  
            else if (pn.fixQuality == 7) return "Manual IP";  
            else if (pn.fixQuality == 8) return "Simulation";  
            else                         return "Unknown";    } }

        public string SpeedMPH { get { return Convert.ToString(Math.Round(pn.speed * 0.621371, 1)); } }
        public string SpeedKPH { get { return Convert.ToString(pn.speed); } }

        public string PeriAreaAcres { get { return Math.Round(periArea.area * 0.000247105, 1).ToString(); ; } }
        public string PeriAreaHectares { get { return Math.Round(periArea.area * 0.0001, 1).ToString(); ; } }

        public string GridFeet { get { return Math.Round(gridZoom * 3.28084, 0).ToString(); } }
        public string GridMeters { get { return Math.Round(gridZoom, 0).ToString(); } }

        public string Acres { get { return Math.Round(totalSquareMeters * 0.00024710499815078974633856493327535, 1).ToString(); } }
        public string Hectares { get { return Math.Round(totalSquareMeters * 0.0001, 1).ToString(); } }

        public string FixHeading { get { return Math.Round(fixHeading, 3).ToString(); } }
        public string FixHeadingSection { get { return Math.Round(fixHeadingSection, 2).ToString(); } }


#endregion properties
 

        /*
         * The order is:
         * The watchdog timer times out and runs this function tmrWatchdog_tick.
         * 20 times per second so statusUpdateCounter updates strip menu etc at 2 hz
         * it also makes sure there is new sentences showing up otherwise it shows **** No GGA....
         * saveCounter ticks 1 up 20x per second, used at end of draw routine every minute to save a backup of field
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

        //Timer runs at 20 hz and is THE clock of the whole program//
        private void tmrWatchdog_tick(object sender, EventArgs e)
        {

            //go see if data ready for draw and position updates
            tmrWatchdog.Enabled = false;
            ScanForNMEA();
            tmrWatchdog.Enabled = true;

           //every half second update all status
            if (statusUpdateCounter++ > 10)
            {
                //reset the counter
                statusUpdateCounter = 0;

                //counter used for saving field in background
                saveCounter++;
                if (isMetric)
                {
                    //acres on the master section soft control
                    this.btnSectionOffAutoOn.Text = Hectares;

                    btnSection1Man.Text = Math.Round(section[0].squareMetersSection * 0.0001, 2).ToString();
                    btnSection2Man.Text = Math.Round(section[1].squareMetersSection * 0.0001, 2).ToString();
                    btnSection3Man.Text = Math.Round(section[2].squareMetersSection * 0.0001, 2).ToString();
                    btnSection4Man.Text = Math.Round(section[3].squareMetersSection * 0.0001, 2).ToString();
                    btnSection5Man.Text = Math.Round(section[4].squareMetersSection * 0.0001, 2).ToString();

                    //area button
                    btnPerimeter.Text = PeriAreaHectares;

                    //status strip values
                    stripDistance.Text = "Dist: " + Convert.ToString(Math.Round(userDistance, 0)) + " m";
                    stripMPH.Text = "Kph: " + SpeedKPH;
                    stripGridZoom.Text = "Grid: " + GridMeters;
                    stripAcres.Text = "Ha: " + Hectares;
                }

                else
                {
                    //acres on the master section soft control
                    this.btnSectionOffAutoOn.Text = Acres;

                    btnSection1Man.Text = Math.Round(section[0].squareMetersSection * 0.00024710499815078974633856493327535, 2).ToString();
                    btnSection2Man.Text = Math.Round(section[1].squareMetersSection * 0.00024710499815078974633856493327535, 2).ToString();
                    btnSection3Man.Text = Math.Round(section[2].squareMetersSection * 0.00024710499815078974633856493327535, 2).ToString();
                    btnSection4Man.Text = Math.Round(section[3].squareMetersSection * 0.00024710499815078974633856493327535, 2).ToString();
                    btnSection5Man.Text = Math.Round(section[4].squareMetersSection * 0.00024710499815078974633856493327535, 2).ToString();

                    //area button
                    btnPerimeter.Text = PeriAreaAcres;

                    //status strip values
                    stripDistance.Text = "Feet: " + Convert.ToString(Math.Round(userDistance * 3.28084, 0));
                    stripMPH.Text = "MPH: " + SpeedMPH;
                    stripGridZoom.Text = "Grid: " + GridFeet + " '";
                    stripAcres.Text = "Acres: " + Acres;
                }

                //non metric fields
                stripHz.Text = "Hz:" + NMEAHz + " ms:" + ((int)frameTime).ToString();
                stripHeading.Text = "Dir: " + Heading + "\u00B0";
                //txtHeading.Text = Heading + "\u00B0";
                stripPassNumber.Text = "Pass: " + PassNumber;
                

                //update the online indicator
                if (recvCounter > 50)
                {
                    stripOnlineGPS.Value = 1;
                    textBoxRcv.Text = "************  NO GGA or RMC **************";
                }
                else stripOnlineGPS.Value = 100;
            }

 
            //wait till timer fires again.
        }


   }//class FormGPS
}//namespace AgOpenGPS




