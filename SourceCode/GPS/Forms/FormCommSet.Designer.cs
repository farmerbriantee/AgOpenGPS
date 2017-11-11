namespace AgOpenGPS
{
    partial class FormCommSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCommSet));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.btnRescan = new System.Windows.Forms.Button();
            this.btnSerialOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboxPort = new System.Windows.Forms.ComboBox();
            this.cboxBaud = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblCurrentPort = new System.Windows.Forms.Label();
            this.lblCurrentBaud = new System.Windows.Forms.Label();
            this.btnCloseSerial = new System.Windows.Forms.Button();
            this.textBoxRcv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenSerial = new System.Windows.Forms.Button();
            this.btnCloseSerialArduino = new System.Windows.Forms.Button();
            this.btnOpenSerialArduino = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCurrentArduinoPort = new System.Windows.Forms.Label();
            this.txtBoxRecvArduino = new System.Windows.Forms.TextBox();
            this.cboxArdPort = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxSendArduino = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxSendAutoSteer = new System.Windows.Forms.TextBox();
            this.cboxASPort = new System.Windows.Forms.ComboBox();
            this.txtBoxRecvAutoSteer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCurrentAutoSteerPort = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOpenSerialAutoSteer = new System.Windows.Forms.Button();
            this.btnCloseSerialAutoSteer = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxTCP = new System.Windows.Forms.CheckBox();
            this.cboxUDP = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnSerialCancel.Location = new System.Drawing.Point(610, 403);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(88, 72);
            this.btnSerialCancel.TabIndex = 62;
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            this.btnSerialCancel.Click += new System.EventHandler(this.btnSerialCancel_Click);
            // 
            // btnRescan
            // 
            this.btnRescan.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRescan.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRescan.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRescan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRescan.Location = new System.Drawing.Point(679, 47);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(117, 50);
            this.btnRescan.TabIndex = 58;
            this.btnRescan.Text = "Rescan Ports";
            this.btnRescan.UseVisualStyleBackColor = false;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // btnSerialOK
            // 
            this.btnSerialOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialOK.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSerialOK.Image = ((System.Drawing.Image)(resources.GetObject("btnSerialOK.Image")));
            this.btnSerialOK.Location = new System.Drawing.Point(722, 403);
            this.btnSerialOK.Name = "btnSerialOK";
            this.btnSerialOK.Size = new System.Drawing.Size(156, 72);
            this.btnSerialOK.TabIndex = 59;
            this.btnSerialOK.Text = "Save";
            this.btnSerialOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSerialOK.UseVisualStyleBackColor = true;
            this.btnSerialOK.Click += new System.EventHandler(this.btnSerialOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.cboxPort);
            this.groupBox1.Controls.Add(this.cboxBaud);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblCurrentPort);
            this.groupBox1.Controls.Add(this.lblCurrentBaud);
            this.groupBox1.Controls.Add(this.btnCloseSerial);
            this.groupBox1.Controls.Add(this.textBoxRcv);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnOpenSerial);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 178);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GPS Port";
            // 
            // cboxPort
            // 
            this.cboxPort.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPort.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxPort.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboxPort.FormattingEnabled = true;
            this.cboxPort.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cboxPort.Location = new System.Drawing.Point(25, 39);
            this.cboxPort.Name = "cboxPort";
            this.cboxPort.Size = new System.Drawing.Size(96, 37);
            this.cboxPort.TabIndex = 50;
            this.cboxPort.SelectedIndexChanged += new System.EventHandler(this.cboxPort_SelectedIndexChanged_1);
            // 
            // cboxBaud
            // 
            this.cboxBaud.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboxBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxBaud.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxBaud.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboxBaud.FormattingEnabled = true;
            this.cboxBaud.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cboxBaud.Location = new System.Drawing.Point(140, 39);
            this.cboxBaud.Name = "cboxBaud";
            this.cboxBaud.Size = new System.Drawing.Size(96, 37);
            this.cboxBaud.TabIndex = 49;
            this.cboxBaud.SelectedIndexChanged += new System.EventHandler(this.cboxBaud_SelectedIndexChanged_1);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(19, 84);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 16);
            this.label16.TabIndex = 48;
            this.label16.Text = "Currently:";
            // 
            // lblCurrentPort
            // 
            this.lblCurrentPort.AutoSize = true;
            this.lblCurrentPort.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPort.Location = new System.Drawing.Point(89, 84);
            this.lblCurrentPort.Name = "lblCurrentPort";
            this.lblCurrentPort.Size = new System.Drawing.Size(36, 16);
            this.lblCurrentPort.TabIndex = 47;
            this.lblCurrentPort.Text = "Port";
            // 
            // lblCurrentBaud
            // 
            this.lblCurrentBaud.AutoSize = true;
            this.lblCurrentBaud.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBaud.Location = new System.Drawing.Point(137, 84);
            this.lblCurrentBaud.Name = "lblCurrentBaud";
            this.lblCurrentBaud.Size = new System.Drawing.Size(40, 16);
            this.lblCurrentBaud.TabIndex = 46;
            this.lblCurrentBaud.Text = "Baud";
            // 
            // btnCloseSerial
            // 
            this.btnCloseSerial.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCloseSerial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCloseSerial.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseSerial.Location = new System.Drawing.Point(437, 39);
            this.btnCloseSerial.Name = "btnCloseSerial";
            this.btnCloseSerial.Size = new System.Drawing.Size(117, 36);
            this.btnCloseSerial.TabIndex = 44;
            this.btnCloseSerial.Text = "Disconnect";
            this.btnCloseSerial.UseVisualStyleBackColor = false;
            this.btnCloseSerial.Click += new System.EventHandler(this.btnCloseSerial_Click);
            // 
            // textBoxRcv
            // 
            this.textBoxRcv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRcv.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxRcv.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRcv.Location = new System.Drawing.Point(7, 110);
            this.textBoxRcv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRcv.Multiline = true;
            this.textBoxRcv.Name = "textBoxRcv";
            this.textBoxRcv.ReadOnly = true;
            this.textBoxRcv.Size = new System.Drawing.Size(559, 60);
            this.textBoxRcv.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(225, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 16);
            this.label1.TabIndex = 41;
            this.label1.Text = "NMEA string from GPS Port:";
            // 
            // btnOpenSerial
            // 
            this.btnOpenSerial.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnOpenSerial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOpenSerial.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSerial.Location = new System.Drawing.Point(298, 39);
            this.btnOpenSerial.Name = "btnOpenSerial";
            this.btnOpenSerial.Size = new System.Drawing.Size(117, 36);
            this.btnOpenSerial.TabIndex = 45;
            this.btnOpenSerial.Text = "Connect";
            this.btnOpenSerial.UseVisualStyleBackColor = false;
            this.btnOpenSerial.Click += new System.EventHandler(this.btnOpenSerial_Click);
            // 
            // btnCloseSerialArduino
            // 
            this.btnCloseSerialArduino.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCloseSerialArduino.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCloseSerialArduino.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseSerialArduino.Location = new System.Drawing.Point(437, 28);
            this.btnCloseSerialArduino.Name = "btnCloseSerialArduino";
            this.btnCloseSerialArduino.Size = new System.Drawing.Size(117, 36);
            this.btnCloseSerialArduino.TabIndex = 52;
            this.btnCloseSerialArduino.Text = "Disconnect";
            this.btnCloseSerialArduino.UseVisualStyleBackColor = false;
            this.btnCloseSerialArduino.Click += new System.EventHandler(this.btnCloseSerialArduino_Click);
            // 
            // btnOpenSerialArduino
            // 
            this.btnOpenSerialArduino.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnOpenSerialArduino.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOpenSerialArduino.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSerialArduino.Location = new System.Drawing.Point(298, 28);
            this.btnOpenSerialArduino.Name = "btnOpenSerialArduino";
            this.btnOpenSerialArduino.Size = new System.Drawing.Size(117, 36);
            this.btnOpenSerialArduino.TabIndex = 53;
            this.btnOpenSerialArduino.Text = "Connect";
            this.btnOpenSerialArduino.UseVisualStyleBackColor = false;
            this.btnOpenSerialArduino.Click += new System.EventHandler(this.btnOpenSerialArduino_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(303, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 16);
            this.label15.TabIndex = 58;
            this.label15.Text = "From Section Port:";
            // 
            // lblCurrentArduinoPort
            // 
            this.lblCurrentArduinoPort.AutoSize = true;
            this.lblCurrentArduinoPort.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentArduinoPort.Location = new System.Drawing.Point(162, 48);
            this.lblCurrentArduinoPort.Name = "lblCurrentArduinoPort";
            this.lblCurrentArduinoPort.Size = new System.Drawing.Size(36, 16);
            this.lblCurrentArduinoPort.TabIndex = 59;
            this.lblCurrentArduinoPort.Text = "Port";
            // 
            // txtBoxRecvArduino
            // 
            this.txtBoxRecvArduino.BackColor = System.Drawing.SystemColors.Window;
            this.txtBoxRecvArduino.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxRecvArduino.Location = new System.Drawing.Point(298, 98);
            this.txtBoxRecvArduino.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxRecvArduino.Name = "txtBoxRecvArduino";
            this.txtBoxRecvArduino.ReadOnly = true;
            this.txtBoxRecvArduino.Size = new System.Drawing.Size(256, 27);
            this.txtBoxRecvArduino.TabIndex = 63;
            // 
            // cboxArdPort
            // 
            this.cboxArdPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxArdPort.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxArdPort.FormattingEnabled = true;
            this.cboxArdPort.Location = new System.Drawing.Point(25, 31);
            this.cboxArdPort.Name = "cboxArdPort";
            this.cboxArdPort.Size = new System.Drawing.Size(121, 37);
            this.cboxArdPort.TabIndex = 64;
            this.cboxArdPort.SelectedIndexChanged += new System.EventHandler(this.cboxArdPort_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtBoxSendArduino);
            this.groupBox2.Controls.Add(this.cboxArdPort);
            this.groupBox2.Controls.Add(this.txtBoxRecvArduino);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.lblCurrentArduinoPort);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.btnOpenSerialArduino);
            this.groupBox2.Controls.Add(this.btnCloseSerialArduino);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(576, 134);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Section Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 66;
            this.label2.Text = "To Section Port:";
            // 
            // txtBoxSendArduino
            // 
            this.txtBoxSendArduino.BackColor = System.Drawing.SystemColors.Window;
            this.txtBoxSendArduino.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSendArduino.Location = new System.Drawing.Point(25, 98);
            this.txtBoxSendArduino.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxSendArduino.Name = "txtBoxSendArduino";
            this.txtBoxSendArduino.ReadOnly = true;
            this.txtBoxSendArduino.Size = new System.Drawing.Size(244, 27);
            this.txtBoxSendArduino.TabIndex = 65;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(162, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 16);
            this.label17.TabIndex = 60;
            this.label17.Text = "Currently:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtBoxSendAutoSteer);
            this.groupBox3.Controls.Add(this.cboxASPort);
            this.groupBox3.Controls.Add(this.txtBoxRecvAutoSteer);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lblCurrentAutoSteerPort);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnOpenSerialAutoSteer);
            this.groupBox3.Controls.Add(this.btnCloseSerialAutoSteer);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 342);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(576, 132);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AutoSteer Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 66;
            this.label3.Text = "To Auto Steer:";
            // 
            // txtBoxSendAutoSteer
            // 
            this.txtBoxSendAutoSteer.BackColor = System.Drawing.SystemColors.Window;
            this.txtBoxSendAutoSteer.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSendAutoSteer.Location = new System.Drawing.Point(25, 98);
            this.txtBoxSendAutoSteer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxSendAutoSteer.Name = "txtBoxSendAutoSteer";
            this.txtBoxSendAutoSteer.ReadOnly = true;
            this.txtBoxSendAutoSteer.Size = new System.Drawing.Size(244, 27);
            this.txtBoxSendAutoSteer.TabIndex = 65;
            // 
            // cboxASPort
            // 
            this.cboxASPort.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboxASPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxASPort.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxASPort.FormattingEnabled = true;
            this.cboxASPort.Location = new System.Drawing.Point(25, 31);
            this.cboxASPort.Name = "cboxASPort";
            this.cboxASPort.Size = new System.Drawing.Size(121, 37);
            this.cboxASPort.TabIndex = 64;
            this.cboxASPort.SelectedIndexChanged += new System.EventHandler(this.cboxASPort_SelectedIndexChanged);
            // 
            // txtBoxRecvAutoSteer
            // 
            this.txtBoxRecvAutoSteer.BackColor = System.Drawing.SystemColors.Window;
            this.txtBoxRecvAutoSteer.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxRecvAutoSteer.Location = new System.Drawing.Point(298, 98);
            this.txtBoxRecvAutoSteer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxRecvAutoSteer.Name = "txtBoxRecvAutoSteer";
            this.txtBoxRecvAutoSteer.ReadOnly = true;
            this.txtBoxRecvAutoSteer.Size = new System.Drawing.Size(256, 27);
            this.txtBoxRecvAutoSteer.TabIndex = 63;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(162, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "Currently:";
            // 
            // lblCurrentAutoSteerPort
            // 
            this.lblCurrentAutoSteerPort.AutoSize = true;
            this.lblCurrentAutoSteerPort.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentAutoSteerPort.Location = new System.Drawing.Point(162, 48);
            this.lblCurrentAutoSteerPort.Name = "lblCurrentAutoSteerPort";
            this.lblCurrentAutoSteerPort.Size = new System.Drawing.Size(36, 16);
            this.lblCurrentAutoSteerPort.TabIndex = 59;
            this.lblCurrentAutoSteerPort.Text = "Port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(303, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 16);
            this.label6.TabIndex = 58;
            this.label6.Text = "From Auto Steer:";
            // 
            // btnOpenSerialAutoSteer
            // 
            this.btnOpenSerialAutoSteer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnOpenSerialAutoSteer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOpenSerialAutoSteer.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSerialAutoSteer.Location = new System.Drawing.Point(298, 28);
            this.btnOpenSerialAutoSteer.Name = "btnOpenSerialAutoSteer";
            this.btnOpenSerialAutoSteer.Size = new System.Drawing.Size(117, 36);
            this.btnOpenSerialAutoSteer.TabIndex = 53;
            this.btnOpenSerialAutoSteer.Text = "Connect";
            this.btnOpenSerialAutoSteer.UseVisualStyleBackColor = false;
            this.btnOpenSerialAutoSteer.Click += new System.EventHandler(this.btnOpenSerialAutoSteer_Click);
            // 
            // btnCloseSerialAutoSteer
            // 
            this.btnCloseSerialAutoSteer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCloseSerialAutoSteer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCloseSerialAutoSteer.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseSerialAutoSteer.Location = new System.Drawing.Point(437, 28);
            this.btnCloseSerialAutoSteer.Name = "btnCloseSerialAutoSteer";
            this.btnCloseSerialAutoSteer.Size = new System.Drawing.Size(117, 36);
            this.btnCloseSerialAutoSteer.TabIndex = 52;
            this.btnCloseSerialAutoSteer.Text = "Disconnect";
            this.btnCloseSerialAutoSteer.UseVisualStyleBackColor = false;
            this.btnCloseSerialAutoSteer.Click += new System.EventHandler(this.btnCloseSerialAutoSteer_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(642, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 16);
            this.label5.TabIndex = 51;
            this.label5.Text = "To Refresh Available USB Ports";
            // 
            // cboxTCP
            // 
            this.cboxTCP.AutoSize = true;
            this.cboxTCP.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxTCP.Location = new System.Drawing.Point(14, 42);
            this.cboxTCP.Name = "cboxTCP";
            this.cboxTCP.Size = new System.Drawing.Size(237, 27);
            this.cboxTCP.TabIndex = 67;
            this.cboxTCP.Text = " - TCP Server On (Port 7777)";
            this.cboxTCP.UseVisualStyleBackColor = true;
            // 
            // cboxUDP
            // 
            this.cboxUDP.AutoSize = true;
            this.cboxUDP.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxUDP.Location = new System.Drawing.Point(14, 91);
            this.cboxUDP.Name = "cboxUDP";
            this.cboxUDP.Size = new System.Drawing.Size(238, 27);
            this.cboxUDP.TabIndex = 68;
            this.cboxUDP.Text = " - UDP Server On (Port 9999)";
            this.cboxUDP.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.cboxUDP);
            this.groupBox4.Controls.Add(this.cboxTCP);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(613, 135);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(265, 201);
            this.groupBox4.TabIndex = 69;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ethernet Servers";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 36);
            this.label7.TabIndex = 70;
            this.label7.Text = "** You must Restart App for \r\nServers to Start or Stop\r\n";
            // 
            // FormCommSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(890, 483);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSerialCancel);
            this.Controls.Add(this.btnRescan);
            this.Controls.Add(this.btnSerialOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormCommSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Communication Settings";
            this.Load += new System.EventHandler(this.FormCommSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Button btnRescan;
        private System.Windows.Forms.Button btnSerialOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblCurrentPort;
        private System.Windows.Forms.Label lblCurrentBaud;
        private System.Windows.Forms.Button btnCloseSerial;
        private System.Windows.Forms.TextBox textBoxRcv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenSerial;
        private System.Windows.Forms.ComboBox cboxBaud;
        private System.Windows.Forms.ComboBox cboxPort;
        private System.Windows.Forms.Button btnCloseSerialArduino;
        private System.Windows.Forms.Button btnOpenSerialArduino;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblCurrentArduinoPort;
        private System.Windows.Forms.TextBox txtBoxRecvArduino;
        private System.Windows.Forms.ComboBox cboxArdPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxSendArduino;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxSendAutoSteer;
        private System.Windows.Forms.ComboBox cboxASPort;
        private System.Windows.Forms.TextBox txtBoxRecvAutoSteer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCurrentAutoSteerPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOpenSerialAutoSteer;
        private System.Windows.Forms.Button btnCloseSerialAutoSteer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cboxTCP;
        private System.Windows.Forms.CheckBox cboxUDP;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
    }
}