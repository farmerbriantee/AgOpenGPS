namespace AgSim
{
    partial class FormSimIP
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtNMEA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudHz = new System.Windows.Forms.NumericUpDown();
            this.tbarHeading = new System.Windows.Forms.TrackBar();
            this.lblHeadingTrueSlide = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnHead0 = new System.Windows.Forms.Button();
            this.btnHead270 = new System.Windows.Forms.Button();
            this.btnHead180 = new System.Windows.Forms.Button();
            this.btnHead90 = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.tbarStepDistance = new System.Windows.Forms.TrackBar();
            this.lblStep = new System.Windows.Forms.Label();
            this.tbarTurnSpeed = new System.Windows.Forms.TrackBar();
            this.lblTurnSpeed = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudAltitude = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.chkGGA = new System.Windows.Forms.CheckBox();
            this.chkVTG = new System.Windows.Forms.CheckBox();
            this.chkRMC = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.tboxIP = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.tboxReceive = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudHz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarHeading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarStepDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarTurnSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAltitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtNMEA
            // 
            this.txtNMEA.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNMEA.Location = new System.Drawing.Point(9, 9);
            this.txtNMEA.Multiline = true;
            this.txtNMEA.Name = "txtNMEA";
            this.txtNMEA.Size = new System.Drawing.Size(575, 63);
            this.txtNMEA.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "M/sec";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(498, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hz";
            // 
            // nudHz
            // 
            this.nudHz.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHz.Location = new System.Drawing.Point(479, 328);
            this.nudHz.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudHz.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHz.Name = "nudHz";
            this.nudHz.Size = new System.Drawing.Size(94, 40);
            this.nudHz.TabIndex = 4;
            this.nudHz.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudHz.ValueChanged += new System.EventHandler(this.nudHz_ValueChanged);
            // 
            // tbarHeading
            // 
            this.tbarHeading.LargeChange = 10;
            this.tbarHeading.Location = new System.Drawing.Point(11, 323);
            this.tbarHeading.Maximum = 720;
            this.tbarHeading.Name = "tbarHeading";
            this.tbarHeading.Size = new System.Drawing.Size(423, 45);
            this.tbarHeading.TabIndex = 8;
            this.tbarHeading.TickFrequency = 20;
            this.tbarHeading.Value = 180;
            this.tbarHeading.Scroll += new System.EventHandler(this.tbarHeading_Scroll);
            // 
            // lblHeadingTrueSlide
            // 
            this.lblHeadingTrueSlide.AutoSize = true;
            this.lblHeadingTrueSlide.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadingTrueSlide.Location = new System.Drawing.Point(191, 300);
            this.lblHeadingTrueSlide.Name = "lblHeadingTrueSlide";
            this.lblHeadingTrueSlide.Size = new System.Drawing.Size(40, 24);
            this.lblHeadingTrueSlide.TabIndex = 9;
            this.lblHeadingTrueSlide.Text = "180";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(405, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "720";
            // 
            // btnHead0
            // 
            this.btnHead0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHead0.Location = new System.Drawing.Point(23, 167);
            this.btnHead0.Name = "btnHead0";
            this.btnHead0.Size = new System.Drawing.Size(75, 30);
            this.btnHead0.TabIndex = 12;
            this.btnHead0.Text = "0";
            this.btnHead0.UseVisualStyleBackColor = true;
            this.btnHead0.Click += new System.EventHandler(this.btnHead0_Click);
            // 
            // btnHead270
            // 
            this.btnHead270.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHead270.Location = new System.Drawing.Point(287, 167);
            this.btnHead270.Name = "btnHead270";
            this.btnHead270.Size = new System.Drawing.Size(75, 30);
            this.btnHead270.TabIndex = 13;
            this.btnHead270.Text = "270";
            this.btnHead270.UseVisualStyleBackColor = true;
            this.btnHead270.Click += new System.EventHandler(this.btnHead270_Click);
            // 
            // btnHead180
            // 
            this.btnHead180.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHead180.Location = new System.Drawing.Point(197, 167);
            this.btnHead180.Name = "btnHead180";
            this.btnHead180.Size = new System.Drawing.Size(75, 30);
            this.btnHead180.TabIndex = 14;
            this.btnHead180.Text = "180";
            this.btnHead180.UseVisualStyleBackColor = true;
            this.btnHead180.Click += new System.EventHandler(this.btnHead180_Click);
            // 
            // btnHead90
            // 
            this.btnHead90.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHead90.Location = new System.Drawing.Point(114, 167);
            this.btnHead90.Name = "btnHead90";
            this.btnHead90.Size = new System.Drawing.Size(75, 30);
            this.btnHead90.TabIndex = 15;
            this.btnHead90.Text = "90";
            this.btnHead90.UseVisualStyleBackColor = true;
            this.btnHead90.Click += new System.EventHandler(this.btnHead90_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.Location = new System.Drawing.Point(31, 216);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(112, 30);
            this.btnLeft.TabIndex = 16;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.Location = new System.Drawing.Point(258, 216);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(112, 30);
            this.btnRight.TabIndex = 17;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // tbarStepDistance
            // 
            this.tbarStepDistance.LargeChange = 10;
            this.tbarStepDistance.Location = new System.Drawing.Point(11, 403);
            this.tbarStepDistance.Maximum = 300;
            this.tbarStepDistance.Name = "tbarStepDistance";
            this.tbarStepDistance.Size = new System.Drawing.Size(347, 45);
            this.tbarStepDistance.SmallChange = 2;
            this.tbarStepDistance.TabIndex = 18;
            this.tbarStepDistance.TickFrequency = 10;
            this.tbarStepDistance.Value = 10;
            this.tbarStepDistance.Scroll += new System.EventHandler(this.tbarStepDistance_Scroll);
            // 
            // lblStep
            // 
            this.lblStep.AutoSize = true;
            this.lblStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep.Location = new System.Drawing.Point(95, 376);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(20, 24);
            this.lblStep.TabIndex = 19;
            this.lblStep.Text = "1";
            // 
            // tbarTurnSpeed
            // 
            this.tbarTurnSpeed.LargeChange = 1;
            this.tbarTurnSpeed.Location = new System.Drawing.Point(20, 259);
            this.tbarTurnSpeed.Maximum = 11;
            this.tbarTurnSpeed.Minimum = 1;
            this.tbarTurnSpeed.Name = "tbarTurnSpeed";
            this.tbarTurnSpeed.Size = new System.Drawing.Size(358, 45);
            this.tbarTurnSpeed.SmallChange = 2;
            this.tbarTurnSpeed.TabIndex = 52;
            this.tbarTurnSpeed.TickFrequency = 2;
            this.tbarTurnSpeed.Value = 1;
            this.tbarTurnSpeed.Scroll += new System.EventHandler(this.tbarTurnSpeed_Scroll);
            // 
            // lblTurnSpeed
            // 
            this.lblTurnSpeed.AutoSize = true;
            this.lblTurnSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnSpeed.Location = new System.Drawing.Point(193, 235);
            this.lblTurnSpeed.Name = "lblTurnSpeed";
            this.lblTurnSpeed.Size = new System.Drawing.Size(20, 24);
            this.lblTurnSpeed.TabIndex = 53;
            this.lblTurnSpeed.Text = "1";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(264, 376);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(20, 24);
            this.lblSpeed.TabIndex = 54;
            this.lblSpeed.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(225, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "kmh";
            // 
            // nudAltitude
            // 
            this.nudAltitude.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAltitude.Location = new System.Drawing.Point(479, 391);
            this.nudAltitude.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudAltitude.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAltitude.Name = "nudAltitude";
            this.nudAltitude.Size = new System.Drawing.Size(94, 40);
            this.nudAltitude.TabIndex = 56;
            this.nudAltitude.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudAltitude.ValueChanged += new System.EventHandler(this.nudAltitude_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(485, 372);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 57;
            this.label6.Text = "Altitude";
            // 
            // chkGGA
            // 
            this.chkGGA.AutoSize = true;
            this.chkGGA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGGA.Location = new System.Drawing.Point(380, 366);
            this.chkGGA.Name = "chkGGA";
            this.chkGGA.Size = new System.Drawing.Size(65, 24);
            this.chkGGA.TabIndex = 58;
            this.chkGGA.Text = "GGA";
            this.chkGGA.UseVisualStyleBackColor = true;
            // 
            // chkVTG
            // 
            this.chkVTG.AutoSize = true;
            this.chkVTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVTG.Location = new System.Drawing.Point(380, 395);
            this.chkVTG.Name = "chkVTG";
            this.chkVTG.Size = new System.Drawing.Size(61, 24);
            this.chkVTG.TabIndex = 59;
            this.chkVTG.Text = "VTG";
            this.chkVTG.UseVisualStyleBackColor = true;
            // 
            // chkRMC
            // 
            this.chkRMC.AutoSize = true;
            this.chkRMC.Checked = true;
            this.chkRMC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRMC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRMC.Location = new System.Drawing.Point(380, 424);
            this.chkRMC.Name = "chkRMC";
            this.chkRMC.Size = new System.Drawing.Size(64, 24);
            this.chkRMC.TabIndex = 60;
            this.chkRMC.Text = "RMC";
            this.chkRMC.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(164, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 61;
            this.label7.Text = "Turn Speed";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(237, 304);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 16);
            this.label8.TabIndex = 62;
            this.label8.Text = "Heading";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(485, 440);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 63;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(436, 271);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 64;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // tboxIP
            // 
            this.tboxIP.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxIP.Location = new System.Drawing.Point(464, 172);
            this.tboxIP.Name = "tboxIP";
            this.tboxIP.Size = new System.Drawing.Size(123, 32);
            this.tboxIP.TabIndex = 65;
            this.tboxIP.Text = "192.168.1.138";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(464, 218);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(96, 32);
            this.numericUpDown1.TabIndex = 66;
            this.numericUpDown1.Value = new decimal(new int[] {
            7777,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(426, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 16);
            this.label9.TabIndex = 67;
            this.label9.Text = "Port";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(438, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 16);
            this.label10.TabIndex = 68;
            this.label10.Text = "IP";
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(524, 271);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(75, 23);
            this.buttonDisconnect.TabIndex = 69;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // tboxReceive
            // 
            this.tboxReceive.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxReceive.Location = new System.Drawing.Point(12, 94);
            this.tboxReceive.Multiline = true;
            this.tboxReceive.Name = "tboxReceive";
            this.tboxReceive.Size = new System.Drawing.Size(575, 56);
            this.tboxReceive.TabIndex = 70;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 16);
            this.label11.TabIndex = 71;
            this.label11.Text = "Echo From Server";
            // 
            // FormSimIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 517);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tboxReceive);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.tboxIP);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkRMC);
            this.Controls.Add(this.chkVTG);
            this.Controls.Add(this.chkGGA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudAltitude);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblTurnSpeed);
            this.Controls.Add(this.tbarTurnSpeed);
            this.Controls.Add(this.lblStep);
            this.Controls.Add(this.tbarStepDistance);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnHead90);
            this.Controls.Add(this.btnHead180);
            this.Controls.Add(this.btnHead270);
            this.Controls.Add(this.btnHead0);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblHeadingTrueSlide);
            this.Controls.Add(this.tbarHeading);
            this.Controls.Add(this.nudHz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNMEA);
            this.Name = "FormSimIP";
            this.Text = "GPS Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSim_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudHz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarHeading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarStepDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarTurnSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAltitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtNMEA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudHz;
        private System.Windows.Forms.TrackBar tbarHeading;
        private System.Windows.Forms.Label lblHeadingTrueSlide;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnHead0;
        private System.Windows.Forms.Button btnHead270;
        private System.Windows.Forms.Button btnHead180;
        private System.Windows.Forms.Button btnHead90;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.TrackBar tbarStepDistance;
        private System.Windows.Forms.TrackBar tbarTurnSpeed;
        private System.Windows.Forms.Label lblTurnSpeed;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudAltitude;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkGGA;
        private System.Windows.Forms.CheckBox chkVTG;
        private System.Windows.Forms.CheckBox chkRMC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox tboxIP;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.TextBox tboxReceive;
        private System.Windows.Forms.Label label11;
    }
}

