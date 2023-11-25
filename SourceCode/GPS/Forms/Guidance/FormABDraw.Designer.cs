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
            this.lblNumAB = new System.Windows.Forms.Label();
            this.lblABSelected = new System.Windows.Forms.Label();
            this.lblCurveSelected = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDistance = new System.Windows.Forms.NumericUpDown();
            this.tboxNameCurve = new System.Windows.Forms.TextBox();
            this.tboxNameLine = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFlipOffset = new System.Windows.Forms.Button();
            this.btnBLength = new System.Windows.Forms.Button();
            this.btnALength = new System.Windows.Forms.Button();
            this.btnMakeBoundaryCurve = new System.Windows.Forms.Button();
            this.btnDrawSections = new System.Windows.Forms.Button();
            this.btnCancelTouch = new System.Windows.Forms.Button();
            this.btnDeleteABLine = new System.Windows.Forms.Button();
            this.btnDeleteCurve = new System.Windows.Forms.Button();
            this.btnSelectABLine = new System.Windows.Forms.Button();
            this.btnSelectCurve = new System.Windows.Forms.Button();
            this.btnMakeCurve = new System.Windows.Forms.Button();
            this.btnMakeABLine = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCmInch = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistance)).BeginInit();
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
            this.lblNumCu.Location = new System.Drawing.Point(963, 325);
            this.lblNumCu.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumCu.Name = "lblNumCu";
            this.lblNumCu.Size = new System.Drawing.Size(35, 26);
            this.lblNumCu.TabIndex = 327;
            this.lblNumCu.Text = "1";
            this.lblNumCu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNumAB
            // 
            this.lblNumAB.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumAB.ForeColor = System.Drawing.Color.Black;
            this.lblNumAB.Location = new System.Drawing.Point(964, 478);
            this.lblNumAB.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumAB.Name = "lblNumAB";
            this.lblNumAB.Size = new System.Drawing.Size(35, 26);
            this.lblNumAB.TabIndex = 328;
            this.lblNumAB.Text = "2";
            this.lblNumAB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblABSelected
            // 
            this.lblABSelected.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblABSelected.ForeColor = System.Drawing.Color.Black;
            this.lblABSelected.Location = new System.Drawing.Point(885, 478);
            this.lblABSelected.Margin = new System.Windows.Forms.Padding(0);
            this.lblABSelected.Name = "lblABSelected";
            this.lblABSelected.Size = new System.Drawing.Size(35, 26);
            this.lblABSelected.TabIndex = 330;
            this.lblABSelected.Text = "1";
            this.lblABSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurveSelected
            // 
            this.lblCurveSelected.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurveSelected.ForeColor = System.Drawing.Color.Black;
            this.lblCurveSelected.Location = new System.Drawing.Point(884, 326);
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
            this.label1.Location = new System.Drawing.Point(926, 327);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 23);
            this.label1.TabIndex = 332;
            this.label1.Text = "of";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(926, 480);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 23);
            this.label2.TabIndex = 333;
            this.label2.Text = "of";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudDistance
            // 
            this.nudDistance.BackColor = System.Drawing.Color.AliceBlue;
            this.nudDistance.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDistance.Location = new System.Drawing.Point(857, 34);
            this.nudDistance.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudDistance.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.nudDistance.Name = "nudDistance";
            this.nudDistance.ReadOnly = true;
            this.nudDistance.Size = new System.Drawing.Size(132, 52);
            this.nudDistance.TabIndex = 16;
            this.nudDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDistance.Click += new System.EventHandler(this.nudDistance_Click);
            this.nudDistance.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.nudDistance_HelpRequested);
            // 
            // tboxNameCurve
            // 
            this.tboxNameCurve.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tboxNameCurve.CausesValidation = false;
            this.tboxNameCurve.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxNameCurve.Location = new System.Drawing.Point(712, 433);
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
            // tboxNameLine
            // 
            this.tboxNameLine.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tboxNameLine.CausesValidation = false;
            this.tboxNameLine.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxNameLine.Location = new System.Drawing.Point(712, 577);
            this.tboxNameLine.Margin = new System.Windows.Forms.Padding(0);
            this.tboxNameLine.MaxLength = 100;
            this.tboxNameLine.Name = "tboxNameLine";
            this.tboxNameLine.Size = new System.Drawing.Size(283, 27);
            this.tboxNameLine.TabIndex = 9;
            this.tboxNameLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxNameLine.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.tboxNameLine_HelpRequested);
            this.tboxNameLine.Enter += new System.EventHandler(this.tboxNameLine_Enter);
            this.tboxNameLine.Leave += new System.EventHandler(this.tboxNameLine_Leave);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(739, 159);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 35);
            this.label4.TabIndex = 12;
            this.label4.Text = "Boundary Curve";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(728, 338);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 348;
            this.label3.Text = "Curve";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(728, 488);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 20);
            this.label7.TabIndex = 349;
            this.label7.Text = "Line";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(807, 614);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Mapping";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFlipOffset
            // 
            this.btnFlipOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFlipOffset.BackColor = System.Drawing.Color.Transparent;
            this.btnFlipOffset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFlipOffset.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFlipOffset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlipOffset.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFlipOffset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFlipOffset.Location = new System.Drawing.Point(723, 40);
            this.btnFlipOffset.Name = "btnFlipOffset";
            this.btnFlipOffset.Size = new System.Drawing.Size(128, 43);
            this.btnFlipOffset.TabIndex = 14;
            this.btnFlipOffset.Text = "In";
            this.btnFlipOffset.UseVisualStyleBackColor = false;
            this.btnFlipOffset.Click += new System.EventHandler(this.btnFlipOffset_Click);
            this.btnFlipOffset.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnFlipOffset_HelpRequested);
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
            this.btnBLength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBLength.Location = new System.Drawing.Point(870, 237);
            this.btnBLength.Name = "btnBLength";
            this.btnBLength.Size = new System.Drawing.Size(92, 53);
            this.btnBLength.TabIndex = 351;
            this.btnBLength.UseVisualStyleBackColor = false;
            this.btnBLength.Click += new System.EventHandler(this.btnBLength_Click);
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
            this.btnALength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnALength.Location = new System.Drawing.Point(751, 237);
            this.btnALength.Name = "btnALength";
            this.btnALength.Size = new System.Drawing.Size(92, 53);
            this.btnALength.TabIndex = 352;
            this.btnALength.UseVisualStyleBackColor = false;
            this.btnALength.Click += new System.EventHandler(this.btnALength_Click);
            // 
            // btnMakeBoundaryCurve
            // 
            this.btnMakeBoundaryCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeBoundaryCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnMakeBoundaryCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMakeBoundaryCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnMakeBoundaryCurve.FlatAppearance.BorderSize = 0;
            this.btnMakeBoundaryCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeBoundaryCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMakeBoundaryCurve.Image = global::AgOpenGPS.Properties.Resources.BoundaryCurveLine;
            this.btnMakeBoundaryCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeBoundaryCurve.Location = new System.Drawing.Point(894, 140);
            this.btnMakeBoundaryCurve.Name = "btnMakeBoundaryCurve";
            this.btnMakeBoundaryCurve.Size = new System.Drawing.Size(80, 71);
            this.btnMakeBoundaryCurve.TabIndex = 4;
            this.btnMakeBoundaryCurve.UseVisualStyleBackColor = false;
            this.btnMakeBoundaryCurve.Click += new System.EventHandler(this.btnMakeBoundaryCurve_Click);
            this.btnMakeBoundaryCurve.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnMakeBoundaryCurve_HelpRequested);
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
            this.btnDrawSections.Location = new System.Drawing.Point(813, 637);
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
            this.btnCancelTouch.Location = new System.Drawing.Point(722, 634);
            this.btnCancelTouch.Name = "btnCancelTouch";
            this.btnCancelTouch.Size = new System.Drawing.Size(64, 63);
            this.btnCancelTouch.TabIndex = 1;
            this.btnCancelTouch.UseVisualStyleBackColor = false;
            this.btnCancelTouch.Click += new System.EventHandler(this.btnCancelTouch_Click);
            this.btnCancelTouch.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnCancelTouch_HelpRequested);
            // 
            // btnDeleteABLine
            // 
            this.btnDeleteABLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteABLine.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteABLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteABLine.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnDeleteABLine.FlatAppearance.BorderSize = 0;
            this.btnDeleteABLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteABLine.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDeleteABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineDelete;
            this.btnDeleteABLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteABLine.Location = new System.Drawing.Point(934, 506);
            this.btnDeleteABLine.Name = "btnDeleteABLine";
            this.btnDeleteABLine.Size = new System.Drawing.Size(70, 68);
            this.btnDeleteABLine.TabIndex = 7;
            this.btnDeleteABLine.UseVisualStyleBackColor = false;
            this.btnDeleteABLine.Click += new System.EventHandler(this.btnDeleteABLine_Click);
            this.btnDeleteABLine.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnDeleteABLine_HelpRequested);
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
            this.btnDeleteCurve.Image = global::AgOpenGPS.Properties.Resources.HideContour;
            this.btnDeleteCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteCurve.Location = new System.Drawing.Point(934, 356);
            this.btnDeleteCurve.Name = "btnDeleteCurve";
            this.btnDeleteCurve.Size = new System.Drawing.Size(70, 68);
            this.btnDeleteCurve.TabIndex = 6;
            this.btnDeleteCurve.UseVisualStyleBackColor = false;
            this.btnDeleteCurve.Click += new System.EventHandler(this.btnDeleteCurve_Click);
            this.btnDeleteCurve.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnDeleteCurve_HelpRequested);
            // 
            // btnSelectABLine
            // 
            this.btnSelectABLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectABLine.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectABLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectABLine.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSelectABLine.FlatAppearance.BorderSize = 0;
            this.btnSelectABLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectABLine.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSelectABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineCycle;
            this.btnSelectABLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectABLine.Location = new System.Drawing.Point(826, 505);
            this.btnSelectABLine.Name = "btnSelectABLine";
            this.btnSelectABLine.Size = new System.Drawing.Size(70, 68);
            this.btnSelectABLine.TabIndex = 8;
            this.btnSelectABLine.UseVisualStyleBackColor = false;
            this.btnSelectABLine.Click += new System.EventHandler(this.btnSelectABLine_Click);
            this.btnSelectABLine.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnSelectABLine_HelpRequested);
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
            this.btnSelectCurve.Location = new System.Drawing.Point(826, 356);
            this.btnSelectCurve.Name = "btnSelectCurve";
            this.btnSelectCurve.Size = new System.Drawing.Size(70, 68);
            this.btnSelectCurve.TabIndex = 5;
            this.btnSelectCurve.UseVisualStyleBackColor = false;
            this.btnSelectCurve.Click += new System.EventHandler(this.btnSelectCurve_Click);
            this.btnSelectCurve.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnSelectCurve_HelpRequested);
            // 
            // btnMakeCurve
            // 
            this.btnMakeCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnMakeCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMakeCurve.Enabled = false;
            this.btnMakeCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnMakeCurve.FlatAppearance.BorderSize = 0;
            this.btnMakeCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMakeCurve.Image = global::AgOpenGPS.Properties.Resources.CurveOn;
            this.btnMakeCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeCurve.Location = new System.Drawing.Point(716, 356);
            this.btnMakeCurve.Name = "btnMakeCurve";
            this.btnMakeCurve.Size = new System.Drawing.Size(70, 68);
            this.btnMakeCurve.TabIndex = 2;
            this.btnMakeCurve.UseVisualStyleBackColor = false;
            this.btnMakeCurve.Click += new System.EventHandler(this.BtnMakeCurve_Click);
            this.btnMakeCurve.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnMakeCurve_HelpRequested);
            // 
            // btnMakeABLine
            // 
            this.btnMakeABLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeABLine.BackColor = System.Drawing.Color.Transparent;
            this.btnMakeABLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMakeABLine.Enabled = false;
            this.btnMakeABLine.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnMakeABLine.FlatAppearance.BorderSize = 0;
            this.btnMakeABLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeABLine.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMakeABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineOn;
            this.btnMakeABLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeABLine.Location = new System.Drawing.Point(716, 506);
            this.btnMakeABLine.Name = "btnMakeABLine";
            this.btnMakeABLine.Size = new System.Drawing.Size(70, 68);
            this.btnMakeABLine.TabIndex = 3;
            this.btnMakeABLine.UseVisualStyleBackColor = false;
            this.btnMakeABLine.Click += new System.EventHandler(this.BtnMakeABLine_Click);
            this.btnMakeABLine.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnMakeABLine_HelpRequested);
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
            this.btnExit.Location = new System.Drawing.Point(875, 637);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(123, 70);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnExit_HelpRequested);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(866, 89);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 27);
            this.label5.TabIndex = 353;
            this.label5.Text = "Offset";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCmInch
            // 
            this.lblCmInch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCmInch.ForeColor = System.Drawing.Color.Black;
            this.lblCmInch.Location = new System.Drawing.Point(936, 7);
            this.lblCmInch.Margin = new System.Windows.Forms.Padding(0);
            this.lblCmInch.Name = "lblCmInch";
            this.lblCmInch.Size = new System.Drawing.Size(44, 24);
            this.lblCmInch.TabIndex = 350;
            this.lblCmInch.Text = "cm";
            this.lblCmInch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(875, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 24);
            this.label6.TabIndex = 341;
            this.label6.Text = "2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(728, 11);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 20);
            this.label9.TabIndex = 354;
            this.label9.Text = "Inside/Outside";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormABDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1004, 709);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnALength);
            this.Controls.Add(this.btnBLength);
            this.Controls.Add(this.btnFlipOffset);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tboxNameLine);
            this.Controls.Add(this.tboxNameCurve);
            this.Controls.Add(this.btnMakeBoundaryCurve);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDrawSections);
            this.Controls.Add(this.nudDistance);
            this.Controls.Add(this.btnCancelTouch);
            this.Controls.Add(this.lblABSelected);
            this.Controls.Add(this.lblCurveSelected);
            this.Controls.Add(this.lblNumAB);
            this.Controls.Add(this.lblNumCu);
            this.Controls.Add(this.btnDeleteABLine);
            this.Controls.Add(this.btnDeleteCurve);
            this.Controls.Add(this.btnSelectABLine);
            this.Controls.Add(this.btnSelectCurve);
            this.Controls.Add(this.btnMakeCurve);
            this.Controls.Add(this.btnMakeABLine);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.oglSelf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCmInch);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl oglSelf;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMakeABLine;
        private System.Windows.Forms.Button btnMakeCurve;
        private System.Windows.Forms.Button btnSelectCurve;
        private System.Windows.Forms.Button btnSelectABLine;
        private System.Windows.Forms.Button btnDeleteCurve;
        private System.Windows.Forms.Button btnDeleteABLine;
        private System.Windows.Forms.Label lblNumCu;
        private System.Windows.Forms.Label lblNumAB;
        private System.Windows.Forms.Label lblABSelected;
        private System.Windows.Forms.Label lblCurveSelected;
        private System.Windows.Forms.Button btnCancelTouch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDistance;
        private System.Windows.Forms.Button btnDrawSections;
        private System.Windows.Forms.Button btnMakeBoundaryCurve;
        private System.Windows.Forms.TextBox tboxNameCurve;
        private System.Windows.Forms.TextBox tboxNameLine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnFlipOffset;
        private System.Windows.Forms.Button btnBLength;
        private System.Windows.Forms.Button btnALength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCmInch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
    }
}