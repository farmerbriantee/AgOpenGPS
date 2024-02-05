namespace AgOpenGPS
{
    partial class FormHeadAche
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
            this.headingGroupBox = new System.Windows.Forms.GroupBox();
            this.rbtnLine = new System.Windows.Forms.RadioButton();
            this.rbtnCurve = new System.Windows.Forms.RadioButton();
            this.nudSetDistance = new AgOpenGPS.NudlessNumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.lblMovedDistance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxToolWidths = new System.Windows.Forms.ComboBox();
            this.lblToolWidth = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pboxHelp = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAShrink = new System.Windows.Forms.Button();
            this.btnBShrink = new System.Windows.Forms.Button();
            this.btnHeadlandOff = new System.Windows.Forms.Button();
            this.btnCycleBackward = new System.Windows.Forms.Button();
            this.btnBndLoop = new System.Windows.Forms.Button();
            this.btnDeleteHeadland = new System.Windows.Forms.Button();
            this.cboxIsSectionControlled = new System.Windows.Forms.CheckBox();
            this.btnCycleForward = new System.Windows.Forms.Button();
            this.btnALength = new System.Windows.Forms.Button();
            this.btnBLength = new System.Windows.Forms.Button();
            this.btnDeleteCurve = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboxIsZoom = new System.Windows.Forms.CheckBox();
            this.headingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxHelp)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // oglSelf
            // 
            this.oglSelf.BackColor = System.Drawing.Color.Black;
            this.oglSelf.Cursor = System.Windows.Forms.Cursors.Cross;
            this.oglSelf.Location = new System.Drawing.Point(5, 11);
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
            this.lblNumCu.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumCu.ForeColor = System.Drawing.Color.Black;
            this.lblNumCu.Location = new System.Drawing.Point(933, 594);
            this.lblNumCu.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumCu.Name = "lblNumCu";
            this.lblNumCu.Size = new System.Drawing.Size(53, 26);
            this.lblNumCu.TabIndex = 327;
            this.lblNumCu.Text = "1";
            this.lblNumCu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurveSelected
            // 
            this.lblCurveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurveSelected.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurveSelected.ForeColor = System.Drawing.Color.Black;
            this.lblCurveSelected.Location = new System.Drawing.Point(807, 594);
            this.lblCurveSelected.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurveSelected.Name = "lblCurveSelected";
            this.lblCurveSelected.Size = new System.Drawing.Size(70, 26);
            this.lblCurveSelected.TabIndex = 329;
            this.lblCurveSelected.Text = "1";
            this.lblCurveSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(887, 594);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 29);
            this.label1.TabIndex = 332;
            this.label1.Text = "of";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headingGroupBox
            // 
            this.headingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.headingGroupBox.Controls.Add(this.rbtnLine);
            this.headingGroupBox.Controls.Add(this.rbtnCurve);
            this.headingGroupBox.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingGroupBox.ForeColor = System.Drawing.Color.Black;
            this.headingGroupBox.Location = new System.Drawing.Point(909, 4);
            this.headingGroupBox.Name = "headingGroupBox";
            this.headingGroupBox.Size = new System.Drawing.Size(97, 217);
            this.headingGroupBox.TabIndex = 438;
            this.headingGroupBox.TabStop = false;
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
            this.rbtnLine.Location = new System.Drawing.Point(11, 23);
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
            this.rbtnCurve.Location = new System.Drawing.Point(11, 122);
            this.rbtnCurve.Name = "rbtnCurve";
            this.rbtnCurve.Size = new System.Drawing.Size(80, 80);
            this.rbtnCurve.TabIndex = 0;
            this.rbtnCurve.TabStop = true;
            this.rbtnCurve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnCurve.UseVisualStyleBackColor = false;
            // 
            // nudSetDistance
            // 
            this.nudSetDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSetDistance.BackColor = System.Drawing.Color.AliceBlue;
            this.nudSetDistance.DecimalPlaces = 1;
            this.nudSetDistance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSetDistance.Location = new System.Drawing.Point(725, 422);
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
            this.nudSetDistance.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudSetDistance.Click += new System.EventHandler(this.nudSetDistance_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(719, 392);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 23);
            this.label11.TabIndex = 468;
            this.label11.Text = "Distance = ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMovedDistance
            // 
            this.lblMovedDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMovedDistance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovedDistance.ForeColor = System.Drawing.Color.Black;
            this.lblMovedDistance.Location = new System.Drawing.Point(816, 391);
            this.lblMovedDistance.Name = "lblMovedDistance";
            this.lblMovedDistance.Size = new System.Drawing.Size(56, 26);
            this.lblMovedDistance.TabIndex = 506;
            this.lblMovedDistance.Text = "0";
            this.lblMovedDistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(880, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 19);
            this.label3.TabIndex = 505;
            this.label3.Text = "ft";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(842, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 508;
            this.label4.Text = "Build";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxToolWidths
            // 
            this.cboxToolWidths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxToolWidths.BackColor = System.Drawing.Color.Lavender;
            this.cboxToolWidths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxToolWidths.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxToolWidths.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxToolWidths.FormattingEnabled = true;
            this.cboxToolWidths.Items.AddRange(new object[] {
            "0",
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
            this.cboxToolWidths.Location = new System.Drawing.Point(916, 418);
            this.cboxToolWidths.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxToolWidths.Name = "cboxToolWidths";
            this.cboxToolWidths.Size = new System.Drawing.Size(83, 53);
            this.cboxToolWidths.TabIndex = 510;
            this.cboxToolWidths.SelectedIndexChanged += new System.EventHandler(this.cboxToolWidths_SelectedIndexChanged);
            // 
            // lblToolWidth
            // 
            this.lblToolWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToolWidth.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolWidth.ForeColor = System.Drawing.Color.Black;
            this.lblToolWidth.Location = new System.Drawing.Point(918, 388);
            this.lblToolWidth.Name = "lblToolWidth";
            this.lblToolWidth.Size = new System.Drawing.Size(81, 26);
            this.lblToolWidth.TabIndex = 511;
            this.lblToolWidth.Text = "3.86";
            this.lblToolWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(945, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 523;
            this.label5.Text = "Reset";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(719, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 526;
            this.label2.Text = "Extend";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(823, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 527;
            this.label6.Text = "Shrink";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pboxHelp
            // 
            this.pboxHelp.BackgroundImage = global::AgOpenGPS.Properties.Resources.HeadacheHelp;
            this.pboxHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pboxHelp.Location = new System.Drawing.Point(36, 580);
            this.pboxHelp.Name = "pboxHelp";
            this.pboxHelp.Size = new System.Drawing.Size(130, 113);
            this.pboxHelp.TabIndex = 521;
            this.pboxHelp.TabStop = false;
            this.pboxHelp.Visible = false;
            this.pboxHelp.Click += new System.EventHandler(this.pboxHelp_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.button1.Image = global::AgOpenGPS.Properties.Resources.Help;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(721, 586);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 46);
            this.button1.TabIndex = 528;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.bntHelp_Click);
            // 
            // btnAShrink
            // 
            this.btnAShrink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAShrink.BackColor = System.Drawing.Color.Transparent;
            this.btnAShrink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAShrink.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnAShrink.FlatAppearance.BorderSize = 0;
            this.btnAShrink.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAShrink.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAShrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAShrink.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnAShrink.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAShrink.Location = new System.Drawing.Point(121, 110);
            this.btnAShrink.Name = "btnAShrink";
            this.btnAShrink.Size = new System.Drawing.Size(53, 64);
            this.btnAShrink.TabIndex = 525;
            this.btnAShrink.UseVisualStyleBackColor = false;
            this.btnAShrink.Click += new System.EventHandler(this.btnAShrink_Click);
            // 
            // btnBShrink
            // 
            this.btnBShrink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBShrink.BackColor = System.Drawing.Color.Transparent;
            this.btnBShrink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBShrink.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnBShrink.FlatAppearance.BorderSize = 0;
            this.btnBShrink.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBShrink.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBShrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBShrink.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnBShrink.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBShrink.Location = new System.Drawing.Point(121, 6);
            this.btnBShrink.Name = "btnBShrink";
            this.btnBShrink.Size = new System.Drawing.Size(53, 64);
            this.btnBShrink.TabIndex = 524;
            this.btnBShrink.UseVisualStyleBackColor = false;
            this.btnBShrink.Click += new System.EventHandler(this.btnBShrink_Click);
            // 
            // btnHeadlandOff
            // 
            this.btnHeadlandOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHeadlandOff.BackColor = System.Drawing.Color.Transparent;
            this.btnHeadlandOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHeadlandOff.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnHeadlandOff.FlatAppearance.BorderSize = 0;
            this.btnHeadlandOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeadlandOff.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnHeadlandOff.Image = global::AgOpenGPS.Properties.Resources.SwitchOff;
            this.btnHeadlandOff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHeadlandOff.Location = new System.Drawing.Point(823, 646);
            this.btnHeadlandOff.Name = "btnHeadlandOff";
            this.btnHeadlandOff.Size = new System.Drawing.Size(69, 70);
            this.btnHeadlandOff.TabIndex = 519;
            this.btnHeadlandOff.UseVisualStyleBackColor = false;
            this.btnHeadlandOff.Click += new System.EventHandler(this.btnHeadlandOff_Click);
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
            this.btnCycleBackward.Location = new System.Drawing.Point(919, 515);
            this.btnCycleBackward.Name = "btnCycleBackward";
            this.btnCycleBackward.Size = new System.Drawing.Size(70, 68);
            this.btnCycleBackward.TabIndex = 507;
            this.btnCycleBackward.UseVisualStyleBackColor = false;
            this.btnCycleBackward.Click += new System.EventHandler(this.btnCycleBackward_Click);
            // 
            // btnBndLoop
            // 
            this.btnBndLoop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBndLoop.BackColor = System.Drawing.Color.Transparent;
            this.btnBndLoop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBndLoop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBndLoop.FlatAppearance.BorderSize = 0;
            this.btnBndLoop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBndLoop.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnBndLoop.Image = global::AgOpenGPS.Properties.Resources.HeadlandBuild;
            this.btnBndLoop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBndLoop.Location = new System.Drawing.Point(818, 269);
            this.btnBndLoop.Name = "btnBndLoop";
            this.btnBndLoop.Size = new System.Drawing.Size(76, 70);
            this.btnBndLoop.TabIndex = 504;
            this.btnBndLoop.UseVisualStyleBackColor = false;
            this.btnBndLoop.Click += new System.EventHandler(this.btnBndLoop_Click);
            // 
            // btnDeleteHeadland
            // 
            this.btnDeleteHeadland.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteHeadland.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteHeadland.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDeleteHeadland.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDeleteHeadland.FlatAppearance.BorderSize = 0;
            this.btnDeleteHeadland.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteHeadland.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDeleteHeadland.Image = global::AgOpenGPS.Properties.Resources.HeadlandReset;
            this.btnDeleteHeadland.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteHeadland.Location = new System.Drawing.Point(923, 269);
            this.btnDeleteHeadland.Name = "btnDeleteHeadland";
            this.btnDeleteHeadland.Size = new System.Drawing.Size(76, 70);
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
            this.cboxIsSectionControlled.FlatAppearance.BorderSize = 0;
            this.cboxIsSectionControlled.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.cboxIsSectionControlled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsSectionControlled.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsSectionControlled.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cboxIsSectionControlled.Image = global::AgOpenGPS.Properties.Resources.HeadlandSectionOff;
            this.cboxIsSectionControlled.Location = new System.Drawing.Point(717, 646);
            this.cboxIsSectionControlled.Name = "cboxIsSectionControlled";
            this.cboxIsSectionControlled.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxIsSectionControlled.Size = new System.Drawing.Size(65, 65);
            this.cboxIsSectionControlled.TabIndex = 467;
            this.cboxIsSectionControlled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsSectionControlled.UseVisualStyleBackColor = false;
            this.cboxIsSectionControlled.Click += new System.EventHandler(this.cboxIsSectionControlled_Click);
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
            this.btnCycleForward.Location = new System.Drawing.Point(821, 515);
            this.btnCycleForward.Name = "btnCycleForward";
            this.btnCycleForward.Size = new System.Drawing.Size(70, 68);
            this.btnCycleForward.TabIndex = 5;
            this.btnCycleForward.UseVisualStyleBackColor = false;
            this.btnCycleForward.Click += new System.EventHandler(this.btnCycleForward_Click);
            // 
            // btnALength
            // 
            this.btnALength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnALength.BackColor = System.Drawing.Color.Transparent;
            this.btnALength.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnALength.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnALength.FlatAppearance.BorderSize = 0;
            this.btnALength.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnALength.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnALength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnALength.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnALength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnALength.Location = new System.Drawing.Point(6, 110);
            this.btnALength.Name = "btnALength";
            this.btnALength.Size = new System.Drawing.Size(53, 64);
            this.btnALength.TabIndex = 352;
            this.btnALength.UseVisualStyleBackColor = false;
            this.btnALength.Click += new System.EventHandler(this.btnALength_Click);
            // 
            // btnBLength
            // 
            this.btnBLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBLength.BackColor = System.Drawing.Color.Transparent;
            this.btnBLength.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBLength.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnBLength.FlatAppearance.BorderSize = 0;
            this.btnBLength.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBLength.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBLength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBLength.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnBLength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBLength.Location = new System.Drawing.Point(6, 7);
            this.btnBLength.Name = "btnBLength";
            this.btnBLength.Size = new System.Drawing.Size(53, 64);
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
            this.btnDeleteCurve.Location = new System.Drawing.Point(706, 515);
            this.btnDeleteCurve.Name = "btnDeleteCurve";
            this.btnDeleteCurve.Size = new System.Drawing.Size(70, 68);
            this.btnDeleteCurve.TabIndex = 6;
            this.btnDeleteCurve.UseVisualStyleBackColor = false;
            this.btnDeleteCurve.Click += new System.EventHandler(this.btnDeleteCurve_Click);
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
            this.btnExit.Location = new System.Drawing.Point(919, 643);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 70);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::AgOpenGPS.Properties.Resources.ABShrinkGrow;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.btnALength);
            this.panel1.Controls.Add(this.btnAShrink);
            this.panel1.Controls.Add(this.btnBShrink);
            this.panel1.Controls.Add(this.btnBLength);
            this.panel1.Location = new System.Drawing.Point(716, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 180);
            this.panel1.TabIndex = 533;
            // 
            // cboxIsZoom
            // 
            this.cboxIsZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxIsZoom.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsZoom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboxIsZoom.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxIsZoom.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(160)))));
            this.cboxIsZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsZoom.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsZoom.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cboxIsZoom.Image = global::AgOpenGPS.Properties.Resources.ZoomOGL;
            this.cboxIsZoom.Location = new System.Drawing.Point(717, 269);
            this.cboxIsZoom.Name = "cboxIsZoom";
            this.cboxIsZoom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxIsZoom.Size = new System.Drawing.Size(72, 72);
            this.cboxIsZoom.TabIndex = 564;
            this.cboxIsZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsZoom.UseVisualStyleBackColor = false;
            this.cboxIsZoom.CheckedChanged += new System.EventHandler(this.cboxIsZoom_CheckedChanged);
            // 
            // FormHeadAche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1010, 720);
            this.Controls.Add(this.cboxIsZoom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pboxHelp);
            this.Controls.Add(this.oglSelf);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnHeadlandOff);
            this.Controls.Add(this.lblToolWidth);
            this.Controls.Add(this.cboxToolWidths);
            this.Controls.Add(this.lblMovedDistance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCycleBackward);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBndLoop);
            this.Controls.Add(this.btnDeleteHeadland);
            this.Controls.Add(this.cboxIsSectionControlled);
            this.Controls.Add(this.nudSetDistance);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.headingGroupBox);
            this.Controls.Add(this.btnCycleForward);
            this.Controls.Add(this.lblCurveSelected);
            this.Controls.Add(this.lblNumCu);
            this.Controls.Add(this.btnDeleteCurve);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHeadAche";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Click 2 points on the Boundary to Begin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHeadLine_FormClosing);
            this.Load += new System.EventHandler(this.FormHeadLine_Load);
            this.headingGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSetDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxHelp)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnBLength;
        private System.Windows.Forms.Button btnALength;
        private System.Windows.Forms.GroupBox headingGroupBox;
        private System.Windows.Forms.RadioButton rbtnLine;
        private System.Windows.Forms.RadioButton rbtnCurve;
        private NudlessNumericUpDown nudSetDistance;
        private System.Windows.Forms.Button btnDeleteHeadland;
        private System.Windows.Forms.CheckBox cboxIsSectionControlled;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnBndLoop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMovedDistance;
        private System.Windows.Forms.Button btnCycleBackward;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboxToolWidths;
        private System.Windows.Forms.Label lblToolWidth;
        private System.Windows.Forms.Button btnHeadlandOff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAShrink;
        private System.Windows.Forms.Button btnBShrink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pboxHelp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cboxIsZoom;
    }
}