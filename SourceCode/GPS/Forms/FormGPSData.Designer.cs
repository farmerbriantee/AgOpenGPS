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
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblFixQuality = new System.Windows.Forms.Label();
            this.lblSatsTracked = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblHDOP = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblRoll = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblGPSHeading = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblYawHeading = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblFixHeading = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblEastingField = new System.Windows.Forms.Label();
            this.lblNorthingField = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblHz = new System.Windows.Forms.Label();
            this.lblTram = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTimeSlice = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFrameTime = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(35, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Lat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(183, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(180, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Quality";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(180, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "# Sats";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(232, 69);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 18);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFixQuality
            // 
            this.lblFixQuality.AutoSize = true;
            this.lblFixQuality.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixQuality.Location = new System.Drawing.Point(232, 25);
            this.lblFixQuality.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFixQuality.Name = "lblFixQuality";
            this.lblFixQuality.Size = new System.Drawing.Size(66, 18);
            this.lblFixQuality.TabIndex = 2;
            this.lblFixQuality.Text = "FixQual";
            this.lblFixQuality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSatsTracked
            // 
            this.lblSatsTracked.AutoSize = true;
            this.lblSatsTracked.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatsTracked.Location = new System.Drawing.Point(232, 90);
            this.lblSatsTracked.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSatsTracked.Name = "lblSatsTracked";
            this.lblSatsTracked.Size = new System.Drawing.Size(41, 18);
            this.lblSatsTracked.TabIndex = 4;
            this.lblSatsTracked.Text = "Sats";
            this.lblSatsTracked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.Location = new System.Drawing.Point(64, 25);
            this.lblLatitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(70, 18);
            this.lblLatitude.TabIndex = 12;
            this.lblLatitude.Text = "Latitude";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.Location = new System.Drawing.Point(64, 7);
            this.lblLongitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(82, 18);
            this.lblLongitude.TabIndex = 13;
            this.lblLongitude.Text = "Longitude";
            // 
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltitude.Location = new System.Drawing.Point(232, 49);
            this.lblAltitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(67, 18);
            this.lblAltitude.TabIndex = 14;
            this.lblAltitude.Text = "Altitude";
            this.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(32, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "Lon";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(208, 48);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 18);
            this.label8.TabIndex = 16;
            this.label8.Text = "Alt";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(185, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "HDOP";
            // 
            // lblHDOP
            // 
            this.lblHDOP.AutoSize = true;
            this.lblHDOP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHDOP.Location = new System.Drawing.Point(232, 7);
            this.lblHDOP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHDOP.Name = "lblHDOP";
            this.lblHDOP.Size = new System.Drawing.Size(52, 18);
            this.lblHDOP.TabIndex = 17;
            this.lblHDOP.Text = "HDOP";
            this.lblHDOP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(15, 88);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 18);
            this.label17.TabIndex = 116;
            this.label17.Text = "Speed";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(64, 88);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(54, 18);
            this.lblSpeed.TabIndex = 115;
            this.lblSpeed.Text = "Speed";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRoll
            // 
            this.lblRoll.AutoSize = true;
            this.lblRoll.BackColor = System.Drawing.Color.Transparent;
            this.lblRoll.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRoll.Location = new System.Drawing.Point(371, 7);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(49, 18);
            this.lblRoll.TabIndex = 463;
            this.lblRoll.Text = "-11.2";
            this.lblRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(344, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 18);
            this.label15.TabIndex = 460;
            this.label15.Text = "Roll";
            // 
            // lblGPSHeading
            // 
            this.lblGPSHeading.AutoSize = true;
            this.lblGPSHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblGPSHeading.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPSHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGPSHeading.Location = new System.Drawing.Point(372, 55);
            this.lblGPSHeading.Name = "lblGPSHeading";
            this.lblGPSHeading.Size = new System.Drawing.Size(64, 23);
            this.lblGPSHeading.TabIndex = 462;
            this.lblGPSHeading.Text = "359.3";
            this.lblGPSHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(333, 55);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 23);
            this.label16.TabIndex = 458;
            this.label16.Text = "GPS";
            // 
            // lblYawHeading
            // 
            this.lblYawHeading.AutoSize = true;
            this.lblYawHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblYawHeading.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYawHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblYawHeading.Location = new System.Drawing.Point(372, 81);
            this.lblYawHeading.Name = "lblYawHeading";
            this.lblYawHeading.Size = new System.Drawing.Size(64, 23);
            this.lblYawHeading.TabIndex = 461;
            this.lblYawHeading.Text = "288.8";
            this.lblYawHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(333, 81);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 23);
            this.label18.TabIndex = 459;
            this.label18.Text = "IMU";
            // 
            // lblFixHeading
            // 
            this.lblFixHeading.AutoSize = true;
            this.lblFixHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblFixHeading.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFixHeading.Location = new System.Drawing.Point(372, 29);
            this.lblFixHeading.Name = "lblFixHeading";
            this.lblFixHeading.Size = new System.Drawing.Size(64, 23);
            this.lblFixHeading.TabIndex = 465;
            this.lblFixHeading.Text = "359.3";
            this.lblFixHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(332, 29);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 23);
            this.label20.TabIndex = 464;
            this.label20.Text = "FUZ";
            // 
            // lblEastingField
            // 
            this.lblEastingField.AutoSize = true;
            this.lblEastingField.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEastingField.Location = new System.Drawing.Point(64, 65);
            this.lblEastingField.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEastingField.Name = "lblEastingField";
            this.lblEastingField.Size = new System.Drawing.Size(63, 18);
            this.lblEastingField.TabIndex = 477;
            this.lblEastingField.Text = "Easting";
            // 
            // lblNorthingField
            // 
            this.lblNorthingField.AutoSize = true;
            this.lblNorthingField.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNorthingField.Location = new System.Drawing.Point(64, 47);
            this.lblNorthingField.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNorthingField.Name = "lblNorthingField";
            this.lblNorthingField.Size = new System.Drawing.Size(74, 18);
            this.lblNorthingField.TabIndex = 476;
            this.lblNorthingField.Text = "Northing";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label27.Location = new System.Drawing.Point(14, 65);
            this.label27.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(49, 18);
            this.label27.TabIndex = 475;
            this.label27.Text = "Field E";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label28.Location = new System.Drawing.Point(12, 47);
            this.label28.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(51, 18);
            this.label28.TabIndex = 474;
            this.label28.Text = "Field N";
            // 
            // lblHz
            // 
            this.lblHz.AutoSize = true;
            this.lblHz.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHz.Location = new System.Drawing.Point(64, 146);
            this.lblHz.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHz.Name = "lblHz";
            this.lblHz.Size = new System.Drawing.Size(46, 18);
            this.lblHz.TabIndex = 506;
            this.lblHz.Text = "msec";
            this.lblHz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTram
            // 
            this.lblTram.AutoSize = true;
            this.lblTram.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTram.Location = new System.Drawing.Point(232, 111);
            this.lblTram.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTram.Name = "lblTram";
            this.lblTram.Size = new System.Drawing.Size(18, 18);
            this.lblTram.TabIndex = 507;
            this.lblTram.Text = "4";
            this.lblTram.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(188, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 508;
            this.label5.Text = "Tram";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(41, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 18);
            this.label4.TabIndex = 509;
            this.label4.Text = "Hz";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(9, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 18);
            this.label10.TabIndex = 511;
            this.label10.Text = "Raw Hz";
            // 
            // lblTimeSlice
            // 
            this.lblTimeSlice.AutoSize = true;
            this.lblTimeSlice.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeSlice.Location = new System.Drawing.Point(64, 128);
            this.lblTimeSlice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTimeSlice.Name = "lblTimeSlice";
            this.lblTimeSlice.Size = new System.Drawing.Size(46, 18);
            this.lblTimeSlice.TabIndex = 510;
            this.lblTimeSlice.Text = "msec";
            this.lblTimeSlice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(16, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 18);
            this.label11.TabIndex = 513;
            this.label11.Text = "Frame";
            // 
            // lblFrameTime
            // 
            this.lblFrameTime.AutoSize = true;
            this.lblFrameTime.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrameTime.Location = new System.Drawing.Point(64, 110);
            this.lblFrameTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFrameTime.Name = "lblFrameTime";
            this.lblFrameTime.Size = new System.Drawing.Size(46, 18);
            this.lblFrameTime.TabIndex = 512;
            this.lblFrameTime.Text = "msec";
            this.lblFrameTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(394, 147);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(48, 18);
            this.lblVersion.TabIndex = 514;
            this.lblVersion.Text = "5.6.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(337, 147);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 18);
            this.label13.TabIndex = 515;
            this.label13.Text = "Version";
            // 
            // FormGPSData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(455, 173);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblFrameTime);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTimeSlice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTram);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblHz);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.lblEastingField);
            this.Controls.Add(this.lblNorthingField);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.lblFixHeading);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblRoll);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblGPSHeading);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblYawHeading);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblHDOP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblAltitude);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSatsTracked);
            this.Controls.Add(this.lblFixQuality);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGPSData";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "System Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGPSData_FormClosing);
            this.Load += new System.EventHandler(this.FormGPSData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblFixQuality;
        private System.Windows.Forms.Label lblSatsTracked;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblHDOP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblGPSHeading;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblYawHeading;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblFixHeading;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblEastingField;
        private System.Windows.Forms.Label lblNorthingField;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblHz;
        private System.Windows.Forms.Label lblTram;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTimeSlice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblFrameTime;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label13;
    }
}