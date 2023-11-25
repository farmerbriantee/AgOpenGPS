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
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace AgOpenGPS
{

    //the main form object
    public partial class FormGPS : Form
    {
        //To bring forward AgIO if running
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWind, int nCmdShow);

        #region // Class Props and instances

        //maximum sections available
        public const int MAXSECTIONS = 64;

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
        public string fieldsDirectory, currentFieldDirectory, displayFieldName;

        private bool leftMouseDownOnOpenGL; //mousedown event in opengl window
        public int flagNumberPicked = 0;

        //bool for whether or not a job is active
        public bool isJobStarted = false, isAutoSteerBtnOn, isLidarBtnOn = true;

        //if we are saving a file
        public bool isSavingFile = false, isLogNMEA = false, isLogElevation = false;

        //texture holders
        public uint[] texture;

        //the currentversion of software
        public string currentVersionStr, inoVersionStr;
        public int inoVersionInt;

        //create instance of a stopwatch for timing of frames and NMEA hz determination
        private readonly Stopwatch swFrame = new Stopwatch();

        public double secondsSinceStart;

        //private readonly Stopwatch swDraw = new Stopwatch();
        //swDraw.Reset();
        //swDraw.Start();
        //swDraw.Stop();
        //label3.Text = ((double) swDraw.ElapsedTicks / (double) System.Diagnostics.Stopwatch.Frequency * 1000).ToString();

        //Time to do fix position update and draw routine
        public double frameTime = 0;

        //create instance of a stopwatch for timing of frames and NMEA hz determination
        //private readonly Stopwatch swHz = new Stopwatch();

        //Time to do fix position update and draw routine
        public double gpsHz = 10;

        //For field saving in background
        private int minuteCounter = 1;
        private int tenMinuteCounter = 1;

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

        public double m2InchOrCm, inchOrCm2m, m2FtOrM, ftOrMtoM, cm2CmOrIn, inOrCm2Cm;
        public string unitsFtM, unitsInCm;

        public char[] hotkeys;

        //used by filePicker Form to return picked file and directory
        public string filePickerFileAndDirectory;

        //the position of the GPS Data window within the FormGPS window
        public int GPSDataWindowLeft = 76, GPSDataWindowTopOffset = 160;

        //the autoManual drive button. Assume in Auto
        public bool isInAutoDrive = true;

        //isGPSData form up
        public bool isGPSSentencesOn = false, isKeepOffsetsOn = false;

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
        /// an array of sections
        /// </summary>
        public CSection[] section;

        /// <summary>
        /// an array of patches to draw
        /// </summary>
        //public CPatches[] triStrip;
        public List<CPatches> triStrip;

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
        /// The internal simulator
        /// </summary>
        public CSim sim;

        /// <summary>
        /// Resource manager for gloabal strings
        /// </summary>
        public ResourceManager _rm;

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

        ///// <summary>
        ///// Sound
        ///// </summary>
        public CSound sounds;

        /// <summary>
        /// Sound for approaching boundary
        /// </summary>
        public SoundPlayer sndHydraulicLift;

        /// <summary>
        /// Sound for approaching boundary
        /// </summary>
        public SoundPlayer sndHydraulicLower;

        /// <summary>
        /// The font class
        /// </summary>
        public CFont font;

        /// <summary>
        /// The new steer algorithms
        /// </summary>
        public CGuidance gyd;

        /// <summary>
        /// The new brightness code
        /// </summary>
        public CWindowsSettingsBrightnessController displayBrightness;


        #endregion // Class Props and instances

        // Constructor, Initializes a new instance of the "FormGPS" class.
        public FormGPS()
        {
            //winform initialization
            InitializeComponent();

            CheckSettingsNotNull();

            //time keeper
            secondsSinceStart = (DateTime.Now - Process.GetCurrentProcess().StartTime).TotalSeconds;

            //create the world grid
            worldGrid = new CWorldGrid(this);

            //our vehicle made with gl object and pointer of mainform
            vehicle = new CVehicle(this);

            tool = new CTool(this);

            //create a new section and set left and right positions
            //created whether used or not, saves restarting program

            section = new CSection[MAXSECTIONS];
            for (int j = 0; j < MAXSECTIONS; j++) section[j] = new CSection();

            triStrip = new List<CPatches>
            {
                new CPatches(this)
            };

            //our NMEA parser
            pn = new CNMEA(this);

            //create the ABLine instance
            ABLine = new CABLine(this);

            //new instance of contour mode
            ct = new CContour(this);

            //new instance of contour mode
            curve = new CABCurve(this);

            ////new instance of auto headland turn
            yt = new CYouTurn(this);

            //module communication
            mc = new CModuleComm(this);

            //boundary object
            bnd = new CBoundary(this);

            //nmea simulator built in.
            sim = new CSim(this);

            ////all the attitude, heading, roll, pitch reference system
            ahrs = new CAHRS();

            //A recorded path
            recPath = new CRecordedPath(this);

            //fieldData all in one place
            fd = new CFieldData(this);

            //start the stopwatch
            //swFrame.Start();

            //instance of tram
            tram = new CTram(this);

            //resource for gloabal language strings
            _rm = new ResourceManager("AgOpenGPS.gStr", Assembly.GetExecutingAssembly());

            //access to font class
            font = new CFont(this);

            //the new steer algorithms
            gyd = new CGuidance(this);

            //sounds class
            sounds = new CSound();

            //brightness object class
            displayBrightness = new CWindowsSettingsBrightnessController(Properties.Settings.Default.setDisplay_isBrightnessOn);
        }

        //Initialize items before the form Loads or is visible
        private void FormGPS_Load(object sender, EventArgs e)
        {
            this.MouseWheel += ZoomByMouseWheel;

            //start udp server is required
            StartLoopbackServer();

            //boundaryToolStripBtn.Enabled = false;
            FieldMenuButtonEnableDisable(false);

            panelRight.Enabled = false;

            oglMain.Left = 75;
            oglMain.Width = this.Width - statusStripLeft.Width - 84;

            panelSim.Left = 100;
            panelSim.Width = Width - statusStripLeft.Width - 200;

            timer2.Enabled = true;

            pictureboxStart.BringToFront();
            pictureboxStart.Dock = System.Windows.Forms.DockStyle.Fill;

            //set the language to last used
            SetLanguage(Settings.Default.setF_culture, false);

            currentVersionStr = Application.ProductVersion.ToString(CultureInfo.InvariantCulture);

            string[] fullVers = currentVersionStr.Split('.');
            int inoV = int.Parse(fullVers[0], CultureInfo.InvariantCulture);
            inoV += int.Parse(fullVers[1], CultureInfo.InvariantCulture);
            inoV += int.Parse(fullVers[2], CultureInfo.InvariantCulture);
            inoVersionInt = inoV;
            inoVersionStr = inoV.ToString();


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

            //get the abLines directory, if not exist, create
            ablinesDirectory = baseDirectory + "ABLines\\";
            dir = Path.GetDirectoryName(fieldsDirectory);
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

            if (isBrightnessOn)
            {
                if (displayBrightness.isWmiMonitor)
                {
                    Settings.Default.setDisplay_brightnessSystem = displayBrightness.GetBrightness();
                    Settings.Default.Save();
                }
                else
                {
                    btnBrightnessDn.Enabled = false;
                    btnBrightnessUp.Enabled = false;
                }

                //display brightness
                if (displayBrightness.isWmiMonitor)
                {
                    if (Settings.Default.setDisplay_brightness < Settings.Default.setDisplay_brightnessSystem)
                    {
                        Settings.Default.setDisplay_brightness = Settings.Default.setDisplay_brightnessSystem;
                        Settings.Default.Save();
                    }

                    displayBrightness.SetBrightness(Settings.Default.setDisplay_brightness);
                }
                else
                {
                    btnBrightnessDn.Enabled = false;
                    btnBrightnessUp.Enabled = false;
                }
            }



            // load all the gui elements in gui.designer.cs
            LoadSettings();

            if (Settings.Default.setMenu_isOGLZoomOn == 1)
                topFieldViewToolStripMenuItem.Checked = true;
            else topFieldViewToolStripMenuItem.Checked = false;

            oglZoom.Width = 400;
            oglZoom.Height = 400;
            oglZoom.Visible = true;
            oglZoom.Left = 300;
            oglZoom.Top = 80;

            if (!topFieldViewToolStripMenuItem.Checked)
            {
                oglZoom.SendToBack();
            }

            if (Properties.Settings.Default.setDisplay_isAutoStartAgIO)
            {
                //Start AgIO process
                Process[] processName = Process.GetProcessesByName("AgIO");
                if (processName.Length == 0)
                {
                    //Start application here
                    DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
                    string strPath = di.ToString();
                    strPath += "\\AgIO.exe";
                    try
                    {
                        ProcessStartInfo processInfo = new ProcessStartInfo
                        {
                            FileName = strPath,
                            WorkingDirectory = Path.GetDirectoryName(strPath)
                        };
                        Process proc = Process.Start(processInfo);
                    }
                    catch
                    {
                        TimedMessageBox(2000, "No File Found", "Can't Find AgIO");
                    }
                }
            }

            //nmea limiter
            udpWatch.Start();

            //ControlExtension.Draggable(panelSnap, true);
            ControlExtension.Draggable(oglZoom, true);
            ControlExtension.Draggable(panelDrag, true);

            setWorkingDirectoryToolStripMenuItem.Text = gStr.gsDirectories;
            enterSimCoordsToolStripMenuItem.Text = gStr.gsEnterSimCoords;
            aboutToolStripMenuItem.Text = gStr.gsAbout;
            menustripLanguage.Text = gStr.gsLanguage;


            simulatorOnToolStripMenuItem.Text = gStr.gsSimulatorOn;

            resetALLToolStripMenuItem.Text = gStr.gsResetAll;
            colorsToolStripMenuItem1.Text = gStr.gsColors;
            topFieldViewToolStripMenuItem.Text = gStr.gsTopFieldView;

            resetEverythingToolStripMenuItem.Text = gStr.gsResetAllForSure;

            steerChartStripMenu.Text = gStr.gsCharts;

            //Tools Menu
            SmoothABtoolStripMenu.Text = gStr.gsSmoothABCurve;
            boundariesToolStripMenuItem.Text = gStr.gsBoundary;
            headlandToolStripMenuItem.Text = gStr.gsHeadland;
            deleteContourPathsToolStripMenuItem.Text = gStr.gsDeleteContourPaths;
            deleteAppliedAreaToolStripMenuItem.Text = gStr.gsDeleteAppliedArea;
            deleteForSureToolStripMenuItem.Text = gStr.gsAreYouSure;
            toolStripMenuItem9.Text = gStr.gsField;
            tramLinesMenuField.Text = gStr.gsTramLines;
            recordedPathStripMenu.Text = gStr.gsRecordedPathMenu;

            webcamToolStrip.Text = gStr.gsWebCam;
            offsetFixToolStrip.Text = gStr.gsOffsetFix;
            wizardsMenu.Text = gStr.gsWizards;
            steerWizardMenuItem.Text = gStr.gsSteerWizard;
            steerChartToolStripMenuItem.Text = gStr.gsSteerChart;
            headingChartToolStripMenuItem.Text = gStr.gsHeadingChart;
            xTEChartToolStripMenuItem.Text = gStr.gsXTEChart;

            btnChangeMappingColor.Text = Application.ProductVersion.ToString(CultureInfo.InvariantCulture);
            //btnChangeMappingColor.Text = btnChangeMappingColor.Text.Substring(2);

            hotkeys = new char[19];

            hotkeys = Properties.Settings.Default.setKey_hotkeys.ToCharArray();
        }

        private void FormGPS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isJobStarted)
            {
                if (autoBtnState == btnStates.Auto)
                {
                    TimedMessageBox(2000, "Safe Shutdown", "Turn off Auto Section Control");
                    e.Cancel = true;
                    return;
                }

                if (manualBtnState == btnStates.On)
                {
                    TimedMessageBox(2000, "Safe Shutdown", "Turn off Manual Section Control");
                    e.Cancel = true;
                    return;
                }


                bool closing = true;
                int choice = SaveOrNot(closing);

                if (choice == 1)
                {
                    e.Cancel = true;
                    return;
                }

                //Save, return, cancel save
                if (isJobStarted)
                {
                    if (choice == 3)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else if (choice == 0)
                    {
                        Settings.Default.setF_CurrentDir = currentFieldDirectory;
                        Settings.Default.Save();

                        FileSaveEverythingBeforeClosingField();

                        displayFieldName = gStr.gsNone;
                    }
                }
            }

            SaveFormGPSWindowSettings();
            FileUpdateAllFieldsKML();

            if (loopBackSocket != null)
            {
                try
                {
                    loopBackSocket.Shutdown(SocketShutdown.Both);
                }
                catch { }
                finally { loopBackSocket.Close(); }
            }

            //save current vehicle
            SettingsIO.ExportAll(vehiclesDirectory + vehicleFileName + ".XML");

            if (displayBrightness.isWmiMonitor)
                displayBrightness.SetBrightness(Settings.Default.setDisplay_brightnessSystem);

        }

        //called everytime window is resized, clean up button positions
        private void FormGPS_Resize(object sender, EventArgs e)
        {
            FixPanelsAndMenus();
            if (isGPSPositionInitialized) SetZoom();

            Form f = Application.OpenForms["FormGPSData"];
            if (f != null)
            {
                f.Top = this.Top + this.Height / 2 - GPSDataWindowTopOffset;
                f.Left = this.Left + GPSDataWindowLeft;
            }
            Form f1 = Application.OpenForms["FormFieldData"];
            if (f1 != null)
            {
                f1.Top = this.Top + this.Height / 2 - GPSDataWindowTopOffset;
                f1.Left = this.Left + GPSDataWindowLeft;
            }
        }
        private void FormGPS_Move(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormGPSData"];
            if (f != null)
            {
                f.Top = this.Top + this.Height/2 - GPSDataWindowTopOffset;
                f.Left = this.Left + GPSDataWindowLeft;
            }
            Form f1 = Application.OpenForms["FormFieldData"];
            if (f1 != null)
            {
                f1.Top = this.Top + this.Height / 2 - GPSDataWindowTopOffset;
                f1.Left = this.Left + GPSDataWindowLeft;
            }
        }

        // Load Bitmaps And Convert To Textures

        public void CheckSettingsNotNull()
        {
            if (Settings.Default.setFeatures == null)
            {
                Settings.Default.setFeatures = new CFeatureSettings();
            }
        }

        public void LoadGLTextures()
        {
            GL.Enable(EnableCap.Texture2D);

            Bitmap[] oglTextures = new Bitmap[]
            {
                Properties.Resources.z_SkyDay,Properties.Resources.z_Floor,Properties.Resources.z_Font,
                Properties.Resources.z_Turn,Properties.Resources.z_TurnCancel,Properties.Resources.z_TurnManual,
                Properties.Resources.z_Compass,Properties.Resources.z_Speedo,Properties.Resources.z_SpeedoNeedle,
                Properties.Resources.z_Lift,Properties.Resources.z_SkyNight,Properties.Resources.z_SteerPointer,
                Properties.Resources.z_SteerDot,GetTractorBrand(Settings.Default.setBrand_TBrand),Properties.Resources.z_QuestionMark,
                Properties.Resources.z_FrontWheels,Get4WDBrandFront(Settings.Default.setBrand_WDBrand), Get4WDBrandRear(Settings.Default.setBrand_WDBrand),
                GetHarvesterBrand(Settings.Default.setBrand_HBrand), Properties.Resources.z_LateralManual, Resources.z_bingMap, Resources.z_NoGPS
            };

            texture = new uint[oglTextures.Length];

            for (int h = 0; h < oglTextures.Length; h++)
            {
                using (Bitmap bitmap = oglTextures[h])
                {
                    GL.GenTextures(1, out texture[h]);
                    GL.BindTexture(TextureTarget.Texture2D, texture[h]);
                    BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                    bitmap.UnlockBits(bitmapData);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
                }
            }
        }

        //dialog for requesting user to save or cancel
        public int SaveOrNot(bool closing)
        {
            CloseTopMosts();

            using (FormSaveOrNot form = new FormSaveOrNot(closing))
            {
                DialogResult result = form.ShowDialog(this);

                if (result == DialogResult.OK) return 0;      //Save and Exit
                if (result == DialogResult.Ignore) return 1;   //Ignore
                if (result == DialogResult.Yes) return 2;   //Ignore

                return 3;  // oops something is really busted
            }
        }

        //make the start picture disappear
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Controls.Remove(pictureboxStart);
            pictureboxStart.Dispose();
            //panel1.SendToBack();
            timer2.Enabled = false;
            timer2.Dispose();
        }

        public bool KeypadToNUD(NumericUpDown sender, Form owner)
        {
            sender.BackColor = Color.Red;
            sender.Value = Math.Round(sender.Value, sender.DecimalPlaces);

            using (FormNumeric form = new FormNumeric((double)sender.Minimum, (double)sender.Maximum, (double)sender.Value))
            {
                DialogResult result = form.ShowDialog(owner);
                if (result == DialogResult.OK)
                {
                    sender.Value = (decimal)form.ReturnValue;
                    sender.BackColor = Color.AliceBlue;
                    return true;
                }
                else if (result == DialogResult.Cancel)
                {
                    sender.BackColor = Color.AliceBlue;
                }
                return false;
            }
        }

        public void KeyboardToText(TextBox sender, Form owner)
        {
            sender.BackColor = Color.Red;
            using (FormKeyboard form = new FormKeyboard(sender.Text))
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                {
                    sender.Text = form.ReturnString;
                }
            }
            sender.BackColor = Color.AliceBlue;
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

            btnSectionMasterManual.Enabled = true;
            manualBtnState = btnStates.Off;
            btnSectionMasterManual.Image = Properties.Resources.ManualOff;

            btnSectionMasterAuto.Enabled = true;
            autoBtnState = btnStates.Off;
            btnSectionMasterAuto.Image = Properties.Resources.SectionMasterOff;

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

            btnZone1.BackColor = Color.Red;
            btnZone2.BackColor = Color.Red;
            btnZone3.BackColor = Color.Red;
            btnZone4.BackColor = Color.Red;
            btnZone5.BackColor = Color.Red;
            btnZone6.BackColor = Color.Red;
            btnZone7.BackColor = Color.Red;
            btnZone8.BackColor = Color.Red;

            btnZone1.Enabled = true;
            btnZone2.Enabled = true;
            btnZone3.Enabled = true;
            btnZone4.Enabled = true;
            btnZone5.Enabled = true;
            btnZone6.Enabled = true;
            btnZone7.Enabled = true;
            btnZone8.Enabled = true;


            btnABLine.Enabled = true;
            btnContour.Enabled = true;
            btnCurve.Enabled = true;
            btnABDraw.Enabled = true;
            btnCycleLines.Image = Properties.Resources.ABLineCycle;
            btnCycleLines.Enabled = true;
            btnCycleLinesBk.Image = Properties.Resources.ABLineCycleBk;
            btnCycleLinesBk.Enabled = true;

            ABLine.abHeading = 0.00;
            btnAutoSteer.Enabled = true;

            DisableYouTurnButtons();
            btnFlag.Enabled = true;

            if (tool.isSectionsNotZones)
            {
                LineUpIndividualSectionBtns();
            }
            else
            {
                LineUpAllZoneButtons();
            }

            //update the menu
            this.menustripLanguage.Enabled = false;
            panelRight.Enabled = true;
            //boundaryToolStripBtn.Enabled = true;

            FieldMenuButtonEnableDisable(true);
            FixPanelsAndMenus();
            SetZoom();
        }

        //close the current job
        public void JobClose()
        {
            recPath.resumeState = 0;
            btnResumePath.Image = Properties.Resources.pathResumeStart;
            recPath.currentPositonIndex = 0;

            //reset field offsets
            if (!isKeepOffsetsOn)
            {
                pn.fixOffset.easting = 0;
                pn.fixOffset.northing = 0;
            }

            //turn off headland
            bnd.isHeadlandOn = false;
            btnHeadlandOnOff.Image = Properties.Resources.HeadlandOff;
            btnHeadlandOnOff.Visible = false;

            recPath.recList.Clear();
            recPath.StopDrivingRecordedPath();
            panelDrag.Visible = false;  

            //make sure hydraulic lift is off
            p_239.pgn[p_239.hydLift] = 0;
            vehicle.isHydLiftOn = false;
            btnHydLift.Image = Properties.Resources.HydraulicLiftOff;
            btnHydLift.Visible = false;

            //zoom gone
            oglZoom.SendToBack();

            //clean all the lines
            bnd.bndList.Clear();

            panelRight.Enabled = false;
            FieldMenuButtonEnableDisable(false);

            menustripLanguage.Enabled = true;
            isJobStarted = false;

            //fix ManualOffOnAuto buttons
            manualBtnState = btnStates.Off;
            btnSectionMasterManual.Image = Properties.Resources.ManualOff;

            //fix auto button
            autoBtnState = btnStates.Off;
            btnSectionMasterAuto.Image = Properties.Resources.SectionMasterOff;

            if (tool.isSectionsNotZones)
            {
                //Update the button colors and text
                AllSectionsAndButtonsToState(btnStates.Off);

                //enable disable manual buttons
                LineUpIndividualSectionBtns();
            }
            else
            {
                AllZonesAndButtonsToState(autoBtnState);
                LineUpAllZoneButtons();
            }

            btnZone1.BackColor = Color.Silver;
            btnZone2.BackColor = Color.Silver;
            btnZone3.BackColor = Color.Silver;
            btnZone4.BackColor = Color.Silver;
            btnZone5.BackColor = Color.Silver;
            btnZone6.BackColor = Color.Silver;
            btnZone7.BackColor = Color.Silver;
            btnZone8.BackColor = Color.Silver;

            btnZone1.Enabled = false;
            btnZone2.Enabled = false;
            btnZone3.Enabled = false;
            btnZone4.Enabled = false;
            btnZone5.Enabled = false;
            btnZone6.Enabled = false;
            btnZone7.Enabled = false;
            btnZone8.Enabled = false;


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
            for (int j = 0; j < triStrip.Count; j++)
            {
                //clean out the lists
                triStrip[j].patchList?.Clear();
                triStrip[j].triangleList?.Clear();
            }

            triStrip?.Clear();
            triStrip.Add(new CPatches(this));

            //clear the flags
            flagPts.Clear();

            //ABLine
            btnABLine.Enabled = false;
            btnABLine.Image = Properties.Resources.ABLineOff;
            ABLine.isBtnABLineOn = false;
            ABLine.DeleteAB();
            ABLine.lineArr?.Clear();
            ABLine.numABLineSelected = 0;
            tram.tramList?.Clear();

            //curve line
            btnCurve.Enabled = false;
            btnCurve.Image = Properties.Resources.CurveOff;
            curve.isBtnCurveOn = false;
            curve.isCurveSet = false;
            curve.ResetCurveLine();
            curve.curveArr?.Clear();
            curve.numCurveLineSelected = 0;

            //clean up tram
            tram.displayMode = 0;
            tram.generateMode = 0;
            tram.tramBndInnerArr?.Clear();
            tram.tramBndOuterArr?.Clear();

            //clear out contour and Lists
            btnContour.Enabled = false;
            //btnContourPriority.Enabled = false;
            btnSnapToPivot.Image = Properties.Resources.SnapToPivot;
            ct.ResetContour();
            ct.isContourBtnOn = false;
            btnContour.Image = Properties.Resources.ContourOff;
            ct.isContourOn = false;

            btnABDraw.Enabled = false;
            btnCycleLines.Image = Properties.Resources.ABLineCycle;
            btnCycleLines.Enabled = false;
            btnCycleLinesBk.Image = Properties.Resources.ABLineCycleBk;
            btnCycleLinesBk.Enabled = false;

            //AutoSteer
            btnAutoSteer.Enabled = false;
            isAutoSteerBtnOn = false;
            btnAutoSteer.Image = Properties.Resources.AutoSteerOff;

            //auto YouTurn shutdown
            yt.isYouTurnBtnOn = false;
            btnAutoYouTurn.Image = Properties.Resources.YouTurnNo;
            btnAutoYouTurn.Enabled = false;

            btnABDraw.Visible = false;

            yt.ResetYouTurn();
            DisableYouTurnButtons();

            //reset acre and distance counters
            fd.workedAreaTotal = 0;

            //reset GUI areas
            fd.UpdateFieldBoundaryGUIAreas();

            displayFieldName = gStr.gsNone;
            FixTramModeButton();

            recPath.recList?.Clear();
            recPath.shortestDubinsList?.Clear();
            recPath.shuttleDubinsList?.Clear();

            FixPanelsAndMenus();
            SetZoom();
            worldGrid.isGeoMap = false;

            using (Bitmap bitmap = Properties.Resources.z_bingMap)
            {
                GL.GenTextures(1, out texture[20]);
                GL.BindTexture(TextureTarget.Texture2D, texture[20]);
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
            }
        }

        public void FieldMenuButtonEnableDisable(bool isOn)
        {
            SmoothABtoolStripMenu.Enabled = isOn;
            //toolStripBtnMakeBndContour.Enabled = isOn;
            boundariesToolStripMenuItem.Enabled = isOn;
            headlandToolStripMenuItem.Enabled = isOn;
            deleteContourPathsToolStripMenuItem.Enabled = isOn;
            tramLinesMenuField.Enabled = isOn;
            recordedPathStripMenu.Enabled = isOn;
            btnABDraw.Enabled = isOn;
            btnFlag.Visible = isOn;

            panelRight.Visible = isOn;
            panelAB.Visible = isOn;

            lblFieldStatus.Visible = isOn;
            //lblFieldDataTopField.Visible = isOn;
            //lblFieldDataTopDone.Visible = isOn;
            //lblFieldDataTopRemain.Visible = isOn;

            btnSnapToPivot.Visible = false;
            cboxpRowWidth.Visible = false;
            btnYouSkipEnable.Visible = false;
            btnEditAB.Visible = false;
        }

        //take the distance from object and convert to camera data
        public void SetZoom()
        {
            //match grid to cam distance and redo perspective
            if (camera.camSetDistance > -50 ) camera.gridZoom = 10;
            else if (camera.camSetDistance > -150 ) camera.gridZoom = 20;
            else if (camera.camSetDistance > -250 ) camera.gridZoom = 40;
            else if (camera.camSetDistance > -500 ) camera.gridZoom = 80;
            else if (camera.camSetDistance > -1000) camera.gridZoom = 160;
            else if (camera.camSetDistance > -2000) camera.gridZoom = 320;
            else if (camera.camSetDistance > -5000) camera.gridZoom = 640;
            else if (camera.camSetDistance > -10000) camera.gridZoom = 1280;
            else if (camera.camSetDistance > -20000) camera.gridZoom = 2000;

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
            if (ct.isContourOn) ct.StopContourLine();

            //turn off all the sections
            for (int j = 0; j < tool.numOfSections; j++)
            {
                section[j].sectionOnOffCycle = false;
                section[j].sectionOffRequest = false;
            }

            //turn off patching
            for (int j = 0; j < triStrip.Count; j++)
            {
                if (triStrip[j].isDrawing) triStrip[j].TurnMappingOff();
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
            FormTimedMessage form = new FormTimedMessage(timeout, s1, s2);
            form.Show(this);
        }
    
    }//class FormGPS

}//namespace AgOpenGPS

        // Generates a random number within a range.       
        //public double RandomNumber(double min, double max)
        //{
        //    return min + _random.NextDouble() * (max - min);
        //}

        //private readonly Random _random = new Random();

        //form is closing so tidy up and save settings

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