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
            this.loadVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.fieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logNMEAMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pursuitLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skyToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sideGuideLines = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.communicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webCamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleEarthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gPSDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.variablesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuHelpHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrWatchdog = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stripHz = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripDistance = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripBtnResetDistance = new System.Windows.Forms.ToolStripSplitButton();
            this.stripAreaUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripEqWidth = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripAreaRate = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.panelMenu1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRateDn = new ProXoft.WinForms.RepeatButton();
            this.btnRateUp = new ProXoft.WinForms.RepeatButton();
            this.lblAccumulatedVolume = new System.Windows.Forms.Label();
            this.btnRate = new System.Windows.Forms.Button();
            this.lblRateAppliedActual = new System.Windows.Forms.Label();
            this.btnRate1Select = new System.Windows.Forms.Button();
            this.btnRate2Select = new System.Windows.Forms.Button();
            this.btnPerimeter = new System.Windows.Forms.Button();
            this.btnJob = new System.Windows.Forms.Button();
            this.btnBoundaryMenu = new System.Windows.Forms.Button();
            this.btnTiltUp = new ProXoft.WinForms.RepeatButton();
            this.btnTiltDown = new ProXoft.WinForms.RepeatButton();
            this.panelMenu3 = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAutoSteerConfig = new System.Windows.Forms.Button();
            this.btnComm = new System.Windows.Forms.Button();
            this.btnGPSData = new System.Windows.Forms.Button();
            this.btnFileExplorer = new System.Windows.Forms.Button();
            this.panelMenu2 = new System.Windows.Forms.Panel();
            this.lblSpeedUnits = new System.Windows.Forms.Label();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.strip2Roll = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.strip2PureSteerAngle = new System.Windows.Forms.ToolStripStatusLabel();
            this.strip2GPSLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.strip2GPSHeading = new System.Windows.Forms.ToolStripStatusLabel();
            this.strip2GyroHeading = new System.Windows.Forms.ToolStripStatusLabel();
            this.strip2TurnProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.strip2BoundaryDistanceAway = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelBoundaryArea = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnMenu3 = new System.Windows.Forms.Button();
            this.btnMenu2 = new System.Windows.Forms.Button();
            this.btnMenu1 = new System.Windows.Forms.Button();
            this.btnRightYouTurn = new System.Windows.Forms.Button();
            this.btnLeftYouTurn = new System.Windows.Forms.Button();
            this.btnSection8Man = new System.Windows.Forms.Button();
            this.btnSection7Man = new System.Windows.Forms.Button();
            this.btnSection6Man = new System.Windows.Forms.Button();
            this.btnZoomIn = new ProXoft.WinForms.RepeatButton();
            this.btnZoomOut = new ProXoft.WinForms.RepeatButton();
            this.btnContour = new System.Windows.Forms.Button();
            this.btnSection5Man = new System.Windows.Forms.Button();
            this.btnSection4Man = new System.Windows.Forms.Button();
            this.btnSection3Man = new System.Windows.Forms.Button();
            this.btnSection2Man = new System.Windows.Forms.Button();
            this.btnSection1Man = new System.Windows.Forms.Button();
            this.btnManualOffOn = new System.Windows.Forms.Button();
            this.btnABLine = new System.Windows.Forms.Button();
            this.btnMinMaxZoom = new System.Windows.Forms.Button();
            this.btnAutoSteer = new System.Windows.Forms.Button();
            this.btnSnap = new System.Windows.Forms.Button();
            this.btnAutoYouTurn = new System.Windows.Forms.Button();
            this.btnFlag = new System.Windows.Forms.Button();
            this.btnSectionOffAutoOn = new System.Windows.Forms.Button();
            this.btnMenu4 = new System.Windows.Forms.Button();
            this.panelMenu4 = new System.Windows.Forms.Panel();
            this.openGLControlZoom = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.contextMenuStripOpenGL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlBack)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStripFlag.SuspendLayout();
            this.contextMenuArea.SuspendLayout();
            this.panelMenu1.SuspendLayout();
            this.panelMenu3.SuspendLayout();
            this.panelMenu2.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.panelMenu4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openGLControl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.openGLControl.ContextMenuStrip = this.contextMenuStripOpenGL;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openGLControl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openGLControl.FrameRate = 5;
            this.openGLControl.Location = new System.Drawing.Point(0, 49);
            this.openGLControl.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.openGLControl.Size = new System.Drawing.Size(846, 582);
            this.openGLControl.TabIndex = 6;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
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
            // deleteFlagToolOpenGLContextMenu
            // 
            this.deleteFlagToolOpenGLContextMenu.AutoSize = false;
            this.deleteFlagToolOpenGLContextMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteFlagToolOpenGLContextMenu.Image = ((System.Drawing.Image)(resources.GetObject("deleteFlagToolOpenGLContextMenu.Image")));
            this.deleteFlagToolOpenGLContextMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteFlagToolOpenGLContextMenu.Name = "deleteFlagToolOpenGLContextMenu";
            this.deleteFlagToolOpenGLContextMenu.Size = new System.Drawing.Size(70, 70);
            this.deleteFlagToolOpenGLContextMenu.Text = ".";
            this.deleteFlagToolOpenGLContextMenu.Click += new System.EventHandler(this.deleteFlagToolOpenGLContextMenu_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(68, 6);
            // 
            // googleEarthOpenGLContextMenu
            // 
            this.googleEarthOpenGLContextMenu.AutoSize = false;
            this.googleEarthOpenGLContextMenu.Image = ((System.Drawing.Image)(resources.GetObject("googleEarthOpenGLContextMenu.Image")));
            this.googleEarthOpenGLContextMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.googleEarthOpenGLContextMenu.Name = "googleEarthOpenGLContextMenu";
            this.googleEarthOpenGLContextMenu.Size = new System.Drawing.Size(70, 70);
            this.googleEarthOpenGLContextMenu.Text = ".";
            this.googleEarthOpenGLContextMenu.Click += new System.EventHandler(this.googleEarthOpenGLContextMenu_Click);
            // 
            // txtDistanceOffABLine
            // 
            this.txtDistanceOffABLine.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDistanceOffABLine.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtDistanceOffABLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDistanceOffABLine.Font = new System.Drawing.Font("Segoe UI Symbol", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDistanceOffABLine.ForeColor = System.Drawing.Color.Green;
            this.txtDistanceOffABLine.Location = new System.Drawing.Point(370, 0);
            this.txtDistanceOffABLine.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.txtDistanceOffABLine.Name = "txtDistanceOffABLine";
            this.txtDistanceOffABLine.ReadOnly = true;
            this.txtDistanceOffABLine.Size = new System.Drawing.Size(110, 43);
            this.txtDistanceOffABLine.TabIndex = 7;
            this.txtDistanceOffABLine.Text = "00000";
            this.txtDistanceOffABLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // openGLControlBack
            // 
            this.openGLControlBack.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.openGLControlBack.DrawFPS = false;
            this.openGLControlBack.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openGLControlBack.FrameRate = 1;
            this.openGLControlBack.Location = new System.Drawing.Point(0, 49);
            this.openGLControlBack.Name = "openGLControlBack";
            this.openGLControlBack.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControlBack.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLControlBack.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.openGLControlBack.Size = new System.Drawing.Size(400, 400);
            this.openGLControlBack.TabIndex = 91;
            this.openGLControlBack.Visible = false;
            this.openGLControlBack.OpenGLInitialized += new System.EventHandler(this.openGLControlBack_OpenGLInitialized);
            this.openGLControlBack.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControlBack_OpenGLDraw);
            this.openGLControlBack.Resized += new System.EventHandler(this.openGLControlBack_Resized);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadVehicleToolStripMenuItem,
            this.saveVehicleToolStripMenuItem,
            this.toolStripSeparator8,
            this.fieldToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(69, 45);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadVehicleToolStripMenuItem
            // 
            this.loadVehicleToolStripMenuItem.Name = "loadVehicleToolStripMenuItem";
            this.loadVehicleToolStripMenuItem.Size = new System.Drawing.Size(258, 40);
            this.loadVehicleToolStripMenuItem.Text = "Load Vehicle";
            this.loadVehicleToolStripMenuItem.Click += new System.EventHandler(this.loadVehicleToolStripMenuItem_Click);
            // 
            // saveVehicleToolStripMenuItem
            // 
            this.saveVehicleToolStripMenuItem.Name = "saveVehicleToolStripMenuItem";
            this.saveVehicleToolStripMenuItem.Size = new System.Drawing.Size(258, 40);
            this.saveVehicleToolStripMenuItem.Text = "Save Vehicle";
            this.saveVehicleToolStripMenuItem.Click += new System.EventHandler(this.saveVehicleToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(255, 6);
            // 
            // fieldToolStripMenuItem
            // 
            this.fieldToolStripMenuItem.Name = "fieldToolStripMenuItem";
            this.fieldToolStripMenuItem.Size = new System.Drawing.Size(258, 40);
            this.fieldToolStripMenuItem.Text = "Start Field";
            this.fieldToolStripMenuItem.Click += new System.EventHandler(this.fieldToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.resetALLToolStripMenuItem,
            this.toolStripSeparator2,
            this.colorsToolStripMenuItem,
            this.toolStripUnitsMenu,
            this.gridToolStripMenuItem,
            this.lightbarToolStripMenuItem,
            this.logNMEAMenuItem,
            this.pursuitLineToolStripMenuItem,
            this.skyToolStripMenu,
            this.polygonsToolStripMenuItem,
            this.sideGuideLines,
            this.toolStripSeparator7,
            this.communicationToolStripMenuItem,
            this.toolStripSeparator6,
            this.settingsToolStripMenuItem1});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(124, 45);
            this.settingsToolStripMenuItem.Text = "Options";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(255, 6);
            // 
            // resetALLToolStripMenuItem
            // 
            this.resetALLToolStripMenuItem.Name = "resetALLToolStripMenuItem";
            this.resetALLToolStripMenuItem.Size = new System.Drawing.Size(258, 40);
            this.resetALLToolStripMenuItem.Text = "Reset ALL";
            this.resetALLToolStripMenuItem.Click += new System.EventHandler(this.resetALLToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(255, 6);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sectionToolStripMenuItem,
            this.fieldToolStripMenuItem1});
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(258, 40);
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
            this.toolStripUnitsMenu.Size = new System.Drawing.Size(258, 40);
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
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(258, 40);
            this.gridToolStripMenuItem.Text = "Grid On";
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
            // 
            // lightbarToolStripMenuItem
            // 
            this.lightbarToolStripMenuItem.Name = "lightbarToolStripMenuItem";
            this.lightbarToolStripMenuItem.Size = new System.Drawing.Size(258, 40);
            this.lightbarToolStripMenuItem.Text = "Lightbar On";
            this.lightbarToolStripMenuItem.Click += new System.EventHandler(this.lightbarToolStripMenuItem_Click);
            // 
            // logNMEAMenuItem
            // 
            this.logNMEAMenuItem.Name = "logNMEAMenuItem";
            this.logNMEAMenuItem.Size = new System.Drawing.Size(258, 40);
            this.logNMEAMenuItem.Text = "Log NMEA";
            this.logNMEAMenuItem.Click += new System.EventHandler(this.logNMEAMenuItem_Click);
            // 
            // pursuitLineToolStripMenuItem
            // 
            this.pursuitLineToolStripMenuItem.Checked = true;
            this.pursuitLineToolStripMenuItem.CheckOnClick = true;
            this.pursuitLineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pursuitLineToolStripMenuItem.Name = "pursuitLineToolStripMenuItem";
            this.pursuitLineToolStripMenuItem.Size = new System.Drawing.Size(258, 40);
            this.pursuitLineToolStripMenuItem.Text = "Pursuit Line";
            this.pursuitLineToolStripMenuItem.Click += new System.EventHandler(this.pursuitLineToolStripMenuItem_Click);
            // 
            // skyToolStripMenu
            // 
            this.skyToolStripMenu.Checked = true;
            this.skyToolStripMenu.CheckOnClick = true;
            this.skyToolStripMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skyToolStripMenu.Name = "skyToolStripMenu";
            this.skyToolStripMenu.Size = new System.Drawing.Size(258, 40);
            this.skyToolStripMenu.Text = "Sky On";
            // 
            // polygonsToolStripMenuItem
            // 
            this.polygonsToolStripMenuItem.Checked = true;
            this.polygonsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.polygonsToolStripMenuItem.Name = "polygonsToolStripMenuItem";
            this.polygonsToolStripMenuItem.Size = new System.Drawing.Size(258, 40);
            this.polygonsToolStripMenuItem.Text = "Polygons On";
            this.polygonsToolStripMenuItem.Click += new System.EventHandler(this.polygonsToolStripMenuItem_Click);
            // 
            // sideGuideLines
            // 
            this.sideGuideLines.Checked = true;
            this.sideGuideLines.CheckOnClick = true;
            this.sideGuideLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sideGuideLines.Name = "sideGuideLines";
            this.sideGuideLines.Size = new System.Drawing.Size(258, 40);
            this.sideGuideLines.Text = "Extra Guides";
            this.sideGuideLines.Click += new System.EventHandler(this.sideGuideLines_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(255, 6);
            // 
            // communicationToolStripMenuItem
            // 
            this.communicationToolStripMenuItem.Name = "communicationToolStripMenuItem";
            this.communicationToolStripMenuItem.Size = new System.Drawing.Size(258, 40);
            this.communicationToolStripMenuItem.Text = "USB Ports ";
            this.communicationToolStripMenuItem.Click += new System.EventHandler(this.communicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(255, 6);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(258, 40);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Size = new System.Drawing.Size(1346, 45);
            this.menuStrip1.TabIndex = 49;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.explorerToolStripMenuItem,
            this.webCamToolStripMenuItem,
            this.fieldViewerToolStripMenuItem,
            this.googleEarthToolStripMenuItem,
            this.gPSDataToolStripMenuItem1,
            this.variablesToolStripMenuItem1,
            this.helpToolStripMenuItem1});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(93, 45);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // explorerToolStripMenuItem
            // 
            this.explorerToolStripMenuItem.Name = "explorerToolStripMenuItem";
            this.explorerToolStripMenuItem.Size = new System.Drawing.Size(360, 40);
            this.explorerToolStripMenuItem.Text = "Windows Explorer";
            this.explorerToolStripMenuItem.Click += new System.EventHandler(this.explorerToolStripMenuItem_Click);
            // 
            // webCamToolStripMenuItem
            // 
            this.webCamToolStripMenuItem.Name = "webCamToolStripMenuItem";
            this.webCamToolStripMenuItem.Size = new System.Drawing.Size(360, 40);
            this.webCamToolStripMenuItem.Text = "Web Cam";
            this.webCamToolStripMenuItem.Click += new System.EventHandler(this.webCamToolStripMenuItem_Click_1);
            // 
            // fieldViewerToolStripMenuItem
            // 
            this.fieldViewerToolStripMenuItem.Name = "fieldViewerToolStripMenuItem";
            this.fieldViewerToolStripMenuItem.Size = new System.Drawing.Size(360, 40);
            this.fieldViewerToolStripMenuItem.Text = "Field Viewer";
            this.fieldViewerToolStripMenuItem.Click += new System.EventHandler(this.fieldViewerToolStripMenuItem_Click);
            // 
            // googleEarthToolStripMenuItem
            // 
            this.googleEarthToolStripMenuItem.Name = "googleEarthToolStripMenuItem";
            this.googleEarthToolStripMenuItem.Size = new System.Drawing.Size(360, 40);
            this.googleEarthToolStripMenuItem.Text = "Google Earth - Flags";
            this.googleEarthToolStripMenuItem.Click += new System.EventHandler(this.googleEarthToolStripMenuItem_Click);
            // 
            // gPSDataToolStripMenuItem1
            // 
            this.gPSDataToolStripMenuItem1.Name = "gPSDataToolStripMenuItem1";
            this.gPSDataToolStripMenuItem1.Size = new System.Drawing.Size(360, 40);
            this.gPSDataToolStripMenuItem1.Text = "GPS Data";
            this.gPSDataToolStripMenuItem1.Click += new System.EventHandler(this.gPSDataToolStripMenuItem1_Click);
            // 
            // variablesToolStripMenuItem1
            // 
            this.variablesToolStripMenuItem1.Name = "variablesToolStripMenuItem1";
            this.variablesToolStripMenuItem1.Size = new System.Drawing.Size(360, 40);
            this.variablesToolStripMenuItem1.Text = "Variables";
            this.variablesToolStripMenuItem1.Click += new System.EventHandler(this.variablesToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuHelpAbout,
            this.helpToolStripMenuHelpHelp});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(360, 40);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuHelpAbout
            // 
            this.aboutToolStripMenuHelpAbout.Name = "aboutToolStripMenuHelpAbout";
            this.aboutToolStripMenuHelpAbout.Size = new System.Drawing.Size(168, 40);
            this.aboutToolStripMenuHelpAbout.Text = "About";
            this.aboutToolStripMenuHelpAbout.Click += new System.EventHandler(this.aboutToolStripMenuHelpAbout_Click);
            // 
            // helpToolStripMenuHelpHelp
            // 
            this.helpToolStripMenuHelpHelp.Name = "helpToolStripMenuHelpHelp";
            this.helpToolStripMenuHelpHelp.Size = new System.Drawing.Size(168, 40);
            this.helpToolStripMenuHelpHelp.Text = "Help";
            this.helpToolStripMenuHelpHelp.Click += new System.EventHandler(this.helpToolStripMenuHelpHelp_Click);
            // 
            // tmrWatchdog
            // 
            this.tmrWatchdog.Interval = 20;
            this.tmrWatchdog.Tick += new System.EventHandler(this.tmrWatchdog_tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripHz,
            this.stripDistance,
            this.toolStripBtnResetDistance,
            this.stripAreaUser,
            this.stripEqWidth,
            this.stripAreaRate,
            this.stripPortGPS,
            this.stripOnlineGPS,
            this.stripPortArduino,
            this.stripOnlineArduino,
            this.stripPortAutoSteer,
            this.stripOnlineAutoSteer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 769);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1346, 38);
            this.statusStrip1.TabIndex = 95;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stripHz
            // 
            this.stripHz.AutoSize = false;
            this.stripHz.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stripHz.Margin = new System.Windows.Forms.Padding(0);
            this.stripHz.Name = "stripHz";
            this.stripHz.Size = new System.Drawing.Size(75, 38);
            this.stripHz.Text = "Hz";
            this.stripHz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stripDistance
            // 
            this.stripDistance.AutoSize = false;
            this.stripDistance.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stripDistance.Margin = new System.Windows.Forms.Padding(-4, 0, 0, 0);
            this.stripDistance.Name = "stripDistance";
            this.stripDistance.Size = new System.Drawing.Size(85, 38);
            this.stripDistance.Text = "8888 ft";
            // 
            // toolStripBtnResetDistance
            // 
            this.toolStripBtnResetDistance.AutoSize = false;
            this.toolStripBtnResetDistance.BackColor = System.Drawing.Color.LightGray;
            this.toolStripBtnResetDistance.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripBtnResetDistance.BackgroundImage")));
            this.toolStripBtnResetDistance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripBtnResetDistance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnResetDistance.DropDownButtonWidth = 20;
            this.toolStripBtnResetDistance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripBtnResetDistance.ForeColor = System.Drawing.SystemColors.MenuText;
            this.toolStripBtnResetDistance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripBtnResetDistance.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripBtnResetDistance.Name = "toolStripBtnResetDistance";
            this.toolStripBtnResetDistance.Size = new System.Drawing.Size(90, 36);
            this.toolStripBtnResetDistance.ButtonClick += new System.EventHandler(this.toolStripBtnResetDistance_ButtonClick);
            // 
            // stripAreaUser
            // 
            this.stripAreaUser.AutoSize = false;
            this.stripAreaUser.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stripAreaUser.Margin = new System.Windows.Forms.Padding(0);
            this.stripAreaUser.Name = "stripAreaUser";
            this.stripAreaUser.Size = new System.Drawing.Size(90, 38);
            this.stripAreaUser.Text = "126.9";
            // 
            // stripEqWidth
            // 
            this.stripEqWidth.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.stripEqWidth.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stripEqWidth.Margin = new System.Windows.Forms.Padding(0);
            this.stripEqWidth.Name = "stripEqWidth";
            this.stripEqWidth.Size = new System.Drawing.Size(801, 38);
            this.stripEqWidth.Spring = true;
            this.stripEqWidth.Text = "Width";
            // 
            // stripAreaRate
            // 
            this.stripAreaRate.AutoSize = false;
            this.stripAreaRate.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stripAreaRate.Margin = new System.Windows.Forms.Padding(0);
            this.stripAreaRate.Name = "stripAreaRate";
            this.stripAreaRate.Size = new System.Drawing.Size(80, 38);
            this.stripAreaRate.Text = "Ac/Hr";
            this.stripAreaRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stripAreaRate.ToolTipText = "Area Per Hour";
            // 
            // stripPortGPS
            // 
            this.stripPortGPS.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.stripPortGPS.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stripPortGPS.ForeColor = System.Drawing.Color.Red;
            this.stripPortGPS.Name = "stripPortGPS";
            this.stripPortGPS.Size = new System.Drawing.Size(20, 33);
            this.stripPortGPS.Text = "* *";
            // 
            // stripOnlineGPS
            // 
            this.stripOnlineGPS.AutoSize = false;
            this.stripOnlineGPS.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.stripOnlineGPS.Name = "stripOnlineGPS";
            this.stripOnlineGPS.Size = new System.Drawing.Size(16, 32);
            this.stripOnlineGPS.Value = 1;
            // 
            // stripPortArduino
            // 
            this.stripPortArduino.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stripPortArduino.ForeColor = System.Drawing.Color.Red;
            this.stripPortArduino.Name = "stripPortArduino";
            this.stripPortArduino.Size = new System.Drawing.Size(20, 33);
            this.stripPortArduino.Text = "* *";
            // 
            // stripOnlineArduino
            // 
            this.stripOnlineArduino.AutoToolTip = true;
            this.stripOnlineArduino.ForeColor = System.Drawing.Color.Chartreuse;
            this.stripOnlineArduino.Name = "stripOnlineArduino";
            this.stripOnlineArduino.Size = new System.Drawing.Size(16, 32);
            this.stripOnlineArduino.ToolTipText = "Arduino";
            this.stripOnlineArduino.Value = 1;
            // 
            // stripPortAutoSteer
            // 
            this.stripPortAutoSteer.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stripPortAutoSteer.ForeColor = System.Drawing.Color.Red;
            this.stripPortAutoSteer.Name = "stripPortAutoSteer";
            this.stripPortAutoSteer.Size = new System.Drawing.Size(20, 33);
            this.stripPortAutoSteer.Text = "* *";
            // 
            // stripOnlineAutoSteer
            // 
            this.stripOnlineAutoSteer.AutoToolTip = true;
            this.stripOnlineAutoSteer.ForeColor = System.Drawing.Color.Chartreuse;
            this.stripOnlineAutoSteer.Name = "stripOnlineAutoSteer";
            this.stripOnlineAutoSteer.Size = new System.Drawing.Size(16, 32);
            this.stripOnlineAutoSteer.ToolTipText = "Arduino";
            this.stripOnlineAutoSteer.Value = 1;
            // 
            // lblNorthing
            // 
            this.lblNorthing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNorthing.AutoSize = true;
            this.lblNorthing.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblNorthing.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNorthing.Location = new System.Drawing.Point(1187, 2);
            this.lblNorthing.Name = "lblNorthing";
            this.lblNorthing.Size = new System.Drawing.Size(55, 18);
            this.lblNorthing.TabIndex = 110;
            this.lblNorthing.Text = "label1";
            this.lblNorthing.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblEasting
            // 
            this.lblEasting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEasting.AutoSize = true;
            this.lblEasting.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblEasting.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasting.Location = new System.Drawing.Point(1065, 2);
            this.lblEasting.Name = "lblEasting";
            this.lblEasting.Size = new System.Drawing.Size(55, 18);
            this.lblEasting.TabIndex = 111;
            this.lblEasting.Text = "label2";
            this.lblEasting.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSpeed
            // 
            this.lblSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpeed.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblSpeed.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(791, 2);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(87, 41);
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
            // toolStripMenuItemFlagRed
            // 
            this.toolStripMenuItemFlagRed.AutoSize = false;
            this.toolStripMenuItemFlagRed.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuItemFlagRed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItemFlagRed.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemFlagRed.Image")));
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
            this.toolStripMenuFlagGrn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuFlagGrn.Image")));
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
            this.toolStripMenuFlagYel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuFlagYel.Image")));
            this.toolStripMenuFlagYel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuFlagYel.Name = "toolStripMenuFlagYel";
            this.toolStripMenuFlagYel.Size = new System.Drawing.Size(70, 70);
            this.toolStripMenuFlagYel.Text = ".";
            this.toolStripMenuFlagYel.Click += new System.EventHandler(this.toolStripMenuYel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(68, 20);
            // 
            // toolStripMenuFlagDelete
            // 
            this.toolStripMenuFlagDelete.AutoSize = false;
            this.toolStripMenuFlagDelete.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuFlagDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuFlagDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuFlagDelete.Image")));
            this.toolStripMenuFlagDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuFlagDelete.Name = "toolStripMenuFlagDelete";
            this.toolStripMenuFlagDelete.Size = new System.Drawing.Size(70, 70);
            this.toolStripMenuFlagDelete.Text = ".";
            this.toolStripMenuFlagDelete.Click += new System.EventHandler(this.toolStripMenuFlagDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(68, 20);
            // 
            // toolStripMenuFlagDeleteAll
            // 
            this.toolStripMenuFlagDeleteAll.AutoSize = false;
            this.toolStripMenuFlagDeleteAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuFlagDeleteAll.Image")));
            this.toolStripMenuFlagDeleteAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuFlagDeleteAll.Name = "toolStripMenuFlagDeleteAll";
            this.toolStripMenuFlagDeleteAll.Size = new System.Drawing.Size(70, 70);
            this.toolStripMenuFlagDeleteAll.Text = "toolStripMenuFlagDeleteAll";
            this.toolStripMenuFlagDeleteAll.Click += new System.EventHandler(this.toolStripMenuFlagDeleteAll_Click);
            // 
            // contextMenuArea
            // 
            this.contextMenuArea.AutoSize = false;
            this.contextMenuArea.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuAreaSide});
            this.contextMenuArea.Name = "contextMenuArea";
            this.contextMenuArea.Size = new System.Drawing.Size(70, 80);
            // 
            // toolStripMenuAreaSide
            // 
            this.toolStripMenuAreaSide.AutoSize = false;
            this.toolStripMenuAreaSide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuAreaSide.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuAreaSide.Image")));
            this.toolStripMenuAreaSide.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuAreaSide.Name = "toolStripMenuAreaSide";
            this.toolStripMenuAreaSide.Size = new System.Drawing.Size(70, 70);
            this.toolStripMenuAreaSide.Text = ".";
            this.toolStripMenuAreaSide.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripMenuAreaSide.Click += new System.EventHandler(this.toolStripMenuAreaSide_Click);
            // 
            // tboxSentence
            // 
            this.tboxSentence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxSentence.BackColor = System.Drawing.Color.LightGray;
            this.tboxSentence.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSentence.Location = new System.Drawing.Point(1059, 23);
            this.tboxSentence.Name = "tboxSentence";
            this.tboxSentence.Size = new System.Drawing.Size(283, 20);
            this.tboxSentence.TabIndex = 134;
            // 
            // lblZone
            // 
            this.lblZone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZone.AutoSize = true;
            this.lblZone.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblZone.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZone.Location = new System.Drawing.Point(1310, 2);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(26, 18);
            this.lblZone.TabIndex = 135;
            this.lblZone.Text = "Zn";
            this.lblZone.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelMenu1
            // 
            this.panelMenu1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu1.Controls.Add(this.label2);
            this.panelMenu1.Controls.Add(this.label1);
            this.panelMenu1.Controls.Add(this.btnRateDn);
            this.panelMenu1.Controls.Add(this.btnRateUp);
            this.panelMenu1.Controls.Add(this.lblAccumulatedVolume);
            this.panelMenu1.Controls.Add(this.btnRate);
            this.panelMenu1.Controls.Add(this.lblRateAppliedActual);
            this.panelMenu1.Controls.Add(this.btnRate1Select);
            this.panelMenu1.Controls.Add(this.btnRate2Select);
            this.panelMenu1.Location = new System.Drawing.Point(912, 122);
            this.panelMenu1.Name = "panelMenu1";
            this.panelMenu1.Size = new System.Drawing.Size(473, 348);
            this.panelMenu1.TabIndex = 136;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(34, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 21);
            this.label2.TabIndex = 147;
            this.label2.Text = "Volume";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(34, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 21);
            this.label1.TabIndex = 146;
            this.label1.Text = "Rate Actual";
            // 
            // btnRateDn
            // 
            this.btnRateDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRateDn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRateDn.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnRateDn.Location = new System.Drawing.Point(360, 219);
            this.btnRateDn.Name = "btnRateDn";
            this.btnRateDn.Size = new System.Drawing.Size(58, 80);
            this.btnRateDn.TabIndex = 148;
            this.btnRateDn.UseVisualStyleBackColor = true;
            this.btnRateDn.Visible = false;
            this.btnRateDn.Click += new System.EventHandler(this.btnRateDn_Click);
            // 
            // btnRateUp
            // 
            this.btnRateUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRateUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRateUp.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnRateUp.Location = new System.Drawing.Point(360, 113);
            this.btnRateUp.Name = "btnRateUp";
            this.btnRateUp.Size = new System.Drawing.Size(58, 80);
            this.btnRateUp.TabIndex = 149;
            this.btnRateUp.UseVisualStyleBackColor = true;
            this.btnRateUp.Visible = false;
            this.btnRateUp.Click += new System.EventHandler(this.btnRateUp_Click);
            // 
            // lblAccumulatedVolume
            // 
            this.lblAccumulatedVolume.AutoSize = true;
            this.lblAccumulatedVolume.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblAccumulatedVolume.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccumulatedVolume.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAccumulatedVolume.Location = new System.Drawing.Point(35, 31);
            this.lblAccumulatedVolume.Name = "lblAccumulatedVolume";
            this.lblAccumulatedVolume.Size = new System.Drawing.Size(33, 45);
            this.lblAccumulatedVolume.TabIndex = 144;
            this.lblAccumulatedVolume.Text = "-";
            // 
            // btnRate
            // 
            this.btnRate.BackColor = System.Drawing.Color.AliceBlue;
            this.btnRate.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnRate.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRate.Image = global::AgOpenGPS.Properties.Resources.RateControlOff;
            this.btnRate.Location = new System.Drawing.Point(174, 25);
            this.btnRate.Name = "btnRate";
            this.btnRate.Size = new System.Drawing.Size(114, 117);
            this.btnRate.TabIndex = 143;
            this.btnRate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRate.UseVisualStyleBackColor = false;
            this.btnRate.Click += new System.EventHandler(this.btnRate_Click);
            // 
            // lblRateAppliedActual
            // 
            this.lblRateAppliedActual.AutoSize = true;
            this.lblRateAppliedActual.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblRateAppliedActual.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRateAppliedActual.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRateAppliedActual.Location = new System.Drawing.Point(28, 102);
            this.lblRateAppliedActual.Name = "lblRateAppliedActual";
            this.lblRateAppliedActual.Size = new System.Drawing.Size(47, 65);
            this.lblRateAppliedActual.TabIndex = 145;
            this.lblRateAppliedActual.Text = "-";
            // 
            // btnRate1Select
            // 
            this.btnRate1Select.BackColor = System.Drawing.Color.Aquamarine;
            this.btnRate1Select.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRate1Select.Image = ((System.Drawing.Image)(resources.GetObject("btnRate1Select.Image")));
            this.btnRate1Select.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRate1Select.Location = new System.Drawing.Point(43, 207);
            this.btnRate1Select.Name = "btnRate1Select";
            this.btnRate1Select.Size = new System.Drawing.Size(107, 96);
            this.btnRate1Select.TabIndex = 145;
            this.btnRate1Select.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRate1Select.UseVisualStyleBackColor = false;
            this.btnRate1Select.Visible = false;
            this.btnRate1Select.Click += new System.EventHandler(this.btnRate1Select_Click);
            // 
            // btnRate2Select
            // 
            this.btnRate2Select.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnRate2Select.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRate2Select.Image = ((System.Drawing.Image)(resources.GetObject("btnRate2Select.Image")));
            this.btnRate2Select.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRate2Select.Location = new System.Drawing.Point(205, 207);
            this.btnRate2Select.Name = "btnRate2Select";
            this.btnRate2Select.Size = new System.Drawing.Size(107, 96);
            this.btnRate2Select.TabIndex = 146;
            this.btnRate2Select.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRate2Select.UseVisualStyleBackColor = false;
            this.btnRate2Select.Visible = false;
            this.btnRate2Select.Click += new System.EventHandler(this.btnRate2Select_Click);
            // 
            // btnPerimeter
            // 
            this.btnPerimeter.BackColor = System.Drawing.Color.AliceBlue;
            this.btnPerimeter.ContextMenuStrip = this.contextMenuArea;
            this.btnPerimeter.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerimeter.Image = ((System.Drawing.Image)(resources.GetObject("btnPerimeter.Image")));
            this.btnPerimeter.Location = new System.Drawing.Point(3, 338);
            this.btnPerimeter.Name = "btnPerimeter";
            this.btnPerimeter.Size = new System.Drawing.Size(100, 100);
            this.btnPerimeter.TabIndex = 108;
            this.btnPerimeter.Text = "000.00";
            this.btnPerimeter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPerimeter.UseVisualStyleBackColor = false;
            this.btnPerimeter.Click += new System.EventHandler(this.btnPerimeter_Click);
            // 
            // btnJob
            // 
            this.btnJob.BackColor = System.Drawing.Color.AliceBlue;
            this.btnJob.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnJob.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJob.Image = ((System.Drawing.Image)(resources.GetObject("btnJob.Image")));
            this.btnJob.Location = new System.Drawing.Point(3, 104);
            this.btnJob.Name = "btnJob";
            this.btnJob.Size = new System.Drawing.Size(100, 100);
            this.btnJob.TabIndex = 132;
            this.btnJob.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJob.UseVisualStyleBackColor = false;
            this.btnJob.Click += new System.EventHandler(this.btnJob_Click);
            // 
            // btnBoundaryMenu
            // 
            this.btnBoundaryMenu.BackColor = System.Drawing.Color.AliceBlue;
            this.btnBoundaryMenu.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnBoundaryMenu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoundaryMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnBoundaryMenu.Image")));
            this.btnBoundaryMenu.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBoundaryMenu.Location = new System.Drawing.Point(3, 221);
            this.btnBoundaryMenu.Name = "btnBoundaryMenu";
            this.btnBoundaryMenu.Size = new System.Drawing.Size(100, 100);
            this.btnBoundaryMenu.TabIndex = 140;
            this.btnBoundaryMenu.Text = "Bounds";
            this.btnBoundaryMenu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBoundaryMenu.UseVisualStyleBackColor = false;
            this.btnBoundaryMenu.Click += new System.EventHandler(this.btnBoundary_Click);
            // 
            // btnTiltUp
            // 
            this.btnTiltUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTiltUp.BackColor = System.Drawing.Color.AliceBlue;
            this.btnTiltUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTiltUp.BackgroundImage")));
            this.btnTiltUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTiltUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTiltUp.Location = new System.Drawing.Point(232, 655);
            this.btnTiltUp.Name = "btnTiltUp";
            this.btnTiltUp.Size = new System.Drawing.Size(63, 61);
            this.btnTiltUp.TabIndex = 123;
            this.btnTiltUp.UseVisualStyleBackColor = false;
            this.btnTiltUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTiltUp_MouseDown);
            // 
            // btnTiltDown
            // 
            this.btnTiltDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTiltDown.BackColor = System.Drawing.Color.AliceBlue;
            this.btnTiltDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTiltDown.BackgroundImage")));
            this.btnTiltDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTiltDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTiltDown.Location = new System.Drawing.Point(311, 655);
            this.btnTiltDown.Name = "btnTiltDown";
            this.btnTiltDown.Size = new System.Drawing.Size(63, 61);
            this.btnTiltDown.TabIndex = 122;
            this.btnTiltDown.UseVisualStyleBackColor = false;
            this.btnTiltDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTiltDown_MouseDown);
            // 
            // panelMenu3
            // 
            this.panelMenu3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu3.Controls.Add(this.btnSettings);
            this.panelMenu3.Controls.Add(this.btnAutoSteerConfig);
            this.panelMenu3.Controls.Add(this.btnComm);
            this.panelMenu3.Controls.Add(this.btnGPSData);
            this.panelMenu3.Location = new System.Drawing.Point(863, 228);
            this.panelMenu3.Name = "panelMenu3";
            this.panelMenu3.Size = new System.Drawing.Size(390, 355);
            this.panelMenu3.TabIndex = 142;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSettings.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Image = global::AgOpenGPS.Properties.Resources.Settings641;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSettings.Location = new System.Drawing.Point(37, 153);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(95, 100);
            this.btnSettings.TabIndex = 135;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click_1);
            // 
            // btnAutoSteerConfig
            // 
            this.btnAutoSteerConfig.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAutoSteerConfig.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnAutoSteerConfig.FlatAppearance.BorderSize = 2;
            this.btnAutoSteerConfig.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSteerConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoSteerConfig.Image")));
            this.btnAutoSteerConfig.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAutoSteerConfig.Location = new System.Drawing.Point(37, 21);
            this.btnAutoSteerConfig.Name = "btnAutoSteerConfig";
            this.btnAutoSteerConfig.Size = new System.Drawing.Size(95, 100);
            this.btnAutoSteerConfig.TabIndex = 139;
            this.btnAutoSteerConfig.Text = "Config";
            this.btnAutoSteerConfig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAutoSteerConfig.UseVisualStyleBackColor = false;
            this.btnAutoSteerConfig.Click += new System.EventHandler(this.btnAutoSteerConfig_Click);
            // 
            // btnComm
            // 
            this.btnComm.BackColor = System.Drawing.Color.AliceBlue;
            this.btnComm.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnComm.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComm.Image = ((System.Drawing.Image)(resources.GetObject("btnComm.Image")));
            this.btnComm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnComm.Location = new System.Drawing.Point(167, 21);
            this.btnComm.Name = "btnComm";
            this.btnComm.Size = new System.Drawing.Size(95, 100);
            this.btnComm.TabIndex = 136;
            this.btnComm.Text = "Ports";
            this.btnComm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnComm.UseVisualStyleBackColor = false;
            this.btnComm.Click += new System.EventHandler(this.btnComm_Click);
            // 
            // btnGPSData
            // 
            this.btnGPSData.BackColor = System.Drawing.Color.AliceBlue;
            this.btnGPSData.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnGPSData.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGPSData.Image = ((System.Drawing.Image)(resources.GetObject("btnGPSData.Image")));
            this.btnGPSData.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGPSData.Location = new System.Drawing.Point(167, 153);
            this.btnGPSData.Name = "btnGPSData";
            this.btnGPSData.Size = new System.Drawing.Size(95, 100);
            this.btnGPSData.TabIndex = 138;
            this.btnGPSData.Text = "GPS Data";
            this.btnGPSData.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGPSData.UseVisualStyleBackColor = false;
            this.btnGPSData.Click += new System.EventHandler(this.btnGPSData_Click);
            // 
            // btnFileExplorer
            // 
            this.btnFileExplorer.BackColor = System.Drawing.Color.AliceBlue;
            this.btnFileExplorer.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnFileExplorer.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileExplorer.Image = ((System.Drawing.Image)(resources.GetObject("btnFileExplorer.Image")));
            this.btnFileExplorer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFileExplorer.Location = new System.Drawing.Point(12, 52);
            this.btnFileExplorer.Name = "btnFileExplorer";
            this.btnFileExplorer.Size = new System.Drawing.Size(95, 100);
            this.btnFileExplorer.TabIndex = 141;
            this.btnFileExplorer.Text = "Files";
            this.btnFileExplorer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFileExplorer.UseVisualStyleBackColor = false;
            this.btnFileExplorer.Click += new System.EventHandler(this.btnFileExplorer_Click);
            // 
            // panelMenu2
            // 
            this.panelMenu2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu2.Controls.Add(this.btnFileExplorer);
            this.panelMenu2.Location = new System.Drawing.Point(975, 326);
            this.panelMenu2.Name = "panelMenu2";
            this.panelMenu2.Size = new System.Drawing.Size(384, 336);
            this.panelMenu2.TabIndex = 142;
            // 
            // lblSpeedUnits
            // 
            this.lblSpeedUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpeedUnits.AutoSize = true;
            this.lblSpeedUnits.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblSpeedUnits.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeedUnits.Location = new System.Drawing.Point(873, 18);
            this.lblSpeedUnits.Name = "lblSpeedUnits";
            this.lblSpeedUnits.Size = new System.Drawing.Size(38, 17);
            this.lblSpeedUnits.TabIndex = 139;
            this.lblSpeedUnits.Text = "kmh";
            this.lblSpeedUnits.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // statusStrip2
            // 
            this.statusStrip2.AutoSize = false;
            this.statusStrip2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.statusStrip2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.strip2Roll,
            this.toolStripStatusLabel2,
            this.strip2PureSteerAngle,
            this.strip2GPSLabel,
            this.strip2GPSHeading,
            this.strip2GyroHeading,
            this.strip2TurnProgressBar,
            this.toolStripStatusLabel1,
            this.strip2BoundaryDistanceAway,
            this.toolStripStatusLabelBoundaryArea});
            this.statusStrip2.Location = new System.Drawing.Point(0, 731);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip2.Size = new System.Drawing.Size(1346, 38);
            this.statusStrip2.TabIndex = 147;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.AutoSize = false;
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel4.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel4.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(52, 38);
            this.toolStripStatusLabel4.Text = "Roll:";
            this.toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // strip2Roll
            // 
            this.strip2Roll.AutoSize = false;
            this.strip2Roll.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strip2Roll.Margin = new System.Windows.Forms.Padding(-4, 0, 0, 0);
            this.strip2Roll.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.strip2Roll.Name = "strip2Roll";
            this.strip2Roll.Size = new System.Drawing.Size(60, 38);
            this.strip2Roll.Text = "Roll";
            this.strip2Roll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel2.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(25, 38);
            this.toolStripStatusLabel2.Text = "§:";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // strip2PureSteerAngle
            // 
            this.strip2PureSteerAngle.AutoSize = false;
            this.strip2PureSteerAngle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strip2PureSteerAngle.Margin = new System.Windows.Forms.Padding(-4, 0, 0, 0);
            this.strip2PureSteerAngle.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.strip2PureSteerAngle.Name = "strip2PureSteerAngle";
            this.strip2PureSteerAngle.Size = new System.Drawing.Size(90, 38);
            this.strip2PureSteerAngle.Text = "SteerAng";
            this.strip2PureSteerAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // strip2GPSLabel
            // 
            this.strip2GPSLabel.AutoSize = false;
            this.strip2GPSLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strip2GPSLabel.Margin = new System.Windows.Forms.Padding(0);
            this.strip2GPSLabel.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.strip2GPSLabel.Name = "strip2GPSLabel";
            this.strip2GPSLabel.Size = new System.Drawing.Size(55, 38);
            this.strip2GPSLabel.Text = "GPS:";
            this.strip2GPSLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // strip2GPSHeading
            // 
            this.strip2GPSHeading.AutoSize = false;
            this.strip2GPSHeading.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strip2GPSHeading.Margin = new System.Windows.Forms.Padding(-4, 0, 0, 0);
            this.strip2GPSHeading.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.strip2GPSHeading.Name = "strip2GPSHeading";
            this.strip2GPSHeading.Size = new System.Drawing.Size(90, 38);
            this.strip2GPSHeading.Text = "GPS";
            this.strip2GPSHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // strip2GyroHeading
            // 
            this.strip2GyroHeading.AutoSize = false;
            this.strip2GyroHeading.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strip2GyroHeading.Margin = new System.Windows.Forms.Padding(0);
            this.strip2GyroHeading.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.strip2GyroHeading.Name = "strip2GyroHeading";
            this.strip2GyroHeading.Size = new System.Drawing.Size(90, 38);
            this.strip2GyroHeading.Text = "GYR";
            // 
            // strip2TurnProgressBar
            // 
            this.strip2TurnProgressBar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.strip2TurnProgressBar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strip2TurnProgressBar.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.strip2TurnProgressBar.Margin = new System.Windows.Forms.Padding(1);
            this.strip2TurnProgressBar.MarqueeAnimationSpeed = 300;
            this.strip2TurnProgressBar.Name = "strip2TurnProgressBar";
            this.strip2TurnProgressBar.Size = new System.Drawing.Size(200, 36);
            this.strip2TurnProgressBar.ToolTipText = "When";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(469, 38);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "-";
            // 
            // strip2BoundaryDistanceAway
            // 
            this.strip2BoundaryDistanceAway.AutoSize = false;
            this.strip2BoundaryDistanceAway.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strip2BoundaryDistanceAway.Margin = new System.Windows.Forms.Padding(0);
            this.strip2BoundaryDistanceAway.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.strip2BoundaryDistanceAway.Name = "strip2BoundaryDistanceAway";
            this.strip2BoundaryDistanceAway.Size = new System.Drawing.Size(90, 38);
            this.strip2BoundaryDistanceAway.Text = "Away";
            this.strip2BoundaryDistanceAway.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabelBoundaryArea
            // 
            this.toolStripStatusLabelBoundaryArea.AutoSize = false;
            this.toolStripStatusLabelBoundaryArea.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelBoundaryArea.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabelBoundaryArea.Name = "toolStripStatusLabelBoundaryArea";
            this.toolStripStatusLabelBoundaryArea.Size = new System.Drawing.Size(120, 38);
            this.toolStripStatusLabelBoundaryArea.Text = "Bnd Area";
            this.toolStripStatusLabelBoundaryArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabelBoundaryArea.ToolTipText = "Area Per Hour";
            // 
            // lblHeading
            // 
            this.lblHeading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeading.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblHeading.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(921, 3);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(130, 40);
            this.lblHeading.TabIndex = 117;
            this.lblHeading.Text = "359.8.";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ComPorts.png");
            this.imageList1.Images.SetKeyName(1, "AcHa.png");
            // 
            // btnMenu3
            // 
            this.btnMenu3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu3.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnMenu3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu3.Image = global::AgOpenGPS.Properties.Resources.SettingsGear64;
            this.btnMenu3.Location = new System.Drawing.Point(1155, 46);
            this.btnMenu3.Name = "btnMenu3";
            this.btnMenu3.Size = new System.Drawing.Size(92, 70);
            this.btnMenu3.TabIndex = 150;
            this.btnMenu3.UseVisualStyleBackColor = true;
            this.btnMenu3.Click += new System.EventHandler(this.btnMenu3_Click);
            // 
            // btnMenu2
            // 
            this.btnMenu2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnMenu2.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnMenu2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu2.Image = global::AgOpenGPS.Properties.Resources.Menu5;
            this.btnMenu2.Location = new System.Drawing.Point(1055, 46);
            this.btnMenu2.Name = "btnMenu2";
            this.btnMenu2.Size = new System.Drawing.Size(92, 70);
            this.btnMenu2.TabIndex = 149;
            this.btnMenu2.UseVisualStyleBackColor = false;
            this.btnMenu2.Click += new System.EventHandler(this.btnMenu2_Click);
            // 
            // btnMenu1
            // 
            this.btnMenu1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu1.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnMenu1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu1.Image = global::AgOpenGPS.Properties.Resources.Rate64;
            this.btnMenu1.Location = new System.Drawing.Point(955, 46);
            this.btnMenu1.Name = "btnMenu1";
            this.btnMenu1.Size = new System.Drawing.Size(92, 70);
            this.btnMenu1.TabIndex = 148;
            this.btnMenu1.UseVisualStyleBackColor = true;
            this.btnMenu1.Click += new System.EventHandler(this.btnMenu1_Click);
            // 
            // btnRightYouTurn
            // 
            this.btnRightYouTurn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRightYouTurn.BackColor = System.Drawing.Color.AliceBlue;
            this.btnRightYouTurn.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnRightYouTurn.Enabled = false;
            this.btnRightYouTurn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightYouTurn.Image = global::AgOpenGPS.Properties.Resources.ArrowRight;
            this.btnRightYouTurn.Location = new System.Drawing.Point(534, 181);
            this.btnRightYouTurn.Name = "btnRightYouTurn";
            this.btnRightYouTurn.Size = new System.Drawing.Size(80, 80);
            this.btnRightYouTurn.TabIndex = 142;
            this.btnRightYouTurn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRightYouTurn.UseVisualStyleBackColor = false;
            this.btnRightYouTurn.Click += new System.EventHandler(this.btnRightYouTurn_Click);
            // 
            // btnLeftYouTurn
            // 
            this.btnLeftYouTurn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLeftYouTurn.BackColor = System.Drawing.Color.AliceBlue;
            this.btnLeftYouTurn.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnLeftYouTurn.Enabled = false;
            this.btnLeftYouTurn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftYouTurn.Image = global::AgOpenGPS.Properties.Resources.ArrowLeft;
            this.btnLeftYouTurn.Location = new System.Drawing.Point(225, 181);
            this.btnLeftYouTurn.Name = "btnLeftYouTurn";
            this.btnLeftYouTurn.Size = new System.Drawing.Size(80, 80);
            this.btnLeftYouTurn.TabIndex = 143;
            this.btnLeftYouTurn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLeftYouTurn.UseVisualStyleBackColor = false;
            this.btnLeftYouTurn.Click += new System.EventHandler(this.btnLeftYouTurn_Click);
            // 
            // btnSection8Man
            // 
            this.btnSection8Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection8Man.BackColor = System.Drawing.SystemColors.Control;
            this.btnSection8Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection8Man.Enabled = false;
            this.btnSection8Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection8Man.FlatAppearance.BorderSize = 0;
            this.btnSection8Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection8Man.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection8Man.Image = ((System.Drawing.Image)(resources.GetObject("btnSection8Man.Image")));
            this.btnSection8Man.Location = new System.Drawing.Point(375, 416);
            this.btnSection8Man.Name = "btnSection8Man";
            this.btnSection8Man.Size = new System.Drawing.Size(69, 45);
            this.btnSection8Man.TabIndex = 125;
            this.btnSection8Man.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSection8Man.UseVisualStyleBackColor = false;
            this.btnSection8Man.Click += new System.EventHandler(this.btnSection8Man_Click);
            // 
            // btnSection7Man
            // 
            this.btnSection7Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection7Man.BackColor = System.Drawing.SystemColors.Control;
            this.btnSection7Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection7Man.Enabled = false;
            this.btnSection7Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection7Man.FlatAppearance.BorderSize = 0;
            this.btnSection7Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection7Man.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection7Man.Image = ((System.Drawing.Image)(resources.GetObject("btnSection7Man.Image")));
            this.btnSection7Man.Location = new System.Drawing.Point(365, 404);
            this.btnSection7Man.Name = "btnSection7Man";
            this.btnSection7Man.Size = new System.Drawing.Size(69, 45);
            this.btnSection7Man.TabIndex = 126;
            this.btnSection7Man.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSection7Man.UseVisualStyleBackColor = false;
            this.btnSection7Man.Click += new System.EventHandler(this.btnSection7Man_Click);
            // 
            // btnSection6Man
            // 
            this.btnSection6Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection6Man.BackColor = System.Drawing.SystemColors.Control;
            this.btnSection6Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection6Man.Enabled = false;
            this.btnSection6Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection6Man.FlatAppearance.BorderSize = 0;
            this.btnSection6Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection6Man.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection6Man.Image = ((System.Drawing.Image)(resources.GetObject("btnSection6Man.Image")));
            this.btnSection6Man.Location = new System.Drawing.Point(355, 391);
            this.btnSection6Man.Name = "btnSection6Man";
            this.btnSection6Man.Size = new System.Drawing.Size(69, 45);
            this.btnSection6Man.TabIndex = 127;
            this.btnSection6Man.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSection6Man.UseVisualStyleBackColor = false;
            this.btnSection6Man.Click += new System.EventHandler(this.btnSection6Man_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomIn.BackColor = System.Drawing.Color.AliceBlue;
            this.btnZoomIn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.BackgroundImage")));
            this.btnZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomIn.Location = new System.Drawing.Point(476, 655);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(63, 61);
            this.btnZoomIn.TabIndex = 120;
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZoomIn_MouseDown);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomOut.BackColor = System.Drawing.Color.AliceBlue;
            this.btnZoomOut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.BackgroundImage")));
            this.btnZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomOut.Location = new System.Drawing.Point(553, 655);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(63, 61);
            this.btnZoomOut.TabIndex = 119;
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZoomOut_MouseDown);
            // 
            // btnContour
            // 
            this.btnContour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContour.BackColor = System.Drawing.Color.AliceBlue;
            this.btnContour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnContour.Enabled = false;
            this.btnContour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContour.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContour.Image = ((System.Drawing.Image)(resources.GetObject("btnContour.Image")));
            this.btnContour.Location = new System.Drawing.Point(735, 217);
            this.btnContour.Name = "btnContour";
            this.btnContour.Size = new System.Drawing.Size(105, 105);
            this.btnContour.TabIndex = 105;
            this.btnContour.Text = "Contour";
            this.btnContour.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnContour.UseVisualStyleBackColor = false;
            this.btnContour.Click += new System.EventHandler(this.btnContour_Click);
            // 
            // btnSection5Man
            // 
            this.btnSection5Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection5Man.BackColor = System.Drawing.SystemColors.Control;
            this.btnSection5Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection5Man.Enabled = false;
            this.btnSection5Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection5Man.FlatAppearance.BorderSize = 0;
            this.btnSection5Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection5Man.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection5Man.Image = ((System.Drawing.Image)(resources.GetObject("btnSection5Man.Image")));
            this.btnSection5Man.Location = new System.Drawing.Point(346, 378);
            this.btnSection5Man.Name = "btnSection5Man";
            this.btnSection5Man.Size = new System.Drawing.Size(69, 45);
            this.btnSection5Man.TabIndex = 103;
            this.btnSection5Man.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSection5Man.UseVisualStyleBackColor = false;
            this.btnSection5Man.Click += new System.EventHandler(this.btnSection5Man_Click);
            // 
            // btnSection4Man
            // 
            this.btnSection4Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection4Man.BackColor = System.Drawing.SystemColors.Control;
            this.btnSection4Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection4Man.Enabled = false;
            this.btnSection4Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection4Man.FlatAppearance.BorderSize = 0;
            this.btnSection4Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection4Man.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection4Man.Image = ((System.Drawing.Image)(resources.GetObject("btnSection4Man.Image")));
            this.btnSection4Man.Location = new System.Drawing.Point(271, 404);
            this.btnSection4Man.Name = "btnSection4Man";
            this.btnSection4Man.Size = new System.Drawing.Size(69, 45);
            this.btnSection4Man.TabIndex = 102;
            this.btnSection4Man.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSection4Man.UseVisualStyleBackColor = false;
            this.btnSection4Man.Click += new System.EventHandler(this.btnSection4Man_Click);
            // 
            // btnSection3Man
            // 
            this.btnSection3Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection3Man.BackColor = System.Drawing.SystemColors.Control;
            this.btnSection3Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection3Man.Enabled = false;
            this.btnSection3Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection3Man.FlatAppearance.BorderSize = 0;
            this.btnSection3Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection3Man.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection3Man.Image = ((System.Drawing.Image)(resources.GetObject("btnSection3Man.Image")));
            this.btnSection3Man.Location = new System.Drawing.Point(261, 391);
            this.btnSection3Man.Name = "btnSection3Man";
            this.btnSection3Man.Size = new System.Drawing.Size(69, 45);
            this.btnSection3Man.TabIndex = 101;
            this.btnSection3Man.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSection3Man.UseVisualStyleBackColor = false;
            this.btnSection3Man.Click += new System.EventHandler(this.btnSection3Man_Click);
            // 
            // btnSection2Man
            // 
            this.btnSection2Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection2Man.BackColor = System.Drawing.SystemColors.Control;
            this.btnSection2Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection2Man.Enabled = false;
            this.btnSection2Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection2Man.FlatAppearance.BorderSize = 0;
            this.btnSection2Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection2Man.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection2Man.Image = ((System.Drawing.Image)(resources.GetObject("btnSection2Man.Image")));
            this.btnSection2Man.Location = new System.Drawing.Point(252, 378);
            this.btnSection2Man.Name = "btnSection2Man";
            this.btnSection2Man.Size = new System.Drawing.Size(69, 45);
            this.btnSection2Man.TabIndex = 100;
            this.btnSection2Man.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSection2Man.UseVisualStyleBackColor = false;
            this.btnSection2Man.Click += new System.EventHandler(this.btnSection2Man_Click);
            // 
            // btnSection1Man
            // 
            this.btnSection1Man.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSection1Man.BackColor = System.Drawing.SystemColors.Control;
            this.btnSection1Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection1Man.Enabled = false;
            this.btnSection1Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection1Man.FlatAppearance.BorderSize = 0;
            this.btnSection1Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection1Man.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection1Man.Image = ((System.Drawing.Image)(resources.GetObject("btnSection1Man.Image")));
            this.btnSection1Man.Location = new System.Drawing.Point(241, 365);
            this.btnSection1Man.Name = "btnSection1Man";
            this.btnSection1Man.Size = new System.Drawing.Size(69, 45);
            this.btnSection1Man.TabIndex = 99;
            this.btnSection1Man.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSection1Man.UseVisualStyleBackColor = false;
            this.btnSection1Man.Click += new System.EventHandler(this.btnSection1Man_Click);
            // 
            // btnManualOffOn
            // 
            this.btnManualOffOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManualOffOn.BackColor = System.Drawing.Color.AliceBlue;
            this.btnManualOffOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnManualOffOn.Enabled = false;
            this.btnManualOffOn.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnManualOffOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManualOffOn.Image = global::AgOpenGPS.Properties.Resources.ManualOff;
            this.btnManualOffOn.Location = new System.Drawing.Point(735, 333);
            this.btnManualOffOn.Name = "btnManualOffOn";
            this.btnManualOffOn.Size = new System.Drawing.Size(105, 105);
            this.btnManualOffOn.TabIndex = 98;
            this.btnManualOffOn.UseVisualStyleBackColor = false;
            this.btnManualOffOn.Click += new System.EventHandler(this.btnManualOffOn_Click);
            // 
            // btnABLine
            // 
            this.btnABLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnABLine.BackColor = System.Drawing.Color.AliceBlue;
            this.btnABLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnABLine.Enabled = false;
            this.btnABLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnABLine.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnABLine.Image = ((System.Drawing.Image)(resources.GetObject("btnABLine.Image")));
            this.btnABLine.Location = new System.Drawing.Point(735, 103);
            this.btnABLine.Name = "btnABLine";
            this.btnABLine.Size = new System.Drawing.Size(105, 105);
            this.btnABLine.TabIndex = 0;
            this.btnABLine.Text = "0";
            this.btnABLine.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnABLine.UseVisualStyleBackColor = false;
            this.btnABLine.Click += new System.EventHandler(this.btnABLine_Click);
            // 
            // btnMinMaxZoom
            // 
            this.btnMinMaxZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMinMaxZoom.BackColor = System.Drawing.Color.AliceBlue;
            this.btnMinMaxZoom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinMaxZoom.Image = ((System.Drawing.Image)(resources.GetObject("btnMinMaxZoom.Image")));
            this.btnMinMaxZoom.Location = new System.Drawing.Point(1, 631);
            this.btnMinMaxZoom.Name = "btnMinMaxZoom";
            this.btnMinMaxZoom.Size = new System.Drawing.Size(100, 100);
            this.btnMinMaxZoom.TabIndex = 92;
            this.btnMinMaxZoom.UseVisualStyleBackColor = false;
            this.btnMinMaxZoom.Click += new System.EventHandler(this.btnMinMax_Click);
            // 
            // btnAutoSteer
            // 
            this.btnAutoSteer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoSteer.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAutoSteer.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnAutoSteer.Enabled = false;
            this.btnAutoSteer.Font = new System.Drawing.Font("Segoe UI Symbol", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSteer.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoSteer.Image")));
            this.btnAutoSteer.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAutoSteer.Location = new System.Drawing.Point(746, 631);
            this.btnAutoSteer.Name = "btnAutoSteer";
            this.btnAutoSteer.Size = new System.Drawing.Size(100, 100);
            this.btnAutoSteer.TabIndex = 128;
            this.btnAutoSteer.Text = "x";
            this.btnAutoSteer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAutoSteer.UseVisualStyleBackColor = false;
            this.btnAutoSteer.Click += new System.EventHandler(this.btnAutoSteer_Click);
            // 
            // btnSnap
            // 
            this.btnSnap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSnap.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSnap.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnSnap.Enabled = false;
            this.btnSnap.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnap.Image = ((System.Drawing.Image)(resources.GetObject("btnSnap.Image")));
            this.btnSnap.Location = new System.Drawing.Point(632, 631);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(100, 100);
            this.btnSnap.TabIndex = 133;
            this.btnSnap.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSnap.UseVisualStyleBackColor = false;
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // btnAutoYouTurn
            // 
            this.btnAutoYouTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAutoYouTurn.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAutoYouTurn.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnAutoYouTurn.Enabled = false;
            this.btnAutoYouTurn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoYouTurn.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoYouTurn.Image")));
            this.btnAutoYouTurn.Location = new System.Drawing.Point(115, 631);
            this.btnAutoYouTurn.Name = "btnAutoYouTurn";
            this.btnAutoYouTurn.Size = new System.Drawing.Size(100, 100);
            this.btnAutoYouTurn.TabIndex = 142;
            this.btnAutoYouTurn.Text = "Off";
            this.btnAutoYouTurn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAutoYouTurn.UseVisualStyleBackColor = false;
            this.btnAutoYouTurn.Click += new System.EventHandler(this.btnAutoYouTurn_Click);
            // 
            // btnFlag
            // 
            this.btnFlag.BackColor = System.Drawing.Color.AliceBlue;
            this.btnFlag.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnFlag.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFlag.Image = ((System.Drawing.Image)(resources.GetObject("btnFlag.Image")));
            this.btnFlag.Location = new System.Drawing.Point(3, 455);
            this.btnFlag.Name = "btnFlag";
            this.btnFlag.Size = new System.Drawing.Size(100, 88);
            this.btnFlag.TabIndex = 121;
            this.btnFlag.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFlag.UseVisualStyleBackColor = false;
            this.btnFlag.Click += new System.EventHandler(this.btnFlag_Click);
            // 
            // btnSectionOffAutoOn
            // 
            this.btnSectionOffAutoOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSectionOffAutoOn.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSectionOffAutoOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSectionOffAutoOn.Enabled = false;
            this.btnSectionOffAutoOn.Font = new System.Drawing.Font("Arial Narrow", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSectionOffAutoOn.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;
            this.btnSectionOffAutoOn.Location = new System.Drawing.Point(716, 455);
            this.btnSectionOffAutoOn.Name = "btnSectionOffAutoOn";
            this.btnSectionOffAutoOn.Size = new System.Drawing.Size(123, 114);
            this.btnSectionOffAutoOn.TabIndex = 152;
            this.btnSectionOffAutoOn.Text = "888.88";
            this.btnSectionOffAutoOn.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSectionOffAutoOn.UseVisualStyleBackColor = false;
            this.btnSectionOffAutoOn.Click += new System.EventHandler(this.btnSectionOffAutoOn_Click);
            // 
            // btnMenu4
            // 
            this.btnMenu4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnMenu4.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnMenu4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu4.Image = global::AgOpenGPS.Properties.Resources.RunMan64;
            this.btnMenu4.Location = new System.Drawing.Point(1255, 46);
            this.btnMenu4.Name = "btnMenu4";
            this.btnMenu4.Size = new System.Drawing.Size(92, 70);
            this.btnMenu4.TabIndex = 157;
            this.btnMenu4.UseVisualStyleBackColor = false;
            this.btnMenu4.Click += new System.EventHandler(this.btnMenu4_Click);
            // 
            // panelMenu4
            // 
            this.panelMenu4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu4.Controls.Add(this.openGLControlZoom);
            this.panelMenu4.Location = new System.Drawing.Point(890, 181);
            this.panelMenu4.Name = "panelMenu4";
            this.panelMenu4.Size = new System.Drawing.Size(316, 375);
            this.panelMenu4.TabIndex = 143;
            // 
            // openGLControlZoom
            // 
            this.openGLControlZoom.DrawFPS = false;
            this.openGLControlZoom.Location = new System.Drawing.Point(5, 5);
            this.openGLControlZoom.Name = "openGLControlZoom";
            this.openGLControlZoom.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControlZoom.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLControlZoom.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControlZoom.Size = new System.Drawing.Size(490, 490);
            this.openGLControlZoom.TabIndex = 0;
            this.openGLControlZoom.OpenGLInitialized += new System.EventHandler(this.openGLControlZoom_OpenGLInitialized);
            this.openGLControlZoom.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControlZoom_OpenGLDraw);
            this.openGLControlZoom.Resized += new System.EventHandler(this.openGLControlZoom_Resized);
            // 
            // FormGPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1346, 807);
            this.Controls.Add(this.panelMenu1);
            this.Controls.Add(this.lblSpeedUnits);
            this.Controls.Add(this.panelMenu4);
            this.Controls.Add(this.btnMenu4);
            this.Controls.Add(this.btnSectionOffAutoOn);
            this.Controls.Add(this.btnPerimeter);
            this.Controls.Add(this.btnFlag);
            this.Controls.Add(this.btnBoundaryMenu);
            this.Controls.Add(this.btnAutoYouTurn);
            this.Controls.Add(this.btnJob);
            this.Controls.Add(this.btnTiltDown);
            this.Controls.Add(this.btnMinMaxZoom);
            this.Controls.Add(this.btnTiltUp);
            this.Controls.Add(this.btnSnap);
            this.Controls.Add(this.btnAutoSteer);
            this.Controls.Add(this.panelMenu2);
            this.Controls.Add(this.panelMenu3);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.btnMenu3);
            this.Controls.Add(this.btnMenu2);
            this.Controls.Add(this.btnMenu1);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.btnRightYouTurn);
            this.Controls.Add(this.btnLeftYouTurn);
            this.Controls.Add(this.txtDistanceOffABLine);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.lblZone);
            this.Controls.Add(this.tboxSentence);
            this.Controls.Add(this.btnSection8Man);
            this.Controls.Add(this.btnSection7Man);
            this.Controls.Add(this.btnSection6Man);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.lblEasting);
            this.Controls.Add(this.lblNorthing);
            this.Controls.Add(this.btnContour);
            this.Controls.Add(this.btnSection5Man);
            this.Controls.Add(this.btnSection4Man);
            this.Controls.Add(this.btnSection3Man);
            this.Controls.Add(this.btnSection2Man);
            this.Controls.Add(this.btnSection1Man);
            this.Controls.Add(this.btnManualOffOn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnABLine);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.openGLControl);
            this.Controls.Add(this.openGLControlBack);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "FormGPS";
            this.Text = "AgOpenGPS - Cuz Retail Sucks";
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
            this.panelMenu1.ResumeLayout(false);
            this.panelMenu1.PerformLayout();
            this.panelMenu3.ResumeLayout(false);
            this.panelMenu2.ResumeLayout(false);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.panelMenu4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.Button btnABLine;
        private System.Windows.Forms.TextBox txtDistanceOffABLine;
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
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem explorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webCamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fieldViewerToolStripMenuItem;
        private System.Windows.Forms.Label lblNorthing;
        private System.Windows.Forms.Label lblEasting;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.ToolStripMenuItem googleEarthToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem communicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem gPSDataToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem variablesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar stripOnlineGPS;
        private System.Windows.Forms.ToolStripProgressBar stripOnlineArduino;
        private System.Windows.Forms.ToolStripSplitButton toolStripBtnResetDistance;
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
        private System.Windows.Forms.Button btnJob;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.TextBox tboxSentence;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.Panel panelMenu1;
        private System.Windows.Forms.Button btnAutoSteerConfig;
        private System.Windows.Forms.Button btnGPSData;
        private System.Windows.Forms.Button btnComm;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnBoundaryMenu;
        private System.Windows.Forms.Button btnFileExplorer;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuHelpHelp;
        private System.Windows.Forms.Label lblSpeedUnits;
        private System.Windows.Forms.ToolStripMenuItem sideGuideLines;
        private System.Windows.Forms.ToolStripMenuItem pursuitLineToolStripMenuItem;
        private System.Windows.Forms.Button btnRightYouTurn;
        private System.Windows.Forms.Button btnLeftYouTurn;
        private System.Windows.Forms.Button btnRate;
        private System.Windows.Forms.Button btnRate1Select;
        private System.Windows.Forms.Button btnRate2Select;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel strip2PureSteerAngle;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.ToolStripStatusLabel strip2Roll;
        private System.Windows.Forms.ToolStripStatusLabel strip2BoundaryDistanceAway;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel strip2GPSLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel stripEqWidth;
        private System.Windows.Forms.ToolStripProgressBar strip2TurnProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel strip2GPSHeading;
        private System.Windows.Forms.ToolStripStatusLabel strip2GyroHeading;
        private System.Windows.Forms.ToolStripStatusLabel stripAreaUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelBoundaryArea;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnMenu1;
        private System.Windows.Forms.Button btnMenu2;
        private System.Windows.Forms.Panel panelMenu2;
        private System.Windows.Forms.Button btnMenu3;
        private System.Windows.Forms.Panel panelMenu3;
        private System.Windows.Forms.Label lblAccumulatedVolume;
        private System.Windows.Forms.Label lblRateAppliedActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMinMaxZoom;
        private System.Windows.Forms.Button btnAutoSteer;
        private System.Windows.Forms.Button btnSnap;
        private System.Windows.Forms.Button btnAutoYouTurn;
        private System.Windows.Forms.Button btnFlag;
        private System.Windows.Forms.Button btnSectionOffAutoOn;
        private ProXoft.WinForms.RepeatButton btnRateDn;
        private ProXoft.WinForms.RepeatButton btnRateUp;
        private System.Windows.Forms.Button btnMenu4;
        private System.Windows.Forms.Panel panelMenu4;
        private SharpGL.OpenGLControl openGLControlZoom;
    }
}

