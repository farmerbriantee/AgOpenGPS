namespace AgOpenGPS
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageVehicle = new System.Windows.Forms.TabPage();
            this.lblToolMarker = new System.Windows.Forms.Label();
            this.lblAntennaInches = new System.Windows.Forms.Label();
            this.lblAntennaFeet = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nudAntennaHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudLookAhead = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.lblForeAftInches = new System.Windows.Forms.Label();
            this.lblForeAftFeet = new System.Windows.Forms.Label();
            this.nudForeAft = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVehicleOK = new System.Windows.Forms.Button();
            this.tabPageSections = new System.Windows.Forms.TabPage();
            this.lblTractor = new System.Windows.Forms.Label();
            this.lblSection5Width = new System.Windows.Forms.Label();
            this.lblSection4Width = new System.Windows.Forms.Label();
            this.lblSection3Width = new System.Windows.Forms.Label();
            this.lblSection2Width = new System.Windows.Forms.Label();
            this.lblSection1Width = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSecTotalWidthInches = new System.Windows.Forms.Label();
            this.lblSecTotalWidthFeet = new System.Windows.Forms.Label();
            this.lblVehicleToolWidth = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSection6Inch = new System.Windows.Forms.Label();
            this.lblSection5Inch = new System.Windows.Forms.Label();
            this.lblSection4Inch = new System.Windows.Forms.Label();
            this.lblSection3Inch = new System.Windows.Forms.Label();
            this.lblSection2Inch = new System.Windows.Forms.Label();
            this.lblSection1Inch = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.nudSection6 = new System.Windows.Forms.NumericUpDown();
            this.nudSection5 = new System.Windows.Forms.NumericUpDown();
            this.nudSection4 = new System.Windows.Forms.NumericUpDown();
            this.nudSection3 = new System.Windows.Forms.NumericUpDown();
            this.nudSection2 = new System.Windows.Forms.NumericUpDown();
            this.nudSection1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudNumberOfSections = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bntSectionOK = new System.Windows.Forms.Button();
            this.btnHomeSerial = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label99 = new System.Windows.Forms.Label();
            this.nudNMEAHz = new System.Windows.Forms.NumericUpDown();
            this.btnOpenSerial = new System.Windows.Forms.Button();
            this.btnCloseSerial = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRcv = new System.Windows.Forms.TextBox();
            this.btnRescan = new System.Windows.Forms.Button();
            this.cboxBaud = new System.Windows.Forms.ComboBox();
            this.cboxPort = new System.Windows.Forms.ComboBox();
            this.btnSerialOK = new System.Windows.Forms.Button();
            this.tabGuidance = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.btnGuidanceOK = new System.Windows.Forms.Button();
            this.lblOverlapInches = new System.Windows.Forms.Label();
            this.lblOverlapFeet = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nudOverlap = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageVehicle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAntennaHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLookAhead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForeAft)).BeginInit();
            this.tabPageSections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSection6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSection5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSection4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSection3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfSections)).BeginInit();
            this.btnHomeSerial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNMEAHz)).BeginInit();
            this.tabGuidance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverlap)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageVehicle);
            this.tabControl1.Controls.Add(this.tabPageSections);
            this.tabControl1.Controls.Add(this.btnHomeSerial);
            this.tabControl1.Controls.Add(this.tabGuidance);
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(5, 9);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(913, 390);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageVehicle
            // 
            this.tabPageVehicle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPageVehicle.BackgroundImage")));
            this.tabPageVehicle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPageVehicle.Controls.Add(this.lblToolMarker);
            this.tabPageVehicle.Controls.Add(this.lblAntennaInches);
            this.tabPageVehicle.Controls.Add(this.lblAntennaFeet);
            this.tabPageVehicle.Controls.Add(this.label13);
            this.tabPageVehicle.Controls.Add(this.nudAntennaHeight);
            this.tabPageVehicle.Controls.Add(this.label3);
            this.tabPageVehicle.Controls.Add(this.nudLookAhead);
            this.tabPageVehicle.Controls.Add(this.button2);
            this.tabPageVehicle.Controls.Add(this.lblForeAftInches);
            this.tabPageVehicle.Controls.Add(this.lblForeAftFeet);
            this.tabPageVehicle.Controls.Add(this.nudForeAft);
            this.tabPageVehicle.Controls.Add(this.label5);
            this.tabPageVehicle.Controls.Add(this.btnVehicleOK);
            this.tabPageVehicle.Location = new System.Drawing.Point(4, 27);
            this.tabPageVehicle.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageVehicle.Name = "tabPageVehicle";
            this.tabPageVehicle.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageVehicle.Size = new System.Drawing.Size(905, 359);
            this.tabPageVehicle.TabIndex = 1;
            this.tabPageVehicle.Text = "Vehicle";
            this.tabPageVehicle.UseVisualStyleBackColor = true;
            // 
            // lblToolMarker
            // 
            this.lblToolMarker.AutoSize = true;
            this.lblToolMarker.BackColor = System.Drawing.Color.GreenYellow;
            this.lblToolMarker.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolMarker.Location = new System.Drawing.Point(392, 171);
            this.lblToolMarker.Name = "lblToolMarker";
            this.lblToolMarker.Size = new System.Drawing.Size(96, 32);
            this.lblToolMarker.TabIndex = 56;
            this.lblToolMarker.Text = "TOOL";
            // 
            // lblAntennaInches
            // 
            this.lblAntennaInches.AutoSize = true;
            this.lblAntennaInches.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAntennaInches.Location = new System.Drawing.Point(579, 118);
            this.lblAntennaInches.Name = "lblAntennaInches";
            this.lblAntennaInches.Size = new System.Drawing.Size(57, 35);
            this.lblAntennaInches.TabIndex = 55;
            this.lblAntennaInches.Text = "YY";
            this.lblAntennaInches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAntennaFeet
            // 
            this.lblAntennaFeet.AutoSize = true;
            this.lblAntennaFeet.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAntennaFeet.Location = new System.Drawing.Point(511, 118);
            this.lblAntennaFeet.Name = "lblAntennaFeet";
            this.lblAntennaFeet.Size = new System.Drawing.Size(59, 35);
            this.lblAntennaFeet.TabIndex = 54;
            this.lblAntennaFeet.Text = "XX";
            this.lblAntennaFeet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(508, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(181, 23);
            this.label13.TabIndex = 53;
            this.label13.Text = "Antenna Height";
            // 
            // nudAntennaHeight
            // 
            this.nudAntennaHeight.DecimalPlaces = 2;
            this.nudAntennaHeight.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAntennaHeight.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudAntennaHeight.Location = new System.Drawing.Point(506, 49);
            this.nudAntennaHeight.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudAntennaHeight.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            this.nudAntennaHeight.Name = "nudAntennaHeight";
            this.nudAntennaHeight.Size = new System.Drawing.Size(182, 66);
            this.nudAntennaHeight.TabIndex = 52;
            this.nudAntennaHeight.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            this.nudAntennaHeight.ValueChanged += new System.EventHandler(this.nudAntennaHeight_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(476, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 23);
            this.label3.TabIndex = 51;
            this.label3.Text = "Look Ahead (Secs)";
            // 
            // nudLookAhead
            // 
            this.nudLookAhead.DecimalPlaces = 1;
            this.nudLookAhead.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLookAhead.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudLookAhead.Location = new System.Drawing.Point(506, 282);
            this.nudLookAhead.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudLookAhead.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudLookAhead.Name = "nudLookAhead";
            this.nudLookAhead.Size = new System.Drawing.Size(182, 66);
            this.nudLookAhead.TabIndex = 50;
            this.nudLookAhead.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.button2.Location = new System.Drawing.Point(814, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 72);
            this.button2.TabIndex = 49;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblForeAftInches
            // 
            this.lblForeAftInches.AutoSize = true;
            this.lblForeAftInches.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForeAftInches.Location = new System.Drawing.Point(111, 313);
            this.lblForeAftInches.Name = "lblForeAftInches";
            this.lblForeAftInches.Size = new System.Drawing.Size(57, 35);
            this.lblForeAftInches.TabIndex = 26;
            this.lblForeAftInches.Text = "YY";
            this.lblForeAftInches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblForeAftFeet
            // 
            this.lblForeAftFeet.AutoSize = true;
            this.lblForeAftFeet.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForeAftFeet.Location = new System.Drawing.Point(43, 313);
            this.lblForeAftFeet.Name = "lblForeAftFeet";
            this.lblForeAftFeet.Size = new System.Drawing.Size(59, 35);
            this.lblForeAftFeet.TabIndex = 25;
            this.lblForeAftFeet.Text = "XX";
            this.lblForeAftFeet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudForeAft
            // 
            this.nudForeAft.DecimalPlaces = 2;
            this.nudForeAft.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudForeAft.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.nudForeAft.Location = new System.Drawing.Point(205, 282);
            this.nudForeAft.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudForeAft.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            -2147483648});
            this.nudForeAft.Name = "nudForeAft";
            this.nudForeAft.Size = new System.Drawing.Size(200, 66);
            this.nudForeAft.TabIndex = 24;
            this.nudForeAft.Value = new decimal(new int[] {
            20,
            0,
            0,
            -2147418112});
            this.nudForeAft.ValueChanged += new System.EventHandler(this.nudForeAft_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 29);
            this.label5.TabIndex = 23;
            this.label5.Text = "Fore / Aft ";
            // 
            // btnVehicleOK
            // 
            this.btnVehicleOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVehicleOK.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehicleOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnVehicleOK.Location = new System.Drawing.Point(744, 280);
            this.btnVehicleOK.Name = "btnVehicleOK";
            this.btnVehicleOK.Size = new System.Drawing.Size(156, 74);
            this.btnVehicleOK.TabIndex = 5;
            this.btnVehicleOK.Text = "Save";
            this.btnVehicleOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVehicleOK.UseVisualStyleBackColor = true;
            this.btnVehicleOK.Click += new System.EventHandler(this.btnVehicleOK_Click);
            // 
            // tabPageSections
            // 
            this.tabPageSections.Controls.Add(this.lblTractor);
            this.tabPageSections.Controls.Add(this.lblSection5Width);
            this.tabPageSections.Controls.Add(this.lblSection4Width);
            this.tabPageSections.Controls.Add(this.lblSection3Width);
            this.tabPageSections.Controls.Add(this.lblSection2Width);
            this.tabPageSections.Controls.Add(this.lblSection1Width);
            this.tabPageSections.Controls.Add(this.label11);
            this.tabPageSections.Controls.Add(this.label10);
            this.tabPageSections.Controls.Add(this.label6);
            this.tabPageSections.Controls.Add(this.label9);
            this.tabPageSections.Controls.Add(this.label8);
            this.tabPageSections.Controls.Add(this.label7);
            this.tabPageSections.Controls.Add(this.lblSecTotalWidthInches);
            this.tabPageSections.Controls.Add(this.lblSecTotalWidthFeet);
            this.tabPageSections.Controls.Add(this.lblVehicleToolWidth);
            this.tabPageSections.Controls.Add(this.label4);
            this.tabPageSections.Controls.Add(this.lblSection6Inch);
            this.tabPageSections.Controls.Add(this.lblSection5Inch);
            this.tabPageSections.Controls.Add(this.lblSection4Inch);
            this.tabPageSections.Controls.Add(this.lblSection3Inch);
            this.tabPageSections.Controls.Add(this.lblSection2Inch);
            this.tabPageSections.Controls.Add(this.lblSection1Inch);
            this.tabPageSections.Controls.Add(this.progressBar1);
            this.tabPageSections.Controls.Add(this.nudSection6);
            this.tabPageSections.Controls.Add(this.nudSection5);
            this.tabPageSections.Controls.Add(this.nudSection4);
            this.tabPageSections.Controls.Add(this.nudSection3);
            this.tabPageSections.Controls.Add(this.nudSection2);
            this.tabPageSections.Controls.Add(this.nudSection1);
            this.tabPageSections.Controls.Add(this.label2);
            this.tabPageSections.Controls.Add(this.nudNumberOfSections);
            this.tabPageSections.Controls.Add(this.btnCancel);
            this.tabPageSections.Controls.Add(this.bntSectionOK);
            this.tabPageSections.Location = new System.Drawing.Point(4, 27);
            this.tabPageSections.Name = "tabPageSections";
            this.tabPageSections.Size = new System.Drawing.Size(905, 359);
            this.tabPageSections.TabIndex = 2;
            this.tabPageSections.Text = "Sections";
            this.tabPageSections.UseVisualStyleBackColor = true;
            // 
            // lblTractor
            // 
            this.lblTractor.AutoSize = true;
            this.lblTractor.BackColor = System.Drawing.SystemColors.Control;
            this.lblTractor.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTractor.ForeColor = System.Drawing.Color.Red;
            this.lblTractor.Location = new System.Drawing.Point(76, 44);
            this.lblTractor.Name = "lblTractor";
            this.lblTractor.Size = new System.Drawing.Size(94, 32);
            this.lblTractor.TabIndex = 37;
            this.lblTractor.Text = "|-^-|";
            // 
            // lblSection5Width
            // 
            this.lblSection5Width.AutoSize = true;
            this.lblSection5Width.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection5Width.Location = new System.Drawing.Point(751, 82);
            this.lblSection5Width.Name = "lblSection5Width";
            this.lblSection5Width.Size = new System.Drawing.Size(22, 23);
            this.lblSection5Width.TabIndex = 36;
            this.lblSection5Width.Text = "0";
            // 
            // lblSection4Width
            // 
            this.lblSection4Width.AutoSize = true;
            this.lblSection4Width.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection4Width.Location = new System.Drawing.Point(585, 82);
            this.lblSection4Width.Name = "lblSection4Width";
            this.lblSection4Width.Size = new System.Drawing.Size(22, 23);
            this.lblSection4Width.TabIndex = 35;
            this.lblSection4Width.Text = "0";
            // 
            // lblSection3Width
            // 
            this.lblSection3Width.AutoSize = true;
            this.lblSection3Width.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection3Width.Location = new System.Drawing.Point(419, 82);
            this.lblSection3Width.Name = "lblSection3Width";
            this.lblSection3Width.Size = new System.Drawing.Size(22, 23);
            this.lblSection3Width.TabIndex = 34;
            this.lblSection3Width.Text = "0";
            // 
            // lblSection2Width
            // 
            this.lblSection2Width.AutoSize = true;
            this.lblSection2Width.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection2Width.Location = new System.Drawing.Point(253, 82);
            this.lblSection2Width.Name = "lblSection2Width";
            this.lblSection2Width.Size = new System.Drawing.Size(22, 23);
            this.lblSection2Width.TabIndex = 33;
            this.lblSection2Width.Text = "0";
            // 
            // lblSection1Width
            // 
            this.lblSection1Width.AutoSize = true;
            this.lblSection1Width.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection1Width.Location = new System.Drawing.Point(87, 82);
            this.lblSection1Width.Name = "lblSection1Width";
            this.lblSection1Width.Size = new System.Drawing.Size(22, 23);
            this.lblSection1Width.TabIndex = 32;
            this.lblSection1Width.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(842, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 38);
            this.label11.TabIndex = 31;
            this.label11.Text = "|";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(678, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 38);
            this.label10.TabIndex = 30;
            this.label10.Text = "|";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 38);
            this.label6.TabIndex = 26;
            this.label6.Text = "|";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(513, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 38);
            this.label9.TabIndex = 29;
            this.label9.Text = "|";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(350, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 38);
            this.label8.TabIndex = 28;
            this.label8.Text = "|";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(187, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 38);
            this.label7.TabIndex = 27;
            this.label7.Text = "|";
            // 
            // lblSecTotalWidthInches
            // 
            this.lblSecTotalWidthInches.AutoSize = true;
            this.lblSecTotalWidthInches.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecTotalWidthInches.Location = new System.Drawing.Point(447, 306);
            this.lblSecTotalWidthInches.Name = "lblSecTotalWidthInches";
            this.lblSecTotalWidthInches.Size = new System.Drawing.Size(39, 29);
            this.lblSecTotalWidthInches.TabIndex = 25;
            this.lblSecTotalWidthInches.Text = "II";
            // 
            // lblSecTotalWidthFeet
            // 
            this.lblSecTotalWidthFeet.AutoSize = true;
            this.lblSecTotalWidthFeet.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecTotalWidthFeet.Location = new System.Drawing.Point(396, 306);
            this.lblSecTotalWidthFeet.Name = "lblSecTotalWidthFeet";
            this.lblSecTotalWidthFeet.Size = new System.Drawing.Size(45, 29);
            this.lblSecTotalWidthFeet.TabIndex = 24;
            this.lblSecTotalWidthFeet.Text = "FF";
            // 
            // lblVehicleToolWidth
            // 
            this.lblVehicleToolWidth.AutoSize = true;
            this.lblVehicleToolWidth.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleToolWidth.Location = new System.Drawing.Point(271, 306);
            this.lblVehicleToolWidth.Name = "lblVehicleToolWidth";
            this.lblVehicleToolWidth.Size = new System.Drawing.Size(59, 29);
            this.lblVehicleToolWidth.TabIndex = 23;
            this.lblVehicleToolWidth.Text = "MM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(292, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "Total Width";
            // 
            // lblSection6Inch
            // 
            this.lblSection6Inch.AutoSize = true;
            this.lblSection6Inch.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection6Inch.Location = new System.Drawing.Point(830, 127);
            this.lblSection6Inch.Name = "lblSection6Inch";
            this.lblSection6Inch.Size = new System.Drawing.Size(28, 29);
            this.lblSection6Inch.TabIndex = 21;
            this.lblSection6Inch.Text = "0";
            // 
            // lblSection5Inch
            // 
            this.lblSection5Inch.AutoSize = true;
            this.lblSection5Inch.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection5Inch.Location = new System.Drawing.Point(667, 127);
            this.lblSection5Inch.Name = "lblSection5Inch";
            this.lblSection5Inch.Size = new System.Drawing.Size(28, 29);
            this.lblSection5Inch.TabIndex = 20;
            this.lblSection5Inch.Text = "0";
            // 
            // lblSection4Inch
            // 
            this.lblSection4Inch.AutoSize = true;
            this.lblSection4Inch.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection4Inch.Location = new System.Drawing.Point(503, 127);
            this.lblSection4Inch.Name = "lblSection4Inch";
            this.lblSection4Inch.Size = new System.Drawing.Size(28, 29);
            this.lblSection4Inch.TabIndex = 19;
            this.lblSection4Inch.Text = "0";
            // 
            // lblSection3Inch
            // 
            this.lblSection3Inch.AutoSize = true;
            this.lblSection3Inch.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection3Inch.Location = new System.Drawing.Point(340, 127);
            this.lblSection3Inch.Name = "lblSection3Inch";
            this.lblSection3Inch.Size = new System.Drawing.Size(28, 29);
            this.lblSection3Inch.TabIndex = 18;
            this.lblSection3Inch.Text = "0";
            // 
            // lblSection2Inch
            // 
            this.lblSection2Inch.AutoSize = true;
            this.lblSection2Inch.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection2Inch.Location = new System.Drawing.Point(177, 127);
            this.lblSection2Inch.Name = "lblSection2Inch";
            this.lblSection2Inch.Size = new System.Drawing.Size(28, 29);
            this.lblSection2Inch.TabIndex = 17;
            this.lblSection2Inch.Text = "0";
            // 
            // lblSection1Inch
            // 
            this.lblSection1Inch.AutoSize = true;
            this.lblSection1Inch.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection1Inch.Location = new System.Drawing.Point(15, 127);
            this.lblSection1Inch.Name = "lblSection1Inch";
            this.lblSection1Inch.Size = new System.Drawing.Size(28, 29);
            this.lblSection1Inch.TabIndex = 16;
            this.lblSection1Inch.Text = "0";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.progressBar1.Location = new System.Drawing.Point(51, 105);
            this.progressBar1.Maximum = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(796, 10);
            this.progressBar1.TabIndex = 15;
            // 
            // nudSection6
            // 
            this.nudSection6.DecimalPlaces = 2;
            this.nudSection6.Font = new System.Drawing.Font("Arial Narrow", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSection6.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.nudSection6.Location = new System.Drawing.Point(795, 173);
            this.nudSection6.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudSection6.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.nudSection6.Name = "nudSection6";
            this.nudSection6.Size = new System.Drawing.Size(88, 48);
            this.nudSection6.TabIndex = 14;
            this.nudSection6.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSection6.ValueChanged += new System.EventHandler(this.nudSection6_ValueChanged);
            // 
            // nudSection5
            // 
            this.nudSection5.DecimalPlaces = 2;
            this.nudSection5.Font = new System.Drawing.Font("Arial Narrow", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSection5.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.nudSection5.Location = new System.Drawing.Point(640, 173);
            this.nudSection5.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudSection5.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.nudSection5.Name = "nudSection5";
            this.nudSection5.Size = new System.Drawing.Size(88, 48);
            this.nudSection5.TabIndex = 13;
            this.nudSection5.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSection5.ValueChanged += new System.EventHandler(this.nudSection5_ValueChanged);
            // 
            // nudSection4
            // 
            this.nudSection4.DecimalPlaces = 2;
            this.nudSection4.Font = new System.Drawing.Font("Arial Narrow", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSection4.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.nudSection4.Location = new System.Drawing.Point(485, 173);
            this.nudSection4.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudSection4.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.nudSection4.Name = "nudSection4";
            this.nudSection4.Size = new System.Drawing.Size(88, 48);
            this.nudSection4.TabIndex = 12;
            this.nudSection4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSection4.ValueChanged += new System.EventHandler(this.nudSection4_ValueChanged);
            // 
            // nudSection3
            // 
            this.nudSection3.DecimalPlaces = 2;
            this.nudSection3.Font = new System.Drawing.Font("Arial Narrow", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSection3.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.nudSection3.Location = new System.Drawing.Point(330, 173);
            this.nudSection3.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudSection3.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.nudSection3.Name = "nudSection3";
            this.nudSection3.Size = new System.Drawing.Size(88, 48);
            this.nudSection3.TabIndex = 11;
            this.nudSection3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSection3.ValueChanged += new System.EventHandler(this.nudSection3_ValueChanged);
            // 
            // nudSection2
            // 
            this.nudSection2.DecimalPlaces = 2;
            this.nudSection2.Font = new System.Drawing.Font("Arial Narrow", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSection2.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.nudSection2.Location = new System.Drawing.Point(175, 173);
            this.nudSection2.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudSection2.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.nudSection2.Name = "nudSection2";
            this.nudSection2.Size = new System.Drawing.Size(88, 48);
            this.nudSection2.TabIndex = 10;
            this.nudSection2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSection2.ValueChanged += new System.EventHandler(this.nudSection2_ValueChanged);
            // 
            // nudSection1
            // 
            this.nudSection1.DecimalPlaces = 2;
            this.nudSection1.Font = new System.Drawing.Font("Arial Narrow", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSection1.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.nudSection1.Location = new System.Drawing.Point(20, 173);
            this.nudSection1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudSection1.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.nudSection1.Name = "nudSection1";
            this.nudSection1.Size = new System.Drawing.Size(88, 48);
            this.nudSection1.TabIndex = 9;
            this.nudSection1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSection1.ValueChanged += new System.EventHandler(this.nudSection1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sections";
            // 
            // nudNumberOfSections
            // 
            this.nudNumberOfSections.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNumberOfSections.Location = new System.Drawing.Point(51, 296);
            this.nudNumberOfSections.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudNumberOfSections.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfSections.Name = "nudNumberOfSections";
            this.nudNumberOfSections.Size = new System.Drawing.Size(58, 46);
            this.nudNumberOfSections.TabIndex = 0;
            this.nudNumberOfSections.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfSections.ValueChanged += new System.EventHandler(this.nudNumberOfSections_ValueChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.Location = new System.Drawing.Point(814, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 73);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bntSectionOK
            // 
            this.bntSectionOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntSectionOK.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntSectionOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntSectionOK.Location = new System.Drawing.Point(745, 281);
            this.bntSectionOK.Name = "bntSectionOK";
            this.bntSectionOK.Size = new System.Drawing.Size(156, 74);
            this.bntSectionOK.TabIndex = 7;
            this.bntSectionOK.Text = "Save";
            this.bntSectionOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntSectionOK.UseVisualStyleBackColor = true;
            this.bntSectionOK.Click += new System.EventHandler(this.bntSectionOK_Click);
            // 
            // btnHomeSerial
            // 
            this.btnHomeSerial.BackColor = System.Drawing.Color.LightGray;
            this.btnHomeSerial.Controls.Add(this.button1);
            this.btnHomeSerial.Controls.Add(this.label99);
            this.btnHomeSerial.Controls.Add(this.nudNMEAHz);
            this.btnHomeSerial.Controls.Add(this.btnOpenSerial);
            this.btnHomeSerial.Controls.Add(this.btnCloseSerial);
            this.btnHomeSerial.Controls.Add(this.label1);
            this.btnHomeSerial.Controls.Add(this.textBoxRcv);
            this.btnHomeSerial.Controls.Add(this.btnRescan);
            this.btnHomeSerial.Controls.Add(this.cboxBaud);
            this.btnHomeSerial.Controls.Add(this.cboxPort);
            this.btnHomeSerial.Controls.Add(this.btnSerialOK);
            this.btnHomeSerial.Location = new System.Drawing.Point(4, 27);
            this.btnHomeSerial.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomeSerial.Name = "btnHomeSerial";
            this.btnHomeSerial.Padding = new System.Windows.Forms.Padding(4);
            this.btnHomeSerial.Size = new System.Drawing.Size(905, 359);
            this.btnHomeSerial.TabIndex = 0;
            this.btnHomeSerial.Text = "Serial Port";
            this.btnHomeSerial.ToolTipText = "Setting of Com Ports and Communication with Antenna";
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.button1.Location = new System.Drawing.Point(814, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 72);
            this.button1.TabIndex = 48;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(487, 35);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(149, 18);
            this.label99.TabIndex = 47;
            this.label99.Text = "RMC Update (Hz)";
            // 
            // nudNMEAHz
            // 
            this.nudNMEAHz.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNMEAHz.Location = new System.Drawing.Point(522, 65);
            this.nudNMEAHz.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNMEAHz.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNMEAHz.Name = "nudNMEAHz";
            this.nudNMEAHz.Size = new System.Drawing.Size(60, 66);
            this.nudNMEAHz.TabIndex = 46;
            this.nudNMEAHz.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNMEAHz.ValueChanged += new System.EventHandler(this.nudNMEAHz_ValueChanged);
            // 
            // btnOpenSerial
            // 
            this.btnOpenSerial.Location = new System.Drawing.Point(282, 33);
            this.btnOpenSerial.Name = "btnOpenSerial";
            this.btnOpenSerial.Size = new System.Drawing.Size(117, 36);
            this.btnOpenSerial.TabIndex = 45;
            this.btnOpenSerial.Text = "Connect";
            this.btnOpenSerial.UseVisualStyleBackColor = true;
            this.btnOpenSerial.Click += new System.EventHandler(this.btnOpenSerial_Click);
            // 
            // btnCloseSerial
            // 
            this.btnCloseSerial.Location = new System.Drawing.Point(282, 88);
            this.btnCloseSerial.Name = "btnCloseSerial";
            this.btnCloseSerial.Size = new System.Drawing.Size(117, 36);
            this.btnCloseSerial.TabIndex = 44;
            this.btnCloseSerial.Text = "Disconnect";
            this.btnCloseSerial.UseVisualStyleBackColor = true;
            this.btnCloseSerial.Click += new System.EventHandler(this.btnCloseSerial_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 16);
            this.label1.TabIndex = 41;
            this.label1.Text = "NMEA string from COM Port:";
            // 
            // textBoxRcv
            // 
            this.textBoxRcv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRcv.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRcv.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRcv.Location = new System.Drawing.Point(25, 188);
            this.textBoxRcv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRcv.Name = "textBoxRcv";
            this.textBoxRcv.ReadOnly = true;
            this.textBoxRcv.Size = new System.Drawing.Size(765, 23);
            this.textBoxRcv.TabIndex = 40;
            // 
            // btnRescan
            // 
            this.btnRescan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRescan.Location = new System.Drawing.Point(25, 88);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(96, 45);
            this.btnRescan.TabIndex = 39;
            this.btnRescan.Text = "Rescan Ports";
            this.btnRescan.UseVisualStyleBackColor = true;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // cboxBaud
            // 
            this.cboxBaud.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cboxBaud.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxBaud.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboxBaud.FormattingEnabled = true;
            this.cboxBaud.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cboxBaud.Location = new System.Drawing.Point(149, 33);
            this.cboxBaud.Name = "cboxBaud";
            this.cboxBaud.Size = new System.Drawing.Size(96, 31);
            this.cboxBaud.TabIndex = 37;
            this.cboxBaud.Text = "Baud";
            this.cboxBaud.SelectedIndexChanged += new System.EventHandler(this.cboxBaud_SelectedIndexChanged);
            // 
            // cboxPort
            // 
            this.cboxPort.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cboxPort.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxPort.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboxPort.FormattingEnabled = true;
            this.cboxPort.Location = new System.Drawing.Point(25, 33);
            this.cboxPort.Name = "cboxPort";
            this.cboxPort.Size = new System.Drawing.Size(96, 31);
            this.cboxPort.TabIndex = 36;
            this.cboxPort.Text = "Port";
            this.cboxPort.SelectedIndexChanged += new System.EventHandler(this.cboxPort_SelectedIndexChanged);
            // 
            // btnSerialOK
            // 
            this.btnSerialOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialOK.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSerialOK.Image = ((System.Drawing.Image)(resources.GetObject("btnSerialOK.Image")));
            this.btnSerialOK.Location = new System.Drawing.Point(748, 282);
            this.btnSerialOK.Name = "btnSerialOK";
            this.btnSerialOK.Size = new System.Drawing.Size(152, 72);
            this.btnSerialOK.TabIndex = 43;
            this.btnSerialOK.Text = "Save";
            this.btnSerialOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSerialOK.UseVisualStyleBackColor = true;
            this.btnSerialOK.Click += new System.EventHandler(this.btnSerialOK_Click);
            // 
            // tabGuidance
            // 
            this.tabGuidance.BackgroundImage = global::AgOpenGPS.Properties.Resources.GuidanceDimensions;
            this.tabGuidance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabGuidance.Controls.Add(this.button3);
            this.tabGuidance.Controls.Add(this.btnGuidanceOK);
            this.tabGuidance.Controls.Add(this.lblOverlapInches);
            this.tabGuidance.Controls.Add(this.lblOverlapFeet);
            this.tabGuidance.Controls.Add(this.label12);
            this.tabGuidance.Controls.Add(this.nudOverlap);
            this.tabGuidance.Location = new System.Drawing.Point(4, 27);
            this.tabGuidance.Name = "tabGuidance";
            this.tabGuidance.Size = new System.Drawing.Size(905, 359);
            this.tabGuidance.TabIndex = 4;
            this.tabGuidance.Text = "Guidance";
            this.tabGuidance.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.button3.Location = new System.Drawing.Point(814, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 72);
            this.button3.TabIndex = 51;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGuidanceOK
            // 
            this.btnGuidanceOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuidanceOK.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuidanceOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnGuidanceOK.Location = new System.Drawing.Point(746, 280);
            this.btnGuidanceOK.Name = "btnGuidanceOK";
            this.btnGuidanceOK.Size = new System.Drawing.Size(156, 74);
            this.btnGuidanceOK.TabIndex = 50;
            this.btnGuidanceOK.Text = "Save";
            this.btnGuidanceOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnGuidanceOK.UseVisualStyleBackColor = true;
            this.btnGuidanceOK.Click += new System.EventHandler(this.btnGuidanceOK_Click);
            // 
            // lblOverlapInches
            // 
            this.lblOverlapInches.AutoSize = true;
            this.lblOverlapInches.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverlapInches.Location = new System.Drawing.Point(213, 209);
            this.lblOverlapInches.Name = "lblOverlapInches";
            this.lblOverlapInches.Size = new System.Drawing.Size(57, 35);
            this.lblOverlapInches.TabIndex = 25;
            this.lblOverlapInches.Text = "YY";
            this.lblOverlapInches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOverlapFeet
            // 
            this.lblOverlapFeet.AutoSize = true;
            this.lblOverlapFeet.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverlapFeet.Location = new System.Drawing.Point(145, 209);
            this.lblOverlapFeet.Name = "lblOverlapFeet";
            this.lblOverlapFeet.Size = new System.Drawing.Size(59, 35);
            this.lblOverlapFeet.TabIndex = 24;
            this.lblOverlapFeet.Text = "XX";
            this.lblOverlapFeet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(136, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 29);
            this.label12.TabIndex = 23;
            this.label12.Text = "Overlap";
            // 
            // nudOverlap
            // 
            this.nudOverlap.DecimalPlaces = 2;
            this.nudOverlap.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudOverlap.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.nudOverlap.Location = new System.Drawing.Point(131, 135);
            this.nudOverlap.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudOverlap.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147418112});
            this.nudOverlap.Name = "nudOverlap";
            this.nudOverlap.Size = new System.Drawing.Size(145, 66);
            this.nudOverlap.TabIndex = 21;
            this.nudOverlap.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudOverlap.ValueChanged += new System.EventHandler(this.nudOverlap_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(475, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(283, 18);
            this.label14.TabIndex = 57;
            this.label14.Text = "Don\'t forget to Save each page";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 402);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageVehicle.ResumeLayout(false);
            this.tabPageVehicle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAntennaHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLookAhead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForeAft)).EndInit();
            this.tabPageSections.ResumeLayout(false);
            this.tabPageSections.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSection6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSection5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSection4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSection3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfSections)).EndInit();
            this.btnHomeSerial.ResumeLayout(false);
            this.btnHomeSerial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNMEAHz)).EndInit();
            this.tabGuidance.ResumeLayout(false);
            this.tabGuidance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverlap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage btnHomeSerial;
        private System.Windows.Forms.TabPage tabPageVehicle;
        private System.Windows.Forms.ComboBox cboxBaud;
        private System.Windows.Forms.ComboBox cboxPort;
        private System.Windows.Forms.Button btnRescan;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxRcv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSerialOK;
        private System.Windows.Forms.Button btnVehicleOK;
        private System.Windows.Forms.Button btnCloseSerial;
        private System.Windows.Forms.Button btnOpenSerial;
        private System.Windows.Forms.Label lblForeAftInches;
        private System.Windows.Forms.Label lblForeAftFeet;
        private System.Windows.Forms.NumericUpDown nudForeAft;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPageSections;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudNumberOfSections;
        private System.Windows.Forms.Button bntSectionOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudSection6;
        private System.Windows.Forms.NumericUpDown nudSection5;
        private System.Windows.Forms.NumericUpDown nudSection4;
        private System.Windows.Forms.NumericUpDown nudSection3;
        private System.Windows.Forms.NumericUpDown nudSection2;
        private System.Windows.Forms.NumericUpDown nudSection1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblSection1Inch;
        private System.Windows.Forms.Label lblSection6Inch;
        private System.Windows.Forms.Label lblSection5Inch;
        private System.Windows.Forms.Label lblSection4Inch;
        private System.Windows.Forms.Label lblSection3Inch;
        private System.Windows.Forms.Label lblSection2Inch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblVehicleToolWidth;
        private System.Windows.Forms.Label lblSecTotalWidthInches;
        private System.Windows.Forms.Label lblSecTotalWidthFeet;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSection5Width;
        private System.Windows.Forms.Label lblSection4Width;
        private System.Windows.Forms.Label lblSection3Width;
        private System.Windows.Forms.Label lblSection2Width;
        private System.Windows.Forms.Label lblSection1Width;
        private System.Windows.Forms.Label lblTractor;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.NumericUpDown nudNMEAHz;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudLookAhead;
        private System.Windows.Forms.TabPage tabGuidance;
        private System.Windows.Forms.Label lblOverlapInches;
        private System.Windows.Forms.Label lblOverlapFeet;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudOverlap;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnGuidanceOK;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nudAntennaHeight;
        private System.Windows.Forms.Label lblAntennaInches;
        private System.Windows.Forms.Label lblAntennaFeet;
        private System.Windows.Forms.Label lblToolMarker;
        private System.Windows.Forms.Label label14;
    }
}