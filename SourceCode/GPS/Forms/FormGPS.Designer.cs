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
            this.googleEarthOpenGLContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.menustripLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageDanish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageDeutsch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageSpanish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageFrench = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageItalian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageLatvian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageLithuanian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageHungarian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageDutch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguagePolish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageRussian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageFinnish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageSlovak = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageUkranian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageTurkish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.setWorkingDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.colorsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sectionColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.topFieldViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.enterSimCoordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.simulatorOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetEverythingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrWatchdog = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripFlag = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemFlagRed = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFlagGrn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFlagYel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuFlagForm = new System.Windows.Forms.ToolStripMenuItem();
            this.cboxpRowWidth = new System.Windows.Forms.ComboBox();
            this.oglZoom = new OpenTK.GLControl();
            this.btnResetSim = new System.Windows.Forms.Button();
            this.btnResetSteerAngle = new System.Windows.Forms.Button();
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
            this.panelRight = new System.Windows.Forms.TableLayoutPanel();
            this.btnGuidance = new System.Windows.Forms.Button();
            this.btnContour = new System.Windows.Forms.Button();
            this.btnAutoSteer = new System.Windows.Forms.Button();
            this.btnSectionMasterAuto = new System.Windows.Forms.Button();
            this.btnSectionMasterManual = new System.Windows.Forms.Button();
            this.btnEditAB = new System.Windows.Forms.Button();
            this.panelSim = new System.Windows.Forms.TableLayoutPanel();
            this.btnSimForward = new System.Windows.Forms.Button();
            this.btnSimSetSpeedToZero = new System.Windows.Forms.Button();
            this.btnSimReverse = new System.Windows.Forms.Button();
            this.btnSection16Man = new System.Windows.Forms.Button();
            this.btnSection15Man = new System.Windows.Forms.Button();
            this.btnSection14Man = new System.Windows.Forms.Button();
            this.btnSection13Man = new System.Windows.Forms.Button();
            this.panelNavigation = new System.Windows.Forms.TableLayoutPanel();
            this.btnN3D = new System.Windows.Forms.Button();
            this.btnBrightnessDn = new System.Windows.Forms.Button();
            this.btnBrightnessUp = new System.Windows.Forms.Button();
            this.btnDayNightMode = new System.Windows.Forms.Button();
            this.btnpTiltUp = new ProXoft.WinForms.RepeatButton();
            this.btnpTiltDown = new ProXoft.WinForms.RepeatButton();
            this.btnN2D = new System.Windows.Forms.Button();
            this.btn3D = new System.Windows.Forms.Button();
            this.btn2D = new System.Windows.Forms.Button();
            this.lblFieldStatus = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panelAB = new System.Windows.Forms.TableLayoutPanel();
            this.btnTramDisplayMode = new System.Windows.Forms.Button();
            this.btnHydLift = new System.Windows.Forms.Button();
            this.btnHeadlandOnOff = new System.Windows.Forms.Button();
            this.btnAutoYouTurn = new System.Windows.Forms.Button();
            this.btnResetToolHeading = new System.Windows.Forms.Button();
            this.btnChangeMappingColor = new System.Windows.Forms.Button();
            this.btnFlag = new System.Windows.Forms.Button();
            this.btnYouSkipEnable = new System.Windows.Forms.Button();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblInty = new System.Windows.Forms.Label();
            this.lblCurveLineName = new System.Windows.Forms.Label();
            this.lblCurrentField = new System.Windows.Forms.Label();
            this.lblFix = new System.Windows.Forms.Label();
            this.btnZone1 = new System.Windows.Forms.Button();
            this.btnZone2 = new System.Windows.Forms.Button();
            this.btnZone3 = new System.Windows.Forms.Button();
            this.btnZone4 = new System.Windows.Forms.Button();
            this.btnZone5 = new System.Windows.Forms.Button();
            this.btnZone6 = new System.Windows.Forms.Button();
            this.btnZone7 = new System.Windows.Forms.Button();
            this.btnZone8 = new System.Windows.Forms.Button();
            this.tlpTrackMethods = new System.Windows.Forms.TableLayoutPanel();
            this.cboxAutoTrack = new System.Windows.Forms.CheckBox();
            this.cboxAutoSnapToPivot = new System.Windows.Forms.CheckBox();
            this.btnTrackCreateEdit = new System.Windows.Forms.Button();
            this.btnABDraw = new System.Windows.Forms.Button();
            this.timerLineAdj = new System.Windows.Forms.Timer(this.components);
            this.btnMaximizeMainForm = new System.Windows.Forms.Button();
            this.pictureboxStart = new System.Windows.Forms.PictureBox();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnMinimizeMainForm = new System.Windows.Forms.Button();
            this.contextMenuStripOpenGL.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripFlag.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelSim.SuspendLayout();
            this.panelNavigation.SuspendLayout();
            this.panelAB.SuspendLayout();
            this.tlpTrackMethods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxStart)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripOpenGL
            // 
            resources.ApplyResources(this.contextMenuStripOpenGL, "contextMenuStripOpenGL");
            this.contextMenuStripOpenGL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.googleEarthOpenGLContextMenu});
            this.contextMenuStripOpenGL.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.contextMenuStripOpenGL.Name = "contextMenuStripOpenGL";
            this.contextMenuStripOpenGL.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripOpenGL_Opening);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // googleEarthOpenGLContextMenu
            // 
            resources.ApplyResources(this.googleEarthOpenGLContextMenu, "googleEarthOpenGLContextMenu");
            this.googleEarthOpenGLContextMenu.Image = global::AgOpenGPS.Properties.Resources.GoogleEarth;
            this.googleEarthOpenGLContextMenu.Name = "googleEarthOpenGLContextMenu";
            this.googleEarthOpenGLContextMenu.Click += new System.EventHandler(this.googleEarthOpenGLContextMenu_Click);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator9,
            this.menustripLanguage,
            this.toolStripSeparator11,
            this.setWorkingDirectoryToolStripMenuItem,
            this.toolStripSeparator10,
            this.colorsToolStripMenuItem1,
            this.sectionColorToolStripMenuItem,
            this.toolStripSeparator8,
            this.topFieldViewToolStripMenuItem,
            this.toolStripSeparator3,
            this.enterSimCoordsToolStripMenuItem,
            this.toolStripSeparator4,
            this.simulatorOnToolStripMenuItem,
            this.resetALLToolStripMenuItem,
            this.hotKeysToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.helpMenuItem});
            this.fileToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.fileMenu;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // menustripLanguage
            // 
            this.menustripLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLanguageDanish,
            this.menuLanguageDeutsch,
            this.menuLanguageEnglish,
            this.menuLanguageSpanish,
            this.menuLanguageFrench,
            this.menuLanguageItalian,
            this.menuLanguageLatvian,
            this.menuLanguageLithuanian,
            this.menuLanguageHungarian,
            this.menuLanguageDutch,
            this.menuLanguagePolish,
            this.menuLanguageRussian,
            this.menuLanguageFinnish,
            this.menuLanguageSlovak,
            this.menuLanguageUkranian,
            this.menuLanguageTurkish,
            this.menuLanguageTest});
            this.menustripLanguage.Name = "menustripLanguage";
            resources.ApplyResources(this.menustripLanguage, "menustripLanguage");
            // 
            // menuLanguageDanish
            // 
            this.menuLanguageDanish.Name = "menuLanguageDanish";
            resources.ApplyResources(this.menuLanguageDanish, "menuLanguageDanish");
            this.menuLanguageDanish.Click += new System.EventHandler(this.menuLanguageDanish_Click);
            // 
            // menuLanguageDeutsch
            // 
            this.menuLanguageDeutsch.CheckOnClick = true;
            this.menuLanguageDeutsch.Name = "menuLanguageDeutsch";
            resources.ApplyResources(this.menuLanguageDeutsch, "menuLanguageDeutsch");
            this.menuLanguageDeutsch.Click += new System.EventHandler(this.menuLanguageDeutsch_Click);
            // 
            // menuLanguageEnglish
            // 
            this.menuLanguageEnglish.CheckOnClick = true;
            this.menuLanguageEnglish.Name = "menuLanguageEnglish";
            resources.ApplyResources(this.menuLanguageEnglish, "menuLanguageEnglish");
            this.menuLanguageEnglish.Click += new System.EventHandler(this.menuLanguageEnglish_Click);
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
            // menuLanguageLatvian
            // 
            this.menuLanguageLatvian.Name = "menuLanguageLatvian";
            resources.ApplyResources(this.menuLanguageLatvian, "menuLanguageLatvian");
            this.menuLanguageLatvian.Click += new System.EventHandler(this.latvianToolStripMenuItem_Click);
            // 
            // menuLanguageLithuanian
            // 
            this.menuLanguageLithuanian.Name = "menuLanguageLithuanian";
            resources.ApplyResources(this.menuLanguageLithuanian, "menuLanguageLithuanian");
            this.menuLanguageLithuanian.Click += new System.EventHandler(this.lithuanianToolStripMenuItem_Click);
            // 
            // menuLanguageHungarian
            // 
            this.menuLanguageHungarian.Name = "menuLanguageHungarian";
            resources.ApplyResources(this.menuLanguageHungarian, "menuLanguageHungarian");
            this.menuLanguageHungarian.Click += new System.EventHandler(this.menuLanguageHungarian_Click);
            // 
            // menuLanguageDutch
            // 
            this.menuLanguageDutch.CheckOnClick = true;
            this.menuLanguageDutch.Name = "menuLanguageDutch";
            resources.ApplyResources(this.menuLanguageDutch, "menuLanguageDutch");
            this.menuLanguageDutch.Click += new System.EventHandler(this.menuLanguageDutch_Click);
            // 
            // menuLanguagePolish
            // 
            this.menuLanguagePolish.Name = "menuLanguagePolish";
            resources.ApplyResources(this.menuLanguagePolish, "menuLanguagePolish");
            this.menuLanguagePolish.Click += new System.EventHandler(this.menuLanguagesPolski_Click);
            // 
            // menuLanguageRussian
            // 
            this.menuLanguageRussian.CheckOnClick = true;
            this.menuLanguageRussian.Name = "menuLanguageRussian";
            resources.ApplyResources(this.menuLanguageRussian, "menuLanguageRussian");
            this.menuLanguageRussian.Click += new System.EventHandler(this.menuLanguageRussian_Click);
            // 
            // menuLanguageFinnish
            // 
            this.menuLanguageFinnish.Name = "menuLanguageFinnish";
            resources.ApplyResources(this.menuLanguageFinnish, "menuLanguageFinnish");
            this.menuLanguageFinnish.Click += new System.EventHandler(this.finnishToolStripMenuItem_Click);
            // 
            // menuLanguageSlovak
            // 
            this.menuLanguageSlovak.Name = "menuLanguageSlovak";
            resources.ApplyResources(this.menuLanguageSlovak, "menuLanguageSlovak");
            this.menuLanguageSlovak.Click += new System.EventHandler(this.menuLanguageSlovak_Click);
            // 
            // menuLanguageUkranian
            // 
            this.menuLanguageUkranian.Name = "menuLanguageUkranian";
            resources.ApplyResources(this.menuLanguageUkranian, "menuLanguageUkranian");
            this.menuLanguageUkranian.Click += new System.EventHandler(this.menuLanguageUkranian_Click);
            // 
            // menuLanguageTurkish
            // 
            this.menuLanguageTurkish.Name = "menuLanguageTurkish";
            resources.ApplyResources(this.menuLanguageTurkish, "menuLanguageTurkish");
            this.menuLanguageTurkish.Click += new System.EventHandler(this.menuLanguageTurkish_Click);
            // 
            // menuLanguageTest
            // 
            this.menuLanguageTest.Name = "menuLanguageTest";
            resources.ApplyResources(this.menuLanguageTest, "menuLanguageTest");
            this.menuLanguageTest.Click += new System.EventHandler(this.menuLanguageTest_Click);
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
            // colorsToolStripMenuItem1
            // 
            this.colorsToolStripMenuItem1.Name = "colorsToolStripMenuItem1";
            resources.ApplyResources(this.colorsToolStripMenuItem1, "colorsToolStripMenuItem1");
            this.colorsToolStripMenuItem1.Click += new System.EventHandler(this.colorsToolStripMenuItem_Click);
            // 
            // sectionColorToolStripMenuItem
            // 
            this.sectionColorToolStripMenuItem.Name = "sectionColorToolStripMenuItem";
            resources.ApplyResources(this.sectionColorToolStripMenuItem, "sectionColorToolStripMenuItem");
            this.sectionColorToolStripMenuItem.Click += new System.EventHandler(this.colorsSectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // topFieldViewToolStripMenuItem
            // 
            this.topFieldViewToolStripMenuItem.Name = "topFieldViewToolStripMenuItem";
            resources.ApplyResources(this.topFieldViewToolStripMenuItem, "topFieldViewToolStripMenuItem");
            this.topFieldViewToolStripMenuItem.Click += new System.EventHandler(this.topFieldViewToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // enterSimCoordsToolStripMenuItem
            // 
            this.enterSimCoordsToolStripMenuItem.Name = "enterSimCoordsToolStripMenuItem";
            resources.ApplyResources(this.enterSimCoordsToolStripMenuItem, "enterSimCoordsToolStripMenuItem");
            this.enterSimCoordsToolStripMenuItem.Click += new System.EventHandler(this.enterSimCoordsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // simulatorOnToolStripMenuItem
            // 
            this.simulatorOnToolStripMenuItem.CheckOnClick = true;
            this.simulatorOnToolStripMenuItem.Name = "simulatorOnToolStripMenuItem";
            resources.ApplyResources(this.simulatorOnToolStripMenuItem, "simulatorOnToolStripMenuItem");
            this.simulatorOnToolStripMenuItem.Click += new System.EventHandler(this.simulatorOnToolStripMenuItem_Click);
            // 
            // resetALLToolStripMenuItem
            // 
            this.resetALLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetEverythingToolStripMenuItem});
            this.resetALLToolStripMenuItem.Name = "resetALLToolStripMenuItem";
            resources.ApplyResources(this.resetALLToolStripMenuItem, "resetALLToolStripMenuItem");
            // 
            // resetEverythingToolStripMenuItem
            // 
            this.resetEverythingToolStripMenuItem.Name = "resetEverythingToolStripMenuItem";
            resources.ApplyResources(this.resetEverythingToolStripMenuItem, "resetEverythingToolStripMenuItem");
            this.resetEverythingToolStripMenuItem.Click += new System.EventHandler(this.resetALLToolStripMenuItem_Click);
            // 
            // hotKeysToolStripMenuItem
            // 
            this.hotKeysToolStripMenuItem.Name = "hotKeysToolStripMenuItem";
            resources.ApplyResources(this.hotKeysToolStripMenuItem, "hotKeysToolStripMenuItem");
            this.hotKeysToolStripMenuItem.Click += new System.EventHandler(this.hotKeysToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Name = "helpMenuItem";
            resources.ApplyResources(this.helpMenuItem, "helpMenuItem");
            this.helpMenuItem.Click += new System.EventHandler(this.helpMenuItem_Click);
            // 
            // tmrWatchdog
            // 
            this.tmrWatchdog.Interval = 250;
            this.tmrWatchdog.Tick += new System.EventHandler(this.tmrWatchdog_tick);
            // 
            // contextMenuStripFlag
            // 
            resources.ApplyResources(this.contextMenuStripFlag, "contextMenuStripFlag");
            this.contextMenuStripFlag.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contextMenuStripFlag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFlagRed,
            this.toolStripMenuFlagGrn,
            this.toolStripMenuFlagYel,
            this.toolStripSeparator12,
            this.toolStripMenuFlagForm});
            this.contextMenuStripFlag.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.contextMenuStripFlag.Name = "contextMenuStripFlag";
            // 
            // toolStripMenuItemFlagRed
            // 
            resources.ApplyResources(this.toolStripMenuItemFlagRed, "toolStripMenuItemFlagRed");
            this.toolStripMenuItemFlagRed.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuItemFlagRed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItemFlagRed.Image = global::AgOpenGPS.Properties.Resources.FlagYel;
            this.toolStripMenuItemFlagRed.Name = "toolStripMenuItemFlagRed";
            this.toolStripMenuItemFlagRed.Click += new System.EventHandler(this.toolStripMenuItemFlagRed_Click);
            // 
            // toolStripMenuFlagGrn
            // 
            resources.ApplyResources(this.toolStripMenuFlagGrn, "toolStripMenuFlagGrn");
            this.toolStripMenuFlagGrn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuFlagGrn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuFlagGrn.Image = global::AgOpenGPS.Properties.Resources.FlagGrn;
            this.toolStripMenuFlagGrn.Name = "toolStripMenuFlagGrn";
            this.toolStripMenuFlagGrn.Click += new System.EventHandler(this.toolStripMenuGrn_Click);
            // 
            // toolStripMenuFlagYel
            // 
            resources.ApplyResources(this.toolStripMenuFlagYel, "toolStripMenuFlagYel");
            this.toolStripMenuFlagYel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuFlagYel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuFlagYel.Image = global::AgOpenGPS.Properties.Resources.FlagRed;
            this.toolStripMenuFlagYel.Name = "toolStripMenuFlagYel";
            this.toolStripMenuFlagYel.Click += new System.EventHandler(this.toolStripMenuYel_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            // 
            // toolStripMenuFlagForm
            // 
            this.toolStripMenuFlagForm.Image = global::AgOpenGPS.Properties.Resources.OK64;
            resources.ApplyResources(this.toolStripMenuFlagForm, "toolStripMenuFlagForm");
            this.toolStripMenuFlagForm.Name = "toolStripMenuFlagForm";
            this.toolStripMenuFlagForm.Click += new System.EventHandler(this.toolStripMenuFlagForm_Click);
            // 
            // cboxpRowWidth
            // 
            resources.ApplyResources(this.cboxpRowWidth, "cboxpRowWidth");
            this.cboxpRowWidth.BackColor = System.Drawing.Color.Lavender;
            this.cboxpRowWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxpRowWidth.FormattingEnabled = true;
            this.cboxpRowWidth.Items.AddRange(new object[] {
            resources.GetString("cboxpRowWidth.Items"),
            resources.GetString("cboxpRowWidth.Items1"),
            resources.GetString("cboxpRowWidth.Items2"),
            resources.GetString("cboxpRowWidth.Items3"),
            resources.GetString("cboxpRowWidth.Items4"),
            resources.GetString("cboxpRowWidth.Items5"),
            resources.GetString("cboxpRowWidth.Items6"),
            resources.GetString("cboxpRowWidth.Items7"),
            resources.GetString("cboxpRowWidth.Items8"),
            resources.GetString("cboxpRowWidth.Items9"),
            resources.GetString("cboxpRowWidth.Items10")});
            this.cboxpRowWidth.Name = "cboxpRowWidth";
            this.cboxpRowWidth.SelectedIndexChanged += new System.EventHandler(this.cboxpRowWidth_SelectedIndexChanged);
            this.cboxpRowWidth.Click += new System.EventHandler(this.cboxpRowWidth_Click);
            // 
            // oglZoom
            // 
            this.oglZoom.BackColor = System.Drawing.Color.Black;
            this.oglZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.oglZoom, "oglZoom");
            this.oglZoom.Name = "oglZoom";
            this.oglZoom.VSync = false;
            this.oglZoom.Load += new System.EventHandler(this.oglZoom_Load);
            this.oglZoom.Paint += new System.Windows.Forms.PaintEventHandler(this.oglZoom_Paint);
            this.oglZoom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.oglZoom_MouseClick);
            this.oglZoom.Resize += new System.EventHandler(this.oglZoom_Resize);
            // 
            // btnResetSim
            // 
            this.btnResetSim.BackColor = System.Drawing.Color.Transparent;
            this.btnResetSim.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnResetSim, "btnResetSim");
            this.btnResetSim.Name = "btnResetSim";
            this.btnResetSim.UseVisualStyleBackColor = false;
            this.btnResetSim.Click += new System.EventHandler(this.btnResetSim_Click);
            // 
            // btnResetSteerAngle
            // 
            this.btnResetSteerAngle.BackColor = System.Drawing.Color.Transparent;
            this.btnResetSteerAngle.ContextMenuStrip = this.contextMenuStripFlag;
            resources.ApplyResources(this.btnResetSteerAngle, "btnResetSteerAngle");
            this.btnResetSteerAngle.Name = "btnResetSteerAngle";
            this.btnResetSteerAngle.UseVisualStyleBackColor = false;
            this.btnResetSteerAngle.Click += new System.EventHandler(this.btnResetSteerAngle_Click);
            // 
            // timerSim
            // 
            this.timerSim.Enabled = true;
            this.timerSim.Interval = 93;
            this.timerSim.Tick += new System.EventHandler(this.timerSim_Tick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // hsbarSteerAngle
            // 
            resources.ApplyResources(this.hsbarSteerAngle, "hsbarSteerAngle");
            this.hsbarSteerAngle.LargeChange = 20;
            this.hsbarSteerAngle.Maximum = 800;
            this.hsbarSteerAngle.Name = "hsbarSteerAngle";
            this.hsbarSteerAngle.Value = 400;
            this.hsbarSteerAngle.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarSteerAngle_Scroll);
            // 
            // hsbarStepDistance
            // 
            resources.ApplyResources(this.hsbarStepDistance, "hsbarStepDistance");
            this.hsbarStepDistance.LargeChange = 2;
            this.hsbarStepDistance.Minimum = -25;
            this.hsbarStepDistance.Name = "hsbarStepDistance";
            this.hsbarStepDistance.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarStepDistance_Scroll);
            // 
            // btnSection8Man
            // 
            resources.ApplyResources(this.btnSection8Man, "btnSection8Man");
            this.btnSection8Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection8Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection8Man.Name = "btnSection8Man";
            this.btnSection8Man.UseVisualStyleBackColor = false;
            this.btnSection8Man.Click += new System.EventHandler(this.btnSection8Man_Click);
            // 
            // btnSection7Man
            // 
            resources.ApplyResources(this.btnSection7Man, "btnSection7Man");
            this.btnSection7Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection7Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection7Man.Name = "btnSection7Man";
            this.btnSection7Man.UseVisualStyleBackColor = false;
            this.btnSection7Man.Click += new System.EventHandler(this.btnSection7Man_Click);
            // 
            // btnSection6Man
            // 
            resources.ApplyResources(this.btnSection6Man, "btnSection6Man");
            this.btnSection6Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection6Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection6Man.Name = "btnSection6Man";
            this.btnSection6Man.UseVisualStyleBackColor = false;
            this.btnSection6Man.Click += new System.EventHandler(this.btnSection6Man_Click);
            // 
            // btnSection5Man
            // 
            resources.ApplyResources(this.btnSection5Man, "btnSection5Man");
            this.btnSection5Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection5Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection5Man.Name = "btnSection5Man";
            this.btnSection5Man.UseVisualStyleBackColor = false;
            this.btnSection5Man.Click += new System.EventHandler(this.btnSection5Man_Click);
            // 
            // btnSection4Man
            // 
            resources.ApplyResources(this.btnSection4Man, "btnSection4Man");
            this.btnSection4Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection4Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection4Man.Name = "btnSection4Man";
            this.btnSection4Man.UseVisualStyleBackColor = false;
            this.btnSection4Man.Click += new System.EventHandler(this.btnSection4Man_Click);
            // 
            // btnSection3Man
            // 
            resources.ApplyResources(this.btnSection3Man, "btnSection3Man");
            this.btnSection3Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection3Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection3Man.Name = "btnSection3Man";
            this.btnSection3Man.UseVisualStyleBackColor = false;
            this.btnSection3Man.Click += new System.EventHandler(this.btnSection3Man_Click);
            // 
            // btnSection2Man
            // 
            resources.ApplyResources(this.btnSection2Man, "btnSection2Man");
            this.btnSection2Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection2Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection2Man.Name = "btnSection2Man";
            this.btnSection2Man.UseVisualStyleBackColor = false;
            this.btnSection2Man.Click += new System.EventHandler(this.btnSection2Man_Click);
            // 
            // btnSection1Man
            // 
            resources.ApplyResources(this.btnSection1Man, "btnSection1Man");
            this.btnSection1Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection1Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection1Man.Name = "btnSection1Man";
            this.btnSection1Man.UseVisualStyleBackColor = false;
            this.btnSection1Man.Click += new System.EventHandler(this.btnSection1Man_Click);
            // 
            // btnSection9Man
            // 
            resources.ApplyResources(this.btnSection9Man, "btnSection9Man");
            this.btnSection9Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection9Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection9Man.Name = "btnSection9Man";
            this.btnSection9Man.UseVisualStyleBackColor = false;
            this.btnSection9Man.Click += new System.EventHandler(this.btnSection9Man_Click);
            // 
            // btnSection10Man
            // 
            resources.ApplyResources(this.btnSection10Man, "btnSection10Man");
            this.btnSection10Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection10Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection10Man.Name = "btnSection10Man";
            this.btnSection10Man.UseVisualStyleBackColor = false;
            this.btnSection10Man.Click += new System.EventHandler(this.btnSection10Man_Click);
            // 
            // btnSection11Man
            // 
            resources.ApplyResources(this.btnSection11Man, "btnSection11Man");
            this.btnSection11Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection11Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection11Man.Name = "btnSection11Man";
            this.btnSection11Man.UseVisualStyleBackColor = false;
            this.btnSection11Man.Click += new System.EventHandler(this.btnSection11Man_Click);
            // 
            // btnSection12Man
            // 
            resources.ApplyResources(this.btnSection12Man, "btnSection12Man");
            this.btnSection12Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection12Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection12Man.Name = "btnSection12Man";
            this.btnSection12Man.UseVisualStyleBackColor = false;
            this.btnSection12Man.Click += new System.EventHandler(this.btnSection12Man_Click);
            // 
            // oglMain
            // 
            resources.ApplyResources(this.oglMain, "oglMain");
            this.oglMain.BackColor = System.Drawing.Color.Black;
            this.oglMain.ContextMenuStrip = this.contextMenuStripOpenGL;
            this.oglMain.Name = "oglMain";
            this.oglMain.VSync = false;
            this.oglMain.Load += new System.EventHandler(this.oglMain_Load);
            this.oglMain.Paint += new System.Windows.Forms.PaintEventHandler(this.oglMain_Paint);
            this.oglMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.oglMain_MouseDown);
            this.oglMain.Resize += new System.EventHandler(this.oglMain_Resize);
            // 
            // oglBack
            // 
            resources.ApplyResources(this.oglBack, "oglBack");
            this.oglBack.BackColor = System.Drawing.Color.Black;
            this.oglBack.ForeColor = System.Drawing.Color.Transparent;
            this.oglBack.Name = "oglBack";
            this.oglBack.VSync = false;
            this.oglBack.Load += new System.EventHandler(this.oglBack_Load);
            this.oglBack.Paint += new System.Windows.Forms.PaintEventHandler(this.oglBack_Paint);
            this.oglBack.Resize += new System.EventHandler(this.oglBack_Resize);
            // 
            // lblHz
            // 
            this.lblHz.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblHz, "lblHz");
            this.lblHz.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblHz.Name = "lblHz";
            this.lblHz.Click += new System.EventHandler(this.btnOpenConfig_Click);
            // 
            // panelRight
            // 
            resources.ApplyResources(this.panelRight, "panelRight");
            this.panelRight.Controls.Add(this.btnGuidance, 0, 1);
            this.panelRight.Controls.Add(this.btnContour, 0, 0);
            this.panelRight.Controls.Add(this.btnAutoSteer, 0, 8);
            this.panelRight.Controls.Add(this.btnSectionMasterAuto, 0, 7);
            this.panelRight.Controls.Add(this.btnSectionMasterManual, 0, 6);
            this.panelRight.Controls.Add(this.btnEditAB, 0, 2);
            this.panelRight.Name = "panelRight";
            // 
            // btnGuidance
            // 
            resources.ApplyResources(this.btnGuidance, "btnGuidance");
            this.btnGuidance.BackColor = System.Drawing.Color.Transparent;
            this.btnGuidance.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnGuidance.FlatAppearance.BorderSize = 0;
            this.btnGuidance.Image = global::AgOpenGPS.Properties.Resources.TrackOff;
            this.btnGuidance.Name = "btnGuidance";
            this.btnGuidance.UseVisualStyleBackColor = false;
            this.btnGuidance.Click += new System.EventHandler(this.btnGuidance_Click);
            // 
            // btnContour
            // 
            resources.ApplyResources(this.btnContour, "btnContour");
            this.btnContour.BackColor = System.Drawing.Color.Transparent;
            this.btnContour.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnContour.FlatAppearance.BorderSize = 0;
            this.btnContour.Image = global::AgOpenGPS.Properties.Resources.ContourOff;
            this.btnContour.Name = "btnContour";
            this.btnContour.UseVisualStyleBackColor = false;
            this.btnContour.Click += new System.EventHandler(this.btnContour_Click);
            // 
            // btnAutoSteer
            // 
            this.btnAutoSteer.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnAutoSteer, "btnAutoSteer");
            this.btnAutoSteer.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnAutoSteer.FlatAppearance.BorderSize = 0;
            this.btnAutoSteer.Image = global::AgOpenGPS.Properties.Resources.AutoSteerOff;
            this.btnAutoSteer.Name = "btnAutoSteer";
            this.btnAutoSteer.UseVisualStyleBackColor = false;
            this.btnAutoSteer.Click += new System.EventHandler(this.btnAutoSteer_Click);
            // 
            // btnSectionMasterAuto
            // 
            resources.ApplyResources(this.btnSectionMasterAuto, "btnSectionMasterAuto");
            this.btnSectionMasterAuto.BackColor = System.Drawing.Color.Transparent;
            this.btnSectionMasterAuto.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSectionMasterAuto.FlatAppearance.BorderSize = 0;
            this.btnSectionMasterAuto.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;
            this.btnSectionMasterAuto.Name = "btnSectionMasterAuto";
            this.btnSectionMasterAuto.UseVisualStyleBackColor = false;
            this.btnSectionMasterAuto.Click += new System.EventHandler(this.btnSectionMasterAuto_Click);
            // 
            // btnSectionMasterManual
            // 
            resources.ApplyResources(this.btnSectionMasterManual, "btnSectionMasterManual");
            this.btnSectionMasterManual.BackColor = System.Drawing.Color.Transparent;
            this.btnSectionMasterManual.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSectionMasterManual.FlatAppearance.BorderSize = 0;
            this.btnSectionMasterManual.Image = global::AgOpenGPS.Properties.Resources.ManualOff;
            this.btnSectionMasterManual.Name = "btnSectionMasterManual";
            this.btnSectionMasterManual.UseVisualStyleBackColor = false;
            this.btnSectionMasterManual.Click += new System.EventHandler(this.btnSectionMasterManual_Click);
            // 
            // btnEditAB
            // 
            resources.ApplyResources(this.btnEditAB, "btnEditAB");
            this.btnEditAB.BackColor = System.Drawing.Color.Transparent;
            this.btnEditAB.FlatAppearance.BorderSize = 0;
            this.btnEditAB.Image = global::AgOpenGPS.Properties.Resources.SnapNudge;
            this.btnEditAB.Name = "btnEditAB";
            this.btnEditAB.UseVisualStyleBackColor = false;
            this.btnEditAB.Click += new System.EventHandler(this.btnEditAB_Click);
            // 
            // panelSim
            // 
            resources.ApplyResources(this.panelSim, "panelSim");
            this.panelSim.BackColor = System.Drawing.Color.Transparent;
            this.panelSim.Controls.Add(this.btnSimForward, 6, 0);
            this.panelSim.Controls.Add(this.btnSimSetSpeedToZero, 5, 0);
            this.panelSim.Controls.Add(this.btnSimReverse, 4, 0);
            this.panelSim.Controls.Add(this.hsbarStepDistance, 1, 0);
            this.panelSim.Controls.Add(this.btnResetSteerAngle, 2, 0);
            this.panelSim.Controls.Add(this.btnResetSim, 0, 0);
            this.panelSim.Controls.Add(this.hsbarSteerAngle, 3, 0);
            this.panelSim.Name = "panelSim";
            // 
            // btnSimForward
            // 
            this.btnSimForward.BackColor = System.Drawing.Color.Transparent;
            this.btnSimForward.BackgroundImage = global::AgOpenGPS.Properties.Resources.UpArrow64;
            resources.ApplyResources(this.btnSimForward, "btnSimForward");
            this.btnSimForward.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnSimForward.Name = "btnSimForward";
            this.btnSimForward.UseVisualStyleBackColor = false;
            this.btnSimForward.Click += new System.EventHandler(this.btnSimForward_Click);
            // 
            // btnSimSetSpeedToZero
            // 
            resources.ApplyResources(this.btnSimSetSpeedToZero, "btnSimSetSpeedToZero");
            this.btnSimSetSpeedToZero.BackColor = System.Drawing.Color.Transparent;
            this.btnSimSetSpeedToZero.BackgroundImage = global::AgOpenGPS.Properties.Resources.AutoStop;
            this.btnSimSetSpeedToZero.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnSimSetSpeedToZero.Name = "btnSimSetSpeedToZero";
            this.btnSimSetSpeedToZero.UseVisualStyleBackColor = false;
            this.btnSimSetSpeedToZero.Click += new System.EventHandler(this.btnSimSetSpeedToZero_Click);
            // 
            // btnSimReverse
            // 
            this.btnSimReverse.BackColor = System.Drawing.Color.Transparent;
            this.btnSimReverse.BackgroundImage = global::AgOpenGPS.Properties.Resources.DnArrow64;
            resources.ApplyResources(this.btnSimReverse, "btnSimReverse");
            this.btnSimReverse.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnSimReverse.Name = "btnSimReverse";
            this.btnSimReverse.UseVisualStyleBackColor = false;
            this.btnSimReverse.Click += new System.EventHandler(this.btnSimReverse_Click);
            // 
            // btnSection16Man
            // 
            resources.ApplyResources(this.btnSection16Man, "btnSection16Man");
            this.btnSection16Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection16Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection16Man.Name = "btnSection16Man";
            this.btnSection16Man.UseVisualStyleBackColor = false;
            this.btnSection16Man.Click += new System.EventHandler(this.btnSection16Man_Click);
            // 
            // btnSection15Man
            // 
            resources.ApplyResources(this.btnSection15Man, "btnSection15Man");
            this.btnSection15Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection15Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection15Man.Name = "btnSection15Man";
            this.btnSection15Man.UseVisualStyleBackColor = false;
            this.btnSection15Man.Click += new System.EventHandler(this.btnSection15Man_Click);
            // 
            // btnSection14Man
            // 
            resources.ApplyResources(this.btnSection14Man, "btnSection14Man");
            this.btnSection14Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection14Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection14Man.Name = "btnSection14Man";
            this.btnSection14Man.UseVisualStyleBackColor = false;
            this.btnSection14Man.Click += new System.EventHandler(this.btnSection14Man_Click);
            // 
            // btnSection13Man
            // 
            resources.ApplyResources(this.btnSection13Man, "btnSection13Man");
            this.btnSection13Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection13Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection13Man.Name = "btnSection13Man";
            this.btnSection13Man.UseVisualStyleBackColor = false;
            this.btnSection13Man.Click += new System.EventHandler(this.btnSection13Man_Click);
            // 
            // panelNavigation
            // 
            this.panelNavigation.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.panelNavigation, "panelNavigation");
            this.panelNavigation.Controls.Add(this.btnN3D, 1, 2);
            this.panelNavigation.Controls.Add(this.btnBrightnessDn, 0, 4);
            this.panelNavigation.Controls.Add(this.btnBrightnessUp, 0, 4);
            this.panelNavigation.Controls.Add(this.btnDayNightMode, 0, 3);
            this.panelNavigation.Controls.Add(this.btnpTiltUp, 1, 0);
            this.panelNavigation.Controls.Add(this.btnpTiltDown, 0, 0);
            this.panelNavigation.Controls.Add(this.btnN2D, 0, 2);
            this.panelNavigation.Controls.Add(this.lblHz, 1, 3);
            this.panelNavigation.Controls.Add(this.btn3D, 1, 1);
            this.panelNavigation.Controls.Add(this.btn2D, 0, 1);
            this.panelNavigation.Name = "panelNavigation";
            // 
            // btnN3D
            // 
            resources.ApplyResources(this.btnN3D, "btnN3D");
            this.btnN3D.BackColor = System.Drawing.Color.Transparent;
            this.btnN3D.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnN3D.FlatAppearance.BorderSize = 0;
            this.btnN3D.Image = global::AgOpenGPS.Properties.Resources.CameraNorth64;
            this.btnN3D.Name = "btnN3D";
            this.btnN3D.UseVisualStyleBackColor = false;
            this.btnN3D.Click += new System.EventHandler(this.btnN3D_Click);
            // 
            // btnBrightnessDn
            // 
            this.btnBrightnessDn.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnBrightnessDn, "btnBrightnessDn");
            this.btnBrightnessDn.FlatAppearance.BorderSize = 0;
            this.btnBrightnessDn.Image = global::AgOpenGPS.Properties.Resources.BrightnessDn;
            this.btnBrightnessDn.Name = "btnBrightnessDn";
            this.btnBrightnessDn.UseVisualStyleBackColor = false;
            this.btnBrightnessDn.Click += new System.EventHandler(this.btnBrightnessDn_Click);
            // 
            // btnBrightnessUp
            // 
            this.btnBrightnessUp.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnBrightnessUp, "btnBrightnessUp");
            this.btnBrightnessUp.FlatAppearance.BorderSize = 0;
            this.btnBrightnessUp.Image = global::AgOpenGPS.Properties.Resources.BrightnessUp;
            this.btnBrightnessUp.Name = "btnBrightnessUp";
            this.btnBrightnessUp.UseVisualStyleBackColor = false;
            this.btnBrightnessUp.Click += new System.EventHandler(this.btnBrightnessUp_Click);
            // 
            // btnDayNightMode
            // 
            resources.ApplyResources(this.btnDayNightMode, "btnDayNightMode");
            this.btnDayNightMode.BackColor = System.Drawing.Color.Transparent;
            this.btnDayNightMode.FlatAppearance.BorderSize = 0;
            this.btnDayNightMode.Image = global::AgOpenGPS.Properties.Resources.WindowNightMode;
            this.btnDayNightMode.Name = "btnDayNightMode";
            this.btnDayNightMode.UseVisualStyleBackColor = false;
            this.btnDayNightMode.Click += new System.EventHandler(this.btnDayNightMode_Click);
            // 
            // btnpTiltUp
            // 
            resources.ApplyResources(this.btnpTiltUp, "btnpTiltUp");
            this.btnpTiltUp.BackColor = System.Drawing.Color.Transparent;
            this.btnpTiltUp.BackgroundImage = global::AgOpenGPS.Properties.Resources.TiltUp;
            this.btnpTiltUp.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnpTiltUp.FlatAppearance.BorderSize = 0;
            this.btnpTiltUp.Name = "btnpTiltUp";
            this.btnpTiltUp.UseVisualStyleBackColor = false;
            this.btnpTiltUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnpTiltUp_MouseDown);
            // 
            // btnpTiltDown
            // 
            resources.ApplyResources(this.btnpTiltDown, "btnpTiltDown");
            this.btnpTiltDown.BackColor = System.Drawing.Color.Transparent;
            this.btnpTiltDown.BackgroundImage = global::AgOpenGPS.Properties.Resources.TiltDown;
            this.btnpTiltDown.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnpTiltDown.FlatAppearance.BorderSize = 0;
            this.btnpTiltDown.Name = "btnpTiltDown";
            this.btnpTiltDown.UseVisualStyleBackColor = false;
            this.btnpTiltDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnpTiltDown_MouseDown);
            // 
            // btnN2D
            // 
            resources.ApplyResources(this.btnN2D, "btnN2D");
            this.btnN2D.BackColor = System.Drawing.Color.Transparent;
            this.btnN2D.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnN2D.FlatAppearance.BorderSize = 0;
            this.btnN2D.Image = global::AgOpenGPS.Properties.Resources.CameraNorth2D;
            this.btnN2D.Name = "btnN2D";
            this.btnN2D.UseVisualStyleBackColor = false;
            this.btnN2D.Click += new System.EventHandler(this.btnN2D_Click);
            // 
            // btn3D
            // 
            resources.ApplyResources(this.btn3D, "btn3D");
            this.btn3D.BackColor = System.Drawing.Color.Transparent;
            this.btn3D.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btn3D.FlatAppearance.BorderSize = 0;
            this.btn3D.Image = global::AgOpenGPS.Properties.Resources.Camera3D64;
            this.btn3D.Name = "btn3D";
            this.btn3D.UseVisualStyleBackColor = false;
            this.btn3D.Click += new System.EventHandler(this.btn3D_Click);
            // 
            // btn2D
            // 
            resources.ApplyResources(this.btn2D, "btn2D");
            this.btn2D.BackColor = System.Drawing.Color.Transparent;
            this.btn2D.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btn2D.FlatAppearance.BorderSize = 0;
            this.btn2D.Image = global::AgOpenGPS.Properties.Resources.Camera2D64;
            this.btn2D.Name = "btn2D";
            this.btn2D.UseVisualStyleBackColor = false;
            this.btn2D.Click += new System.EventHandler(this.btn2D_Click);
            // 
            // lblFieldStatus
            // 
            resources.ApplyResources(this.lblFieldStatus, "lblFieldStatus");
            this.lblFieldStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFieldStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFieldStatus.Name = "lblFieldStatus";
            this.lblFieldStatus.Click += new System.EventHandler(this.lblFieldStatus_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 4200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panelAB
            // 
            resources.ApplyResources(this.panelAB, "panelAB");
            this.panelAB.BackColor = System.Drawing.Color.Transparent;
            this.panelAB.Controls.Add(this.btnTramDisplayMode, 3, 0);
            this.panelAB.Controls.Add(this.btnHydLift, 2, 0);
            this.panelAB.Controls.Add(this.btnHeadlandOnOff, 1, 0);
            this.panelAB.Controls.Add(this.btnAutoYouTurn, 9, 0);
            this.panelAB.Controls.Add(this.btnResetToolHeading, 0, 0);
            this.panelAB.Controls.Add(this.btnChangeMappingColor, 4, 0);
            this.panelAB.Controls.Add(this.btnFlag, 6, 0);
            this.panelAB.Controls.Add(this.btnYouSkipEnable, 7, 0);
            this.panelAB.Controls.Add(this.cboxpRowWidth, 8, 0);
            this.panelAB.Name = "panelAB";
            // 
            // btnTramDisplayMode
            // 
            resources.ApplyResources(this.btnTramDisplayMode, "btnTramDisplayMode");
            this.btnTramDisplayMode.BackColor = System.Drawing.Color.Transparent;
            this.btnTramDisplayMode.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnTramDisplayMode.FlatAppearance.BorderSize = 0;
            this.btnTramDisplayMode.Image = global::AgOpenGPS.Properties.Resources.TramOff;
            this.btnTramDisplayMode.Name = "btnTramDisplayMode";
            this.btnTramDisplayMode.UseVisualStyleBackColor = false;
            this.btnTramDisplayMode.Click += new System.EventHandler(this.btnTramDisplayMode_Click);
            // 
            // btnHydLift
            // 
            resources.ApplyResources(this.btnHydLift, "btnHydLift");
            this.btnHydLift.BackColor = System.Drawing.Color.Transparent;
            this.btnHydLift.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnHydLift.FlatAppearance.BorderSize = 0;
            this.btnHydLift.Image = global::AgOpenGPS.Properties.Resources.HydraulicLiftOff;
            this.btnHydLift.Name = "btnHydLift";
            this.btnHydLift.UseVisualStyleBackColor = false;
            this.btnHydLift.Click += new System.EventHandler(this.btnHydLift_Click);
            // 
            // btnHeadlandOnOff
            // 
            resources.ApplyResources(this.btnHeadlandOnOff, "btnHeadlandOnOff");
            this.btnHeadlandOnOff.BackColor = System.Drawing.Color.Transparent;
            this.btnHeadlandOnOff.FlatAppearance.BorderSize = 0;
            this.btnHeadlandOnOff.Image = global::AgOpenGPS.Properties.Resources.HeadlandOff;
            this.btnHeadlandOnOff.Name = "btnHeadlandOnOff";
            this.btnHeadlandOnOff.UseVisualStyleBackColor = false;
            this.btnHeadlandOnOff.Click += new System.EventHandler(this.btnHeadlandOnOff_Click);
            // 
            // btnAutoYouTurn
            // 
            resources.ApplyResources(this.btnAutoYouTurn, "btnAutoYouTurn");
            this.btnAutoYouTurn.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoYouTurn.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnAutoYouTurn.FlatAppearance.BorderSize = 0;
            this.btnAutoYouTurn.Image = global::AgOpenGPS.Properties.Resources.YouTurnNo;
            this.btnAutoYouTurn.Name = "btnAutoYouTurn";
            this.btnAutoYouTurn.UseVisualStyleBackColor = false;
            this.btnAutoYouTurn.Click += new System.EventHandler(this.btnAutoYouTurn_Click);
            // 
            // btnResetToolHeading
            // 
            resources.ApplyResources(this.btnResetToolHeading, "btnResetToolHeading");
            this.btnResetToolHeading.BackColor = System.Drawing.Color.Transparent;
            this.btnResetToolHeading.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnResetToolHeading.FlatAppearance.BorderSize = 0;
            this.btnResetToolHeading.ForeColor = System.Drawing.Color.Black;
            this.btnResetToolHeading.Image = global::AgOpenGPS.Properties.Resources.ResetTool;
            this.btnResetToolHeading.Name = "btnResetToolHeading";
            this.btnResetToolHeading.UseVisualStyleBackColor = false;
            this.btnResetToolHeading.Click += new System.EventHandler(this.btnResetToolHeading_Click);
            // 
            // btnChangeMappingColor
            // 
            resources.ApplyResources(this.btnChangeMappingColor, "btnChangeMappingColor");
            this.btnChangeMappingColor.BackColor = System.Drawing.Color.SkyBlue;
            this.btnChangeMappingColor.BackgroundImage = global::AgOpenGPS.Properties.Resources.SectionMapping;
            this.btnChangeMappingColor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnChangeMappingColor.FlatAppearance.BorderSize = 0;
            this.btnChangeMappingColor.ForeColor = System.Drawing.Color.Black;
            this.btnChangeMappingColor.Name = "btnChangeMappingColor";
            this.btnChangeMappingColor.UseVisualStyleBackColor = false;
            this.btnChangeMappingColor.Click += new System.EventHandler(this.btnChangeMappingColor_Click);
            // 
            // btnFlag
            // 
            resources.ApplyResources(this.btnFlag, "btnFlag");
            this.btnFlag.BackColor = System.Drawing.Color.Transparent;
            this.btnFlag.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnFlag.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnFlag.FlatAppearance.BorderSize = 0;
            this.btnFlag.Image = global::AgOpenGPS.Properties.Resources.FlagRed;
            this.btnFlag.Name = "btnFlag";
            this.btnFlag.UseVisualStyleBackColor = false;
            this.btnFlag.Click += new System.EventHandler(this.btnFlag_Click);
            // 
            // btnYouSkipEnable
            // 
            resources.ApplyResources(this.btnYouSkipEnable, "btnYouSkipEnable");
            this.btnYouSkipEnable.BackColor = System.Drawing.Color.Transparent;
            this.btnYouSkipEnable.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnYouSkipEnable.FlatAppearance.BorderSize = 0;
            this.btnYouSkipEnable.Image = global::AgOpenGPS.Properties.Resources.YouSkipOff;
            this.btnYouSkipEnable.Name = "btnYouSkipEnable";
            this.btnYouSkipEnable.UseVisualStyleBackColor = false;
            this.btnYouSkipEnable.Click += new System.EventHandler(this.btnYouSkipEnable_Click);
            // 
            // lblSpeed
            // 
            resources.ApplyResources(this.lblSpeed, "lblSpeed");
            this.lblSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSpeed.ForeColor = System.Drawing.Color.Black;
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Click += new System.EventHandler(this.lblSpeed_Click);
            // 
            // lblInty
            // 
            resources.ApplyResources(this.lblInty, "lblInty");
            this.lblInty.Name = "lblInty";
            this.lblInty.Click += new System.EventHandler(this.lblInty_Click);
            // 
            // lblCurveLineName
            // 
            resources.ApplyResources(this.lblCurveLineName, "lblCurveLineName");
            this.lblCurveLineName.Name = "lblCurveLineName";
            // 
            // lblCurrentField
            // 
            resources.ApplyResources(this.lblCurrentField, "lblCurrentField");
            this.lblCurrentField.Name = "lblCurrentField";
            // 
            // lblFix
            // 
            resources.ApplyResources(this.lblFix, "lblFix");
            this.lblFix.Name = "lblFix";
            // 
            // btnZone1
            // 
            resources.ApplyResources(this.btnZone1, "btnZone1");
            this.btnZone1.BackColor = System.Drawing.Color.Silver;
            this.btnZone1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone1.Name = "btnZone1";
            this.btnZone1.UseVisualStyleBackColor = false;
            this.btnZone1.Click += new System.EventHandler(this.btnZone1_Click);
            // 
            // btnZone2
            // 
            resources.ApplyResources(this.btnZone2, "btnZone2");
            this.btnZone2.BackColor = System.Drawing.Color.Silver;
            this.btnZone2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone2.Name = "btnZone2";
            this.btnZone2.UseVisualStyleBackColor = false;
            this.btnZone2.Click += new System.EventHandler(this.btnZone2_Click);
            // 
            // btnZone3
            // 
            resources.ApplyResources(this.btnZone3, "btnZone3");
            this.btnZone3.BackColor = System.Drawing.Color.Silver;
            this.btnZone3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone3.Name = "btnZone3";
            this.btnZone3.UseVisualStyleBackColor = false;
            this.btnZone3.Click += new System.EventHandler(this.btnZone3_Click);
            // 
            // btnZone4
            // 
            resources.ApplyResources(this.btnZone4, "btnZone4");
            this.btnZone4.BackColor = System.Drawing.Color.Silver;
            this.btnZone4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone4.Name = "btnZone4";
            this.btnZone4.UseVisualStyleBackColor = false;
            this.btnZone4.Click += new System.EventHandler(this.btnZone4_Click);
            // 
            // btnZone5
            // 
            resources.ApplyResources(this.btnZone5, "btnZone5");
            this.btnZone5.BackColor = System.Drawing.Color.Silver;
            this.btnZone5.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone5.Name = "btnZone5";
            this.btnZone5.UseVisualStyleBackColor = false;
            this.btnZone5.Click += new System.EventHandler(this.btnZone5_Click);
            // 
            // btnZone6
            // 
            resources.ApplyResources(this.btnZone6, "btnZone6");
            this.btnZone6.BackColor = System.Drawing.Color.Silver;
            this.btnZone6.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone6.Name = "btnZone6";
            this.btnZone6.UseVisualStyleBackColor = false;
            this.btnZone6.Click += new System.EventHandler(this.btnZone6_Click);
            // 
            // btnZone7
            // 
            resources.ApplyResources(this.btnZone7, "btnZone7");
            this.btnZone7.BackColor = System.Drawing.Color.Silver;
            this.btnZone7.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone7.Name = "btnZone7";
            this.btnZone7.UseVisualStyleBackColor = false;
            this.btnZone7.Click += new System.EventHandler(this.btnZone7_Click);
            // 
            // btnZone8
            // 
            resources.ApplyResources(this.btnZone8, "btnZone8");
            this.btnZone8.BackColor = System.Drawing.Color.Silver;
            this.btnZone8.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone8.Name = "btnZone8";
            this.btnZone8.UseVisualStyleBackColor = false;
            this.btnZone8.Click += new System.EventHandler(this.btnZone8_Click);
            // 
            // tlpTrackMethods
            // 
            resources.ApplyResources(this.tlpTrackMethods, "tlpTrackMethods");
            this.tlpTrackMethods.Controls.Add(this.cboxAutoTrack, 0, 0);
            this.tlpTrackMethods.Controls.Add(this.cboxAutoSnapToPivot, 0, 0);
            this.tlpTrackMethods.Controls.Add(this.btnTrackCreateEdit, 3, 0);
            this.tlpTrackMethods.Controls.Add(this.btnABDraw, 2, 0);
            this.tlpTrackMethods.Name = "tlpTrackMethods";
            // 
            // cboxAutoTrack
            // 
            resources.ApplyResources(this.cboxAutoTrack, "cboxAutoTrack");
            this.cboxAutoTrack.BackColor = System.Drawing.Color.Transparent;
            this.cboxAutoTrack.Checked = true;
            this.cboxAutoTrack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxAutoTrack.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cboxAutoTrack.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxAutoTrack.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cboxAutoTrack.Image = global::AgOpenGPS.Properties.Resources.AutoTrack;
            this.cboxAutoTrack.Name = "cboxAutoTrack";
            this.cboxAutoTrack.UseVisualStyleBackColor = false;
            // 
            // cboxAutoSnapToPivot
            // 
            resources.ApplyResources(this.cboxAutoSnapToPivot, "cboxAutoSnapToPivot");
            this.cboxAutoSnapToPivot.BackColor = System.Drawing.Color.Transparent;
            this.cboxAutoSnapToPivot.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cboxAutoSnapToPivot.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxAutoSnapToPivot.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cboxAutoSnapToPivot.Image = global::AgOpenGPS.Properties.Resources.SnapToPivot;
            this.cboxAutoSnapToPivot.Name = "cboxAutoSnapToPivot";
            this.cboxAutoSnapToPivot.UseVisualStyleBackColor = false;
            this.cboxAutoSnapToPivot.Click += new System.EventHandler(this.cboxAutoSnapToPivot_Click);
            // 
            // btnTrackCreateEdit
            // 
            resources.ApplyResources(this.btnTrackCreateEdit, "btnTrackCreateEdit");
            this.btnTrackCreateEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnTrackCreateEdit.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnTrackCreateEdit.FlatAppearance.BorderSize = 0;
            this.btnTrackCreateEdit.Image = global::AgOpenGPS.Properties.Resources.TrackDrive;
            this.btnTrackCreateEdit.Name = "btnTrackCreateEdit";
            this.btnTrackCreateEdit.UseVisualStyleBackColor = false;
            this.btnTrackCreateEdit.Click += new System.EventHandler(this.btnTrackCreateEdit_Click);
            // 
            // btnABDraw
            // 
            resources.ApplyResources(this.btnABDraw, "btnABDraw");
            this.btnABDraw.BackColor = System.Drawing.Color.Transparent;
            this.btnABDraw.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnABDraw.FlatAppearance.BorderSize = 0;
            this.btnABDraw.Image = global::AgOpenGPS.Properties.Resources.PointStart;
            this.btnABDraw.Name = "btnABDraw";
            this.btnABDraw.UseVisualStyleBackColor = false;
            this.btnABDraw.Click += new System.EventHandler(this.btnABDraw_Click);
            // 
            // btnMaximizeMainForm
            // 
            resources.ApplyResources(this.btnMaximizeMainForm, "btnMaximizeMainForm");
            this.btnMaximizeMainForm.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximizeMainForm.BackgroundImage = global::AgOpenGPS.Properties.Resources.WindowMaximize;
            this.btnMaximizeMainForm.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnMaximizeMainForm.FlatAppearance.BorderSize = 0;
            this.btnMaximizeMainForm.Name = "btnMaximizeMainForm";
            this.btnMaximizeMainForm.UseVisualStyleBackColor = false;
            this.btnMaximizeMainForm.Click += new System.EventHandler(this.btnMaximizeMainForm_Click);
            // 
            // pictureboxStart
            // 
            resources.ApplyResources(this.pictureboxStart, "pictureboxStart");
            this.pictureboxStart.BackColor = System.Drawing.Color.Black;
            this.pictureboxStart.Image = global::AgOpenGPS.Properties.Resources.Splash;
            this.pictureboxStart.Name = "pictureboxStart";
            this.pictureboxStart.TabStop = false;
            // 
            // btnShutdown
            // 
            resources.ApplyResources(this.btnShutdown, "btnShutdown");
            this.btnShutdown.BackColor = System.Drawing.Color.Transparent;
            this.btnShutdown.BackgroundImage = global::AgOpenGPS.Properties.Resources.WindowClose;
            this.btnShutdown.FlatAppearance.BorderSize = 0;
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.UseVisualStyleBackColor = false;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // btnHelp
            // 
            resources.ApplyResources(this.btnHelp, "btnHelp");
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.ForeColor = System.Drawing.Color.DimGray;
            this.btnHelp.Image = global::AgOpenGPS.Properties.Resources.Help;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnMinimizeMainForm
            // 
            resources.ApplyResources(this.btnMinimizeMainForm, "btnMinimizeMainForm");
            this.btnMinimizeMainForm.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimizeMainForm.BackgroundImage = global::AgOpenGPS.Properties.Resources.WindowMinimize;
            this.btnMinimizeMainForm.FlatAppearance.BorderSize = 0;
            this.btnMinimizeMainForm.ForeColor = System.Drawing.Color.DimGray;
            this.btnMinimizeMainForm.Name = "btnMinimizeMainForm";
            this.btnMinimizeMainForm.UseVisualStyleBackColor = false;
            this.btnMinimizeMainForm.Click += new System.EventHandler(this.btnMinimizeMainForm_Click);
            // 
            // FormGPS
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.tlpTrackMethods);
            this.Controls.Add(this.btnZone8);
            this.Controls.Add(this.btnZone7);
            this.Controls.Add(this.btnZone6);
            this.Controls.Add(this.btnZone5);
            this.Controls.Add(this.btnZone4);
            this.Controls.Add(this.btnZone3);
            this.Controls.Add(this.btnZone2);
            this.Controls.Add(this.btnZone1);
            this.Controls.Add(this.lblCurrentField);
            this.Controls.Add(this.lblCurveLineName);
            this.Controls.Add(this.lblFieldStatus);
            this.Controls.Add(this.lblFix);
            this.Controls.Add(this.lblInty);
            this.Controls.Add(this.btnMaximizeMainForm);
            this.Controls.Add(this.pictureboxStart);
            this.Controls.Add(this.panelNavigation);
            this.Controls.Add(this.btnSection13Man);
            this.Controls.Add(this.btnSection14Man);
            this.Controls.Add(this.btnSection15Man);
            this.Controls.Add(this.btnSection16Man);
            this.Controls.Add(this.btnShutdown);
            this.Controls.Add(this.panelSim);
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
            this.Controls.Add(this.oglZoom);
            this.Controls.Add(this.oglBack);
            this.Controls.Add(this.panelAB);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.btnMinimizeMainForm);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGPS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGPS_FormClosing);
            this.Load += new System.EventHandler(this.FormGPS_Load);
            this.Move += new System.EventHandler(this.FormGPS_Move);
            this.Resize += new System.EventHandler(this.FormGPS_Resize);
            this.contextMenuStripOpenGL.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripFlag.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelSim.ResumeLayout(false);
            this.panelNavigation.ResumeLayout(false);
            this.panelAB.ResumeLayout(false);
            this.tlpTrackMethods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Timer tmrWatchdog;
        private System.Windows.Forms.Button btnSection1Man;
        private System.Windows.Forms.Button btnSection2Man;
        private System.Windows.Forms.Button btnSection3Man;
        private System.Windows.Forms.Button btnSection4Man;
        private System.Windows.Forms.Button btnSection5Man;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFlag;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFlagRed;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFlagGrn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFlagYel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripOpenGL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem googleEarthOpenGLContextMenu;
        private System.Windows.Forms.Button btnSection8Man;
        private System.Windows.Forms.Button btnSection7Man;
        private System.Windows.Forms.Button btnSection6Man;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.Button btnFlag;
        private System.Windows.Forms.Button btnResetSteerAngle;
        private System.Windows.Forms.Button btnResetSim;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        public System.Windows.Forms.Button btnSectionMasterAuto;
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
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.Button btnGuidance;
        private System.Windows.Forms.Button btnSection9Man;
        private System.Windows.Forms.Button btnSection10Man;
        private System.Windows.Forms.Button btnSection11Man;
        private System.Windows.Forms.Button btnSection12Man;
        private System.Windows.Forms.ToolStripMenuItem enterSimCoordsToolStripMenuItem;
        public System.Windows.Forms.Button btnAutoYouTurn;
        public System.Windows.Forms.Button btnAutoSteer;
        private System.Windows.Forms.HScrollBar hsbarStepDistance;
        private System.Windows.Forms.HScrollBar hsbarSteerAngle;
        private OpenTK.GLControl oglZoom;
        private OpenTK.GLControl oglMain;
        private OpenTK.GLControl oglBack;
        private System.Windows.Forms.ComboBox cboxpRowWidth;
        private System.Windows.Forms.Label lblHz;
        public System.Windows.Forms.Button btnContour;
        public System.Windows.Forms.Timer timerSim;
        public System.Windows.Forms.Button btnSectionMasterManual;
        public System.Windows.Forms.Button btnABDraw;
        public System.Windows.Forms.ToolStripMenuItem menustripLanguage;
        private System.Windows.Forms.TableLayoutPanel panelSim;
        public System.Windows.Forms.TableLayoutPanel panelRight;
        private ProXoft.WinForms.RepeatButton btnpTiltDown;
        private ProXoft.WinForms.RepeatButton btnpTiltUp;
        private System.Windows.Forms.Button btnHeadlandOnOff;
        private System.Windows.Forms.Button btnShutdown;
        private System.Windows.Forms.Button btnSection16Man;
        private System.Windows.Forms.Button btnSection15Man;
        private System.Windows.Forms.Button btnSection14Man;
        private System.Windows.Forms.Button btnSection13Man;
        private System.Windows.Forms.Button btnSimSetSpeedToZero;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageUkranian;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageSlovak;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFlagForm;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageTest;
        public System.Windows.Forms.Button btnHydLift;
        private System.Windows.Forms.ToolStripMenuItem menuLanguagePolish;
        public System.Windows.Forms.Button btnDayNightMode;
        public System.Windows.Forms.Button btnN3D;
        public System.Windows.Forms.Button btn2D;
        public System.Windows.Forms.Button btn3D;
        public System.Windows.Forms.Button btnN2D;
        private System.Windows.Forms.Label lblFieldStatus;
        private System.Windows.Forms.PictureBox pictureboxStart;
        private System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.Button btnChangeMappingColor;
        private System.Windows.Forms.TableLayoutPanel panelAB;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem topFieldViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem simulatorOnToolStripMenuItem;
        private System.Windows.Forms.Button btnMinimizeMainForm;
        private System.Windows.Forms.Button btnMaximizeMainForm;
        private System.Windows.Forms.ToolStripMenuItem resetALLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetEverythingToolStripMenuItem;
        private System.Windows.Forms.Label lblInty;
        private System.Windows.Forms.Label lblCurveLineName;
        private System.Windows.Forms.Label lblCurrentField;
        public System.Windows.Forms.Button btnTramDisplayMode;
        public System.Windows.Forms.Button btnYouSkipEnable;
        private System.Windows.Forms.Label lblFix;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageDanish;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sectionColorToolStripMenuItem;
        private System.Windows.Forms.Button btnEditAB;
        private System.Windows.Forms.Button btnHelp;
        public System.Windows.Forms.Button btnResetToolHeading;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageTurkish;
        public System.Windows.Forms.Button btnBrightnessDn;
        public System.Windows.Forms.Button btnBrightnessUp;
        private System.Windows.Forms.Button btnZone1;
        private System.Windows.Forms.Button btnZone2;
        private System.Windows.Forms.Button btnZone3;
        private System.Windows.Forms.Button btnZone4;
        private System.Windows.Forms.Button btnZone5;
        private System.Windows.Forms.Button btnZone6;
        private System.Windows.Forms.Button btnZone7;
        private System.Windows.Forms.Button btnZone8;
        private System.Windows.Forms.ToolStripMenuItem hotKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageHungarian;
        private System.Windows.Forms.Button btnSimForward;
        private System.Windows.Forms.Button btnSimReverse;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageFinnish;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageLatvian;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageLithuanian;
        private System.Windows.Forms.TableLayoutPanel tlpTrackMethods;
        public System.Windows.Forms.Button btnTrackCreateEdit;
        private System.Windows.Forms.Timer timerLineAdj;
        public System.Windows.Forms.TableLayoutPanel panelNavigation;
        private System.Windows.Forms.CheckBox cboxAutoSnapToPivot;
        private System.Windows.Forms.CheckBox cboxAutoTrack;
    }
}

