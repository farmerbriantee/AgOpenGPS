namespace AgOpenGPS
{
    partial class FormBndTool
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
            this.cboxSmooth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.tlp1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tlp1.SuspendLayout();
            this.SuspendLayout();
            // 
            // oglSelf
            // 
            this.oglSelf.BackColor = System.Drawing.Color.Black;
            this.oglSelf.Cursor = System.Windows.Forms.Cursors.Cross;
            this.oglSelf.Location = new System.Drawing.Point(0, 0);
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
            this.lblStartPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlp1.SetColumnSpan(this.lblStartPoints, 3);
            this.lblStartPoints.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartPoints.ForeColor = System.Drawing.Color.Black;
            this.lblStartPoints.Location = new System.Drawing.Point(158, 38);
            this.lblStartPoints.Name = "lblStartPoints";
            this.lblStartPoints.Size = new System.Drawing.Size(138, 25);
            this.lblStartPoints.TabIndex = 524;
            this.lblStartPoints.Text = "Points";
            this.lblStartPoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboxPointDistance
            // 
            this.cboxPointDistance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboxPointDistance.BackColor = System.Drawing.Color.Lavender;
            this.tlp1.SetColumnSpan(this.cboxPointDistance, 3);
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
            this.cboxPointDistance.Location = new System.Drawing.Point(27, 136);
            this.cboxPointDistance.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxPointDistance.Name = "cboxPointDistance";
            this.cboxPointDistance.Size = new System.Drawing.Size(101, 53);
            this.cboxPointDistance.TabIndex = 541;
            this.cboxPointDistance.SelectedIndexChanged += new System.EventHandler(this.cboxPointDistance_SelectedIndexChanged);
            // 
            // lblReducedPoints
            // 
            this.lblReducedPoints.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tlp1.SetColumnSpan(this.lblReducedPoints, 3);
            this.lblReducedPoints.Enabled = false;
            this.lblReducedPoints.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReducedPoints.ForeColor = System.Drawing.Color.Black;
            this.lblReducedPoints.Location = new System.Drawing.Point(167, 108);
            this.lblReducedPoints.Name = "lblReducedPoints";
            this.lblReducedPoints.Size = new System.Drawing.Size(120, 25);
            this.lblReducedPoints.TabIndex = 542;
            this.lblReducedPoints.Text = "***";
            this.lblReducedPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxSmooth
            // 
            this.cboxSmooth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboxSmooth.BackColor = System.Drawing.Color.Lavender;
            this.tlp1.SetColumnSpan(this.cboxSmooth, 3);
            this.cboxSmooth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSmooth.Enabled = false;
            this.cboxSmooth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxSmooth.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSmooth.FormattingEnabled = true;
            this.cboxSmooth.Items.AddRange(new object[] {
            "0",
            "4",
            "8",
            "16",
            "32",
            "64"});
            this.cboxSmooth.Location = new System.Drawing.Point(27, 264);
            this.cboxSmooth.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxSmooth.Name = "cboxSmooth";
            this.cboxSmooth.Size = new System.Drawing.Size(101, 53);
            this.cboxSmooth.TabIndex = 547;
            this.cboxSmooth.SelectedIndexChanged += new System.EventHandler(this.cboxSmooth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.tlp1.SetColumnSpan(this.label1, 2);
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(38, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 25);
            this.label1.TabIndex = 562;
            this.label1.Text = "m";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.tlp1.SetColumnSpan(this.label6, 3);
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(42, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 19);
            this.label6.TabIndex = 569;
            this.label6.Text = "Smooth";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxIsZoom
            // 
            this.cboxIsZoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxIsZoom.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsZoom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboxIsZoom.Checked = true;
            this.cboxIsZoom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tlp1.SetColumnSpan(this.cboxIsZoom, 3);
            this.cboxIsZoom.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxIsZoom.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(160)))));
            this.cboxIsZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsZoom.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsZoom.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cboxIsZoom.Image = global::AgOpenGPS.Properties.Resources.ZoomOGL;
            this.cboxIsZoom.Location = new System.Drawing.Point(37, 375);
            this.cboxIsZoom.Name = "cboxIsZoom";
            this.cboxIsZoom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxIsZoom.Size = new System.Drawing.Size(81, 83);
            this.cboxIsZoom.TabIndex = 561;
            this.cboxIsZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsZoom.UseVisualStyleBackColor = false;
            this.cboxIsZoom.CheckedChanged += new System.EventHandler(this.cboxIsZoom_CheckedChanged);
            this.cboxIsZoom.Click += new System.EventHandler(this.cboxIsZoom_Click);
            // 
            // btnCenterOGL
            // 
            this.btnCenterOGL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCenterOGL.BackColor = System.Drawing.Color.White;
            this.btnCenterOGL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tlp1.SetColumnSpan(this.btnCenterOGL, 3);
            this.btnCenterOGL.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCenterOGL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCenterOGL.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCenterOGL.Image = global::AgOpenGPS.Properties.Resources.ConS_SourceFix;
            this.btnCenterOGL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCenterOGL.Location = new System.Drawing.Point(37, 494);
            this.btnCenterOGL.Name = "btnCenterOGL";
            this.btnCenterOGL.Size = new System.Drawing.Size(81, 83);
            this.btnCenterOGL.TabIndex = 560;
            this.btnCenterOGL.UseVisualStyleBackColor = false;
            this.btnCenterOGL.Click += new System.EventHandler(this.btnCenterOGL_Click);
            // 
            // btnSlice
            // 
            this.btnSlice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSlice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSlice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tlp1.SetColumnSpan(this.btnSlice, 3);
            this.btnSlice.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSlice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlice.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSlice.Image = global::AgOpenGPS.Properties.Resources.BoundaryMakeLine;
            this.btnSlice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSlice.Location = new System.Drawing.Point(186, 375);
            this.btnSlice.Name = "btnSlice";
            this.btnSlice.Size = new System.Drawing.Size(81, 83);
            this.btnSlice.TabIndex = 548;
            this.btnSlice.UseVisualStyleBackColor = false;
            this.btnSlice.Click += new System.EventHandler(this.btnSlice_Click);
            // 
            // btnMakeBoundary
            // 
            this.btnMakeBoundary.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMakeBoundary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMakeBoundary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tlp1.SetColumnSpan(this.btnMakeBoundary, 3);
            this.btnMakeBoundary.Enabled = false;
            this.btnMakeBoundary.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMakeBoundary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeBoundary.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMakeBoundary.Image = global::AgOpenGPS.Properties.Resources.BoundaryOuter;
            this.btnMakeBoundary.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeBoundary.Location = new System.Drawing.Point(172, 264);
            this.btnMakeBoundary.Name = "btnMakeBoundary";
            this.btnMakeBoundary.Size = new System.Drawing.Size(110, 68);
            this.btnMakeBoundary.TabIndex = 545;
            this.btnMakeBoundary.UseVisualStyleBackColor = false;
            this.btnMakeBoundary.Click += new System.EventHandler(this.btnMakeBoundary_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStartStop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnStartStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tlp1.SetColumnSpan(this.btnStartStop, 3);
            this.btnStartStop.Enabled = false;
            this.btnStartStop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStop.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnStartStop.Image = global::AgOpenGPS.Properties.Resources.BoundaryReduce;
            this.btnStartStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStartStop.Location = new System.Drawing.Point(169, 136);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(115, 61);
            this.btnStartStop.TabIndex = 544;
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnResetReduce
            // 
            this.btnResetReduce.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnResetReduce.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnResetReduce.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tlp1.SetColumnSpan(this.btnResetReduce, 3);
            this.btnResetReduce.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnResetReduce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetReduce.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnResetReduce.Image = global::AgOpenGPS.Properties.Resources.SwitchOn;
            this.btnResetReduce.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetReduce.Location = new System.Drawing.Point(20, 20);
            this.btnResetReduce.Name = "btnResetReduce";
            this.btnResetReduce.Size = new System.Drawing.Size(115, 61);
            this.btnResetReduce.TabIndex = 540;
            this.btnResetReduce.UseVisualStyleBackColor = false;
            this.btnResetReduce.Click += new System.EventHandler(this.btnResetReduce_Click);
            // 
            // btnCancelTouch
            // 
            this.btnCancelTouch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelTouch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelTouch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tlp1.SetColumnSpan(this.btnCancelTouch, 3);
            this.btnCancelTouch.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelTouch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelTouch.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancelTouch.Image = global::AgOpenGPS.Properties.Resources.HeadlandDeletePoints;
            this.btnCancelTouch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelTouch.Location = new System.Drawing.Point(186, 494);
            this.btnCancelTouch.Name = "btnCancelTouch";
            this.btnCancelTouch.Size = new System.Drawing.Size(81, 83);
            this.btnCancelTouch.TabIndex = 470;
            this.btnCancelTouch.UseVisualStyleBackColor = false;
            this.btnCancelTouch.Click += new System.EventHandler(this.btnCancelTouch_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.tlp1.SetColumnSpan(this.btnExit, 2);
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExit.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnExit.Location = new System.Drawing.Point(217, 613);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(63, 70);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnZoomOut.BackColor = System.Drawing.Color.White;
            this.btnZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tlp1.SetColumnSpan(this.btnZoomOut, 2);
            this.btnZoomOut.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomOut.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomOut.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZoomOut.Location = new System.Drawing.Point(19, 613);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(69, 69);
            this.btnZoomOut.TabIndex = 570;
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnZoomIn.BackColor = System.Drawing.Color.White;
            this.btnZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tlp1.SetColumnSpan(this.btnZoomIn, 2);
            this.btnZoomIn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomIn.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomIn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZoomIn.Location = new System.Drawing.Point(118, 613);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(69, 69);
            this.btnZoomIn.TabIndex = 571;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // tlp1
            // 
            this.tlp1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tlp1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlp1.ColumnCount = 6;
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.7507F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.4958F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.79832F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.45378F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.7507F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.7507F));
            this.tlp1.Controls.Add(this.btnZoomOut, 0, 7);
            this.tlp1.Controls.Add(this.label6, 0, 3);
            this.tlp1.Controls.Add(this.btnZoomIn, 2, 7);
            this.tlp1.Controls.Add(this.lblStartPoints, 3, 0);
            this.tlp1.Controls.Add(this.btnResetReduce, 0, 0);
            this.tlp1.Controls.Add(this.cboxPointDistance, 0, 2);
            this.tlp1.Controls.Add(this.btnCancelTouch, 3, 6);
            this.tlp1.Controls.Add(this.btnSlice, 3, 5);
            this.tlp1.Controls.Add(this.btnCenterOGL, 0, 6);
            this.tlp1.Controls.Add(this.btnStartStop, 3, 2);
            this.tlp1.Controls.Add(this.label1, 0, 1);
            this.tlp1.Controls.Add(this.lblReducedPoints, 3, 1);
            this.tlp1.Controls.Add(this.btnMakeBoundary, 3, 4);
            this.tlp1.Controls.Add(this.cboxSmooth, 0, 4);
            this.tlp1.Controls.Add(this.btnExit, 4, 7);
            this.tlp1.Controls.Add(this.cboxIsZoom, 0, 5);
            this.tlp1.Controls.Add(this.label2, 3, 3);
            this.tlp1.Location = new System.Drawing.Point(701, 0);
            this.tlp1.Name = "tlp1";
            this.tlp1.RowCount = 8;
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.57143F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.428571F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.85714F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.71428F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.28572F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.71429F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp1.Size = new System.Drawing.Size(299, 700);
            this.tlp1.TabIndex = 572;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.tlp1.SetColumnSpan(this.label2, 3);
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(195, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.TabIndex = 572;
            this.label2.Text = "Create";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormBndTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1006, 726);
            this.ControlBox = false;
            this.Controls.Add(this.tlp1);
            this.Controls.Add(this.oglSelf);
            this.ForeColor = System.Drawing.Color.Black;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1022, 742);
            this.Name = "FormBndTool";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Boundary From Mapping";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBndTool_FormClosing);
            this.Load += new System.EventHandler(this.FormBndTool_Load);
            this.ResizeEnd += new System.EventHandler(this.FormBndTool_ResizeEnd);
            this.tlp1.ResumeLayout(false);
            this.tlp1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnMakeBoundary;
        private System.Windows.Forms.ComboBox cboxSmooth;
        private System.Windows.Forms.Button btnSlice;
        private System.Windows.Forms.Button btnCenterOGL;
        private System.Windows.Forms.CheckBox cboxIsZoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.TableLayoutPanel tlp1;
        private System.Windows.Forms.Label label2;
    }
}