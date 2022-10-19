namespace AgOpenGPS
{
    partial class FormSteerWiz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSteerWiz));
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
            this.hsbarLowSteerPWM = new System.Windows.Forms.HScrollBar();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLowSteerPWM = new System.Windows.Forms.Label();
            this.tabGain = new System.Windows.Forms.TabPage();
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
            this.lblSideHillComp = new System.Windows.Forms.Label();
            this.hsbarSideHillComp = new System.Windows.Forms.HScrollBar();
            this.label22 = new System.Windows.Forms.Label();
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
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hsbarMinPWM = new System.Windows.Forms.HScrollBar();
            this.hsbarProportionalGain = new System.Windows.Forms.HScrollBar();
            this.lblProportionalGain = new System.Windows.Forms.Label();
            this.lblHighSteerPWM = new System.Windows.Forms.Label();
            this.lblMinPWM = new System.Windows.Forms.Label();
            this.hsbarHighSteerPWM = new System.Windows.Forms.HScrollBar();
            this.lblMaxSteerAngle = new System.Windows.Forms.Label();
            this.hsbarAckerman = new System.Windows.Forms.HScrollBar();
            this.hsbarMaxSteerAngle = new System.Windows.Forms.HScrollBar();
            this.lblAckerman = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.hsbarCountsPerDegree = new System.Windows.Forms.HScrollBar();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCountsPerDegree = new System.Windows.Forms.Label();
            this.hsbarWasOffset = new System.Windows.Forms.HScrollBar();
            this.lblSteerAngleSensorZero = new System.Windows.Forms.Label();
            this.pbarRight = new System.Windows.Forms.ProgressBar();
            this.pbarLeft = new System.Windows.Forms.ProgressBar();
            this.label28 = new System.Windows.Forms.Label();
            this.labelPressureTurnSensor = new System.Windows.Forms.Label();
            this.labelCurrentTurnSensor = new System.Windows.Forms.Label();
            this.labelEncoder = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
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
            this.btnSteerStatus = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label38 = new System.Windows.Forms.Label();
            this.btnFreeDriveZero = new System.Windows.Forms.Button();
            this.btnSteerAngleUp = new ProXoft.WinForms.RepeatButton();
            this.btnFreeDrive = new System.Windows.Forms.Button();
            this.btnSteerAngleDown = new ProXoft.WinForms.RepeatButton();
            this.hsbarSensor = new System.Windows.Forms.HScrollBar();
            this.lblhsbarSensor = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.nudPanicStopSpeed = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.tabWiz = new System.Windows.Forms.TabControl();
            this.tabStart = new System.Windows.Forms.TabPage();
            this.btnStartWizard = new System.Windows.Forms.Button();
            this.tabLoadDef = new System.Windows.Forms.TabPage();
            this.label81 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.btnOkNext_LoadDefault = new System.Windows.Forms.Button();
            this.btnLoadDefaults = new System.Windows.Forms.Button();
            this.tabButtonSwitch = new System.Windows.Forms.TabPage();
            this.label53 = new System.Windows.Forms.Label();
            this.btnOkNext_ButtonSwitch = new System.Windows.Forms.Button();
            this.tabA2DConv = new System.Windows.Forms.TabPage();
            this.btnPrev_A2D = new System.Windows.Forms.Button();
            this.label52 = new System.Windows.Forms.Label();
            this.btnOkNext_A2D = new System.Windows.Forms.Button();
            this.tabMotorDriver = new System.Windows.Forms.TabPage();
            this.btnPrev_MotorDriver = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.btnOkNext_MotorDriver = new System.Windows.Forms.Button();
            this.tabInvertRelays = new System.Windows.Forms.TabPage();
            this.label59 = new System.Windows.Forms.Label();
            this.btnPrev_InvertRelays = new System.Windows.Forms.Button();
            this.label51 = new System.Windows.Forms.Label();
            this.btnOkNext_InvertRelays = new System.Windows.Forms.Button();
            this.chkSteerInvertRelays = new System.Windows.Forms.CheckBox();
            this.tabDanfoss = new System.Windows.Forms.TabPage();
            this.btnPrev_Danfoss = new System.Windows.Forms.Button();
            this.label50 = new System.Windows.Forms.Label();
            this.btnOkNext_Danfoss = new System.Windows.Forms.Button();
            this.cboxDanfoss = new System.Windows.Forms.CheckBox();
            this.tabWAS = new System.Windows.Forms.TabPage();
            this.label45 = new System.Windows.Forms.Label();
            this.btnPrev_InvertWAS = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.btnOkWAS = new System.Windows.Forms.Button();
            this.chkInvertWAS = new System.Windows.Forms.CheckBox();
            this.tabMotorDirection = new System.Windows.Forms.TabPage();
            this.label58 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.btnPrev_MotorDirection = new System.Windows.Forms.Button();
            this.btnOkNext_MotorDirection = new System.Windows.Forms.Button();
            this.btnSteerLeft = new System.Windows.Forms.Button();
            this.btnSteerRight = new System.Windows.Forms.Button();
            this.chkInvertSteer = new System.Windows.Forms.CheckBox();
            this.tabCPD_Setup = new System.Windows.Forms.TabPage();
            this.label60 = new System.Windows.Forms.Label();
            this.btnPrev_CountsPerDegree = new System.Windows.Forms.Button();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.btnSkipCPD_Setup = new System.Windows.Forms.Button();
            this.btnOKNext_CPDSetup = new System.Windows.Forms.Button();
            this.tabWAS_Zero = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.btnRemoveWasOffset = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.btnOkNext_WAS_Zero = new System.Windows.Forms.Button();
            this.btnZeroWAS = new System.Windows.Forms.Button();
            this.tabCountsPerDeg = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.lblCPDError = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.btnOkNext_CountsPerDeg = new System.Windows.Forms.Button();
            this.btnStartSA = new System.Windows.Forms.Button();
            this.tabAckermannRight = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.btnOkLockRightCalc = new System.Windows.Forms.Button();
            this.tabAckermannLeft = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.label47 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.btnOkLockLeftCalc = new System.Windows.Forms.Button();
            this.tabAckermannCalc = new System.Windows.Forms.TabPage();
            this.btnPrev_AckermannCalc = new System.Windows.Forms.Button();
            this.lblAckError = new System.Windows.Forms.Label();
            this.lblAckLeft = new System.Windows.Forms.Label();
            this.lblAckRight = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.btnOkNext_AckermannCalc = new System.Windows.Forms.Button();
            this.tabMaxSteerAngle = new System.Windows.Forms.TabPage();
            this.btnOkSetMaximumSteerAngle = new System.Windows.Forms.Button();
            this.label73 = new System.Windows.Forms.Label();
            this.btnPrev_MaxSteerAngle = new System.Windows.Forms.Button();
            this.label49 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnOkNextMaxSteerAngle = new System.Windows.Forms.Button();
            this.tabCancelGuidance = new System.Windows.Forms.TabPage();
            this.btnPrev_CancelGuidance = new System.Windows.Forms.Button();
            this.btnOkNextCancelGuidance = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
            this.cboxPressureSensor = new System.Windows.Forms.CheckBox();
            this.cboxEncoder = new System.Windows.Forms.CheckBox();
            this.cboxCurrentSensor = new System.Windows.Forms.CheckBox();
            this.tabPanicStop = new System.Windows.Forms.TabPage();
            this.label82 = new System.Windows.Forms.Label();
            this.btnPrev_Panic = new System.Windows.Forms.Button();
            this.label54 = new System.Windows.Forms.Label();
            this.btnOkNext_PanicStop = new System.Windows.Forms.Button();
            this.tab_MinimumGain = new System.Windows.Forms.TabPage();
            this.label72 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.btnMinGainLeft = new System.Windows.Forms.Button();
            this.btnZeroMinMovementSetting = new System.Windows.Forms.Button();
            this.label77 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.btnMinGainRight = new System.Windows.Forms.Button();
            this.label68 = new System.Windows.Forms.Label();
            this.btnPrev_Gain = new System.Windows.Forms.Button();
            this.btnOK_Next = new System.Windows.Forms.Button();
            this.tabPGain = new System.Windows.Forms.TabPage();
            this.label88 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.btnLeftPGain = new System.Windows.Forms.Button();
            this.btnZeroPGain = new System.Windows.Forms.Button();
            this.label85 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.btnRightPGain = new System.Windows.Forms.Button();
            this.label87 = new System.Windows.Forms.Label();
            this.btnPrev_PGain = new System.Windows.Forms.Button();
            this.btnNext_PGain = new System.Windows.Forms.Button();
            this.tabEnd = new System.Windows.Forms.TabPage();
            this.btnRestartWizard = new System.Windows.Forms.Button();
            this.label69 = new System.Windows.Forms.Label();
            this.btnPrev_End = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStopWizard = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbarProgress = new System.Windows.Forms.ProgressBar();
            this.label71 = new System.Windows.Forms.Label();
            this.lblBarCPD = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.lblBarAck = new System.Windows.Forms.Label();
            this.sideBarTimer = new System.Windows.Forms.Timer(this.components);
            this.label67 = new System.Windows.Forms.Label();
            this.lblBarWasOffset = new System.Windows.Forms.Label();
            this.btnCloseAll = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabSteer.SuspendLayout();
            this.tabStan.SuspendLayout();
            this.tabInt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCounts)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPanicStopSpeed)).BeginInit();
            this.tabWiz.SuspendLayout();
            this.tabStart.SuspendLayout();
            this.tabLoadDef.SuspendLayout();
            this.tabButtonSwitch.SuspendLayout();
            this.tabA2DConv.SuspendLayout();
            this.tabMotorDriver.SuspendLayout();
            this.tabInvertRelays.SuspendLayout();
            this.tabDanfoss.SuspendLayout();
            this.tabWAS.SuspendLayout();
            this.tabMotorDirection.SuspendLayout();
            this.tabCPD_Setup.SuspendLayout();
            this.tabWAS_Zero.SuspendLayout();
            this.tabCountsPerDeg.SuspendLayout();
            this.tabAckermannRight.SuspendLayout();
            this.tabAckermannLeft.SuspendLayout();
            this.tabAckermannCalc.SuspendLayout();
            this.tabMaxSteerAngle.SuspendLayout();
            this.tabCancelGuidance.SuspendLayout();
            this.tabPanicStop.SuspendLayout();
            this.tab_MinimumGain.SuspendLayout();
            this.tabPGain.SuspendLayout();
            this.tabEnd.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.lblSteerAngle.BackColor = System.Drawing.Color.Transparent;
            this.lblSteerAngle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerAngle.ForeColor = System.Drawing.Color.Black;
            this.lblSteerAngle.Location = new System.Drawing.Point(417, 14);
            this.lblSteerAngle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSteerAngle.Name = "lblSteerAngle";
            this.lblSteerAngle.Size = new System.Drawing.Size(150, 46);
            this.lblSteerAngle.TabIndex = 306;
            this.lblSteerAngle.Text = "-55.5";
            this.lblSteerAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSteerAngleActual
            // 
            this.lblSteerAngleActual.BackColor = System.Drawing.Color.Transparent;
            this.lblSteerAngleActual.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerAngleActual.ForeColor = System.Drawing.Color.Black;
            this.lblSteerAngleActual.Location = new System.Drawing.Point(686, 14);
            this.lblSteerAngleActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSteerAngleActual.Name = "lblSteerAngleActual";
            this.lblSteerAngleActual.Size = new System.Drawing.Size(150, 46);
            this.lblSteerAngleActual.TabIndex = 311;
            this.lblSteerAngleActual.Text = "-55.5";
            this.lblSteerAngleActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Black;
            this.lblError.Location = new System.Drawing.Point(528, 153);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(152, 46);
            this.lblError.TabIndex = 312;
            this.lblError.Text = "-30.0";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPWMDisplay
            // 
            this.lblPWMDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPWMDisplay.BackColor = System.Drawing.Color.White;
            this.lblPWMDisplay.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPWMDisplay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPWMDisplay.Location = new System.Drawing.Point(916, 178);
            this.lblPWMDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPWMDisplay.Name = "lblPWMDisplay";
            this.lblPWMDisplay.Size = new System.Drawing.Size(69, 34);
            this.lblPWMDisplay.TabIndex = 316;
            this.lblPWMDisplay.Text = "255";
            this.lblPWMDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(820, 177);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 34);
            this.label9.TabIndex = 318;
            this.label9.Text = "PWM:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(576, 14);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 50);
            this.label11.TabIndex = 319;
            this.label11.Text = "WAS:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(326, 10);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 50);
            this.label12.TabIndex = 320;
            this.label12.Text = "Set:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(429, 153);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 50);
            this.label13.TabIndex = 321;
            this.label13.Text = "Error:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(532, 106);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 24);
            this.label14.TabIndex = 322;
            this.label14.Text = "Or +5";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(414, 164);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 39);
            this.label8.TabIndex = 328;
            this.label8.Text = "Steer Angle:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(444, 216);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 39);
            this.label1.TabIndex = 327;
            this.label1.Text = "Diameter:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCalcSteerAngleInner
            // 
            this.lblCalcSteerAngleInner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCalcSteerAngleInner.AutoSize = true;
            this.lblCalcSteerAngleInner.BackColor = System.Drawing.Color.Transparent;
            this.lblCalcSteerAngleInner.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalcSteerAngleInner.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCalcSteerAngleInner.Location = new System.Drawing.Point(603, 166);
            this.lblCalcSteerAngleInner.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalcSteerAngleInner.Name = "lblCalcSteerAngleInner";
            this.lblCalcSteerAngleInner.Size = new System.Drawing.Size(67, 39);
            this.lblCalcSteerAngleInner.TabIndex = 326;
            this.lblCalcSteerAngleInner.Text = "0.0";
            this.lblCalcSteerAngleInner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiameter
            // 
            this.lblDiameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDiameter.AutoSize = true;
            this.lblDiameter.BackColor = System.Drawing.Color.Transparent;
            this.lblDiameter.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiameter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDiameter.Location = new System.Drawing.Point(603, 219);
            this.lblDiameter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiameter.Name = "lblDiameter";
            this.lblDiameter.Size = new System.Drawing.Size(107, 39);
            this.lblDiameter.TabIndex = 325;
            this.lblDiameter.Text = "0.0 m";
            this.lblDiameter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbarSensor
            // 
            this.pbarSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbarSensor.Location = new System.Drawing.Point(56, 405);
            this.pbarSensor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbarSensor.Maximum = 255;
            this.pbarSensor.Name = "pbarSensor";
            this.pbarSensor.Size = new System.Drawing.Size(420, 39);
            this.pbarSensor.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbarSensor.TabIndex = 496;
            // 
            // lblPercentFS
            // 
            this.lblPercentFS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPercentFS.AutoSize = true;
            this.lblPercentFS.BackColor = System.Drawing.Color.Transparent;
            this.lblPercentFS.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentFS.ForeColor = System.Drawing.Color.Black;
            this.lblPercentFS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPercentFS.Location = new System.Drawing.Point(504, 405);
            this.lblPercentFS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentFS.Name = "lblPercentFS";
            this.lblPercentFS.Size = new System.Drawing.Size(85, 43);
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
            this.tabControl1.ItemSize = new System.Drawing.Size(86, 48);
            this.tabControl1.Location = new System.Drawing.Point(1482, 306);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(534, 568);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 347;
            // 
            // tabSteer
            // 
            this.tabSteer.AutoScroll = true;
            this.tabSteer.BackColor = System.Drawing.Color.Gainsboro;
            this.tabSteer.BackgroundImage = global::AgOpenGPS.Properties.Resources.Sf_SteerTab;
            this.tabSteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabSteer.Controls.Add(this.hsbarLowSteerPWM);
            this.tabSteer.Controls.Add(this.label6);
            this.tabSteer.Controls.Add(this.lblLowSteerPWM);
            this.tabSteer.ImageIndex = 0;
            this.tabSteer.Location = new System.Drawing.Point(4, 52);
            this.tabSteer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabSteer.Name = "tabSteer";
            this.tabSteer.Size = new System.Drawing.Size(526, 512);
            this.tabSteer.TabIndex = 5;
            // 
            // hsbarLowSteerPWM
            // 
            this.hsbarLowSteerPWM.LargeChange = 1;
            this.hsbarLowSteerPWM.Location = new System.Drawing.Point(98, 338);
            this.hsbarLowSteerPWM.Maximum = 255;
            this.hsbarLowSteerPWM.Name = "hsbarLowSteerPWM";
            this.hsbarLowSteerPWM.Size = new System.Drawing.Size(292, 30);
            this.hsbarLowSteerPWM.TabIndex = 269;
            this.hsbarLowSteerPWM.Value = 1;
            this.hsbarLowSteerPWM.ValueChanged += new System.EventHandler(this.hsbarLowSteerPWM_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(294, 304);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 29);
            this.label6.TabIndex = 337;
            this.label6.Text = "Low";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLowSteerPWM
            // 
            this.lblLowSteerPWM.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowSteerPWM.ForeColor = System.Drawing.Color.Black;
            this.lblLowSteerPWM.Location = new System.Drawing.Point(8, 334);
            this.lblLowSteerPWM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLowSteerPWM.Name = "lblLowSteerPWM";
            this.lblLowSteerPWM.Size = new System.Drawing.Size(92, 52);
            this.lblLowSteerPWM.TabIndex = 273;
            this.lblLowSteerPWM.Text = "888";
            this.lblLowSteerPWM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabGain
            // 
            this.tabGain.AutoScroll = true;
            this.tabGain.BackColor = System.Drawing.Color.Gainsboro;
            this.tabGain.BackgroundImage = global::AgOpenGPS.Properties.Resources.Sf_GainTab;
            this.tabGain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabGain.ImageIndex = 1;
            this.tabGain.Location = new System.Drawing.Point(4, 52);
            this.tabGain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabGain.Name = "tabGain";
            this.tabGain.Size = new System.Drawing.Size(526, 512);
            this.tabGain.TabIndex = 13;
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
            this.tabStan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabStan.Name = "tabStan";
            this.tabStan.Size = new System.Drawing.Size(526, 512);
            this.tabStan.TabIndex = 15;
            // 
            // lblIntegralPercent
            // 
            this.lblIntegralPercent.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntegralPercent.ForeColor = System.Drawing.Color.Black;
            this.lblIntegralPercent.Location = new System.Drawing.Point(4, 368);
            this.lblIntegralPercent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIntegralPercent.Name = "lblIntegralPercent";
            this.lblIntegralPercent.Size = new System.Drawing.Size(90, 52);
            this.lblIntegralPercent.TabIndex = 352;
            this.lblIntegralPercent.Text = "888";
            this.lblIntegralPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarIntegral
            // 
            this.hsbarIntegral.LargeChange = 1;
            this.hsbarIntegral.Location = new System.Drawing.Point(102, 370);
            this.hsbarIntegral.Name = "hsbarIntegral";
            this.hsbarIntegral.Size = new System.Drawing.Size(303, 30);
            this.hsbarIntegral.TabIndex = 351;
            this.hsbarIntegral.Value = 5;
            this.hsbarIntegral.ValueChanged += new System.EventHandler(this.hsbarIntegral_ValueChanged);
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(94, 327);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(306, 45);
            this.label27.TabIndex = 350;
            this.label27.Text = "Integral";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label27.UseCompatibleTextRendering = true;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.SandyBrown;
            this.label25.Location = new System.Drawing.Point(176, 4);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(171, 46);
            this.label25.TabIndex = 347;
            this.label25.Text = "Stanley";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeadingErrorGain
            // 
            this.lblHeadingErrorGain.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadingErrorGain.ForeColor = System.Drawing.Color.Black;
            this.lblHeadingErrorGain.Location = new System.Drawing.Point(14, 228);
            this.lblHeadingErrorGain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeadingErrorGain.Name = "lblHeadingErrorGain";
            this.lblHeadingErrorGain.Size = new System.Drawing.Size(81, 52);
            this.lblHeadingErrorGain.TabIndex = 295;
            this.lblHeadingErrorGain.Text = "888";
            this.lblHeadingErrorGain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStanleyGain
            // 
            this.lblStanleyGain.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStanleyGain.ForeColor = System.Drawing.Color.Black;
            this.lblStanleyGain.Location = new System.Drawing.Point(14, 96);
            this.lblStanleyGain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStanleyGain.Name = "lblStanleyGain";
            this.lblStanleyGain.Size = new System.Drawing.Size(81, 52);
            this.lblStanleyGain.TabIndex = 299;
            this.lblStanleyGain.Text = "888";
            this.lblStanleyGain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(93, 189);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(306, 45);
            this.label5.TabIndex = 296;
            this.label5.Text = "Heading";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(94, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(306, 42);
            this.label3.TabIndex = 298;
            this.label3.Text = "Distance";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarStanleyGain
            // 
            this.hsbarStanleyGain.LargeChange = 1;
            this.hsbarStanleyGain.Location = new System.Drawing.Point(102, 99);
            this.hsbarStanleyGain.Maximum = 40;
            this.hsbarStanleyGain.Minimum = 1;
            this.hsbarStanleyGain.Name = "hsbarStanleyGain";
            this.hsbarStanleyGain.Size = new System.Drawing.Size(300, 30);
            this.hsbarStanleyGain.TabIndex = 297;
            this.hsbarStanleyGain.Value = 10;
            this.hsbarStanleyGain.ValueChanged += new System.EventHandler(this.hsbarStanleyGain_ValueChanged);
            // 
            // hsbarHeadingErrorGain
            // 
            this.hsbarHeadingErrorGain.LargeChange = 1;
            this.hsbarHeadingErrorGain.Location = new System.Drawing.Point(102, 234);
            this.hsbarHeadingErrorGain.Maximum = 15;
            this.hsbarHeadingErrorGain.Minimum = 1;
            this.hsbarHeadingErrorGain.Name = "hsbarHeadingErrorGain";
            this.hsbarHeadingErrorGain.Size = new System.Drawing.Size(300, 30);
            this.hsbarHeadingErrorGain.TabIndex = 294;
            this.hsbarHeadingErrorGain.Value = 10;
            this.hsbarHeadingErrorGain.ValueChanged += new System.EventHandler(this.hsbarHeadingErrorGain_ValueChanged);
            // 
            // tabInt
            // 
            this.tabInt.BackColor = System.Drawing.Color.Gainsboro;
            this.tabInt.BackgroundImage = global::AgOpenGPS.Properties.Resources.Sf_PP;
            this.tabInt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabInt.Controls.Add(this.lblSideHillComp);
            this.tabInt.Controls.Add(this.hsbarSideHillComp);
            this.tabInt.Controls.Add(this.label22);
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
            this.tabInt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabInt.Name = "tabInt";
            this.tabInt.Size = new System.Drawing.Size(526, 512);
            this.tabInt.TabIndex = 16;
            // 
            // lblSideHillComp
            // 
            this.lblSideHillComp.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSideHillComp.ForeColor = System.Drawing.Color.Black;
            this.lblSideHillComp.Location = new System.Drawing.Point(9, 314);
            this.lblSideHillComp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSideHillComp.Name = "lblSideHillComp";
            this.lblSideHillComp.Size = new System.Drawing.Size(90, 52);
            this.lblSideHillComp.TabIndex = 353;
            this.lblSideHillComp.Text = "888";
            this.lblSideHillComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarSideHillComp
            // 
            this.hsbarSideHillComp.LargeChange = 1;
            this.hsbarSideHillComp.Location = new System.Drawing.Point(104, 312);
            this.hsbarSideHillComp.Name = "hsbarSideHillComp";
            this.hsbarSideHillComp.Size = new System.Drawing.Size(326, 30);
            this.hsbarSideHillComp.TabIndex = 352;
            this.hsbarSideHillComp.Value = 5;
            this.hsbarSideHillComp.ValueChanged += new System.EventHandler(this.hsbarSideHillComp_ValueChanged);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(110, 280);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(315, 28);
            this.label22.TabIndex = 351;
            this.label22.Text = "Sidehill Deg per Deg of Roll";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label22.UseCompatibleTextRendering = true;
            // 
            // lblPureIntegral
            // 
            this.lblPureIntegral.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPureIntegral.ForeColor = System.Drawing.Color.Black;
            this.lblPureIntegral.Location = new System.Drawing.Point(8, 418);
            this.lblPureIntegral.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPureIntegral.Name = "lblPureIntegral";
            this.lblPureIntegral.Size = new System.Drawing.Size(90, 52);
            this.lblPureIntegral.TabIndex = 350;
            this.lblPureIntegral.Text = "888";
            this.lblPureIntegral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarIntegralPurePursuit
            // 
            this.hsbarIntegralPurePursuit.LargeChange = 1;
            this.hsbarIntegralPurePursuit.Location = new System.Drawing.Point(102, 420);
            this.hsbarIntegralPurePursuit.Name = "hsbarIntegralPurePursuit";
            this.hsbarIntegralPurePursuit.Size = new System.Drawing.Size(326, 30);
            this.hsbarIntegralPurePursuit.TabIndex = 349;
            this.hsbarIntegralPurePursuit.Value = 5;
            this.hsbarIntegralPurePursuit.ValueChanged += new System.EventHandler(this.hsbarIntegralPurePursuit_ValueChanged);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.SteelBlue;
            this.label26.Location = new System.Drawing.Point(132, 6);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(258, 42);
            this.label26.TabIndex = 348;
            this.label26.Text = "Pure Pursuit";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(111, 386);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(306, 28);
            this.label24.TabIndex = 342;
            this.label24.Text = "Integral";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label24.UseCompatibleTextRendering = true;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(111, 63);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(306, 28);
            this.label21.TabIndex = 303;
            this.label21.Text = "Look Ahead (m)";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label20.Location = new System.Drawing.Point(868, 342);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(306, 45);
            this.label20.TabIndex = 302;
            this.label20.Text = "Look Ahead Min";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(111, 171);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(306, 28);
            this.label19.TabIndex = 301;
            this.label19.Text = "Look Ahead Speed Gain";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label18.Location = new System.Drawing.Point(842, 20);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(306, 45);
            this.label18.TabIndex = 300;
            this.label18.Text = "Look Ahead";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarLookAheadMult
            // 
            this.hsbarLookAheadMult.LargeChange = 1;
            this.hsbarLookAheadMult.Location = new System.Drawing.Point(102, 204);
            this.hsbarLookAheadMult.Maximum = 30;
            this.hsbarLookAheadMult.Minimum = 5;
            this.hsbarLookAheadMult.Name = "hsbarLookAheadMult";
            this.hsbarLookAheadMult.Size = new System.Drawing.Size(326, 30);
            this.hsbarLookAheadMult.TabIndex = 298;
            this.hsbarLookAheadMult.Value = 6;
            this.hsbarLookAheadMult.ValueChanged += new System.EventHandler(this.hsbarLookAheadMult_ValueChanged);
            // 
            // lblLookAhead
            // 
            this.lblLookAhead.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLookAhead.ForeColor = System.Drawing.Color.Black;
            this.lblLookAhead.Location = new System.Drawing.Point(6, 92);
            this.lblLookAhead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLookAhead.Name = "lblLookAhead";
            this.lblLookAhead.Size = new System.Drawing.Size(90, 52);
            this.lblLookAhead.TabIndex = 293;
            this.lblLookAhead.Text = "888";
            this.lblLookAhead.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLookAheadMult
            // 
            this.lblLookAheadMult.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLookAheadMult.ForeColor = System.Drawing.Color.Black;
            this.lblLookAheadMult.Location = new System.Drawing.Point(6, 212);
            this.lblLookAheadMult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLookAheadMult.Name = "lblLookAheadMult";
            this.lblLookAheadMult.Size = new System.Drawing.Size(90, 52);
            this.lblLookAheadMult.TabIndex = 299;
            this.lblLookAheadMult.Text = "888";
            this.lblLookAheadMult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarLookAhead
            // 
            this.hsbarLookAhead.LargeChange = 1;
            this.hsbarLookAhead.Location = new System.Drawing.Point(102, 96);
            this.hsbarLookAhead.Maximum = 50;
            this.hsbarLookAhead.Minimum = 10;
            this.hsbarLookAhead.Name = "hsbarLookAhead";
            this.hsbarLookAhead.Size = new System.Drawing.Size(326, 30);
            this.hsbarLookAhead.TabIndex = 289;
            this.hsbarLookAhead.Value = 25;
            this.hsbarLookAhead.ValueChanged += new System.EventHandler(this.hsbarLookAhead_ValueChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ST_SteerTab.png");
            this.imageList1.Images.SetKeyName(1, "ST_GainTab.png");
            this.imageList1.Images.SetKeyName(2, "ST_StanleyTab.png");
            this.imageList1.Images.SetKeyName(3, "Sf_PPTab.png");
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(254, 327);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(345, 35);
            this.label15.TabIndex = 338;
            this.label15.Text = "PWM Minimum Movement";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(384, 392);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 29);
            this.label4.TabIndex = 336;
            this.label4.Text = "PWM Maximum";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(358, 272);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 29);
            this.label2.TabIndex = 335;
            this.label2.Text = "Proportional Gain";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarMinPWM
            // 
            this.hsbarMinPWM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hsbarMinPWM.LargeChange = 1;
            this.hsbarMinPWM.Location = new System.Drawing.Point(230, 366);
            this.hsbarMinPWM.Name = "hsbarMinPWM";
            this.hsbarMinPWM.Size = new System.Drawing.Size(384, 44);
            this.hsbarMinPWM.TabIndex = 284;
            this.hsbarMinPWM.Value = 10;
            this.hsbarMinPWM.ValueChanged += new System.EventHandler(this.hsbarMinPWM_ValueChanged);
            // 
            // hsbarProportionalGain
            // 
            this.hsbarProportionalGain.LargeChange = 1;
            this.hsbarProportionalGain.Location = new System.Drawing.Point(268, 304);
            this.hsbarProportionalGain.Maximum = 200;
            this.hsbarProportionalGain.Name = "hsbarProportionalGain";
            this.hsbarProportionalGain.Size = new System.Drawing.Size(292, 30);
            this.hsbarProportionalGain.TabIndex = 254;
            this.hsbarProportionalGain.Value = 4;
            this.hsbarProportionalGain.ValueChanged += new System.EventHandler(this.hsbarProportionalGain_ValueChanged);
            // 
            // lblProportionalGain
            // 
            this.lblProportionalGain.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProportionalGain.ForeColor = System.Drawing.Color.Black;
            this.lblProportionalGain.Location = new System.Drawing.Point(178, 302);
            this.lblProportionalGain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProportionalGain.Name = "lblProportionalGain";
            this.lblProportionalGain.Size = new System.Drawing.Size(92, 52);
            this.lblProportionalGain.TabIndex = 258;
            this.lblProportionalGain.Text = "888";
            this.lblProportionalGain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHighSteerPWM
            // 
            this.lblHighSteerPWM.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighSteerPWM.ForeColor = System.Drawing.Color.Black;
            this.lblHighSteerPWM.Location = new System.Drawing.Point(178, 416);
            this.lblHighSteerPWM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHighSteerPWM.Name = "lblHighSteerPWM";
            this.lblHighSteerPWM.Size = new System.Drawing.Size(92, 52);
            this.lblHighSteerPWM.TabIndex = 278;
            this.lblHighSteerPWM.Text = "888";
            this.lblHighSteerPWM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMinPWM
            // 
            this.lblMinPWM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMinPWM.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinPWM.ForeColor = System.Drawing.Color.Black;
            this.lblMinPWM.Location = new System.Drawing.Point(98, 370);
            this.lblMinPWM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinPWM.Name = "lblMinPWM";
            this.lblMinPWM.Size = new System.Drawing.Size(123, 52);
            this.lblMinPWM.TabIndex = 288;
            this.lblMinPWM.Text = "888";
            this.lblMinPWM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarHighSteerPWM
            // 
            this.hsbarHighSteerPWM.LargeChange = 2;
            this.hsbarHighSteerPWM.Location = new System.Drawing.Point(268, 420);
            this.hsbarHighSteerPWM.Maximum = 255;
            this.hsbarHighSteerPWM.Name = "hsbarHighSteerPWM";
            this.hsbarHighSteerPWM.Size = new System.Drawing.Size(292, 30);
            this.hsbarHighSteerPWM.TabIndex = 274;
            this.hsbarHighSteerPWM.Value = 50;
            this.hsbarHighSteerPWM.ValueChanged += new System.EventHandler(this.hsbarHighSteerPWM_ValueChanged);
            // 
            // lblMaxSteerAngle
            // 
            this.lblMaxSteerAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMaxSteerAngle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxSteerAngle.ForeColor = System.Drawing.Color.Black;
            this.lblMaxSteerAngle.Location = new System.Drawing.Point(99, 345);
            this.lblMaxSteerAngle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxSteerAngle.Name = "lblMaxSteerAngle";
            this.lblMaxSteerAngle.Size = new System.Drawing.Size(138, 52);
            this.lblMaxSteerAngle.TabIndex = 303;
            this.lblMaxSteerAngle.Text = "888";
            this.lblMaxSteerAngle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarAckerman
            // 
            this.hsbarAckerman.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hsbarAckerman.LargeChange = 1;
            this.hsbarAckerman.Location = new System.Drawing.Point(302, 302);
            this.hsbarAckerman.Maximum = 200;
            this.hsbarAckerman.Minimum = 1;
            this.hsbarAckerman.Name = "hsbarAckerman";
            this.hsbarAckerman.Size = new System.Drawing.Size(405, 50);
            this.hsbarAckerman.TabIndex = 331;
            this.hsbarAckerman.Value = 100;
            this.hsbarAckerman.ValueChanged += new System.EventHandler(this.hsbarAckerman_ValueChanged);
            // 
            // hsbarMaxSteerAngle
            // 
            this.hsbarMaxSteerAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hsbarMaxSteerAngle.LargeChange = 1;
            this.hsbarMaxSteerAngle.Location = new System.Drawing.Point(258, 333);
            this.hsbarMaxSteerAngle.Maximum = 80;
            this.hsbarMaxSteerAngle.Minimum = 10;
            this.hsbarMaxSteerAngle.Name = "hsbarMaxSteerAngle";
            this.hsbarMaxSteerAngle.Size = new System.Drawing.Size(405, 50);
            this.hsbarMaxSteerAngle.TabIndex = 299;
            this.hsbarMaxSteerAngle.Value = 10;
            this.hsbarMaxSteerAngle.ValueChanged += new System.EventHandler(this.hsbarMaxSteerAngle_ValueChanged);
            // 
            // lblAckerman
            // 
            this.lblAckerman.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAckerman.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAckerman.ForeColor = System.Drawing.Color.Black;
            this.lblAckerman.Location = new System.Drawing.Point(152, 309);
            this.lblAckerman.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAckerman.Name = "lblAckerman";
            this.lblAckerman.Size = new System.Drawing.Size(136, 52);
            this.lblAckerman.TabIndex = 333;
            this.lblAckerman.Text = "888";
            this.lblAckerman.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(26, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(948, 86);
            this.label7.TabIndex = 334;
            this.label7.Text = "Turn steering wheel to RIGHT about 30 degrees and drive in a steady circle, Press" +
    " Rec and drive.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // hsbarCountsPerDegree
            // 
            this.hsbarCountsPerDegree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hsbarCountsPerDegree.LargeChange = 1;
            this.hsbarCountsPerDegree.Location = new System.Drawing.Point(201, 369);
            this.hsbarCountsPerDegree.Maximum = 255;
            this.hsbarCountsPerDegree.Minimum = 1;
            this.hsbarCountsPerDegree.Name = "hsbarCountsPerDegree";
            this.hsbarCountsPerDegree.Size = new System.Drawing.Size(405, 50);
            this.hsbarCountsPerDegree.TabIndex = 304;
            this.hsbarCountsPerDegree.Value = 20;
            this.hsbarCountsPerDegree.ValueChanged += new System.EventHandler(this.hsbarCountsPerDegree_ValueChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(75, 48);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(816, 87);
            this.label10.TabIndex = 295;
            this.label10.Text = "Drive straight forward and Touch Zero";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblCountsPerDegree
            // 
            this.lblCountsPerDegree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountsPerDegree.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountsPerDegree.ForeColor = System.Drawing.Color.Black;
            this.lblCountsPerDegree.Location = new System.Drawing.Point(58, 380);
            this.lblCountsPerDegree.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCountsPerDegree.Name = "lblCountsPerDegree";
            this.lblCountsPerDegree.Size = new System.Drawing.Size(129, 52);
            this.lblCountsPerDegree.TabIndex = 308;
            this.lblCountsPerDegree.Text = "888";
            this.lblCountsPerDegree.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarWasOffset
            // 
            this.hsbarWasOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hsbarWasOffset.LargeChange = 20;
            this.hsbarWasOffset.Location = new System.Drawing.Point(282, 279);
            this.hsbarWasOffset.Maximum = 4000;
            this.hsbarWasOffset.Minimum = -4000;
            this.hsbarWasOffset.Name = "hsbarWasOffset";
            this.hsbarWasOffset.Size = new System.Drawing.Size(405, 50);
            this.hsbarWasOffset.SmallChange = 2;
            this.hsbarWasOffset.TabIndex = 294;
            this.hsbarWasOffset.ValueChanged += new System.EventHandler(this.hsbarSteerAngleSensorZero_ValueChanged);
            // 
            // lblSteerAngleSensorZero
            // 
            this.lblSteerAngleSensorZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSteerAngleSensorZero.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerAngleSensorZero.ForeColor = System.Drawing.Color.Black;
            this.lblSteerAngleSensorZero.Location = new System.Drawing.Point(692, 291);
            this.lblSteerAngleSensorZero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSteerAngleSensorZero.Name = "lblSteerAngleSensorZero";
            this.lblSteerAngleSensorZero.Size = new System.Drawing.Size(164, 52);
            this.lblSteerAngleSensorZero.TabIndex = 298;
            this.lblSteerAngleSensorZero.Text = "-55.88";
            this.lblSteerAngleSensorZero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbarRight
            // 
            this.pbarRight.Location = new System.Drawing.Point(602, 74);
            this.pbarRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbarRight.Name = "pbarRight";
            this.pbarRight.Size = new System.Drawing.Size(318, 52);
            this.pbarRight.TabIndex = 330;
            // 
            // pbarLeft
            // 
            this.pbarLeft.Location = new System.Drawing.Point(280, 74);
            this.pbarLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbarLeft.Name = "pbarLeft";
            this.pbarLeft.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pbarLeft.RightToLeftLayout = true;
            this.pbarLeft.Size = new System.Drawing.Size(318, 52);
            this.pbarLeft.TabIndex = 329;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(273, 250);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(325, 145);
            this.label28.TabIndex = 513;
            this.label28.Text = "Button - Push Release, On.   \r\n               Push Release, Off\r\n\r\nSwitch - While" +
    " Pushed is On. \r\n               Released is Off.";
            // 
            // labelPressureTurnSensor
            // 
            this.labelPressureTurnSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPressureTurnSensor.AutoSize = true;
            this.labelPressureTurnSensor.ForeColor = System.Drawing.Color.Black;
            this.labelPressureTurnSensor.Location = new System.Drawing.Point(644, 102);
            this.labelPressureTurnSensor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPressureTurnSensor.Name = "labelPressureTurnSensor";
            this.labelPressureTurnSensor.Size = new System.Drawing.Size(168, 21);
            this.labelPressureTurnSensor.TabIndex = 512;
            this.labelPressureTurnSensor.Text = "Pressure Turn Sensor";
            // 
            // labelCurrentTurnSensor
            // 
            this.labelCurrentTurnSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCurrentTurnSensor.AutoSize = true;
            this.labelCurrentTurnSensor.ForeColor = System.Drawing.Color.Black;
            this.labelCurrentTurnSensor.Location = new System.Drawing.Point(423, 102);
            this.labelCurrentTurnSensor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrentTurnSensor.Name = "labelCurrentTurnSensor";
            this.labelCurrentTurnSensor.Size = new System.Drawing.Size(159, 21);
            this.labelCurrentTurnSensor.TabIndex = 511;
            this.labelCurrentTurnSensor.Text = "Current Turn Sensor";
            // 
            // labelEncoder
            // 
            this.labelEncoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelEncoder.AutoSize = true;
            this.labelEncoder.ForeColor = System.Drawing.Color.Black;
            this.labelEncoder.Location = new System.Drawing.Point(237, 102);
            this.labelEncoder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEncoder.Name = "labelEncoder";
            this.labelEncoder.Size = new System.Drawing.Size(99, 21);
            this.labelEncoder.TabIndex = 506;
            this.labelEncoder.Text = "Turn Sensor";
            // 
            // label70
            // 
            this.label70.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label70.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.Black;
            this.label70.Location = new System.Drawing.Point(12, 92);
            this.label70.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(939, 78);
            this.label70.TabIndex = 505;
            this.label70.Text = "Invert Direction if steer motor turns the wrong way.\r\nTest with Arrows.";
            this.label70.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label29.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(90, 126);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(812, 48);
            this.label29.TabIndex = 504;
            this.label29.Text = "Invert Hydraulic Enable Relay?";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxMotorDrive
            // 
            this.cboxMotorDrive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxMotorDrive.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxMotorDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMotorDrive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxMotorDrive.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxMotorDrive.FormattingEnabled = true;
            this.cboxMotorDrive.Items.AddRange(new object[] {
            "Cytron",
            "IBT2"});
            this.cboxMotorDrive.Location = new System.Drawing.Point(357, 228);
            this.cboxMotorDrive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboxMotorDrive.Name = "cboxMotorDrive";
            this.cboxMotorDrive.Size = new System.Drawing.Size(260, 51);
            this.cboxMotorDrive.TabIndex = 495;
            this.cboxMotorDrive.SelectedIndexChanged += new System.EventHandler(this.cboxMotorDrive_SelectedIndexChanged);
            // 
            // cboxSteerEnable
            // 
            this.cboxSteerEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxSteerEnable.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxSteerEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSteerEnable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxSteerEnable.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSteerEnable.FormattingEnabled = true;
            this.cboxSteerEnable.Items.AddRange(new object[] {
            "None",
            "Switch",
            "Button"});
            this.cboxSteerEnable.Location = new System.Drawing.Point(292, 166);
            this.cboxSteerEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboxSteerEnable.Name = "cboxSteerEnable";
            this.cboxSteerEnable.Size = new System.Drawing.Size(260, 51);
            this.cboxSteerEnable.TabIndex = 498;
            this.cboxSteerEnable.SelectedIndexChanged += new System.EventHandler(this.cboxSteerEnable_SelectedIndexChanged);
            // 
            // label62
            // 
            this.label62.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label62.BackColor = System.Drawing.Color.Transparent;
            this.label62.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label62.ForeColor = System.Drawing.Color.Black;
            this.label62.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label62.Location = new System.Drawing.Point(126, 114);
            this.label62.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(594, 44);
            this.label62.TabIndex = 499;
            this.label62.Text = "Steer Enable Mode";
            this.label62.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cboxConv
            // 
            this.cboxConv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxConv.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxConv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxConv.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxConv.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxConv.FormattingEnabled = true;
            this.cboxConv.Items.AddRange(new object[] {
            "Single",
            "Differential"});
            this.cboxConv.Location = new System.Drawing.Point(357, 228);
            this.cboxConv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboxConv.Name = "cboxConv";
            this.cboxConv.Size = new System.Drawing.Size(260, 51);
            this.cboxConv.TabIndex = 500;
            this.cboxConv.SelectedIndexChanged += new System.EventHandler(this.cboxConv_SelectedIndexChanged);
            // 
            // label63
            // 
            this.label63.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label63.BackColor = System.Drawing.Color.Transparent;
            this.label63.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label63.ForeColor = System.Drawing.Color.Black;
            this.label63.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label63.Location = new System.Drawing.Point(100, 153);
            this.label63.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(794, 38);
            this.label63.TabIndex = 496;
            this.label63.Text = "What Style of Motor Driver?";
            this.label63.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label64
            // 
            this.label64.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label64.BackColor = System.Drawing.Color.Transparent;
            this.label64.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label64.ForeColor = System.Drawing.Color.Black;
            this.label64.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label64.Location = new System.Drawing.Point(171, 154);
            this.label64.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(654, 38);
            this.label64.TabIndex = 497;
            this.label64.Text = "A/D Convertor Connection?";
            this.label64.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label61
            // 
            this.label61.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label61.BackColor = System.Drawing.Color.Transparent;
            this.label61.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.Color.Black;
            this.label61.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label61.Location = new System.Drawing.Point(80, 268);
            this.label61.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(168, 48);
            this.label61.TabIndex = 494;
            this.label61.Text = "Turn Counts";
            this.label61.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nudMaxCounts
            // 
            this.nudMaxCounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudMaxCounts.BackColor = System.Drawing.Color.AliceBlue;
            this.nudMaxCounts.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMaxCounts.InterceptArrowKeys = false;
            this.nudMaxCounts.Location = new System.Drawing.Point(87, 321);
            this.nudMaxCounts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudMaxCounts.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMaxCounts.Name = "nudMaxCounts";
            this.nudMaxCounts.ReadOnly = true;
            this.nudMaxCounts.Size = new System.Drawing.Size(160, 74);
            this.nudMaxCounts.TabIndex = 493;
            this.nudMaxCounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMaxCounts.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudMaxCounts.Click += new System.EventHandler(this.nudMaxCounts_Click);
            // 
            // label55
            // 
            this.label55.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.Color.Black;
            this.label55.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label55.Location = new System.Drawing.Point(116, 126);
            this.label55.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(752, 46);
            this.label55.TabIndex = 489;
            this.label55.Text = "Do yo u have a Danfoss Valve?";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label55.Click += new System.EventHandler(this.label55_Click);
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label30.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(18, 88);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(952, 84);
            this.label30.TabIndex = 515;
            this.label30.Text = "Steer Angle must be positive when turning to the right.\r\nIf not, select the Inver" +
    "t WAS.";
            this.label30.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSteerStatus);
            this.panel2.Controls.Add(this.label35);
            this.panel2.Controls.Add(this.label34);
            this.panel2.Controls.Add(this.lblError);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.lblSteerAngle);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lblPWMDisplay);
            this.panel2.Controls.Add(this.lblSteerAngleActual);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.pbarLeft);
            this.panel2.Controls.Add(this.pbarRight);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(8, 604);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(996, 224);
            this.panel2.TabIndex = 324;
            // 
            // btnSteerStatus
            // 
            this.btnSteerStatus.BackColor = System.Drawing.Color.White;
            this.btnSteerStatus.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnSteerStatus.FlatAppearance.BorderSize = 0;
            this.btnSteerStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSteerStatus.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSteerStatus.Image = global::AgOpenGPS.Properties.Resources.WizSteerDot;
            this.btnSteerStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSteerStatus.Location = new System.Drawing.Point(21, 14);
            this.btnSteerStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSteerStatus.Name = "btnSteerStatus";
            this.btnSteerStatus.Size = new System.Drawing.Size(192, 192);
            this.btnSteerStatus.TabIndex = 531;
            this.btnSteerStatus.UseVisualStyleBackColor = false;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label35.Location = new System.Drawing.Point(291, 130);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(49, 24);
            this.label35.TabIndex = 332;
            this.label35.Text = "Left";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label34.Location = new System.Drawing.Point(858, 130);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(65, 24);
            this.label34.TabIndex = 331;
            this.label34.Text = "Right";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label38);
            this.panel1.Controls.Add(this.btnFreeDriveZero);
            this.panel1.Controls.Add(this.btnSteerAngleUp);
            this.panel1.Controls.Add(this.btnFreeDrive);
            this.panel1.Controls.Add(this.btnSteerAngleDown);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Location = new System.Drawing.Point(1372, 64);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 150);
            this.panel1.TabIndex = 323;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label38.Location = new System.Drawing.Point(20, 108);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(115, 24);
            this.label38.TabIndex = 325;
            this.label38.Text = "Free Drive";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnFreeDriveZero
            // 
            this.btnFreeDriveZero.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFreeDriveZero.FlatAppearance.BorderSize = 0;
            this.btnFreeDriveZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFreeDriveZero.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreeDriveZero.ForeColor = System.Drawing.Color.White;
            this.btnFreeDriveZero.Image = global::AgOpenGPS.Properties.Resources.SteerZeroSmall;
            this.btnFreeDriveZero.Location = new System.Drawing.Point(510, 20);
            this.btnFreeDriveZero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFreeDriveZero.Name = "btnFreeDriveZero";
            this.btnFreeDriveZero.Size = new System.Drawing.Size(110, 84);
            this.btnFreeDriveZero.TabIndex = 313;
            this.btnFreeDriveZero.UseVisualStyleBackColor = true;
            this.btnFreeDriveZero.Click += new System.EventHandler(this.btnFreeDriveZero_Click);
            // 
            // btnSteerAngleUp
            // 
            this.btnSteerAngleUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSteerAngleUp.FlatAppearance.BorderSize = 0;
            this.btnSteerAngleUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSteerAngleUp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSteerAngleUp.Image = global::AgOpenGPS.Properties.Resources.SteerRight;
            this.btnSteerAngleUp.Location = new System.Drawing.Point(345, 21);
            this.btnSteerAngleUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSteerAngleUp.Name = "btnSteerAngleUp";
            this.btnSteerAngleUp.Size = new System.Drawing.Size(110, 111);
            this.btnSteerAngleUp.TabIndex = 315;
            this.btnSteerAngleUp.UseVisualStyleBackColor = true;
            this.btnSteerAngleUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSteerAngleUp_MouseDown);
            // 
            // btnFreeDrive
            // 
            this.btnFreeDrive.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFreeDrive.FlatAppearance.BorderSize = 0;
            this.btnFreeDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFreeDrive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreeDrive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFreeDrive.Image = global::AgOpenGPS.Properties.Resources.SteerDriveOff;
            this.btnFreeDrive.Location = new System.Drawing.Point(20, 20);
            this.btnFreeDrive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFreeDrive.Name = "btnFreeDrive";
            this.btnFreeDrive.Size = new System.Drawing.Size(110, 84);
            this.btnFreeDrive.TabIndex = 228;
            this.btnFreeDrive.UseVisualStyleBackColor = false;
            this.btnFreeDrive.Click += new System.EventHandler(this.btnFreeDrive_Click);
            // 
            // btnSteerAngleDown
            // 
            this.btnSteerAngleDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSteerAngleDown.FlatAppearance.BorderSize = 0;
            this.btnSteerAngleDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSteerAngleDown.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSteerAngleDown.Image = global::AgOpenGPS.Properties.Resources.SteerLeft;
            this.btnSteerAngleDown.Location = new System.Drawing.Point(186, 20);
            this.btnSteerAngleDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSteerAngleDown.Name = "btnSteerAngleDown";
            this.btnSteerAngleDown.Size = new System.Drawing.Size(110, 111);
            this.btnSteerAngleDown.TabIndex = 314;
            this.btnSteerAngleDown.UseVisualStyleBackColor = true;
            this.btnSteerAngleDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSteerAngleDown_MouseDown);
            // 
            // hsbarSensor
            // 
            this.hsbarSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hsbarSensor.LargeChange = 1;
            this.hsbarSensor.Location = new System.Drawing.Point(56, 333);
            this.hsbarSensor.Maximum = 255;
            this.hsbarSensor.Name = "hsbarSensor";
            this.hsbarSensor.Size = new System.Drawing.Size(420, 30);
            this.hsbarSensor.TabIndex = 516;
            this.hsbarSensor.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarSensor_Scroll);
            // 
            // lblhsbarSensor
            // 
            this.lblhsbarSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblhsbarSensor.AutoSize = true;
            this.lblhsbarSensor.BackColor = System.Drawing.Color.Transparent;
            this.lblhsbarSensor.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhsbarSensor.ForeColor = System.Drawing.Color.Black;
            this.lblhsbarSensor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblhsbarSensor.Location = new System.Drawing.Point(504, 338);
            this.lblhsbarSensor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblhsbarSensor.Name = "lblhsbarSensor";
            this.lblhsbarSensor.Size = new System.Drawing.Size(85, 43);
            this.lblhsbarSensor.TabIndex = 518;
            this.lblhsbarSensor.Text = "0%";
            this.lblhsbarSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(66, 208);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(820, 44);
            this.label16.TabIndex = 520;
            this.label16.Text = "Set Panic Stop Speed";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudPanicStopSpeed
            // 
            this.nudPanicStopSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudPanicStopSpeed.BackColor = System.Drawing.Color.AliceBlue;
            this.nudPanicStopSpeed.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPanicStopSpeed.InterceptArrowKeys = false;
            this.nudPanicStopSpeed.Location = new System.Drawing.Point(394, 266);
            this.nudPanicStopSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudPanicStopSpeed.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudPanicStopSpeed.Name = "nudPanicStopSpeed";
            this.nudPanicStopSpeed.ReadOnly = true;
            this.nudPanicStopSpeed.Size = new System.Drawing.Size(160, 74);
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
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(426, 354);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(92, 29);
            this.label31.TabIndex = 521;
            this.label31.Text = "0 = Off";
            this.label31.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tabWiz
            // 
            this.tabWiz.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabWiz.Controls.Add(this.tabStart);
            this.tabWiz.Controls.Add(this.tabLoadDef);
            this.tabWiz.Controls.Add(this.tabButtonSwitch);
            this.tabWiz.Controls.Add(this.tabA2DConv);
            this.tabWiz.Controls.Add(this.tabMotorDriver);
            this.tabWiz.Controls.Add(this.tabInvertRelays);
            this.tabWiz.Controls.Add(this.tabDanfoss);
            this.tabWiz.Controls.Add(this.tabWAS);
            this.tabWiz.Controls.Add(this.tabMotorDirection);
            this.tabWiz.Controls.Add(this.tabCPD_Setup);
            this.tabWiz.Controls.Add(this.tabWAS_Zero);
            this.tabWiz.Controls.Add(this.tabCountsPerDeg);
            this.tabWiz.Controls.Add(this.tabAckermannRight);
            this.tabWiz.Controls.Add(this.tabAckermannLeft);
            this.tabWiz.Controls.Add(this.tabAckermannCalc);
            this.tabWiz.Controls.Add(this.tabMaxSteerAngle);
            this.tabWiz.Controls.Add(this.tabCancelGuidance);
            this.tabWiz.Controls.Add(this.tabPanicStop);
            this.tabWiz.Controls.Add(this.tab_MinimumGain);
            this.tabWiz.Controls.Add(this.tabPGain);
            this.tabWiz.Controls.Add(this.tabEnd);
            this.tabWiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabWiz.ItemSize = new System.Drawing.Size(60, 15);
            this.tabWiz.Location = new System.Drawing.Point(0, 0);
            this.tabWiz.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabWiz.Name = "tabWiz";
            this.tabWiz.Padding = new System.Drawing.Point(0, 0);
            this.tabWiz.SelectedIndex = 0;
            this.tabWiz.Size = new System.Drawing.Size(994, 519);
            this.tabWiz.TabIndex = 522;
            // 
            // tabStart
            // 
            this.tabStart.BackColor = System.Drawing.Color.White;
            this.tabStart.Controls.Add(this.btnStartWizard);
            this.tabStart.Location = new System.Drawing.Point(4, 19);
            this.tabStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabStart.Name = "tabStart";
            this.tabStart.Size = new System.Drawing.Size(986, 496);
            this.tabStart.TabIndex = 15;
            this.tabStart.Text = "tabStart";
            // 
            // btnStartWizard
            // 
            this.btnStartWizard.BackColor = System.Drawing.Color.PaleGreen;
            this.btnStartWizard.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnStartWizard.FlatAppearance.BorderSize = 2;
            this.btnStartWizard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartWizard.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnStartWizard.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnStartWizard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartWizard.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStartWizard.Location = new System.Drawing.Point(339, 165);
            this.btnStartWizard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartWizard.Name = "btnStartWizard";
            this.btnStartWizard.Size = new System.Drawing.Size(298, 120);
            this.btnStartWizard.TabIndex = 526;
            this.btnStartWizard.Text = "  Start Wizard";
            this.btnStartWizard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartWizard.UseVisualStyleBackColor = false;
            this.btnStartWizard.Click += new System.EventHandler(this.btnStartWizard_Click);
            // 
            // tabLoadDef
            // 
            this.tabLoadDef.BackColor = System.Drawing.Color.White;
            this.tabLoadDef.Controls.Add(this.label81);
            this.tabLoadDef.Controls.Add(this.label80);
            this.tabLoadDef.Controls.Add(this.btnOkNext_LoadDefault);
            this.tabLoadDef.Controls.Add(this.btnLoadDefaults);
            this.tabLoadDef.Location = new System.Drawing.Point(4, 19);
            this.tabLoadDef.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabLoadDef.Name = "tabLoadDef";
            this.tabLoadDef.Size = new System.Drawing.Size(986, 496);
            this.tabLoadDef.TabIndex = 35;
            this.tabLoadDef.Text = "LoadDef";
            // 
            // label81
            // 
            this.label81.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label81.BackColor = System.Drawing.Color.Transparent;
            this.label81.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label81.ForeColor = System.Drawing.Color.Black;
            this.label81.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label81.Location = new System.Drawing.Point(172, 183);
            this.label81.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(654, 38);
            this.label81.TabIndex = 536;
            this.label81.Text = "Highly Recommended";
            this.label81.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.ForeColor = System.Drawing.Color.Black;
            this.label80.Location = new System.Drawing.Point(9, 8);
            this.label80.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(236, 39);
            this.label80.TabIndex = 535;
            this.label80.Text = "Load Defaults";
            this.label80.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnOkNext_LoadDefault
            // 
            this.btnOkNext_LoadDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkNext_LoadDefault.BackColor = System.Drawing.Color.Transparent;
            this.btnOkNext_LoadDefault.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnOkNext_LoadDefault.FlatAppearance.BorderSize = 0;
            this.btnOkNext_LoadDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkNext_LoadDefault.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkNext_LoadDefault.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkNext_LoadDefault.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkNext_LoadDefault.Location = new System.Drawing.Point(864, 368);
            this.btnOkNext_LoadDefault.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkNext_LoadDefault.Name = "btnOkNext_LoadDefault";
            this.btnOkNext_LoadDefault.Size = new System.Drawing.Size(108, 108);
            this.btnOkNext_LoadDefault.TabIndex = 534;
            this.btnOkNext_LoadDefault.UseVisualStyleBackColor = false;
            this.btnOkNext_LoadDefault.Click += new System.EventHandler(this.btnOkNext_Click);
            // 
            // btnLoadDefaults
            // 
            this.btnLoadDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadDefaults.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLoadDefaults.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadDefaults.FlatAppearance.BorderSize = 2;
            this.btnLoadDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDefaults.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnLoadDefaults.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnLoadDefaults.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadDefaults.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLoadDefaults.Location = new System.Drawing.Point(351, 238);
            this.btnLoadDefaults.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadDefaults.Name = "btnLoadDefaults";
            this.btnLoadDefaults.Size = new System.Drawing.Size(298, 120);
            this.btnLoadDefaults.TabIndex = 533;
            this.btnLoadDefaults.Text = "Load Defaults";
            this.btnLoadDefaults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadDefaults.UseVisualStyleBackColor = false;
            this.btnLoadDefaults.Click += new System.EventHandler(this.btnLoadDefaults_Click);
            // 
            // tabButtonSwitch
            // 
            this.tabButtonSwitch.BackColor = System.Drawing.Color.White;
            this.tabButtonSwitch.Controls.Add(this.label53);
            this.tabButtonSwitch.Controls.Add(this.cboxSteerEnable);
            this.tabButtonSwitch.Controls.Add(this.label28);
            this.tabButtonSwitch.Controls.Add(this.label62);
            this.tabButtonSwitch.Controls.Add(this.btnOkNext_ButtonSwitch);
            this.tabButtonSwitch.Location = new System.Drawing.Point(4, 19);
            this.tabButtonSwitch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabButtonSwitch.Name = "tabButtonSwitch";
            this.tabButtonSwitch.Size = new System.Drawing.Size(986, 496);
            this.tabButtonSwitch.TabIndex = 19;
            this.tabButtonSwitch.Text = "ButtonSwitch";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.Color.Black;
            this.label53.Location = new System.Drawing.Point(8, 6);
            this.label53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(219, 39);
            this.label53.TabIndex = 533;
            this.label53.Text = "Steer Switch";
            this.label53.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnOkNext_ButtonSwitch
            // 
            this.btnOkNext_ButtonSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkNext_ButtonSwitch.BackColor = System.Drawing.Color.Transparent;
            this.btnOkNext_ButtonSwitch.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnOkNext_ButtonSwitch.FlatAppearance.BorderSize = 0;
            this.btnOkNext_ButtonSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkNext_ButtonSwitch.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkNext_ButtonSwitch.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkNext_ButtonSwitch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkNext_ButtonSwitch.Location = new System.Drawing.Point(862, 366);
            this.btnOkNext_ButtonSwitch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkNext_ButtonSwitch.Name = "btnOkNext_ButtonSwitch";
            this.btnOkNext_ButtonSwitch.Size = new System.Drawing.Size(108, 108);
            this.btnOkNext_ButtonSwitch.TabIndex = 525;
            this.btnOkNext_ButtonSwitch.UseVisualStyleBackColor = false;
            this.btnOkNext_ButtonSwitch.Click += new System.EventHandler(this.btnOkNext_Click);
            // 
            // tabA2DConv
            // 
            this.tabA2DConv.BackColor = System.Drawing.Color.White;
            this.tabA2DConv.Controls.Add(this.btnPrev_A2D);
            this.tabA2DConv.Controls.Add(this.label52);
            this.tabA2DConv.Controls.Add(this.cboxConv);
            this.tabA2DConv.Controls.Add(this.label64);
            this.tabA2DConv.Controls.Add(this.btnOkNext_A2D);
            this.tabA2DConv.Location = new System.Drawing.Point(4, 19);
            this.tabA2DConv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabA2DConv.Name = "tabA2DConv";
            this.tabA2DConv.Size = new System.Drawing.Size(986, 496);
            this.tabA2DConv.TabIndex = 27;
            this.tabA2DConv.Text = "A2DConv";
            // 
            // btnPrev_A2D
            // 
            this.btnPrev_A2D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev_A2D.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev_A2D.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnPrev_A2D.FlatAppearance.BorderSize = 0;
            this.btnPrev_A2D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev_A2D.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnPrev_A2D.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.btnPrev_A2D.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrev_A2D.Location = new System.Drawing.Point(728, 366);
            this.btnPrev_A2D.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev_A2D.Name = "btnPrev_A2D";
            this.btnPrev_A2D.Size = new System.Drawing.Size(108, 108);
            this.btnPrev_A2D.TabIndex = 537;
            this.btnPrev_A2D.UseVisualStyleBackColor = false;
            this.btnPrev_A2D.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.Black;
            this.label52.Location = new System.Drawing.Point(8, 6);
            this.label52.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(250, 39);
            this.label52.TabIndex = 533;
            this.label52.Text = "A/D Convertor";
            this.label52.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnOkNext_A2D
            // 
            this.btnOkNext_A2D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkNext_A2D.BackColor = System.Drawing.Color.Transparent;
            this.btnOkNext_A2D.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnOkNext_A2D.FlatAppearance.BorderSize = 0;
            this.btnOkNext_A2D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkNext_A2D.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkNext_A2D.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkNext_A2D.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkNext_A2D.Location = new System.Drawing.Point(864, 366);
            this.btnOkNext_A2D.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkNext_A2D.Name = "btnOkNext_A2D";
            this.btnOkNext_A2D.Size = new System.Drawing.Size(108, 108);
            this.btnOkNext_A2D.TabIndex = 527;
            this.btnOkNext_A2D.UseVisualStyleBackColor = false;
            this.btnOkNext_A2D.Click += new System.EventHandler(this.btnOkNext_Click);
            // 
            // tabMotorDriver
            // 
            this.tabMotorDriver.BackColor = System.Drawing.Color.White;
            this.tabMotorDriver.Controls.Add(this.btnPrev_MotorDriver);
            this.tabMotorDriver.Controls.Add(this.label43);
            this.tabMotorDriver.Controls.Add(this.cboxMotorDrive);
            this.tabMotorDriver.Controls.Add(this.label63);
            this.tabMotorDriver.Controls.Add(this.btnOkNext_MotorDriver);
            this.tabMotorDriver.Location = new System.Drawing.Point(4, 19);
            this.tabMotorDriver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMotorDriver.Name = "tabMotorDriver";
            this.tabMotorDriver.Size = new System.Drawing.Size(986, 496);
            this.tabMotorDriver.TabIndex = 16;
            this.tabMotorDriver.Text = "MotorDriver";
            // 
            // btnPrev_MotorDriver
            // 
            this.btnPrev_MotorDriver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev_MotorDriver.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev_MotorDriver.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnPrev_MotorDriver.FlatAppearance.BorderSize = 0;
            this.btnPrev_MotorDriver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev_MotorDriver.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnPrev_MotorDriver.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.btnPrev_MotorDriver.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrev_MotorDriver.Location = new System.Drawing.Point(728, 366);
            this.btnPrev_MotorDriver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev_MotorDriver.Name = "btnPrev_MotorDriver";
            this.btnPrev_MotorDriver.Size = new System.Drawing.Size(108, 108);
            this.btnPrev_MotorDriver.TabIndex = 537;
            this.btnPrev_MotorDriver.UseVisualStyleBackColor = false;
            this.btnPrev_MotorDriver.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.Color.Black;
            this.label43.Location = new System.Drawing.Point(6, 6);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(326, 39);
            this.label43.TabIndex = 532;
            this.label43.Text = "Motor Driver Board";
            this.label43.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnOkNext_MotorDriver
            // 
            this.btnOkNext_MotorDriver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkNext_MotorDriver.BackColor = System.Drawing.Color.Transparent;
            this.btnOkNext_MotorDriver.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnOkNext_MotorDriver.FlatAppearance.BorderSize = 0;
            this.btnOkNext_MotorDriver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkNext_MotorDriver.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkNext_MotorDriver.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkNext_MotorDriver.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkNext_MotorDriver.Location = new System.Drawing.Point(864, 366);
            this.btnOkNext_MotorDriver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkNext_MotorDriver.Name = "btnOkNext_MotorDriver";
            this.btnOkNext_MotorDriver.Size = new System.Drawing.Size(108, 108);
            this.btnOkNext_MotorDriver.TabIndex = 526;
            this.btnOkNext_MotorDriver.UseVisualStyleBackColor = false;
            this.btnOkNext_MotorDriver.Click += new System.EventHandler(this.btnOkNext_Click);
            // 
            // tabInvertRelays
            // 
            this.tabInvertRelays.BackColor = System.Drawing.Color.White;
            this.tabInvertRelays.Controls.Add(this.label59);
            this.tabInvertRelays.Controls.Add(this.btnPrev_InvertRelays);
            this.tabInvertRelays.Controls.Add(this.label51);
            this.tabInvertRelays.Controls.Add(this.label29);
            this.tabInvertRelays.Controls.Add(this.btnOkNext_InvertRelays);
            this.tabInvertRelays.Controls.Add(this.chkSteerInvertRelays);
            this.tabInvertRelays.Location = new System.Drawing.Point(4, 19);
            this.tabInvertRelays.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabInvertRelays.Name = "tabInvertRelays";
            this.tabInvertRelays.Size = new System.Drawing.Size(986, 496);
            this.tabInvertRelays.TabIndex = 29;
            this.tabInvertRelays.Text = "InvertRelays";
            // 
            // label59
            // 
            this.label59.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label59.AutoSize = true;
            this.label59.BackColor = System.Drawing.Color.Transparent;
            this.label59.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label59.Location = new System.Drawing.Point(423, 316);
            this.label59.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(147, 24);
            this.label59.TabIndex = 539;
            this.label59.Text = "Invert Relays";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrev_InvertRelays
            // 
            this.btnPrev_InvertRelays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev_InvertRelays.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev_InvertRelays.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnPrev_InvertRelays.FlatAppearance.BorderSize = 0;
            this.btnPrev_InvertRelays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev_InvertRelays.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnPrev_InvertRelays.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.btnPrev_InvertRelays.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrev_InvertRelays.Location = new System.Drawing.Point(728, 366);
            this.btnPrev_InvertRelays.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev_InvertRelays.Name = "btnPrev_InvertRelays";
            this.btnPrev_InvertRelays.Size = new System.Drawing.Size(108, 108);
            this.btnPrev_InvertRelays.TabIndex = 537;
            this.btnPrev_InvertRelays.UseVisualStyleBackColor = false;
            this.btnPrev_InvertRelays.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Black;
            this.label51.Location = new System.Drawing.Point(8, 6);
            this.label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(342, 39);
            this.label51.TabIndex = 533;
            this.label51.Text = "Driver Control Relay";
            this.label51.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnOkNext_InvertRelays
            // 
            this.btnOkNext_InvertRelays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkNext_InvertRelays.BackColor = System.Drawing.Color.Transparent;
            this.btnOkNext_InvertRelays.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnOkNext_InvertRelays.FlatAppearance.BorderSize = 0;
            this.btnOkNext_InvertRelays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkNext_InvertRelays.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkNext_InvertRelays.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkNext_InvertRelays.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkNext_InvertRelays.Location = new System.Drawing.Point(864, 366);
            this.btnOkNext_InvertRelays.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkNext_InvertRelays.Name = "btnOkNext_InvertRelays";
            this.btnOkNext_InvertRelays.Size = new System.Drawing.Size(108, 108);
            this.btnOkNext_InvertRelays.TabIndex = 528;
            this.btnOkNext_InvertRelays.UseVisualStyleBackColor = false;
            this.btnOkNext_InvertRelays.Click += new System.EventHandler(this.btnOkNext_Click);
            // 
            // chkSteerInvertRelays
            // 
            this.chkSteerInvertRelays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSteerInvertRelays.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSteerInvertRelays.BackColor = System.Drawing.Color.AliceBlue;
            this.chkSteerInvertRelays.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.chkSteerInvertRelays.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.chkSteerInvertRelays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSteerInvertRelays.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSteerInvertRelays.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSteerInvertRelays.Image = global::AgOpenGPS.Properties.Resources.ConSt_InvertRelay;
            this.chkSteerInvertRelays.Location = new System.Drawing.Point(411, 195);
            this.chkSteerInvertRelays.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSteerInvertRelays.Name = "chkSteerInvertRelays";
            this.chkSteerInvertRelays.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSteerInvertRelays.Size = new System.Drawing.Size(164, 117);
            this.chkSteerInvertRelays.TabIndex = 503;
            this.chkSteerInvertRelays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSteerInvertRelays.UseVisualStyleBackColor = false;
            this.chkSteerInvertRelays.CheckedChanged += new System.EventHandler(this.chkSteerInvertRelays_CheckedChanged);
            // 
            // tabDanfoss
            // 
            this.tabDanfoss.BackColor = System.Drawing.Color.White;
            this.tabDanfoss.Controls.Add(this.btnPrev_Danfoss);
            this.tabDanfoss.Controls.Add(this.label50);
            this.tabDanfoss.Controls.Add(this.label55);
            this.tabDanfoss.Controls.Add(this.btnOkNext_Danfoss);
            this.tabDanfoss.Controls.Add(this.cboxDanfoss);
            this.tabDanfoss.Location = new System.Drawing.Point(4, 19);
            this.tabDanfoss.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabDanfoss.Name = "tabDanfoss";
            this.tabDanfoss.Size = new System.Drawing.Size(986, 496);
            this.tabDanfoss.TabIndex = 28;
            this.tabDanfoss.Text = "Danfoss";
            // 
            // btnPrev_Danfoss
            // 
            this.btnPrev_Danfoss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev_Danfoss.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev_Danfoss.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnPrev_Danfoss.FlatAppearance.BorderSize = 0;
            this.btnPrev_Danfoss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev_Danfoss.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnPrev_Danfoss.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.btnPrev_Danfoss.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrev_Danfoss.Location = new System.Drawing.Point(728, 366);
            this.btnPrev_Danfoss.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev_Danfoss.Name = "btnPrev_Danfoss";
            this.btnPrev_Danfoss.Size = new System.Drawing.Size(108, 108);
            this.btnPrev_Danfoss.TabIndex = 537;
            this.btnPrev_Danfoss.UseVisualStyleBackColor = false;
            this.btnPrev_Danfoss.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.Black;
            this.label50.Location = new System.Drawing.Point(8, 6);
            this.label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(242, 39);
            this.label50.TabIndex = 533;
            this.label50.Text = "Danfoss Valve";
            this.label50.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnOkNext_Danfoss
            // 
            this.btnOkNext_Danfoss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkNext_Danfoss.BackColor = System.Drawing.Color.Transparent;
            this.btnOkNext_Danfoss.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnOkNext_Danfoss.FlatAppearance.BorderSize = 0;
            this.btnOkNext_Danfoss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkNext_Danfoss.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkNext_Danfoss.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkNext_Danfoss.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkNext_Danfoss.Location = new System.Drawing.Point(864, 366);
            this.btnOkNext_Danfoss.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkNext_Danfoss.Name = "btnOkNext_Danfoss";
            this.btnOkNext_Danfoss.Size = new System.Drawing.Size(108, 108);
            this.btnOkNext_Danfoss.TabIndex = 528;
            this.btnOkNext_Danfoss.UseVisualStyleBackColor = false;
            this.btnOkNext_Danfoss.Click += new System.EventHandler(this.btnOkNext_Click);
            // 
            // cboxDanfoss
            // 
            this.cboxDanfoss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxDanfoss.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxDanfoss.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxDanfoss.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxDanfoss.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxDanfoss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxDanfoss.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDanfoss.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxDanfoss.Image = global::AgOpenGPS.Properties.Resources.ConSt_Danfoss;
            this.cboxDanfoss.Location = new System.Drawing.Point(411, 195);
            this.cboxDanfoss.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboxDanfoss.Name = "cboxDanfoss";
            this.cboxDanfoss.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxDanfoss.Size = new System.Drawing.Size(171, 117);
            this.cboxDanfoss.TabIndex = 507;
            this.cboxDanfoss.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxDanfoss.UseVisualStyleBackColor = false;
            this.cboxDanfoss.CheckedChanged += new System.EventHandler(this.cboxDanfoss_CheckedChanged);
            // 
            // tabWAS
            // 
            this.tabWAS.BackColor = System.Drawing.Color.White;
            this.tabWAS.Controls.Add(this.label45);
            this.tabWAS.Controls.Add(this.btnPrev_InvertWAS);
            this.tabWAS.Controls.Add(this.label42);
            this.tabWAS.Controls.Add(this.label30);
            this.tabWAS.Controls.Add(this.btnOkWAS);
            this.tabWAS.Controls.Add(this.chkInvertWAS);
            this.tabWAS.Location = new System.Drawing.Point(4, 19);
            this.tabWAS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabWAS.Name = "tabWAS";
            this.tabWAS.Size = new System.Drawing.Size(986, 496);
            this.tabWAS.TabIndex = 18;
            this.tabWAS.Text = "WAS";
            // 
            // label45
            // 
            this.label45.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label45.Location = new System.Drawing.Point(435, 316);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(128, 24);
            this.label45.TabIndex = 538;
            this.label45.Text = "Invert WAS";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrev_InvertWAS
            // 
            this.btnPrev_InvertWAS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev_InvertWAS.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev_InvertWAS.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnPrev_InvertWAS.FlatAppearance.BorderSize = 0;
            this.btnPrev_InvertWAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev_InvertWAS.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnPrev_InvertWAS.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.btnPrev_InvertWAS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrev_InvertWAS.Location = new System.Drawing.Point(728, 366);
            this.btnPrev_InvertWAS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev_InvertWAS.Name = "btnPrev_InvertWAS";
            this.btnPrev_InvertWAS.Size = new System.Drawing.Size(108, 108);
            this.btnPrev_InvertWAS.TabIndex = 537;
            this.btnPrev_InvertWAS.UseVisualStyleBackColor = false;
            this.btnPrev_InvertWAS.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(6, 6);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(248, 39);
            this.label42.TabIndex = 532;
            this.label42.Text = "WAS Direction";
            this.label42.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnOkWAS
            // 
            this.btnOkWAS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkWAS.BackColor = System.Drawing.Color.Transparent;
            this.btnOkWAS.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnOkWAS.FlatAppearance.BorderSize = 0;
            this.btnOkWAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkWAS.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkWAS.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkWAS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkWAS.Location = new System.Drawing.Point(864, 366);
            this.btnOkWAS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkWAS.Name = "btnOkWAS";
            this.btnOkWAS.Size = new System.Drawing.Size(108, 108);
            this.btnOkWAS.TabIndex = 526;
            this.btnOkWAS.UseVisualStyleBackColor = false;
            this.btnOkWAS.Click += new System.EventHandler(this.btnOkNext_Click);
            // 
            // chkInvertWAS
            // 
            this.chkInvertWAS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.chkInvertWAS.Location = new System.Drawing.Point(411, 195);
            this.chkInvertWAS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkInvertWAS.Name = "chkInvertWAS";
            this.chkInvertWAS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkInvertWAS.Size = new System.Drawing.Size(164, 117);
            this.chkInvertWAS.TabIndex = 490;
            this.chkInvertWAS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkInvertWAS.UseVisualStyleBackColor = false;
            this.chkInvertWAS.CheckedChanged += new System.EventHandler(this.chkInvertWAS_CheckedChanged);
            // 
            // tabMotorDirection
            // 
            this.tabMotorDirection.BackColor = System.Drawing.Color.White;
            this.tabMotorDirection.Controls.Add(this.label58);
            this.tabMotorDirection.Controls.Add(this.label41);
            this.tabMotorDirection.Controls.Add(this.label17);
            this.tabMotorDirection.Controls.Add(this.label33);
            this.tabMotorDirection.Controls.Add(this.label70);
            this.tabMotorDirection.Controls.Add(this.btnPrev_MotorDirection);
            this.tabMotorDirection.Controls.Add(this.btnOkNext_MotorDirection);
            this.tabMotorDirection.Controls.Add(this.btnSteerLeft);
            this.tabMotorDirection.Controls.Add(this.btnSteerRight);
            this.tabMotorDirection.Controls.Add(this.chkInvertSteer);
            this.tabMotorDirection.Location = new System.Drawing.Point(4, 19);
            this.tabMotorDirection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMotorDirection.Name = "tabMotorDirection";
            this.tabMotorDirection.Size = new System.Drawing.Size(986, 496);
            this.tabMotorDirection.TabIndex = 17;
            this.tabMotorDirection.Text = "MotorDirection";
            this.tabMotorDirection.Enter += new System.EventHandler(this.tabMotorDirection_Enter);
            this.tabMotorDirection.Leave += new System.EventHandler(this.tabMotorDirection_Leave);
            // 
            // label58
            // 
            this.label58.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.Color.Transparent;
            this.label58.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label58.Location = new System.Drawing.Point(411, 316);
            this.label58.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(172, 24);
            this.label58.TabIndex = 540;
            this.label58.Text = "Invert Direction";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(4, 6);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(363, 39);
            this.label41.TabIndex = 532;
            this.label41.Text = "Steer Motor Direction";
            this.label41.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(261, 324);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 24);
            this.label17.TabIndex = 530;
            this.label17.Text = "Left";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label33.Location = new System.Drawing.Point(663, 324);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(65, 24);
            this.label33.TabIndex = 529;
            this.label33.Text = "Right";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrev_MotorDirection
            // 
            this.btnPrev_MotorDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev_MotorDirection.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev_MotorDirection.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnPrev_MotorDirection.FlatAppearance.BorderSize = 0;
            this.btnPrev_MotorDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev_MotorDirection.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnPrev_MotorDirection.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.btnPrev_MotorDirection.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrev_MotorDirection.Location = new System.Drawing.Point(728, 366);
            this.btnPrev_MotorDirection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev_MotorDirection.Name = "btnPrev_MotorDirection";
            this.btnPrev_MotorDirection.Size = new System.Drawing.Size(108, 108);
            this.btnPrev_MotorDirection.TabIndex = 537;
            this.btnPrev_MotorDirection.UseVisualStyleBackColor = false;
            this.btnPrev_MotorDirection.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnOkNext_MotorDirection
            // 
            this.btnOkNext_MotorDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkNext_MotorDirection.BackColor = System.Drawing.Color.Transparent;
            this.btnOkNext_MotorDirection.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnOkNext_MotorDirection.FlatAppearance.BorderSize = 0;
            this.btnOkNext_MotorDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkNext_MotorDirection.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkNext_MotorDirection.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkNext_MotorDirection.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkNext_MotorDirection.Location = new System.Drawing.Point(864, 366);
            this.btnOkNext_MotorDirection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkNext_MotorDirection.Name = "btnOkNext_MotorDirection";
            this.btnOkNext_MotorDirection.Size = new System.Drawing.Size(108, 108);
            this.btnOkNext_MotorDirection.TabIndex = 528;
            this.btnOkNext_MotorDirection.UseVisualStyleBackColor = false;
            this.btnOkNext_MotorDirection.Click += new System.EventHandler(this.btnOkNext_Click);
            // 
            // btnSteerLeft
            // 
            this.btnSteerLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSteerLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnSteerLeft.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnSteerLeft.FlatAppearance.BorderSize = 0;
            this.btnSteerLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSteerLeft.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSteerLeft.Image = global::AgOpenGPS.Properties.Resources.SteerLeft;
            this.btnSteerLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSteerLeft.Location = new System.Drawing.Point(225, 200);
            this.btnSteerLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSteerLeft.Name = "btnSteerLeft";
            this.btnSteerLeft.Size = new System.Drawing.Size(114, 122);
            this.btnSteerLeft.TabIndex = 525;
            this.btnSteerLeft.UseVisualStyleBackColor = false;
            this.btnSteerLeft.Click += new System.EventHandler(this.btnSteerLeft_Click);
            // 
            // btnSteerRight
            // 
            this.btnSteerRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSteerRight.BackColor = System.Drawing.Color.Transparent;
            this.btnSteerRight.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnSteerRight.FlatAppearance.BorderSize = 0;
            this.btnSteerRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSteerRight.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSteerRight.Image = global::AgOpenGPS.Properties.Resources.SteerRight;
            this.btnSteerRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSteerRight.Location = new System.Drawing.Point(638, 200);
            this.btnSteerRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSteerRight.Name = "btnSteerRight";
            this.btnSteerRight.Size = new System.Drawing.Size(114, 120);
            this.btnSteerRight.TabIndex = 526;
            this.btnSteerRight.UseVisualStyleBackColor = false;
            this.btnSteerRight.Click += new System.EventHandler(this.btnSteerRight_Click);
            // 
            // chkInvertSteer
            // 
            this.chkInvertSteer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkInvertSteer.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkInvertSteer.BackColor = System.Drawing.Color.AliceBlue;
            this.chkInvertSteer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.chkInvertSteer.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.chkInvertSteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkInvertSteer.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInvertSteer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkInvertSteer.Image = global::AgOpenGPS.Properties.Resources.ConSt_InvertDirection;
            this.chkInvertSteer.Location = new System.Drawing.Point(411, 195);
            this.chkInvertSteer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkInvertSteer.Name = "chkInvertSteer";
            this.chkInvertSteer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkInvertSteer.Size = new System.Drawing.Size(164, 117);
            this.chkInvertSteer.TabIndex = 491;
            this.chkInvertSteer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkInvertSteer.UseVisualStyleBackColor = false;
            this.chkInvertSteer.CheckedChanged += new System.EventHandler(this.chkInvertSteer_CheckedChanged);
            // 
            // tabCPD_Setup
            // 
            this.tabCPD_Setup.BackColor = System.Drawing.Color.White;
            this.tabCPD_Setup.Controls.Add(this.label60);
            this.tabCPD_Setup.Controls.Add(this.btnPrev_CountsPerDegree);
            this.tabCPD_Setup.Controls.Add(this.label74);
            this.tabCPD_Setup.Controls.Add(this.label75);
            this.tabCPD_Setup.Controls.Add(this.btnSkipCPD_Setup);
            this.tabCPD_Setup.Controls.Add(this.btnOKNext_CPDSetup);
            this.tabCPD_Setup.Location = new System.Drawing.Point(4, 19);
            this.tabCPD_Setup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCPD_Setup.Name = "tabCPD_Setup";
            this.tabCPD_Setup.Size = new System.Drawing.Size(986, 496);
            this.tabCPD_Setup.TabIndex = 33;
            this.tabCPD_Setup.Text = "CPD_Setup";
            // 
            // label60
            // 
            this.label60.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label60.BackColor = System.Drawing.Color.Transparent;
            this.label60.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.Color.Black;
            this.label60.Location = new System.Drawing.Point(20, 394);
            this.label60.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(702, 52);
            this.label60.TabIndex = 544;
            this.label60.Text = "Begin WAS Calibration";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrev_CountsPerDegree
            // 
            this.btnPrev_CountsPerDegree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev_CountsPerDegree.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev_CountsPerDegree.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrev_CountsPerDegree.FlatAppearance.BorderSize = 0;
            this.btnPrev_CountsPerDegree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev_CountsPerDegree.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnPrev_CountsPerDegree.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.btnPrev_CountsPerDegree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrev_CountsPerDegree.Location = new System.Drawing.Point(728, 366);
            this.btnPrev_CountsPerDegree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev_CountsPerDegree.Name = "btnPrev_CountsPerDegree";
            this.btnPrev_CountsPerDegree.Size = new System.Drawing.Size(108, 108);
            this.btnPrev_CountsPerDegree.TabIndex = 537;
            this.btnPrev_CountsPerDegree.UseVisualStyleBackColor = false;
            this.btnPrev_CountsPerDegree.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.BackColor = System.Drawing.Color.Transparent;
            this.label74.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.ForeColor = System.Drawing.Color.Black;
            this.label74.Location = new System.Drawing.Point(8, 8);
            this.label74.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(277, 39);
            this.label74.TabIndex = 543;
            this.label74.Text = "WAS Calibration";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label75
            // 
            this.label75.BackColor = System.Drawing.Color.Transparent;
            this.label75.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.ForeColor = System.Drawing.Color.Black;
            this.label75.Location = new System.Drawing.Point(118, 146);
            this.label75.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(603, 129);
            this.label75.TabIndex = 542;
            this.label75.Text = "* SKIP *  Counts Per Degree, WAS Zero, and Ackermann Setting?";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSkipCPD_Setup
            // 
            this.btnSkipCPD_Setup.BackColor = System.Drawing.Color.Transparent;
            this.btnSkipCPD_Setup.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnSkipCPD_Setup.FlatAppearance.BorderSize = 0;
            this.btnSkipCPD_Setup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkipCPD_Setup.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSkipCPD_Setup.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnSkipCPD_Setup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSkipCPD_Setup.Location = new System.Drawing.Point(730, 168);
            this.btnSkipCPD_Setup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSkipCPD_Setup.Name = "btnSkipCPD_Setup";
            this.btnSkipCPD_Setup.Size = new System.Drawing.Size(108, 92);
            this.btnSkipCPD_Setup.TabIndex = 539;
            this.btnSkipCPD_Setup.UseVisualStyleBackColor = false;
            this.btnSkipCPD_Setup.Click += new System.EventHandler(this.btnSkipCPD_Setup_Click);
            // 
            // btnOKNext_CPDSetup
            // 
            this.btnOKNext_CPDSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOKNext_CPDSetup.BackColor = System.Drawing.Color.Transparent;
            this.btnOKNext_CPDSetup.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnOKNext_CPDSetup.FlatAppearance.BorderSize = 0;
            this.btnOKNext_CPDSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOKNext_CPDSetup.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOKNext_CPDSetup.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOKNext_CPDSetup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOKNext_CPDSetup.Location = new System.Drawing.Point(864, 366);
            this.btnOKNext_CPDSetup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOKNext_CPDSetup.Name = "btnOKNext_CPDSetup";
            this.btnOKNext_CPDSetup.Size = new System.Drawing.Size(108, 108);
            this.btnOKNext_CPDSetup.TabIndex = 541;
            this.btnOKNext_CPDSetup.UseVisualStyleBackColor = false;
            this.btnOKNext_CPDSetup.Click += new System.EventHandler(this.btnOKNext_CPDSetup_Click);
            // 
            // tabWAS_Zero
            // 
            this.tabWAS_Zero.BackColor = System.Drawing.Color.White;
            this.tabWAS_Zero.Controls.Add(this.button6);
            this.tabWAS_Zero.Controls.Add(this.btnRemoveWasOffset);
            this.tabWAS_Zero.Controls.Add(this.label40);
            this.tabWAS_Zero.Controls.Add(this.hsbarWasOffset);
            this.tabWAS_Zero.Controls.Add(this.lblSteerAngleSensorZero);
            this.tabWAS_Zero.Controls.Add(this.label10);
            this.tabWAS_Zero.Controls.Add(this.btnOkNext_WAS_Zero);
            this.tabWAS_Zero.Controls.Add(this.btnZeroWAS);
            this.tabWAS_Zero.Location = new System.Drawing.Point(4, 19);
            this.tabWAS_Zero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabWAS_Zero.Name = "tabWAS_Zero";
            this.tabWAS_Zero.Size = new System.Drawing.Size(986, 496);
            this.tabWAS_Zero.TabIndex = 21;
            this.tabWAS_Zero.Text = "WAS_Zero";
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.button6.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.button6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button6.Location = new System.Drawing.Point(728, 366);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(108, 108);
            this.button6.TabIndex = 538;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnRemoveWasOffset
            // 
            this.btnRemoveWasOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveWasOffset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveWasOffset.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRemoveWasOffset.FlatAppearance.BorderSize = 0;
            this.btnRemoveWasOffset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveWasOffset.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveWasOffset.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRemoveWasOffset.Image = global::AgOpenGPS.Properties.Resources.WizWasZeroReset;
            this.btnRemoveWasOffset.Location = new System.Drawing.Point(106, 261);
            this.btnRemoveWasOffset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveWasOffset.Name = "btnRemoveWasOffset";
            this.btnRemoveWasOffset.Size = new System.Drawing.Size(150, 108);
            this.btnRemoveWasOffset.TabIndex = 533;
            this.btnRemoveWasOffset.UseVisualStyleBackColor = true;
            this.btnRemoveWasOffset.Click += new System.EventHandler(this.btnRemoveWasOffset_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(4, 6);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(224, 39);
            this.label40.TabIndex = 532;
            this.label40.Text = "WAS Zeroing";
            this.label40.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnOkNext_WAS_Zero
            // 
            this.btnOkNext_WAS_Zero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkNext_WAS_Zero.BackColor = System.Drawing.Color.Transparent;
            this.btnOkNext_WAS_Zero.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnOkNext_WAS_Zero.FlatAppearance.BorderSize = 0;
            this.btnOkNext_WAS_Zero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkNext_WAS_Zero.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkNext_WAS_Zero.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkNext_WAS_Zero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkNext_WAS_Zero.Location = new System.Drawing.Point(864, 366);
            this.btnOkNext_WAS_Zero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkNext_WAS_Zero.Name = "btnOkNext_WAS_Zero";
            this.btnOkNext_WAS_Zero.Size = new System.Drawing.Size(108, 108);
            this.btnOkNext_WAS_Zero.TabIndex = 529;
            this.btnOkNext_WAS_Zero.UseVisualStyleBackColor = false;
            this.btnOkNext_WAS_Zero.Click += new System.EventHandler(this.btnOkNext_Click);
            // 
            // btnZeroWAS
            // 
            this.btnZeroWAS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZeroWAS.BackgroundImage = global::AgOpenGPS.Properties.Resources.WizWasZero;
            this.btnZeroWAS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZeroWAS.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnZeroWAS.FlatAppearance.BorderSize = 0;
            this.btnZeroWAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZeroWAS.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroWAS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZeroWAS.Location = new System.Drawing.Point(410, 144);
            this.btnZeroWAS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnZeroWAS.Name = "btnZeroWAS";
            this.btnZeroWAS.Size = new System.Drawing.Size(150, 116);
            this.btnZeroWAS.TabIndex = 323;
            this.btnZeroWAS.UseVisualStyleBackColor = true;
            this.btnZeroWAS.Click += new System.EventHandler(this.btnZeroWAS_Click);
            // 
            // tabCountsPerDeg
            // 
            this.tabCountsPerDeg.BackColor = System.Drawing.Color.White;
            this.tabCountsPerDeg.Controls.Add(this.button5);
            this.tabCountsPerDeg.Controls.Add(this.lblCPDError);
            this.tabCountsPerDeg.Controls.Add(this.label39);
            this.tabCountsPerDeg.Controls.Add(this.hsbarCountsPerDegree);
            this.tabCountsPerDeg.Controls.Add(this.label8);
            this.tabCountsPerDeg.Controls.Add(this.lblCountsPerDegree);
            this.tabCountsPerDeg.Controls.Add(this.label7);
            this.tabCountsPerDeg.Controls.Add(this.lblDiameter);
            this.tabCountsPerDeg.Controls.Add(this.lblCalcSteerAngleInner);
            this.tabCountsPerDeg.Controls.Add(this.label1);
            this.tabCountsPerDeg.Controls.Add(this.btnOkNext_CountsPerDeg);
            this.tabCountsPerDeg.Controls.Add(this.btnStartSA);
            this.tabCountsPerDeg.Location = new System.Drawing.Point(4, 19);
            this.tabCountsPerDeg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCountsPerDeg.Name = "tabCountsPerDeg";
            this.tabCountsPerDeg.Size = new System.Drawing.Size(986, 496);
            this.tabCountsPerDeg.TabIndex = 22;
            this.tabCountsPerDeg.Text = "CountsPerDeg";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.button5.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.button5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button5.Location = new System.Drawing.Point(728, 366);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 108);
            this.button5.TabIndex = 538;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lblCPDError
            // 
            this.lblCPDError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCPDError.AutoSize = true;
            this.lblCPDError.BackColor = System.Drawing.Color.Transparent;
            this.lblCPDError.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPDError.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCPDError.Location = new System.Drawing.Point(232, 315);
            this.lblCPDError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCPDError.Name = "lblCPDError";
            this.lblCPDError.Size = new System.Drawing.Size(47, 39);
            this.lblCPDError.TabIndex = 532;
            this.lblCPDError.Text = "...";
            this.lblCPDError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(4, 4);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(387, 39);
            this.label39.TabIndex = 531;
            this.label39.Text = "Counts per Degree";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOkNext_CountsPerDeg
            // 
            this.btnOkNext_CountsPerDeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkNext_CountsPerDeg.BackColor = System.Drawing.Color.Transparent;
            this.btnOkNext_CountsPerDeg.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnOkNext_CountsPerDeg.FlatAppearance.BorderSize = 0;
            this.btnOkNext_CountsPerDeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkNext_CountsPerDeg.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkNext_CountsPerDeg.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkNext_CountsPerDeg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkNext_CountsPerDeg.Location = new System.Drawing.Point(864, 366);
            this.btnOkNext_CountsPerDeg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkNext_CountsPerDeg.Name = "btnOkNext_CountsPerDeg";
            this.btnOkNext_CountsPerDeg.Size = new System.Drawing.Size(108, 108);
            this.btnOkNext_CountsPerDeg.TabIndex = 529;
            this.btnOkNext_CountsPerDeg.UseVisualStyleBackColor = false;
            this.btnOkNext_CountsPerDeg.Click += new System.EventHandler(this.btnOkNext_Click);
            // 
            // btnStartSA
            // 
            this.btnStartSA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartSA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStartSA.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartSA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStartSA.Image = global::AgOpenGPS.Properties.Resources.BoundaryRecord;
            this.btnStartSA.Location = new System.Drawing.Point(282, 156);
            this.btnStartSA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartSA.Name = "btnStartSA";
            this.btnStartSA.Size = new System.Drawing.Size(110, 117);
            this.btnStartSA.TabIndex = 323;
            this.btnStartSA.UseVisualStyleBackColor = true;
            this.btnStartSA.Click += new System.EventHandler(this.btnStartSA_Click);
            // 
            // tabAckermannRight
            // 
            this.tabAckermannRight.BackColor = System.Drawing.Color.White;
            this.tabAckermannRight.Controls.Add(this.button4);
            this.tabAckermannRight.Controls.Add(this.label46);
            this.tabAckermannRight.Controls.Add(this.label36);
            this.tabAckermannRight.Controls.Add(this.btnOkLockRightCalc);
            this.tabAckermannRight.Location = new System.Drawing.Point(4, 19);
            this.tabAckermannRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabAckermannRight.Name = "tabAckermannRight";
            this.tabAckermannRight.Size = new System.Drawing.Size(986, 496);
            this.tabAckermannRight.TabIndex = 24;
            this.tabAckermannRight.Text = "AckermannRight";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.button4.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button4.Location = new System.Drawing.Point(728, 366);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 108);
            this.button4.TabIndex = 538;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.Black;
            this.label46.Location = new System.Drawing.Point(8, 6);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(322, 39);
            this.label46.TabIndex = 528;
            this.label46.Text = "Ackermann Setting";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.Black;
            this.label36.Location = new System.Drawing.Point(270, 195);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(476, 39);
            this.label36.TabIndex = 320;
            this.label36.Text = "Turn steering all the way RIGHT";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOkLockRightCalc
            // 
            this.btnOkLockRightCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkLockRightCalc.BackColor = System.Drawing.Color.Transparent;
            this.btnOkLockRightCalc.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOkLockRightCalc.FlatAppearance.BorderSize = 0;
            this.btnOkLockRightCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkLockRightCalc.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkLockRightCalc.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkLockRightCalc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkLockRightCalc.Location = new System.Drawing.Point(430, 254);
            this.btnOkLockRightCalc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkLockRightCalc.Name = "btnOkLockRightCalc";
            this.btnOkLockRightCalc.Size = new System.Drawing.Size(108, 108);
            this.btnOkLockRightCalc.TabIndex = 525;
            this.btnOkLockRightCalc.UseVisualStyleBackColor = false;
            this.btnOkLockRightCalc.Click += new System.EventHandler(this.btnOkLockRightCalc_Click);
            // 
            // tabAckermannLeft
            // 
            this.tabAckermannLeft.BackColor = System.Drawing.Color.White;
            this.tabAckermannLeft.Controls.Add(this.button3);
            this.tabAckermannLeft.Controls.Add(this.label47);
            this.tabAckermannLeft.Controls.Add(this.label37);
            this.tabAckermannLeft.Controls.Add(this.btnOkLockLeftCalc);
            this.tabAckermannLeft.Location = new System.Drawing.Point(4, 19);
            this.tabAckermannLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabAckermannLeft.Name = "tabAckermannLeft";
            this.tabAckermannLeft.Size = new System.Drawing.Size(986, 496);
            this.tabAckermannLeft.TabIndex = 23;
            this.tabAckermannLeft.Text = "AckermannLeft";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.button3.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(728, 366);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 108);
            this.button3.TabIndex = 537;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.BackColor = System.Drawing.Color.Transparent;
            this.label47.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.Black;
            this.label47.Location = new System.Drawing.Point(9, 6);
            this.label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(322, 39);
            this.label47.TabIndex = 529;
            this.label47.Text = "Ackermann Setting";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(72, 192);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(846, 44);
            this.label37.TabIndex = 321;
            this.label37.Text = "Turn steering all the way LEFT";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOkLockLeftCalc
            // 
            this.btnOkLockLeftCalc.BackColor = System.Drawing.Color.Transparent;
            this.btnOkLockLeftCalc.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOkLockLeftCalc.FlatAppearance.BorderSize = 0;
            this.btnOkLockLeftCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkLockLeftCalc.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkLockLeftCalc.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkLockLeftCalc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkLockLeftCalc.Location = new System.Drawing.Point(430, 254);
            this.btnOkLockLeftCalc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkLockLeftCalc.Name = "btnOkLockLeftCalc";
            this.btnOkLockLeftCalc.Size = new System.Drawing.Size(108, 108);
            this.btnOkLockLeftCalc.TabIndex = 525;
            this.btnOkLockLeftCalc.UseVisualStyleBackColor = false;
            this.btnOkLockLeftCalc.Click += new System.EventHandler(this.btnOkLockLeftCalc_Click);
            // 
            // tabAckermannCalc
            // 
            this.tabAckermannCalc.BackColor = System.Drawing.Color.White;
            this.tabAckermannCalc.Controls.Add(this.btnPrev_AckermannCalc);
            this.tabAckermannCalc.Controls.Add(this.lblAckError);
            this.tabAckermannCalc.Controls.Add(this.lblAckLeft);
            this.tabAckermannCalc.Controls.Add(this.lblAckRight);
            this.tabAckermannCalc.Controls.Add(this.label57);
            this.tabAckermannCalc.Controls.Add(this.label56);
            this.tabAckermannCalc.Controls.Add(this.label48);
            this.tabAckermannCalc.Controls.Add(this.label32);
            this.tabAckermannCalc.Controls.Add(this.hsbarAckerman);
            this.tabAckermannCalc.Controls.Add(this.lblAckerman);
            this.tabAckermannCalc.Controls.Add(this.btnOkNext_AckermannCalc);
            this.tabAckermannCalc.Location = new System.Drawing.Point(4, 19);
            this.tabAckermannCalc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabAckermannCalc.Name = "tabAckermannCalc";
            this.tabAckermannCalc.Size = new System.Drawing.Size(986, 496);
            this.tabAckermannCalc.TabIndex = 25;
            this.tabAckermannCalc.Text = "AckermannCalc";
            // 
            // btnPrev_AckermannCalc
            // 
            this.btnPrev_AckermannCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev_AckermannCalc.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev_AckermannCalc.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnPrev_AckermannCalc.FlatAppearance.BorderSize = 0;
            this.btnPrev_AckermannCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev_AckermannCalc.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnPrev_AckermannCalc.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.btnPrev_AckermannCalc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrev_AckermannCalc.Location = new System.Drawing.Point(728, 366);
            this.btnPrev_AckermannCalc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev_AckermannCalc.Name = "btnPrev_AckermannCalc";
            this.btnPrev_AckermannCalc.Size = new System.Drawing.Size(108, 108);
            this.btnPrev_AckermannCalc.TabIndex = 537;
            this.btnPrev_AckermannCalc.UseVisualStyleBackColor = false;
            this.btnPrev_AckermannCalc.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lblAckError
            // 
            this.lblAckError.AutoSize = true;
            this.lblAckError.BackColor = System.Drawing.Color.Transparent;
            this.lblAckError.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAckError.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAckError.Location = new System.Drawing.Point(250, 110);
            this.lblAckError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAckError.Name = "lblAckError";
            this.lblAckError.Size = new System.Drawing.Size(37, 29);
            this.lblAckError.TabIndex = 535;
            this.lblAckError.Text = "...";
            this.lblAckError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAckLeft
            // 
            this.lblAckLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblAckLeft.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAckLeft.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAckLeft.Location = new System.Drawing.Point(394, 184);
            this.lblAckLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAckLeft.Name = "lblAckLeft";
            this.lblAckLeft.Size = new System.Drawing.Size(84, 28);
            this.lblAckLeft.TabIndex = 534;
            this.lblAckLeft.Text = "0.0";
            this.lblAckLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAckRight
            // 
            this.lblAckRight.BackColor = System.Drawing.Color.Transparent;
            this.lblAckRight.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAckRight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAckRight.Location = new System.Drawing.Point(552, 184);
            this.lblAckRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAckRight.Name = "lblAckRight";
            this.lblAckRight.Size = new System.Drawing.Size(84, 28);
            this.lblAckRight.TabIndex = 533;
            this.lblAckRight.Text = "0.0";
            this.lblAckRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.BackColor = System.Drawing.Color.Transparent;
            this.label57.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label57.Location = new System.Drawing.Point(552, 146);
            this.label57.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(86, 29);
            this.label57.TabIndex = 531;
            this.label57.Text = "Right:";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.BackColor = System.Drawing.Color.Transparent;
            this.label56.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label56.Location = new System.Drawing.Point(405, 146);
            this.label56.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(69, 29);
            this.label56.TabIndex = 530;
            this.label56.Text = "Left:";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.BackColor = System.Drawing.Color.Transparent;
            this.label48.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.Color.Black;
            this.label48.Location = new System.Drawing.Point(8, 8);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(375, 39);
            this.label48.TabIndex = 529;
            this.label48.Text = "Ackermann Calculated";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(117, 243);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(776, 44);
            this.label32.TabIndex = 526;
            this.label32.Text = "Ackermann Value:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOkNext_AckermannCalc
            // 
            this.btnOkNext_AckermannCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkNext_AckermannCalc.BackColor = System.Drawing.Color.Transparent;
            this.btnOkNext_AckermannCalc.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOkNext_AckermannCalc.FlatAppearance.BorderSize = 0;
            this.btnOkNext_AckermannCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkNext_AckermannCalc.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkNext_AckermannCalc.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkNext_AckermannCalc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkNext_AckermannCalc.Location = new System.Drawing.Point(864, 366);
            this.btnOkNext_AckermannCalc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkNext_AckermannCalc.Name = "btnOkNext_AckermannCalc";
            this.btnOkNext_AckermannCalc.Size = new System.Drawing.Size(108, 108);
            this.btnOkNext_AckermannCalc.TabIndex = 525;
            this.btnOkNext_AckermannCalc.UseVisualStyleBackColor = false;
            this.btnOkNext_AckermannCalc.Click += new System.EventHandler(this.btnOkNext_Click);
            // 
            // tabMaxSteerAngle
            // 
            this.tabMaxSteerAngle.BackColor = System.Drawing.Color.White;
            this.tabMaxSteerAngle.Controls.Add(this.btnOkSetMaximumSteerAngle);
            this.tabMaxSteerAngle.Controls.Add(this.label73);
            this.tabMaxSteerAngle.Controls.Add(this.btnPrev_MaxSteerAngle);
            this.tabMaxSteerAngle.Controls.Add(this.label49);
            this.tabMaxSteerAngle.Controls.Add(this.label23);
            this.tabMaxSteerAngle.Controls.Add(this.lblMaxSteerAngle);
            this.tabMaxSteerAngle.Controls.Add(this.hsbarMaxSteerAngle);
            this.tabMaxSteerAngle.Controls.Add(this.btnOkNextMaxSteerAngle);
            this.tabMaxSteerAngle.Location = new System.Drawing.Point(4, 19);
            this.tabMaxSteerAngle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMaxSteerAngle.Name = "tabMaxSteerAngle";
            this.tabMaxSteerAngle.Size = new System.Drawing.Size(986, 496);
            this.tabMaxSteerAngle.TabIndex = 26;
            this.tabMaxSteerAngle.Text = "MaxSteerAngle";
            // 
            // btnOkSetMaximumSteerAngle
            // 
            this.btnOkSetMaximumSteerAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkSetMaximumSteerAngle.BackColor = System.Drawing.Color.Transparent;
            this.btnOkSetMaximumSteerAngle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOkSetMaximumSteerAngle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOkSetMaximumSteerAngle.FlatAppearance.BorderSize = 0;
            this.btnOkSetMaximumSteerAngle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkSetMaximumSteerAngle.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkSetMaximumSteerAngle.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnOkSetMaximumSteerAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkSetMaximumSteerAngle.Location = new System.Drawing.Point(696, 100);
            this.btnOkSetMaximumSteerAngle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkSetMaximumSteerAngle.Name = "btnOkSetMaximumSteerAngle";
            this.btnOkSetMaximumSteerAngle.Size = new System.Drawing.Size(156, 108);
            this.btnOkSetMaximumSteerAngle.TabIndex = 541;
            this.btnOkSetMaximumSteerAngle.UseVisualStyleBackColor = false;
            this.btnOkSetMaximumSteerAngle.Click += new System.EventHandler(this.btnOkSetMaximumSteerAngle_Click);
            // 
            // label73
            // 
            this.label73.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label73.BackColor = System.Drawing.Color.Transparent;
            this.label73.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.Color.Black;
            this.label73.Location = new System.Drawing.Point(66, 111);
            this.label73.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(602, 84);
            this.label73.TabIndex = 538;
            this.label73.Text = "Turn steering right to your desired limit for guidance and touch OK";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrev_MaxSteerAngle
            // 
            this.btnPrev_MaxSteerAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev_MaxSteerAngle.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev_MaxSteerAngle.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnPrev_MaxSteerAngle.FlatAppearance.BorderSize = 0;
            this.btnPrev_MaxSteerAngle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev_MaxSteerAngle.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnPrev_MaxSteerAngle.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.btnPrev_MaxSteerAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrev_MaxSteerAngle.Location = new System.Drawing.Point(728, 366);
            this.btnPrev_MaxSteerAngle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev_MaxSteerAngle.Name = "btnPrev_MaxSteerAngle";
            this.btnPrev_MaxSteerAngle.Size = new System.Drawing.Size(108, 108);
            this.btnPrev_MaxSteerAngle.TabIndex = 537;
            this.btnPrev_MaxSteerAngle.UseVisualStyleBackColor = false;
            this.btnPrev_MaxSteerAngle.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.Black;
            this.label49.Location = new System.Drawing.Point(8, 8);
            this.label49.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(451, 39);
            this.label49.TabIndex = 532;
            this.label49.Text = "Guidance Steer Angle Limit";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(32, 272);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(858, 44);
            this.label23.TabIndex = 531;
            this.label23.Text = "Or Manually Set Guidance Steer Angle Limit";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOkNextMaxSteerAngle
            // 
            this.btnOkNextMaxSteerAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkNextMaxSteerAngle.BackColor = System.Drawing.Color.Transparent;
            this.btnOkNextMaxSteerAngle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOkNextMaxSteerAngle.FlatAppearance.BorderSize = 0;
            this.btnOkNextMaxSteerAngle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkNextMaxSteerAngle.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkNextMaxSteerAngle.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkNextMaxSteerAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkNextMaxSteerAngle.Location = new System.Drawing.Point(864, 366);
            this.btnOkNextMaxSteerAngle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkNextMaxSteerAngle.Name = "btnOkNextMaxSteerAngle";
            this.btnOkNextMaxSteerAngle.Size = new System.Drawing.Size(108, 108);
            this.btnOkNextMaxSteerAngle.TabIndex = 530;
            this.btnOkNextMaxSteerAngle.UseVisualStyleBackColor = false;
            this.btnOkNextMaxSteerAngle.Click += new System.EventHandler(this.btnOkNext_Click);
            // 
            // tabCancelGuidance
            // 
            this.tabCancelGuidance.BackColor = System.Drawing.Color.White;
            this.tabCancelGuidance.Controls.Add(this.btnPrev_CancelGuidance);
            this.tabCancelGuidance.Controls.Add(this.btnOkNextCancelGuidance);
            this.tabCancelGuidance.Controls.Add(this.label44);
            this.tabCancelGuidance.Controls.Add(this.labelEncoder);
            this.tabCancelGuidance.Controls.Add(this.labelCurrentTurnSensor);
            this.tabCancelGuidance.Controls.Add(this.labelPressureTurnSensor);
            this.tabCancelGuidance.Controls.Add(this.pbarSensor);
            this.tabCancelGuidance.Controls.Add(this.nudMaxCounts);
            this.tabCancelGuidance.Controls.Add(this.label61);
            this.tabCancelGuidance.Controls.Add(this.hsbarSensor);
            this.tabCancelGuidance.Controls.Add(this.lblPercentFS);
            this.tabCancelGuidance.Controls.Add(this.lblhsbarSensor);
            this.tabCancelGuidance.Controls.Add(this.cboxPressureSensor);
            this.tabCancelGuidance.Controls.Add(this.cboxEncoder);
            this.tabCancelGuidance.Controls.Add(this.cboxCurrentSensor);
            this.tabCancelGuidance.Location = new System.Drawing.Point(4, 19);
            this.tabCancelGuidance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCancelGuidance.Name = "tabCancelGuidance";
            this.tabCancelGuidance.Size = new System.Drawing.Size(986, 496);
            this.tabCancelGuidance.TabIndex = 20;
            this.tabCancelGuidance.Text = "CancelGuidance";
            // 
            // btnPrev_CancelGuidance
            // 
            this.btnPrev_CancelGuidance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev_CancelGuidance.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev_CancelGuidance.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnPrev_CancelGuidance.FlatAppearance.BorderSize = 0;
            this.btnPrev_CancelGuidance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev_CancelGuidance.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnPrev_CancelGuidance.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.btnPrev_CancelGuidance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrev_CancelGuidance.Location = new System.Drawing.Point(728, 366);
            this.btnPrev_CancelGuidance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev_CancelGuidance.Name = "btnPrev_CancelGuidance";
            this.btnPrev_CancelGuidance.Size = new System.Drawing.Size(108, 108);
            this.btnPrev_CancelGuidance.TabIndex = 536;
            this.btnPrev_CancelGuidance.UseVisualStyleBackColor = false;
            this.btnPrev_CancelGuidance.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnOkNextCancelGuidance
            // 
            this.btnOkNextCancelGuidance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkNextCancelGuidance.BackColor = System.Drawing.Color.Transparent;
            this.btnOkNextCancelGuidance.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnOkNextCancelGuidance.FlatAppearance.BorderSize = 0;
            this.btnOkNextCancelGuidance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkNextCancelGuidance.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkNextCancelGuidance.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkNextCancelGuidance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkNextCancelGuidance.Location = new System.Drawing.Point(864, 366);
            this.btnOkNextCancelGuidance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkNextCancelGuidance.Name = "btnOkNextCancelGuidance";
            this.btnOkNextCancelGuidance.Size = new System.Drawing.Size(108, 108);
            this.btnOkNextCancelGuidance.TabIndex = 533;
            this.btnOkNextCancelGuidance.UseVisualStyleBackColor = false;
            this.btnOkNextCancelGuidance.Click += new System.EventHandler(this.btnOkNextCancelGuidance_Click);
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(4, 8);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(836, 39);
            this.label44.TabIndex = 532;
            this.label44.Text = "Automatic Canceling Feature";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboxPressureSensor
            // 
            this.cboxPressureSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxPressureSensor.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxPressureSensor.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxPressureSensor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxPressureSensor.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxPressureSensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxPressureSensor.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxPressureSensor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxPressureSensor.Image = global::AgOpenGPS.Properties.Resources.ConSt_TurnSensorPressure;
            this.cboxPressureSensor.Location = new System.Drawing.Point(640, 128);
            this.cboxPressureSensor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboxPressureSensor.Name = "cboxPressureSensor";
            this.cboxPressureSensor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxPressureSensor.Size = new System.Drawing.Size(171, 117);
            this.cboxPressureSensor.TabIndex = 508;
            this.cboxPressureSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxPressureSensor.UseVisualStyleBackColor = false;
            this.cboxPressureSensor.Click += new System.EventHandler(this.cboxCancelGuidance_Click);
            // 
            // cboxEncoder
            // 
            this.cboxEncoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxEncoder.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxEncoder.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxEncoder.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxEncoder.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxEncoder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxEncoder.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxEncoder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxEncoder.Image = global::AgOpenGPS.Properties.Resources.ConSt_TurnSensor;
            this.cboxEncoder.Location = new System.Drawing.Point(194, 126);
            this.cboxEncoder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboxEncoder.Name = "cboxEncoder";
            this.cboxEncoder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxEncoder.Size = new System.Drawing.Size(171, 117);
            this.cboxEncoder.TabIndex = 492;
            this.cboxEncoder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxEncoder.UseVisualStyleBackColor = false;
            this.cboxEncoder.Click += new System.EventHandler(this.cboxCancelGuidance_Click);
            // 
            // cboxCurrentSensor
            // 
            this.cboxCurrentSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxCurrentSensor.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxCurrentSensor.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxCurrentSensor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxCurrentSensor.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxCurrentSensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxCurrentSensor.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxCurrentSensor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxCurrentSensor.Image = global::AgOpenGPS.Properties.Resources.ConSt_TurnSensorCurrent;
            this.cboxCurrentSensor.Location = new System.Drawing.Point(417, 126);
            this.cboxCurrentSensor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboxCurrentSensor.Name = "cboxCurrentSensor";
            this.cboxCurrentSensor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxCurrentSensor.Size = new System.Drawing.Size(171, 117);
            this.cboxCurrentSensor.TabIndex = 510;
            this.cboxCurrentSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxCurrentSensor.UseVisualStyleBackColor = false;
            this.cboxCurrentSensor.Click += new System.EventHandler(this.cboxCancelGuidance_Click);
            // 
            // tabPanicStop
            // 
            this.tabPanicStop.BackColor = System.Drawing.Color.White;
            this.tabPanicStop.Controls.Add(this.label82);
            this.tabPanicStop.Controls.Add(this.btnPrev_Panic);
            this.tabPanicStop.Controls.Add(this.label54);
            this.tabPanicStop.Controls.Add(this.nudPanicStopSpeed);
            this.tabPanicStop.Controls.Add(this.label16);
            this.tabPanicStop.Controls.Add(this.label31);
            this.tabPanicStop.Controls.Add(this.btnOkNext_PanicStop);
            this.tabPanicStop.Location = new System.Drawing.Point(4, 19);
            this.tabPanicStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPanicStop.Name = "tabPanicStop";
            this.tabPanicStop.Size = new System.Drawing.Size(986, 496);
            this.tabPanicStop.TabIndex = 30;
            this.tabPanicStop.Text = "PanicStop";
            // 
            // label82
            // 
            this.label82.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label82.BackColor = System.Drawing.Color.Transparent;
            this.label82.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.ForeColor = System.Drawing.Color.Black;
            this.label82.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label82.Location = new System.Drawing.Point(66, 124);
            this.label82.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(820, 44);
            this.label82.TabIndex = 536;
            this.label82.Text = "Kmh drop per fix update (3 works well)";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrev_Panic
            // 
            this.btnPrev_Panic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev_Panic.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev_Panic.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnPrev_Panic.FlatAppearance.BorderSize = 0;
            this.btnPrev_Panic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev_Panic.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnPrev_Panic.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.btnPrev_Panic.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrev_Panic.Location = new System.Drawing.Point(728, 366);
            this.btnPrev_Panic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev_Panic.Name = "btnPrev_Panic";
            this.btnPrev_Panic.Size = new System.Drawing.Size(108, 108);
            this.btnPrev_Panic.TabIndex = 535;
            this.btnPrev_Panic.UseVisualStyleBackColor = false;
            this.btnPrev_Panic.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.Color.Transparent;
            this.label54.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.Color.Black;
            this.label54.Location = new System.Drawing.Point(8, 8);
            this.label54.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(293, 39);
            this.label54.TabIndex = 534;
            this.label54.Text = "Panic Stop Speed";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOkNext_PanicStop
            // 
            this.btnOkNext_PanicStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOkNext_PanicStop.BackColor = System.Drawing.Color.Transparent;
            this.btnOkNext_PanicStop.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnOkNext_PanicStop.FlatAppearance.BorderSize = 0;
            this.btnOkNext_PanicStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkNext_PanicStop.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOkNext_PanicStop.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOkNext_PanicStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOkNext_PanicStop.Location = new System.Drawing.Point(864, 366);
            this.btnOkNext_PanicStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOkNext_PanicStop.Name = "btnOkNext_PanicStop";
            this.btnOkNext_PanicStop.Size = new System.Drawing.Size(108, 108);
            this.btnOkNext_PanicStop.TabIndex = 533;
            this.btnOkNext_PanicStop.UseVisualStyleBackColor = false;
            this.btnOkNext_PanicStop.Click += new System.EventHandler(this.btnOkNext_Click);
            // 
            // tab_MinimumGain
            // 
            this.tab_MinimumGain.BackColor = System.Drawing.Color.White;
            this.tab_MinimumGain.Controls.Add(this.label72);
            this.tab_MinimumGain.Controls.Add(this.label79);
            this.tab_MinimumGain.Controls.Add(this.label78);
            this.tab_MinimumGain.Controls.Add(this.btnMinGainLeft);
            this.tab_MinimumGain.Controls.Add(this.btnZeroMinMovementSetting);
            this.tab_MinimumGain.Controls.Add(this.label77);
            this.tab_MinimumGain.Controls.Add(this.label76);
            this.tab_MinimumGain.Controls.Add(this.btnMinGainRight);
            this.tab_MinimumGain.Controls.Add(this.label68);
            this.tab_MinimumGain.Controls.Add(this.label15);
            this.tab_MinimumGain.Controls.Add(this.btnPrev_Gain);
            this.tab_MinimumGain.Controls.Add(this.btnOK_Next);
            this.tab_MinimumGain.Controls.Add(this.hsbarMinPWM);
            this.tab_MinimumGain.Controls.Add(this.lblMinPWM);
            this.tab_MinimumGain.Location = new System.Drawing.Point(4, 19);
            this.tab_MinimumGain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tab_MinimumGain.Name = "tab_MinimumGain";
            this.tab_MinimumGain.Size = new System.Drawing.Size(986, 496);
            this.tab_MinimumGain.TabIndex = 34;
            this.tab_MinimumGain.Text = "MinGain";
            this.tab_MinimumGain.Enter += new System.EventHandler(this.tab_MinimumGain_Enter);
            this.tab_MinimumGain.Leave += new System.EventHandler(this.tab_MinimumGain_Leave);
            // 
            // label72
            // 
            this.label72.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label72.AutoSize = true;
            this.label72.BackColor = System.Drawing.Color.Transparent;
            this.label72.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label72.Location = new System.Drawing.Point(808, 46);
            this.label72.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(55, 24);
            this.label72.TabIndex = 549;
            this.label72.Text = "Zero";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label79
            // 
            this.label79.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label79.AutoSize = true;
            this.label79.BackColor = System.Drawing.Color.Transparent;
            this.label79.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label79.Location = new System.Drawing.Point(879, 303);
            this.label79.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(65, 24);
            this.label79.TabIndex = 548;
            this.label79.Text = "Right";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label78
            // 
            this.label78.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label78.AutoSize = true;
            this.label78.BackColor = System.Drawing.Color.Transparent;
            this.label78.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label78.Location = new System.Drawing.Point(736, 303);
            this.label78.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(49, 24);
            this.label78.TabIndex = 547;
            this.label78.Text = "Left";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnMinGainLeft
            // 
            this.btnMinGainLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMinGainLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnMinGainLeft.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnMinGainLeft.FlatAppearance.BorderSize = 0;
            this.btnMinGainLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinGainLeft.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMinGainLeft.Image = global::AgOpenGPS.Properties.Resources.SteerLeft;
            this.btnMinGainLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMinGainLeft.Location = new System.Drawing.Point(700, 198);
            this.btnMinGainLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMinGainLeft.Name = "btnMinGainLeft";
            this.btnMinGainLeft.Size = new System.Drawing.Size(114, 102);
            this.btnMinGainLeft.TabIndex = 546;
            this.btnMinGainLeft.UseVisualStyleBackColor = false;
            this.btnMinGainLeft.Click += new System.EventHandler(this.btnMinGainLeft_Click);
            // 
            // btnZeroMinMovementSetting
            // 
            this.btnZeroMinMovementSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZeroMinMovementSetting.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnZeroMinMovementSetting.FlatAppearance.BorderSize = 0;
            this.btnZeroMinMovementSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZeroMinMovementSetting.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroMinMovementSetting.ForeColor = System.Drawing.Color.White;
            this.btnZeroMinMovementSetting.Image = global::AgOpenGPS.Properties.Resources.AutoSteerOff;
            this.btnZeroMinMovementSetting.Location = new System.Drawing.Point(778, 69);
            this.btnZeroMinMovementSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnZeroMinMovementSetting.Name = "btnZeroMinMovementSetting";
            this.btnZeroMinMovementSetting.Size = new System.Drawing.Size(114, 100);
            this.btnZeroMinMovementSetting.TabIndex = 545;
            this.btnZeroMinMovementSetting.UseVisualStyleBackColor = true;
            this.btnZeroMinMovementSetting.Click += new System.EventHandler(this.btnZeroMinMovementSetting_Click);
            // 
            // label77
            // 
            this.label77.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label77.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.ForeColor = System.Drawing.Color.Black;
            this.label77.Location = new System.Drawing.Point(39, 142);
            this.label77.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(652, 124);
            this.label77.TabIndex = 544;
            this.label77.Text = "Use Left, Right and Zero to adjust Minumum Movement as high as possible without s" +
    "teer motor or hydraulics moving steering";
            this.label77.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label76
            // 
            this.label76.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label76.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.ForeColor = System.Drawing.Color.Black;
            this.label76.Location = new System.Drawing.Point(39, 81);
            this.label76.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(652, 50);
            this.label76.TabIndex = 543;
            this.label76.Text = "Drive slowly straight forward  ( WAS = 0 )";
            this.label76.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnMinGainRight
            // 
            this.btnMinGainRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMinGainRight.BackColor = System.Drawing.Color.Transparent;
            this.btnMinGainRight.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnMinGainRight.FlatAppearance.BorderSize = 0;
            this.btnMinGainRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinGainRight.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMinGainRight.Image = global::AgOpenGPS.Properties.Resources.SteerRight;
            this.btnMinGainRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMinGainRight.Location = new System.Drawing.Point(850, 198);
            this.btnMinGainRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMinGainRight.Name = "btnMinGainRight";
            this.btnMinGainRight.Size = new System.Drawing.Size(114, 102);
            this.btnMinGainRight.TabIndex = 542;
            this.btnMinGainRight.UseVisualStyleBackColor = false;
            this.btnMinGainRight.Click += new System.EventHandler(this.btnMinGainRight_Click);
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.BackColor = System.Drawing.Color.Transparent;
            this.label68.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.ForeColor = System.Drawing.Color.Black;
            this.label68.Location = new System.Drawing.Point(8, 8);
            this.label68.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(471, 39);
            this.label68.TabIndex = 538;
            this.label68.Text = "Minimum Movement Setting";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrev_Gain
            // 
            this.btnPrev_Gain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev_Gain.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev_Gain.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnPrev_Gain.FlatAppearance.BorderSize = 0;
            this.btnPrev_Gain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev_Gain.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnPrev_Gain.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.btnPrev_Gain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrev_Gain.Location = new System.Drawing.Point(728, 366);
            this.btnPrev_Gain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev_Gain.Name = "btnPrev_Gain";
            this.btnPrev_Gain.Size = new System.Drawing.Size(108, 108);
            this.btnPrev_Gain.TabIndex = 537;
            this.btnPrev_Gain.UseVisualStyleBackColor = false;
            this.btnPrev_Gain.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnOK_Next
            // 
            this.btnOK_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK_Next.BackColor = System.Drawing.Color.Transparent;
            this.btnOK_Next.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOK_Next.FlatAppearance.BorderSize = 0;
            this.btnOK_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK_Next.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOK_Next.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnOK_Next.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK_Next.Location = new System.Drawing.Point(864, 366);
            this.btnOK_Next.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK_Next.Name = "btnOK_Next";
            this.btnOK_Next.Size = new System.Drawing.Size(108, 108);
            this.btnOK_Next.TabIndex = 536;
            this.btnOK_Next.UseVisualStyleBackColor = false;
            this.btnOK_Next.Click += new System.EventHandler(this.btnOkNext_Click);
            // 
            // tabPGain
            // 
            this.tabPGain.BackColor = System.Drawing.Color.White;
            this.tabPGain.Controls.Add(this.label88);
            this.tabPGain.Controls.Add(this.label83);
            this.tabPGain.Controls.Add(this.label84);
            this.tabPGain.Controls.Add(this.label4);
            this.tabPGain.Controls.Add(this.btnLeftPGain);
            this.tabPGain.Controls.Add(this.btnZeroPGain);
            this.tabPGain.Controls.Add(this.label2);
            this.tabPGain.Controls.Add(this.label85);
            this.tabPGain.Controls.Add(this.label86);
            this.tabPGain.Controls.Add(this.btnRightPGain);
            this.tabPGain.Controls.Add(this.label87);
            this.tabPGain.Controls.Add(this.hsbarHighSteerPWM);
            this.tabPGain.Controls.Add(this.btnPrev_PGain);
            this.tabPGain.Controls.Add(this.btnNext_PGain);
            this.tabPGain.Controls.Add(this.hsbarProportionalGain);
            this.tabPGain.Controls.Add(this.lblProportionalGain);
            this.tabPGain.Controls.Add(this.lblHighSteerPWM);
            this.tabPGain.Location = new System.Drawing.Point(4, 19);
            this.tabPGain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPGain.Name = "tabPGain";
            this.tabPGain.Size = new System.Drawing.Size(986, 496);
            this.tabPGain.TabIndex = 36;
            this.tabPGain.Text = "PGain";
            this.tabPGain.Enter += new System.EventHandler(this.tabPGain_Enter);
            this.tabPGain.Leave += new System.EventHandler(this.tabPGain_Leave);
            // 
            // label88
            // 
            this.label88.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label88.AutoSize = true;
            this.label88.BackColor = System.Drawing.Color.Transparent;
            this.label88.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label88.Location = new System.Drawing.Point(879, 304);
            this.label88.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(65, 24);
            this.label88.TabIndex = 560;
            this.label88.Text = "Right";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label83
            // 
            this.label83.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label83.AutoSize = true;
            this.label83.BackColor = System.Drawing.Color.Transparent;
            this.label83.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label83.Location = new System.Drawing.Point(772, 52);
            this.label83.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(117, 24);
            this.label83.TabIndex = 559;
            this.label83.Text = "Zero or +5";
            this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label84
            // 
            this.label84.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label84.AutoSize = true;
            this.label84.BackColor = System.Drawing.Color.Transparent;
            this.label84.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label84.Location = new System.Drawing.Point(738, 304);
            this.label84.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(49, 24);
            this.label84.TabIndex = 558;
            this.label84.Text = "Left";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLeftPGain
            // 
            this.btnLeftPGain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLeftPGain.BackColor = System.Drawing.Color.Transparent;
            this.btnLeftPGain.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnLeftPGain.FlatAppearance.BorderSize = 0;
            this.btnLeftPGain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeftPGain.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnLeftPGain.Image = global::AgOpenGPS.Properties.Resources.SteerLeft;
            this.btnLeftPGain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLeftPGain.Location = new System.Drawing.Point(702, 200);
            this.btnLeftPGain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLeftPGain.Name = "btnLeftPGain";
            this.btnLeftPGain.Size = new System.Drawing.Size(114, 102);
            this.btnLeftPGain.TabIndex = 557;
            this.btnLeftPGain.UseVisualStyleBackColor = false;
            this.btnLeftPGain.Click += new System.EventHandler(this.btnLeftPGain_Click);
            // 
            // btnZeroPGain
            // 
            this.btnZeroPGain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZeroPGain.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnZeroPGain.FlatAppearance.BorderSize = 0;
            this.btnZeroPGain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZeroPGain.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroPGain.ForeColor = System.Drawing.Color.White;
            this.btnZeroPGain.Image = global::AgOpenGPS.Properties.Resources.SteerZeroSmall;
            this.btnZeroPGain.Location = new System.Drawing.Point(780, 70);
            this.btnZeroPGain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnZeroPGain.Name = "btnZeroPGain";
            this.btnZeroPGain.Size = new System.Drawing.Size(114, 100);
            this.btnZeroPGain.TabIndex = 556;
            this.btnZeroPGain.UseVisualStyleBackColor = true;
            this.btnZeroPGain.Click += new System.EventHandler(this.btnZeroPGain_Click);
            // 
            // label85
            // 
            this.label85.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label85.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label85.ForeColor = System.Drawing.Color.Black;
            this.label85.Location = new System.Drawing.Point(40, 118);
            this.label85.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(652, 100);
            this.label85.TabIndex = 555;
            this.label85.Text = "Adjust Proportional for good response and Maximum to limit turning speed";
            this.label85.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label86
            // 
            this.label86.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label86.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.ForeColor = System.Drawing.Color.Black;
            this.label86.Location = new System.Drawing.Point(40, 58);
            this.label86.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(652, 50);
            this.label86.TabIndex = 554;
            this.label86.Text = "Drive slowly straight forward  ( WAS = 0 )";
            this.label86.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnRightPGain
            // 
            this.btnRightPGain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRightPGain.BackColor = System.Drawing.Color.Transparent;
            this.btnRightPGain.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnRightPGain.FlatAppearance.BorderSize = 0;
            this.btnRightPGain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRightPGain.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnRightPGain.Image = global::AgOpenGPS.Properties.Resources.SteerRight;
            this.btnRightPGain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRightPGain.Location = new System.Drawing.Point(852, 200);
            this.btnRightPGain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRightPGain.Name = "btnRightPGain";
            this.btnRightPGain.Size = new System.Drawing.Size(114, 102);
            this.btnRightPGain.TabIndex = 553;
            this.btnRightPGain.UseVisualStyleBackColor = false;
            this.btnRightPGain.Click += new System.EventHandler(this.btnRightPGain_Click);
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.BackColor = System.Drawing.Color.Transparent;
            this.label87.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.ForeColor = System.Drawing.Color.Black;
            this.label87.Location = new System.Drawing.Point(9, 9);
            this.label87.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(214, 39);
            this.label87.TabIndex = 552;
            this.label87.Text = "Gain Setting";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrev_PGain
            // 
            this.btnPrev_PGain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev_PGain.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev_PGain.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnPrev_PGain.FlatAppearance.BorderSize = 0;
            this.btnPrev_PGain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev_PGain.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnPrev_PGain.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.btnPrev_PGain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrev_PGain.Location = new System.Drawing.Point(729, 368);
            this.btnPrev_PGain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev_PGain.Name = "btnPrev_PGain";
            this.btnPrev_PGain.Size = new System.Drawing.Size(108, 108);
            this.btnPrev_PGain.TabIndex = 551;
            this.btnPrev_PGain.UseVisualStyleBackColor = false;
            this.btnPrev_PGain.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext_PGain
            // 
            this.btnNext_PGain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext_PGain.BackColor = System.Drawing.Color.Transparent;
            this.btnNext_PGain.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNext_PGain.FlatAppearance.BorderSize = 0;
            this.btnNext_PGain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext_PGain.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnNext_PGain.Image = global::AgOpenGPS.Properties.Resources.Next;
            this.btnNext_PGain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNext_PGain.Location = new System.Drawing.Point(866, 368);
            this.btnNext_PGain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNext_PGain.Name = "btnNext_PGain";
            this.btnNext_PGain.Size = new System.Drawing.Size(108, 108);
            this.btnNext_PGain.TabIndex = 550;
            this.btnNext_PGain.UseVisualStyleBackColor = false;
            this.btnNext_PGain.Click += new System.EventHandler(this.btnOkNext_Click);
            // 
            // tabEnd
            // 
            this.tabEnd.BackColor = System.Drawing.Color.White;
            this.tabEnd.Controls.Add(this.btnRestartWizard);
            this.tabEnd.Controls.Add(this.label69);
            this.tabEnd.Controls.Add(this.btnPrev_End);
            this.tabEnd.Controls.Add(this.btnExit);
            this.tabEnd.Location = new System.Drawing.Point(4, 19);
            this.tabEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabEnd.Name = "tabEnd";
            this.tabEnd.Size = new System.Drawing.Size(986, 496);
            this.tabEnd.TabIndex = 32;
            this.tabEnd.Text = "End";
            // 
            // btnRestartWizard
            // 
            this.btnRestartWizard.BackColor = System.Drawing.Color.LightBlue;
            this.btnRestartWizard.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnRestartWizard.FlatAppearance.BorderSize = 0;
            this.btnRestartWizard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestartWizard.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnRestartWizard.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRestartWizard.Location = new System.Drawing.Point(333, 246);
            this.btnRestartWizard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRestartWizard.Name = "btnRestartWizard";
            this.btnRestartWizard.Size = new System.Drawing.Size(267, 50);
            this.btnRestartWizard.TabIndex = 533;
            this.btnRestartWizard.Text = "Restart Wizard";
            this.btnRestartWizard.UseVisualStyleBackColor = false;
            this.btnRestartWizard.Click += new System.EventHandler(this.btnRestartWizard_Click);
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.BackColor = System.Drawing.Color.Transparent;
            this.label69.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.Color.Black;
            this.label69.Location = new System.Drawing.Point(387, 117);
            this.label69.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(171, 39);
            this.label69.TabIndex = 537;
            this.label69.Text = "Finished !";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrev_End
            // 
            this.btnPrev_End.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev_End.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev_End.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnPrev_End.FlatAppearance.BorderSize = 0;
            this.btnPrev_End.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev_End.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnPrev_End.Image = global::AgOpenGPS.Properties.Resources.Previous;
            this.btnPrev_End.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrev_End.Location = new System.Drawing.Point(676, 369);
            this.btnPrev_End.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrev_End.Name = "btnPrev_End";
            this.btnPrev_End.Size = new System.Drawing.Size(108, 108);
            this.btnPrev_End.TabIndex = 536;
            this.btnPrev_End.UseVisualStyleBackColor = false;
            this.btnPrev_End.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnExit.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExit.Location = new System.Drawing.Point(819, 369);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(156, 108);
            this.btnExit.TabIndex = 530;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStopWizard
            // 
            this.btnStopWizard.BackColor = System.Drawing.Color.LightCoral;
            this.btnStopWizard.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnStopWizard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopWizard.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnStopWizard.Image = global::AgOpenGPS.Properties.Resources.HelpCancel;
            this.btnStopWizard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStopWizard.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStopWizard.Location = new System.Drawing.Point(27, 10);
            this.btnStopWizard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStopWizard.Name = "btnStopWizard";
            this.btnStopWizard.Size = new System.Drawing.Size(252, 57);
            this.btnStopWizard.TabIndex = 527;
            this.btnStopWizard.Text = "Stop Wizard";
            this.btnStopWizard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopWizard.UseVisualStyleBackColor = false;
            this.btnStopWizard.Click += new System.EventHandler(this.btnStopWizard_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tabWiz);
            this.panel3.Location = new System.Drawing.Point(8, 76);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(996, 521);
            this.panel3.TabIndex = 531;
            // 
            // pbarProgress
            // 
            this.pbarProgress.Location = new System.Drawing.Point(504, 27);
            this.pbarProgress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbarProgress.Name = "pbarProgress";
            this.pbarProgress.Size = new System.Drawing.Size(484, 22);
            this.pbarProgress.Step = 1;
            this.pbarProgress.TabIndex = 532;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.BackColor = System.Drawing.Color.Transparent;
            this.label71.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.Color.Black;
            this.label71.Location = new System.Drawing.Point(352, 18);
            this.label71.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(154, 35);
            this.label71.TabIndex = 532;
            this.label71.Text = "Progress:";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBarCPD
            // 
            this.lblBarCPD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBarCPD.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarCPD.ForeColor = System.Drawing.Color.Black;
            this.lblBarCPD.Location = new System.Drawing.Point(1101, 172);
            this.lblBarCPD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarCPD.Name = "lblBarCPD";
            this.lblBarCPD.Size = new System.Drawing.Size(87, 52);
            this.lblBarCPD.TabIndex = 534;
            this.lblBarCPD.Text = "888";
            this.lblBarCPD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label66
            // 
            this.label66.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label66.AutoSize = true;
            this.label66.BackColor = System.Drawing.Color.Transparent;
            this.label66.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label66.Location = new System.Drawing.Point(1028, 183);
            this.label66.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(78, 35);
            this.label66.TabIndex = 535;
            this.label66.Text = "CPD:";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label65
            // 
            this.label65.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label65.AutoSize = true;
            this.label65.BackColor = System.Drawing.Color.Transparent;
            this.label65.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label65.Location = new System.Drawing.Point(1035, 232);
            this.label65.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(69, 35);
            this.label65.TabIndex = 537;
            this.label65.Text = "Ack:";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBarAck
            // 
            this.lblBarAck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBarAck.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarAck.ForeColor = System.Drawing.Color.Black;
            this.lblBarAck.Location = new System.Drawing.Point(1101, 225);
            this.lblBarAck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarAck.Name = "lblBarAck";
            this.lblBarAck.Size = new System.Drawing.Size(87, 52);
            this.lblBarAck.TabIndex = 536;
            this.lblBarAck.Text = "888";
            this.lblBarAck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sideBarTimer
            // 
            this.sideBarTimer.Enabled = true;
            this.sideBarTimer.Interval = 1000;
            this.sideBarTimer.Tick += new System.EventHandler(this.sideBarTimer_Tick);
            // 
            // label67
            // 
            this.label67.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label67.AutoSize = true;
            this.label67.BackColor = System.Drawing.Color.Transparent;
            this.label67.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label67.Location = new System.Drawing.Point(1005, 126);
            this.label67.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(102, 35);
            this.label67.TabIndex = 539;
            this.label67.Text = "Offset:";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBarWasOffset
            // 
            this.lblBarWasOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBarWasOffset.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarWasOffset.ForeColor = System.Drawing.Color.Black;
            this.lblBarWasOffset.Location = new System.Drawing.Point(1101, 120);
            this.lblBarWasOffset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarWasOffset.Name = "lblBarWasOffset";
            this.lblBarWasOffset.Size = new System.Drawing.Size(87, 52);
            this.lblBarWasOffset.TabIndex = 538;
            this.lblBarWasOffset.Text = "888";
            this.lblBarWasOffset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCloseAll.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseAll.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseAll.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCloseAll.FlatAppearance.BorderSize = 0;
            this.btnCloseAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseAll.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCloseAll.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnCloseAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCloseAll.Location = new System.Drawing.Point(1032, 718);
            this.btnCloseAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(156, 108);
            this.btnCloseAll.TabIndex = 540;
            this.btnCloseAll.UseVisualStyleBackColor = false;
            this.btnCloseAll.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormSteerWiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1196, 837);
            this.Controls.Add(this.btnCloseAll);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.lblBarWasOffset);
            this.Controls.Add(this.label65);
            this.Controls.Add(this.lblBarAck);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.lblBarCPD);
            this.Controls.Add(this.label71);
            this.Controls.Add(this.pbarProgress);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnStopWizard);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.Name = "FormSteerWiz";
            this.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auto Steer Wizard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSteer_FormClosing);
            this.Load += new System.EventHandler(this.FormSteer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSteer.ResumeLayout(false);
            this.tabSteer.PerformLayout();
            this.tabStan.ResumeLayout(false);
            this.tabInt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCounts)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPanicStopSpeed)).EndInit();
            this.tabWiz.ResumeLayout(false);
            this.tabStart.ResumeLayout(false);
            this.tabLoadDef.ResumeLayout(false);
            this.tabLoadDef.PerformLayout();
            this.tabButtonSwitch.ResumeLayout(false);
            this.tabButtonSwitch.PerformLayout();
            this.tabA2DConv.ResumeLayout(false);
            this.tabA2DConv.PerformLayout();
            this.tabMotorDriver.ResumeLayout(false);
            this.tabMotorDriver.PerformLayout();
            this.tabInvertRelays.ResumeLayout(false);
            this.tabInvertRelays.PerformLayout();
            this.tabDanfoss.ResumeLayout(false);
            this.tabDanfoss.PerformLayout();
            this.tabWAS.ResumeLayout(false);
            this.tabWAS.PerformLayout();
            this.tabMotorDirection.ResumeLayout(false);
            this.tabMotorDirection.PerformLayout();
            this.tabCPD_Setup.ResumeLayout(false);
            this.tabCPD_Setup.PerformLayout();
            this.tabWAS_Zero.ResumeLayout(false);
            this.tabWAS_Zero.PerformLayout();
            this.tabCountsPerDeg.ResumeLayout(false);
            this.tabCountsPerDeg.PerformLayout();
            this.tabAckermannRight.ResumeLayout(false);
            this.tabAckermannRight.PerformLayout();
            this.tabAckermannLeft.ResumeLayout(false);
            this.tabAckermannLeft.PerformLayout();
            this.tabAckermannCalc.ResumeLayout(false);
            this.tabAckermannCalc.PerformLayout();
            this.tabMaxSteerAngle.ResumeLayout(false);
            this.tabMaxSteerAngle.PerformLayout();
            this.tabCancelGuidance.ResumeLayout(false);
            this.tabCancelGuidance.PerformLayout();
            this.tabPanicStop.ResumeLayout(false);
            this.tabPanicStop.PerformLayout();
            this.tab_MinimumGain.ResumeLayout(false);
            this.tab_MinimumGain.PerformLayout();
            this.tabPGain.ResumeLayout(false);
            this.tabPGain.PerformLayout();
            this.tabEnd.ResumeLayout(false);
            this.tabEnd.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFreeDrive;
        private System.Windows.Forms.Label lblHighSteerPWM;
        private System.Windows.Forms.HScrollBar hsbarHighSteerPWM;
        private System.Windows.Forms.Label lblLowSteerPWM;
        private System.Windows.Forms.HScrollBar hsbarLowSteerPWM;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tabSteer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.HScrollBar hsbarAckerman;
        private System.Windows.Forms.Label lblAckerman;
        private System.Windows.Forms.ProgressBar pbarRight;
        private System.Windows.Forms.ProgressBar pbarLeft;
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
        private System.Windows.Forms.CheckBox cboxDanfoss;
        private System.Windows.Forms.CheckBox chkSteerInvertRelays;
        private System.Windows.Forms.CheckBox chkInvertSteer;
        private System.Windows.Forms.CheckBox cboxEncoder;
        private System.Windows.Forms.CheckBox chkInvertWAS;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.HScrollBar hsbarSensor;
        private System.Windows.Forms.Label lblhsbarSensor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nudPanicStopSpeed;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TabControl tabWiz;
        private System.Windows.Forms.TabPage tabStart;
        private System.Windows.Forms.TabPage tabMotorDriver;
        private System.Windows.Forms.TabPage tabMotorDirection;
        private System.Windows.Forms.Button btnSteerLeft;
        private System.Windows.Forms.Button btnSteerRight;
        private System.Windows.Forms.TabPage tabWAS;
        private System.Windows.Forms.TabPage tabButtonSwitch;
        private System.Windows.Forms.Button btnStartWizard;
        private System.Windows.Forms.Button btnStopWizard;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TabPage tabCancelGuidance;
        private System.Windows.Forms.TabPage tabWAS_Zero;
        private System.Windows.Forms.TabPage tabCountsPerDeg;
        private System.Windows.Forms.TabPage tabAckermannLeft;
        private System.Windows.Forms.Button btnOkWAS;
        private System.Windows.Forms.Button btnOkNext_MotorDriver;
        private System.Windows.Forms.Button btnOkNext_MotorDirection;
        private System.Windows.Forms.Button btnOkNext_WAS_Zero;
        private System.Windows.Forms.Button btnOkNext_CountsPerDeg;
        private System.Windows.Forms.TabPage tabAckermannRight;
        private System.Windows.Forms.Button btnOkLockRightCalc;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOkLockLeftCalc;
        private System.Windows.Forms.TabPage tabAckermannCalc;
        private System.Windows.Forms.Button btnOkNext_AckermannCalc;
        private System.Windows.Forms.Button btnOkNext_ButtonSwitch;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TabPage tabMaxSteerAngle;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnOkNextMaxSteerAngle;
        private System.Windows.Forms.TabPage tabA2DConv;
        private System.Windows.Forms.Button btnOkNext_A2D;
        private System.Windows.Forms.TabPage tabInvertRelays;
        private System.Windows.Forms.TabPage tabDanfoss;
        private System.Windows.Forms.Button btnOkNext_InvertRelays;
        private System.Windows.Forms.Button btnOkNext_Danfoss;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Button btnOkNextCancelGuidance;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Button btnSteerStatus;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabPage tabPanicStop;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Button btnOkNext_PanicStop;
        private System.Windows.Forms.Label lblAckLeft;
        private System.Windows.Forms.Label lblAckRight;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Button btnPrev_A2D;
        private System.Windows.Forms.Button btnPrev_MotorDriver;
        private System.Windows.Forms.Button btnPrev_InvertRelays;
        private System.Windows.Forms.Button btnPrev_Danfoss;
        private System.Windows.Forms.Button btnPrev_InvertWAS;
        private System.Windows.Forms.Button btnPrev_MotorDirection;
        private System.Windows.Forms.Button btnPrev_CountsPerDegree;
        private System.Windows.Forms.Button btnPrev_MaxSteerAngle;
        private System.Windows.Forms.Button btnPrev_CancelGuidance;
        private System.Windows.Forms.Button btnPrev_Panic;
        private System.Windows.Forms.TabPage tabEnd;
        private System.Windows.Forms.Button btnPrev_End;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.ProgressBar pbarProgress;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TabPage tabCPD_Setup;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Button btnSkipCPD_Setup;
        private System.Windows.Forms.Button btnOKNext_CPDSetup;
        private System.Windows.Forms.Button btnRestartWizard;
        private System.Windows.Forms.Button btnRemoveWasOffset;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Button btnLoadDefaults;
        private System.Windows.Forms.Label lblBarCPD;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label lblBarAck;
        private System.Windows.Forms.Timer sideBarTimer;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label lblBarWasOffset;
        private System.Windows.Forms.Label lblAckError;
        private System.Windows.Forms.Label lblCPDError;
        private System.Windows.Forms.Button btnCloseAll;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnPrev_AckermannCalc;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TabPage tab_MinimumGain;
        private System.Windows.Forms.Button btnPrev_Gain;
        private System.Windows.Forms.Button btnOK_Next;
        private System.Windows.Forms.Button btnMinGainRight;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Button btnOkSetMaximumSteerAngle;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Button btnZeroMinMovementSetting;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Button btnMinGainLeft;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TabPage tabLoadDef;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Button btnOkNext_LoadDefault;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.TabPage tabPGain;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Button btnLeftPGain;
        private System.Windows.Forms.Button btnZeroPGain;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Button btnRightPGain;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Button btnPrev_PGain;
        private System.Windows.Forms.Button btnNext_PGain;
    }
}