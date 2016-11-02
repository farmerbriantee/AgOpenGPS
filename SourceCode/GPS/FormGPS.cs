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

//http://maps.google.com/maps?q=54.3%2C-111.10

namespace AgOpenGPS
{
    //the main form object
    public partial class FormGPS : Form
    {
        //class variables ----------------------------------------------------

        //maximum sections available
        const int MAXSECTIONS = 5;

        private const byte SET_1 = 1;
        private const byte SET_2 = 2;
        private const byte SET_3 = 4;
        private const byte SET_4 = 8;
        private const byte SET_5 = 16;
                            
        private const byte RESET_1 = 254;
        private const byte RESET_2 = 253;
        private const byte RESET_3 = 251;
        private const byte RESET_4 = 247;
        private const byte RESET_5 = 239;

        byte[] bufferArd = { 0 };


        //polygon mode for section drawing
        bool isDrawPolygons = false;
        bool isDrawVehicleTrack = true;

        //Current fix position
        public double fixPosX = 0.0;
        public double fixPosY = 0.0;
        public double fixPosZ = -7.0;

        //headings
        public double fixHeading = 0.0;
        public double fixHeadingCam = 0.0;
        public double fixHeadingSection = 0.0;
        public double fixHeadingDelta = 0;

        public double deltaTurn = 32; 

        //storage for the cos and sin of heading
        public double cosHeading = 1.0;
        public double sinHeading = 0.0;

        //Is it in 2D or 3D
        public bool isIn3D = true;

        //Zoom variables
        double gridZoom;
        double zoomValue = 10.06;

        // Storage For Our Tractor, implement, background etc Textures
        Texture particleTexture;
        public uint[] texture = new uint[3];	
		
        //bool for whether or not a job is active
        public bool isJobStarted = false;

        //the master on off for all sections
        public bool isMasterSectionOn = false;

        //if we are saving a file
        public bool isSavingFile = false;

// Instances --------------------------------------------------------------------------

        //Instances made in FormGPS_Load if not new here.
        //create the scene camera
        public CCamera camera = new CCamera();

        //create world grid
        CWorldGrid worldGrid;

        //create instance of a stopwatch
        Stopwatch sw = new Stopwatch();

        //Parsing object of NMEA sentences
        public CNMEA pn;

        //create an array of sections, so far only 5 section
        public CSection[] section = new CSection[MAXSECTIONS];


        //ABLine Instance
        public CABLine ABLine;

        //a brand new vehicle
        public CVehicle vehicle;

        //create a sound player object
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

// Forms //................................................................................

        //All the forms related procedures

        /// Constructor, Initializes a new instance of the "FormGPS" class.
        public FormGPS()
        {
            //winform initialization
            InitializeComponent();

            sw.Start();//start the stopwatch
        }

        //Initialize items before the form Loads or is visible
        private void FormGPS_Load(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //create the world grid
            worldGrid = new CWorldGrid(gl);

            //our vehicle made with gl object and pointer of mainform
            vehicle = new CVehicle(gl, this);

            //our NMEA parser
            pn = new CNMEA(this);

            //get the pitch of camera from settings
            camera.camPitch = Properties.Settings.Default.setCam_pitch;

            //change 2D or 3D icon accordingly on button
            if (camera.camPitch == -20)  {
                this.btn2D3D.Image = global::AgOpenGPS.Properties.Resources.Icon_3D;   isIn3D = true;  }
            else  {
                this.btn2D3D.Image = global::AgOpenGPS.Properties.Resources.Icon_2D;   isIn3D = false; }

            //set baud and port from last time run
            baudRate = Properties.Settings.Default.setPort_baudRate;
            portName = Properties.Settings.Default.setPort_portName;

            //same for Arduino port
            portNameArduino = Properties.Settings.Default.setPort_portNameArduino;
            wasArduinoConnectedLastRun = Properties.Settings.Default.setPort_wasArduinoConnected;

            //get the number of sections from settings
            vehicle.numberOfSections = Properties.Settings.Default.setVehicle_numSections;

            //from settings grab the vehicle specifics
            vehicle.toolOverlap = Properties.Settings.Default.setVehicle_toolOverlap;
            vehicle.toolForeAft = Properties.Settings.Default.setVehicle_toolForeAft;
            vehicle.antennaHeight = Properties.Settings.Default.setVehicle_antennaHeight;
            vehicle.lookAhead = Properties.Settings.Default.setVehicle_lookAhead;
            vehicle.isHitched = Properties.Settings.Default.setVehicle_isHitched;
            
            //create a new section and set left and right positions
            //created whether used or not, saves restarting program
            section[0] = new CSection(this);
            section[1] = new CSection(this);
            section[2] = new CSection(this);
            section[3] = new CSection(this);
            section[4] = new CSection(this);

            //Set width of section and positions for each section
            SectionSetPosition();

            //Calculate total width and each section width
            SectionCalcWidths();
 
            //create the ABLine instance
            ABLine = new CABLine(gl, this);

            //Can't close a job if you haven't started
            menuCloseJob.Enabled = false;

            //try and open, if not go to setting up port
            SerialPortOpenGPS();

            //Only if Arduino was connected successfully last run
            if (wasArduinoConnectedLastRun)
                    SerialPortOpenArduino();

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

          }
   
