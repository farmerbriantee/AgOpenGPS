namespace AgIO
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFixQuality = new System.Windows.Forms.Label();
            this.lblSatsTracked = new System.Windows.Forms.Label();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblHDOP = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblRoll = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblGPSHeading = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.tboxVTG = new System.Windows.Forms.TextBox();
            this.tboxGGA = new System.Windows.Forms.TextBox();
            this.tboxHDT = new System.Windows.Forms.TextBox();
            this.tboxAVR = new System.Windows.Forms.TextBox();
            this.tboxPAOGI = new System.Windows.Forms.TextBox();
            this.tboxHPD = new System.Windows.Forms.TextBox();
            this.lblDualHeading = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxRMC = new System.Windows.Forms.TextBox();
            this.tboxPANDA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblIMUYawRate = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblIMUPitch = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblIMUHeading = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblIMURoll = new System.Windows.Forms.Label();
            this.tboxKSXT = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblLatitude2 = new System.Windows.Forms.Label();
            this.labelLatGPS2 = new System.Windows.Forms.Label();
            this.labelLonGPS2 = new System.Windows.Forms.Label();
            this.lblLongitude2 = new System.Windows.Forms.Label();
            this.tboxGGA2 = new System.Windows.Forms.TextBox();
            this.tboxVTG2 = new System.Windows.Forms.TextBox();
            this.lblGPSHeading2 = new System.Windows.Forms.Label();
            this.labelSpeedGPS2 = new System.Windows.Forms.Label();
            this.lblSpeed2 = new System.Windows.Forms.Label();
            this.labelHDOP2 = new System.Windows.Forms.Label();
            this.lblHDOP2 = new System.Windows.Forms.Label();
            this.lblAltitude2 = new System.Windows.Forms.Label();
            this.labelQualGPS2 = new System.Windows.Forms.Label();
            this.lblSatsTracked2 = new System.Windows.Forms.Label();
            this.lblFixQuality2 = new System.Windows.Forms.Label();
            this.labelSats2 = new System.Windows.Forms.Label();
            this.labelVTG2 = new System.Windows.Forms.Label();
            this.labelAlt2 = new System.Windows.Forms.Label();
            this.labelAntDist = new System.Windows.Forms.Label();
            this.labelDualHead = new System.Windows.Forms.Label();
            this.labelDualRoll = new System.Windows.Forms.Label();
            this.lblAntDist = new System.Windows.Forms.Label();
            this.lblHeadDual = new System.Windows.Forms.Label();
            this.lblRollDual = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.labelAge2 = new System.Windows.Forms.Label();
            this.lblAge2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Quality";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(175, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "# Sats";
            // 
            // lblFixQuality
            // 
            this.lblFixQuality.AutoSize = true;
            this.lblFixQuality.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixQuality.Location = new System.Drawing.Point(52, 79);
            this.lblFixQuality.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFixQuality.Name = "lblFixQuality";
            this.lblFixQuality.Size = new System.Drawing.Size(66, 18);
            this.lblFixQuality.TabIndex = 2;
            this.lblFixQuality.Text = "FixQual";
            this.lblFixQuality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFixQuality.Click += new System.EventHandler(this.lblFixQuality_Click);
            // 
            // lblSatsTracked
            // 
            this.lblSatsTracked.AutoSize = true;
            this.lblSatsTracked.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatsTracked.Location = new System.Drawing.Point(231, 32);
            this.lblSatsTracked.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSatsTracked.Name = "lblSatsTracked";
            this.lblSatsTracked.Size = new System.Drawing.Size(41, 18);
            this.lblSatsTracked.TabIndex = 4;
            this.lblSatsTracked.Text = "Sats";
            this.lblSatsTracked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltitude.Location = new System.Drawing.Point(231, 55);
            this.lblAltitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(67, 18);
            this.lblAltitude.TabIndex = 14;
            this.lblAltitude.Text = "Altitude";
            this.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAltitude.Click += new System.EventHandler(this.lblAltitude_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(175, 55);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 18);
            this.label8.TabIndex = 16;
            this.label8.Text = "Altitude";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(180, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "HDOP";
            // 
            // lblHDOP
            // 
            this.lblHDOP.AutoSize = true;
            this.lblHDOP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHDOP.Location = new System.Drawing.Point(231, 8);
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
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(6, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 18);
            this.label17.TabIndex = 116;
            this.label17.Text = "Speed";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(52, 55);
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
            this.lblRoll.Location = new System.Drawing.Point(356, 55);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(49, 18);
            this.lblRoll.TabIndex = 463;
            this.lblRoll.Text = "-11.2";
            this.lblRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRoll.Click += new System.EventHandler(this.lblRoll_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(448, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 18);
            this.label15.TabIndex = 460;
            this.label15.Text = "Roll";
            // 
            // lblGPSHeading
            // 
            this.lblGPSHeading.AutoSize = true;
            this.lblGPSHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblGPSHeading.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPSHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGPSHeading.Location = new System.Drawing.Point(355, 7);
            this.lblGPSHeading.Name = "lblGPSHeading";
            this.lblGPSHeading.Size = new System.Drawing.Size(54, 19);
            this.lblGPSHeading.TabIndex = 462;
            this.lblGPSHeading.Text = "359.3";
            this.lblGPSHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label29.Location = new System.Drawing.Point(4, 267);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(30, 13);
            this.label29.TabIndex = 496;
            this.label29.Text = "AVR";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(3, 112);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 501;
            this.label19.Text = "GGA";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(5, 205);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 502;
            this.label11.Text = "OGI";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(5, 143);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 13);
            this.label26.TabIndex = 503;
            this.label26.Text = "VTG";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(4, 236);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(30, 13);
            this.label30.TabIndex = 505;
            this.label30.Text = "HDT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(4, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 509;
            this.label4.Text = "HPD";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.Location = new System.Drawing.Point(36, 32);
            this.lblLongitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(82, 18);
            this.lblLongitude.TabIndex = 13;
            this.lblLongitude.Text = "Longitude";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(7, 32);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "Lon";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(7, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Lat";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.Location = new System.Drawing.Point(36, 8);
            this.lblLatitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(70, 18);
            this.lblLatitude.TabIndex = 12;
            this.lblLatitude.Text = "Latitude";
            this.lblLatitude.Click += new System.EventHandler(this.lblLatitude_Click);
            // 
            // tboxVTG
            // 
            this.tboxVTG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxVTG.BackColor = System.Drawing.SystemColors.Window;
            this.tboxVTG.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxVTG.Location = new System.Drawing.Point(35, 139);
            this.tboxVTG.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxVTG.Name = "tboxVTG";
            this.tboxVTG.ReadOnly = true;
            this.tboxVTG.Size = new System.Drawing.Size(513, 21);
            this.tboxVTG.TabIndex = 497;
            this.tboxVTG.Text = "$GPVTG,0,T,034.4,M,1,N,1.852,K";
            // 
            // tboxGGA
            // 
            this.tboxGGA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxGGA.BackColor = System.Drawing.SystemColors.Window;
            this.tboxGGA.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxGGA.Location = new System.Drawing.Point(35, 108);
            this.tboxGGA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxGGA.Name = "tboxGGA";
            this.tboxGGA.ReadOnly = true;
            this.tboxGGA.Size = new System.Drawing.Size(513, 21);
            this.tboxGGA.TabIndex = 498;
            this.tboxGGA.Text = "$GPGGA,055129.00,5326.1729618,N,111,09.6028200,W,4,12,0.9,300,M,46.9,M,,,";
            // 
            // tboxHDT
            // 
            this.tboxHDT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxHDT.BackColor = System.Drawing.SystemColors.Window;
            this.tboxHDT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxHDT.Location = new System.Drawing.Point(35, 232);
            this.tboxHDT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxHDT.Name = "tboxHDT";
            this.tboxHDT.ReadOnly = true;
            this.tboxHDT.Size = new System.Drawing.Size(513, 21);
            this.tboxHDT.TabIndex = 499;
            this.tboxHDT.Text = "$GNHDT,123.456,T * 00";
            // 
            // tboxAVR
            // 
            this.tboxAVR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxAVR.BackColor = System.Drawing.SystemColors.Window;
            this.tboxAVR.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxAVR.Location = new System.Drawing.Point(35, 263);
            this.tboxAVR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxAVR.Name = "tboxAVR";
            this.tboxAVR.ReadOnly = true;
            this.tboxAVR.Size = new System.Drawing.Size(513, 21);
            this.tboxAVR.TabIndex = 500;
            this.tboxAVR.Text = "$PTNL,AVR,145331.50,+35.9990,Yaw,-7.8209,Tilt,-0.4305,Roll,444.232,3,1.2,17 * 03";
            // 
            // tboxPAOGI
            // 
            this.tboxPAOGI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxPAOGI.BackColor = System.Drawing.SystemColors.Window;
            this.tboxPAOGI.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxPAOGI.Location = new System.Drawing.Point(35, 201);
            this.tboxPAOGI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxPAOGI.Name = "tboxPAOGI";
            this.tboxPAOGI.ReadOnly = true;
            this.tboxPAOGI.Size = new System.Drawing.Size(513, 21);
            this.tboxPAOGI.TabIndex = 504;
            this.tboxPAOGI.Text = "$PAOGI,055129.00,5326.1729618,N,111,09.6028200,W,4,12,0.9,300,M,46.9,M,,,";
            // 
            // tboxHPD
            // 
            this.tboxHPD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxHPD.BackColor = System.Drawing.SystemColors.Window;
            this.tboxHPD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxHPD.Location = new System.Drawing.Point(35, 294);
            this.tboxHPD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxHPD.Name = "tboxHPD";
            this.tboxHPD.ReadOnly = true;
            this.tboxHPD.Size = new System.Drawing.Size(513, 21);
            this.tboxHPD.TabIndex = 510;
            this.tboxHPD.Text = "$PTNL,AVR,145331.50,+35.9990,Yaw,-7.8209,Tilt,-0.4305,Roll,444.232,3,1.2,17 * 03";
            // 
            // lblDualHeading
            // 
            this.lblDualHeading.AutoSize = true;
            this.lblDualHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblDualHeading.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDualHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDualHeading.Location = new System.Drawing.Point(355, 31);
            this.lblDualHeading.Name = "lblDualHeading";
            this.lblDualHeading.Size = new System.Drawing.Size(54, 19);
            this.lblDualHeading.TabIndex = 514;
            this.lblDualHeading.Text = "359.3";
            this.lblDualHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(316, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 18);
            this.label10.TabIndex = 513;
            this.label10.Text = "Dual";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(323, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 18);
            this.label1.TabIndex = 525;
            this.label1.Text = "Roll";
            // 
            // tboxRMC
            // 
            this.tboxRMC.Location = new System.Drawing.Point(0, 0);
            this.tboxRMC.Name = "tboxRMC";
            this.tboxRMC.Size = new System.Drawing.Size(100, 20);
            this.tboxRMC.TabIndex = 0;
            // 
            // tboxPANDA
            // 
            this.tboxPANDA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxPANDA.BackColor = System.Drawing.SystemColors.Window;
            this.tboxPANDA.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxPANDA.Location = new System.Drawing.Point(36, 170);
            this.tboxPANDA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxPANDA.Name = "tboxPANDA";
            this.tboxPANDA.ReadOnly = true;
            this.tboxPANDA.Size = new System.Drawing.Size(512, 21);
            this.tboxPANDA.TabIndex = 518;
            this.tboxPANDA.Text = "$PANDA,145331.50,+35.9990,Yaw,-7.8209,Tilt,-0.4305,Roll,444.232,3,1.2,17 * 03";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(5, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 517;
            this.label5.Text = "NDA";
            // 
            // lblIMUYawRate
            // 
            this.lblIMUYawRate.AutoSize = true;
            this.lblIMUYawRate.BackColor = System.Drawing.Color.Transparent;
            this.lblIMUYawRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMUYawRate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblIMUYawRate.Location = new System.Drawing.Point(485, 79);
            this.lblIMUYawRate.Name = "lblIMUYawRate";
            this.lblIMUYawRate.Size = new System.Drawing.Size(49, 18);
            this.lblIMUYawRate.TabIndex = 520;
            this.lblIMUYawRate.Text = "-11.2";
            this.lblIMUYawRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIMUYawRate.Click += new System.EventHandler(this.lblIMUYawRate_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(411, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 18);
            this.label14.TabIndex = 519;
            this.label14.Text = "YawRate";
            // 
            // lblIMUPitch
            // 
            this.lblIMUPitch.AutoSize = true;
            this.lblIMUPitch.BackColor = System.Drawing.Color.Transparent;
            this.lblIMUPitch.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMUPitch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblIMUPitch.Location = new System.Drawing.Point(485, 55);
            this.lblIMUPitch.Name = "lblIMUPitch";
            this.lblIMUPitch.Size = new System.Drawing.Size(49, 18);
            this.lblIMUPitch.TabIndex = 522;
            this.lblIMUPitch.Text = "-11.2";
            this.lblIMUPitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIMUPitch.Click += new System.EventHandler(this.lblIMUPitch_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(439, 55);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 18);
            this.label20.TabIndex = 521;
            this.label20.Text = "Pitch";
            // 
            // lblIMUHeading
            // 
            this.lblIMUHeading.AutoSize = true;
            this.lblIMUHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblIMUHeading.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMUHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblIMUHeading.Location = new System.Drawing.Point(485, 8);
            this.lblIMUHeading.Name = "lblIMUHeading";
            this.lblIMUHeading.Size = new System.Drawing.Size(49, 18);
            this.lblIMUHeading.TabIndex = 524;
            this.lblIMUHeading.Text = "-11.2";
            this.lblIMUHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIMUHeading.Click += new System.EventHandler(this.lblIMUHeading_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(441, 8);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(36, 18);
            this.label22.TabIndex = 523;
            this.label22.Text = "Yaw";
            // 
            // lblIMURoll
            // 
            this.lblIMURoll.AutoSize = true;
            this.lblIMURoll.BackColor = System.Drawing.Color.Transparent;
            this.lblIMURoll.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMURoll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblIMURoll.Location = new System.Drawing.Point(485, 32);
            this.lblIMURoll.Name = "lblIMURoll";
            this.lblIMURoll.Size = new System.Drawing.Size(49, 18);
            this.lblIMURoll.TabIndex = 526;
            this.lblIMURoll.Text = "-11.2";
            this.lblIMURoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIMURoll.Click += new System.EventHandler(this.lblIMURoll_Click);
            // 
            // tboxKSXT
            // 
            this.tboxKSXT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxKSXT.BackColor = System.Drawing.SystemColors.Window;
            this.tboxKSXT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxKSXT.Location = new System.Drawing.Point(35, 327);
            this.tboxKSXT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxKSXT.Name = "tboxKSXT";
            this.tboxKSXT.ReadOnly = true;
            this.tboxKSXT.Size = new System.Drawing.Size(513, 21);
            this.tboxKSXT.TabIndex = 528;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(4, 330);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 13);
            this.label13.TabIndex = 527;
            this.label13.Text = "SXT";
            // 
            // lblLatitude2
            // 
            this.lblLatitude2.AutoSize = true;
            this.lblLatitude2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude2.Location = new System.Drawing.Point(612, 8);
            this.lblLatitude2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLatitude2.Name = "lblLatitude2";
            this.lblLatitude2.Size = new System.Drawing.Size(80, 18);
            this.lblLatitude2.TabIndex = 524;
            this.lblLatitude2.Text = "Latitude2";
            // 
            // labelLatGPS2
            // 
            this.labelLatGPS2.AutoSize = true;
            this.labelLatGPS2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLatGPS2.ForeColor = System.Drawing.Color.Black;
            this.labelLatGPS2.Location = new System.Drawing.Point(582, 8);
            this.labelLatGPS2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelLatGPS2.Name = "labelLatGPS2";
            this.labelLatGPS2.Size = new System.Drawing.Size(28, 18);
            this.labelLatGPS2.TabIndex = 521;
            this.labelLatGPS2.Text = "Lat";
            // 
            // labelLonGPS2
            // 
            this.labelLonGPS2.AutoSize = true;
            this.labelLonGPS2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLonGPS2.ForeColor = System.Drawing.Color.Black;
            this.labelLonGPS2.Location = new System.Drawing.Point(579, 32);
            this.labelLonGPS2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelLonGPS2.Name = "labelLonGPS2";
            this.labelLonGPS2.Size = new System.Drawing.Size(31, 18);
            this.labelLonGPS2.TabIndex = 527;
            this.labelLonGPS2.Text = "Lon";
            // 
            // lblLongitude2
            // 
            this.lblLongitude2.AutoSize = true;
            this.lblLongitude2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude2.Location = new System.Drawing.Point(612, 32);
            this.lblLongitude2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLongitude2.Name = "lblLongitude2";
            this.lblLongitude2.Size = new System.Drawing.Size(92, 18);
            this.lblLongitude2.TabIndex = 525;
            this.lblLongitude2.Text = "Longitude2";
            // 
            // tboxGGA2
            // 
            this.tboxGGA2.BackColor = System.Drawing.SystemColors.Window;
            this.tboxGGA2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxGGA2.Location = new System.Drawing.Point(559, 108);
            this.tboxGGA2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxGGA2.Name = "tboxGGA2";
            this.tboxGGA2.ReadOnly = true;
            this.tboxGGA2.Size = new System.Drawing.Size(513, 21);
            this.tboxGGA2.TabIndex = 539;
            this.tboxGGA2.Text = "$GPGGA,055129.00,5326.1729618,N,111,09.6028200,W,4,12,0.9,300,M,46.9,M,,,";
            this.tboxGGA2.TextChanged += new System.EventHandler(this.tboxGGA2_TextChanged);
            // 
            // tboxVTG2
            // 
            this.tboxVTG2.BackColor = System.Drawing.SystemColors.Window;
            this.tboxVTG2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxVTG2.Location = new System.Drawing.Point(559, 139);
            this.tboxVTG2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxVTG2.Name = "tboxVTG2";
            this.tboxVTG2.ReadOnly = true;
            this.tboxVTG2.Size = new System.Drawing.Size(513, 21);
            this.tboxVTG2.TabIndex = 538;
            this.tboxVTG2.Text = "$GPVTG,0,T,034.4,M,1,N,1.852,K";
            // 
            // lblGPSHeading2
            // 
            this.lblGPSHeading2.AutoSize = true;
            this.lblGPSHeading2.BackColor = System.Drawing.Color.Transparent;
            this.lblGPSHeading2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPSHeading2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGPSHeading2.Location = new System.Drawing.Point(999, 7);
            this.lblGPSHeading2.Name = "lblGPSHeading2";
            this.lblGPSHeading2.Size = new System.Drawing.Size(54, 19);
            this.lblGPSHeading2.TabIndex = 535;
            this.lblGPSHeading2.Text = "359.3";
            this.lblGPSHeading2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSpeedGPS2
            // 
            this.labelSpeedGPS2.AutoSize = true;
            this.labelSpeedGPS2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeedGPS2.ForeColor = System.Drawing.Color.Black;
            this.labelSpeedGPS2.Location = new System.Drawing.Point(579, 55);
            this.labelSpeedGPS2.Name = "labelSpeedGPS2";
            this.labelSpeedGPS2.Size = new System.Drawing.Size(48, 18);
            this.labelSpeedGPS2.TabIndex = 532;
            this.labelSpeedGPS2.Text = "Speed";
            // 
            // lblSpeed2
            // 
            this.lblSpeed2.AutoSize = true;
            this.lblSpeed2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed2.Location = new System.Drawing.Point(628, 55);
            this.lblSpeed2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSpeed2.Name = "lblSpeed2";
            this.lblSpeed2.Size = new System.Drawing.Size(64, 18);
            this.lblSpeed2.TabIndex = 531;
            this.lblSpeed2.Text = "Speed2";
            this.lblSpeed2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelHDOP2
            // 
            this.labelHDOP2.AutoSize = true;
            this.labelHDOP2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHDOP2.ForeColor = System.Drawing.Color.Black;
            this.labelHDOP2.Location = new System.Drawing.Point(759, 8);
            this.labelHDOP2.Name = "labelHDOP2";
            this.labelHDOP2.Size = new System.Drawing.Size(47, 18);
            this.labelHDOP2.TabIndex = 530;
            this.labelHDOP2.Text = "HDOP";
            // 
            // lblHDOP2
            // 
            this.lblHDOP2.AutoSize = true;
            this.lblHDOP2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHDOP2.Location = new System.Drawing.Point(807, 8);
            this.lblHDOP2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHDOP2.Name = "lblHDOP2";
            this.lblHDOP2.Size = new System.Drawing.Size(62, 18);
            this.lblHDOP2.TabIndex = 529;
            this.lblHDOP2.Text = "HDOP2";
            this.lblHDOP2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAltitude2
            // 
            this.lblAltitude2.AutoSize = true;
            this.lblAltitude2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltitude2.Location = new System.Drawing.Point(807, 55);
            this.lblAltitude2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAltitude2.Name = "lblAltitude2";
            this.lblAltitude2.Size = new System.Drawing.Size(77, 18);
            this.lblAltitude2.TabIndex = 526;
            this.lblAltitude2.Text = "Altitude2";
            this.lblAltitude2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelQualGPS2
            // 
            this.labelQualGPS2.AutoSize = true;
            this.labelQualGPS2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQualGPS2.ForeColor = System.Drawing.Color.Black;
            this.labelQualGPS2.Location = new System.Drawing.Point(575, 79);
            this.labelQualGPS2.Name = "labelQualGPS2";
            this.labelQualGPS2.Size = new System.Drawing.Size(52, 18);
            this.labelQualGPS2.TabIndex = 522;
            this.labelQualGPS2.Text = "Quality";
            // 
            // lblSatsTracked2
            // 
            this.lblSatsTracked2.AutoSize = true;
            this.lblSatsTracked2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatsTracked2.Location = new System.Drawing.Point(807, 32);
            this.lblSatsTracked2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSatsTracked2.Name = "lblSatsTracked2";
            this.lblSatsTracked2.Size = new System.Drawing.Size(51, 18);
            this.lblSatsTracked2.TabIndex = 520;
            this.lblSatsTracked2.Text = "Sats2";
            this.lblSatsTracked2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFixQuality2
            // 
            this.lblFixQuality2.AutoSize = true;
            this.lblFixQuality2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixQuality2.Location = new System.Drawing.Point(628, 79);
            this.lblFixQuality2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFixQuality2.Name = "lblFixQuality2";
            this.lblFixQuality2.Size = new System.Drawing.Size(76, 18);
            this.lblFixQuality2.TabIndex = 519;
            this.lblFixQuality2.Text = "FixQual2";
            this.lblFixQuality2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSats2
            // 
            this.labelSats2.AutoSize = true;
            this.labelSats2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSats2.ForeColor = System.Drawing.Color.Black;
            this.labelSats2.Location = new System.Drawing.Point(754, 32);
            this.labelSats2.Name = "labelSats2";
            this.labelSats2.Size = new System.Drawing.Size(52, 18);
            this.labelSats2.TabIndex = 523;
            this.labelSats2.Text = "# Sats";
            // 
            // labelVTG2
            // 
            this.labelVTG2.AutoSize = true;
            this.labelVTG2.BackColor = System.Drawing.Color.Transparent;
            this.labelVTG2.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.labelVTG2.ForeColor = System.Drawing.Color.Black;
            this.labelVTG2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelVTG2.Location = new System.Drawing.Point(956, 8);
            this.labelVTG2.Name = "labelVTG2";
            this.labelVTG2.Size = new System.Drawing.Size(37, 18);
            this.labelVTG2.TabIndex = 533;
            this.labelVTG2.Text = "VTG";
            // 
            // labelAlt2
            // 
            this.labelAlt2.AutoSize = true;
            this.labelAlt2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlt2.ForeColor = System.Drawing.Color.Black;
            this.labelAlt2.Location = new System.Drawing.Point(751, 55);
            this.labelAlt2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelAlt2.Name = "labelAlt2";
            this.labelAlt2.Size = new System.Drawing.Size(55, 18);
            this.labelAlt2.TabIndex = 528;
            this.labelAlt2.Text = "Altitude";
            // 
            // labelAntDist
            // 
            this.labelAntDist.AutoSize = true;
            this.labelAntDist.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAntDist.ForeColor = System.Drawing.Color.Black;
            this.labelAntDist.Location = new System.Drawing.Point(897, 32);
            this.labelAntDist.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelAntDist.Name = "labelAntDist";
            this.labelAntDist.Size = new System.Drawing.Size(96, 18);
            this.labelAntDist.TabIndex = 555;
            this.labelAntDist.Text = "Antenna Dist.";
            this.labelAntDist.Click += new System.EventHandler(this.label13_Click);
            // 
            // labelDualHead
            // 
            this.labelDualHead.AutoSize = true;
            this.labelDualHead.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDualHead.ForeColor = System.Drawing.Color.Black;
            this.labelDualHead.Location = new System.Drawing.Point(891, 55);
            this.labelDualHead.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDualHead.Name = "labelDualHead";
            this.labelDualHead.Size = new System.Drawing.Size(102, 18);
            this.labelDualHead.TabIndex = 556;
            this.labelDualHead.Text = "Heading (fus.)";
            // 
            // labelDualRoll
            // 
            this.labelDualRoll.AutoSize = true;
            this.labelDualRoll.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDualRoll.ForeColor = System.Drawing.Color.Black;
            this.labelDualRoll.Location = new System.Drawing.Point(909, 79);
            this.labelDualRoll.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDualRoll.Name = "labelDualRoll";
            this.labelDualRoll.Size = new System.Drawing.Size(84, 18);
            this.labelDualRoll.TabIndex = 557;
            this.labelDualRoll.Text = "Roll (fusion)";
            this.labelDualRoll.Click += new System.EventHandler(this.label20_Click);
            // 
            // lblAntDist
            // 
            this.lblAntDist.AutoSize = true;
            this.lblAntDist.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAntDist.Location = new System.Drawing.Point(1000, 32);
            this.lblAntDist.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAntDist.Name = "lblAntDist";
            this.lblAntDist.Size = new System.Drawing.Size(63, 18);
            this.lblAntDist.TabIndex = 558;
            this.lblAntDist.Text = "AntDist";
            this.lblAntDist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHeadDual
            // 
            this.lblHeadDual.AutoSize = true;
            this.lblHeadDual.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadDual.Location = new System.Drawing.Point(1000, 55);
            this.lblHeadDual.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHeadDual.Name = "lblHeadDual";
            this.lblHeadDual.Size = new System.Drawing.Size(80, 18);
            this.lblHeadDual.TabIndex = 559;
            this.lblHeadDual.Text = "HeadDual";
            this.lblHeadDual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRollDual
            // 
            this.lblRollDual.AutoSize = true;
            this.lblRollDual.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRollDual.Location = new System.Drawing.Point(1000, 79);
            this.lblRollDual.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRollDual.Name = "lblRollDual";
            this.lblRollDual.Size = new System.Drawing.Size(72, 18);
            this.lblRollDual.TabIndex = 560;
            this.lblRollDual.Text = "RollDual";
            this.lblRollDual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(315, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 18);
            this.label12.TabIndex = 561;
            this.label12.Text = "VTG";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(231, 79);
            this.lblAge.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(36, 18);
            this.lblAge.TabIndex = 562;
            this.lblAge.Text = "Age";
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAge.ForeColor = System.Drawing.Color.Black;
            this.labelAge.Location = new System.Drawing.Point(194, 79);
            this.labelAge.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(33, 18);
            this.labelAge.TabIndex = 563;
            this.labelAge.Text = "Age";
            this.labelAge.Click += new System.EventHandler(this.label16_Click);
            // 
            // labelAge2
            // 
            this.labelAge2.AutoSize = true;
            this.labelAge2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAge2.ForeColor = System.Drawing.Color.Black;
            this.labelAge2.Location = new System.Drawing.Point(773, 79);
            this.labelAge2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelAge2.Name = "labelAge2";
            this.labelAge2.Size = new System.Drawing.Size(33, 18);
            this.labelAge2.TabIndex = 565;
            this.labelAge2.Text = "Age";
            // 
            // lblAge2
            // 
            this.lblAge2.AutoSize = true;
            this.lblAge2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge2.Location = new System.Drawing.Point(807, 79);
            this.lblAge2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAge2.Name = "lblAge2";
            this.lblAge2.Size = new System.Drawing.Size(46, 18);
            this.lblAge2.TabIndex = 564;
            this.lblAge2.Text = "Age2";
            this.lblAge2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormGPSData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1085, 357);
            this.Controls.Add(this.labelAge2);
            this.Controls.Add(this.lblAge2);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tboxKSXT);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblIMURoll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblIMUHeading);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblIMUPitch);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblIMUYawRate);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblRollDual);
            this.Controls.Add(this.lblHeadDual);
            this.Controls.Add(this.lblAntDist);
            this.Controls.Add(this.labelDualRoll);
            this.Controls.Add(this.labelDualHead);
            this.Controls.Add(this.labelAntDist);
            this.Controls.Add(this.lblLatitude2);
            this.Controls.Add(this.labelLatGPS2);
            this.Controls.Add(this.labelLonGPS2);
            this.Controls.Add(this.lblLongitude2);
            this.Controls.Add(this.tboxGGA2);
            this.Controls.Add(this.tboxVTG2);
            this.Controls.Add(this.lblGPSHeading2);
            this.Controls.Add(this.labelSpeedGPS2);
            this.Controls.Add(this.lblSpeed2);
            this.Controls.Add(this.labelHDOP2);
            this.Controls.Add(this.lblHDOP2);
            this.Controls.Add(this.lblAltitude2);
            this.Controls.Add(this.labelQualGPS2);
            this.Controls.Add(this.lblSatsTracked2);
            this.Controls.Add(this.lblFixQuality2);
            this.Controls.Add(this.labelSats2);
            this.Controls.Add(this.labelVTG2);
            this.Controls.Add(this.labelAlt2);
            this.Controls.Add(this.tboxPANDA);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDualHeading);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tboxHPD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tboxPAOGI);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tboxAVR);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.tboxHDT);
            this.Controls.Add(this.tboxGGA);
            this.Controls.Add(this.tboxVTG);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.lblRoll);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblGPSHeading);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblHDOP);
            this.Controls.Add(this.lblAltitude);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSatsTracked);
            this.Controls.Add(this.lblFixQuality);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGPSData";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GPS Data Overview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGPSData_FormClosing);
            this.Load += new System.EventHandler(this.FormGPSData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFixQuality;
        private System.Windows.Forms.Label lblSatsTracked;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblHDOP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblGPSHeading;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.TextBox tboxVTG;
        private System.Windows.Forms.TextBox tboxGGA;
        private System.Windows.Forms.TextBox tboxHDT;
        private System.Windows.Forms.TextBox tboxAVR;
        private System.Windows.Forms.TextBox tboxPAOGI;
        private System.Windows.Forms.TextBox tboxHPD;
        private System.Windows.Forms.Label lblDualHeading;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tboxPANDA;
        private System.Windows.Forms.TextBox tboxRMC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblIMUYawRate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblIMUPitch;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblIMUHeading;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIMURoll;
        private System.Windows.Forms.TextBox tboxKSXT;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblLatitude2;
        private System.Windows.Forms.Label labelLatGPS2;
        private System.Windows.Forms.Label labelLonGPS2;
        private System.Windows.Forms.Label lblLongitude2;
        private System.Windows.Forms.TextBox tboxGGA2;
        private System.Windows.Forms.TextBox tboxVTG2;
        private System.Windows.Forms.Label lblGPSHeading2;
        private System.Windows.Forms.Label labelSpeedGPS2;
        private System.Windows.Forms.Label lblSpeed2;
        private System.Windows.Forms.Label labelHDOP2;
        private System.Windows.Forms.Label lblHDOP2;
        private System.Windows.Forms.Label lblAltitude2;
        private System.Windows.Forms.Label labelQualGPS2;
        private System.Windows.Forms.Label lblSatsTracked2;
        private System.Windows.Forms.Label lblFixQuality2;
        private System.Windows.Forms.Label labelSats2;
        private System.Windows.Forms.Label labelVTG2;
        private System.Windows.Forms.Label labelAlt2;
        private System.Windows.Forms.Label labelAntDist;
        private System.Windows.Forms.Label labelDualHead;
        private System.Windows.Forms.Label labelDualRoll;
        private System.Windows.Forms.Label lblAntDist;
        private System.Windows.Forms.Label lblHeadDual;
        private System.Windows.Forms.Label lblRollDual;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.Label labelAge2;
        private System.Windows.Forms.Label lblAge2;
    }
}