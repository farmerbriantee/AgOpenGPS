namespace AgOpenGPS
{
    partial class FormSimCoords
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.bntOK = new System.Windows.Forms.Button();
            this.nudLongitude = new System.Windows.Forms.NumericUpDown();
            this.nudLatitude = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetFieldFix = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLatStart = new System.Windows.Forms.Label();
            this.lblLonStart = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGPSLon = new System.Windows.Forms.Label();
            this.lblGPSLat = new System.Windows.Forms.Label();
            this.btnLoadGPSFix = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLatitude)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(671, 346);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 80);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bntOK
            // 
            this.bntOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntOK.Location = new System.Drawing.Point(783, 346);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(136, 80);
            this.bntOK.TabIndex = 4;
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // nudLongitude
            // 
            this.nudLongitude.BackColor = System.Drawing.Color.AliceBlue;
            this.nudLongitude.DecimalPlaces = 7;
            this.nudLongitude.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLongitude.Location = new System.Drawing.Point(308, 377);
            this.nudLongitude.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudLongitude.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nudLongitude.Name = "nudLongitude";
            this.nudLongitude.Size = new System.Drawing.Size(298, 52);
            this.nudLongitude.TabIndex = 48;
            this.nudLongitude.Value = new decimal(new int[] {
            1781234567,
            0,
            0,
            -2147024896});
            this.nudLongitude.Enter += new System.EventHandler(this.NudLongitude_Enter);
            // 
            // nudLatitude
            // 
            this.nudLatitude.BackColor = System.Drawing.Color.AliceBlue;
            this.nudLatitude.DecimalPlaces = 7;
            this.nudLatitude.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLatitude.Location = new System.Drawing.Point(12, 377);
            this.nudLatitude.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudLatitude.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.nudLatitude.Name = "nudLatitude";
            this.nudLatitude.Size = new System.Drawing.Size(274, 52);
            this.nudLatitude.TabIndex = 49;
            this.nudLatitude.Value = new decimal(new int[] {
            881234567,
            0,
            0,
            -2147024896});
            this.nudLatitude.Enter += new System.EventHandler(this.NudLatitude_Enter);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(20, 324);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(252, 25);
            this.label18.TabIndex = 178;
            this.label18.Text = "Latitude";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(317, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 25);
            this.label1.TabIndex = 179;
            this.label1.Text = "Longitude";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGetFieldFix
            // 
            this.btnGetFieldFix.BackColor = System.Drawing.Color.AliceBlue;
            this.btnGetFieldFix.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnGetFieldFix.Image = global::AgOpenGPS.Properties.Resources.Boundary;
            this.btnGetFieldFix.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetFieldFix.Location = new System.Drawing.Point(594, 154);
            this.btnGetFieldFix.Name = "btnGetFieldFix";
            this.btnGetFieldFix.Size = new System.Drawing.Size(109, 110);
            this.btnGetFieldFix.TabIndex = 181;
            this.btnGetFieldFix.Text = "Use Field";
            this.btnGetFieldFix.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGetFieldFix.UseVisualStyleBackColor = false;
            this.btnGetFieldFix.Click += new System.EventHandler(this.btnGetFieldFix_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(570, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 23);
            this.label3.TabIndex = 182;
            this.label3.Text = "Lat:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(563, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 23);
            this.label4.TabIndex = 183;
            this.label4.Text = "Lon:";
            // 
            // lblLatStart
            // 
            this.lblLatStart.AutoSize = true;
            this.lblLatStart.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLatStart.Location = new System.Drawing.Point(605, 86);
            this.lblLatStart.Name = "lblLatStart";
            this.lblLatStart.Size = new System.Drawing.Size(103, 23);
            this.lblLatStart.TabIndex = 184;
            this.lblLatStart.Text = "-99.999999";
            // 
            // lblLonStart
            // 
            this.lblLonStart.AutoSize = true;
            this.lblLonStart.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLonStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLonStart.Location = new System.Drawing.Point(602, 111);
            this.lblLonStart.Name = "lblLonStart";
            this.lblLonStart.Size = new System.Drawing.Size(113, 23);
            this.lblLonStart.TabIndex = 185;
            this.lblLonStart.Text = "-188.888888";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(568, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 61);
            this.label7.TabIndex = 186;
            this.label7.Text = "Field Origin";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(761, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 61);
            this.label5.TabIndex = 192;
            this.label5.Text = "GPS Current Fix";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblGPSLon
            // 
            this.lblGPSLon.AutoSize = true;
            this.lblGPSLon.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPSLon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGPSLon.Location = new System.Drawing.Point(799, 111);
            this.lblGPSLon.Name = "lblGPSLon";
            this.lblGPSLon.Size = new System.Drawing.Size(113, 23);
            this.lblGPSLon.TabIndex = 191;
            this.lblGPSLon.Text = "-189.999999";
            // 
            // lblGPSLat
            // 
            this.lblGPSLat.AutoSize = true;
            this.lblGPSLat.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPSLat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGPSLat.Location = new System.Drawing.Point(800, 86);
            this.lblGPSLat.Name = "lblGPSLat";
            this.lblGPSLat.Size = new System.Drawing.Size(103, 23);
            this.lblGPSLat.TabIndex = 190;
            this.lblGPSLat.Text = "-88.777777";
            // 
            // btnLoadGPSFix
            // 
            this.btnLoadGPSFix.BackColor = System.Drawing.Color.AliceBlue;
            this.btnLoadGPSFix.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoadGPSFix.Image = global::AgOpenGPS.Properties.Resources.Satellite64;
            this.btnLoadGPSFix.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadGPSFix.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLoadGPSFix.Location = new System.Drawing.Point(774, 154);
            this.btnLoadGPSFix.Name = "btnLoadGPSFix";
            this.btnLoadGPSFix.Size = new System.Drawing.Size(109, 110);
            this.btnLoadGPSFix.TabIndex = 187;
            this.btnLoadGPSFix.Text = "Use GPS";
            this.btnLoadGPSFix.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadGPSFix.UseVisualStyleBackColor = false;
            this.btnLoadGPSFix.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(756, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 23);
            this.label2.TabIndex = 194;
            this.label2.Text = "Lon:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(763, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 23);
            this.label6.TabIndex = 193;
            this.label6.Text = "Lat:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(75, 349);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 25);
            this.label8.TabIndex = 195;
            this.label8.Text = "( +90 to -90)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(370, 349);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 25);
            this.label9.TabIndex = 196;
            this.label9.Text = "( +180 to -180 )";
            // 
            // FormSimCoords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AgOpenGPS.Properties.Resources.LonLat;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(931, 438);
            this.ControlBox = false;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblGPSLon);
            this.Controls.Add(this.lblGPSLat);
            this.Controls.Add(this.lblLonStart);
            this.Controls.Add(this.lblLatStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLoadGPSFix);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGetFieldFix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.nudLatitude);
            this.Controls.Add(this.nudLongitude);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.bntOK);
            this.Name = "FormSimCoords";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Coordinates For Simulator";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormSimCoords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLatitude)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.NumericUpDown nudLongitude;
        private System.Windows.Forms.NumericUpDown nudLatitude;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetFieldFix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLatStart;
        private System.Windows.Forms.Label lblLonStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblGPSLon;
        private System.Windows.Forms.Label lblGPSLat;
        private System.Windows.Forms.Button btnLoadGPSFix;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}