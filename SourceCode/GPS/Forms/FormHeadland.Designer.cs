namespace AgOpenGPS
{
    partial class FormHeadland
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
            this.nudDistance = new System.Windows.Forms.NumericUpDown();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.btnDeletePoints = new System.Windows.Forms.Button();
            this.btnMakeFixedHeadland = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStartUp = new ProXoft.WinForms.RepeatButton();
            this.btnStartDown = new ProXoft.WinForms.RepeatButton();
            this.nudSetDistance = new System.Windows.Forms.NumericUpDown();
            this.btnSetDistance = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnTurnOffHeadland = new System.Windows.Forms.Button();
            this.btnEndUp = new ProXoft.WinForms.RepeatButton();
            this.btnEndDown = new ProXoft.WinForms.RepeatButton();
            this.btnMoveRight = new ProXoft.WinForms.RepeatButton();
            this.btnMoveLeft = new ProXoft.WinForms.RepeatButton();
            this.btnMoveUp = new ProXoft.WinForms.RepeatButton();
            this.btnMoveDown = new ProXoft.WinForms.RepeatButton();
            this.btnDoneManualMove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // oglSelf
            // 
            this.oglSelf.BackColor = System.Drawing.Color.Black;
            this.oglSelf.Cursor = System.Windows.Forms.Cursors.Cross;
            this.oglSelf.Location = new System.Drawing.Point(5, 7);
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
            // nudDistance
            // 
            this.nudDistance.BackColor = System.Drawing.Color.AliceBlue;
            this.nudDistance.DecimalPlaces = 1;
            this.nudDistance.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDistance.Location = new System.Drawing.Point(737, 14);
            this.nudDistance.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            65536});
            this.nudDistance.Name = "nudDistance";
            this.nudDistance.Size = new System.Drawing.Size(148, 52);
            this.nudDistance.TabIndex = 338;
            this.nudDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDistance.Enter += new System.EventHandler(this.nudDistance_Enter);
            // 
            // lblStart
            // 
            this.lblStart.BackColor = System.Drawing.Color.LightSalmon;
            this.lblStart.Enabled = false;
            this.lblStart.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(710, 398);
            this.lblStart.Margin = new System.Windows.Forms.Padding(0);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(67, 23);
            this.lblStart.TabIndex = 329;
            this.lblStart.Text = "99999";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnd
            // 
            this.lblEnd.BackColor = System.Drawing.Color.Khaki;
            this.lblEnd.Enabled = false;
            this.lblEnd.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.Location = new System.Drawing.Point(710, 546);
            this.lblEnd.Margin = new System.Windows.Forms.Padding(0);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(67, 23);
            this.lblEnd.TabIndex = 340;
            this.lblEnd.Text = "99999";
            this.lblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDeletePoints
            // 
            this.btnDeletePoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeletePoints.BackColor = System.Drawing.Color.Transparent;
            this.btnDeletePoints.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDeletePoints.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnDeletePoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePoints.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDeletePoints.Image = global::AgOpenGPS.Properties.Resources.HeadlandDeletePoints;
            this.btnDeletePoints.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeletePoints.Location = new System.Drawing.Point(925, 252);
            this.btnDeletePoints.Name = "btnDeletePoints";
            this.btnDeletePoints.Size = new System.Drawing.Size(73, 61);
            this.btnDeletePoints.TabIndex = 452;
            this.btnDeletePoints.UseVisualStyleBackColor = false;
            this.btnDeletePoints.Click += new System.EventHandler(this.btnDeletePoints_Click);
            // 
            // btnMakeFixedHeadland
            // 
            this.btnMakeFixedHeadland.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeFixedHeadland.BackColor = System.Drawing.Color.Transparent;
            this.btnMakeFixedHeadland.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMakeFixedHeadland.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnMakeFixedHeadland.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeFixedHeadland.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMakeFixedHeadland.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnMakeFixedHeadland.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeFixedHeadland.Location = new System.Drawing.Point(925, 8);
            this.btnMakeFixedHeadland.Name = "btnMakeFixedHeadland";
            this.btnMakeFixedHeadland.Size = new System.Drawing.Size(73, 61);
            this.btnMakeFixedHeadland.TabIndex = 450;
            this.btnMakeFixedHeadland.UseVisualStyleBackColor = false;
            this.btnMakeFixedHeadland.Click += new System.EventHandler(this.btnMakeFixedHeadland_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExit.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnExit.Location = new System.Drawing.Point(875, 637);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(123, 70);
            this.btnExit.TabIndex = 234;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStartUp
            // 
            this.btnStartUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStartUp.FlatAppearance.BorderSize = 0;
            this.btnStartUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartUp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartUp.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnStartUp.Location = new System.Drawing.Point(714, 342);
            this.btnStartUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStartUp.Name = "btnStartUp";
            this.btnStartUp.Size = new System.Drawing.Size(63, 59);
            this.btnStartUp.TabIndex = 454;
            this.btnStartUp.UseVisualStyleBackColor = true;
            this.btnStartUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStartUp_MouseDown);
            // 
            // btnStartDown
            // 
            this.btnStartDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStartDown.FlatAppearance.BorderSize = 0;
            this.btnStartDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartDown.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartDown.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnStartDown.Location = new System.Drawing.Point(714, 418);
            this.btnStartDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStartDown.Name = "btnStartDown";
            this.btnStartDown.Size = new System.Drawing.Size(63, 59);
            this.btnStartDown.TabIndex = 453;
            this.btnStartDown.UseVisualStyleBackColor = true;
            this.btnStartDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStartDown_MouseDown);
            // 
            // nudSetDistance
            // 
            this.nudSetDistance.BackColor = System.Drawing.Color.AliceBlue;
            this.nudSetDistance.DecimalPlaces = 1;
            this.nudSetDistance.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSetDistance.Location = new System.Drawing.Point(737, 134);
            this.nudSetDistance.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            65536});
            this.nudSetDistance.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147418112});
            this.nudSetDistance.Name = "nudSetDistance";
            this.nudSetDistance.Size = new System.Drawing.Size(148, 52);
            this.nudSetDistance.TabIndex = 457;
            this.nudSetDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSetDistance.Enter += new System.EventHandler(this.nudSetDistance_Enter);
            // 
            // btnSetDistance
            // 
            this.btnSetDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetDistance.BackColor = System.Drawing.Color.Transparent;
            this.btnSetDistance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSetDistance.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSetDistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetDistance.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSetDistance.Image = global::AgOpenGPS.Properties.Resources.HeadlandTouchSave;
            this.btnSetDistance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSetDistance.Location = new System.Drawing.Point(925, 130);
            this.btnSetDistance.Name = "btnSetDistance";
            this.btnSetDistance.Size = new System.Drawing.Size(73, 61);
            this.btnSetDistance.TabIndex = 458;
            this.btnSetDistance.UseVisualStyleBackColor = false;
            this.btnSetDistance.Click += new System.EventHandler(this.btnSetDistance_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnReset.Image = global::AgOpenGPS.Properties.Resources.back_button;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReset.Location = new System.Drawing.Point(737, 253);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(140, 61);
            this.btnReset.TabIndex = 459;
            this.btnReset.Text = "Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnTurnOffHeadland
            // 
            this.btnTurnOffHeadland.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTurnOffHeadland.BackColor = System.Drawing.Color.Transparent;
            this.btnTurnOffHeadland.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTurnOffHeadland.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnTurnOffHeadland.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTurnOffHeadland.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnTurnOffHeadland.Image = global::AgOpenGPS.Properties.Resources.SwitchOff;
            this.btnTurnOffHeadland.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTurnOffHeadland.Location = new System.Drawing.Point(726, 637);
            this.btnTurnOffHeadland.Name = "btnTurnOffHeadland";
            this.btnTurnOffHeadland.Size = new System.Drawing.Size(88, 70);
            this.btnTurnOffHeadland.TabIndex = 460;
            this.btnTurnOffHeadland.UseVisualStyleBackColor = false;
            this.btnTurnOffHeadland.Click += new System.EventHandler(this.btnTurnOffHeadland_Click);
            // 
            // btnEndUp
            // 
            this.btnEndUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEndUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEndUp.FlatAppearance.BorderSize = 0;
            this.btnEndUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndUp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndUp.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnEndUp.Location = new System.Drawing.Point(714, 489);
            this.btnEndUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEndUp.Name = "btnEndUp";
            this.btnEndUp.Size = new System.Drawing.Size(63, 59);
            this.btnEndUp.TabIndex = 462;
            this.btnEndUp.UseVisualStyleBackColor = true;
            this.btnEndUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEndUp_MouseDown);
            // 
            // btnEndDown
            // 
            this.btnEndDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEndDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEndDown.FlatAppearance.BorderSize = 0;
            this.btnEndDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndDown.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndDown.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnEndDown.Location = new System.Drawing.Point(714, 567);
            this.btnEndDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEndDown.Name = "btnEndDown";
            this.btnEndDown.Size = new System.Drawing.Size(63, 59);
            this.btnEndDown.TabIndex = 461;
            this.btnEndDown.UseVisualStyleBackColor = true;
            this.btnEndDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEndDown_MouseDown);
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMoveRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMoveRight.FlatAppearance.BorderSize = 0;
            this.btnMoveRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveRight.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveRight.Image = global::AgOpenGPS.Properties.Resources.ArrowRight;
            this.btnMoveRight.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMoveRight.Location = new System.Drawing.Point(950, 395);
            this.btnMoveRight.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(48, 73);
            this.btnMoveRight.TabIndex = 465;
            this.btnMoveRight.UseVisualStyleBackColor = true;
            this.btnMoveRight.Click += new System.EventHandler(this.btnMoveRight_Click);
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMoveLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMoveLeft.FlatAppearance.BorderSize = 0;
            this.btnMoveLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveLeft.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveLeft.Image = global::AgOpenGPS.Properties.Resources.ArrowLeft;
            this.btnMoveLeft.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMoveLeft.Location = new System.Drawing.Point(829, 395);
            this.btnMoveLeft.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(48, 73);
            this.btnMoveLeft.TabIndex = 466;
            this.btnMoveLeft.UseVisualStyleBackColor = true;
            this.btnMoveLeft.Click += new System.EventHandler(this.btnMoveLeft_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMoveUp.FlatAppearance.BorderSize = 0;
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveUp.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnMoveUp.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMoveUp.Location = new System.Drawing.Point(889, 355);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(48, 73);
            this.btnMoveUp.TabIndex = 464;
            this.btnMoveUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click_1);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMoveDown.FlatAppearance.BorderSize = 0;
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDown.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveDown.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnMoveDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMoveDown.Location = new System.Drawing.Point(889, 437);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(48, 73);
            this.btnMoveDown.TabIndex = 463;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnDoneManualMove
            // 
            this.btnDoneManualMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoneManualMove.BackColor = System.Drawing.Color.Transparent;
            this.btnDoneManualMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDoneManualMove.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnDoneManualMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoneManualMove.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDoneManualMove.Image = global::AgOpenGPS.Properties.Resources.HeadlandTouchSave;
            this.btnDoneManualMove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDoneManualMove.Location = new System.Drawing.Point(875, 528);
            this.btnDoneManualMove.Name = "btnDoneManualMove";
            this.btnDoneManualMove.Size = new System.Drawing.Size(73, 61);
            this.btnDoneManualMove.TabIndex = 467;
            this.btnDoneManualMove.UseVisualStyleBackColor = false;
            this.btnDoneManualMove.Click += new System.EventHandler(this.btnDoneManualMove_Click);
            // 
            // FormHeadland
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1004, 709);
            this.ControlBox = false;
            this.Controls.Add(this.btnDoneManualMove);
            this.Controls.Add(this.btnMoveRight);
            this.Controls.Add(this.btnMoveLeft);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.btnEndUp);
            this.Controls.Add(this.btnEndDown);
            this.Controls.Add(this.btnTurnOffHeadland);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSetDistance);
            this.Controls.Add(this.nudSetDistance);
            this.Controls.Add(this.btnStartUp);
            this.Controls.Add(this.btnStartDown);
            this.Controls.Add(this.btnDeletePoints);
            this.Controls.Add(this.btnMakeFixedHeadland);
            this.Controls.Add(this.nudDistance);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.oglSelf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHeadland";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Click 2 points on the Boundary to Begin";
            this.Load += new System.EventHandler(this.FormHeadland_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetDistance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl oglSelf;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NumericUpDown nudDistance;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Button btnMakeFixedHeadland;
        private System.Windows.Forms.Button btnDeletePoints;
        private ProXoft.WinForms.RepeatButton btnStartUp;
        private ProXoft.WinForms.RepeatButton btnStartDown;
        private System.Windows.Forms.NumericUpDown nudSetDistance;
        private System.Windows.Forms.Button btnSetDistance;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnTurnOffHeadland;
        private ProXoft.WinForms.RepeatButton btnEndUp;
        private ProXoft.WinForms.RepeatButton btnEndDown;
        private ProXoft.WinForms.RepeatButton btnMoveRight;
        private ProXoft.WinForms.RepeatButton btnMoveLeft;
        private ProXoft.WinForms.RepeatButton btnMoveUp;
        private ProXoft.WinForms.RepeatButton btnMoveDown;
        private System.Windows.Forms.Button btnDoneManualMove;
    }
}