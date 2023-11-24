namespace AgOpenGPS
{
    partial class FormHeadLine
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
            this.headingGroupBox = new System.Windows.Forms.GroupBox();
            this.rbtnLine = new System.Windows.Forms.RadioButton();
            this.rbtnCurve = new System.Windows.Forms.RadioButton();
            this.btnALength = new System.Windows.Forms.Button();
            this.btnBLength = new System.Windows.Forms.Button();
            this.btnDeleteCurve = new System.Windows.Forms.Button();
            this.btnCycleForward = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSetLineDistance = new System.Windows.Forms.Button();
            this.nudSetDistance = new System.Windows.Forms.NumericUpDown();
            this.btnDeleteHeadland = new System.Windows.Forms.Button();
            this.cboxIsSectionControlled = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnBndLoop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCycleBackward = new System.Windows.Forms.Button();
            this.lblMovedDistance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeletePoints = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.headingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetDistance)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // oglSelf
            // 
            this.oglSelf.BackColor = System.Drawing.Color.Black;
            this.oglSelf.Cursor = System.Windows.Forms.Cursors.Cross;
            this.oglSelf.Location = new System.Drawing.Point(5, 53);
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
            // lblNumCu
            // 
            this.lblNumCu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumCu.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumCu.ForeColor = System.Drawing.Color.Black;
            this.lblNumCu.Location = new System.Drawing.Point(792, 644);
            this.lblNumCu.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumCu.Name = "lblNumCu";
            this.lblNumCu.Size = new System.Drawing.Size(35, 26);
            this.lblNumCu.TabIndex = 327;
            this.lblNumCu.Text = "1";
            this.lblNumCu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurveSelected
            // 
            this.lblCurveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurveSelected.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurveSelected.ForeColor = System.Drawing.Color.Black;
            this.lblCurveSelected.Location = new System.Drawing.Point(713, 644);
            this.lblCurveSelected.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurveSelected.Name = "lblCurveSelected";
            this.lblCurveSelected.Size = new System.Drawing.Size(35, 26);
            this.lblCurveSelected.TabIndex = 329;
            this.lblCurveSelected.Text = "1";
            this.lblCurveSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(755, 646);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 23);
            this.label1.TabIndex = 332;
            this.label1.Text = "of";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tboxNameCurve
            // 
            this.tboxNameCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxNameCurve.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tboxNameCurve.CausesValidation = false;
            this.tboxNameCurve.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxNameCurve.Location = new System.Drawing.Point(727, 620);
            this.tboxNameCurve.Margin = new System.Windows.Forms.Padding(0);
            this.tboxNameCurve.MaxLength = 100;
            this.tboxNameCurve.Name = "tboxNameCurve";
            this.tboxNameCurve.Size = new System.Drawing.Size(286, 27);
            this.tboxNameCurve.TabIndex = 10;
            this.tboxNameCurve.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // headingGroupBox
            // 
            this.headingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.headingGroupBox.Controls.Add(this.rbtnLine);
            this.headingGroupBox.Controls.Add(this.rbtnCurve);
            this.headingGroupBox.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingGroupBox.ForeColor = System.Drawing.Color.Black;
            this.headingGroupBox.Location = new System.Drawing.Point(807, 12);
            this.headingGroupBox.Name = "headingGroupBox";
            this.headingGroupBox.Size = new System.Drawing.Size(206, 125);
            this.headingGroupBox.TabIndex = 438;
            this.headingGroupBox.TabStop = false;
            this.headingGroupBox.Text = "Line Style";
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
            this.rbtnLine.Location = new System.Drawing.Point(115, 32);
            this.rbtnLine.Name = "rbtnLine";
            this.rbtnLine.Size = new System.Drawing.Size(80, 80);
            this.rbtnLine.TabIndex = 2;
            this.rbtnLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnLine.UseVisualStyleBackColor = false;
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
            this.btnALength.Location = new System.Drawing.Point(730, 130);
            this.btnALength.Name = "btnALength";
            this.btnALength.Size = new System.Drawing.Size(54, 83);
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
            this.btnBLength.Location = new System.Drawing.Point(730, 41);
            this.btnBLength.Name = "btnBLength";
            this.btnBLength.Size = new System.Drawing.Size(54, 83);
            this.btnBLength.TabIndex = 351;
            this.btnBLength.UseVisualStyleBackColor = false;
            this.btnBLength.Click += new System.EventHandler(this.btnBLength_Click);
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
            this.btnDeleteCurve.Location = new System.Drawing.Point(713, 681);
            this.btnDeleteCurve.Name = "btnDeleteCurve";
            this.btnDeleteCurve.Size = new System.Drawing.Size(70, 68);
            this.btnDeleteCurve.TabIndex = 6;
            this.btnDeleteCurve.UseVisualStyleBackColor = false;
            this.btnDeleteCurve.Click += new System.EventHandler(this.btnDeleteCurve_Click);
            // 
            // btnCycleForward
            // 
            this.btnCycleForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCycleForward.BackColor = System.Drawing.Color.Transparent;
            this.btnCycleForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCycleForward.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnCycleForward.FlatAppearance.BorderSize = 0;
            this.btnCycleForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCycleForward.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCycleForward.Image = global::AgOpenGPS.Properties.Resources.ABLineCycle;
            this.btnCycleForward.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCycleForward.Location = new System.Drawing.Point(119, 159);
            this.btnCycleForward.Name = "btnCycleForward";
            this.btnCycleForward.Size = new System.Drawing.Size(70, 68);
            this.btnCycleForward.TabIndex = 5;
            this.btnCycleForward.UseVisualStyleBackColor = false;
            this.btnCycleForward.Click += new System.EventHandler(this.btnCycleForward_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExit.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.Location = new System.Drawing.Point(928, 679);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 70);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSetLineDistance
            // 
            this.btnSetLineDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetLineDistance.BackColor = System.Drawing.Color.Transparent;
            this.btnSetLineDistance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSetLineDistance.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSetLineDistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetLineDistance.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSetLineDistance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSetLineDistance.Location = new System.Drawing.Point(17, 157);
            this.btnSetLineDistance.Name = "btnSetLineDistance";
            this.btnSetLineDistance.Size = new System.Drawing.Size(78, 70);
            this.btnSetLineDistance.TabIndex = 465;
            this.btnSetLineDistance.Text = "Move Line";
            this.btnSetLineDistance.UseVisualStyleBackColor = false;
            this.btnSetLineDistance.Click += new System.EventHandler(this.btnSetLineDistance_Click);
            // 
            // nudSetDistance
            // 
            this.nudSetDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSetDistance.BackColor = System.Drawing.Color.AliceBlue;
            this.nudSetDistance.DecimalPlaces = 1;
            this.nudSetDistance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSetDistance.Location = new System.Drawing.Point(40, 69);
            this.nudSetDistance.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudSetDistance.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.nudSetDistance.Name = "nudSetDistance";
            this.nudSetDistance.ReadOnly = true;
            this.nudSetDistance.Size = new System.Drawing.Size(150, 46);
            this.nudSetDistance.TabIndex = 464;
            this.nudSetDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSetDistance.Click += new System.EventHandler(this.nudSetDistance_Click);
            // 
            // btnDeleteHeadland
            // 
            this.btnDeleteHeadland.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteHeadland.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteHeadland.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDeleteHeadland.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDeleteHeadland.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteHeadland.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDeleteHeadland.Image = global::AgOpenGPS.Properties.Resources.BoundaryDelete;
            this.btnDeleteHeadland.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteHeadland.Location = new System.Drawing.Point(928, 244);
            this.btnDeleteHeadland.Name = "btnDeleteHeadland";
            this.btnDeleteHeadland.Size = new System.Drawing.Size(74, 61);
            this.btnDeleteHeadland.TabIndex = 465;
            this.btnDeleteHeadland.UseVisualStyleBackColor = false;
            this.btnDeleteHeadland.Click += new System.EventHandler(this.btnDeleteHeadland_Click);
            // 
            // cboxIsSectionControlled
            // 
            this.cboxIsSectionControlled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxIsSectionControlled.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsSectionControlled.BackColor = System.Drawing.Color.Transparent;
            this.cboxIsSectionControlled.Checked = true;
            this.cboxIsSectionControlled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxIsSectionControlled.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cboxIsSectionControlled.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.cboxIsSectionControlled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsSectionControlled.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsSectionControlled.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cboxIsSectionControlled.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;
            this.cboxIsSectionControlled.Location = new System.Drawing.Point(826, 682);
            this.cboxIsSectionControlled.Name = "cboxIsSectionControlled";
            this.cboxIsSectionControlled.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxIsSectionControlled.Size = new System.Drawing.Size(65, 65);
            this.cboxIsSectionControlled.TabIndex = 467;
            this.cboxIsSectionControlled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsSectionControlled.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(53, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 468;
            this.label11.Text = "Distance = ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBndLoop
            // 
            this.btnBndLoop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBndLoop.BackColor = System.Drawing.Color.Transparent;
            this.btnBndLoop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBndLoop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBndLoop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBndLoop.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnBndLoop.Image = global::AgOpenGPS.Properties.Resources.TramOuter;
            this.btnBndLoop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBndLoop.Location = new System.Drawing.Point(217, 56);
            this.btnBndLoop.Name = "btnBndLoop";
            this.btnBndLoop.Size = new System.Drawing.Size(76, 70);
            this.btnBndLoop.TabIndex = 504;
            this.btnBndLoop.UseVisualStyleBackColor = false;
            this.btnBndLoop.Click += new System.EventHandler(this.btnBndLoop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCycleBackward);
            this.groupBox1.Controls.Add(this.lblMovedDistance);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnBndLoop);
            this.groupBox1.Controls.Add(this.btnSetLineDistance);
            this.groupBox1.Controls.Add(this.nudSetDistance);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnCycleForward);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(713, 338);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 261);
            this.groupBox1.TabIndex = 505;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Build and Modify";
            // 
            // btnCycleBackward
            // 
            this.btnCycleBackward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCycleBackward.BackColor = System.Drawing.Color.Transparent;
            this.btnCycleBackward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCycleBackward.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnCycleBackward.FlatAppearance.BorderSize = 0;
            this.btnCycleBackward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCycleBackward.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCycleBackward.Image = global::AgOpenGPS.Properties.Resources.ABLineCycleBk;
            this.btnCycleBackward.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCycleBackward.Location = new System.Drawing.Point(217, 159);
            this.btnCycleBackward.Name = "btnCycleBackward";
            this.btnCycleBackward.Size = new System.Drawing.Size(70, 68);
            this.btnCycleBackward.TabIndex = 507;
            this.btnCycleBackward.UseVisualStyleBackColor = false;
            this.btnCycleBackward.Click += new System.EventHandler(this.btnCycleBackward_Click);
            // 
            // lblMovedDistance
            // 
            this.lblMovedDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMovedDistance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovedDistance.ForeColor = System.Drawing.Color.Black;
            this.lblMovedDistance.Location = new System.Drawing.Point(127, 46);
            this.lblMovedDistance.Name = "lblMovedDistance";
            this.lblMovedDistance.Size = new System.Drawing.Size(56, 16);
            this.lblMovedDistance.TabIndex = 506;
            this.lblMovedDistance.Text = "m";
            this.lblMovedDistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 16);
            this.label3.TabIndex = 505;
            this.label3.Text = "m";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDeletePoints
            // 
            this.btnDeletePoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeletePoints.BackColor = System.Drawing.Color.Transparent;
            this.btnDeletePoints.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDeletePoints.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDeletePoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePoints.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDeletePoints.Image = global::AgOpenGPS.Properties.Resources.HeadlandDeletePoints;
            this.btnDeletePoints.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeletePoints.Location = new System.Drawing.Point(820, 152);
            this.btnDeletePoints.Name = "btnDeletePoints";
            this.btnDeletePoints.Size = new System.Drawing.Size(73, 61);
            this.btnDeletePoints.TabIndex = 506;
            this.btnDeletePoints.UseVisualStyleBackColor = false;
            this.btnDeletePoints.Click += new System.EventHandler(this.btnDeletePoints_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(176, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 25);
            this.label2.TabIndex = 507;
            this.label2.Text = "* Build in Clockwise Order *";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormHeadLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1021, 761);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeletePoints);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDeleteHeadland);
            this.Controls.Add(this.cboxIsSectionControlled);
            this.Controls.Add(this.headingGroupBox);
            this.Controls.Add(this.btnALength);
            this.Controls.Add(this.btnBLength);
            this.Controls.Add(this.tboxNameCurve);
            this.Controls.Add(this.lblCurveSelected);
            this.Controls.Add(this.lblNumCu);
            this.Controls.Add(this.btnDeleteCurve);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.oglSelf);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHeadLine";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Click 2 points on the Boundary to Begin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHeadLine_FormClosing);
            this.Load += new System.EventHandler(this.FormHeadLine_Load);
            this.headingGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSetDistance)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl oglSelf;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCycleForward;
        private System.Windows.Forms.Button btnDeleteCurve;
        private System.Windows.Forms.Label lblNumCu;
        private System.Windows.Forms.Label lblCurveSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxNameCurve;
        private System.Windows.Forms.Button btnBLength;
        private System.Windows.Forms.Button btnALength;
        private System.Windows.Forms.GroupBox headingGroupBox;
        private System.Windows.Forms.RadioButton rbtnLine;
        private System.Windows.Forms.RadioButton rbtnCurve;
        private System.Windows.Forms.Button btnSetLineDistance;
        private System.Windows.Forms.NumericUpDown nudSetDistance;
        private System.Windows.Forms.Button btnDeleteHeadland;
        private System.Windows.Forms.CheckBox cboxIsSectionControlled;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnBndLoop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeletePoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMovedDistance;
        private System.Windows.Forms.Button btnCycleBackward;
    }
}