namespace AgIO.Forms
{
    partial class FormTeachSteering
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
            this.timerATS = new System.Windows.Forms.Timer(this.components);
            this.textATS2 = new System.Windows.Forms.Label();
            this.textATS3 = new System.Windows.Forms.Label();
            this.lblATSDoneRight = new System.Windows.Forms.Label();
            this.textATS4 = new System.Windows.Forms.Label();
            this.lblATSAngleRight = new System.Windows.Forms.Label();
            this.textATS7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblATSDoneLeft = new System.Windows.Forms.Label();
            this.textATS8 = new System.Windows.Forms.Label();
            this.lblATSWASRight = new System.Windows.Forms.Label();
            this.textATS5 = new System.Windows.Forms.Label();
            this.textATS6 = new System.Windows.Forms.Label();
            this.textATS10 = new System.Windows.Forms.Label();
            this.lblATSWASLeft = new System.Windows.Forms.Label();
            this.textATS9 = new System.Windows.Forms.Label();
            this.lblATSAngleLeft = new System.Windows.Forms.Label();
            this.textATS11 = new System.Windows.Forms.Label();
            this.textATS12 = new System.Windows.Forms.Label();
            this.lblATSDigPerDeg = new System.Windows.Forms.Label();
            this.textATS0 = new System.Windows.Forms.Label();
            this.nudAxisDist = new System.Windows.Forms.NumericUpDown();
            this.lblATSRTK = new System.Windows.Forms.Label();
            this.btnATSOK = new System.Windows.Forms.Button();
            this.textATS13 = new System.Windows.Forms.Label();
            this.lblATSZero = new System.Windows.Forms.Label();
            this.lblATSAckermann = new System.Windows.Forms.Label();
            this.lblATSMaxDeg = new System.Windows.Forms.Label();
            this.lblATSWASInverted = new System.Windows.Forms.Label();
            this.lblATSWAS = new System.Windows.Forms.Label();
            this.textATS14 = new System.Windows.Forms.Label();
            this.userControl11 = new AgIO.Forms.UserControl1();
            ((System.ComponentModel.ISupportInitialize)(this.nudAxisDist)).BeginInit();
            this.SuspendLayout();
            // 
            // timerATS
            // 
            this.timerATS.Enabled = true;
            this.timerATS.Interval = 50;
            this.timerATS.Tick += new System.EventHandler(this.timerATS_Tick);
            // 
            // textATS2
            // 
            this.textATS2.AutoSize = true;
            this.textATS2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.textATS2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textATS2.Location = new System.Drawing.Point(34, 62);
            this.textATS2.Name = "textATS2";
            this.textATS2.Size = new System.Drawing.Size(470, 17);
            this.textATS2.TabIndex = 181;
            this.textATS2.Text = "(Please cancel and try again if you didn\'t start with steering = 0° or no RTK)";
            // 
            // textATS3
            // 
            this.textATS3.AutoSize = true;
            this.textATS3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textATS3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textATS3.Location = new System.Drawing.Point(33, 124);
            this.textATS3.Name = "textATS3";
            this.textATS3.Size = new System.Drawing.Size(576, 23);
            this.textATS3.TabIndex = 183;
            this.textATS3.Text = "Drive the smalles possible circle to the right. Already done:";
            // 
            // lblATSDoneRight
            // 
            this.lblATSDoneRight.BackColor = System.Drawing.Color.Transparent;
            this.lblATSDoneRight.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblATSDoneRight.ForeColor = System.Drawing.Color.Black;
            this.lblATSDoneRight.Location = new System.Drawing.Point(601, 122);
            this.lblATSDoneRight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblATSDoneRight.Name = "lblATSDoneRight";
            this.lblATSDoneRight.Size = new System.Drawing.Size(64, 27);
            this.lblATSDoneRight.TabIndex = 184;
            this.lblATSDoneRight.Text = "---";
            this.lblATSDoneRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textATS4
            // 
            this.textATS4.BackColor = System.Drawing.Color.Transparent;
            this.textATS4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textATS4.ForeColor = System.Drawing.Color.Black;
            this.textATS4.Location = new System.Drawing.Point(655, 120);
            this.textATS4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textATS4.Name = "textATS4";
            this.textATS4.Size = new System.Drawing.Size(37, 27);
            this.textATS4.TabIndex = 185;
            this.textATS4.Text = "%";
            this.textATS4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblATSAngleRight
            // 
            this.lblATSAngleRight.BackColor = System.Drawing.Color.Transparent;
            this.lblATSAngleRight.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblATSAngleRight.ForeColor = System.Drawing.Color.Black;
            this.lblATSAngleRight.Location = new System.Drawing.Point(602, 165);
            this.lblATSAngleRight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblATSAngleRight.Name = "lblATSAngleRight";
            this.lblATSAngleRight.Size = new System.Drawing.Size(64, 27);
            this.lblATSAngleRight.TabIndex = 187;
            this.lblATSAngleRight.Text = "---";
            this.lblATSAngleRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textATS7
            // 
            this.textATS7.AutoSize = true;
            this.textATS7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textATS7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textATS7.Location = new System.Drawing.Point(34, 197);
            this.textATS7.Name = "textATS7";
            this.textATS7.Size = new System.Drawing.Size(351, 16);
            this.textATS7.TabIndex = 186;
            this.textATS7.Text = "Maximum wheel angle sensor ADC value when driving right:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(655, 258);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 27);
            this.label4.TabIndex = 190;
            this.label4.Text = "%";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblATSDoneLeft
            // 
            this.lblATSDoneLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblATSDoneLeft.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblATSDoneLeft.ForeColor = System.Drawing.Color.Black;
            this.lblATSDoneLeft.Location = new System.Drawing.Point(601, 260);
            this.lblATSDoneLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblATSDoneLeft.Name = "lblATSDoneLeft";
            this.lblATSDoneLeft.Size = new System.Drawing.Size(64, 27);
            this.lblATSDoneLeft.TabIndex = 189;
            this.lblATSDoneLeft.Text = "---";
            this.lblATSDoneLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textATS8
            // 
            this.textATS8.AutoSize = true;
            this.textATS8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textATS8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textATS8.Location = new System.Drawing.Point(33, 262);
            this.textATS8.Name = "textATS8";
            this.textATS8.Size = new System.Drawing.Size(562, 23);
            this.textATS8.TabIndex = 188;
            this.textATS8.Text = "Drive the smalles possible circle to the left. Already done:";
            // 
            // lblATSWASRight
            // 
            this.lblATSWASRight.BackColor = System.Drawing.Color.Transparent;
            this.lblATSWASRight.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblATSWASRight.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblATSWASRight.Location = new System.Drawing.Point(602, 197);
            this.lblATSWASRight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblATSWASRight.Name = "lblATSWASRight";
            this.lblATSWASRight.Size = new System.Drawing.Size(64, 27);
            this.lblATSWASRight.TabIndex = 192;
            this.lblATSWASRight.Text = "---";
            this.lblATSWASRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textATS5
            // 
            this.textATS5.AutoSize = true;
            this.textATS5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textATS5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textATS5.Location = new System.Drawing.Point(33, 167);
            this.textATS5.Name = "textATS5";
            this.textATS5.Size = new System.Drawing.Size(414, 23);
            this.textATS5.TabIndex = 191;
            this.textATS5.Text = "Maximum wheel angle when driving right:";
            // 
            // textATS6
            // 
            this.textATS6.BackColor = System.Drawing.Color.Transparent;
            this.textATS6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textATS6.ForeColor = System.Drawing.Color.Black;
            this.textATS6.Location = new System.Drawing.Point(656, 165);
            this.textATS6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textATS6.Name = "textATS6";
            this.textATS6.Size = new System.Drawing.Size(37, 27);
            this.textATS6.TabIndex = 193;
            this.textATS6.Text = "°";
            this.textATS6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textATS10
            // 
            this.textATS10.BackColor = System.Drawing.Color.Transparent;
            this.textATS10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textATS10.ForeColor = System.Drawing.Color.Black;
            this.textATS10.Location = new System.Drawing.Point(656, 300);
            this.textATS10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textATS10.Name = "textATS10";
            this.textATS10.Size = new System.Drawing.Size(37, 27);
            this.textATS10.TabIndex = 198;
            this.textATS10.Text = "°";
            this.textATS10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblATSWASLeft
            // 
            this.lblATSWASLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblATSWASLeft.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblATSWASLeft.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblATSWASLeft.Location = new System.Drawing.Point(602, 332);
            this.lblATSWASLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblATSWASLeft.Name = "lblATSWASLeft";
            this.lblATSWASLeft.Size = new System.Drawing.Size(64, 27);
            this.lblATSWASLeft.TabIndex = 197;
            this.lblATSWASLeft.Text = "---";
            this.lblATSWASLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textATS9
            // 
            this.textATS9.AutoSize = true;
            this.textATS9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textATS9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textATS9.Location = new System.Drawing.Point(33, 302);
            this.textATS9.Name = "textATS9";
            this.textATS9.Size = new System.Drawing.Size(400, 23);
            this.textATS9.TabIndex = 196;
            this.textATS9.Text = "Maximum wheel angle when driving left:";
            // 
            // lblATSAngleLeft
            // 
            this.lblATSAngleLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblATSAngleLeft.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblATSAngleLeft.ForeColor = System.Drawing.Color.Black;
            this.lblATSAngleLeft.Location = new System.Drawing.Point(602, 300);
            this.lblATSAngleLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblATSAngleLeft.Name = "lblATSAngleLeft";
            this.lblATSAngleLeft.Size = new System.Drawing.Size(64, 27);
            this.lblATSAngleLeft.TabIndex = 195;
            this.lblATSAngleLeft.Text = "---";
            this.lblATSAngleLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textATS11
            // 
            this.textATS11.AutoSize = true;
            this.textATS11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textATS11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textATS11.Location = new System.Drawing.Point(34, 332);
            this.textATS11.Name = "textATS11";
            this.textATS11.Size = new System.Drawing.Size(343, 16);
            this.textATS11.TabIndex = 194;
            this.textATS11.Text = "Maximum wheel angle sensor ADC value when driving left:";
            // 
            // textATS12
            // 
            this.textATS12.AutoSize = true;
            this.textATS12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textATS12.ForeColor = System.Drawing.SystemColors.Highlight;
            this.textATS12.Location = new System.Drawing.Point(33, 418);
            this.textATS12.Name = "textATS12";
            this.textATS12.Size = new System.Drawing.Size(212, 19);
            this.textATS12.TabIndex = 201;
            this.textATS12.Text = "Settings for AgOpenGPS:";
            // 
            // lblATSDigPerDeg
            // 
            this.lblATSDigPerDeg.BackColor = System.Drawing.Color.Transparent;
            this.lblATSDigPerDeg.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblATSDigPerDeg.ForeColor = System.Drawing.Color.Black;
            this.lblATSDigPerDeg.Location = new System.Drawing.Point(352, 453);
            this.lblATSDigPerDeg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblATSDigPerDeg.Name = "lblATSDigPerDeg";
            this.lblATSDigPerDeg.Size = new System.Drawing.Size(64, 27);
            this.lblATSDigPerDeg.TabIndex = 200;
            this.lblATSDigPerDeg.Text = "---";
            this.lblATSDigPerDeg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textATS0
            // 
            this.textATS0.AutoSize = true;
            this.textATS0.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textATS0.ForeColor = System.Drawing.SystemColors.Highlight;
            this.textATS0.Location = new System.Drawing.Point(33, 39);
            this.textATS0.Name = "textATS0";
            this.textATS0.Size = new System.Drawing.Size(427, 23);
            this.textATS0.TabIndex = 205;
            this.textATS0.Text = "Distance between front and rear axis in cm:";
            // 
            // nudAxisDist
            // 
            this.nudAxisDist.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAxisDist.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.nudAxisDist.Location = new System.Drawing.Point(569, 37);
            this.nudAxisDist.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.nudAxisDist.Minimum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nudAxisDist.Name = "nudAxisDist";
            this.nudAxisDist.Size = new System.Drawing.Size(96, 30);
            this.nudAxisDist.TabIndex = 206;
            this.nudAxisDist.Value = new decimal(new int[] {
            290,
            0,
            0,
            0});
            // 
            // lblATSRTK
            // 
            this.lblATSRTK.AutoSize = true;
            this.lblATSRTK.Font = new System.Drawing.Font("Tahoma", 24.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblATSRTK.ForeColor = System.Drawing.Color.Red;
            this.lblATSRTK.Location = new System.Drawing.Point(106, 464);
            this.lblATSRTK.Name = "lblATSRTK";
            this.lblATSRTK.Size = new System.Drawing.Size(64, 80);
            this.lblATSRTK.TabIndex = 200;
            this.lblATSRTK.Text = "XXX";
            // 
            // btnATSOK
            // 
            this.btnATSOK.BackColor = System.Drawing.Color.Transparent;
            this.btnATSOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnATSOK.FlatAppearance.BorderSize = 0;
            this.btnATSOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnATSOK.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnATSOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnATSOK.Image = global::AgIO.Properties.Resources.OK64;
            this.btnATSOK.Location = new System.Drawing.Point(615, 458);
            this.btnATSOK.Name = "btnATSOK";
            this.btnATSOK.Size = new System.Drawing.Size(91, 63);
            this.btnATSOK.TabIndex = 204;
            this.btnATSOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnATSOK.UseVisualStyleBackColor = false;
            this.btnATSOK.Click += new System.EventHandler(this.btnATSOK_Click);
            // 
            // textATS13
            // 
            this.textATS13.AutoSize = true;
            this.textATS13.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.textATS13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textATS13.Location = new System.Drawing.Point(277, 480);
            this.textATS13.Name = "textATS13";
            this.textATS13.Size = new System.Drawing.Size(322, 17);
            this.textATS13.TabIndex = 208;
            this.textATS13.Text = "   Zero      CntPerDeg Ackermann maxDegrees";
            // 
            // lblATSZero
            // 
            this.lblATSZero.BackColor = System.Drawing.Color.Transparent;
            this.lblATSZero.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblATSZero.ForeColor = System.Drawing.Color.Black;
            this.lblATSZero.Location = new System.Drawing.Point(276, 453);
            this.lblATSZero.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblATSZero.Name = "lblATSZero";
            this.lblATSZero.Size = new System.Drawing.Size(64, 27);
            this.lblATSZero.TabIndex = 209;
            this.lblATSZero.Text = "---";
            this.lblATSZero.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblATSAckermann
            // 
            this.lblATSAckermann.BackColor = System.Drawing.Color.Transparent;
            this.lblATSAckermann.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblATSAckermann.ForeColor = System.Drawing.Color.Black;
            this.lblATSAckermann.Location = new System.Drawing.Point(438, 453);
            this.lblATSAckermann.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblATSAckermann.Name = "lblATSAckermann";
            this.lblATSAckermann.Size = new System.Drawing.Size(64, 27);
            this.lblATSAckermann.TabIndex = 210;
            this.lblATSAckermann.Text = "---";
            this.lblATSAckermann.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblATSMaxDeg
            // 
            this.lblATSMaxDeg.BackColor = System.Drawing.Color.Transparent;
            this.lblATSMaxDeg.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblATSMaxDeg.ForeColor = System.Drawing.Color.Black;
            this.lblATSMaxDeg.Location = new System.Drawing.Point(517, 453);
            this.lblATSMaxDeg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblATSMaxDeg.Name = "lblATSMaxDeg";
            this.lblATSMaxDeg.Size = new System.Drawing.Size(64, 27);
            this.lblATSMaxDeg.TabIndex = 211;
            this.lblATSMaxDeg.Text = "---";
            this.lblATSMaxDeg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblATSWASInverted
            // 
            this.lblATSWASInverted.AutoSize = true;
            this.lblATSWASInverted.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblATSWASInverted.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblATSWASInverted.Location = new System.Drawing.Point(33, 453);
            this.lblATSWASInverted.Name = "lblATSWASInverted";
            this.lblATSWASInverted.Size = new System.Drawing.Size(34, 23);
            this.lblATSWASInverted.TabIndex = 212;
            this.lblATSWASInverted.Text = "---";
            // 
            // lblATSWAS
            // 
            this.lblATSWAS.AutoSize = true;
            this.lblATSWAS.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblATSWAS.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblATSWAS.Location = new System.Drawing.Point(621, 70);
            this.lblATSWAS.Name = "lblATSWAS";
            this.lblATSWAS.Size = new System.Drawing.Size(23, 17);
            this.lblATSWAS.TabIndex = 213;
            this.lblATSWAS.Text = "---";
            this.lblATSWAS.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textATS14
            // 
            this.textATS14.AutoSize = true;
            this.textATS14.Font = new System.Drawing.Font("Tahoma", 10F);
            this.textATS14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textATS14.Location = new System.Drawing.Point(519, 70);
            this.textATS14.Name = "textATS14";
            this.textATS14.Size = new System.Drawing.Size(74, 17);
            this.textATS14.TabIndex = 216;
            this.textATS14.Text = "WAS ADC:";
            // 
            // userControl11
            // 
            this.userControl11.BackgroundImage = global::AgIO.Properties.Resources.Capture;
            this.userControl11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.userControl11.Location = new System.Drawing.Point(280, 382);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(291, 71);
            this.userControl11.TabIndex = 207;
            // 
            // FormTeachSteering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(709, 533);
            this.Controls.Add(this.textATS14);
            this.Controls.Add(this.lblATSWAS);
            this.Controls.Add(this.lblATSWASInverted);
            this.Controls.Add(this.lblATSMaxDeg);
            this.Controls.Add(this.lblATSAckermann);
            this.Controls.Add(this.lblATSZero);
            this.Controls.Add(this.textATS13);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.nudAxisDist);
            this.Controls.Add(this.textATS0);
            this.Controls.Add(this.btnATSOK);
            this.Controls.Add(this.textATS12);
            this.Controls.Add(this.lblATSDigPerDeg);
            this.Controls.Add(this.textATS10);
            this.Controls.Add(this.lblATSWASLeft);
            this.Controls.Add(this.textATS9);
            this.Controls.Add(this.lblATSAngleLeft);
            this.Controls.Add(this.textATS11);
            this.Controls.Add(this.textATS6);
            this.Controls.Add(this.lblATSWASRight);
            this.Controls.Add(this.textATS5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblATSDoneLeft);
            this.Controls.Add(this.textATS8);
            this.Controls.Add(this.lblATSAngleRight);
            this.Controls.Add(this.textATS7);
            this.Controls.Add(this.textATS4);
            this.Controls.Add(this.lblATSDoneRight);
            this.Controls.Add(this.textATS3);
            this.Controls.Add(this.textATS2);
            this.Name = "FormTeachSteering";
            this.ShowIcon = false;
            this.Text = "Auto-Teach Steering";
            ((System.ComponentModel.ISupportInitialize)(this.nudAxisDist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerATS;
        private System.Windows.Forms.Label textATS2;
        private System.Windows.Forms.Label textATS3;
        private System.Windows.Forms.Label lblATSDoneRight;
        private System.Windows.Forms.Label textATS4;
        private System.Windows.Forms.Label lblATSAngleRight;
        private System.Windows.Forms.Label textATS7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblATSDoneLeft;
        private System.Windows.Forms.Label textATS8;
        private System.Windows.Forms.Label lblATSWASRight;
        private System.Windows.Forms.Label textATS5;
        private System.Windows.Forms.Label textATS6;
        private System.Windows.Forms.Label textATS10;
        private System.Windows.Forms.Label lblATSWASLeft;
        private System.Windows.Forms.Label textATS9;
        private System.Windows.Forms.Label lblATSAngleLeft;
        private System.Windows.Forms.Label textATS11;
        private System.Windows.Forms.Label textATS12;
        private System.Windows.Forms.Label lblATSDigPerDeg;
        private System.Windows.Forms.Button btnATSOK;
        private System.Windows.Forms.Label textATS0;
        private System.Windows.Forms.Label lblATSRTK;
        private System.Windows.Forms.NumericUpDown nudAxisDist;
        private UserControl1 userControl11;
        private System.Windows.Forms.Label textATS13;
        private System.Windows.Forms.Label lblATSZero;
        private System.Windows.Forms.Label lblATSAckermann;
        private System.Windows.Forms.Label lblATSMaxDeg;
        private System.Windows.Forms.Label lblATSWASInverted;
        private System.Windows.Forms.Label lblATSWAS;
        private System.Windows.Forms.Label textATS14;
    }
}