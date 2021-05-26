namespace AgIO
{
    partial class FormCommSetGPS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCommSetGPS));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboxPort = new System.Windows.Forms.ComboBox();
            this.cboxBaud = new System.Windows.Forms.ComboBox();
            this.lblCurrentPort = new System.Windows.Forms.Label();
            this.lblCurrentBaud = new System.Windows.Forms.Label();
            this.btnCloseSerial = new System.Windows.Forms.Button();
            this.textBoxRcv = new System.Windows.Forms.TextBox();
            this.btnOpenSerial = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboxPort2 = new System.Windows.Forms.ComboBox();
            this.cboxBaud2 = new System.Windows.Forms.ComboBox();
            this.lblCurrentPort2 = new System.Windows.Forms.Label();
            this.lblCurrentBaud2 = new System.Windows.Forms.Label();
            this.btnCloseSerial2 = new System.Windows.Forms.Button();
            this.textBoxRcv2 = new System.Windows.Forms.TextBox();
            this.btnOpenSerial2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboxModule1Port = new System.Windows.Forms.ComboBox();
            this.lblCurrentModule1Port = new System.Windows.Forms.Label();
            this.btnOpenSerialModule1 = new System.Windows.Forms.Button();
            this.btnCloseSerialModule1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboxModule2Port = new System.Windows.Forms.ComboBox();
            this.lblCurrentModule2Port = new System.Windows.Forms.Label();
            this.btnOpenSerialModule2 = new System.Windows.Forms.Button();
            this.btnCloseSerialModule2 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblCurrentModule3Port = new System.Windows.Forms.Label();
            this.cboxModule3Port = new System.Windows.Forms.ComboBox();
            this.btnOpenSerialModule3 = new System.Windows.Forms.Button();
            this.btnCloseSerialModule3 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblCurrentIMU = new System.Windows.Forms.Label();
            this.cboxIMU = new System.Windows.Forms.ComboBox();
            this.btnCloseIMU = new System.Windows.Forms.Button();
            this.btnOpenIMU = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRescan = new System.Windows.Forms.Button();
            this.btnSerialOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblIMU = new System.Windows.Forms.Label();
            this.lblSteer = new System.Windows.Forms.Label();
            this.lblMachine = new System.Windows.Forms.Label();
            this.lblGPS = new System.Windows.Forms.Label();
            this.lblFromGPS = new System.Windows.Forms.Label();
            this.lblFromMU = new System.Windows.Forms.Label();
            this.lblFromModule1 = new System.Windows.Forms.Label();
            this.lblFromModule2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.cboxPort);
            this.groupBox1.Controls.Add(this.cboxBaud);
            this.groupBox1.Controls.Add(this.lblCurrentPort);
            this.groupBox1.Controls.Add(this.lblCurrentBaud);
            this.groupBox1.Controls.Add(this.btnCloseSerial);
            this.groupBox1.Controls.Add(this.textBoxRcv);
            this.groupBox1.Controls.Add(this.btnOpenSerial);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(173, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(678, 146);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GPS";
            // 
            // cboxPort
            // 
            this.cboxPort.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPort.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboxPort.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboxPort.FormattingEnabled = true;
            this.cboxPort.Location = new System.Drawing.Point(10, 37);
            this.cboxPort.Name = "cboxPort";
            this.cboxPort.Size = new System.Drawing.Size(124, 37);
            this.cboxPort.TabIndex = 50;
            this.cboxPort.SelectedIndexChanged += new System.EventHandler(this.cboxPort_SelectedIndexChanged_1);
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
            this.cboxBaud.Location = new System.Drawing.Point(161, 37);
            this.cboxBaud.Name = "cboxBaud";
            this.cboxBaud.Size = new System.Drawing.Size(127, 37);
            this.cboxBaud.TabIndex = 49;
            this.cboxBaud.SelectedIndexChanged += new System.EventHandler(this.cboxBaud_SelectedIndexChanged_1);
            // 
            // lblCurrentPort
            // 
            this.lblCurrentPort.AutoSize = true;
            this.lblCurrentPort.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPort.Location = new System.Drawing.Point(101, 16);
            this.lblCurrentPort.Name = "lblCurrentPort";
            this.lblCurrentPort.Size = new System.Drawing.Size(40, 18);
            this.lblCurrentPort.TabIndex = 47;
            this.lblCurrentPort.Text = "Port";
            // 
            // lblCurrentBaud
            // 
            this.lblCurrentBaud.AutoSize = true;
            this.lblCurrentBaud.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBaud.Location = new System.Drawing.Point(243, 16);
            this.lblCurrentBaud.Name = "lblCurrentBaud";
            this.lblCurrentBaud.Size = new System.Drawing.Size(45, 18);
            this.lblCurrentBaud.TabIndex = 46;
            this.lblCurrentBaud.Text = "Baud";
            // 
            // btnCloseSerial
            // 
            this.btnCloseSerial.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseSerial.FlatAppearance.BorderSize = 0;
            this.btnCloseSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseSerial.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseSerial.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseSerial.Image")));
            this.btnCloseSerial.Location = new System.Drawing.Point(459, 16);
            this.btnCloseSerial.Name = "btnCloseSerial";
            this.btnCloseSerial.Size = new System.Drawing.Size(101, 58);
            this.btnCloseSerial.TabIndex = 44;
            this.btnCloseSerial.UseVisualStyleBackColor = false;
            this.btnCloseSerial.Click += new System.EventHandler(this.btnCloseSerial_Click);
            // 
            // textBoxRcv
            // 
            this.textBoxRcv.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxRcv.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.textBoxRcv.Location = new System.Drawing.Point(7, 82);
            this.textBoxRcv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRcv.Multiline = true;
            this.textBoxRcv.Name = "textBoxRcv";
            this.textBoxRcv.ReadOnly = true;
            this.textBoxRcv.Size = new System.Drawing.Size(661, 53);
            this.textBoxRcv.TabIndex = 40;
            // 
            // btnOpenSerial
            // 
            this.btnOpenSerial.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenSerial.FlatAppearance.BorderSize = 0;
            this.btnOpenSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenSerial.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSerial.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenSerial.Image")));
            this.btnOpenSerial.Location = new System.Drawing.Point(329, 16);
            this.btnOpenSerial.Name = "btnOpenSerial";
            this.btnOpenSerial.Size = new System.Drawing.Size(101, 58);
            this.btnOpenSerial.TabIndex = 45;
            this.btnOpenSerial.UseVisualStyleBackColor = false;
            this.btnOpenSerial.Click += new System.EventHandler(this.btnOpenSerial_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.cboxPort2);
            this.groupBox2.Controls.Add(this.cboxBaud2);
            this.groupBox2.Controls.Add(this.lblCurrentPort2);
            this.groupBox2.Controls.Add(this.lblCurrentBaud2);
            this.groupBox2.Controls.Add(this.btnCloseSerial2);
            this.groupBox2.Controls.Add(this.textBoxRcv2);
            this.groupBox2.Controls.Add(this.btnOpenSerial2);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(1118, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 120);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GPS Port 2";
            // 
            // cboxPort2
            // 
            this.cboxPort2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboxPort2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPort2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboxPort2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboxPort2.FormattingEnabled = true;
            this.cboxPort2.Location = new System.Drawing.Point(10, 37);
            this.cboxPort2.Name = "cboxPort2";
            this.cboxPort2.Size = new System.Drawing.Size(169, 37);
            this.cboxPort2.TabIndex = 50;
            this.cboxPort2.SelectedIndexChanged += new System.EventHandler(this.cboxPort2_SelectedIndexChanged);
            // 
            // cboxBaud2
            // 
            this.cboxBaud2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboxBaud2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxBaud2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboxBaud2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboxBaud2.FormattingEnabled = true;
            this.cboxBaud2.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cboxBaud2.Location = new System.Drawing.Point(198, 37);
            this.cboxBaud2.Name = "cboxBaud2";
            this.cboxBaud2.Size = new System.Drawing.Size(127, 37);
            this.cboxBaud2.TabIndex = 49;
            this.cboxBaud2.SelectedIndexChanged += new System.EventHandler(this.cboxBaud2_SelectedIndexChanged);
            // 
            // lblCurrentPort2
            // 
            this.lblCurrentPort2.AutoSize = true;
            this.lblCurrentPort2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPort2.Location = new System.Drawing.Point(139, 16);
            this.lblCurrentPort2.Name = "lblCurrentPort2";
            this.lblCurrentPort2.Size = new System.Drawing.Size(40, 18);
            this.lblCurrentPort2.TabIndex = 47;
            this.lblCurrentPort2.Text = "Port";
            // 
            // lblCurrentBaud2
            // 
            this.lblCurrentBaud2.AutoSize = true;
            this.lblCurrentBaud2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBaud2.Location = new System.Drawing.Point(280, 16);
            this.lblCurrentBaud2.Name = "lblCurrentBaud2";
            this.lblCurrentBaud2.Size = new System.Drawing.Size(45, 18);
            this.lblCurrentBaud2.TabIndex = 46;
            this.lblCurrentBaud2.Text = "Baud";
            // 
            // btnCloseSerial2
            // 
            this.btnCloseSerial2.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseSerial2.FlatAppearance.BorderSize = 0;
            this.btnCloseSerial2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseSerial2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseSerial2.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseSerial2.Image")));
            this.btnCloseSerial2.Location = new System.Drawing.Point(313, 37);
            this.btnCloseSerial2.Name = "btnCloseSerial2";
            this.btnCloseSerial2.Size = new System.Drawing.Size(101, 58);
            this.btnCloseSerial2.TabIndex = 44;
            this.btnCloseSerial2.UseVisualStyleBackColor = false;
            this.btnCloseSerial2.Click += new System.EventHandler(this.btnCloseSerial2_Click);
            // 
            // textBoxRcv2
            // 
            this.textBoxRcv2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRcv2.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxRcv2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.textBoxRcv2.Location = new System.Drawing.Point(-355, 81);
            this.textBoxRcv2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRcv2.Multiline = true;
            this.textBoxRcv2.Name = "textBoxRcv2";
            this.textBoxRcv2.ReadOnly = true;
            this.textBoxRcv2.Size = new System.Drawing.Size(176, 31);
            this.textBoxRcv2.TabIndex = 40;
            // 
            // btnOpenSerial2
            // 
            this.btnOpenSerial2.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenSerial2.FlatAppearance.BorderSize = 0;
            this.btnOpenSerial2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenSerial2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSerial2.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenSerial2.Image")));
            this.btnOpenSerial2.Location = new System.Drawing.Point(224, 54);
            this.btnOpenSerial2.Name = "btnOpenSerial2";
            this.btnOpenSerial2.Size = new System.Drawing.Size(101, 58);
            this.btnOpenSerial2.TabIndex = 45;
            this.btnOpenSerial2.UseVisualStyleBackColor = false;
            this.btnOpenSerial2.Click += new System.EventHandler(this.btnOpenSerial2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.cboxModule1Port);
            this.groupBox3.Controls.Add(this.lblCurrentModule1Port);
            this.groupBox3.Controls.Add(this.btnOpenSerialModule1);
            this.groupBox3.Controls.Add(this.btnCloseSerialModule1);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(173, 355);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(369, 117);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Steer";
            // 
            // cboxModule1Port
            // 
            this.cboxModule1Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxModule1Port.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboxModule1Port.FormattingEnabled = true;
            this.cboxModule1Port.Location = new System.Drawing.Point(10, 57);
            this.cboxModule1Port.Name = "cboxModule1Port";
            this.cboxModule1Port.Size = new System.Drawing.Size(124, 37);
            this.cboxModule1Port.TabIndex = 64;
            this.cboxModule1Port.SelectedIndexChanged += new System.EventHandler(this.cboxModule1_SelectedIndexChanged);
            // 
            // lblCurrentModule1Port
            // 
            this.lblCurrentModule1Port.AutoSize = true;
            this.lblCurrentModule1Port.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentModule1Port.Location = new System.Drawing.Point(22, 36);
            this.lblCurrentModule1Port.Name = "lblCurrentModule1Port";
            this.lblCurrentModule1Port.Size = new System.Drawing.Size(40, 18);
            this.lblCurrentModule1Port.TabIndex = 69;
            this.lblCurrentModule1Port.Text = "Port";
            // 
            // btnOpenSerialModule1
            // 
            this.btnOpenSerialModule1.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenSerialModule1.FlatAppearance.BorderSize = 0;
            this.btnOpenSerialModule1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenSerialModule1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSerialModule1.Image = global::AgIO.Properties.Resources.USB_Connect;
            this.btnOpenSerialModule1.Location = new System.Drawing.Point(161, 29);
            this.btnOpenSerialModule1.Name = "btnOpenSerialModule1";
            this.btnOpenSerialModule1.Size = new System.Drawing.Size(101, 58);
            this.btnOpenSerialModule1.TabIndex = 53;
            this.btnOpenSerialModule1.UseVisualStyleBackColor = false;
            this.btnOpenSerialModule1.Click += new System.EventHandler(this.btnOpenSerialModule1_Click);
            // 
            // btnCloseSerialModule1
            // 
            this.btnCloseSerialModule1.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseSerialModule1.FlatAppearance.BorderSize = 0;
            this.btnCloseSerialModule1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseSerialModule1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseSerialModule1.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseSerialModule1.Image")));
            this.btnCloseSerialModule1.Location = new System.Drawing.Point(268, 29);
            this.btnCloseSerialModule1.Name = "btnCloseSerialModule1";
            this.btnCloseSerialModule1.Size = new System.Drawing.Size(101, 58);
            this.btnCloseSerialModule1.TabIndex = 52;
            this.btnCloseSerialModule1.UseVisualStyleBackColor = false;
            this.btnCloseSerialModule1.Click += new System.EventHandler(this.btnCloseSerialModule1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.cboxModule2Port);
            this.groupBox4.Controls.Add(this.lblCurrentModule2Port);
            this.groupBox4.Controls.Add(this.btnOpenSerialModule2);
            this.groupBox4.Controls.Add(this.btnCloseSerialModule2);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(173, 518);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(369, 117);
            this.groupBox4.TabIndex = 67;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Machine";
            // 
            // cboxModule2Port
            // 
            this.cboxModule2Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxModule2Port.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboxModule2Port.FormattingEnabled = true;
            this.cboxModule2Port.Location = new System.Drawing.Point(10, 62);
            this.cboxModule2Port.Name = "cboxModule2Port";
            this.cboxModule2Port.Size = new System.Drawing.Size(124, 37);
            this.cboxModule2Port.TabIndex = 64;
            this.cboxModule2Port.SelectedIndexChanged += new System.EventHandler(this.cboxModule2Port_SelectedIndexChanged);
            // 
            // lblCurrentModule2Port
            // 
            this.lblCurrentModule2Port.AutoSize = true;
            this.lblCurrentModule2Port.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentModule2Port.Location = new System.Drawing.Point(22, 41);
            this.lblCurrentModule2Port.Name = "lblCurrentModule2Port";
            this.lblCurrentModule2Port.Size = new System.Drawing.Size(40, 18);
            this.lblCurrentModule2Port.TabIndex = 70;
            this.lblCurrentModule2Port.Text = "Port";
            // 
            // btnOpenSerialModule2
            // 
            this.btnOpenSerialModule2.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenSerialModule2.FlatAppearance.BorderSize = 0;
            this.btnOpenSerialModule2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenSerialModule2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSerialModule2.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenSerialModule2.Image")));
            this.btnOpenSerialModule2.Location = new System.Drawing.Point(161, 31);
            this.btnOpenSerialModule2.Name = "btnOpenSerialModule2";
            this.btnOpenSerialModule2.Size = new System.Drawing.Size(101, 58);
            this.btnOpenSerialModule2.TabIndex = 53;
            this.btnOpenSerialModule2.UseVisualStyleBackColor = false;
            this.btnOpenSerialModule2.Click += new System.EventHandler(this.btnOpenSerialModule2_Click);
            // 
            // btnCloseSerialModule2
            // 
            this.btnCloseSerialModule2.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseSerialModule2.FlatAppearance.BorderSize = 0;
            this.btnCloseSerialModule2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseSerialModule2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseSerialModule2.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseSerialModule2.Image")));
            this.btnCloseSerialModule2.Location = new System.Drawing.Point(268, 31);
            this.btnCloseSerialModule2.Name = "btnCloseSerialModule2";
            this.btnCloseSerialModule2.Size = new System.Drawing.Size(101, 58);
            this.btnCloseSerialModule2.TabIndex = 52;
            this.btnCloseSerialModule2.UseVisualStyleBackColor = false;
            this.btnCloseSerialModule2.Click += new System.EventHandler(this.btnCloseSerialModule2_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox5.Controls.Add(this.lblCurrentModule3Port);
            this.groupBox5.Controls.Add(this.cboxModule3Port);
            this.groupBox5.Controls.Add(this.btnOpenSerialModule3);
            this.groupBox5.Controls.Add(this.btnCloseSerialModule3);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox5.Location = new System.Drawing.Point(1164, 222);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(368, 90);
            this.groupBox5.TabIndex = 68;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Module 3";
            // 
            // lblCurrentModule3Port
            // 
            this.lblCurrentModule3Port.AutoSize = true;
            this.lblCurrentModule3Port.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentModule3Port.Location = new System.Drawing.Point(115, 19);
            this.lblCurrentModule3Port.Name = "lblCurrentModule3Port";
            this.lblCurrentModule3Port.Size = new System.Drawing.Size(40, 18);
            this.lblCurrentModule3Port.TabIndex = 71;
            this.lblCurrentModule3Port.Text = "Port";
            // 
            // cboxModule3Port
            // 
            this.cboxModule3Port.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboxModule3Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxModule3Port.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboxModule3Port.FormattingEnabled = true;
            this.cboxModule3Port.Location = new System.Drawing.Point(10, 42);
            this.cboxModule3Port.Name = "cboxModule3Port";
            this.cboxModule3Port.Size = new System.Drawing.Size(124, 37);
            this.cboxModule3Port.TabIndex = 64;
            this.cboxModule3Port.SelectedIndexChanged += new System.EventHandler(this.cboxModule3Port_SelectedIndexChanged);
            // 
            // btnOpenSerialModule3
            // 
            this.btnOpenSerialModule3.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenSerialModule3.FlatAppearance.BorderSize = 0;
            this.btnOpenSerialModule3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenSerialModule3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSerialModule3.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenSerialModule3.Image")));
            this.btnOpenSerialModule3.Location = new System.Drawing.Point(161, 21);
            this.btnOpenSerialModule3.Name = "btnOpenSerialModule3";
            this.btnOpenSerialModule3.Size = new System.Drawing.Size(101, 58);
            this.btnOpenSerialModule3.TabIndex = 53;
            this.btnOpenSerialModule3.UseVisualStyleBackColor = false;
            this.btnOpenSerialModule3.Click += new System.EventHandler(this.btnOpenSerialModule3_Click);
            // 
            // btnCloseSerialModule3
            // 
            this.btnCloseSerialModule3.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseSerialModule3.FlatAppearance.BorderSize = 0;
            this.btnCloseSerialModule3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseSerialModule3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseSerialModule3.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseSerialModule3.Image")));
            this.btnCloseSerialModule3.Location = new System.Drawing.Point(268, 19);
            this.btnCloseSerialModule3.Name = "btnCloseSerialModule3";
            this.btnCloseSerialModule3.Size = new System.Drawing.Size(101, 58);
            this.btnCloseSerialModule3.TabIndex = 52;
            this.btnCloseSerialModule3.UseVisualStyleBackColor = false;
            this.btnCloseSerialModule3.Click += new System.EventHandler(this.btnCloseSerialModule3_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox6.Controls.Add(this.lblCurrentIMU);
            this.groupBox6.Controls.Add(this.cboxIMU);
            this.groupBox6.Controls.Add(this.btnCloseIMU);
            this.groupBox6.Controls.Add(this.btnOpenIMU);
            this.groupBox6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox6.Location = new System.Drawing.Point(173, 192);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(369, 117);
            this.groupBox6.TabIndex = 68;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "IMU";
            // 
            // lblCurrentIMU
            // 
            this.lblCurrentIMU.AutoSize = true;
            this.lblCurrentIMU.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentIMU.Location = new System.Drawing.Point(22, 37);
            this.lblCurrentIMU.Name = "lblCurrentIMU";
            this.lblCurrentIMU.Size = new System.Drawing.Size(40, 18);
            this.lblCurrentIMU.TabIndex = 51;
            this.lblCurrentIMU.Text = "Port";
            // 
            // cboxIMU
            // 
            this.cboxIMU.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboxIMU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIMU.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboxIMU.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboxIMU.FormattingEnabled = true;
            this.cboxIMU.Location = new System.Drawing.Point(10, 58);
            this.cboxIMU.Name = "cboxIMU";
            this.cboxIMU.Size = new System.Drawing.Size(124, 37);
            this.cboxIMU.TabIndex = 50;
            this.cboxIMU.SelectedIndexChanged += new System.EventHandler(this.cboxIMU_SelectedIndexChanged);
            // 
            // btnCloseIMU
            // 
            this.btnCloseIMU.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseIMU.FlatAppearance.BorderSize = 0;
            this.btnCloseIMU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseIMU.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseIMU.Image = global::AgIO.Properties.Resources.USB_Disconnect;
            this.btnCloseIMU.Location = new System.Drawing.Point(262, 34);
            this.btnCloseIMU.Name = "btnCloseIMU";
            this.btnCloseIMU.Size = new System.Drawing.Size(101, 58);
            this.btnCloseIMU.TabIndex = 44;
            this.btnCloseIMU.UseVisualStyleBackColor = false;
            this.btnCloseIMU.Click += new System.EventHandler(this.btnCloseIMU_Click);
            // 
            // btnOpenIMU
            // 
            this.btnOpenIMU.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenIMU.FlatAppearance.BorderSize = 0;
            this.btnOpenIMU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenIMU.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenIMU.Image = global::AgIO.Properties.Resources.USB_Connect;
            this.btnOpenIMU.Location = new System.Drawing.Point(161, 34);
            this.btnOpenIMU.Name = "btnOpenIMU";
            this.btnOpenIMU.Size = new System.Drawing.Size(101, 58);
            this.btnOpenIMU.TabIndex = 45;
            this.btnOpenIMU.UseVisualStyleBackColor = false;
            this.btnOpenIMU.Click += new System.EventHandler(this.btnOpenIMU_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::AgIO.Properties.Resources.satellite;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(36, 28);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(120, 120);
            this.pictureBox4.TabIndex = 72;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::AgIO.Properties.Resources.Com_Module2;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(27, 515);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(120, 120);
            this.pictureBox3.TabIndex = 71;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::AgIO.Properties.Resources.Com_AutosteerModule;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(27, 352);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(120, 120);
            this.pictureBox2.TabIndex = 70;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AgIO.Properties.Resources.Com_IMUModule;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(27, 189);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.TabIndex = 69;
            this.pictureBox1.TabStop = false;
            // 
            // btnRescan
            // 
            this.btnRescan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRescan.BackColor = System.Drawing.Color.Transparent;
            this.btnRescan.FlatAppearance.BorderSize = 0;
            this.btnRescan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRescan.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRescan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRescan.Image = global::AgIO.Properties.Resources.ScanPorts;
            this.btnRescan.Location = new System.Drawing.Point(601, 589);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(89, 63);
            this.btnRescan.TabIndex = 58;
            this.btnRescan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRescan.UseVisualStyleBackColor = false;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // btnSerialOK
            // 
            this.btnSerialOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialOK.BackColor = System.Drawing.Color.Transparent;
            this.btnSerialOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialOK.FlatAppearance.BorderSize = 0;
            this.btnSerialOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialOK.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSerialOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSerialOK.Image = global::AgIO.Properties.Resources.OK64;
            this.btnSerialOK.Location = new System.Drawing.Point(762, 588);
            this.btnSerialOK.Name = "btnSerialOK";
            this.btnSerialOK.Size = new System.Drawing.Size(91, 63);
            this.btnSerialOK.TabIndex = 59;
            this.btnSerialOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSerialOK.UseVisualStyleBackColor = false;
            this.btnSerialOK.Click += new System.EventHandler(this.btnSerialOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(625, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 73;
            this.label1.Text = "GPS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(413, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 18);
            this.label2.TabIndex = 74;
            this.label2.Text = "GPS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(584, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 76;
            this.label4.Text = "Machine:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(613, 319);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 23);
            this.label5.TabIndex = 77;
            this.label5.Text = "Steer:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(623, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 23);
            this.label6.TabIndex = 78;
            this.label6.Text = "IMU:";
            // 
            // lblIMU
            // 
            this.lblIMU.AutoSize = true;
            this.lblIMU.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMU.Location = new System.Drawing.Point(679, 276);
            this.lblIMU.Name = "lblIMU";
            this.lblIMU.Size = new System.Drawing.Size(50, 23);
            this.lblIMU.TabIndex = 83;
            this.lblIMU.Text = "IMU";
            // 
            // lblSteer
            // 
            this.lblSteer.AutoSize = true;
            this.lblSteer.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteer.Location = new System.Drawing.Point(679, 319);
            this.lblSteer.Name = "lblSteer";
            this.lblSteer.Size = new System.Drawing.Size(60, 23);
            this.lblSteer.TabIndex = 82;
            this.lblSteer.Text = "Steer";
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = true;
            this.lblMachine.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMachine.Location = new System.Drawing.Point(679, 349);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(60, 23);
            this.lblMachine.TabIndex = 81;
            this.lblMachine.Text = "Mach";
            // 
            // lblGPS
            // 
            this.lblGPS.AutoSize = true;
            this.lblGPS.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPS.Location = new System.Drawing.Point(679, 232);
            this.lblGPS.Name = "lblGPS";
            this.lblGPS.Size = new System.Drawing.Size(48, 23);
            this.lblGPS.TabIndex = 79;
            this.lblGPS.Text = "GPS";
            // 
            // lblFromGPS
            // 
            this.lblFromGPS.BackColor = System.Drawing.Color.Transparent;
            this.lblFromGPS.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromGPS.ForeColor = System.Drawing.Color.Black;
            this.lblFromGPS.Location = new System.Drawing.Point(758, 230);
            this.lblFromGPS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromGPS.Name = "lblFromGPS";
            this.lblFromGPS.Size = new System.Drawing.Size(64, 27);
            this.lblFromGPS.TabIndex = 172;
            this.lblFromGPS.Text = "---";
            this.lblFromGPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromMU
            // 
            this.lblFromMU.BackColor = System.Drawing.Color.Transparent;
            this.lblFromMU.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromMU.ForeColor = System.Drawing.Color.Black;
            this.lblFromMU.Location = new System.Drawing.Point(758, 273);
            this.lblFromMU.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromMU.Name = "lblFromMU";
            this.lblFromMU.Size = new System.Drawing.Size(64, 27);
            this.lblFromMU.TabIndex = 175;
            this.lblFromMU.Text = "---";
            this.lblFromMU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromModule1
            // 
            this.lblFromModule1.BackColor = System.Drawing.Color.Transparent;
            this.lblFromModule1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromModule1.ForeColor = System.Drawing.Color.Black;
            this.lblFromModule1.Location = new System.Drawing.Point(758, 317);
            this.lblFromModule1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromModule1.Name = "lblFromModule1";
            this.lblFromModule1.Size = new System.Drawing.Size(64, 27);
            this.lblFromModule1.TabIndex = 173;
            this.lblFromModule1.Text = "---";
            this.lblFromModule1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromModule2
            // 
            this.lblFromModule2.BackColor = System.Drawing.Color.Transparent;
            this.lblFromModule2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromModule2.ForeColor = System.Drawing.Color.Black;
            this.lblFromModule2.Location = new System.Drawing.Point(758, 347);
            this.lblFromModule2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromModule2.Name = "lblFromModule2";
            this.lblFromModule2.Size = new System.Drawing.Size(64, 27);
            this.lblFromModule2.TabIndex = 174;
            this.lblFromModule2.Text = "---";
            this.lblFromModule2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormCommSetGPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(865, 663);
            this.ControlBox = false;
            this.Controls.Add(this.lblFromGPS);
            this.Controls.Add(this.lblFromMU);
            this.Controls.Add(this.lblFromModule1);
            this.Controls.Add(this.lblFromModule2);
            this.Controls.Add(this.lblIMU);
            this.Controls.Add(this.lblSteer);
            this.Controls.Add(this.lblMachine);
            this.Controls.Add(this.lblGPS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnRescan);
            this.Controls.Add(this.btnSerialOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormCommSetGPS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connect GPS";
            this.Load += new System.EventHandler(this.FormCommSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRescan;
        private System.Windows.Forms.Button btnSerialOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCurrentPort;
        private System.Windows.Forms.Label lblCurrentBaud;
        private System.Windows.Forms.Button btnCloseSerial;
        private System.Windows.Forms.TextBox textBoxRcv;
        private System.Windows.Forms.Button btnOpenSerial;
        private System.Windows.Forms.ComboBox cboxBaud;
        private System.Windows.Forms.ComboBox cboxPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboxPort2;
        private System.Windows.Forms.ComboBox cboxBaud2;
        private System.Windows.Forms.Label lblCurrentPort2;
        private System.Windows.Forms.Label lblCurrentBaud2;
        private System.Windows.Forms.Button btnCloseSerial2;
        private System.Windows.Forms.TextBox textBoxRcv2;
        private System.Windows.Forms.Button btnOpenSerial2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboxModule1Port;
        private System.Windows.Forms.Button btnOpenSerialModule1;
        private System.Windows.Forms.Button btnCloseSerialModule1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboxModule2Port;
        private System.Windows.Forms.Button btnOpenSerialModule2;
        private System.Windows.Forms.Button btnCloseSerialModule2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cboxModule3Port;
        private System.Windows.Forms.Button btnOpenSerialModule3;
        private System.Windows.Forms.Button btnCloseSerialModule3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cboxIMU;
        private System.Windows.Forms.Button btnCloseIMU;
        private System.Windows.Forms.Button btnOpenIMU;
        private System.Windows.Forms.Label lblCurrentModule1Port;
        private System.Windows.Forms.Label lblCurrentModule2Port;
        private System.Windows.Forms.Label lblCurrentModule3Port;
        private System.Windows.Forms.Label lblCurrentIMU;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblIMU;
        private System.Windows.Forms.Label lblSteer;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.Label lblGPS;
        private System.Windows.Forms.Label lblFromGPS;
        private System.Windows.Forms.Label lblFromMU;
        private System.Windows.Forms.Label lblFromModule1;
        private System.Windows.Forms.Label lblFromModule2;
    }
}