namespace AgIO
{
    partial class FormEthernet
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboxIsUDPOn = new System.Windows.Forms.CheckBox();
            this.nudThirdIP = new System.Windows.Forms.NumericUpDown();
            this.nudSecndIP = new System.Windows.Forms.NumericUpDown();
            this.nudFirstIP = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudFourthIP = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThirdIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecndIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFirstIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFourthIP)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudFourthIP);
            this.groupBox3.Controls.Add(this.nudThirdIP);
            this.groupBox3.Controls.Add(this.nudFirstIP);
            this.groupBox3.Controls.Add(this.nudSecndIP);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 54);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(401, 119);
            this.groupBox3.TabIndex = 94;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Linux Only !";
            // 
            // cboxIsUDPOn
            // 
            this.cboxIsUDPOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsUDPOn.BackColor = System.Drawing.Color.LightSalmon;
            this.cboxIsUDPOn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxIsUDPOn.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxIsUDPOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsUDPOn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsUDPOn.Location = new System.Drawing.Point(573, 65);
            this.cboxIsUDPOn.Name = "cboxIsUDPOn";
            this.cboxIsUDPOn.Size = new System.Drawing.Size(181, 61);
            this.cboxIsUDPOn.TabIndex = 92;
            this.cboxIsUDPOn.Text = "UDP Is Off";
            this.cboxIsUDPOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsUDPOn.UseVisualStyleBackColor = false;
            this.cboxIsUDPOn.Click += new System.EventHandler(this.cboxIsUDPOn_Click);
            // 
            // nudThirdIP
            // 
            this.nudThirdIP.BackColor = System.Drawing.Color.AliceBlue;
            this.nudThirdIP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudThirdIP.Location = new System.Drawing.Point(215, 53);
            this.nudThirdIP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudThirdIP.Name = "nudThirdIP";
            this.nudThirdIP.Size = new System.Drawing.Size(77, 33);
            this.nudThirdIP.TabIndex = 527;
            this.nudThirdIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudThirdIP.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudThirdIP.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudThirdIP.Click += new System.EventHandler(this.nudFirstIP_Click);
            // 
            // nudSecndIP
            // 
            this.nudSecndIP.BackColor = System.Drawing.Color.AliceBlue;
            this.nudSecndIP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSecndIP.Location = new System.Drawing.Point(122, 53);
            this.nudSecndIP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSecndIP.Name = "nudSecndIP";
            this.nudSecndIP.Size = new System.Drawing.Size(77, 33);
            this.nudSecndIP.TabIndex = 526;
            this.nudSecndIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSecndIP.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudSecndIP.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSecndIP.Click += new System.EventHandler(this.nudFirstIP_Click);
            // 
            // nudFirstIP
            // 
            this.nudFirstIP.BackColor = System.Drawing.Color.AliceBlue;
            this.nudFirstIP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFirstIP.Location = new System.Drawing.Point(30, 53);
            this.nudFirstIP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudFirstIP.Name = "nudFirstIP";
            this.nudFirstIP.Size = new System.Drawing.Size(77, 33);
            this.nudFirstIP.TabIndex = 525;
            this.nudFirstIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudFirstIP.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudFirstIP.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.nudFirstIP.Click += new System.EventHandler(this.nudFirstIP_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(105, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 25);
            this.label2.TabIndex = 528;
            this.label2.Text = ".";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(198, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 25);
            this.label3.TabIndex = 529;
            this.label3.Text = ".";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudFourthIP
            // 
            this.nudFourthIP.BackColor = System.Drawing.Color.AliceBlue;
            this.nudFourthIP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFourthIP.Location = new System.Drawing.Point(303, 53);
            this.nudFourthIP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudFourthIP.Name = "nudFourthIP";
            this.nudFourthIP.Size = new System.Drawing.Size(77, 33);
            this.nudFourthIP.TabIndex = 530;
            this.nudFourthIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudFourthIP.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudFourthIP.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudFourthIP.Click += new System.EventHandler(this.nudFirstIP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(288, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 25);
            this.label1.TabIndex = 531;
            this.label1.Text = ".";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.FlatAppearance.BorderSize = 0;
            this.btnSerialCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialCancel.Image = global::AgIO.Properties.Resources.OK64;
            this.btnSerialCancel.Location = new System.Drawing.Point(624, 163);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(92, 79);
            this.btnSerialCancel.TabIndex = 71;
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            this.btnSerialCancel.Click += new System.EventHandler(this.btnSerialCancel_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(589, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 50);
            this.label4.TabIndex = 532;
            this.label4.Text = "Turn UDP On And Hit OK";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormEthernet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(772, 254);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboxIsUDPOn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSerialCancel);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEthernet";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ethernet Configuration";
            this.Load += new System.EventHandler(this.FormUDp_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThirdIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecndIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFirstIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFourthIP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cboxIsUDPOn;
        private System.Windows.Forms.NumericUpDown nudThirdIP;
        private System.Windows.Forms.NumericUpDown nudSecndIP;
        private System.Windows.Forms.NumericUpDown nudFirstIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudFourthIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}