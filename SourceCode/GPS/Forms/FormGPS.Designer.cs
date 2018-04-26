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
            this.openGLControl = new SharpGL.OpenGLControl();
            this.contextMenuStripOpenGL = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteFlagToolOpenGLContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.googleEarthOpenGLContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDistanceOffABLine = new System.Windows.Forms.TextBox();
            this.openGLControlBack = new SharpGL.OpenGLControl();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.menustripLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageDeutsch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageRussian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageDutch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageSpanish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageFrench = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageItalian = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tmrWatchdog = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stripHz = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnHideTabs = new System.Windows.Forms.ToolStripDropDownButton();
            this.stripDistance = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolstripUDPConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripUSBPortsConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripDisplayConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripVehicleConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripAutoSteerConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripYouTurnConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.stripAreaRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownBtnFuncs = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolstripField = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripBoundary = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripHeadland = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripResetTrip = new System.Windows.Forms.ToolStripMenuItem();
            this.stripEqWidth = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripZoomOut = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripZoomIn = new System.Windows.Forms.ToolStripDropDownButton();
            this.stripPortGPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripOnlineGPS = new System.Windows.Forms.ToolStripProgressBar();
            this.stripPortArduino = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripOnlineArduino = new System.Windows.Forms.ToolStripProgressBar();
            this.stripPortAutoSteer = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripOnlineAutoSteer = new System.Windows.Forms.ToolStripProgressBar();
            this.lblNorthing = new System.Windows.Forms.Label();
            this.lblEasting = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.contextMenuStripFlag = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemFlagRed = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFlagGrn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFlagYel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuFlagDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuFlagDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuArea = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuAreaSide = new System.Windows.Forms.ToolStripMenuItem();
            this.tboxSentence = new System.Windows.Forms.TextBox();
            this.lblZone = new System.Windows.Forms.Label();
            this.lblSpeedUnits = new System.Windows.Forms.Label();
            this.lblHeading = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openGLControlZoom = new SharpGL.OpenGLControl();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFieldWidthNorthSouth = new System.Windows.Forms.Label();
            this.lblFieldWidthEastWest = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.DataPage = new System.Windows.Forms.TabPage();
            this.lblFixOffset = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHeading2 = new System.Windows.Forms.Label();
            this.lblFixQuality = new System.Windows.Forms.Label();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.btnZoomOut = new ProXoft.WinForms.RepeatButton();
            this.btnZoomIn = new ProXoft.WinForms.RepeatButton();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblHeadlandDistanceFromTool = new System.Windows.Forms.Label();
            this.lblHeadlandDistanceAway = new System.Windows.Forms.Label();
            this.lblBoundaryArea = new System.Windows.Forms.Label();
            this.lblRoll = new System.Windows.Forms.Label();
            this.lblGPSHeading = new System.Windows.Forms.Label();
            this.lblYawHeading = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.btnTiltUp = new ProXoft.WinForms.RepeatButton();
            this.btnTiltDown = new ProXoft.WinForms.RepeatButton();
            this.label22 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtBoxSendAutoSteer = new System.Windows.Forms.TextBox();
            this.txtBoxRecvAutoSteer = new System.Windows.Forms.TextBox();
            this.lblSats = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.zoomPage2 = new System.Windows.Forms.TabPage();
            this.btnMakeContourFromBoundary = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblZooom = new System.Windows.Forms.Label();
            this.btnDeleteAllData = new System.Windows.Forms.Button();
            this.btnPerimeter = new System.Windows.Forms.Button();
            this.rate2Page5 = new System.Windows.Forms.TabPage();
            this.label30 = new System.Windows.Forms.Label();
            this.btnSelectSingleDualMeter = new System.Windows.Forms.Button();
            this.btnSelectRate2 = new System.Windows.Forms.Button();
            this.btnSelectRate1 = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.txtBoxSendArduino = new System.Windows.Forms.TextBox();
            this.txtBoxRecvArduino = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.lblFlowRateRight = new System.Windows.Forms.Label();
            this.lblFlowRateLeft = new System.Windows.Forms.Label();
            this.btnRateRightDn = new ProXoft.WinForms.RepeatButton();
            this.btnRateRightUp = new ProXoft.WinForms.RepeatButton();
            this.lblRateSetpointRight = new System.Windows.Forms.Label();
            this.lblFlowRight = new System.Windows.Forms.Label();
            this.lblRateAppliedActualLeft = new System.Windows.Forms.Label();
            this.btnDualRateConfig = new System.Windows.Forms.Button();
            this.btnRateLeftDn = new ProXoft.WinForms.RepeatButton();
            this.label28 = new System.Windows.Forms.Label();
            this.lblFlowLeft = new System.Windows.Forms.Label();
            this.lblRateAppliedActualRight = new System.Windows.Forms.Label();
            this.lblDualAccumulatedVolume = new System.Windows.Forms.Label();
            this.btnRateLeftUp = new ProXoft.WinForms.RepeatButton();
            this.btnDualRate = new System.Windows.Forms.Button();
            this.lblRateSetpointLeft = new System.Windows.Forms.Label();
            this.configPage1 = new System.Windows.Forms.TabPage();
            this.btnFixOffset = new System.Windows.Forms.Button();
            this.btnSmoothAB = new System.Windows.Forms.Button();
            this.btnFlagsGoogleEarth = new System.Windows.Forms.Button();
            this.btnWebCam = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnFileExplorer = new System.Windows.Forms.Button();
            this.btnGPSData = new System.Windows.Forms.Button();
            this.autoPage4 = new System.Windows.Forms.TabPage();
            this.btnOffsetOutward = new System.Windows.Forms.Button();
            this.btnOffsetInward = new System.Windows.Forms.Button();
            this.btnOffsetBackward = new System.Windows.Forms.Button();
            this.btnOffsetForward = new System.Windows.Forms.Button();
            this.btnCartOnOff = new System.Windows.Forms.Button();
            this.btnCartDone = new System.Windows.Forms.Button();
            this.btnCallCart = new System.Windows.Forms.Button();
            this.btnRecPathPauseRecord = new System.Windows.Forms.Button();
            this.btnResetSim = new System.Windows.Forms.Button();
            this.btnResetSteerAngle = new System.Windows.Forms.Button();
            this.lblPureSteerAngle = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblSteerAngle = new System.Windows.Forms.Label();
            this.tbarSteerAngle = new System.Windows.Forms.TrackBar();
            this.tbarStepDistance = new System.Windows.Forms.TrackBar();
            this.timerSim = new System.Windows.Forms.Timer(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSimControls = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
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
            this.btnCurve = new System.Windows.Forms.Button();
            this.btnLeftYouTurn = new System.Windows.Forms.Button();
            this.btnSwapDirection = new System.Windows.Forms.Button();
            this.btnEnableAutoYouTurn = new System.Windows.Forms.Button();
            this.btnSectionOffAutoOn = new System.Windows.Forms.Button();
            this.btnFlag = new System.Windows.Forms.Button();
            this.btnSnap = new System.Windows.Forms.Button();
            this.btnAutoSteer = new System.Windows.Forms.Button();
            this.btnRightYouTurn = new System.Windows.Forms.Button();
            this.btnContour = new System.Windows.Forms.Button();
            this.btnManualOffOn = new System.Windows.Forms.Button();
            this.btnABLine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.contextMenuStripOpenGL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlBack)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStripFlag.SuspendLayout();
            this.contextMenuArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlZoom)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.DataPage.SuspendLayout();
            this.zoomPage2.SuspendLayout();
            this.rate2Page5.SuspendLayout();
            this.configPage1.SuspendLayout();
            this.autoPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSteerAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarStepDistance)).BeginInit();
            this.panelSimControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            resources.ApplyResources(this.openGLControl, "openGLControl");
            this.openGLControl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.openGLControl.ContextMenuStrip = this.contextMenuStripOpenGL;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openGLControl.FrameRate = 5;
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            // 
            // contextMenuStripOpenGL
            // 
            resources.ApplyResources(this.contextMenuStripOpenGL, "contextMenuStripOpenGL");
            this.contextMenuStripOpenGL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteFlagToolOpenGLContextMenu,
            this.toolStripSeparator5,
            this.googleEarthOpenGLContextMenu});
            this.contextMenuStripOpenGL.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.contextMenuStripOpenGL.Name = "contextMenuStripOpenGL";
            this.contextMenuStripOpenGL.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripOpenGL_Opening);
            // 
            // deleteFlagToolOpenGLContextMenu
            // 
            resources.ApplyResources(this.deleteFlagToolOpenGLContextMenu, "deleteFlagToolOpenGLContextMenu");
            this.deleteFlagToolOpenGLContextMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteFlagToolOpenGLContextMenu.Name = "deleteFlagToolOpenGLContextMenu";
            this.deleteFlagToolOpenGLContextMenu.Click += new System.EventHandler(this.deleteFlagToolOpenGLContextMenu_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // googleEarthOpenGLContextMenu
            // 
            resources.ApplyResources(this.googleEarthOpenGLContextMenu, "googleEarthOpenGLContextMenu");
            this.googleEarthOpenGLContextMenu.Name = "googleEarthOpenGLContextMenu";
            this.googleEarthOpenGLContextMenu.Click += new System.EventHandler(this.googleEarthOpenGLContextMenu_Click);
            // 
            // txtDistanceOffABLine
            // 
            resources.ApplyResources(this.txtDistanceOffABLine, "txtDistanceOffABLine");
            this.txtDistanceOffABLine.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtDistanceOffABLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDistanceOffABLine.ForeColor = System.Drawing.Color.Green;
            this.txtDistanceOffABLine.Name = "txtDistanceOffABLine";
            this.txtDistanceOffABLine.ReadOnly = true;
            // 
            // openGLControlBack
            // 
            this.openGLControlBack.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.openGLControlBack.DrawFPS = false;
            this.openGLControlBack.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openGLControlBack.FrameRate = 1;
            resources.ApplyResources(this.openGLControlBack, "openGLControlBack");
            this.openGLControlBack.Name = "openGLControlBack";
            this.openGLControlBack.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControlBack.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLControlBack.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.openGLControlBack.OpenGLInitialized += new System.EventHandler(this.openGLControlBack_OpenGLInitialized);
            this.openGLControlBack.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControlBack_OpenGLDraw);
            this.openGLControlBack.Resized += new System.EventHandler(this.openGLControlBack_Resized);
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
            this.aboutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // menustripLanguage
            // 
            this.menustripLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLanguageEnglish,
            this.menuLanguageDeutsch,
            this.menuLanguageRussian,
            this.menuLanguageDutch,
            this.menuLanguageSpanish,
            this.menuLanguageFrench,
            this.menuLanguageItalian});
            this.menustripLanguage.Name = "menustripLanguage";
            resources.ApplyResources(this.menustripLanguage, "menustripLanguage");
            // 
            // menuLanguageEnglish
            // 
            this.menuLanguageEnglish.CheckOnClick = true;
            this.menuLanguageEnglish.Name = "menuLanguageEnglish";
            resources.ApplyResources(this.menuLanguageEnglish, "menuLanguageEnglish");
            this.menuLanguageEnglish.Click += new System.EventHandler(this.menuLanguageEnglish_Click);
            // 
            // menuLanguageDeutsch
            // 
            this.menuLanguageDeutsch.CheckOnClick = true;
            this.menuLanguageDeutsch.Name = "menuLanguageDeutsch";
            resources.ApplyResources(this.menuLanguageDeutsch, "menuLanguageDeutsch");
            this.menuLanguageDeutsch.Click += new System.EventHandler(this.menuLanguageDeutsch_Click);
            // 
            // menuLanguageRussian
            // 
            this.menuLanguageRussian.CheckOnClick = true;
            this.menuLanguageRussian.Name = "menuLanguageRussian";
            resources.ApplyResources(this.menuLanguageRussian, "menuLanguageRussian");
            this.menuLanguageRussian.Click += new System.EventHandler(this.menuLanguageRussian_Click);
            // 
            // menuLanguageDutch
            // 
            this.menuLanguageDutch.CheckOnClick = true;
            this.menuLanguageDutch.Name = "menuLanguageDutch";
            resources.ApplyResources(this.menuLanguageDutch, "menuLanguageDutch");
            this.menuLanguageDutch.Click += new System.EventHandler(this.menuLanguageDutch_Click);
            // 
            // menuLanguageSpanish
            // 
            this.menuLanguageSpanish.CheckOnClick = true;
            this.menuLanguageSpanish.Name = "menuLanguageSpanish";
            resources.ApplyResources(this.menuLanguageSpanish, "menuLanguageSpanish");
            this.menuLanguageSpanish.Click += new System.EventHandler(this.menuLanguageSpanish_Click);
            // 
            // menuLanguageFrench
            // 
            this.menuLanguageFrench.CheckOnClick = true;
            this.menuLanguageFrench.Name = "menuLanguageFrench";
            resources.ApplyResources(this.menuLanguageFrench, "menuLanguageFrench");
            this.menuLanguageFrench.Click += new System.EventHandler(this.menuLanguageFrench_Click);
            // 
            // menuLanguageItalian
            // 
            this.menuLanguageItalian.Name = "menuLanguageItalian";
            resources.ApplyResources(this.menuLanguageItalian, "menuLanguageItalian");
            this.menuLanguageItalian.Click += new System.EventHandler(this.menuLanguageItalian_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // setWorkingDirectoryToolStripMenuItem
            // 
            this.setWorkingDirectoryToolStripMenuItem.Name = "setWorkingDirectoryToolStripMenuItem";
            resources.ApplyResources(this.setWorkingDirectoryToolStripMenuItem, "setWorkingDirectoryToolStripMenuItem");
            this.setWorkingDirectoryToolStripMenuItem.Click += new System.EventHandler(this.setWorkingDirectoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            // 
            // enterSimCoordsToolStripMenuItem
            // 
            this.enterSimCoordsToolStripMenuItem.Name = "enterSimCoordsToolStripMenuItem";
            resources.ApplyResources(this.enterSimCoordsToolStripMenuItem, "enterSimCoordsToolStripMenuItem");
            this.enterSimCoordsToolStripMenuItem.Click += new System.EventHandler(this.enterSimCoordsToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            // 
            // loadVehicleToolStripMenuItem
            // 
            this.loadVehicleToolStripMenuItem.Name = "loadVehicleToolStripMenuItem";
            resources.ApplyResources(this.loadVehicleToolStripMenuItem, "loadVehicleToolStripMenuItem");
            this.loadVehicleToolStripMenuItem.Click += new System.EventHandler(this.loadVehicleToolStripMenuItem_Click);
            // 
            // saveVehicleToolStripMenuItem
            // 
            this.saveVehicleToolStripMenuItem.Name = "saveVehicleToolStripMenuItem";
            resources.ApplyResources(this.saveVehicleToolStripMenuItem, "saveVehicleToolStripMenuItem");
            this.saveVehicleToolStripMenuItem.Click += new System.EventHandler(this.saveVehicleToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // fieldToolStripMenuItem
            // 
            this.fieldToolStripMenuItem.Name = "fieldToolStripMenuItem";
            resources.ApplyResources(this.fieldToolStripMenuItem, "fieldToolStripMenuItem");
            this.fieldToolStripMenuItem.Click += new System.EventHandler(this.fieldToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
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
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // resetALLToolStripMenuItem
            // 
            this.resetALLToolStripMenuItem.Name = "resetALLToolStripMenuItem";
            resources.ApplyResources(this.resetALLToolStripMenuItem, "resetALLToolStripMenuItem");
            this.resetALLToolStripMenuItem.Click += new System.EventHandler(this.resetALLToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sectionToolStripMenuItem,
            this.fieldToolStripMenuItem1});
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            resources.ApplyResources(this.colorsToolStripMenuItem, "colorsToolStripMenuItem");
            // 
            // sectionToolStripMenuItem
            // 
            this.sectionToolStripMenuItem.Name = "sectionToolStripMenuItem";
            resources.ApplyResources(this.sectionToolStripMenuItem, "sectionToolStripMenuItem");
            this.sectionToolStripMenuItem.Click += new System.EventHandler(this.sectionToolStripMenuItem_Click);
            // 
            // fieldToolStripMenuItem1
            // 
            this.fieldToolStripMenuItem1.Name = "fieldToolStripMenuItem1";
            resources.ApplyResources(this.fieldToolStripMenuItem1, "fieldToolStripMenuItem1");
            this.fieldToolStripMenuItem1.Click += new System.EventHandler(this.fieldToolStripMenuItem1_Click);
            // 
            // toolStripUnitsMenu
            // 
            this.toolStripUnitsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metricToolStrip,
            this.imperialToolStrip});
            this.toolStripUnitsMenu.Name = "toolStripUnitsMenu";
            resources.ApplyResources(this.toolStripUnitsMenu, "toolStripUnitsMenu");
            // 
            // metricToolStrip
            // 
            this.metricToolStrip.CheckOnClick = true;
            this.metricToolStrip.Name = "metricToolStrip";
            resources.ApplyResources(this.metricToolStrip, "metricToolStrip");
            this.metricToolStrip.Click += new System.EventHandler(this.metricToolStrip_Click);
            // 
            // imperialToolStrip
            // 
            this.imperialToolStrip.CheckOnClick = true;
            this.imperialToolStrip.Name = "imperialToolStrip";
            resources.ApplyResources(this.imperialToolStrip, "imperialToolStrip");
            this.imperialToolStrip.Click += new System.EventHandler(this.imperialToolStrip_Click);
            // 
            // sideGuideLines
            // 
            this.sideGuideLines.Checked = true;
            this.sideGuideLines.CheckOnClick = true;
            this.sideGuideLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sideGuideLines.Name = "sideGuideLines";
            resources.ApplyResources(this.sideGuideLines, "sideGuideLines");
            this.sideGuideLines.Click += new System.EventHandler(this.sideGuideLines_Click);
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            resources.ApplyResources(this.gridToolStripMenuItem, "gridToolStripMenuItem");
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
            // 
            // lightbarToolStripMenuItem
            // 
            this.lightbarToolStripMenuItem.Name = "lightbarToolStripMenuItem";
            resources.ApplyResources(this.lightbarToolStripMenuItem, "lightbarToolStripMenuItem");
            this.lightbarToolStripMenuItem.Click += new System.EventHandler(this.lightbarToolStripMenuItem_Click);
            // 
            // logNMEAMenuItem
            // 
            this.logNMEAMenuItem.Name = "logNMEAMenuItem";
            resources.ApplyResources(this.logNMEAMenuItem, "logNMEAMenuItem");
            this.logNMEAMenuItem.Click += new System.EventHandler(this.logNMEAMenuItem_Click);
            // 
            // polygonsToolStripMenuItem
            // 
            this.polygonsToolStripMenuItem.Checked = true;
            this.polygonsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.polygonsToolStripMenuItem.Name = "polygonsToolStripMenuItem";
            resources.ApplyResources(this.polygonsToolStripMenuItem, "polygonsToolStripMenuItem");
            this.polygonsToolStripMenuItem.Click += new System.EventHandler(this.polygonsToolStripMenuItem_Click);
            // 
            // pursuitLineToolStripMenuItem
            // 
            this.pursuitLineToolStripMenuItem.Checked = true;
            this.pursuitLineToolStripMenuItem.CheckOnClick = true;
            this.pursuitLineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pursuitLineToolStripMenuItem.Name = "pursuitLineToolStripMenuItem";
            resources.ApplyResources(this.pursuitLineToolStripMenuItem, "pursuitLineToolStripMenuItem");
            this.pursuitLineToolStripMenuItem.Click += new System.EventHandler(this.pursuitLineToolStripMenuItem_Click);
            // 
            // skyToolStripMenu
            // 
            this.skyToolStripMenu.Checked = true;
            this.skyToolStripMenu.CheckOnClick = true;
            this.skyToolStripMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skyToolStripMenu.Name = "skyToolStripMenu";
            resources.ApplyResources(this.skyToolStripMenu, "skyToolStripMenu");
            this.skyToolStripMenu.Click += new System.EventHandler(this.skyToolStripMenu_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // simulatorOnToolStripMenuItem
            // 
            this.simulatorOnToolStripMenuItem.Checked = true;
            this.simulatorOnToolStripMenuItem.CheckOnClick = true;
            this.simulatorOnToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.simulatorOnToolStripMenuItem.Name = "simulatorOnToolStripMenuItem";
            resources.ApplyResources(this.simulatorOnToolStripMenuItem, "simulatorOnToolStripMenuItem");
            this.simulatorOnToolStripMenuItem.Click += new System.EventHandler(this.simulatorOnToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // tmrWatchdog
            // 
            this.tmrWatchdog.Interval = 50;
            this.tmrWatchdog.Tick += new System.EventHandler(this.tmrWatchdog_tick);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripHz,
            this.btnHideTabs,
            this.stripEqWidth,
            this.toolStripDropDownButton2,
            this.stripAreaRate,
            this.toolStripDropDownBtnFuncs,
            this.stripDistance,
            this.toolStripZoomOut,
            this.toolStripZoomIn,
            this.stripPortGPS,
            this.stripOnlineGPS,
            this.stripPortArduino,
            this.stripOnlineArduino,
            this.stripPortAutoSteer,
            this.stripOnlineAutoSteer});
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // stripHz
            // 
            resources.ApplyResources(this.stripHz, "stripHz");
            this.stripHz.Margin = new System.Windows.Forms.Padding(0);
            this.stripHz.Name = "stripHz";
            // 
            // btnHideTabs
            // 
            resources.ApplyResources(this.btnHideTabs, "btnHideTabs");
            this.btnHideTabs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHideTabs.Name = "btnHideTabs";
            this.btnHideTabs.ShowDropDownArrow = false;
            this.btnHideTabs.Click += new System.EventHandler(this.btnHideTabs_Click);
            // 
            // stripDistance
            // 
            resources.ApplyResources(this.stripDistance, "stripDistance");
            this.stripDistance.Margin = new System.Windows.Forms.Padding(-4, 0, 0, 0);
            this.stripDistance.Name = "stripDistance";
            // 
            // toolStripDropDownButton2
            // 
            resources.ApplyResources(this.toolStripDropDownButton2, "toolStripDropDownButton2");
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripUDPConfig,
            this.toolstripUSBPortsConfig,
            this.toolstripDisplayConfig,
            this.toolstripVehicleConfig,
            this.toolstripAutoSteerConfig,
            this.toolstripYouTurnConfig});
            this.toolStripDropDownButton2.Image = global::AgOpenGPS.Properties.Resources.SetupStatusStrip;
            this.toolStripDropDownButton2.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.ShowDropDownArrow = false;
            // 
            // toolstripUDPConfig
            // 
            this.toolstripUDPConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripUDPConfig, "toolstripUDPConfig");
            this.toolstripUDPConfig.Name = "toolstripUDPConfig";
            this.toolstripUDPConfig.Click += new System.EventHandler(this.toolstripUDPConfig_Click);
            // 
            // toolstripUSBPortsConfig
            // 
            this.toolstripUSBPortsConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripUSBPortsConfig, "toolstripUSBPortsConfig");
            this.toolstripUSBPortsConfig.Name = "toolstripUSBPortsConfig";
            this.toolstripUSBPortsConfig.Click += new System.EventHandler(this.toolstripUSBPortsConfig_Click);
            // 
            // toolstripDisplayConfig
            // 
            this.toolstripDisplayConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripDisplayConfig, "toolstripDisplayConfig");
            this.toolstripDisplayConfig.Image = global::AgOpenGPS.Properties.Resources.gyro;
            this.toolstripDisplayConfig.Name = "toolstripDisplayConfig";
            this.toolstripDisplayConfig.Click += new System.EventHandler(this.toolstripDisplayConfig_Click);
            // 
            // toolstripVehicleConfig
            // 
            this.toolstripVehicleConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripVehicleConfig, "toolstripVehicleConfig");
            this.toolstripVehicleConfig.Name = "toolstripVehicleConfig";
            this.toolstripVehicleConfig.Click += new System.EventHandler(this.toolstripVehicleConfig_Click);
            // 
            // toolstripAutoSteerConfig
            // 
            this.toolstripAutoSteerConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripAutoSteerConfig, "toolstripAutoSteerConfig");
            this.toolstripAutoSteerConfig.Name = "toolstripAutoSteerConfig";
            this.toolstripAutoSteerConfig.Click += new System.EventHandler(this.toolstripAutoSteerConfig_Click);
            // 
            // toolstripYouTurnConfig
            // 
            this.toolstripYouTurnConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripYouTurnConfig, "toolstripYouTurnConfig");
            this.toolstripYouTurnConfig.Name = "toolstripYouTurnConfig";
            this.toolstripYouTurnConfig.Click += new System.EventHandler(this.toolstripYouTurnConfig_Click);
            // 
            // stripAreaRate
            // 
            resources.ApplyResources(this.stripAreaRate, "stripAreaRate");
            this.stripAreaRate.Margin = new System.Windows.Forms.Padding(0);
            this.stripAreaRate.Name = "stripAreaRate";
            // 
            // toolStripDropDownBtnFuncs
            // 
            resources.ApplyResources(this.toolStripDropDownBtnFuncs, "toolStripDropDownBtnFuncs");
            this.toolStripDropDownBtnFuncs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripField,
            this.toolstripBoundary,
            this.toolstripHeadland,
            this.toolstripResetTrip});
            this.toolStripDropDownBtnFuncs.Image = global::AgOpenGPS.Properties.Resources.start;
            this.toolStripDropDownBtnFuncs.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.toolStripDropDownBtnFuncs.Name = "toolStripDropDownBtnFuncs";
            this.toolStripDropDownBtnFuncs.ShowDropDownArrow = false;
            // 
            // toolstripField
            // 
            this.toolstripField.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripField, "toolstripField");
            this.toolstripField.Name = "toolstripField";
            this.toolstripField.Click += new System.EventHandler(this.toolstripField_Click);
            // 
            // toolstripBoundary
            // 
            this.toolstripBoundary.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripBoundary, "toolstripBoundary");
            this.toolstripBoundary.Name = "toolstripBoundary";
            this.toolstripBoundary.Click += new System.EventHandler(this.toolstripBoundary_Click);
            // 
            // toolstripHeadland
            // 
            this.toolstripHeadland.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripHeadland, "toolstripHeadland");
            this.toolstripHeadland.Name = "toolstripHeadland";
            this.toolstripHeadland.Click += new System.EventHandler(this.toolstripHeadland_Click);
            // 
            // toolstripResetTrip
            // 
            this.toolstripResetTrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripResetTrip, "toolstripResetTrip");
            this.toolstripResetTrip.Name = "toolstripResetTrip";
            this.toolstripResetTrip.Click += new System.EventHandler(this.toolstripResetTrip_Click_1);
            // 
            // stripEqWidth
            // 
            this.stripEqWidth.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.stripEqWidth, "stripEqWidth");
            this.stripEqWidth.Margin = new System.Windows.Forms.Padding(0);
            this.stripEqWidth.Name = "stripEqWidth";
            this.stripEqWidth.Spring = true;
            // 
            // toolStripZoomOut
            // 
            resources.ApplyResources(this.toolStripZoomOut, "toolStripZoomOut");
            this.toolStripZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripZoomOut.Image = global::AgOpenGPS.Properties.Resources.ZoomOut48;
            this.toolStripZoomOut.Name = "toolStripZoomOut";
            this.toolStripZoomOut.ShowDropDownArrow = false;
            this.toolStripZoomOut.Click += new System.EventHandler(this.toolStripZoomOut_Click);
            // 
            // toolStripZoomIn
            // 
            resources.ApplyResources(this.toolStripZoomIn, "toolStripZoomIn");
            this.toolStripZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripZoomIn.Image = global::AgOpenGPS.Properties.Resources.ZoomIn48;
            this.toolStripZoomIn.Name = "toolStripZoomIn";
            this.toolStripZoomIn.ShowDropDownArrow = false;
            this.toolStripZoomIn.Click += new System.EventHandler(this.toolStripZoomIn_Click);
            // 
            // stripPortGPS
            // 
            this.stripPortGPS.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            resources.ApplyResources(this.stripPortGPS, "stripPortGPS");
            this.stripPortGPS.ForeColor = System.Drawing.Color.Red;
            this.stripPortGPS.Name = "stripPortGPS";
            // 
            // stripOnlineGPS
            // 
            resources.ApplyResources(this.stripOnlineGPS, "stripOnlineGPS");
            this.stripOnlineGPS.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.stripOnlineGPS.Name = "stripOnlineGPS";
            this.stripOnlineGPS.Value = 1;
            // 
            // stripPortArduino
            // 
            resources.ApplyResources(this.stripPortArduino, "stripPortArduino");
            this.stripPortArduino.ForeColor = System.Drawing.Color.Red;
            this.stripPortArduino.Name = "stripPortArduino";
            // 
            // stripOnlineArduino
            // 
            this.stripOnlineArduino.AutoToolTip = true;
            this.stripOnlineArduino.ForeColor = System.Drawing.Color.Chartreuse;
            this.stripOnlineArduino.Name = "stripOnlineArduino";
            resources.ApplyResources(this.stripOnlineArduino, "stripOnlineArduino");
            this.stripOnlineArduino.Value = 1;
            // 
            // stripPortAutoSteer
            // 
            resources.ApplyResources(this.stripPortAutoSteer, "stripPortAutoSteer");
            this.stripPortAutoSteer.ForeColor = System.Drawing.Color.Red;
            this.stripPortAutoSteer.Name = "stripPortAutoSteer";
            // 
            // stripOnlineAutoSteer
            // 
            this.stripOnlineAutoSteer.AutoToolTip = true;
            this.stripOnlineAutoSteer.ForeColor = System.Drawing.Color.Chartreuse;
            this.stripOnlineAutoSteer.Name = "stripOnlineAutoSteer";
            resources.ApplyResources(this.stripOnlineAutoSteer, "stripOnlineAutoSteer");
            this.stripOnlineAutoSteer.Value = 1;
            // 
            // lblNorthing
            // 
            resources.ApplyResources(this.lblNorthing, "lblNorthing");
            this.lblNorthing.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblNorthing.Name = "lblNorthing";
            // 
            // lblEasting
            // 
            resources.ApplyResources(this.lblEasting, "lblEasting");
            this.lblEasting.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblEasting.Name = "lblEasting";
            // 
            // lblSpeed
            // 
            resources.ApplyResources(this.lblSpeed, "lblSpeed");
            this.lblSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeed.Name = "lblSpeed";
            // 
            // contextMenuStripFlag
            // 
            resources.ApplyResources(this.contextMenuStripFlag, "contextMenuStripFlag");
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
            this.contextMenuStripFlag.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripFlag_Opening);
            // 
            // toolStripMenuItemFlagRed
            // 
            resources.ApplyResources(this.toolStripMenuItemFlagRed, "toolStripMenuItemFlagRed");
            this.toolStripMenuItemFlagRed.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuItemFlagRed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItemFlagRed.Name = "toolStripMenuItemFlagRed";
            this.toolStripMenuItemFlagRed.Click += new System.EventHandler(this.toolStripMenuItemFlagRed_Click);
            // 
            // toolStripMenuFlagGrn
            // 
            resources.ApplyResources(this.toolStripMenuFlagGrn, "toolStripMenuFlagGrn");
            this.toolStripMenuFlagGrn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuFlagGrn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuFlagGrn.Name = "toolStripMenuFlagGrn";
            this.toolStripMenuFlagGrn.Click += new System.EventHandler(this.toolStripMenuGrn_Click);
            // 
            // toolStripMenuFlagYel
            // 
            resources.ApplyResources(this.toolStripMenuFlagYel, "toolStripMenuFlagYel");
            this.toolStripMenuFlagYel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuFlagYel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuFlagYel.Name = "toolStripMenuFlagYel";
            this.toolStripMenuFlagYel.Click += new System.EventHandler(this.toolStripMenuYel_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // toolStripMenuFlagDelete
            // 
            resources.ApplyResources(this.toolStripMenuFlagDelete, "toolStripMenuFlagDelete");
            this.toolStripMenuFlagDelete.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuFlagDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuFlagDelete.Name = "toolStripMenuFlagDelete";
            this.toolStripMenuFlagDelete.Click += new System.EventHandler(this.toolStripMenuFlagDelete_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // toolStripMenuFlagDeleteAll
            // 
            resources.ApplyResources(this.toolStripMenuFlagDeleteAll, "toolStripMenuFlagDeleteAll");
            this.toolStripMenuFlagDeleteAll.Name = "toolStripMenuFlagDeleteAll";
            this.toolStripMenuFlagDeleteAll.Click += new System.EventHandler(this.toolStripMenuFlagDeleteAll_Click);
            // 
            // contextMenuArea
            // 
            resources.ApplyResources(this.contextMenuArea, "contextMenuArea");
            this.contextMenuArea.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuAreaSide});
            this.contextMenuArea.Name = "contextMenuArea";
            // 
            // toolStripMenuAreaSide
            // 
            resources.ApplyResources(this.toolStripMenuAreaSide, "toolStripMenuAreaSide");
            this.toolStripMenuAreaSide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuAreaSide.Name = "toolStripMenuAreaSide";
            this.toolStripMenuAreaSide.Click += new System.EventHandler(this.toolStripMenuAreaSide_Click);
            // 
            // tboxSentence
            // 
            resources.ApplyResources(this.tboxSentence, "tboxSentence");
            this.tboxSentence.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tboxSentence.Name = "tboxSentence";
            this.tboxSentence.ReadOnly = true;
            // 
            // lblZone
            // 
            resources.ApplyResources(this.lblZone, "lblZone");
            this.lblZone.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblZone.Name = "lblZone";
            // 
            // lblSpeedUnits
            // 
            resources.ApplyResources(this.lblSpeedUnits, "lblSpeedUnits");
            this.lblSpeedUnits.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblSpeedUnits.Name = "lblSpeedUnits";
            // 
            // lblHeading
            // 
            resources.ApplyResources(this.lblHeading, "lblHeading");
            this.lblHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblHeading.Name = "lblHeading";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "SettingsGear64.png");
            this.imageList1.Images.SetKeyName(1, "Satellite64.png");
            this.imageList1.Images.SetKeyName(2, "Rate64.png");
            this.imageList1.Images.SetKeyName(3, "FieldView.png");
            // 
            // openGLControlZoom
            // 
            this.openGLControlZoom.DrawFPS = false;
            resources.ApplyResources(this.openGLControlZoom, "openGLControlZoom");
            this.openGLControlZoom.Name = "openGLControlZoom";
            this.openGLControlZoom.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControlZoom.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLControlZoom.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.openGLControlZoom.OpenGLInitialized += new System.EventHandler(this.openGLControlZoom_OpenGLInitialized);
            this.openGLControlZoom.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControlZoom_OpenGLDraw);
            this.openGLControlZoom.Resized += new System.EventHandler(this.openGLControlZoom_Resized);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Name = "label4";
            // 
            // lblFieldWidthNorthSouth
            // 
            resources.ApplyResources(this.lblFieldWidthNorthSouth, "lblFieldWidthNorthSouth");
            this.lblFieldWidthNorthSouth.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblFieldWidthNorthSouth.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFieldWidthNorthSouth.Name = "lblFieldWidthNorthSouth";
            // 
            // lblFieldWidthEastWest
            // 
            resources.ApplyResources(this.lblFieldWidthEastWest, "lblFieldWidthEastWest");
            this.lblFieldWidthEastWest.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblFieldWidthEastWest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFieldWidthEastWest.Name = "lblFieldWidthEastWest";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.DataPage);
            this.tabControl1.Controls.Add(this.zoomPage2);
            this.tabControl1.Controls.Add(this.rate2Page5);
            this.tabControl1.Controls.Add(this.configPage1);
            this.tabControl1.Controls.Add(this.autoPage4);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            // 
            // DataPage
            // 
            this.DataPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DataPage.Controls.Add(this.lblFixOffset);
            this.DataPage.Controls.Add(this.label2);
            this.DataPage.Controls.Add(this.lblHeading2);
            this.DataPage.Controls.Add(this.lblFixQuality);
            this.DataPage.Controls.Add(this.lblAltitude);
            this.DataPage.Controls.Add(this.btnZoomOut);
            this.DataPage.Controls.Add(this.btnZoomIn);
            this.DataPage.Controls.Add(this.lblLongitude);
            this.DataPage.Controls.Add(this.lblLatitude);
            this.DataPage.Controls.Add(this.lblHeadlandDistanceFromTool);
            this.DataPage.Controls.Add(this.lblHeadlandDistanceAway);
            this.DataPage.Controls.Add(this.lblBoundaryArea);
            this.DataPage.Controls.Add(this.lblRoll);
            this.DataPage.Controls.Add(this.lblGPSHeading);
            this.DataPage.Controls.Add(this.lblYawHeading);
            this.DataPage.Controls.Add(this.lblEasting);
            this.DataPage.Controls.Add(this.lblNorthing);
            this.DataPage.Controls.Add(this.label26);
            this.DataPage.Controls.Add(this.label25);
            this.DataPage.Controls.Add(this.label24);
            this.DataPage.Controls.Add(this.btnTiltUp);
            this.DataPage.Controls.Add(this.btnTiltDown);
            this.DataPage.Controls.Add(this.label22);
            this.DataPage.Controls.Add(this.label13);
            this.DataPage.Controls.Add(this.label20);
            this.DataPage.Controls.Add(this.txtBoxSendAutoSteer);
            this.DataPage.Controls.Add(this.txtBoxRecvAutoSteer);
            this.DataPage.Controls.Add(this.lblSats);
            this.DataPage.Controls.Add(this.label17);
            this.DataPage.Controls.Add(this.label16);
            this.DataPage.Controls.Add(this.label19);
            this.DataPage.Controls.Add(this.label18);
            this.DataPage.Controls.Add(this.label15);
            this.DataPage.Controls.Add(this.label14);
            this.DataPage.Controls.Add(this.label7);
            this.DataPage.Controls.Add(this.tboxSentence);
            this.DataPage.Controls.Add(this.label10);
            this.DataPage.Controls.Add(this.label9);
            this.DataPage.Controls.Add(this.label8);
            this.DataPage.Controls.Add(this.lblZone);
            this.DataPage.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.DataPage, "DataPage");
            this.DataPage.Name = "DataPage";
            // 
            // lblFixOffset
            // 
            resources.ApplyResources(this.lblFixOffset, "lblFixOffset");
            this.lblFixOffset.Name = "lblFixOffset";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblHeading2
            // 
            resources.ApplyResources(this.lblHeading2, "lblHeading2");
            this.lblHeading2.Name = "lblHeading2";
            // 
            // lblFixQuality
            // 
            resources.ApplyResources(this.lblFixQuality, "lblFixQuality");
            this.lblFixQuality.Name = "lblFixQuality";
            // 
            // lblAltitude
            // 
            resources.ApplyResources(this.lblAltitude, "lblAltitude");
            this.lblAltitude.Name = "lblAltitude";
            // 
            // btnZoomOut
            // 
            resources.ApplyResources(this.btnZoomOut, "btnZoomOut");
            this.btnZoomOut.BackColor = System.Drawing.Color.Lavender;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZoomOut_MouseDown);
            // 
            // btnZoomIn
            // 
            resources.ApplyResources(this.btnZoomIn, "btnZoomIn");
            this.btnZoomIn.BackColor = System.Drawing.Color.Lavender;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZoomIn_MouseDown);
            // 
            // lblLongitude
            // 
            resources.ApplyResources(this.lblLongitude, "lblLongitude");
            this.lblLongitude.Name = "lblLongitude";
            // 
            // lblLatitude
            // 
            resources.ApplyResources(this.lblLatitude, "lblLatitude");
            this.lblLatitude.Name = "lblLatitude";
            // 
            // lblHeadlandDistanceFromTool
            // 
            resources.ApplyResources(this.lblHeadlandDistanceFromTool, "lblHeadlandDistanceFromTool");
            this.lblHeadlandDistanceFromTool.Name = "lblHeadlandDistanceFromTool";
            // 
            // lblHeadlandDistanceAway
            // 
            resources.ApplyResources(this.lblHeadlandDistanceAway, "lblHeadlandDistanceAway");
            this.lblHeadlandDistanceAway.Name = "lblHeadlandDistanceAway";
            // 
            // lblBoundaryArea
            // 
            resources.ApplyResources(this.lblBoundaryArea, "lblBoundaryArea");
            this.lblBoundaryArea.Name = "lblBoundaryArea";
            // 
            // lblRoll
            // 
            resources.ApplyResources(this.lblRoll, "lblRoll");
            this.lblRoll.Name = "lblRoll";
            // 
            // lblGPSHeading
            // 
            resources.ApplyResources(this.lblGPSHeading, "lblGPSHeading");
            this.lblGPSHeading.Name = "lblGPSHeading";
            // 
            // lblYawHeading
            // 
            resources.ApplyResources(this.lblYawHeading, "lblYawHeading");
            this.lblYawHeading.Name = "lblYawHeading";
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // btnTiltUp
            // 
            resources.ApplyResources(this.btnTiltUp, "btnTiltUp");
            this.btnTiltUp.BackColor = System.Drawing.Color.Lavender;
            this.btnTiltUp.Name = "btnTiltUp";
            this.btnTiltUp.UseVisualStyleBackColor = false;
            this.btnTiltUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTiltUp_MouseDown);
            // 
            // btnTiltDown
            // 
            resources.ApplyResources(this.btnTiltDown, "btnTiltDown");
            this.btnTiltDown.BackColor = System.Drawing.Color.Lavender;
            this.btnTiltDown.Name = "btnTiltDown";
            this.btnTiltDown.UseVisualStyleBackColor = false;
            this.btnTiltDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTiltDown_MouseDown);
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // txtBoxSendAutoSteer
            // 
            this.txtBoxSendAutoSteer.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.txtBoxSendAutoSteer, "txtBoxSendAutoSteer");
            this.txtBoxSendAutoSteer.Name = "txtBoxSendAutoSteer";
            this.txtBoxSendAutoSteer.ReadOnly = true;
            // 
            // txtBoxRecvAutoSteer
            // 
            this.txtBoxRecvAutoSteer.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.txtBoxRecvAutoSteer, "txtBoxRecvAutoSteer");
            this.txtBoxRecvAutoSteer.Name = "txtBoxRecvAutoSteer";
            this.txtBoxRecvAutoSteer.ReadOnly = true;
            // 
            // lblSats
            // 
            resources.ApplyResources(this.lblSats, "lblSats");
            this.lblSats.Name = "lblSats";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // zoomPage2
            // 
            this.zoomPage2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.zoomPage2.Controls.Add(this.btnMakeContourFromBoundary);
            this.zoomPage2.Controls.Add(this.openGLControlZoom);
            this.zoomPage2.Controls.Add(this.label6);
            this.zoomPage2.Controls.Add(this.lblZooom);
            this.zoomPage2.Controls.Add(this.label5);
            this.zoomPage2.Controls.Add(this.label4);
            this.zoomPage2.Controls.Add(this.lblFieldWidthEastWest);
            this.zoomPage2.Controls.Add(this.lblFieldWidthNorthSouth);
            this.zoomPage2.Controls.Add(this.btnDeleteAllData);
            this.zoomPage2.Controls.Add(this.btnPerimeter);
            resources.ApplyResources(this.zoomPage2, "zoomPage2");
            this.zoomPage2.Name = "zoomPage2";
            // 
            // btnMakeContourFromBoundary
            // 
            this.btnMakeContourFromBoundary.BackColor = System.Drawing.Color.AliceBlue;
            this.btnMakeContourFromBoundary.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnMakeContourFromBoundary, "btnMakeContourFromBoundary");
            this.btnMakeContourFromBoundary.Name = "btnMakeContourFromBoundary";
            this.btnMakeContourFromBoundary.UseVisualStyleBackColor = false;
            this.btnMakeContourFromBoundary.Click += new System.EventHandler(this.btnMakeContourFromBoundary_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Name = "label6";
            // 
            // lblZooom
            // 
            resources.ApplyResources(this.lblZooom, "lblZooom");
            this.lblZooom.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblZooom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblZooom.Name = "lblZooom";
            // 
            // btnDeleteAllData
            // 
            this.btnDeleteAllData.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteAllData.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnDeleteAllData, "btnDeleteAllData");
            this.btnDeleteAllData.Name = "btnDeleteAllData";
            this.btnDeleteAllData.UseVisualStyleBackColor = false;
            this.btnDeleteAllData.Click += new System.EventHandler(this.btnDeleteAllData_Click);
            // 
            // btnPerimeter
            // 
            this.btnPerimeter.BackColor = System.Drawing.Color.AliceBlue;
            this.btnPerimeter.ContextMenuStrip = this.contextMenuArea;
            resources.ApplyResources(this.btnPerimeter, "btnPerimeter");
            this.btnPerimeter.Name = "btnPerimeter";
            this.btnPerimeter.UseVisualStyleBackColor = false;
            this.btnPerimeter.Click += new System.EventHandler(this.btnPerimeter_Click);
            // 
            // rate2Page5
            // 
            this.rate2Page5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.rate2Page5.Controls.Add(this.label30);
            this.rate2Page5.Controls.Add(this.btnSelectSingleDualMeter);
            this.rate2Page5.Controls.Add(this.btnSelectRate2);
            this.rate2Page5.Controls.Add(this.btnSelectRate1);
            this.rate2Page5.Controls.Add(this.label21);
            this.rate2Page5.Controls.Add(this.txtBoxSendArduino);
            this.rate2Page5.Controls.Add(this.txtBoxRecvArduino);
            this.rate2Page5.Controls.Add(this.label23);
            this.rate2Page5.Controls.Add(this.lblFlowRateRight);
            this.rate2Page5.Controls.Add(this.lblFlowRateLeft);
            this.rate2Page5.Controls.Add(this.btnRateRightDn);
            this.rate2Page5.Controls.Add(this.btnRateRightUp);
            this.rate2Page5.Controls.Add(this.lblRateSetpointRight);
            this.rate2Page5.Controls.Add(this.lblFlowRight);
            this.rate2Page5.Controls.Add(this.lblRateAppliedActualLeft);
            this.rate2Page5.Controls.Add(this.btnDualRateConfig);
            this.rate2Page5.Controls.Add(this.btnRateLeftDn);
            this.rate2Page5.Controls.Add(this.label28);
            this.rate2Page5.Controls.Add(this.lblFlowLeft);
            this.rate2Page5.Controls.Add(this.lblRateAppliedActualRight);
            this.rate2Page5.Controls.Add(this.lblDualAccumulatedVolume);
            this.rate2Page5.Controls.Add(this.btnRateLeftUp);
            this.rate2Page5.Controls.Add(this.btnDualRate);
            this.rate2Page5.Controls.Add(this.lblRateSetpointLeft);
            resources.ApplyResources(this.rate2Page5, "rate2Page5");
            this.rate2Page5.Name = "rate2Page5";
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // btnSelectSingleDualMeter
            // 
            resources.ApplyResources(this.btnSelectSingleDualMeter, "btnSelectSingleDualMeter");
            this.btnSelectSingleDualMeter.Image = global::AgOpenGPS.Properties.Resources.FlowMeterSingle;
            this.btnSelectSingleDualMeter.Name = "btnSelectSingleDualMeter";
            this.btnSelectSingleDualMeter.UseVisualStyleBackColor = true;
            this.btnSelectSingleDualMeter.Click += new System.EventHandler(this.btnSelectSingleDualMeter_Click);
            // 
            // btnSelectRate2
            // 
            this.btnSelectRate2.BackColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.btnSelectRate2, "btnSelectRate2");
            this.btnSelectRate2.Image = global::AgOpenGPS.Properties.Resources.RateSelect2;
            this.btnSelectRate2.Name = "btnSelectRate2";
            this.btnSelectRate2.UseVisualStyleBackColor = false;
            this.btnSelectRate2.Click += new System.EventHandler(this.btnSelectRate2_Click);
            // 
            // btnSelectRate1
            // 
            this.btnSelectRate1.BackColor = System.Drawing.Color.LightSkyBlue;
            resources.ApplyResources(this.btnSelectRate1, "btnSelectRate1");
            this.btnSelectRate1.Image = global::AgOpenGPS.Properties.Resources.Rate1Select;
            this.btnSelectRate1.Name = "btnSelectRate1";
            this.btnSelectRate1.UseVisualStyleBackColor = false;
            this.btnSelectRate1.Click += new System.EventHandler(this.btnSelectRate1_Click);
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // txtBoxSendArduino
            // 
            this.txtBoxSendArduino.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.txtBoxSendArduino, "txtBoxSendArduino");
            this.txtBoxSendArduino.Name = "txtBoxSendArduino";
            this.txtBoxSendArduino.ReadOnly = true;
            // 
            // txtBoxRecvArduino
            // 
            this.txtBoxRecvArduino.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.txtBoxRecvArduino, "txtBoxRecvArduino");
            this.txtBoxRecvArduino.Name = "txtBoxRecvArduino";
            this.txtBoxRecvArduino.ReadOnly = true;
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // lblFlowRateRight
            // 
            resources.ApplyResources(this.lblFlowRateRight, "lblFlowRateRight");
            this.lblFlowRateRight.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblFlowRateRight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFlowRateRight.Name = "lblFlowRateRight";
            // 
            // lblFlowRateLeft
            // 
            resources.ApplyResources(this.lblFlowRateLeft, "lblFlowRateLeft");
            this.lblFlowRateLeft.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblFlowRateLeft.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFlowRateLeft.Name = "lblFlowRateLeft";
            // 
            // btnRateRightDn
            // 
            resources.ApplyResources(this.btnRateRightDn, "btnRateRightDn");
            this.btnRateRightDn.Name = "btnRateRightDn";
            this.btnRateRightDn.UseVisualStyleBackColor = true;
            this.btnRateRightDn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRateRightDn_MouseDown);
            // 
            // btnRateRightUp
            // 
            resources.ApplyResources(this.btnRateRightUp, "btnRateRightUp");
            this.btnRateRightUp.Name = "btnRateRightUp";
            this.btnRateRightUp.UseVisualStyleBackColor = true;
            this.btnRateRightUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRateRightUp_MouseDown);
            // 
            // lblRateSetpointRight
            // 
            resources.ApplyResources(this.lblRateSetpointRight, "lblRateSetpointRight");
            this.lblRateSetpointRight.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblRateSetpointRight.ForeColor = System.Drawing.Color.DarkRed;
            this.lblRateSetpointRight.Name = "lblRateSetpointRight";
            // 
            // lblFlowRight
            // 
            resources.ApplyResources(this.lblFlowRight, "lblFlowRight");
            this.lblFlowRight.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblFlowRight.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFlowRight.Name = "lblFlowRight";
            // 
            // lblRateAppliedActualLeft
            // 
            resources.ApplyResources(this.lblRateAppliedActualLeft, "lblRateAppliedActualLeft");
            this.lblRateAppliedActualLeft.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblRateAppliedActualLeft.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblRateAppliedActualLeft.Name = "lblRateAppliedActualLeft";
            // 
            // btnDualRateConfig
            // 
            this.btnDualRateConfig.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnDualRateConfig, "btnDualRateConfig");
            this.btnDualRateConfig.Image = global::AgOpenGPS.Properties.Resources.Settings48;
            this.btnDualRateConfig.Name = "btnDualRateConfig";
            this.btnDualRateConfig.UseVisualStyleBackColor = false;
            this.btnDualRateConfig.Click += new System.EventHandler(this.btnDualRateConfig_Click);
            // 
            // btnRateLeftDn
            // 
            resources.ApplyResources(this.btnRateLeftDn, "btnRateLeftDn");
            this.btnRateLeftDn.Name = "btnRateLeftDn";
            this.btnRateLeftDn.UseVisualStyleBackColor = true;
            this.btnRateLeftDn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRateLeftDn_MouseDown);
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label28.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label28.Name = "label28";
            // 
            // lblFlowLeft
            // 
            resources.ApplyResources(this.lblFlowLeft, "lblFlowLeft");
            this.lblFlowLeft.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblFlowLeft.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblFlowLeft.Name = "lblFlowLeft";
            // 
            // lblRateAppliedActualRight
            // 
            resources.ApplyResources(this.lblRateAppliedActualRight, "lblRateAppliedActualRight");
            this.lblRateAppliedActualRight.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblRateAppliedActualRight.ForeColor = System.Drawing.Color.DarkRed;
            this.lblRateAppliedActualRight.Name = "lblRateAppliedActualRight";
            // 
            // lblDualAccumulatedVolume
            // 
            resources.ApplyResources(this.lblDualAccumulatedVolume, "lblDualAccumulatedVolume");
            this.lblDualAccumulatedVolume.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblDualAccumulatedVolume.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDualAccumulatedVolume.Name = "lblDualAccumulatedVolume";
            // 
            // btnRateLeftUp
            // 
            resources.ApplyResources(this.btnRateLeftUp, "btnRateLeftUp");
            this.btnRateLeftUp.Name = "btnRateLeftUp";
            this.btnRateLeftUp.UseVisualStyleBackColor = true;
            this.btnRateLeftUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRateLeftUp_MouseDown);
            // 
            // btnDualRate
            // 
            this.btnDualRate.BackColor = System.Drawing.Color.AliceBlue;
            this.btnDualRate.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnDualRate, "btnDualRate");
            this.btnDualRate.Name = "btnDualRate";
            this.btnDualRate.UseVisualStyleBackColor = false;
            this.btnDualRate.Click += new System.EventHandler(this.btnDualRate_Click);
            // 
            // lblRateSetpointLeft
            // 
            resources.ApplyResources(this.lblRateSetpointLeft, "lblRateSetpointLeft");
            this.lblRateSetpointLeft.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblRateSetpointLeft.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblRateSetpointLeft.Name = "lblRateSetpointLeft";
            // 
            // configPage1
            // 
            this.configPage1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.configPage1.Controls.Add(this.btnFixOffset);
            this.configPage1.Controls.Add(this.btnSmoothAB);
            this.configPage1.Controls.Add(this.btnFlagsGoogleEarth);
            this.configPage1.Controls.Add(this.btnWebCam);
            this.configPage1.Controls.Add(this.btnHelp);
            this.configPage1.Controls.Add(this.btnFileExplorer);
            this.configPage1.Controls.Add(this.btnGPSData);
            resources.ApplyResources(this.configPage1, "configPage1");
            this.configPage1.Name = "configPage1";
            // 
            // btnFixOffset
            // 
            this.btnFixOffset.BackColor = System.Drawing.Color.AliceBlue;
            this.btnFixOffset.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnFixOffset, "btnFixOffset");
            this.btnFixOffset.Name = "btnFixOffset";
            this.btnFixOffset.UseVisualStyleBackColor = false;
            this.btnFixOffset.Click += new System.EventHandler(this.btnFixOffset_Click);
            // 
            // btnSmoothAB
            // 
            this.btnSmoothAB.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSmoothAB.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnSmoothAB, "btnSmoothAB");
            this.btnSmoothAB.Name = "btnSmoothAB";
            this.btnSmoothAB.UseVisualStyleBackColor = false;
            this.btnSmoothAB.Click += new System.EventHandler(this.btnSmoothAB_Click);
            // 
            // btnFlagsGoogleEarth
            // 
            this.btnFlagsGoogleEarth.BackColor = System.Drawing.Color.AliceBlue;
            this.btnFlagsGoogleEarth.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnFlagsGoogleEarth, "btnFlagsGoogleEarth");
            this.btnFlagsGoogleEarth.Name = "btnFlagsGoogleEarth";
            this.btnFlagsGoogleEarth.UseVisualStyleBackColor = false;
            this.btnFlagsGoogleEarth.Click += new System.EventHandler(this.btnFlagsGoogleEarth_Click);
            // 
            // btnWebCam
            // 
            this.btnWebCam.BackColor = System.Drawing.Color.AliceBlue;
            this.btnWebCam.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnWebCam, "btnWebCam");
            this.btnWebCam.Name = "btnWebCam";
            this.btnWebCam.UseVisualStyleBackColor = false;
            this.btnWebCam.Click += new System.EventHandler(this.btnWebCam_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.AliceBlue;
            this.btnHelp.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnHelp, "btnHelp");
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnFileExplorer
            // 
            this.btnFileExplorer.BackColor = System.Drawing.Color.AliceBlue;
            this.btnFileExplorer.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnFileExplorer, "btnFileExplorer");
            this.btnFileExplorer.Name = "btnFileExplorer";
            this.btnFileExplorer.UseVisualStyleBackColor = false;
            this.btnFileExplorer.Click += new System.EventHandler(this.btnFileExplorer_Click);
            // 
            // btnGPSData
            // 
            this.btnGPSData.BackColor = System.Drawing.Color.AliceBlue;
            this.btnGPSData.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnGPSData, "btnGPSData");
            this.btnGPSData.Name = "btnGPSData";
            this.btnGPSData.UseVisualStyleBackColor = false;
            this.btnGPSData.Click += new System.EventHandler(this.btnGPSData_Click);
            // 
            // autoPage4
            // 
            this.autoPage4.Controls.Add(this.btnOffsetOutward);
            this.autoPage4.Controls.Add(this.btnOffsetInward);
            this.autoPage4.Controls.Add(this.btnOffsetBackward);
            this.autoPage4.Controls.Add(this.btnOffsetForward);
            this.autoPage4.Controls.Add(this.btnCartOnOff);
            this.autoPage4.Controls.Add(this.btnCartDone);
            this.autoPage4.Controls.Add(this.btnCallCart);
            this.autoPage4.Controls.Add(this.btnRecPathPauseRecord);
            resources.ApplyResources(this.autoPage4, "autoPage4");
            this.autoPage4.Name = "autoPage4";
            this.autoPage4.UseVisualStyleBackColor = true;
            // 
            // btnOffsetOutward
            // 
            this.btnOffsetOutward.BackColor = System.Drawing.Color.AliceBlue;
            this.btnOffsetOutward.BackgroundImage = global::AgOpenGPS.Properties.Resources.ArrowLeft;
            resources.ApplyResources(this.btnOffsetOutward, "btnOffsetOutward");
            this.btnOffsetOutward.Name = "btnOffsetOutward";
            this.btnOffsetOutward.UseVisualStyleBackColor = false;
            this.btnOffsetOutward.Click += new System.EventHandler(this.btnOffsetOutward_Click);
            // 
            // btnOffsetInward
            // 
            this.btnOffsetInward.BackColor = System.Drawing.Color.AliceBlue;
            this.btnOffsetInward.BackgroundImage = global::AgOpenGPS.Properties.Resources.ArrowRight;
            resources.ApplyResources(this.btnOffsetInward, "btnOffsetInward");
            this.btnOffsetInward.Name = "btnOffsetInward";
            this.btnOffsetInward.UseVisualStyleBackColor = false;
            this.btnOffsetInward.Click += new System.EventHandler(this.btnOffsetInward_Click);
            // 
            // btnOffsetBackward
            // 
            this.btnOffsetBackward.BackColor = System.Drawing.Color.AliceBlue;
            this.btnOffsetBackward.BackgroundImage = global::AgOpenGPS.Properties.Resources.DnArrow64;
            resources.ApplyResources(this.btnOffsetBackward, "btnOffsetBackward");
            this.btnOffsetBackward.Name = "btnOffsetBackward";
            this.btnOffsetBackward.UseVisualStyleBackColor = false;
            this.btnOffsetBackward.Click += new System.EventHandler(this.btnOffsetBackward_Click);
            // 
            // btnOffsetForward
            // 
            this.btnOffsetForward.BackColor = System.Drawing.Color.AliceBlue;
            this.btnOffsetForward.BackgroundImage = global::AgOpenGPS.Properties.Resources.UpArrow64;
            resources.ApplyResources(this.btnOffsetForward, "btnOffsetForward");
            this.btnOffsetForward.Name = "btnOffsetForward";
            this.btnOffsetForward.UseVisualStyleBackColor = false;
            this.btnOffsetForward.Click += new System.EventHandler(this.btnOffsetForward_Click);
            // 
            // btnCartOnOff
            // 
            this.btnCartOnOff.BackColor = System.Drawing.Color.AliceBlue;
            resources.ApplyResources(this.btnCartOnOff, "btnCartOnOff");
            this.btnCartOnOff.Image = global::AgOpenGPS.Properties.Resources.FlagRed;
            this.btnCartOnOff.Name = "btnCartOnOff";
            this.btnCartOnOff.UseVisualStyleBackColor = false;
            this.btnCartOnOff.Click += new System.EventHandler(this.btnCartOnOff_Click);
            // 
            // btnCartDone
            // 
            this.btnCartDone.BackColor = System.Drawing.Color.AliceBlue;
            resources.ApplyResources(this.btnCartDone, "btnCartDone");
            this.btnCartDone.Image = global::AgOpenGPS.Properties.Resources.back_button;
            this.btnCartDone.Name = "btnCartDone";
            this.btnCartDone.UseVisualStyleBackColor = false;
            this.btnCartDone.Click += new System.EventHandler(this.btnCartDone_Click);
            // 
            // btnCallCart
            // 
            this.btnCallCart.BackColor = System.Drawing.Color.AliceBlue;
            resources.ApplyResources(this.btnCallCart, "btnCallCart");
            this.btnCallCart.Image = global::AgOpenGPS.Properties.Resources.boundaryPlay;
            this.btnCallCart.Name = "btnCallCart";
            this.btnCallCart.UseVisualStyleBackColor = false;
            this.btnCallCart.Click += new System.EventHandler(this.btnCallCart_Click);
            // 
            // btnRecPathPauseRecord
            // 
            this.btnRecPathPauseRecord.BackColor = System.Drawing.Color.AliceBlue;
            resources.ApplyResources(this.btnRecPathPauseRecord, "btnRecPathPauseRecord");
            this.btnRecPathPauseRecord.Image = global::AgOpenGPS.Properties.Resources.boundaryPause;
            this.btnRecPathPauseRecord.Name = "btnRecPathPauseRecord";
            this.btnRecPathPauseRecord.UseVisualStyleBackColor = false;
            this.btnRecPathPauseRecord.Click += new System.EventHandler(this.btnRecPathPauseRecord_Click);
            // 
            // btnResetSim
            // 
            resources.ApplyResources(this.btnResetSim, "btnResetSim");
            this.btnResetSim.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnResetSim.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnResetSim.Name = "btnResetSim";
            this.btnResetSim.UseVisualStyleBackColor = false;
            this.btnResetSim.Click += new System.EventHandler(this.btnResetSim_Click);
            // 
            // btnResetSteerAngle
            // 
            resources.ApplyResources(this.btnResetSteerAngle, "btnResetSteerAngle");
            this.btnResetSteerAngle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnResetSteerAngle.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnResetSteerAngle.Name = "btnResetSteerAngle";
            this.btnResetSteerAngle.UseVisualStyleBackColor = false;
            this.btnResetSteerAngle.Click += new System.EventHandler(this.btnResetSteerAngle_Click);
            // 
            // lblPureSteerAngle
            // 
            resources.ApplyResources(this.lblPureSteerAngle, "lblPureSteerAngle");
            this.lblPureSteerAngle.BackColor = System.Drawing.Color.Transparent;
            this.lblPureSteerAngle.Name = "lblPureSteerAngle";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // lblSteerAngle
            // 
            resources.ApplyResources(this.lblSteerAngle, "lblSteerAngle");
            this.lblSteerAngle.Name = "lblSteerAngle";
            // 
            // tbarSteerAngle
            // 
            resources.ApplyResources(this.tbarSteerAngle, "tbarSteerAngle");
            this.tbarSteerAngle.LargeChange = 10;
            this.tbarSteerAngle.Maximum = 300;
            this.tbarSteerAngle.Minimum = -300;
            this.tbarSteerAngle.Name = "tbarSteerAngle";
            this.tbarSteerAngle.TickFrequency = 30;
            this.tbarSteerAngle.Scroll += new System.EventHandler(this.tbarSteerAngle_Scroll);
            // 
            // tbarStepDistance
            // 
            resources.ApplyResources(this.tbarStepDistance, "tbarStepDistance");
            this.tbarStepDistance.LargeChange = 10;
            this.tbarStepDistance.Maximum = 300;
            this.tbarStepDistance.Name = "tbarStepDistance";
            this.tbarStepDistance.TickFrequency = 10;
            this.tbarStepDistance.Value = 20;
            this.tbarStepDistance.Scroll += new System.EventHandler(this.tbarStepDistance_Scroll);
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
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // panelSimControls
            // 
            resources.ApplyResources(this.panelSimControls, "panelSimControls");
            this.panelSimControls.Controls.Add(this.btnResetSteerAngle);
            this.panelSimControls.Controls.Add(this.label3);
            this.panelSimControls.Controls.Add(this.btnResetSim);
            this.panelSimControls.Controls.Add(this.lblSteerAngle);
            this.panelSimControls.Controls.Add(this.label11);
            this.panelSimControls.Controls.Add(this.label12);
            this.panelSimControls.Controls.Add(this.tbarSteerAngle);
            this.panelSimControls.Controls.Add(this.tbarStepDistance);
            this.panelSimControls.Name = "panelSimControls";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // btnSection8Man
            // 
            resources.ApplyResources(this.btnSection8Man, "btnSection8Man");
            this.btnSection8Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection8Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection8Man.FlatAppearance.BorderSize = 0;
            this.btnSection8Man.Name = "btnSection8Man";
            this.btnSection8Man.UseVisualStyleBackColor = false;
            this.btnSection8Man.Click += new System.EventHandler(this.btnSection8Man_Click);
            // 
            // btnSection7Man
            // 
            resources.ApplyResources(this.btnSection7Man, "btnSection7Man");
            this.btnSection7Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection7Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection7Man.FlatAppearance.BorderSize = 0;
            this.btnSection7Man.Name = "btnSection7Man";
            this.btnSection7Man.UseVisualStyleBackColor = false;
            this.btnSection7Man.Click += new System.EventHandler(this.btnSection7Man_Click);
            // 
            // btnSection6Man
            // 
            resources.ApplyResources(this.btnSection6Man, "btnSection6Man");
            this.btnSection6Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection6Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection6Man.FlatAppearance.BorderSize = 0;
            this.btnSection6Man.Name = "btnSection6Man";
            this.btnSection6Man.UseVisualStyleBackColor = false;
            this.btnSection6Man.Click += new System.EventHandler(this.btnSection6Man_Click);
            // 
            // btnSection5Man
            // 
            resources.ApplyResources(this.btnSection5Man, "btnSection5Man");
            this.btnSection5Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection5Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection5Man.FlatAppearance.BorderSize = 0;
            this.btnSection5Man.Name = "btnSection5Man";
            this.btnSection5Man.UseVisualStyleBackColor = false;
            this.btnSection5Man.Click += new System.EventHandler(this.btnSection5Man_Click);
            // 
            // btnSection4Man
            // 
            resources.ApplyResources(this.btnSection4Man, "btnSection4Man");
            this.btnSection4Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection4Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection4Man.FlatAppearance.BorderSize = 0;
            this.btnSection4Man.Name = "btnSection4Man";
            this.btnSection4Man.UseVisualStyleBackColor = false;
            this.btnSection4Man.Click += new System.EventHandler(this.btnSection4Man_Click);
            // 
            // btnSection3Man
            // 
            resources.ApplyResources(this.btnSection3Man, "btnSection3Man");
            this.btnSection3Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection3Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection3Man.FlatAppearance.BorderSize = 0;
            this.btnSection3Man.Name = "btnSection3Man";
            this.btnSection3Man.UseVisualStyleBackColor = false;
            this.btnSection3Man.Click += new System.EventHandler(this.btnSection3Man_Click);
            // 
            // btnSection2Man
            // 
            resources.ApplyResources(this.btnSection2Man, "btnSection2Man");
            this.btnSection2Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection2Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection2Man.FlatAppearance.BorderSize = 0;
            this.btnSection2Man.Name = "btnSection2Man";
            this.btnSection2Man.UseVisualStyleBackColor = false;
            this.btnSection2Man.Click += new System.EventHandler(this.btnSection2Man_Click);
            // 
            // btnSection1Man
            // 
            resources.ApplyResources(this.btnSection1Man, "btnSection1Man");
            this.btnSection1Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection1Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection1Man.FlatAppearance.BorderSize = 0;
            this.btnSection1Man.Name = "btnSection1Man";
            this.btnSection1Man.UseVisualStyleBackColor = false;
            this.btnSection1Man.Click += new System.EventHandler(this.btnSection1Man_Click);
            // 
            // btnSection9Man
            // 
            resources.ApplyResources(this.btnSection9Man, "btnSection9Man");
            this.btnSection9Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection9Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection9Man.FlatAppearance.BorderSize = 0;
            this.btnSection9Man.Name = "btnSection9Man";
            this.btnSection9Man.UseVisualStyleBackColor = false;
            this.btnSection9Man.Click += new System.EventHandler(this.btnSection9Man_Click);
            // 
            // btnSection10Man
            // 
            resources.ApplyResources(this.btnSection10Man, "btnSection10Man");
            this.btnSection10Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection10Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection10Man.FlatAppearance.BorderSize = 0;
            this.btnSection10Man.Name = "btnSection10Man";
            this.btnSection10Man.UseVisualStyleBackColor = false;
            this.btnSection10Man.Click += new System.EventHandler(this.btnSection10Man_Click);
            // 
            // btnSection11Man
            // 
            resources.ApplyResources(this.btnSection11Man, "btnSection11Man");
            this.btnSection11Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection11Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection11Man.FlatAppearance.BorderSize = 0;
            this.btnSection11Man.Name = "btnSection11Man";
            this.btnSection11Man.UseVisualStyleBackColor = false;
            this.btnSection11Man.Click += new System.EventHandler(this.btnSection11Man_Click);
            // 
            // btnSection12Man
            // 
            resources.ApplyResources(this.btnSection12Man, "btnSection12Man");
            this.btnSection12Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection12Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection12Man.FlatAppearance.BorderSize = 0;
            this.btnSection12Man.Name = "btnSection12Man";
            this.btnSection12Man.UseVisualStyleBackColor = false;
            this.btnSection12Man.Click += new System.EventHandler(this.btnSection12Man_Click);
            // 
            // btnCurve
            // 
            resources.ApplyResources(this.btnCurve, "btnCurve");
            this.btnCurve.BackColor = System.Drawing.Color.Lavender;
            this.btnCurve.Image = global::AgOpenGPS.Properties.Resources.CurveOff;
            this.btnCurve.Name = "btnCurve";
            this.btnCurve.UseVisualStyleBackColor = false;
            this.btnCurve.Click += new System.EventHandler(this.btnCurve_Click);
            // 
            // btnLeftYouTurn
            // 
            this.btnLeftYouTurn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLeftYouTurn.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnLeftYouTurn, "btnLeftYouTurn");
            this.btnLeftYouTurn.Name = "btnLeftYouTurn";
            this.btnLeftYouTurn.UseVisualStyleBackColor = false;
            this.btnLeftYouTurn.Click += new System.EventHandler(this.btnLeftYouTurn_Click);
            // 
            // btnSwapDirection
            // 
            this.btnSwapDirection.BackColor = System.Drawing.Color.Transparent;
            this.btnSwapDirection.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnSwapDirection, "btnSwapDirection");
            this.btnSwapDirection.Name = "btnSwapDirection";
            this.btnSwapDirection.UseVisualStyleBackColor = false;
            this.btnSwapDirection.Click += new System.EventHandler(this.btnSwapDirection_Click);
            // 
            // btnEnableAutoYouTurn
            // 
            this.btnEnableAutoYouTurn.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnEnableAutoYouTurn, "btnEnableAutoYouTurn");
            this.btnEnableAutoYouTurn.Name = "btnEnableAutoYouTurn";
            this.btnEnableAutoYouTurn.UseVisualStyleBackColor = false;
            this.btnEnableAutoYouTurn.Click += new System.EventHandler(this.btnEnableAutoYouTurn_Click);
            // 
            // btnSectionOffAutoOn
            // 
            resources.ApplyResources(this.btnSectionOffAutoOn, "btnSectionOffAutoOn");
            this.btnSectionOffAutoOn.BackColor = System.Drawing.Color.Lavender;
            this.btnSectionOffAutoOn.Name = "btnSectionOffAutoOn";
            this.btnSectionOffAutoOn.UseVisualStyleBackColor = false;
            this.btnSectionOffAutoOn.Click += new System.EventHandler(this.btnSectionOffAutoOn_Click);
            // 
            // btnFlag
            // 
            this.btnFlag.BackColor = System.Drawing.Color.Transparent;
            this.btnFlag.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnFlag, "btnFlag");
            this.btnFlag.Name = "btnFlag";
            this.btnFlag.UseVisualStyleBackColor = false;
            this.btnFlag.Click += new System.EventHandler(this.btnFlag_Click);
            // 
            // btnSnap
            // 
            this.btnSnap.BackColor = System.Drawing.Color.Transparent;
            this.btnSnap.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnSnap, "btnSnap");
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.UseVisualStyleBackColor = false;
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // btnAutoSteer
            // 
            this.btnAutoSteer.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoSteer.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnAutoSteer, "btnAutoSteer");
            this.btnAutoSteer.Name = "btnAutoSteer";
            this.btnAutoSteer.UseVisualStyleBackColor = false;
            this.btnAutoSteer.Click += new System.EventHandler(this.btnAutoSteer_Click);
            // 
            // btnRightYouTurn
            // 
            resources.ApplyResources(this.btnRightYouTurn, "btnRightYouTurn");
            this.btnRightYouTurn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRightYouTurn.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnRightYouTurn.Name = "btnRightYouTurn";
            this.btnRightYouTurn.UseVisualStyleBackColor = false;
            this.btnRightYouTurn.Click += new System.EventHandler(this.btnRightYouTurn_Click);
            // 
            // btnContour
            // 
            resources.ApplyResources(this.btnContour, "btnContour");
            this.btnContour.BackColor = System.Drawing.Color.Lavender;
            this.btnContour.Name = "btnContour";
            this.btnContour.UseVisualStyleBackColor = false;
            this.btnContour.Click += new System.EventHandler(this.btnContour_Click);
            // 
            // btnManualOffOn
            // 
            resources.ApplyResources(this.btnManualOffOn, "btnManualOffOn");
            this.btnManualOffOn.BackColor = System.Drawing.Color.Lavender;
            this.btnManualOffOn.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnManualOffOn.Name = "btnManualOffOn";
            this.btnManualOffOn.UseVisualStyleBackColor = false;
            this.btnManualOffOn.Click += new System.EventHandler(this.btnManualOffOn_Click);
            // 
            // btnABLine
            // 
            resources.ApplyResources(this.btnABLine, "btnABLine");
            this.btnABLine.BackColor = System.Drawing.Color.Lavender;
            this.btnABLine.Name = "btnABLine";
            this.btnABLine.UseVisualStyleBackColor = false;
            this.btnABLine.Click += new System.EventHandler(this.btnABLine_Click);
            // 
            // FormGPS
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Controls.Add(this.btnCurve);
            this.Controls.Add(this.btnLeftYouTurn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.btnSwapDirection);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnEnableAutoYouTurn);
            this.Controls.Add(this.lblPureSteerAngle);
            this.Controls.Add(this.btnSectionOffAutoOn);
            this.Controls.Add(this.btnFlag);
            this.Controls.Add(this.btnSnap);
            this.Controls.Add(this.btnAutoSteer);
            this.Controls.Add(this.btnRightYouTurn);
            this.Controls.Add(this.btnContour);
            this.Controls.Add(this.btnManualOffOn);
            this.Controls.Add(this.btnABLine);
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
            this.Controls.Add(this.panelSimControls);
            this.Controls.Add(this.btnSection12Man);
            this.Controls.Add(this.btnSection11Man);
            this.Controls.Add(this.btnSection10Man);
            this.Controls.Add(this.btnSection9Man);
            this.Controls.Add(this.openGLControl);
            this.Controls.Add(this.openGLControlBack);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGPS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGPS_FormClosing);
            this.Load += new System.EventHandler(this.FormGPS_Load);
            this.Resize += new System.EventHandler(this.FormGPS_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.contextMenuStripOpenGL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlBack)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStripFlag.ResumeLayout(false);
            this.contextMenuArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlZoom)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.DataPage.ResumeLayout(false);
            this.DataPage.PerformLayout();
            this.zoomPage2.ResumeLayout(false);
            this.zoomPage2.PerformLayout();
            this.rate2Page5.ResumeLayout(false);
            this.rate2Page5.PerformLayout();
            this.configPage1.ResumeLayout(false);
            this.autoPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbarSteerAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarStepDistance)).EndInit();
            this.panelSimControls.ResumeLayout(false);
            this.panelSimControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.Button btnABLine;
        private SharpGL.OpenGLControl openGLControlBack;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Timer tmrWatchdog;
        private System.Windows.Forms.ToolStripMenuItem polygonsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stripDistance;
        private System.Windows.Forms.ToolStripStatusLabel stripPortGPS;
        private System.Windows.Forms.ToolStripStatusLabel stripAreaRate;
        private System.Windows.Forms.ToolStripStatusLabel stripPortArduino;
        private System.Windows.Forms.ToolStripMenuItem resetALLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadVehicleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveVehicleToolStripMenuItem;
        private System.Windows.Forms.Button btnManualOffOn;
        private System.Windows.Forms.Button btnSection1Man;
        private System.Windows.Forms.Button btnSection2Man;
        private System.Windows.Forms.Button btnSection3Man;
        private System.Windows.Forms.Button btnSection4Man;
        private System.Windows.Forms.Button btnSection5Man;
        private System.Windows.Forms.Button btnContour;
        private System.Windows.Forms.ToolStripStatusLabel stripHz;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnPerimeter;
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
        private ProXoft.WinForms.RepeatButton btnTiltUp;
        private ProXoft.WinForms.RepeatButton btnTiltDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFlagDeleteAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripOpenGL;
        private System.Windows.Forms.ToolStripMenuItem deleteFlagToolOpenGLContextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem googleEarthOpenGLContextMenu;
        private System.Windows.Forms.ContextMenuStrip contextMenuArea;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAreaSide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem fieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar stripOnlineGPS;
        private System.Windows.Forms.ToolStripProgressBar stripOnlineArduino;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fieldToolStripMenuItem1;
        private System.Windows.Forms.Button btnSection8Man;
        private System.Windows.Forms.Button btnSection7Man;
        private System.Windows.Forms.Button btnSection6Man;
        private System.Windows.Forms.ToolStripStatusLabel stripPortAutoSteer;
        private System.Windows.Forms.ToolStripProgressBar stripOnlineAutoSteer;
        private System.Windows.Forms.ToolStripMenuItem logNMEAMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripUnitsMenu;
        private System.Windows.Forms.ToolStripMenuItem metricToolStrip;
        private System.Windows.Forms.ToolStripMenuItem imperialToolStrip;
        private System.Windows.Forms.ToolStripMenuItem skyToolStripMenu;
        private System.Windows.Forms.Button btnSnap;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.TextBox tboxSentence;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.Button btnGPSData;
        private System.Windows.Forms.Button btnFileExplorer;
        private System.Windows.Forms.Label lblSpeedUnits;
        private System.Windows.Forms.ToolStripMenuItem sideGuideLines;
        private System.Windows.Forms.ToolStripMenuItem pursuitLineToolStripMenuItem;
        private System.Windows.Forms.Button btnRightYouTurn;
        private System.Windows.Forms.Button btnLeftYouTurn;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnAutoSteer;
        private System.Windows.Forms.Button btnFlag;
        private SharpGL.OpenGLControl openGLControlZoom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFieldWidthNorthSouth;
        private System.Windows.Forms.Label lblFieldWidthEastWest;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage configPage1;
        private System.Windows.Forms.TabPage zoomPage2;
        private System.Windows.Forms.TabPage DataPage;
        private System.Windows.Forms.Button btnEnableAutoYouTurn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblZooom;
        private System.Windows.Forms.Timer timerSim;
        private System.Windows.Forms.TrackBar tbarStepDistance;
        private System.Windows.Forms.TrackBar tbarSteerAngle;
        private System.Windows.Forms.Button btnResetSteerAngle;
        private System.Windows.Forms.Label lblSteerAngle;
        private System.Windows.Forms.Button btnResetSim;
        private System.Windows.Forms.ToolStripMenuItem simulatorOnToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownBtnFuncs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.Label lblPureSteerAngle;
        private System.Windows.Forms.Label lblGPSHeading;
        private System.Windows.Forms.Label lblYawHeading;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolstripUSBPortsConfig;
        private System.Windows.Forms.ToolStripMenuItem toolstripVehicleConfig;
        private System.Windows.Forms.ToolStripMenuItem toolstripAutoSteerConfig;
        private System.Windows.Forms.ToolStripMenuItem toolstripYouTurnConfig;
        private System.Windows.Forms.ToolStripMenuItem toolstripResetTrip;
        private System.Windows.Forms.ToolStripMenuItem toolstripField;
        private System.Windows.Forms.ToolStripMenuItem toolstripBoundary;
        private System.Windows.Forms.ToolStripMenuItem toolstripHeadland;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button btnSwapDirection;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblHeadlandDistanceAway;
        private System.Windows.Forms.Label lblBoundaryArea;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblHeadlandDistanceFromTool;
        private System.Windows.Forms.ToolStripMenuItem toolstripUDPConfig;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblFixQuality;
        private System.Windows.Forms.Label lblSats;
        private System.Windows.Forms.Panel panelSimControls;
        private System.Windows.Forms.ToolStripDropDownButton btnHideTabs;
        public System.Windows.Forms.Button btnSectionOffAutoOn;
        private System.Windows.Forms.ToolStripStatusLabel stripEqWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem menustripLanguage;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageEnglish;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageDeutsch;
        private System.Windows.Forms.Label label14;
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
        private System.Windows.Forms.TabPage autoPage4;
        private System.Windows.Forms.Button btnFlagsGoogleEarth;
        private System.Windows.Forms.Button btnWebCam;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnDeleteAllData;
        private System.Windows.Forms.ToolStripMenuItem toolstripDisplayConfig;
        private System.Windows.Forms.Button btnMakeContourFromBoundary;
        private System.Windows.Forms.Button btnRecPathPauseRecord;
        private System.Windows.Forms.Button btnCartDone;
        private System.Windows.Forms.Button btnCallCart;
        private System.Windows.Forms.Button btnCartOnOff;
        private System.Windows.Forms.Button btnOffsetForward;
        private System.Windows.Forms.Button btnOffsetOutward;
        private System.Windows.Forms.Button btnOffsetInward;
        private System.Windows.Forms.Button btnOffsetBackward;
        public System.Windows.Forms.Button btnCurve;
        private System.Windows.Forms.TextBox txtBoxSendAutoSteer;
        private System.Windows.Forms.TextBox txtBoxRecvAutoSteer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblHeading2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnSection9Man;
        private System.Windows.Forms.Button btnSection10Man;
        private System.Windows.Forms.Button btnSection11Man;
        private System.Windows.Forms.Button btnSection12Man;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TabPage rate2Page5;
        private System.Windows.Forms.Label lblFlowRateRight;
        private System.Windows.Forms.Label lblFlowRateLeft;
        private ProXoft.WinForms.RepeatButton btnRateRightDn;
        private ProXoft.WinForms.RepeatButton btnRateRightUp;
        private System.Windows.Forms.Label lblRateSetpointRight;
        private System.Windows.Forms.Label lblFlowRight;
        private System.Windows.Forms.Label lblRateAppliedActualLeft;
        private System.Windows.Forms.Button btnDualRateConfig;
        private ProXoft.WinForms.RepeatButton btnRateLeftDn;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblFlowLeft;
        private System.Windows.Forms.Label lblRateAppliedActualRight;
        private System.Windows.Forms.Label lblDualAccumulatedVolume;
        private ProXoft.WinForms.RepeatButton btnRateLeftUp;
        private System.Windows.Forms.Button btnDualRate;
        private System.Windows.Forms.Label lblRateSetpointLeft;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtBoxSendArduino;
        private System.Windows.Forms.TextBox txtBoxRecvArduino;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnSelectRate2;
        private System.Windows.Forms.Button btnSelectRate1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnSelectSingleDualMeter;
        private System.Windows.Forms.ToolStripMenuItem enterSimCoordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.Label lblFixOffset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFixOffset;
        private System.Windows.Forms.Button btnSmoothAB;
        private System.Windows.Forms.ToolStripDropDownButton toolStripZoomOut;
        private System.Windows.Forms.ToolStripDropDownButton toolStripZoomIn;
    }
}

