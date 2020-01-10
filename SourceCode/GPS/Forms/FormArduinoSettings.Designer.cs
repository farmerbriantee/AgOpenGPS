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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.btnChangeAttachment = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMaxSpeed = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bntOK = new System.Windows.Forms.Button();
            this.cboxMotorDrive = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxA2DConvertor = new System.Windows.Forms.ComboBox();
            this.chkInvertWAS = new System.Windows.Forms.CheckBox();
            this.chkInvertSteer = new System.Windows.Forms.CheckBox();
            this.chkBNOInstalled = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxSteerEnable = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboxMMAAxis = new System.Windows.Forms.ComboBox();
            this.chkInvertRoll = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboxRelayType = new System.Windows.Forms.ComboBox();
            this.chkEthernet = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudMinSpeed = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabConfig);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(180, 69);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(967, 618);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabConfig
            // 
            this.tabConfig.BackColor = System.Drawing.SystemColors.Window;
            this.tabConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabConfig.Controls.Add(this.checkBox1);
            this.tabConfig.Controls.Add(this.label8);
            this.tabConfig.Controls.Add(this.nudMinSpeed);
            this.tabConfig.Controls.Add(this.label4);
            this.tabConfig.Controls.Add(this.chkEthernet);
            this.tabConfig.Controls.Add(this.label7);
            this.tabConfig.Controls.Add(this.nudMaxSpeed);
            this.tabConfig.Controls.Add(this.cboxRelayType);
            this.tabConfig.Controls.Add(this.chkInvertRoll);
            this.tabConfig.Controls.Add(this.label6);
            this.tabConfig.Controls.Add(this.cboxMMAAxis);
            this.tabConfig.Controls.Add(this.label5);
            this.tabConfig.Controls.Add(this.cboxSteerEnable);
            this.tabConfig.Controls.Add(this.chkBNOInstalled);
            this.tabConfig.Controls.Add(this.chkInvertSteer);
            this.tabConfig.Controls.Add(this.chkInvertWAS);
            this.tabConfig.Controls.Add(this.label3);
            this.tabConfig.Controls.Add(this.cboxA2DConvertor);
            this.tabConfig.Controls.Add(this.label1);
            this.tabConfig.Controls.Add(this.cboxMotorDrive);
            this.tabConfig.Controls.Add(this.btnChangeAttachment);
            this.tabConfig.Location = new System.Drawing.Point(4, 73);
            this.tabConfig.Margin = new System.Windows.Forms.Padding(4);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(4);
            this.tabConfig.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabConfig.Size = new System.Drawing.Size(959, 541);
            this.tabConfig.TabIndex = 1;
            this.tabConfig.Text = "Configuration";
            // 
            // btnChangeAttachment
            // 
            this.btnChangeAttachment.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeAttachment.Image = global::AgOpenGPS.Properties.Resources.ToolAcceptChange;
            this.btnChangeAttachment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnChangeAttachment.Location = new System.Drawing.Point(786, 444);
            this.btnChangeAttachment.Name = "btnChangeAttachment";
            this.btnChangeAttachment.Size = new System.Drawing.Size(133, 67);
            this.btnChangeAttachment.TabIndex = 251;
            this.btnChangeAttachment.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(680, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 27);
            this.label4.TabIndex = 250;
            this.label4.Text = "Max Speed";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nudMaxSpeed
            // 
            this.nudMaxSpeed.BackColor = System.Drawing.Color.AliceBlue;
            this.nudMaxSpeed.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMaxSpeed.InterceptArrowKeys = false;
            this.nudMaxSpeed.Location = new System.Drawing.Point(692, 297);
            this.nudMaxSpeed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMaxSpeed.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMaxSpeed.Name = "nudMaxSpeed";
            this.nudMaxSpeed.Size = new System.Drawing.Size(165, 52);
            this.nudMaxSpeed.TabIndex = 249;
            this.nudMaxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMaxSpeed.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(685, 624);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 68);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bntOK
            // 
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntOK.Location = new System.Drawing.Point(818, 624);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(156, 68);
            this.bntOK.TabIndex = 0;
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cboxMotorDrive
            // 
            this.cboxMotorDrive.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxMotorDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMotorDrive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxMotorDrive.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxMotorDrive.FormattingEnabled = true;
            this.cboxMotorDrive.Items.AddRange(new object[] {
            "Cytron",
            "IBT2"});
            this.cboxMotorDrive.Location = new System.Drawing.Point(12, 49);
            this.cboxMotorDrive.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxMotorDrive.Name = "cboxMotorDrive";
            this.cboxMotorDrive.Size = new System.Drawing.Size(255, 50);
            this.cboxMotorDrive.TabIndex = 252;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 29);
            this.label1.TabIndex = 253;
            this.label1.Text = "Motor Driver";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 29);
            this.label3.TabIndex = 255;
            this.label3.Text = "A2D Convertor";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cboxA2DConvertor
            // 
            this.cboxA2DConvertor.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxA2DConvertor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxA2DConvertor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxA2DConvertor.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxA2DConvertor.FormattingEnabled = true;
            this.cboxA2DConvertor.Items.AddRange(new object[] {
            "Arduino",
            "ADS1115 S",
            "ADS1115 D"});
            this.cboxA2DConvertor.Location = new System.Drawing.Point(12, 165);
            this.cboxA2DConvertor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxA2DConvertor.Name = "cboxA2DConvertor";
            this.cboxA2DConvertor.Size = new System.Drawing.Size(255, 50);
            this.cboxA2DConvertor.TabIndex = 254;
            // 
            // chkInvertWAS
            // 
            this.chkInvertWAS.AutoSize = true;
            this.chkInvertWAS.Location = new System.Drawing.Point(114, 280);
            this.chkInvertWAS.Name = "chkInvertWAS";
            this.chkInvertWAS.Size = new System.Drawing.Size(153, 33);
            this.chkInvertWAS.TabIndex = 256;
            this.chkInvertWAS.Text = "Invert WAS";
            this.chkInvertWAS.UseVisualStyleBackColor = true;
            this.chkInvertWAS.CheckedChanged += new System.EventHandler(this.chkInvertWAS_CheckedChanged);
            // 
            // chkInvertSteer
            // 
            this.chkInvertSteer.AutoSize = true;
            this.chkInvertSteer.Location = new System.Drawing.Point(6, 371);
            this.chkInvertSteer.Name = "chkInvertSteer";
            this.chkInvertSteer.Size = new System.Drawing.Size(261, 33);
            this.chkInvertSteer.TabIndex = 257;
            this.chkInvertSteer.Text = "Invert Steer Direction";
            this.chkInvertSteer.UseVisualStyleBackColor = true;
            // 
            // chkBNOInstalled
            // 
            this.chkBNOInstalled.AutoSize = true;
            this.chkBNOInstalled.Location = new System.Drawing.Point(90, 462);
            this.chkBNOInstalled.Name = "chkBNOInstalled";
            this.chkBNOInstalled.Size = new System.Drawing.Size(177, 33);
            this.chkBNOInstalled.TabIndex = 258;
            this.chkBNOInstalled.Text = "BNO Installed";
            this.chkBNOInstalled.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(363, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 29);
            this.label5.TabIndex = 260;
            this.label5.Text = "Steer Enable";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cboxSteerEnable
            // 
            this.cboxSteerEnable.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxSteerEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSteerEnable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxSteerEnable.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSteerEnable.FormattingEnabled = true;
            this.cboxSteerEnable.Items.AddRange(new object[] {
            "Switch",
            "Button"});
            this.cboxSteerEnable.Location = new System.Drawing.Point(379, 165);
            this.cboxSteerEnable.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxSteerEnable.Name = "cboxSteerEnable";
            this.cboxSteerEnable.Size = new System.Drawing.Size(204, 50);
            this.cboxSteerEnable.TabIndex = 259;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Window;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(666, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 29);
            this.label6.TabIndex = 262;
            this.label6.Text = "MMA Axis";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cboxMMAAxis
            // 
            this.cboxMMAAxis.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxMMAAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMMAAxis.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxMMAAxis.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxMMAAxis.FormattingEnabled = true;
            this.cboxMMAAxis.Items.AddRange(new object[] {
            "X Axis",
            "Y Axis"});
            this.cboxMMAAxis.Location = new System.Drawing.Point(692, 49);
            this.cboxMMAAxis.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxMMAAxis.Name = "cboxMMAAxis";
            this.cboxMMAAxis.Size = new System.Drawing.Size(199, 50);
            this.cboxMMAAxis.TabIndex = 261;
            // 
            // chkInvertRoll
            // 
            this.chkInvertRoll.AutoSize = true;
            this.chkInvertRoll.Location = new System.Drawing.Point(413, 371);
            this.chkInvertRoll.Name = "chkInvertRoll";
            this.chkInvertRoll.Size = new System.Drawing.Size(142, 33);
            this.chkInvertRoll.TabIndex = 263;
            this.chkInvertRoll.Text = "Invert Roll";
            this.chkInvertRoll.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Window;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(363, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 29);
            this.label7.TabIndex = 265;
            this.label7.Text = "Relay Type";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cboxRelayType
            // 
            this.cboxRelayType.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxRelayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxRelayType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxRelayType.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxRelayType.FormattingEnabled = true;
            this.cboxRelayType.Items.AddRange(new object[] {
            "None",
            "Section",
            "uTurn"});
            this.cboxRelayType.Location = new System.Drawing.Point(379, 49);
            this.cboxRelayType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxRelayType.Name = "cboxRelayType";
            this.cboxRelayType.Size = new System.Drawing.Size(204, 50);
            this.cboxRelayType.TabIndex = 264;
            // 
            // chkEthernet
            // 
            this.chkEthernet.AutoSize = true;
            this.chkEthernet.Location = new System.Drawing.Point(433, 282);
            this.chkEthernet.Name = "chkEthernet";
            this.chkEthernet.Size = new System.Drawing.Size(122, 33);
            this.chkEthernet.TabIndex = 266;
            this.chkEthernet.Text = "Ethernet";
            this.chkEthernet.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Window;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(680, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 27);
            this.label8.TabIndex = 268;
            this.label8.Text = "Min Speed";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nudMinSpeed
            // 
            this.nudMinSpeed.BackColor = System.Drawing.Color.AliceBlue;
            this.nudMinSpeed.DecimalPlaces = 1;
            this.nudMinSpeed.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMinSpeed.InterceptArrowKeys = false;
            this.nudMinSpeed.Location = new System.Drawing.Point(692, 170);
            this.nudMinSpeed.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMinSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMinSpeed.Name = "nudMinSpeed";
            this.nudMinSpeed.Size = new System.Drawing.Size(165, 52);
            this.nudMinSpeed.TabIndex = 267;
            this.nudMinSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMinSpeed.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(438, 462);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 33);
            this.checkBox1.TabIndex = 269;
            this.checkBox1.Text = "Encoder";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FormArduinoSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(976, 700);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.bntOK);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormArduinoSettings";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormToolSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            this.tabConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnChangeAttachment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudMaxSpeed;
        private System.Windows.Forms.ComboBox cboxMotorDrive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudMinSpeed;
        private System.Windows.Forms.CheckBox chkEthernet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboxRelayType;
        private System.Windows.Forms.CheckBox chkInvertRoll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboxMMAAxis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboxSteerEnable;
        private System.Windows.Forms.CheckBox chkBNOInstalled;
        private System.Windows.Forms.CheckBox chkInvertSteer;
        private System.Windows.Forms.CheckBox chkInvertWAS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxA2DConvertor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}