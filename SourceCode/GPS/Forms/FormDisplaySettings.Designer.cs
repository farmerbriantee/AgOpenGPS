namespace AgOpenGPS
{
    partial class FormDisplaySettings
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.bntOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabIMU = new System.Windows.Forms.TabPage();
            this.headingGroupBox = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rbtnHeadingHDT = new System.Windows.Forms.RadioButton();
            this.rbtnHeadingGPS = new System.Windows.Forms.RadioButton();
            this.rbtnHeadingFix = new System.Windows.Forms.RadioButton();
            this.btnRollZero = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRemoveZeroOffsetPitch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnZeroPitch = new System.Windows.Forms.Button();
            this.btnRemoveZeroOffset = new System.Windows.Forms.Button();
            this.lblRollZeroOffset = new System.Windows.Forms.Label();
            this.btnZeroRoll = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cboxRollExtUDP = new System.Windows.Forms.CheckBox();
            this.cboxRollFromBrick = new System.Windows.Forms.CheckBox();
            this.cboxRollFromGPS = new System.Windows.Forms.CheckBox();
            this.cboxRollAutoSteer = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cboxHeadingExtUDP = new System.Windows.Forms.CheckBox();
            this.cboxHeadingPAOGI = new System.Windows.Forms.CheckBox();
            this.cboxHeadingAutoSteer = new System.Windows.Forms.CheckBox();
            this.cboxHeadingBrick = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tboxTinkerUID = new System.Windows.Forms.TextBox();
            this.tabDisplay = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudLightbarCmPerPixel = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.nudBoundaryDistance = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudTriangleResolution = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.nudMinFixStepDistance = new System.Windows.Forms.NumericUpDown();
            this.tabGuidance = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cboxAutoSteerAuto = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.nudSnapDistanceSmall = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudSnapDistance = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabIMU.SuspendLayout();
            this.headingGroupBox.SuspendLayout();
            this.btnRollZero.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabDisplay.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLightbarCmPerPixel)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoundaryDistance)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTriangleResolution)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinFixStepDistance)).BeginInit();
            this.tabGuidance.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSnapDistanceSmall)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSnapDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(689, 647);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 72);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bntOK
            // 
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntOK.Location = new System.Drawing.Point(802, 647);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(156, 72);
            this.bntOK.TabIndex = 4;
            this.bntOK.Text = "Save";
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabIMU);
            this.tabControl1.Controls.Add(this.tabDisplay);
            this.tabControl1.Controls.Add(this.tabGuidance);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(300, 50);
            this.tabControl1.Location = new System.Drawing.Point(6, 7);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(956, 633);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 6;
            // 
            // tabIMU
            // 
            this.tabIMU.BackColor = System.Drawing.Color.Transparent;
            this.tabIMU.Controls.Add(this.headingGroupBox);
            this.tabIMU.Controls.Add(this.btnRollZero);
            this.tabIMU.Controls.Add(this.label10);
            this.tabIMU.Controls.Add(this.groupBox6);
            this.tabIMU.Controls.Add(this.groupBox7);
            this.tabIMU.Controls.Add(this.label9);
            this.tabIMU.Controls.Add(this.tboxTinkerUID);
            this.tabIMU.Location = new System.Drawing.Point(4, 54);
            this.tabIMU.Name = "tabIMU";
            this.tabIMU.Size = new System.Drawing.Size(948, 575);
            this.tabIMU.TabIndex = 13;
            this.tabIMU.Text = "IMU - GPS";
            // 
            // headingGroupBox
            // 
            this.headingGroupBox.Controls.Add(this.label13);
            this.headingGroupBox.Controls.Add(this.label12);
            this.headingGroupBox.Controls.Add(this.label11);
            this.headingGroupBox.Controls.Add(this.rbtnHeadingHDT);
            this.headingGroupBox.Controls.Add(this.rbtnHeadingGPS);
            this.headingGroupBox.Controls.Add(this.rbtnHeadingFix);
            this.headingGroupBox.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.headingGroupBox.Location = new System.Drawing.Point(16, 30);
            this.headingGroupBox.Name = "headingGroupBox";
            this.headingGroupBox.Size = new System.Drawing.Size(322, 238);
            this.headingGroupBox.TabIndex = 84;
            this.headingGroupBox.TabStop = false;
            this.headingGroupBox.Text = "GPS True Heading From";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(115, 179);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 18);
            this.label13.TabIndex = 88;
            this.label13.Text = "Dual Antenna";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(115, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 18);
            this.label12.TabIndex = 87;
            this.label12.Text = "From VTG or RMC ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(115, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 18);
            this.label11.TabIndex = 86;
            this.label11.Text = "Fix to Fix Calc";
            // 
            // rbtnHeadingHDT
            // 
            this.rbtnHeadingHDT.AutoSize = true;
            this.rbtnHeadingHDT.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHeadingHDT.Location = new System.Drawing.Point(22, 171);
            this.rbtnHeadingHDT.Name = "rbtnHeadingHDT";
            this.rbtnHeadingHDT.Size = new System.Drawing.Size(75, 29);
            this.rbtnHeadingHDT.TabIndex = 2;
            this.rbtnHeadingHDT.TabStop = true;
            this.rbtnHeadingHDT.Text = "HDT";
            this.rbtnHeadingHDT.UseVisualStyleBackColor = true;
            // 
            // rbtnHeadingGPS
            // 
            this.rbtnHeadingGPS.AutoSize = true;
            this.rbtnHeadingGPS.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHeadingGPS.Location = new System.Drawing.Point(22, 113);
            this.rbtnHeadingGPS.Name = "rbtnHeadingGPS";
            this.rbtnHeadingGPS.Size = new System.Drawing.Size(73, 29);
            this.rbtnHeadingGPS.TabIndex = 1;
            this.rbtnHeadingGPS.TabStop = true;
            this.rbtnHeadingGPS.Text = "GPS";
            this.rbtnHeadingGPS.UseVisualStyleBackColor = true;
            // 
            // rbtnHeadingFix
            // 
            this.rbtnHeadingFix.AutoSize = true;
            this.rbtnHeadingFix.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHeadingFix.Location = new System.Drawing.Point(22, 55);
            this.rbtnHeadingFix.Name = "rbtnHeadingFix";
            this.rbtnHeadingFix.Size = new System.Drawing.Size(61, 29);
            this.rbtnHeadingFix.TabIndex = 0;
            this.rbtnHeadingFix.TabStop = true;
            this.rbtnHeadingFix.Text = "Fix";
            this.rbtnHeadingFix.UseVisualStyleBackColor = true;
            this.rbtnHeadingFix.CheckedChanged += new System.EventHandler(this.rbtnHeadingFix_CheckedChanged);
            // 
            // btnRollZero
            // 
            this.btnRollZero.Controls.Add(this.label2);
            this.btnRollZero.Controls.Add(this.label3);
            this.btnRollZero.Controls.Add(this.btnRemoveZeroOffsetPitch);
            this.btnRollZero.Controls.Add(this.label1);
            this.btnRollZero.Controls.Add(this.btnZeroPitch);
            this.btnRollZero.Controls.Add(this.btnRemoveZeroOffset);
            this.btnRollZero.Controls.Add(this.lblRollZeroOffset);
            this.btnRollZero.Controls.Add(this.btnZeroRoll);
            this.btnRollZero.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRollZero.Location = new System.Drawing.Point(16, 319);
            this.btnRollZero.Name = "btnRollZero";
            this.btnRollZero.Size = new System.Drawing.Size(322, 246);
            this.btnRollZero.TabIndex = 83;
            this.btnRollZero.TabStop = false;
            this.btnRollZero.Text = "Roll / Pitch Zero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(204, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 84;
            this.label2.Text = "Pitch";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(204, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 16);
            this.label3.TabIndex = 85;
            this.label3.Text = "Roll";
            // 
            // btnRemoveZeroOffsetPitch
            // 
            this.btnRemoveZeroOffsetPitch.Enabled = false;
            this.btnRemoveZeroOffsetPitch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveZeroOffsetPitch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemoveZeroOffsetPitch.Location = new System.Drawing.Point(12, 153);
            this.btnRemoveZeroOffsetPitch.Name = "btnRemoveZeroOffsetPitch";
            this.btnRemoveZeroOffsetPitch.Size = new System.Drawing.Size(79, 48);
            this.btnRemoveZeroOffsetPitch.TabIndex = 79;
            this.btnRemoveZeroOffsetPitch.Text = "Remove Offset";
            this.btnRemoveZeroOffsetPitch.UseVisualStyleBackColor = true;
            this.btnRemoveZeroOffsetPitch.Click += new System.EventHandler(this.btnRemoveZeroOffsetPitch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(99, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 33);
            this.label1.TabIndex = 78;
            this.label1.Text = "--";
            // 
            // btnZeroPitch
            // 
            this.btnZeroPitch.Enabled = false;
            this.btnZeroPitch.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroPitch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZeroPitch.Location = new System.Drawing.Point(207, 153);
            this.btnZeroPitch.Name = "btnZeroPitch";
            this.btnZeroPitch.Size = new System.Drawing.Size(103, 48);
            this.btnZeroPitch.TabIndex = 77;
            this.btnZeroPitch.Text = "> 0 <";
            this.btnZeroPitch.UseVisualStyleBackColor = true;
            this.btnZeroPitch.Click += new System.EventHandler(this.btnZeroPitch_Click);
            // 
            // btnRemoveZeroOffset
            // 
            this.btnRemoveZeroOffset.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveZeroOffset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemoveZeroOffset.Location = new System.Drawing.Point(12, 46);
            this.btnRemoveZeroOffset.Name = "btnRemoveZeroOffset";
            this.btnRemoveZeroOffset.Size = new System.Drawing.Size(79, 48);
            this.btnRemoveZeroOffset.TabIndex = 76;
            this.btnRemoveZeroOffset.Text = "Remove Offset";
            this.btnRemoveZeroOffset.UseVisualStyleBackColor = true;
            this.btnRemoveZeroOffset.Click += new System.EventHandler(this.btnRemoveZeroOffset_Click);
            // 
            // lblRollZeroOffset
            // 
            this.lblRollZeroOffset.AutoSize = true;
            this.lblRollZeroOffset.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.lblRollZeroOffset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRollZeroOffset.Location = new System.Drawing.Point(99, 55);
            this.lblRollZeroOffset.Name = "lblRollZeroOffset";
            this.lblRollZeroOffset.Size = new System.Drawing.Size(100, 33);
            this.lblRollZeroOffset.TabIndex = 75;
            this.lblRollZeroOffset.Text = "label11";
            // 
            // btnZeroRoll
            // 
            this.btnZeroRoll.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroRoll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZeroRoll.Location = new System.Drawing.Point(207, 46);
            this.btnZeroRoll.Name = "btnZeroRoll";
            this.btnZeroRoll.Size = new System.Drawing.Size(103, 48);
            this.btnZeroRoll.TabIndex = 73;
            this.btnZeroRoll.Text = "> 0 <";
            this.btnZeroRoll.UseVisualStyleBackColor = true;
            this.btnZeroRoll.Click += new System.EventHandler(this.btnZeroRoll_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(736, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 16);
            this.label10.TabIndex = 82;
            this.label10.Text = "*Most Settings Require Restart";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cboxRollExtUDP);
            this.groupBox6.Controls.Add(this.cboxRollFromBrick);
            this.groupBox6.Controls.Add(this.cboxRollFromGPS);
            this.groupBox6.Controls.Add(this.cboxRollAutoSteer);
            this.groupBox6.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(385, 319);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(314, 246);
            this.groupBox6.TabIndex = 80;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Roll Source";
            // 
            // cboxRollExtUDP
            // 
            this.cboxRollExtUDP.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxRollExtUDP.AutoSize = true;
            this.cboxRollExtUDP.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSalmon;
            this.cboxRollExtUDP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxRollExtUDP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxRollExtUDP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboxRollExtUDP.Location = new System.Drawing.Point(18, 150);
            this.cboxRollExtUDP.Name = "cboxRollExtUDP";
            this.cboxRollExtUDP.Size = new System.Drawing.Size(186, 35);
            this.cboxRollExtUDP.TabIndex = 75;
            this.cboxRollExtUDP.Text = "Ext UDP Source";
            this.cboxRollExtUDP.UseVisualStyleBackColor = true;
            this.cboxRollExtUDP.CheckedChanged += new System.EventHandler(this.CboxRollExtUDP_CheckedChanged);
            // 
            // cboxRollFromBrick
            // 
            this.cboxRollFromBrick.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxRollFromBrick.AutoSize = true;
            this.cboxRollFromBrick.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSalmon;
            this.cboxRollFromBrick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxRollFromBrick.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxRollFromBrick.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboxRollFromBrick.Location = new System.Drawing.Point(18, 96);
            this.cboxRollFromBrick.Name = "cboxRollFromBrick";
            this.cboxRollFromBrick.Size = new System.Drawing.Size(106, 35);
            this.cboxRollFromBrick.TabIndex = 74;
            this.cboxRollFromBrick.Text = "Brick v2";
            this.cboxRollFromBrick.UseVisualStyleBackColor = true;
            this.cboxRollFromBrick.CheckedChanged += new System.EventHandler(this.CboxRollBrick_CheckedChanged);
            // 
            // cboxRollFromGPS
            // 
            this.cboxRollFromGPS.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxRollFromGPS.AutoSize = true;
            this.cboxRollFromGPS.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSalmon;
            this.cboxRollFromGPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxRollFromGPS.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxRollFromGPS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboxRollFromGPS.Location = new System.Drawing.Point(18, 204);
            this.cboxRollFromGPS.Name = "cboxRollFromGPS";
            this.cboxRollFromGPS.Size = new System.Drawing.Size(125, 35);
            this.cboxRollFromGPS.TabIndex = 73;
            this.cboxRollFromGPS.Text = "From GPS";
            this.cboxRollFromGPS.UseVisualStyleBackColor = true;
            this.cboxRollFromGPS.CheckedChanged += new System.EventHandler(this.cboxRollFromGPS_CheckedChanged);
            // 
            // cboxRollAutoSteer
            // 
            this.cboxRollAutoSteer.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxRollAutoSteer.AutoSize = true;
            this.cboxRollAutoSteer.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSalmon;
            this.cboxRollAutoSteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxRollAutoSteer.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxRollAutoSteer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboxRollAutoSteer.Location = new System.Drawing.Point(18, 42);
            this.cboxRollAutoSteer.Name = "cboxRollAutoSteer";
            this.cboxRollAutoSteer.Size = new System.Drawing.Size(254, 35);
            this.cboxRollAutoSteer.TabIndex = 72;
            this.cboxRollAutoSteer.Text = "From AutoSteer Board";
            this.cboxRollAutoSteer.UseVisualStyleBackColor = true;
            this.cboxRollAutoSteer.CheckedChanged += new System.EventHandler(this.cboxRollAutoSteer_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cboxHeadingExtUDP);
            this.groupBox7.Controls.Add(this.cboxHeadingPAOGI);
            this.groupBox7.Controls.Add(this.cboxHeadingAutoSteer);
            this.groupBox7.Controls.Add(this.cboxHeadingBrick);
            this.groupBox7.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(385, 22);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(314, 246);
            this.groupBox7.TabIndex = 81;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Heading Correction Source";
            // 
            // cboxHeadingExtUDP
            // 
            this.cboxHeadingExtUDP.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxHeadingExtUDP.AutoSize = true;
            this.cboxHeadingExtUDP.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxHeadingExtUDP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxHeadingExtUDP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxHeadingExtUDP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboxHeadingExtUDP.Location = new System.Drawing.Point(16, 147);
            this.cboxHeadingExtUDP.Name = "cboxHeadingExtUDP";
            this.cboxHeadingExtUDP.Size = new System.Drawing.Size(186, 35);
            this.cboxHeadingExtUDP.TabIndex = 72;
            this.cboxHeadingExtUDP.Text = "Ext UDP Source";
            this.cboxHeadingExtUDP.UseVisualStyleBackColor = true;
            this.cboxHeadingExtUDP.CheckedChanged += new System.EventHandler(this.CboxHeadingExtUDP_CheckedChanged);
            // 
            // cboxHeadingPAOGI
            // 
            this.cboxHeadingPAOGI.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxHeadingPAOGI.AutoSize = true;
            this.cboxHeadingPAOGI.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxHeadingPAOGI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxHeadingPAOGI.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxHeadingPAOGI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboxHeadingPAOGI.Location = new System.Drawing.Point(16, 201);
            this.cboxHeadingPAOGI.Name = "cboxHeadingPAOGI";
            this.cboxHeadingPAOGI.Size = new System.Drawing.Size(233, 35);
            this.cboxHeadingPAOGI.TabIndex = 71;
            this.cboxHeadingPAOGI.Text = "PAOGI (Reach IMU)";
            this.cboxHeadingPAOGI.UseVisualStyleBackColor = true;
            this.cboxHeadingPAOGI.CheckedChanged += new System.EventHandler(this.cboxHeadingPAOGI_CheckedChanged);
            // 
            // cboxHeadingAutoSteer
            // 
            this.cboxHeadingAutoSteer.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxHeadingAutoSteer.AutoSize = true;
            this.cboxHeadingAutoSteer.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxHeadingAutoSteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxHeadingAutoSteer.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxHeadingAutoSteer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboxHeadingAutoSteer.Location = new System.Drawing.Point(16, 39);
            this.cboxHeadingAutoSteer.Name = "cboxHeadingAutoSteer";
            this.cboxHeadingAutoSteer.Size = new System.Drawing.Size(254, 35);
            this.cboxHeadingAutoSteer.TabIndex = 69;
            this.cboxHeadingAutoSteer.Text = "From AutoSteer Board";
            this.cboxHeadingAutoSteer.UseVisualStyleBackColor = true;
            this.cboxHeadingAutoSteer.CheckedChanged += new System.EventHandler(this.cboxHeadingAutosteer_CheckedChanged);
            // 
            // cboxHeadingBrick
            // 
            this.cboxHeadingBrick.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxHeadingBrick.AutoSize = true;
            this.cboxHeadingBrick.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxHeadingBrick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxHeadingBrick.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxHeadingBrick.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboxHeadingBrick.Location = new System.Drawing.Point(16, 93);
            this.cboxHeadingBrick.Name = "cboxHeadingBrick";
            this.cboxHeadingBrick.Size = new System.Drawing.Size(106, 35);
            this.cboxHeadingBrick.TabIndex = 70;
            this.cboxHeadingBrick.Text = "Brick v2";
            this.cboxHeadingBrick.UseVisualStyleBackColor = true;
            this.cboxHeadingBrick.CheckedChanged += new System.EventHandler(this.cboxHeadingBrick_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(746, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 23);
            this.label9.TabIndex = 79;
            this.label9.Text = "IMU Brick v2 UID";
            // 
            // tboxTinkerUID
            // 
            this.tboxTinkerUID.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.tboxTinkerUID.Location = new System.Drawing.Point(753, 161);
            this.tboxTinkerUID.Name = "tboxTinkerUID";
            this.tboxTinkerUID.Size = new System.Drawing.Size(169, 33);
            this.tboxTinkerUID.TabIndex = 78;
            // 
            // tabDisplay
            // 
            this.tabDisplay.Controls.Add(this.groupBox3);
            this.tabDisplay.Controls.Add(this.groupBox5);
            this.tabDisplay.Controls.Add(this.groupBox2);
            this.tabDisplay.Controls.Add(this.groupBox4);
            this.tabDisplay.Location = new System.Drawing.Point(4, 54);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.Size = new System.Drawing.Size(948, 575);
            this.tabDisplay.TabIndex = 5;
            this.tabDisplay.Text = " Display Calcs";
            this.tabDisplay.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudLightbarCmPerPixel);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(21, 229);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(387, 142);
            this.groupBox3.TabIndex = 119;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Offline cm per Lightbar Pixel";
            // 
            // nudLightbarCmPerPixel
            // 
            this.nudLightbarCmPerPixel.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLightbarCmPerPixel.Location = new System.Drawing.Point(23, 40);
            this.nudLightbarCmPerPixel.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudLightbarCmPerPixel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLightbarCmPerPixel.Name = "nudLightbarCmPerPixel";
            this.nudLightbarCmPerPixel.Size = new System.Drawing.Size(148, 85);
            this.nudLightbarCmPerPixel.TabIndex = 117;
            this.nudLightbarCmPerPixel.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudLightbarCmPerPixel.ValueChanged += new System.EventHandler(this.nudLightbarCmPerPixel_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.nudBoundaryDistance);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.groupBox5.Location = new System.Drawing.Point(488, 229);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(387, 142);
            this.groupBox5.TabIndex = 62;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Boundary Point to Point Distance";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(190, 66);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(140, 25);
            this.label31.TabIndex = 67;
            this.label31.Text = "2 to 4 is good\r\n";
            // 
            // nudBoundaryDistance
            // 
            this.nudBoundaryDistance.DecimalPlaces = 1;
            this.nudBoundaryDistance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBoundaryDistance.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudBoundaryDistance.Location = new System.Drawing.Point(30, 40);
            this.nudBoundaryDistance.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudBoundaryDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBoundaryDistance.Name = "nudBoundaryDistance";
            this.nudBoundaryDistance.Size = new System.Drawing.Size(147, 85);
            this.nudBoundaryDistance.TabIndex = 66;
            this.nudBoundaryDistance.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudBoundaryDistance.ValueChanged += new System.EventHandler(this.nudBoundaryDistance_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nudTriangleResolution);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.groupBox2.Location = new System.Drawing.Point(488, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 142);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Distance Between Section Triggers";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(205, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 25);
            this.label7.TabIndex = 67;
            this.label7.Text = "4 -> Few triangles";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(183, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 25);
            this.label6.TabIndex = 66;
            this.label6.Text = "1 -> Many Triangles";
            // 
            // nudTriangleResolution
            // 
            this.nudTriangleResolution.DecimalPlaces = 1;
            this.nudTriangleResolution.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTriangleResolution.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudTriangleResolution.Location = new System.Drawing.Point(30, 40);
            this.nudTriangleResolution.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            65536});
            this.nudTriangleResolution.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudTriangleResolution.Name = "nudTriangleResolution";
            this.nudTriangleResolution.Size = new System.Drawing.Size(147, 85);
            this.nudTriangleResolution.TabIndex = 64;
            this.nudTriangleResolution.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nudTriangleResolution.ValueChanged += new System.EventHandler(this.nudTriangleResolution_ValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.nudMinFixStepDistance);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.groupBox4.Location = new System.Drawing.Point(21, 53);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(387, 142);
            this.groupBox4.TabIndex = 60;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Distance Back for Heading Calc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(273, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 50);
            this.label4.TabIndex = 68;
            this.label4.Text = "More is\r\nsmoother";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(192, 93);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 29);
            this.label20.TabIndex = 67;
            this.label20.Text = "Meters";
            // 
            // nudMinFixStepDistance
            // 
            this.nudMinFixStepDistance.DecimalPlaces = 1;
            this.nudMinFixStepDistance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinFixStepDistance.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudMinFixStepDistance.Location = new System.Drawing.Point(23, 40);
            this.nudMinFixStepDistance.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            65536});
            this.nudMinFixStepDistance.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            this.nudMinFixStepDistance.Name = "nudMinFixStepDistance";
            this.nudMinFixStepDistance.Size = new System.Drawing.Size(163, 85);
            this.nudMinFixStepDistance.TabIndex = 66;
            this.nudMinFixStepDistance.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nudMinFixStepDistance.ValueChanged += new System.EventHandler(this.nudMinFixStepDistance_ValueChanged);
            // 
            // tabGuidance
            // 
            this.tabGuidance.Controls.Add(this.groupBox9);
            this.tabGuidance.Controls.Add(this.groupBox8);
            this.tabGuidance.Controls.Add(this.groupBox1);
            this.tabGuidance.Location = new System.Drawing.Point(4, 54);
            this.tabGuidance.Name = "tabGuidance";
            this.tabGuidance.Size = new System.Drawing.Size(948, 575);
            this.tabGuidance.TabIndex = 11;
            this.tabGuidance.Text = "Guidance";
            this.tabGuidance.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cboxAutoSteerAuto);
            this.groupBox9.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(512, 207);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(264, 203);
            this.groupBox9.TabIndex = 89;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Auto AutoSteer Button";
            // 
            // cboxAutoSteerAuto
            // 
            this.cboxAutoSteerAuto.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxAutoSteerAuto.AutoSize = true;
            this.cboxAutoSteerAuto.FlatAppearance.BorderSize = 3;
            this.cboxAutoSteerAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxAutoSteerAuto.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxAutoSteerAuto.Image = global::AgOpenGPS.Properties.Resources.AutoSteerOn;
            this.cboxAutoSteerAuto.Location = new System.Drawing.Point(76, 61);
            this.cboxAutoSteerAuto.Name = "cboxAutoSteerAuto";
            this.cboxAutoSteerAuto.Size = new System.Drawing.Size(86, 96);
            this.cboxAutoSteerAuto.TabIndex = 0;
            this.cboxAutoSteerAuto.Text = "Manual";
            this.cboxAutoSteerAuto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cboxAutoSteerAuto.UseVisualStyleBackColor = true;
            this.cboxAutoSteerAuto.CheckedChanged += new System.EventHandler(this.CboxAutoSteerAuto_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.nudSnapDistanceSmall);
            this.groupBox8.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.groupBox8.Location = new System.Drawing.Point(61, 65);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(274, 142);
            this.groupBox8.TabIndex = 68;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Small Snap Distance (cm)";
            // 
            // nudSnapDistanceSmall
            // 
            this.nudSnapDistanceSmall.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSnapDistanceSmall.Location = new System.Drawing.Point(23, 40);
            this.nudSnapDistanceSmall.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudSnapDistanceSmall.Name = "nudSnapDistanceSmall";
            this.nudSnapDistanceSmall.Size = new System.Drawing.Size(184, 85);
            this.nudSnapDistanceSmall.TabIndex = 66;
            this.nudSnapDistanceSmall.Value = new decimal(new int[] {
            499,
            0,
            0,
            0});
            this.nudSnapDistanceSmall.ValueChanged += new System.EventHandler(this.nudSnapDistanceSmall_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudSnapDistance);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.groupBox1.Location = new System.Drawing.Point(61, 268);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 142);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Snap Distance (cm)";
            // 
            // nudSnapDistance
            // 
            this.nudSnapDistance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSnapDistance.Location = new System.Drawing.Point(23, 40);
            this.nudSnapDistance.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudSnapDistance.Name = "nudSnapDistance";
            this.nudSnapDistance.Size = new System.Drawing.Size(184, 85);
            this.nudSnapDistance.TabIndex = 66;
            this.nudSnapDistance.Value = new decimal(new int[] {
            499,
            0,
            0,
            0});
            this.nudSnapDistance.ValueChanged += new System.EventHandler(this.nudSnapDistance_ValueChanged);
            // 
            // FormDisplaySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 731);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.bntOK);
            this.Name = "FormDisplaySettings";
            this.ShowInTaskbar = false;
            this.Text = "FormDisplaySettings";
            this.Load += new System.EventHandler(this.FormDisplaySettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabIMU.ResumeLayout(false);
            this.tabIMU.PerformLayout();
            this.headingGroupBox.ResumeLayout(false);
            this.headingGroupBox.PerformLayout();
            this.btnRollZero.ResumeLayout(false);
            this.btnRollZero.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabDisplay.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLightbarCmPerPixel)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoundaryDistance)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTriangleResolution)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinFixStepDistance)).EndInit();
            this.tabGuidance.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSnapDistanceSmall)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSnapDistance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDisplay;
        private System.Windows.Forms.NumericUpDown nudLightbarCmPerPixel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.NumericUpDown nudBoundaryDistance;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudTriangleResolution;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown nudMinFixStepDistance;
        private System.Windows.Forms.TabPage tabGuidance;
        private System.Windows.Forms.TabPage tabIMU;
        private System.Windows.Forms.GroupBox headingGroupBox;
        private System.Windows.Forms.GroupBox btnRollZero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemoveZeroOffsetPitch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnZeroPitch;
        private System.Windows.Forms.Button btnRemoveZeroOffset;
        private System.Windows.Forms.Label lblRollZeroOffset;
        private System.Windows.Forms.Button btnZeroRoll;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox cboxHeadingPAOGI;
        private System.Windows.Forms.CheckBox cboxHeadingAutoSteer;
        private System.Windows.Forms.CheckBox cboxHeadingBrick;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox cboxRollFromGPS;
        private System.Windows.Forms.CheckBox cboxRollAutoSteer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tboxTinkerUID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtnHeadingHDT;
        private System.Windows.Forms.RadioButton rbtnHeadingGPS;
        private System.Windows.Forms.RadioButton rbtnHeadingFix;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudSnapDistance;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.NumericUpDown nudSnapDistanceSmall;
        private System.Windows.Forms.CheckBox cboxHeadingExtUDP;
        private System.Windows.Forms.CheckBox cboxRollExtUDP;
        private System.Windows.Forms.CheckBox cboxRollFromBrick;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox cboxAutoSteerAuto;
    }
}