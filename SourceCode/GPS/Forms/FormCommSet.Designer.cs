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
            this.cboxNMEAHz = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnRescan
            // 
            this.btnRescan.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.btnRescan, "btnRescan");
            this.btnRescan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.UseVisualStyleBackColor = false;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // btnSerialOK
            // 
            resources.ApplyResources(this.btnSerialOK, "btnSerialOK");
            this.btnSerialOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSerialOK.Name = "btnSerialOK";
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
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cboxPort
            // 
            this.cboxPort.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboxPort, "cboxPort");
            this.cboxPort.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboxPort.FormattingEnabled = true;
            this.cboxPort.Items.AddRange(new object[] {
            resources.GetString("cboxPort.Items"),
            resources.GetString("cboxPort.Items1"),
            resources.GetString("cboxPort.Items2"),
            resources.GetString("cboxPort.Items3"),
            resources.GetString("cboxPort.Items4"),
            resources.GetString("cboxPort.Items5")});
            this.cboxPort.Name = "cboxPort";
            this.cboxPort.SelectedIndexChanged += new System.EventHandler(this.cboxPort_SelectedIndexChanged_1);
            // 
            // cboxBaud
            // 
            this.cboxBaud.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboxBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboxBaud, "cboxBaud");
            this.cboxBaud.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboxBaud.FormattingEnabled = true;
            this.cboxBaud.Items.AddRange(new object[] {
            resources.GetString("cboxBaud.Items"),
            resources.GetString("cboxBaud.Items1"),
            resources.GetString("cboxBaud.Items2"),
            resources.GetString("cboxBaud.Items3"),
            resources.GetString("cboxBaud.Items4"),
            resources.GetString("cboxBaud.Items5")});
            this.cboxBaud.Name = "cboxBaud";
            this.cboxBaud.SelectedIndexChanged += new System.EventHandler(this.cboxBaud_SelectedIndexChanged_1);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // lblCurrentPort
            // 
            resources.ApplyResources(this.lblCurrentPort, "lblCurrentPort");
            this.lblCurrentPort.Name = "lblCurrentPort";
            // 
            // lblCurrentBaud
            // 
            resources.ApplyResources(this.lblCurrentBaud, "lblCurrentBaud");
            this.lblCurrentBaud.Name = "lblCurrentBaud";
            // 
            // btnCloseSerial
            // 
            this.btnCloseSerial.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.btnCloseSerial, "btnCloseSerial");
            this.btnCloseSerial.Name = "btnCloseSerial";
            this.btnCloseSerial.UseVisualStyleBackColor = false;
            this.btnCloseSerial.Click += new System.EventHandler(this.btnCloseSerial_Click);
            // 
            // textBoxRcv
            // 
            resources.ApplyResources(this.textBoxRcv, "textBoxRcv");
            this.textBoxRcv.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxRcv.Name = "textBoxRcv";
            this.textBoxRcv.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnOpenSerial
            // 
            this.btnOpenSerial.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.btnOpenSerial, "btnOpenSerial");
            this.btnOpenSerial.Name = "btnOpenSerial";
            this.btnOpenSerial.UseVisualStyleBackColor = false;
            this.btnOpenSerial.Click += new System.EventHandler(this.btnOpenSerial_Click);
            // 
            // btnCloseSerialArduino
            // 
            this.btnCloseSerialArduino.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.btnCloseSerialArduino, "btnCloseSerialArduino");
            this.btnCloseSerialArduino.Name = "btnCloseSerialArduino";
            this.btnCloseSerialArduino.UseVisualStyleBackColor = false;
            this.btnCloseSerialArduino.Click += new System.EventHandler(this.btnCloseSerialArduino_Click);
            // 
            // btnOpenSerialArduino
            // 
            this.btnOpenSerialArduino.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.btnOpenSerialArduino, "btnOpenSerialArduino");
            this.btnOpenSerialArduino.Name = "btnOpenSerialArduino";
            this.btnOpenSerialArduino.UseVisualStyleBackColor = false;
            this.btnOpenSerialArduino.Click += new System.EventHandler(this.btnOpenSerialArduino_Click);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // lblCurrentArduinoPort
            // 
            resources.ApplyResources(this.lblCurrentArduinoPort, "lblCurrentArduinoPort");
            this.lblCurrentArduinoPort.Name = "lblCurrentArduinoPort";
            // 
            // txtBoxRecvArduino
            // 
            this.txtBoxRecvArduino.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.txtBoxRecvArduino, "txtBoxRecvArduino");
            this.txtBoxRecvArduino.Name = "txtBoxRecvArduino";
            this.txtBoxRecvArduino.ReadOnly = true;
            // 
            // cboxArdPort
            // 
            this.cboxArdPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboxArdPort, "cboxArdPort");
            this.cboxArdPort.FormattingEnabled = true;
            this.cboxArdPort.Name = "cboxArdPort";
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
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtBoxSendArduino
            // 
            this.txtBoxSendArduino.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.txtBoxSendArduino, "txtBoxSendArduino");
            this.txtBoxSendArduino.Name = "txtBoxSendArduino";
            this.txtBoxSendArduino.ReadOnly = true;
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
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
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtBoxSendAutoSteer
            // 
            this.txtBoxSendAutoSteer.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.txtBoxSendAutoSteer, "txtBoxSendAutoSteer");
            this.txtBoxSendAutoSteer.Name = "txtBoxSendAutoSteer";
            this.txtBoxSendAutoSteer.ReadOnly = true;
            // 
            // cboxASPort
            // 
            this.cboxASPort.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboxASPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboxASPort, "cboxASPort");
            this.cboxASPort.FormattingEnabled = true;
            this.cboxASPort.Name = "cboxASPort";
            this.cboxASPort.SelectedIndexChanged += new System.EventHandler(this.cboxASPort_SelectedIndexChanged);
            // 
            // txtBoxRecvAutoSteer
            // 
            this.txtBoxRecvAutoSteer.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.txtBoxRecvAutoSteer, "txtBoxRecvAutoSteer");
            this.txtBoxRecvAutoSteer.Name = "txtBoxRecvAutoSteer";
            this.txtBoxRecvAutoSteer.ReadOnly = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // lblCurrentAutoSteerPort
            // 
            resources.ApplyResources(this.lblCurrentAutoSteerPort, "lblCurrentAutoSteerPort");
            this.lblCurrentAutoSteerPort.Name = "lblCurrentAutoSteerPort";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // btnOpenSerialAutoSteer
            // 
            this.btnOpenSerialAutoSteer.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.btnOpenSerialAutoSteer, "btnOpenSerialAutoSteer");
            this.btnOpenSerialAutoSteer.Name = "btnOpenSerialAutoSteer";
            this.btnOpenSerialAutoSteer.UseVisualStyleBackColor = false;
            this.btnOpenSerialAutoSteer.Click += new System.EventHandler(this.btnOpenSerialAutoSteer_Click);
            // 
            // btnCloseSerialAutoSteer
            // 
            this.btnCloseSerialAutoSteer.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.btnCloseSerialAutoSteer, "btnCloseSerialAutoSteer");
            this.btnCloseSerialAutoSteer.Name = "btnCloseSerialAutoSteer";
            this.btnCloseSerialAutoSteer.UseVisualStyleBackColor = false;
            this.btnCloseSerialAutoSteer.Click += new System.EventHandler(this.btnCloseSerialAutoSteer_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cboxNMEAHz
            // 
            this.cboxNMEAHz.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboxNMEAHz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboxNMEAHz, "cboxNMEAHz");
            this.cboxNMEAHz.FormattingEnabled = true;
            this.cboxNMEAHz.Items.AddRange(new object[] {
            resources.GetString("cboxNMEAHz.Items"),
            resources.GetString("cboxNMEAHz.Items1"),
            resources.GetString("cboxNMEAHz.Items2"),
            resources.GetString("cboxNMEAHz.Items3")});
            this.cboxNMEAHz.Name = "cboxNMEAHz";
            this.cboxNMEAHz.SelectedIndexChanged += new System.EventHandler(this.cboxNMEAHz_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // FormCommSet
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboxNMEAHz);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnRescan);
            this.Controls.Add(this.btnSerialOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormCommSet";
            this.Load += new System.EventHandler(this.FormCommSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
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
        private System.Windows.Forms.ComboBox cboxNMEAHz;
        private System.Windows.Forms.Label label7;
    }
}