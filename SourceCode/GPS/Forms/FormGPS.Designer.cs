namespace AgOpenGPS
{
    partial class FormGPS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGPS));
            this.contextMenuStripOpenGL = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.txtDistanceOffABLine = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tmrWatchdog = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNorthing = new System.Windows.Forms.Label();
            this.lblEasting = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.contextMenuStripFlag = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblSpeedUnits = new System.Windows.Forms.Label();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblUturnByte = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pbarFieldAreaRemainPercent = new System.Windows.Forms.ProgressBar();
            this.label13 = new System.Windows.Forms.Label();
            this.pbarRelayCommSmall = new System.Windows.Forms.ProgressBar();
            this.lblHeading2 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.nudElevation = new System.Windows.Forms.NumericUpDown();
            this.btnElevationMap = new System.Windows.Forms.Button();
            this.cboxpRowWidth = new System.Windows.Forms.ComboBox();
            this.btnResetSim = new System.Windows.Forms.Button();
            this.timerSim = new System.Windows.Forms.Timer(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.hsbarSteerAngle = new System.Windows.Forms.HScrollBar();
            this.hsbarStepDistance = new System.Windows.Forms.HScrollBar();
            this.btnSection8Man = new System.Windows.Forms.Button();
            this.btnSection7Man = new System.Windows.Forms.Button();
            this.btnSection6Man = new System.Windows.Forms.Button();
            this.btnSection5Man = new System.Windows.Forms.Button();
            this.btnSection4Man = new System.Windows.Forms.Button();
            this.btnSection3Man = new System.Windows.Forms.Button();
            this.btnSection2Man = new System.Windows.Forms.Button();
            this.btnSection1Man = new System.Windows.Forms.Button();
            this.btnSection9Man = new System.Windows.Forms.Button();
            this.btnSection10Man = new System.Windows.Forms.Button();
            this.btnSection11Man = new System.Windows.Forms.Button();
            this.btnSection12Man = new System.Windows.Forms.Button();
            this.oglMain = new OpenTK.GLControl();
            this.oglBack = new OpenTK.GLControl();
            this.lblHz = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblpAltitude = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lblRoll = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lblYawHeading = new System.Windows.Forms.Label();
            this.lblGPSHeading = new System.Windows.Forms.Label();
            this.lblpFieldAreaRemainPercent = new System.Windows.Forms.Label();
            this.lblpBoundaryArea = new System.Windows.Forms.Label();
            this.lblpFieldAreaRemain = new System.Windows.Forms.Label();
            this.lblpAreaWorked = new System.Windows.Forms.Label();
            this.lblpTimeToFinish = new System.Windows.Forms.Label();
            this.pbarNtrip = new System.Windows.Forms.ProgressBar();
            this.lblNtripBytes = new System.Windows.Forms.Label();
            this.lblNTRIPSeconds = new System.Windows.Forms.Label();
            this.btnStartStopNtrip = new System.Windows.Forms.Button();
            this.lblWatch = new System.Windows.Forms.Label();
            this.pbarSteerSmall = new System.Windows.Forms.ProgressBar();
            this.pbarUDPSmall = new System.Windows.Forms.ProgressBar();
            this.label26 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblSats = new System.Windows.Forms.Label();
            this.panelZoom = new System.Windows.Forms.Panel();
            this.oglZoom = new OpenTK.GLControl();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblZone = new System.Windows.Forms.Label();
            this.lblConvergenceAngle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tboxSentence = new System.Windows.Forms.TextBox();
            this.lblFieldWidthNorthSouth = new System.Windows.Forms.Label();
            this.lblFieldWidthEastWest = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStripLeft = new System.Windows.Forms.StatusStrip();
            this.cboxTramBasedOn = new System.Windows.Forms.ComboBox();
            this.cboxTramPassEvery = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelDisplay = new System.Windows.Forms.TableLayoutPanel();
            this.panelSnap = new System.Windows.Forms.TableLayoutPanel();
            this.panelSim = new System.Windows.Forms.TableLayoutPanel();
            this.btnResetSteerAngle = new System.Windows.Forms.Button();
            this.panelTram = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSnapRightSmall = new System.Windows.Forms.Button();
            this.btnSnapLeftSmall = new System.Windows.Forms.Button();
            this.btnSnapLeft = new System.Windows.Forms.Button();
            this.btnContourPriority = new System.Windows.Forms.Button();
            this.btnSaveAB = new System.Windows.Forms.Button();
            this.btnSnapRight = new System.Windows.Forms.Button();
            this.btnpTiltUp = new ProXoft.WinForms.RepeatButton();
            this.btnpTiltDown = new ProXoft.WinForms.RepeatButton();
            this.btnCamera = new System.Windows.Forms.Button();
            this.toolStripMenuRecPath = new System.Windows.Forms.ToolStripDropDownButton();
            this.goStopRecPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseResumeRecPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordRecPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePathRecPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoManualtoolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripBtnPower = new System.Windows.Forms.ToolStripSplitButton();
            this.btnZoomIn = new ProXoft.WinForms.RepeatButton();
            this.btnZoomOut = new ProXoft.WinForms.RepeatButton();
            this.btnFlagsGoogleEarth = new System.Windows.Forms.Button();
            this.btnLeftYouTurn = new System.Windows.Forms.Button();
            this.toolStripBatman = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButtonDistance = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripBtnGPSStength = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripAutoSteerChart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripAutoSteerConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripYouTurnConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripVehicleConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripNTRIPConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripUDPConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripUSBPortsConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripDisplayConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonVehicleSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.steerAnglesToolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripbtnAutoSteerConfig = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripBtnField = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripBtnDropDownBoundaryTools = new System.Windows.Forms.ToolStripDropDownButton();
            this.treePlanterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webCamToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripBtnSmoothABCurve = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDeleteApplied = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAreYouSure = new System.Windows.Forms.ToolStripMenuItem();
            this.fileExplorerToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteContourPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripBtnMakeBndContour = new System.Windows.Forms.ToolStripMenuItem();
            this.boundariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripBtnYouTurn = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnRightYouTurn = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.menustripLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageDeutsch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageFrench = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageItalian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageDutch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageRussian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageSpanish = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.setWorkingDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.enterSimCoordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.loadVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.fieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortcutKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripUnitsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.metricToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.imperialToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.sideGuideLines = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logNMEAMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pursuitLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skyToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.simulatorOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteFlagToolOpenGLContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.googleEarthOpenGLContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRecordElevation = new System.Windows.Forms.Button();
            this.btnCurve = new System.Windows.Forms.Button();
            this.btnContour = new System.Windows.Forms.Button();
            this.btnABLine = new System.Windows.Forms.Button();
            this.btnSectionOffAutoOn = new System.Windows.Forms.Button();
            this.btnManualOffOn = new System.Windows.Forms.Button();
            this.btnEnableAutoYouTurn = new System.Windows.Forms.Button();
            this.btnAutoSteer = new System.Windows.Forms.Button();
            this.btnSwapDirection = new System.Windows.Forms.Button();
            this.btnCycleLines = new System.Windows.Forms.Button();
            this.btnFlag = new System.Windows.Forms.Button();
            this.btnMakeLinesFromBoundary = new System.Windows.Forms.Button();
            this.toolStripMenuItemFlagRed = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFlagGrn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFlagYel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFlagDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFlagDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripOpenGL.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStripFlag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudElevation)).BeginInit();
            this.panelZoom.SuspendLayout();
            this.statusStripLeft.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelDisplay.SuspendLayout();
            this.panelSnap.SuspendLayout();
            this.panelSim.SuspendLayout();
            this.panelTram.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripOpenGL
            // 
            this.contextMenuStripOpenGL.AutoSize = false;
            this.contextMenuStripOpenGL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteFlagToolOpenGLContextMenu,
            this.toolStripSeparator5,
            this.googleEarthOpenGLContextMenu});
            this.contextMenuStripOpenGL.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.contextMenuStripOpenGL.Name = "contextMenuStripOpenGL";
            this.contextMenuStripOpenGL.Size = new System.Drawing.Size(72, 160);
            this.contextMenuStripOpenGL.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripOpenGL_Opening);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(68, 6);
            // 
            // txtDistanceOffABLine
            // 
            this.txtDistanceOffABLine.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDistanceOffABLine.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDistanceOffABLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDistanceOffABLine.Font = new System.Drawing.Font("Tahoma", 21.75F);
            this.txtDistanceOffABLine.ForeColor = System.Drawing.Color.Green;
            this.txtDistanceOffABLine.Location = new System.Drawing.Point(756, 3);
            this.txtDistanceOffABLine.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.txtDistanceOffABLine.Name = "txtDistanceOffABLine";
            this.txtDistanceOffABLine.ReadOnly = true;
            this.txtDistanceOffABLine.Size = new System.Drawing.Size(110, 36);
            this.txtDistanceOffABLine.TabIndex = 7;
            this.txtDistanceOffABLine.Text = "00000";
            this.txtDistanceOffABLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 22F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Size = new System.Drawing.Size(1371, 40);
            this.menuStrip1.TabIndex = 49;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tmrWatchdog
            // 
            this.tmrWatchdog.Interval = 15;
            this.tmrWatchdog.Tick += new System.EventHandler(this.tmrWatchdog_tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowItemReorder = true;
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(54, 54);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBatman,
            this.toolStripDropDownButtonDistance,
            this.toolStripBtnGPSStength,
            this.toolStripDropDownButton2,
            this.toolStripButtonVehicleSettings,
            this.steerAnglesToolStripDropDownButton1,
            this.toolStripbtnAutoSteerConfig,
            this.toolStripStatusLabel1,
            this.toolStripBtnField,
            this.toolStripBtnDropDownBoundaryTools,
            this.toolStripBtnYouTurn,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 631);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1371, 70);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 95;
            this.statusStrip1.Text = "st";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(367, 65);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(26, 65);
            this.toolStripStatusLabel2.Text = "lbl";
            // 
            // lblNorthing
            // 
            this.lblNorthing.AutoSize = true;
            this.lblNorthing.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblNorthing.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblNorthing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNorthing.Location = new System.Drawing.Point(131, 296);
            this.lblNorthing.Name = "lblNorthing";
            this.lblNorthing.Size = new System.Drawing.Size(92, 19);
            this.lblNorthing.TabIndex = 110;
            this.lblNorthing.Text = "N: 590888";
            this.lblNorthing.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblEasting
            // 
            this.lblEasting.AutoSize = true;
            this.lblEasting.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblEasting.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblEasting.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblEasting.Location = new System.Drawing.Point(9, 296);
            this.lblEasting.Name = "lblEasting";
            this.lblEasting.Size = new System.Drawing.Size(90, 19);
            this.lblEasting.TabIndex = 111;
            this.lblEasting.Text = "E: 440888";
            this.lblEasting.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSpeed
            // 
            this.lblSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeed.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSpeed.Location = new System.Drawing.Point(1106, 5);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(87, 31);
            this.lblSpeed.TabIndex = 116;
            this.lblSpeed.Text = "88.8";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contextMenuStripFlag
            // 
            this.contextMenuStripFlag.AutoSize = false;
            this.contextMenuStripFlag.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contextMenuStripFlag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFlagRed,
            this.toolStripMenuFlagGrn,
            this.toolStripMenuFlagYel,
            this.toolStripSeparator3,
            this.toolStripMenuFlagDelete,
            this.toolStripSeparator4,
            this.toolStripMenuFlagDeleteAll});
            this.contextMenuStripFlag.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.contextMenuStripFlag.Name = "contextMenuStripFlag";
            this.contextMenuStripFlag.Size = new System.Drawing.Size(72, 400);
            this.contextMenuStripFlag.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripFlag_Opening);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(68, 20);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(68, 20);
            // 
            // lblSpeedUnits
            // 
            this.lblSpeedUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpeedUnits.AutoSize = true;
            this.lblSpeedUnits.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblSpeedUnits.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblSpeedUnits.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSpeedUnits.Location = new System.Drawing.Point(1188, 15);
            this.lblSpeedUnits.Name = "lblSpeedUnits";
            this.lblSpeedUnits.Size = new System.Drawing.Size(38, 17);
            this.lblSpeedUnits.TabIndex = 139;
            this.lblSpeedUnits.Text = "kmh";
            this.lblSpeedUnits.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblHeading
            // 
            this.lblHeading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblHeading.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHeading.Location = new System.Drawing.Point(1236, 5);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(130, 31);
            this.lblHeading.TabIndex = 117;
            this.lblHeading.Text = "359.88..";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUturnByte
            // 
            this.lblUturnByte.AutoSize = true;
            this.lblUturnByte.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblUturnByte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUturnByte.Location = new System.Drawing.Point(78, 217);
            this.lblUturnByte.Name = "lblUturnByte";
            this.lblUturnByte.Size = new System.Drawing.Size(89, 19);
            this.lblUturnByte.TabIndex = 272;
            this.lblUturnByte.Text = "10101010";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(100, 150);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 19);
            this.label16.TabIndex = 180;
            this.label16.Text = "Elev:";
            // 
            // pbarFieldAreaRemainPercent
            // 
            this.pbarFieldAreaRemainPercent.BackColor = System.Drawing.Color.Maroon;
            this.pbarFieldAreaRemainPercent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbarFieldAreaRemainPercent.Location = new System.Drawing.Point(8, 399);
            this.pbarFieldAreaRemainPercent.Name = "pbarFieldAreaRemainPercent";
            this.pbarFieldAreaRemainPercent.Size = new System.Drawing.Size(219, 10);
            this.pbarFieldAreaRemainPercent.Step = 1;
            this.pbarFieldAreaRemainPercent.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbarFieldAreaRemainPercent.TabIndex = 311;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(165, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 309;
            this.label13.Text = "R";
            // 
            // pbarRelayCommSmall
            // 
            this.pbarRelayCommSmall.BackColor = System.Drawing.Color.Maroon;
            this.pbarRelayCommSmall.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbarRelayCommSmall.Location = new System.Drawing.Point(181, 57);
            this.pbarRelayCommSmall.Name = "pbarRelayCommSmall";
            this.pbarRelayCommSmall.Size = new System.Drawing.Size(50, 10);
            this.pbarRelayCommSmall.TabIndex = 304;
            // 
            // lblHeading2
            // 
            this.lblHeading2.AutoSize = true;
            this.lblHeading2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHeading2.Location = new System.Drawing.Point(183, 342);
            this.lblHeading2.Name = "lblHeading2";
            this.lblHeading2.Size = new System.Drawing.Size(44, 19);
            this.lblHeading2.TabIndex = 211;
            this.lblHeading2.Text = "22.6";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(131, 342);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 19);
            this.label22.TabIndex = 210;
            this.label22.Text = "Fused:";
            // 
            // nudElevation
            // 
            this.nudElevation.DecimalPlaces = 1;
            this.nudElevation.Font = new System.Drawing.Font("Tahoma", 21.75F);
            this.nudElevation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudElevation.Location = new System.Drawing.Point(478, 246);
            this.nudElevation.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudElevation.Name = "nudElevation";
            this.nudElevation.Size = new System.Drawing.Size(111, 43);
            this.nudElevation.TabIndex = 302;
            this.nudElevation.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudElevation.Value = new decimal(new int[] {
            3000,
            0,
            0,
            65536});
            this.nudElevation.ValueChanged += new System.EventHandler(this.NudElevation_ValueChanged);
            // 
            // btnElevationMap
            // 
            this.btnElevationMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnElevationMap.BackColor = System.Drawing.Color.AliceBlue;
            this.btnElevationMap.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnElevationMap.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnElevationMap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnElevationMap.Location = new System.Drawing.Point(876, 307);
            this.btnElevationMap.Name = "btnElevationMap";
            this.btnElevationMap.Size = new System.Drawing.Size(82, 90);
            this.btnElevationMap.TabIndex = 227;
            this.btnElevationMap.Text = "Show Elevation Map";
            this.btnElevationMap.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnElevationMap.UseVisualStyleBackColor = false;
            this.btnElevationMap.Click += new System.EventHandler(this.BtnElevationMap_Click);
            // 
            // cboxpRowWidth
            // 
            this.cboxpRowWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxpRowWidth.BackColor = System.Drawing.Color.Lavender;
            this.cboxpRowWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxpRowWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxpRowWidth.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold);
            this.cboxpRowWidth.FormattingEnabled = true;
            this.cboxpRowWidth.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cboxpRowWidth.Location = new System.Drawing.Point(5, 355);
            this.cboxpRowWidth.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxpRowWidth.Name = "cboxpRowWidth";
            this.cboxpRowWidth.Size = new System.Drawing.Size(60, 53);
            this.cboxpRowWidth.TabIndex = 247;
            this.cboxpRowWidth.SelectedIndexChanged += new System.EventHandler(this.cboxpRowWidth_SelectedIndexChanged);
            // 
            // btnResetSim
            // 
            this.btnResetSim.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnResetSim.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnResetSim.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnResetSim.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetSim.Location = new System.Drawing.Point(142, 8);
            this.btnResetSim.Name = "btnResetSim";
            this.btnResetSim.Size = new System.Drawing.Size(40, 34);
            this.btnResetSim.TabIndex = 164;
            this.btnResetSim.Text = "Rst";
            this.btnResetSim.UseVisualStyleBackColor = false;
            this.btnResetSim.Click += new System.EventHandler(this.btnResetSim_Click);
            // 
            // timerSim
            // 
            this.timerSim.Enabled = true;
            this.timerSim.Interval = 200;
            this.timerSim.Tick += new System.EventHandler(this.timerSim_Tick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(334, 62);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // hsbarSteerAngle
            // 
            this.hsbarSteerAngle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hsbarSteerAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hsbarSteerAngle.LargeChange = 20;
            this.hsbarSteerAngle.Location = new System.Drawing.Point(187, 3);
            this.hsbarSteerAngle.Maximum = 600;
            this.hsbarSteerAngle.Name = "hsbarSteerAngle";
            this.hsbarSteerAngle.Size = new System.Drawing.Size(135, 43);
            this.hsbarSteerAngle.TabIndex = 179;
            this.hsbarSteerAngle.Value = 300;
            this.hsbarSteerAngle.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarSteerAngle_Scroll);
            // 
            // hsbarStepDistance
            // 
            this.hsbarStepDistance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hsbarStepDistance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hsbarStepDistance.LargeChange = 5;
            this.hsbarStepDistance.Location = new System.Drawing.Point(2, 3);
            this.hsbarStepDistance.Maximum = 300;
            this.hsbarStepDistance.Name = "hsbarStepDistance";
            this.hsbarStepDistance.Size = new System.Drawing.Size(135, 43);
            this.hsbarStepDistance.TabIndex = 178;
            this.hsbarStepDistance.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarStepDistance_Scroll);
            // 
            // btnSection8Man
            // 
            this.btnSection8Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection8Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection8Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection8Man.Enabled = false;
            this.btnSection8Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection8Man.FlatAppearance.BorderSize = 0;
            this.btnSection8Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection8Man.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSection8Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection8Man.Location = new System.Drawing.Point(530, 457);
            this.btnSection8Man.Name = "btnSection8Man";
            this.btnSection8Man.Size = new System.Drawing.Size(52, 30);
            this.btnSection8Man.TabIndex = 125;
            this.btnSection8Man.Text = "8";
            this.btnSection8Man.UseVisualStyleBackColor = false;
            this.btnSection8Man.Click += new System.EventHandler(this.btnSection8Man_Click);
            // 
            // btnSection7Man
            // 
            this.btnSection7Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection7Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection7Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection7Man.Enabled = false;
            this.btnSection7Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection7Man.FlatAppearance.BorderSize = 0;
            this.btnSection7Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection7Man.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSection7Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection7Man.Location = new System.Drawing.Point(518, 443);
            this.btnSection7Man.Name = "btnSection7Man";
            this.btnSection7Man.Size = new System.Drawing.Size(52, 30);
            this.btnSection7Man.TabIndex = 126;
            this.btnSection7Man.Text = "7";
            this.btnSection7Man.UseVisualStyleBackColor = false;
            this.btnSection7Man.Click += new System.EventHandler(this.btnSection7Man_Click);
            // 
            // btnSection6Man
            // 
            this.btnSection6Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection6Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection6Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection6Man.Enabled = false;
            this.btnSection6Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection6Man.FlatAppearance.BorderSize = 0;
            this.btnSection6Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection6Man.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSection6Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection6Man.Location = new System.Drawing.Point(496, 425);
            this.btnSection6Man.Name = "btnSection6Man";
            this.btnSection6Man.Size = new System.Drawing.Size(52, 30);
            this.btnSection6Man.TabIndex = 127;
            this.btnSection6Man.Text = "6";
            this.btnSection6Man.UseVisualStyleBackColor = false;
            this.btnSection6Man.Click += new System.EventHandler(this.btnSection6Man_Click);
            // 
            // btnSection5Man
            // 
            this.btnSection5Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection5Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection5Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection5Man.Enabled = false;
            this.btnSection5Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection5Man.FlatAppearance.BorderSize = 0;
            this.btnSection5Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection5Man.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSection5Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection5Man.Location = new System.Drawing.Point(475, 407);
            this.btnSection5Man.Name = "btnSection5Man";
            this.btnSection5Man.Size = new System.Drawing.Size(52, 30);
            this.btnSection5Man.TabIndex = 103;
            this.btnSection5Man.Text = "5";
            this.btnSection5Man.UseVisualStyleBackColor = false;
            this.btnSection5Man.Click += new System.EventHandler(this.btnSection5Man_Click);
            // 
            // btnSection4Man
            // 
            this.btnSection4Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection4Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection4Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection4Man.Enabled = false;
            this.btnSection4Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection4Man.FlatAppearance.BorderSize = 0;
            this.btnSection4Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection4Man.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSection4Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection4Man.Location = new System.Drawing.Point(540, 384);
            this.btnSection4Man.Name = "btnSection4Man";
            this.btnSection4Man.Size = new System.Drawing.Size(52, 30);
            this.btnSection4Man.TabIndex = 102;
            this.btnSection4Man.Text = "4";
            this.btnSection4Man.UseVisualStyleBackColor = false;
            this.btnSection4Man.Click += new System.EventHandler(this.btnSection4Man_Click);
            // 
            // btnSection3Man
            // 
            this.btnSection3Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection3Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection3Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection3Man.Enabled = false;
            this.btnSection3Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection3Man.FlatAppearance.BorderSize = 0;
            this.btnSection3Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection3Man.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSection3Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection3Man.Location = new System.Drawing.Point(519, 370);
            this.btnSection3Man.Name = "btnSection3Man";
            this.btnSection3Man.Size = new System.Drawing.Size(52, 30);
            this.btnSection3Man.TabIndex = 101;
            this.btnSection3Man.Text = "3";
            this.btnSection3Man.UseVisualStyleBackColor = false;
            this.btnSection3Man.Click += new System.EventHandler(this.btnSection3Man_Click);
            // 
            // btnSection2Man
            // 
            this.btnSection2Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection2Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection2Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection2Man.Enabled = false;
            this.btnSection2Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection2Man.FlatAppearance.BorderSize = 0;
            this.btnSection2Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection2Man.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSection2Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection2Man.Location = new System.Drawing.Point(496, 352);
            this.btnSection2Man.Name = "btnSection2Man";
            this.btnSection2Man.Size = new System.Drawing.Size(52, 30);
            this.btnSection2Man.TabIndex = 100;
            this.btnSection2Man.Text = "2";
            this.btnSection2Man.UseVisualStyleBackColor = false;
            this.btnSection2Man.Click += new System.EventHandler(this.btnSection2Man_Click);
            // 
            // btnSection1Man
            // 
            this.btnSection1Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection1Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection1Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection1Man.Enabled = false;
            this.btnSection1Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection1Man.FlatAppearance.BorderSize = 0;
            this.btnSection1Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection1Man.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSection1Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection1Man.Location = new System.Drawing.Point(479, 334);
            this.btnSection1Man.Name = "btnSection1Man";
            this.btnSection1Man.Size = new System.Drawing.Size(52, 30);
            this.btnSection1Man.TabIndex = 99;
            this.btnSection1Man.Text = "1";
            this.btnSection1Man.UseVisualStyleBackColor = false;
            this.btnSection1Man.Click += new System.EventHandler(this.btnSection1Man_Click);
            // 
            // btnSection9Man
            // 
            this.btnSection9Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection9Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection9Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection9Man.Enabled = false;
            this.btnSection9Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection9Man.FlatAppearance.BorderSize = 0;
            this.btnSection9Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection9Man.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSection9Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection9Man.Location = new System.Drawing.Point(473, 486);
            this.btnSection9Man.Name = "btnSection9Man";
            this.btnSection9Man.Size = new System.Drawing.Size(52, 30);
            this.btnSection9Man.TabIndex = 174;
            this.btnSection9Man.Text = "9";
            this.btnSection9Man.UseVisualStyleBackColor = false;
            this.btnSection9Man.Click += new System.EventHandler(this.btnSection9Man_Click);
            // 
            // btnSection10Man
            // 
            this.btnSection10Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection10Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection10Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection10Man.Enabled = false;
            this.btnSection10Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection10Man.FlatAppearance.BorderSize = 0;
            this.btnSection10Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection10Man.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSection10Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection10Man.Location = new System.Drawing.Point(498, 498);
            this.btnSection10Man.Name = "btnSection10Man";
            this.btnSection10Man.Size = new System.Drawing.Size(52, 30);
            this.btnSection10Man.TabIndex = 175;
            this.btnSection10Man.Text = "10";
            this.btnSection10Man.UseVisualStyleBackColor = false;
            this.btnSection10Man.Click += new System.EventHandler(this.btnSection10Man_Click);
            // 
            // btnSection11Man
            // 
            this.btnSection11Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection11Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection11Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection11Man.Enabled = false;
            this.btnSection11Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection11Man.FlatAppearance.BorderSize = 0;
            this.btnSection11Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection11Man.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSection11Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection11Man.Location = new System.Drawing.Point(530, 507);
            this.btnSection11Man.Name = "btnSection11Man";
            this.btnSection11Man.Size = new System.Drawing.Size(52, 30);
            this.btnSection11Man.TabIndex = 176;
            this.btnSection11Man.Text = "11";
            this.btnSection11Man.UseVisualStyleBackColor = false;
            this.btnSection11Man.Click += new System.EventHandler(this.btnSection11Man_Click);
            // 
            // btnSection12Man
            // 
            this.btnSection12Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection12Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection12Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection12Man.Enabled = false;
            this.btnSection12Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection12Man.FlatAppearance.BorderSize = 0;
            this.btnSection12Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection12Man.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSection12Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection12Man.Location = new System.Drawing.Point(547, 522);
            this.btnSection12Man.Name = "btnSection12Man";
            this.btnSection12Man.Size = new System.Drawing.Size(52, 30);
            this.btnSection12Man.TabIndex = 177;
            this.btnSection12Man.Text = "12";
            this.btnSection12Man.UseVisualStyleBackColor = false;
            this.btnSection12Man.Click += new System.EventHandler(this.btnSection12Man_Click);
            // 
            // oglMain
            // 
            this.oglMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oglMain.BackColor = System.Drawing.Color.Black;
            this.oglMain.ContextMenuStrip = this.contextMenuStripOpenGL;
            this.oglMain.Location = new System.Drawing.Point(304, 41);
            this.oglMain.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.oglMain.Name = "oglMain";
            this.oglMain.Size = new System.Drawing.Size(888, 592);
            this.oglMain.TabIndex = 180;
            this.oglMain.VSync = false;
            this.oglMain.Load += new System.EventHandler(this.oglMain_Load);
            this.oglMain.Paint += new System.Windows.Forms.PaintEventHandler(this.oglMain_Paint);
            this.oglMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.oglMain_MouseDown);
            this.oglMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.oglMain_MouseUp);
            this.oglMain.Resize += new System.EventHandler(this.oglMain_Resize);
            // 
            // oglBack
            // 
            this.oglBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.oglBack.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.oglBack.Location = new System.Drawing.Point(232, 636);
            this.oglBack.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.oglBack.Name = "oglBack";
            this.oglBack.Size = new System.Drawing.Size(500, 500);
            this.oglBack.TabIndex = 181;
            this.oglBack.VSync = false;
            this.oglBack.Load += new System.EventHandler(this.oglBack_Load);
            this.oglBack.Paint += new System.Windows.Forms.PaintEventHandler(this.oglBack_Paint);
            this.oglBack.Resize += new System.EventHandler(this.oglBack_Resize);
            // 
            // lblHz
            // 
            this.lblHz.AutoSize = true;
            this.lblHz.BackColor = System.Drawing.Color.Transparent;
            this.lblHz.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHz.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHz.Location = new System.Drawing.Point(228, 2);
            this.lblHz.Name = "lblHz";
            this.lblHz.Size = new System.Drawing.Size(70, 38);
            this.lblHz.TabIndex = 249;
            this.lblHz.Text = "5 Hz 32\r\nPPS";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(4, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 13);
            this.label15.TabIndex = 309;
            this.label15.Text = "S";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(84, 54);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 13);
            this.label20.TabIndex = 310;
            this.label20.Text = "U";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(157, 375);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 19);
            this.label14.TabIndex = 262;
            this.label14.Text = "=";
            // 
            // lblpAltitude
            // 
            this.lblpAltitude.AutoSize = true;
            this.lblpAltitude.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblpAltitude.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblpAltitude.Location = new System.Drawing.Point(138, 150);
            this.lblpAltitude.Name = "lblpAltitude";
            this.lblpAltitude.Size = new System.Drawing.Size(54, 19);
            this.lblpAltitude.TabIndex = 232;
            this.lblpAltitude.Text = "356m";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(7, 321);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(42, 19);
            this.label33.TabIndex = 251;
            this.label33.Text = "Roll:";
            // 
            // lblRoll
            // 
            this.lblRoll.AutoSize = true;
            this.lblRoll.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblRoll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRoll.Location = new System.Drawing.Point(46, 321);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(34, 19);
            this.lblRoll.TabIndex = 252;
            this.lblRoll.Text = "1.2";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label39.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label39.Location = new System.Drawing.Point(142, 321);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(44, 19);
            this.label39.TabIndex = 253;
            this.label39.Text = "GPS:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label35.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label35.Location = new System.Drawing.Point(5, 342);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(44, 19);
            this.label35.TabIndex = 254;
            this.label35.Text = "IMU:";
            // 
            // lblYawHeading
            // 
            this.lblYawHeading.AutoSize = true;
            this.lblYawHeading.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblYawHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblYawHeading.Location = new System.Drawing.Point(46, 342);
            this.lblYawHeading.Name = "lblYawHeading";
            this.lblYawHeading.Size = new System.Drawing.Size(54, 19);
            this.lblYawHeading.TabIndex = 255;
            this.lblYawHeading.Text = "388.8";
            // 
            // lblGPSHeading
            // 
            this.lblGPSHeading.AutoSize = true;
            this.lblGPSHeading.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblGPSHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGPSHeading.Location = new System.Drawing.Point(182, 321);
            this.lblGPSHeading.Name = "lblGPSHeading";
            this.lblGPSHeading.Size = new System.Drawing.Size(54, 19);
            this.lblGPSHeading.TabIndex = 256;
            this.lblGPSHeading.Text = "388.8";
            // 
            // lblpFieldAreaRemainPercent
            // 
            this.lblpFieldAreaRemainPercent.AutoSize = true;
            this.lblpFieldAreaRemainPercent.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblpFieldAreaRemainPercent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblpFieldAreaRemainPercent.Location = new System.Drawing.Point(165, 413);
            this.lblpFieldAreaRemainPercent.Name = "lblpFieldAreaRemainPercent";
            this.lblpFieldAreaRemainPercent.Size = new System.Drawing.Size(48, 19);
            this.lblpFieldAreaRemainPercent.TabIndex = 262;
            this.lblpFieldAreaRemainPercent.Text = "45%";
            // 
            // lblpBoundaryArea
            // 
            this.lblpBoundaryArea.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblpBoundaryArea.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblpBoundaryArea.Location = new System.Drawing.Point(33, 375);
            this.lblpBoundaryArea.Name = "lblpBoundaryArea";
            this.lblpBoundaryArea.Size = new System.Drawing.Size(54, 19);
            this.lblpBoundaryArea.TabIndex = 259;
            this.lblpBoundaryArea.Text = "000.0";
            this.lblpBoundaryArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblpFieldAreaRemain
            // 
            this.lblpFieldAreaRemain.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblpFieldAreaRemain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblpFieldAreaRemain.Location = new System.Drawing.Point(175, 375);
            this.lblpFieldAreaRemain.Name = "lblpFieldAreaRemain";
            this.lblpFieldAreaRemain.Size = new System.Drawing.Size(82, 19);
            this.lblpFieldAreaRemain.TabIndex = 261;
            this.lblpFieldAreaRemain.Text = "000.0";
            this.lblpFieldAreaRemain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblpAreaWorked
            // 
            this.lblpAreaWorked.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblpAreaWorked.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblpAreaWorked.Location = new System.Drawing.Point(101, 375);
            this.lblpAreaWorked.Name = "lblpAreaWorked";
            this.lblpAreaWorked.Size = new System.Drawing.Size(54, 19);
            this.lblpAreaWorked.TabIndex = 264;
            this.lblpAreaWorked.Text = "000.0";
            this.lblpAreaWorked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblpTimeToFinish
            // 
            this.lblpTimeToFinish.AutoSize = true;
            this.lblpTimeToFinish.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblpTimeToFinish.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblpTimeToFinish.Location = new System.Drawing.Point(45, 413);
            this.lblpTimeToFinish.Name = "lblpTimeToFinish";
            this.lblpTimeToFinish.Size = new System.Drawing.Size(106, 19);
            this.lblpTimeToFinish.TabIndex = 267;
            this.lblpTimeToFinish.Text = "13.56 Hours";
            // 
            // pbarNtrip
            // 
            this.pbarNtrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbarNtrip.BackColor = System.Drawing.Color.Maroon;
            this.pbarNtrip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbarNtrip.Location = new System.Drawing.Point(7, 564);
            this.pbarNtrip.Maximum = 256;
            this.pbarNtrip.Name = "pbarNtrip";
            this.pbarNtrip.Size = new System.Drawing.Size(144, 8);
            this.pbarNtrip.TabIndex = 270;
            // 
            // lblNtripBytes
            // 
            this.lblNtripBytes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNtripBytes.AutoSize = true;
            this.lblNtripBytes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNtripBytes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNtripBytes.Location = new System.Drawing.Point(24, 542);
            this.lblNtripBytes.Name = "lblNtripBytes";
            this.lblNtripBytes.Size = new System.Drawing.Size(31, 13);
            this.lblNtripBytes.TabIndex = 271;
            this.lblNtripBytes.Text = "0 kb";
            // 
            // lblNTRIPSeconds
            // 
            this.lblNTRIPSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNTRIPSeconds.AutoSize = true;
            this.lblNTRIPSeconds.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNTRIPSeconds.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNTRIPSeconds.Location = new System.Drawing.Point(94, 544);
            this.lblNTRIPSeconds.Name = "lblNTRIPSeconds";
            this.lblNTRIPSeconds.Size = new System.Drawing.Size(60, 13);
            this.lblNTRIPSeconds.TabIndex = 273;
            this.lblNTRIPSeconds.Text = "NTRIP Off";
            // 
            // btnStartStopNtrip
            // 
            this.btnStartStopNtrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartStopNtrip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStartStopNtrip.Location = new System.Drawing.Point(162, 545);
            this.btnStartStopNtrip.Name = "btnStartStopNtrip";
            this.btnStartStopNtrip.Size = new System.Drawing.Size(72, 33);
            this.btnStartStopNtrip.TabIndex = 250;
            this.btnStartStopNtrip.Text = "Stop";
            this.btnStartStopNtrip.UseVisualStyleBackColor = true;
            this.btnStartStopNtrip.Click += new System.EventHandler(this.btnStartStopNtrip_Click);
            // 
            // lblWatch
            // 
            this.lblWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWatch.AutoSize = true;
            this.lblWatch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblWatch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblWatch.Location = new System.Drawing.Point(24, 526);
            this.lblWatch.Name = "lblWatch";
            this.lblWatch.Size = new System.Drawing.Size(94, 13);
            this.lblWatch.TabIndex = 274;
            this.lblWatch.Text = "Waiting for GPS";
            // 
            // pbarSteerSmall
            // 
            this.pbarSteerSmall.BackColor = System.Drawing.Color.Maroon;
            this.pbarSteerSmall.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbarSteerSmall.Location = new System.Drawing.Point(21, 57);
            this.pbarSteerSmall.Name = "pbarSteerSmall";
            this.pbarSteerSmall.Size = new System.Drawing.Size(50, 10);
            this.pbarSteerSmall.TabIndex = 307;
            // 
            // pbarUDPSmall
            // 
            this.pbarUDPSmall.BackColor = System.Drawing.Color.Maroon;
            this.pbarUDPSmall.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbarUDPSmall.Location = new System.Drawing.Point(102, 57);
            this.pbarUDPSmall.Name = "pbarUDPSmall";
            this.pbarUDPSmall.Size = new System.Drawing.Size(50, 10);
            this.pbarUDPSmall.TabIndex = 308;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(87, 375);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(15, 19);
            this.label26.TabIndex = 266;
            this.label26.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(21, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 19);
            this.label3.TabIndex = 312;
            this.label3.Text = "UTurn:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(28, 150);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(44, 19);
            this.label24.TabIndex = 216;
            this.label24.Text = "Sats:";
            // 
            // lblSats
            // 
            this.lblSats.AutoSize = true;
            this.lblSats.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblSats.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSats.Location = new System.Drawing.Point(68, 150);
            this.lblSats.Name = "lblSats";
            this.lblSats.Size = new System.Drawing.Size(19, 19);
            this.lblSats.TabIndex = 183;
            this.lblSats.Text = "S";
            // 
            // panelZoom
            // 
            this.panelZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelZoom.Controls.Add(this.oglZoom);
            this.panelZoom.Controls.Add(this.btnFlagsGoogleEarth);
            this.panelZoom.Controls.Add(this.btnStartStopNtrip);
            this.panelZoom.Controls.Add(this.pbarNtrip);
            this.panelZoom.Controls.Add(this.lblNtripBytes);
            this.panelZoom.Controls.Add(this.label13);
            this.panelZoom.Controls.Add(this.lblNTRIPSeconds);
            this.panelZoom.Controls.Add(this.label20);
            this.panelZoom.Controls.Add(this.lblWatch);
            this.panelZoom.Controls.Add(this.label15);
            this.panelZoom.Controls.Add(this.lblUturnByte);
            this.panelZoom.Controls.Add(this.pbarUDPSmall);
            this.panelZoom.Controls.Add(this.label3);
            this.panelZoom.Controls.Add(this.label5);
            this.panelZoom.Controls.Add(this.label26);
            this.panelZoom.Controls.Add(this.lblLongitude);
            this.panelZoom.Controls.Add(this.pbarSteerSmall);
            this.panelZoom.Controls.Add(this.lblLatitude);
            this.panelZoom.Controls.Add(this.lblpTimeToFinish);
            this.panelZoom.Controls.Add(this.lblZone);
            this.panelZoom.Controls.Add(this.lblpAreaWorked);
            this.panelZoom.Controls.Add(this.lblGPSHeading);
            this.panelZoom.Controls.Add(this.lblNorthing);
            this.panelZoom.Controls.Add(this.lblpFieldAreaRemain);
            this.panelZoom.Controls.Add(this.lblConvergenceAngle);
            this.panelZoom.Controls.Add(this.lblpBoundaryArea);
            this.panelZoom.Controls.Add(this.lblEasting);
            this.panelZoom.Controls.Add(this.lblpFieldAreaRemainPercent);
            this.panelZoom.Controls.Add(this.pbarFieldAreaRemainPercent);
            this.panelZoom.Controls.Add(this.lblYawHeading);
            this.panelZoom.Controls.Add(this.label14);
            this.panelZoom.Controls.Add(this.label35);
            this.panelZoom.Controls.Add(this.label2);
            this.panelZoom.Controls.Add(this.label39);
            this.panelZoom.Controls.Add(this.label25);
            this.panelZoom.Controls.Add(this.lblRoll);
            this.panelZoom.Controls.Add(this.label19);
            this.panelZoom.Controls.Add(this.label33);
            this.panelZoom.Controls.Add(this.label18);
            this.panelZoom.Controls.Add(this.tboxSentence);
            this.panelZoom.Controls.Add(this.label22);
            this.panelZoom.Controls.Add(this.label16);
            this.panelZoom.Controls.Add(this.lblHeading2);
            this.panelZoom.Controls.Add(this.lblSats);
            this.panelZoom.Controls.Add(this.label24);
            this.panelZoom.Controls.Add(this.lblpAltitude);
            this.panelZoom.Controls.Add(this.lblFieldWidthNorthSouth);
            this.panelZoom.Controls.Add(this.lblFieldWidthEastWest);
            this.panelZoom.Controls.Add(this.label4);
            this.panelZoom.Controls.Add(this.pbarRelayCommSmall);
            this.panelZoom.Location = new System.Drawing.Point(0, 46);
            this.panelZoom.Name = "panelZoom";
            this.panelZoom.Size = new System.Drawing.Size(240, 584);
            this.panelZoom.TabIndex = 303;
            this.panelZoom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelZoom_MouseDown);
            // 
            // oglZoom
            // 
            this.oglZoom.BackColor = System.Drawing.Color.Black;
            this.oglZoom.Location = new System.Drawing.Point(0, 3);
            this.oglZoom.Margin = new System.Windows.Forms.Padding(0);
            this.oglZoom.Name = "oglZoom";
            this.oglZoom.Size = new System.Drawing.Size(240, 240);
            this.oglZoom.TabIndex = 182;
            this.oglZoom.VSync = false;
            this.oglZoom.Load += new System.EventHandler(this.oglZoom_Load);
            this.oglZoom.Paint += new System.Windows.Forms.PaintEventHandler(this.oglZoom_Paint);
            this.oglZoom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.oglZoom_MouseUp);
            this.oglZoom.Resize += new System.EventHandler(this.oglZoom_Resize);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(6, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 242;
            this.label5.Text = "E to W:";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblLongitude.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLongitude.Location = new System.Drawing.Point(51, 97);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(121, 19);
            this.lblLongitude.TabIndex = 233;
            this.lblLongitude.Text = "-111.2534749";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblLatitude.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLatitude.Location = new System.Drawing.Point(50, 76);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(104, 19);
            this.lblLatitude.TabIndex = 232;
            this.lblLatitude.Text = "53.2344549";
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblZone.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblZone.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblZone.Location = new System.Drawing.Point(51, 130);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(29, 19);
            this.lblZone.TabIndex = 231;
            this.lblZone.Text = "Zn";
            this.lblZone.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblConvergenceAngle
            // 
            this.lblConvergenceAngle.AutoSize = true;
            this.lblConvergenceAngle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblConvergenceAngle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblConvergenceAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblConvergenceAngle.Location = new System.Drawing.Point(132, 130);
            this.lblConvergenceAngle.Name = "lblConvergenceAngle";
            this.lblConvergenceAngle.Size = new System.Drawing.Size(32, 19);
            this.lblConvergenceAngle.TabIndex = 237;
            this.lblConvergenceAngle.Text = "CA";
            this.lblConvergenceAngle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(100, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 19);
            this.label2.TabIndex = 238;
            this.label2.Text = "CA:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(7, 130);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(50, 19);
            this.label25.TabIndex = 236;
            this.label25.Text = "Zone:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(20, 76);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 19);
            this.label19.TabIndex = 235;
            this.label19.Text = "Lat:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(15, 97);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 19);
            this.label18.TabIndex = 234;
            this.label18.Text = "Lon:";
            // 
            // tboxSentence
            // 
            this.tboxSentence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxSentence.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tboxSentence.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tboxSentence.Location = new System.Drawing.Point(2, 2);
            this.tboxSentence.Multiline = true;
            this.tboxSentence.Name = "tboxSentence";
            this.tboxSentence.ReadOnly = true;
            this.tboxSentence.Size = new System.Drawing.Size(236, 45);
            this.tboxSentence.TabIndex = 135;
            // 
            // lblFieldWidthNorthSouth
            // 
            this.lblFieldWidthNorthSouth.AutoSize = true;
            this.lblFieldWidthNorthSouth.BackColor = System.Drawing.Color.Transparent;
            this.lblFieldWidthNorthSouth.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblFieldWidthNorthSouth.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFieldWidthNorthSouth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFieldWidthNorthSouth.Location = new System.Drawing.Point(169, 188);
            this.lblFieldWidthNorthSouth.Name = "lblFieldWidthNorthSouth";
            this.lblFieldWidthNorthSouth.Size = new System.Drawing.Size(44, 19);
            this.lblFieldWidthNorthSouth.TabIndex = 240;
            this.lblFieldWidthNorthSouth.Text = "0.00";
            // 
            // lblFieldWidthEastWest
            // 
            this.lblFieldWidthEastWest.AutoSize = true;
            this.lblFieldWidthEastWest.BackColor = System.Drawing.Color.Transparent;
            this.lblFieldWidthEastWest.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblFieldWidthEastWest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFieldWidthEastWest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFieldWidthEastWest.Location = new System.Drawing.Point(64, 188);
            this.lblFieldWidthEastWest.Name = "lblFieldWidthEastWest";
            this.lblFieldWidthEastWest.Size = new System.Drawing.Size(44, 19);
            this.lblFieldWidthEastWest.TabIndex = 239;
            this.lblFieldWidthEastWest.Text = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(114, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 19);
            this.label4.TabIndex = 241;
            this.label4.Text = "N to S:";
            // 
            // statusStripLeft
            // 
            this.statusStripLeft.AllowMerge = false;
            this.statusStripLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.statusStripLeft.AutoSize = false;
            this.statusStripLeft.BackColor = System.Drawing.Color.Transparent;
            this.statusStripLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.statusStripLeft.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStripLeft.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStripLeft.ImageScalingSize = new System.Drawing.Size(56, 56);
            this.statusStripLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuRecPath,
            this.AutoManualtoolStripSplitButton1,
            this.toolStripBtnPower});
            this.statusStripLeft.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStripLeft.Location = new System.Drawing.Point(2, 273);
            this.statusStripLeft.Name = "statusStripLeft";
            this.statusStripLeft.Size = new System.Drawing.Size(60, 331);
            this.statusStripLeft.SizingGrip = false;
            this.statusStripLeft.Stretch = false;
            this.statusStripLeft.TabIndex = 312;
            this.statusStripLeft.Text = "statusStrip2";
            // 
            // cboxTramBasedOn
            // 
            this.cboxTramBasedOn.BackColor = System.Drawing.Color.Lavender;
            this.cboxTramBasedOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxTramBasedOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTramBasedOn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxTramBasedOn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxTramBasedOn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboxTramBasedOn.FormattingEnabled = true;
            this.cboxTramBasedOn.Items.AddRange(new object[] {
            "-5",
            "-4",
            "-3",
            "-2",
            "-1",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboxTramBasedOn.Location = new System.Drawing.Point(4, 22);
            this.cboxTramBasedOn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxTramBasedOn.Name = "cboxTramBasedOn";
            this.cboxTramBasedOn.Size = new System.Drawing.Size(58, 37);
            this.cboxTramBasedOn.TabIndex = 315;
            this.cboxTramBasedOn.SelectedIndexChanged += new System.EventHandler(this.cboxTramBasedOn_SelectedIndexChanged);
            // 
            // cboxTramPassEvery
            // 
            this.cboxTramPassEvery.BackColor = System.Drawing.Color.Lavender;
            this.cboxTramPassEvery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxTramPassEvery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTramPassEvery.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxTramPassEvery.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxTramPassEvery.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboxTramPassEvery.FormattingEnabled = true;
            this.cboxTramPassEvery.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cboxTramPassEvery.Location = new System.Drawing.Point(68, 22);
            this.cboxTramPassEvery.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxTramPassEvery.Name = "cboxTramPassEvery";
            this.cboxTramPassEvery.Size = new System.Drawing.Size(59, 37);
            this.cboxTramPassEvery.TabIndex = 316;
            this.cboxTramPassEvery.SelectedIndexChanged += new System.EventHandler(this.cboxTramPassEvery_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnCurve, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnContour, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnABLine, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboxpRowWidth, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnSectionOffAutoOn, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnManualOffOn, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnEnableAutoYouTurn, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnAutoSteer, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnSwapDirection, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCycleLines, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnFlag, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnMakeLinesFromBoundary, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1191, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.45187F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.45187F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.45187F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.82117F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.82117F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.82117F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.82117F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.35971F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(180, 587);
            this.tableLayoutPanel1.TabIndex = 319;
            // 
            // tableLayoutPanelDisplay
            // 
            this.tableLayoutPanelDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanelDisplay.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanelDisplay.ColumnCount = 1;
            this.tableLayoutPanelDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDisplay.Controls.Add(this.btnpTiltUp, 0, 2);
            this.tableLayoutPanelDisplay.Controls.Add(this.btnpTiltDown, 0, 3);
            this.tableLayoutPanelDisplay.Controls.Add(this.btnCamera, 0, 4);
            this.tableLayoutPanelDisplay.Controls.Add(this.statusStripLeft, 0, 5);
            this.tableLayoutPanelDisplay.Controls.Add(this.btnZoomIn, 0, 1);
            this.tableLayoutPanelDisplay.Controls.Add(this.btnZoomOut, 0, 0);
            this.tableLayoutPanelDisplay.Location = new System.Drawing.Point(243, 41);
            this.tableLayoutPanelDisplay.Name = "tableLayoutPanelDisplay";
            this.tableLayoutPanelDisplay.RowCount = 6;
            this.tableLayoutPanelDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDisplay.Size = new System.Drawing.Size(64, 592);
            this.tableLayoutPanelDisplay.TabIndex = 320;
            // 
            // panelSnap
            // 
            this.panelSnap.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelSnap.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSnap.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.panelSnap.ColumnCount = 8;
            this.panelSnap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelSnap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelSnap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelSnap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelSnap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelSnap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.panelSnap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelSnap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.panelSnap.Controls.Add(this.btnSnapRightSmall, 3, 0);
            this.panelSnap.Controls.Add(this.btnSnapLeftSmall, 1, 0);
            this.panelSnap.Controls.Add(this.btnSnapLeft, 0, 0);
            this.panelSnap.Controls.Add(this.btnContourPriority, 2, 0);
            this.panelSnap.Controls.Add(this.btnSaveAB, 6, 0);
            this.panelSnap.Controls.Add(this.btnSnapRight, 4, 0);
            this.panelSnap.Location = new System.Drawing.Point(790, 568);
            this.panelSnap.Name = "panelSnap";
            this.panelSnap.RowCount = 1;
            this.panelSnap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSnap.Size = new System.Drawing.Size(395, 60);
            this.panelSnap.TabIndex = 321;
            // 
            // panelSim
            // 
            this.panelSim.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelSim.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSim.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.panelSim.ColumnCount = 5;
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.panelSim.Controls.Add(this.hsbarSteerAngle, 2, 0);
            this.panelSim.Controls.Add(this.hsbarStepDistance, 0, 0);
            this.panelSim.Controls.Add(this.btnResetSim, 1, 0);
            this.panelSim.Controls.Add(this.btnResetSteerAngle, 3, 0);
            this.panelSim.Location = new System.Drawing.Point(375, 576);
            this.panelSim.Name = "panelSim";
            this.panelSim.RowCount = 1;
            this.panelSim.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSim.Size = new System.Drawing.Size(402, 50);
            this.panelSim.TabIndex = 322;
            // 
            // btnResetSteerAngle
            // 
            this.btnResetSteerAngle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnResetSteerAngle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnResetSteerAngle.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnResetSteerAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetSteerAngle.Location = new System.Drawing.Point(327, 8);
            this.btnResetSteerAngle.Name = "btnResetSteerAngle";
            this.btnResetSteerAngle.Size = new System.Drawing.Size(47, 34);
            this.btnResetSteerAngle.TabIndex = 162;
            this.btnResetSteerAngle.Text = "0";
            this.btnResetSteerAngle.UseVisualStyleBackColor = false;
            this.btnResetSteerAngle.Click += new System.EventHandler(this.btnResetSteerAngle_Click);
            // 
            // panelTram
            // 
            this.panelTram.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelTram.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelTram.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.panelTram.ColumnCount = 3;
            this.panelTram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.panelTram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.panelTram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.panelTram.Controls.Add(this.label6, 1, 0);
            this.panelTram.Controls.Add(this.cboxTramBasedOn, 0, 1);
            this.panelTram.Controls.Add(this.cboxTramPassEvery, 1, 1);
            this.panelTram.Controls.Add(this.label1, 0, 0);
            this.panelTram.Location = new System.Drawing.Point(983, 57);
            this.panelTram.Name = "panelTram";
            this.panelTram.RowCount = 2;
            this.panelTram.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.panelTram.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTram.Size = new System.Drawing.Size(171, 65);
            this.panelTram.TabIndex = 323;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightGreen;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(69, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 318;
            this.label6.Text = "Skips:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Orchid;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 317;
            this.label1.Text = "Start On:";
            // 
            // btnSnapRightSmall
            // 
            this.btnSnapRightSmall.BackColor = System.Drawing.Color.Transparent;
            this.btnSnapRightSmall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSnapRightSmall.FlatAppearance.BorderSize = 0;
            this.btnSnapRightSmall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnapRightSmall.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSnapRightSmall.Image = global::AgOpenGPS.Properties.Resources.SnapRight;
            this.btnSnapRightSmall.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSnapRightSmall.Location = new System.Drawing.Point(199, 5);
            this.btnSnapRightSmall.Name = "btnSnapRightSmall";
            this.btnSnapRightSmall.Size = new System.Drawing.Size(47, 50);
            this.btnSnapRightSmall.TabIndex = 181;
            this.btnSnapRightSmall.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSnapRightSmall.UseVisualStyleBackColor = false;
            this.btnSnapRightSmall.Click += new System.EventHandler(this.btnSnapRightSmall_Click);
            // 
            // btnSnapLeftSmall
            // 
            this.btnSnapLeftSmall.BackColor = System.Drawing.Color.Transparent;
            this.btnSnapLeftSmall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSnapLeftSmall.FlatAppearance.BorderSize = 0;
            this.btnSnapLeftSmall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnapLeftSmall.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSnapLeftSmall.Image = global::AgOpenGPS.Properties.Resources.SnapLeft;
            this.btnSnapLeftSmall.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSnapLeftSmall.Location = new System.Drawing.Point(60, 5);
            this.btnSnapLeftSmall.Name = "btnSnapLeftSmall";
            this.btnSnapLeftSmall.Size = new System.Drawing.Size(47, 50);
            this.btnSnapLeftSmall.TabIndex = 180;
            this.btnSnapLeftSmall.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSnapLeftSmall.UseVisualStyleBackColor = false;
            this.btnSnapLeftSmall.Click += new System.EventHandler(this.btnSnapLeftSmall_Click);
            // 
            // btnSnapLeft
            // 
            this.btnSnapLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnSnapLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSnapLeft.FlatAppearance.BorderSize = 0;
            this.btnSnapLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnapLeft.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSnapLeft.Image = global::AgOpenGPS.Properties.Resources.SnapLeftSmall;
            this.btnSnapLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSnapLeft.Location = new System.Drawing.Point(5, 5);
            this.btnSnapLeft.Name = "btnSnapLeft";
            this.btnSnapLeft.Size = new System.Drawing.Size(47, 50);
            this.btnSnapLeft.TabIndex = 179;
            this.btnSnapLeft.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSnapLeft.UseVisualStyleBackColor = false;
            this.btnSnapLeft.Click += new System.EventHandler(this.btnSnapLeft_Click_1);
            // 
            // btnContourPriority
            // 
            this.btnContourPriority.BackColor = System.Drawing.Color.Transparent;
            this.btnContourPriority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnContourPriority.Enabled = false;
            this.btnContourPriority.FlatAppearance.BorderSize = 0;
            this.btnContourPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContourPriority.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContourPriority.Image = global::AgOpenGPS.Properties.Resources.Snap2;
            this.btnContourPriority.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnContourPriority.Location = new System.Drawing.Point(115, 5);
            this.btnContourPriority.Name = "btnContourPriority";
            this.btnContourPriority.Size = new System.Drawing.Size(76, 50);
            this.btnContourPriority.TabIndex = 178;
            this.btnContourPriority.Text = "77";
            this.btnContourPriority.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnContourPriority.UseVisualStyleBackColor = false;
            this.btnContourPriority.Click += new System.EventHandler(this.btnContourPriority_Click_1);
            // 
            // btnSaveAB
            // 
            this.btnSaveAB.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveAB.BackgroundImage = global::AgOpenGPS.Properties.Resources.FileSave;
            this.btnSaveAB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveAB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveAB.FlatAppearance.BorderSize = 0;
            this.btnSaveAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAB.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSaveAB.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveAB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveAB.Location = new System.Drawing.Point(321, 5);
            this.btnSaveAB.Name = "btnSaveAB";
            this.btnSaveAB.Size = new System.Drawing.Size(47, 50);
            this.btnSaveAB.TabIndex = 182;
            this.btnSaveAB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveAB.UseVisualStyleBackColor = false;
            this.btnSaveAB.Click += new System.EventHandler(this.btnSaveAB_Click);
            // 
            // btnSnapRight
            // 
            this.btnSnapRight.BackColor = System.Drawing.Color.Transparent;
            this.btnSnapRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSnapRight.FlatAppearance.BorderSize = 0;
            this.btnSnapRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnapRight.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSnapRight.Image = global::AgOpenGPS.Properties.Resources.SnapRightSmall;
            this.btnSnapRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSnapRight.Location = new System.Drawing.Point(254, 5);
            this.btnSnapRight.Name = "btnSnapRight";
            this.btnSnapRight.Size = new System.Drawing.Size(47, 50);
            this.btnSnapRight.TabIndex = 184;
            this.btnSnapRight.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSnapRight.UseVisualStyleBackColor = false;
            this.btnSnapRight.Click += new System.EventHandler(this.btnSnapRight_Click_1);
            // 
            // btnpTiltUp
            // 
            this.btnpTiltUp.BackColor = System.Drawing.Color.Transparent;
            this.btnpTiltUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnpTiltUp.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnpTiltUp.FlatAppearance.BorderSize = 0;
            this.btnpTiltUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpTiltUp.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnpTiltUp.Image = global::AgOpenGPS.Properties.Resources.TiltUp;
            this.btnpTiltUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnpTiltUp.Location = new System.Drawing.Point(5, 113);
            this.btnpTiltUp.Name = "btnpTiltUp";
            this.btnpTiltUp.Size = new System.Drawing.Size(54, 46);
            this.btnpTiltUp.TabIndex = 246;
            this.btnpTiltUp.UseVisualStyleBackColor = false;
            this.btnpTiltUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnpTiltUp_MouseDown);
            // 
            // btnpTiltDown
            // 
            this.btnpTiltDown.BackColor = System.Drawing.Color.Transparent;
            this.btnpTiltDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnpTiltDown.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnpTiltDown.FlatAppearance.BorderSize = 0;
            this.btnpTiltDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpTiltDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnpTiltDown.Image = global::AgOpenGPS.Properties.Resources.TiltDown;
            this.btnpTiltDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnpTiltDown.Location = new System.Drawing.Point(5, 167);
            this.btnpTiltDown.Name = "btnpTiltDown";
            this.btnpTiltDown.Size = new System.Drawing.Size(54, 46);
            this.btnpTiltDown.TabIndex = 245;
            this.btnpTiltDown.UseVisualStyleBackColor = false;
            this.btnpTiltDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnpTiltDown_MouseDown);
            // 
            // btnCamera
            // 
            this.btnCamera.BackColor = System.Drawing.Color.Transparent;
            this.btnCamera.BackgroundImage = global::AgOpenGPS.Properties.Resources.Camera541;
            this.btnCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCamera.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnCamera.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnCamera.FlatAppearance.BorderSize = 0;
            this.btnCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCamera.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCamera.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCamera.Location = new System.Drawing.Point(5, 221);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(54, 47);
            this.btnCamera.TabIndex = 311;
            this.btnCamera.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCamera.UseVisualStyleBackColor = false;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // toolStripMenuRecPath
            // 
            this.toolStripMenuRecPath.AutoSize = false;
            this.toolStripMenuRecPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuRecPath.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goStopRecPathToolStripMenuItem,
            this.pauseResumeRecPathToolStripMenuItem,
            this.recordRecPathToolStripMenuItem,
            this.deletePathRecPathToolStripMenuItem});
            this.toolStripMenuRecPath.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuRecPath.Image = global::AgOpenGPS.Properties.Resources.RecPath;
            this.toolStripMenuRecPath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuRecPath.Name = "toolStripMenuRecPath";
            this.toolStripMenuRecPath.Size = new System.Drawing.Size(60, 64);
            this.toolStripMenuRecPath.Text = "toolStripDropDownButton3";
            // 
            // goStopRecPathToolStripMenuItem
            // 
            this.goStopRecPathToolStripMenuItem.Name = "goStopRecPathToolStripMenuItem";
            this.goStopRecPathToolStripMenuItem.Size = new System.Drawing.Size(329, 40);
            this.goStopRecPathToolStripMenuItem.Text = "Go / Stop";
            this.goStopRecPathToolStripMenuItem.Click += new System.EventHandler(this.goStopRecPathToolStripMenuItem_Click);
            // 
            // pauseResumeRecPathToolStripMenuItem
            // 
            this.pauseResumeRecPathToolStripMenuItem.Name = "pauseResumeRecPathToolStripMenuItem";
            this.pauseResumeRecPathToolStripMenuItem.Size = new System.Drawing.Size(329, 40);
            this.pauseResumeRecPathToolStripMenuItem.Text = "Pause / Resume";
            this.pauseResumeRecPathToolStripMenuItem.Click += new System.EventHandler(this.pauseResumeRecPathToolStripMenuItem_Click);
            // 
            // recordRecPathToolStripMenuItem
            // 
            this.recordRecPathToolStripMenuItem.Name = "recordRecPathToolStripMenuItem";
            this.recordRecPathToolStripMenuItem.Size = new System.Drawing.Size(329, 40);
            this.recordRecPathToolStripMenuItem.Text = "Record";
            this.recordRecPathToolStripMenuItem.Click += new System.EventHandler(this.recordRecPathToolStripMenuItem_Click);
            // 
            // deletePathRecPathToolStripMenuItem
            // 
            this.deletePathRecPathToolStripMenuItem.Name = "deletePathRecPathToolStripMenuItem";
            this.deletePathRecPathToolStripMenuItem.Size = new System.Drawing.Size(329, 40);
            this.deletePathRecPathToolStripMenuItem.Text = "Delete Path";
            this.deletePathRecPathToolStripMenuItem.Click += new System.EventHandler(this.deletePathRecPathToolStripMenuItem_Click);
            // 
            // AutoManualtoolStripSplitButton1
            // 
            this.AutoManualtoolStripSplitButton1.AutoSize = false;
            this.AutoManualtoolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AutoManualtoolStripSplitButton1.DropDownButtonWidth = 0;
            this.AutoManualtoolStripSplitButton1.Image = global::AgOpenGPS.Properties.Resources.AutoManualIsAuto;
            this.AutoManualtoolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AutoManualtoolStripSplitButton1.Name = "AutoManualtoolStripSplitButton1";
            this.AutoManualtoolStripSplitButton1.Size = new System.Drawing.Size(60, 64);
            this.AutoManualtoolStripSplitButton1.Text = "toolStripSplitButton1";
            this.AutoManualtoolStripSplitButton1.ButtonClick += new System.EventHandler(this.AutoManualtoolStripSplitButton1_ButtonClick);
            // 
            // toolStripBtnPower
            // 
            this.toolStripBtnPower.AutoSize = false;
            this.toolStripBtnPower.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnPower.DropDownButtonWidth = 0;
            this.toolStripBtnPower.Image = global::AgOpenGPS.Properties.Resources.SwitchOff;
            this.toolStripBtnPower.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnPower.Name = "toolStripBtnPower";
            this.toolStripBtnPower.Size = new System.Drawing.Size(60, 64);
            this.toolStripBtnPower.Text = "toolStripSplitButton1";
            this.toolStripBtnPower.ButtonClick += new System.EventHandler(this.toolStripBtnPower_ButtonClick);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomIn.BackgroundImage = global::AgOpenGPS.Properties.Resources.ZoomOut48;
            this.btnZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomIn.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnZoomIn.FlatAppearance.BorderSize = 0;
            this.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomIn.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnZoomIn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZoomIn.Location = new System.Drawing.Point(5, 59);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(54, 46);
            this.btnZoomIn.TabIndex = 120;
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZoomIn_MouseDown);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomOut.BackgroundImage = global::AgOpenGPS.Properties.Resources.ZoomIn48;
            this.btnZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomOut.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnZoomOut.FlatAppearance.BorderSize = 0;
            this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomOut.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnZoomOut.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZoomOut.Location = new System.Drawing.Point(5, 5);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(54, 46);
            this.btnZoomOut.TabIndex = 119;
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZoomOut_MouseDown);
            // 
            // btnFlagsGoogleEarth
            // 
            this.btnFlagsGoogleEarth.BackColor = System.Drawing.Color.Transparent;
            this.btnFlagsGoogleEarth.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnFlagsGoogleEarth.FlatAppearance.BorderSize = 0;
            this.btnFlagsGoogleEarth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlagsGoogleEarth.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnFlagsGoogleEarth.Image = global::AgOpenGPS.Properties.Resources.GoogleEarth;
            this.btnFlagsGoogleEarth.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFlagsGoogleEarth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFlagsGoogleEarth.Location = new System.Drawing.Point(17, 445);
            this.btnFlagsGoogleEarth.Name = "btnFlagsGoogleEarth";
            this.btnFlagsGoogleEarth.Size = new System.Drawing.Size(64, 62);
            this.btnFlagsGoogleEarth.TabIndex = 177;
            this.btnFlagsGoogleEarth.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFlagsGoogleEarth.UseVisualStyleBackColor = false;
            this.btnFlagsGoogleEarth.Click += new System.EventHandler(this.btnFlagsGoogleEarth_Click);
            // 
            // btnLeftYouTurn
            // 
            this.btnLeftYouTurn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLeftYouTurn.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnLeftYouTurn.Enabled = false;
            this.btnLeftYouTurn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftYouTurn.Image = global::AgOpenGPS.Properties.Resources.ArrowLeft;
            this.btnLeftYouTurn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLeftYouTurn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLeftYouTurn.Location = new System.Drawing.Point(689, 138);
            this.btnLeftYouTurn.Name = "btnLeftYouTurn";
            this.btnLeftYouTurn.Size = new System.Drawing.Size(80, 65);
            this.btnLeftYouTurn.TabIndex = 143;
            this.btnLeftYouTurn.Text = "8888 ft";
            this.btnLeftYouTurn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLeftYouTurn.UseVisualStyleBackColor = false;
            this.btnLeftYouTurn.Click += new System.EventHandler(this.btnLeftYouTurn_Click);
            // 
            // toolStripBatman
            // 
            this.toolStripBatman.AutoSize = false;
            this.toolStripBatman.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripBatman.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBatman.Font = new System.Drawing.Font("Tahoma", 18F);
            this.toolStripBatman.Image = global::AgOpenGPS.Properties.Resources.Batman48;
            this.toolStripBatman.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBatman.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBatman.Name = "toolStripBatman";
            this.toolStripBatman.ShowDropDownArrow = false;
            this.toolStripBatman.Size = new System.Drawing.Size(80, 68);
            this.toolStripBatman.Click += new System.EventHandler(this.toolStripBatman_Click);
            // 
            // toolStripDropDownButtonDistance
            // 
            this.toolStripDropDownButtonDistance.AutoSize = false;
            this.toolStripDropDownButtonDistance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripDropDownButtonDistance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonDistance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButtonDistance.Image = global::AgOpenGPS.Properties.Resources.Batman48;
            this.toolStripDropDownButtonDistance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButtonDistance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonDistance.Name = "toolStripDropDownButtonDistance";
            this.toolStripDropDownButtonDistance.ShowDropDownArrow = false;
            this.toolStripDropDownButtonDistance.Size = new System.Drawing.Size(68, 68);
            this.toolStripDropDownButtonDistance.Text = "88.8";
            this.toolStripDropDownButtonDistance.Click += new System.EventHandler(this.toolStripDropDownButtonDistance_Click);
            // 
            // toolStripBtnGPSStength
            // 
            this.toolStripBtnGPSStength.AutoSize = false;
            this.toolStripBtnGPSStength.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripBtnGPSStength.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnGPSStength.Font = new System.Drawing.Font("Tahoma", 18F);
            this.toolStripBtnGPSStength.Image = global::AgOpenGPS.Properties.Resources.GPSSignalPoor;
            this.toolStripBtnGPSStength.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnGPSStength.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnGPSStength.Name = "toolStripBtnGPSStength";
            this.toolStripBtnGPSStength.ShowDropDownArrow = false;
            this.toolStripBtnGPSStength.Size = new System.Drawing.Size(100, 68);
            this.toolStripBtnGPSStength.Click += new System.EventHandler(this.toolStripBtnGPSStength_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.AutoSize = false;
            this.toolStripDropDownButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAutoSteerChart,
            this.toolstripAutoSteerConfig,
            this.toolstripYouTurnConfig,
            this.toolstripVehicleConfig,
            this.toolStripNTRIPConfig,
            this.toolstripUDPConfig,
            this.toolstripUSBPortsConfig,
            this.toolstripDisplayConfig});
            this.toolStripDropDownButton2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton2.Image = global::AgOpenGPS.Properties.Resources.SettingsGear64;
            this.toolStripDropDownButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.ShowDropDownArrow = false;
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(100, 70);
            this.toolStripDropDownButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // toolStripAutoSteerChart
            // 
            this.toolStripAutoSteerChart.AutoSize = false;
            this.toolStripAutoSteerChart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripAutoSteerChart.Font = new System.Drawing.Font("Tahoma", 24F);
            this.toolStripAutoSteerChart.Image = global::AgOpenGPS.Properties.Resources.Chart;
            this.toolStripAutoSteerChart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripAutoSteerChart.Name = "toolStripAutoSteerChart";
            this.toolStripAutoSteerChart.Size = new System.Drawing.Size(331, 80);
            this.toolStripAutoSteerChart.Text = "Steer Chart";
            this.toolStripAutoSteerChart.Click += new System.EventHandler(this.toolStripAutoSteerChart_Click);
            // 
            // toolstripAutoSteerConfig
            // 
            this.toolstripAutoSteerConfig.AutoSize = false;
            this.toolstripAutoSteerConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolstripAutoSteerConfig.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolstripAutoSteerConfig.Image = global::AgOpenGPS.Properties.Resources.AutoSteerConf;
            this.toolstripAutoSteerConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolstripAutoSteerConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolstripAutoSteerConfig.Name = "toolstripAutoSteerConfig";
            this.toolstripAutoSteerConfig.Size = new System.Drawing.Size(331, 80);
            this.toolstripAutoSteerConfig.Text = "Auto Steer";
            this.toolstripAutoSteerConfig.Click += new System.EventHandler(this.toolstripAutoSteerConfig_Click);
            // 
            // toolstripYouTurnConfig
            // 
            this.toolstripYouTurnConfig.AutoSize = false;
            this.toolstripYouTurnConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolstripYouTurnConfig.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolstripYouTurnConfig.Image = global::AgOpenGPS.Properties.Resources.Youturn64;
            this.toolstripYouTurnConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolstripYouTurnConfig.Name = "toolstripYouTurnConfig";
            this.toolstripYouTurnConfig.Size = new System.Drawing.Size(331, 80);
            this.toolstripYouTurnConfig.Text = "U Turn";
            this.toolstripYouTurnConfig.Click += new System.EventHandler(this.toolstripYouTurnConfig_Click);
            // 
            // toolstripVehicleConfig
            // 
            this.toolstripVehicleConfig.AutoSize = false;
            this.toolstripVehicleConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolstripVehicleConfig.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolstripVehicleConfig.Image = global::AgOpenGPS.Properties.Resources.Settings64;
            this.toolstripVehicleConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolstripVehicleConfig.Name = "toolstripVehicleConfig";
            this.toolstripVehicleConfig.Size = new System.Drawing.Size(331, 80);
            this.toolstripVehicleConfig.Text = "Vehicle";
            this.toolstripVehicleConfig.Click += new System.EventHandler(this.toolstripVehicleConfig_Click);
            // 
            // toolStripNTRIPConfig
            // 
            this.toolStripNTRIPConfig.AutoSize = false;
            this.toolStripNTRIPConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripNTRIPConfig.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripNTRIPConfig.Image = global::AgOpenGPS.Properties.Resources.NtripSettings;
            this.toolStripNTRIPConfig.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripNTRIPConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripNTRIPConfig.Name = "toolStripNTRIPConfig";
            this.toolStripNTRIPConfig.Size = new System.Drawing.Size(331, 80);
            this.toolStripNTRIPConfig.Text = "NTRIP";
            this.toolStripNTRIPConfig.Click += new System.EventHandler(this.toolStripNTRIPConfig_Click);
            // 
            // toolstripUDPConfig
            // 
            this.toolstripUDPConfig.AutoSize = false;
            this.toolstripUDPConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolstripUDPConfig.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolstripUDPConfig.Image = global::AgOpenGPS.Properties.Resources.UDPConfig;
            this.toolstripUDPConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolstripUDPConfig.Name = "toolstripUDPConfig";
            this.toolstripUDPConfig.Size = new System.Drawing.Size(331, 80);
            this.toolstripUDPConfig.Text = "UDP";
            this.toolstripUDPConfig.Click += new System.EventHandler(this.toolstripUDPConfig_Click);
            // 
            // toolstripUSBPortsConfig
            // 
            this.toolstripUSBPortsConfig.AutoSize = false;
            this.toolstripUSBPortsConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolstripUSBPortsConfig.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolstripUSBPortsConfig.Image = global::AgOpenGPS.Properties.Resources.ComPorts;
            this.toolstripUSBPortsConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolstripUSBPortsConfig.Name = "toolstripUSBPortsConfig";
            this.toolstripUSBPortsConfig.Size = new System.Drawing.Size(331, 80);
            this.toolstripUSBPortsConfig.Text = "Serial Ports";
            this.toolstripUSBPortsConfig.Click += new System.EventHandler(this.toolstripUSBPortsConfig_Click);
            // 
            // toolstripDisplayConfig
            // 
            this.toolstripDisplayConfig.AutoSize = false;
            this.toolstripDisplayConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolstripDisplayConfig.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolstripDisplayConfig.Image = global::AgOpenGPS.Properties.Resources.gyro;
            this.toolstripDisplayConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolstripDisplayConfig.Name = "toolstripDisplayConfig";
            this.toolstripDisplayConfig.Size = new System.Drawing.Size(331, 80);
            this.toolstripDisplayConfig.Text = "Heading/Roll";
            this.toolstripDisplayConfig.Click += new System.EventHandler(this.toolstripDisplayConfig_Click);
            // 
            // toolStripButtonVehicleSettings
            // 
            this.toolStripButtonVehicleSettings.AutoSize = false;
            this.toolStripButtonVehicleSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButtonVehicleSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVehicleSettings.Font = new System.Drawing.Font("Tahoma", 18F);
            this.toolStripButtonVehicleSettings.Image = global::AgOpenGPS.Properties.Resources.GifTractor;
            this.toolStripButtonVehicleSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonVehicleSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVehicleSettings.Name = "toolStripButtonVehicleSettings";
            this.toolStripButtonVehicleSettings.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripButtonVehicleSettings.ShowDropDownArrow = false;
            this.toolStripButtonVehicleSettings.Size = new System.Drawing.Size(110, 68);
            this.toolStripButtonVehicleSettings.Click += new System.EventHandler(this.toolStripButtonVehicleSettings_Click);
            // 
            // steerAnglesToolStripDropDownButton1
            // 
            this.steerAnglesToolStripDropDownButton1.AutoSize = false;
            this.steerAnglesToolStripDropDownButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.steerAnglesToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.steerAnglesToolStripDropDownButton1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.steerAnglesToolStripDropDownButton1.Image = global::AgOpenGPS.Properties.Resources.Batman48;
            this.steerAnglesToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.steerAnglesToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.steerAnglesToolStripDropDownButton1.Name = "steerAnglesToolStripDropDownButton1";
            this.steerAnglesToolStripDropDownButton1.ShowDropDownArrow = false;
            this.steerAnglesToolStripDropDownButton1.Size = new System.Drawing.Size(64, 68);
            this.steerAnglesToolStripDropDownButton1.Text = "-38.88";
            this.steerAnglesToolStripDropDownButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripbtnAutoSteerConfig
            // 
            this.toolStripbtnAutoSteerConfig.AutoSize = false;
            this.toolStripbtnAutoSteerConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripbtnAutoSteerConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripbtnAutoSteerConfig.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripbtnAutoSteerConfig.Image = global::AgOpenGPS.Properties.Resources.AutoSteerConf;
            this.toolStripbtnAutoSteerConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripbtnAutoSteerConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripbtnAutoSteerConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnAutoSteerConfig.Name = "toolStripbtnAutoSteerConfig";
            this.toolStripbtnAutoSteerConfig.ShowDropDownArrow = false;
            this.toolStripbtnAutoSteerConfig.Size = new System.Drawing.Size(80, 68);
            this.toolStripbtnAutoSteerConfig.Text = "-38.8";
            this.toolStripbtnAutoSteerConfig.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripbtnAutoSteerConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripbtnAutoSteerConfig.Click += new System.EventHandler(this.toolStripbtnAutoSteerConfig_Click);
            // 
            // toolStripBtnField
            // 
            this.toolStripBtnField.AutoSize = false;
            this.toolStripBtnField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripBtnField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnField.Font = new System.Drawing.Font("Tahoma", 18F);
            this.toolStripBtnField.Image = global::AgOpenGPS.Properties.Resources.JobActive;
            this.toolStripBtnField.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnField.Name = "toolStripBtnField";
            this.toolStripBtnField.ShowDropDownArrow = false;
            this.toolStripBtnField.Size = new System.Drawing.Size(110, 68);
            this.toolStripBtnField.Click += new System.EventHandler(this.toolStripBtnField_Click);
            // 
            // toolStripBtnDropDownBoundaryTools
            // 
            this.toolStripBtnDropDownBoundaryTools.AutoSize = false;
            this.toolStripBtnDropDownBoundaryTools.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripBtnDropDownBoundaryTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnDropDownBoundaryTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.treePlanterToolStripMenuItem,
            this.webCamToolStripItem,
            this.toolStripBtnSmoothABCurve,
            this.toolStripDeleteApplied,
            this.fileExplorerToolStripItem,
            this.deleteContourPathsToolStripMenuItem,
            this.toolStripBtnMakeBndContour,
            this.boundariesToolStripMenuItem});
            this.toolStripBtnDropDownBoundaryTools.Font = new System.Drawing.Font("Tahoma", 18F);
            this.toolStripBtnDropDownBoundaryTools.Image = global::AgOpenGPS.Properties.Resources.GifBounds;
            this.toolStripBtnDropDownBoundaryTools.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnDropDownBoundaryTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDropDownBoundaryTools.Name = "toolStripBtnDropDownBoundaryTools";
            this.toolStripBtnDropDownBoundaryTools.ShowDropDownArrow = false;
            this.toolStripBtnDropDownBoundaryTools.Size = new System.Drawing.Size(110, 68);
            // 
            // treePlanterToolStripMenuItem
            // 
            this.treePlanterToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treePlanterToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.tree;
            this.treePlanterToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.treePlanterToolStripMenuItem.Name = "treePlanterToolStripMenuItem";
            this.treePlanterToolStripMenuItem.Size = new System.Drawing.Size(401, 70);
            this.treePlanterToolStripMenuItem.Text = "Tree Planter";
            this.treePlanterToolStripMenuItem.Click += new System.EventHandler(this.treePlanterToolStripMenuItem_Click);
            // 
            // webCamToolStripItem
            // 
            this.webCamToolStripItem.Image = global::AgOpenGPS.Properties.Resources.Webcam;
            this.webCamToolStripItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.webCamToolStripItem.Name = "webCamToolStripItem";
            this.webCamToolStripItem.Size = new System.Drawing.Size(401, 70);
            this.webCamToolStripItem.Text = "WebCam";
            this.webCamToolStripItem.Click += new System.EventHandler(this.webCamToolStripItem_Click);
            // 
            // toolStripBtnSmoothABCurve
            // 
            this.toolStripBtnSmoothABCurve.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.toolStripBtnSmoothABCurve.Image = global::AgOpenGPS.Properties.Resources.ABSmooth;
            this.toolStripBtnSmoothABCurve.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnSmoothABCurve.Name = "toolStripBtnSmoothABCurve";
            this.toolStripBtnSmoothABCurve.Size = new System.Drawing.Size(401, 70);
            this.toolStripBtnSmoothABCurve.Text = "Smooth AB Curve";
            this.toolStripBtnSmoothABCurve.Click += new System.EventHandler(this.toolStripBtnSmoothABCurve_Click);
            // 
            // toolStripDeleteApplied
            // 
            this.toolStripDeleteApplied.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAreYouSure});
            this.toolStripDeleteApplied.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDeleteApplied.Image = global::AgOpenGPS.Properties.Resources.skull;
            this.toolStripDeleteApplied.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDeleteApplied.Name = "toolStripDeleteApplied";
            this.toolStripDeleteApplied.Size = new System.Drawing.Size(401, 70);
            this.toolStripDeleteApplied.Text = "Delete Applied Area";
            // 
            // toolStripAreYouSure
            // 
            this.toolStripAreYouSure.Name = "toolStripAreYouSure";
            this.toolStripAreYouSure.Size = new System.Drawing.Size(235, 34);
            this.toolStripAreYouSure.Text = "Are You sure?";
            this.toolStripAreYouSure.Click += new System.EventHandler(this.toolStripAreYouSure_Click);
            // 
            // fileExplorerToolStripItem
            // 
            this.fileExplorerToolStripItem.Image = global::AgOpenGPS.Properties.Resources.FileExplorerWindows;
            this.fileExplorerToolStripItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fileExplorerToolStripItem.Name = "fileExplorerToolStripItem";
            this.fileExplorerToolStripItem.Size = new System.Drawing.Size(401, 70);
            this.fileExplorerToolStripItem.Text = "Field - File Explorer";
            this.fileExplorerToolStripItem.Click += new System.EventHandler(this.fileExplorerToolStripItem_Click);
            // 
            // deleteContourPathsToolStripMenuItem
            // 
            this.deleteContourPathsToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.HideContour;
            this.deleteContourPathsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteContourPathsToolStripMenuItem.Name = "deleteContourPathsToolStripMenuItem";
            this.deleteContourPathsToolStripMenuItem.Size = new System.Drawing.Size(401, 70);
            this.deleteContourPathsToolStripMenuItem.Text = "Hide Contour Paths";
            this.deleteContourPathsToolStripMenuItem.Click += new System.EventHandler(this.deleteContourPathsToolStripMenuItem_Click);
            // 
            // toolStripBtnMakeBndContour
            // 
            this.toolStripBtnMakeBndContour.Image = global::AgOpenGPS.Properties.Resources.MakeBoundary;
            this.toolStripBtnMakeBndContour.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnMakeBndContour.Name = "toolStripBtnMakeBndContour";
            this.toolStripBtnMakeBndContour.Size = new System.Drawing.Size(401, 70);
            this.toolStripBtnMakeBndContour.Text = "Make Boundary Contours";
            this.toolStripBtnMakeBndContour.Click += new System.EventHandler(this.toolStripBtnMakeBndContour_Click);
            // 
            // boundariesToolStripMenuItem
            // 
            this.boundariesToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.BoundaryMenu;
            this.boundariesToolStripMenuItem.Name = "boundariesToolStripMenuItem";
            this.boundariesToolStripMenuItem.Size = new System.Drawing.Size(401, 70);
            this.boundariesToolStripMenuItem.Text = "Boundary";
            this.boundariesToolStripMenuItem.Click += new System.EventHandler(this.boundariesToolStripMenuItem_Click);
            // 
            // toolStripBtnYouTurn
            // 
            this.toolStripBtnYouTurn.AutoSize = false;
            this.toolStripBtnYouTurn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripBtnYouTurn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnYouTurn.Font = new System.Drawing.Font("Tahoma", 18F);
            this.toolStripBtnYouTurn.Image = global::AgOpenGPS.Properties.Resources.Youturn64;
            this.toolStripBtnYouTurn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnYouTurn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnYouTurn.Name = "toolStripBtnYouTurn";
            this.toolStripBtnYouTurn.ShowDropDownArrow = false;
            this.toolStripBtnYouTurn.Size = new System.Drawing.Size(110, 68);
            this.toolStripBtnYouTurn.Click += new System.EventHandler(this.toolStripBtnYouTurn_Click);
            // 
            // btnRightYouTurn
            // 
            this.btnRightYouTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRightYouTurn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRightYouTurn.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnRightYouTurn.Enabled = false;
            this.btnRightYouTurn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightYouTurn.Image = global::AgOpenGPS.Properties.Resources.ArrowRight;
            this.btnRightYouTurn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRightYouTurn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRightYouTurn.Location = new System.Drawing.Point(905, 138);
            this.btnRightYouTurn.Name = "btnRightYouTurn";
            this.btnRightYouTurn.Size = new System.Drawing.Size(80, 65);
            this.btnRightYouTurn.TabIndex = 142;
            this.btnRightYouTurn.Text = "8888 ft";
            this.btnRightYouTurn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRightYouTurn.UseVisualStyleBackColor = false;
            this.btnRightYouTurn.Click += new System.EventHandler(this.btnRightYouTurn_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator9,
            this.menustripLanguage,
            this.toolStripSeparator11,
            this.setWorkingDirectoryToolStripMenuItem,
            this.toolStripSeparator10,
            this.enterSimCoordsToolStripMenuItem,
            this.toolStripSeparator12,
            this.loadVehicleToolStripMenuItem,
            this.saveVehicleToolStripMenuItem,
            this.toolStripSeparator8,
            this.fieldToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.shortcutKeysToolStripMenuItem});
            this.fileToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.fileMenu;
            this.fileToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(108, 40);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(316, 6);
            // 
            // menustripLanguage
            // 
            this.menustripLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLanguageDeutsch,
            this.menuLanguageEnglish,
            this.menuLanguageFrench,
            this.menuLanguageItalian,
            this.menuLanguageDutch,
            this.menuLanguageRussian,
            this.menuLanguageSpanish});
            this.menustripLanguage.Name = "menustripLanguage";
            this.menustripLanguage.Size = new System.Drawing.Size(319, 40);
            this.menustripLanguage.Text = "Language";
            // 
            // menuLanguageDeutsch
            // 
            this.menuLanguageDeutsch.CheckOnClick = true;
            this.menuLanguageDeutsch.Name = "menuLanguageDeutsch";
            this.menuLanguageDeutsch.Size = new System.Drawing.Size(240, 40);
            this.menuLanguageDeutsch.Text = "Deutsch";
            this.menuLanguageDeutsch.Click += new System.EventHandler(this.menuLanguageDeutsch_Click);
            // 
            // menuLanguageEnglish
            // 
            this.menuLanguageEnglish.CheckOnClick = true;
            this.menuLanguageEnglish.Name = "menuLanguageEnglish";
            this.menuLanguageEnglish.Size = new System.Drawing.Size(240, 40);
            this.menuLanguageEnglish.Text = "English";
            this.menuLanguageEnglish.Click += new System.EventHandler(this.menuLanguageEnglish_Click);
            // 
            // menuLanguageFrench
            // 
            this.menuLanguageFrench.CheckOnClick = true;
            this.menuLanguageFrench.Name = "menuLanguageFrench";
            this.menuLanguageFrench.Size = new System.Drawing.Size(240, 40);
            this.menuLanguageFrench.Text = "Français";
            this.menuLanguageFrench.Click += new System.EventHandler(this.menuLanguageFrench_Click);
            // 
            // menuLanguageItalian
            // 
            this.menuLanguageItalian.Name = "menuLanguageItalian";
            this.menuLanguageItalian.Size = new System.Drawing.Size(240, 40);
            this.menuLanguageItalian.Text = "Italiano";
            this.menuLanguageItalian.Click += new System.EventHandler(this.menuLanguageItalian_Click);
            // 
            // menuLanguageDutch
            // 
            this.menuLanguageDutch.CheckOnClick = true;
            this.menuLanguageDutch.Name = "menuLanguageDutch";
            this.menuLanguageDutch.Size = new System.Drawing.Size(240, 40);
            this.menuLanguageDutch.Text = "Nederlands";
            this.menuLanguageDutch.Click += new System.EventHandler(this.menuLanguageDutch_Click);
            // 
            // menuLanguageRussian
            // 
            this.menuLanguageRussian.CheckOnClick = true;
            this.menuLanguageRussian.Enabled = false;
            this.menuLanguageRussian.Name = "menuLanguageRussian";
            this.menuLanguageRussian.Size = new System.Drawing.Size(240, 40);
            this.menuLanguageRussian.Text = "русский";
            this.menuLanguageRussian.Click += new System.EventHandler(this.menuLanguageRussian_Click);
            // 
            // menuLanguageSpanish
            // 
            this.menuLanguageSpanish.CheckOnClick = true;
            this.menuLanguageSpanish.Enabled = false;
            this.menuLanguageSpanish.Name = "menuLanguageSpanish";
            this.menuLanguageSpanish.Size = new System.Drawing.Size(240, 40);
            this.menuLanguageSpanish.Text = "Español";
            this.menuLanguageSpanish.Click += new System.EventHandler(this.menuLanguageSpanish_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(316, 6);
            // 
            // setWorkingDirectoryToolStripMenuItem
            // 
            this.setWorkingDirectoryToolStripMenuItem.Name = "setWorkingDirectoryToolStripMenuItem";
            this.setWorkingDirectoryToolStripMenuItem.Size = new System.Drawing.Size(319, 40);
            this.setWorkingDirectoryToolStripMenuItem.Text = "Directories";
            this.setWorkingDirectoryToolStripMenuItem.Click += new System.EventHandler(this.setWorkingDirectoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(316, 6);
            // 
            // enterSimCoordsToolStripMenuItem
            // 
            this.enterSimCoordsToolStripMenuItem.Name = "enterSimCoordsToolStripMenuItem";
            this.enterSimCoordsToolStripMenuItem.Size = new System.Drawing.Size(319, 40);
            this.enterSimCoordsToolStripMenuItem.Text = "Enter Sim Coords";
            this.enterSimCoordsToolStripMenuItem.Click += new System.EventHandler(this.enterSimCoordsToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(316, 6);
            // 
            // loadVehicleToolStripMenuItem
            // 
            this.loadVehicleToolStripMenuItem.Name = "loadVehicleToolStripMenuItem";
            this.loadVehicleToolStripMenuItem.Size = new System.Drawing.Size(319, 40);
            this.loadVehicleToolStripMenuItem.Text = "Load Vehicle";
            this.loadVehicleToolStripMenuItem.Click += new System.EventHandler(this.loadVehicleToolStripMenuItem_Click);
            // 
            // saveVehicleToolStripMenuItem
            // 
            this.saveVehicleToolStripMenuItem.Name = "saveVehicleToolStripMenuItem";
            this.saveVehicleToolStripMenuItem.Size = new System.Drawing.Size(319, 40);
            this.saveVehicleToolStripMenuItem.Text = "Save Vehicle";
            this.saveVehicleToolStripMenuItem.Click += new System.EventHandler(this.saveVehicleToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(316, 6);
            // 
            // fieldToolStripMenuItem
            // 
            this.fieldToolStripMenuItem.Name = "fieldToolStripMenuItem";
            this.fieldToolStripMenuItem.Size = new System.Drawing.Size(319, 40);
            this.fieldToolStripMenuItem.Text = "Field";
            this.fieldToolStripMenuItem.Click += new System.EventHandler(this.fieldToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(319, 40);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // shortcutKeysToolStripMenuItem
            // 
            this.shortcutKeysToolStripMenuItem.Name = "shortcutKeysToolStripMenuItem";
            this.shortcutKeysToolStripMenuItem.Size = new System.Drawing.Size(319, 40);
            this.shortcutKeysToolStripMenuItem.Text = "Shortcut Keys";
            this.shortcutKeysToolStripMenuItem.Click += new System.EventHandler(this.shortcutKeysToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.resetALLToolStripMenuItem,
            this.toolStripSeparator2,
            this.colorsToolStripMenuItem,
            this.toolStripUnitsMenu,
            this.sideGuideLines,
            this.gridToolStripMenuItem,
            this.lightbarToolStripMenuItem,
            this.logNMEAMenuItem,
            this.polygonsToolStripMenuItem,
            this.pursuitLineToolStripMenuItem,
            this.skyToolStripMenu,
            this.toolStripSeparator6,
            this.simulatorOnToolStripMenuItem,
            this.toolStripSeparator7});
            this.settingsToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.displayMenu;
            this.settingsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(108, 40);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(260, 6);
            // 
            // resetALLToolStripMenuItem
            // 
            this.resetALLToolStripMenuItem.Name = "resetALLToolStripMenuItem";
            this.resetALLToolStripMenuItem.Size = new System.Drawing.Size(263, 40);
            this.resetALLToolStripMenuItem.Text = "Reset ALL";
            this.resetALLToolStripMenuItem.Click += new System.EventHandler(this.resetALLToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(260, 6);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sectionToolStripMenuItem,
            this.fieldToolStripMenuItem1});
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(263, 40);
            this.colorsToolStripMenuItem.Text = "Colors";
            // 
            // sectionToolStripMenuItem
            // 
            this.sectionToolStripMenuItem.Name = "sectionToolStripMenuItem";
            this.sectionToolStripMenuItem.Size = new System.Drawing.Size(187, 40);
            this.sectionToolStripMenuItem.Text = "Section";
            this.sectionToolStripMenuItem.Click += new System.EventHandler(this.sectionToolStripMenuItem_Click);
            // 
            // fieldToolStripMenuItem1
            // 
            this.fieldToolStripMenuItem1.Name = "fieldToolStripMenuItem1";
            this.fieldToolStripMenuItem1.Size = new System.Drawing.Size(187, 40);
            this.fieldToolStripMenuItem1.Text = "Field";
            this.fieldToolStripMenuItem1.Click += new System.EventHandler(this.fieldToolStripMenuItem1_Click);
            // 
            // toolStripUnitsMenu
            // 
            this.toolStripUnitsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metricToolStrip,
            this.imperialToolStrip});
            this.toolStripUnitsMenu.Name = "toolStripUnitsMenu";
            this.toolStripUnitsMenu.Size = new System.Drawing.Size(263, 40);
            this.toolStripUnitsMenu.Text = "Units";
            // 
            // metricToolStrip
            // 
            this.metricToolStrip.CheckOnClick = true;
            this.metricToolStrip.Name = "metricToolStrip";
            this.metricToolStrip.Size = new System.Drawing.Size(200, 40);
            this.metricToolStrip.Text = "Metric";
            this.metricToolStrip.Click += new System.EventHandler(this.metricToolStrip_Click);
            // 
            // imperialToolStrip
            // 
            this.imperialToolStrip.CheckOnClick = true;
            this.imperialToolStrip.Name = "imperialToolStrip";
            this.imperialToolStrip.Size = new System.Drawing.Size(200, 40);
            this.imperialToolStrip.Text = "Imperial";
            this.imperialToolStrip.Click += new System.EventHandler(this.imperialToolStrip_Click);
            // 
            // sideGuideLines
            // 
            this.sideGuideLines.Checked = true;
            this.sideGuideLines.CheckOnClick = true;
            this.sideGuideLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sideGuideLines.Name = "sideGuideLines";
            this.sideGuideLines.Size = new System.Drawing.Size(263, 40);
            this.sideGuideLines.Text = "Extra Guides";
            this.sideGuideLines.Click += new System.EventHandler(this.sideGuideLines_Click);
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(263, 40);
            this.gridToolStripMenuItem.Text = "Grid On";
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
            // 
            // lightbarToolStripMenuItem
            // 
            this.lightbarToolStripMenuItem.Name = "lightbarToolStripMenuItem";
            this.lightbarToolStripMenuItem.Size = new System.Drawing.Size(263, 40);
            this.lightbarToolStripMenuItem.Text = "Lightbar On";
            this.lightbarToolStripMenuItem.Click += new System.EventHandler(this.lightbarToolStripMenuItem_Click);
            // 
            // logNMEAMenuItem
            // 
            this.logNMEAMenuItem.Name = "logNMEAMenuItem";
            this.logNMEAMenuItem.Size = new System.Drawing.Size(263, 40);
            this.logNMEAMenuItem.Text = "Log NMEA";
            this.logNMEAMenuItem.Click += new System.EventHandler(this.logNMEAMenuItem_Click);
            // 
            // polygonsToolStripMenuItem
            // 
            this.polygonsToolStripMenuItem.Checked = true;
            this.polygonsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.polygonsToolStripMenuItem.Name = "polygonsToolStripMenuItem";
            this.polygonsToolStripMenuItem.Size = new System.Drawing.Size(263, 40);
            this.polygonsToolStripMenuItem.Text = "Polygons On";
            this.polygonsToolStripMenuItem.Click += new System.EventHandler(this.polygonsToolStripMenuItem_Click);
            // 
            // pursuitLineToolStripMenuItem
            // 
            this.pursuitLineToolStripMenuItem.Checked = true;
            this.pursuitLineToolStripMenuItem.CheckOnClick = true;
            this.pursuitLineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pursuitLineToolStripMenuItem.Name = "pursuitLineToolStripMenuItem";
            this.pursuitLineToolStripMenuItem.Size = new System.Drawing.Size(263, 40);
            this.pursuitLineToolStripMenuItem.Text = "Pursuit Line";
            this.pursuitLineToolStripMenuItem.Click += new System.EventHandler(this.pursuitLineToolStripMenuItem_Click);
            // 
            // skyToolStripMenu
            // 
            this.skyToolStripMenu.Checked = true;
            this.skyToolStripMenu.CheckOnClick = true;
            this.skyToolStripMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skyToolStripMenu.Name = "skyToolStripMenu";
            this.skyToolStripMenu.Size = new System.Drawing.Size(263, 40);
            this.skyToolStripMenu.Text = "Sky On";
            this.skyToolStripMenu.Click += new System.EventHandler(this.skyToolStripMenu_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(260, 6);
            // 
            // simulatorOnToolStripMenuItem
            // 
            this.simulatorOnToolStripMenuItem.CheckOnClick = true;
            this.simulatorOnToolStripMenuItem.Name = "simulatorOnToolStripMenuItem";
            this.simulatorOnToolStripMenuItem.Size = new System.Drawing.Size(263, 40);
            this.simulatorOnToolStripMenuItem.Text = "Simulator On";
            this.simulatorOnToolStripMenuItem.Click += new System.EventHandler(this.simulatorOnToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(260, 6);
            // 
            // deleteFlagToolOpenGLContextMenu
            // 
            this.deleteFlagToolOpenGLContextMenu.AutoSize = false;
            this.deleteFlagToolOpenGLContextMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteFlagToolOpenGLContextMenu.Image = global::AgOpenGPS.Properties.Resources.FlagDelete;
            this.deleteFlagToolOpenGLContextMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteFlagToolOpenGLContextMenu.Name = "deleteFlagToolOpenGLContextMenu";
            this.deleteFlagToolOpenGLContextMenu.Size = new System.Drawing.Size(70, 70);
            this.deleteFlagToolOpenGLContextMenu.Text = ".";
            this.deleteFlagToolOpenGLContextMenu.Click += new System.EventHandler(this.deleteFlagToolOpenGLContextMenu_Click);
            // 
            // googleEarthOpenGLContextMenu
            // 
            this.googleEarthOpenGLContextMenu.AutoSize = false;
            this.googleEarthOpenGLContextMenu.Image = global::AgOpenGPS.Properties.Resources.GoogleEarth;
            this.googleEarthOpenGLContextMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.googleEarthOpenGLContextMenu.Name = "googleEarthOpenGLContextMenu";
            this.googleEarthOpenGLContextMenu.Size = new System.Drawing.Size(70, 70);
            this.googleEarthOpenGLContextMenu.Text = ".";
            this.googleEarthOpenGLContextMenu.Click += new System.EventHandler(this.googleEarthOpenGLContextMenu_Click);
            // 
            // btnRecordElevation
            // 
            this.btnRecordElevation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecordElevation.BackColor = System.Drawing.Color.AliceBlue;
            this.btnRecordElevation.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnRecordElevation.Image = global::AgOpenGPS.Properties.Resources.BoundaryRecord;
            this.btnRecordElevation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecordElevation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRecordElevation.Location = new System.Drawing.Point(876, 200);
            this.btnRecordElevation.Name = "btnRecordElevation";
            this.btnRecordElevation.Size = new System.Drawing.Size(82, 90);
            this.btnRecordElevation.TabIndex = 226;
            this.btnRecordElevation.Text = "Record Elevation";
            this.btnRecordElevation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecordElevation.UseVisualStyleBackColor = false;
            this.btnRecordElevation.Click += new System.EventHandler(this.BtnRecordElevation_Click);
            // 
            // btnCurve
            // 
            this.btnCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCurve.Enabled = false;
            this.btnCurve.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCurve.FlatAppearance.BorderSize = 0;
            this.btnCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurve.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurve.Image = global::AgOpenGPS.Properties.Resources.CurveOff;
            this.btnCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCurve.Location = new System.Drawing.Point(91, 3);
            this.btnCurve.Margin = new System.Windows.Forms.Padding(0);
            this.btnCurve.Name = "btnCurve";
            this.btnCurve.Size = new System.Drawing.Size(86, 64);
            this.btnCurve.TabIndex = 173;
            this.btnCurve.Text = "34";
            this.btnCurve.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCurve.UseVisualStyleBackColor = false;
            this.btnCurve.Click += new System.EventHandler(this.btnCurve_Click);
            // 
            // btnContour
            // 
            this.btnContour.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContour.BackColor = System.Drawing.Color.Transparent;
            this.btnContour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnContour.Enabled = false;
            this.btnContour.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnContour.FlatAppearance.BorderSize = 0;
            this.btnContour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContour.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContour.Image = global::AgOpenGPS.Properties.Resources.ContourOff;
            this.btnContour.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnContour.Location = new System.Drawing.Point(94, 73);
            this.btnContour.Name = "btnContour";
            this.btnContour.Size = new System.Drawing.Size(80, 58);
            this.btnContour.TabIndex = 105;
            this.btnContour.Text = "34 cm";
            this.btnContour.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContour.UseVisualStyleBackColor = false;
            this.btnContour.Click += new System.EventHandler(this.btnContour_Click);
            // 
            // btnABLine
            // 
            this.btnABLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnABLine.BackColor = System.Drawing.Color.Transparent;
            this.btnABLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnABLine.Enabled = false;
            this.btnABLine.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnABLine.FlatAppearance.BorderSize = 0;
            this.btnABLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnABLine.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineOff;
            this.btnABLine.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnABLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnABLine.Location = new System.Drawing.Point(94, 140);
            this.btnABLine.Name = "btnABLine";
            this.btnABLine.Size = new System.Drawing.Size(80, 58);
            this.btnABLine.TabIndex = 0;
            this.btnABLine.Text = "43";
            this.btnABLine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnABLine.UseVisualStyleBackColor = false;
            this.btnABLine.Click += new System.EventHandler(this.btnABLine_Click);
            // 
            // btnSectionOffAutoOn
            // 
            this.btnSectionOffAutoOn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSectionOffAutoOn.BackColor = System.Drawing.Color.Transparent;
            this.btnSectionOffAutoOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSectionOffAutoOn.Enabled = false;
            this.btnSectionOffAutoOn.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSectionOffAutoOn.FlatAppearance.BorderSize = 0;
            this.btnSectionOffAutoOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSectionOffAutoOn.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.btnSectionOffAutoOn.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;
            this.btnSectionOffAutoOn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSectionOffAutoOn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSectionOffAutoOn.Location = new System.Drawing.Point(91, 500);
            this.btnSectionOffAutoOn.Margin = new System.Windows.Forms.Padding(0);
            this.btnSectionOffAutoOn.Name = "btnSectionOffAutoOn";
            this.btnSectionOffAutoOn.Size = new System.Drawing.Size(86, 84);
            this.btnSectionOffAutoOn.TabIndex = 152;
            this.btnSectionOffAutoOn.Text = "888.8";
            this.btnSectionOffAutoOn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSectionOffAutoOn.UseVisualStyleBackColor = false;
            this.btnSectionOffAutoOn.Click += new System.EventHandler(this.btnSectionOffAutoOn_Click);
            // 
            // btnManualOffOn
            // 
            this.btnManualOffOn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManualOffOn.BackColor = System.Drawing.Color.Transparent;
            this.btnManualOffOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnManualOffOn.Enabled = false;
            this.btnManualOffOn.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnManualOffOn.FlatAppearance.BorderSize = 0;
            this.btnManualOffOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManualOffOn.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnManualOffOn.Image = global::AgOpenGPS.Properties.Resources.ManualOff;
            this.btnManualOffOn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnManualOffOn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnManualOffOn.Location = new System.Drawing.Point(94, 429);
            this.btnManualOffOn.Name = "btnManualOffOn";
            this.btnManualOffOn.Size = new System.Drawing.Size(80, 65);
            this.btnManualOffOn.TabIndex = 98;
            this.btnManualOffOn.UseVisualStyleBackColor = false;
            this.btnManualOffOn.Click += new System.EventHandler(this.btnManualOffOn_Click);
            // 
            // btnEnableAutoYouTurn
            // 
            this.btnEnableAutoYouTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnableAutoYouTurn.BackColor = System.Drawing.Color.Transparent;
            this.btnEnableAutoYouTurn.Enabled = false;
            this.btnEnableAutoYouTurn.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnEnableAutoYouTurn.FlatAppearance.BorderSize = 0;
            this.btnEnableAutoYouTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnableAutoYouTurn.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnEnableAutoYouTurn.Image = global::AgOpenGPS.Properties.Resources.YouTurnNo;
            this.btnEnableAutoYouTurn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEnableAutoYouTurn.Location = new System.Drawing.Point(94, 355);
            this.btnEnableAutoYouTurn.Name = "btnEnableAutoYouTurn";
            this.btnEnableAutoYouTurn.Size = new System.Drawing.Size(80, 65);
            this.btnEnableAutoYouTurn.TabIndex = 132;
            this.btnEnableAutoYouTurn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnableAutoYouTurn.UseVisualStyleBackColor = false;
            this.btnEnableAutoYouTurn.Click += new System.EventHandler(this.btnEnableAutoYouTurn_Click);
            // 
            // btnAutoSteer
            // 
            this.btnAutoSteer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoSteer.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoSteer.Enabled = false;
            this.btnAutoSteer.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnAutoSteer.FlatAppearance.BorderSize = 0;
            this.btnAutoSteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoSteer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnAutoSteer.Image = global::AgOpenGPS.Properties.Resources.AutoSteerOff;
            this.btnAutoSteer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAutoSteer.Location = new System.Drawing.Point(91, 278);
            this.btnAutoSteer.Margin = new System.Windows.Forms.Padding(0);
            this.btnAutoSteer.Name = "btnAutoSteer";
            this.btnAutoSteer.Size = new System.Drawing.Size(86, 71);
            this.btnAutoSteer.TabIndex = 128;
            this.btnAutoSteer.Text = "M";
            this.btnAutoSteer.UseVisualStyleBackColor = false;
            this.btnAutoSteer.Click += new System.EventHandler(this.btnAutoSteer_Click);
            // 
            // btnSwapDirection
            // 
            this.btnSwapDirection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSwapDirection.BackColor = System.Drawing.Color.Indigo;
            this.btnSwapDirection.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSwapDirection.FlatAppearance.BorderSize = 2;
            this.btnSwapDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwapDirection.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSwapDirection.Image = global::AgOpenGPS.Properties.Resources.YouTurnReverse;
            this.btnSwapDirection.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSwapDirection.Location = new System.Drawing.Point(6, 142);
            this.btnSwapDirection.Margin = new System.Windows.Forms.Padding(0);
            this.btnSwapDirection.Name = "btnSwapDirection";
            this.btnSwapDirection.Size = new System.Drawing.Size(79, 53);
            this.btnSwapDirection.TabIndex = 179;
            this.btnSwapDirection.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSwapDirection.UseVisualStyleBackColor = false;
            this.btnSwapDirection.Visible = false;
            this.btnSwapDirection.Click += new System.EventHandler(this.btnSwapDirection_Click_1);
            // 
            // btnCycleLines
            // 
            this.btnCycleLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCycleLines.BackColor = System.Drawing.Color.Transparent;
            this.btnCycleLines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCycleLines.Enabled = false;
            this.btnCycleLines.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCycleLines.FlatAppearance.BorderSize = 0;
            this.btnCycleLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCycleLines.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnCycleLines.Image = global::AgOpenGPS.Properties.Resources.ABLineCycle;
            this.btnCycleLines.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCycleLines.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCycleLines.Location = new System.Drawing.Point(94, 207);
            this.btnCycleLines.Name = "btnCycleLines";
            this.btnCycleLines.Size = new System.Drawing.Size(80, 65);
            this.btnCycleLines.TabIndex = 251;
            this.btnCycleLines.Text = "-";
            this.btnCycleLines.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCycleLines.UseVisualStyleBackColor = false;
            this.btnCycleLines.Click += new System.EventHandler(this.btnCycleLines_Click);
            // 
            // btnFlag
            // 
            this.btnFlag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFlag.BackColor = System.Drawing.Color.Transparent;
            this.btnFlag.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnFlag.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnFlag.FlatAppearance.BorderSize = 0;
            this.btnFlag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlag.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnFlag.Image = global::AgOpenGPS.Properties.Resources.FlagRed;
            this.btnFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFlag.Location = new System.Drawing.Point(6, 281);
            this.btnFlag.Name = "btnFlag";
            this.btnFlag.Size = new System.Drawing.Size(79, 65);
            this.btnFlag.TabIndex = 121;
            this.btnFlag.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFlag.UseVisualStyleBackColor = false;
            this.btnFlag.Click += new System.EventHandler(this.btnFlag_Click);
            // 
            // btnMakeLinesFromBoundary
            // 
            this.btnMakeLinesFromBoundary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeLinesFromBoundary.BackColor = System.Drawing.Color.Transparent;
            this.btnMakeLinesFromBoundary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMakeLinesFromBoundary.Enabled = false;
            this.btnMakeLinesFromBoundary.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnMakeLinesFromBoundary.FlatAppearance.BorderSize = 0;
            this.btnMakeLinesFromBoundary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeLinesFromBoundary.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnMakeLinesFromBoundary.Image = global::AgOpenGPS.Properties.Resources.PointStart;
            this.btnMakeLinesFromBoundary.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeLinesFromBoundary.Location = new System.Drawing.Point(6, 207);
            this.btnMakeLinesFromBoundary.Name = "btnMakeLinesFromBoundary";
            this.btnMakeLinesFromBoundary.Size = new System.Drawing.Size(79, 65);
            this.btnMakeLinesFromBoundary.TabIndex = 250;
            this.btnMakeLinesFromBoundary.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMakeLinesFromBoundary.UseVisualStyleBackColor = false;
            this.btnMakeLinesFromBoundary.Click += new System.EventHandler(this.BtnMakeLinesFromBoundary_Click);
            // 
            // toolStripMenuItemFlagRed
            // 
            this.toolStripMenuItemFlagRed.AutoSize = false;
            this.toolStripMenuItemFlagRed.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuItemFlagRed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItemFlagRed.Image = global::AgOpenGPS.Properties.Resources.FlagRed;
            this.toolStripMenuItemFlagRed.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemFlagRed.Name = "toolStripMenuItemFlagRed";
            this.toolStripMenuItemFlagRed.Size = new System.Drawing.Size(70, 70);
            this.toolStripMenuItemFlagRed.Text = ".";
            this.toolStripMenuItemFlagRed.Click += new System.EventHandler(this.toolStripMenuItemFlagRed_Click);
            // 
            // toolStripMenuFlagGrn
            // 
            this.toolStripMenuFlagGrn.AutoSize = false;
            this.toolStripMenuFlagGrn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuFlagGrn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuFlagGrn.Image = global::AgOpenGPS.Properties.Resources.FlagGrn;
            this.toolStripMenuFlagGrn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuFlagGrn.Name = "toolStripMenuFlagGrn";
            this.toolStripMenuFlagGrn.Size = new System.Drawing.Size(70, 70);
            this.toolStripMenuFlagGrn.Text = ".";
            this.toolStripMenuFlagGrn.Click += new System.EventHandler(this.toolStripMenuGrn_Click);
            // 
            // toolStripMenuFlagYel
            // 
            this.toolStripMenuFlagYel.AutoSize = false;
            this.toolStripMenuFlagYel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuFlagYel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuFlagYel.Image = global::AgOpenGPS.Properties.Resources.FlagYel;
            this.toolStripMenuFlagYel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuFlagYel.Name = "toolStripMenuFlagYel";
            this.toolStripMenuFlagYel.Size = new System.Drawing.Size(70, 70);
            this.toolStripMenuFlagYel.Text = ".";
            this.toolStripMenuFlagYel.Click += new System.EventHandler(this.toolStripMenuYel_Click);
            // 
            // toolStripMenuFlagDelete
            // 
            this.toolStripMenuFlagDelete.AutoSize = false;
            this.toolStripMenuFlagDelete.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuFlagDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuFlagDelete.Image = global::AgOpenGPS.Properties.Resources.FlagDelete;
            this.toolStripMenuFlagDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuFlagDelete.Name = "toolStripMenuFlagDelete";
            this.toolStripMenuFlagDelete.Size = new System.Drawing.Size(70, 70);
            this.toolStripMenuFlagDelete.Text = ".";
            this.toolStripMenuFlagDelete.Click += new System.EventHandler(this.toolStripMenuFlagDelete_Click);
            // 
            // toolStripMenuFlagDeleteAll
            // 
            this.toolStripMenuFlagDeleteAll.AutoSize = false;
            this.toolStripMenuFlagDeleteAll.Image = global::AgOpenGPS.Properties.Resources.FlagDeleteAll;
            this.toolStripMenuFlagDeleteAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuFlagDeleteAll.Name = "toolStripMenuFlagDeleteAll";
            this.toolStripMenuFlagDeleteAll.Size = new System.Drawing.Size(70, 70);
            this.toolStripMenuFlagDeleteAll.Text = "toolStripMenuFlagDeleteAll";
            this.toolStripMenuFlagDeleteAll.Click += new System.EventHandler(this.toolStripMenuFlagDeleteAll_Click);
            // 
            // FormGPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1371, 701);
            this.Controls.Add(this.panelTram);
            this.Controls.Add(this.panelSnap);
            this.Controls.Add(this.panelSim);
            this.Controls.Add(this.tableLayoutPanelDisplay);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.panelZoom);
            this.Controls.Add(this.lblHz);
            this.Controls.Add(this.btnLeftYouTurn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnRightYouTurn);
            this.Controls.Add(this.lblSpeedUnits);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.txtDistanceOffABLine);
            this.Controls.Add(this.btnSection8Man);
            this.Controls.Add(this.btnSection7Man);
            this.Controls.Add(this.btnSection6Man);
            this.Controls.Add(this.btnSection5Man);
            this.Controls.Add(this.btnSection4Man);
            this.Controls.Add(this.btnSection3Man);
            this.Controls.Add(this.btnSection2Man);
            this.Controls.Add(this.btnSection1Man);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnSection12Man);
            this.Controls.Add(this.btnSection11Man);
            this.Controls.Add(this.btnSection10Man);
            this.Controls.Add(this.btnSection9Man);
            this.Controls.Add(this.oglMain);
            this.Controls.Add(this.nudElevation);
            this.Controls.Add(this.btnRecordElevation);
            this.Controls.Add(this.btnElevationMap);
            this.Controls.Add(this.oglBack);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1015, 740);
            this.Name = "FormGPS";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "AgOpenGPS - No Field Loaded";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGPS_FormClosing);
            this.Load += new System.EventHandler(this.FormGPS_Load);
            this.Resize += new System.EventHandler(this.FormGPS_Resize);
            this.contextMenuStripOpenGL.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStripFlag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudElevation)).EndInit();
            this.panelZoom.ResumeLayout(false);
            this.panelZoom.PerformLayout();
            this.statusStripLeft.ResumeLayout(false);
            this.statusStripLeft.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanelDisplay.ResumeLayout(false);
            this.panelSnap.ResumeLayout(false);
            this.panelSim.ResumeLayout(false);
            this.panelTram.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Timer tmrWatchdog;
        private System.Windows.Forms.ToolStripMenuItem polygonsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem resetALLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadVehicleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveVehicleToolStripMenuItem;
        private System.Windows.Forms.Button btnSection1Man;
        private System.Windows.Forms.Button btnSection2Man;
        private System.Windows.Forms.Button btnSection3Man;
        private System.Windows.Forms.Button btnSection4Man;
        private System.Windows.Forms.Button btnSection5Man;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightbarToolStripMenuItem;
        private System.Windows.Forms.Label lblNorthing;
        private System.Windows.Forms.Label lblEasting;
        private System.Windows.Forms.Label lblSpeed;
        private ProXoft.WinForms.RepeatButton btnZoomOut;
        private ProXoft.WinForms.RepeatButton btnZoomIn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFlag;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFlagRed;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFlagGrn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFlagYel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFlagDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFlagDeleteAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripOpenGL;
        private System.Windows.Forms.ToolStripMenuItem deleteFlagToolOpenGLContextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem googleEarthOpenGLContextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem fieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fieldToolStripMenuItem1;
        private System.Windows.Forms.Button btnSection8Man;
        private System.Windows.Forms.Button btnSection7Man;
        private System.Windows.Forms.Button btnSection6Man;
        private System.Windows.Forms.ToolStripMenuItem logNMEAMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripUnitsMenu;
        private System.Windows.Forms.ToolStripMenuItem metricToolStrip;
        private System.Windows.Forms.ToolStripMenuItem imperialToolStrip;
        private System.Windows.Forms.ToolStripMenuItem skyToolStripMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.Label lblSpeedUnits;
        private System.Windows.Forms.ToolStripMenuItem sideGuideLines;
        private System.Windows.Forms.ToolStripMenuItem pursuitLineToolStripMenuItem;
        private System.Windows.Forms.Button btnRightYouTurn;
        private System.Windows.Forms.Button btnLeftYouTurn;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Button btnFlag;
        private System.Windows.Forms.Button btnResetSim;
        private System.Windows.Forms.ToolStripMenuItem simulatorOnToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolstripUSBPortsConfig;
        private System.Windows.Forms.ToolStripMenuItem toolstripVehicleConfig;
        private System.Windows.Forms.ToolStripMenuItem toolstripAutoSteerConfig;
        private System.Windows.Forms.ToolStripMenuItem toolstripYouTurnConfig;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolstripUDPConfig;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.Button btnSectionOffAutoOn;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageEnglish;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageDeutsch;
        private System.Windows.Forms.ToolStripMenuItem setWorkingDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageRussian;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageDutch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageSpanish;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageFrench;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageItalian;
        public System.Windows.Forms.TextBox txtDistanceOffABLine;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolstripDisplayConfig;
        public System.Windows.Forms.Button btnCurve;
        private System.Windows.Forms.Label lblHeading2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnSection9Man;
        private System.Windows.Forms.Button btnSection10Man;
        private System.Windows.Forms.Button btnSection11Man;
        private System.Windows.Forms.Button btnSection12Man;
        private System.Windows.Forms.ToolStripMenuItem enterSimCoordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        public System.Windows.Forms.Button btnABLine;
        public System.Windows.Forms.Button btnEnableAutoYouTurn;
        public System.Windows.Forms.Button btnAutoSteer;
        private System.Windows.Forms.ToolStripDropDownButton toolStripBtnDropDownBoundaryTools;
        private System.Windows.Forms.HScrollBar hsbarStepDistance;
        private System.Windows.Forms.HScrollBar hsbarSteerAngle;
        private System.Windows.Forms.ToolStripMenuItem toolStripBtnSmoothABCurve;
        private System.Windows.Forms.ToolStripMenuItem toolStripDeleteApplied;
        private System.Windows.Forms.ToolStripMenuItem toolStripAreYouSure;
        public System.Windows.Forms.ToolStripMenuItem toolStripAutoSteerChart;
        private System.Windows.Forms.ToolStripMenuItem shortcutKeysToolStripMenuItem;
        private OpenTK.GLControl oglMain;
        private OpenTK.GLControl oglBack;
        private System.Windows.Forms.ToolStripDropDownButton toolStripBatman;
        private System.Windows.Forms.ComboBox cboxpRowWidth;
        private ProXoft.WinForms.RepeatButton btnpTiltUp;
        private ProXoft.WinForms.RepeatButton btnpTiltDown;
        private System.Windows.Forms.Button btnFlagsGoogleEarth;
        private System.Windows.Forms.Label lblHz;
        public System.Windows.Forms.Button btnSwapDirection;
        private System.Windows.Forms.ToolStripMenuItem toolStripNTRIPConfig;
        public System.Windows.Forms.Button btnContour;
        public System.Windows.Forms.Timer timerSim;
        private System.Windows.Forms.ToolStripMenuItem treePlanterToolStripMenuItem;
        public System.Windows.Forms.Button btnManualOffOn;
        private System.Windows.Forms.Button btnRecordElevation;
        private System.Windows.Forms.Button btnElevationMap;
        private System.Windows.Forms.NumericUpDown nudElevation;
        private System.Windows.Forms.ProgressBar pbarRelayCommSmall;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Button btnMakeLinesFromBoundary;
        private System.Windows.Forms.ProgressBar pbarFieldAreaRemainPercent;
        public System.Windows.Forms.ToolStripMenuItem menustripLanguage;
        public System.Windows.Forms.Button btnCycleLines;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblpAltitude;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label lblYawHeading;
        private System.Windows.Forms.Label lblGPSHeading;
        private System.Windows.Forms.Label lblpFieldAreaRemainPercent;
        private System.Windows.Forms.Label lblpBoundaryArea;
        private System.Windows.Forms.Label lblpFieldAreaRemain;
        private System.Windows.Forms.Label lblpAreaWorked;
        private System.Windows.Forms.Label lblpTimeToFinish;
        private System.Windows.Forms.ProgressBar pbarNtrip;
        private System.Windows.Forms.Label lblNtripBytes;
        private System.Windows.Forms.Label lblNTRIPSeconds;
        private System.Windows.Forms.Button btnStartStopNtrip;
        private System.Windows.Forms.Label lblWatch;
        private System.Windows.Forms.Label lblUturnByte;
        private System.Windows.Forms.ProgressBar pbarSteerSmall;
        private System.Windows.Forms.ProgressBar pbarUDPSmall;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panelZoom;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblSats;
        private System.Windows.Forms.ToolStripMenuItem webCamToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem fileExplorerToolStripItem;
        private System.Windows.Forms.Label lblFieldWidthEastWest;
        private System.Windows.Forms.Label lblFieldWidthNorthSouth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblZone;
        public System.Windows.Forms.Label lblConvergenceAngle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tboxSentence;
        private System.Windows.Forms.ToolStripMenuItem deleteContourPathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripbtnAutoSteerConfig;
        private System.Windows.Forms.ToolStripDropDownButton toolStripBtnGPSStength;
        private System.Windows.Forms.ToolStripMenuItem toolStripBtnMakeBndContour;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonDistance;
        private System.Windows.Forms.ToolStripDropDownButton toolStripBtnYouTurn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonVehicleSettings;
        private System.Windows.Forms.StatusStrip statusStripLeft;
        private System.Windows.Forms.ToolStripDropDownButton toolStripMenuRecPath;
        private System.Windows.Forms.ToolStripMenuItem recordRecPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePathRecPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton AutoManualtoolStripSplitButton1;
        public System.Windows.Forms.ToolStripMenuItem goStopRecPathToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem pauseResumeRecPathToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripDropDownButton steerAnglesToolStripDropDownButton1;
        private System.Windows.Forms.ToolStripSplitButton toolStripBtnPower;
        private System.Windows.Forms.ComboBox cboxTramBasedOn;
        private System.Windows.Forms.ComboBox cboxTramPassEvery;
        private System.Windows.Forms.ToolStripDropDownButton toolStripBtnField;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDisplay;
        private System.Windows.Forms.TableLayoutPanel panelSnap;
        private System.Windows.Forms.ToolStripMenuItem boundariesToolStripMenuItem;
        private System.Windows.Forms.Button btnSaveAB;
        private System.Windows.Forms.Button btnSnapRightSmall;
        private System.Windows.Forms.Button btnSnapLeftSmall;
        private System.Windows.Forms.Button btnSnapLeft;
        private System.Windows.Forms.Button btnSnapRight;
        private System.Windows.Forms.TableLayoutPanel panelSim;
        private System.Windows.Forms.Button btnResetSteerAngle;
        public System.Windows.Forms.Button btnContourPriority;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.TableLayoutPanel panelTram;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private OpenTK.GLControl oglZoom;
    }
}

