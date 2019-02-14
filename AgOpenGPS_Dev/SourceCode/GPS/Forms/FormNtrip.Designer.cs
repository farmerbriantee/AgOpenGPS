namespace AgOpenGPS
{
    partial class FormNtrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNtrip));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboxIsNTRIPOn = new System.Windows.Forms.CheckBox();
            this.tboxCasterIP = new System.Windows.Forms.TextBox();
            this.nudCasterPort = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tboxHostName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tboxThisIP = new System.Windows.Forms.TextBox();
            this.nudSendToUDPPort = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.btnSerialOK = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tboxUserName = new System.Windows.Forms.TextBox();
            this.tboxUserPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tboxMount = new System.Windows.Forms.TextBox();
            this.nudGGAInterval = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.tboxEnterURL = new System.Windows.Forms.TextBox();
            this.btnGetIP = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudLatitude = new System.Windows.Forms.NumericUpDown();
            this.nudLongitude = new System.Windows.Forms.NumericUpDown();
            this.tboxCurrentLat = new System.Windows.Forms.TextBox();
            this.tboxCurrentLon = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnGetSourceTable = new System.Windows.Forms.Button();
            this.btnSetManualPosition = new System.Windows.Forms.Button();
            this.cboxGGAManual = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCasterPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSendToUDPPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGGAInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLatitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitude)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboxIsNTRIPOn);
            this.groupBox2.Location = new System.Drawing.Point(580, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 76);
            this.groupBox2.TabIndex = 98;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Networking";
            // 
            // cboxIsNTRIPOn
            // 
            this.cboxIsNTRIPOn.AutoSize = true;
            this.cboxIsNTRIPOn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxIsNTRIPOn.Checked = true;
            this.cboxIsNTRIPOn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxIsNTRIPOn.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsNTRIPOn.Location = new System.Drawing.Point(21, 23);
            this.cboxIsNTRIPOn.Name = "cboxIsNTRIPOn";
            this.cboxIsNTRIPOn.Size = new System.Drawing.Size(161, 39);
            this.cboxIsNTRIPOn.TabIndex = 92;
            this.cboxIsNTRIPOn.Text = "NTRIP On";
            this.cboxIsNTRIPOn.UseVisualStyleBackColor = true;
            this.cboxIsNTRIPOn.CheckedChanged += new System.EventHandler(this.cboxIsNTRIPOn_CheckedChanged);
            // 
            // tboxCasterIP
            // 
            this.tboxCasterIP.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxCasterIP.Location = new System.Drawing.Point(51, 188);
            this.tboxCasterIP.Name = "tboxCasterIP";
            this.tboxCasterIP.Size = new System.Drawing.Size(157, 30);
            this.tboxCasterIP.TabIndex = 79;
            this.tboxCasterIP.Text = "192.168.188.255";
            this.tboxCasterIP.Validating += new System.ComponentModel.CancelEventHandler(this.tboxCasterIP_Validating);
            // 
            // nudCasterPort
            // 
            this.nudCasterPort.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCasterPort.Location = new System.Drawing.Point(51, 232);
            this.nudCasterPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudCasterPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.nudCasterPort.Name = "nudCasterPort";
            this.nudCasterPort.Size = new System.Drawing.Size(122, 43);
            this.nudCasterPort.TabIndex = 80;
            this.nudCasterPort.Value = new decimal(new int[] {
            8888,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 23);
            this.label6.TabIndex = 81;
            this.label6.Text = "Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 23);
            this.label5.TabIndex = 82;
            this.label5.Text = "IP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 23);
            this.label4.TabIndex = 83;
            this.label4.Text = "Broadcaster";
            // 
            // tboxHostName
            // 
            this.tboxHostName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxHostName.Location = new System.Drawing.Point(40, 3);
            this.tboxHostName.Name = "tboxHostName";
            this.tboxHostName.ReadOnly = true;
            this.tboxHostName.Size = new System.Drawing.Size(157, 23);
            this.tboxHostName.TabIndex = 86;
            this.tboxHostName.Text = "HostName";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(1, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 16);
            this.label14.TabIndex = 85;
            this.label14.Text = "Host";
            // 
            // tboxThisIP
            // 
            this.tboxThisIP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxThisIP.Location = new System.Drawing.Point(40, 31);
            this.tboxThisIP.Name = "tboxThisIP";
            this.tboxThisIP.ReadOnly = true;
            this.tboxThisIP.Size = new System.Drawing.Size(157, 23);
            this.tboxThisIP.TabIndex = 73;
            this.tboxThisIP.Text = "192.168.1.255";
            // 
            // nudSendToUDPPort
            // 
            this.nudSendToUDPPort.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSendToUDPPort.Location = new System.Drawing.Point(602, 59);
            this.nudSendToUDPPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudSendToUDPPort.Name = "nudSendToUDPPort";
            this.nudSendToUDPPort.Size = new System.Drawing.Size(121, 43);
            this.nudSendToUDPPort.TabIndex = 74;
            this.nudSendToUDPPort.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudSendToUDPPort.ValueChanged += new System.EventHandler(this.nudSendToUDPPort_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 16);
            this.label10.TabIndex = 76;
            this.label10.Text = "IP";
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnSerialCancel.Location = new System.Drawing.Point(690, 312);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(88, 76);
            this.btnSerialCancel.TabIndex = 95;
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            // 
            // btnSerialOK
            // 
            this.btnSerialOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSerialOK.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSerialOK.Image = ((System.Drawing.Image)(resources.GetObject("btnSerialOK.Image")));
            this.btnSerialOK.Location = new System.Drawing.Point(640, 397);
            this.btnSerialOK.Name = "btnSerialOK";
            this.btnSerialOK.Size = new System.Drawing.Size(138, 76);
            this.btnSerialOK.TabIndex = 94;
            this.btnSerialOK.Text = "Save";
            this.btnSerialOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSerialOK.UseVisualStyleBackColor = true;
            this.btnSerialOK.Click += new System.EventHandler(this.btnSerialOK_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(598, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 23);
            this.label7.TabIndex = 99;
            this.label7.Text = "To UDP Port";
            // 
            // tboxUserName
            // 
            this.tboxUserName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxUserName.Location = new System.Drawing.Point(295, 27);
            this.tboxUserName.Name = "tboxUserName";
            this.tboxUserName.Size = new System.Drawing.Size(226, 30);
            this.tboxUserName.TabIndex = 100;
            // 
            // tboxUserPassword
            // 
            this.tboxUserPassword.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxUserPassword.Location = new System.Drawing.Point(295, 86);
            this.tboxUserPassword.Name = "tboxUserPassword";
            this.tboxUserPassword.Size = new System.Drawing.Size(226, 30);
            this.tboxUserPassword.TabIndex = 101;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(293, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 102;
            this.label3.Text = "Username";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(293, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 19);
            this.label12.TabIndex = 103;
            this.label12.Text = "Password";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 294);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 19);
            this.label13.TabIndex = 105;
            this.label13.Text = "Mount";
            // 
            // tboxMount
            // 
            this.tboxMount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxMount.Location = new System.Drawing.Point(11, 316);
            this.tboxMount.Name = "tboxMount";
            this.tboxMount.Size = new System.Drawing.Size(223, 30);
            this.tboxMount.TabIndex = 104;
            // 
            // nudGGAInterval
            // 
            this.nudGGAInterval.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudGGAInterval.Location = new System.Drawing.Point(66, 398);
            this.nudGGAInterval.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudGGAInterval.Name = "nudGGAInterval";
            this.nudGGAInterval.Size = new System.Drawing.Size(133, 43);
            this.nudGGAInterval.TabIndex = 106;
            this.nudGGAInterval.Value = new decimal(new int[] {
            333,
            0,
            0,
            0});
            this.nudGGAInterval.ValueChanged += new System.EventHandler(this.nudGGAInterval_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(58, 372);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(172, 23);
            this.label15.TabIndex = 107;
            this.label15.Text = "GGA Interval (secs)";
            // 
            // tboxEnterURL
            // 
            this.tboxEnterURL.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxEnterURL.Location = new System.Drawing.Point(11, 96);
            this.tboxEnterURL.Name = "tboxEnterURL";
            this.tboxEnterURL.Size = new System.Drawing.Size(223, 26);
            this.tboxEnterURL.TabIndex = 108;
            this.tboxEnterURL.Text = "RTK2Go.com";
            // 
            // btnGetIP
            // 
            this.btnGetIP.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetIP.Location = new System.Drawing.Point(11, 136);
            this.btnGetIP.Name = "btnGetIP";
            this.btnGetIP.Size = new System.Drawing.Size(93, 30);
            this.btnGetIP.TabIndex = 109;
            this.btnGetIP.Text = "Get IP";
            this.btnGetIP.UseVisualStyleBackColor = true;
            this.btnGetIP.Click += new System.EventHandler(this.btnGetIP_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(282, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 23);
            this.label2.TabIndex = 115;
            this.label2.Text = "Lat:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(277, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 23);
            this.label8.TabIndex = 116;
            this.label8.Text = "Lon:";
            // 
            // nudLatitude
            // 
            this.nudLatitude.DecimalPlaces = 7;
            this.nudLatitude.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLatitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudLatitude.Location = new System.Drawing.Point(319, 156);
            this.nudLatitude.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudLatitude.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.nudLatitude.Name = "nudLatitude";
            this.nudLatitude.Size = new System.Drawing.Size(192, 40);
            this.nudLatitude.TabIndex = 118;
            this.nudLatitude.Value = new decimal(new int[] {
            881234567,
            0,
            0,
            -2147024896});
            // 
            // nudLongitude
            // 
            this.nudLongitude.DecimalPlaces = 7;
            this.nudLongitude.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLongitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudLongitude.Location = new System.Drawing.Point(319, 209);
            this.nudLongitude.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudLongitude.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nudLongitude.Name = "nudLongitude";
            this.nudLongitude.Size = new System.Drawing.Size(202, 40);
            this.nudLongitude.TabIndex = 117;
            this.nudLongitude.Value = new decimal(new int[] {
            1781234567,
            0,
            0,
            -2147024896});
            // 
            // tboxCurrentLat
            // 
            this.tboxCurrentLat.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxCurrentLat.Location = new System.Drawing.Point(368, 350);
            this.tboxCurrentLat.Name = "tboxCurrentLat";
            this.tboxCurrentLat.ReadOnly = true;
            this.tboxCurrentLat.Size = new System.Drawing.Size(143, 27);
            this.tboxCurrentLat.TabIndex = 119;
            this.tboxCurrentLat.Text = "53.2398652";
            // 
            // tboxCurrentLon
            // 
            this.tboxCurrentLon.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxCurrentLon.Location = new System.Drawing.Point(368, 392);
            this.tboxCurrentLon.Name = "tboxCurrentLon";
            this.tboxCurrentLon.ReadOnly = true;
            this.tboxCurrentLon.Size = new System.Drawing.Size(143, 27);
            this.tboxCurrentLon.TabIndex = 120;
            this.tboxCurrentLon.Text = "-111.1234567";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(365, 331);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 122;
            this.label9.Text = "GPS Fix:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(332, 356);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 16);
            this.label11.TabIndex = 123;
            this.label11.Text = "Lat:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(329, 398);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 16);
            this.label16.TabIndex = 124;
            this.label16.Text = "Lon:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(316, 137);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 16);
            this.label17.TabIndex = 125;
            this.label17.Text = "Manual Fix:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(598, 105);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(166, 23);
            this.label18.TabIndex = 126;
            this.label18.Text = "*Set to 0 for Serial";
            // 
            // btnGetSourceTable
            // 
            this.btnGetSourceTable.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetSourceTable.Location = new System.Drawing.Point(141, 136);
            this.btnGetSourceTable.Name = "btnGetSourceTable";
            this.btnGetSourceTable.Size = new System.Drawing.Size(93, 30);
            this.btnGetSourceTable.TabIndex = 127;
            this.btnGetSourceTable.Text = "Source";
            this.btnGetSourceTable.UseVisualStyleBackColor = true;
            this.btnGetSourceTable.Click += new System.EventHandler(this.btnGetSourceTable_Click);
            // 
            // btnSetManualPosition
            // 
            this.btnSetManualPosition.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetManualPosition.Location = new System.Drawing.Point(368, 425);
            this.btnSetManualPosition.Name = "btnSetManualPosition";
            this.btnSetManualPosition.Size = new System.Drawing.Size(143, 29);
            this.btnSetManualPosition.TabIndex = 121;
            this.btnSetManualPosition.Text = "Send To Manual";
            this.btnSetManualPosition.UseVisualStyleBackColor = true;
            this.btnSetManualPosition.Click += new System.EventHandler(this.btnSetManualPosition_Click);
            // 
            // cboxGGAManual
            // 
            this.cboxGGAManual.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboxGGAManual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxGGAManual.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxGGAManual.FormattingEnabled = true;
            this.cboxGGAManual.Items.AddRange(new object[] {
            "Use Manual Fix",
            "Use GPS Fix"});
            this.cboxGGAManual.Location = new System.Drawing.Point(319, 275);
            this.cboxGGAManual.Name = "cboxGGAManual";
            this.cboxGGAManual.Size = new System.Drawing.Size(192, 33);
            this.cboxGGAManual.TabIndex = 128;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(593, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 23);
            this.label1.TabIndex = 129;
            this.label1.Text = "*Restart Required";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(66, 450);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 23);
            this.label19.TabIndex = 131;
            this.label19.Text = "0 = Off";
            // 
            // FormNtrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 485);
            this.ControlBox = false;
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxGGAManual);
            this.Controls.Add(this.btnGetSourceTable);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSetManualPosition);
            this.Controls.Add(this.tboxCurrentLon);
            this.Controls.Add(this.tboxCurrentLat);
            this.Controls.Add(this.nudLatitude);
            this.Controls.Add(this.nudLongitude);
            this.Controls.Add(this.btnGetIP);
            this.Controls.Add(this.tboxEnterURL);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.nudGGAInterval);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tboxMount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tboxUserPassword);
            this.Controls.Add(this.tboxUserName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tboxCasterIP);
            this.Controls.Add(this.nudCasterPort);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tboxHostName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tboxThisIP);
            this.Controls.Add(this.btnSerialCancel);
            this.Controls.Add(this.nudSendToUDPPort);
            this.Controls.Add(this.btnSerialOK);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNtrip";
            this.Text = "NTRIP Client Settings";
            this.Load += new System.EventHandler(this.FormNtrip_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCasterPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSendToUDPPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGGAInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLatitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitude)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cboxIsNTRIPOn;
        private System.Windows.Forms.TextBox tboxCasterIP;
        private System.Windows.Forms.NumericUpDown nudCasterPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tboxHostName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tboxThisIP;
        private System.Windows.Forms.NumericUpDown nudSendToUDPPort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Button btnSerialOK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tboxUserName;
        private System.Windows.Forms.TextBox tboxUserPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tboxMount;
        private System.Windows.Forms.NumericUpDown nudGGAInterval;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tboxEnterURL;
        private System.Windows.Forms.Button btnGetIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudLatitude;
        private System.Windows.Forms.NumericUpDown nudLongitude;
        private System.Windows.Forms.TextBox tboxCurrentLat;
        private System.Windows.Forms.TextBox tboxCurrentLon;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnGetSourceTable;
        private System.Windows.Forms.Button btnSetManualPosition;
        private System.Windows.Forms.ComboBox cboxGGAManual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
    }
}