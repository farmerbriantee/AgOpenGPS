namespace AgIO
{
    partial class FormUDP
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
            this.label6 = new System.Windows.Forms.Label();
            this.lblNetworkHelp = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.nudFirstIP = new System.Windows.Forms.NumericUpDown();
            this.nudSecndIP = new System.Windows.Forms.NumericUpDown();
            this.nudThirdIP = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tboxNets = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHostname = new System.Windows.Forms.Label();
            this.lblNoAdapter = new System.Windows.Forms.Label();
            this.cboxUp = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSubTimer = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBtnIMU = new System.Windows.Forms.Label();
            this.lblBtnGPS = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblIMU_IP = new System.Windows.Forms.Label();
            this.lblBtnMachine = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblGPSIP = new System.Windows.Forms.Label();
            this.lblSteerIP = new System.Windows.Forms.Label();
            this.lblBtnSteer = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblMachineIP = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblNewSubnet = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnNetworkCPL = new System.Windows.Forms.Button();
            this.btnAutoSet = new System.Windows.Forms.Button();
            this.btnSendSubnet = new System.Windows.Forms.Button();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.pboxSendSteer = new System.Windows.Forms.PictureBox();
            this.btnSerialMonitor = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudFirstIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecndIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThirdIP)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSendSteer)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(485, 543);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 23);
            this.label6.TabIndex = 144;
            this.label6.Text = "Current Subnet";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNetworkHelp
            // 
            this.lblNetworkHelp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNetworkHelp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNetworkHelp.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkHelp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNetworkHelp.Location = new System.Drawing.Point(408, 493);
            this.lblNetworkHelp.Name = "lblNetworkHelp";
            this.lblNetworkHelp.Size = new System.Drawing.Size(279, 46);
            this.lblNetworkHelp.TabIndex = 143;
            this.lblNetworkHelp.Text = "192 . 168 . 123  .  x";
            this.lblNetworkHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(434, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 23);
            this.label1.TabIndex = 147;
            this.label1.Text = "Enter New Subnet Address";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudFirstIP
            // 
            this.nudFirstIP.BackColor = System.Drawing.Color.AliceBlue;
            this.nudFirstIP.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFirstIP.Location = new System.Drawing.Point(372, 378);
            this.nudFirstIP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudFirstIP.Name = "nudFirstIP";
            this.nudFirstIP.Size = new System.Drawing.Size(102, 40);
            this.nudFirstIP.TabIndex = 148;
            this.nudFirstIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudFirstIP.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudFirstIP.Value = new decimal(new int[] {
            192,
            0,
            0,
            0});
            this.nudFirstIP.Click += new System.EventHandler(this.nudFirstIP_Click);
            // 
            // nudSecndIP
            // 
            this.nudSecndIP.BackColor = System.Drawing.Color.AliceBlue;
            this.nudSecndIP.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSecndIP.Location = new System.Drawing.Point(489, 378);
            this.nudSecndIP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSecndIP.Name = "nudSecndIP";
            this.nudSecndIP.Size = new System.Drawing.Size(102, 40);
            this.nudSecndIP.TabIndex = 149;
            this.nudSecndIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSecndIP.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudSecndIP.Value = new decimal(new int[] {
            168,
            0,
            0,
            0});
            this.nudSecndIP.Click += new System.EventHandler(this.nudFirstIP_Click);
            // 
            // nudThirdIP
            // 
            this.nudThirdIP.BackColor = System.Drawing.Color.AliceBlue;
            this.nudThirdIP.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudThirdIP.Location = new System.Drawing.Point(606, 378);
            this.nudThirdIP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudThirdIP.Name = "nudThirdIP";
            this.nudThirdIP.Size = new System.Drawing.Size(102, 40);
            this.nudThirdIP.TabIndex = 150;
            this.nudThirdIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudThirdIP.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudThirdIP.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudThirdIP.Click += new System.EventHandler(this.nudFirstIP_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(472, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 35);
            this.label2.TabIndex = 152;
            this.label2.Text = ".";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(589, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 35);
            this.label3.TabIndex = 153;
            this.label3.Text = ".";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(783, 421);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 23);
            this.label8.TabIndex = 157;
            this.label8.Text = "Set";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(337, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 23);
            this.label7.TabIndex = 161;
            this.label7.Text = "Module Scan";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tboxNets
            // 
            this.tboxNets.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxNets.Location = new System.Drawing.Point(16, 45);
            this.tboxNets.Multiline = true;
            this.tboxNets.Name = "tboxNets";
            this.tboxNets.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tboxNets.Size = new System.Drawing.Size(261, 468);
            this.tboxNets.TabIndex = 162;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 23);
            this.label4.TabIndex = 163;
            this.label4.Text = "Hostname:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHostname
            // 
            this.lblHostname.AutoSize = true;
            this.lblHostname.BackColor = System.Drawing.Color.White;
            this.lblHostname.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostname.Location = new System.Drawing.Point(112, 13);
            this.lblHostname.Name = "lblHostname";
            this.lblHostname.Size = new System.Drawing.Size(94, 23);
            this.lblHostname.TabIndex = 165;
            this.lblHostname.Text = "Hostname";
            this.lblHostname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoAdapter
            // 
            this.lblNoAdapter.AutoSize = true;
            this.lblNoAdapter.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoAdapter.ForeColor = System.Drawing.Color.Red;
            this.lblNoAdapter.Location = new System.Drawing.Point(398, 462);
            this.lblNoAdapter.Name = "lblNoAdapter";
            this.lblNoAdapter.Size = new System.Drawing.Size(298, 25);
            this.lblNoAdapter.TabIndex = 166;
            this.lblNoAdapter.Text = "No Adapter For This Subnet";
            this.lblNoAdapter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxUp
            // 
            this.cboxUp.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxUp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxUp.Checked = true;
            this.cboxUp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxUp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.cboxUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxUp.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxUp.Location = new System.Drawing.Point(78, 520);
            this.cboxUp.Name = "cboxUp";
            this.cboxUp.Size = new System.Drawing.Size(171, 50);
            this.cboxUp.TabIndex = 168;
            this.cboxUp.Text = "Up";
            this.cboxUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxUp.UseVisualStyleBackColor = true;
            this.cboxUp.Click += new System.EventHandler(this.cboxUp_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(583, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 512;
            this.label5.Text = "Fill In";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 534);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 23);
            this.label9.TabIndex = 513;
            this.label9.Text = "Filter";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubTimer
            // 
            this.lblSubTimer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTimer.Location = new System.Drawing.Point(362, 314);
            this.lblSubTimer.Name = "lblSubTimer";
            this.lblSubTimer.Size = new System.Drawing.Size(100, 23);
            this.lblSubTimer.TabIndex = 514;
            this.lblSubTimer.Text = "Scanning";
            this.lblSubTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(502, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 23);
            this.label11.TabIndex = 516;
            this.label11.Text = "IP Address";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(362, 249);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 23);
            this.label13.TabIndex = 518;
            this.label13.Text = "Subnet";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Controls.Add(this.lblBtnIMU, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBtnGPS, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblIMU_IP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBtnMachine, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblGPSIP, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSteerIP, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBtnSteer, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblMachineIP, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(341, 45);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(341, 177);
            this.tableLayoutPanel1.TabIndex = 519;
            // 
            // lblBtnIMU
            // 
            this.lblBtnIMU.AutoSize = true;
            this.lblBtnIMU.BackColor = System.Drawing.Color.White;
            this.lblBtnIMU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBtnIMU.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBtnIMU.Location = new System.Drawing.Point(316, 1);
            this.lblBtnIMU.Name = "lblBtnIMU";
            this.lblBtnIMU.Size = new System.Drawing.Size(21, 43);
            this.lblBtnIMU.TabIndex = 533;
            this.lblBtnIMU.Text = "-";
            this.lblBtnIMU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBtnGPS
            // 
            this.lblBtnGPS.AutoSize = true;
            this.lblBtnGPS.BackColor = System.Drawing.Color.White;
            this.lblBtnGPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBtnGPS.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBtnGPS.Location = new System.Drawing.Point(316, 89);
            this.lblBtnGPS.Name = "lblBtnGPS";
            this.lblBtnGPS.Size = new System.Drawing.Size(21, 43);
            this.lblBtnGPS.TabIndex = 532;
            this.lblBtnGPS.Text = "-";
            this.lblBtnGPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(4, 1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 43);
            this.label18.TabIndex = 524;
            this.label18.Text = "IMU";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIMU_IP
            // 
            this.lblIMU_IP.AutoSize = true;
            this.lblIMU_IP.BackColor = System.Drawing.Color.White;
            this.lblIMU_IP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIMU_IP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMU_IP.Location = new System.Drawing.Point(100, 1);
            this.lblIMU_IP.Name = "lblIMU_IP";
            this.lblIMU_IP.Size = new System.Drawing.Size(209, 43);
            this.lblIMU_IP.TabIndex = 526;
            this.lblIMU_IP.Text = "..";
            this.lblIMU_IP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBtnMachine
            // 
            this.lblBtnMachine.AutoSize = true;
            this.lblBtnMachine.BackColor = System.Drawing.Color.White;
            this.lblBtnMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBtnMachine.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBtnMachine.Location = new System.Drawing.Point(316, 133);
            this.lblBtnMachine.Name = "lblBtnMachine";
            this.lblBtnMachine.Size = new System.Drawing.Size(21, 43);
            this.lblBtnMachine.TabIndex = 531;
            this.lblBtnMachine.Text = "-";
            this.lblBtnMachine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(4, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 43);
            this.label15.TabIndex = 521;
            this.label15.Text = "Steer";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGPSIP
            // 
            this.lblGPSIP.AutoSize = true;
            this.lblGPSIP.BackColor = System.Drawing.Color.White;
            this.lblGPSIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGPSIP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPSIP.Location = new System.Drawing.Point(100, 89);
            this.lblGPSIP.Name = "lblGPSIP";
            this.lblGPSIP.Size = new System.Drawing.Size(209, 43);
            this.lblGPSIP.TabIndex = 530;
            this.lblGPSIP.Text = "..";
            this.lblGPSIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSteerIP
            // 
            this.lblSteerIP.AutoSize = true;
            this.lblSteerIP.BackColor = System.Drawing.Color.White;
            this.lblSteerIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSteerIP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerIP.Location = new System.Drawing.Point(100, 45);
            this.lblSteerIP.Name = "lblSteerIP";
            this.lblSteerIP.Size = new System.Drawing.Size(209, 43);
            this.lblSteerIP.TabIndex = 526;
            this.lblSteerIP.Text = "..";
            this.lblSteerIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBtnSteer
            // 
            this.lblBtnSteer.AutoSize = true;
            this.lblBtnSteer.BackColor = System.Drawing.Color.White;
            this.lblBtnSteer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBtnSteer.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBtnSteer.Location = new System.Drawing.Point(316, 45);
            this.lblBtnSteer.Name = "lblBtnSteer";
            this.lblBtnSteer.Size = new System.Drawing.Size(21, 43);
            this.lblBtnSteer.TabIndex = 521;
            this.lblBtnSteer.Text = "-";
            this.lblBtnSteer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(4, 133);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 43);
            this.label16.TabIndex = 522;
            this.label16.Text = "Machine";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMachineIP
            // 
            this.lblMachineIP.AutoSize = true;
            this.lblMachineIP.BackColor = System.Drawing.Color.White;
            this.lblMachineIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMachineIP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMachineIP.Location = new System.Drawing.Point(100, 133);
            this.lblMachineIP.Name = "lblMachineIP";
            this.lblMachineIP.Size = new System.Drawing.Size(209, 43);
            this.lblMachineIP.TabIndex = 528;
            this.lblMachineIP.Text = "..";
            this.lblMachineIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(4, 89);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 43);
            this.label17.TabIndex = 523;
            this.label17.Text = "GPS";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNewSubnet
            // 
            this.lblNewSubnet.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNewSubnet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNewSubnet.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewSubnet.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNewSubnet.Location = new System.Drawing.Point(438, 235);
            this.lblNewSubnet.Name = "lblNewSubnet";
            this.lblNewSubnet.Size = new System.Drawing.Size(221, 46);
            this.lblNewSubnet.TabIndex = 520;
            this.lblNewSubnet.Text = "192 . 168 . 123";
            this.lblNewSubnet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHelp
            // 
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnHelp.Image = global::AgIO.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(759, 12);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(76, 65);
            this.btnHelp.TabIndex = 521;
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnNetworkCPL
            // 
            this.btnNetworkCPL.BackgroundImage = global::AgIO.Properties.Resources.DeviceManager;
            this.btnNetworkCPL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNetworkCPL.FlatAppearance.BorderSize = 0;
            this.btnNetworkCPL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNetworkCPL.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNetworkCPL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNetworkCPL.Location = new System.Drawing.Point(303, 511);
            this.btnNetworkCPL.Name = "btnNetworkCPL";
            this.btnNetworkCPL.Size = new System.Drawing.Size(76, 65);
            this.btnNetworkCPL.TabIndex = 521;
            this.btnNetworkCPL.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNetworkCPL.UseVisualStyleBackColor = true;
            this.btnNetworkCPL.Click += new System.EventHandler(this.btnNetworkCPL_Click);
            // 
            // btnAutoSet
            // 
            this.btnAutoSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAutoSet.Enabled = false;
            this.btnAutoSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoSet.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSet.Image = global::AgIO.Properties.Resources.DnArrow64;
            this.btnAutoSet.Location = new System.Drawing.Point(517, 296);
            this.btnAutoSet.Name = "btnAutoSet";
            this.btnAutoSet.Size = new System.Drawing.Size(60, 58);
            this.btnAutoSet.TabIndex = 511;
            this.btnAutoSet.UseVisualStyleBackColor = true;
            this.btnAutoSet.Click += new System.EventHandler(this.btnAutoSet_Click);
            // 
            // btnSendSubnet
            // 
            this.btnSendSubnet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSendSubnet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendSubnet.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendSubnet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSendSubnet.Image = global::AgIO.Properties.Resources.SubnetSend;
            this.btnSendSubnet.Location = new System.Drawing.Point(755, 339);
            this.btnSendSubnet.Name = "btnSendSubnet";
            this.btnSendSubnet.Size = new System.Drawing.Size(92, 79);
            this.btnSendSubnet.TabIndex = 151;
            this.btnSendSubnet.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSendSubnet.UseVisualStyleBackColor = true;
            this.btnSendSubnet.Click += new System.EventHandler(this.btnSendSubnet_Click);
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.FlatAppearance.BorderSize = 0;
            this.btnSerialCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialCancel.Image = global::AgIO.Properties.Resources.back_button;
            this.btnSerialCancel.Location = new System.Drawing.Point(757, 493);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(92, 79);
            this.btnSerialCancel.TabIndex = 71;
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            this.btnSerialCancel.Click += new System.EventHandler(this.btnSerialCancel_Click);
            // 
            // pboxSendSteer
            // 
            this.pboxSendSteer.BackgroundImage = global::AgIO.Properties.Resources.ConSt_Mandatory;
            this.pboxSendSteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pboxSendSteer.Location = new System.Drawing.Point(782, 299);
            this.pboxSendSteer.Name = "pboxSendSteer";
            this.pboxSendSteer.Size = new System.Drawing.Size(38, 39);
            this.pboxSendSteer.TabIndex = 510;
            this.pboxSendSteer.TabStop = false;
            this.pboxSendSteer.Visible = false;
            // 
            // btnSerialMonitor
            // 
            this.btnSerialMonitor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialMonitor.FlatAppearance.BorderSize = 0;
            this.btnSerialMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialMonitor.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialMonitor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSerialMonitor.Image = global::AgIO.Properties.Resources.SerialMonitor;
            this.btnSerialMonitor.Location = new System.Drawing.Point(761, 110);
            this.btnSerialMonitor.Name = "btnSerialMonitor";
            this.btnSerialMonitor.Size = new System.Drawing.Size(76, 65);
            this.btnSerialMonitor.TabIndex = 522;
            this.btnSerialMonitor.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSerialMonitor.UseVisualStyleBackColor = true;
            this.btnSerialMonitor.Click += new System.EventHandler(this.btnSerialMonitor_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(769, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 18);
            this.label10.TabIndex = 523;
            this.label10.Text = "Monitor";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormUDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 584);
            this.ControlBox = false;
            this.Controls.Add(this.btnSerialMonitor);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnNetworkCPL);
            this.Controls.Add(this.lblNewSubnet);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnAutoSet);
            this.Controls.Add(this.cboxUp);
            this.Controls.Add(this.lblNoAdapter);
            this.Controls.Add(this.lblHostname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tboxNets);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblNetworkHelp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSendSubnet);
            this.Controls.Add(this.nudThirdIP);
            this.Controls.Add(this.nudSecndIP);
            this.Controls.Add(this.nudFirstIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSerialCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSubTimer);
            this.Controls.Add(this.pboxSendSteer);
            this.Controls.Add(this.label10);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUDP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ethernet Configuration";
            this.Load += new System.EventHandler(this.FormUDp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudFirstIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecndIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThirdIP)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSendSteer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Label lblNetworkHelp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudFirstIP;
        private System.Windows.Forms.NumericUpDown nudSecndIP;
        private System.Windows.Forms.NumericUpDown nudThirdIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tboxNets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHostname;
        private System.Windows.Forms.Label lblNoAdapter;
        private System.Windows.Forms.CheckBox cboxUp;
        private System.Windows.Forms.Button btnAutoSet;
        private System.Windows.Forms.PictureBox pboxSendSteer;
        private System.Windows.Forms.Button btnSendSubnet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSubTimer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblSteerIP;
        private System.Windows.Forms.Label lblGPSIP;
        private System.Windows.Forms.Label lblMachineIP;
        private System.Windows.Forms.Label lblIMU_IP;
        private System.Windows.Forms.Label lblNewSubnet;
        private System.Windows.Forms.Label lblBtnIMU;
        private System.Windows.Forms.Label lblBtnGPS;
        private System.Windows.Forms.Label lblBtnMachine;
        private System.Windows.Forms.Label lblBtnSteer;
        private System.Windows.Forms.Button btnNetworkCPL;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnSerialMonitor;
        private System.Windows.Forms.Label label10;
    }
}