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
            ((System.ComponentModel.ISupportInitialize)(this.nudWaterLevel)).BeginInit();
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
            this.nudWaterLevel.DecimalPlaces = 1;
            this.nudWaterLevel.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWaterLevel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudWaterLevel.Location = new System.Drawing.Point(880, 218);
            this.nudWaterLevel.Name = "nudWaterLevel";
            this.nudWaterLevel.Size = new System.Drawing.Size(120, 46);
            this.nudWaterLevel.TabIndex = 185;
            this.nudWaterLevel.ValueChanged += new System.EventHandler(this.NudWaterLevel_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(876, 192);
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
            // FormElev
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 630);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudWaterLevel);
            this.Controls.Add(this.lblBuildMap);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.oglElev);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormElev";
            this.Text = "FormElev";
            this.Load += new System.EventHandler(this.FormElev_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudWaterLevel)).EndInit();
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
    }
}