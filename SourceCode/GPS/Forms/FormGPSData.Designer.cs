namespace AgOpenGPS
{
    partial class FormGPSData
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblFixQuality = new System.Windows.Forms.Label();
            this.lblSatsTracked = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblEasting = new System.Windows.Forms.Label();
            this.lblNorthing = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblHDOP = new System.Windows.Forms.Label();
            this.tboxNMEASerial = new System.Windows.Forms.TextBox();
            this.tboxSerialFromMachine = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblZone = new System.Windows.Forms.Label();
            this.tboxSerialToMachine = new System.Windows.Forms.TextBox();
            this.tboxSerialFromAutoSteer = new System.Windows.Forms.TextBox();
            this.tboxSerialToAutoSteer = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblSectionLoByte = new System.Windows.Forms.Label();
            this.lblSectionHiByte = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPgnHiRd = new System.Windows.Forms.Label();
            this.lblPgnLoRd = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblSpd = new System.Windows.Forms.Label();
            this.lblUTurn = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblTree = new System.Windows.Forms.Label();
            this.lblMachine = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lblUTurnSd = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblAngleHi = new System.Windows.Forms.Label();
            this.lblAngleLo = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.lblDistHi = new System.Windows.Forms.Label();
            this.lblDistLo = new System.Windows.Forms.Label();
            this.lblPgnHiSd = new System.Windows.Forms.Label();
            this.lblPgnLoSd = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.lblSpdSd = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.lbl60 = new System.Windows.Forms.Label();
            this.lbl61 = new System.Windows.Forms.Label();
            this.lblMaxInt = new System.Windows.Forms.Label();
            this.lblCntPerDegree = new System.Windows.Forms.Label();
            this.lblSteerOffset = new System.Windows.Forms.Label();
            this.lblMinPWM = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.lblKd = new System.Windows.Forms.Label();
            this.lblKo = new System.Windows.Forms.Label();
            this.lblPgnHiSs = new System.Windows.Forms.Label();
            this.lblPgnLoSs = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.lblKp = new System.Windows.Forms.Label();
            this.lblKi = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.lblSectionLoSd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 333;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(210, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Northing";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(219, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Easting";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(216, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Latitude";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(39, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(5, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fix Quality";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(-2, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "# Satellites";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(102, 0);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(61, 19);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFixQuality
            // 
            this.lblFixQuality.AutoSize = true;
            this.lblFixQuality.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixQuality.Location = new System.Drawing.Point(102, 26);
            this.lblFixQuality.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFixQuality.Name = "lblFixQuality";
            this.lblFixQuality.Size = new System.Drawing.Size(70, 19);
            this.lblFixQuality.TabIndex = 2;
            this.lblFixQuality.Text = "FixQual";
            this.lblFixQuality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSatsTracked
            // 
            this.lblSatsTracked.AutoSize = true;
            this.lblSatsTracked.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatsTracked.Location = new System.Drawing.Point(102, 52);
            this.lblSatsTracked.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSatsTracked.Name = "lblSatsTracked";
            this.lblSatsTracked.Size = new System.Drawing.Size(44, 19);
            this.lblSatsTracked.TabIndex = 4;
            this.lblSatsTracked.Text = "Sats";
            this.lblSatsTracked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.Location = new System.Drawing.Point(293, 81);
            this.lblLatitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(77, 19);
            this.lblLatitude.TabIndex = 12;
            this.lblLatitude.Text = "Latitude";
            // 
            // lblEasting
            // 
            this.lblEasting.AutoSize = true;
            this.lblEasting.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasting.Location = new System.Drawing.Point(291, 49);
            this.lblEasting.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEasting.Name = "lblEasting";
            this.lblEasting.Size = new System.Drawing.Size(69, 19);
            this.lblEasting.TabIndex = 11;
            this.lblEasting.Text = "Easting";
            // 
            // lblNorthing
            // 
            this.lblNorthing.AutoSize = true;
            this.lblNorthing.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNorthing.Location = new System.Drawing.Point(291, 25);
            this.lblNorthing.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNorthing.Name = "lblNorthing";
            this.lblNorthing.Size = new System.Drawing.Size(80, 19);
            this.lblNorthing.TabIndex = 10;
            this.lblNorthing.Text = "Northing";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.Location = new System.Drawing.Point(293, 106);
            this.lblLongitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(90, 19);
            this.lblLongitude.TabIndex = 13;
            this.lblLongitude.Text = "Longitude";
            // 
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltitude.Location = new System.Drawing.Point(102, 107);
            this.lblAltitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(75, 19);
            this.lblAltitude.TabIndex = 14;
            this.lblAltitude.Text = "Altitude";
            this.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(196, 103);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Longitiude";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(21, 104);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 23);
            this.label8.TabIndex = 16;
            this.label8.Text = "Altitude";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(42, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 23);
            this.label9.TabIndex = 18;
            this.label9.Text = "HDOP";
            // 
            // lblHDOP
            // 
            this.lblHDOP.AutoSize = true;
            this.lblHDOP.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHDOP.Location = new System.Drawing.Point(102, 78);
            this.lblHDOP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHDOP.Name = "lblHDOP";
            this.lblHDOP.Size = new System.Drawing.Size(56, 19);
            this.lblHDOP.TabIndex = 17;
            this.lblHDOP.Text = "HDOP";
            this.lblHDOP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tboxNMEASerial
            // 
            this.tboxNMEASerial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxNMEASerial.Location = new System.Drawing.Point(424, 4);
            this.tboxNMEASerial.Multiline = true;
            this.tboxNMEASerial.Name = "tboxNMEASerial";
            this.tboxNMEASerial.ReadOnly = true;
            this.tboxNMEASerial.Size = new System.Drawing.Size(453, 56);
            this.tboxNMEASerial.TabIndex = 107;
            // 
            // tboxSerialFromMachine
            // 
            this.tboxSerialFromMachine.BackColor = System.Drawing.SystemColors.Control;
            this.tboxSerialFromMachine.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSerialFromMachine.Location = new System.Drawing.Point(656, 88);
            this.tboxSerialFromMachine.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tboxSerialFromMachine.Name = "tboxSerialFromMachine";
            this.tboxSerialFromMachine.ReadOnly = true;
            this.tboxSerialFromMachine.Size = new System.Drawing.Size(221, 27);
            this.tboxSerialFromMachine.TabIndex = 108;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(237, -2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 23);
            this.label11.TabIndex = 114;
            this.label11.Text = "Zone";
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZone.Location = new System.Drawing.Point(291, 1);
            this.lblZone.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(49, 19);
            this.lblZone.TabIndex = 113;
            this.lblZone.Text = "Zone";
            this.lblZone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tboxSerialToMachine
            // 
            this.tboxSerialToMachine.BackColor = System.Drawing.SystemColors.Control;
            this.tboxSerialToMachine.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSerialToMachine.Location = new System.Drawing.Point(424, 88);
            this.tboxSerialToMachine.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tboxSerialToMachine.Name = "tboxSerialToMachine";
            this.tboxSerialToMachine.ReadOnly = true;
            this.tboxSerialToMachine.Size = new System.Drawing.Size(224, 27);
            this.tboxSerialToMachine.TabIndex = 115;
            // 
            // tboxSerialFromAutoSteer
            // 
            this.tboxSerialFromAutoSteer.BackColor = System.Drawing.SystemColors.Control;
            this.tboxSerialFromAutoSteer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSerialFromAutoSteer.Location = new System.Drawing.Point(656, 140);
            this.tboxSerialFromAutoSteer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tboxSerialFromAutoSteer.Name = "tboxSerialFromAutoSteer";
            this.tboxSerialFromAutoSteer.ReadOnly = true;
            this.tboxSerialFromAutoSteer.Size = new System.Drawing.Size(221, 27);
            this.tboxSerialFromAutoSteer.TabIndex = 119;
            // 
            // tboxSerialToAutoSteer
            // 
            this.tboxSerialToAutoSteer.BackColor = System.Drawing.SystemColors.Control;
            this.tboxSerialToAutoSteer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSerialToAutoSteer.Location = new System.Drawing.Point(424, 141);
            this.tboxSerialToAutoSteer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tboxSerialToAutoSteer.Name = "tboxSerialToAutoSteer";
            this.tboxSerialToAutoSteer.ReadOnly = true;
            this.tboxSerialToAutoSteer.Size = new System.Drawing.Size(224, 27);
            this.tboxSerialToAutoSteer.TabIndex = 117;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(426, 126);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(195, 13);
            this.label20.TabIndex = 209;
            this.label20.Text = "MachineLo, Spd, Dist, SteerAng, UTurn";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(660, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(204, 13);
            this.label13.TabIndex = 210;
            this.label13.Text = "Steer Actual, SetPoint, Heading, Roll, Sw";
            // 
            // lblSectionLoByte
            // 
            this.lblSectionLoByte.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblSectionLoByte.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSectionLoByte.Location = new System.Drawing.Point(199, 261);
            this.lblSectionLoByte.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSectionLoByte.Name = "lblSectionLoByte";
            this.lblSectionLoByte.Size = new System.Drawing.Size(91, 23);
            this.lblSectionLoByte.TabIndex = 211;
            this.lblSectionLoByte.Text = "00000000";
            this.lblSectionLoByte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSectionHiByte
            // 
            this.lblSectionHiByte.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblSectionHiByte.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSectionHiByte.Location = new System.Drawing.Point(105, 261);
            this.lblSectionHiByte.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSectionHiByte.Name = "lblSectionHiByte";
            this.lblSectionHiByte.Size = new System.Drawing.Size(91, 23);
            this.lblSectionHiByte.TabIndex = 212;
            this.lblSectionHiByte.Text = "00000000";
            this.lblSectionHiByte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(199, 236);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 23);
            this.label12.TabIndex = 213;
            this.label12.Text = "Section Lo";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(107, 236);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 23);
            this.label14.TabIndex = 214;
            this.label14.Text = "Section Hi";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPgnHiRd
            // 
            this.lblPgnHiRd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblPgnHiRd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPgnHiRd.Location = new System.Drawing.Point(12, 261);
            this.lblPgnHiRd.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPgnHiRd.Name = "lblPgnHiRd";
            this.lblPgnHiRd.Size = new System.Drawing.Size(44, 23);
            this.lblPgnHiRd.TabIndex = 216;
            this.lblPgnHiRd.Text = "127";
            this.lblPgnHiRd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPgnLoRd
            // 
            this.lblPgnLoRd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblPgnLoRd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPgnLoRd.Location = new System.Drawing.Point(57, 261);
            this.lblPgnLoRd.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPgnLoRd.Name = "lblPgnLoRd";
            this.lblPgnLoRd.Size = new System.Drawing.Size(44, 23);
            this.lblPgnLoRd.TabIndex = 215;
            this.lblPgnLoRd.Text = "254";
            this.lblPgnLoRd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label16.Location = new System.Drawing.Point(39, 208);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 19);
            this.label16.TabIndex = 217;
            this.label16.Text = "PGN";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(17, 236);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 19);
            this.label17.TabIndex = 218;
            this.label17.Text = "Machine Data";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label18.Location = new System.Drawing.Point(293, 236);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(91, 23);
            this.label18.TabIndex = 222;
            this.label18.Text = "Spd*4";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label19.Location = new System.Drawing.Point(387, 236);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 23);
            this.label19.TabIndex = 221;
            this.label19.Text = "UTurn";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSpd
            // 
            this.lblSpd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblSpd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpd.Location = new System.Drawing.Point(293, 261);
            this.lblSpd.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSpd.Name = "lblSpd";
            this.lblSpd.Size = new System.Drawing.Size(91, 23);
            this.lblSpd.TabIndex = 220;
            this.lblSpd.Text = "128";
            this.lblSpd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUTurn
            // 
            this.lblUTurn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblUTurn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUTurn.Location = new System.Drawing.Point(387, 261);
            this.lblUTurn.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUTurn.Name = "lblUTurn";
            this.lblUTurn.Size = new System.Drawing.Size(91, 23);
            this.lblUTurn.TabIndex = 219;
            this.lblUTurn.Text = "00000000";
            this.lblUTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label23.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(669, 261);
            this.label23.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(91, 23);
            this.label23.TabIndex = 226;
            this.label23.Text = "-";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label24.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(763, 261);
            this.label24.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(91, 23);
            this.label24.TabIndex = 225;
            this.label24.Text = "-";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTree
            // 
            this.lblTree.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblTree.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTree.Location = new System.Drawing.Point(481, 261);
            this.lblTree.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTree.Name = "lblTree";
            this.lblTree.Size = new System.Drawing.Size(91, 23);
            this.lblTree.TabIndex = 224;
            this.lblTree.Text = "00000000";
            this.lblTree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMachine
            // 
            this.lblMachine.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblMachine.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMachine.Location = new System.Drawing.Point(575, 261);
            this.lblMachine.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(91, 23);
            this.lblMachine.TabIndex = 223;
            this.lblMachine.Text = "00000000";
            this.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label27.Location = new System.Drawing.Point(482, 236);
            this.label27.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(91, 23);
            this.label27.TabIndex = 227;
            this.label27.Text = "Tree";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label28.Location = new System.Drawing.Point(575, 236);
            this.label28.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(91, 23);
            this.label28.TabIndex = 228;
            this.label28.Text = "Machine";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label29.Location = new System.Drawing.Point(762, 234);
            this.label29.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(91, 23);
            this.label29.TabIndex = 230;
            this.label29.Text = "-";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label30.Location = new System.Drawing.Point(669, 234);
            this.label30.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(91, 23);
            this.label30.TabIndex = 229;
            this.label30.Text = "-";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label31.Location = new System.Drawing.Point(667, 298);
            this.label31.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(91, 23);
            this.label31.TabIndex = 249;
            this.label31.Text = "-";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label32.Location = new System.Drawing.Point(574, 298);
            this.label32.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(91, 23);
            this.label32.TabIndex = 248;
            this.label32.Text = "-";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label33.Location = new System.Drawing.Point(480, 300);
            this.label33.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(91, 23);
            this.label33.TabIndex = 247;
            this.label33.Text = "Angle Lo";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label34.Location = new System.Drawing.Point(387, 300);
            this.label34.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(91, 23);
            this.label34.TabIndex = 246;
            this.label34.Text = "Angle Hi";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUTurnSd
            // 
            this.lblUTurnSd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblUTurnSd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUTurnSd.Location = new System.Drawing.Point(574, 325);
            this.lblUTurnSd.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUTurnSd.Name = "lblUTurnSd";
            this.lblUTurnSd.Size = new System.Drawing.Size(91, 23);
            this.lblUTurnSd.TabIndex = 245;
            this.lblUTurnSd.Text = "-";
            this.lblUTurnSd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label36.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(668, 325);
            this.label36.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(91, 23);
            this.label36.TabIndex = 244;
            this.label36.Text = "-";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAngleHi
            // 
            this.lblAngleHi.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblAngleHi.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAngleHi.Location = new System.Drawing.Point(386, 325);
            this.lblAngleHi.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAngleHi.Name = "lblAngleHi";
            this.lblAngleHi.Size = new System.Drawing.Size(91, 23);
            this.lblAngleHi.TabIndex = 243;
            this.lblAngleHi.Text = "128";
            this.lblAngleHi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAngleLo
            // 
            this.lblAngleLo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblAngleLo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAngleLo.Location = new System.Drawing.Point(480, 325);
            this.lblAngleLo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAngleLo.Name = "lblAngleLo";
            this.lblAngleLo.Size = new System.Drawing.Size(91, 23);
            this.lblAngleLo.TabIndex = 242;
            this.lblAngleLo.Text = "128";
            this.lblAngleLo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label39.Location = new System.Drawing.Point(198, 300);
            this.label39.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(91, 23);
            this.label39.TabIndex = 241;
            this.label39.Text = "Dist Hi";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label40.Location = new System.Drawing.Point(292, 300);
            this.label40.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(91, 23);
            this.label40.TabIndex = 240;
            this.label40.Text = "Dist Lo";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDistHi
            // 
            this.lblDistHi.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblDistHi.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistHi.Location = new System.Drawing.Point(198, 325);
            this.lblDistHi.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDistHi.Name = "lblDistHi";
            this.lblDistHi.Size = new System.Drawing.Size(91, 23);
            this.lblDistHi.TabIndex = 239;
            this.lblDistHi.Text = "128";
            this.lblDistHi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDistLo
            // 
            this.lblDistLo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblDistLo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistLo.Location = new System.Drawing.Point(292, 325);
            this.lblDistLo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDistLo.Name = "lblDistLo";
            this.lblDistLo.Size = new System.Drawing.Size(91, 23);
            this.lblDistLo.TabIndex = 238;
            this.lblDistLo.Text = "128";
            this.lblDistLo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPgnHiSd
            // 
            this.lblPgnHiSd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblPgnHiSd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPgnHiSd.Location = new System.Drawing.Point(12, 325);
            this.lblPgnHiSd.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPgnHiSd.Name = "lblPgnHiSd";
            this.lblPgnHiSd.Size = new System.Drawing.Size(44, 23);
            this.lblPgnHiSd.TabIndex = 236;
            this.lblPgnHiSd.Text = "127";
            this.lblPgnHiSd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPgnLoSd
            // 
            this.lblPgnLoSd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblPgnLoSd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPgnLoSd.Location = new System.Drawing.Point(57, 325);
            this.lblPgnLoSd.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPgnLoSd.Name = "lblPgnLoSd";
            this.lblPgnLoSd.Size = new System.Drawing.Size(44, 23);
            this.lblPgnLoSd.TabIndex = 235;
            this.lblPgnLoSd.Text = "254";
            this.lblPgnLoSd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label45.Location = new System.Drawing.Point(764, 300);
            this.label45.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(91, 23);
            this.label45.TabIndex = 234;
            this.label45.Text = "-";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label46.Location = new System.Drawing.Point(104, 300);
            this.label46.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(91, 23);
            this.label46.TabIndex = 233;
            this.label46.Text = "Spd*4";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSpdSd
            // 
            this.lblSpdSd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblSpdSd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpdSd.Location = new System.Drawing.Point(104, 325);
            this.lblSpdSd.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSpdSd.Name = "lblSpdSd";
            this.lblSpdSd.Size = new System.Drawing.Size(91, 23);
            this.lblSpdSd.TabIndex = 231;
            this.lblSpdSd.Text = "122";
            this.lblSpdSd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label49.Location = new System.Drawing.Point(17, 300);
            this.label49.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(84, 19);
            this.label49.TabIndex = 237;
            this.label49.Text = "A/S Data";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label50.Location = new System.Drawing.Point(387, 364);
            this.label50.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(91, 23);
            this.label50.TabIndex = 268;
            this.label50.Text = "Ko";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label51.Location = new System.Drawing.Point(763, 364);
            this.label51.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(91, 23);
            this.label51.TabIndex = 267;
            this.label51.Text = "Ct Per Deg";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl60
            // 
            this.lbl60.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl60.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl60.Location = new System.Drawing.Point(669, 366);
            this.lbl60.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl60.Name = "lbl60";
            this.lbl60.Size = new System.Drawing.Size(91, 23);
            this.lbl60.TabIndex = 266;
            this.lbl60.Text = "Max Int";
            this.lbl60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl61
            // 
            this.lbl61.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl61.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl61.Location = new System.Drawing.Point(576, 366);
            this.lbl61.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl61.Name = "lbl61";
            this.lbl61.Size = new System.Drawing.Size(91, 23);
            this.lbl61.TabIndex = 265;
            this.lbl61.Text = "Min PWM";
            this.lbl61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxInt
            // 
            this.lblMaxInt.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblMaxInt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxInt.Location = new System.Drawing.Point(669, 391);
            this.lblMaxInt.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMaxInt.Name = "lblMaxInt";
            this.lblMaxInt.Size = new System.Drawing.Size(91, 23);
            this.lblMaxInt.TabIndex = 264;
            this.lblMaxInt.Text = "128";
            this.lblMaxInt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCntPerDegree
            // 
            this.lblCntPerDegree.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblCntPerDegree.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCntPerDegree.Location = new System.Drawing.Point(763, 391);
            this.lblCntPerDegree.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCntPerDegree.Name = "lblCntPerDegree";
            this.lblCntPerDegree.Size = new System.Drawing.Size(91, 23);
            this.lblCntPerDegree.TabIndex = 263;
            this.lblCntPerDegree.Text = "128";
            this.lblCntPerDegree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSteerOffset
            // 
            this.lblSteerOffset.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblSteerOffset.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerOffset.Location = new System.Drawing.Point(481, 391);
            this.lblSteerOffset.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSteerOffset.Name = "lblSteerOffset";
            this.lblSteerOffset.Size = new System.Drawing.Size(91, 23);
            this.lblSteerOffset.TabIndex = 262;
            this.lblSteerOffset.Text = "128";
            this.lblSteerOffset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinPWM
            // 
            this.lblMinPWM.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblMinPWM.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinPWM.Location = new System.Drawing.Point(575, 391);
            this.lblMinPWM.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMinPWM.Name = "lblMinPWM";
            this.lblMinPWM.Size = new System.Drawing.Size(91, 23);
            this.lblMinPWM.TabIndex = 261;
            this.lblMinPWM.Text = "128";
            this.lblMinPWM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label58
            // 
            this.label58.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label58.Location = new System.Drawing.Point(293, 366);
            this.label58.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(91, 23);
            this.label58.TabIndex = 260;
            this.label58.Text = "Kd";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label59
            // 
            this.label59.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label59.Location = new System.Drawing.Point(481, 366);
            this.label59.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(91, 23);
            this.label59.TabIndex = 259;
            this.label59.Text = "Offset";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKd
            // 
            this.lblKd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblKd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKd.Location = new System.Drawing.Point(293, 391);
            this.lblKd.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblKd.Name = "lblKd";
            this.lblKd.Size = new System.Drawing.Size(91, 23);
            this.lblKd.TabIndex = 258;
            this.lblKd.Text = "128";
            this.lblKd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKo
            // 
            this.lblKo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblKo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKo.Location = new System.Drawing.Point(387, 391);
            this.lblKo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblKo.Name = "lblKo";
            this.lblKo.Size = new System.Drawing.Size(91, 23);
            this.lblKo.TabIndex = 257;
            this.lblKo.Text = "128";
            this.lblKo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPgnHiSs
            // 
            this.lblPgnHiSs.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblPgnHiSs.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPgnHiSs.Location = new System.Drawing.Point(12, 391);
            this.lblPgnHiSs.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPgnHiSs.Name = "lblPgnHiSs";
            this.lblPgnHiSs.Size = new System.Drawing.Size(44, 23);
            this.lblPgnHiSs.TabIndex = 255;
            this.lblPgnHiSs.Text = "127";
            this.lblPgnHiSs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPgnLoSs
            // 
            this.lblPgnLoSs.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblPgnLoSs.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPgnLoSs.Location = new System.Drawing.Point(57, 391);
            this.lblPgnLoSs.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPgnLoSs.Name = "lblPgnLoSs";
            this.lblPgnLoSs.Size = new System.Drawing.Size(44, 23);
            this.lblPgnLoSs.TabIndex = 254;
            this.lblPgnLoSs.Text = "254";
            this.lblPgnLoSs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label64
            // 
            this.label64.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label64.Location = new System.Drawing.Point(107, 366);
            this.label64.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(91, 23);
            this.label64.TabIndex = 253;
            this.label64.Text = "Kp";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label65
            // 
            this.label65.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label65.Location = new System.Drawing.Point(199, 366);
            this.label65.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(91, 23);
            this.label65.TabIndex = 252;
            this.label65.Text = "Ki";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKp
            // 
            this.lblKp.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblKp.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKp.Location = new System.Drawing.Point(105, 391);
            this.lblKp.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblKp.Name = "lblKp";
            this.lblKp.Size = new System.Drawing.Size(91, 23);
            this.lblKp.TabIndex = 251;
            this.lblKp.Text = "128";
            this.lblKp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKi
            // 
            this.lblKi.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblKi.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKi.Location = new System.Drawing.Point(199, 391);
            this.lblKi.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblKi.Name = "lblKi";
            this.lblKi.Size = new System.Drawing.Size(91, 23);
            this.lblKi.TabIndex = 250;
            this.lblKi.Text = "128";
            this.lblKi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label68
            // 
            this.label68.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label68.Location = new System.Drawing.Point(17, 366);
            this.label68.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(84, 19);
            this.label68.TabIndex = 256;
            this.label68.Text = "A/S Sett";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSectionLoSd
            // 
            this.lblSectionLoSd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblSectionLoSd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSectionLoSd.Location = new System.Drawing.Point(762, 325);
            this.lblSectionLoSd.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSectionLoSd.Name = "lblSectionLoSd";
            this.lblSectionLoSd.Size = new System.Drawing.Size(91, 23);
            this.lblSectionLoSd.TabIndex = 232;
            this.lblSectionLoSd.Text = "-";
            this.lblSectionLoSd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormGPSData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(878, 434);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.lbl60);
            this.Controls.Add(this.lbl61);
            this.Controls.Add(this.lblMaxInt);
            this.Controls.Add(this.lblCntPerDegree);
            this.Controls.Add(this.lblSteerOffset);
            this.Controls.Add(this.lblMinPWM);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.lblKd);
            this.Controls.Add(this.lblKo);
            this.Controls.Add(this.lblPgnHiSs);
            this.Controls.Add(this.lblPgnLoSs);
            this.Controls.Add(this.label64);
            this.Controls.Add(this.label65);
            this.Controls.Add(this.lblKp);
            this.Controls.Add(this.lblKi);
            this.Controls.Add(this.label68);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.lblUTurnSd);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.lblAngleHi);
            this.Controls.Add(this.lblAngleLo);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.lblDistHi);
            this.Controls.Add(this.lblDistLo);
            this.Controls.Add(this.lblPgnHiSd);
            this.Controls.Add(this.lblPgnLoSd);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.lblSectionLoSd);
            this.Controls.Add(this.lblSpdSd);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.lblTree);
            this.Controls.Add(this.lblMachine);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblSpd);
            this.Controls.Add(this.lblUTurn);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblPgnHiRd);
            this.Controls.Add(this.lblPgnLoRd);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblSectionHiByte);
            this.Controls.Add(this.lblSectionLoByte);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblZone);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.lblEasting);
            this.Controls.Add(this.lblNorthing);
            this.Controls.Add(this.tboxSerialFromAutoSteer);
            this.Controls.Add(this.tboxSerialToAutoSteer);
            this.Controls.Add(this.tboxSerialToMachine);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tboxSerialFromMachine);
            this.Controls.Add(this.tboxNMEASerial);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblHDOP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblAltitude);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblSatsTracked);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblFixQuality);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label17);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGPSData";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPS Data";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblFixQuality;
        private System.Windows.Forms.Label lblSatsTracked;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblEasting;
        private System.Windows.Forms.Label lblNorthing;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblHDOP;
        private System.Windows.Forms.TextBox tboxNMEASerial;
        private System.Windows.Forms.TextBox tboxSerialFromMachine;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.TextBox tboxSerialToMachine;
        private System.Windows.Forms.TextBox tboxSerialFromAutoSteer;
        private System.Windows.Forms.TextBox tboxSerialToAutoSteer;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblSectionLoByte;
        private System.Windows.Forms.Label lblSectionHiByte;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblPgnHiRd;
        private System.Windows.Forms.Label lblPgnLoRd;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblSpd;
        private System.Windows.Forms.Label lblUTurn;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblTree;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label lblUTurnSd;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label lblAngleHi;
        private System.Windows.Forms.Label lblAngleLo;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label lblDistHi;
        private System.Windows.Forms.Label lblDistLo;
        private System.Windows.Forms.Label lblPgnHiSd;
        private System.Windows.Forms.Label lblPgnLoSd;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label lblSpdSd;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label lbl60;
        private System.Windows.Forms.Label lbl61;
        private System.Windows.Forms.Label lblMaxInt;
        private System.Windows.Forms.Label lblCntPerDegree;
        private System.Windows.Forms.Label lblSteerOffset;
        private System.Windows.Forms.Label lblMinPWM;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label lblKd;
        private System.Windows.Forms.Label lblKo;
        private System.Windows.Forms.Label lblPgnHiSs;
        private System.Windows.Forms.Label lblPgnLoSs;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label lblKp;
        private System.Windows.Forms.Label lblKi;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label lblSectionLoSd;
    }
}