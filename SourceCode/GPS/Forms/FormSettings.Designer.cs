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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.gboxAttachment = new System.Windows.Forms.GroupBox();
            this.rbtnHarvester = new System.Windows.Forms.RadioButton();
            this.rbtn4WD = new System.Windows.Forms.RadioButton();
            this.btnChangeAttachment = new System.Windows.Forms.Button();
            this.rbtnTractor = new System.Windows.Forms.RadioButton();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.nudAntennaHeight = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudWheelbase = new System.Windows.Forms.NumericUpDown();
            this.nudAntennaPivot = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.nudAntennaOffset = new System.Windows.Forms.NumericUpDown();
            this.tabVehicle = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudHydLiftSecs = new System.Windows.Forms.NumericUpDown();
            this.nudMinTurnRadius = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabGuidance = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nudLineWidth = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudLightbarCmPerPixel = new System.Windows.Forms.NumericUpDown();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cboxAutoSteerAuto = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudSnapDistance = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.lblInchesCm = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bntOK = new System.Windows.Forms.Button();
            this.cboxIsAutoLiftOn = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.gboxAttachment.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAntennaHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWheelbase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAntennaPivot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAntennaOffset)).BeginInit();
            this.tabVehicle.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHydLiftSecs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinTurnRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabGuidance.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLightbarCmPerPixel)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSnapDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabConfig);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabVehicle);
            this.tabControl1.Controls.Add(this.tabGuidance);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 69);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(978, 618);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 2;
            // 
            // tabConfig
            // 
            this.tabConfig.BackColor = System.Drawing.SystemColors.Control;
            this.tabConfig.Controls.Add(this.gboxAttachment);
            this.tabConfig.Location = new System.Drawing.Point(4, 73);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(970, 541);
            this.tabConfig.TabIndex = 14;
            this.tabConfig.Text = "Configuration";
            // 
            // gboxAttachment
            // 
            this.gboxAttachment.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gboxAttachment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gboxAttachment.Controls.Add(this.rbtnHarvester);
            this.gboxAttachment.Controls.Add(this.rbtn4WD);
            this.gboxAttachment.Controls.Add(this.btnChangeAttachment);
            this.gboxAttachment.Controls.Add(this.rbtnTractor);
            this.gboxAttachment.Location = new System.Drawing.Point(35, 38);
            this.gboxAttachment.Name = "gboxAttachment";
            this.gboxAttachment.Size = new System.Drawing.Size(871, 483);
            this.gboxAttachment.TabIndex = 111;
            this.gboxAttachment.TabStop = false;
            this.gboxAttachment.Text = "Vehicle Type";
            // 
            // rbtnHarvester
            // 
            this.rbtnHarvester.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnHarvester.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbtnHarvester.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnHarvester.FlatAppearance.BorderSize = 0;
            this.rbtnHarvester.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbtnHarvester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnHarvester.Image = global::AgOpenGPS.Properties.Resources.vehiclePageHarvester;
            this.rbtnHarvester.Location = new System.Drawing.Point(49, 278);
            this.rbtnHarvester.Name = "rbtnHarvester";
            this.rbtnHarvester.Size = new System.Drawing.Size(321, 183);
            this.rbtnHarvester.TabIndex = 253;
            this.rbtnHarvester.TabStop = true;
            this.rbtnHarvester.UseVisualStyleBackColor = true;
            this.rbtnHarvester.CheckedChanged += new System.EventHandler(this.rbtn4WD_CheckedChanged);
            // 
            // rbtn4WD
            // 
            this.rbtn4WD.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtn4WD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbtn4WD.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtn4WD.FlatAppearance.BorderSize = 0;
            this.rbtn4WD.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbtn4WD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtn4WD.Image = global::AgOpenGPS.Properties.Resources.vehiclePage4WD;
            this.rbtn4WD.Location = new System.Drawing.Point(49, 53);
            this.rbtn4WD.Name = "rbtn4WD";
            this.rbtn4WD.Size = new System.Drawing.Size(321, 183);
            this.rbtn4WD.TabIndex = 252;
            this.rbtn4WD.TabStop = true;
            this.rbtn4WD.UseVisualStyleBackColor = true;
            this.rbtn4WD.CheckedChanged += new System.EventHandler(this.rbtn4WD_CheckedChanged);
            // 
            // btnChangeAttachment
            // 
            this.btnChangeAttachment.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeAttachment.Image = global::AgOpenGPS.Properties.Resources.ToolAcceptChange;
            this.btnChangeAttachment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnChangeAttachment.Location = new System.Drawing.Point(611, 316);
            this.btnChangeAttachment.Name = "btnChangeAttachment";
            this.btnChangeAttachment.Size = new System.Drawing.Size(170, 106);
            this.btnChangeAttachment.TabIndex = 251;
            this.btnChangeAttachment.UseVisualStyleBackColor = false;
            this.btnChangeAttachment.Click += new System.EventHandler(this.btnChangeAttachment_Click);
            // 
            // rbtnTractor
            // 
            this.rbtnTractor.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnTractor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbtnTractor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnTractor.FlatAppearance.BorderSize = 0;
            this.rbtnTractor.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbtnTractor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnTractor.Image = global::AgOpenGPS.Properties.Resources.vehiclePageTractor;
            this.rbtnTractor.Location = new System.Drawing.Point(460, 53);
            this.rbtnTractor.Name = "rbtnTractor";
            this.rbtnTractor.Size = new System.Drawing.Size(321, 183);
            this.rbtnTractor.TabIndex = 112;
            this.rbtnTractor.TabStop = true;
            this.rbtnTractor.UseVisualStyleBackColor = true;
            this.rbtnTractor.CheckedChanged += new System.EventHandler(this.rbtn4WD_CheckedChanged);
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.SystemColors.Window;
            this.tabSettings.BackgroundImage = global::AgOpenGPS.Properties.Resources.VehicleSettingsTractor;
            this.tabSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabSettings.Controls.Add(this.btnNext);
            this.tabSettings.Controls.Add(this.label9);
            this.tabSettings.Controls.Add(this.nudAntennaHeight);
            this.tabSettings.Controls.Add(this.label26);
            this.tabSettings.Controls.Add(this.label15);
            this.tabSettings.Controls.Add(this.label7);
            this.tabSettings.Controls.Add(this.nudWheelbase);
            this.tabSettings.Controls.Add(this.nudAntennaPivot);
            this.tabSettings.Controls.Add(this.label18);
            this.tabSettings.Controls.Add(this.nudAntennaOffset);
            this.tabSettings.Location = new System.Drawing.Point(4, 73);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(970, 541);
            this.tabSettings.TabIndex = 11;
            this.tabSettings.Text = "Settings";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(863, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(104, 49);
            this.btnNext.TabIndex = 0;
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Window;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(670, 392);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label9.Size = new System.Drawing.Size(216, 23);
            this.label9.TabIndex = 28;
            this.label9.Text = "*Left is negative";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudAntennaHeight
            // 
            this.nudAntennaHeight.BackColor = System.Drawing.Color.AliceBlue;
            this.nudAntennaHeight.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAntennaHeight.InterceptArrowKeys = false;
            this.nudAntennaHeight.Location = new System.Drawing.Point(710, 180);
            this.nudAntennaHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudAntennaHeight.Name = "nudAntennaHeight";
            this.nudAntennaHeight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudAntennaHeight.Size = new System.Drawing.Size(144, 65);
            this.nudAntennaHeight.TabIndex = 5;
            this.nudAntennaHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudAntennaHeight.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudAntennaHeight.ValueChanged += new System.EventHandler(this.nudAntennaHeight_ValueChanged);
            this.nudAntennaHeight.Enter += new System.EventHandler(this.NudAntennaHeight_Enter);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(457, 480);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(134, 51);
            this.label26.TabIndex = 13;
            this.label26.Text = "Wheelbase";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.Window;
            this.label15.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(670, 154);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(216, 23);
            this.label15.TabIndex = 21;
            this.label15.Text = "Height";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Window;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(670, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(216, 23);
            this.label7.TabIndex = 27;
            this.label7.Text = "Offset";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudWheelbase
            // 
            this.nudWheelbase.BackColor = System.Drawing.Color.AliceBlue;
            this.nudWheelbase.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWheelbase.InterceptArrowKeys = false;
            this.nudWheelbase.Location = new System.Drawing.Point(292, 470);
            this.nudWheelbase.Maximum = new decimal(new int[] {
            1999,
            0,
            0,
            0});
            this.nudWheelbase.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudWheelbase.Name = "nudWheelbase";
            this.nudWheelbase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudWheelbase.Size = new System.Drawing.Size(152, 65);
            this.nudWheelbase.TabIndex = 6;
            this.nudWheelbase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudWheelbase.Value = new decimal(new int[] {
            501,
            0,
            0,
            0});
            this.nudWheelbase.ValueChanged += new System.EventHandler(this.nudWheelbase_ValueChanged);
            this.nudWheelbase.Enter += new System.EventHandler(this.NudWheelbase_Enter);
            // 
            // nudAntennaPivot
            // 
            this.nudAntennaPivot.BackColor = System.Drawing.Color.AliceBlue;
            this.nudAntennaPivot.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAntennaPivot.InterceptArrowKeys = false;
            this.nudAntennaPivot.Location = new System.Drawing.Point(292, 22);
            this.nudAntennaPivot.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudAntennaPivot.Name = "nudAntennaPivot";
            this.nudAntennaPivot.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudAntennaPivot.Size = new System.Drawing.Size(144, 65);
            this.nudAntennaPivot.TabIndex = 3;
            this.nudAntennaPivot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudAntennaPivot.Value = new decimal(new int[] {
            111,
            0,
            0,
            0});
            this.nudAntennaPivot.ValueChanged += new System.EventHandler(this.nudAntennaPivot_ValueChanged);
            this.nudAntennaPivot.Enter += new System.EventHandler(this.NudAntennaPivot_Enter);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.Window;
            this.label18.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(442, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 56);
            this.label18.TabIndex = 8;
            this.label18.Text = "Distance";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudAntennaOffset
            // 
            this.nudAntennaOffset.BackColor = System.Drawing.Color.AliceBlue;
            this.nudAntennaOffset.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAntennaOffset.InterceptArrowKeys = false;
            this.nudAntennaOffset.Location = new System.Drawing.Point(710, 319);
            this.nudAntennaOffset.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudAntennaOffset.Name = "nudAntennaOffset";
            this.nudAntennaOffset.Size = new System.Drawing.Size(144, 65);
            this.nudAntennaOffset.TabIndex = 26;
            this.nudAntennaOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudAntennaOffset.ValueChanged += new System.EventHandler(this.nudAntennaOffset_ValueChanged);
            this.nudAntennaOffset.Enter += new System.EventHandler(this.NudAntennaOffset_Enter);
            // 
            // tabVehicle
            // 
            this.tabVehicle.BackColor = System.Drawing.SystemColors.Window;
            this.tabVehicle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabVehicle.Controls.Add(this.groupBox3);
            this.tabVehicle.Controls.Add(this.nudMinTurnRadius);
            this.tabVehicle.Controls.Add(this.pictureBox1);
            this.tabVehicle.Controls.Add(this.label6);
            this.tabVehicle.Location = new System.Drawing.Point(4, 73);
            this.tabVehicle.Margin = new System.Windows.Forms.Padding(4);
            this.tabVehicle.Name = "tabVehicle";
            this.tabVehicle.Padding = new System.Windows.Forms.Padding(4);
            this.tabVehicle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabVehicle.Size = new System.Drawing.Size(970, 541);
            this.tabVehicle.TabIndex = 1;
            this.tabVehicle.Text = "  Vehicle ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboxIsAutoLiftOn);
            this.groupBox3.Controls.Add(this.nudHydLiftSecs);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(395, 36);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 172);
            this.groupBox3.TabIndex = 125;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hydraulic Lift Look Ahead (secs)";
            // 
            // nudHydLiftSecs
            // 
            this.nudHydLiftSecs.BackColor = System.Drawing.Color.AliceBlue;
            this.nudHydLiftSecs.DecimalPlaces = 1;
            this.nudHydLiftSecs.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHydLiftSecs.InterceptArrowKeys = false;
            this.nudHydLiftSecs.Location = new System.Drawing.Point(228, 65);
            this.nudHydLiftSecs.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudHydLiftSecs.Name = "nudHydLiftSecs";
            this.nudHydLiftSecs.Size = new System.Drawing.Size(148, 65);
            this.nudHydLiftSecs.TabIndex = 117;
            this.nudHydLiftSecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudHydLiftSecs.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudHydLiftSecs.Enter += new System.EventHandler(this.nudHydLiftSecs_Enter);
            // 
            // nudMinTurnRadius
            // 
            this.nudMinTurnRadius.BackColor = System.Drawing.Color.AliceBlue;
            this.nudMinTurnRadius.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinTurnRadius.InterceptArrowKeys = false;
            this.nudMinTurnRadius.Location = new System.Drawing.Point(96, 255);
            this.nudMinTurnRadius.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudMinTurnRadius.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudMinTurnRadius.Name = "nudMinTurnRadius";
            this.nudMinTurnRadius.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudMinTurnRadius.Size = new System.Drawing.Size(152, 65);
            this.nudMinTurnRadius.TabIndex = 24;
            this.nudMinTurnRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMinTurnRadius.Value = new decimal(new int[] {
            301,
            0,
            0,
            0});
            this.nudMinTurnRadius.ValueChanged += new System.EventHandler(this.nudMinTurnRadius_ValueChanged);
            this.nudMinTurnRadius.Enter += new System.EventHandler(this.NudMinTurnRadius_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AgOpenGPS.Properties.Resources.tire;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(64, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(96, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 47);
            this.label6.TabIndex = 25;
            this.label6.Text = "Turn Radius";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabGuidance
            // 
            this.tabGuidance.BackColor = System.Drawing.SystemColors.Window;
            this.tabGuidance.Controls.Add(this.groupBox4);
            this.tabGuidance.Controls.Add(this.groupBox2);
            this.tabGuidance.Controls.Add(this.groupBox9);
            this.tabGuidance.Controls.Add(this.groupBox1);
            this.tabGuidance.Location = new System.Drawing.Point(4, 73);
            this.tabGuidance.Name = "tabGuidance";
            this.tabGuidance.Padding = new System.Windows.Forms.Padding(3);
            this.tabGuidance.Size = new System.Drawing.Size(970, 541);
            this.tabGuidance.TabIndex = 13;
            this.tabGuidance.Text = " Guidance ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nudLineWidth);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(714, 59);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(232, 172);
            this.groupBox4.TabIndex = 124;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Guidance Line Width";
            // 
            // nudLineWidth
            // 
            this.nudLineWidth.BackColor = System.Drawing.Color.AliceBlue;
            this.nudLineWidth.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLineWidth.InterceptArrowKeys = false;
            this.nudLineWidth.Location = new System.Drawing.Point(44, 76);
            this.nudLineWidth.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLineWidth.Name = "nudLineWidth";
            this.nudLineWidth.Size = new System.Drawing.Size(148, 65);
            this.nudLineWidth.TabIndex = 118;
            this.nudLineWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLineWidth.Enter += new System.EventHandler(this.nudLineWidth_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudLightbarCmPerPixel);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(394, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 172);
            this.groupBox2.TabIndex = 123;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "cm / Lightbar Pixel";
            // 
            // nudLightbarCmPerPixel
            // 
            this.nudLightbarCmPerPixel.BackColor = System.Drawing.Color.AliceBlue;
            this.nudLightbarCmPerPixel.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLightbarCmPerPixel.InterceptArrowKeys = false;
            this.nudLightbarCmPerPixel.Location = new System.Drawing.Point(26, 73);
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
            this.nudLightbarCmPerPixel.Size = new System.Drawing.Size(148, 65);
            this.nudLightbarCmPerPixel.TabIndex = 117;
            this.nudLightbarCmPerPixel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudLightbarCmPerPixel.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudLightbarCmPerPixel.ValueChanged += new System.EventHandler(this.NudLightbarCmPerPixel_ValueChanged);
            this.nudLightbarCmPerPixel.Enter += new System.EventHandler(this.NudLightbarCmPerPixel_Enter);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cboxAutoSteerAuto);
            this.groupBox9.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(714, 288);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(232, 192);
            this.groupBox9.TabIndex = 92;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Auto/Manual AutoSteer Button";
            // 
            // cboxAutoSteerAuto
            // 
            this.cboxAutoSteerAuto.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxAutoSteerAuto.FlatAppearance.BorderSize = 3;
            this.cboxAutoSteerAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxAutoSteerAuto.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxAutoSteerAuto.Image = global::AgOpenGPS.Properties.Resources.AutoSteerOn;
            this.cboxAutoSteerAuto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cboxAutoSteerAuto.Location = new System.Drawing.Point(58, 66);
            this.cboxAutoSteerAuto.Name = "cboxAutoSteerAuto";
            this.cboxAutoSteerAuto.Size = new System.Drawing.Size(98, 103);
            this.cboxAutoSteerAuto.TabIndex = 0;
            this.cboxAutoSteerAuto.Text = "Manual";
            this.cboxAutoSteerAuto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cboxAutoSteerAuto.UseVisualStyleBackColor = true;
            this.cboxAutoSteerAuto.CheckedChanged += new System.EventHandler(this.CboxAutoSteerAuto_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudSnapDistance);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.groupBox1.Location = new System.Drawing.Point(34, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 168);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "<< >> Snap Distance";
            // 
            // nudSnapDistance
            // 
            this.nudSnapDistance.BackColor = System.Drawing.Color.AliceBlue;
            this.nudSnapDistance.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSnapDistance.InterceptArrowKeys = false;
            this.nudSnapDistance.Location = new System.Drawing.Point(23, 73);
            this.nudSnapDistance.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudSnapDistance.Name = "nudSnapDistance";
            this.nudSnapDistance.Size = new System.Drawing.Size(184, 65);
            this.nudSnapDistance.TabIndex = 66;
            this.nudSnapDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSnapDistance.Value = new decimal(new int[] {
            499,
            0,
            0,
            0});
            this.nudSnapDistance.ValueChanged += new System.EventHandler(this.NudSnapDistance_ValueChanged);
            this.nudSnapDistance.Enter += new System.EventHandler(this.NudSnapDistance_Enter);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(23, 622);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(153, 23);
            this.label17.TabIndex = 89;
            this.label17.Text = "Measurements in";
            // 
            // lblInchesCm
            // 
            this.lblInchesCm.AutoSize = true;
            this.lblInchesCm.Font = new System.Drawing.Font("Tahoma", 24F);
            this.lblInchesCm.ForeColor = System.Drawing.Color.Red;
            this.lblInchesCm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblInchesCm.Location = new System.Drawing.Point(65, 653);
            this.lblInchesCm.Name = "lblInchesCm";
            this.lblInchesCm.Size = new System.Drawing.Size(111, 39);
            this.lblInchesCm.TabIndex = 109;
            this.lblInchesCm.Text = "Inches";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(687, 626);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 68);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bntOK
            // 
            this.bntOK.BackColor = System.Drawing.Color.Transparent;
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntOK.Location = new System.Drawing.Point(820, 626);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(156, 68);
            this.bntOK.TabIndex = 0;
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = false;
            this.bntOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cboxIsAutoLiftOn
            // 
            this.cboxIsAutoLiftOn.AutoSize = true;
            this.cboxIsAutoLiftOn.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxIsAutoLiftOn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxIsAutoLiftOn.Checked = true;
            this.cboxIsAutoLiftOn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxIsAutoLiftOn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsAutoLiftOn.Location = new System.Drawing.Point(27, 83);
            this.cboxIsAutoLiftOn.Name = "cboxIsAutoLiftOn";
            this.cboxIsAutoLiftOn.Size = new System.Drawing.Size(144, 29);
            this.cboxIsAutoLiftOn.TabIndex = 92;
            this.cboxIsAutoLiftOn.Text = "Auto Lift On";
            this.cboxIsAutoLiftOn.UseVisualStyleBackColor = false;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(987, 700);
            this.ControlBox = false;
            this.Controls.Add(this.lblInchesCm);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.bntOK);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            this.gboxAttachment.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudAntennaHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWheelbase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAntennaPivot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAntennaOffset)).EndInit();
            this.tabVehicle.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHydLiftSecs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinTurnRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabGuidance.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLightbarCmPerPixel)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSnapDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabVehicle;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudAntennaHeight;
        private System.Windows.Forms.NumericUpDown nudAntennaPivot;
        private System.Windows.Forms.NumericUpDown nudWheelbase;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblInchesCm;
        private System.Windows.Forms.NumericUpDown nudMinTurnRadius;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudAntennaOffset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabGuidance;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox cboxAutoSteerAuto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudSnapDistance;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudLightbarCmPerPixel;
        private System.Windows.Forms.NumericUpDown nudLineWidth;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.GroupBox gboxAttachment;
        private System.Windows.Forms.Button btnChangeAttachment;
        private System.Windows.Forms.RadioButton rbtnTractor;
        private System.Windows.Forms.RadioButton rbtnHarvester;
        private System.Windows.Forms.RadioButton rbtn4WD;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudHydLiftSecs;
        private System.Windows.Forms.CheckBox cboxIsAutoLiftOn;
    }
}