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
            this.btnFreeDrive = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGain = new System.Windows.Forms.TabPage();
            this.hsbarHighSteerPWM = new System.Windows.Forms.HScrollBar();
            this.hsbarMinPWM = new System.Windows.Forms.HScrollBar();
            this.hsbarProportionalGain = new System.Windows.Forms.HScrollBar();
            this.label45 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.hsbarLowSteerPWM = new System.Windows.Forms.HScrollBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lblMinPWM = new System.Windows.Forms.Label();
            this.lblHighSteerPWM = new System.Windows.Forms.Label();
            this.lblLowSteerPWM = new System.Windows.Forms.Label();
            this.lblProportionalGain = new System.Windows.Forms.Label();
            this.tabSteer = new System.Windows.Forms.TabPage();
            this.hsbarSidehillDraftGain = new System.Windows.Forms.HScrollBar();
            this.label25 = new System.Windows.Forms.Label();
            this.hsbarCountsPerDegree = new System.Windows.Forms.HScrollBar();
            this.label29 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.hsbarMaxSteerAngle = new System.Windows.Forms.HScrollBar();
            this.label10 = new System.Windows.Forms.Label();
            this.hsbarSteerAngleSensorZero = new System.Windows.Forms.HScrollBar();
            this.lblCountsPerDegree = new System.Windows.Forms.Label();
            this.lblMaxSteerAngle = new System.Windows.Forms.Label();
            this.lblSidehillDraftGain = new System.Windows.Forms.Label();
            this.lblSteerAngleSensorZero = new System.Windows.Forms.Label();
            this.tabLook = new System.Windows.Forms.TabPage();
            this.hsbarLookAheadUturnMult = new System.Windows.Forms.HScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.hsbarLookAheadMin = new System.Windows.Forms.HScrollBar();
            this.hsbarDistanceFromLine = new System.Windows.Forms.HScrollBar();
            this.hsbarLookAhead = new System.Windows.Forms.HScrollBar();
            this.label37 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLookAheadUturnMult = new System.Windows.Forms.Label();
            this.lblLookAhead = new System.Windows.Forms.Label();
            this.lblLookAheadMinimum = new System.Windows.Forms.Label();
            this.lblDistanceFromLine = new System.Windows.Forms.Label();
            this.tabStan = new System.Windows.Forms.TabPage();
            this.btnStanley = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hsbarHeadingErrorGain = new System.Windows.Forms.HScrollBar();
            this.btnChart = new System.Windows.Forms.Button();
            this.lblStanleyGain = new System.Windows.Forms.Label();
            this.hsbarStanleyGain = new System.Windows.Forms.HScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblHeadingErrorGain = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblSteerAngle = new System.Windows.Forms.Label();
            this.lblRecd = new System.Windows.Forms.Label();
            this.lblSent = new System.Windows.Forms.Label();
            this.lblSteerAngleActual = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnFreeDriveZero = new System.Windows.Forms.Button();
            this.btnSteerAngleDown = new ProXoft.WinForms.RepeatButton();
            this.btnSteerAngleUp = new ProXoft.WinForms.RepeatButton();
            this.lblPWMDisplay = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabGain.SuspendLayout();
            this.tabSteer.SuspendLayout();
            this.tabLook.SuspendLayout();
            this.tabStan.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFreeDrive
            // 
            this.btnFreeDrive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreeDrive.Location = new System.Drawing.Point(3, 350);
            this.btnFreeDrive.Name = "btnFreeDrive";
            this.btnFreeDrive.Size = new System.Drawing.Size(81, 44);
            this.btnFreeDrive.TabIndex = 228;
            this.btnFreeDrive.Text = "Drive";
            this.btnFreeDrive.UseVisualStyleBackColor = true;
            this.btnFreeDrive.Click += new System.EventHandler(this.btnFreeDrive_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabGain);
            this.tabControl1.Controls.Add(this.tabSteer);
            this.tabControl1.Controls.Add(this.tabLook);
            this.tabControl1.Controls.Add(this.tabStan);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(92, 44);
            this.tabControl1.Location = new System.Drawing.Point(2, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 319);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 232;
            // 
            // tabGain
            // 
            this.tabGain.AutoScroll = true;
            this.tabGain.BackColor = System.Drawing.Color.PowderBlue;
            this.tabGain.Controls.Add(this.hsbarHighSteerPWM);
            this.tabGain.Controls.Add(this.hsbarMinPWM);
            this.tabGain.Controls.Add(this.hsbarProportionalGain);
            this.tabGain.Controls.Add(this.label45);
            this.tabGain.Controls.Add(this.label41);
            this.tabGain.Controls.Add(this.hsbarLowSteerPWM);
            this.tabGain.Controls.Add(this.label7);
            this.tabGain.Controls.Add(this.label33);
            this.tabGain.Controls.Add(this.lblMinPWM);
            this.tabGain.Controls.Add(this.lblHighSteerPWM);
            this.tabGain.Controls.Add(this.lblLowSteerPWM);
            this.tabGain.Controls.Add(this.lblProportionalGain);
            this.tabGain.Location = new System.Drawing.Point(4, 48);
            this.tabGain.Name = "tabGain";
            this.tabGain.Size = new System.Drawing.Size(376, 267);
            this.tabGain.TabIndex = 13;
            this.tabGain.Text = "Gain";
            // 
            // hsbarHighSteerPWM
            // 
            this.hsbarHighSteerPWM.LargeChange = 2;
            this.hsbarHighSteerPWM.Location = new System.Drawing.Point(12, 163);
            this.hsbarHighSteerPWM.Maximum = 255;
            this.hsbarHighSteerPWM.Minimum = 1;
            this.hsbarHighSteerPWM.Name = "hsbarHighSteerPWM";
            this.hsbarHighSteerPWM.Size = new System.Drawing.Size(260, 30);
            this.hsbarHighSteerPWM.TabIndex = 274;
            this.hsbarHighSteerPWM.Value = 50;
            this.hsbarHighSteerPWM.ValueChanged += new System.EventHandler(this.hsbarHighSteerPWM_ValueChanged);
            // 
            // hsbarMinPWM
            // 
            this.hsbarMinPWM.LargeChange = 1;
            this.hsbarMinPWM.Location = new System.Drawing.Point(14, 97);
            this.hsbarMinPWM.Name = "hsbarMinPWM";
            this.hsbarMinPWM.Size = new System.Drawing.Size(260, 30);
            this.hsbarMinPWM.TabIndex = 284;
            this.hsbarMinPWM.Value = 10;
            this.hsbarMinPWM.ValueChanged += new System.EventHandler(this.hsbarMinPWM_ValueChanged);
            // 
            // hsbarProportionalGain
            // 
            this.hsbarProportionalGain.LargeChange = 1;
            this.hsbarProportionalGain.Location = new System.Drawing.Point(12, 32);
            this.hsbarProportionalGain.Maximum = 200;
            this.hsbarProportionalGain.Name = "hsbarProportionalGain";
            this.hsbarProportionalGain.Size = new System.Drawing.Size(260, 30);
            this.hsbarProportionalGain.TabIndex = 254;
            this.hsbarProportionalGain.Value = 4;
            this.hsbarProportionalGain.ValueChanged += new System.EventHandler(this.hsbarProportionalGain_ValueChanged);
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(13, 139);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(251, 23);
            this.label45.TabIndex = 275;
            this.label45.Text = "High Max PWM";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(17, 71);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(247, 23);
            this.label41.TabIndex = 285;
            this.label41.Text = "Minimum PWM Drive";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarLowSteerPWM
            // 
            this.hsbarLowSteerPWM.LargeChange = 1;
            this.hsbarLowSteerPWM.Location = new System.Drawing.Point(14, 229);
            this.hsbarLowSteerPWM.Maximum = 255;
            this.hsbarLowSteerPWM.Minimum = 1;
            this.hsbarLowSteerPWM.Name = "hsbarLowSteerPWM";
            this.hsbarLowSteerPWM.Size = new System.Drawing.Size(260, 30);
            this.hsbarLowSteerPWM.TabIndex = 269;
            this.hsbarLowSteerPWM.Value = 1;
            this.hsbarLowSteerPWM.ValueChanged += new System.EventHandler(this.hsbarLowSteerPWM_ValueChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(249, 23);
            this.label7.TabIndex = 255;
            this.label7.Text = "Proportional Gain";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(12, 205);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(254, 23);
            this.label33.TabIndex = 270;
            this.label33.Text = "Low Max PWM";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinPWM
            // 
            this.lblMinPWM.AutoSize = true;
            this.lblMinPWM.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinPWM.Location = new System.Drawing.Point(279, 91);
            this.lblMinPWM.Name = "lblMinPWM";
            this.lblMinPWM.Size = new System.Drawing.Size(91, 39);
            this.lblMinPWM.TabIndex = 288;
            this.lblMinPWM.Text = "-888";
            // 
            // lblHighSteerPWM
            // 
            this.lblHighSteerPWM.AutoSize = true;
            this.lblHighSteerPWM.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighSteerPWM.Location = new System.Drawing.Point(279, 157);
            this.lblHighSteerPWM.Name = "lblHighSteerPWM";
            this.lblHighSteerPWM.Size = new System.Drawing.Size(91, 39);
            this.lblHighSteerPWM.TabIndex = 278;
            this.lblHighSteerPWM.Text = "-888";
            // 
            // lblLowSteerPWM
            // 
            this.lblLowSteerPWM.AutoSize = true;
            this.lblLowSteerPWM.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowSteerPWM.Location = new System.Drawing.Point(279, 223);
            this.lblLowSteerPWM.Name = "lblLowSteerPWM";
            this.lblLowSteerPWM.Size = new System.Drawing.Size(91, 39);
            this.lblLowSteerPWM.TabIndex = 273;
            this.lblLowSteerPWM.Text = "-888";
            // 
            // lblProportionalGain
            // 
            this.lblProportionalGain.AutoSize = true;
            this.lblProportionalGain.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProportionalGain.Location = new System.Drawing.Point(279, 25);
            this.lblProportionalGain.Name = "lblProportionalGain";
            this.lblProportionalGain.Size = new System.Drawing.Size(91, 39);
            this.lblProportionalGain.TabIndex = 258;
            this.lblProportionalGain.Text = "-888";
            // 
            // tabSteer
            // 
            this.tabSteer.AutoScroll = true;
            this.tabSteer.BackColor = System.Drawing.Color.PowderBlue;
            this.tabSteer.Controls.Add(this.hsbarSidehillDraftGain);
            this.tabSteer.Controls.Add(this.label25);
            this.tabSteer.Controls.Add(this.hsbarCountsPerDegree);
            this.tabSteer.Controls.Add(this.label29);
            this.tabSteer.Controls.Add(this.label19);
            this.tabSteer.Controls.Add(this.hsbarMaxSteerAngle);
            this.tabSteer.Controls.Add(this.label10);
            this.tabSteer.Controls.Add(this.hsbarSteerAngleSensorZero);
            this.tabSteer.Controls.Add(this.lblCountsPerDegree);
            this.tabSteer.Controls.Add(this.lblMaxSteerAngle);
            this.tabSteer.Controls.Add(this.lblSidehillDraftGain);
            this.tabSteer.Controls.Add(this.lblSteerAngleSensorZero);
            this.tabSteer.Location = new System.Drawing.Point(4, 48);
            this.tabSteer.Name = "tabSteer";
            this.tabSteer.Size = new System.Drawing.Size(376, 267);
            this.tabSteer.TabIndex = 5;
            this.tabSteer.Text = "Steer";
            // 
            // hsbarSidehillDraftGain
            // 
            this.hsbarSidehillDraftGain.LargeChange = 1;
            this.hsbarSidehillDraftGain.Location = new System.Drawing.Point(10, 231);
            this.hsbarSidehillDraftGain.Maximum = 24;
            this.hsbarSidehillDraftGain.Name = "hsbarSidehillDraftGain";
            this.hsbarSidehillDraftGain.Size = new System.Drawing.Size(260, 30);
            this.hsbarSidehillDraftGain.TabIndex = 264;
            this.hsbarSidehillDraftGain.Value = 2;
            this.hsbarSidehillDraftGain.ValueChanged += new System.EventHandler(this.hsbarSidehillDraftGain_ValueChanged);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(10, 71);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(253, 23);
            this.label25.TabIndex = 305;
            this.label25.Text = "Counts per Degree";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarCountsPerDegree
            // 
            this.hsbarCountsPerDegree.LargeChange = 1;
            this.hsbarCountsPerDegree.Location = new System.Drawing.Point(10, 96);
            this.hsbarCountsPerDegree.Maximum = 255;
            this.hsbarCountsPerDegree.Minimum = 1;
            this.hsbarCountsPerDegree.Name = "hsbarCountsPerDegree";
            this.hsbarCountsPerDegree.Size = new System.Drawing.Size(260, 30);
            this.hsbarCountsPerDegree.TabIndex = 304;
            this.hsbarCountsPerDegree.Value = 20;
            this.hsbarCountsPerDegree.ValueChanged += new System.EventHandler(this.hsbarCountsPerDegree_ValueChanged);
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(12, 206);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(253, 23);
            this.label29.TabIndex = 265;
            this.label29.Text = "Sidehill Draft Gain";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(10, 139);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(253, 23);
            this.label19.TabIndex = 300;
            this.label19.Text = "Max Steer Angle in Degrees";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarMaxSteerAngle
            // 
            this.hsbarMaxSteerAngle.LargeChange = 1;
            this.hsbarMaxSteerAngle.Location = new System.Drawing.Point(10, 164);
            this.hsbarMaxSteerAngle.Maximum = 80;
            this.hsbarMaxSteerAngle.Minimum = 10;
            this.hsbarMaxSteerAngle.Name = "hsbarMaxSteerAngle";
            this.hsbarMaxSteerAngle.Size = new System.Drawing.Size(260, 30);
            this.hsbarMaxSteerAngle.TabIndex = 299;
            this.hsbarMaxSteerAngle.Value = 10;
            this.hsbarMaxSteerAngle.ValueChanged += new System.EventHandler(this.hsbarMaxSteerAngle_ValueChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(253, 23);
            this.label10.TabIndex = 295;
            this.label10.Text = "Wheel Angle Sensor Zero";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarSteerAngleSensorZero
            // 
            this.hsbarSteerAngleSensorZero.LargeChange = 1;
            this.hsbarSteerAngleSensorZero.Location = new System.Drawing.Point(10, 30);
            this.hsbarSteerAngleSensorZero.Maximum = 127;
            this.hsbarSteerAngleSensorZero.Minimum = -127;
            this.hsbarSteerAngleSensorZero.Name = "hsbarSteerAngleSensorZero";
            this.hsbarSteerAngleSensorZero.Size = new System.Drawing.Size(260, 30);
            this.hsbarSteerAngleSensorZero.TabIndex = 294;
            this.hsbarSteerAngleSensorZero.ValueChanged += new System.EventHandler(this.hsbarSteerAngleSensorZero_ValueChanged);
            // 
            // lblCountsPerDegree
            // 
            this.lblCountsPerDegree.AutoSize = true;
            this.lblCountsPerDegree.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountsPerDegree.Location = new System.Drawing.Point(277, 90);
            this.lblCountsPerDegree.Name = "lblCountsPerDegree";
            this.lblCountsPerDegree.Size = new System.Drawing.Size(91, 39);
            this.lblCountsPerDegree.TabIndex = 308;
            this.lblCountsPerDegree.Text = "-888";
            // 
            // lblMaxSteerAngle
            // 
            this.lblMaxSteerAngle.AutoSize = true;
            this.lblMaxSteerAngle.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxSteerAngle.Location = new System.Drawing.Point(277, 157);
            this.lblMaxSteerAngle.Name = "lblMaxSteerAngle";
            this.lblMaxSteerAngle.Size = new System.Drawing.Size(91, 39);
            this.lblMaxSteerAngle.TabIndex = 303;
            this.lblMaxSteerAngle.Text = "-888";
            // 
            // lblSidehillDraftGain
            // 
            this.lblSidehillDraftGain.AutoSize = true;
            this.lblSidehillDraftGain.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSidehillDraftGain.Location = new System.Drawing.Point(279, 224);
            this.lblSidehillDraftGain.Name = "lblSidehillDraftGain";
            this.lblSidehillDraftGain.Size = new System.Drawing.Size(91, 39);
            this.lblSidehillDraftGain.TabIndex = 268;
            this.lblSidehillDraftGain.Text = "-888";
            // 
            // lblSteerAngleSensorZero
            // 
            this.lblSteerAngleSensorZero.AutoSize = true;
            this.lblSteerAngleSensorZero.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerAngleSensorZero.Location = new System.Drawing.Point(277, 23);
            this.lblSteerAngleSensorZero.Name = "lblSteerAngleSensorZero";
            this.lblSteerAngleSensorZero.Size = new System.Drawing.Size(91, 39);
            this.lblSteerAngleSensorZero.TabIndex = 298;
            this.lblSteerAngleSensorZero.Text = "-888";
            // 
            // tabLook
            // 
            this.tabLook.BackColor = System.Drawing.Color.PowderBlue;
            this.tabLook.Controls.Add(this.hsbarLookAheadUturnMult);
            this.tabLook.Controls.Add(this.label2);
            this.tabLook.Controls.Add(this.hsbarLookAheadMin);
            this.tabLook.Controls.Add(this.hsbarDistanceFromLine);
            this.tabLook.Controls.Add(this.hsbarLookAhead);
            this.tabLook.Controls.Add(this.label37);
            this.tabLook.Controls.Add(this.label4);
            this.tabLook.Controls.Add(this.label6);
            this.tabLook.Controls.Add(this.lblLookAheadUturnMult);
            this.tabLook.Controls.Add(this.lblLookAhead);
            this.tabLook.Controls.Add(this.lblLookAheadMinimum);
            this.tabLook.Controls.Add(this.lblDistanceFromLine);
            this.tabLook.Location = new System.Drawing.Point(4, 48);
            this.tabLook.Name = "tabLook";
            this.tabLook.Size = new System.Drawing.Size(376, 267);
            this.tabLook.TabIndex = 14;
            this.tabLook.Text = "Pure P";
            // 
            // hsbarLookAheadUturnMult
            // 
            this.hsbarLookAheadUturnMult.LargeChange = 1;
            this.hsbarLookAheadUturnMult.Location = new System.Drawing.Point(11, 231);
            this.hsbarLookAheadUturnMult.Maximum = 10;
            this.hsbarLookAheadUturnMult.Minimum = 1;
            this.hsbarLookAheadUturnMult.Name = "hsbarLookAheadUturnMult";
            this.hsbarLookAheadUturnMult.Size = new System.Drawing.Size(260, 30);
            this.hsbarLookAheadUturnMult.TabIndex = 298;
            this.hsbarLookAheadUturnMult.Value = 4;
            this.hsbarLookAheadUturnMult.ValueChanged += new System.EventHandler(this.hsbarLookAheadUturnMult_ValueChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 25);
            this.label2.TabIndex = 297;
            this.label2.Text = "UTurn Look Ahead (Multiplier)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarLookAheadMin
            // 
            this.hsbarLookAheadMin.LargeChange = 1;
            this.hsbarLookAheadMin.Location = new System.Drawing.Point(11, 164);
            this.hsbarLookAheadMin.Maximum = 50;
            this.hsbarLookAheadMin.Minimum = 2;
            this.hsbarLookAheadMin.Name = "hsbarLookAheadMin";
            this.hsbarLookAheadMin.Size = new System.Drawing.Size(260, 30);
            this.hsbarLookAheadMin.TabIndex = 272;
            this.hsbarLookAheadMin.Value = 10;
            this.hsbarLookAheadMin.ValueChanged += new System.EventHandler(this.hsbarLookAheadMin_ValueChanged);
            // 
            // hsbarDistanceFromLine
            // 
            this.hsbarDistanceFromLine.LargeChange = 1;
            this.hsbarDistanceFromLine.Location = new System.Drawing.Point(11, 98);
            this.hsbarDistanceFromLine.Maximum = 30;
            this.hsbarDistanceFromLine.Name = "hsbarDistanceFromLine";
            this.hsbarDistanceFromLine.Size = new System.Drawing.Size(260, 30);
            this.hsbarDistanceFromLine.TabIndex = 269;
            this.hsbarDistanceFromLine.Value = 10;
            this.hsbarDistanceFromLine.ValueChanged += new System.EventHandler(this.hsbarDistanceFromLine_ValueChanged);
            // 
            // hsbarLookAhead
            // 
            this.hsbarLookAhead.LargeChange = 1;
            this.hsbarLookAhead.Location = new System.Drawing.Point(11, 33);
            this.hsbarLookAhead.Maximum = 60;
            this.hsbarLookAhead.Minimum = 5;
            this.hsbarLookAhead.Name = "hsbarLookAhead";
            this.hsbarLookAhead.Size = new System.Drawing.Size(260, 30);
            this.hsbarLookAhead.TabIndex = 289;
            this.hsbarLookAhead.Value = 25;
            this.hsbarLookAhead.ValueChanged += new System.EventHandler(this.hsbarLookAhead_ValueChanged);
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(18, 5);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(257, 25);
            this.label37.TabIndex = 290;
            this.label37.Text = "Look Ahead (Seconds)";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(257, 25);
            this.label4.TabIndex = 273;
            this.label4.Text = "Look Ahead Offline Multiplier";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(257, 25);
            this.label6.TabIndex = 270;
            this.label6.Text = "Min Look Ahead (Meters)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLookAheadUturnMult
            // 
            this.lblLookAheadUturnMult.AutoSize = true;
            this.lblLookAheadUturnMult.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLookAheadUturnMult.Location = new System.Drawing.Point(277, 223);
            this.lblLookAheadUturnMult.Name = "lblLookAheadUturnMult";
            this.lblLookAheadUturnMult.Size = new System.Drawing.Size(91, 39);
            this.lblLookAheadUturnMult.TabIndex = 299;
            this.lblLookAheadUturnMult.Text = "-888";
            // 
            // lblLookAhead
            // 
            this.lblLookAhead.AutoSize = true;
            this.lblLookAhead.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLookAhead.Location = new System.Drawing.Point(277, 25);
            this.lblLookAhead.Name = "lblLookAhead";
            this.lblLookAhead.Size = new System.Drawing.Size(91, 39);
            this.lblLookAhead.TabIndex = 293;
            this.lblLookAhead.Text = "-888";
            // 
            // lblLookAheadMinimum
            // 
            this.lblLookAheadMinimum.AutoSize = true;
            this.lblLookAheadMinimum.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLookAheadMinimum.Location = new System.Drawing.Point(277, 157);
            this.lblLookAheadMinimum.Name = "lblLookAheadMinimum";
            this.lblLookAheadMinimum.Size = new System.Drawing.Size(91, 39);
            this.lblLookAheadMinimum.TabIndex = 274;
            this.lblLookAheadMinimum.Text = "-888";
            // 
            // lblDistanceFromLine
            // 
            this.lblDistanceFromLine.AutoSize = true;
            this.lblDistanceFromLine.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistanceFromLine.Location = new System.Drawing.Point(277, 91);
            this.lblDistanceFromLine.Name = "lblDistanceFromLine";
            this.lblDistanceFromLine.Size = new System.Drawing.Size(91, 39);
            this.lblDistanceFromLine.TabIndex = 271;
            this.lblDistanceFromLine.Text = "-888";
            // 
            // tabStan
            // 
            this.tabStan.BackColor = System.Drawing.Color.PowderBlue;
            this.tabStan.Controls.Add(this.btnStanley);
            this.tabStan.Controls.Add(this.label1);
            this.tabStan.Controls.Add(this.hsbarHeadingErrorGain);
            this.tabStan.Controls.Add(this.btnChart);
            this.tabStan.Controls.Add(this.lblStanleyGain);
            this.tabStan.Controls.Add(this.hsbarStanleyGain);
            this.tabStan.Controls.Add(this.label3);
            this.tabStan.Controls.Add(this.label5);
            this.tabStan.Controls.Add(this.lblHeadingErrorGain);
            this.tabStan.Location = new System.Drawing.Point(4, 48);
            this.tabStan.Name = "tabStan";
            this.tabStan.Size = new System.Drawing.Size(376, 267);
            this.tabStan.TabIndex = 15;
            this.tabStan.Text = "Stanley";
            // 
            // btnStanley
            // 
            this.btnStanley.BackColor = System.Drawing.Color.Transparent;
            this.btnStanley.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStanley.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStanley.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStanley.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStanley.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStanley.Location = new System.Drawing.Point(218, 188);
            this.btnStanley.Name = "btnStanley";
            this.btnStanley.Size = new System.Drawing.Size(129, 69);
            this.btnStanley.TabIndex = 302;
            this.btnStanley.Text = "Stanley";
            this.btnStanley.UseVisualStyleBackColor = false;
            this.btnStanley.Click += new System.EventHandler(this.BtnStanley_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 27);
            this.label1.TabIndex = 300;
            this.label1.Text = "Choose Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // hsbarHeadingErrorGain
            // 
            this.hsbarHeadingErrorGain.LargeChange = 1;
            this.hsbarHeadingErrorGain.Location = new System.Drawing.Point(6, 114);
            this.hsbarHeadingErrorGain.Maximum = 10;
            this.hsbarHeadingErrorGain.Minimum = 1;
            this.hsbarHeadingErrorGain.Name = "hsbarHeadingErrorGain";
            this.hsbarHeadingErrorGain.Size = new System.Drawing.Size(260, 30);
            this.hsbarHeadingErrorGain.TabIndex = 294;
            this.hsbarHeadingErrorGain.Value = 5;
            this.hsbarHeadingErrorGain.ValueChanged += new System.EventHandler(this.hsbarHeadingErrorGain_ValueChanged);
            // 
            // btnChart
            // 
            this.btnChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChart.BackColor = System.Drawing.Color.Transparent;
            this.btnChart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChart.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChart.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChart.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChart.ForeColor = System.Drawing.Color.Black;
            this.btnChart.Location = new System.Drawing.Point(17, 188);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(125, 69);
            this.btnChart.TabIndex = 234;
            this.btnChart.Text = "Steer Chart";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // lblStanleyGain
            // 
            this.lblStanleyGain.AutoSize = true;
            this.lblStanleyGain.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStanleyGain.Location = new System.Drawing.Point(280, 28);
            this.lblStanleyGain.Name = "lblStanleyGain";
            this.lblStanleyGain.Size = new System.Drawing.Size(91, 39);
            this.lblStanleyGain.TabIndex = 299;
            this.lblStanleyGain.Text = "-888";
            // 
            // hsbarStanleyGain
            // 
            this.hsbarStanleyGain.LargeChange = 1;
            this.hsbarStanleyGain.Location = new System.Drawing.Point(6, 35);
            this.hsbarStanleyGain.Maximum = 30;
            this.hsbarStanleyGain.Minimum = 1;
            this.hsbarStanleyGain.Name = "hsbarStanleyGain";
            this.hsbarStanleyGain.Size = new System.Drawing.Size(260, 30);
            this.hsbarStanleyGain.TabIndex = 297;
            this.hsbarStanleyGain.Value = 10;
            this.hsbarStanleyGain.ValueChanged += new System.EventHandler(this.hsbarStanleyGain_ValueChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 23);
            this.label3.TabIndex = 298;
            this.label3.Text = "Agressiveness";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 23);
            this.label5.TabIndex = 296;
            this.label5.Text = "Overshoot Reduction";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeadingErrorGain
            // 
            this.lblHeadingErrorGain.AutoSize = true;
            this.lblHeadingErrorGain.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadingErrorGain.Location = new System.Drawing.Point(280, 107);
            this.lblHeadingErrorGain.Name = "lblHeadingErrorGain";
            this.lblHeadingErrorGain.Size = new System.Drawing.Size(91, 39);
            this.lblHeadingErrorGain.TabIndex = 295;
            this.lblHeadingErrorGain.Text = "-888";
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
            this.lblSteerAngle.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerAngle.ForeColor = System.Drawing.Color.DarkViolet;
            this.lblSteerAngle.Location = new System.Drawing.Point(175, 323);
            this.lblSteerAngle.Name = "lblSteerAngle";
            this.lblSteerAngle.Size = new System.Drawing.Size(79, 23);
            this.lblSteerAngle.TabIndex = 306;
            this.lblSteerAngle.Text = "-55.5";
            this.lblSteerAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRecd
            // 
            this.lblRecd.AutoSize = true;
            this.lblRecd.BackColor = System.Drawing.Color.Transparent;
            this.lblRecd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecd.Location = new System.Drawing.Point(78, 400);
            this.lblRecd.Name = "lblRecd";
            this.lblRecd.Size = new System.Drawing.Size(32, 16);
            this.lblRecd.TabIndex = 309;
            this.lblRecd.Text = "255";
            this.lblRecd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSent
            // 
            this.lblSent.AutoSize = true;
            this.lblSent.BackColor = System.Drawing.Color.Transparent;
            this.lblSent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSent.Location = new System.Drawing.Point(40, 400);
            this.lblSent.Name = "lblSent";
            this.lblSent.Size = new System.Drawing.Size(32, 16);
            this.lblSent.TabIndex = 310;
            this.lblSent.Text = "255";
            this.lblSent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSteerAngleActual
            // 
            this.lblSteerAngleActual.BackColor = System.Drawing.Color.Transparent;
            this.lblSteerAngleActual.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerAngleActual.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSteerAngleActual.Location = new System.Drawing.Point(50, 323);
            this.lblSteerAngleActual.Name = "lblSteerAngleActual";
            this.lblSteerAngleActual.Size = new System.Drawing.Size(70, 23);
            this.lblSteerAngleActual.TabIndex = 311;
            this.lblSteerAngleActual.Text = "-55.5";
            this.lblSteerAngleActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(306, 323);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(70, 23);
            this.lblError.TabIndex = 312;
            this.lblError.Text = "-30.0";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFreeDriveZero
            // 
            this.btnFreeDriveZero.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreeDriveZero.Location = new System.Drawing.Point(312, 349);
            this.btnFreeDriveZero.Name = "btnFreeDriveZero";
            this.btnFreeDriveZero.Size = new System.Drawing.Size(69, 45);
            this.btnFreeDriveZero.TabIndex = 313;
            this.btnFreeDriveZero.Text = ">0<";
            this.btnFreeDriveZero.UseVisualStyleBackColor = true;
            this.btnFreeDriveZero.Click += new System.EventHandler(this.btnFreeDriveZero_Click);
            // 
            // btnSteerAngleDown
            // 
            this.btnSteerAngleDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSteerAngleDown.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSteerAngleDown.Image = global::AgOpenGPS.Properties.Resources.ArrowLeft;
            this.btnSteerAngleDown.Location = new System.Drawing.Point(106, 349);
            this.btnSteerAngleDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSteerAngleDown.Name = "btnSteerAngleDown";
            this.btnSteerAngleDown.Size = new System.Drawing.Size(81, 45);
            this.btnSteerAngleDown.TabIndex = 314;
            this.btnSteerAngleDown.UseVisualStyleBackColor = true;
            this.btnSteerAngleDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSteerAngleDown_MouseDown);
            // 
            // btnSteerAngleUp
            // 
            this.btnSteerAngleUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSteerAngleUp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSteerAngleUp.Image = global::AgOpenGPS.Properties.Resources.ArrowRight;
            this.btnSteerAngleUp.Location = new System.Drawing.Point(209, 349);
            this.btnSteerAngleUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSteerAngleUp.Name = "btnSteerAngleUp";
            this.btnSteerAngleUp.Size = new System.Drawing.Size(81, 45);
            this.btnSteerAngleUp.TabIndex = 315;
            this.btnSteerAngleUp.UseVisualStyleBackColor = true;
            this.btnSteerAngleUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSteerAngleUp_MouseDown);
            // 
            // lblPWMDisplay
            // 
            this.lblPWMDisplay.BackColor = System.Drawing.Color.Transparent;
            this.lblPWMDisplay.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPWMDisplay.Location = new System.Drawing.Point(213, 397);
            this.lblPWMDisplay.Name = "lblPWMDisplay";
            this.lblPWMDisplay.Size = new System.Drawing.Size(64, 23);
            this.lblPWMDisplay.TabIndex = 316;
            this.lblPWMDisplay.Text = "255";
            this.lblPWMDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 400);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 16);
            this.label8.TabIndex = 317;
            this.label8.Text = "Chk:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(155, 397);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 318;
            this.label9.Text = "PWM:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 324);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 23);
            this.label11.TabIndex = 319;
            this.label11.Text = "Act:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(130, 323);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 23);
            this.label12.TabIndex = 320;
            this.label12.Text = "Set:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(260, 323);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 23);
            this.label13.TabIndex = 321;
            this.label13.Text = "Err:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(323, 397);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 16);
            this.label14.TabIndex = 322;
            this.label14.Text = "Or +5";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormSteer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(388, 423);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblPWMDisplay);
            this.Controls.Add(this.btnSteerAngleDown);
            this.Controls.Add(this.btnSteerAngleUp);
            this.Controls.Add(this.btnFreeDriveZero);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblSteerAngleActual);
            this.Controls.Add(this.btnFreeDrive);
            this.Controls.Add(this.lblSteerAngle);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblSent);
            this.Controls.Add(this.lblRecd);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSteer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auto Steer Configuration";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSteer_FormClosing);
            this.Load += new System.EventHandler(this.FormSteer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGain.ResumeLayout(false);
            this.tabGain.PerformLayout();
            this.tabSteer.ResumeLayout(false);
            this.tabSteer.PerformLayout();
            this.tabLook.ResumeLayout(false);
            this.tabLook.PerformLayout();
            this.tabStan.ResumeLayout(false);
            this.tabStan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFreeDrive;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSteer;
        private System.Windows.Forms.TabPage tabGain;
        private System.Windows.Forms.Label lblHighSteerPWM;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.HScrollBar hsbarHighSteerPWM;
        private System.Windows.Forms.Label lblLowSteerPWM;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.HScrollBar hsbarLowSteerPWM;
        private System.Windows.Forms.Label lblSidehillDraftGain;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.HScrollBar hsbarSidehillDraftGain;
        private System.Windows.Forms.Label lblProportionalGain;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.HScrollBar hsbarProportionalGain;
        private System.Windows.Forms.Label lblLookAhead;
        private System.Windows.Forms.HScrollBar hsbarLookAhead;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label lblMinPWM;
        private System.Windows.Forms.HScrollBar hsbarMinPWM;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label lblCountsPerDegree;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.HScrollBar hsbarCountsPerDegree;
        private System.Windows.Forms.Label lblMaxSteerAngle;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.HScrollBar hsbarMaxSteerAngle;
        private System.Windows.Forms.Label lblSteerAngleSensorZero;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.HScrollBar hsbarSteerAngleSensorZero;
        private System.Windows.Forms.TabPage tabLook;
        private System.Windows.Forms.HScrollBar hsbarLookAheadMin;
        private System.Windows.Forms.HScrollBar hsbarDistanceFromLine;
        private System.Windows.Forms.Label lblLookAheadMinimum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDistanceFromLine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.HScrollBar hsbarLookAheadUturnMult;
        private System.Windows.Forms.Label lblLookAheadUturnMult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabStan;
        private System.Windows.Forms.HScrollBar hsbarHeadingErrorGain;
        private System.Windows.Forms.Label lblStanleyGain;
        private System.Windows.Forms.HScrollBar hsbarStanleyGain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblHeadingErrorGain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStanley;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblSteerAngle;
        private System.Windows.Forms.Label lblRecd;
        private System.Windows.Forms.Label lblSent;
        private System.Windows.Forms.Label lblSteerAngleActual;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnFreeDriveZero;
        private ProXoft.WinForms.RepeatButton btnSteerAngleDown;
        private ProXoft.WinForms.RepeatButton btnSteerAngleUp;
        private System.Windows.Forms.Label lblPWMDisplay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}