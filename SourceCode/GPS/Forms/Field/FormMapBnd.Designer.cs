namespace AgOpenGPS
{
    partial class FormMapBnd
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
            this.oglSelf = new OpenTK.GLControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCancelTouch = new System.Windows.Forms.Button();
            this.lblStartPoints = new System.Windows.Forms.Label();
            this.cboxPointDistance = new System.Windows.Forms.ComboBox();
            this.btnResetReduce = new System.Windows.Forms.Button();
            this.lblReducedPoints = new System.Windows.Forms.Label();
            this.lblDist = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnMakeBoundary = new System.Windows.Forms.Button();
            this.btnSmooth = new System.Windows.Forms.Button();
            this.cboxSmooth = new System.Windows.Forms.ComboBox();
            this.btnSlice = new System.Windows.Forms.Button();
            this.btnCenterOGL = new System.Windows.Forms.Button();
            this.cboxIsZoom = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // oglSelf
            // 
            this.oglSelf.BackColor = System.Drawing.Color.Black;
            this.oglSelf.Cursor = System.Windows.Forms.Cursors.Cross;
            this.oglSelf.Location = new System.Drawing.Point(5, 5);
            this.oglSelf.Margin = new System.Windows.Forms.Padding(0);
            this.oglSelf.Name = "oglSelf";
            this.oglSelf.Size = new System.Drawing.Size(700, 700);
            this.oglSelf.TabIndex = 183;
            this.oglSelf.VSync = false;
            this.oglSelf.Load += new System.EventHandler(this.oglSelf_Load);
            this.oglSelf.Paint += new System.Windows.Forms.PaintEventHandler(this.oglSelf_Paint);
            this.oglSelf.MouseDown += new System.Windows.Forms.MouseEventHandler(this.oglSelf_MouseDown);
            this.oglSelf.Resize += new System.EventHandler(this.oglSelf_Resize);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExit.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.Location = new System.Drawing.Point(906, 628);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 70);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(726, 633);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 66);
            this.btnCancel.TabIndex = 469;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCancelTouch
            // 
            this.btnCancelTouch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelTouch.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelTouch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancelTouch.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelTouch.FlatAppearance.BorderSize = 0;
            this.btnCancelTouch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelTouch.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancelTouch.Image = global::AgOpenGPS.Properties.Resources.HeadlandDeletePoints;
            this.btnCancelTouch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelTouch.Location = new System.Drawing.Point(830, 628);
            this.btnCancelTouch.Name = "btnCancelTouch";
            this.btnCancelTouch.Size = new System.Drawing.Size(70, 68);
            this.btnCancelTouch.TabIndex = 470;
            this.btnCancelTouch.UseVisualStyleBackColor = false;
            this.btnCancelTouch.Click += new System.EventHandler(this.btnCancelTouch_Click);
            // 
            // lblStartPoints
            // 
            this.lblStartPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartPoints.AutoSize = true;
            this.lblStartPoints.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartPoints.ForeColor = System.Drawing.Color.Black;
            this.lblStartPoints.Location = new System.Drawing.Point(851, 9);
            this.lblStartPoints.Name = "lblStartPoints";
            this.lblStartPoints.Size = new System.Drawing.Size(46, 25);
            this.lblStartPoints.TabIndex = 524;
            this.lblStartPoints.Text = "Pts";
            this.lblStartPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxPointDistance
            // 
            this.cboxPointDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxPointDistance.BackColor = System.Drawing.Color.Lavender;
            this.cboxPointDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPointDistance.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxPointDistance.FormattingEnabled = true;
            this.cboxPointDistance.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cboxPointDistance.Location = new System.Drawing.Point(726, 80);
            this.cboxPointDistance.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxPointDistance.Name = "cboxPointDistance";
            this.cboxPointDistance.Size = new System.Drawing.Size(88, 53);
            this.cboxPointDistance.TabIndex = 541;
            this.cboxPointDistance.SelectedIndexChanged += new System.EventHandler(this.cboxPointDistance_SelectedIndexChanged);
            // 
            // btnResetReduce
            // 
            this.btnResetReduce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetReduce.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnResetReduce.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnResetReduce.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnResetReduce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetReduce.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnResetReduce.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetReduce.Location = new System.Drawing.Point(726, 5);
            this.btnResetReduce.Name = "btnResetReduce";
            this.btnResetReduce.Size = new System.Drawing.Size(116, 52);
            this.btnResetReduce.TabIndex = 540;
            this.btnResetReduce.Text = "Start";
            this.btnResetReduce.UseVisualStyleBackColor = false;
            this.btnResetReduce.Click += new System.EventHandler(this.btnResetReduce_Click);
            // 
            // lblReducedPoints
            // 
            this.lblReducedPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReducedPoints.AutoSize = true;
            this.lblReducedPoints.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReducedPoints.ForeColor = System.Drawing.Color.Black;
            this.lblReducedPoints.Location = new System.Drawing.Point(756, 136);
            this.lblReducedPoints.Name = "lblReducedPoints";
            this.lblReducedPoints.Size = new System.Drawing.Size(51, 25);
            this.lblReducedPoints.TabIndex = 542;
            this.lblReducedPoints.Text = "***";
            this.lblReducedPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDist
            // 
            this.lblDist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDist.AutoSize = true;
            this.lblDist.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDist.ForeColor = System.Drawing.Color.Black;
            this.lblDist.Location = new System.Drawing.Point(836, 553);
            this.lblDist.Name = "lblDist";
            this.lblDist.Size = new System.Drawing.Size(51, 25);
            this.lblDist.TabIndex = 543;
            this.lblDist.Text = "***";
            this.lblDist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartStop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnStartStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStartStop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStop.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnStartStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStartStop.Location = new System.Drawing.Point(873, 80);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(115, 53);
            this.btnStartStop.TabIndex = 544;
            this.btnStartStop.Text = "Begin";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnMakeBoundary
            // 
            this.btnMakeBoundary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeBoundary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMakeBoundary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMakeBoundary.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMakeBoundary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeBoundary.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMakeBoundary.Image = global::AgOpenGPS.Properties.Resources.Boundary;
            this.btnMakeBoundary.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeBoundary.Location = new System.Drawing.Point(726, 260);
            this.btnMakeBoundary.Name = "btnMakeBoundary";
            this.btnMakeBoundary.Size = new System.Drawing.Size(115, 68);
            this.btnMakeBoundary.TabIndex = 545;
            this.btnMakeBoundary.UseVisualStyleBackColor = false;
            this.btnMakeBoundary.Click += new System.EventHandler(this.btnMakeBoundary_Click);
            // 
            // btnSmooth
            // 
            this.btnSmooth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSmooth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSmooth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSmooth.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSmooth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSmooth.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSmooth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSmooth.Location = new System.Drawing.Point(873, 174);
            this.btnSmooth.Name = "btnSmooth";
            this.btnSmooth.Size = new System.Drawing.Size(116, 53);
            this.btnSmooth.TabIndex = 546;
            this.btnSmooth.Text = "Smooth";
            this.btnSmooth.UseVisualStyleBackColor = false;
            this.btnSmooth.Click += new System.EventHandler(this.btnSmooth_Click);
            // 
            // cboxSmooth
            // 
            this.cboxSmooth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxSmooth.BackColor = System.Drawing.Color.Lavender;
            this.cboxSmooth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSmooth.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSmooth.FormattingEnabled = true;
            this.cboxSmooth.Items.AddRange(new object[] {
            "4",
            "8",
            "12",
            "16",
            "20",
            "24",
            "28",
            "32"});
            this.cboxSmooth.Location = new System.Drawing.Point(726, 174);
            this.cboxSmooth.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxSmooth.Name = "cboxSmooth";
            this.cboxSmooth.Size = new System.Drawing.Size(117, 53);
            this.cboxSmooth.TabIndex = 547;
            this.cboxSmooth.SelectedIndexChanged += new System.EventHandler(this.cboxSmooth_SelectedIndexChanged);
            // 
            // btnSlice
            // 
            this.btnSlice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSlice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSlice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSlice.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSlice.FlatAppearance.BorderSize = 0;
            this.btnSlice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlice.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSlice.Image = global::AgOpenGPS.Properties.Resources.HeadlandSlice;
            this.btnSlice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSlice.Location = new System.Drawing.Point(873, 395);
            this.btnSlice.Name = "btnSlice";
            this.btnSlice.Size = new System.Drawing.Size(81, 71);
            this.btnSlice.TabIndex = 548;
            this.btnSlice.UseVisualStyleBackColor = false;
            this.btnSlice.Click += new System.EventHandler(this.btnSlice_Click);
            // 
            // btnCenterOGL
            // 
            this.btnCenterOGL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCenterOGL.BackColor = System.Drawing.Color.White;
            this.btnCenterOGL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCenterOGL.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCenterOGL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCenterOGL.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCenterOGL.Image = global::AgOpenGPS.Properties.Resources.ConS_SourceFix;
            this.btnCenterOGL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCenterOGL.Location = new System.Drawing.Point(726, 388);
            this.btnCenterOGL.Name = "btnCenterOGL";
            this.btnCenterOGL.Size = new System.Drawing.Size(81, 80);
            this.btnCenterOGL.TabIndex = 560;
            this.btnCenterOGL.UseVisualStyleBackColor = false;
            this.btnCenterOGL.Click += new System.EventHandler(this.btnCenterOGL_Click);
            // 
            // cboxIsZoom
            // 
            this.cboxIsZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxIsZoom.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsZoom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboxIsZoom.Checked = true;
            this.cboxIsZoom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxIsZoom.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxIsZoom.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(160)))));
            this.cboxIsZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsZoom.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsZoom.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cboxIsZoom.Image = global::AgOpenGPS.Properties.Resources.ZoomOGL;
            this.cboxIsZoom.Location = new System.Drawing.Point(726, 498);
            this.cboxIsZoom.Name = "cboxIsZoom";
            this.cboxIsZoom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxIsZoom.Size = new System.Drawing.Size(81, 80);
            this.cboxIsZoom.TabIndex = 561;
            this.cboxIsZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsZoom.UseVisualStyleBackColor = false;
            this.cboxIsZoom.Click += new System.EventHandler(this.cboxIsZoom_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(818, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 25);
            this.label1.TabIndex = 562;
            this.label1.Text = "m";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMapBnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1000, 711);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxIsZoom);
            this.Controls.Add(this.btnCenterOGL);
            this.Controls.Add(this.btnSlice);
            this.Controls.Add(this.cboxSmooth);
            this.Controls.Add(this.btnSmooth);
            this.Controls.Add(this.btnMakeBoundary);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.lblReducedPoints);
            this.Controls.Add(this.cboxPointDistance);
            this.Controls.Add(this.btnResetReduce);
            this.Controls.Add(this.lblStartPoints);
            this.Controls.Add(this.btnCancelTouch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.oglSelf);
            this.Controls.Add(this.lblDist);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMapBnd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Draw AB - Click 2 points on the Boundary to Begin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMapBnd_FormClosing);
            this.Load += new System.EventHandler(this.FormMapBnd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl oglSelf;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCancelTouch;
        private System.Windows.Forms.Label lblStartPoints;
        private System.Windows.Forms.ComboBox cboxPointDistance;
        private System.Windows.Forms.Button btnResetReduce;
        private System.Windows.Forms.Label lblReducedPoints;
        private System.Windows.Forms.Label lblDist;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnMakeBoundary;
        private System.Windows.Forms.Button btnSmooth;
        private System.Windows.Forms.ComboBox cboxSmooth;
        private System.Windows.Forms.Button btnSlice;
        private System.Windows.Forms.Button btnCenterOGL;
        private System.Windows.Forms.CheckBox cboxIsZoom;
        private System.Windows.Forms.Label label1;
    }
}