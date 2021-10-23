
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCurentLon = new System.Windows.Forms.Label();
            this.lblCurrentLat = new System.Windows.Forms.Label();
            this.lblWatch = new System.Windows.Forms.Label();
            this.lblNTRIPBytes = new System.Windows.Forms.Label();
            this.lblBytes = new System.Windows.Forms.Label();
            this.lblToAOG = new System.Windows.Forms.Label();
            this.lblToUDP = new System.Windows.Forms.Label();
            this.lblFromUDP = new System.Windows.Forms.Label();
            this.lblFromAOG = new System.Windows.Forms.Label();
            this.lblToModule2 = new System.Windows.Forms.Label();
            this.lblToModule1 = new System.Windows.Forms.Label();
            this.lblFromModule2 = new System.Windows.Forms.Label();
            this.lblFromModule1 = new System.Windows.Forms.Label();
            this.lblMod2Comm = new System.Windows.Forms.Label();
            this.lblMod1Comm = new System.Windows.Forms.Label();
            this.lblIMUComm = new System.Windows.Forms.Label();
            this.lblFromMU = new System.Windows.Forms.Label();
            this.lblToIMU = new System.Windows.Forms.Label();
            this.lblToGPS = new System.Windows.Forms.Label();
            this.lblFromGPS = new System.Windows.Forms.Label();
            this.lblGPS1Comm = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.settingsMenuStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripGPSData = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAgDiag = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.uDPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRadio = new System.Windows.Forms.Button();
            this.cboxLogNMEA = new System.Windows.Forms.CheckBox();
            this.btnStartStopNtrip = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNTRIP = new System.Windows.Forms.Button();
            this.btnRunAOG = new System.Windows.Forms.Button();
            this.btnSteer = new System.Windows.Forms.Button();
            this.btnMod1 = new System.Windows.Forms.Button();
            this.btnGPS = new System.Windows.Forms.Button();
            this.btnAOGButton = new System.Windows.Forms.Button();
            this.btnIMU = new System.Windows.Forms.Button();
            this.btnUDP = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnRescanPorts = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 4000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(11, 6);
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
            this.label8.Location = new System.Drawing.Point(6, 31);
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
            this.lblCurentLon.Location = new System.Drawing.Point(42, 32);
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
            this.lblCurrentLat.Location = new System.Drawing.Point(43, 8);
            this.lblCurrentLat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentLat.Name = "lblCurrentLat";
            this.lblCurrentLat.Size = new System.Drawing.Size(28, 18);
            this.lblCurrentLat.TabIndex = 153;
            this.lblCurrentLat.Text = "53";
            // 
            // lblWatch
            // 
            this.lblWatch.AutoSize = true;
            this.lblWatch.BackColor = System.Drawing.Color.Transparent;
            this.lblWatch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWatch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWatch.Location = new System.Drawing.Point(22, 164);
            this.lblWatch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWatch.Name = "lblWatch";
            this.lblWatch.Size = new System.Drawing.Size(50, 16);
            this.lblWatch.TabIndex = 146;
            this.lblWatch.Text = "Watch";
            // 
            // lblNTRIPBytes
            // 
            this.lblNTRIPBytes.AutoSize = true;
            this.lblNTRIPBytes.BackColor = System.Drawing.Color.Transparent;
            this.lblNTRIPBytes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNTRIPBytes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNTRIPBytes.Location = new System.Drawing.Point(64, 184);
            this.lblNTRIPBytes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNTRIPBytes.Name = "lblNTRIPBytes";
            this.lblNTRIPBytes.Size = new System.Drawing.Size(39, 16);
            this.lblNTRIPBytes.TabIndex = 148;
            this.lblNTRIPBytes.Text = "10kb";
            // 
            // lblBytes
            // 
            this.lblBytes.AutoSize = true;
            this.lblBytes.BackColor = System.Drawing.Color.Transparent;
            this.lblBytes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBytes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBytes.Location = new System.Drawing.Point(22, 185);
            this.lblBytes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBytes.Name = "lblBytes";
            this.lblBytes.Size = new System.Drawing.Size(41, 14);
            this.lblBytes.TabIndex = 150;
            this.lblBytes.Text = "Bytes";
            // 
            // lblToAOG
            // 
            this.lblToAOG.BackColor = System.Drawing.Color.Transparent;
            this.lblToAOG.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToAOG.ForeColor = System.Drawing.Color.Black;
            this.lblToAOG.Location = new System.Drawing.Point(202, 53);
            this.lblToAOG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToAOG.Name = "lblToAOG";
            this.lblToAOG.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblToAOG.Size = new System.Drawing.Size(64, 27);
            this.lblToAOG.TabIndex = 123;
            this.lblToAOG.Text = "0000";
            this.lblToAOG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToUDP
            // 
            this.lblToUDP.BackColor = System.Drawing.Color.Transparent;
            this.lblToUDP.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToUDP.ForeColor = System.Drawing.Color.Black;
            this.lblToUDP.Location = new System.Drawing.Point(344, 115);
            this.lblToUDP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToUDP.Name = "lblToUDP";
            this.lblToUDP.Size = new System.Drawing.Size(64, 27);
            this.lblToUDP.TabIndex = 132;
            this.lblToUDP.Text = "---";
            this.lblToUDP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromUDP
            // 
            this.lblFromUDP.BackColor = System.Drawing.Color.Transparent;
            this.lblFromUDP.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromUDP.ForeColor = System.Drawing.Color.Black;
            this.lblFromUDP.Location = new System.Drawing.Point(202, 114);
            this.lblFromUDP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromUDP.Name = "lblFromUDP";
            this.lblFromUDP.Size = new System.Drawing.Size(64, 27);
            this.lblFromUDP.TabIndex = 134;
            this.lblFromUDP.Text = "---";
            this.lblFromUDP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromAOG
            // 
            this.lblFromAOG.BackColor = System.Drawing.Color.Transparent;
            this.lblFromAOG.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromAOG.ForeColor = System.Drawing.Color.Black;
            this.lblFromAOG.Location = new System.Drawing.Point(344, 54);
            this.lblFromAOG.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromAOG.Name = "lblFromAOG";
            this.lblFromAOG.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFromAOG.Size = new System.Drawing.Size(64, 27);
            this.lblFromAOG.TabIndex = 126;
            this.lblFromAOG.Text = "0000";
            this.lblFromAOG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToModule2
            // 
            this.lblToModule2.BackColor = System.Drawing.Color.Transparent;
            this.lblToModule2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToModule2.ForeColor = System.Drawing.Color.Black;
            this.lblToModule2.Location = new System.Drawing.Point(202, 359);
            this.lblToModule2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToModule2.Name = "lblToModule2";
            this.lblToModule2.Size = new System.Drawing.Size(64, 27);
            this.lblToModule2.TabIndex = 163;
            this.lblToModule2.Text = "---";
            this.lblToModule2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToModule1
            // 
            this.lblToModule1.BackColor = System.Drawing.Color.Transparent;
            this.lblToModule1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToModule1.ForeColor = System.Drawing.Color.Black;
            this.lblToModule1.Location = new System.Drawing.Point(202, 303);
            this.lblToModule1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToModule1.Name = "lblToModule1";
            this.lblToModule1.Size = new System.Drawing.Size(64, 27);
            this.lblToModule1.TabIndex = 141;
            this.lblToModule1.Text = "---";
            this.lblToModule1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromModule2
            // 
            this.lblFromModule2.BackColor = System.Drawing.Color.Transparent;
            this.lblFromModule2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromModule2.ForeColor = System.Drawing.Color.Black;
            this.lblFromModule2.Location = new System.Drawing.Point(344, 359);
            this.lblFromModule2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromModule2.Name = "lblFromModule2";
            this.lblFromModule2.Size = new System.Drawing.Size(64, 27);
            this.lblFromModule2.TabIndex = 164;
            this.lblFromModule2.Text = "---";
            this.lblFromModule2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromModule1
            // 
            this.lblFromModule1.BackColor = System.Drawing.Color.Transparent;
            this.lblFromModule1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromModule1.ForeColor = System.Drawing.Color.Black;
            this.lblFromModule1.Location = new System.Drawing.Point(344, 303);
            this.lblFromModule1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromModule1.Name = "lblFromModule1";
            this.lblFromModule1.Size = new System.Drawing.Size(64, 27);
            this.lblFromModule1.TabIndex = 142;
            this.lblFromModule1.Text = "---";
            this.lblFromModule1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMod2Comm
            // 
            this.lblMod2Comm.BackColor = System.Drawing.Color.Transparent;
            this.lblMod2Comm.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMod2Comm.ForeColor = System.Drawing.Color.Black;
            this.lblMod2Comm.Location = new System.Drawing.Point(115, 361);
            this.lblMod2Comm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMod2Comm.Name = "lblMod2Comm";
            this.lblMod2Comm.Size = new System.Drawing.Size(80, 27);
            this.lblMod2Comm.TabIndex = 178;
            this.lblMod2Comm.Text = "--";
            this.lblMod2Comm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMod1Comm
            // 
            this.lblMod1Comm.BackColor = System.Drawing.Color.Transparent;
            this.lblMod1Comm.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMod1Comm.ForeColor = System.Drawing.Color.Black;
            this.lblMod1Comm.Location = new System.Drawing.Point(115, 305);
            this.lblMod1Comm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMod1Comm.Name = "lblMod1Comm";
            this.lblMod1Comm.Size = new System.Drawing.Size(80, 27);
            this.lblMod1Comm.TabIndex = 177;
            this.lblMod1Comm.Text = "--";
            this.lblMod1Comm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIMUComm
            // 
            this.lblIMUComm.BackColor = System.Drawing.Color.Transparent;
            this.lblIMUComm.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMUComm.ForeColor = System.Drawing.Color.Black;
            this.lblIMUComm.Location = new System.Drawing.Point(115, 249);
            this.lblIMUComm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIMUComm.Name = "lblIMUComm";
            this.lblIMUComm.Size = new System.Drawing.Size(80, 27);
            this.lblIMUComm.TabIndex = 175;
            this.lblIMUComm.Text = "--";
            this.lblIMUComm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromMU
            // 
            this.lblFromMU.BackColor = System.Drawing.Color.Transparent;
            this.lblFromMU.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromMU.ForeColor = System.Drawing.Color.Black;
            this.lblFromMU.Location = new System.Drawing.Point(344, 247);
            this.lblFromMU.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromMU.Name = "lblFromMU";
            this.lblFromMU.Size = new System.Drawing.Size(64, 27);
            this.lblFromMU.TabIndex = 171;
            this.lblFromMU.Text = "---";
            this.lblFromMU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToIMU
            // 
            this.lblToIMU.BackColor = System.Drawing.Color.Transparent;
            this.lblToIMU.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToIMU.ForeColor = System.Drawing.Color.Black;
            this.lblToIMU.Location = new System.Drawing.Point(202, 247);
            this.lblToIMU.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToIMU.Name = "lblToIMU";
            this.lblToIMU.Size = new System.Drawing.Size(64, 27);
            this.lblToIMU.TabIndex = 170;
            this.lblToIMU.Text = "---";
            this.lblToIMU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToGPS
            // 
            this.lblToGPS.BackColor = System.Drawing.Color.Transparent;
            this.lblToGPS.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToGPS.ForeColor = System.Drawing.Color.Black;
            this.lblToGPS.Location = new System.Drawing.Point(202, 182);
            this.lblToGPS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToGPS.Name = "lblToGPS";
            this.lblToGPS.Size = new System.Drawing.Size(64, 27);
            this.lblToGPS.TabIndex = 128;
            this.lblToGPS.Text = "---";
            this.lblToGPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromGPS
            // 
            this.lblFromGPS.BackColor = System.Drawing.Color.Transparent;
            this.lblFromGPS.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromGPS.ForeColor = System.Drawing.Color.Black;
            this.lblFromGPS.Location = new System.Drawing.Point(344, 182);
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
            this.lblGPS1Comm.ForeColor = System.Drawing.Color.Black;
            this.lblGPS1Comm.Location = new System.Drawing.Point(115, 184);
            this.lblGPS1Comm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGPS1Comm.Name = "lblGPS1Comm";
            this.lblGPS1Comm.Size = new System.Drawing.Size(80, 27);
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
            this.statusStrip1.Location = new System.Drawing.Point(87, 414);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 11, 0);
            this.statusStrip1.Size = new System.Drawing.Size(95, 76);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 149;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // settingsMenuStrip
            // 
            this.settingsMenuStrip.AutoSize = false;
            this.settingsMenuStrip.BackColor = System.Drawing.Color.Gainsboro;
            this.settingsMenuStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripGPSData,
            this.deviceManagerToolStripMenuItem,
            this.toolStripAgDiag,
            this.saveToolStrip,
            this.loadToolStrip,
            this.uDPToolStripMenuItem});
            this.settingsMenuStrip.Image = global::AgIO.Properties.Resources.Settings48;
            this.settingsMenuStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingsMenuStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsMenuStrip.Name = "settingsMenuStrip";
            this.settingsMenuStrip.ShowDropDownArrow = false;
            this.settingsMenuStrip.Size = new System.Drawing.Size(64, 74);
            // 
            // toolStripGPSData
            // 
            this.toolStripGPSData.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripGPSData.Image = global::AgIO.Properties.Resources.B_GPS;
            this.toolStripGPSData.Name = "toolStripGPSData";
            this.toolStripGPSData.Size = new System.Drawing.Size(276, 70);
            this.toolStripGPSData.Text = "GPS Data";
            this.toolStripGPSData.Click += new System.EventHandler(this.toolStripGPSData_Click);
            // 
            // deviceManagerToolStripMenuItem
            // 
            this.deviceManagerToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceManagerToolStripMenuItem.Image = global::AgIO.Properties.Resources.DeviceManager;
            this.deviceManagerToolStripMenuItem.Name = "deviceManagerToolStripMenuItem";
            this.deviceManagerToolStripMenuItem.Size = new System.Drawing.Size(276, 70);
            this.deviceManagerToolStripMenuItem.Text = "Device Manager";
            this.deviceManagerToolStripMenuItem.Click += new System.EventHandler(this.deviceManagerToolStripMenuItem_Click);
            // 
            // toolStripAgDiag
            // 
            this.toolStripAgDiag.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripAgDiag.Image = global::AgIO.Properties.Resources.AgDiagButton;
            this.toolStripAgDiag.Name = "toolStripAgDiag";
            this.toolStripAgDiag.Size = new System.Drawing.Size(276, 70);
            this.toolStripAgDiag.Text = "AgDiag";
            this.toolStripAgDiag.Click += new System.EventHandler(this.toolStripAgDiag_Click);
            // 
            // saveToolStrip
            // 
            this.saveToolStrip.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveToolStrip.Image = global::AgIO.Properties.Resources.VehFileSave;
            this.saveToolStrip.Name = "saveToolStrip";
            this.saveToolStrip.Size = new System.Drawing.Size(276, 70);
            this.saveToolStrip.Text = "Save";
            this.saveToolStrip.Click += new System.EventHandler(this.saveToolStrip_Click);
            // 
            // loadToolStrip
            // 
            this.loadToolStrip.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadToolStrip.Image = global::AgIO.Properties.Resources.VehFileLoad;
            this.loadToolStrip.Name = "loadToolStrip";
            this.loadToolStrip.Size = new System.Drawing.Size(276, 70);
            this.loadToolStrip.Text = "Load";
            this.loadToolStrip.Click += new System.EventHandler(this.loadToolStrip_Click);
            // 
            // uDPToolStripMenuItem
            // 
            this.uDPToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uDPToolStripMenuItem.Image = global::AgIO.Properties.Resources.B_UDP;
            this.uDPToolStripMenuItem.Name = "uDPToolStripMenuItem";
            this.uDPToolStripMenuItem.Size = new System.Drawing.Size(276, 70);
            this.uDPToolStripMenuItem.Text = "UDP";
            this.uDPToolStripMenuItem.Click += new System.EventHandler(this.uDPToolStripMenuItem_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Snow;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Location = new System.Drawing.Point(5, 276);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(90, 140);
            this.listBox1.TabIndex = 193;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btnRadio);
            this.panel1.Controls.Add(this.cboxLogNMEA);
            this.panel1.Controls.Add(this.btnStartStopNtrip);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.lblFromGPS);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.lblToIMU);
            this.panel1.Controls.Add(this.btnNTRIP);
            this.panel1.Controls.Add(this.lblGPS1Comm);
            this.panel1.Controls.Add(this.btnRunAOG);
            this.panel1.Controls.Add(this.lblFromMU);
            this.panel1.Controls.Add(this.btnSteer);
            this.panel1.Controls.Add(this.lblToGPS);
            this.panel1.Controls.Add(this.btnMod1);
            this.panel1.Controls.Add(this.lblIMUComm);
            this.panel1.Controls.Add(this.btnGPS);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.btnAOGButton);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnIMU);
            this.panel1.Controls.Add(this.lblMod1Comm);
            this.panel1.Controls.Add(this.btnUDP);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.lblMod2Comm);
            this.panel1.Controls.Add(this.lblToAOG);
            this.panel1.Controls.Add(this.lblNTRIPBytes);
            this.panel1.Controls.Add(this.lblToUDP);
            this.panel1.Controls.Add(this.lblCurrentLat);
            this.panel1.Controls.Add(this.lblBytes);
            this.panel1.Controls.Add(this.lblFromModule1);
            this.panel1.Controls.Add(this.lblWatch);
            this.panel1.Controls.Add(this.lblFromUDP);
            this.panel1.Controls.Add(this.lblFromModule2);
            this.panel1.Controls.Add(this.lblFromAOG);
            this.panel1.Controls.Add(this.lblCurentLon);
            this.panel1.Controls.Add(this.btnRescanPorts);
            this.panel1.Controls.Add(this.lblToModule1);
            this.panel1.Controls.Add(this.lblToModule2);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(411, 491);
            this.panel1.TabIndex = 194;
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
            this.btnRadio.Location = new System.Drawing.Point(254, 423);
            this.btnRadio.Margin = new System.Windows.Forms.Padding(4);
            this.btnRadio.Name = "btnRadio";
            this.btnRadio.Size = new System.Drawing.Size(63, 58);
            this.btnRadio.TabIndex = 462;
            this.btnRadio.UseVisualStyleBackColor = false;
            this.btnRadio.Click += new System.EventHandler(this.btnRadio_Click);
            // 
            // cboxLogNMEA
            // 
            this.cboxLogNMEA.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxLogNMEA.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxLogNMEA.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxLogNMEA.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxLogNMEA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxLogNMEA.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxLogNMEA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxLogNMEA.Location = new System.Drawing.Point(10, 63);
            this.cboxLogNMEA.Name = "cboxLogNMEA";
            this.cboxLogNMEA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxLogNMEA.Size = new System.Drawing.Size(90, 30);
            this.cboxLogNMEA.TabIndex = 461;
            this.cboxLogNMEA.Text = "Log NMEA";
            this.cboxLogNMEA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxLogNMEA.UseVisualStyleBackColor = false;
            this.cboxLogNMEA.CheckedChanged += new System.EventHandler(this.cboxLogNMEA_CheckedChanged);
            // 
            // btnStartStopNtrip
            // 
            this.btnStartStopNtrip.BackColor = System.Drawing.Color.Transparent;
            this.btnStartStopNtrip.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnStartStopNtrip.FlatAppearance.BorderSize = 0;
            this.btnStartStopNtrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStopNtrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStopNtrip.ForeColor = System.Drawing.Color.Black;
            this.btnStartStopNtrip.Image = global::AgIO.Properties.Resources.NtripBlank;
            this.btnStartStopNtrip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStartStopNtrip.Location = new System.Drawing.Point(6, 110);
            this.btnStartStopNtrip.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartStopNtrip.Name = "btnStartStopNtrip";
            this.btnStartStopNtrip.Size = new System.Drawing.Size(97, 46);
            this.btnStartStopNtrip.TabIndex = 147;
            this.btnStartStopNtrip.Text = "StartStop";
            this.btnStartStopNtrip.UseVisualStyleBackColor = false;
            this.btnStartStopNtrip.Click += new System.EventHandler(this.btnStartStopNtrip_Click);
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
            this.btnExit.Location = new System.Drawing.Point(10, 423);
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
            this.btnNTRIP.Location = new System.Drawing.Point(177, 423);
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
            this.btnRunAOG.Location = new System.Drawing.Point(331, 423);
            this.btnRunAOG.Margin = new System.Windows.Forms.Padding(4);
            this.btnRunAOG.Name = "btnRunAOG";
            this.btnRunAOG.Size = new System.Drawing.Size(63, 58);
            this.btnRunAOG.TabIndex = 190;
            this.btnRunAOG.UseVisualStyleBackColor = false;
            this.btnRunAOG.Click += new System.EventHandler(this.btnRunAOG_Click);
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
            this.btnSteer.Location = new System.Drawing.Point(268, 295);
            this.btnSteer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSteer.Name = "btnSteer";
            this.btnSteer.Size = new System.Drawing.Size(74, 48);
            this.btnSteer.TabIndex = 189;
            this.btnSteer.UseVisualStyleBackColor = false;
            this.btnSteer.Click += new System.EventHandler(this.btnBringUpCommSettings_Click);
            // 
            // btnMod1
            // 
            this.btnMod1.BackColor = System.Drawing.Color.Transparent;
            this.btnMod1.BackgroundImage = global::AgIO.Properties.Resources.B_Machine;
            this.btnMod1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMod1.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnMod1.FlatAppearance.BorderSize = 0;
            this.btnMod1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMod1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMod1.ForeColor = System.Drawing.Color.White;
            this.btnMod1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMod1.Location = new System.Drawing.Point(268, 351);
            this.btnMod1.Margin = new System.Windows.Forms.Padding(4);
            this.btnMod1.Name = "btnMod1";
            this.btnMod1.Size = new System.Drawing.Size(74, 48);
            this.btnMod1.TabIndex = 188;
            this.btnMod1.UseVisualStyleBackColor = false;
            this.btnMod1.Click += new System.EventHandler(this.btnBringUpCommSettings_Click);
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
            this.btnGPS.Location = new System.Drawing.Point(268, 173);
            this.btnGPS.Margin = new System.Windows.Forms.Padding(4);
            this.btnGPS.Name = "btnGPS";
            this.btnGPS.Size = new System.Drawing.Size(74, 48);
            this.btnGPS.TabIndex = 187;
            this.btnGPS.UseVisualStyleBackColor = false;
            this.btnGPS.Click += new System.EventHandler(this.btnBringUpCommSettings_Click);
            // 
            // btnAOGButton
            // 
            this.btnAOGButton.BackColor = System.Drawing.Color.Transparent;
            this.btnAOGButton.BackgroundImage = global::AgIO.Properties.Resources.B_AoG;
            this.btnAOGButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAOGButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnAOGButton.FlatAppearance.BorderSize = 0;
            this.btnAOGButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAOGButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAOGButton.ForeColor = System.Drawing.Color.White;
            this.btnAOGButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAOGButton.Location = new System.Drawing.Point(268, 45);
            this.btnAOGButton.Margin = new System.Windows.Forms.Padding(4);
            this.btnAOGButton.Name = "btnAOGButton";
            this.btnAOGButton.Size = new System.Drawing.Size(74, 48);
            this.btnAOGButton.TabIndex = 186;
            this.btnAOGButton.UseVisualStyleBackColor = false;
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
            this.btnIMU.Location = new System.Drawing.Point(268, 237);
            this.btnIMU.Margin = new System.Windows.Forms.Padding(4);
            this.btnIMU.Name = "btnIMU";
            this.btnIMU.Size = new System.Drawing.Size(74, 48);
            this.btnIMU.TabIndex = 185;
            this.btnIMU.UseVisualStyleBackColor = false;
            this.btnIMU.Click += new System.EventHandler(this.btnBringUpCommSettings_Click);
            // 
            // btnUDP
            // 
            this.btnUDP.BackColor = System.Drawing.Color.Transparent;
            this.btnUDP.BackgroundImage = global::AgIO.Properties.Resources.B_UDP;
            this.btnUDP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUDP.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnUDP.FlatAppearance.BorderSize = 0;
            this.btnUDP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUDP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUDP.ForeColor = System.Drawing.Color.White;
            this.btnUDP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUDP.Location = new System.Drawing.Point(268, 109);
            this.btnUDP.Margin = new System.Windows.Forms.Padding(4);
            this.btnUDP.Name = "btnUDP";
            this.btnUDP.Size = new System.Drawing.Size(74, 48);
            this.btnUDP.TabIndex = 184;
            this.btnUDP.UseVisualStyleBackColor = false;
            this.btnUDP.Click += new System.EventHandler(this.btnUDP_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::AgIO.Properties.Resources.InOut;
            this.pictureBox2.Location = new System.Drawing.Point(216, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(186, 36);
            this.pictureBox2.TabIndex = 183;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnRescanPorts
            // 
            this.btnRescanPorts.BackColor = System.Drawing.Color.Transparent;
            this.btnRescanPorts.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnRescanPorts.FlatAppearance.BorderSize = 0;
            this.btnRescanPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRescanPorts.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRescanPorts.ForeColor = System.Drawing.Color.White;
            this.btnRescanPorts.Image = global::AgIO.Properties.Resources.ScanPorts;
            this.btnRescanPorts.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRescanPorts.Location = new System.Drawing.Point(17, 214);
            this.btnRescanPorts.Margin = new System.Windows.Forms.Padding(4);
            this.btnRescanPorts.Name = "btnRescanPorts";
            this.btnRescanPorts.Size = new System.Drawing.Size(63, 58);
            this.btnRescanPorts.TabIndex = 180;
            this.btnRescanPorts.UseVisualStyleBackColor = false;
            this.btnRescanPorts.Click += new System.EventHandler(this.btnRescanPorts_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AgIO.Properties.Resources.FirstAgiO;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(217, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 35);
            this.pictureBox1.TabIndex = 182;
            this.pictureBox1.TabStop = false;
            // 
            // FormLoop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(419, 497);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCurentLon;
        private System.Windows.Forms.Label lblCurrentLat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblWatch;
        private System.Windows.Forms.Button btnStartStopNtrip;
        private System.Windows.Forms.Label lblNTRIPBytes;
        private System.Windows.Forms.Label lblBytes;
        private System.Windows.Forms.Label lblToAOG;
        private System.Windows.Forms.Label lblToUDP;
        private System.Windows.Forms.Label lblFromUDP;
        private System.Windows.Forms.Label lblFromAOG;
        private System.Windows.Forms.Label lblToModule2;
        private System.Windows.Forms.Label lblToModule1;
        private System.Windows.Forms.Label lblFromModule2;
        private System.Windows.Forms.Label lblFromModule1;
        private System.Windows.Forms.Label lblMod2Comm;
        private System.Windows.Forms.Label lblMod1Comm;
        private System.Windows.Forms.Label lblIMUComm;
        private System.Windows.Forms.Label lblFromMU;
        private System.Windows.Forms.Label lblToIMU;
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
        private System.Windows.Forms.Button btnAOGButton;
        private System.Windows.Forms.Button btnGPS;
        private System.Windows.Forms.Button btnMod1;
        private System.Windows.Forms.Button btnSteer;
        private System.Windows.Forms.Button btnRunAOG;
        private System.Windows.Forms.Button btnNTRIP;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRescanPorts;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem uDPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripGPSData;
        private System.Windows.Forms.ToolStripMenuItem toolStripAgDiag;
        private System.Windows.Forms.CheckBox cboxLogNMEA;
        private System.Windows.Forms.Button btnRadio;
    }
}

