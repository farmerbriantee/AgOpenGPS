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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tboxHostName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxThisIP = new System.Windows.Forms.TextBox();
            this.nudThisPort = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.btnSerialOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudAutoSteerPort = new System.Windows.Forms.NumericUpDown();
            this.tboxAutoSteerIP = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboxIsUDPOn = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThisPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoSteerPort)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.tboxHostName);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tboxThisIP);
            this.groupBox4.Controls.Add(this.nudThisPort);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 62);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(300, 232);
            this.groupBox4.TabIndex = 72;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Drive Server";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(219, 23);
            this.label11.TabIndex = 95;
            this.label11.Text = "All modules send to 9999";
            // 
            // tboxHostName
            // 
            this.tboxHostName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxHostName.Location = new System.Drawing.Point(57, 79);
            this.tboxHostName.Name = "tboxHostName";
            this.tboxHostName.ReadOnly = true;
            this.tboxHostName.Size = new System.Drawing.Size(221, 30);
            this.tboxHostName.TabIndex = 86;
            this.tboxHostName.Text = "HostName";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(2, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 23);
            this.label14.TabIndex = 85;
            this.label14.Text = "Host";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 23);
            this.label1.TabIndex = 84;
            this.label1.Text = "This Computer";
            // 
            // tboxThisIP
            // 
            this.tboxThisIP.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxThisIP.Location = new System.Drawing.Point(54, 120);
            this.tboxThisIP.Name = "tboxThisIP";
            this.tboxThisIP.ReadOnly = true;
            this.tboxThisIP.Size = new System.Drawing.Size(157, 30);
            this.tboxThisIP.TabIndex = 73;
            this.tboxThisIP.Text = "192.168.1.255";
            // 
            // nudThisPort
            // 
            this.nudThisPort.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudThisPort.Location = new System.Drawing.Point(54, 162);
            this.nudThisPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudThisPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.nudThisPort.Name = "nudThisPort";
            this.nudThisPort.Size = new System.Drawing.Size(96, 30);
            this.nudThisPort.TabIndex = 74;
            this.nudThisPort.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 23);
            this.label9.TabIndex = 75;
            this.label9.Text = "Port";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 23);
            this.label10.TabIndex = 76;
            this.label10.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 78;
            this.label2.Text = "9999";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(463, 23);
            this.label7.TabIndex = 70;
            this.label7.Text = "** You must RESTART for any changes to take effect!\r\n";
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
            this.btnSerialCancel.Location = new System.Drawing.Point(363, 332);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(88, 76);
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
            this.btnSerialOK.Location = new System.Drawing.Point(476, 330);
            this.btnSerialOK.Name = "btnSerialOK";
            this.btnSerialOK.Size = new System.Drawing.Size(102, 76);
            this.btnSerialOK.TabIndex = 70;
            this.btnSerialOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSerialOK.UseVisualStyleBackColor = true;
            this.btnSerialOK.Click += new System.EventHandler(this.btnSerialOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(179, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 84;
            this.label3.Text = "8888";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 23);
            this.label4.TabIndex = 83;
            this.label4.Text = "Module Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 23);
            this.label5.TabIndex = 82;
            this.label5.Text = "IP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 23);
            this.label6.TabIndex = 81;
            this.label6.Text = "Port";
            // 
            // nudAutoSteerPort
            // 
            this.nudAutoSteerPort.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAutoSteerPort.Location = new System.Drawing.Point(70, 143);
            this.nudAutoSteerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudAutoSteerPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.nudAutoSteerPort.Name = "nudAutoSteerPort";
            this.nudAutoSteerPort.Size = new System.Drawing.Size(96, 30);
            this.nudAutoSteerPort.TabIndex = 80;
            this.nudAutoSteerPort.Value = new decimal(new int[] {
            8888,
            0,
            0,
            0});
            // 
            // tboxAutoSteerIP
            // 
            this.tboxAutoSteerIP.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxAutoSteerIP.Location = new System.Drawing.Point(70, 95);
            this.tboxAutoSteerIP.Name = "tboxAutoSteerIP";
            this.tboxAutoSteerIP.Size = new System.Drawing.Size(167, 30);
            this.tboxAutoSteerIP.TabIndex = 79;
            this.tboxAutoSteerIP.Text = "192.168.1.255";
            this.tboxAutoSteerIP.Click += new System.EventHandler(this.tboxAutoSteerIP_Click);
            this.tboxAutoSteerIP.Validating += new System.ComponentModel.CancelEventHandler(this.tboxAutoSteerIP_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tboxAutoSteerIP);
            this.groupBox1.Controls.Add(this.nudAutoSteerPort);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(318, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 232);
            this.groupBox1.TabIndex = 91;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Module Adress and Ports";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(30, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 23);
            this.label8.TabIndex = 94;
            this.label8.Text = "All modules use 8888.";
            // 
            // cboxIsUDPOn
            // 
            this.cboxIsUDPOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsUDPOn.AutoSize = true;
            this.cboxIsUDPOn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxIsUDPOn.Checked = true;
            this.cboxIsUDPOn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxIsUDPOn.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxIsUDPOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsUDPOn.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsUDPOn.Location = new System.Drawing.Point(107, 37);
            this.cboxIsUDPOn.Name = "cboxIsUDPOn";
            this.cboxIsUDPOn.Size = new System.Drawing.Size(126, 45);
            this.cboxIsUDPOn.TabIndex = 92;
            this.cboxIsUDPOn.Text = "UDP On";
            this.cboxIsUDPOn.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboxIsUDPOn);
            this.groupBox2.Location = new System.Drawing.Point(18, 306);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 100);
            this.groupBox2.TabIndex = 93;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Networking";
            // 
            // FormUDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 417);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnSerialCancel);
            this.Controls.Add(this.btnSerialOK);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudThisPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoSteerPort)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Button btnSerialOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudAutoSteerPort;
        private System.Windows.Forms.TextBox tboxAutoSteerIP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tboxThisIP;
        private System.Windows.Forms.NumericUpDown nudThisPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxHostName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cboxIsUDPOn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
    }
}