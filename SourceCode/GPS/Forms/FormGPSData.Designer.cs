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
            this.button1 = new System.Windows.Forms.Button();
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
            this.tboxSerialFromRelay = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblZone = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tboxSerialToRelay = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tboxSerialFromAutoSteer = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tboxSerialToAutoSteer = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnPPlus = new System.Windows.Forms.Button();
            this.btnDPlus = new System.Windows.Forms.Button();
            this.btnIPlus = new System.Windows.Forms.Button();
            this.btnIMinus = new System.Windows.Forms.Button();
            this.btnDMinus = new System.Windows.Forms.Button();
            this.btnPMinus = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnOMinus = new System.Windows.Forms.Button();
            this.btnOPlus = new System.Windows.Forms.Button();
            this.lblPValue = new System.Windows.Forms.Label();
            this.lblIValue = new System.Windows.Forms.Label();
            this.lblDValue = new System.Windows.Forms.Label();
            this.lblOValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(507, 355);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 63);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(236, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Northing";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(245, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Easting";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(240, 87);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Latitude";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(41, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fix Quality";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(8, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "# Satellites";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(115, 22);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(58, 23);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFixQuality
            // 
            this.lblFixQuality.AutoSize = true;
            this.lblFixQuality.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixQuality.Location = new System.Drawing.Point(115, 48);
            this.lblFixQuality.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFixQuality.Name = "lblFixQuality";
            this.lblFixQuality.Size = new System.Drawing.Size(68, 23);
            this.lblFixQuality.TabIndex = 2;
            this.lblFixQuality.Text = "FixQual";
            this.lblFixQuality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSatsTracked
            // 
            this.lblSatsTracked.AutoSize = true;
            this.lblSatsTracked.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatsTracked.Location = new System.Drawing.Point(115, 74);
            this.lblSatsTracked.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSatsTracked.Name = "lblSatsTracked";
            this.lblSatsTracked.Size = new System.Drawing.Size(43, 23);
            this.lblSatsTracked.TabIndex = 4;
            this.lblSatsTracked.Text = "Sats";
            this.lblSatsTracked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.Location = new System.Drawing.Point(329, 87);
            this.lblLatitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(72, 23);
            this.lblLatitude.TabIndex = 12;
            this.lblLatitude.Text = "Latitude";
            // 
            // lblEasting
            // 
            this.lblEasting.AutoSize = true;
            this.lblEasting.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasting.Location = new System.Drawing.Point(329, 57);
            this.lblEasting.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEasting.Name = "lblEasting";
            this.lblEasting.Size = new System.Drawing.Size(67, 23);
            this.lblEasting.TabIndex = 11;
            this.lblEasting.Text = "Easting";
            // 
            // lblNorthing
            // 
            this.lblNorthing.AutoSize = true;
            this.lblNorthing.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNorthing.Location = new System.Drawing.Point(329, 33);
            this.lblNorthing.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNorthing.Name = "lblNorthing";
            this.lblNorthing.Size = new System.Drawing.Size(76, 23);
            this.lblNorthing.TabIndex = 10;
            this.lblNorthing.Text = "Northing";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.Location = new System.Drawing.Point(329, 112);
            this.lblLongitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(88, 23);
            this.lblLongitude.TabIndex = 13;
            this.lblLongitude.Text = "Longitude";
            // 
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltitude.Location = new System.Drawing.Point(328, 137);
            this.lblAltitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(68, 23);
            this.lblAltitude.TabIndex = 14;
            this.lblAltitude.Text = "Altitude";
            this.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(220, 112);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Longitiude";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(244, 137);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 23);
            this.label8.TabIndex = 16;
            this.label8.Text = "Altitude";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(45, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 23);
            this.label9.TabIndex = 18;
            this.label9.Text = "HDOP";
            // 
            // lblHDOP
            // 
            this.lblHDOP.AutoSize = true;
            this.lblHDOP.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHDOP.Location = new System.Drawing.Point(115, 100);
            this.lblHDOP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHDOP.Name = "lblHDOP";
            this.lblHDOP.Size = new System.Drawing.Size(54, 23);
            this.lblHDOP.TabIndex = 17;
            this.lblHDOP.Text = "HDOP";
            this.lblHDOP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tboxNMEASerial
            // 
            this.tboxNMEASerial.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxNMEASerial.Location = new System.Drawing.Point(-8, 168);
            this.tboxNMEASerial.Multiline = true;
            this.tboxNMEASerial.Name = "tboxNMEASerial";
            this.tboxNMEASerial.ReadOnly = true;
            this.tboxNMEASerial.Size = new System.Drawing.Size(435, 60);
            this.tboxNMEASerial.TabIndex = 107;
            // 
            // tboxSerialFromRelay
            // 
            this.tboxSerialFromRelay.BackColor = System.Drawing.SystemColors.Control;
            this.tboxSerialFromRelay.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSerialFromRelay.Location = new System.Drawing.Point(60, 292);
            this.tboxSerialFromRelay.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tboxSerialFromRelay.Name = "tboxSerialFromRelay";
            this.tboxSerialFromRelay.ReadOnly = true;
            this.tboxSerialFromRelay.Size = new System.Drawing.Size(367, 29);
            this.tboxSerialFromRelay.TabIndex = 108;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(16, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 23);
            this.label10.TabIndex = 110;
            this.label10.Text = "NMEA Serial";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(1, 299);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 23);
            this.label12.TabIndex = 112;
            this.label12.Text = "Frm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(263, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 23);
            this.label11.TabIndex = 114;
            this.label11.Text = "Zone";
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZone.Location = new System.Drawing.Point(329, 9);
            this.lblZone.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(49, 23);
            this.lblZone.TabIndex = 113;
            this.lblZone.Text = "Zone";
            this.lblZone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(11, 265);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 23);
            this.label13.TabIndex = 116;
            this.label13.Text = "To";
            // 
            // tboxSerialToRelay
            // 
            this.tboxSerialToRelay.BackColor = System.Drawing.SystemColors.Control;
            this.tboxSerialToRelay.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSerialToRelay.Location = new System.Drawing.Point(60, 260);
            this.tboxSerialToRelay.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tboxSerialToRelay.Name = "tboxSerialToRelay";
            this.tboxSerialToRelay.ReadOnly = true;
            this.tboxSerialToRelay.Size = new System.Drawing.Size(366, 29);
            this.tboxSerialToRelay.TabIndex = 115;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(1, 391);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 23);
            this.label14.TabIndex = 120;
            this.label14.Text = "Frm";
            // 
            // tboxSerialFromAutoSteer
            // 
            this.tboxSerialFromAutoSteer.BackColor = System.Drawing.SystemColors.Control;
            this.tboxSerialFromAutoSteer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSerialFromAutoSteer.Location = new System.Drawing.Point(60, 387);
            this.tboxSerialFromAutoSteer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tboxSerialFromAutoSteer.Name = "tboxSerialFromAutoSteer";
            this.tboxSerialFromAutoSteer.ReadOnly = true;
            this.tboxSerialFromAutoSteer.Size = new System.Drawing.Size(432, 29);
            this.tboxSerialFromAutoSteer.TabIndex = 119;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(11, 363);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 23);
            this.label15.TabIndex = 118;
            this.label15.Text = "To";
            // 
            // tboxSerialToAutoSteer
            // 
            this.tboxSerialToAutoSteer.BackColor = System.Drawing.SystemColors.Control;
            this.tboxSerialToAutoSteer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSerialToAutoSteer.Location = new System.Drawing.Point(60, 355);
            this.tboxSerialToAutoSteer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tboxSerialToAutoSteer.Name = "tboxSerialToAutoSteer";
            this.tboxSerialToAutoSteer.ReadOnly = true;
            this.tboxSerialToAutoSteer.Size = new System.Drawing.Size(433, 29);
            this.tboxSerialToAutoSteer.TabIndex = 117;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label16.Location = new System.Drawing.Point(125, 235);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 23);
            this.label16.TabIndex = 121;
            this.label16.Text = "Section Relay";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(125, 329);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 23);
            this.label17.TabIndex = 122;
            this.label17.Text = "AutoSteer";
            // 
            // btnPPlus
            // 
            this.btnPPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPPlus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPPlus.Location = new System.Drawing.Point(459, 35);
            this.btnPPlus.Name = "btnPPlus";
            this.btnPPlus.Size = new System.Drawing.Size(62, 36);
            this.btnPPlus.TabIndex = 123;
            this.btnPPlus.Text = "+";
            this.btnPPlus.UseVisualStyleBackColor = true;
            this.btnPPlus.Click += new System.EventHandler(this.btnPPlus_Click);
            // 
            // btnDPlus
            // 
            this.btnDPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDPlus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDPlus.Location = new System.Drawing.Point(459, 199);
            this.btnDPlus.Name = "btnDPlus";
            this.btnDPlus.Size = new System.Drawing.Size(62, 36);
            this.btnDPlus.TabIndex = 124;
            this.btnDPlus.Text = "+";
            this.btnDPlus.UseVisualStyleBackColor = true;
            this.btnDPlus.Click += new System.EventHandler(this.btnDPlus_Click);
            // 
            // btnIPlus
            // 
            this.btnIPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIPlus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIPlus.Location = new System.Drawing.Point(459, 116);
            this.btnIPlus.Name = "btnIPlus";
            this.btnIPlus.Size = new System.Drawing.Size(62, 36);
            this.btnIPlus.TabIndex = 125;
            this.btnIPlus.Text = "+";
            this.btnIPlus.UseVisualStyleBackColor = true;
            this.btnIPlus.Click += new System.EventHandler(this.btnIPlus_Click);
            // 
            // btnIMinus
            // 
            this.btnIMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIMinus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIMinus.Location = new System.Drawing.Point(534, 117);
            this.btnIMinus.Name = "btnIMinus";
            this.btnIMinus.Size = new System.Drawing.Size(62, 36);
            this.btnIMinus.TabIndex = 128;
            this.btnIMinus.Text = "-";
            this.btnIMinus.UseVisualStyleBackColor = true;
            this.btnIMinus.Click += new System.EventHandler(this.btnIMinus_Click);
            // 
            // btnDMinus
            // 
            this.btnDMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDMinus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDMinus.Location = new System.Drawing.Point(534, 199);
            this.btnDMinus.Name = "btnDMinus";
            this.btnDMinus.Size = new System.Drawing.Size(62, 36);
            this.btnDMinus.TabIndex = 127;
            this.btnDMinus.Text = "-";
            this.btnDMinus.UseVisualStyleBackColor = true;
            this.btnDMinus.Click += new System.EventHandler(this.btnDMinus_Click);
            // 
            // btnPMinus
            // 
            this.btnPMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPMinus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMinus.Location = new System.Drawing.Point(534, 35);
            this.btnPMinus.Name = "btnPMinus";
            this.btnPMinus.Size = new System.Drawing.Size(62, 36);
            this.btnPMinus.TabIndex = 126;
            this.btnPMinus.Text = "-";
            this.btnPMinus.UseVisualStyleBackColor = true;
            this.btnPMinus.Click += new System.EventHandler(this.btnPMinus_Click);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(496, 175);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(34, 23);
            this.label18.TabIndex = 129;
            this.label18.Text = "D =";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(496, 92);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 23);
            this.label19.TabIndex = 130;
            this.label19.Text = "I =";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(496, 11);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(33, 23);
            this.label20.TabIndex = 131;
            this.label20.Text = "P =";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(496, 257);
            this.label21.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 23);
            this.label21.TabIndex = 134;
            this.label21.Text = "O =";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOMinus
            // 
            this.btnOMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOMinus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOMinus.Location = new System.Drawing.Point(534, 281);
            this.btnOMinus.Name = "btnOMinus";
            this.btnOMinus.Size = new System.Drawing.Size(62, 36);
            this.btnOMinus.TabIndex = 133;
            this.btnOMinus.Text = "-";
            this.btnOMinus.UseVisualStyleBackColor = true;
            this.btnOMinus.Click += new System.EventHandler(this.btnOMinus_Click);
            // 
            // btnOPlus
            // 
            this.btnOPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOPlus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOPlus.Location = new System.Drawing.Point(459, 281);
            this.btnOPlus.Name = "btnOPlus";
            this.btnOPlus.Size = new System.Drawing.Size(62, 36);
            this.btnOPlus.TabIndex = 132;
            this.btnOPlus.Text = "+";
            this.btnOPlus.UseVisualStyleBackColor = true;
            this.btnOPlus.Click += new System.EventHandler(this.btnOPlus_Click);
            // 
            // lblPValue
            // 
            this.lblPValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPValue.AutoSize = true;
            this.lblPValue.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPValue.Location = new System.Drawing.Point(534, 11);
            this.lblPValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPValue.Name = "lblPValue";
            this.lblPValue.Size = new System.Drawing.Size(19, 23);
            this.lblPValue.TabIndex = 135;
            this.lblPValue.Text = "0";
            this.lblPValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIValue
            // 
            this.lblIValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIValue.AutoSize = true;
            this.lblIValue.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIValue.Location = new System.Drawing.Point(534, 92);
            this.lblIValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblIValue.Name = "lblIValue";
            this.lblIValue.Size = new System.Drawing.Size(19, 23);
            this.lblIValue.TabIndex = 136;
            this.lblIValue.Text = "0";
            this.lblIValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDValue
            // 
            this.lblDValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDValue.AutoSize = true;
            this.lblDValue.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDValue.Location = new System.Drawing.Point(534, 175);
            this.lblDValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDValue.Name = "lblDValue";
            this.lblDValue.Size = new System.Drawing.Size(19, 23);
            this.lblDValue.TabIndex = 137;
            this.lblDValue.Text = "0";
            this.lblDValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOValue
            // 
            this.lblOValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOValue.AutoSize = true;
            this.lblOValue.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOValue.Location = new System.Drawing.Point(534, 257);
            this.lblOValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOValue.Name = "lblOValue";
            this.lblOValue.Size = new System.Drawing.Size(19, 23);
            this.lblOValue.TabIndex = 138;
            this.lblOValue.Text = "0";
            this.lblOValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormGPSData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(602, 424);
            this.Controls.Add(this.lblOValue);
            this.Controls.Add(this.lblDValue);
            this.Controls.Add(this.lblIValue);
            this.Controls.Add(this.lblPValue);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnOMinus);
            this.Controls.Add(this.btnOPlus);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnIMinus);
            this.Controls.Add(this.btnDMinus);
            this.Controls.Add(this.btnPMinus);
            this.Controls.Add(this.btnIPlus);
            this.Controls.Add(this.btnDPlus);
            this.Controls.Add(this.btnPPlus);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tboxSerialFromAutoSteer);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tboxSerialToAutoSteer);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tboxSerialToRelay);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblZone);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tboxSerialFromRelay);
            this.Controls.Add(this.tboxNMEASerial);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblHDOP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblAltitude);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.lblEasting);
            this.Controls.Add(this.lblNorthing);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblSatsTracked);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblFixQuality);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGPSData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GPS Data";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.TextBox tboxSerialFromRelay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tboxSerialToRelay;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tboxSerialFromAutoSteer;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tboxSerialToAutoSteer;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnPPlus;
        private System.Windows.Forms.Button btnDPlus;
        private System.Windows.Forms.Button btnIPlus;
        private System.Windows.Forms.Button btnIMinus;
        private System.Windows.Forms.Button btnDMinus;
        private System.Windows.Forms.Button btnPMinus;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnOMinus;
        private System.Windows.Forms.Button btnOPlus;
        private System.Windows.Forms.Label lblPValue;
        private System.Windows.Forms.Label lblIValue;
        private System.Windows.Forms.Label lblDValue;
        private System.Windows.Forms.Label lblOValue;
    }
}