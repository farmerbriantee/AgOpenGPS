namespace AgIO
{
    partial class FormSerialPass
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
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.btnSerialOK = new System.Windows.Forms.Button();
            this.cboxSerialPassOn = new System.Windows.Forms.CheckBox();
            this.btnCloseSerial = new System.Windows.Forms.Button();
            this.btnOpenSerial = new System.Windows.Forms.Button();
            this.cboxBaud = new System.Windows.Forms.ComboBox();
            this.lblCurrentBaud = new System.Windows.Forms.Label();
            this.cboxRadioPort = new System.Windows.Forms.ComboBox();
            this.lblCurrentPort = new System.Windows.Forms.Label();
            this.btnRescan = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cboxToSerial = new System.Windows.Forms.CheckBox();
            this.cboxToUDP = new System.Windows.Forms.CheckBox();
            this.nudSendToUDPPort = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSendToUDPPort)).BeginInit();
            this.SuspendLayout();
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
            this.btnSerialCancel.Location = new System.Drawing.Point(480, 422);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(88, 64);
            this.btnSerialCancel.TabIndex = 71;
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            this.btnSerialCancel.Click += new System.EventHandler(this.btnSerialCancel_Click);
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
            this.btnSerialOK.Location = new System.Drawing.Point(593, 422);
            this.btnSerialOK.Name = "btnSerialOK";
            this.btnSerialOK.Size = new System.Drawing.Size(88, 64);
            this.btnSerialOK.TabIndex = 70;
            this.btnSerialOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSerialOK.UseVisualStyleBackColor = true;
            this.btnSerialOK.Click += new System.EventHandler(this.btnSerialOK_Click);
            // 
            // cboxSerialPassOn
            // 
            this.cboxSerialPassOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxSerialPassOn.BackColor = System.Drawing.Color.Salmon;
            this.cboxSerialPassOn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxSerialPassOn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboxSerialPassOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxSerialPassOn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSerialPassOn.Location = new System.Drawing.Point(215, 428);
            this.cboxSerialPassOn.Name = "cboxSerialPassOn";
            this.cboxSerialPassOn.Size = new System.Drawing.Size(184, 50);
            this.cboxSerialPassOn.TabIndex = 163;
            this.cboxSerialPassOn.Text = "Serial Pass On";
            this.cboxSerialPassOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxSerialPassOn.UseVisualStyleBackColor = false;
            this.cboxSerialPassOn.Click += new System.EventHandler(this.cboxSerialPassOn_Click);
            // 
            // btnCloseSerial
            // 
            this.btnCloseSerial.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseSerial.FlatAppearance.BorderSize = 0;
            this.btnCloseSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseSerial.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseSerial.Image = global::AgIO.Properties.Resources.USB_Disconnect;
            this.btnCloseSerial.Location = new System.Drawing.Point(584, 139);
            this.btnCloseSerial.Name = "btnCloseSerial";
            this.btnCloseSerial.Size = new System.Drawing.Size(101, 58);
            this.btnCloseSerial.TabIndex = 176;
            this.btnCloseSerial.UseVisualStyleBackColor = false;
            this.btnCloseSerial.Click += new System.EventHandler(this.btnCloseSerial_Click);
            // 
            // btnOpenSerial
            // 
            this.btnOpenSerial.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenSerial.FlatAppearance.BorderSize = 0;
            this.btnOpenSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenSerial.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSerial.Image = global::AgIO.Properties.Resources.USB_Connect;
            this.btnOpenSerial.Location = new System.Drawing.Point(463, 139);
            this.btnOpenSerial.Name = "btnOpenSerial";
            this.btnOpenSerial.Size = new System.Drawing.Size(101, 58);
            this.btnOpenSerial.TabIndex = 177;
            this.btnOpenSerial.UseVisualStyleBackColor = false;
            this.btnOpenSerial.Click += new System.EventHandler(this.btnOpenSerial_Click);
            // 
            // cboxBaud
            // 
            this.cboxBaud.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboxBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxBaud.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboxBaud.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboxBaud.FormattingEnabled = true;
            this.cboxBaud.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.cboxBaud.Location = new System.Drawing.Point(316, 153);
            this.cboxBaud.Name = "cboxBaud";
            this.cboxBaud.Size = new System.Drawing.Size(127, 37);
            this.cboxBaud.TabIndex = 175;
            // 
            // lblCurrentBaud
            // 
            this.lblCurrentBaud.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBaud.Location = new System.Drawing.Point(316, 132);
            this.lblCurrentBaud.Name = "lblCurrentBaud";
            this.lblCurrentBaud.Size = new System.Drawing.Size(127, 18);
            this.lblCurrentBaud.TabIndex = 174;
            this.lblCurrentBaud.Text = "Baud";
            this.lblCurrentBaud.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxRadioPort
            // 
            this.cboxRadioPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxRadioPort.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboxRadioPort.FormattingEnabled = true;
            this.cboxRadioPort.Location = new System.Drawing.Point(161, 153);
            this.cboxRadioPort.Name = "cboxRadioPort";
            this.cboxRadioPort.Size = new System.Drawing.Size(124, 37);
            this.cboxRadioPort.TabIndex = 172;
            // 
            // lblCurrentPort
            // 
            this.lblCurrentPort.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPort.Location = new System.Drawing.Point(168, 132);
            this.lblCurrentPort.Name = "lblCurrentPort";
            this.lblCurrentPort.Size = new System.Drawing.Size(119, 18);
            this.lblCurrentPort.TabIndex = 173;
            this.lblCurrentPort.Text = "Port";
            this.lblCurrentPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCurrentPort.UseCompatibleTextRendering = true;
            // 
            // btnRescan
            // 
            this.btnRescan.BackColor = System.Drawing.Color.Transparent;
            this.btnRescan.FlatAppearance.BorderSize = 0;
            this.btnRescan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRescan.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRescan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRescan.Image = global::AgIO.Properties.Resources.ScanPorts;
            this.btnRescan.Location = new System.Drawing.Point(40, 139);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(89, 63);
            this.btnRescan.TabIndex = 171;
            this.btnRescan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRescan.UseVisualStyleBackColor = false;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(132, 250);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(337, 31);
            this.label23.TabIndex = 170;
            this.label23.Text = "Send NTRIP To GPS Using:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(228, 40);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(156, 29);
            this.label21.TabIndex = 166;
            this.label21.Text = "Serial RTCM";
            // 
            // cboxToSerial
            // 
            this.cboxToSerial.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxToSerial.BackColor = System.Drawing.Color.Salmon;
            this.cboxToSerial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxToSerial.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboxToSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxToSerial.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxToSerial.Image = global::AgIO.Properties.Resources.NtripToSerial;
            this.cboxToSerial.Location = new System.Drawing.Point(98, 303);
            this.cboxToSerial.Name = "cboxToSerial";
            this.cboxToSerial.Size = new System.Drawing.Size(150, 50);
            this.cboxToSerial.TabIndex = 179;
            this.cboxToSerial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxToSerial.UseVisualStyleBackColor = false;
            this.cboxToSerial.Click += new System.EventHandler(this.cboxToSerial_Click);
            // 
            // cboxToUDP
            // 
            this.cboxToUDP.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxToUDP.BackColor = System.Drawing.Color.Salmon;
            this.cboxToUDP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxToUDP.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboxToUDP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxToUDP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxToUDP.Image = global::AgIO.Properties.Resources.NtripToUDP;
            this.cboxToUDP.Location = new System.Drawing.Point(355, 300);
            this.cboxToUDP.Name = "cboxToUDP";
            this.cboxToUDP.Size = new System.Drawing.Size(150, 50);
            this.cboxToUDP.TabIndex = 180;
            this.cboxToUDP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxToUDP.UseVisualStyleBackColor = false;
            this.cboxToUDP.Click += new System.EventHandler(this.cboxToUDP_Click);
            // 
            // nudSendToUDPPort
            // 
            this.nudSendToUDPPort.BackColor = System.Drawing.Color.AliceBlue;
            this.nudSendToUDPPort.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSendToUDPPort.Location = new System.Drawing.Point(517, 303);
            this.nudSendToUDPPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudSendToUDPPort.Name = "nudSendToUDPPort";
            this.nudSendToUDPPort.Size = new System.Drawing.Size(141, 46);
            this.nudSendToUDPPort.TabIndex = 178;
            this.nudSendToUDPPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSendToUDPPort.Value = new decimal(new int[] {
            2233,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 181;
            this.label1.Text = "Or";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // FormSerialPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 497);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxToSerial);
            this.Controls.Add(this.cboxToUDP);
            this.Controls.Add(this.nudSendToUDPPort);
            this.Controls.Add(this.cboxSerialPassOn);
            this.Controls.Add(this.btnCloseSerial);
            this.Controls.Add(this.btnOpenSerial);
            this.Controls.Add(this.cboxBaud);
            this.Controls.Add(this.lblCurrentBaud);
            this.Controls.Add(this.cboxRadioPort);
            this.Controls.Add(this.lblCurrentPort);
            this.Controls.Add(this.btnRescan);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnSerialCancel);
            this.Controls.Add(this.btnSerialOK);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSerialPass";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Serial Pass Thru Configuration";
            this.Load += new System.EventHandler(this.FormSerialPass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSendToUDPPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Button btnSerialOK;
        private System.Windows.Forms.CheckBox cboxSerialPassOn;
        private System.Windows.Forms.Button btnCloseSerial;
        private System.Windows.Forms.Button btnOpenSerial;
        private System.Windows.Forms.ComboBox cboxBaud;
        private System.Windows.Forms.Label lblCurrentBaud;
        private System.Windows.Forms.ComboBox cboxRadioPort;
        private System.Windows.Forms.Label lblCurrentPort;
        private System.Windows.Forms.Button btnRescan;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox cboxToSerial;
        private System.Windows.Forms.CheckBox cboxToUDP;
        private System.Windows.Forms.NumericUpDown nudSendToUDPPort;
        private System.Windows.Forms.Label label1;
    }
}