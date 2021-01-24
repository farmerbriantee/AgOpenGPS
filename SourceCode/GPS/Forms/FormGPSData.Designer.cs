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
            this.label17 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblOverlapPercent = new System.Windows.Forms.Label();
            this.lblTotalAppliedArea = new System.Windows.Forms.Label();
            this.lblTotalFieldArea = new System.Windows.Forms.Label();
            this.lblAreaMinusActualApplied = new System.Windows.Forms.Label();
            this.lblEqSpec = new System.Windows.Forms.Label();
            this.lblWorkRemaining = new System.Windows.Forms.Label();
            this.lblAreaOverlapped = new System.Windows.Forms.Label();
            this.lblAreaAppliedMinusOverlap = new System.Windows.Forms.Label();
            this.lblPercentRemaining = new System.Windows.Forms.Label();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblRoll = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblGPSHeading = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblYawHeading = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblFixHeading = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblSunset = new System.Windows.Forms.Label();
            this.lblSunrise = new System.Windows.Forms.Label();
            this.lblUturnByte = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblEastingField = new System.Windows.Forms.Label();
            this.lblNorthingField = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtBoxRecvAutoSteer = new System.Windows.Forms.TextBox();
            this.txtBoxRecvMachine = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.tboxUDPSteer = new System.Windows.Forms.TextBox();
            this.tboxUDPMachine = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.tboxUDPSwitch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(9, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Northing";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(16, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Easting";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(151, 120);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Lat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(385, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(268, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Quality";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(383, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "# Sats";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(430, 104);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(51, 16);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFixQuality
            // 
            this.lblFixQuality.AutoSize = true;
            this.lblFixQuality.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixQuality.Location = new System.Drawing.Point(316, 85);
            this.lblFixQuality.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFixQuality.Name = "lblFixQuality";
            this.lblFixQuality.Size = new System.Drawing.Size(52, 16);
            this.lblFixQuality.TabIndex = 2;
            this.lblFixQuality.Text = "FixQual";
            this.lblFixQuality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSatsTracked
            // 
            this.lblSatsTracked.AutoSize = true;
            this.lblSatsTracked.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatsTracked.Location = new System.Drawing.Point(430, 120);
            this.lblSatsTracked.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSatsTracked.Name = "lblSatsTracked";
            this.lblSatsTracked.Size = new System.Drawing.Size(37, 16);
            this.lblSatsTracked.TabIndex = 4;
            this.lblSatsTracked.Text = "Sats";
            this.lblSatsTracked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.Location = new System.Drawing.Point(176, 120);
            this.lblLatitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(62, 16);
            this.lblLatitude.TabIndex = 12;
            this.lblLatitude.Text = "Latitude";
            // 
            // lblEasting
            // 
            this.lblEasting.AutoSize = true;
            this.lblEasting.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasting.Location = new System.Drawing.Point(66, 85);
            this.lblEasting.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEasting.Name = "lblEasting";
            this.lblEasting.Size = new System.Drawing.Size(55, 16);
            this.lblEasting.TabIndex = 11;
            this.lblEasting.Text = "Easting";
            // 
            // lblNorthing
            // 
            this.lblNorthing.AutoSize = true;
            this.lblNorthing.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNorthing.Location = new System.Drawing.Point(66, 69);
            this.lblNorthing.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNorthing.Name = "lblNorthing";
            this.lblNorthing.Size = new System.Drawing.Size(63, 16);
            this.lblNorthing.TabIndex = 10;
            this.lblNorthing.Text = "Northing";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.Location = new System.Drawing.Point(176, 104);
            this.lblLongitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(72, 16);
            this.lblLongitude.TabIndex = 13;
            this.lblLongitude.Text = "Longitude";
            // 
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltitude.Location = new System.Drawing.Point(175, 85);
            this.lblAltitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(60, 16);
            this.lblAltitude.TabIndex = 14;
            this.lblAltitude.Text = "Altitude";
            this.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(148, 104);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Lon";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(153, 85);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Alt";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(275, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "HDOP";
            // 
            // lblHDOP
            // 
            this.lblHDOP.AutoSize = true;
            this.lblHDOP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHDOP.Location = new System.Drawing.Point(316, 69);
            this.lblHDOP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHDOP.Name = "lblHDOP";
            this.lblHDOP.Size = new System.Drawing.Size(43, 16);
            this.lblHDOP.TabIndex = 17;
            this.lblHDOP.Text = "HDOP";
            this.lblHDOP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tboxNMEASerial
            // 
            this.tboxNMEASerial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxNMEASerial.Location = new System.Drawing.Point(7, 5);
            this.tboxNMEASerial.Multiline = true;
            this.tboxNMEASerial.Name = "tboxNMEASerial";
            this.tboxNMEASerial.ReadOnly = true;
            this.tboxNMEASerial.Size = new System.Drawing.Size(469, 57);
            this.tboxNMEASerial.TabIndex = 107;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(272, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 16);
            this.label17.TabIndex = 116;
            this.label17.Text = "Speed";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(315, 104);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(48, 16);
            this.lblSpeed.TabIndex = 115;
            this.lblSpeed.Text = "Speed";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOverlapPercent
            // 
            this.lblOverlapPercent.AutoSize = true;
            this.lblOverlapPercent.BackColor = System.Drawing.Color.Transparent;
            this.lblOverlapPercent.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblOverlapPercent.ForeColor = System.Drawing.Color.MediumOrchid;
            this.lblOverlapPercent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOverlapPercent.Location = new System.Drawing.Point(78, 453);
            this.lblOverlapPercent.Name = "lblOverlapPercent";
            this.lblOverlapPercent.Size = new System.Drawing.Size(65, 19);
            this.lblOverlapPercent.TabIndex = 314;
            this.lblOverlapPercent.Text = "OVL %";
            // 
            // lblTotalAppliedArea
            // 
            this.lblTotalAppliedArea.AutoSize = true;
            this.lblTotalAppliedArea.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAppliedArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAppliedArea.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotalAppliedArea.Location = new System.Drawing.Point(100, 175);
            this.lblTotalAppliedArea.Name = "lblTotalAppliedArea";
            this.lblTotalAppliedArea.Size = new System.Drawing.Size(36, 16);
            this.lblTotalAppliedArea.TabIndex = 453;
            this.lblTotalAppliedArea.Text = "22.6";
            // 
            // lblTotalFieldArea
            // 
            this.lblTotalFieldArea.AutoSize = true;
            this.lblTotalFieldArea.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalFieldArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFieldArea.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotalFieldArea.Location = new System.Drawing.Point(100, 159);
            this.lblTotalFieldArea.Name = "lblTotalFieldArea";
            this.lblTotalFieldArea.Size = new System.Drawing.Size(36, 16);
            this.lblTotalFieldArea.TabIndex = 453;
            this.lblTotalFieldArea.Text = "22.6";
            // 
            // lblAreaMinusActualApplied
            // 
            this.lblAreaMinusActualApplied.AutoSize = true;
            this.lblAreaMinusActualApplied.BackColor = System.Drawing.Color.Transparent;
            this.lblAreaMinusActualApplied.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaMinusActualApplied.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAreaMinusActualApplied.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAreaMinusActualApplied.Location = new System.Drawing.Point(101, 427);
            this.lblAreaMinusActualApplied.Name = "lblAreaMinusActualApplied";
            this.lblAreaMinusActualApplied.Size = new System.Drawing.Size(36, 16);
            this.lblAreaMinusActualApplied.TabIndex = 314;
            this.lblAreaMinusActualApplied.Text = "21.5";
            // 
            // lblEqSpec
            // 
            this.lblEqSpec.AutoSize = true;
            this.lblEqSpec.BackColor = System.Drawing.Color.Transparent;
            this.lblEqSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEqSpec.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblEqSpec.Location = new System.Drawing.Point(67, 139);
            this.lblEqSpec.Name = "lblEqSpec";
            this.lblEqSpec.Size = new System.Drawing.Size(69, 16);
            this.lblEqSpec.TabIndex = 313;
            this.lblEqSpec.Text = "EQ Spec";
            // 
            // lblWorkRemaining
            // 
            this.lblWorkRemaining.AutoSize = true;
            this.lblWorkRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkRemaining.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblWorkRemaining.Location = new System.Drawing.Point(100, 192);
            this.lblWorkRemaining.Name = "lblWorkRemaining";
            this.lblWorkRemaining.Size = new System.Drawing.Size(36, 16);
            this.lblWorkRemaining.TabIndex = 314;
            this.lblWorkRemaining.Text = "22.6";
            // 
            // lblAreaOverlapped
            // 
            this.lblAreaOverlapped.AutoSize = true;
            this.lblAreaOverlapped.BackColor = System.Drawing.Color.Transparent;
            this.lblAreaOverlapped.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblAreaOverlapped.ForeColor = System.Drawing.Color.MediumOrchid;
            this.lblAreaOverlapped.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAreaOverlapped.Location = new System.Drawing.Point(8, 453);
            this.lblAreaOverlapped.Name = "lblAreaOverlapped";
            this.lblAreaOverlapped.Size = new System.Drawing.Size(61, 19);
            this.lblAreaOverlapped.TabIndex = 315;
            this.lblAreaOverlapped.Text = "Actual";
            // 
            // lblAreaAppliedMinusOverlap
            // 
            this.lblAreaAppliedMinusOverlap.AutoSize = true;
            this.lblAreaAppliedMinusOverlap.BackColor = System.Drawing.Color.Transparent;
            this.lblAreaAppliedMinusOverlap.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaAppliedMinusOverlap.ForeColor = System.Drawing.Color.MediumOrchid;
            this.lblAreaAppliedMinusOverlap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAreaAppliedMinusOverlap.Location = new System.Drawing.Point(159, 453);
            this.lblAreaAppliedMinusOverlap.Name = "lblAreaAppliedMinusOverlap";
            this.lblAreaAppliedMinusOverlap.Size = new System.Drawing.Size(44, 19);
            this.lblAreaAppliedMinusOverlap.TabIndex = 314;
            this.lblAreaAppliedMinusOverlap.Text = "98.2";
            // 
            // lblPercentRemaining
            // 
            this.lblPercentRemaining.AutoSize = true;
            this.lblPercentRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblPercentRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentRemaining.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPercentRemaining.Location = new System.Drawing.Point(165, 159);
            this.lblPercentRemaining.Name = "lblPercentRemaining";
            this.lblPercentRemaining.Size = new System.Drawing.Size(49, 16);
            this.lblPercentRemaining.TabIndex = 314;
            this.lblPercentRemaining.Text = "99.5%";
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.AutoSize = true;
            this.lblTimeRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeRemaining.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTimeRemaining.Location = new System.Drawing.Point(165, 175);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(44, 16);
            this.lblTimeRemaining.TabIndex = 314;
            this.lblTimeRemaining.Text = "1.5Hr";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(2, 159);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 16);
            this.label10.TabIndex = 455;
            this.label10.Text = "Total Field Area";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(15, 175);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 16);
            this.label12.TabIndex = 454;
            this.label12.Text = "Total Applied";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(-1, 192);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 16);
            this.label13.TabIndex = 456;
            this.label13.Text = "Area Remaining";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(9, 427);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 16);
            this.label14.TabIndex = 457;
            this.label14.Text = "Actual Applied";
            // 
            // lblRoll
            // 
            this.lblRoll.AutoSize = true;
            this.lblRoll.BackColor = System.Drawing.Color.Transparent;
            this.lblRoll.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRoll.Location = new System.Drawing.Point(394, 159);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(42, 16);
            this.lblRoll.TabIndex = 463;
            this.lblRoll.Text = "-11.2";
            this.lblRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(367, 159);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 16);
            this.label15.TabIndex = 460;
            this.label15.Text = "Roll";
            // 
            // lblGPSHeading
            // 
            this.lblGPSHeading.AutoSize = true;
            this.lblGPSHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblGPSHeading.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPSHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGPSHeading.Location = new System.Drawing.Point(282, 176);
            this.lblGPSHeading.Name = "lblGPSHeading";
            this.lblGPSHeading.Size = new System.Drawing.Size(44, 16);
            this.lblGPSHeading.TabIndex = 462;
            this.lblGPSHeading.Text = "359.3";
            this.lblGPSHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(255, 176);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 16);
            this.label16.TabIndex = 458;
            this.label16.Text = "GPS";
            // 
            // lblYawHeading
            // 
            this.lblYawHeading.AutoSize = true;
            this.lblYawHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblYawHeading.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYawHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblYawHeading.Location = new System.Drawing.Point(282, 192);
            this.lblYawHeading.Name = "lblYawHeading";
            this.lblYawHeading.Size = new System.Drawing.Size(44, 16);
            this.lblYawHeading.TabIndex = 461;
            this.lblYawHeading.Text = "288.8";
            this.lblYawHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(255, 192);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 16);
            this.label18.TabIndex = 459;
            this.label18.Text = "IMU";
            // 
            // lblFixHeading
            // 
            this.lblFixHeading.AutoSize = true;
            this.lblFixHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblFixHeading.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFixHeading.Location = new System.Drawing.Point(282, 160);
            this.lblFixHeading.Name = "lblFixHeading";
            this.lblFixHeading.Size = new System.Drawing.Size(44, 16);
            this.lblFixHeading.TabIndex = 465;
            this.lblFixHeading.Text = "359.3";
            this.lblFixHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(254, 160);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(30, 16);
            this.label20.TabIndex = 464;
            this.label20.Text = "FUZ";
            // 
            // lblSunset
            // 
            this.lblSunset.AutoSize = true;
            this.lblSunset.BackColor = System.Drawing.Color.Transparent;
            this.lblSunset.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSunset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSunset.Location = new System.Drawing.Point(434, 85);
            this.lblSunset.Name = "lblSunset";
            this.lblSunset.Size = new System.Drawing.Size(45, 16);
            this.lblSunset.TabIndex = 469;
            this.lblSunset.Text = "18:00";
            // 
            // lblSunrise
            // 
            this.lblSunrise.AutoSize = true;
            this.lblSunrise.BackColor = System.Drawing.Color.Transparent;
            this.lblSunrise.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSunrise.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSunrise.Location = new System.Drawing.Point(434, 67);
            this.lblSunrise.Name = "lblSunrise";
            this.lblSunrise.Size = new System.Drawing.Size(45, 16);
            this.lblSunrise.TabIndex = 468;
            this.lblSunrise.Text = "06:00";
            // 
            // lblUturnByte
            // 
            this.lblUturnByte.AutoSize = true;
            this.lblUturnByte.BackColor = System.Drawing.Color.Transparent;
            this.lblUturnByte.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUturnByte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUturnByte.Location = new System.Drawing.Point(394, 175);
            this.lblUturnByte.Name = "lblUturnByte";
            this.lblUturnByte.Size = new System.Drawing.Size(72, 16);
            this.lblUturnByte.TabIndex = 466;
            this.lblUturnByte.Text = "10101001";
            this.lblUturnByte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(353, 175);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 16);
            this.label21.TabIndex = 467;
            this.label21.Text = "UTurn";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label23.Location = new System.Drawing.Point(383, 67);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(51, 16);
            this.label23.TabIndex = 472;
            this.label23.Text = "Sunrise";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label24.Location = new System.Drawing.Point(386, 85);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 16);
            this.label24.TabIndex = 473;
            this.label24.Text = "Sunset";
            // 
            // lblEastingField
            // 
            this.lblEastingField.AutoSize = true;
            this.lblEastingField.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEastingField.Location = new System.Drawing.Point(66, 120);
            this.lblEastingField.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEastingField.Name = "lblEastingField";
            this.lblEastingField.Size = new System.Drawing.Size(55, 16);
            this.lblEastingField.TabIndex = 477;
            this.lblEastingField.Text = "Easting";
            // 
            // lblNorthingField
            // 
            this.lblNorthingField.AutoSize = true;
            this.lblNorthingField.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNorthingField.Location = new System.Drawing.Point(66, 104);
            this.lblNorthingField.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNorthingField.Name = "lblNorthingField";
            this.lblNorthingField.Size = new System.Drawing.Size(63, 16);
            this.lblNorthingField.TabIndex = 476;
            this.lblNorthingField.Text = "Northing";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label27.Location = new System.Drawing.Point(21, 120);
            this.label27.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(46, 16);
            this.label27.TabIndex = 475;
            this.label27.Text = "Field E";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label28.Location = new System.Drawing.Point(20, 104);
            this.label28.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(47, 16);
            this.label28.TabIndex = 474;
            this.label28.Text = "Field N";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label25.Location = new System.Drawing.Point(11, 139);
            this.label25.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 16);
            this.label25.TabIndex = 478;
            this.label25.Text = "Eq Spec";
            // 
            // txtBoxRecvAutoSteer
            // 
            this.txtBoxRecvAutoSteer.BackColor = System.Drawing.SystemColors.Window;
            this.txtBoxRecvAutoSteer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxRecvAutoSteer.Location = new System.Drawing.Point(5, 220);
            this.txtBoxRecvAutoSteer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxRecvAutoSteer.Name = "txtBoxRecvAutoSteer";
            this.txtBoxRecvAutoSteer.ReadOnly = true;
            this.txtBoxRecvAutoSteer.Size = new System.Drawing.Size(231, 22);
            this.txtBoxRecvAutoSteer.TabIndex = 479;
            this.txtBoxRecvAutoSteer.Text = "127,253,1234,1234,1234,123";
            // 
            // txtBoxRecvMachine
            // 
            this.txtBoxRecvMachine.BackColor = System.Drawing.SystemColors.Window;
            this.txtBoxRecvMachine.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxRecvMachine.Location = new System.Drawing.Point(245, 220);
            this.txtBoxRecvMachine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxRecvMachine.Name = "txtBoxRecvMachine";
            this.txtBoxRecvMachine.ReadOnly = true;
            this.txtBoxRecvMachine.Size = new System.Drawing.Size(231, 22);
            this.txtBoxRecvMachine.TabIndex = 480;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(177, 206);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(55, 13);
            this.label26.TabIndex = 481;
            this.label26.Text = "USB Steer";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label29.Location = new System.Drawing.Point(405, 205);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(68, 13);
            this.label29.TabIndex = 482;
            this.label29.Text = "USB Machine";
            // 
            // tboxUDPSteer
            // 
            this.tboxUDPSteer.BackColor = System.Drawing.SystemColors.Window;
            this.tboxUDPSteer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxUDPSteer.Location = new System.Drawing.Point(62, 245);
            this.tboxUDPSteer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxUDPSteer.Name = "tboxUDPSteer";
            this.tboxUDPSteer.ReadOnly = true;
            this.tboxUDPSteer.Size = new System.Drawing.Size(114, 22);
            this.tboxUDPSteer.TabIndex = 483;
            this.tboxUDPSteer.Text = "127,253,1234,1234,1234,123";
            // 
            // tboxUDPMachine
            // 
            this.tboxUDPMachine.BackColor = System.Drawing.SystemColors.Window;
            this.tboxUDPMachine.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxUDPMachine.Location = new System.Drawing.Point(220, 245);
            this.tboxUDPMachine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxUDPMachine.Name = "tboxUDPMachine";
            this.tboxUDPMachine.ReadOnly = true;
            this.tboxUDPMachine.Size = new System.Drawing.Size(114, 22);
            this.tboxUDPMachine.TabIndex = 484;
            this.tboxUDPMachine.Text = "127,253,1234,1234,1234,123";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(4, 249);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 13);
            this.label19.TabIndex = 485;
            this.label19.Text = "UDP Steer";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(186, 249);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(32, 13);
            this.label30.TabIndex = 486;
            this.label30.Text = "Mach";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(342, 249);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(21, 13);
            this.label31.TabIndex = 488;
            this.label31.Text = "Sw";
            // 
            // tboxUDPSwitch
            // 
            this.tboxUDPSwitch.BackColor = System.Drawing.SystemColors.Window;
            this.tboxUDPSwitch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxUDPSwitch.Location = new System.Drawing.Point(366, 245);
            this.tboxUDPSwitch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxUDPSwitch.Name = "tboxUDPSwitch";
            this.tboxUDPSwitch.ReadOnly = true;
            this.tboxUDPSwitch.Size = new System.Drawing.Size(114, 22);
            this.tboxUDPSwitch.TabIndex = 487;
            this.tboxUDPSwitch.Text = "127,253,1234,1234,1234,123";
            // 
            // FormGPSData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(483, 270);
            this.Controls.Add(this.tboxUDPSwitch);
            this.Controls.Add(this.tboxUDPMachine);
            this.Controls.Add(this.tboxUDPSteer);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txtBoxRecvMachine);
            this.Controls.Add(this.txtBoxRecvAutoSteer);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.lblEastingField);
            this.Controls.Add(this.lblNorthingField);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.lblSunset);
            this.Controls.Add(this.lblSunrise);
            this.Controls.Add(this.lblUturnByte);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblFixHeading);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblRoll);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblGPSHeading);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblYawHeading);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblEqSpec);
            this.Controls.Add(this.lblOverlapPercent);
            this.Controls.Add(this.lblAreaOverlapped);
            this.Controls.Add(this.lblAreaMinusActualApplied);
            this.Controls.Add(this.lblTotalAppliedArea);
            this.Controls.Add(this.lblTimeRemaining);
            this.Controls.Add(this.lblPercentRemaining);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblWorkRemaining);
            this.Controls.Add(this.lblTotalFieldArea);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblAreaAppliedMinusOverlap);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.lblEasting);
            this.Controls.Add(this.lblNorthing);
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
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label19);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGPSData";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GPS Data";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormGPSData_Load);
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
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblOverlapPercent;
        private System.Windows.Forms.Label lblTotalAppliedArea;
        private System.Windows.Forms.Label lblTotalFieldArea;
        private System.Windows.Forms.Label lblAreaMinusActualApplied;
        private System.Windows.Forms.Label lblEqSpec;
        private System.Windows.Forms.Label lblWorkRemaining;
        private System.Windows.Forms.Label lblAreaOverlapped;
        private System.Windows.Forms.Label lblAreaAppliedMinusOverlap;
        private System.Windows.Forms.Label lblPercentRemaining;
        private System.Windows.Forms.Label lblTimeRemaining;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblGPSHeading;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblYawHeading;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblFixHeading;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblSunset;
        private System.Windows.Forms.Label lblSunrise;
        private System.Windows.Forms.Label lblUturnByte;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblEastingField;
        private System.Windows.Forms.Label lblNorthingField;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtBoxRecvAutoSteer;
        private System.Windows.Forms.TextBox txtBoxRecvMachine;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox tboxUDPSteer;
        private System.Windows.Forms.TextBox tboxUDPMachine;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox tboxUDPSwitch;
    }
}