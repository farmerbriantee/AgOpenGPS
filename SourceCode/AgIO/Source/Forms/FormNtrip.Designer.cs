namespace AgIO
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
            this.tboxCasterIP = new System.Windows.Forms.TextBox();
            this.nudCasterPort = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tboxHostName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.nudSendToUDPPort = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
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
            this.btnGetSourceTable = new System.Windows.Forms.Button();
            this.btnSetManualPosition = new System.Windows.Forms.Button();
            this.cboxGGAManual = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.checkBoxusetcp = new System.Windows.Forms.CheckBox();
            this.btnPassUsername = new System.Windows.Forms.Button();
            this.btnPassPassword = new System.Windows.Forms.Button();
            this.cboxHTTP = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listboxIP = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxToSerial = new System.Windows.Forms.CheckBox();
            this.cboxToUDP = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboboxPacketSize = new System.Windows.Forms.ComboBox();
            this.labelRtcmPort = new System.Windows.Forms.Label();
            this.cboxIsNTRIPOn = new System.Windows.Forms.CheckBox();
            this.btnSerialOK = new System.Windows.Forms.Button();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCasterPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSendToUDPPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGGAInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLatitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitude)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tboxCasterIP
            // 
            this.tboxCasterIP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxCasterIP.Location = new System.Drawing.Point(92, 446);
            this.tboxCasterIP.Name = "tboxCasterIP";
            this.tboxCasterIP.ReadOnly = true;
            this.tboxCasterIP.Size = new System.Drawing.Size(170, 33);
            this.tboxCasterIP.TabIndex = 79;
            this.tboxCasterIP.Text = "192.168.188.255";
            this.tboxCasterIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxCasterIP.Validating += new System.ComponentModel.CancelEventHandler(this.tboxCasterIP_Validating);
            // 
            // nudCasterPort
            // 
            this.nudCasterPort.BackColor = System.Drawing.Color.AliceBlue;
            this.nudCasterPort.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCasterPort.Location = new System.Drawing.Point(494, 411);
            this.nudCasterPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudCasterPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCasterPort.Name = "nudCasterPort";
            this.nudCasterPort.Size = new System.Drawing.Size(119, 40);
            this.nudCasterPort.TabIndex = 80;
            this.nudCasterPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCasterPort.Value = new decimal(new int[] {
            8888,
            0,
            0,
            0});
            this.nudCasterPort.Enter += new System.EventHandler(this.NudCasterPort_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 449);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 25);
            this.label5.TabIndex = 82;
            this.label5.Text = "IP:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(297, 56);
            this.label4.TabIndex = 83;
            this.label4.Text = "Enter Broadcaster URL or IP ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tboxHostName
            // 
            this.tboxHostName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxHostName.Location = new System.Drawing.Point(91, 32);
            this.tboxHostName.Name = "tboxHostName";
            this.tboxHostName.ReadOnly = true;
            this.tboxHostName.Size = new System.Drawing.Size(221, 30);
            this.tboxHostName.TabIndex = 86;
            this.tboxHostName.Text = "HostName";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(38, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 23);
            this.label14.TabIndex = 85;
            this.label14.Text = "Host";
            // 
            // nudSendToUDPPort
            // 
            this.nudSendToUDPPort.BackColor = System.Drawing.Color.AliceBlue;
            this.nudSendToUDPPort.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSendToUDPPort.Location = new System.Drawing.Point(569, 200);
            this.nudSendToUDPPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudSendToUDPPort.Name = "nudSendToUDPPort";
            this.nudSendToUDPPort.Size = new System.Drawing.Size(141, 46);
            this.nudSendToUDPPort.TabIndex = 74;
            this.nudSendToUDPPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSendToUDPPort.Value = new decimal(new int[] {
            36666,
            0,
            0,
            0});
            this.nudSendToUDPPort.Enter += new System.EventHandler(this.NudSendToUDPPort_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(53, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 23);
            this.label10.TabIndex = 76;
            this.label10.Text = "IP";
            // 
            // tboxUserName
            // 
            this.tboxUserName.BackColor = System.Drawing.Color.AliceBlue;
            this.tboxUserName.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxUserName.Location = new System.Drawing.Point(389, 63);
            this.tboxUserName.Name = "tboxUserName";
            this.tboxUserName.PasswordChar = '*';
            this.tboxUserName.Size = new System.Drawing.Size(252, 33);
            this.tboxUserName.TabIndex = 100;
            this.tboxUserName.Click += new System.EventHandler(this.tboxUserName_Click);
            // 
            // tboxUserPassword
            // 
            this.tboxUserPassword.BackColor = System.Drawing.Color.AliceBlue;
            this.tboxUserPassword.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxUserPassword.Location = new System.Drawing.Point(389, 134);
            this.tboxUserPassword.Name = "tboxUserPassword";
            this.tboxUserPassword.PasswordChar = '*';
            this.tboxUserPassword.Size = new System.Drawing.Size(252, 33);
            this.tboxUserPassword.TabIndex = 101;
            this.tboxUserPassword.Click += new System.EventHandler(this.tboxUserPassword_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(393, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 102;
            this.label3.Text = "Username";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(393, 106);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 25);
            this.label12.TabIndex = 103;
            this.label12.Text = "Password";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(394, 291);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 25);
            this.label13.TabIndex = 105;
            this.label13.Text = "Mount";
            // 
            // tboxMount
            // 
            this.tboxMount.BackColor = System.Drawing.Color.AliceBlue;
            this.tboxMount.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxMount.Location = new System.Drawing.Point(380, 322);
            this.tboxMount.Name = "tboxMount";
            this.tboxMount.Size = new System.Drawing.Size(341, 33);
            this.tboxMount.TabIndex = 104;
            this.tboxMount.Click += new System.EventHandler(this.tboxMount_Click);
            // 
            // nudGGAInterval
            // 
            this.nudGGAInterval.BackColor = System.Drawing.Color.AliceBlue;
            this.nudGGAInterval.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudGGAInterval.Location = new System.Drawing.Point(445, 373);
            this.nudGGAInterval.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudGGAInterval.Name = "nudGGAInterval";
            this.nudGGAInterval.Size = new System.Drawing.Size(113, 40);
            this.nudGGAInterval.TabIndex = 106;
            this.nudGGAInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudGGAInterval.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudGGAInterval.Enter += new System.EventHandler(this.NudGGAInterval_Enter);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(411, 333);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(196, 33);
            this.label15.TabIndex = 107;
            this.label15.Text = "GGA Interval (secs)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tboxEnterURL
            // 
            this.tboxEnterURL.BackColor = System.Drawing.Color.AliceBlue;
            this.tboxEnterURL.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxEnterURL.Location = new System.Drawing.Point(21, 322);
            this.tboxEnterURL.Name = "tboxEnterURL";
            this.tboxEnterURL.Size = new System.Drawing.Size(341, 33);
            this.tboxEnterURL.TabIndex = 108;
            this.tboxEnterURL.Text = "RTK2Go.com";
            this.tboxEnterURL.Click += new System.EventHandler(this.tboxEnterURL_Click);
            // 
            // btnGetIP
            // 
            this.btnGetIP.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnGetIP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetIP.Location = new System.Drawing.Point(100, 377);
            this.btnGetIP.Name = "btnGetIP";
            this.btnGetIP.Size = new System.Drawing.Size(157, 40);
            this.btnGetIP.TabIndex = 109;
            this.btnGetIP.Text = "Verify";
            this.btnGetIP.UseVisualStyleBackColor = false;
            this.btnGetIP.Click += new System.EventHandler(this.btnGetIP_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 23);
            this.label2.TabIndex = 115;
            this.label2.Text = "Lat:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 23);
            this.label8.TabIndex = 116;
            this.label8.Text = "Lon:";
            // 
            // nudLatitude
            // 
            this.nudLatitude.BackColor = System.Drawing.Color.AliceBlue;
            this.nudLatitude.DecimalPlaces = 7;
            this.nudLatitude.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLatitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudLatitude.Location = new System.Drawing.Point(76, 82);
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
            this.nudLatitude.Size = new System.Drawing.Size(224, 33);
            this.nudLatitude.TabIndex = 118;
            this.nudLatitude.Value = new decimal(new int[] {
            881234567,
            0,
            0,
            -2147024896});
            this.nudLatitude.Enter += new System.EventHandler(this.NudLatitude_Enter);
            // 
            // nudLongitude
            // 
            this.nudLongitude.BackColor = System.Drawing.Color.AliceBlue;
            this.nudLongitude.DecimalPlaces = 7;
            this.nudLongitude.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLongitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudLongitude.Location = new System.Drawing.Point(76, 137);
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
            this.nudLongitude.Size = new System.Drawing.Size(224, 33);
            this.nudLongitude.TabIndex = 117;
            this.nudLongitude.Value = new decimal(new int[] {
            1781234567,
            0,
            0,
            -2147024896});
            this.nudLongitude.Enter += new System.EventHandler(this.NudLongitude_Enter);
            // 
            // tboxCurrentLat
            // 
            this.tboxCurrentLat.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxCurrentLat.Location = new System.Drawing.Point(75, 310);
            this.tboxCurrentLat.Name = "tboxCurrentLat";
            this.tboxCurrentLat.ReadOnly = true;
            this.tboxCurrentLat.Size = new System.Drawing.Size(224, 33);
            this.tboxCurrentLat.TabIndex = 119;
            this.tboxCurrentLat.Text = "53.2398652";
            // 
            // tboxCurrentLon
            // 
            this.tboxCurrentLon.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxCurrentLon.Location = new System.Drawing.Point(75, 369);
            this.tboxCurrentLon.Name = "tboxCurrentLon";
            this.tboxCurrentLon.ReadOnly = true;
            this.tboxCurrentLon.Size = new System.Drawing.Size(224, 33);
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
            this.label9.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(319, 32);
            this.label9.TabIndex = 122;
            this.label9.Text = "Current GPS Fix:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(27, 314);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 23);
            this.label11.TabIndex = 123;
            this.label11.Text = "Lat:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(23, 373);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 23);
            this.label16.TabIndex = 124;
            this.label16.Text = "Lon:";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(45, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(269, 30);
            this.label17.TabIndex = 125;
            this.label17.Text = "Manual Fix:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnGetSourceTable
            // 
            this.btnGetSourceTable.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnGetSourceTable.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetSourceTable.Location = new System.Drawing.Point(486, 252);
            this.btnGetSourceTable.Name = "btnGetSourceTable";
            this.btnGetSourceTable.Size = new System.Drawing.Size(235, 37);
            this.btnGetSourceTable.TabIndex = 127;
            this.btnGetSourceTable.Text = "Get Source Table";
            this.btnGetSourceTable.UseVisualStyleBackColor = false;
            this.btnGetSourceTable.Click += new System.EventHandler(this.btnGetSourceTable_Click);
            // 
            // btnSetManualPosition
            // 
            this.btnSetManualPosition.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetManualPosition.Location = new System.Drawing.Point(75, 430);
            this.btnSetManualPosition.Name = "btnSetManualPosition";
            this.btnSetManualPosition.Size = new System.Drawing.Size(224, 33);
            this.btnSetManualPosition.TabIndex = 121;
            this.btnSetManualPosition.Text = "Send To Manual Fix";
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
            this.cboxGGAManual.Location = new System.Drawing.Point(76, 190);
            this.cboxGGAManual.Name = "cboxGGAManual";
            this.cboxGGAManual.Size = new System.Drawing.Size(192, 33);
            this.cboxGGAManual.TabIndex = 128;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(564, 381);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(81, 25);
            this.label19.TabIndex = 131;
            this.label19.Text = "0 = Off";
            // 
            // checkBoxusetcp
            // 
            this.checkBoxusetcp.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxusetcp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.checkBoxusetcp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxusetcp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxusetcp.Location = new System.Drawing.Point(45, 139);
            this.checkBoxusetcp.Name = "checkBoxusetcp";
            this.checkBoxusetcp.Size = new System.Drawing.Size(129, 41);
            this.checkBoxusetcp.TabIndex = 132;
            this.checkBoxusetcp.Text = "Only TCP:Port";
            this.checkBoxusetcp.UseVisualStyleBackColor = true;
            // 
            // btnPassUsername
            // 
            this.btnPassUsername.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPassUsername.Location = new System.Drawing.Point(647, 60);
            this.btnPassUsername.Name = "btnPassUsername";
            this.btnPassUsername.Size = new System.Drawing.Size(63, 40);
            this.btnPassUsername.TabIndex = 133;
            this.btnPassUsername.Text = "(o)";
            this.btnPassUsername.UseVisualStyleBackColor = true;
            this.btnPassUsername.Click += new System.EventHandler(this.btnPassUsername_Click);
            // 
            // btnPassPassword
            // 
            this.btnPassPassword.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPassPassword.Location = new System.Drawing.Point(647, 131);
            this.btnPassPassword.Name = "btnPassPassword";
            this.btnPassPassword.Size = new System.Drawing.Size(63, 40);
            this.btnPassPassword.TabIndex = 134;
            this.btnPassPassword.Text = "(o)";
            this.btnPassPassword.UseVisualStyleBackColor = true;
            this.btnPassPassword.Click += new System.EventHandler(this.btnPassPassword_Click);
            // 
            // cboxHTTP
            // 
            this.cboxHTTP.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboxHTTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxHTTP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxHTTP.FormattingEnabled = true;
            this.cboxHTTP.Items.AddRange(new object[] {
            "1.0",
            "1.1"});
            this.cboxHTTP.Location = new System.Drawing.Point(68, 72);
            this.cboxHTTP.Name = "cboxHTTP";
            this.cboxHTTP.Size = new System.Drawing.Size(80, 33);
            this.cboxHTTP.TabIndex = 135;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(77, 46);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 23);
            this.label20.TabIndex = 136;
            this.label20.Text = "HTTP:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 40);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(741, 563);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 137;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Azure;
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.listboxIP);
            this.tabPage1.Controls.Add(this.tboxUserPassword);
            this.tabPage1.Controls.Add(this.btnGetSourceTable);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.tboxUserName);
            this.tabPage1.Controls.Add(this.tboxMount);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnPassPassword);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.btnPassUsername);
            this.tabPage1.Controls.Add(this.btnGetIP);
            this.tabPage1.Controls.Add(this.tboxCasterIP);
            this.tabPage1.Controls.Add(this.tboxEnterURL);
            this.tabPage1.Controls.Add(this.nudCasterPort);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.tboxHostName);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(733, 515);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Source";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(489, 454);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 23);
            this.label6.TabIndex = 146;
            this.label6.Text = "Default: 2101";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(494, 379);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 25);
            this.label7.TabIndex = 145;
            this.label7.Text = "Caster Port:";
            // 
            // listboxIP
            // 
            this.listboxIP.Enabled = false;
            this.listboxIP.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listboxIP.FormattingEnabled = true;
            this.listboxIP.ItemHeight = 29;
            this.listboxIP.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.listboxIP.Location = new System.Drawing.Point(91, 94);
            this.listboxIP.Name = "listboxIP";
            this.listboxIP.Size = new System.Drawing.Size(221, 120);
            this.listboxIP.TabIndex = 144;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Azure;
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cboxToSerial);
            this.tabPage2.Controls.Add(this.cboxToUDP);
            this.tabPage2.Controls.Add(this.nudSendToUDPPort);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.nudGGAInterval);
            this.tabPage2.Controls.Add(this.cboxGGAManual);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.nudLongitude);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.nudLatitude);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.tboxCurrentLat);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.tboxCurrentLon);
            this.tabPage2.Controls.Add(this.btnSetManualPosition);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(733, 515);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Position";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(440, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 31);
            this.label1.TabIndex = 142;
            this.label1.Text = "Send To GPS Using:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cboxToSerial
            // 
            this.cboxToSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxToSerial.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxToSerial.BackColor = System.Drawing.Color.Salmon;
            this.cboxToSerial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxToSerial.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboxToSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxToSerial.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxToSerial.Image = global::AgIO.Properties.Resources.NtripToSerial;
            this.cboxToSerial.Location = new System.Drawing.Point(395, 106);
            this.cboxToSerial.Name = "cboxToSerial";
            this.cboxToSerial.Size = new System.Drawing.Size(150, 50);
            this.cboxToSerial.TabIndex = 140;
            this.cboxToSerial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxToSerial.UseVisualStyleBackColor = false;
            this.cboxToSerial.Click += new System.EventHandler(this.cboxToSerial_Click);
            // 
            // cboxToUDP
            // 
            this.cboxToUDP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxToUDP.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxToUDP.BackColor = System.Drawing.Color.Salmon;
            this.cboxToUDP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxToUDP.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboxToUDP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxToUDP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxToUDP.Image = global::AgIO.Properties.Resources.NtripToUDP;
            this.cboxToUDP.Location = new System.Drawing.Point(395, 197);
            this.cboxToUDP.Name = "cboxToUDP";
            this.cboxToUDP.Size = new System.Drawing.Size(150, 50);
            this.cboxToUDP.TabIndex = 141;
            this.cboxToUDP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxToUDP.UseVisualStyleBackColor = false;
            this.cboxToUDP.Click += new System.EventHandler(this.cboxToUDP_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.comboboxPacketSize);
            this.tabPage3.Controls.Add(this.labelRtcmPort);
            this.tabPage3.Controls.Add(this.cboxHTTP);
            this.tabPage3.Controls.Add(this.checkBoxusetcp);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Location = new System.Drawing.Point(4, 44);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(733, 515);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Advanced";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // comboboxPacketSize
            // 
            this.comboboxPacketSize.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboboxPacketSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxPacketSize.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.comboboxPacketSize.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboboxPacketSize.FormattingEnabled = true;
            this.comboboxPacketSize.Items.AddRange(new object[] {
            "64",
            "128",
            "256"});
            this.comboboxPacketSize.Location = new System.Drawing.Point(53, 344);
            this.comboboxPacketSize.Name = "comboboxPacketSize";
            this.comboboxPacketSize.Size = new System.Drawing.Size(112, 37);
            this.comboboxPacketSize.TabIndex = 138;
            // 
            // labelRtcmPort
            // 
            this.labelRtcmPort.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRtcmPort.Location = new System.Drawing.Point(48, 280);
            this.labelRtcmPort.Name = "labelRtcmPort";
            this.labelRtcmPort.Size = new System.Drawing.Size(121, 62);
            this.labelRtcmPort.TabIndex = 137;
            this.labelRtcmPort.Text = "UDP Send Packet Burst \r\nDefault 256 bytes\r\n";
            this.labelRtcmPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxIsNTRIPOn
            // 
            this.cboxIsNTRIPOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsNTRIPOn.BackColor = System.Drawing.Color.Salmon;
            this.cboxIsNTRIPOn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxIsNTRIPOn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboxIsNTRIPOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsNTRIPOn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsNTRIPOn.Location = new System.Drawing.Point(342, 588);
            this.cboxIsNTRIPOn.Name = "cboxIsNTRIPOn";
            this.cboxIsNTRIPOn.Size = new System.Drawing.Size(150, 50);
            this.cboxIsNTRIPOn.TabIndex = 92;
            this.cboxIsNTRIPOn.Text = "NTRIP On";
            this.cboxIsNTRIPOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsNTRIPOn.UseVisualStyleBackColor = false;
            this.cboxIsNTRIPOn.Click += new System.EventHandler(this.cboxIsNTRIPOn_Click);
            // 
            // btnSerialOK
            // 
            this.btnSerialOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSerialOK.FlatAppearance.BorderSize = 0;
            this.btnSerialOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialOK.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSerialOK.Image = global::AgIO.Properties.Resources.OK64;
            this.btnSerialOK.Location = new System.Drawing.Point(650, 581);
            this.btnSerialOK.Name = "btnSerialOK";
            this.btnSerialOK.Size = new System.Drawing.Size(105, 64);
            this.btnSerialOK.TabIndex = 94;
            this.btnSerialOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSerialOK.UseVisualStyleBackColor = true;
            this.btnSerialOK.Click += new System.EventHandler(this.btnSerialOK_Click);
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.FlatAppearance.BorderSize = 0;
            this.btnSerialCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialCancel.Image = global::AgIO.Properties.Resources.Cancel64;
            this.btnSerialCancel.Location = new System.Drawing.Point(529, 581);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(105, 64);
            this.btnSerialCancel.TabIndex = 95;
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnHelp.Image = global::AgIO.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(162, 577);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(76, 65);
            this.btnHelp.TabIndex = 533;
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // FormNtrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(767, 648);
            this.ControlBox = false;
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cboxIsNTRIPOn);
            this.Controls.Add(this.btnSerialCancel);
            this.Controls.Add(this.btnSerialOK);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNtrip";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NTRIP Client Settings";
            this.Load += new System.EventHandler(this.FormNtrip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCasterPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSendToUDPPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGGAInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLatitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitude)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox cboxIsNTRIPOn;
        private System.Windows.Forms.TextBox tboxCasterIP;
        private System.Windows.Forms.NumericUpDown nudCasterPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tboxHostName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nudSendToUDPPort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSerialOK;
        private System.Windows.Forms.TextBox tboxUserName;
        private System.Windows.Forms.TextBox tboxUserPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
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
        private System.Windows.Forms.Button btnGetSourceTable;
        private System.Windows.Forms.Button btnSetManualPosition;
        private System.Windows.Forms.ComboBox cboxGGAManual;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox checkBoxusetcp;
        public System.Windows.Forms.TextBox tboxMount;
        private System.Windows.Forms.Button btnPassUsername;
        private System.Windows.Forms.Button btnPassPassword;
        private System.Windows.Forms.ComboBox cboxHTTP;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cboxToSerial;
        private System.Windows.Forms.CheckBox cboxToUDP;
        private System.Windows.Forms.ListBox listboxIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox comboboxPacketSize;
        private System.Windows.Forms.Label labelRtcmPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Button btnHelp;
    }
}