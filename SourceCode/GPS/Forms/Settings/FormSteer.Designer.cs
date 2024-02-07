namespace AgOpenGPS
{
    partial class FormSteer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSteer));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblSteerAngle = new System.Windows.Forms.Label();
            this.lblSteerAngleActual = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblPWMDisplay = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCalcSteerAngleInner = new System.Windows.Forms.Label();
            this.lblDiameter = new System.Windows.Forms.Label();
            this.pbarSensor = new System.Windows.Forms.ProgressBar();
            this.lblPercentFS = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSteer = new System.Windows.Forms.TabPage();
            this.label23 = new System.Windows.Forms.Label();
            this.lblMaxSteerAngle = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.hsbarAckerman = new System.Windows.Forms.HScrollBar();
            this.hsbarMaxSteerAngle = new System.Windows.Forms.HScrollBar();
            this.lblAckerman = new System.Windows.Forms.Label();
            this.pbarRight = new System.Windows.Forms.ProgressBar();
            this.pbarLeft = new System.Windows.Forms.ProgressBar();
            this.lblActualSteerAngleUpper = new System.Windows.Forms.Label();
            this.btnZeroWAS = new System.Windows.Forms.Button();
            this.hsbarCountsPerDegree = new System.Windows.Forms.HScrollBar();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCountsPerDegree = new System.Windows.Forms.Label();
            this.hsbarWasOffset = new System.Windows.Forms.HScrollBar();
            this.lblSteerAngleSensorZero = new System.Windows.Forms.Label();
            this.tabGain = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hsbarMinPWM = new System.Windows.Forms.HScrollBar();
            this.hsbarProportionalGain = new System.Windows.Forms.HScrollBar();
            this.lblProportionalGain = new System.Windows.Forms.Label();
            this.lblHighSteerPWM = new System.Windows.Forms.Label();
            this.lblMinPWM = new System.Windows.Forms.Label();
            this.hsbarHighSteerPWM = new System.Windows.Forms.HScrollBar();
            this.tabStan = new System.Windows.Forms.TabPage();
            this.lblIntegralPercent = new System.Windows.Forms.Label();
            this.hsbarIntegral = new System.Windows.Forms.HScrollBar();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblHeadingErrorGain = new System.Windows.Forms.Label();
            this.lblStanleyGain = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hsbarStanleyGain = new System.Windows.Forms.HScrollBar();
            this.hsbarHeadingErrorGain = new System.Windows.Forms.HScrollBar();
            this.tabInt = new System.Windows.Forms.TabPage();
            this.label32 = new System.Windows.Forms.Label();
            this.lblHoldLookAhead = new System.Windows.Forms.Label();
            this.hsbarHoldLookAhead = new System.Windows.Forms.HScrollBar();
            this.lblPureIntegral = new System.Windows.Forms.Label();
            this.hsbarIntegralPurePursuit = new System.Windows.Forms.HScrollBar();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.hsbarLookAheadMult = new System.Windows.Forms.HScrollBar();
            this.lblLookAhead = new System.Windows.Forms.Label();
            this.lblLookAheadMult = new System.Windows.Forms.Label();
            this.hsbarLookAhead = new System.Windows.Forms.HScrollBar();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblSideHillComp = new System.Windows.Forms.Label();
            this.hsbarSideHillComp = new System.Windows.Forms.HScrollBar();
            this.label22 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.labelPressureTurnSensor = new System.Windows.Forms.Label();
            this.labelCurrentTurnSensor = new System.Windows.Forms.Label();
            this.labelEncoder = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.cboxMotorDrive = new System.Windows.Forms.ComboBox();
            this.cboxSteerEnable = new System.Windows.Forms.ComboBox();
            this.label62 = new System.Windows.Forms.Label();
            this.cboxConv = new System.Windows.Forms.ComboBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.nudMaxCounts = new System.Windows.Forms.NumericUpDown();
            this.label55 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStartSA = new System.Windows.Forms.Button();
            this.btnFreeDriveZero = new System.Windows.Forms.Button();
            this.btnSteerAngleUp = new ProXoft.WinForms.RepeatButton();
            this.btnFreeDrive = new System.Windows.Forms.Button();
            this.btnSteerAngleDown = new ProXoft.WinForms.RepeatButton();
            this.hsbarSensor = new System.Windows.Forms.HScrollBar();
            this.lblhsbarSensor = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.nudPanicStopSpeed = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cboxCurrentSensor = new System.Windows.Forms.CheckBox();
            this.cboxPressureSensor = new System.Windows.Forms.CheckBox();
            this.pboxSendSteer = new System.Windows.Forms.PictureBox();
            this.cboxDanfoss = new System.Windows.Forms.CheckBox();
            this.chkSteerInvertRelays = new System.Windows.Forms.CheckBox();
            this.chkInvertSteer = new System.Windows.Forms.CheckBox();
            this.cboxEncoder = new System.Windows.Forms.CheckBox();
            this.chkInvertWAS = new System.Windows.Forms.CheckBox();
            this.btnSendSteerConfigPGN = new System.Windows.Forms.Button();
            this.cboxXY = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.btnStanleyPure = new System.Windows.Forms.Button();
            this.lblAV_Set = new System.Windows.Forms.Label();
            this.lblAV_Act = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabSteer.SuspendLayout();
            this.tabGain.SuspendLayout();
            this.tabStan.SuspendLayout();
            this.tabInt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCounts)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPanicStopSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSendSteer)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // lblSteerAngle
            // 
            this.lblSteerAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSteerAngle.BackColor = System.Drawing.Color.Transparent;
            this.lblSteerAngle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerAngle.ForeColor = System.Drawing.Color.Black;
            this.lblSteerAngle.Location = new System.Drawing.Point(52, 5);
            this.lblSteerAngle.Name = "lblSteerAngle";
            this.lblSteerAngle.Size = new System.Drawing.Size(70, 23);
            this.lblSteerAngle.TabIndex = 306;
            this.lblSteerAngle.Text = "-55.5";
            this.lblSteerAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSteerAngle.Click += new System.EventHandler(this.expandWindow_Click);
            // 
            // lblSteerAngleActual
            // 
            this.lblSteerAngleActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSteerAngleActual.BackColor = System.Drawing.Color.Transparent;
            this.lblSteerAngleActual.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerAngleActual.ForeColor = System.Drawing.Color.Black;
            this.lblSteerAngleActual.Location = new System.Drawing.Point(174, 5);
            this.lblSteerAngleActual.Name = "lblSteerAngleActual";
            this.lblSteerAngleActual.Size = new System.Drawing.Size(70, 23);
            this.lblSteerAngleActual.TabIndex = 311;
            this.lblSteerAngleActual.Text = "-55.5";
            this.lblSteerAngleActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSteerAngleActual.Click += new System.EventHandler(this.expandWindow_Click);
            // 
            // lblError
            // 
            this.lblError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Black;
            this.lblError.Location = new System.Drawing.Point(286, 5);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(62, 23);
            this.lblError.TabIndex = 312;
            this.lblError.Text = "-30.0";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Click += new System.EventHandler(this.expandWindow_Click);
            // 
            // lblPWMDisplay
            // 
            this.lblPWMDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPWMDisplay.BackColor = System.Drawing.Color.Transparent;
            this.lblPWMDisplay.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPWMDisplay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPWMDisplay.Location = new System.Drawing.Point(78, 81);
            this.lblPWMDisplay.Name = "lblPWMDisplay";
            this.lblPWMDisplay.Size = new System.Drawing.Size(64, 23);
            this.lblPWMDisplay.TabIndex = 316;
            this.lblPWMDisplay.Text = "255";
            this.lblPWMDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(17, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 318;
            this.label9.Text = "PWM:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(133, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 23);
            this.label11.TabIndex = 319;
            this.label11.Text = "Act:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Click += new System.EventHandler(this.expandWindow_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(7, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 23);
            this.label12.TabIndex = 320;
            this.label12.Text = "Set:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Click += new System.EventHandler(this.expandWindow_Click);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(246, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 23);
            this.label13.TabIndex = 321;
            this.label13.Text = "Err:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label13.Click += new System.EventHandler(this.expandWindow_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(289, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 16);
            this.label14.TabIndex = 322;
            this.label14.Text = "Or +5";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(92, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 23);
            this.label8.TabIndex = 328;
            this.label8.Text = "Steer Angle:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(112, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 23);
            this.label1.TabIndex = 327;
            this.label1.Text = "Diameter:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCalcSteerAngleInner
            // 
            this.lblCalcSteerAngleInner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCalcSteerAngleInner.AutoSize = true;
            this.lblCalcSteerAngleInner.BackColor = System.Drawing.Color.Transparent;
            this.lblCalcSteerAngleInner.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalcSteerAngleInner.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCalcSteerAngleInner.Location = new System.Drawing.Point(209, 146);
            this.lblCalcSteerAngleInner.Name = "lblCalcSteerAngleInner";
            this.lblCalcSteerAngleInner.Size = new System.Drawing.Size(40, 23);
            this.lblCalcSteerAngleInner.TabIndex = 326;
            this.lblCalcSteerAngleInner.Text = "0.0";
            this.lblCalcSteerAngleInner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiameter
            // 
            this.lblDiameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDiameter.AutoSize = true;
            this.lblDiameter.BackColor = System.Drawing.Color.Transparent;
            this.lblDiameter.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiameter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDiameter.Location = new System.Drawing.Point(206, 181);
            this.lblDiameter.Name = "lblDiameter";
            this.lblDiameter.Size = new System.Drawing.Size(64, 23);
            this.lblDiameter.TabIndex = 325;
            this.lblDiameter.Text = "0.0 m";
            this.lblDiameter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbarSensor
            // 
            this.pbarSensor.Location = new System.Drawing.Point(402, 638);
            this.pbarSensor.Maximum = 255;
            this.pbarSensor.Name = "pbarSensor";
            this.pbarSensor.Size = new System.Drawing.Size(280, 26);
            this.pbarSensor.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbarSensor.TabIndex = 496;
            // 
            // lblPercentFS
            // 
            this.lblPercentFS.AutoSize = true;
            this.lblPercentFS.BackColor = System.Drawing.Color.Transparent;
            this.lblPercentFS.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentFS.ForeColor = System.Drawing.Color.Black;
            this.lblPercentFS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPercentFS.Location = new System.Drawing.Point(688, 635);
            this.lblPercentFS.Name = "lblPercentFS";
            this.lblPercentFS.Size = new System.Drawing.Size(57, 29);
            this.lblPercentFS.TabIndex = 495;
            this.lblPercentFS.Text = "0%";
            this.lblPercentFS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabSteer);
            this.tabControl1.Controls.Add(this.tabGain);
            this.tabControl1.Controls.Add(this.tabStan);
            this.tabControl1.Controls.Add(this.tabInt);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.ItemSize = new System.Drawing.Size(88, 48);
            this.tabControl1.Location = new System.Drawing.Point(3, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(366, 402);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 347;
            // 
            // tabSteer
            // 
            this.tabSteer.AutoScroll = true;
            this.tabSteer.BackColor = System.Drawing.Color.Gainsboro;
            this.tabSteer.BackgroundImage = global::AgOpenGPS.Properties.Resources.Sf_SteerTab;
            this.tabSteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabSteer.Controls.Add(this.label23);
            this.tabSteer.Controls.Add(this.lblAV_Set);
            this.tabSteer.Controls.Add(this.lblAV_Act);
            this.tabSteer.Controls.Add(this.lblMaxSteerAngle);
            this.tabSteer.Controls.Add(this.label36);
            this.tabSteer.Controls.Add(this.label17);
            this.tabSteer.Controls.Add(this.label38);
            this.tabSteer.Controls.Add(this.label7);
            this.tabSteer.Controls.Add(this.hsbarAckerman);
            this.tabSteer.Controls.Add(this.hsbarMaxSteerAngle);
            this.tabSteer.Controls.Add(this.lblAckerman);
            this.tabSteer.Controls.Add(this.pbarRight);
            this.tabSteer.Controls.Add(this.pbarLeft);
            this.tabSteer.Controls.Add(this.lblActualSteerAngleUpper);
            this.tabSteer.Controls.Add(this.btnZeroWAS);
            this.tabSteer.Controls.Add(this.hsbarCountsPerDegree);
            this.tabSteer.Controls.Add(this.label10);
            this.tabSteer.Controls.Add(this.lblCountsPerDegree);
            this.tabSteer.Controls.Add(this.hsbarWasOffset);
            this.tabSteer.Controls.Add(this.lblSteerAngleSensorZero);
            this.tabSteer.ImageIndex = 0;
            this.tabSteer.Location = new System.Drawing.Point(4, 52);
            this.tabSteer.Name = "tabSteer";
            this.tabSteer.Size = new System.Drawing.Size(358, 346);
            this.tabSteer.TabIndex = 5;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(61, 264);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(204, 30);
            this.label23.TabIndex = 341;
            this.label23.Text = "Max Steer Angle";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxSteerAngle
            // 
            this.lblMaxSteerAngle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxSteerAngle.ForeColor = System.Drawing.Color.Black;
            this.lblMaxSteerAngle.Location = new System.Drawing.Point(11, 291);
            this.lblMaxSteerAngle.Name = "lblMaxSteerAngle";
            this.lblMaxSteerAngle.Size = new System.Drawing.Size(52, 35);
            this.lblMaxSteerAngle.TabIndex = 303;
            this.lblMaxSteerAngle.Text = "888";
            this.lblMaxSteerAngle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(125, 206);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 19);
            this.label17.TabIndex = 335;
            this.label17.Text = "Ackermann";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(94, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 19);
            this.label7.TabIndex = 334;
            this.label7.Text = "Counts per Degree";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarAckerman
            // 
            this.hsbarAckerman.LargeChange = 1;
            this.hsbarAckerman.Location = new System.Drawing.Point(65, 228);
            this.hsbarAckerman.Maximum = 200;
            this.hsbarAckerman.Minimum = 1;
            this.hsbarAckerman.Name = "hsbarAckerman";
            this.hsbarAckerman.Size = new System.Drawing.Size(200, 30);
            this.hsbarAckerman.TabIndex = 331;
            this.hsbarAckerman.Value = 100;
            this.hsbarAckerman.ValueChanged += new System.EventHandler(this.hsbarAckerman_ValueChanged);
            this.hsbarAckerman.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.hsbarAckerman_HelpRequested);
            // 
            // hsbarMaxSteerAngle
            // 
            this.hsbarMaxSteerAngle.LargeChange = 1;
            this.hsbarMaxSteerAngle.Location = new System.Drawing.Point(65, 294);
            this.hsbarMaxSteerAngle.Maximum = 80;
            this.hsbarMaxSteerAngle.Minimum = 10;
            this.hsbarMaxSteerAngle.Name = "hsbarMaxSteerAngle";
            this.hsbarMaxSteerAngle.Size = new System.Drawing.Size(200, 30);
            this.hsbarMaxSteerAngle.TabIndex = 299;
            this.hsbarMaxSteerAngle.Value = 10;
            this.hsbarMaxSteerAngle.ValueChanged += new System.EventHandler(this.hsbarMaxSteerAngle_ValueChanged);
            this.hsbarMaxSteerAngle.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.hsbarMaxSteerAngle_HelpRequested);
            // 
            // lblAckerman
            // 
            this.lblAckerman.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAckerman.ForeColor = System.Drawing.Color.Black;
            this.lblAckerman.Location = new System.Drawing.Point(9, 223);
            this.lblAckerman.Name = "lblAckerman";
            this.lblAckerman.Size = new System.Drawing.Size(55, 35);
            this.lblAckerman.TabIndex = 333;
            this.lblAckerman.Text = "888";
            this.lblAckerman.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbarRight
            // 
            this.pbarRight.Location = new System.Drawing.Point(171, 2);
            this.pbarRight.Maximum = 50;
            this.pbarRight.Name = "pbarRight";
            this.pbarRight.Size = new System.Drawing.Size(159, 10);
            this.pbarRight.TabIndex = 330;
            // 
            // pbarLeft
            // 
            this.pbarLeft.Location = new System.Drawing.Point(11, 2);
            this.pbarLeft.Maximum = 50;
            this.pbarLeft.Name = "pbarLeft";
            this.pbarLeft.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pbarLeft.RightToLeftLayout = true;
            this.pbarLeft.Size = new System.Drawing.Size(159, 10);
            this.pbarLeft.TabIndex = 329;
            // 
            // lblActualSteerAngleUpper
            // 
            this.lblActualSteerAngleUpper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActualSteerAngleUpper.AutoSize = true;
            this.lblActualSteerAngleUpper.BackColor = System.Drawing.Color.Transparent;
            this.lblActualSteerAngleUpper.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualSteerAngleUpper.ForeColor = System.Drawing.Color.Black;
            this.lblActualSteerAngleUpper.Location = new System.Drawing.Point(43, 16);
            this.lblActualSteerAngleUpper.Name = "lblActualSteerAngleUpper";
            this.lblActualSteerAngleUpper.Size = new System.Drawing.Size(39, 19);
            this.lblActualSteerAngleUpper.TabIndex = 324;
            this.lblActualSteerAngleUpper.Text = "255";
            this.lblActualSteerAngleUpper.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnZeroWAS
            // 
            this.btnZeroWAS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZeroWAS.FlatAppearance.BorderSize = 0;
            this.btnZeroWAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZeroWAS.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroWAS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZeroWAS.Image = global::AgOpenGPS.Properties.Resources.SteerZero;
            this.btnZeroWAS.Location = new System.Drawing.Point(132, 15);
            this.btnZeroWAS.Name = "btnZeroWAS";
            this.btnZeroWAS.Size = new System.Drawing.Size(70, 30);
            this.btnZeroWAS.TabIndex = 323;
            this.btnZeroWAS.UseVisualStyleBackColor = true;
            this.btnZeroWAS.Click += new System.EventHandler(this.btnZeroWAS_Click);
            this.btnZeroWAS.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnZeroWAS_HelpRequested);
            // 
            // hsbarCountsPerDegree
            // 
            this.hsbarCountsPerDegree.LargeChange = 1;
            this.hsbarCountsPerDegree.Location = new System.Drawing.Point(65, 162);
            this.hsbarCountsPerDegree.Maximum = 255;
            this.hsbarCountsPerDegree.Minimum = 1;
            this.hsbarCountsPerDegree.Name = "hsbarCountsPerDegree";
            this.hsbarCountsPerDegree.Size = new System.Drawing.Size(200, 30);
            this.hsbarCountsPerDegree.TabIndex = 304;
            this.hsbarCountsPerDegree.Value = 20;
            this.hsbarCountsPerDegree.ValueChanged += new System.EventHandler(this.hsbarCountsPerDegree_ValueChanged);
            this.hsbarCountsPerDegree.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.hsbarCountsPerDegree_HelpRequested);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(122, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 25);
            this.label10.TabIndex = 295;
            this.label10.Text = "WAS Zero";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCountsPerDegree
            // 
            this.lblCountsPerDegree.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountsPerDegree.ForeColor = System.Drawing.Color.Black;
            this.lblCountsPerDegree.Location = new System.Drawing.Point(9, 157);
            this.lblCountsPerDegree.Name = "lblCountsPerDegree";
            this.lblCountsPerDegree.Size = new System.Drawing.Size(55, 35);
            this.lblCountsPerDegree.TabIndex = 308;
            this.lblCountsPerDegree.Text = "888";
            this.lblCountsPerDegree.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarWasOffset
            // 
            this.hsbarWasOffset.LargeChange = 20;
            this.hsbarWasOffset.Location = new System.Drawing.Point(77, 91);
            this.hsbarWasOffset.Maximum = 4000;
            this.hsbarWasOffset.Minimum = -4000;
            this.hsbarWasOffset.Name = "hsbarWasOffset";
            this.hsbarWasOffset.Size = new System.Drawing.Size(188, 30);
            this.hsbarWasOffset.SmallChange = 2;
            this.hsbarWasOffset.TabIndex = 294;
            this.hsbarWasOffset.ValueChanged += new System.EventHandler(this.hsbarSteerAngleSensorZero_ValueChanged);
            this.hsbarWasOffset.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.hsbarWasOffset_HelpRequested);
            // 
            // lblSteerAngleSensorZero
            // 
            this.lblSteerAngleSensorZero.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerAngleSensorZero.ForeColor = System.Drawing.Color.Black;
            this.lblSteerAngleSensorZero.Location = new System.Drawing.Point(8, 86);
            this.lblSteerAngleSensorZero.Name = "lblSteerAngleSensorZero";
            this.lblSteerAngleSensorZero.Size = new System.Drawing.Size(70, 35);
            this.lblSteerAngleSensorZero.TabIndex = 298;
            this.lblSteerAngleSensorZero.Text = "-55.88";
            this.lblSteerAngleSensorZero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabGain
            // 
            this.tabGain.AutoScroll = true;
            this.tabGain.BackColor = System.Drawing.Color.Gainsboro;
            this.tabGain.BackgroundImage = global::AgOpenGPS.Properties.Resources.Sf_GainTab;
            this.tabGain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabGain.Controls.Add(this.label6);
            this.tabGain.Controls.Add(this.label15);
            this.tabGain.Controls.Add(this.label4);
            this.tabGain.Controls.Add(this.label2);
            this.tabGain.Controls.Add(this.hsbarMinPWM);
            this.tabGain.Controls.Add(this.hsbarProportionalGain);
            this.tabGain.Controls.Add(this.lblProportionalGain);
            this.tabGain.Controls.Add(this.lblHighSteerPWM);
            this.tabGain.Controls.Add(this.lblMinPWM);
            this.tabGain.Controls.Add(this.hsbarHighSteerPWM);
            this.tabGain.ImageIndex = 1;
            this.tabGain.Location = new System.Drawing.Point(4, 52);
            this.tabGain.Name = "tabGain";
            this.tabGain.Size = new System.Drawing.Size(358, 346);
            this.tabGain.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(43, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(262, 25);
            this.label6.TabIndex = 339;
            this.label6.Text = "Motor or Hydraulic Gain";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(108, 246);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(136, 19);
            this.label15.TabIndex = 338;
            this.label15.Text = "Minimum to Move";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(112, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 19);
            this.label4.TabIndex = 336;
            this.label4.Text = "Maximum Limit";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(107, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 19);
            this.label2.TabIndex = 335;
            this.label2.Text = "Proportional Gain";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarMinPWM
            // 
            this.hsbarMinPWM.LargeChange = 1;
            this.hsbarMinPWM.Location = new System.Drawing.Point(68, 269);
            this.hsbarMinPWM.Name = "hsbarMinPWM";
            this.hsbarMinPWM.Size = new System.Drawing.Size(202, 30);
            this.hsbarMinPWM.TabIndex = 284;
            this.hsbarMinPWM.Value = 10;
            this.hsbarMinPWM.ValueChanged += new System.EventHandler(this.hsbarMinPWM_ValueChanged);
            this.hsbarMinPWM.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.hsbarMinPWM_HelpRequested);
            // 
            // hsbarProportionalGain
            // 
            this.hsbarProportionalGain.LargeChange = 1;
            this.hsbarProportionalGain.Location = new System.Drawing.Point(68, 89);
            this.hsbarProportionalGain.Maximum = 200;
            this.hsbarProportionalGain.Name = "hsbarProportionalGain";
            this.hsbarProportionalGain.Size = new System.Drawing.Size(202, 30);
            this.hsbarProportionalGain.TabIndex = 254;
            this.hsbarProportionalGain.Value = 4;
            this.hsbarProportionalGain.ValueChanged += new System.EventHandler(this.hsbarProportionalGain_ValueChanged);
            this.hsbarProportionalGain.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.hsbarProportionalGain_HelpRequested);
            // 
            // lblProportionalGain
            // 
            this.lblProportionalGain.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProportionalGain.ForeColor = System.Drawing.Color.Black;
            this.lblProportionalGain.Location = new System.Drawing.Point(8, 87);
            this.lblProportionalGain.Name = "lblProportionalGain";
            this.lblProportionalGain.Size = new System.Drawing.Size(61, 35);
            this.lblProportionalGain.TabIndex = 258;
            this.lblProportionalGain.Text = "888";
            this.lblProportionalGain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHighSteerPWM
            // 
            this.lblHighSteerPWM.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighSteerPWM.ForeColor = System.Drawing.Color.Black;
            this.lblHighSteerPWM.Location = new System.Drawing.Point(8, 176);
            this.lblHighSteerPWM.Name = "lblHighSteerPWM";
            this.lblHighSteerPWM.Size = new System.Drawing.Size(61, 35);
            this.lblHighSteerPWM.TabIndex = 278;
            this.lblHighSteerPWM.Text = "888";
            this.lblHighSteerPWM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMinPWM
            // 
            this.lblMinPWM.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinPWM.ForeColor = System.Drawing.Color.Black;
            this.lblMinPWM.Location = new System.Drawing.Point(8, 266);
            this.lblMinPWM.Name = "lblMinPWM";
            this.lblMinPWM.Size = new System.Drawing.Size(61, 35);
            this.lblMinPWM.TabIndex = 288;
            this.lblMinPWM.Text = "888";
            this.lblMinPWM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarHighSteerPWM
            // 
            this.hsbarHighSteerPWM.LargeChange = 2;
            this.hsbarHighSteerPWM.Location = new System.Drawing.Point(68, 179);
            this.hsbarHighSteerPWM.Maximum = 255;
            this.hsbarHighSteerPWM.Name = "hsbarHighSteerPWM";
            this.hsbarHighSteerPWM.Size = new System.Drawing.Size(202, 30);
            this.hsbarHighSteerPWM.TabIndex = 274;
            this.hsbarHighSteerPWM.Value = 50;
            this.hsbarHighSteerPWM.ValueChanged += new System.EventHandler(this.hsbarHighSteerPWM_ValueChanged);
            this.hsbarHighSteerPWM.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.hsbarHighSteerPWM_HelpRequested);
            // 
            // tabStan
            // 
            this.tabStan.BackColor = System.Drawing.Color.Gainsboro;
            this.tabStan.BackgroundImage = global::AgOpenGPS.Properties.Resources.Sf_Stanley;
            this.tabStan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabStan.Controls.Add(this.lblIntegralPercent);
            this.tabStan.Controls.Add(this.hsbarIntegral);
            this.tabStan.Controls.Add(this.label27);
            this.tabStan.Controls.Add(this.label25);
            this.tabStan.Controls.Add(this.lblHeadingErrorGain);
            this.tabStan.Controls.Add(this.lblStanleyGain);
            this.tabStan.Controls.Add(this.label5);
            this.tabStan.Controls.Add(this.label3);
            this.tabStan.Controls.Add(this.hsbarStanleyGain);
            this.tabStan.Controls.Add(this.hsbarHeadingErrorGain);
            this.tabStan.ImageIndex = 2;
            this.tabStan.Location = new System.Drawing.Point(4, 52);
            this.tabStan.Name = "tabStan";
            this.tabStan.Size = new System.Drawing.Size(358, 346);
            this.tabStan.TabIndex = 15;
            // 
            // lblIntegralPercent
            // 
            this.lblIntegralPercent.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntegralPercent.ForeColor = System.Drawing.Color.Black;
            this.lblIntegralPercent.Location = new System.Drawing.Point(3, 259);
            this.lblIntegralPercent.Name = "lblIntegralPercent";
            this.lblIntegralPercent.Size = new System.Drawing.Size(60, 35);
            this.lblIntegralPercent.TabIndex = 352;
            this.lblIntegralPercent.Text = "888";
            this.lblIntegralPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarIntegral
            // 
            this.hsbarIntegral.LargeChange = 1;
            this.hsbarIntegral.Location = new System.Drawing.Point(68, 261);
            this.hsbarIntegral.Name = "hsbarIntegral";
            this.hsbarIntegral.Size = new System.Drawing.Size(202, 30);
            this.hsbarIntegral.TabIndex = 351;
            this.hsbarIntegral.Value = 5;
            this.hsbarIntegral.ValueChanged += new System.EventHandler(this.hsbarIntegral_ValueChanged);
            this.hsbarIntegral.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.hsbarIntegral_HelpRequested);
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(63, 232);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(204, 30);
            this.label27.TabIndex = 350;
            this.label27.Text = "Integral";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label27.UseCompatibleTextRendering = true;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Chocolate;
            this.label25.Location = new System.Drawing.Point(70, 3);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(201, 31);
            this.label25.TabIndex = 347;
            this.label25.Text = "Stanley Gains";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeadingErrorGain
            // 
            this.lblHeadingErrorGain.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadingErrorGain.ForeColor = System.Drawing.Color.Black;
            this.lblHeadingErrorGain.Location = new System.Drawing.Point(9, 166);
            this.lblHeadingErrorGain.Name = "lblHeadingErrorGain";
            this.lblHeadingErrorGain.Size = new System.Drawing.Size(54, 35);
            this.lblHeadingErrorGain.TabIndex = 295;
            this.lblHeadingErrorGain.Text = "888";
            this.lblHeadingErrorGain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStanleyGain
            // 
            this.lblStanleyGain.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStanleyGain.ForeColor = System.Drawing.Color.Black;
            this.lblStanleyGain.Location = new System.Drawing.Point(9, 78);
            this.lblStanleyGain.Name = "lblStanleyGain";
            this.lblStanleyGain.Size = new System.Drawing.Size(54, 35);
            this.lblStanleyGain.TabIndex = 299;
            this.lblStanleyGain.Text = "888";
            this.lblStanleyGain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(62, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 30);
            this.label5.TabIndex = 296;
            this.label5.Text = "Heading";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(63, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 28);
            this.label3.TabIndex = 298;
            this.label3.Text = "Distance";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarStanleyGain
            // 
            this.hsbarStanleyGain.LargeChange = 1;
            this.hsbarStanleyGain.Location = new System.Drawing.Point(68, 80);
            this.hsbarStanleyGain.Maximum = 40;
            this.hsbarStanleyGain.Minimum = 1;
            this.hsbarStanleyGain.Name = "hsbarStanleyGain";
            this.hsbarStanleyGain.Size = new System.Drawing.Size(200, 30);
            this.hsbarStanleyGain.TabIndex = 297;
            this.hsbarStanleyGain.Value = 10;
            this.hsbarStanleyGain.ValueChanged += new System.EventHandler(this.hsbarStanleyGain_ValueChanged);
            this.hsbarStanleyGain.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.hsbarStanleyGain_HelpRequested);
            // 
            // hsbarHeadingErrorGain
            // 
            this.hsbarHeadingErrorGain.LargeChange = 1;
            this.hsbarHeadingErrorGain.Location = new System.Drawing.Point(68, 170);
            this.hsbarHeadingErrorGain.Maximum = 15;
            this.hsbarHeadingErrorGain.Minimum = 1;
            this.hsbarHeadingErrorGain.Name = "hsbarHeadingErrorGain";
            this.hsbarHeadingErrorGain.Size = new System.Drawing.Size(200, 30);
            this.hsbarHeadingErrorGain.TabIndex = 294;
            this.hsbarHeadingErrorGain.Value = 10;
            this.hsbarHeadingErrorGain.ValueChanged += new System.EventHandler(this.hsbarHeadingErrorGain_ValueChanged);
            this.hsbarHeadingErrorGain.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.hsbarHeadingErrorGain_HelpRequested);
            // 
            // tabInt
            // 
            this.tabInt.BackColor = System.Drawing.Color.Gainsboro;
            this.tabInt.BackgroundImage = global::AgOpenGPS.Properties.Resources.Sf_PP;
            this.tabInt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabInt.Controls.Add(this.label32);
            this.tabInt.Controls.Add(this.lblHoldLookAhead);
            this.tabInt.Controls.Add(this.hsbarHoldLookAhead);
            this.tabInt.Controls.Add(this.lblPureIntegral);
            this.tabInt.Controls.Add(this.hsbarIntegralPurePursuit);
            this.tabInt.Controls.Add(this.label26);
            this.tabInt.Controls.Add(this.label24);
            this.tabInt.Controls.Add(this.label21);
            this.tabInt.Controls.Add(this.label20);
            this.tabInt.Controls.Add(this.label19);
            this.tabInt.Controls.Add(this.label18);
            this.tabInt.Controls.Add(this.hsbarLookAheadMult);
            this.tabInt.Controls.Add(this.lblLookAhead);
            this.tabInt.Controls.Add(this.lblLookAheadMult);
            this.tabInt.Controls.Add(this.hsbarLookAhead);
            this.tabInt.ForeColor = System.Drawing.Color.Black;
            this.tabInt.ImageIndex = 3;
            this.tabInt.Location = new System.Drawing.Point(4, 52);
            this.tabInt.Name = "tabInt";
            this.tabInt.Size = new System.Drawing.Size(358, 346);
            this.tabInt.TabIndex = 16;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(75, 110);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(204, 19);
            this.label32.TabIndex = 356;
            this.label32.Text = "Hold Look Ahead";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHoldLookAhead
            // 
            this.lblHoldLookAhead.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoldLookAhead.ForeColor = System.Drawing.Color.Black;
            this.lblHoldLookAhead.Location = new System.Drawing.Point(5, 129);
            this.lblHoldLookAhead.Name = "lblHoldLookAhead";
            this.lblHoldLookAhead.Size = new System.Drawing.Size(60, 35);
            this.lblHoldLookAhead.TabIndex = 355;
            this.lblHoldLookAhead.Text = "888";
            this.lblHoldLookAhead.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarHoldLookAhead
            // 
            this.hsbarHoldLookAhead.LargeChange = 1;
            this.hsbarHoldLookAhead.Location = new System.Drawing.Point(68, 132);
            this.hsbarHoldLookAhead.Maximum = 50;
            this.hsbarHoldLookAhead.Minimum = 10;
            this.hsbarHoldLookAhead.Name = "hsbarHoldLookAhead";
            this.hsbarHoldLookAhead.Size = new System.Drawing.Size(217, 30);
            this.hsbarHoldLookAhead.TabIndex = 354;
            this.hsbarHoldLookAhead.Value = 25;
            this.hsbarHoldLookAhead.ValueChanged += new System.EventHandler(this.hsbarHoldLookAhead_ValueChanged);
            this.hsbarHoldLookAhead.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.hsbarHoldLookAhead_HelpRequested);
            // 
            // lblPureIntegral
            // 
            this.lblPureIntegral.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPureIntegral.ForeColor = System.Drawing.Color.Black;
            this.lblPureIntegral.Location = new System.Drawing.Point(5, 285);
            this.lblPureIntegral.Name = "lblPureIntegral";
            this.lblPureIntegral.Size = new System.Drawing.Size(60, 35);
            this.lblPureIntegral.TabIndex = 350;
            this.lblPureIntegral.Text = "888";
            this.lblPureIntegral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarIntegralPurePursuit
            // 
            this.hsbarIntegralPurePursuit.LargeChange = 1;
            this.hsbarIntegralPurePursuit.Location = new System.Drawing.Point(68, 289);
            this.hsbarIntegralPurePursuit.Name = "hsbarIntegralPurePursuit";
            this.hsbarIntegralPurePursuit.Size = new System.Drawing.Size(217, 30);
            this.hsbarIntegralPurePursuit.TabIndex = 349;
            this.hsbarIntegralPurePursuit.Value = 5;
            this.hsbarIntegralPurePursuit.ValueChanged += new System.EventHandler(this.hsbarIntegralPurePursuit_ValueChanged);
            this.hsbarIntegralPurePursuit.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.hsbarIntegralPurePursuit_HelpRequested);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.SteelBlue;
            this.label26.Location = new System.Drawing.Point(58, 4);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(233, 17);
            this.label26.TabIndex = 348;
            this.label26.Text = "Pure Pursuit";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(74, 266);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(204, 19);
            this.label24.TabIndex = 342;
            this.label24.Text = "Integral";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label24.UseCompatibleTextRendering = true;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(74, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(204, 19);
            this.label21.TabIndex = 303;
            this.label21.Text = "Acquire Look Ahead";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label20.Location = new System.Drawing.Point(579, 228);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(204, 30);
            this.label20.TabIndex = 302;
            this.label20.Text = "Look Ahead Min";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(76, 188);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(204, 19);
            this.label19.TabIndex = 301;
            this.label19.Text = "Look Ahead Speed Gain";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label18.Location = new System.Drawing.Point(561, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(204, 30);
            this.label18.TabIndex = 300;
            this.label18.Text = "Look Ahead";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarLookAheadMult
            // 
            this.hsbarLookAheadMult.LargeChange = 1;
            this.hsbarLookAheadMult.Location = new System.Drawing.Point(70, 210);
            this.hsbarLookAheadMult.Maximum = 30;
            this.hsbarLookAheadMult.Minimum = 5;
            this.hsbarLookAheadMult.Name = "hsbarLookAheadMult";
            this.hsbarLookAheadMult.Size = new System.Drawing.Size(217, 30);
            this.hsbarLookAheadMult.TabIndex = 298;
            this.hsbarLookAheadMult.Value = 6;
            this.hsbarLookAheadMult.ValueChanged += new System.EventHandler(this.hsbarLookAheadMult_ValueChanged);
            this.hsbarLookAheadMult.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.hsbarLookAheadMult_HelpRequested);
            // 
            // lblLookAhead
            // 
            this.lblLookAhead.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLookAhead.ForeColor = System.Drawing.Color.Black;
            this.lblLookAhead.Location = new System.Drawing.Point(5, 51);
            this.lblLookAhead.Name = "lblLookAhead";
            this.lblLookAhead.Size = new System.Drawing.Size(60, 35);
            this.lblLookAhead.TabIndex = 293;
            this.lblLookAhead.Text = "888";
            this.lblLookAhead.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLookAheadMult
            // 
            this.lblLookAheadMult.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLookAheadMult.ForeColor = System.Drawing.Color.Black;
            this.lblLookAheadMult.Location = new System.Drawing.Point(5, 207);
            this.lblLookAheadMult.Name = "lblLookAheadMult";
            this.lblLookAheadMult.Size = new System.Drawing.Size(60, 35);
            this.lblLookAheadMult.TabIndex = 299;
            this.lblLookAheadMult.Text = "888";
            this.lblLookAheadMult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarLookAhead
            // 
            this.hsbarLookAhead.LargeChange = 1;
            this.hsbarLookAhead.Location = new System.Drawing.Point(68, 54);
            this.hsbarLookAhead.Maximum = 50;
            this.hsbarLookAhead.Minimum = 10;
            this.hsbarLookAhead.Name = "hsbarLookAhead";
            this.hsbarLookAhead.Size = new System.Drawing.Size(217, 30);
            this.hsbarLookAhead.TabIndex = 289;
            this.hsbarLookAhead.Value = 25;
            this.hsbarLookAhead.ValueChanged += new System.EventHandler(this.hsbarLookAhead_ValueChanged);
            this.hsbarLookAhead.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.hsbarLookAhead_HelpRequested);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ST_SteerTab.png");
            this.imageList1.Images.SetKeyName(1, "ST_GainTab.png");
            this.imageList1.Images.SetKeyName(2, "ST_StanleyTab.png");
            this.imageList1.Images.SetKeyName(3, "Sf_PPTab.png");
            this.imageList1.Images.SetKeyName(4, "Sf_XTE2.png");
            // 
            // lblSideHillComp
            // 
            this.lblSideHillComp.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSideHillComp.ForeColor = System.Drawing.Color.Black;
            this.lblSideHillComp.Location = new System.Drawing.Point(384, 512);
            this.lblSideHillComp.Name = "lblSideHillComp";
            this.lblSideHillComp.Size = new System.Drawing.Size(60, 35);
            this.lblSideHillComp.TabIndex = 353;
            this.lblSideHillComp.Text = "888";
            this.lblSideHillComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarSideHillComp
            // 
            this.hsbarSideHillComp.LargeChange = 1;
            this.hsbarSideHillComp.Location = new System.Drawing.Point(447, 514);
            this.hsbarSideHillComp.Name = "hsbarSideHillComp";
            this.hsbarSideHillComp.Size = new System.Drawing.Size(254, 30);
            this.hsbarSideHillComp.TabIndex = 352;
            this.hsbarSideHillComp.Value = 5;
            this.hsbarSideHillComp.ValueChanged += new System.EventHandler(this.hsbarSideHillComp_ValueChanged);
            this.hsbarSideHillComp.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.hsbarSideHillComp_HelpRequested);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(461, 493);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(210, 19);
            this.label22.TabIndex = 351;
            this.label22.Text = "Sidehill Deg per Deg of Roll";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label22.UseCompatibleTextRendering = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(749, 334);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(164, 26);
            this.label28.TabIndex = 513;
            this.label28.Text = "Button - Push On. Push Off\r\nSwitch - Pushed On, Release Off";
            // 
            // labelPressureTurnSensor
            // 
            this.labelPressureTurnSensor.AutoSize = true;
            this.labelPressureTurnSensor.ForeColor = System.Drawing.Color.Black;
            this.labelPressureTurnSensor.Location = new System.Drawing.Point(416, 253);
            this.labelPressureTurnSensor.Name = "labelPressureTurnSensor";
            this.labelPressureTurnSensor.Size = new System.Drawing.Size(110, 13);
            this.labelPressureTurnSensor.TabIndex = 512;
            this.labelPressureTurnSensor.Text = "Pressure Turn Sensor";
            // 
            // labelCurrentTurnSensor
            // 
            this.labelCurrentTurnSensor.AutoSize = true;
            this.labelCurrentTurnSensor.ForeColor = System.Drawing.Color.Black;
            this.labelCurrentTurnSensor.Location = new System.Drawing.Point(417, 379);
            this.labelCurrentTurnSensor.Name = "labelCurrentTurnSensor";
            this.labelCurrentTurnSensor.Size = new System.Drawing.Size(105, 13);
            this.labelCurrentTurnSensor.TabIndex = 511;
            this.labelCurrentTurnSensor.Text = "Current Turn Sensor";
            // 
            // labelEncoder
            // 
            this.labelEncoder.AutoSize = true;
            this.labelEncoder.ForeColor = System.Drawing.Color.Black;
            this.labelEncoder.Location = new System.Drawing.Point(416, 129);
            this.labelEncoder.Name = "labelEncoder";
            this.labelEncoder.Size = new System.Drawing.Size(65, 13);
            this.labelEncoder.TabIndex = 506;
            this.labelEncoder.Text = "Turn Sensor";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.ForeColor = System.Drawing.Color.Black;
            this.label70.Location = new System.Drawing.Point(591, 131);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(84, 13);
            this.label70.TabIndex = 505;
            this.label70.Text = "Invert Motor Dir";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(591, 257);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(72, 13);
            this.label29.TabIndex = 504;
            this.label29.Text = "Invert Relays";
            // 
            // label68
            // 
            this.label68.BackColor = System.Drawing.Color.Transparent;
            this.label68.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label68.ForeColor = System.Drawing.Color.Black;
            this.label68.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label68.Location = new System.Drawing.Point(762, 635);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(172, 30);
            this.label68.TabIndex = 502;
            this.label68.Text = "Send + Save";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboxMotorDrive
            // 
            this.cboxMotorDrive.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxMotorDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMotorDrive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxMotorDrive.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxMotorDrive.FormattingEnabled = true;
            this.cboxMotorDrive.Items.AddRange(new object[] {
            "Cytron",
            "IBT2"});
            this.cboxMotorDrive.Location = new System.Drawing.Point(743, 37);
            this.cboxMotorDrive.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxMotorDrive.Name = "cboxMotorDrive";
            this.cboxMotorDrive.Size = new System.Drawing.Size(175, 37);
            this.cboxMotorDrive.TabIndex = 495;
            this.cboxMotorDrive.Click += new System.EventHandler(this.EnableAlert_Click);
            this.cboxMotorDrive.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.cboxMotorDrive_HelpRequested);
            // 
            // cboxSteerEnable
            // 
            this.cboxSteerEnable.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxSteerEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSteerEnable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxSteerEnable.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSteerEnable.FormattingEnabled = true;
            this.cboxSteerEnable.Items.AddRange(new object[] {
            "None",
            "Switch",
            "Button"});
            this.cboxSteerEnable.Location = new System.Drawing.Point(743, 292);
            this.cboxSteerEnable.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxSteerEnable.Name = "cboxSteerEnable";
            this.cboxSteerEnable.Size = new System.Drawing.Size(175, 37);
            this.cboxSteerEnable.TabIndex = 498;
            this.cboxSteerEnable.Click += new System.EventHandler(this.EnableAlert_Click);
            this.cboxSteerEnable.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.cboxSteerEnable_HelpRequested);
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.Color.Transparent;
            this.label62.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label62.ForeColor = System.Drawing.Color.Black;
            this.label62.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label62.Location = new System.Drawing.Point(740, 263);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(181, 29);
            this.label62.TabIndex = 499;
            this.label62.Text = "Steer Enable";
            this.label62.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cboxConv
            // 
            this.cboxConv.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxConv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxConv.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxConv.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxConv.FormattingEnabled = true;
            this.cboxConv.Items.AddRange(new object[] {
            "Single",
            "Differential"});
            this.cboxConv.Location = new System.Drawing.Point(743, 118);
            this.cboxConv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxConv.Name = "cboxConv";
            this.cboxConv.Size = new System.Drawing.Size(175, 37);
            this.cboxConv.TabIndex = 500;
            this.cboxConv.Click += new System.EventHandler(this.EnableAlert_Click);
            this.cboxConv.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.cboxConv_HelpRequested);
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.Color.Transparent;
            this.label63.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label63.ForeColor = System.Drawing.Color.Black;
            this.label63.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label63.Location = new System.Drawing.Point(740, 7);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(181, 29);
            this.label63.TabIndex = 496;
            this.label63.Text = "Motor Driver";
            this.label63.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label64
            // 
            this.label64.BackColor = System.Drawing.Color.Transparent;
            this.label64.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label64.ForeColor = System.Drawing.Color.Black;
            this.label64.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label64.Location = new System.Drawing.Point(740, 87);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(181, 29);
            this.label64.TabIndex = 497;
            this.label64.Text = "A2D Convertor";
            this.label64.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.Color.Transparent;
            this.label61.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.Color.Black;
            this.label61.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label61.Location = new System.Drawing.Point(418, 547);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(112, 32);
            this.label61.TabIndex = 494;
            this.label61.Text = "Turn Sensor";
            this.label61.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nudMaxCounts
            // 
            this.nudMaxCounts.BackColor = System.Drawing.Color.AliceBlue;
            this.nudMaxCounts.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMaxCounts.InterceptArrowKeys = false;
            this.nudMaxCounts.Location = new System.Drawing.Point(423, 582);
            this.nudMaxCounts.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMaxCounts.Name = "nudMaxCounts";
            this.nudMaxCounts.ReadOnly = true;
            this.nudMaxCounts.Size = new System.Drawing.Size(107, 52);
            this.nudMaxCounts.TabIndex = 493;
            this.nudMaxCounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMaxCounts.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudMaxCounts.Click += new System.EventHandler(this.nudMaxCounts_Click);
            this.nudMaxCounts.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.nudMaxCounts_HelpRequested);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.Color.Black;
            this.label55.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label55.Location = new System.Drawing.Point(417, 4);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(52, 16);
            this.label55.TabIndex = 489;
            this.label55.Text = "Danfoss";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(591, 4);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 13);
            this.label30.TabIndex = 515;
            this.label30.Text = "Invert WAS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lblError);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.lblSteerAngle);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lblSteerAngleActual);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(4, 405);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 34);
            this.panel2.TabIndex = 324;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lblPWMDisplay);
            this.panel1.Controls.Add(this.btnStartSA);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnFreeDriveZero);
            this.panel1.Controls.Add(this.btnSteerAngleUp);
            this.panel1.Controls.Add(this.btnFreeDrive);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSteerAngleDown);
            this.panel1.Controls.Add(this.lblCalcSteerAngleInner);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.lblDiameter);
            this.panel1.Location = new System.Drawing.Point(5, 445);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 231);
            this.panel1.TabIndex = 323;
            // 
            // btnStartSA
            // 
            this.btnStartSA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartSA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStartSA.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartSA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStartSA.Image = global::AgOpenGPS.Properties.Resources.BoundaryRecord;
            this.btnStartSA.Location = new System.Drawing.Point(15, 146);
            this.btnStartSA.Name = "btnStartSA";
            this.btnStartSA.Size = new System.Drawing.Size(62, 58);
            this.btnStartSA.TabIndex = 323;
            this.btnStartSA.UseVisualStyleBackColor = true;
            this.btnStartSA.Click += new System.EventHandler(this.btnStartSA_Click);
            this.btnStartSA.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnStartSA_HelpRequested);
            // 
            // btnFreeDriveZero
            // 
            this.btnFreeDriveZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFreeDriveZero.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnFreeDriveZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFreeDriveZero.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreeDriveZero.ForeColor = System.Drawing.Color.White;
            this.btnFreeDriveZero.Image = global::AgOpenGPS.Properties.Resources.SteerZeroSmall;
            this.btnFreeDriveZero.Location = new System.Drawing.Point(277, 22);
            this.btnFreeDriveZero.Name = "btnFreeDriveZero";
            this.btnFreeDriveZero.Size = new System.Drawing.Size(73, 56);
            this.btnFreeDriveZero.TabIndex = 313;
            this.btnFreeDriveZero.UseVisualStyleBackColor = true;
            this.btnFreeDriveZero.Click += new System.EventHandler(this.btnFreeDriveZero_Click);
            this.btnFreeDriveZero.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnFreeDriveZero_HelpRequested);
            // 
            // btnSteerAngleUp
            // 
            this.btnSteerAngleUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSteerAngleUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSteerAngleUp.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSteerAngleUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSteerAngleUp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSteerAngleUp.Image = global::AgOpenGPS.Properties.Resources.ArrowRight;
            this.btnSteerAngleUp.Location = new System.Drawing.Point(186, 22);
            this.btnSteerAngleUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSteerAngleUp.Name = "btnSteerAngleUp";
            this.btnSteerAngleUp.Size = new System.Drawing.Size(73, 56);
            this.btnSteerAngleUp.TabIndex = 315;
            this.btnSteerAngleUp.UseVisualStyleBackColor = true;
            this.btnSteerAngleUp.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnSteerAngleUp_HelpRequested);
            this.btnSteerAngleUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSteerAngleUp_MouseDown);
            // 
            // btnFreeDrive
            // 
            this.btnFreeDrive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFreeDrive.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFreeDrive.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnFreeDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFreeDrive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreeDrive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFreeDrive.Image = global::AgOpenGPS.Properties.Resources.SteerDriveOff;
            this.btnFreeDrive.Location = new System.Drawing.Point(4, 22);
            this.btnFreeDrive.Name = "btnFreeDrive";
            this.btnFreeDrive.Size = new System.Drawing.Size(73, 56);
            this.btnFreeDrive.TabIndex = 228;
            this.btnFreeDrive.UseVisualStyleBackColor = false;
            this.btnFreeDrive.Click += new System.EventHandler(this.btnFreeDrive_Click);
            this.btnFreeDrive.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnFreeDrive_HelpRequested);
            // 
            // btnSteerAngleDown
            // 
            this.btnSteerAngleDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSteerAngleDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSteerAngleDown.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSteerAngleDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSteerAngleDown.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSteerAngleDown.Image = global::AgOpenGPS.Properties.Resources.ArrowLeft;
            this.btnSteerAngleDown.Location = new System.Drawing.Point(95, 22);
            this.btnSteerAngleDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSteerAngleDown.Name = "btnSteerAngleDown";
            this.btnSteerAngleDown.Size = new System.Drawing.Size(73, 56);
            this.btnSteerAngleDown.TabIndex = 314;
            this.btnSteerAngleDown.UseVisualStyleBackColor = true;
            this.btnSteerAngleDown.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnSteerAngleDown_HelpRequested);
            this.btnSteerAngleDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSteerAngleDown_MouseDown);
            // 
            // hsbarSensor
            // 
            this.hsbarSensor.LargeChange = 1;
            this.hsbarSensor.Location = new System.Drawing.Point(402, 590);
            this.hsbarSensor.Maximum = 255;
            this.hsbarSensor.Name = "hsbarSensor";
            this.hsbarSensor.Size = new System.Drawing.Size(280, 30);
            this.hsbarSensor.TabIndex = 516;
            this.hsbarSensor.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarSensor_Scroll);
            // 
            // lblhsbarSensor
            // 
            this.lblhsbarSensor.AutoSize = true;
            this.lblhsbarSensor.BackColor = System.Drawing.Color.Transparent;
            this.lblhsbarSensor.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhsbarSensor.ForeColor = System.Drawing.Color.Black;
            this.lblhsbarSensor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblhsbarSensor.Location = new System.Drawing.Point(688, 590);
            this.lblhsbarSensor.Name = "lblhsbarSensor";
            this.lblhsbarSensor.Size = new System.Drawing.Size(57, 29);
            this.lblhsbarSensor.TabIndex = 518;
            this.lblhsbarSensor.Text = "0%";
            this.lblhsbarSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(585, 386);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 22);
            this.label16.TabIndex = 520;
            this.label16.Text = "Panic Stop Speed";
            this.label16.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nudPanicStopSpeed
            // 
            this.nudPanicStopSpeed.BackColor = System.Drawing.Color.AliceBlue;
            this.nudPanicStopSpeed.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPanicStopSpeed.InterceptArrowKeys = false;
            this.nudPanicStopSpeed.Location = new System.Drawing.Point(590, 411);
            this.nudPanicStopSpeed.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudPanicStopSpeed.Name = "nudPanicStopSpeed";
            this.nudPanicStopSpeed.ReadOnly = true;
            this.nudPanicStopSpeed.Size = new System.Drawing.Size(107, 52);
            this.nudPanicStopSpeed.TabIndex = 519;
            this.nudPanicStopSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudPanicStopSpeed.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudPanicStopSpeed.Click += new System.EventHandler(this.nudPanicStopSpeed_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(615, 466);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(48, 16);
            this.label31.TabIndex = 521;
            this.label31.Text = "0 = Off";
            this.label31.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(841, 372);
            this.label37.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(89, 42);
            this.label37.TabIndex = 523;
            this.label37.Text = "Reset To Defaults";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.AliceBlue;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.button2.Image = global::AgOpenGPS.Properties.Resources.Reset_Default;
            this.button2.Location = new System.Drawing.Point(848, 414);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 69);
            this.button2.TabIndex = 522;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnVehicleReset_Click);
            // 
            // cboxCurrentSensor
            // 
            this.cboxCurrentSensor.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxCurrentSensor.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxCurrentSensor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxCurrentSensor.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxCurrentSensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxCurrentSensor.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxCurrentSensor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxCurrentSensor.Image = global::AgOpenGPS.Properties.Resources.ConSt_TurnSensorCurrent;
            this.cboxCurrentSensor.Location = new System.Drawing.Point(414, 396);
            this.cboxCurrentSensor.Name = "cboxCurrentSensor";
            this.cboxCurrentSensor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxCurrentSensor.Size = new System.Drawing.Size(114, 78);
            this.cboxCurrentSensor.TabIndex = 510;
            this.cboxCurrentSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxCurrentSensor.UseVisualStyleBackColor = false;
            this.cboxCurrentSensor.Click += new System.EventHandler(this.EnableAlert_Click);
            this.cboxCurrentSensor.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.cboxCurrentSensor_HelpRequested);
            // 
            // cboxPressureSensor
            // 
            this.cboxPressureSensor.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxPressureSensor.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxPressureSensor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxPressureSensor.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxPressureSensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxPressureSensor.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxPressureSensor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxPressureSensor.Image = global::AgOpenGPS.Properties.Resources.ConSt_TurnSensorPressure;
            this.cboxPressureSensor.Location = new System.Drawing.Point(414, 270);
            this.cboxPressureSensor.Name = "cboxPressureSensor";
            this.cboxPressureSensor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxPressureSensor.Size = new System.Drawing.Size(114, 78);
            this.cboxPressureSensor.TabIndex = 508;
            this.cboxPressureSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxPressureSensor.UseVisualStyleBackColor = false;
            this.cboxPressureSensor.Click += new System.EventHandler(this.EnableAlert_Click);
            this.cboxPressureSensor.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.cboxPressureSensor_HelpRequested);
            // 
            // pboxSendSteer
            // 
            this.pboxSendSteer.BackgroundImage = global::AgOpenGPS.Properties.Resources.ConSt_Mandatory1;
            this.pboxSendSteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pboxSendSteer.Location = new System.Drawing.Point(827, 521);
            this.pboxSendSteer.Name = "pboxSendSteer";
            this.pboxSendSteer.Size = new System.Drawing.Size(86, 47);
            this.pboxSendSteer.TabIndex = 509;
            this.pboxSendSteer.TabStop = false;
            this.pboxSendSteer.Visible = false;
            this.pboxSendSteer.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.pboxSendSteer_HelpRequested);
            // 
            // cboxDanfoss
            // 
            this.cboxDanfoss.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxDanfoss.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxDanfoss.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxDanfoss.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxDanfoss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxDanfoss.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDanfoss.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxDanfoss.Image = global::AgOpenGPS.Properties.Resources.ConSt_Danfoss;
            this.cboxDanfoss.Location = new System.Drawing.Point(414, 23);
            this.cboxDanfoss.Name = "cboxDanfoss";
            this.cboxDanfoss.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxDanfoss.Size = new System.Drawing.Size(114, 78);
            this.cboxDanfoss.TabIndex = 507;
            this.cboxDanfoss.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxDanfoss.UseVisualStyleBackColor = false;
            this.cboxDanfoss.Click += new System.EventHandler(this.EnableAlert_Click);
            this.cboxDanfoss.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.cboxDanfoss_HelpRequested);
            // 
            // chkSteerInvertRelays
            // 
            this.chkSteerInvertRelays.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSteerInvertRelays.BackColor = System.Drawing.Color.AliceBlue;
            this.chkSteerInvertRelays.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.chkSteerInvertRelays.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.chkSteerInvertRelays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSteerInvertRelays.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSteerInvertRelays.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSteerInvertRelays.Image = global::AgOpenGPS.Properties.Resources.ConSt_InvertRelay;
            this.chkSteerInvertRelays.Location = new System.Drawing.Point(588, 273);
            this.chkSteerInvertRelays.Name = "chkSteerInvertRelays";
            this.chkSteerInvertRelays.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSteerInvertRelays.Size = new System.Drawing.Size(109, 78);
            this.chkSteerInvertRelays.TabIndex = 503;
            this.chkSteerInvertRelays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSteerInvertRelays.UseVisualStyleBackColor = false;
            this.chkSteerInvertRelays.Click += new System.EventHandler(this.EnableAlert_Click);
            this.chkSteerInvertRelays.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.chkSteerInvertRelays_HelpRequested);
            // 
            // chkInvertSteer
            // 
            this.chkInvertSteer.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkInvertSteer.BackColor = System.Drawing.Color.AliceBlue;
            this.chkInvertSteer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.chkInvertSteer.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.chkInvertSteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkInvertSteer.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInvertSteer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkInvertSteer.Image = global::AgOpenGPS.Properties.Resources.ConSt_InvertDirection;
            this.chkInvertSteer.Location = new System.Drawing.Point(588, 147);
            this.chkInvertSteer.Name = "chkInvertSteer";
            this.chkInvertSteer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkInvertSteer.Size = new System.Drawing.Size(109, 78);
            this.chkInvertSteer.TabIndex = 491;
            this.chkInvertSteer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkInvertSteer.UseVisualStyleBackColor = false;
            this.chkInvertSteer.Click += new System.EventHandler(this.EnableAlert_Click);
            this.chkInvertSteer.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.chkInvertSteer_HelpRequested);
            // 
            // cboxEncoder
            // 
            this.cboxEncoder.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxEncoder.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxEncoder.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxEncoder.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxEncoder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxEncoder.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxEncoder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxEncoder.Image = global::AgOpenGPS.Properties.Resources.ConSt_TurnSensor;
            this.cboxEncoder.Location = new System.Drawing.Point(414, 145);
            this.cboxEncoder.Name = "cboxEncoder";
            this.cboxEncoder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxEncoder.Size = new System.Drawing.Size(114, 78);
            this.cboxEncoder.TabIndex = 492;
            this.cboxEncoder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxEncoder.UseVisualStyleBackColor = false;
            this.cboxEncoder.Click += new System.EventHandler(this.EnableAlert_Click);
            this.cboxEncoder.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.cboxEncoder_HelpRequested);
            // 
            // chkInvertWAS
            // 
            this.chkInvertWAS.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkInvertWAS.BackColor = System.Drawing.Color.AliceBlue;
            this.chkInvertWAS.Checked = true;
            this.chkInvertWAS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInvertWAS.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.chkInvertWAS.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.chkInvertWAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkInvertWAS.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInvertWAS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkInvertWAS.Image = global::AgOpenGPS.Properties.Resources.ConSt_InvertWAS;
            this.chkInvertWAS.Location = new System.Drawing.Point(588, 21);
            this.chkInvertWAS.Name = "chkInvertWAS";
            this.chkInvertWAS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkInvertWAS.Size = new System.Drawing.Size(109, 78);
            this.chkInvertWAS.TabIndex = 490;
            this.chkInvertWAS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkInvertWAS.UseVisualStyleBackColor = false;
            this.chkInvertWAS.Click += new System.EventHandler(this.EnableAlert_Click);
            this.chkInvertWAS.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.chkInvertWAS_HelpRequested);
            // 
            // btnSendSteerConfigPGN
            // 
            this.btnSendSteerConfigPGN.BackColor = System.Drawing.Color.Transparent;
            this.btnSendSteerConfigPGN.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSendSteerConfigPGN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendSteerConfigPGN.Image = global::AgOpenGPS.Properties.Resources.ToolAcceptChange;
            this.btnSendSteerConfigPGN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSendSteerConfigPGN.Location = new System.Drawing.Point(818, 568);
            this.btnSendSteerConfigPGN.Name = "btnSendSteerConfigPGN";
            this.btnSendSteerConfigPGN.Size = new System.Drawing.Size(103, 62);
            this.btnSendSteerConfigPGN.TabIndex = 501;
            this.btnSendSteerConfigPGN.UseVisualStyleBackColor = false;
            this.btnSendSteerConfigPGN.Click += new System.EventHandler(this.btnSendSteerConfigPGN_Click);
            this.btnSendSteerConfigPGN.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.pboxSendSteer_HelpRequested);
            // 
            // cboxXY
            // 
            this.cboxXY.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxXY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxXY.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxXY.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxXY.FormattingEnabled = true;
            this.cboxXY.Items.AddRange(new object[] {
            "X",
            "Y"});
            this.cboxXY.Location = new System.Drawing.Point(743, 207);
            this.cboxXY.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxXY.Name = "cboxXY";
            this.cboxXY.Size = new System.Drawing.Size(175, 37);
            this.cboxXY.TabIndex = 525;
            this.cboxXY.Click += new System.EventHandler(this.EnableAlert_Click);
            this.cboxXY.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.cboxXY_HelpRequested);
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(740, 176);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(181, 29);
            this.label33.TabIndex = 524;
            this.label33.Text = "IMU X or Y Axis";
            this.label33.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label34.Location = new System.Drawing.Point(723, 376);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(112, 32);
            this.label34.TabIndex = 527;
            this.label34.Text = "Stanley/Pure";
            this.label34.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnStanleyPure
            // 
            this.btnStanleyPure.BackColor = System.Drawing.Color.AliceBlue;
            this.btnStanleyPure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStanleyPure.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStanleyPure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStanleyPure.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStanleyPure.ForeColor = System.Drawing.Color.Black;
            this.btnStanleyPure.Image = global::AgOpenGPS.Properties.Resources.ModeStanley;
            this.btnStanleyPure.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStanleyPure.Location = new System.Drawing.Point(745, 414);
            this.btnStanleyPure.Margin = new System.Windows.Forms.Padding(0);
            this.btnStanleyPure.Name = "btnStanleyPure";
            this.btnStanleyPure.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnStanleyPure.Size = new System.Drawing.Size(75, 69);
            this.btnStanleyPure.TabIndex = 526;
            this.btnStanleyPure.UseVisualStyleBackColor = false;
            this.btnStanleyPure.Click += new System.EventHandler(this.btnStanleyPure_Click);
            // 
            // lblAV_Set
            // 
            this.lblAV_Set.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAV_Set.AutoSize = true;
            this.lblAV_Set.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAV_Set.Location = new System.Drawing.Point(292, 16);
            this.lblAV_Set.Name = "lblAV_Set";
            this.lblAV_Set.Size = new System.Drawing.Size(51, 19);
            this.lblAV_Set.TabIndex = 529;
            this.lblAV_Set.Text = "-55.8";
            this.lblAV_Set.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAV_Act
            // 
            this.lblAV_Act.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAV_Act.AutoSize = true;
            this.lblAV_Act.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAV_Act.Location = new System.Drawing.Point(292, 40);
            this.lblAV_Act.Name = "lblAV_Act";
            this.lblAV_Act.Size = new System.Drawing.Size(54, 19);
            this.lblAV_Act.TabIndex = 528;
            this.lblAV_Act.Text = "66.89";
            this.lblAV_Act.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(247, 42);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(50, 16);
            this.label36.TabIndex = 530;
            this.label36.Text = "AV Act:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(246, 18);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(51, 16);
            this.label38.TabIndex = 531;
            this.label38.Text = "AV Set:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormSteer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 681);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.btnStanleyPure);
            this.Controls.Add(this.cboxXY);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.lblSideHillComp);
            this.Controls.Add(this.hsbarSideHillComp);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.nudPanicStopSpeed);
            this.Controls.Add(this.lblhsbarSensor);
            this.Controls.Add(this.hsbarSensor);
            this.Controls.Add(this.lblPercentFS);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.pbarSensor);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.labelPressureTurnSensor);
            this.Controls.Add(this.labelCurrentTurnSensor);
            this.Controls.Add(this.labelEncoder);
            this.Controls.Add(this.label70);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label68);
            this.Controls.Add(this.cboxMotorDrive);
            this.Controls.Add(this.cboxSteerEnable);
            this.Controls.Add(this.label62);
            this.Controls.Add(this.cboxConv);
            this.Controls.Add(this.label63);
            this.Controls.Add(this.label64);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.nudMaxCounts);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.cboxCurrentSensor);
            this.Controls.Add(this.cboxPressureSensor);
            this.Controls.Add(this.pboxSendSteer);
            this.Controls.Add(this.cboxDanfoss);
            this.Controls.Add(this.chkSteerInvertRelays);
            this.Controls.Add(this.chkInvertSteer);
            this.Controls.Add(this.cboxEncoder);
            this.Controls.Add(this.chkInvertWAS);
            this.Controls.Add(this.btnSendSteerConfigPGN);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(960, 720);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(388, 480);
            this.Name = "FormSteer";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auto Steer Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSteer_FormClosing);
            this.Load += new System.EventHandler(this.FormSteer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSteer.ResumeLayout(false);
            this.tabSteer.PerformLayout();
            this.tabGain.ResumeLayout(false);
            this.tabGain.PerformLayout();
            this.tabStan.ResumeLayout(false);
            this.tabInt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCounts)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPanicStopSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSendSteer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFreeDrive;
        private System.Windows.Forms.Label lblHighSteerPWM;
        private System.Windows.Forms.HScrollBar hsbarHighSteerPWM;
        private System.Windows.Forms.Label lblProportionalGain;
        private System.Windows.Forms.HScrollBar hsbarProportionalGain;
        private System.Windows.Forms.Label lblLookAhead;
        private System.Windows.Forms.HScrollBar hsbarLookAhead;
        private System.Windows.Forms.Label lblMinPWM;
        private System.Windows.Forms.HScrollBar hsbarMinPWM;
        private System.Windows.Forms.Label lblMaxSteerAngle;
        private System.Windows.Forms.HScrollBar hsbarMaxSteerAngle;
        private System.Windows.Forms.HScrollBar hsbarLookAheadMult;
        private System.Windows.Forms.Label lblLookAheadMult;
        private System.Windows.Forms.HScrollBar hsbarHeadingErrorGain;
        private System.Windows.Forms.Label lblStanleyGain;
        private System.Windows.Forms.HScrollBar hsbarStanleyGain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblHeadingErrorGain;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblSteerAngle;
        private System.Windows.Forms.Label lblSteerAngleActual;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnFreeDriveZero;
        private ProXoft.WinForms.RepeatButton btnSteerAngleDown;
        private ProXoft.WinForms.RepeatButton btnSteerAngleUp;
        private System.Windows.Forms.Label lblPWMDisplay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGain;
        private System.Windows.Forms.TabPage tabStan;
        private System.Windows.Forms.TabPage tabInt;
        private System.Windows.Forms.Button btnStartSA;
        private System.Windows.Forms.Label lblCalcSteerAngleInner;
        private System.Windows.Forms.Label lblDiameter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tabSteer;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.HScrollBar hsbarAckerman;
        private System.Windows.Forms.Label lblAckerman;
        private System.Windows.Forms.ProgressBar pbarRight;
        private System.Windows.Forms.ProgressBar pbarLeft;
        private System.Windows.Forms.Label lblActualSteerAngleUpper;
        private System.Windows.Forms.Button btnZeroWAS;
        private System.Windows.Forms.HScrollBar hsbarCountsPerDegree;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCountsPerDegree;
        private System.Windows.Forms.HScrollBar hsbarWasOffset;
        private System.Windows.Forms.Label lblSteerAngleSensorZero;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.HScrollBar hsbarIntegral;
        private System.Windows.Forms.HScrollBar hsbarIntegralPurePursuit;
        private System.Windows.Forms.Label lblIntegralPercent;
        private System.Windows.Forms.Label lblPureIntegral;
        private System.Windows.Forms.Label lblSideHillComp;
        private System.Windows.Forms.HScrollBar hsbarSideHillComp;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ProgressBar pbarSensor;
        private System.Windows.Forms.Label lblPercentFS;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label labelPressureTurnSensor;
        private System.Windows.Forms.Label labelCurrentTurnSensor;
        private System.Windows.Forms.Label labelEncoder;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.ComboBox cboxMotorDrive;
        private System.Windows.Forms.ComboBox cboxSteerEnable;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.ComboBox cboxConv;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.NumericUpDown nudMaxCounts;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.CheckBox cboxCurrentSensor;
        private System.Windows.Forms.CheckBox cboxPressureSensor;
        private System.Windows.Forms.PictureBox pboxSendSteer;
        private System.Windows.Forms.CheckBox cboxDanfoss;
        private System.Windows.Forms.CheckBox chkSteerInvertRelays;
        private System.Windows.Forms.CheckBox chkInvertSteer;
        private System.Windows.Forms.CheckBox cboxEncoder;
        private System.Windows.Forms.CheckBox chkInvertWAS;
        private System.Windows.Forms.Button btnSendSteerConfigPGN;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.HScrollBar hsbarSensor;
        private System.Windows.Forms.Label lblhsbarSensor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nudPanicStopSpeed;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblHoldLookAhead;
        private System.Windows.Forms.HScrollBar hsbarHoldLookAhead;
        private System.Windows.Forms.ComboBox cboxXY;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        public System.Windows.Forms.Button btnStanleyPure;
        private System.Windows.Forms.Label lblAV_Set;
        private System.Windows.Forms.Label lblAV_Act;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label38;
    }
}