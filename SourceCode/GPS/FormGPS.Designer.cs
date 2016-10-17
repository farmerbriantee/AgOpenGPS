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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGPS));
            this.openGLControl = new SharpGL.OpenGLControl();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblPortName = new System.Windows.Forms.Label();
            this.textBoxRcv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblConnected = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gPSDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COMPortsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewJob = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCloseJob = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEqWidth = new System.Windows.Forms.Label();
            this.lblSatellites = new System.Windows.Forms.Label();
            this.lblSats = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGridSpacing = new System.Windows.Forms.Label();
            this.txtDistanceOffABLine = new System.Windows.Forms.TextBox();
            this.lblPassNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalDistance = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.openGLControlBack = new SharpGL.OpenGLControl();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSnapToAB = new System.Windows.Forms.Button();
            this.chkSectionsOnOff = new System.Windows.Forms.CheckBox();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btn2D3D = new System.Windows.Forms.Button();
            this.btnABLine = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlBack)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openGLControl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.openGLControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openGLControl.FrameRate = 1;
            this.openGLControl.Location = new System.Drawing.Point(0, 31);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(920, 452);
            this.openGLControl.TabIndex = 6;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblBaudRate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaudRate.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblBaudRate.Location = new System.Drawing.Point(813, 490);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(15, 16);
            this.lblBaudRate.TabIndex = 32;
            this.lblBaudRate.Text = "-";
            // 
            // lblPortName
            // 
            this.lblPortName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPortName.AutoSize = true;
            this.lblPortName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPortName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortName.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblPortName.Location = new System.Drawing.Point(773, 490);
            this.lblPortName.Name = "lblPortName";
            this.lblPortName.Size = new System.Drawing.Size(15, 16);
            this.lblPortName.TabIndex = 31;
            this.lblPortName.Text = "-";
            // 
            // textBoxRcv
            // 
            this.textBoxRcv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRcv.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRcv.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRcv.Location = new System.Drawing.Point(569, 6);
            this.textBoxRcv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRcv.Name = "textBoxRcv";
            this.textBoxRcv.ReadOnly = true;
            this.textBoxRcv.Size = new System.Drawing.Size(233, 20);
            this.textBoxRcv.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label3.Location = new System.Drawing.Point(119, 489);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 18);
            this.label3.TabIndex = 37;
            this.label3.Text = "MPH";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSpeed
            // 
            this.lblSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lblSpeed.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblSpeed.Location = new System.Drawing.Point(161, 489);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSpeed.Size = new System.Drawing.Size(19, 18);
            this.lblSpeed.TabIndex = 36;
            this.lblSpeed.Text = "0";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLongitude
            // 
            this.lblLongitude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.BackColor = System.Drawing.Color.Snow;
            this.lblLongitude.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLongitude.Location = new System.Drawing.Point(809, 16);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(51, 14);
            this.lblLongitude.TabIndex = 10;
            this.lblLongitude.Text = "Deg W";
            this.lblLongitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLatitude
            // 
            this.lblLatitude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.BackColor = System.Drawing.Color.Snow;
            this.lblLatitude.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLatitude.Location = new System.Drawing.Point(825, 2);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(47, 14);
            this.lblLatitude.TabIndex = 11;
            this.lblLatitude.Text = "Deg N";
            this.lblLatitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblConnected
            // 
            this.lblConnected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConnected.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnected.ForeColor = System.Drawing.Color.HotPink;
            this.lblConnected.Location = new System.Drawing.Point(857, 488);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(64, 20);
            this.lblConnected.TabIndex = 42;
            this.lblConnected.Text = "Offline";
            this.lblConnected.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.jobsToolStripMenuItem,
            this.aboutToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(920, 31);
            this.menuStrip1.TabIndex = 49;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 27);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(183, 28);
            this.openToolStripMenuItem.Text = "Open Field";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(183, 28);
            this.saveToolStripMenuItem.Text = "Save Field";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gPSDataToolStripMenuItem,
            this.sectionsToolStripMenuItem,
            this.vehicleToolStripMenuItem,
            this.COMPortsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(100, 27);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // gPSDataToolStripMenuItem
            // 
            this.gPSDataToolStripMenuItem.Name = "gPSDataToolStripMenuItem";
            this.gPSDataToolStripMenuItem.Size = new System.Drawing.Size(179, 28);
            this.gPSDataToolStripMenuItem.Text = "GPS Data";
            this.gPSDataToolStripMenuItem.Click += new System.EventHandler(this.menuItemGPSDataToolStrip_Click);
            // 
            // sectionsToolStripMenuItem
            // 
            this.sectionsToolStripMenuItem.Name = "sectionsToolStripMenuItem";
            this.sectionsToolStripMenuItem.Size = new System.Drawing.Size(179, 28);
            this.sectionsToolStripMenuItem.Text = "Sections";
            this.sectionsToolStripMenuItem.Click += new System.EventHandler(this.sectionsToolStripMenuItem_Click);
            // 
            // vehicleToolStripMenuItem
            // 
            this.vehicleToolStripMenuItem.Name = "vehicleToolStripMenuItem";
            this.vehicleToolStripMenuItem.Size = new System.Drawing.Size(179, 28);
            this.vehicleToolStripMenuItem.Text = "Vehicle";
            this.vehicleToolStripMenuItem.Click += new System.EventHandler(this.menuItemVehicleToolStrip_Click);
            // 
            // COMPortsToolStripMenuItem
            // 
            this.COMPortsToolStripMenuItem.Name = "COMPortsToolStripMenuItem";
            this.COMPortsToolStripMenuItem.Size = new System.Drawing.Size(179, 28);
            this.COMPortsToolStripMenuItem.Text = "COM Ports";
            this.COMPortsToolStripMenuItem.Click += new System.EventHandler(this.menuItemCOMPortsToolStrip_Click);
            // 
            // jobsToolStripMenuItem
            // 
            this.jobsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewJob,
            this.menuCloseJob});
            this.jobsToolStripMenuItem.Name = "jobsToolStripMenuItem";
            this.jobsToolStripMenuItem.Size = new System.Drawing.Size(65, 27);
            this.jobsToolStripMenuItem.Text = "Jobs";
            // 
            // menuNewJob
            // 
            this.menuNewJob.Name = "menuNewJob";
            this.menuNewJob.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.J)));
            this.menuNewJob.Size = new System.Drawing.Size(222, 28);
            this.menuNewJob.Text = "New Job";
            this.menuNewJob.Click += new System.EventHandler(this.menuJobNew_Click);
            // 
            // menuCloseJob
            // 
            this.menuCloseJob.Name = "menuCloseJob";
            this.menuCloseJob.Size = new System.Drawing.Size(222, 28);
            this.menuCloseJob.Text = "Close Job";
            this.menuCloseJob.Click += new System.EventHandler(this.menuJobClose_Click);
            // 
            // aboutToolStripMenuItem2
            // 
            this.aboutToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
            this.aboutToolStripMenuItem2.Size = new System.Drawing.Size(65, 27);
            this.aboutToolStripMenuItem2.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 489);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 63;
            this.label1.Text = "Width";
            // 
            // lblEqWidth
            // 
            this.lblEqWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEqWidth.AutoSize = true;
            this.lblEqWidth.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEqWidth.Location = new System.Drawing.Point(56, 489);
            this.lblEqWidth.Name = "lblEqWidth";
            this.lblEqWidth.Size = new System.Drawing.Size(19, 18);
            this.lblEqWidth.TabIndex = 64;
            this.lblEqWidth.Text = "0";
            // 
            // lblSatellites
            // 
            this.lblSatellites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSatellites.AutoSize = true;
            this.lblSatellites.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatellites.Location = new System.Drawing.Point(736, 489);
            this.lblSatellites.Name = "lblSatellites";
            this.lblSatellites.Size = new System.Drawing.Size(17, 16);
            this.lblSatellites.TabIndex = 69;
            this.lblSatellites.Text = "0";
            // 
            // lblSats
            // 
            this.lblSats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSats.AutoSize = true;
            this.lblSats.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lblSats.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSats.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblSats.Location = new System.Drawing.Point(704, 489);
            this.lblSats.Name = "lblSats";
            this.lblSats.Size = new System.Drawing.Size(35, 16);
            this.lblSats.TabIndex = 70;
            this.lblSats.Text = "Sats";
            this.lblSats.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(526, 490);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 73;
            this.label2.Text = "m/sq";
            // 
            // lblGridSpacing
            // 
            this.lblGridSpacing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGridSpacing.AutoSize = true;
            this.lblGridSpacing.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lblGridSpacing.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGridSpacing.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblGridSpacing.Location = new System.Drawing.Point(566, 490);
            this.lblGridSpacing.Name = "lblGridSpacing";
            this.lblGridSpacing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblGridSpacing.Size = new System.Drawing.Size(19, 18);
            this.lblGridSpacing.TabIndex = 74;
            this.lblGridSpacing.Text = "0";
            this.lblGridSpacing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDistanceOffABLine
            // 
            this.txtDistanceOffABLine.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDistanceOffABLine.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDistanceOffABLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDistanceOffABLine.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDistanceOffABLine.ForeColor = System.Drawing.Color.Chartreuse;
            this.txtDistanceOffABLine.Location = new System.Drawing.Point(442, 77);
            this.txtDistanceOffABLine.Name = "txtDistanceOffABLine";
            this.txtDistanceOffABLine.ReadOnly = true;
            this.txtDistanceOffABLine.Size = new System.Drawing.Size(39, 34);
            this.txtDistanceOffABLine.TabIndex = 7;
            this.txtDistanceOffABLine.Text = "000";
            this.txtDistanceOffABLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPassNumber
            // 
            this.lblPassNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPassNumber.AutoSize = true;
            this.lblPassNumber.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lblPassNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassNumber.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblPassNumber.Location = new System.Drawing.Point(444, 490);
            this.lblPassNumber.Name = "lblPassNumber";
            this.lblPassNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPassNumber.Size = new System.Drawing.Size(19, 18);
            this.lblPassNumber.TabIndex = 77;
            this.lblPassNumber.Text = "0";
            this.lblPassNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label4.Location = new System.Drawing.Point(392, 490);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 78;
            this.label4.Text = "Pass#";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalDistance
            // 
            this.lblTotalDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalDistance.AutoSize = true;
            this.lblTotalDistance.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lblTotalDistance.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDistance.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblTotalDistance.Location = new System.Drawing.Point(314, 489);
            this.lblTotalDistance.Name = "lblTotalDistance";
            this.lblTotalDistance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalDistance.Size = new System.Drawing.Size(19, 18);
            this.lblTotalDistance.TabIndex = 81;
            this.lblTotalDistance.Text = "0";
            this.lblTotalDistance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label8.Location = new System.Drawing.Point(294, 489);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 18);
            this.label8.TabIndex = 86;
            this.label8.Text = "m";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // openGLControlBack
            // 
            this.openGLControlBack.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.openGLControlBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.openGLControlBack.DrawFPS = false;
            this.openGLControlBack.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openGLControlBack.FrameRate = 1;
            this.openGLControlBack.Location = new System.Drawing.Point(0, 0);
            this.openGLControlBack.Name = "openGLControlBack";
            this.openGLControlBack.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControlBack.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLControlBack.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.openGLControlBack.Size = new System.Drawing.Size(400, 400);
            this.openGLControlBack.TabIndex = 91;
            this.openGLControlBack.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControlBack_OpenGLDraw);
            this.openGLControlBack.Resized += new System.EventHandler(this.openGLControlBack_Resized);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(12, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 67);
            this.button1.TabIndex = 92;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSnapToAB
            // 
            this.btnSnapToAB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSnapToAB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSnapToAB.Enabled = false;
            this.btnSnapToAB.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnapToAB.Image = global::AgOpenGPS.Properties.Resources.Snap64;
            this.btnSnapToAB.Location = new System.Drawing.Point(840, 242);
            this.btnSnapToAB.Name = "btnSnapToAB";
            this.btnSnapToAB.Size = new System.Drawing.Size(70, 67);
            this.btnSnapToAB.TabIndex = 87;
            this.btnSnapToAB.UseVisualStyleBackColor = true;
            this.btnSnapToAB.Click += new System.EventHandler(this.btnABSnapToAB_Click);
            // 
            // chkSectionsOnOff
            // 
            this.chkSectionsOnOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSectionsOnOff.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSectionsOnOff.AutoSize = true;
            this.chkSectionsOnOff.Enabled = false;
            this.chkSectionsOnOff.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSectionsOnOff.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;
            this.chkSectionsOnOff.Location = new System.Drawing.Point(840, 332);
            this.chkSectionsOnOff.Name = "chkSectionsOnOff";
            this.chkSectionsOnOff.Size = new System.Drawing.Size(70, 86);
            this.chkSectionsOnOff.TabIndex = 1;
            this.chkSectionsOnOff.Text = "0.00";
            this.chkSectionsOnOff.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkSectionsOnOff.UseVisualStyleBackColor = true;
            this.chkSectionsOnOff.CheckedChanged += new System.EventHandler(this.chkSectionsOnOff_CheckedChanged);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomIn.BackColor = System.Drawing.Color.Lavender;
            this.btnZoomIn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.BackgroundImage")));
            this.btnZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomIn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnZoomIn.Location = new System.Drawing.Point(840, 44);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(70, 67);
            this.btnZoomIn.TabIndex = 3;
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.BackColor = System.Drawing.Color.Lavender;
            this.btnZoomOut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.BackgroundImage")));
            this.btnZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomOut.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnZoomOut.Location = new System.Drawing.Point(12, 40);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(70, 67);
            this.btnZoomOut.TabIndex = 4;
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btn2D3D
            // 
            this.btn2D3D.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2D3D.Image = global::AgOpenGPS.Properties.Resources.Icon_3D;
            this.btn2D3D.Location = new System.Drawing.Point(12, 242);
            this.btn2D3D.Name = "btn2D3D";
            this.btn2D3D.Size = new System.Drawing.Size(70, 67);
            this.btn2D3D.TabIndex = 2;
            this.btn2D3D.UseVisualStyleBackColor = true;
            this.btn2D3D.Click += new System.EventHandler(this.btn2D3D_Click);
            // 
            // btnABLine
            // 
            this.btnABLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnABLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnABLine.Enabled = false;
            this.btnABLine.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnABLine.Image = ((System.Drawing.Image)(resources.GetObject("btnABLine.Image")));
            this.btnABLine.Location = new System.Drawing.Point(840, 164);
            this.btnABLine.Name = "btnABLine";
            this.btnABLine.Size = new System.Drawing.Size(70, 67);
            this.btnABLine.TabIndex = 0;
            this.btnABLine.UseVisualStyleBackColor = true;
            this.btnABLine.Click += new System.EventHandler(this.btnABLine_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label5.Location = new System.Drawing.Point(220, 490);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(19, 18);
            this.label5.TabIndex = 93;
            this.label5.Text = "0";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormGPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(920, 511);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSnapToAB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTotalDistance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPassNumber);
            this.Controls.Add(this.chkSectionsOnOff);
            this.Controls.Add(this.txtDistanceOffABLine);
            this.Controls.Add(this.lblGridSpacing);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.lblSatellites);
            this.Controls.Add(this.btn2D3D);
            this.Controls.Add(this.lblEqWidth);
            this.Controls.Add(this.btnABLine);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.textBoxRcv);
            this.Controls.Add(this.lblBaudRate);
            this.Controls.Add(this.lblPortName);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.openGLControl);
            this.Controls.Add(this.openGLControlBack);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGPS";
            this.Text = "AgOpenGPS - v 0.01 ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGPS_FormClosing);
            this.Load += new System.EventHandler(this.FormGPS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Label lblPortName;
        private System.Windows.Forms.TextBox textBoxRcv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnABLine;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEqWidth;
        private System.Windows.Forms.Button btn2D3D;
        private System.Windows.Forms.ToolStripMenuItem jobsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuNewJob;
        private System.Windows.Forms.ToolStripMenuItem menuCloseJob;
        private System.Windows.Forms.Label lblSatellites;
        private System.Windows.Forms.ToolStripMenuItem gPSDataToolStripMenuItem;
        private System.Windows.Forms.Label lblSats;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGridSpacing;
        private System.Windows.Forms.TextBox txtDistanceOffABLine;
        private System.Windows.Forms.CheckBox chkSectionsOnOff;
        private System.Windows.Forms.Label lblPassNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem vehicleToolStripMenuItem;
        private System.Windows.Forms.Label lblTotalDistance;
        private System.Windows.Forms.ToolStripMenuItem COMPortsToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSnapToAB;
        private System.Windows.Forms.ToolStripMenuItem sectionsToolStripMenuItem;
        private SharpGL.OpenGLControl openGLControlBack;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label label5;
    }
}

