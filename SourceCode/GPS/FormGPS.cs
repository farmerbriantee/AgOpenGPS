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

        //Current fix position
        public double fixPosX = 0.0;
        public double fixPosY = 0.0;
        public double fixPosZ = -7.0;

        //headings
        public double fixHeading = 0.0;
        public double fixHeadingCam = 0.0;
        public double fixHeadingSection = 0.0;
        public double fixHeadingDelta = 0;

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

#region Forms //................................................................................

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

#endregion

#region OpenGL //-------------------------------------------------------------------
        /// Handles the OpenGLDraw event of the openGLControl control.
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {

            //sw.Stop();
            //int FPS = Convert.ToInt16(1 / (sw.Elapsed.TotalMilliseconds / 1000));
            //sw.Reset();
            ////start the watch and time till it gets back here
            //sw.Start();

            //if there is new data go update everything first.
            UpdateFixPosition();

            //Update the port counter
            recvCounter++;

            ProcessSectionOnOffRequests();

            SectionControlOutToArduino();
            
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();

            //camera does translations and rotations
            camera.SetWorldCam(gl, fixPosX, fixPosY, fixPosZ, fixHeadingCam);

            //Draw the world grid based on camera position
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            gl.Disable(OpenGL.GL_TEXTURE_2D);
            worldGrid.DrawWorldGrid(gridZoom);

            // draw the current and reference AB Lines
            if (ABLine.isABLineSet | ABLine.isABLineBeingSet) ABLine.DrawABLines();

            //turn on blend for paths
            gl.Enable(OpenGL.GL_BLEND);
            gl.Disable(OpenGL.GL_DEPTH_TEST);

            //section patch color
            gl.Color(0.0f, 0.45f, 0.0f, 0.6f);
            
            if (isDrawPolygons) gl.PolygonMode(OpenGL.GL_FRONT, OpenGL.GL_LINE);

            //draw patches of sections
            for (int j = 0; j < vehicle.numberOfSections; j++)
            {
                //every time the section turns off and on is a new patch
                int patchCount = section[j].patchList.Count();

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (var triList in section[j].patchList)
                    {
                        //draw the triangle strip in each triangle strip
                        gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
                        int count2 = triList.Count();
                        for (int i = 0; i < count2; i++) gl.Vertex(triList[i].x, 0, triList[i].z);
                        gl.End();
                    }
                }
            }

            gl.PolygonMode(OpenGL.GL_FRONT, OpenGL.GL_FILL);
 
            //draw the tractor/implement
            vehicle.DrawVehicle();

            //gl.DrawText(100, 150, 1, 0, 0, "Verdana", 24, " fix " + Convert.ToString(fixHeading));
            //gl.DrawText(100, 180, 1, 0, 0, "Verdana", 24, " fixCam " + Convert.ToString(fixHeadingSection));
            //gl.DrawText(100, 210, 1, 1, 0, "Verdana", 24, " delta " + Convert.ToString(Math.Round(fixHeadingSection-fixHeading,3)));

            gl.Color(1.0f,1.0f,1.0f);


            gl.Disable(OpenGL.GL_BLEND);
            gl.Enable(OpenGL.GL_DEPTH_TEST);

            //// 2D Ortho --------------------------
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.PushMatrix();
            gl.LoadIdentity();

            //negative and positive on width, 0 at top to bottom ortho view
            gl.Ortho2D(-(double)Width / 2, (double)Width / 2, (double)Height, 0);

            //  Create the appropriate modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.PushMatrix();
            gl.LoadIdentity();

            //draw the background when in 3D
            if (isIn3D)
            {
                //the background
                double winLeftPos = -(double)Width / 2;
                double winRightPos = -winLeftPos;

                gl.Enable(OpenGL.GL_TEXTURE_2D);
                gl.BindTexture(OpenGL.GL_TEXTURE_2D, texture[1]);		// Select Our Texture
                gl.Begin(OpenGL.GL_TRIANGLE_STRIP);				// Build Quad From A Triangle Strip
                    gl.TexCoord(0, 0); gl.Vertex(winRightPos, 0.0); // Top Right
                    gl.TexCoord(1, 0); gl.Vertex(winLeftPos, 0.0); // Top Left
                    gl.TexCoord(0, 1); gl.Vertex(winRightPos, 0.2 * (double)Height); // Bottom Right
                    gl.TexCoord(1, 1); gl.Vertex(winLeftPos, 0.2 * (double)Height); // Bottom Left
                gl.End();						// Done Building Triangle Strip
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            }

            //LightBar if AB Line is set
            if (ABLine.isABLineSet | ABLine.isABLineBeingSet)
            {
                txtDistanceOffABLine.Visible = true;
                ABLine.DrawLightBar(openGLControl.Width, openGLControl.Height);
                txtDistanceOffABLine.Text = Convert.ToString(Math.Abs(ABLine.distanceFromCurrentLine));
                if (Math.Abs(ABLine.distanceFromCurrentLine) > 15.0) txtDistanceOffABLine.ForeColor = Color.Yellow;
                else  txtDistanceOffABLine.ForeColor = Color.LightGreen;
            }

            //AB line is not set
            else txtDistanceOffABLine.Visible = false;


            //finish openGL commands
            gl.Flush();

            //  Pop the modelview.
            gl.PopMatrix();

            //  back to the projection and pop it, then back to the model view.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.PopMatrix();
            gl.MatrixMode(OpenGL.GL_MODELVIEW);


            //reset point size
            gl.PointSize(1.0f);

            gl.Flush();

            //draw the section control window off screen buffer
            openGLControlBack.DoRender();
           
        }

         /// Handles the OpenGLInitialized event of the openGLControl control.
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //Load all the textures
            LoadGLTextures();

            //  Set the clear color.
            gl.ClearColor(0.5f, 0.5f, 0.5f, 1.0f);

            // Set The Blending Function For Translucency
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            gl.Enable(OpenGL.GL_CULL_FACE);
            gl.CullFace(OpenGL.GL_BACK);

            gl.PixelStore(OpenGL.GL_PACK_ALIGNMENT, 1);

            //set the camera to right distance
            SetZoom();
        }

        /// Handles the Resized event of the openGLControl control.
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            //  TODO: Set the projection matrix here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            //  Create a perspective transformation.
            gl.Perspective(50.0f, (double)openGLControl.Width / (double)openGLControl.Height, 1, -4 * camera.camSetDistance);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

