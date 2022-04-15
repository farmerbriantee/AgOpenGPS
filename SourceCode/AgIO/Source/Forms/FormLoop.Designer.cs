
namespace AgIO
{
    partial class FormLoop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoop));
            this.oneSecondLoopTimer = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCurentLon = new System.Windows.Forms.Label();
            this.lblCurrentLat = new System.Windows.Forms.Label();
            this.lblWatch = new System.Windows.Forms.Label();
            this.lblNTRIPBytes = new System.Windows.Forms.Label();
            this.lblToMachine = new System.Windows.Forms.Label();
            this.lblToSteer = new System.Windows.Forms.Label();
            this.lblFromMachine = new System.Windows.Forms.Label();
            this.lblFromSteer = new System.Windows.Forms.Label();
            this.lblMod2Comm = new System.Windows.Forms.Label();
            this.lblMod1Comm = new System.Windows.Forms.Label();
            this.lblIMUComm = new System.Windows.Forms.Label();
            this.lblFromMU = new System.Windows.Forms.Label();
            this.lblToGPS = new System.Windows.Forms.Label();
            this.lblFromGPS = new System.Windows.Forms.Label();
            this.lblGPS1Comm = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.settingsMenuStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.deviceManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSteerAngle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNTRIP_IP = new System.Windows.Forms.Label();
            this.lblSerialPorts = new System.Windows.Forms.Label();
            this.lblMount = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.ntripMeterTimer = new System.Windows.Forms.Timer(this.components);
            this.lblMessages = new System.Windows.Forms.Label();
            this.lblWASCounts = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalMessageCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSwitchStatus = new System.Windows.Forms.Label();
            this.lblWorkSwitchStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnStartStopNtrip = new System.Windows.Forms.Button();
            this.btnWindowsShutDown = new System.Windows.Forms.Button();
            this.btnSlide = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUDP = new System.Windows.Forms.Button();
            this.btnRadio = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cboxLogNMEA = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNTRIP = new System.Windows.Forms.Button();
            this.btnRunAOG = new System.Windows.Forms.Button();
            this.btnIMU = new System.Windows.Forms.Button();
            this.btnSteer = new System.Windows.Forms.Button();
            this.btnMachine = new System.Windows.Forms.Button();
            this.btnGPS = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMessagesFound = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // oneSecondLoopTimer
            // 
            this.oneSecondLoopTimer.Interval = 2200;
            this.oneSecondLoopTimer.Tick += new System.EventHandler(this.oneSecondLoopTimer_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(11, 5);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 19);
            this.label6.TabIndex = 151;
            this.label6.Text = "Lat";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(6, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 19);
            this.label8.TabIndex = 152;
            this.label8.Text = "Lon";
            // 
            // lblCurentLon
            // 
            this.lblCurentLon.AutoSize = true;
            this.lblCurentLon.BackColor = System.Drawing.Color.Transparent;
            this.lblCurentLon.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurentLon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCurentLon.Location = new System.Drawing.Point(43, 32);
            this.lblCurentLon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurentLon.Name = "lblCurentLon";
            this.lblCurentLon.Size = new System.Drawing.Size(44, 18);
            this.lblCurentLon.TabIndex = 154;
            this.lblCurentLon.Text = "-111";
            // 
            // lblCurrentLat
            // 
            this.lblCurrentLat.AutoSize = true;
            this.lblCurrentLat.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentLat.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentLat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCurrentLat.Location = new System.Drawing.Point(43, 7);
            this.lblCurrentLat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentLat.Name = "lblCurrentLat";
            this.lblCurrentLat.Size = new System.Drawing.Size(28, 18);
            this.lblCurrentLat.TabIndex = 153;
            this.lblCurrentLat.Text = "53";
            // 
            // lblWatch
            // 
            this.lblWatch.BackColor = System.Drawing.Color.Transparent;
            this.lblWatch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWatch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWatch.Location = new System.Drawing.Point(3, 81);
            this.lblWatch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWatch.Name = "lblWatch";
            this.lblWatch.Size = new System.Drawing.Size(120, 18);
            this.lblWatch.TabIndex = 146;
            this.lblWatch.Text = "Watch";
            this.lblWatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNTRIPBytes
            // 
            this.lblNTRIPBytes.BackColor = System.Drawing.Color.Transparent;
            this.lblNTRIPBytes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNTRIPBytes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNTRIPBytes.Location = new System.Drawing.Point(3, 104);
            this.lblNTRIPBytes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNTRIPBytes.Name = "lblNTRIPBytes";
            this.lblNTRIPBytes.Size = new System.Drawing.Size(120, 18);
            this.lblNTRIPBytes.TabIndex = 148;
            this.lblNTRIPBytes.Text = "999,999,999";
            this.lblNTRIPBytes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToMachine
            // 
            this.lblToMachine.BackColor = System.Drawing.Color.Transparent;
            this.lblToMachine.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToMachine.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblToMachine.Location = new System.Drawing.Point(205, 309);
            this.lblToMachine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToMachine.Name = "lblToMachine";
            this.lblToMachine.Size = new System.Drawing.Size(64, 27);
            this.lblToMachine.TabIndex = 163;
            this.lblToMachine.Text = "---";
            this.lblToMachine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToSteer
            // 
            this.lblToSteer.BackColor = System.Drawing.Color.Transparent;
            this.lblToSteer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToSteer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblToSteer.Location = new System.Drawing.Point(205, 242);
            this.lblToSteer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToSteer.Name = "lblToSteer";
            this.lblToSteer.Size = new System.Drawing.Size(64, 27);
            this.lblToSteer.TabIndex = 141;
            this.lblToSteer.Text = "---";
            this.lblToSteer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromMachine
            // 
            this.lblFromMachine.BackColor = System.Drawing.Color.Transparent;
            this.lblFromMachine.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromMachine.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFromMachine.Location = new System.Drawing.Point(347, 309);
            this.lblFromMachine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromMachine.Name = "lblFromMachine";
            this.lblFromMachine.Size = new System.Drawing.Size(64, 27);
            this.lblFromMachine.TabIndex = 164;
            this.lblFromMachine.Text = "---";
            this.lblFromMachine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromSteer
            // 
            this.lblFromSteer.BackColor = System.Drawing.Color.Transparent;
            this.lblFromSteer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromSteer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFromSteer.Location = new System.Drawing.Point(347, 241);
            this.lblFromSteer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromSteer.Name = "lblFromSteer";
            this.lblFromSteer.Size = new System.Drawing.Size(64, 27);
            this.lblFromSteer.TabIndex = 142;
            this.lblFromSteer.Text = "---";
            this.lblFromSteer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMod2Comm
            // 
            this.lblMod2Comm.BackColor = System.Drawing.Color.Transparent;
            this.lblMod2Comm.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMod2Comm.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMod2Comm.Location = new System.Drawing.Point(134, 309);
            this.lblMod2Comm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMod2Comm.Name = "lblMod2Comm";
            this.lblMod2Comm.Size = new System.Drawing.Size(66, 27);
            this.lblMod2Comm.TabIndex = 178;
            this.lblMod2Comm.Text = "Com12";
            this.lblMod2Comm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMod1Comm
            // 
            this.lblMod1Comm.BackColor = System.Drawing.Color.Transparent;
            this.lblMod1Comm.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMod1Comm.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMod1Comm.Location = new System.Drawing.Point(134, 242);
            this.lblMod1Comm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMod1Comm.Name = "lblMod1Comm";
            this.lblMod1Comm.Size = new System.Drawing.Size(66, 27);
            this.lblMod1Comm.TabIndex = 177;
            this.lblMod1Comm.Text = "--";
            this.lblMod1Comm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIMUComm
            // 
            this.lblIMUComm.BackColor = System.Drawing.Color.Transparent;
            this.lblIMUComm.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMUComm.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIMUComm.Location = new System.Drawing.Point(134, 175);
            this.lblIMUComm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIMUComm.Name = "lblIMUComm";
            this.lblIMUComm.Size = new System.Drawing.Size(66, 27);
            this.lblIMUComm.TabIndex = 175;
            this.lblIMUComm.Text = "--";
            this.lblIMUComm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromMU
            // 
            this.lblFromMU.BackColor = System.Drawing.Color.Transparent;
            this.lblFromMU.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromMU.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFromMU.Location = new System.Drawing.Point(347, 175);
            this.lblFromMU.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromMU.Name = "lblFromMU";
            this.lblFromMU.Size = new System.Drawing.Size(64, 27);
            this.lblFromMU.TabIndex = 171;
            this.lblFromMU.Text = "---";
            this.lblFromMU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToGPS
            // 
            this.lblToGPS.BackColor = System.Drawing.Color.Transparent;
            this.lblToGPS.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToGPS.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblToGPS.Location = new System.Drawing.Point(199, 108);
            this.lblToGPS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToGPS.Name = "lblToGPS";
            this.lblToGPS.Size = new System.Drawing.Size(70, 28);
            this.lblToGPS.TabIndex = 128;
            this.lblToGPS.Text = "00000";
            this.lblToGPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromGPS
            // 
            this.lblFromGPS.BackColor = System.Drawing.Color.Transparent;
            this.lblFromGPS.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromGPS.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFromGPS.Location = new System.Drawing.Point(347, 109);
            this.lblFromGPS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromGPS.Name = "lblFromGPS";
            this.lblFromGPS.Size = new System.Drawing.Size(64, 27);
            this.lblFromGPS.TabIndex = 130;
            this.lblFromGPS.Text = "---";
            this.lblFromGPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGPS1Comm
            // 
            this.lblGPS1Comm.BackColor = System.Drawing.Color.Transparent;
            this.lblGPS1Comm.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPS1Comm.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGPS1Comm.Location = new System.Drawing.Point(134, 109);
            this.lblGPS1Comm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGPS1Comm.Name = "lblGPS1Comm";
            this.lblGPS1Comm.Size = new System.Drawing.Size(66, 27);
            this.lblGPS1Comm.TabIndex = 176;
            this.lblGPS1Comm.Text = "--";
            this.lblGPS1Comm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuStrip});
            this.statusStrip1.Location = new System.Drawing.Point(83, 371);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 11, 0);
            this.statusStrip1.Size = new System.Drawing.Size(69, 70);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 149;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // settingsMenuStrip
            // 
            this.settingsMenuStrip.AutoSize = false;
            this.settingsMenuStrip.BackColor = System.Drawing.Color.Transparent;
            this.settingsMenuStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deviceManagerToolStripMenuItem,
            this.saveToolStrip,
            this.loadToolStrip});
            this.settingsMenuStrip.Image = global::AgIO.Properties.Resources.Settings48;
            this.settingsMenuStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingsMenuStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsMenuStrip.Name = "settingsMenuStrip";
            this.settingsMenuStrip.ShowDropDownArrow = false;
            this.settingsMenuStrip.Size = new System.Drawing.Size(64, 68);
            // 
            // deviceManagerToolStripMenuItem
            // 
            this.deviceManagerToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceManagerToolStripMenuItem.Image = global::AgIO.Properties.Resources.DeviceManager;
            this.deviceManagerToolStripMenuItem.Name = "deviceManagerToolStripMenuItem";
            this.deviceManagerToolStripMenuItem.Size = new System.Drawing.Size(296, 70);
            this.deviceManagerToolStripMenuItem.Text = "Device Manager";
            this.deviceManagerToolStripMenuItem.Click += new System.EventHandler(this.deviceManagerToolStripMenuItem_Click);
            // 
            // saveToolStrip
            // 
            this.saveToolStrip.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveToolStrip.Image = global::AgIO.Properties.Resources.VehFileSave;
            this.saveToolStrip.Name = "saveToolStrip";
            this.saveToolStrip.Size = new System.Drawing.Size(296, 70);
            this.saveToolStrip.Text = "Save";
            this.saveToolStrip.Click += new System.EventHandler(this.saveToolStrip_Click);
            // 
            // loadToolStrip
            // 
            this.loadToolStrip.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadToolStrip.Image = global::AgIO.Properties.Resources.VehFileLoad;
            this.loadToolStrip.Name = "loadToolStrip";
            this.loadToolStrip.Size = new System.Drawing.Size(296, 70);
            this.loadToolStrip.Text = "Load";
            this.loadToolStrip.Click += new System.EventHandler(this.loadToolStrip_Click);
            // 
            // lblSteerAngle
            // 
            this.lblSteerAngle.AutoSize = true;
            this.lblSteerAngle.BackColor = System.Drawing.Color.Transparent;
            this.lblSteerAngle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerAngle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSteerAngle.Location = new System.Drawing.Point(497, 12);
            this.lblSteerAngle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSteerAngle.Name = "lblSteerAngle";
            this.lblSteerAngle.Size = new System.Drawing.Size(40, 18);
            this.lblSteerAngle.TabIndex = 473;
            this.lblSteerAngle.Text = "UDP";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(8, 346);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 470;
            this.label1.Text = "Com Ports";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNTRIP_IP
            // 
            this.lblNTRIP_IP.BackColor = System.Drawing.Color.Transparent;
            this.lblNTRIP_IP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNTRIP_IP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNTRIP_IP.Location = new System.Drawing.Point(3, 32);
            this.lblNTRIP_IP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNTRIP_IP.Name = "lblNTRIP_IP";
            this.lblNTRIP_IP.Size = new System.Drawing.Size(120, 18);
            this.lblNTRIP_IP.TabIndex = 468;
            this.lblNTRIP_IP.Text = "--";
            this.lblNTRIP_IP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSerialPorts
            // 
            this.lblSerialPorts.AutoSize = true;
            this.lblSerialPorts.BackColor = System.Drawing.Color.Transparent;
            this.lblSerialPorts.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialPorts.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSerialPorts.Location = new System.Drawing.Point(90, 352);
            this.lblSerialPorts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSerialPorts.Name = "lblSerialPorts";
            this.lblSerialPorts.Size = new System.Drawing.Size(15, 14);
            this.lblSerialPorts.TabIndex = 467;
            this.lblSerialPorts.Text = "--";
            this.lblSerialPorts.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMount
            // 
            this.lblMount.BackColor = System.Drawing.Color.Transparent;
            this.lblMount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMount.Location = new System.Drawing.Point(3, 53);
            this.lblMount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMount.Name = "lblMount";
            this.lblMount.Size = new System.Drawing.Size(120, 18);
            this.lblMount.TabIndex = 465;
            this.lblMount.Text = "--";
            this.lblMount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIP
            // 
            this.lblIP.BackColor = System.Drawing.Color.Transparent;
            this.lblIP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblIP.Location = new System.Drawing.Point(3, 246);
            this.lblIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(120, 18);
            this.lblIP.TabIndex = 464;
            this.lblIP.Text = "288.288.288.288";
            this.lblIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCount.Location = new System.Drawing.Point(459, 396);
            this.lblCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(26, 18);
            this.lblCount.TabIndex = 463;
            this.lblCount.Text = "---";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ntripMeterTimer
            // 
            this.ntripMeterTimer.Interval = 50;
            this.ntripMeterTimer.Tick += new System.EventHandler(this.ntripMeterTimer_Tick);
            // 
            // lblMessages
            // 
            this.lblMessages.BackColor = System.Drawing.Color.Transparent;
            this.lblMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMessages.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessages.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMessages.Location = new System.Drawing.Point(578, 29);
            this.lblMessages.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Size = new System.Drawing.Size(97, 331);
            this.lblMessages.TabIndex = 474;
            this.lblMessages.Text = "--";
            // 
            // lblWASCounts
            // 
            this.lblWASCounts.AutoSize = true;
            this.lblWASCounts.BackColor = System.Drawing.Color.Transparent;
            this.lblWASCounts.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWASCounts.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWASCounts.Location = new System.Drawing.Point(497, 35);
            this.lblWASCounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWASCounts.Name = "lblWASCounts";
            this.lblWASCounts.Size = new System.Drawing.Size(43, 18);
            this.lblWASCounts.TabIndex = 476;
            this.lblWASCounts.Text = "Only";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(444, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 477;
            this.label3.Text = "Angle:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(436, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.TabIndex = 478;
            this.label4.Text = "Counts:";
            // 
            // lblTotalMessageCount
            // 
            this.lblTotalMessageCount.AutoSize = true;
            this.lblTotalMessageCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalMessageCount.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMessageCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalMessageCount.Location = new System.Drawing.Point(593, 5);
            this.lblTotalMessageCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalMessageCount.Name = "lblTotalMessageCount";
            this.lblTotalMessageCount.Size = new System.Drawing.Size(18, 18);
            this.lblTotalMessageCount.TabIndex = 480;
            this.lblTotalMessageCount.Text = "0";
            this.lblTotalMessageCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(436, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 481;
            this.label2.Text = "Switch:";
            // 
            // lblSwitchStatus
            // 
            this.lblSwitchStatus.AutoSize = true;
            this.lblSwitchStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblSwitchStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwitchStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSwitchStatus.Location = new System.Drawing.Point(497, 62);
            this.lblSwitchStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSwitchStatus.Name = "lblSwitchStatus";
            this.lblSwitchStatus.Size = new System.Drawing.Size(18, 18);
            this.lblSwitchStatus.TabIndex = 482;
            this.lblSwitchStatus.Text = "*";
            // 
            // lblWorkSwitchStatus
            // 
            this.lblWorkSwitchStatus.AutoSize = true;
            this.lblWorkSwitchStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkSwitchStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkSwitchStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWorkSwitchStatus.Location = new System.Drawing.Point(497, 85);
            this.lblWorkSwitchStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWorkSwitchStatus.Name = "lblWorkSwitchStatus";
            this.lblWorkSwitchStatus.Size = new System.Drawing.Size(18, 18);
            this.lblWorkSwitchStatus.TabIndex = 484;
            this.lblWorkSwitchStatus.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(445, 84);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 19);
            this.label9.TabIndex = 483;
            this.label9.Text = "Work:";
            // 
            // btnStartStopNtrip
            // 
            this.btnStartStopNtrip.BackColor = System.Drawing.Color.AliceBlue;
            this.btnStartStopNtrip.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnStartStopNtrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStopNtrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStopNtrip.ForeColor = System.Drawing.Color.Black;
            this.btnStartStopNtrip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStartStopNtrip.Location = new System.Drawing.Point(23, 130);
            this.btnStartStopNtrip.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartStopNtrip.Name = "btnStartStopNtrip";
            this.btnStartStopNtrip.Size = new System.Drawing.Size(80, 27);
            this.btnStartStopNtrip.TabIndex = 147;
            this.btnStartStopNtrip.Text = "StartStop";
            this.btnStartStopNtrip.UseVisualStyleBackColor = false;
            this.btnStartStopNtrip.Click += new System.EventHandler(this.btnStartStopNtrip_Click);
            // 
            // btnWindowsShutDown
            // 
            this.btnWindowsShutDown.BackColor = System.Drawing.Color.Transparent;
            this.btnWindowsShutDown.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnWindowsShutDown.FlatAppearance.BorderSize = 0;
            this.btnWindowsShutDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindowsShutDown.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWindowsShutDown.ForeColor = System.Drawing.Color.White;
            this.btnWindowsShutDown.Image = global::AgIO.Properties.Resources.WindowsShutDown;
            this.btnWindowsShutDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnWindowsShutDown.Location = new System.Drawing.Point(613, 377);
            this.btnWindowsShutDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnWindowsShutDown.Name = "btnWindowsShutDown";
            this.btnWindowsShutDown.Size = new System.Drawing.Size(63, 58);
            this.btnWindowsShutDown.TabIndex = 486;
            this.btnWindowsShutDown.UseVisualStyleBackColor = false;
            this.btnWindowsShutDown.Click += new System.EventHandler(this.btnWindowsShutDown_Click);
            // 
            // btnSlide
            // 
            this.btnSlide.BackColor = System.Drawing.Color.Transparent;
            this.btnSlide.BackgroundImage = global::AgIO.Properties.Resources.ArrowGrnRight;
            this.btnSlide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSlide.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSlide.FlatAppearance.BorderSize = 0;
            this.btnSlide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlide.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSlide.ForeColor = System.Drawing.Color.White;
            this.btnSlide.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSlide.Location = new System.Drawing.Point(352, 2);
            this.btnSlide.Margin = new System.Windows.Forms.Padding(4);
            this.btnSlide.Name = "btnSlide";
            this.btnSlide.Size = new System.Drawing.Size(55, 43);
            this.btnSlide.TabIndex = 475;
            this.btnSlide.UseVisualStyleBackColor = false;
            this.btnSlide.Click += new System.EventHandler(this.btnSlide_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::AgIO.Properties.Resources.AgIO_First;
            this.pictureBox1.Location = new System.Drawing.Point(94, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 35);
            this.pictureBox1.TabIndex = 182;
            this.pictureBox1.TabStop = false;
            // 
            // btnUDP
            // 
            this.btnUDP.BackColor = System.Drawing.Color.GhostWhite;
            this.btnUDP.BackgroundImage = global::AgIO.Properties.Resources.B_UDP;
            this.btnUDP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUDP.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnUDP.FlatAppearance.BorderSize = 0;
            this.btnUDP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUDP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUDP.ForeColor = System.Drawing.Color.White;
            this.btnUDP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUDP.Location = new System.Drawing.Point(20, 268);
            this.btnUDP.Margin = new System.Windows.Forms.Padding(4);
            this.btnUDP.Name = "btnUDP";
            this.btnUDP.Size = new System.Drawing.Size(82, 60);
            this.btnUDP.TabIndex = 184;
            this.btnUDP.UseVisualStyleBackColor = false;
            this.btnUDP.Click += new System.EventHandler(this.btnUDP_Click);
            // 
            // btnRadio
            // 
            this.btnRadio.BackColor = System.Drawing.Color.Transparent;
            this.btnRadio.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnRadio.FlatAppearance.BorderSize = 0;
            this.btnRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRadio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRadio.ForeColor = System.Drawing.Color.White;
            this.btnRadio.Image = global::AgIO.Properties.Resources.RadioSettings;
            this.btnRadio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRadio.Location = new System.Drawing.Point(171, 377);
            this.btnRadio.Margin = new System.Windows.Forms.Padding(4);
            this.btnRadio.Name = "btnRadio";
            this.btnRadio.Size = new System.Drawing.Size(63, 58);
            this.btnRadio.TabIndex = 466;
            this.btnRadio.UseVisualStyleBackColor = false;
            this.btnRadio.Click += new System.EventHandler(this.btnRadio_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::AgIO.Properties.Resources.InOut;
            this.pictureBox2.Location = new System.Drawing.Point(216, 57);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(186, 36);
            this.pictureBox2.TabIndex = 183;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // cboxLogNMEA
            // 
            this.cboxLogNMEA.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxLogNMEA.BackColor = System.Drawing.Color.Transparent;
            this.cboxLogNMEA.BackgroundImage = global::AgIO.Properties.Resources.LogNMEA;
            this.cboxLogNMEA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cboxLogNMEA.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxLogNMEA.FlatAppearance.BorderSize = 0;
            this.cboxLogNMEA.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.cboxLogNMEA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxLogNMEA.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxLogNMEA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxLogNMEA.Location = new System.Drawing.Point(519, 377);
            this.cboxLogNMEA.Name = "cboxLogNMEA";
            this.cboxLogNMEA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxLogNMEA.Size = new System.Drawing.Size(63, 58);
            this.cboxLogNMEA.TabIndex = 461;
            this.cboxLogNMEA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxLogNMEA.UseVisualStyleBackColor = false;
            this.cboxLogNMEA.CheckedChanged += new System.EventHandler(this.cboxLogNMEA_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = global::AgIO.Properties.Resources.SwitchOff;
            this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExit.Location = new System.Drawing.Point(3, 377);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(63, 58);
            this.btnExit.TabIndex = 192;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNTRIP
            // 
            this.btnNTRIP.BackColor = System.Drawing.Color.Transparent;
            this.btnNTRIP.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnNTRIP.FlatAppearance.BorderSize = 0;
            this.btnNTRIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNTRIP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNTRIP.ForeColor = System.Drawing.Color.White;
            this.btnNTRIP.Image = global::AgIO.Properties.Resources.NtripSettings;
            this.btnNTRIP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNTRIP.Location = new System.Drawing.Point(262, 377);
            this.btnNTRIP.Margin = new System.Windows.Forms.Padding(4);
            this.btnNTRIP.Name = "btnNTRIP";
            this.btnNTRIP.Size = new System.Drawing.Size(63, 58);
            this.btnNTRIP.TabIndex = 191;
            this.btnNTRIP.UseVisualStyleBackColor = false;
            this.btnNTRIP.Click += new System.EventHandler(this.btnNTRIP_Click);
            // 
            // btnRunAOG
            // 
            this.btnRunAOG.BackColor = System.Drawing.Color.Transparent;
            this.btnRunAOG.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnRunAOG.FlatAppearance.BorderSize = 0;
            this.btnRunAOG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunAOG.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunAOG.ForeColor = System.Drawing.Color.White;
            this.btnRunAOG.Image = global::AgIO.Properties.Resources.AgIOBtn;
            this.btnRunAOG.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRunAOG.Location = new System.Drawing.Point(350, 377);
            this.btnRunAOG.Margin = new System.Windows.Forms.Padding(4);
            this.btnRunAOG.Name = "btnRunAOG";
            this.btnRunAOG.Size = new System.Drawing.Size(63, 58);
            this.btnRunAOG.TabIndex = 190;
            this.btnRunAOG.UseVisualStyleBackColor = false;
            this.btnRunAOG.Click += new System.EventHandler(this.btnRunAOG_Click);
            // 
            // btnIMU
            // 
            this.btnIMU.BackColor = System.Drawing.Color.Transparent;
            this.btnIMU.BackgroundImage = global::AgIO.Properties.Resources.B_IMU;
            this.btnIMU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIMU.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnIMU.FlatAppearance.BorderSize = 0;
            this.btnIMU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIMU.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIMU.ForeColor = System.Drawing.Color.White;
            this.btnIMU.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnIMU.Location = new System.Drawing.Point(271, 165);
            this.btnIMU.Margin = new System.Windows.Forms.Padding(4);
            this.btnIMU.Name = "btnIMU";
            this.btnIMU.Size = new System.Drawing.Size(74, 48);
            this.btnIMU.TabIndex = 185;
            this.btnIMU.UseVisualStyleBackColor = false;
            this.btnIMU.Click += new System.EventHandler(this.btnBringUpCommSettings_Click);
            // 
            // btnSteer
            // 
            this.btnSteer.BackColor = System.Drawing.Color.Transparent;
            this.btnSteer.BackgroundImage = global::AgIO.Properties.Resources.B_Autosteer;
            this.btnSteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSteer.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSteer.FlatAppearance.BorderSize = 0;
            this.btnSteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSteer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSteer.ForeColor = System.Drawing.Color.White;
            this.btnSteer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSteer.Location = new System.Drawing.Point(271, 232);
            this.btnSteer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSteer.Name = "btnSteer";
            this.btnSteer.Size = new System.Drawing.Size(74, 48);
            this.btnSteer.TabIndex = 189;
            this.btnSteer.UseVisualStyleBackColor = false;
            this.btnSteer.Click += new System.EventHandler(this.btnBringUpCommSettings_Click);
            // 
            // btnMachine
            // 
            this.btnMachine.BackColor = System.Drawing.Color.Transparent;
            this.btnMachine.BackgroundImage = global::AgIO.Properties.Resources.B_Machine;
            this.btnMachine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMachine.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnMachine.FlatAppearance.BorderSize = 0;
            this.btnMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMachine.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMachine.ForeColor = System.Drawing.Color.White;
            this.btnMachine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMachine.Location = new System.Drawing.Point(271, 299);
            this.btnMachine.Margin = new System.Windows.Forms.Padding(4);
            this.btnMachine.Name = "btnMachine";
            this.btnMachine.Size = new System.Drawing.Size(74, 48);
            this.btnMachine.TabIndex = 188;
            this.btnMachine.UseVisualStyleBackColor = false;
            this.btnMachine.Click += new System.EventHandler(this.btnBringUpCommSettings_Click);
            // 
            // btnGPS
            // 
            this.btnGPS.BackColor = System.Drawing.Color.Transparent;
            this.btnGPS.BackgroundImage = global::AgIO.Properties.Resources.B_GPS;
            this.btnGPS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGPS.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnGPS.FlatAppearance.BorderSize = 0;
            this.btnGPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGPS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGPS.ForeColor = System.Drawing.Color.White;
            this.btnGPS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGPS.Location = new System.Drawing.Point(271, 98);
            this.btnGPS.Margin = new System.Windows.Forms.Padding(4);
            this.btnGPS.Name = "btnGPS";
            this.btnGPS.Size = new System.Drawing.Size(74, 48);
            this.btnGPS.TabIndex = 187;
            this.btnGPS.UseVisualStyleBackColor = false;
            this.btnGPS.Click += new System.EventHandler(this.btnBringUpCommSettings_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnStartStopNtrip);
            this.panel1.Controls.Add(this.lblWatch);
            this.panel1.Controls.Add(this.lblNTRIPBytes);
            this.panel1.Controls.Add(this.lblMount);
            this.panel1.Controls.Add(this.lblNTRIP_IP);
            this.panel1.Location = new System.Drawing.Point(3, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 165);
            this.panel1.TabIndex = 490;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(3, 2);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 18);
            this.label10.TabIndex = 469;
            this.label10.Text = "NTRIP";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMessagesFound
            // 
            this.lblMessagesFound.AutoSize = true;
            this.lblMessagesFound.BackColor = System.Drawing.Color.Transparent;
            this.lblMessagesFound.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessagesFound.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMessagesFound.Location = new System.Drawing.Point(649, 5);
            this.lblMessagesFound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessagesFound.Name = "lblMessagesFound";
            this.lblMessagesFound.Size = new System.Drawing.Size(18, 18);
            this.lblMessagesFound.TabIndex = 491;
            this.lblMessagesFound.Text = "0";
            this.lblMessagesFound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(632, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 18);
            this.label5.TabIndex = 492;
            this.label5.Text = "F:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(574, 5);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 18);
            this.label7.TabIndex = 493;
            this.label7.Text = "T:";
            // 
            // FormLoop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(685, 439);
            this.ControlBox = false;
            this.Controls.Add(this.lblTotalMessageCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblMessagesFound);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnWindowsShutDown);
            this.Controls.Add(this.lblWorkSwitchStatus);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblSwitchStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblWASCounts);
            this.Controls.Add(this.lblSteerAngle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSlide);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUDP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSerialPorts);
            this.Controls.Add(this.btnRadio);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblToMachine);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.lblToSteer);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblCurentLon);
            this.Controls.Add(this.cboxLogNMEA);
            this.Controls.Add(this.lblFromMachine);
            this.Controls.Add(this.lblFromGPS);
            this.Controls.Add(this.lblFromSteer);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblCurrentLat);
            this.Controls.Add(this.btnNTRIP);
            this.Controls.Add(this.lblGPS1Comm);
            this.Controls.Add(this.lblMod2Comm);
            this.Controls.Add(this.btnRunAOG);
            this.Controls.Add(this.lblMod1Comm);
            this.Controls.Add(this.lblFromMU);
            this.Controls.Add(this.btnIMU);
            this.Controls.Add(this.btnSteer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblToGPS);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnMachine);
            this.Controls.Add(this.btnGPS);
            this.Controls.Add(this.lblIMUComm);
            this.Controls.Add(this.lblMessages);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "FormLoop";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "AgIO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLoop_FormClosing);
            this.Load += new System.EventHandler(this.FormLoop_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer oneSecondLoopTimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCurentLon;
        private System.Windows.Forms.Label lblCurrentLat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblWatch;
        private System.Windows.Forms.Button btnStartStopNtrip;
        private System.Windows.Forms.Label lblNTRIPBytes;
        private System.Windows.Forms.Label lblToMachine;
        private System.Windows.Forms.Label lblToSteer;
        private System.Windows.Forms.Label lblFromMachine;
        private System.Windows.Forms.Label lblFromSteer;
        private System.Windows.Forms.Label lblMod2Comm;
        private System.Windows.Forms.Label lblMod1Comm;
        private System.Windows.Forms.Label lblIMUComm;
        private System.Windows.Forms.Label lblFromMU;
        private System.Windows.Forms.Label lblToGPS;
        private System.Windows.Forms.Label lblFromGPS;
        private System.Windows.Forms.Label lblGPS1Comm;
        private System.Windows.Forms.ToolStripDropDownButton settingsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deviceManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStrip;
        private System.Windows.Forms.ToolStripMenuItem loadToolStrip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnUDP;
        private System.Windows.Forms.Button btnIMU;
        private System.Windows.Forms.Button btnGPS;
        private System.Windows.Forms.Button btnMachine;
        private System.Windows.Forms.Button btnSteer;
        private System.Windows.Forms.Button btnRunAOG;
        private System.Windows.Forms.Button btnNTRIP;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox cboxLogNMEA;
        private System.Windows.Forms.Timer ntripMeterTimer;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblMount;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Button btnRadio;
        private System.Windows.Forms.Label lblSerialPorts;
        private System.Windows.Forms.Label lblNTRIP_IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSteerAngle;
        private System.Windows.Forms.Label lblMessages;
        private System.Windows.Forms.Button btnSlide;
        private System.Windows.Forms.Label lblWASCounts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalMessageCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSwitchStatus;
        private System.Windows.Forms.Label lblWorkSwitchStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnWindowsShutDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMessagesFound;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
    }
}

