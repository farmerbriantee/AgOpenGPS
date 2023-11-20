namespace AgOpenGPS
{
    partial class FormABDraw
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
            this.lblNumCu = new System.Windows.Forms.Label();
            this.lblCurveSelected = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxNameCurve = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.headingGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnBoundary = new System.Windows.Forms.RadioButton();
            this.rbtnLine = new System.Windows.Forms.RadioButton();
            this.rbtnCurve = new System.Windows.Forms.RadioButton();
            this.btnMakeInnerBoundaryCurve = new System.Windows.Forms.Button();
            this.btnMakeOuterBoundaryCurve = new System.Windows.Forms.Button();
            this.btnALength = new System.Windows.Forms.Button();
            this.btnBLength = new System.Windows.Forms.Button();
            this.btnDrawSections = new System.Windows.Forms.Button();
            this.btnCancelTouch = new System.Windows.Forms.Button();
            this.btnDeleteCurve = new System.Windows.Forms.Button();
            this.btnVisible = new System.Windows.Forms.Button();
            this.btnSelectCurve = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.headingGroupBox.SuspendLayout();
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
            this.oglSelf.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.oglSelf_HelpRequested);
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
            // lblNumCu
            // 
            this.lblNumCu.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumCu.ForeColor = System.Drawing.Color.Black;
            this.lblNumCu.Location = new System.Drawing.Point(954, 576);
            this.lblNumCu.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumCu.Name = "lblNumCu";
            this.lblNumCu.Size = new System.Drawing.Size(35, 26);
            this.lblNumCu.TabIndex = 327;
            this.lblNumCu.Text = "1";
            this.lblNumCu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurveSelected
            // 
            this.lblCurveSelected.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurveSelected.ForeColor = System.Drawing.Color.Black;
            this.lblCurveSelected.Location = new System.Drawing.Point(875, 577);
            this.lblCurveSelected.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurveSelected.Name = "lblCurveSelected";
            this.lblCurveSelected.Size = new System.Drawing.Size(35, 26);
            this.lblCurveSelected.TabIndex = 329;
            this.lblCurveSelected.Text = "1";
            this.lblCurveSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(917, 578);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 23);
            this.label1.TabIndex = 332;
            this.label1.Text = "of";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tboxNameCurve
            // 
            this.tboxNameCurve.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tboxNameCurve.CausesValidation = false;
            this.tboxNameCurve.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxNameCurve.Location = new System.Drawing.Point(715, 549);
            this.tboxNameCurve.Margin = new System.Windows.Forms.Padding(0);
            this.tboxNameCurve.MaxLength = 100;
            this.tboxNameCurve.Name = "tboxNameCurve";
            this.tboxNameCurve.Size = new System.Drawing.Size(283, 27);
            this.tboxNameCurve.TabIndex = 10;
            this.tboxNameCurve.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxNameCurve.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.tboxNameCurve_HelpRequested);
            this.tboxNameCurve.Enter += new System.EventHandler(this.tboxNameCurve_Enter);
            this.tboxNameCurve.Leave += new System.EventHandler(this.tboxNameCurve_Leave);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(815, 608);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Mapping";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headingGroupBox
            // 
            this.headingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.headingGroupBox.Controls.Add(this.rbtnBoundary);
            this.headingGroupBox.Controls.Add(this.rbtnLine);
            this.headingGroupBox.Controls.Add(this.rbtnCurve);
            this.headingGroupBox.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingGroupBox.ForeColor = System.Drawing.Color.Black;
            this.headingGroupBox.Location = new System.Drawing.Point(870, 88);
            this.headingGroupBox.Name = "headingGroupBox";
            this.headingGroupBox.Size = new System.Drawing.Size(115, 335);
            this.headingGroupBox.TabIndex = 438;
            this.headingGroupBox.TabStop = false;
            this.headingGroupBox.Text = "Track";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(726, 444);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 501;
            this.label2.Text = "Active";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbtnBoundary
            // 
            this.rbtnBoundary.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnBoundary.BackColor = System.Drawing.Color.AliceBlue;
            this.rbtnBoundary.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleTurquoise;
            this.rbtnBoundary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnBoundary.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnBoundary.ForeColor = System.Drawing.Color.Black;
            this.rbtnBoundary.Image = global::AgOpenGPS.Properties.Resources.ABBndLines;
            this.rbtnBoundary.Location = new System.Drawing.Point(15, 234);
            this.rbtnBoundary.Name = "rbtnBoundary";
            this.rbtnBoundary.Size = new System.Drawing.Size(80, 80);
            this.rbtnBoundary.TabIndex = 3;
            this.rbtnBoundary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnBoundary.UseVisualStyleBackColor = false;
            this.rbtnBoundary.CheckedChanged += new System.EventHandler(this.rbtnTrackMethod_CheckedChanged);
            // 
            // rbtnLine
            // 
            this.rbtnLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnLine.BackColor = System.Drawing.Color.AliceBlue;
            this.rbtnLine.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleTurquoise;
            this.rbtnLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnLine.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnLine.ForeColor = System.Drawing.Color.Black;
            this.rbtnLine.Image = global::AgOpenGPS.Properties.Resources.ABTrackAB;
            this.rbtnLine.Location = new System.Drawing.Point(15, 133);
            this.rbtnLine.Name = "rbtnLine";
            this.rbtnLine.Size = new System.Drawing.Size(80, 80);
            this.rbtnLine.TabIndex = 2;
            this.rbtnLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnLine.UseVisualStyleBackColor = false;
            this.rbtnLine.CheckedChanged += new System.EventHandler(this.rbtnTrackMethod_CheckedChanged);
            // 
            // rbtnCurve
            // 
            this.rbtnCurve.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnCurve.BackColor = System.Drawing.Color.AliceBlue;
            this.rbtnCurve.Checked = true;
            this.rbtnCurve.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleTurquoise;
            this.rbtnCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnCurve.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCurve.ForeColor = System.Drawing.Color.Black;
            this.rbtnCurve.Image = global::AgOpenGPS.Properties.Resources.ABTrackCurve;
            this.rbtnCurve.Location = new System.Drawing.Point(15, 32);
            this.rbtnCurve.Name = "rbtnCurve";
            this.rbtnCurve.Size = new System.Drawing.Size(80, 80);
            this.rbtnCurve.TabIndex = 0;
            this.rbtnCurve.TabStop = true;
            this.rbtnCurve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnCurve.UseVisualStyleBackColor = false;
            this.rbtnCurve.CheckedChanged += new System.EventHandler(this.rbtnTrackMethod_CheckedChanged);
            // 
            // btnMakeInnerBoundaryCurve
            // 
            this.btnMakeInnerBoundaryCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnMakeInnerBoundaryCurve.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMakeInnerBoundaryCurve.FlatAppearance.BorderSize = 0;
            this.btnMakeInnerBoundaryCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeInnerBoundaryCurve.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeInnerBoundaryCurve.Image = global::AgOpenGPS.Properties.Resources.BoundaryCurveLineInner;
            this.btnMakeInnerBoundaryCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeInnerBoundaryCurve.Location = new System.Drawing.Point(821, 9);
            this.btnMakeInnerBoundaryCurve.Name = "btnMakeInnerBoundaryCurve";
            this.btnMakeInnerBoundaryCurve.Size = new System.Drawing.Size(90, 34);
            this.btnMakeInnerBoundaryCurve.TabIndex = 437;
            this.btnMakeInnerBoundaryCurve.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMakeInnerBoundaryCurve.UseVisualStyleBackColor = false;
            this.btnMakeInnerBoundaryCurve.Click += new System.EventHandler(this.btnMakeInnerBoundaryCurve_Click);
            // 
            // btnMakeOuterBoundaryCurve
            // 
            this.btnMakeOuterBoundaryCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnMakeOuterBoundaryCurve.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMakeOuterBoundaryCurve.FlatAppearance.BorderSize = 0;
            this.btnMakeOuterBoundaryCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeOuterBoundaryCurve.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeOuterBoundaryCurve.Image = global::AgOpenGPS.Properties.Resources.BoundaryCurveLine;
            this.btnMakeOuterBoundaryCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeOuterBoundaryCurve.Location = new System.Drawing.Point(736, 12);
            this.btnMakeOuterBoundaryCurve.Name = "btnMakeOuterBoundaryCurve";
            this.btnMakeOuterBoundaryCurve.Size = new System.Drawing.Size(73, 39);
            this.btnMakeOuterBoundaryCurve.TabIndex = 436;
            this.btnMakeOuterBoundaryCurve.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMakeOuterBoundaryCurve.UseVisualStyleBackColor = false;
            this.btnMakeOuterBoundaryCurve.Click += new System.EventHandler(this.btnMakeOuterBoundaryCurve_Click);
            // 
            // btnALength
            // 
            this.btnALength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnALength.BackColor = System.Drawing.Color.Linen;
            this.btnALength.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnALength.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnALength.FlatAppearance.BorderSize = 2;
            this.btnALength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnALength.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnALength.Image = global::AgOpenGPS.Properties.Resources.DrawLineExtendA;
            this.btnALength.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnALength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnALength.Location = new System.Drawing.Point(718, 332);
            this.btnALength.Name = "btnALength";
            this.btnALength.Size = new System.Drawing.Size(67, 91);
            this.btnALength.TabIndex = 352;
            this.btnALength.UseVisualStyleBackColor = false;
            this.btnALength.Click += new System.EventHandler(this.btnALength_Click);
            // 
            // btnBLength
            // 
            this.btnBLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBLength.BackColor = System.Drawing.Color.Azure;
            this.btnBLength.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBLength.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnBLength.FlatAppearance.BorderSize = 2;
            this.btnBLength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBLength.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnBLength.Image = global::AgOpenGPS.Properties.Resources.DrawLineExtendB;
            this.btnBLength.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBLength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBLength.Location = new System.Drawing.Point(718, 235);
            this.btnBLength.Name = "btnBLength";
            this.btnBLength.Size = new System.Drawing.Size(67, 91);
            this.btnBLength.TabIndex = 351;
            this.btnBLength.UseVisualStyleBackColor = false;
            this.btnBLength.Click += new System.EventHandler(this.btnBLength_Click);
            // 
            // btnDrawSections
            // 
            this.btnDrawSections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrawSections.BackColor = System.Drawing.Color.Transparent;
            this.btnDrawSections.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDrawSections.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnDrawSections.FlatAppearance.BorderSize = 0;
            this.btnDrawSections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawSections.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDrawSections.Image = global::AgOpenGPS.Properties.Resources.MappingOff;
            this.btnDrawSections.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDrawSections.Location = new System.Drawing.Point(821, 631);
            this.btnDrawSections.Name = "btnDrawSections";
            this.btnDrawSections.Size = new System.Drawing.Size(89, 63);
            this.btnDrawSections.TabIndex = 11;
            this.btnDrawSections.UseVisualStyleBackColor = false;
            this.btnDrawSections.Click += new System.EventHandler(this.btnDrawSections_Click);
            this.btnDrawSections.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnDrawSections_HelpRequested);
            // 
            // btnCancelTouch
            // 
            this.btnCancelTouch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelTouch.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelTouch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancelTouch.Enabled = false;
            this.btnCancelTouch.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelTouch.FlatAppearance.BorderSize = 0;
            this.btnCancelTouch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelTouch.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancelTouch.Image = global::AgOpenGPS.Properties.Resources.HeadlandDeletePoints;
            this.btnCancelTouch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelTouch.Location = new System.Drawing.Point(721, 102);
            this.btnCancelTouch.Name = "btnCancelTouch";
            this.btnCancelTouch.Size = new System.Drawing.Size(64, 63);
            this.btnCancelTouch.TabIndex = 1;
            this.btnCancelTouch.UseVisualStyleBackColor = false;
            this.btnCancelTouch.Click += new System.EventHandler(this.btnCancelTouch_Click);
            this.btnCancelTouch.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnCancelTouch_HelpRequested);
            // 
            // btnDeleteCurve
            // 
            this.btnDeleteCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnDeleteCurve.FlatAppearance.BorderSize = 0;
            this.btnDeleteCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDeleteCurve.Image = global::AgOpenGPS.Properties.Resources.Trash;
            this.btnDeleteCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteCurve.Location = new System.Drawing.Point(715, 628);
            this.btnDeleteCurve.Name = "btnDeleteCurve";
            this.btnDeleteCurve.Size = new System.Drawing.Size(70, 68);
            this.btnDeleteCurve.TabIndex = 6;
            this.btnDeleteCurve.UseVisualStyleBackColor = false;
            this.btnDeleteCurve.Click += new System.EventHandler(this.btnDeleteCurve_Click);
            this.btnDeleteCurve.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnDeleteCurve_HelpRequested);
            // 
            // btnVisible
            // 
            this.btnVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisible.BackColor = System.Drawing.Color.Transparent;
            this.btnVisible.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVisible.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisible.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnVisible.Image = global::AgOpenGPS.Properties.Resources.TrackVisible;
            this.btnVisible.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVisible.Location = new System.Drawing.Point(736, 470);
            this.btnVisible.Name = "btnVisible";
            this.btnVisible.Size = new System.Drawing.Size(70, 68);
            this.btnVisible.TabIndex = 5;
            this.btnVisible.UseVisualStyleBackColor = false;
            this.btnVisible.Click += new System.EventHandler(this.btnVisible_Click);
            this.btnVisible.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnSelectCurve_HelpRequested);
            // 
            // btnSelectCurve
            // 
            this.btnSelectCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSelectCurve.FlatAppearance.BorderSize = 0;
            this.btnSelectCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSelectCurve.Image = global::AgOpenGPS.Properties.Resources.ABLineCycle;
            this.btnSelectCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectCurve.Location = new System.Drawing.Point(895, 459);
            this.btnSelectCurve.Name = "btnSelectCurve";
            this.btnSelectCurve.Size = new System.Drawing.Size(70, 68);
            this.btnSelectCurve.TabIndex = 5;
            this.btnSelectCurve.UseVisualStyleBackColor = false;
            this.btnSelectCurve.Click += new System.EventHandler(this.btnSelectCurve_Click);
            this.btnSelectCurve.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnSelectCurve_HelpRequested);
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
            this.btnExit.Location = new System.Drawing.Point(873, 626);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(123, 70);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnExit_HelpRequested);
            // 
            // FormABDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1004, 709);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.headingGroupBox);
            this.Controls.Add(this.btnMakeInnerBoundaryCurve);
            this.Controls.Add(this.btnMakeOuterBoundaryCurve);
            this.Controls.Add(this.btnALength);
            this.Controls.Add(this.btnBLength);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tboxNameCurve);
            this.Controls.Add(this.btnDrawSections);
            this.Controls.Add(this.btnCancelTouch);
            this.Controls.Add(this.lblCurveSelected);
            this.Controls.Add(this.lblNumCu);
            this.Controls.Add(this.btnDeleteCurve);
            this.Controls.Add(this.btnVisible);
            this.Controls.Add(this.btnSelectCurve);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.oglSelf);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormABDraw";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Click 2 points on the Boundary to Begin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormABDraw_FormClosing);
            this.Load += new System.EventHandler(this.FormABDraw_Load);
            this.headingGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl oglSelf;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSelectCurve;
        private System.Windows.Forms.Button btnDeleteCurve;
        private System.Windows.Forms.Label lblNumCu;
        private System.Windows.Forms.Label lblCurveSelected;
        private System.Windows.Forms.Button btnCancelTouch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDrawSections;
        private System.Windows.Forms.TextBox tboxNameCurve;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBLength;
        private System.Windows.Forms.Button btnALength;
        private System.Windows.Forms.Button btnMakeInnerBoundaryCurve;
        private System.Windows.Forms.Button btnMakeOuterBoundaryCurve;
        private System.Windows.Forms.GroupBox headingGroupBox;
        private System.Windows.Forms.RadioButton rbtnLine;
        private System.Windows.Forms.RadioButton rbtnCurve;
        private System.Windows.Forms.RadioButton rbtnBoundary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVisible;
    }
}