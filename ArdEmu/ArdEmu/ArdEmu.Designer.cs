namespace ArdEmu
{
    partial class ArdEmu
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.nudTimer = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nud0 = new System.Windows.Forms.NumericUpDown();
            this.nud1 = new System.Windows.Forms.NumericUpDown();
            this.nud2 = new System.Windows.Forms.NumericUpDown();
            this.nud9 = new System.Windows.Forms.NumericUpDown();
            this.nud4 = new System.Windows.Forms.NumericUpDown();
            this.nud3 = new System.Windows.Forms.NumericUpDown();
            this.nud6 = new System.Windows.Forms.NumericUpDown();
            this.nud5 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nud8 = new System.Windows.Forms.NumericUpDown();
            this.nud7 = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSteer = new System.Windows.Forms.Label();
            this.lblMachine = new System.Windows.Forms.Label();
            this.rtxtStatus = new System.Windows.Forms.RichTextBox();
            this.lblSteerCtr = new System.Windows.Forms.Label();
            this.lblMachineCtr = new System.Windows.Forms.Label();
            this.btnUDPSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud7)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(659, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 32);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(12, 15);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 32);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(103, 19);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(533, 26);
            this.txtMessage.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(467, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Send On";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nudTimer
            // 
            this.nudTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTimer.Location = new System.Drawing.Point(381, 74);
            this.nudTimer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTimer.Name = "nudTimer";
            this.nudTimer.Size = new System.Drawing.Size(73, 38);
            this.nudTimer.TabIndex = 8;
            this.nudTimer.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTimer.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(289, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Send Rate";
            // 
            // nud0
            // 
            this.nud0.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud0.Location = new System.Drawing.Point(15, 77);
            this.nud0.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud0.Name = "nud0";
            this.nud0.Size = new System.Drawing.Size(73, 38);
            this.nud0.TabIndex = 10;
            this.nud0.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            // 
            // nud1
            // 
            this.nud1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud1.Location = new System.Drawing.Point(113, 77);
            this.nud1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud1.Name = "nud1";
            this.nud1.Size = new System.Drawing.Size(73, 38);
            this.nud1.TabIndex = 11;
            this.nud1.Value = new decimal(new int[] {
            253,
            0,
            0,
            0});
            // 
            // nud2
            // 
            this.nud2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud2.Location = new System.Drawing.Point(14, 152);
            this.nud2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud2.Name = "nud2";
            this.nud2.Size = new System.Drawing.Size(73, 38);
            this.nud2.TabIndex = 13;
            this.nud2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nud9
            // 
            this.nud9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud9.Location = new System.Drawing.Point(674, 152);
            this.nud9.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud9.Name = "nud9";
            this.nud9.Size = new System.Drawing.Size(73, 38);
            this.nud9.TabIndex = 12;
            this.nud9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nud4
            // 
            this.nud4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud4.Location = new System.Drawing.Point(196, 152);
            this.nud4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud4.Name = "nud4";
            this.nud4.Size = new System.Drawing.Size(73, 38);
            this.nud4.TabIndex = 15;
            this.nud4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nud3
            // 
            this.nud3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud3.Location = new System.Drawing.Point(105, 152);
            this.nud3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud3.Name = "nud3";
            this.nud3.Size = new System.Drawing.Size(73, 38);
            this.nud3.TabIndex = 14;
            this.nud3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud3.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // nud6
            // 
            this.nud6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud6.Location = new System.Drawing.Point(401, 152);
            this.nud6.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud6.Name = "nud6";
            this.nud6.Size = new System.Drawing.Size(73, 38);
            this.nud6.TabIndex = 17;
            this.nud6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nud5
            // 
            this.nud5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud5.Location = new System.Drawing.Point(287, 152);
            this.nud5.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud5.Name = "nud5";
            this.nud5.Size = new System.Drawing.Size(73, 38);
            this.nud5.TabIndex = 16;
            this.nud5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud5.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Header Hi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(132, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Header Lo";
            // 
            // nud8
            // 
            this.nud8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud8.Location = new System.Drawing.Point(583, 152);
            this.nud8.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud8.Name = "nud8";
            this.nud8.Size = new System.Drawing.Size(73, 38);
            this.nud8.TabIndex = 27;
            this.nud8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nud7
            // 
            this.nud7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud7.Location = new System.Drawing.Point(492, 152);
            this.nud7.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud7.Name = "nud7";
            this.nud7.Size = new System.Drawing.Size(73, 38);
            this.nud7.TabIndex = 26;
            this.nud7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(39, 129);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 20);
            this.label13.TabIndex = 30;
            this.label13.Text = "2";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 16);
            this.label14.TabIndex = 31;
            this.label14.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(113, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 16);
            this.label15.TabIndex = 32;
            this.label15.Text = "1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(125, 129);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(19, 20);
            this.label16.TabIndex = 33;
            this.label16.Text = "3";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(216, 129);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 20);
            this.label17.TabIndex = 34;
            this.label17.Text = "4";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(308, 129);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(19, 20);
            this.label18.TabIndex = 35;
            this.label18.Text = "5";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(421, 129);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(19, 20);
            this.label19.TabIndex = 36;
            this.label19.Text = "6";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(512, 129);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(19, 20);
            this.label20.TabIndex = 37;
            this.label20.Text = "7";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(603, 129);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(19, 20);
            this.label21.TabIndex = 38;
            this.label21.Text = "8";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(697, 129);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(19, 20);
            this.label22.TabIndex = 39;
            this.label22.Text = "9";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(209, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "253 Steer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(209, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "248 Machine";
            // 
            // lblSteer
            // 
            this.lblSteer.AutoSize = true;
            this.lblSteer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteer.Location = new System.Drawing.Point(46, 213);
            this.lblSteer.Name = "lblSteer";
            this.lblSteer.Size = new System.Drawing.Size(53, 20);
            this.lblSteer.TabIndex = 46;
            this.lblSteer.Text = "Steer";
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = true;
            this.lblMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMachine.Location = new System.Drawing.Point(440, 214);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(76, 20);
            this.lblMachine.TabIndex = 47;
            this.lblMachine.Text = "Machine";
            // 
            // rtxtStatus
            // 
            this.rtxtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtStatus.Location = new System.Drawing.Point(10, 242);
            this.rtxtStatus.Name = "rtxtStatus";
            this.rtxtStatus.ReadOnly = true;
            this.rtxtStatus.Size = new System.Drawing.Size(738, 184);
            this.rtxtStatus.TabIndex = 0;
            this.rtxtStatus.Text = "";
            // 
            // lblSteerCtr
            // 
            this.lblSteerCtr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerCtr.Location = new System.Drawing.Point(2, 215);
            this.lblSteerCtr.Name = "lblSteerCtr";
            this.lblSteerCtr.Size = new System.Drawing.Size(44, 16);
            this.lblSteerCtr.TabIndex = 48;
            this.lblSteerCtr.Text = "none";
            this.lblSteerCtr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMachineCtr
            // 
            this.lblMachineCtr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMachineCtr.Location = new System.Drawing.Point(401, 216);
            this.lblMachineCtr.Name = "lblMachineCtr";
            this.lblMachineCtr.Size = new System.Drawing.Size(39, 16);
            this.lblMachineCtr.TabIndex = 49;
            this.lblMachineCtr.Text = "none";
            this.lblMachineCtr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnUDPSettings
            // 
            this.btnUDPSettings.Location = new System.Drawing.Point(630, 79);
            this.btnUDPSettings.Name = "btnUDPSettings";
            this.btnUDPSettings.Size = new System.Drawing.Size(104, 32);
            this.btnUDPSettings.TabIndex = 50;
            this.btnUDPSettings.Text = "UDP Settings";
            this.btnUDPSettings.UseVisualStyleBackColor = true;
            this.btnUDPSettings.Click += new System.EventHandler(this.btnUDPSettings_Click);
            // 
            // ArdEmu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 435);
            this.Controls.Add(this.btnUDPSettings);
            this.Controls.Add(this.lblMachine);
            this.Controls.Add(this.lblSteer);
            this.Controls.Add(this.lblMachineCtr);
            this.Controls.Add(this.lblSteerCtr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nud8);
            this.Controls.Add(this.nud7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nud6);
            this.Controls.Add(this.nud5);
            this.Controls.Add(this.nud4);
            this.Controls.Add(this.nud3);
            this.Controls.Add(this.nud2);
            this.Controls.Add(this.nud9);
            this.Controls.Add(this.nud1);
            this.Controls.Add(this.nud0);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudTimer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.rtxtStatus);
            this.Name = "ArdEmu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArdEmu Port 7777";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArdEmu_FormClosing);
            this.Load += new System.EventHandler(this.Server_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nudTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud0;
        private System.Windows.Forms.NumericUpDown nud1;
        private System.Windows.Forms.NumericUpDown nud2;
        private System.Windows.Forms.NumericUpDown nud9;
        private System.Windows.Forms.NumericUpDown nud4;
        private System.Windows.Forms.NumericUpDown nud3;
        private System.Windows.Forms.NumericUpDown nud6;
        private System.Windows.Forms.NumericUpDown nud5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud8;
        private System.Windows.Forms.NumericUpDown nud7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSteer;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.RichTextBox rtxtStatus;
        private System.Windows.Forms.Label lblSteerCtr;
        private System.Windows.Forms.Label lblMachineCtr;
        private System.Windows.Forms.Button btnUDPSettings;
    }
}

