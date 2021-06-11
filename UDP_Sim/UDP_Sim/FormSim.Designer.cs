
namespace UDP_Sim
{
    partial class FormSim
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
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Heading = new System.Windows.Forms.Label();
            this.cboxVTG = new System.Windows.Forms.CheckBox();
            this.cboxAVR = new System.Windows.Forms.CheckBox();
            this.cboxHDT = new System.Windows.Forms.CheckBox();
            this.mSec = new System.Windows.Forms.Label();
            this.Kmh = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cboxGGA = new System.Windows.Forms.CheckBox();
            this.lblLat = new System.Windows.Forms.TextBox();
            this.lblLon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxRMC = new System.Windows.Forms.CheckBox();
            this.cboxOGI = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbarRoll = new System.Windows.Forms.TrackBar();
            this.lblRoll = new System.Windows.Forms.Label();
            this.cboxIMU = new System.Windows.Forms.CheckBox();
            this.lblIMUHeading = new System.Windows.Forms.Label();
            this.cboxIMUHeading = new System.Windows.Forms.CheckBox();
            this.lblWAS = new System.Windows.Forms.Label();
            this.tbarWAS = new System.Windows.Forms.TrackBar();
            this.cboxWAS = new System.Windows.Forms.CheckBox();
            this.tbarIMUHeading = new System.Windows.Forms.TrackBar();
            this.cboxSwitch = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarWAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarIMUHeading)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(10, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "0";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 100;
            this.trackBar2.Location = new System.Drawing.Point(6, 149);
            this.trackBar2.Maximum = 3600;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(173, 45);
            this.trackBar2.SmallChange = 10;
            this.trackBar2.TabIndex = 7;
            this.trackBar2.TickFrequency = 250;
            this.trackBar2.Value = 1800;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // trackBar3
            // 
            this.trackBar3.LargeChange = 10;
            this.trackBar3.Location = new System.Drawing.Point(209, 213);
            this.trackBar3.Maximum = 500;
            this.trackBar3.Minimum = -200;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(229, 45);
            this.trackBar3.TabIndex = 8;
            this.trackBar3.TickFrequency = 50;
            this.trackBar3.ValueChanged += new System.EventHandler(this.trackBar3_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightCyan;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(439, 73);
            this.textBox1.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(73, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "90";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(203, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "270";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(139, 83);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(51, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "180";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Heading
            // 
            this.Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Heading.Location = new System.Drawing.Point(8, 126);
            this.Heading.Name = "Heading";
            this.Heading.Size = new System.Drawing.Size(127, 20);
            this.Heading.TabIndex = 15;
            this.Heading.Text = "Heading: 112°";
            this.Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxVTG
            // 
            this.cboxVTG.Checked = true;
            this.cboxVTG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxVTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxVTG.Location = new System.Drawing.Point(12, 293);
            this.cboxVTG.Name = "cboxVTG";
            this.cboxVTG.Size = new System.Drawing.Size(69, 24);
            this.cboxVTG.TabIndex = 16;
            this.cboxVTG.Text = "VTG";
            this.cboxVTG.UseVisualStyleBackColor = true;
            // 
            // cboxAVR
            // 
            this.cboxAVR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxAVR.Location = new System.Drawing.Point(12, 325);
            this.cboxAVR.Name = "cboxAVR";
            this.cboxAVR.Size = new System.Drawing.Size(69, 24);
            this.cboxAVR.TabIndex = 17;
            this.cboxAVR.Text = "AVR";
            this.cboxAVR.UseVisualStyleBackColor = true;
            // 
            // cboxHDT
            // 
            this.cboxHDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxHDT.Location = new System.Drawing.Point(12, 357);
            this.cboxHDT.Name = "cboxHDT";
            this.cboxHDT.Size = new System.Drawing.Size(69, 24);
            this.cboxHDT.TabIndex = 18;
            this.cboxHDT.Text = "HDT";
            this.cboxHDT.UseVisualStyleBackColor = true;
            // 
            // mSec
            // 
            this.mSec.AutoSize = true;
            this.mSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mSec.Location = new System.Drawing.Point(338, 196);
            this.mSec.Name = "mSec";
            this.mSec.Size = new System.Drawing.Size(80, 16);
            this.mSec.TabIndex = 20;
            this.mSec.Text = "M/Sec: 0.0";
            // 
            // Kmh
            // 
            this.Kmh.AutoSize = true;
            this.Kmh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Kmh.Location = new System.Drawing.Point(237, 194);
            this.Kmh.Name = "Kmh";
            this.Kmh.Size = new System.Drawing.Size(79, 20);
            this.Kmh.TabIndex = 21;
            this.Kmh.Text = "Kmh: 0.0";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(39, 7);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 26);
            this.textBox2.TabIndex = 22;
            this.textBox2.Text = "192.168.1.255";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.WordWrap = false;
            // 
            // nudPort
            // 
            this.nudPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPort.Location = new System.Drawing.Point(48, 40);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(96, 26);
            this.nudPort.TabIndex = 24;
            this.nudPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudPort.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 23);
            this.label6.TabIndex = 83;
            this.label6.Text = "Port";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 26);
            this.label5.TabIndex = 84;
            this.label5.Text = "IP";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown3.Location = new System.Drawing.Point(229, 37);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(85, 26);
            this.numericUpDown3.TabIndex = 86;
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown3.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown2.Location = new System.Drawing.Point(9, 106);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(98, 26);
            this.numericUpDown2.TabIndex = 87;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(229, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "NMEA Hz";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(17, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 89;
            this.label7.Text = "Altitude";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(9, 146);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(115, 28);
            this.button6.TabIndex = 90;
            this.button6.Text = "Apply";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.DoSimTick);
            // 
            // cboxGGA
            // 
            this.cboxGGA.Checked = true;
            this.cboxGGA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxGGA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxGGA.Location = new System.Drawing.Point(12, 261);
            this.cboxGGA.Name = "cboxGGA";
            this.cboxGGA.Size = new System.Drawing.Size(69, 24);
            this.cboxGGA.TabIndex = 92;
            this.cboxGGA.Text = "GGA";
            this.cboxGGA.UseVisualStyleBackColor = true;
            // 
            // lblLat
            // 
            this.lblLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLat.Location = new System.Drawing.Point(155, 82);
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new System.Drawing.Size(160, 26);
            this.lblLat.TabIndex = 93;
            this.lblLat.Text = "53.4360564";
            this.lblLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lblLat.WordWrap = false;
            this.lblLat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // lblLon
            // 
            this.lblLon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLon.Location = new System.Drawing.Point(155, 114);
            this.lblLon.Name = "lblLon";
            this.lblLon.Size = new System.Drawing.Size(160, 26);
            this.lblLon.TabIndex = 94;
            this.lblLon.Text = "-111.160047";
            this.lblLon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lblLon.WordWrap = false;
            this.lblLon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 95;
            this.label1.Text = "Lat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 96;
            this.label2.Text = "Lon";
            // 
            // cboxRMC
            // 
            this.cboxRMC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxRMC.Location = new System.Drawing.Point(12, 389);
            this.cboxRMC.Name = "cboxRMC";
            this.cboxRMC.Size = new System.Drawing.Size(69, 24);
            this.cboxRMC.TabIndex = 97;
            this.cboxRMC.Text = "RMC";
            this.cboxRMC.UseVisualStyleBackColor = true;
            // 
            // cboxOGI
            // 
            this.cboxOGI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxOGI.Location = new System.Drawing.Point(12, 421);
            this.cboxOGI.Name = "cboxOGI";
            this.cboxOGI.Size = new System.Drawing.Size(69, 24);
            this.cboxOGI.TabIndex = 98;
            this.cboxOGI.Text = "OGI";
            this.cboxOGI.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(155, 146);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(160, 28);
            this.button7.TabIndex = 99;
            this.button7.Text = "Get Current";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Controls.Add(this.nudPort);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.lblLat);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.lblLon);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericUpDown3);
            this.panel1.Location = new System.Drawing.Point(116, 264);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 186);
            this.panel1.TabIndex = 101;
            // 
            // tbarRoll
            // 
            this.tbarRoll.LargeChange = 1;
            this.tbarRoll.Location = new System.Drawing.Point(6, 213);
            this.tbarRoll.Maximum = 20;
            this.tbarRoll.Minimum = -20;
            this.tbarRoll.Name = "tbarRoll";
            this.tbarRoll.Size = new System.Drawing.Size(173, 45);
            this.tbarRoll.TabIndex = 102;
            this.tbarRoll.TickFrequency = 5;
            this.tbarRoll.ValueChanged += new System.EventHandler(this.tbarRoll_ValueChanged);
            // 
            // lblRoll
            // 
            this.lblRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoll.Location = new System.Drawing.Point(37, 193);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(118, 21);
            this.lblRoll.TabIndex = 103;
            this.lblRoll.Text = "Roll:";
            this.lblRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxIMU
            // 
            this.cboxIMU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIMU.Location = new System.Drawing.Point(6, 28);
            this.cboxIMU.Name = "cboxIMU";
            this.cboxIMU.Size = new System.Drawing.Size(61, 24);
            this.cboxIMU.TabIndex = 104;
            this.cboxIMU.Text = "IMU";
            this.cboxIMU.UseVisualStyleBackColor = true;
            this.cboxIMU.Click += new System.EventHandler(this.cboxIMU_Click);
            // 
            // lblIMUHeading
            // 
            this.lblIMUHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMUHeading.Location = new System.Drawing.Point(103, 11);
            this.lblIMUHeading.Name = "lblIMUHeading";
            this.lblIMUHeading.Size = new System.Drawing.Size(190, 20);
            this.lblIMUHeading.TabIndex = 106;
            this.lblIMUHeading.Text = "Heading: 0°";
            this.lblIMUHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxIMUHeading
            // 
            this.cboxIMUHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIMUHeading.Location = new System.Drawing.Point(334, 19);
            this.cboxIMUHeading.Name = "cboxIMUHeading";
            this.cboxIMUHeading.Size = new System.Drawing.Size(91, 45);
            this.cboxIMUHeading.TabIndex = 107;
            this.cboxIMUHeading.Text = "Use This Heading";
            this.cboxIMUHeading.UseVisualStyleBackColor = true;
            // 
            // lblWAS
            // 
            this.lblWAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWAS.Location = new System.Drawing.Point(263, 126);
            this.lblWAS.Name = "lblWAS";
            this.lblWAS.Size = new System.Drawing.Size(136, 20);
            this.lblWAS.TabIndex = 110;
            this.lblWAS.Text = "Steer Angle: 0°";
            this.lblWAS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWAS.Click += new System.EventHandler(this.lblWAS_Click);
            // 
            // tbarWAS
            // 
            this.tbarWAS.LargeChange = 1;
            this.tbarWAS.Location = new System.Drawing.Point(209, 149);
            this.tbarWAS.Maximum = 600;
            this.tbarWAS.Minimum = -600;
            this.tbarWAS.Name = "tbarWAS";
            this.tbarWAS.Size = new System.Drawing.Size(229, 45);
            this.tbarWAS.TabIndex = 109;
            this.tbarWAS.TickFrequency = 100;
            this.tbarWAS.ValueChanged += new System.EventHandler(this.tbarWAS_ValueChanged);
            // 
            // cboxWAS
            // 
            this.cboxWAS.Checked = true;
            this.cboxWAS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxWAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxWAS.Location = new System.Drawing.Point(274, 85);
            this.cboxWAS.Name = "cboxWAS";
            this.cboxWAS.Size = new System.Drawing.Size(84, 24);
            this.cboxWAS.TabIndex = 108;
            this.cboxWAS.Text = "To AgIO";
            this.cboxWAS.UseVisualStyleBackColor = true;
            // 
            // tbarIMUHeading
            // 
            this.tbarIMUHeading.LargeChange = 100;
            this.tbarIMUHeading.Location = new System.Drawing.Point(80, 30);
            this.tbarIMUHeading.Maximum = 3600;
            this.tbarIMUHeading.Name = "tbarIMUHeading";
            this.tbarIMUHeading.Size = new System.Drawing.Size(237, 45);
            this.tbarIMUHeading.SmallChange = 10;
            this.tbarIMUHeading.TabIndex = 111;
            this.tbarIMUHeading.TickFrequency = 200;
            this.tbarIMUHeading.ValueChanged += new System.EventHandler(this.tbarIMUHeading_ValueChanged);
            // 
            // cboxSwitch
            // 
            this.cboxSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSwitch.Location = new System.Drawing.Point(369, 85);
            this.cboxSwitch.Name = "cboxSwitch";
            this.cboxSwitch.Size = new System.Drawing.Size(76, 24);
            this.cboxSwitch.TabIndex = 112;
            this.cboxSwitch.Text = "Switch";
            this.cboxSwitch.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.GhostWhite;
            this.groupBox1.Controls.Add(this.cboxIMUHeading);
            this.groupBox1.Controls.Add(this.tbarIMUHeading);
            this.groupBox1.Controls.Add(this.lblIMUHeading);
            this.groupBox1.Controls.Add(this.cboxIMU);
            this.groupBox1.Location = new System.Drawing.Point(10, 456);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 83);
            this.groupBox1.TabIndex = 113;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IMU Module";
            // 
            // FormSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(450, 542);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboxSwitch);
            this.Controls.Add(this.lblWAS);
            this.Controls.Add(this.tbarWAS);
            this.Controls.Add(this.cboxWAS);
            this.Controls.Add(this.Heading);
            this.Controls.Add(this.lblRoll);
            this.Controls.Add(this.tbarRoll);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboxOGI);
            this.Controls.Add(this.cboxRMC);
            this.Controls.Add(this.cboxGGA);
            this.Controls.Add(this.Kmh);
            this.Controls.Add(this.mSec);
            this.Controls.Add(this.cboxHDT);
            this.Controls.Add(this.cboxAVR);
            this.Controls.Add(this.cboxVTG);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.button1);
            this.Name = "FormSim";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarWAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarIMUHeading)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label Heading;
        private System.Windows.Forms.CheckBox cboxVTG;
        private System.Windows.Forms.CheckBox cboxAVR;
        private System.Windows.Forms.CheckBox cboxHDT;
        private System.Windows.Forms.Label mSec;
        private System.Windows.Forms.Label Kmh;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cboxGGA;
        private System.Windows.Forms.TextBox lblLat;
        private System.Windows.Forms.TextBox lblLon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cboxRMC;
        private System.Windows.Forms.CheckBox cboxOGI;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar tbarRoll;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.CheckBox cboxIMU;
        private System.Windows.Forms.Label lblIMUHeading;
        private System.Windows.Forms.CheckBox cboxIMUHeading;
        private System.Windows.Forms.Label lblWAS;
        private System.Windows.Forms.TrackBar tbarWAS;
        private System.Windows.Forms.CheckBox cboxWAS;
        private System.Windows.Forms.TrackBar tbarIMUHeading;
        private System.Windows.Forms.CheckBox cboxSwitch;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

