namespace AgIO
{
    partial class FormUDP
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNetworkHelp = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tboxHostName = new System.Windows.Forms.TextBox();
            this.cboxIsUDPOn = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboxIsSendNMEAToUDP = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboxPlugin = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.nudFirstIP = new System.Windows.Forms.NumericUpDown();
            this.nudSecondIP = new System.Windows.Forms.NumericUpDown();
            this.nudThirdIP = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblConnectedModules = new System.Windows.Forms.Label();
            this.btnSendSubnet = new System.Windows.Forms.Button();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.btnSerialOK = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFirstIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecondIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThirdIP)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.lblNetworkHelp);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.tboxHostName);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(33, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(267, 282);
            this.groupBox4.TabIndex = 72;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "This Computer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 23);
            this.label6.TabIndex = 144;
            this.label6.Text = "Current Network Address";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNetworkHelp
            // 
            this.lblNetworkHelp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNetworkHelp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNetworkHelp.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkHelp.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNetworkHelp.Location = new System.Drawing.Point(22, 233);
            this.lblNetworkHelp.Name = "lblNetworkHelp";
            this.lblNetworkHelp.Size = new System.Drawing.Size(221, 32);
            this.lblNetworkHelp.TabIndex = 143;
            this.lblNetworkHelp.Text = "192.168.1.xxx";
            this.lblNetworkHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(31, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(182, 23);
            this.label12.TabIndex = 142;
            this.label12.Text = "Connected Networks";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tboxHostName
            // 
            this.tboxHostName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxHostName.Location = new System.Drawing.Point(27, 33);
            this.tboxHostName.Name = "tboxHostName";
            this.tboxHostName.ReadOnly = true;
            this.tboxHostName.Size = new System.Drawing.Size(221, 30);
            this.tboxHostName.TabIndex = 86;
            this.tboxHostName.Text = "HostName";
            // 
            // cboxIsUDPOn
            // 
            this.cboxIsUDPOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsUDPOn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxIsUDPOn.Checked = true;
            this.cboxIsUDPOn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxIsUDPOn.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxIsUDPOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsUDPOn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsUDPOn.Location = new System.Drawing.Point(96, 36);
            this.cboxIsUDPOn.Name = "cboxIsUDPOn";
            this.cboxIsUDPOn.Size = new System.Drawing.Size(145, 50);
            this.cboxIsUDPOn.TabIndex = 92;
            this.cboxIsUDPOn.Text = "UDP On";
            this.cboxIsUDPOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsUDPOn.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboxIsSendNMEAToUDP);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(519, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 100);
            this.groupBox3.TabIndex = 94;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Send NMEA to Network";
            // 
            // cboxIsSendNMEAToUDP
            // 
            this.cboxIsSendNMEAToUDP.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsSendNMEAToUDP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxIsSendNMEAToUDP.Checked = true;
            this.cboxIsSendNMEAToUDP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxIsSendNMEAToUDP.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxIsSendNMEAToUDP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsSendNMEAToUDP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsSendNMEAToUDP.Location = new System.Drawing.Point(115, 37);
            this.cboxIsSendNMEAToUDP.Name = "cboxIsSendNMEAToUDP";
            this.cboxIsSendNMEAToUDP.Size = new System.Drawing.Size(126, 35);
            this.cboxIsSendNMEAToUDP.TabIndex = 92;
            this.cboxIsSendNMEAToUDP.Text = "NMEA";
            this.cboxIsSendNMEAToUDP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsSendNMEAToUDP.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboxPlugin);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(519, 134);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(257, 100);
            this.groupBox5.TabIndex = 95;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Application Plugin";
            // 
            // cboxPlugin
            // 
            this.cboxPlugin.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxPlugin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cboxPlugin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxPlugin.Checked = true;
            this.cboxPlugin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxPlugin.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxPlugin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxPlugin.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxPlugin.Location = new System.Drawing.Point(115, 35);
            this.cboxPlugin.Name = "cboxPlugin";
            this.cboxPlugin.Size = new System.Drawing.Size(126, 35);
            this.cboxPlugin.TabIndex = 92;
            this.cboxPlugin.Text = "Rate App";
            this.cboxPlugin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxPlugin.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 23);
            this.label1.TabIndex = 147;
            this.label1.Text = "Change Network Address";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudFirstIP
            // 
            this.nudFirstIP.BackColor = System.Drawing.Color.AliceBlue;
            this.nudFirstIP.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFirstIP.Location = new System.Drawing.Point(14, 335);
            this.nudFirstIP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudFirstIP.Name = "nudFirstIP";
            this.nudFirstIP.Size = new System.Drawing.Size(90, 40);
            this.nudFirstIP.TabIndex = 148;
            this.nudFirstIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudFirstIP.Value = new decimal(new int[] {
            192,
            0,
            0,
            0});
            this.nudFirstIP.Click += new System.EventHandler(this.nudFirstIP_Click);
            // 
            // nudSecondIP
            // 
            this.nudSecondIP.BackColor = System.Drawing.Color.AliceBlue;
            this.nudSecondIP.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSecondIP.Location = new System.Drawing.Point(123, 335);
            this.nudSecondIP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSecondIP.Name = "nudSecondIP";
            this.nudSecondIP.Size = new System.Drawing.Size(90, 40);
            this.nudSecondIP.TabIndex = 149;
            this.nudSecondIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSecondIP.Value = new decimal(new int[] {
            168,
            0,
            0,
            0});
            this.nudSecondIP.Click += new System.EventHandler(this.nudSecondIP_Click);
            // 
            // nudThirdIP
            // 
            this.nudThirdIP.BackColor = System.Drawing.Color.AliceBlue;
            this.nudThirdIP.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudThirdIP.Location = new System.Drawing.Point(231, 335);
            this.nudThirdIP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudThirdIP.Name = "nudThirdIP";
            this.nudThirdIP.Size = new System.Drawing.Size(90, 40);
            this.nudThirdIP.TabIndex = 150;
            this.nudThirdIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudThirdIP.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudThirdIP.Click += new System.EventHandler(this.nudThirdIP_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(102, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 35);
            this.label2.TabIndex = 152;
            this.label2.Text = ".";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(211, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 35);
            this.label3.TabIndex = 153;
            this.label3.Text = ".";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(320, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 35);
            this.label4.TabIndex = 154;
            this.label4.Text = ".";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(336, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 35);
            this.label5.TabIndex = 155;
            this.label5.Text = "x";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboxIsUDPOn);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(519, 275);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 100);
            this.groupBox1.TabIndex = 96;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UDP Network";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(70, 416);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 23);
            this.label8.TabIndex = 157;
            this.label8.Text = "Send";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConnectedModules
            // 
            this.lblConnectedModules.AutoSize = true;
            this.lblConnectedModules.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblConnectedModules.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblConnectedModules.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectedModules.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblConnectedModules.Location = new System.Drawing.Point(306, 48);
            this.lblConnectedModules.Name = "lblConnectedModules";
            this.lblConnectedModules.Size = new System.Drawing.Size(197, 27);
            this.lblConnectedModules.TabIndex = 160;
            this.lblConnectedModules.Text = "Scan For Modules";
            this.lblConnectedModules.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSendSubnet
            // 
            this.btnSendSubnet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSendSubnet.FlatAppearance.BorderSize = 0;
            this.btnSendSubnet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendSubnet.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendSubnet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSendSubnet.Image = global::AgIO.Properties.Resources.ToolAcceptChange;
            this.btnSendSubnet.Location = new System.Drawing.Point(124, 396);
            this.btnSendSubnet.Name = "btnSendSubnet";
            this.btnSendSubnet.Size = new System.Drawing.Size(98, 64);
            this.btnSendSubnet.TabIndex = 151;
            this.btnSendSubnet.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSendSubnet.UseVisualStyleBackColor = true;
            this.btnSendSubnet.Click += new System.EventHandler(this.btnSendSubnet_Click);
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.FlatAppearance.BorderSize = 0;
            this.btnSerialCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialCancel.Image = global::AgIO.Properties.Resources.Cancel64;
            this.btnSerialCancel.Location = new System.Drawing.Point(570, 395);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(88, 64);
            this.btnSerialCancel.TabIndex = 71;
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            // 
            // btnSerialOK
            // 
            this.btnSerialOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialOK.FlatAppearance.BorderSize = 0;
            this.btnSerialOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialOK.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSerialOK.Image = global::AgIO.Properties.Resources.OK64;
            this.btnSerialOK.Location = new System.Drawing.Point(683, 395);
            this.btnSerialOK.Name = "btnSerialOK";
            this.btnSerialOK.Size = new System.Drawing.Size(88, 64);
            this.btnSerialOK.TabIndex = 70;
            this.btnSerialOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSerialOK.UseVisualStyleBackColor = true;
            this.btnSerialOK.Click += new System.EventHandler(this.btnSerialOK_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(338, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 23);
            this.label7.TabIndex = 161;
            this.label7.Text = "Network Scan";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(35, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 27);
            this.label9.TabIndex = 161;
            this.label9.Text = "....";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormUDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 470);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblConnectedModules);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSendSubnet);
            this.Controls.Add(this.nudThirdIP);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.nudSecondIP);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.nudFirstIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnSerialCancel);
            this.Controls.Add(this.btnSerialOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUDP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ethernet Configuration";
            this.Load += new System.EventHandler(this.FormUDp_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudFirstIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecondIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThirdIP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Button btnSerialOK;
        private System.Windows.Forms.TextBox tboxHostName;
        private System.Windows.Forms.CheckBox cboxIsUDPOn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cboxIsSendNMEAToUDP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cboxPlugin;
        private System.Windows.Forms.Label lblNetworkHelp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudFirstIP;
        private System.Windows.Forms.NumericUpDown nudSecondIP;
        private System.Windows.Forms.NumericUpDown nudThirdIP;
        private System.Windows.Forms.Button btnSendSubnet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblConnectedModules;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label9;
    }
}