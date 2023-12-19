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
            this.panelDrag = new System.Windows.Forms.TableLayoutPanel();
            this.btnPathGoStop = new System.Windows.Forms.Button();
            this.btnPickPath = new System.Windows.Forms.Button();
            this.btnPathRecordStop = new System.Windows.Forms.Button();
            this.btnResumePath = new System.Windows.Forms.Button();
            this.btnResetSim = new System.Windows.Forms.Button();
            this.btnResetSteerAngle = new System.Windows.Forms.Button();
            this.timerSim = new System.Windows.Forms.Timer(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.hsbarSteerAngle = new System.Windows.Forms.HScrollBar();
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
            this.btnCycleLinesBk = new System.Windows.Forms.Button();
            this.btnCurve = new System.Windows.Forms.Button();
            this.btnContour = new System.Windows.Forms.Button();
            this.btnABLine = new System.Windows.Forms.Button();
            this.btnCycleLines = new System.Windows.Forms.Button();
            this.btnAutoSteer = new System.Windows.Forms.Button();
            this.btnAutoYouTurn = new System.Windows.Forms.Button();
            this.btnSectionMasterAuto = new System.Windows.Forms.Button();
            this.btnSectionMasterManual = new System.Windows.Forms.Button();
            this.statusStripLeft = new System.Windows.Forms.StatusStrip();
            this.distanceToolBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.simplifyToolStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.wizardsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.steerWizardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.steerChartStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.steerChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headingChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xTEChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rollCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SmoothABtoolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteContourPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAppliedAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteForSureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webcamToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.offsetFixToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripBtnFieldTools = new System.Windows.Forms.ToolStripDropDownButton();
            this.boundariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headlandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headlandBuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tramLinesMenuField = new System.Windows.Forms.ToolStripMenuItem();
            this.recordedPathStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSim = new System.Windows.Forms.TableLayoutPanel();
            this.btnSpeedDn = new ProXoft.WinForms.RepeatButton();
            this.btnSimSpeedUp = new ProXoft.WinForms.RepeatButton();
            this.btnSimSetSpeedToZero = new System.Windows.Forms.Button();
            this.btnSection16Man = new System.Windows.Forms.Button();
            this.btnSection15Man = new System.Windows.Forms.Button();
            this.btnSection14Man = new System.Windows.Forms.Button();
            this.btnSection13Man = new System.Windows.Forms.Button();
            this.panelNavigation = new System.Windows.Forms.TableLayoutPanel();
            this.btnN3D = new System.Windows.Forms.Button();
            this.btnpTiltUp = new ProXoft.WinForms.RepeatButton();
            this.btnpTiltDown = new ProXoft.WinForms.RepeatButton();
            this.btnN2D = new System.Windows.Forms.Button();
            this.btn3D = new System.Windows.Forms.Button();
            this.btn2D = new System.Windows.Forms.Button();
            this.btnDayNightMode = new System.Windows.Forms.Button();
            this.btnBrightnessUp = new System.Windows.Forms.Button();
            this.btnBrightnessDn = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panelAB = new System.Windows.Forms.TableLayoutPanel();
            this.btnResetToolHeading = new System.Windows.Forms.Button();
            this.btnYouSkipEnable = new System.Windows.Forms.Button();
            this.btnABDraw = new System.Windows.Forms.Button();
            this.btnChangeMappingColor = new System.Windows.Forms.Button();
            this.btnFlag = new System.Windows.Forms.Button();
            this.btnTramDisplayMode = new System.Windows.Forms.Button();
            this.btnHydLift = new System.Windows.Forms.Button();
            this.btnHeadlandOnOff = new System.Windows.Forms.Button();
            this.btnEditAB = new System.Windows.Forms.Button();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblInty = new System.Windows.Forms.Label();
            this.lblFix = new System.Windows.Forms.Label();
            this.btnZone1 = new System.Windows.Forms.Button();
            this.btnZone2 = new System.Windows.Forms.Button();
            this.btnZone3 = new System.Windows.Forms.Button();
            this.btnZone4 = new System.Windows.Forms.Button();
            this.btnZone5 = new System.Windows.Forms.Button();
            this.btnZone6 = new System.Windows.Forms.Button();
            this.btnZone7 = new System.Windows.Forms.Button();
            this.btnZone8 = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnStartAgIO = new System.Windows.Forms.Button();
            this.btnJobMenu = new System.Windows.Forms.Button();
            this.btnAutoSteerConfig = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFieldStatus = new System.Windows.Forms.Label();
            this.lblGuidanceLine = new System.Windows.Forms.Label();
            this.lblCurrentField = new System.Windows.Forms.Label();
            this.btnGPSData = new System.Windows.Forms.Button();
            this.btnFieldStats = new System.Windows.Forms.Button();
            this.panelPan = new System.Windows.Forms.TableLayoutPanel();
            this.btnDownLeft = new System.Windows.Forms.Button();
            this.btnPanUp = new System.Windows.Forms.Button();
            this.btnUpLeft = new System.Windows.Forms.Button();
            this.btnPanLeft = new System.Windows.Forms.Button();
            this.btnPanRight = new System.Windows.Forms.Button();
            this.btnPanCancel = new System.Windows.Forms.Button();
            this.btnPanDn = new System.Windows.Forms.Button();
            this.btnDownRight = new System.Windows.Forms.Button();
            this.btnUpRight = new System.Windows.Forms.Button();
            this.btnMaximizeMainForm = new System.Windows.Forms.Button();
            this.pictureboxStart = new System.Windows.Forms.PictureBox();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnMinimizeMainForm = new System.Windows.Forms.Button();
            this.contextMenuStripOpenGL.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripFlag.SuspendLayout();
            this.panelDrag.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.statusStripLeft.SuspendLayout();
            this.panelSim.SuspendLayout();
            this.panelNavigation.SuspendLayout();
            this.panelAB.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelPan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxStart)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripOpenGL
            // 
            this.contextMenuStripOpenGL.AutoSize = false;
            this.contextMenuStripOpenGL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 22F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Size = new System.Drawing.Size(80, 36);
            this.menuStrip1.TabIndex = 49;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator9,
            this.menustripLanguage,
            this.toolStripSeparator11,
            this.setWorkingDirectoryToolStripMenuItem,
            this.toolStripSeparator10,
            this.colorsToolStripMenuItem1,
            this.sectionColorToolStripMenuItem,
            this.toolStripSeparator3,
            this.enterSimCoordsToolStripMenuItem,
            this.toolStripSeparator4,
            this.simulatorOnToolStripMenuItem,
            this.resetALLToolStripMenuItem,
            this.hotKeysToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.helpMenuItem});
            this.fileToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.fileMenu;
            this.fileToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fileToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(68, 36);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(316, 6);
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
            this.menustripLanguage.Size = new System.Drawing.Size(319, 40);
            this.menustripLanguage.Text = "Language";
            // 
            // menuLanguageDanish
            // 
            this.menuLanguageDanish.Name = "menuLanguageDanish";
            this.menuLanguageDanish.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageDanish.Text = "Dansk (Denmark)";
            this.menuLanguageDanish.Click += new System.EventHandler(this.menuLanguageDanish_Click);
            // 
            // menuLanguageDeutsch
            // 
            this.menuLanguageDeutsch.CheckOnClick = true;
            this.menuLanguageDeutsch.Name = "menuLanguageDeutsch";
            this.menuLanguageDeutsch.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageDeutsch.Text = "Deutsch (Germany)";
            this.menuLanguageDeutsch.Click += new System.EventHandler(this.menuLanguageDeutsch_Click);
            // 
            // menuLanguageEnglish
            // 
            this.menuLanguageEnglish.CheckOnClick = true;
            this.menuLanguageEnglish.Name = "menuLanguageEnglish";
            this.menuLanguageEnglish.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageEnglish.Text = "English (Canada)";
            this.menuLanguageEnglish.Click += new System.EventHandler(this.menuLanguageEnglish_Click);
            // 
            // menuLanguageSpanish
            // 
            this.menuLanguageSpanish.CheckOnClick = true;
            this.menuLanguageSpanish.Name = "menuLanguageSpanish";
            this.menuLanguageSpanish.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageSpanish.Text = "Español (Spanish)";
            this.menuLanguageSpanish.Click += new System.EventHandler(this.menuLanguageSpanish_Click);
            // 
            // menuLanguageFrench
            // 
            this.menuLanguageFrench.CheckOnClick = true;
            this.menuLanguageFrench.Name = "menuLanguageFrench";
            this.menuLanguageFrench.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageFrench.Text = "Français (France)";
            this.menuLanguageFrench.Click += new System.EventHandler(this.menuLanguageFrench_Click);
            // 
            // menuLanguageItalian
            // 
            this.menuLanguageItalian.Name = "menuLanguageItalian";
            this.menuLanguageItalian.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageItalian.Text = "Italiano (Italy)";
            this.menuLanguageItalian.Click += new System.EventHandler(this.menuLanguageItalian_Click);
            // 
            // menuLanguageLatvian
            // 
            this.menuLanguageLatvian.Name = "menuLanguageLatvian";
            this.menuLanguageLatvian.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageLatvian.Text = "Latviski (Latvia)";
            this.menuLanguageLatvian.Click += new System.EventHandler(this.latvianToolStripMenuItem_Click);
            // 
            // menuLanguageLithuanian
            // 
            this.menuLanguageLithuanian.Name = "menuLanguageLithuanian";
            this.menuLanguageLithuanian.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageLithuanian.Text = "Lietuvių (Lithuania)";
            this.menuLanguageLithuanian.Click += new System.EventHandler(this.lithuanianToolStripMenuItem_Click);
            // 
            // menuLanguageHungarian
            // 
            this.menuLanguageHungarian.Name = "menuLanguageHungarian";
            this.menuLanguageHungarian.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageHungarian.Text = "Magyar (Hungary)";
            this.menuLanguageHungarian.Click += new System.EventHandler(this.menuLanguageHungarian_Click);
            // 
            // menuLanguageDutch
            // 
            this.menuLanguageDutch.CheckOnClick = true;
            this.menuLanguageDutch.Name = "menuLanguageDutch";
            this.menuLanguageDutch.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageDutch.Text = "Nederlands (Holland)";
            this.menuLanguageDutch.Click += new System.EventHandler(this.menuLanguageDutch_Click);
            // 
            // menuLanguagePolish
            // 
            this.menuLanguagePolish.Name = "menuLanguagePolish";
            this.menuLanguagePolish.Size = new System.Drawing.Size(389, 40);
            this.menuLanguagePolish.Text = "Polski (Poland)";
            this.menuLanguagePolish.Click += new System.EventHandler(this.menuLanguagesPolski_Click);
            // 
            // menuLanguageRussian
            // 
            this.menuLanguageRussian.CheckOnClick = true;
            this.menuLanguageRussian.Name = "menuLanguageRussian";
            this.menuLanguageRussian.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageRussian.Text = "русский (Russia)";
            this.menuLanguageRussian.Click += new System.EventHandler(this.menuLanguageRussian_Click);
            // 
            // menuLanguageFinnish
            // 
            this.menuLanguageFinnish.Name = "menuLanguageFinnish";
            this.menuLanguageFinnish.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageFinnish.Text = "Suomalainen (Finland)";
            this.menuLanguageFinnish.Click += new System.EventHandler(this.finnishToolStripMenuItem_Click);
            // 
            // menuLanguageSlovak
            // 
            this.menuLanguageSlovak.Name = "menuLanguageSlovak";
            this.menuLanguageSlovak.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageSlovak.Text = "Slovenčina (Slovakia)";
            this.menuLanguageSlovak.Click += new System.EventHandler(this.menuLanguageSlovak_Click);
            // 
            // menuLanguageUkranian
            // 
            this.menuLanguageUkranian.Name = "menuLanguageUkranian";
            this.menuLanguageUkranian.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageUkranian.Text = "Yкраїнська (Ukraine)";
            this.menuLanguageUkranian.Click += new System.EventHandler(this.menuLanguageUkranian_Click);
            // 
            // menuLanguageTurkish
            // 
            this.menuLanguageTurkish.Name = "menuLanguageTurkish";
            this.menuLanguageTurkish.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageTurkish.Text = "Türkçe (Turkey)";
            this.menuLanguageTurkish.Click += new System.EventHandler(this.menuLanguageTurkish_Click);
            // 
            // menuLanguageTest
            // 
            this.menuLanguageTest.Name = "menuLanguageTest";
            this.menuLanguageTest.Size = new System.Drawing.Size(389, 40);
            this.menuLanguageTest.Text = "Test";
            this.menuLanguageTest.Click += new System.EventHandler(this.menuLanguageTest_Click);
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
            // colorsToolStripMenuItem1
            // 
            this.colorsToolStripMenuItem1.Name = "colorsToolStripMenuItem1";
            this.colorsToolStripMenuItem1.Size = new System.Drawing.Size(319, 40);
            this.colorsToolStripMenuItem1.Text = "Colors";
            this.colorsToolStripMenuItem1.Click += new System.EventHandler(this.colorsToolStripMenuItem_Click);
            // 
            // sectionColorToolStripMenuItem
            // 
            this.sectionColorToolStripMenuItem.Name = "sectionColorToolStripMenuItem";
            this.sectionColorToolStripMenuItem.Size = new System.Drawing.Size(319, 40);
            this.sectionColorToolStripMenuItem.Text = "Section Colors";
            this.sectionColorToolStripMenuItem.Click += new System.EventHandler(this.colorsSectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(316, 6);
            // 
            // enterSimCoordsToolStripMenuItem
            // 
            this.enterSimCoordsToolStripMenuItem.Name = "enterSimCoordsToolStripMenuItem";
            this.enterSimCoordsToolStripMenuItem.Size = new System.Drawing.Size(319, 40);
            this.enterSimCoordsToolStripMenuItem.Text = "Enter Sim Coords";
            this.enterSimCoordsToolStripMenuItem.Click += new System.EventHandler(this.enterSimCoordsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(316, 6);
            // 
            // simulatorOnToolStripMenuItem
            // 
            this.simulatorOnToolStripMenuItem.CheckOnClick = true;
            this.simulatorOnToolStripMenuItem.Name = "simulatorOnToolStripMenuItem";
            this.simulatorOnToolStripMenuItem.Size = new System.Drawing.Size(319, 40);
            this.simulatorOnToolStripMenuItem.Text = "Simulator On";
            this.simulatorOnToolStripMenuItem.Click += new System.EventHandler(this.simulatorOnToolStripMenuItem_Click);
            // 
            // resetALLToolStripMenuItem
            // 
            this.resetALLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetEverythingToolStripMenuItem});
            this.resetALLToolStripMenuItem.Name = "resetALLToolStripMenuItem";
            this.resetALLToolStripMenuItem.Size = new System.Drawing.Size(319, 40);
            this.resetALLToolStripMenuItem.Text = "Reset All";
            // 
            // resetEverythingToolStripMenuItem
            // 
            this.resetEverythingToolStripMenuItem.Name = "resetEverythingToolStripMenuItem";
            this.resetEverythingToolStripMenuItem.Size = new System.Drawing.Size(312, 40);
            this.resetEverythingToolStripMenuItem.Text = "Reset To Default";
            this.resetEverythingToolStripMenuItem.Click += new System.EventHandler(this.resetALLToolStripMenuItem_Click);
            // 
            // hotKeysToolStripMenuItem
            // 
            this.hotKeysToolStripMenuItem.Name = "hotKeysToolStripMenuItem";
            this.hotKeysToolStripMenuItem.Size = new System.Drawing.Size(319, 40);
            this.hotKeysToolStripMenuItem.Text = "HotKeys";
            this.hotKeysToolStripMenuItem.Click += new System.EventHandler(this.hotKeysToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(319, 40);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(319, 40);
            this.helpMenuItem.Text = "Help";
            this.helpMenuItem.Click += new System.EventHandler(this.helpMenuItem_Click);
            // 
            // tmrWatchdog
            // 
            this.tmrWatchdog.Interval = 250;
            this.tmrWatchdog.Tick += new System.EventHandler(this.tmrWatchdog_tick);
            // 
            // contextMenuStripFlag
            // 
            this.contextMenuStripFlag.AutoSize = false;
            this.contextMenuStripFlag.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contextMenuStripFlag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFlagRed,
            this.toolStripMenuFlagGrn,
            this.toolStripMenuFlagYel,
            this.toolStripSeparator12,
            this.toolStripMenuFlagForm});
            this.contextMenuStripFlag.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.contextMenuStripFlag.Name = "contextMenuStripFlag";
            this.contextMenuStripFlag.Size = new System.Drawing.Size(72, 312);
            // 
            // toolStripMenuItemFlagRed
            // 
            this.toolStripMenuItemFlagRed.AutoSize = false;
            this.toolStripMenuItemFlagRed.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuItemFlagRed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItemFlagRed.Image = global::AgOpenGPS.Properties.Resources.FlagYel;
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
            this.toolStripMenuFlagYel.Image = global::AgOpenGPS.Properties.Resources.FlagRed;
            this.toolStripMenuFlagYel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuFlagYel.Name = "toolStripMenuFlagYel";
            this.toolStripMenuFlagYel.Size = new System.Drawing.Size(70, 70);
            this.toolStripMenuFlagYel.Text = ".";
            this.toolStripMenuFlagYel.Click += new System.EventHandler(this.toolStripMenuYel_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(68, 6);
            // 
            // toolStripMenuFlagForm
            // 
            this.toolStripMenuFlagForm.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.toolStripMenuFlagForm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuFlagForm.Name = "toolStripMenuFlagForm";
            this.toolStripMenuFlagForm.Size = new System.Drawing.Size(259, 70);
            this.toolStripMenuFlagForm.Text = "toolStripMenuItem3";
            this.toolStripMenuFlagForm.Click += new System.EventHandler(this.toolStripMenuFlagForm_Click);
            // 
            // cboxpRowWidth
            // 
            this.cboxpRowWidth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxpRowWidth.BackColor = System.Drawing.Color.Lavender;
            this.cboxpRowWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxpRowWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxpRowWidth.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cboxpRowWidth.Location = new System.Drawing.Point(74, 11);
            this.cboxpRowWidth.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxpRowWidth.Name = "cboxpRowWidth";
            this.cboxpRowWidth.Size = new System.Drawing.Size(44, 41);
            this.cboxpRowWidth.TabIndex = 247;
            this.cboxpRowWidth.SelectedIndexChanged += new System.EventHandler(this.cboxpRowWidth_SelectedIndexChanged);
            this.cboxpRowWidth.Click += new System.EventHandler(this.cboxpRowWidth_Click);
            // 
            // oglZoom
            // 
            this.oglZoom.BackColor = System.Drawing.Color.Black;
            this.oglZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oglZoom.Location = new System.Drawing.Point(101, 59);
            this.oglZoom.Margin = new System.Windows.Forms.Padding(0);
            this.oglZoom.Name = "oglZoom";
            this.oglZoom.Size = new System.Drawing.Size(61, 65);
            this.oglZoom.TabIndex = 182;
            this.oglZoom.VSync = false;
            this.oglZoom.Load += new System.EventHandler(this.oglZoom_Load);
            this.oglZoom.Paint += new System.Windows.Forms.PaintEventHandler(this.oglZoom_Paint);
            this.oglZoom.Resize += new System.EventHandler(this.oglZoom_Resize);
            // 
            // panelDrag
            // 
            this.panelDrag.BackColor = System.Drawing.Color.White;
            this.panelDrag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelDrag.ColumnCount = 1;
            this.panelDrag.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelDrag.Controls.Add(this.btnPathGoStop, 0, 0);
            this.panelDrag.Controls.Add(this.btnPickPath, 0, 3);
            this.panelDrag.Controls.Add(this.btnPathRecordStop, 0, 2);
            this.panelDrag.Controls.Add(this.btnResumePath, 0, 1);
            this.panelDrag.Location = new System.Drawing.Point(641, 47);
            this.panelDrag.Name = "panelDrag";
            this.panelDrag.RowCount = 5;
            this.panelDrag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelDrag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelDrag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelDrag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelDrag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelDrag.Size = new System.Drawing.Size(64, 320);
            this.panelDrag.TabIndex = 445;
            this.panelDrag.Visible = false;
            // 
            // btnPathGoStop
            // 
            this.btnPathGoStop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPathGoStop.BackColor = System.Drawing.Color.Transparent;
            this.btnPathGoStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPathGoStop.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPathGoStop.FlatAppearance.BorderSize = 0;
            this.btnPathGoStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPathGoStop.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPathGoStop.ForeColor = System.Drawing.Color.DarkGray;
            this.btnPathGoStop.Image = global::AgOpenGPS.Properties.Resources.boundaryPlay;
            this.btnPathGoStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPathGoStop.Location = new System.Drawing.Point(0, 0);
            this.btnPathGoStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnPathGoStop.Name = "btnPathGoStop";
            this.btnPathGoStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPathGoStop.Size = new System.Drawing.Size(64, 61);
            this.btnPathGoStop.TabIndex = 468;
            this.btnPathGoStop.UseVisualStyleBackColor = false;
            this.btnPathGoStop.Click += new System.EventHandler(this.btnPathGoStop_Click);
            // 
            // btnPickPath
            // 
            this.btnPickPath.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPickPath.BackColor = System.Drawing.Color.Transparent;
            this.btnPickPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPickPath.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPickPath.FlatAppearance.BorderSize = 0;
            this.btnPickPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPickPath.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickPath.ForeColor = System.Drawing.Color.DarkGray;
            this.btnPickPath.Image = global::AgOpenGPS.Properties.Resources.FileExplorerWindows;
            this.btnPickPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPickPath.Location = new System.Drawing.Point(0, 227);
            this.btnPickPath.Margin = new System.Windows.Forms.Padding(0);
            this.btnPickPath.Name = "btnPickPath";
            this.btnPickPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPickPath.Size = new System.Drawing.Size(64, 61);
            this.btnPickPath.TabIndex = 471;
            this.btnPickPath.UseVisualStyleBackColor = false;
            this.btnPickPath.Click += new System.EventHandler(this.btnPickPath_Click);
            // 
            // btnPathRecordStop
            // 
            this.btnPathRecordStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPathRecordStop.BackColor = System.Drawing.Color.Transparent;
            this.btnPathRecordStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPathRecordStop.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPathRecordStop.FlatAppearance.BorderSize = 0;
            this.btnPathRecordStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPathRecordStop.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPathRecordStop.ForeColor = System.Drawing.Color.DarkGray;
            this.btnPathRecordStop.Image = global::AgOpenGPS.Properties.Resources.BoundaryRecord;
            this.btnPathRecordStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPathRecordStop.Location = new System.Drawing.Point(0, 149);
            this.btnPathRecordStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnPathRecordStop.Name = "btnPathRecordStop";
            this.btnPathRecordStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPathRecordStop.Size = new System.Drawing.Size(64, 61);
            this.btnPathRecordStop.TabIndex = 470;
            this.btnPathRecordStop.UseVisualStyleBackColor = false;
            this.btnPathRecordStop.Click += new System.EventHandler(this.btnPathRecordStop_Click);
            // 
            // btnResumePath
            // 
            this.btnResumePath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnResumePath.BackColor = System.Drawing.Color.Transparent;
            this.btnResumePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResumePath.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnResumePath.FlatAppearance.BorderSize = 0;
            this.btnResumePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResumePath.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResumePath.ForeColor = System.Drawing.Color.Red;
            this.btnResumePath.Image = global::AgOpenGPS.Properties.Resources.pathResumeStart;
            this.btnResumePath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResumePath.Location = new System.Drawing.Point(0, 76);
            this.btnResumePath.Margin = new System.Windows.Forms.Padding(0);
            this.btnResumePath.Name = "btnResumePath";
            this.btnResumePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnResumePath.Size = new System.Drawing.Size(64, 64);
            this.btnResumePath.TabIndex = 472;
            this.btnResumePath.UseVisualStyleBackColor = false;
            this.btnResumePath.Click += new System.EventHandler(this.btnResumePath_Click);
            // 
            // btnResetSim
            // 
            this.btnResetSim.BackColor = System.Drawing.Color.Transparent;
            this.btnResetSim.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnResetSim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResetSim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetSim.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnResetSim.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetSim.Location = new System.Drawing.Point(4, 4);
            this.btnResetSim.Name = "btnResetSim";
            this.btnResetSim.Size = new System.Drawing.Size(59, 25);
            this.btnResetSim.TabIndex = 164;
            this.btnResetSim.Text = "Reset";
            this.btnResetSim.UseVisualStyleBackColor = false;
            this.btnResetSim.Click += new System.EventHandler(this.btnResetSim_Click);
            // 
            // btnResetSteerAngle
            // 
            this.btnResetSteerAngle.BackColor = System.Drawing.Color.Transparent;
            this.btnResetSteerAngle.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnResetSteerAngle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResetSteerAngle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetSteerAngle.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnResetSteerAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetSteerAngle.Location = new System.Drawing.Point(70, 4);
            this.btnResetSteerAngle.Name = "btnResetSteerAngle";
            this.btnResetSteerAngle.Size = new System.Drawing.Size(59, 25);
            this.btnResetSteerAngle.TabIndex = 162;
            this.btnResetSteerAngle.Text = ">0<";
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
            this.toolStripMenuItem2.Size = new System.Drawing.Size(334, 62);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // hsbarSteerAngle
            // 
            this.hsbarSteerAngle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hsbarSteerAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hsbarSteerAngle.LargeChange = 20;
            this.hsbarSteerAngle.Location = new System.Drawing.Point(152, 1);
            this.hsbarSteerAngle.Maximum = 800;
            this.hsbarSteerAngle.Name = "hsbarSteerAngle";
            this.hsbarSteerAngle.Size = new System.Drawing.Size(200, 31);
            this.hsbarSteerAngle.TabIndex = 179;
            this.hsbarSteerAngle.Value = 400;
            this.hsbarSteerAngle.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarSteerAngle_Scroll);
            // 
            // btnSection8Man
            // 
            this.btnSection8Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection8Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection8Man.Enabled = false;
            this.btnSection8Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection8Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection8Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection8Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection8Man.Location = new System.Drawing.Point(817, 234);
            this.btnSection8Man.Name = "btnSection8Man";
            this.btnSection8Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection8Man.TabIndex = 125;
            this.btnSection8Man.Text = "8";
            this.btnSection8Man.UseVisualStyleBackColor = false;
            this.btnSection8Man.Click += new System.EventHandler(this.btnSection8Man_Click);
            // 
            // btnSection7Man
            // 
            this.btnSection7Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection7Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection7Man.Enabled = false;
            this.btnSection7Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection7Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection7Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection7Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection7Man.Location = new System.Drawing.Point(817, 207);
            this.btnSection7Man.Name = "btnSection7Man";
            this.btnSection7Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection7Man.TabIndex = 126;
            this.btnSection7Man.Text = "7";
            this.btnSection7Man.UseVisualStyleBackColor = false;
            this.btnSection7Man.Click += new System.EventHandler(this.btnSection7Man_Click);
            // 
            // btnSection6Man
            // 
            this.btnSection6Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection6Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection6Man.Enabled = false;
            this.btnSection6Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection6Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection6Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection6Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection6Man.Location = new System.Drawing.Point(817, 180);
            this.btnSection6Man.Name = "btnSection6Man";
            this.btnSection6Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection6Man.TabIndex = 127;
            this.btnSection6Man.Text = "6";
            this.btnSection6Man.UseVisualStyleBackColor = false;
            this.btnSection6Man.Click += new System.EventHandler(this.btnSection6Man_Click);
            // 
            // btnSection5Man
            // 
            this.btnSection5Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection5Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection5Man.Enabled = false;
            this.btnSection5Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection5Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection5Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection5Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection5Man.Location = new System.Drawing.Point(817, 153);
            this.btnSection5Man.Name = "btnSection5Man";
            this.btnSection5Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection5Man.TabIndex = 103;
            this.btnSection5Man.Text = "5";
            this.btnSection5Man.UseVisualStyleBackColor = false;
            this.btnSection5Man.Click += new System.EventHandler(this.btnSection5Man_Click);
            // 
            // btnSection4Man
            // 
            this.btnSection4Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection4Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection4Man.Enabled = false;
            this.btnSection4Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection4Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection4Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection4Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection4Man.Location = new System.Drawing.Point(817, 127);
            this.btnSection4Man.Name = "btnSection4Man";
            this.btnSection4Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection4Man.TabIndex = 102;
            this.btnSection4Man.Text = "4";
            this.btnSection4Man.UseVisualStyleBackColor = false;
            this.btnSection4Man.Click += new System.EventHandler(this.btnSection4Man_Click);
            // 
            // btnSection3Man
            // 
            this.btnSection3Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection3Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection3Man.Enabled = false;
            this.btnSection3Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection3Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection3Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection3Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection3Man.Location = new System.Drawing.Point(817, 101);
            this.btnSection3Man.Name = "btnSection3Man";
            this.btnSection3Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection3Man.TabIndex = 101;
            this.btnSection3Man.Text = "3";
            this.btnSection3Man.UseVisualStyleBackColor = false;
            this.btnSection3Man.Click += new System.EventHandler(this.btnSection3Man_Click);
            // 
            // btnSection2Man
            // 
            this.btnSection2Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection2Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection2Man.Enabled = false;
            this.btnSection2Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection2Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection2Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection2Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection2Man.Location = new System.Drawing.Point(817, 74);
            this.btnSection2Man.Name = "btnSection2Man";
            this.btnSection2Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection2Man.TabIndex = 100;
            this.btnSection2Man.Text = "2";
            this.btnSection2Man.UseVisualStyleBackColor = false;
            this.btnSection2Man.Click += new System.EventHandler(this.btnSection2Man_Click);
            // 
            // btnSection1Man
            // 
            this.btnSection1Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection1Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection1Man.Enabled = false;
            this.btnSection1Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection1Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection1Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection1Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection1Man.Location = new System.Drawing.Point(817, 47);
            this.btnSection1Man.Name = "btnSection1Man";
            this.btnSection1Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection1Man.TabIndex = 99;
            this.btnSection1Man.Text = "1";
            this.btnSection1Man.UseVisualStyleBackColor = false;
            this.btnSection1Man.Click += new System.EventHandler(this.btnSection1Man_Click);
            // 
            // btnSection9Man
            // 
            this.btnSection9Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection9Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection9Man.Enabled = false;
            this.btnSection9Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection9Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection9Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection9Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection9Man.Location = new System.Drawing.Point(777, 47);
            this.btnSection9Man.Name = "btnSection9Man";
            this.btnSection9Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection9Man.TabIndex = 174;
            this.btnSection9Man.Text = "9";
            this.btnSection9Man.UseVisualStyleBackColor = false;
            this.btnSection9Man.Click += new System.EventHandler(this.btnSection9Man_Click);
            // 
            // btnSection10Man
            // 
            this.btnSection10Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection10Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection10Man.Enabled = false;
            this.btnSection10Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection10Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection10Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection10Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection10Man.Location = new System.Drawing.Point(777, 74);
            this.btnSection10Man.Name = "btnSection10Man";
            this.btnSection10Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection10Man.TabIndex = 175;
            this.btnSection10Man.Text = "10";
            this.btnSection10Man.UseVisualStyleBackColor = false;
            this.btnSection10Man.Click += new System.EventHandler(this.btnSection10Man_Click);
            // 
            // btnSection11Man
            // 
            this.btnSection11Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection11Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection11Man.Enabled = false;
            this.btnSection11Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection11Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection11Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection11Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection11Man.Location = new System.Drawing.Point(777, 101);
            this.btnSection11Man.Name = "btnSection11Man";
            this.btnSection11Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection11Man.TabIndex = 176;
            this.btnSection11Man.Text = "11";
            this.btnSection11Man.UseVisualStyleBackColor = false;
            this.btnSection11Man.Click += new System.EventHandler(this.btnSection11Man_Click);
            // 
            // btnSection12Man
            // 
            this.btnSection12Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection12Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection12Man.Enabled = false;
            this.btnSection12Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection12Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection12Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection12Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection12Man.Location = new System.Drawing.Point(777, 127);
            this.btnSection12Man.Name = "btnSection12Man";
            this.btnSection12Man.Size = new System.Drawing.Size(34, 25);
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
            this.oglMain.Location = new System.Drawing.Point(81, 39);
            this.oglMain.Margin = new System.Windows.Forms.Padding(0);
            this.oglMain.Name = "oglMain";
            this.oglMain.Size = new System.Drawing.Size(832, 587);
            this.oglMain.TabIndex = 180;
            this.oglMain.VSync = false;
            this.oglMain.Load += new System.EventHandler(this.oglMain_Load);
            this.oglMain.Paint += new System.Windows.Forms.PaintEventHandler(this.oglMain_Paint);
            this.oglMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.oglMain_MouseDown);
            this.oglMain.Resize += new System.EventHandler(this.oglMain_Resize);
            // 
            // oglBack
            // 
            this.oglBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.oglBack.BackColor = System.Drawing.Color.Black;
            this.oglBack.ForeColor = System.Drawing.Color.Transparent;
            this.oglBack.Location = new System.Drawing.Point(122, 70);
            this.oglBack.Margin = new System.Windows.Forms.Padding(1);
            this.oglBack.Name = "oglBack";
            this.oglBack.Size = new System.Drawing.Size(500, 300);
            this.oglBack.TabIndex = 181;
            this.oglBack.VSync = false;
            this.oglBack.Load += new System.EventHandler(this.oglBack_Load);
            this.oglBack.Paint += new System.Windows.Forms.PaintEventHandler(this.oglBack_Paint);
            this.oglBack.Resize += new System.EventHandler(this.oglBack_Resize);
            // 
            // lblHz
            // 
            this.lblHz.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblHz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHz.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHz.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblHz.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHz.Location = new System.Drawing.Point(92, 234);
            this.lblHz.Name = "lblHz";
            this.lblHz.Size = new System.Drawing.Size(84, 78);
            this.lblHz.TabIndex = 249;
            this.lblHz.Text = "5 Hz 32\r\nPPS";
            this.lblHz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.ColumnCount = 1;
            this.panelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRight.Controls.Add(this.btnCycleLinesBk, 0, 4);
            this.panelRight.Controls.Add(this.btnCurve, 0, 1);
            this.panelRight.Controls.Add(this.btnContour, 0, 0);
            this.panelRight.Controls.Add(this.btnABLine, 0, 2);
            this.panelRight.Controls.Add(this.btnCycleLines, 0, 3);
            this.panelRight.Controls.Add(this.btnAutoSteer, 0, 8);
            this.panelRight.Controls.Add(this.btnAutoYouTurn, 0, 7);
            this.panelRight.Controls.Add(this.btnSectionMasterAuto, 0, 6);
            this.panelRight.Controls.Add(this.btnSectionMasterManual, 0, 5);
            this.panelRight.Location = new System.Drawing.Point(916, 44);
            this.panelRight.Name = "panelRight";
            this.panelRight.RowCount = 9;
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.panelRight.Size = new System.Drawing.Size(75, 652);
            this.panelRight.TabIndex = 320;
            // 
            // btnCycleLinesBk
            // 
            this.btnCycleLinesBk.BackColor = System.Drawing.Color.Transparent;
            this.btnCycleLinesBk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCycleLinesBk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCycleLinesBk.Enabled = false;
            this.btnCycleLinesBk.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCycleLinesBk.FlatAppearance.BorderSize = 0;
            this.btnCycleLinesBk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCycleLinesBk.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCycleLinesBk.Image = global::AgOpenGPS.Properties.Resources.ABLineCycleBk;
            this.btnCycleLinesBk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCycleLinesBk.Location = new System.Drawing.Point(3, 291);
            this.btnCycleLinesBk.Name = "btnCycleLinesBk";
            this.btnCycleLinesBk.Size = new System.Drawing.Size(69, 66);
            this.btnCycleLinesBk.TabIndex = 252;
            this.btnCycleLinesBk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCycleLinesBk.UseVisualStyleBackColor = false;
            this.btnCycleLinesBk.Click += new System.EventHandler(this.btnCycleLinesBk_Click);
            // 
            // btnCurve
            // 
            this.btnCurve.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCurve.Enabled = false;
            this.btnCurve.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCurve.FlatAppearance.BorderSize = 0;
            this.btnCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurve.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurve.Image = global::AgOpenGPS.Properties.Resources.CurveOff;
            this.btnCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCurve.Location = new System.Drawing.Point(0, 74);
            this.btnCurve.Margin = new System.Windows.Forms.Padding(0);
            this.btnCurve.Name = "btnCurve";
            this.btnCurve.Size = new System.Drawing.Size(75, 67);
            this.btnCurve.TabIndex = 173;
            this.btnCurve.Text = "1 / 7";
            this.btnCurve.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCurve.UseVisualStyleBackColor = false;
            this.btnCurve.Click += new System.EventHandler(this.btnCurve_Click);
            // 
            // btnContour
            // 
            this.btnContour.BackColor = System.Drawing.Color.Transparent;
            this.btnContour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnContour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnContour.Enabled = false;
            this.btnContour.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnContour.FlatAppearance.BorderSize = 0;
            this.btnContour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContour.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContour.Image = global::AgOpenGPS.Properties.Resources.ContourOff;
            this.btnContour.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnContour.Location = new System.Drawing.Point(3, 3);
            this.btnContour.Name = "btnContour";
            this.btnContour.Size = new System.Drawing.Size(69, 66);
            this.btnContour.TabIndex = 105;
            this.btnContour.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContour.UseVisualStyleBackColor = false;
            this.btnContour.Click += new System.EventHandler(this.btnContour_Click);
            // 
            // btnABLine
            // 
            this.btnABLine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnABLine.BackColor = System.Drawing.Color.Transparent;
            this.btnABLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnABLine.Enabled = false;
            this.btnABLine.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnABLine.FlatAppearance.BorderSize = 0;
            this.btnABLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnABLine.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineOff;
            this.btnABLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnABLine.Location = new System.Drawing.Point(0, 146);
            this.btnABLine.Margin = new System.Windows.Forms.Padding(0);
            this.btnABLine.Name = "btnABLine";
            this.btnABLine.Size = new System.Drawing.Size(75, 67);
            this.btnABLine.TabIndex = 0;
            this.btnABLine.Text = "2 / 3";
            this.btnABLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnABLine.UseVisualStyleBackColor = false;
            this.btnABLine.Click += new System.EventHandler(this.btnABLine_Click);
            // 
            // btnCycleLines
            // 
            this.btnCycleLines.BackColor = System.Drawing.Color.Transparent;
            this.btnCycleLines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCycleLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCycleLines.Enabled = false;
            this.btnCycleLines.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCycleLines.FlatAppearance.BorderSize = 0;
            this.btnCycleLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCycleLines.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCycleLines.Image = global::AgOpenGPS.Properties.Resources.ABLineCycle;
            this.btnCycleLines.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCycleLines.Location = new System.Drawing.Point(3, 219);
            this.btnCycleLines.Name = "btnCycleLines";
            this.btnCycleLines.Size = new System.Drawing.Size(69, 66);
            this.btnCycleLines.TabIndex = 251;
            this.btnCycleLines.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCycleLines.UseVisualStyleBackColor = false;
            this.btnCycleLines.Click += new System.EventHandler(this.btnCycleLines_Click);
            // 
            // btnAutoSteer
            // 
            this.btnAutoSteer.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoSteer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAutoSteer.Enabled = false;
            this.btnAutoSteer.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnAutoSteer.FlatAppearance.BorderSize = 0;
            this.btnAutoSteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoSteer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnAutoSteer.Image = global::AgOpenGPS.Properties.Resources.AutoSteerOff;
            this.btnAutoSteer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAutoSteer.Location = new System.Drawing.Point(0, 576);
            this.btnAutoSteer.Margin = new System.Windows.Forms.Padding(0);
            this.btnAutoSteer.Name = "btnAutoSteer";
            this.btnAutoSteer.Size = new System.Drawing.Size(75, 76);
            this.btnAutoSteer.TabIndex = 128;
            this.btnAutoSteer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAutoSteer.UseVisualStyleBackColor = false;
            this.btnAutoSteer.Click += new System.EventHandler(this.btnAutoSteer_Click);
            // 
            // btnAutoYouTurn
            // 
            this.btnAutoYouTurn.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoYouTurn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAutoYouTurn.Enabled = false;
            this.btnAutoYouTurn.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnAutoYouTurn.FlatAppearance.BorderSize = 0;
            this.btnAutoYouTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoYouTurn.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnAutoYouTurn.Image = global::AgOpenGPS.Properties.Resources.YouTurnNo;
            this.btnAutoYouTurn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAutoYouTurn.Location = new System.Drawing.Point(3, 507);
            this.btnAutoYouTurn.Name = "btnAutoYouTurn";
            this.btnAutoYouTurn.Size = new System.Drawing.Size(69, 66);
            this.btnAutoYouTurn.TabIndex = 132;
            this.btnAutoYouTurn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAutoYouTurn.UseVisualStyleBackColor = false;
            this.btnAutoYouTurn.Click += new System.EventHandler(this.btnAutoYouTurn_Click);
            // 
            // btnSectionMasterAuto
            // 
            this.btnSectionMasterAuto.BackColor = System.Drawing.Color.Transparent;
            this.btnSectionMasterAuto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSectionMasterAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSectionMasterAuto.Enabled = false;
            this.btnSectionMasterAuto.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSectionMasterAuto.FlatAppearance.BorderSize = 0;
            this.btnSectionMasterAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSectionMasterAuto.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSectionMasterAuto.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;
            this.btnSectionMasterAuto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSectionMasterAuto.Location = new System.Drawing.Point(0, 432);
            this.btnSectionMasterAuto.Margin = new System.Windows.Forms.Padding(0);
            this.btnSectionMasterAuto.Name = "btnSectionMasterAuto";
            this.btnSectionMasterAuto.Size = new System.Drawing.Size(75, 72);
            this.btnSectionMasterAuto.TabIndex = 152;
            this.btnSectionMasterAuto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSectionMasterAuto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSectionMasterAuto.UseVisualStyleBackColor = false;
            this.btnSectionMasterAuto.Click += new System.EventHandler(this.btnSectionMasterAuto_Click);
            // 
            // btnSectionMasterManual
            // 
            this.btnSectionMasterManual.BackColor = System.Drawing.Color.Transparent;
            this.btnSectionMasterManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSectionMasterManual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSectionMasterManual.Enabled = false;
            this.btnSectionMasterManual.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSectionMasterManual.FlatAppearance.BorderSize = 0;
            this.btnSectionMasterManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSectionMasterManual.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSectionMasterManual.Image = global::AgOpenGPS.Properties.Resources.ManualOff;
            this.btnSectionMasterManual.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSectionMasterManual.Location = new System.Drawing.Point(3, 363);
            this.btnSectionMasterManual.Name = "btnSectionMasterManual";
            this.btnSectionMasterManual.Size = new System.Drawing.Size(69, 66);
            this.btnSectionMasterManual.TabIndex = 98;
            this.btnSectionMasterManual.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSectionMasterManual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSectionMasterManual.UseVisualStyleBackColor = false;
            this.btnSectionMasterManual.Click += new System.EventHandler(this.btnSectionMasterManual_Click);
            // 
            // statusStripLeft
            // 
            this.statusStripLeft.AllowMerge = false;
            this.statusStripLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.statusStripLeft.AutoSize = false;
            this.statusStripLeft.BackColor = System.Drawing.Color.Transparent;
            this.statusStripLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.statusStripLeft.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStripLeft.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStripLeft.GripMargin = new System.Windows.Forms.Padding(0);
            this.statusStripLeft.ImageScalingSize = new System.Drawing.Size(60, 60);
            this.statusStripLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.distanceToolBtn,
            this.simplifyToolStrip,
            this.toolStripDropDownButton4,
            this.toolStripBtnFieldTools});
            this.statusStripLeft.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStripLeft.Location = new System.Drawing.Point(2, 3);
            this.statusStripLeft.Name = "statusStripLeft";
            this.statusStripLeft.Size = new System.Drawing.Size(67, 294);
            this.statusStripLeft.SizingGrip = false;
            this.statusStripLeft.TabIndex = 324;
            this.statusStripLeft.Text = "UDP";
            // 
            // distanceToolBtn
            // 
            this.distanceToolBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.distanceToolBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distanceToolBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.distanceToolBtn.Name = "distanceToolBtn";
            this.distanceToolBtn.ShowDropDownArrow = false;
            this.distanceToolBtn.Size = new System.Drawing.Size(54, 20);
            this.distanceToolBtn.Text = "2345m";
            this.distanceToolBtn.Click += new System.EventHandler(this.toolStripDropDownButtonDistance_Click);
            // 
            // simplifyToolStrip
            // 
            this.simplifyToolStrip.AutoSize = false;
            this.simplifyToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.simplifyToolStrip.Image = global::AgOpenGPS.Properties.Resources.NavigationSettings;
            this.simplifyToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.simplifyToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.simplifyToolStrip.Margin = new System.Windows.Forms.Padding(0);
            this.simplifyToolStrip.Name = "simplifyToolStrip";
            this.simplifyToolStrip.ShowDropDownArrow = false;
            this.simplifyToolStrip.Size = new System.Drawing.Size(66, 64);
            this.simplifyToolStrip.Text = "toolStripDropDownButton4";
            this.simplifyToolStrip.Click += new System.EventHandler(this.navPanelToolStrip_Click);
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.AutoSize = false;
            this.toolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wizardsMenu,
            this.steerChartStripMenu,
            this.SmoothABtoolStripMenu,
            this.deleteContourPathsToolStripMenuItem,
            this.deleteAppliedAreaToolStripMenuItem,
            this.webcamToolStrip,
            this.offsetFixToolStrip});
            this.toolStripDropDownButton4.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton4.Image = global::AgOpenGPS.Properties.Resources.SpecialFunctions;
            this.toolStripDropDownButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.ShowDropDownArrow = false;
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(66, 90);
            this.toolStripDropDownButton4.Text = "toolStripDropDownButton3";
            // 
            // wizardsMenu
            // 
            this.wizardsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.steerWizardMenuItem});
            this.wizardsMenu.Image = global::AgOpenGPS.Properties.Resources.WizardWand;
            this.wizardsMenu.Name = "wizardsMenu";
            this.wizardsMenu.Size = new System.Drawing.Size(426, 70);
            this.wizardsMenu.Text = "Wizards";
            // 
            // steerWizardMenuItem
            // 
            this.steerWizardMenuItem.Image = global::AgOpenGPS.Properties.Resources.AutoSteerOn;
            this.steerWizardMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.steerWizardMenuItem.Name = "steerWizardMenuItem";
            this.steerWizardMenuItem.Size = new System.Drawing.Size(278, 40);
            this.steerWizardMenuItem.Text = "Steer Wizard";
            this.steerWizardMenuItem.Click += new System.EventHandler(this.steerWizardMenuItem_Click);
            // 
            // steerChartStripMenu
            // 
            this.steerChartStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.steerChartToolStripMenuItem,
            this.headingChartToolStripMenuItem,
            this.xTEChartToolStripMenuItem,
            this.rollCheckToolStripMenuItem});
            this.steerChartStripMenu.Image = global::AgOpenGPS.Properties.Resources.Chart;
            this.steerChartStripMenu.Name = "steerChartStripMenu";
            this.steerChartStripMenu.Size = new System.Drawing.Size(426, 70);
            this.steerChartStripMenu.Text = "Charts";
            // 
            // steerChartToolStripMenuItem
            // 
            this.steerChartToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.AutoSteerOn;
            this.steerChartToolStripMenuItem.Name = "steerChartToolStripMenuItem";
            this.steerChartToolStripMenuItem.Size = new System.Drawing.Size(299, 40);
            this.steerChartToolStripMenuItem.Text = "Steer Chart";
            this.steerChartToolStripMenuItem.Click += new System.EventHandler(this.toolStripAutoSteerChart_Click);
            // 
            // headingChartToolStripMenuItem
            // 
            this.headingChartToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.ConS_SourcesHeading;
            this.headingChartToolStripMenuItem.Name = "headingChartToolStripMenuItem";
            this.headingChartToolStripMenuItem.Size = new System.Drawing.Size(299, 40);
            this.headingChartToolStripMenuItem.Text = "Heading Chart";
            this.headingChartToolStripMenuItem.Click += new System.EventHandler(this.headingChartToolStripMenuItem_Click);
            // 
            // xTEChartToolStripMenuItem
            // 
            this.xTEChartToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.AutoManualIsAuto;
            this.xTEChartToolStripMenuItem.Name = "xTEChartToolStripMenuItem";
            this.xTEChartToolStripMenuItem.Size = new System.Drawing.Size(299, 40);
            this.xTEChartToolStripMenuItem.Text = "XTE Chart";
            this.xTEChartToolStripMenuItem.Click += new System.EventHandler(this.xTEChartToolStripMenuItem_Click);
            // 
            // rollCheckToolStripMenuItem
            // 
            this.rollCheckToolStripMenuItem.Name = "rollCheckToolStripMenuItem";
            this.rollCheckToolStripMenuItem.Size = new System.Drawing.Size(299, 40);
            this.rollCheckToolStripMenuItem.Text = "Roll Check";
            this.rollCheckToolStripMenuItem.Click += new System.EventHandler(this.correctionToolStrip_Click);
            // 
            // SmoothABtoolStripMenu
            // 
            this.SmoothABtoolStripMenu.Image = global::AgOpenGPS.Properties.Resources.ABSmooth;
            this.SmoothABtoolStripMenu.Name = "SmoothABtoolStripMenu";
            this.SmoothABtoolStripMenu.Size = new System.Drawing.Size(426, 70);
            this.SmoothABtoolStripMenu.Text = "Smooth AB Curve";
            this.SmoothABtoolStripMenu.Click += new System.EventHandler(this.SmoothABtoolStripMenu_Click);
            // 
            // deleteContourPathsToolStripMenuItem
            // 
            this.deleteContourPathsToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.Trash;
            this.deleteContourPathsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteContourPathsToolStripMenuItem.Name = "deleteContourPathsToolStripMenuItem";
            this.deleteContourPathsToolStripMenuItem.Size = new System.Drawing.Size(426, 70);
            this.deleteContourPathsToolStripMenuItem.Text = "Hide Contour Paths";
            this.deleteContourPathsToolStripMenuItem.Click += new System.EventHandler(this.deleteContourPathsToolStripMenuItem_Click);
            // 
            // deleteAppliedAreaToolStripMenuItem
            // 
            this.deleteAppliedAreaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteForSureToolStripMenuItem});
            this.deleteAppliedAreaToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.Trash;
            this.deleteAppliedAreaToolStripMenuItem.Name = "deleteAppliedAreaToolStripMenuItem";
            this.deleteAppliedAreaToolStripMenuItem.Size = new System.Drawing.Size(426, 70);
            this.deleteAppliedAreaToolStripMenuItem.Text = "Delete Applied Area";
            // 
            // deleteForSureToolStripMenuItem
            // 
            this.deleteForSureToolStripMenuItem.Name = "deleteForSureToolStripMenuItem";
            this.deleteForSureToolStripMenuItem.Size = new System.Drawing.Size(317, 40);
            this.deleteForSureToolStripMenuItem.Text = "Delete For Sure";
            this.deleteForSureToolStripMenuItem.Click += new System.EventHandler(this.toolStripAreYouSure_Click);
            // 
            // webcamToolStrip
            // 
            this.webcamToolStrip.Image = global::AgOpenGPS.Properties.Resources.Webcam;
            this.webcamToolStrip.Name = "webcamToolStrip";
            this.webcamToolStrip.Size = new System.Drawing.Size(426, 70);
            this.webcamToolStrip.Text = "WebCam";
            this.webcamToolStrip.Click += new System.EventHandler(this.webcamToolStrip_Click);
            // 
            // offsetFixToolStrip
            // 
            this.offsetFixToolStrip.Image = global::AgOpenGPS.Properties.Resources.YouTurnReverse;
            this.offsetFixToolStrip.Name = "offsetFixToolStrip";
            this.offsetFixToolStrip.Size = new System.Drawing.Size(426, 70);
            this.offsetFixToolStrip.Text = "Offset Fix";
            this.offsetFixToolStrip.Click += new System.EventHandler(this.offsetFixToolStrip_Click);
            // 
            // toolStripBtnFieldTools
            // 
            this.toolStripBtnFieldTools.AutoSize = false;
            this.toolStripBtnFieldTools.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripBtnFieldTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnFieldTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boundariesToolStripMenuItem,
            this.headlandToolStripMenuItem,
            this.headlandBuildToolStripMenuItem,
            this.tramLinesMenuField,
            this.recordedPathStripMenu});
            this.toolStripBtnFieldTools.Enabled = false;
            this.toolStripBtnFieldTools.Font = new System.Drawing.Font("Tahoma", 18F);
            this.toolStripBtnFieldTools.Image = global::AgOpenGPS.Properties.Resources.FieldTools;
            this.toolStripBtnFieldTools.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnFieldTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnFieldTools.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripBtnFieldTools.Name = "toolStripBtnFieldTools";
            this.toolStripBtnFieldTools.ShowDropDownArrow = false;
            this.toolStripBtnFieldTools.Size = new System.Drawing.Size(65, 100);
            this.toolStripBtnFieldTools.Click += new System.EventHandler(this.toolStripBtnFieldTools_Click);
            // 
            // boundariesToolStripMenuItem
            // 
            this.boundariesToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.Boundary;
            this.boundariesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.boundariesToolStripMenuItem.Name = "boundariesToolStripMenuItem";
            this.boundariesToolStripMenuItem.Size = new System.Drawing.Size(309, 70);
            this.boundariesToolStripMenuItem.Text = "Boundary";
            this.boundariesToolStripMenuItem.Click += new System.EventHandler(this.boundariesToolStripMenuItem_Click);
            // 
            // headlandToolStripMenuItem
            // 
            this.headlandToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.HeadlandBuild;
            this.headlandToolStripMenuItem.Name = "headlandToolStripMenuItem";
            this.headlandToolStripMenuItem.Size = new System.Drawing.Size(309, 70);
            this.headlandToolStripMenuItem.Text = "Headland";
            this.headlandToolStripMenuItem.Click += new System.EventHandler(this.headlandToolStripMenuItem_Click);
            // 
            // headlandBuildToolStripMenuItem
            // 
            this.headlandBuildToolStripMenuItem.Image = global::AgOpenGPS.Properties.Resources.Headache;
            this.headlandBuildToolStripMenuItem.Name = "headlandBuildToolStripMenuItem";
            this.headlandBuildToolStripMenuItem.Size = new System.Drawing.Size(309, 70);
            this.headlandBuildToolStripMenuItem.Text = "Headland (Build)";
            this.headlandBuildToolStripMenuItem.Click += new System.EventHandler(this.headlandBuildToolStripMenuItem_Click);
            // 
            // tramLinesMenuField
            // 
            this.tramLinesMenuField.Image = global::AgOpenGPS.Properties.Resources.ABTramLine;
            this.tramLinesMenuField.Name = "tramLinesMenuField";
            this.tramLinesMenuField.Size = new System.Drawing.Size(309, 70);
            this.tramLinesMenuField.Text = "TramLines";
            this.tramLinesMenuField.Click += new System.EventHandler(this.tramLinesMenuField_Click);
            // 
            // recordedPathStripMenu
            // 
            this.recordedPathStripMenu.Image = global::AgOpenGPS.Properties.Resources.RecPath;
            this.recordedPathStripMenu.Name = "recordedPathStripMenu";
            this.recordedPathStripMenu.Size = new System.Drawing.Size(309, 70);
            this.recordedPathStripMenu.Text = "Recorded Path";
            this.recordedPathStripMenu.Click += new System.EventHandler(this.recordedPathStripMenu_Click);
            // 
            // panelSim
            // 
            this.panelSim.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelSim.BackColor = System.Drawing.Color.Transparent;
            this.panelSim.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelSim.ColumnCount = 8;
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.panelSim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelSim.Controls.Add(this.btnSpeedDn, 5, 0);
            this.panelSim.Controls.Add(this.btnSimSpeedUp, 7, 0);
            this.panelSim.Controls.Add(this.btnResetSim, 0, 0);
            this.panelSim.Controls.Add(this.btnSimSetSpeedToZero, 6, 0);
            this.panelSim.Controls.Add(this.btnResetSteerAngle, 1, 0);
            this.panelSim.Controls.Add(this.hsbarSteerAngle, 3, 0);
            this.panelSim.Location = new System.Drawing.Point(283, 587);
            this.panelSim.Name = "panelSim";
            this.panelSim.RowCount = 1;
            this.panelSim.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSim.Size = new System.Drawing.Size(538, 33);
            this.panelSim.TabIndex = 325;
            // 
            // btnSpeedDn
            // 
            this.btnSpeedDn.BackColor = System.Drawing.Color.Transparent;
            this.btnSpeedDn.BackgroundImage = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnSpeedDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSpeedDn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSpeedDn.FlatAppearance.BorderSize = 0;
            this.btnSpeedDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeedDn.Location = new System.Drawing.Point(374, 4);
            this.btnSpeedDn.Name = "btnSpeedDn";
            this.btnSpeedDn.Size = new System.Drawing.Size(41, 25);
            this.btnSpeedDn.TabIndex = 533;
            this.btnSpeedDn.UseVisualStyleBackColor = false;
            this.btnSpeedDn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSpeedDn_MouseDown);
            // 
            // btnSimSpeedUp
            // 
            this.btnSimSpeedUp.BackColor = System.Drawing.Color.Transparent;
            this.btnSimSpeedUp.BackgroundImage = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnSimSpeedUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSimSpeedUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSimSpeedUp.FlatAppearance.BorderSize = 0;
            this.btnSimSpeedUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimSpeedUp.Location = new System.Drawing.Point(493, 4);
            this.btnSimSpeedUp.Name = "btnSimSpeedUp";
            this.btnSimSpeedUp.Size = new System.Drawing.Size(41, 25);
            this.btnSimSpeedUp.TabIndex = 532;
            this.btnSimSpeedUp.UseVisualStyleBackColor = false;
            this.btnSimSpeedUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSimSpeedUp_MouseDown);
            // 
            // btnSimSetSpeedToZero
            // 
            this.btnSimSetSpeedToZero.BackColor = System.Drawing.Color.Transparent;
            this.btnSimSetSpeedToZero.BackgroundImage = global::AgOpenGPS.Properties.Resources.AutoStop;
            this.btnSimSetSpeedToZero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSimSetSpeedToZero.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnSimSetSpeedToZero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSimSetSpeedToZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimSetSpeedToZero.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnSimSetSpeedToZero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSimSetSpeedToZero.Location = new System.Drawing.Point(422, 4);
            this.btnSimSetSpeedToZero.Name = "btnSimSetSpeedToZero";
            this.btnSimSetSpeedToZero.Size = new System.Drawing.Size(64, 25);
            this.btnSimSetSpeedToZero.TabIndex = 453;
            this.btnSimSetSpeedToZero.UseVisualStyleBackColor = false;
            this.btnSimSetSpeedToZero.Click += new System.EventHandler(this.btnSimSetSpeedToZero_Click);
            // 
            // btnSection16Man
            // 
            this.btnSection16Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection16Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection16Man.Enabled = false;
            this.btnSection16Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection16Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection16Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection16Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection16Man.Location = new System.Drawing.Point(777, 234);
            this.btnSection16Man.Name = "btnSection16Man";
            this.btnSection16Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection16Man.TabIndex = 448;
            this.btnSection16Man.Text = "16";
            this.btnSection16Man.UseVisualStyleBackColor = false;
            this.btnSection16Man.Click += new System.EventHandler(this.btnSection16Man_Click);
            // 
            // btnSection15Man
            // 
            this.btnSection15Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection15Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection15Man.Enabled = false;
            this.btnSection15Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection15Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection15Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection15Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection15Man.Location = new System.Drawing.Point(777, 207);
            this.btnSection15Man.Name = "btnSection15Man";
            this.btnSection15Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection15Man.TabIndex = 449;
            this.btnSection15Man.Text = "15";
            this.btnSection15Man.UseVisualStyleBackColor = false;
            this.btnSection15Man.Click += new System.EventHandler(this.btnSection15Man_Click);
            // 
            // btnSection14Man
            // 
            this.btnSection14Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection14Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection14Man.Enabled = false;
            this.btnSection14Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection14Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection14Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection14Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection14Man.Location = new System.Drawing.Point(777, 180);
            this.btnSection14Man.Name = "btnSection14Man";
            this.btnSection14Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection14Man.TabIndex = 450;
            this.btnSection14Man.Text = "14";
            this.btnSection14Man.UseVisualStyleBackColor = false;
            this.btnSection14Man.Click += new System.EventHandler(this.btnSection14Man_Click);
            // 
            // btnSection13Man
            // 
            this.btnSection13Man.BackColor = System.Drawing.Color.Silver;
            this.btnSection13Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSection13Man.Enabled = false;
            this.btnSection13Man.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSection13Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSection13Man.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSection13Man.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSection13Man.Location = new System.Drawing.Point(777, 153);
            this.btnSection13Man.Name = "btnSection13Man";
            this.btnSection13Man.Size = new System.Drawing.Size(34, 25);
            this.btnSection13Man.TabIndex = 451;
            this.btnSection13Man.Text = "13";
            this.btnSection13Man.UseVisualStyleBackColor = false;
            this.btnSection13Man.Click += new System.EventHandler(this.btnSection13Man_Click);
            // 
            // panelNavigation
            // 
            this.panelNavigation.BackColor = System.Drawing.Color.White;
            this.panelNavigation.ColumnCount = 2;
            this.panelNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelNavigation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelNavigation.Controls.Add(this.btnN3D, 1, 2);
            this.panelNavigation.Controls.Add(this.btnpTiltUp, 1, 0);
            this.panelNavigation.Controls.Add(this.btnpTiltDown, 0, 0);
            this.panelNavigation.Controls.Add(this.btnN2D, 0, 2);
            this.panelNavigation.Controls.Add(this.btn3D, 1, 1);
            this.panelNavigation.Controls.Add(this.btn2D, 0, 1);
            this.panelNavigation.Controls.Add(this.btnDayNightMode, 0, 3);
            this.panelNavigation.Controls.Add(this.lblHz, 1, 3);
            this.panelNavigation.Controls.Add(this.btnBrightnessUp, 1, 4);
            this.panelNavigation.Controls.Add(this.btnBrightnessDn, 0, 4);
            this.panelNavigation.Location = new System.Drawing.Point(455, 50);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.RowCount = 5;
            this.panelNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.panelNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.panelNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.panelNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.panelNavigation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.panelNavigation.Size = new System.Drawing.Size(179, 392);
            this.panelNavigation.TabIndex = 468;
            this.panelNavigation.Visible = false;
            // 
            // btnN3D
            // 
            this.btnN3D.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnN3D.BackColor = System.Drawing.Color.Transparent;
            this.btnN3D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnN3D.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnN3D.FlatAppearance.BorderSize = 0;
            this.btnN3D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnN3D.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnN3D.Image = global::AgOpenGPS.Properties.Resources.CameraNorth64;
            this.btnN3D.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnN3D.Location = new System.Drawing.Point(105, 167);
            this.btnN3D.Name = "btnN3D";
            this.btnN3D.Size = new System.Drawing.Size(57, 55);
            this.btnN3D.TabIndex = 472;
            this.btnN3D.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnN3D.UseVisualStyleBackColor = false;
            this.btnN3D.Click += new System.EventHandler(this.btnN3D_Click);
            // 
            // btnpTiltUp
            // 
            this.btnpTiltUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnpTiltUp.BackColor = System.Drawing.Color.Transparent;
            this.btnpTiltUp.BackgroundImage = global::AgOpenGPS.Properties.Resources.TiltUp;
            this.btnpTiltUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnpTiltUp.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnpTiltUp.FlatAppearance.BorderSize = 0;
            this.btnpTiltUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpTiltUp.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnpTiltUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnpTiltUp.Location = new System.Drawing.Point(102, 7);
            this.btnpTiltUp.Name = "btnpTiltUp";
            this.btnpTiltUp.Size = new System.Drawing.Size(63, 63);
            this.btnpTiltUp.TabIndex = 447;
            this.btnpTiltUp.UseVisualStyleBackColor = false;
            this.btnpTiltUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnpTiltUp_MouseDown);
            // 
            // btnpTiltDown
            // 
            this.btnpTiltDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnpTiltDown.BackColor = System.Drawing.Color.Transparent;
            this.btnpTiltDown.BackgroundImage = global::AgOpenGPS.Properties.Resources.TiltDown;
            this.btnpTiltDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnpTiltDown.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnpTiltDown.FlatAppearance.BorderSize = 0;
            this.btnpTiltDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpTiltDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnpTiltDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnpTiltDown.Location = new System.Drawing.Point(13, 7);
            this.btnpTiltDown.Name = "btnpTiltDown";
            this.btnpTiltDown.Size = new System.Drawing.Size(63, 63);
            this.btnpTiltDown.TabIndex = 446;
            this.btnpTiltDown.UseVisualStyleBackColor = false;
            this.btnpTiltDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnpTiltDown_MouseDown);
            // 
            // btnN2D
            // 
            this.btnN2D.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnN2D.BackColor = System.Drawing.Color.Transparent;
            this.btnN2D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnN2D.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnN2D.FlatAppearance.BorderSize = 0;
            this.btnN2D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnN2D.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnN2D.Image = global::AgOpenGPS.Properties.Resources.CameraNorth2D;
            this.btnN2D.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnN2D.Location = new System.Drawing.Point(16, 167);
            this.btnN2D.Name = "btnN2D";
            this.btnN2D.Size = new System.Drawing.Size(57, 55);
            this.btnN2D.TabIndex = 470;
            this.btnN2D.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnN2D.UseVisualStyleBackColor = false;
            this.btnN2D.Click += new System.EventHandler(this.btnN2D_Click);
            // 
            // btn3D
            // 
            this.btn3D.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn3D.BackColor = System.Drawing.Color.Transparent;
            this.btn3D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn3D.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btn3D.FlatAppearance.BorderSize = 0;
            this.btn3D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3D.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3D.Image = global::AgOpenGPS.Properties.Resources.Camera3D64;
            this.btn3D.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn3D.Location = new System.Drawing.Point(105, 89);
            this.btn3D.Name = "btn3D";
            this.btn3D.Size = new System.Drawing.Size(57, 55);
            this.btn3D.TabIndex = 471;
            this.btn3D.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn3D.UseVisualStyleBackColor = false;
            this.btn3D.Click += new System.EventHandler(this.btn3D_Click);
            // 
            // btn2D
            // 
            this.btn2D.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn2D.BackColor = System.Drawing.Color.Transparent;
            this.btn2D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn2D.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btn2D.FlatAppearance.BorderSize = 0;
            this.btn2D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2D.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2D.Image = global::AgOpenGPS.Properties.Resources.Camera2D64;
            this.btn2D.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn2D.Location = new System.Drawing.Point(16, 89);
            this.btn2D.Name = "btn2D";
            this.btn2D.Size = new System.Drawing.Size(57, 55);
            this.btn2D.TabIndex = 469;
            this.btn2D.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn2D.UseVisualStyleBackColor = false;
            this.btn2D.Click += new System.EventHandler(this.btn2D_Click);
            // 
            // btnDayNightMode
            // 
            this.btnDayNightMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDayNightMode.BackColor = System.Drawing.Color.Transparent;
            this.btnDayNightMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDayNightMode.FlatAppearance.BorderSize = 0;
            this.btnDayNightMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDayNightMode.Image = global::AgOpenGPS.Properties.Resources.WindowNightMode;
            this.btnDayNightMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDayNightMode.Location = new System.Drawing.Point(16, 245);
            this.btnDayNightMode.Name = "btnDayNightMode";
            this.btnDayNightMode.Size = new System.Drawing.Size(57, 55);
            this.btnDayNightMode.TabIndex = 452;
            this.btnDayNightMode.UseVisualStyleBackColor = false;
            this.btnDayNightMode.Click += new System.EventHandler(this.btnDayNightMode_Click);
            // 
            // btnBrightnessUp
            // 
            this.btnBrightnessUp.BackColor = System.Drawing.Color.Transparent;
            this.btnBrightnessUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBrightnessUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrightnessUp.FlatAppearance.BorderSize = 0;
            this.btnBrightnessUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrightnessUp.Image = global::AgOpenGPS.Properties.Resources.BrightnessUp;
            this.btnBrightnessUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrightnessUp.Location = new System.Drawing.Point(92, 315);
            this.btnBrightnessUp.Name = "btnBrightnessUp";
            this.btnBrightnessUp.Size = new System.Drawing.Size(84, 74);
            this.btnBrightnessUp.TabIndex = 473;
            this.btnBrightnessUp.UseVisualStyleBackColor = false;
            this.btnBrightnessUp.Click += new System.EventHandler(this.btnBrightnessUp_Click);
            // 
            // btnBrightnessDn
            // 
            this.btnBrightnessDn.BackColor = System.Drawing.Color.Transparent;
            this.btnBrightnessDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBrightnessDn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrightnessDn.FlatAppearance.BorderSize = 0;
            this.btnBrightnessDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrightnessDn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrightnessDn.Image = global::AgOpenGPS.Properties.Resources.BrightnessDn;
            this.btnBrightnessDn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrightnessDn.Location = new System.Drawing.Point(3, 315);
            this.btnBrightnessDn.Name = "btnBrightnessDn";
            this.btnBrightnessDn.Size = new System.Drawing.Size(83, 74);
            this.btnBrightnessDn.TabIndex = 474;
            this.btnBrightnessDn.Text = "20%";
            this.btnBrightnessDn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBrightnessDn.UseVisualStyleBackColor = false;
            this.btnBrightnessDn.Click += new System.EventHandler(this.btnBrightnessDn_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 4200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panelAB
            // 
            this.panelAB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAB.BackColor = System.Drawing.Color.Transparent;
            this.panelAB.ColumnCount = 10;
            this.panelAB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.248095F));
            this.panelAB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.217083F));
            this.panelAB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.335134F));
            this.panelAB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.40961F));
            this.panelAB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.40961F));
            this.panelAB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.40961F));
            this.panelAB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.40961F));
            this.panelAB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.40961F));
            this.panelAB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.40961F));
            this.panelAB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.742041F));
            this.panelAB.Controls.Add(this.btnResetToolHeading, 9, 0);
            this.panelAB.Controls.Add(this.btnYouSkipEnable, 0, 0);
            this.panelAB.Controls.Add(this.cboxpRowWidth, 1, 0);
            this.panelAB.Controls.Add(this.btnABDraw, 7, 0);
            this.panelAB.Controls.Add(this.btnChangeMappingColor, 2, 0);
            this.panelAB.Controls.Add(this.btnFlag, 6, 0);
            this.panelAB.Controls.Add(this.btnTramDisplayMode, 3, 0);
            this.panelAB.Controls.Add(this.btnHydLift, 4, 0);
            this.panelAB.Controls.Add(this.btnHeadlandOnOff, 5, 0);
            this.panelAB.Controls.Add(this.btnEditAB, 8, 0);
            this.panelAB.Location = new System.Drawing.Point(89, 627);
            this.panelAB.Name = "panelAB";
            this.panelAB.RowCount = 1;
            this.panelAB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelAB.Size = new System.Drawing.Size(816, 64);
            this.panelAB.TabIndex = 480;
            // 
            // btnResetToolHeading
            // 
            this.btnResetToolHeading.BackColor = System.Drawing.Color.Transparent;
            this.btnResetToolHeading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResetToolHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResetToolHeading.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnResetToolHeading.FlatAppearance.BorderSize = 0;
            this.btnResetToolHeading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetToolHeading.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetToolHeading.ForeColor = System.Drawing.Color.Black;
            this.btnResetToolHeading.Image = global::AgOpenGPS.Properties.Resources.ResetTool;
            this.btnResetToolHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetToolHeading.Location = new System.Drawing.Point(759, 0);
            this.btnResetToolHeading.Margin = new System.Windows.Forms.Padding(0);
            this.btnResetToolHeading.Name = "btnResetToolHeading";
            this.btnResetToolHeading.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnResetToolHeading.Size = new System.Drawing.Size(57, 64);
            this.btnResetToolHeading.TabIndex = 491;
            this.btnResetToolHeading.UseVisualStyleBackColor = false;
            this.btnResetToolHeading.Click += new System.EventHandler(this.btnResetToolHeading_Click);
            // 
            // btnYouSkipEnable
            // 
            this.btnYouSkipEnable.BackColor = System.Drawing.Color.Transparent;
            this.btnYouSkipEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYouSkipEnable.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnYouSkipEnable.FlatAppearance.BorderSize = 0;
            this.btnYouSkipEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYouSkipEnable.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYouSkipEnable.Image = global::AgOpenGPS.Properties.Resources.YouSkipOff;
            this.btnYouSkipEnable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnYouSkipEnable.Location = new System.Drawing.Point(3, 3);
            this.btnYouSkipEnable.Name = "btnYouSkipEnable";
            this.btnYouSkipEnable.Size = new System.Drawing.Size(61, 58);
            this.btnYouSkipEnable.TabIndex = 490;
            this.btnYouSkipEnable.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnYouSkipEnable.UseVisualStyleBackColor = false;
            this.btnYouSkipEnable.Click += new System.EventHandler(this.btnYouSkipEnable_Click);
            // 
            // btnABDraw
            // 
            this.btnABDraw.BackColor = System.Drawing.Color.Transparent;
            this.btnABDraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnABDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnABDraw.Enabled = false;
            this.btnABDraw.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnABDraw.FlatAppearance.BorderSize = 0;
            this.btnABDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnABDraw.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnABDraw.Image = global::AgOpenGPS.Properties.Resources.ABDraw;
            this.btnABDraw.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnABDraw.Location = new System.Drawing.Point(576, 3);
            this.btnABDraw.Name = "btnABDraw";
            this.btnABDraw.Size = new System.Drawing.Size(87, 58);
            this.btnABDraw.TabIndex = 250;
            this.btnABDraw.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnABDraw.UseVisualStyleBackColor = false;
            this.btnABDraw.Visible = false;
            this.btnABDraw.Click += new System.EventHandler(this.btnABDraw_Click);
            // 
            // btnChangeMappingColor
            // 
            this.btnChangeMappingColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChangeMappingColor.BackColor = System.Drawing.Color.SkyBlue;
            this.btnChangeMappingColor.BackgroundImage = global::AgOpenGPS.Properties.Resources.SectionMapping;
            this.btnChangeMappingColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChangeMappingColor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnChangeMappingColor.FlatAppearance.BorderSize = 0;
            this.btnChangeMappingColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeMappingColor.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeMappingColor.ForeColor = System.Drawing.Color.Black;
            this.btnChangeMappingColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnChangeMappingColor.Location = new System.Drawing.Point(133, 3);
            this.btnChangeMappingColor.Margin = new System.Windows.Forms.Padding(0);
            this.btnChangeMappingColor.Name = "btnChangeMappingColor";
            this.btnChangeMappingColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnChangeMappingColor.Size = new System.Drawing.Size(60, 57);
            this.btnChangeMappingColor.TabIndex = 476;
            this.btnChangeMappingColor.Text = "5.8.4";
            this.btnChangeMappingColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChangeMappingColor.UseVisualStyleBackColor = false;
            this.btnChangeMappingColor.Click += new System.EventHandler(this.btnChangeMappingColor_Click);
            // 
            // btnFlag
            // 
            this.btnFlag.BackColor = System.Drawing.Color.Transparent;
            this.btnFlag.ContextMenuStrip = this.contextMenuStripFlag;
            this.btnFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFlag.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnFlag.FlatAppearance.BorderSize = 0;
            this.btnFlag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlag.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFlag.Image = global::AgOpenGPS.Properties.Resources.FlagRed;
            this.btnFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFlag.Location = new System.Drawing.Point(483, 3);
            this.btnFlag.Name = "btnFlag";
            this.btnFlag.Size = new System.Drawing.Size(87, 58);
            this.btnFlag.TabIndex = 121;
            this.btnFlag.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFlag.UseVisualStyleBackColor = false;
            this.btnFlag.Click += new System.EventHandler(this.btnFlag_Click);
            // 
            // btnTramDisplayMode
            // 
            this.btnTramDisplayMode.BackColor = System.Drawing.Color.Transparent;
            this.btnTramDisplayMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTramDisplayMode.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnTramDisplayMode.FlatAppearance.BorderSize = 0;
            this.btnTramDisplayMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTramDisplayMode.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTramDisplayMode.Image = global::AgOpenGPS.Properties.Resources.TramOff;
            this.btnTramDisplayMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTramDisplayMode.Location = new System.Drawing.Point(204, 3);
            this.btnTramDisplayMode.Name = "btnTramDisplayMode";
            this.btnTramDisplayMode.Size = new System.Drawing.Size(87, 58);
            this.btnTramDisplayMode.TabIndex = 480;
            this.btnTramDisplayMode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTramDisplayMode.UseVisualStyleBackColor = false;
            this.btnTramDisplayMode.Click += new System.EventHandler(this.btnTramDisplayMode_Click);
            // 
            // btnHydLift
            // 
            this.btnHydLift.BackColor = System.Drawing.Color.Transparent;
            this.btnHydLift.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHydLift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHydLift.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnHydLift.FlatAppearance.BorderSize = 0;
            this.btnHydLift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHydLift.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnHydLift.Image = global::AgOpenGPS.Properties.Resources.HydraulicLiftOff;
            this.btnHydLift.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHydLift.Location = new System.Drawing.Point(297, 3);
            this.btnHydLift.Name = "btnHydLift";
            this.btnHydLift.Size = new System.Drawing.Size(87, 58);
            this.btnHydLift.TabIndex = 453;
            this.btnHydLift.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHydLift.UseVisualStyleBackColor = false;
            this.btnHydLift.Visible = false;
            this.btnHydLift.Click += new System.EventHandler(this.btnHydLift_Click);
            // 
            // btnHeadlandOnOff
            // 
            this.btnHeadlandOnOff.BackColor = System.Drawing.Color.Transparent;
            this.btnHeadlandOnOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHeadlandOnOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeadlandOnOff.FlatAppearance.BorderSize = 0;
            this.btnHeadlandOnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeadlandOnOff.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeadlandOnOff.Image = global::AgOpenGPS.Properties.Resources.HeadlandOff;
            this.btnHeadlandOnOff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHeadlandOnOff.Location = new System.Drawing.Point(390, 3);
            this.btnHeadlandOnOff.Name = "btnHeadlandOnOff";
            this.btnHeadlandOnOff.Size = new System.Drawing.Size(87, 58);
            this.btnHeadlandOnOff.TabIndex = 447;
            this.btnHeadlandOnOff.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHeadlandOnOff.UseVisualStyleBackColor = false;
            this.btnHeadlandOnOff.Visible = false;
            this.btnHeadlandOnOff.Click += new System.EventHandler(this.btnHeadlandOnOff_Click);
            // 
            // btnEditAB
            // 
            this.btnEditAB.BackColor = System.Drawing.Color.Transparent;
            this.btnEditAB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditAB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditAB.FlatAppearance.BorderSize = 0;
            this.btnEditAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditAB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditAB.Image = global::AgOpenGPS.Properties.Resources.ABSnapNudgeMenu;
            this.btnEditAB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditAB.Location = new System.Drawing.Point(669, 3);
            this.btnEditAB.Name = "btnEditAB";
            this.btnEditAB.Size = new System.Drawing.Size(87, 58);
            this.btnEditAB.TabIndex = 489;
            this.btnEditAB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditAB.UseVisualStyleBackColor = false;
            this.btnEditAB.Visible = false;
            this.btnEditAB.Click += new System.EventHandler(this.btnEditAB_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSpeed.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.ForeColor = System.Drawing.Color.Black;
            this.lblSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSpeed.Location = new System.Drawing.Point(638, 2);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(95, 35);
            this.lblSpeed.TabIndex = 116;
            this.lblSpeed.Text = "88.88";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblSpeed.Click += new System.EventHandler(this.btnGPSData_Click);
            // 
            // lblInty
            // 
            this.lblInty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInty.AutoSize = true;
            this.lblInty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInty.Location = new System.Drawing.Point(-359, 392);
            this.lblInty.Name = "lblInty";
            this.lblInty.Size = new System.Drawing.Size(15, 16);
            this.lblInty.TabIndex = 485;
            this.lblInty.Text = "0";
            this.lblInty.Click += new System.EventHandler(this.lblInty_Click);
            // 
            // lblFix
            // 
            this.lblFix.AutoSize = true;
            this.lblFix.BackColor = System.Drawing.Color.Transparent;
            this.lblFix.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFix.Location = new System.Drawing.Point(84, -1);
            this.lblFix.Name = "lblFix";
            this.lblFix.Size = new System.Drawing.Size(84, 18);
            this.lblFix.TabIndex = 489;
            this.lblFix.Text = "Fix       sec";
            this.lblFix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnZone1
            // 
            this.btnZone1.BackColor = System.Drawing.Color.Silver;
            this.btnZone1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone1.Enabled = false;
            this.btnZone1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone1.Location = new System.Drawing.Point(712, 47);
            this.btnZone1.Name = "btnZone1";
            this.btnZone1.Size = new System.Drawing.Size(59, 25);
            this.btnZone1.TabIndex = 496;
            this.btnZone1.Text = "1";
            this.btnZone1.UseVisualStyleBackColor = false;
            this.btnZone1.Click += new System.EventHandler(this.btnZone1_Click);
            // 
            // btnZone2
            // 
            this.btnZone2.BackColor = System.Drawing.Color.Silver;
            this.btnZone2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone2.Enabled = false;
            this.btnZone2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone2.Location = new System.Drawing.Point(712, 73);
            this.btnZone2.Name = "btnZone2";
            this.btnZone2.Size = new System.Drawing.Size(59, 25);
            this.btnZone2.TabIndex = 497;
            this.btnZone2.Text = "2";
            this.btnZone2.UseVisualStyleBackColor = false;
            this.btnZone2.Click += new System.EventHandler(this.btnZone2_Click);
            // 
            // btnZone3
            // 
            this.btnZone3.BackColor = System.Drawing.Color.Silver;
            this.btnZone3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone3.Enabled = false;
            this.btnZone3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone3.Location = new System.Drawing.Point(712, 99);
            this.btnZone3.Name = "btnZone3";
            this.btnZone3.Size = new System.Drawing.Size(59, 25);
            this.btnZone3.TabIndex = 498;
            this.btnZone3.Text = "3";
            this.btnZone3.UseVisualStyleBackColor = false;
            this.btnZone3.Click += new System.EventHandler(this.btnZone3_Click);
            // 
            // btnZone4
            // 
            this.btnZone4.BackColor = System.Drawing.Color.Silver;
            this.btnZone4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone4.Enabled = false;
            this.btnZone4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone4.Location = new System.Drawing.Point(712, 125);
            this.btnZone4.Name = "btnZone4";
            this.btnZone4.Size = new System.Drawing.Size(59, 25);
            this.btnZone4.TabIndex = 499;
            this.btnZone4.Text = "4";
            this.btnZone4.UseVisualStyleBackColor = false;
            this.btnZone4.Click += new System.EventHandler(this.btnZone4_Click);
            // 
            // btnZone5
            // 
            this.btnZone5.BackColor = System.Drawing.Color.Silver;
            this.btnZone5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone5.Enabled = false;
            this.btnZone5.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone5.Location = new System.Drawing.Point(712, 151);
            this.btnZone5.Name = "btnZone5";
            this.btnZone5.Size = new System.Drawing.Size(59, 25);
            this.btnZone5.TabIndex = 500;
            this.btnZone5.Text = "5";
            this.btnZone5.UseVisualStyleBackColor = false;
            this.btnZone5.Click += new System.EventHandler(this.btnZone5_Click);
            // 
            // btnZone6
            // 
            this.btnZone6.BackColor = System.Drawing.Color.Silver;
            this.btnZone6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone6.Enabled = false;
            this.btnZone6.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone6.Location = new System.Drawing.Point(712, 177);
            this.btnZone6.Name = "btnZone6";
            this.btnZone6.Size = new System.Drawing.Size(59, 25);
            this.btnZone6.TabIndex = 501;
            this.btnZone6.Text = "6";
            this.btnZone6.UseVisualStyleBackColor = false;
            this.btnZone6.Click += new System.EventHandler(this.btnZone6_Click);
            // 
            // btnZone7
            // 
            this.btnZone7.BackColor = System.Drawing.Color.Silver;
            this.btnZone7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone7.Enabled = false;
            this.btnZone7.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone7.Location = new System.Drawing.Point(712, 203);
            this.btnZone7.Name = "btnZone7";
            this.btnZone7.Size = new System.Drawing.Size(59, 25);
            this.btnZone7.TabIndex = 503;
            this.btnZone7.Text = "7";
            this.btnZone7.UseVisualStyleBackColor = false;
            this.btnZone7.Click += new System.EventHandler(this.btnZone7_Click);
            // 
            // btnZone8
            // 
            this.btnZone8.BackColor = System.Drawing.Color.Silver;
            this.btnZone8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZone8.Enabled = false;
            this.btnZone8.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZone8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZone8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZone8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZone8.Location = new System.Drawing.Point(712, 229);
            this.btnZone8.Name = "btnZone8";
            this.btnZone8.Size = new System.Drawing.Size(59, 25);
            this.btnZone8.TabIndex = 504;
            this.btnZone8.Text = "8";
            this.btnZone8.UseVisualStyleBackColor = false;
            this.btnZone8.Click += new System.EventHandler(this.btnZone8_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLeft.ColumnCount = 1;
            this.panelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLeft.Controls.Add(this.btnConfig, 0, 2);
            this.panelLeft.Controls.Add(this.btnStartAgIO, 0, 4);
            this.panelLeft.Controls.Add(this.btnJobMenu, 0, 1);
            this.panelLeft.Controls.Add(this.btnAutoSteerConfig, 0, 3);
            this.panelLeft.Controls.Add(this.statusStripLeft, 0, 0);
            this.panelLeft.Location = new System.Drawing.Point(7, 58);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.RowCount = 5;
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelLeft.Size = new System.Drawing.Size(72, 629);
            this.panelLeft.TabIndex = 529;
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfig.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnConfig.FlatAppearance.BorderSize = 0;
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfig.ForeColor = System.Drawing.Color.DarkGray;
            this.btnConfig.Image = global::AgOpenGPS.Properties.Resources.Settings48;
            this.btnConfig.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConfig.Location = new System.Drawing.Point(0, 382);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnConfig.Size = new System.Drawing.Size(72, 82);
            this.btnConfig.TabIndex = 537;
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnStartAgIO
            // 
            this.btnStartAgIO.BackColor = System.Drawing.Color.Transparent;
            this.btnStartAgIO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartAgIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartAgIO.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnStartAgIO.FlatAppearance.BorderSize = 0;
            this.btnStartAgIO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStartAgIO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStartAgIO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartAgIO.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartAgIO.ForeColor = System.Drawing.Color.DarkGray;
            this.btnStartAgIO.Image = global::AgOpenGPS.Properties.Resources.AgIO;
            this.btnStartAgIO.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStartAgIO.Location = new System.Drawing.Point(0, 546);
            this.btnStartAgIO.Margin = new System.Windows.Forms.Padding(0);
            this.btnStartAgIO.Name = "btnStartAgIO";
            this.btnStartAgIO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnStartAgIO.Size = new System.Drawing.Size(72, 83);
            this.btnStartAgIO.TabIndex = 467;
            this.btnStartAgIO.UseVisualStyleBackColor = false;
            this.btnStartAgIO.Click += new System.EventHandler(this.btnStartAgIO_Click);
            // 
            // btnJobMenu
            // 
            this.btnJobMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnJobMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnJobMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJobMenu.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnJobMenu.FlatAppearance.BorderSize = 0;
            this.btnJobMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnJobMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnJobMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobMenu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobMenu.ForeColor = System.Drawing.Color.DarkGray;
            this.btnJobMenu.Image = global::AgOpenGPS.Properties.Resources.JobActive;
            this.btnJobMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnJobMenu.Location = new System.Drawing.Point(0, 300);
            this.btnJobMenu.Margin = new System.Windows.Forms.Padding(0);
            this.btnJobMenu.Name = "btnJobMenu";
            this.btnJobMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnJobMenu.Size = new System.Drawing.Size(72, 82);
            this.btnJobMenu.TabIndex = 536;
            this.btnJobMenu.UseVisualStyleBackColor = false;
            this.btnJobMenu.Click += new System.EventHandler(this.btnJobMenu_Click);
            // 
            // btnAutoSteerConfig
            // 
            this.btnAutoSteerConfig.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAutoSteerConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoSteerConfig.BackgroundImage = global::AgOpenGPS.Properties.Resources.AutoSteerConf;
            this.btnAutoSteerConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAutoSteerConfig.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.btnAutoSteerConfig.FlatAppearance.BorderSize = 0;
            this.btnAutoSteerConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoSteerConfig.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSteerConfig.ForeColor = System.Drawing.Color.Black;
            this.btnAutoSteerConfig.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAutoSteerConfig.Location = new System.Drawing.Point(5, 475);
            this.btnAutoSteerConfig.Margin = new System.Windows.Forms.Padding(0);
            this.btnAutoSteerConfig.Name = "btnAutoSteerConfig";
            this.btnAutoSteerConfig.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnAutoSteerConfig.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAutoSteerConfig.Size = new System.Drawing.Size(61, 59);
            this.btnAutoSteerConfig.TabIndex = 475;
            this.btnAutoSteerConfig.Text = "-38.8.";
            this.btnAutoSteerConfig.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAutoSteerConfig.UseVisualStyleBackColor = false;
            this.btnAutoSteerConfig.Click += new System.EventHandler(this.btnAutoSteerConfig_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.lblFieldStatus, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblGuidanceLine, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(17, 692);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(958, 22);
            this.tableLayoutPanel2.TabIndex = 533;
            // 
            // lblFieldStatus
            // 
            this.lblFieldStatus.AutoSize = true;
            this.lblFieldStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblFieldStatus.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFieldStatus.Location = new System.Drawing.Point(3, 0);
            this.lblFieldStatus.Name = "lblFieldStatus";
            this.lblFieldStatus.Size = new System.Drawing.Size(123, 22);
            this.lblFieldStatus.TabIndex = 535;
            this.lblFieldStatus.Text = "Field Status";
            this.lblFieldStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblFieldStatus.Click += new System.EventHandler(this.lblFieldStatus_Click);
            // 
            // lblGuidanceLine
            // 
            this.lblGuidanceLine.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGuidanceLine.AutoSize = true;
            this.lblGuidanceLine.BackColor = System.Drawing.Color.Transparent;
            this.lblGuidanceLine.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuidanceLine.Location = new System.Drawing.Point(895, 0);
            this.lblGuidanceLine.Name = "lblGuidanceLine";
            this.lblGuidanceLine.Size = new System.Drawing.Size(60, 22);
            this.lblGuidanceLine.TabIndex = 534;
            this.lblGuidanceLine.Text = "Lines";
            this.lblGuidanceLine.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblCurrentField
            // 
            this.lblCurrentField.AutoSize = true;
            this.lblCurrentField.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentField.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentField.Location = new System.Drawing.Point(83, 19);
            this.lblCurrentField.Name = "lblCurrentField";
            this.lblCurrentField.Size = new System.Drawing.Size(100, 19);
            this.lblCurrentField.TabIndex = 534;
            this.lblCurrentField.Text = "Current Field";
            this.lblCurrentField.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnGPSData
            // 
            this.btnGPSData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGPSData.BackColor = System.Drawing.Color.Yellow;
            this.btnGPSData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGPSData.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnGPSData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGPSData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGPSData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGPSData.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGPSData.Image = global::AgOpenGPS.Properties.Resources.GPSQuality;
            this.btnGPSData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGPSData.Location = new System.Drawing.Point(554, 4);
            this.btnGPSData.Name = "btnGPSData";
            this.btnGPSData.Size = new System.Drawing.Size(52, 32);
            this.btnGPSData.TabIndex = 536;
            this.btnGPSData.UseVisualStyleBackColor = false;
            this.btnGPSData.Click += new System.EventHandler(this.btnGPSData_Click);
            // 
            // btnFieldStats
            // 
            this.btnFieldStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFieldStats.BackColor = System.Drawing.Color.Transparent;
            this.btnFieldStats.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFieldStats.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnFieldStats.FlatAppearance.BorderSize = 0;
            this.btnFieldStats.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFieldStats.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFieldStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFieldStats.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFieldStats.Image = global::AgOpenGPS.Properties.Resources.FieldStats;
            this.btnFieldStats.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFieldStats.Location = new System.Drawing.Point(452, 3);
            this.btnFieldStats.Name = "btnFieldStats";
            this.btnFieldStats.Size = new System.Drawing.Size(52, 32);
            this.btnFieldStats.TabIndex = 535;
            this.btnFieldStats.UseVisualStyleBackColor = false;
            this.btnFieldStats.Visible = false;
            this.btnFieldStats.Click += new System.EventHandler(this.btnFieldStats_Click);
            // 
            // panelPan
            // 
            this.panelPan.BackColor = System.Drawing.Color.Black;
            this.panelPan.BackgroundImage = global::AgOpenGPS.Properties.Resources.PanBackground;
            this.panelPan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelPan.ColumnCount = 3;
            this.panelPan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelPan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelPan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelPan.Controls.Add(this.btnDownLeft, 0, 2);
            this.panelPan.Controls.Add(this.btnPanUp, 1, 0);
            this.panelPan.Controls.Add(this.btnUpLeft, 0, 0);
            this.panelPan.Controls.Add(this.btnPanLeft, 0, 1);
            this.panelPan.Controls.Add(this.btnPanRight, 2, 1);
            this.panelPan.Controls.Add(this.btnPanCancel, 1, 1);
            this.panelPan.Controls.Add(this.btnPanDn, 1, 2);
            this.panelPan.Controls.Add(this.btnDownRight, 2, 2);
            this.panelPan.Controls.Add(this.btnUpRight, 2, 0);
            this.panelPan.Location = new System.Drawing.Point(650, 385);
            this.panelPan.Name = "panelPan";
            this.panelPan.RowCount = 3;
            this.panelPan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelPan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelPan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelPan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.panelPan.Size = new System.Drawing.Size(150, 150);
            this.panelPan.TabIndex = 530;
            this.panelPan.Visible = false;
            // 
            // btnDownLeft
            // 
            this.btnDownLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDownLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnDownLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDownLeft.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnDownLeft.FlatAppearance.BorderSize = 0;
            this.btnDownLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownLeft.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDownLeft.Location = new System.Drawing.Point(3, 114);
            this.btnDownLeft.Name = "btnDownLeft";
            this.btnDownLeft.Size = new System.Drawing.Size(34, 33);
            this.btnDownLeft.TabIndex = 478;
            this.btnDownLeft.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDownLeft.UseVisualStyleBackColor = false;
            this.btnDownLeft.Click += new System.EventHandler(this.btnDownLeft_Click);
            // 
            // btnPanUp
            // 
            this.btnPanUp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPanUp.BackColor = System.Drawing.Color.Transparent;
            this.btnPanUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPanUp.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPanUp.FlatAppearance.BorderSize = 0;
            this.btnPanUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanUp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPanUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPanUp.Location = new System.Drawing.Point(56, 3);
            this.btnPanUp.Name = "btnPanUp";
            this.btnPanUp.Size = new System.Drawing.Size(34, 33);
            this.btnPanUp.TabIndex = 471;
            this.btnPanUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPanUp.UseVisualStyleBackColor = false;
            this.btnPanUp.Click += new System.EventHandler(this.btnPanUp_Click);
            // 
            // btnUpLeft
            // 
            this.btnUpLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnUpLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpLeft.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnUpLeft.FlatAppearance.BorderSize = 0;
            this.btnUpLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpLeft.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpLeft.Location = new System.Drawing.Point(3, 3);
            this.btnUpLeft.Name = "btnUpLeft";
            this.btnUpLeft.Size = new System.Drawing.Size(34, 33);
            this.btnUpLeft.TabIndex = 475;
            this.btnUpLeft.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpLeft.UseVisualStyleBackColor = false;
            this.btnUpLeft.Click += new System.EventHandler(this.btnUpLeft_Click);
            // 
            // btnPanLeft
            // 
            this.btnPanLeft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPanLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnPanLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPanLeft.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPanLeft.FlatAppearance.BorderSize = 0;
            this.btnPanLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanLeft.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPanLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPanLeft.Location = new System.Drawing.Point(3, 57);
            this.btnPanLeft.Name = "btnPanLeft";
            this.btnPanLeft.Size = new System.Drawing.Size(34, 33);
            this.btnPanLeft.TabIndex = 472;
            this.btnPanLeft.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPanLeft.UseVisualStyleBackColor = false;
            this.btnPanLeft.Click += new System.EventHandler(this.btnPanLeft_Click);
            // 
            // btnPanRight
            // 
            this.btnPanRight.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPanRight.BackColor = System.Drawing.Color.Transparent;
            this.btnPanRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPanRight.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPanRight.FlatAppearance.BorderSize = 0;
            this.btnPanRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanRight.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPanRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPanRight.Location = new System.Drawing.Point(113, 57);
            this.btnPanRight.Name = "btnPanRight";
            this.btnPanRight.Size = new System.Drawing.Size(34, 33);
            this.btnPanRight.TabIndex = 472;
            this.btnPanRight.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPanRight.UseVisualStyleBackColor = false;
            this.btnPanRight.Click += new System.EventHandler(this.btnPanRight_Click);
            // 
            // btnPanCancel
            // 
            this.btnPanCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPanCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnPanCancel.BackgroundImage = global::AgOpenGPS.Properties.Resources.boundaryStop;
            this.btnPanCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPanCancel.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPanCancel.FlatAppearance.BorderSize = 0;
            this.btnPanCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanCancel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPanCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPanCancel.Location = new System.Drawing.Point(54, 53);
            this.btnPanCancel.Name = "btnPanCancel";
            this.btnPanCancel.Size = new System.Drawing.Size(39, 41);
            this.btnPanCancel.TabIndex = 474;
            this.btnPanCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPanCancel.UseVisualStyleBackColor = false;
            this.btnPanCancel.Click += new System.EventHandler(this.btnPanCancel_Click);
            // 
            // btnPanDn
            // 
            this.btnPanDn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPanDn.BackColor = System.Drawing.Color.Transparent;
            this.btnPanDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPanDn.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPanDn.FlatAppearance.BorderSize = 0;
            this.btnPanDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanDn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPanDn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPanDn.Location = new System.Drawing.Point(56, 114);
            this.btnPanDn.Name = "btnPanDn";
            this.btnPanDn.Size = new System.Drawing.Size(34, 33);
            this.btnPanDn.TabIndex = 470;
            this.btnPanDn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPanDn.UseVisualStyleBackColor = false;
            this.btnPanDn.Click += new System.EventHandler(this.btnPanDn_Click);
            // 
            // btnDownRight
            // 
            this.btnDownRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownRight.BackColor = System.Drawing.Color.Transparent;
            this.btnDownRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDownRight.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnDownRight.FlatAppearance.BorderSize = 0;
            this.btnDownRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownRight.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDownRight.Location = new System.Drawing.Point(113, 114);
            this.btnDownRight.Name = "btnDownRight";
            this.btnDownRight.Size = new System.Drawing.Size(34, 33);
            this.btnDownRight.TabIndex = 477;
            this.btnDownRight.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDownRight.UseVisualStyleBackColor = false;
            this.btnDownRight.Click += new System.EventHandler(this.btnDownRight_Click);
            // 
            // btnUpRight
            // 
            this.btnUpRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpRight.BackColor = System.Drawing.Color.Transparent;
            this.btnUpRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpRight.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnUpRight.FlatAppearance.BorderSize = 0;
            this.btnUpRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpRight.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpRight.Location = new System.Drawing.Point(113, 3);
            this.btnUpRight.Name = "btnUpRight";
            this.btnUpRight.Size = new System.Drawing.Size(34, 33);
            this.btnUpRight.TabIndex = 476;
            this.btnUpRight.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpRight.UseVisualStyleBackColor = false;
            this.btnUpRight.Click += new System.EventHandler(this.btnUpRight_Click);
            // 
            // btnMaximizeMainForm
            // 
            this.btnMaximizeMainForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizeMainForm.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximizeMainForm.BackgroundImage = global::AgOpenGPS.Properties.Resources.WindowMaximize;
            this.btnMaximizeMainForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMaximizeMainForm.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnMaximizeMainForm.FlatAppearance.BorderSize = 0;
            this.btnMaximizeMainForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMaximizeMainForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMaximizeMainForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximizeMainForm.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximizeMainForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMaximizeMainForm.Location = new System.Drawing.Point(868, 3);
            this.btnMaximizeMainForm.Name = "btnMaximizeMainForm";
            this.btnMaximizeMainForm.Size = new System.Drawing.Size(52, 33);
            this.btnMaximizeMainForm.TabIndex = 482;
            this.btnMaximizeMainForm.UseVisualStyleBackColor = false;
            this.btnMaximizeMainForm.Click += new System.EventHandler(this.btnMaximizeMainForm_Click);
            // 
            // pictureboxStart
            // 
            this.pictureboxStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureboxStart.BackColor = System.Drawing.Color.Black;
            this.pictureboxStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureboxStart.Image = global::AgOpenGPS.Properties.Resources.Splash;
            this.pictureboxStart.Location = new System.Drawing.Point(839, 566);
            this.pictureboxStart.Name = "pictureboxStart";
            this.pictureboxStart.Size = new System.Drawing.Size(74, 60);
            this.pictureboxStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureboxStart.TabIndex = 473;
            this.pictureboxStart.TabStop = false;
            // 
            // btnShutdown
            // 
            this.btnShutdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShutdown.BackColor = System.Drawing.Color.Transparent;
            this.btnShutdown.BackgroundImage = global::AgOpenGPS.Properties.Resources.WindowClose;
            this.btnShutdown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShutdown.FlatAppearance.BorderSize = 0;
            this.btnShutdown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnShutdown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnShutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShutdown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnShutdown.Location = new System.Drawing.Point(938, 4);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(52, 33);
            this.btnShutdown.TabIndex = 447;
            this.btnShutdown.UseVisualStyleBackColor = false;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.DimGray;
            this.btnHelp.Image = global::AgOpenGPS.Properties.Resources.Help;
            this.btnHelp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHelp.Location = new System.Drawing.Point(742, 3);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(51, 37);
            this.btnHelp.TabIndex = 495;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnMinimizeMainForm
            // 
            this.btnMinimizeMainForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizeMainForm.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimizeMainForm.BackgroundImage = global::AgOpenGPS.Properties.Resources.WindowMinimize;
            this.btnMinimizeMainForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMinimizeMainForm.FlatAppearance.BorderSize = 0;
            this.btnMinimizeMainForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinimizeMainForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMinimizeMainForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizeMainForm.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizeMainForm.ForeColor = System.Drawing.Color.DimGray;
            this.btnMinimizeMainForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMinimizeMainForm.Location = new System.Drawing.Point(799, 3);
            this.btnMinimizeMainForm.Name = "btnMinimizeMainForm";
            this.btnMinimizeMainForm.Size = new System.Drawing.Size(52, 33);
            this.btnMinimizeMainForm.TabIndex = 481;
            this.btnMinimizeMainForm.UseVisualStyleBackColor = false;
            this.btnMinimizeMainForm.Click += new System.EventHandler(this.btnMinimizeMainForm_Click);
            // 
            // FormGPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1000, 720);
            this.Controls.Add(this.lblFix);
            this.Controls.Add(this.btnGPSData);
            this.Controls.Add(this.btnFieldStats);
            this.Controls.Add(this.panelPan);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.btnZone8);
            this.Controls.Add(this.btnZone7);
            this.Controls.Add(this.btnZone6);
            this.Controls.Add(this.btnZone5);
            this.Controls.Add(this.btnZone4);
            this.Controls.Add(this.btnZone3);
            this.Controls.Add(this.btnZone2);
            this.Controls.Add(this.btnZone1);
            this.Controls.Add(this.lblInty);
            this.Controls.Add(this.btnMaximizeMainForm);
            this.Controls.Add(this.pictureboxStart);
            this.Controls.Add(this.panelNavigation);
            this.Controls.Add(this.btnSection13Man);
            this.Controls.Add(this.btnSection14Man);
            this.Controls.Add(this.btnSection15Man);
            this.Controls.Add(this.btnSection16Man);
            this.Controls.Add(this.btnShutdown);
            this.Controls.Add(this.panelDrag);
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
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.oglZoom);
            this.Controls.Add(this.oglBack);
            this.Controls.Add(this.panelAB);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.btnMinimizeMainForm);
            this.Controls.Add(this.lblCurrentField);
            this.Controls.Add(this.tableLayoutPanel2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1000, 720);
            this.Name = "FormGPS";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "AgOpenGPS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGPS_FormClosing);
            this.Load += new System.EventHandler(this.FormGPS_Load);
            this.Move += new System.EventHandler(this.FormGPS_Move);
            this.Resize += new System.EventHandler(this.FormGPS_Resize);
            this.contextMenuStripOpenGL.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripFlag.ResumeLayout(false);
            this.panelDrag.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.statusStripLeft.ResumeLayout(false);
            this.statusStripLeft.PerformLayout();
            this.panelSim.ResumeLayout(false);
            this.panelNavigation.ResumeLayout(false);
            this.panelAB.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelPan.ResumeLayout(false);
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
        public System.Windows.Forms.Button btnCurve;
        private System.Windows.Forms.Button btnSection9Man;
        private System.Windows.Forms.Button btnSection10Man;
        private System.Windows.Forms.Button btnSection11Man;
        private System.Windows.Forms.Button btnSection12Man;
        private System.Windows.Forms.ToolStripMenuItem enterSimCoordsToolStripMenuItem;
        public System.Windows.Forms.Button btnABLine;
        public System.Windows.Forms.Button btnAutoYouTurn;
        public System.Windows.Forms.Button btnAutoSteer;
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
        public System.Windows.Forms.Button btnCycleLines;
        private System.Windows.Forms.StatusStrip statusStripLeft;
        private System.Windows.Forms.TableLayoutPanel panelSim;
        public System.Windows.Forms.TableLayoutPanel panelRight;
        public System.Windows.Forms.TableLayoutPanel panelDrag;
        private ProXoft.WinForms.RepeatButton btnpTiltDown;
        private ProXoft.WinForms.RepeatButton btnpTiltUp;
        private System.Windows.Forms.Button btnHeadlandOnOff;
        private System.Windows.Forms.Button btnShutdown;
        private System.Windows.Forms.Button btnSection16Man;
        private System.Windows.Forms.Button btnSection15Man;
        private System.Windows.Forms.Button btnSection14Man;
        private System.Windows.Forms.Button btnSection13Man;
        private System.Windows.Forms.Button btnSimSetSpeedToZero;
        private System.Windows.Forms.ToolStripDropDownButton simplifyToolStrip;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageUkranian;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageSlovak;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFlagForm;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageTest;
        public System.Windows.Forms.Button btnHydLift;
        private System.Windows.Forms.ToolStripMenuItem menuLanguagePolish;
        private System.Windows.Forms.ToolStripDropDownButton distanceToolBtn;
        public System.Windows.Forms.Button btnDayNightMode;
        public System.Windows.Forms.Button btnStartAgIO;
        public System.Windows.Forms.Button btnPickPath;
        public System.Windows.Forms.Button btnPathRecordStop;
        public System.Windows.Forms.Button btnPathGoStop;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        public System.Windows.Forms.ToolStripMenuItem steerChartStripMenu;
        private System.Windows.Forms.ToolStripMenuItem webcamToolStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteAppliedAreaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteForSureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offsetFixToolStrip;
        private System.Windows.Forms.TableLayoutPanel panelNavigation;
        public System.Windows.Forms.Button btnN3D;
        public System.Windows.Forms.Button btn2D;
        public System.Windows.Forms.Button btn3D;
        public System.Windows.Forms.Button btnN2D;
        private System.Windows.Forms.ToolStripDropDownButton toolStripBtnFieldTools;
        private System.Windows.Forms.ToolStripMenuItem tramLinesMenuField;
        private System.Windows.Forms.ToolStripMenuItem headlandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boundariesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteContourPathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SmoothABtoolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem recordedPathStripMenu;
        private System.Windows.Forms.PictureBox pictureboxStart;
        private System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.Button btnAutoSteerConfig;
        public System.Windows.Forms.Button btnChangeMappingColor;
        private System.Windows.Forms.TableLayoutPanel panelAB;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem simulatorOnToolStripMenuItem;
        private System.Windows.Forms.Button btnMinimizeMainForm;
        private System.Windows.Forms.Button btnMaximizeMainForm;
        private System.Windows.Forms.ToolStripMenuItem resetALLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetEverythingToolStripMenuItem;
        private System.Windows.Forms.Label lblInty;
        public System.Windows.Forms.Button btnTramDisplayMode;
        public System.Windows.Forms.Button btnYouSkipEnable;
        private System.Windows.Forms.Label lblFix;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageDanish;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sectionColorToolStripMenuItem;
        private System.Windows.Forms.Button btnEditAB;
        private System.Windows.Forms.Button btnHelp;
        public System.Windows.Forms.Button btnResumePath;
        public System.Windows.Forms.Button btnResetToolHeading;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageTurkish;
        private System.Windows.Forms.ToolStripMenuItem wizardsMenu;
        private System.Windows.Forms.ToolStripMenuItem steerWizardMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem menuLanguageFinnish;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageLatvian;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageLithuanian;
        private System.Windows.Forms.ToolStripMenuItem rollCheckToolStripMenuItem;
        public System.Windows.Forms.Button btnCycleLinesBk;
        private System.Windows.Forms.TableLayoutPanel panelLeft;
        private System.Windows.Forms.ToolStripMenuItem headlandBuildToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel panelPan;
        public System.Windows.Forms.Button btnPanDn;
        public System.Windows.Forms.Button btnPanUp;
        public System.Windows.Forms.Button btnPanLeft;
        public System.Windows.Forms.Button btnPanRight;
        public System.Windows.Forms.Button btnPanCancel;
        public System.Windows.Forms.Button btnDownLeft;
        public System.Windows.Forms.Button btnUpLeft;
        public System.Windows.Forms.Button btnUpRight;
        public System.Windows.Forms.Button btnDownRight;
        private ProXoft.WinForms.RepeatButton btnSimSpeedUp;
        private ProXoft.WinForms.RepeatButton btnSpeedDn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblGuidanceLine;
        private System.Windows.Forms.Label lblCurrentField;
        private System.Windows.Forms.Label lblFieldStatus;
        private System.Windows.Forms.Button btnFieldStats;
        public System.Windows.Forms.Button btnJobMenu;
        public System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnGPSData;
    }
}