#endregion

#region Procedures and Functions //---------------------------------------

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
        private void GPSDataShow()
        {
            using (var form = new FormGPSData(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
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

        //function to open a previously saved field
        private void FileOpenField()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            //get the directory where the fields are stored
            //string directoryName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+ "\\fields\\";
            string directoryName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AgOpenGPS\\Fields\\";

            //make sure the directory exists, if not, create it
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            //the initial directory, fields, for the open dialog
            ofd.InitialDirectory = directoryName;

            //When leaving dialog put windows back where it was
            ofd.RestoreDirectory = true;

            //set the filter to text files only
            ofd.Filter = "txt files (*.txt)|*.txt";

            //was a file selected
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = ofd.FileName;

                //make sure the file if fully valid and vehicle matches sections
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line2;
                    
                    line2 = reader.ReadLine();//Date time line                  
                    line2 = reader.ReadLine();//AB Line header

                    if (line2.IndexOf("$Heading") == -1)
                    {  MessageBox.Show("File is Corrupt");  return;  }

                    //read the boolean if AB is set
                    line2 = reader.ReadLine();
                    if ( (line2.IndexOf("True") == -1 && (line2.IndexOf("False") == -1)) )
                    {    MessageBox.Show("AB Line is Corrupt"); return; }
                  
                    line2 = reader.ReadLine();//just read and skip the heading line                
                    line2 = reader.ReadLine();//read the line $Sections

                    if (line2.IndexOf("$Sections") == -1)
                    { MessageBox.Show("Sections header is Corrupt"); return; }

                    //read number of sections
                    line2 = reader.ReadLine();
                    int numSects = int.Parse(line2);

                    //make sure sections in file matches sections set in current vehicle
                    if (vehicle.numberOfSections != numSects)
                    {  MessageBox.Show("Vehicle doesn't match this field");  return; }


                    for (int j = 0; j < vehicle.numberOfSections; j++)
                    { 
                        //now read number of patches, then how many vertex's
                        line2 = reader.ReadLine();
                        int patches = int.Parse(line2);

                        for (int k = 0; k < patches; k++)
                        {
 
                            line2 = reader.ReadLine();
                            int verts = int.Parse(line2);

                            for (int v = 0; v < verts; v++)
                            {
                                line2 = reader.ReadLine();
                            }
                        }
                    }

                    //read final area and header lines
                    line2 = reader.ReadLine();
                    if (line2.IndexOf("$totalSquareMeters") == -1)
                    {
                        MessageBox.Show("Meters header is Corrupt");
                        return;
                    }
                
                }
                //made it to here so file is mostly valid

                //close the existing job and reset everything
                this.JobClose();

                //and open a new job
                this.JobNew();

                //start to read the file
                string line;
                using (StreamReader reader = new StreamReader(fileName))
                {
                    //Date time line
                    line = reader.ReadLine();

                    //AB Line header
                    line = reader.ReadLine();

                    //read the boolean if AB is set
                    line = reader.ReadLine();
                    bool b = bool.Parse(line);

                    //If is true there is AB Line data
                    if (b)
                    {
                        //Heading, refPoint1x,z,refPoint2x,z
                        line = reader.ReadLine();

                        //separate it into the 4 words
                        string[] words = line.Split(',');
                        ABLine.abHeading = double.Parse(words[0]);
                        ABLine.refPoint1.x = double.Parse(words[1]);
                        ABLine.refPoint1.z = double.Parse(words[2]);
                        ABLine.refPoint2.x = double.Parse(words[3]);
                        ABLine.refPoint2.z = double.Parse(words[4]);

                        ABLine.refABLineP1.x = ABLine.refPoint1.x - Math.Sin(ABLine.abHeading) * 10000.0;
                        ABLine.refABLineP1.z = ABLine.refPoint1.z - Math.Cos(ABLine.abHeading) * 10000.0;

                        ABLine.refABLineP2.x = ABLine.refPoint1.x + Math.Sin(ABLine.abHeading) * 10000.0;
                        ABLine.refABLineP2.z = ABLine.refPoint1.z + Math.Cos(ABLine.abHeading) * 10000.0;

                        ABLine.isABLineSet = true;
                    }

                    //false so just read and skip the heading line
                    else line = reader.ReadLine();

                    //read the section and patch triangles...

                    //read the line $Sections
                    line = reader.ReadLine();

                    //read number of sections
                    line = reader.ReadLine();

                    //finally start loading triangles
                    vec3 vecFix = new vec3(0, 0, 0);

                    for (int j = 0; j < vehicle.numberOfSections; j++)
                    {
                        //now read number of patches, then how many vertex's
                        line = reader.ReadLine();
                        int patches = int.Parse(line);
                        
                        for (int k = 0; k < patches; k++)
                        {
                            section[j].triangleList = new List<vec3>();
                            section[j].patchList.Add(section[j].triangleList);

                            line = reader.ReadLine();
                            int verts = int.Parse(line);

                            for (int v = 0; v < verts; v++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');
                                vecFix.x = double.Parse(words[0]);
                                vecFix.y = 0;
                                vecFix.z = double.Parse(words[1]);

                                section[j].triangleList.Add(vecFix);
                            }

                        }

                    }

                    line = reader.ReadLine();
                    if (line.IndexOf("$totalSquareMeters") == -1)
                    {
                        MessageBox.Show("Meters header is Corrupt");
                        return;
                    }

                    line = reader.ReadLine();
                    totalSquareMeters = double.Parse(line);

 

                }
                //cancelled out of open file
            }


        }//end of open file

        //Function to save a field
        private void FileSaveField()
        {
            //in the current application directory
            //string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //string fieldDir = dir + "\\fields\\";

            if (!isJobStarted)
            {
                MessageBox.Show("Can't save a job if no job is open");
                return;
            }

            string dirField = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AgOpenGPS\\Fields\\";

            string directoryName = Path.GetDirectoryName(dirField);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName = String.Format("{0}{1}", DateTime.Now.ToString("yyyy_MMM_dd__hh.mm.ss.tt"), ".txt");

            //set saving flag on
            isSavingFile = true;
            
            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //Write out the date
                writer.WriteLine(DateTime.Now.ToLongDateString() + "  -->  " + DateTime.Now.ToLongTimeString());

                //write out the ABLine
                writer.WriteLine("$Heading");

                //true or false if ABLine is set
                if (ABLine.isABLineSet) writer.WriteLine(true);
                else writer.WriteLine(false);

                writer.WriteLine(ABLine.abHeading + "," + ABLine.refPoint1.x + ","
                    + ABLine.refPoint1.z + "," + ABLine.refPoint2.x + "," + ABLine.refPoint2.z);

                //write paths # of sections
                writer.WriteLine("$Sections");
                writer.WriteLine(vehicle.numberOfSections);
                for (int j = 0; j < vehicle.numberOfSections; j++)
                {
                    //every time the patch turns off and on is a new patch
                    int patchCount = section[j].patchList.Count();

                    //Write out the patch
                    writer.WriteLine(patchCount);

                    if (patchCount > 0)
                    {
                        //for every new chunk of patch in the whole section
                        foreach (var triList in section[j].patchList)
                        {
                            int count2 = triList.Count();

                            writer.WriteLine(count2);

                            for (int i = 0; i < count2; i++)
                            {
                                writer.WriteLine(Math.Round(triList[i].x,2) + "," + Math.Round(triList[i].z,2));
                            }
                        }
                    }

               }

                   //writer.WriteLine(Math.Round(totalSquareMeters / 4046.8627, 2));
                    writer.WriteLine("$totalSquareMeters");
                    writer.WriteLine(totalSquareMeters);

 
            }

            //set saving flag off
            isSavingFile = false;

            //little show to say saved and where
            MessageBox.Show((dirField + "\n\r\n\r" + myFileName),"File Saved to ");

        }

        #endregion //..................................................................

