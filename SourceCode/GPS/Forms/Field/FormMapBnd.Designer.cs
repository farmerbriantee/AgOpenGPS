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
            this.lblStartPoints = new System.Windows.Forms.Label();
            this.cboxPointDistance = new System.Windows.Forms.ComboBox();
            this.lblReducedPoints = new System.Windows.Forms.Label();
            this.lblDist = new System.Windows.Forms.Label();
            this.cboxSmooth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboxIsZoom = new System.Windows.Forms.CheckBox();
            this.btnCenterOGL = new System.Windows.Forms.Button();
            this.btnSlice = new System.Windows.Forms.Button();
            this.btnMakeBoundary = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnResetReduce = new System.Windows.Forms.Button();
            this.btnCancelTouch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
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
            // lblStartPoints
            // 
            this.lblStartPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartPoints.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartPoints.ForeColor = System.Drawing.Color.Black;
            this.lblStartPoints.Location = new System.Drawing.Point(848, 23);
            this.lblStartPoints.Name = "lblStartPoints";
            this.lblStartPoints.Size = new System.Drawing.Size(139, 25);
            this.lblStartPoints.TabIndex = 524;
            this.lblStartPoints.Text = "Points";
            this.lblStartPoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboxPointDistance
            // 
            this.cboxPointDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxPointDistance.BackColor = System.Drawing.Color.Lavender;
            this.cboxPointDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPointDistance.Enabled = false;
            this.cboxPointDistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.cboxPointDistance.Location = new System.Drawing.Point(726, 115);
            this.cboxPointDistance.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxPointDistance.Name = "cboxPointDistance";
            this.cboxPointDistance.Size = new System.Drawing.Size(88, 53);
            this.cboxPointDistance.TabIndex = 541;
            this.cboxPointDistance.SelectedIndexChanged += new System.EventHandler(this.cboxPointDistance_SelectedIndexChanged);
            // 
            // lblReducedPoints
            // 
            this.lblReducedPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReducedPoints.Enabled = false;
            this.lblReducedPoints.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReducedPoints.ForeColor = System.Drawing.Color.Black;
            this.lblReducedPoints.Location = new System.Drawing.Point(871, 81);
            this.lblReducedPoints.Name = "lblReducedPoints";
            this.lblReducedPoints.Size = new System.Drawing.Size(115, 25);
            this.lblReducedPoints.TabIndex = 542;
            this.lblReducedPoints.Text = "***";
            this.lblReducedPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDist
            // 
            this.lblDist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDist.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDist.ForeColor = System.Drawing.Color.Black;
            this.lblDist.Location = new System.Drawing.Point(726, 295);
            this.lblDist.Name = "lblDist";
            this.lblDist.Size = new System.Drawing.Size(237, 25);
            this.lblDist.TabIndex = 543;
            this.lblDist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxSmooth
            // 
            this.cboxSmooth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxSmooth.BackColor = System.Drawing.Color.Lavender;
            this.cboxSmooth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSmooth.Enabled = false;
            this.cboxSmooth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxSmooth.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSmooth.FormattingEnabled = true;
            this.cboxSmooth.Items.AddRange(new object[] {
            "4",
            "8",
            "16",
            "32",
            "64"});
            this.cboxSmooth.Location = new System.Drawing.Point(726, 231);
            this.cboxSmooth.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxSmooth.Name = "cboxSmooth";
            this.cboxSmooth.Size = new System.Drawing.Size(88, 53);
            this.cboxSmooth.TabIndex = 547;
            this.cboxSmooth.SelectedIndexChanged += new System.EventHandler(this.cboxSmooth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(817, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 25);
            this.label1.TabIndex = 562;
            this.label1.Text = "m";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(712, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 563;
            this.label2.Text = "1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(706, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 564;
            this.label3.Text = "2";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(855, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 565;
            this.label4.Text = "3";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(708, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 566;
            this.label5.Text = "4";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(856, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 568;
            this.label7.Text = "5";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(741, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 569;
            this.label6.Text = "Smooth";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cboxIsZoom.Location = new System.Drawing.Point(731, 344);
            this.cboxIsZoom.Name = "cboxIsZoom";
            this.cboxIsZoom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxIsZoom.Size = new System.Drawing.Size(81, 83);
            this.cboxIsZoom.TabIndex = 561;
            this.cboxIsZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsZoom.UseVisualStyleBackColor = false;
            this.cboxIsZoom.Click += new System.EventHandler(this.cboxIsZoom_Click);
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
            this.btnCenterOGL.Location = new System.Drawing.Point(731, 466);
            this.btnCenterOGL.Name = "btnCenterOGL";
            this.btnCenterOGL.Size = new System.Drawing.Size(81, 83);
            this.btnCenterOGL.TabIndex = 560;
            this.btnCenterOGL.UseVisualStyleBackColor = false;
            this.btnCenterOGL.Click += new System.EventHandler(this.btnCenterOGL_Click);
            // 
            // btnSlice
            // 
            this.btnSlice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSlice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSlice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSlice.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSlice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlice.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSlice.Image = global::AgOpenGPS.Properties.Resources.BoundaryMakeLine;
            this.btnSlice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSlice.Location = new System.Drawing.Point(877, 345);
            this.btnSlice.Name = "btnSlice";
            this.btnSlice.Size = new System.Drawing.Size(81, 83);
            this.btnSlice.TabIndex = 548;
            this.btnSlice.UseVisualStyleBackColor = false;
            this.btnSlice.Click += new System.EventHandler(this.btnSlice_Click);
            // 
            // btnMakeBoundary
            // 
            this.btnMakeBoundary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeBoundary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMakeBoundary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMakeBoundary.Enabled = false;
            this.btnMakeBoundary.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMakeBoundary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeBoundary.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMakeBoundary.Image = global::AgOpenGPS.Properties.Resources.BoundaryOuter;
            this.btnMakeBoundary.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeBoundary.Location = new System.Drawing.Point(877, 221);
            this.btnMakeBoundary.Name = "btnMakeBoundary";
            this.btnMakeBoundary.Size = new System.Drawing.Size(110, 68);
            this.btnMakeBoundary.TabIndex = 545;
            this.btnMakeBoundary.UseVisualStyleBackColor = false;
            this.btnMakeBoundary.Click += new System.EventHandler(this.btnMakeBoundary_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartStop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnStartStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStartStop.Enabled = false;
            this.btnStartStop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStop.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnStartStop.Image = global::AgOpenGPS.Properties.Resources.BoundaryReduce;
            this.btnStartStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStartStop.Location = new System.Drawing.Point(877, 110);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(115, 61);
            this.btnStartStop.TabIndex = 544;
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnResetReduce
            // 
            this.btnResetReduce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetReduce.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnResetReduce.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnResetReduce.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnResetReduce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetReduce.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnResetReduce.Image = global::AgOpenGPS.Properties.Resources.BoundarySmooth;
            this.btnResetReduce.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetReduce.Location = new System.Drawing.Point(726, 5);
            this.btnResetReduce.Name = "btnResetReduce";
            this.btnResetReduce.Size = new System.Drawing.Size(115, 61);
            this.btnResetReduce.TabIndex = 540;
            this.btnResetReduce.UseVisualStyleBackColor = false;
            this.btnResetReduce.Click += new System.EventHandler(this.btnResetReduce_Click);
            // 
            // btnCancelTouch
            // 
            this.btnCancelTouch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelTouch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelTouch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancelTouch.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelTouch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelTouch.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancelTouch.Image = global::AgOpenGPS.Properties.Resources.HeadlandDeletePoints;
            this.btnCancelTouch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelTouch.Location = new System.Drawing.Point(877, 466);
            this.btnCancelTouch.Name = "btnCancelTouch";
            this.btnCancelTouch.Size = new System.Drawing.Size(81, 83);
            this.btnCancelTouch.TabIndex = 470;
            this.btnCancelTouch.UseVisualStyleBackColor = false;
            this.btnCancelTouch.Click += new System.EventHandler(this.btnCancelTouch_Click);
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
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomOut.BackColor = System.Drawing.Color.White;
            this.btnZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZoomOut.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomOut.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomOut.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZoomOut.Location = new System.Drawing.Point(729, 582);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(66, 69);
            this.btnZoomOut.TabIndex = 570;
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomIn.BackColor = System.Drawing.Color.White;
            this.btnZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZoomIn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomIn.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomIn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZoomIn.Location = new System.Drawing.Point(822, 582);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(66, 69);
            this.btnZoomIn.TabIndex = 571;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // FormMapBnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1000, 711);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxIsZoom);
            this.Controls.Add(this.btnCenterOGL);
            this.Controls.Add(this.btnSlice);
            this.Controls.Add(this.cboxSmooth);
            this.Controls.Add(this.btnMakeBoundary);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.lblReducedPoints);
            this.Controls.Add(this.cboxPointDistance);
            this.Controls.Add(this.btnResetReduce);
            this.Controls.Add(this.lblStartPoints);
            this.Controls.Add(this.btnCancelTouch);
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
        private System.Windows.Forms.Button btnCancelTouch;
        private System.Windows.Forms.Label lblStartPoints;
        private System.Windows.Forms.ComboBox cboxPointDistance;
        private System.Windows.Forms.Button btnResetReduce;
        private System.Windows.Forms.Label lblReducedPoints;
        private System.Windows.Forms.Label lblDist;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnMakeBoundary;
        private System.Windows.Forms.ComboBox cboxSmooth;
        private System.Windows.Forms.Button btnSlice;
        private System.Windows.Forms.Button btnCenterOGL;
        private System.Windows.Forms.CheckBox cboxIsZoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
    }
}