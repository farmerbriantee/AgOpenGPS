namespace AgOpenGPS
{
    partial class FormIMU
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
            this.headingGroupBox = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rbtnHeadingHDT = new System.Windows.Forms.RadioButton();
            this.rbtnHeadingGPS = new System.Windows.Forms.RadioButton();
            this.rbtnHeadingFix = new System.Windows.Forms.RadioButton();
            this.btnRollZero = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.nudMinFixStepDistance = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bntOK = new System.Windows.Forms.Button();
            this.headingGroupBox.SuspendLayout();
            this.btnRollZero.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinFixStepDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // headingGroupBox
            // 
            this.headingGroupBox.Controls.Add(this.label13);
            this.headingGroupBox.Controls.Add(this.label12);
            this.headingGroupBox.Controls.Add(this.label11);
            this.headingGroupBox.Controls.Add(this.rbtnHeadingHDT);
            this.headingGroupBox.Controls.Add(this.rbtnHeadingGPS);
            this.headingGroupBox.Controls.Add(this.rbtnHeadingFix);
            this.headingGroupBox.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingGroupBox.Location = new System.Drawing.Point(706, 36);
            this.headingGroupBox.Name = "headingGroupBox";
            this.headingGroupBox.Size = new System.Drawing.Size(262, 293);
            this.headingGroupBox.TabIndex = 84;
            this.headingGroupBox.TabStop = false;
            this.headingGroupBox.Text = "GPS Heading From";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(115, 196);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 45);
            this.label13.TabIndex = 88;
            this.label13.Text = "Dual Antenna";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(115, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 45);
            this.label12.TabIndex = 87;
            this.label12.Text = "From VTG or RMC ";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(115, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 45);
            this.label11.TabIndex = 86;
            this.label11.Text = "Fix to Fix Calc";
            // 
            // rbtnHeadingHDT
            // 
            this.rbtnHeadingHDT.AutoSize = true;
            this.rbtnHeadingHDT.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHeadingHDT.Location = new System.Drawing.Point(22, 189);
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
            this.rbtnHeadingGPS.Location = new System.Drawing.Point(22, 122);
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
            this.btnRollZero.Controls.Add(this.btnRemoveZeroOffsetPitch);
            this.btnRollZero.Controls.Add(this.label1);
            this.btnRollZero.Controls.Add(this.btnZeroPitch);
            this.btnRollZero.Controls.Add(this.btnRemoveZeroOffset);
            this.btnRollZero.Controls.Add(this.lblRollZeroOffset);
            this.btnRollZero.Controls.Add(this.btnZeroRoll);
            this.btnRollZero.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRollZero.Location = new System.Drawing.Point(18, 360);
            this.btnRollZero.Name = "btnRollZero";
            this.btnRollZero.Size = new System.Drawing.Size(242, 179);
            this.btnRollZero.TabIndex = 83;
            this.btnRollZero.TabStop = false;
            this.btnRollZero.Text = "Roll Zero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(204, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 84;
            this.label2.Text = "Pitch";
            // 
            // btnRemoveZeroOffsetPitch
            // 
            this.btnRemoveZeroOffsetPitch.Enabled = false;
            this.btnRemoveZeroOffsetPitch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveZeroOffsetPitch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemoveZeroOffsetPitch.Location = new System.Drawing.Point(12, 242);
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
            this.label1.Location = new System.Drawing.Point(99, 251);
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
            this.btnZeroPitch.Location = new System.Drawing.Point(207, 242);
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
            this.btnRemoveZeroOffset.Location = new System.Drawing.Point(12, 41);
            this.btnRemoveZeroOffset.Name = "btnRemoveZeroOffset";
            this.btnRemoveZeroOffset.Size = new System.Drawing.Size(79, 49);
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
            this.lblRollZeroOffset.Location = new System.Drawing.Point(127, 120);
            this.lblRollZeroOffset.Name = "lblRollZeroOffset";
            this.lblRollZeroOffset.Size = new System.Drawing.Size(100, 33);
            this.lblRollZeroOffset.TabIndex = 75;
            this.lblRollZeroOffset.Text = "label11";
            // 
            // btnZeroRoll
            // 
            this.btnZeroRoll.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroRoll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZeroRoll.Location = new System.Drawing.Point(6, 111);
            this.btnZeroRoll.Name = "btnZeroRoll";
            this.btnZeroRoll.Size = new System.Drawing.Size(103, 48);
            this.btnZeroRoll.TabIndex = 73;
            this.btnZeroRoll.Text = "> 0 <";
            this.btnZeroRoll.UseVisualStyleBackColor = true;
            this.btnZeroRoll.Click += new System.EventHandler(this.btnZeroRoll_Click);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(77, 567);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(461, 69);
            this.label10.TabIndex = 82;
            this.label10.Text = "*ALL Settings Require Restart";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cboxRollExtUDP);
            this.groupBox6.Controls.Add(this.cboxRollFromBrick);
            this.groupBox6.Controls.Add(this.cboxRollFromGPS);
            this.groupBox6.Controls.Add(this.cboxRollAutoSteer);
            this.groupBox6.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(18, 36);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(288, 293);
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
            this.cboxRollExtUDP.Location = new System.Drawing.Point(12, 170);
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
            this.cboxRollFromBrick.Location = new System.Drawing.Point(12, 116);
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
            this.cboxRollFromGPS.Location = new System.Drawing.Point(12, 224);
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
            this.cboxRollAutoSteer.Location = new System.Drawing.Point(12, 62);
            this.cboxRollAutoSteer.Name = "cboxRollAutoSteer";
            this.cboxRollAutoSteer.Size = new System.Drawing.Size(186, 35);
            this.cboxRollAutoSteer.TabIndex = 72;
            this.cboxRollAutoSteer.Text = "From AutoSteer";
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
            this.groupBox7.Location = new System.Drawing.Point(362, 36);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(288, 293);
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
            this.cboxHeadingExtUDP.Location = new System.Drawing.Point(16, 170);
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
            this.cboxHeadingPAOGI.Location = new System.Drawing.Point(16, 224);
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
            this.cboxHeadingAutoSteer.Location = new System.Drawing.Point(16, 62);
            this.cboxHeadingAutoSteer.Name = "cboxHeadingAutoSteer";
            this.cboxHeadingAutoSteer.Size = new System.Drawing.Size(186, 35);
            this.cboxHeadingAutoSteer.TabIndex = 69;
            this.cboxHeadingAutoSteer.Text = "From AutoSteer";
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
            this.cboxHeadingBrick.Location = new System.Drawing.Point(16, 116);
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
            this.label9.Location = new System.Drawing.Point(370, 348);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 23);
            this.label9.TabIndex = 79;
            this.label9.Text = "IMU Brick v2 UID";
            // 
            // tboxTinkerUID
            // 
            this.tboxTinkerUID.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.tboxTinkerUID.Location = new System.Drawing.Point(373, 375);
            this.tboxTinkerUID.Name = "tboxTinkerUID";
            this.tboxTinkerUID.Size = new System.Drawing.Size(169, 33);
            this.tboxTinkerUID.TabIndex = 78;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.nudMinFixStepDistance);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.groupBox1.Location = new System.Drawing.Point(642, 355);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 178);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fix To Fix Distance";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.label35.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label35.Location = new System.Drawing.Point(192, 115);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(94, 29);
            this.label35.TabIndex = 67;
            this.label35.Text = "Meters";
            // 
            // nudMinFixStepDistance
            // 
            this.nudMinFixStepDistance.BackColor = System.Drawing.Color.AliceBlue;
            this.nudMinFixStepDistance.DecimalPlaces = 1;
            this.nudMinFixStepDistance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinFixStepDistance.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudMinFixStepDistance.InterceptArrowKeys = false;
            this.nudMinFixStepDistance.Location = new System.Drawing.Point(23, 62);
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
            this.nudMinFixStepDistance.ValueChanged += new System.EventHandler(this.NudMinFixStepDistance_ValueChanged);
            this.nudMinFixStepDistance.Enter += new System.EventHandler(this.NudMinFixStepDistance_Enter);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(673, 564);
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
            this.bntOK.Location = new System.Drawing.Point(809, 564);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(156, 72);
            this.bntOK.TabIndex = 4;
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // FormIMU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(984, 648);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.headingGroupBox);
            this.Controls.Add(this.btnRollZero);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.bntOK);
            this.Controls.Add(this.tboxTinkerUID);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIMU";
            this.ShowInTaskbar = false;
            this.Text = "FormDisplaySettings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormDisplaySettings_Load);
            this.headingGroupBox.ResumeLayout(false);
            this.headingGroupBox.PerformLayout();
            this.btnRollZero.ResumeLayout(false);
            this.btnRollZero.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinFixStepDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.GroupBox headingGroupBox;
        private System.Windows.Forms.GroupBox btnRollZero;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.RadioButton rbtnHeadingHDT;
        private System.Windows.Forms.RadioButton rbtnHeadingGPS;
        private System.Windows.Forms.RadioButton rbtnHeadingFix;
        private System.Windows.Forms.CheckBox cboxHeadingExtUDP;
        private System.Windows.Forms.CheckBox cboxRollExtUDP;
        private System.Windows.Forms.CheckBox cboxRollFromBrick;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.NumericUpDown nudMinFixStepDistance;
    }
}