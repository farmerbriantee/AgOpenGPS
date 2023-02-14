namespace AgIO
{
    partial class FormUDPMonitor
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
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.textBoxRcv = new System.Windows.Forms.TextBox();
            this.btnLog = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnFileSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLogNMEA = new System.Windows.Forms.Button();
            this.lblSteerAngle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogNTRIP = new System.Windows.Forms.Button();
            this.lblPGNGuide = new System.Windows.Forms.Label();
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
            this.btnSerialCancel.Image = global::AgIO.Properties.Resources.OK64;
            this.btnSerialCancel.Location = new System.Drawing.Point(386, 232);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(65, 54);
            this.btnSerialCancel.TabIndex = 71;
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            this.btnSerialCancel.Click += new System.EventHandler(this.btnSerialCancel_Click);
            // 
            // textBoxRcv
            // 
            this.textBoxRcv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRcv.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxRcv.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRcv.Location = new System.Drawing.Point(6, 31);
            this.textBoxRcv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRcv.Multiline = true;
            this.textBoxRcv.Name = "textBoxRcv";
            this.textBoxRcv.ReadOnly = true;
            this.textBoxRcv.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxRcv.Size = new System.Drawing.Size(437, 194);
            this.textBoxRcv.TabIndex = 539;
            this.textBoxRcv.WordWrap = false;
            // 
            // btnLog
            // 
            this.btnLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLog.BackColor = System.Drawing.Color.LightGreen;
            this.btnLog.FlatAppearance.BorderSize = 0;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.Image = global::AgIO.Properties.Resources.LogNMEA;
            this.btnLog.Location = new System.Drawing.Point(290, 232);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(78, 54);
            this.btnLog.TabIndex = 541;
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 333;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnFileSave
            // 
            this.btnFileSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileSave.BackColor = System.Drawing.Color.Transparent;
            this.btnFileSave.FlatAppearance.BorderSize = 0;
            this.btnFileSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileSave.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileSave.Image = global::AgIO.Properties.Resources.VehFileSave;
            this.btnFileSave.Location = new System.Drawing.Point(77, 233);
            this.btnFileSave.Name = "btnFileSave";
            this.btnFileSave.Size = new System.Drawing.Size(53, 53);
            this.btnFileSave.TabIndex = 542;
            this.btnFileSave.UseVisualStyleBackColor = false;
            this.btnFileSave.Click += new System.EventHandler(this.btnFileSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::AgIO.Properties.Resources.Trash;
            this.btnClear.Location = new System.Drawing.Point(6, 233);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(53, 53);
            this.btnClear.TabIndex = 543;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLogNMEA
            // 
            this.btnLogNMEA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogNMEA.BackColor = System.Drawing.Color.Transparent;
            this.btnLogNMEA.FlatAppearance.BorderSize = 0;
            this.btnLogNMEA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogNMEA.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogNMEA.Image = global::AgIO.Properties.Resources.Nmea;
            this.btnLogNMEA.Location = new System.Drawing.Point(219, 233);
            this.btnLogNMEA.Name = "btnLogNMEA";
            this.btnLogNMEA.Size = new System.Drawing.Size(53, 53);
            this.btnLogNMEA.TabIndex = 544;
            this.btnLogNMEA.UseVisualStyleBackColor = false;
            this.btnLogNMEA.Click += new System.EventHandler(this.btnLogNMEA_Click);
            // 
            // lblSteerAngle
            // 
            this.lblSteerAngle.AutoSize = true;
            this.lblSteerAngle.BackColor = System.Drawing.Color.Transparent;
            this.lblSteerAngle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerAngle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSteerAngle.Location = new System.Drawing.Point(15, 8);
            this.lblSteerAngle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSteerAngle.Name = "lblSteerAngle";
            this.lblSteerAngle.Size = new System.Drawing.Size(44, 18);
            this.lblSteerAngle.TabIndex = 545;
            this.lblSteerAngle.Text = "Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(100, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 546;
            this.label1.Text = "IP Address : Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(310, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 547;
            this.label2.Text = "PGN";
            // 
            // btnLogNTRIP
            // 
            this.btnLogNTRIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogNTRIP.BackColor = System.Drawing.Color.Transparent;
            this.btnLogNTRIP.FlatAppearance.BorderSize = 0;
            this.btnLogNTRIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogNTRIP.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogNTRIP.Image = global::AgIO.Properties.Resources.NTRIP_Client;
            this.btnLogNTRIP.Location = new System.Drawing.Point(148, 233);
            this.btnLogNTRIP.Name = "btnLogNTRIP";
            this.btnLogNTRIP.Size = new System.Drawing.Size(53, 53);
            this.btnLogNTRIP.TabIndex = 548;
            this.btnLogNTRIP.UseVisualStyleBackColor = false;
            this.btnLogNTRIP.Click += new System.EventHandler(this.btnLogNTRIP_Click);
            // 
            // lblPGNGuide
            // 
            this.lblPGNGuide.AutoSize = true;
            this.lblPGNGuide.BackColor = System.Drawing.Color.Transparent;
            this.lblPGNGuide.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPGNGuide.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPGNGuide.Location = new System.Drawing.Point(381, 8);
            this.lblPGNGuide.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPGNGuide.Name = "lblPGNGuide";
            this.lblPGNGuide.Size = new System.Drawing.Size(73, 18);
            this.lblPGNGuide.TabIndex = 549;
            this.lblPGNGuide.Text = "Guide ->";
            this.lblPGNGuide.Click += new System.EventHandler(this.lblPGNGuide_Click);
            // 
            // FormUDPMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(456, 291);
            this.ControlBox = false;
            this.Controls.Add(this.lblPGNGuide);
            this.Controls.Add(this.btnLogNTRIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSteerAngle);
            this.Controls.Add(this.btnLogNMEA);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFileSave);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.textBoxRcv);
            this.Controls.Add(this.btnSerialCancel);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(465, 307);
            this.Name = "FormUDPMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UDP Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUDPMonitor_FormClosing);
            this.Load += new System.EventHandler(this.FormUDp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.TextBox textBoxRcv;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnFileSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnLogNMEA;
        private System.Windows.Forms.Label lblSteerAngle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogNTRIP;
        private System.Windows.Forms.Label lblPGNGuide;
    }
}