        //form is closing so tidy up and save settings
        private void FormGPS_FormClosing(object sender, FormClosingEventArgs e)
        {
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

            //turn everything off
            for (int j = 0; j < MAXSECTIONS; j++)
            {
                section[j].isSectionOn = false;
            }

            SectionControlOutToArduino();

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
                particleTexture.Create(gl, @".\Dependencies\Vehicle.png");
                texture[0] = particleTexture.TextureName;
            }

            catch (System.Exception excep)
            {

                MessageBox.Show("Texture File Vehicle.png is Missing",excep.Message);
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


            return texture[0];
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
            section[0].positionLeft = (double)Properties.Settings.Default.setSection_nudSpin1;
            section[0].positionRight = (double)Properties.Settings.Default.setSection_nudSpin2;

            section[1].positionLeft = (double)Properties.Settings.Default.setSection_nudSpin2;
            section[1].positionRight = (double)Properties.Settings.Default.setSection_nudSpin3;

            section[2].positionLeft = (double)Properties.Settings.Default.setSection_nudSpin3;
            section[2].positionRight = (double)Properties.Settings.Default.setSection_nudSpin4;

            section[3].positionLeft = (double)Properties.Settings.Default.setSection_nudSpin4;
            section[3].positionRight = (double)Properties.Settings.Default.setSection_nudSpin5;

            section[4].positionLeft = (double)Properties.Settings.Default.setSection_nudSpin5;
            section[4].positionRight = (double)Properties.Settings.Default.setSection_nudSpin6;
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

        //request a new job
        private void JobNew()
        {
            btnNewJob.Visible = false;
            isJobStarted = true;
            menuCloseJob.Enabled = true;
            menuNewJob.Enabled = false;

            chkSectionsOnOff.Enabled = true;

            btnABLine.Enabled = true;

            btnSnapToAB.Enabled = true;

            ABLine.abHeading = 0.00;
        }

        //close the current job
        private void JobClose()
        {
            isJobStarted = false;
            btnNewJob.Visible = true;

            for (int j = 0; j < MAXSECTIONS; j++)
            {
                //clean out the lists
                section[j].patchList.Clear();
                if (section[j].triangleList != null) section[j].triangleList.Clear();

                //turn all the sections off
                section[j].isSectionOn = false;
                isMasterSectionOn = false;
            }

            menuCloseJob.Enabled = false;
            menuNewJob.Enabled = true;

            btnABLine.Enabled = false;
            btnSnapToAB.Enabled = false;

            //change image to reflect on off
            this.btnABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineOff;


            //fix the section on off to off
            chkSectionsOnOff.Enabled = false;
            chkSectionsOnOff.Checked = false;
            this.chkSectionsOnOff.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;

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
           for (int j = 0; j < vehicle.numberOfSections; j++)
            {
                //lblTest.Text = section[j].sectionOnTimer.ToString();
                //lblTest2.Text = section[j].sectionOffTimer.ToString();

                //Turn ON
                //if requested to be on, set the timer to 10 (2 seconds) = 5 frames per second
                if (section[j].sectionOnRequest && !section[j].sectionOnOffCycle)
                {
                    section[j].sectionOnTimer = (int)(pn.speed*vehicle.lookAhead);
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
                    section[j].sectionOffTimer = 7;
                }
                
                if (!section[j].sectionOffRequest) section[j].sectionOffTimer = 7;

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

        //Reset everything action
        private void okThenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //delete the default config file and remake it with restart
            Properties.Settings.Default.setVehicle_toolOverlap = 0.5;
            Properties.Settings.Default.setVehicle_toolForeAft = -2;
            Properties.Settings.Default.setVehicle_antennaHeight = 3.0;
            Properties.Settings.Default.setVehicle_lookAhead = 2.0;
            Properties.Settings.Default.setVehicle_isHitched = true;

            Properties.Settings.Default.setSection_nudSpin1 = -8;
            Properties.Settings.Default.setSection_nudSpin2 = -3;
            Properties.Settings.Default.setSection_nudSpin3 = 3;
            Properties.Settings.Default.setSection_nudSpin4 = 8;
            Properties.Settings.Default.setSection_nudSpin5 = 0;
            Properties.Settings.Default.setSection_nudSpin6 = 0;

            Properties.Settings.Default.setVehicle_numSections = 3;
            Properties.Settings.Default.setVehicle_toolWidth = 16.0;

            Properties.Settings.Default.setCam_pitch = -20;
            Properties.Settings.Default.setPort_baudRate = 4800;
            Properties.Settings.Default.setPort_portName = "COM Reset";
            Properties.Settings.Default.setPort_wasArduinoConnected = false;
            Properties.Settings.Default.setPort_portNameArduino = "COM SecReset";

            Properties.Settings.Default.setWindow_Maximized = false;
            Properties.Settings.Default.setWindow_Minimized = false;

            //Properties.Settings.Default.setDelay_camera = 4;
            //Properties.Settings.Default.setDelay_section = 5;
            //Properties.Settings.Default.setDelay_vehicle = 2;

            Properties.Settings.Default.Save();

            Application.Exit();
        }

   // Menu items //------------------------------------------------------------------

        private void polygonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDrawPolygons = !isDrawPolygons;
            polygonsToolStripMenuItem.Checked = !polygonsToolStripMenuItem.Checked;
        }

        private void vehicleTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDrawVehicleTrack = !isDrawVehicleTrack;
            vehicleTrackToolStripMenuItem.Checked = !vehicleTrackToolStripMenuItem.Checked;
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
            SettingsPageOpen(1);
        }

