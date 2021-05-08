
namespace RateController
{
    partial class frmComm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComm));
            this.bntOK = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnConnect3 = new System.Windows.Forms.Button();
            this.cboPort3 = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cboBaud3 = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.PortIndicator3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConnect2 = new System.Windows.Forms.Button();
            this.cboPort2 = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cboBaud2 = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.PortIndicator2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnConnect1 = new System.Windows.Forms.Button();
            this.cboPort1 = new System.Windows.Forms.ComboBox();
            this.lbBaud = new System.Windows.Forms.Label();
            this.cboBaud1 = new System.Windows.Forms.ComboBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.PortIndicator1 = new System.Windows.Forms.Label();
            this.btnRescan = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bntOK
            // 
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntOK.Image = ((System.Drawing.Image)(resources.GetObject("bntOK.Image")));
            this.bntOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntOK.Location = new System.Drawing.Point(242, 334);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(115, 72);
            this.bntOK.TabIndex = 136;
            this.bntOK.Text = "Close";
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnConnect3);
            this.groupBox4.Controls.Add(this.cboPort3);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.cboBaud3);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.PortIndicator3);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(6, 229);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(478, 99);
            this.groupBox4.TabIndex = 149;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Serial3";
            this.groupBox4.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox3_Paint);
            // 
            // btnConnect3
            // 
            this.btnConnect3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnConnect3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConnect3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect3.Location = new System.Drawing.Point(17, 45);
            this.btnConnect3.Name = "btnConnect3";
            this.btnConnect3.Size = new System.Drawing.Size(127, 37);
            this.btnConnect3.TabIndex = 122;
            this.btnConnect3.Text = "Connect";
            this.btnConnect3.UseVisualStyleBackColor = false;
            this.btnConnect3.Click += new System.EventHandler(this.btnConnect3_Click);
            // 
            // cboPort3
            // 
            this.cboPort3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboPort3.FormattingEnabled = true;
            this.cboPort3.Location = new System.Drawing.Point(150, 45);
            this.cboPort3.Name = "cboPort3";
            this.cboPort3.Size = new System.Drawing.Size(127, 37);
            this.cboPort3.TabIndex = 121;
            this.cboPort3.SelectedIndexChanged += new System.EventHandler(this.cboPort3_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(283, 18);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(127, 23);
            this.label28.TabIndex = 125;
            this.label28.Text = "Baud";
            this.label28.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboBaud3
            // 
            this.cboBaud3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboBaud3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaud3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboBaud3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboBaud3.FormattingEnabled = true;
            this.cboBaud3.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cboBaud3.Location = new System.Drawing.Point(283, 45);
            this.cboBaud3.Name = "cboBaud3";
            this.cboBaud3.Size = new System.Drawing.Size(127, 37);
            this.cboBaud3.TabIndex = 124;
            this.cboBaud3.SelectedIndexChanged += new System.EventHandler(this.cboBaud3_SelectedIndexChanged);
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(150, 18);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(127, 23);
            this.label29.TabIndex = 120;
            this.label29.Text = "Port";
            this.label29.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PortIndicator3
            // 
            this.PortIndicator3.BackColor = System.Drawing.SystemColors.Control;
            this.PortIndicator3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortIndicator3.Image = global::RateController.Properties.Resources.Off;
            this.PortIndicator3.Location = new System.Drawing.Point(416, 45);
            this.PortIndicator3.Name = "PortIndicator3";
            this.PortIndicator3.Size = new System.Drawing.Size(41, 37);
            this.PortIndicator3.TabIndex = 123;
            this.PortIndicator3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConnect2);
            this.groupBox2.Controls.Add(this.cboPort2);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.cboBaud2);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.PortIndicator2);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 99);
            this.groupBox2.TabIndex = 148;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serial2";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox3_Paint);
            // 
            // btnConnect2
            // 
            this.btnConnect2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnConnect2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConnect2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect2.Location = new System.Drawing.Point(17, 45);
            this.btnConnect2.Name = "btnConnect2";
            this.btnConnect2.Size = new System.Drawing.Size(127, 37);
            this.btnConnect2.TabIndex = 122;
            this.btnConnect2.Text = "Connect";
            this.btnConnect2.UseVisualStyleBackColor = false;
            this.btnConnect2.Click += new System.EventHandler(this.btnConnect2_Click);
            // 
            // cboPort2
            // 
            this.cboPort2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboPort2.FormattingEnabled = true;
            this.cboPort2.Location = new System.Drawing.Point(150, 45);
            this.cboPort2.Name = "cboPort2";
            this.cboPort2.Size = new System.Drawing.Size(127, 37);
            this.cboPort2.TabIndex = 121;
            this.cboPort2.SelectedIndexChanged += new System.EventHandler(this.cboPort2_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(283, 18);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(127, 23);
            this.label22.TabIndex = 125;
            this.label22.Text = "Baud";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboBaud2
            // 
            this.cboBaud2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboBaud2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaud2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboBaud2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboBaud2.FormattingEnabled = true;
            this.cboBaud2.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cboBaud2.Location = new System.Drawing.Point(283, 45);
            this.cboBaud2.Name = "cboBaud2";
            this.cboBaud2.Size = new System.Drawing.Size(127, 37);
            this.cboBaud2.TabIndex = 124;
            this.cboBaud2.SelectedIndexChanged += new System.EventHandler(this.cboBaud2_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(150, 18);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(127, 23);
            this.label25.TabIndex = 120;
            this.label25.Text = "Port";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PortIndicator2
            // 
            this.PortIndicator2.BackColor = System.Drawing.SystemColors.Control;
            this.PortIndicator2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortIndicator2.Image = global::RateController.Properties.Resources.Off;
            this.PortIndicator2.Location = new System.Drawing.Point(416, 45);
            this.PortIndicator2.Name = "PortIndicator2";
            this.PortIndicator2.Size = new System.Drawing.Size(41, 37);
            this.PortIndicator2.TabIndex = 123;
            this.PortIndicator2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnConnect1);
            this.groupBox3.Controls.Add(this.cboPort1);
            this.groupBox3.Controls.Add(this.lbBaud);
            this.groupBox3.Controls.Add(this.cboBaud1);
            this.groupBox3.Controls.Add(this.lbPort);
            this.groupBox3.Controls.Add(this.PortIndicator1);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(478, 99);
            this.groupBox3.TabIndex = 147;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Serial1";
            this.groupBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox3_Paint);
            // 
            // btnConnect1
            // 
            this.btnConnect1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnConnect1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConnect1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect1.Location = new System.Drawing.Point(17, 47);
            this.btnConnect1.Name = "btnConnect1";
            this.btnConnect1.Size = new System.Drawing.Size(127, 37);
            this.btnConnect1.TabIndex = 122;
            this.btnConnect1.Text = "Connect";
            this.btnConnect1.UseVisualStyleBackColor = false;
            this.btnConnect1.Click += new System.EventHandler(this.btnConnect1_Click);
            // 
            // cboPort1
            // 
            this.cboPort1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboPort1.FormattingEnabled = true;
            this.cboPort1.Location = new System.Drawing.Point(150, 47);
            this.cboPort1.Name = "cboPort1";
            this.cboPort1.Size = new System.Drawing.Size(127, 37);
            this.cboPort1.TabIndex = 121;
            this.cboPort1.SelectedIndexChanged += new System.EventHandler(this.cboPort1_SelectedIndexChanged);
            // 
            // lbBaud
            // 
            this.lbBaud.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBaud.Location = new System.Drawing.Point(283, 20);
            this.lbBaud.Name = "lbBaud";
            this.lbBaud.Size = new System.Drawing.Size(127, 23);
            this.lbBaud.TabIndex = 125;
            this.lbBaud.Text = "Baud";
            this.lbBaud.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboBaud1
            // 
            this.cboBaud1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboBaud1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaud1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboBaud1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboBaud1.FormattingEnabled = true;
            this.cboBaud1.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cboBaud1.Location = new System.Drawing.Point(283, 47);
            this.cboBaud1.Name = "cboBaud1";
            this.cboBaud1.Size = new System.Drawing.Size(127, 37);
            this.cboBaud1.TabIndex = 124;
            this.cboBaud1.SelectedIndexChanged += new System.EventHandler(this.cboBaud1_SelectedIndexChanged);
            // 
            // lbPort
            // 
            this.lbPort.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPort.Location = new System.Drawing.Point(150, 20);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(127, 23);
            this.lbPort.TabIndex = 120;
            this.lbPort.Text = "Port";
            this.lbPort.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PortIndicator1
            // 
            this.PortIndicator1.BackColor = System.Drawing.SystemColors.Control;
            this.PortIndicator1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortIndicator1.Image = global::RateController.Properties.Resources.Off;
            this.PortIndicator1.Location = new System.Drawing.Point(416, 47);
            this.PortIndicator1.Name = "PortIndicator1";
            this.PortIndicator1.Size = new System.Drawing.Size(41, 37);
            this.PortIndicator1.TabIndex = 123;
            this.PortIndicator1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRescan
            // 
            this.btnRescan.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRescan.Image = ((System.Drawing.Image)(resources.GetObject("btnRescan.Image")));
            this.btnRescan.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRescan.Location = new System.Drawing.Point(112, 334);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(124, 72);
            this.btnRescan.TabIndex = 150;
            this.btnRescan.Text = "Rescan";
            this.btnRescan.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRescan.UseVisualStyleBackColor = true;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // frmComm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 412);
            this.Controls.Add(this.btnRescan);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.bntOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmComm";
            this.ShowInTaskbar = false;
            this.Text = "Comm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmComm_FormClosed);
            this.Load += new System.EventHandler(this.frmComm_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnConnect3;
        private System.Windows.Forms.ComboBox cboPort3;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cboBaud3;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label PortIndicator3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConnect2;
        private System.Windows.Forms.ComboBox cboPort2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cboBaud2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label PortIndicator2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnConnect1;
        private System.Windows.Forms.ComboBox cboPort1;
        private System.Windows.Forms.Label lbBaud;
        private System.Windows.Forms.ComboBox cboBaud1;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label PortIndicator1;
        private System.Windows.Forms.Button btnRescan;
    }
}