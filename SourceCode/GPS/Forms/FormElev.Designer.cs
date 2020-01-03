namespace AgOpenGPS
{
    partial class FormElev
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
            this.oglElev = new OpenTK.GLControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nudWaterLevel = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblBuildMap = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudZoomGain = new System.Windows.Forms.NumericUpDown();
            this.lblDeltaElev = new System.Windows.Forms.Label();
            this.lblMaxElev = new System.Windows.Forms.Label();
            this.lblMinElev = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudWaterLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZoomGain)).BeginInit();
            this.SuspendLayout();
            // 
            // oglElev
            // 
            this.oglElev.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oglElev.BackColor = System.Drawing.Color.Black;
            this.oglElev.Cursor = System.Windows.Forms.Cursors.Cross;
            this.oglElev.Location = new System.Drawing.Point(0, 0);
            this.oglElev.Margin = new System.Windows.Forms.Padding(0);
            this.oglElev.Name = "oglElev";
            this.oglElev.Size = new System.Drawing.Size(794, 629);
            this.oglElev.TabIndex = 184;
            this.oglElev.VSync = false;
            this.oglElev.Load += new System.EventHandler(this.OglElev_Load);
            this.oglElev.Paint += new System.Windows.Forms.PaintEventHandler(this.OglElev_Paint);
            this.oglElev.Resize += new System.EventHandler(this.OglElev_Resize);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // nudWaterLevel
            // 
            this.nudWaterLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudWaterLevel.DecimalPlaces = 1;
            this.nudWaterLevel.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWaterLevel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudWaterLevel.Location = new System.Drawing.Point(903, 50);
            this.nudWaterLevel.Name = "nudWaterLevel";
            this.nudWaterLevel.Size = new System.Drawing.Size(120, 46);
            this.nudWaterLevel.TabIndex = 185;
            this.nudWaterLevel.ValueChanged += new System.EventHandler(this.NudWaterLevel_ValueChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(899, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 23);
            this.label7.TabIndex = 256;
            this.label7.Text = "Water Level";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(99, 166);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(478, 38);
            this.progressBar1.TabIndex = 257;
            // 
            // lblBuildMap
            // 
            this.lblBuildMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuildMap.AutoSize = true;
            this.lblBuildMap.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuildMap.Location = new System.Drawing.Point(119, 140);
            this.lblBuildMap.Name = "lblBuildMap";
            this.lblBuildMap.Size = new System.Drawing.Size(226, 23);
            this.lblBuildMap.TabIndex = 258;
            this.lblBuildMap.Text = "Building Map, Please Wait";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(899, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 260;
            this.label1.Text = "Zoom";
            // 
            // nudZoomGain
            // 
            this.nudZoomGain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudZoomGain.DecimalPlaces = 1;
            this.nudZoomGain.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudZoomGain.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudZoomGain.Location = new System.Drawing.Point(903, 158);
            this.nudZoomGain.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudZoomGain.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudZoomGain.Name = "nudZoomGain";
            this.nudZoomGain.Size = new System.Drawing.Size(120, 46);
            this.nudZoomGain.TabIndex = 259;
            this.nudZoomGain.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nudZoomGain.ValueChanged += new System.EventHandler(this.NudZoomGain_ValueChanged);
            // 
            // lblDeltaElev
            // 
            this.lblDeltaElev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeltaElev.AutoSize = true;
            this.lblDeltaElev.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeltaElev.Location = new System.Drawing.Point(931, 502);
            this.lblDeltaElev.Name = "lblDeltaElev";
            this.lblDeltaElev.Size = new System.Drawing.Size(76, 23);
            this.lblDeltaElev.TabIndex = 261;
            this.lblDeltaElev.Text = "6789.99";
            // 
            // lblMaxElev
            // 
            this.lblMaxElev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaxElev.AutoSize = true;
            this.lblMaxElev.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxElev.Location = new System.Drawing.Point(931, 462);
            this.lblMaxElev.Name = "lblMaxElev";
            this.lblMaxElev.Size = new System.Drawing.Size(76, 23);
            this.lblMaxElev.TabIndex = 262;
            this.lblMaxElev.Text = "3456.66";
            // 
            // lblMinElev
            // 
            this.lblMinElev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinElev.AutoSize = true;
            this.lblMinElev.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinElev.Location = new System.Drawing.Point(931, 422);
            this.lblMinElev.Name = "lblMinElev";
            this.lblMinElev.Size = new System.Drawing.Size(76, 23);
            this.lblMinElev.TabIndex = 263;
            this.lblMinElev.Text = "2345.11";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(886, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 23);
            this.label5.TabIndex = 264;
            this.label5.Text = "Min:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(873, 502);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 23);
            this.label6.TabIndex = 265;
            this.label6.Text = "Delta:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(882, 462);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 23);
            this.label8.TabIndex = 266;
            this.label8.Text = "Max:";
            // 
            // FormElev
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 630);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblMinElev);
            this.Controls.Add(this.lblMaxElev);
            this.Controls.Add(this.lblDeltaElev);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudZoomGain);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudWaterLevel);
            this.Controls.Add(this.lblBuildMap);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.oglElev);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormElev";
            this.ShowInTaskbar = false;
            this.Text = "FormElev";
            this.Load += new System.EventHandler(this.FormElev_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudWaterLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZoomGain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl oglElev;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown nudWaterLevel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblBuildMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudZoomGain;
        private System.Windows.Forms.Label lblDeltaElev;
        private System.Windows.Forms.Label lblMaxElev;
        private System.Windows.Forms.Label lblMinElev;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}