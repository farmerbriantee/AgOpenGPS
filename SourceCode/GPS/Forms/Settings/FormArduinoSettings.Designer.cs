namespace AgOpenGPS
{
    partial class FormArduinoSettings
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
            this.label2 = new System.Windows.Forms.Label();
            this.cboxInclinometer = new System.Windows.Forms.ComboBox();
            this.cboxConv = new System.Windows.Forms.ComboBox();
            this.cboxEncoder = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudMinSpeed = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMaxSpeed = new System.Windows.Forms.NumericUpDown();
            this.chkInvertRoll = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboxMMAAxis = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxSteerEnable = new System.Windows.Forms.ComboBox();
            this.chkBNOInstalled = new System.Windows.Forms.CheckBox();
            this.chkInvertSteer = new System.Windows.Forms.CheckBox();
            this.chkInvertWAS = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxMotorDrive = new System.Windows.Forms.ComboBox();
            this.btnChangeAttachment = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.nudMaxCounts = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.tboxSerialFromAutoSteer = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabcArduino = new System.Windows.Forms.TabControl();
            this.tabAutoSteer = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.cboxSteerInvertRelays = new System.Windows.Forms.CheckBox();
            this.lblSent = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblRecd = new System.Windows.Forms.Label();
            this.nudAckerman = new System.Windows.Forms.NumericUpDown();
            this.tabMachine = new System.Windows.Forms.TabPage();
            this.cboxMachInvertRelays = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboxIsSendMachineControlToAutoSteer = new System.Windows.Forms.CheckBox();
            this.tboxSerialFromMachine = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudLowerTime = new System.Windows.Forms.NumericUpDown();
            this.nudRaiseTime = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cboxIsHydOn = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bntOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCounts)).BeginInit();
            this.tabcArduino.SuspendLayout();
            this.tabAutoSteer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAckerman)).BeginInit();
            this.tabMachine.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLowerTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRaiseTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 29);
            this.label2.TabIndex = 272;
            this.label2.Text = "Inclinometer";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cboxInclinometer
            // 
            this.cboxInclinometer.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxInclinometer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxInclinometer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxInclinometer.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxInclinometer.FormattingEnabled = true;
            this.cboxInclinometer.Items.AddRange(new object[] {
            "None",
            "DOGS2",
            "MMA (1C)",
            "MMA (1D)"});
            this.cboxInclinometer.Location = new System.Drawing.Point(18, 237);
            this.cboxInclinometer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxInclinometer.Name = "cboxInclinometer";
            this.cboxInclinometer.Size = new System.Drawing.Size(217, 37);
            this.cboxInclinometer.TabIndex = 271;
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
            this.cboxConv.Location = new System.Drawing.Point(17, 141);
            this.cboxConv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxConv.Name = "cboxConv";
            this.cboxConv.Size = new System.Drawing.Size(217, 37);
            this.cboxConv.TabIndex = 270;
            // 
            // cboxEncoder
            // 
            this.cboxEncoder.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxEncoder.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxEncoder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxEncoder.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxEncoder.Location = new System.Drawing.Point(634, 352);
            this.cboxEncoder.Name = "cboxEncoder";
            this.cboxEncoder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxEncoder.Size = new System.Drawing.Size(192, 70);
            this.cboxEncoder.TabIndex = 269;
            this.cboxEncoder.Text = "Turn Sensor";
            this.cboxEncoder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxEncoder.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(343, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 27);
            this.label8.TabIndex = 268;
            this.label8.Text = "Min Speed";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nudMinSpeed
            // 
            this.nudMinSpeed.BackColor = System.Drawing.Color.AliceBlue;
            this.nudMinSpeed.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinSpeed.InterceptArrowKeys = false;
            this.nudMinSpeed.Location = new System.Drawing.Point(357, 67);
            this.nudMinSpeed.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudMinSpeed.Name = "nudMinSpeed";
            this.nudMinSpeed.Size = new System.Drawing.Size(165, 52);
            this.nudMinSpeed.TabIndex = 267;
            this.nudMinSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMinSpeed.Enter += new System.EventHandler(this.nudMinSpeed_Enter);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(343, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 27);
            this.label4.TabIndex = 250;
            this.label4.Text = "Max Speed";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nudMaxSpeed
            // 
            this.nudMaxSpeed.BackColor = System.Drawing.Color.AliceBlue;
            this.nudMaxSpeed.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMaxSpeed.InterceptArrowKeys = false;
            this.nudMaxSpeed.Location = new System.Drawing.Point(357, 163);
            this.nudMaxSpeed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMaxSpeed.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudMaxSpeed.Name = "nudMaxSpeed";
            this.nudMaxSpeed.Size = new System.Drawing.Size(165, 52);
            this.nudMaxSpeed.TabIndex = 249;
            this.nudMaxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMaxSpeed.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudMaxSpeed.Enter += new System.EventHandler(this.nudMaxSpeed_Enter);
            // 
            // chkInvertRoll
            // 
            this.chkInvertRoll.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkInvertRoll.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkInvertRoll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkInvertRoll.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInvertRoll.Location = new System.Drawing.Point(634, 182);
            this.chkInvertRoll.Name = "chkInvertRoll";
            this.chkInvertRoll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkInvertRoll.Size = new System.Drawing.Size(192, 70);
            this.chkInvertRoll.TabIndex = 263;
            this.chkInvertRoll.Text = "Invert Roll";
            this.chkInvertRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkInvertRoll.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(12, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 29);
            this.label6.TabIndex = 262;
            this.label6.Text = "MMA Axis";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cboxMMAAxis
            // 
            this.cboxMMAAxis.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxMMAAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMMAAxis.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxMMAAxis.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxMMAAxis.FormattingEnabled = true;
            this.cboxMMAAxis.Items.AddRange(new object[] {
            "X Axis",
            "Y Axis"});
            this.cboxMMAAxis.Location = new System.Drawing.Point(17, 333);
            this.cboxMMAAxis.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxMMAAxis.Name = "cboxMMAAxis";
            this.cboxMMAAxis.Size = new System.Drawing.Size(217, 37);
            this.cboxMMAAxis.TabIndex = 261;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(14, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 29);
            this.label5.TabIndex = 260;
            this.label5.Text = "Steer Enable";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cboxSteerEnable
            // 
            this.cboxSteerEnable.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxSteerEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSteerEnable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxSteerEnable.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSteerEnable.FormattingEnabled = true;
            this.cboxSteerEnable.Items.AddRange(new object[] {
            "Button",
            "Switch"});
            this.cboxSteerEnable.Location = new System.Drawing.Point(16, 429);
            this.cboxSteerEnable.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxSteerEnable.Name = "cboxSteerEnable";
            this.cboxSteerEnable.Size = new System.Drawing.Size(217, 37);
            this.cboxSteerEnable.TabIndex = 259;
            // 
            // chkBNOInstalled
            // 
            this.chkBNOInstalled.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBNOInstalled.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkBNOInstalled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBNOInstalled.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBNOInstalled.Location = new System.Drawing.Point(634, 267);
            this.chkBNOInstalled.Name = "chkBNOInstalled";
            this.chkBNOInstalled.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBNOInstalled.Size = new System.Drawing.Size(192, 70);
            this.chkBNOInstalled.TabIndex = 258;
            this.chkBNOInstalled.Text = "BNO Installed";
            this.chkBNOInstalled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBNOInstalled.UseVisualStyleBackColor = true;
            // 
            // chkInvertSteer
            // 
            this.chkInvertSteer.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkInvertSteer.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkInvertSteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkInvertSteer.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInvertSteer.Location = new System.Drawing.Point(634, 97);
            this.chkInvertSteer.Name = "chkInvertSteer";
            this.chkInvertSteer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkInvertSteer.Size = new System.Drawing.Size(192, 70);
            this.chkInvertSteer.TabIndex = 257;
            this.chkInvertSteer.Text = "Invert Steer Motor";
            this.chkInvertSteer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkInvertSteer.UseVisualStyleBackColor = true;
            // 
            // chkInvertWAS
            // 
            this.chkInvertWAS.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkInvertWAS.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkInvertWAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkInvertWAS.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInvertWAS.Location = new System.Drawing.Point(634, 12);
            this.chkInvertWAS.Name = "chkInvertWAS";
            this.chkInvertWAS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkInvertWAS.Size = new System.Drawing.Size(192, 70);
            this.chkInvertWAS.TabIndex = 256;
            this.chkInvertWAS.Text = "Invert WAS\r\nline 2";
            this.chkInvertWAS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkInvertWAS.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 29);
            this.label3.TabIndex = 255;
            this.label3.Text = "A2D Convertor";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 29);
            this.label1.TabIndex = 253;
            this.label1.Text = "Motor Driver";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
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
            this.cboxMotorDrive.Location = new System.Drawing.Point(17, 45);
            this.cboxMotorDrive.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxMotorDrive.Name = "cboxMotorDrive";
            this.cboxMotorDrive.Size = new System.Drawing.Size(217, 37);
            this.cboxMotorDrive.TabIndex = 252;
            // 
            // btnChangeAttachment
            // 
            this.btnChangeAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeAttachment.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeAttachment.Image = global::AgOpenGPS.Properties.Resources.ToolAcceptChange;
            this.btnChangeAttachment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnChangeAttachment.Location = new System.Drawing.Point(747, 628);
            this.btnChangeAttachment.Name = "btnChangeAttachment";
            this.btnChangeAttachment.Size = new System.Drawing.Size(133, 62);
            this.btnChangeAttachment.TabIndex = 251;
            this.btnChangeAttachment.UseVisualStyleBackColor = false;
            this.btnChangeAttachment.Click += new System.EventHandler(this.btnSendToSteerArduino_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(333, 384);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(216, 29);
            this.label7.TabIndex = 274;
            this.label7.Text = "Turn Sensor";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nudMaxCounts
            // 
            this.nudMaxCounts.BackColor = System.Drawing.Color.AliceBlue;
            this.nudMaxCounts.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMaxCounts.InterceptArrowKeys = false;
            this.nudMaxCounts.Location = new System.Drawing.Point(357, 416);
            this.nudMaxCounts.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudMaxCounts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxCounts.Name = "nudMaxCounts";
            this.nudMaxCounts.Size = new System.Drawing.Size(165, 52);
            this.nudMaxCounts.TabIndex = 273;
            this.nudMaxCounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMaxCounts.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudMaxCounts.Enter += new System.EventHandler(this.nudMaxCounts_Enter);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(569, 628);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 62);
            this.label9.TabIndex = 275;
            this.label9.Text = "Send ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tboxSerialFromAutoSteer
            // 
            this.tboxSerialFromAutoSteer.BackColor = System.Drawing.SystemColors.Control;
            this.tboxSerialFromAutoSteer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSerialFromAutoSteer.Location = new System.Drawing.Point(7, 516);
            this.tboxSerialFromAutoSteer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tboxSerialFromAutoSteer.Name = "tboxSerialFromAutoSteer";
            this.tboxSerialFromAutoSteer.ReadOnly = true;
            this.tboxSerialFromAutoSteer.Size = new System.Drawing.Size(372, 27);
            this.tboxSerialFromAutoSteer.TabIndex = 314;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabcArduino
            // 
            this.tabcArduino.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabcArduino.Controls.Add(this.tabAutoSteer);
            this.tabcArduino.Controls.Add(this.tabMachine);
            this.tabcArduino.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabcArduino.ItemSize = new System.Drawing.Size(260, 50);
            this.tabcArduino.Location = new System.Drawing.Point(12, 12);
            this.tabcArduino.Name = "tabcArduino";
            this.tabcArduino.SelectedIndex = 0;
            this.tabcArduino.Size = new System.Drawing.Size(868, 610);
            this.tabcArduino.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabcArduino.TabIndex = 315;
            // 
            // tabAutoSteer
            // 
            this.tabAutoSteer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabAutoSteer.Controls.Add(this.label12);
            this.tabAutoSteer.Controls.Add(this.cboxSteerInvertRelays);
            this.tabAutoSteer.Controls.Add(this.lblSent);
            this.tabAutoSteer.Controls.Add(this.label13);
            this.tabAutoSteer.Controls.Add(this.lblRecd);
            this.tabAutoSteer.Controls.Add(this.nudAckerman);
            this.tabAutoSteer.Controls.Add(this.cboxMotorDrive);
            this.tabAutoSteer.Controls.Add(this.tboxSerialFromAutoSteer);
            this.tabAutoSteer.Controls.Add(this.cboxSteerEnable);
            this.tabAutoSteer.Controls.Add(this.label5);
            this.tabAutoSteer.Controls.Add(this.cboxMMAAxis);
            this.tabAutoSteer.Controls.Add(this.label7);
            this.tabAutoSteer.Controls.Add(this.cboxInclinometer);
            this.tabAutoSteer.Controls.Add(this.nudMaxCounts);
            this.tabAutoSteer.Controls.Add(this.label6);
            this.tabAutoSteer.Controls.Add(this.chkInvertRoll);
            this.tabAutoSteer.Controls.Add(this.cboxConv);
            this.tabAutoSteer.Controls.Add(this.label8);
            this.tabAutoSteer.Controls.Add(this.chkInvertSteer);
            this.tabAutoSteer.Controls.Add(this.nudMaxSpeed);
            this.tabAutoSteer.Controls.Add(this.label1);
            this.tabAutoSteer.Controls.Add(this.nudMinSpeed);
            this.tabAutoSteer.Controls.Add(this.cboxEncoder);
            this.tabAutoSteer.Controls.Add(this.label4);
            this.tabAutoSteer.Controls.Add(this.label3);
            this.tabAutoSteer.Controls.Add(this.chkInvertWAS);
            this.tabAutoSteer.Controls.Add(this.label2);
            this.tabAutoSteer.Controls.Add(this.chkBNOInstalled);
            this.tabAutoSteer.Location = new System.Drawing.Point(4, 54);
            this.tabAutoSteer.Name = "tabAutoSteer";
            this.tabAutoSteer.Padding = new System.Windows.Forms.Padding(3);
            this.tabAutoSteer.Size = new System.Drawing.Size(860, 552);
            this.tabAutoSteer.TabIndex = 0;
            this.tabAutoSteer.Text = "Auto Steer";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(415, 517);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 23);
            this.label12.TabIndex = 320;
            this.label12.Text = "Check:";
            // 
            // cboxSteerInvertRelays
            // 
            this.cboxSteerInvertRelays.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxSteerInvertRelays.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxSteerInvertRelays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxSteerInvertRelays.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSteerInvertRelays.Location = new System.Drawing.Point(634, 440);
            this.cboxSteerInvertRelays.Name = "cboxSteerInvertRelays";
            this.cboxSteerInvertRelays.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxSteerInvertRelays.Size = new System.Drawing.Size(192, 70);
            this.cboxSteerInvertRelays.TabIndex = 317;
            this.cboxSteerInvertRelays.Text = "Invert Relays";
            this.cboxSteerInvertRelays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxSteerInvertRelays.UseVisualStyleBackColor = true;
            // 
            // lblSent
            // 
            this.lblSent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSent.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSent.Location = new System.Drawing.Point(485, 517);
            this.lblSent.Name = "lblSent";
            this.lblSent.Size = new System.Drawing.Size(68, 26);
            this.lblSent.TabIndex = 319;
            this.lblSent.Text = "Sent";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(333, 271);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(216, 27);
            this.label13.TabIndex = 316;
            this.label13.Text = "Ackerman %";
            this.label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblRecd
            // 
            this.lblRecd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecd.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecd.Location = new System.Drawing.Point(565, 517);
            this.lblRecd.Name = "lblRecd";
            this.lblRecd.Size = new System.Drawing.Size(68, 26);
            this.lblRecd.TabIndex = 318;
            this.lblRecd.Text = "Recd";
            // 
            // nudAckerman
            // 
            this.nudAckerman.BackColor = System.Drawing.Color.AliceBlue;
            this.nudAckerman.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAckerman.InterceptArrowKeys = false;
            this.nudAckerman.Location = new System.Drawing.Point(357, 301);
            this.nudAckerman.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudAckerman.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudAckerman.Name = "nudAckerman";
            this.nudAckerman.Size = new System.Drawing.Size(165, 52);
            this.nudAckerman.TabIndex = 315;
            this.nudAckerman.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudAckerman.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudAckerman.Enter += new System.EventHandler(this.nudAckerman_Enter);
            // 
            // tabMachine
            // 
            this.tabMachine.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabMachine.Controls.Add(this.cboxMachInvertRelays);
            this.tabMachine.Controls.Add(this.groupBox5);
            this.tabMachine.Controls.Add(this.tboxSerialFromMachine);
            this.tabMachine.Controls.Add(this.groupBox1);
            this.tabMachine.Location = new System.Drawing.Point(4, 54);
            this.tabMachine.Name = "tabMachine";
            this.tabMachine.Padding = new System.Windows.Forms.Padding(3);
            this.tabMachine.Size = new System.Drawing.Size(860, 552);
            this.tabMachine.TabIndex = 1;
            this.tabMachine.Text = "Machine";
            // 
            // cboxMachInvertRelays
            // 
            this.cboxMachInvertRelays.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxMachInvertRelays.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxMachInvertRelays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxMachInvertRelays.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxMachInvertRelays.Location = new System.Drawing.Point(447, 261);
            this.cboxMachInvertRelays.Name = "cboxMachInvertRelays";
            this.cboxMachInvertRelays.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxMachInvertRelays.Size = new System.Drawing.Size(192, 70);
            this.cboxMachInvertRelays.TabIndex = 318;
            this.cboxMachInvertRelays.Text = "Invert Relays";
            this.cboxMachInvertRelays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxMachInvertRelays.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboxIsSendMachineControlToAutoSteer);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(396, 46);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(279, 168);
            this.groupBox5.TabIndex = 316;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "To AutoSteer Port";
            // 
            // cboxIsSendMachineControlToAutoSteer
            // 
            this.cboxIsSendMachineControlToAutoSteer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxIsSendMachineControlToAutoSteer.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsSendMachineControlToAutoSteer.BackColor = System.Drawing.Color.Transparent;
            this.cboxIsSendMachineControlToAutoSteer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxIsSendMachineControlToAutoSteer.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxIsSendMachineControlToAutoSteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsSendMachineControlToAutoSteer.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsSendMachineControlToAutoSteer.Location = new System.Drawing.Point(26, 66);
            this.cboxIsSendMachineControlToAutoSteer.Name = "cboxIsSendMachineControlToAutoSteer";
            this.cboxIsSendMachineControlToAutoSteer.Size = new System.Drawing.Size(230, 61);
            this.cboxIsSendMachineControlToAutoSteer.TabIndex = 312;
            this.cboxIsSendMachineControlToAutoSteer.Text = "Machine Control \r\nPGN";
            this.cboxIsSendMachineControlToAutoSteer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsSendMachineControlToAutoSteer.UseVisualStyleBackColor = false;
            // 
            // tboxSerialFromMachine
            // 
            this.tboxSerialFromMachine.BackColor = System.Drawing.SystemColors.Control;
            this.tboxSerialFromMachine.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSerialFromMachine.Location = new System.Drawing.Point(7, 434);
            this.tboxSerialFromMachine.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tboxSerialFromMachine.Name = "tboxSerialFromMachine";
            this.tboxSerialFromMachine.ReadOnly = true;
            this.tboxSerialFromMachine.Size = new System.Drawing.Size(559, 40);
            this.tboxSerialFromMachine.TabIndex = 315;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudLowerTime);
            this.groupBox1.Controls.Add(this.nudRaiseTime);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboxIsHydOn);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 360);
            this.groupBox1.TabIndex = 278;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hydraulic Tool Lift";
            // 
            // nudLowerTime
            // 
            this.nudLowerTime.BackColor = System.Drawing.Color.AliceBlue;
            this.nudLowerTime.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLowerTime.InterceptArrowKeys = false;
            this.nudLowerTime.Location = new System.Drawing.Point(55, 288);
            this.nudLowerTime.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudLowerTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLowerTime.Name = "nudLowerTime";
            this.nudLowerTime.Size = new System.Drawing.Size(165, 52);
            this.nudLowerTime.TabIndex = 271;
            this.nudLowerTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudLowerTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLowerTime.Enter += new System.EventHandler(this.nudLowerTime_Enter);
            // 
            // nudRaiseTime
            // 
            this.nudRaiseTime.BackColor = System.Drawing.Color.AliceBlue;
            this.nudRaiseTime.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRaiseTime.InterceptArrowKeys = false;
            this.nudRaiseTime.Location = new System.Drawing.Point(55, 165);
            this.nudRaiseTime.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudRaiseTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRaiseTime.Name = "nudRaiseTime";
            this.nudRaiseTime.Size = new System.Drawing.Size(165, 52);
            this.nudRaiseTime.TabIndex = 269;
            this.nudRaiseTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRaiseTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRaiseTime.Enter += new System.EventHandler(this.nudRaiseTime_Enter);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(13, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(235, 54);
            this.label10.TabIndex = 270;
            this.label10.Text = "Raise Time (secs)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cboxIsHydOn
            // 
            this.cboxIsHydOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsHydOn.BackColor = System.Drawing.Color.Transparent;
            this.cboxIsHydOn.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxIsHydOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsHydOn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsHydOn.Location = new System.Drawing.Point(55, 50);
            this.cboxIsHydOn.Name = "cboxIsHydOn";
            this.cboxIsHydOn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxIsHydOn.Size = new System.Drawing.Size(165, 52);
            this.cboxIsHydOn.TabIndex = 273;
            this.cboxIsHydOn.Text = "Enable";
            this.cboxIsHydOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsHydOn.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(18, 231);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(235, 54);
            this.label11.TabIndex = 272;
            this.label11.Text = "Lower Time (secs)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(35, 628);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 67);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bntOK
            // 
            this.bntOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntOK.Location = new System.Drawing.Point(157, 628);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(161, 67);
            this.bntOK.TabIndex = 0;
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormArduinoSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(892, 697);
            this.Controls.Add(this.tabcArduino);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.bntOK);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnChangeAttachment);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormArduinoSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Module Configure";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormToolSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCounts)).EndInit();
            this.tabcArduino.ResumeLayout(false);
            this.tabAutoSteer.ResumeLayout(false);
            this.tabAutoSteer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAckerman)).EndInit();
            this.tabMachine.ResumeLayout(false);
            this.tabMachine.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLowerTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRaiseTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnChangeAttachment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudMaxSpeed;
        private System.Windows.Forms.ComboBox cboxMotorDrive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudMinSpeed;
        private System.Windows.Forms.CheckBox chkInvertRoll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboxMMAAxis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboxSteerEnable;
        private System.Windows.Forms.CheckBox chkBNOInstalled;
        private System.Windows.Forms.CheckBox chkInvertSteer;
        private System.Windows.Forms.CheckBox chkInvertWAS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cboxEncoder;
        private System.Windows.Forms.ComboBox cboxConv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxInclinometer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudMaxCounts;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tboxSerialFromAutoSteer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabcArduino;
        private System.Windows.Forms.TabPage tabAutoSteer;
        private System.Windows.Forms.TabPage tabMachine;
        private System.Windows.Forms.CheckBox cboxIsHydOn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudLowerTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudRaiseTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tboxSerialFromMachine;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cboxIsSendMachineControlToAutoSteer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nudAckerman;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.CheckBox cboxSteerInvertRelays;
        private System.Windows.Forms.CheckBox cboxMachInvertRelays;
        private System.Windows.Forms.Label lblSent;
        private System.Windows.Forms.Label lblRecd;
        private System.Windows.Forms.Label label12;
    }
}