        private void menuItemCOMPortsToolStrip_Click(object sender, EventArgs e)
        {
            SettingsPageOpen(0);
        }

        private void sectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsPageOpen(2);
        }

        private void gPSDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GPSDataFormShow();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOpenField();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSaveField();
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

// Buttons //-----------------------------------------------------------------------

        private void btnNewJob_Click(object sender, EventArgs e)
        {
            JobNew();
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

        //Zoom functions
        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (zoomValue <= 12)  zoomValue += 1.0;
            else zoomValue += 4.0;
            camera.camSetDistance = zoomValue * zoomValue * -1;
            SetZoom();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (zoomValue <= 15)
            {
                if ((zoomValue -= 1.0) < 4.0) zoomValue = 4.0;
            }

            else 
            {
                if ((zoomValue -= 4.0) < 4.0) zoomValue = 4.0;
            }
            camera.camSetDistance = zoomValue * zoomValue * -1;
            SetZoom();

        }

        private void btnMinMax_Click(object sender, EventArgs e)
        {
            if (zoomValue < 15) zoomValue = 50;
            else zoomValue = 12;
            //zoomValue = 12.0;
            camera.camSetDistance = zoomValue * zoomValue * -1;
            SetZoom();

        }

        private void SetZoom()
        {
            //match grid to cam distance and redo perspective
            if (camera.camSetDistance <= -20000) gridZoom = 2000;
            if (camera.camSetDistance >= -20000 && camera.camSetDistance < -10000) gridZoom = 2000;
            if (camera.camSetDistance >= -10000 && camera.camSetDistance < -5000) gridZoom = 1000;
            if (camera.camSetDistance >= -5000 && camera.camSetDistance < -2000) gridZoom = 503;
            if (camera.camSetDistance >= -2000 && camera.camSetDistance < -1000) gridZoom = 201.2;
            if (camera.camSetDistance >= -1000 && camera.camSetDistance < -500) gridZoom = 100.6;
            if (camera.camSetDistance >= -500 && camera.camSetDistance < -250) gridZoom = 50.3;
            if (camera.camSetDistance >= -250 && camera.camSetDistance < -100) gridZoom = 25.15;
            if (camera.camSetDistance >= -100 && camera.camSetDistance < -50) gridZoom = 10.06;
            if (camera.camSetDistance >= -50 && camera.camSetDistance < -10) gridZoom = 5.03;

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            //  Create a perspective transformation.
            gl.Perspective(50.0f, (double)openGLControl.Width / (double)openGLControl.Height, 1, -2 * camera.camSetDistance);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        //2D and 3D toggle
        private void btn2D3D_Click(object sender, EventArgs e)
        {

            if (camera.camPitch == -20)
            {
                camera.camPitch = -90;
                this.btn2D3D.Image = global::AgOpenGPS.Properties.Resources.Icon_2D;
                isIn3D = false;
                //player.SoundLocation = @".\Dependencies\TurnOn.wav";
                //player.Play();

            }
            else
            {
                camera.camPitch = -20;
                this.btn2D3D.Image = global::AgOpenGPS.Properties.Resources.Icon_3D;
                isIn3D = true;
                //player.SoundLocation = @".\Dependencies\TurnOff.wav";
                //player.Play();

            }

            Properties.Settings.Default.setCam_pitch = camera.camPitch;
            Properties.Settings.Default.Save();
            SetZoom();
        }

        //Main sections on off control
        private void chkSectionsOnOff_CheckedChanged(object sender, EventArgs e)
        {
             //turning the sections all ON
            if (chkSectionsOnOff.Checked)
            {
                //set master flag on
                isMasterSectionOn = true;

                //change the image on button to on
                this.chkSectionsOnOff.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOn;
            }

            //turning the sections all OFF   
            else
            {
                //change the image on button to off
                this.chkSectionsOnOff.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;

                //turn off the master section on off flag
                isMasterSectionOn = false;

                for (int j = 0; j < vehicle.numberOfSections; j++)
                {
                    section[j].TurnSectionOff();
                    section[j].sectionOnOffCycle = false;
                    section[j].sectionOffRequest = true;
                    section[j].sectionOnRequest = false;
                    section[j].sectionOffTimer = 0;
                    section[j].sectionOnTimer = 0;
                }
            }

        }

        //Settings    
        private void btnSettings_Click(object sender, EventArgs e)
        {
             SettingsPageOpen(1);
        }

        private void stripBtnResetDistance_ButtonClick(object sender, EventArgs e)
        {
            userDistance = 0;
        }

       

#region Properties // ---------------------------------------------------------------------

        public string FixNorthing { get { return Convert.ToString(Math.Round(pn.northing, 2)); } }
        public string FixEasting { get { return Convert.ToString(Math.Round(pn.easting, 2)); } }
        public string Latitude { get { return Convert.ToString(Math.Round(pn.latitude,7)); } }
        public string Longitude { get { return Convert.ToString(Math.Round(pn.longitude,7)); } }
        public string SatsTracked { get { return Convert.ToString(pn.satellitesTracked); } }
        public string Altitude { get { return Convert.ToString(pn.altitude); }  }
        public string HDOP { get { return Convert.ToString(pn.hdop); }  }
        public string SpeedMPH { get { return Convert.ToString(Math.Round(pn.speed * 0.621371, 1)); } }
        public string SpeedKPH { get { return Convert.ToString(pn.speed); } }
        public string PassNumber { get { return Convert.ToString(ABLine.passNumber); } }
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

        public string Grid { get { return Math.Round(gridZoom*3.28084/16,0).ToString(); } }
        public string Acres { get { return Math.Round(totalSquareMeters / 4046.8627, 2).ToString(); } }

#endregion properties
 
        private void tmrWatchdog_tick(object sender, EventArgs e)
        {
            this.lblLatitude.Text = Latitude;
            this.lblLongitude.Text = Longitude;

            //acres on the master section soft control
            this.chkSectionsOnOff.Text = Acres;

            //status strip values
            stripDistance.Text = "Feet: " + Convert.ToString(Math.Round(userDistance * 3.28084, 0));
            stripMPH.Text = "MPH: " + SpeedMPH;
            stripPassNumber.Text = "Pass: " + PassNumber;
            stripGridZoom.Text = "Grid: " + Grid + " Acres";
            stripAcres.Text = "Acres: " + Acres;

            //update the online indicator
            if (recvCounter > 16)
            {
                stripOnlineGPS.Value = 1;
            }
            else stripOnlineGPS.Value = 100;

            //textBox1.Text = pn.theSent;
            //textBox1.SelectionStart = textBox1.Text.Length;
            //textBox1.ScrollToCaret();
        }

        private void lblTest_Click(object sender, EventArgs e)
        {

        }


 
   }//class FormGPS
}//namespace AgOpenGPS