#region Menu items //------------------------------------------------------------------

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
            SettingsPageOpen(1);
        }

        private void menuItemGPSDataToolStrip_Click(object sender, EventArgs e)
        {
            GPSDataShow();
        }

        private void menuItemCOMPortsToolStrip_Click(object sender, EventArgs e)
        {
            SettingsPageOpen(0);
        }

        private void sectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsPageOpen(2);
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
        #endregion

#region Buttons //-----------------------------------------------------------------------

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
        
        //File functions
        private void btnFileSave_Click(object sender, EventArgs e)
        {
            FileSaveField();
        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            FileOpenField();
        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            SettingsPageOpen(1);
        }

       private void stripBtnResetDistance_ButtonClick(object sender, EventArgs e)
        {
            userDistance = 0;
        }
        
#endregion

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

#region SectionControl // ----------------------------------------------------------------

        //data buffer for pixels read from off screen buffer
        byte[] pixelsTop = new byte[401];
        byte[] pixelsMiddle = new byte[401];
        byte[] pixelsBottom = new byte[401];
        byte[] pixelsAtTool = new byte[401];

        //main openGL draw function
        private void openGLControlBack_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = openGLControlBack.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);	// Clear The Screen And The Depth Buffer
            gl.LoadIdentity();					// Reset The View

            //back the camera up
            gl.Translate(0, 0, -384);

            //flip the world over so positive z aka north goes into screen
            gl.Rotate(180, 0, 0, 1);

            //rotate the camera down to look at fix
            gl.Rotate(-90, 1, 0, 0);

            //rotate camera so heading matched fix heading in the world
            gl.Rotate(-fixHeadingSection * 180.0 / Math.PI + 180, 0, 1, 0);

            //translate to that spot in the world 
            gl.Translate(-fixPosX, -fixPosY, -fixPosZ);

            //patch color
            gl.Color(0.0f, 1.0f, 0.0f);

            //draw patches j= # of sections
            for (int j = 0; j < vehicle.numberOfSections; j++)
            {
                //every time the section turns off and on is a new patch
                int patchCount = section[j].patchList.Count();

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (var triList in section[j].patchList)
                    {
                        //draw the triangle strip in each triangle strip
                        gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
                        int count2 = triList.Count();
                        for (int i = 0; i < count2; i++) gl.Vertex(triList[i].x, 0, triList[i].z);
                        gl.End();
                    }
                }
            }
 
            //10 pixels to a meter or 1 pixel is 10cm or 10 pixels is 1 meter - simple math
            int rpXPosition = 200 - Math.Abs((int)(vehicle.toolFarLeftPosition * 10));
            int rpWidth = (int)(vehicle.toolWidth * 10);

            //read position for look ahead for turning on 
            double sectionLookAheadPosition = (pn.speed * vehicle.lookAhead * 2.0) + (vehicle.toolForeAft * 10); //how far ahead ie up the screen
            if (sectionLookAheadPosition > 80) sectionLookAheadPosition = 80;

            //scan 3 different spots, one at 2 secs ahead and one at 1 sec and one at section
            gl.ReadPixels(rpXPosition, 200 + (int)(sectionLookAheadPosition*0.6), rpWidth, 1,
                                OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, pixelsBottom);
            gl.ReadPixels(rpXPosition, 200 + (int)(sectionLookAheadPosition*0.8), rpWidth, 1,
                                OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, pixelsMiddle);
            gl.ReadPixels(rpXPosition, 200 + (int)sectionLookAheadPosition, rpWidth, 1,
                                OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, pixelsTop);

            //scan just ahead of the tool otherwise its too fussy and keep turning on section
            gl.ReadPixels(rpXPosition, 203 + (int)(vehicle.toolForeAft * 10), rpWidth, 1,
                                OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, pixelsAtTool);

            
            //OR them together, if anywhere isn't applied, turn on section
            for (int a = 0; a < 401; a++)
            {
                if (pixelsMiddle[a] < 10 | pixelsBottom[a] < 10 | pixelsAtTool[a] < 10 
                    | pixelsTop[a] < 10) pixelsAtTool[a] = 0;
                else pixelsAtTool[a] = 255;
            }
         
            //if anywhere in the section is a 0, as in needs section turned on, turn on section and break out loop
            bool isSectionRequiredOn = false;
            int x = 0;
            for (int j = 0; j < vehicle.numberOfSections; j++)
            {
                //section width * 10 is measured in pixels
                for (int i = 0; i < (int)(section[j].sectionWidth*10); i++)
                {
                    if (pixelsAtTool[x] < 50)
                    {
                        isSectionRequiredOn = true;
                        x += (int)(section[j].sectionWidth * 10) - i;
                        break;
                    }

                x++;

                }

                if (isSectionRequiredOn && isMasterSectionOn)
                {
                    //global request to turn on section
                    section[j].sectionOnRequest = true;
                }

                else if (!isSectionRequiredOn )
                {
                    //global request to turn off section
                    section[j].sectionOffRequest = true;
                }

                //used in this loop only
                isSectionRequiredOn = false;
            }
            gl.Flush();

        }

        //Resize is called upn window creation
        private void openGLControlBack_Resized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControlBack.OpenGL;

            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            //  Create a perspective transformation.
            gl.Perspective(6.0f, 1, 1, 6000);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);        

        }


#endregion

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
                    section[j].sectionOnTimer = 10;
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
                    section[j].sectionOffTimer = 3;
                }
                
                if (!section[j].sectionOffRequest) section[j].sectionOffTimer = 5;

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

        private void gPSDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GPSDataShow();
        }

        private void btnNewJob_Click(object sender, EventArgs e)
        {
            JobNew();
        }

        private void FormGPS_MouseMove(object sender, MouseEventArgs e)
        {
            MessageBox.Show("hello");
        }

 
   }//class FormGPS
}//namespace AgOpenGPS




