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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMakeABLine = new System.Windows.Forms.Button();
            this.btnMakeCurve = new System.Windows.Forms.Button();
            this.btnSelectCurve = new System.Windows.Forms.Button();
            this.btnSelectABLine = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteCurve = new System.Windows.Forms.Button();
            this.btnDeleteABLine = new System.Windows.Forms.Button();
            this.lblNumCu = new System.Windows.Forms.Label();
            this.lblNumAB = new System.Windows.Forms.Label();
            this.lblABSelected = new System.Windows.Forms.Label();
            this.lblCurveSelected = new System.Windows.Forms.Label();
            this.btnCancelTouch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblABLineName = new System.Windows.Forms.Label();
            this.lblCurveName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudDistance = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDrawSections = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistance)).BeginInit();
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
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExit.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnExit.Location = new System.Drawing.Point(875, 637);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(123, 70);
            this.btnExit.TabIndex = 234;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMakeABLine
            // 
            this.btnMakeABLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeABLine.BackColor = System.Drawing.Color.Lavender;
            this.btnMakeABLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMakeABLine.Enabled = false;
            this.btnMakeABLine.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnMakeABLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeABLine.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMakeABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineOn;
            this.btnMakeABLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeABLine.Location = new System.Drawing.Point(826, 128);
            this.btnMakeABLine.Name = "btnMakeABLine";
            this.btnMakeABLine.Size = new System.Drawing.Size(80, 80);
            this.btnMakeABLine.TabIndex = 311;
            this.btnMakeABLine.UseVisualStyleBackColor = false;
            this.btnMakeABLine.Click += new System.EventHandler(this.BtnMakeABLine_Click);
            // 
            // btnMakeCurve
            // 
            this.btnMakeCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeCurve.BackColor = System.Drawing.Color.Lavender;
            this.btnMakeCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMakeCurve.Enabled = false;
            this.btnMakeCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnMakeCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMakeCurve.Image = global::AgOpenGPS.Properties.Resources.CurveOn;
            this.btnMakeCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeCurve.Location = new System.Drawing.Point(716, 128);
            this.btnMakeCurve.Name = "btnMakeCurve";
            this.btnMakeCurve.Size = new System.Drawing.Size(80, 80);
            this.btnMakeCurve.TabIndex = 313;
            this.btnMakeCurve.UseVisualStyleBackColor = false;
            this.btnMakeCurve.Click += new System.EventHandler(this.BtnMakeCurve_Click);
            // 
            // btnSelectCurve
            // 
            this.btnSelectCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectCurve.BackColor = System.Drawing.Color.Lavender;
            this.btnSelectCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSelectCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSelectCurve.Image = global::AgOpenGPS.Properties.Resources.CurveOn;
            this.btnSelectCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectCurve.Location = new System.Drawing.Point(737, 319);
            this.btnSelectCurve.Name = "btnSelectCurve";
            this.btnSelectCurve.Size = new System.Drawing.Size(82, 85);
            this.btnSelectCurve.TabIndex = 321;
            this.btnSelectCurve.UseVisualStyleBackColor = false;
            this.btnSelectCurve.Click += new System.EventHandler(this.btnSelectCurve_Click);
            // 
            // btnSelectABLine
            // 
            this.btnSelectABLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectABLine.BackColor = System.Drawing.Color.Lavender;
            this.btnSelectABLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectABLine.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSelectABLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectABLine.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSelectABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineOn;
            this.btnSelectABLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectABLine.Location = new System.Drawing.Point(737, 498);
            this.btnSelectABLine.Name = "btnSelectABLine";
            this.btnSelectABLine.Size = new System.Drawing.Size(82, 85);
            this.btnSelectABLine.TabIndex = 322;
            this.btnSelectABLine.UseVisualStyleBackColor = false;
            this.btnSelectABLine.Click += new System.EventHandler(this.btnSelectABLine_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Location = new System.Drawing.Point(712, 231);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 5);
            this.panel1.TabIndex = 323;
            // 
            // btnDeleteCurve
            // 
            this.btnDeleteCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCurve.BackColor = System.Drawing.Color.Lavender;
            this.btnDeleteCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnDeleteCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDeleteCurve.Image = global::AgOpenGPS.Properties.Resources.FileDelete;
            this.btnDeleteCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteCurve.Location = new System.Drawing.Point(910, 319);
            this.btnDeleteCurve.Name = "btnDeleteCurve";
            this.btnDeleteCurve.Size = new System.Drawing.Size(88, 78);
            this.btnDeleteCurve.TabIndex = 325;
            this.btnDeleteCurve.UseVisualStyleBackColor = false;
            this.btnDeleteCurve.Click += new System.EventHandler(this.btnDeleteCurve_Click);
            // 
            // btnDeleteABLine
            // 
            this.btnDeleteABLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteABLine.BackColor = System.Drawing.Color.Lavender;
            this.btnDeleteABLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteABLine.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnDeleteABLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteABLine.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDeleteABLine.Image = global::AgOpenGPS.Properties.Resources.FileDelete;
            this.btnDeleteABLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteABLine.Location = new System.Drawing.Point(910, 498);
            this.btnDeleteABLine.Name = "btnDeleteABLine";
            this.btnDeleteABLine.Size = new System.Drawing.Size(88, 78);
            this.btnDeleteABLine.TabIndex = 326;
            this.btnDeleteABLine.UseVisualStyleBackColor = false;
            this.btnDeleteABLine.Click += new System.EventHandler(this.btnDeleteABLine_Click);
            // 
            // lblNumCu
            // 
            this.lblNumCu.Enabled = false;
            this.lblNumCu.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumCu.Location = new System.Drawing.Point(801, 288);
            this.lblNumCu.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumCu.Name = "lblNumCu";
            this.lblNumCu.Size = new System.Drawing.Size(35, 26);
            this.lblNumCu.TabIndex = 327;
            this.lblNumCu.Text = "1";
            this.lblNumCu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNumAB
            // 
            this.lblNumAB.Enabled = false;
            this.lblNumAB.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumAB.Location = new System.Drawing.Point(800, 468);
            this.lblNumAB.Margin = new System.Windows.Forms.Padding(0);
            this.lblNumAB.Name = "lblNumAB";
            this.lblNumAB.Size = new System.Drawing.Size(35, 26);
            this.lblNumAB.TabIndex = 328;
            this.lblNumAB.Text = "2";
            this.lblNumAB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblABSelected
            // 
            this.lblABSelected.Enabled = false;
            this.lblABSelected.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblABSelected.Location = new System.Drawing.Point(721, 468);
            this.lblABSelected.Margin = new System.Windows.Forms.Padding(0);
            this.lblABSelected.Name = "lblABSelected";
            this.lblABSelected.Size = new System.Drawing.Size(35, 26);
            this.lblABSelected.TabIndex = 330;
            this.lblABSelected.Text = "1";
            this.lblABSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurveSelected
            // 
            this.lblCurveSelected.Enabled = false;
            this.lblCurveSelected.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurveSelected.Location = new System.Drawing.Point(722, 289);
            this.lblCurveSelected.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurveSelected.Name = "lblCurveSelected";
            this.lblCurveSelected.Size = new System.Drawing.Size(35, 26);
            this.lblCurveSelected.TabIndex = 329;
            this.lblCurveSelected.Text = "1";
            this.lblCurveSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancelTouch
            // 
            this.btnCancelTouch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelTouch.BackColor = System.Drawing.Color.Lavender;
            this.btnCancelTouch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancelTouch.Enabled = false;
            this.btnCancelTouch.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelTouch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelTouch.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancelTouch.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancelTouch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelTouch.Location = new System.Drawing.Point(936, 137);
            this.btnCancelTouch.Name = "btnCancelTouch";
            this.btnCancelTouch.Size = new System.Drawing.Size(64, 63);
            this.btnCancelTouch.TabIndex = 331;
            this.btnCancelTouch.UseVisualStyleBackColor = false;
            this.btnCancelTouch.Click += new System.EventHandler(this.btnCancelTouch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(764, 290);
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
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(762, 470);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 23);
            this.label2.TabIndex = 333;
            this.label2.Text = "of";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblABLineName
            // 
            this.lblABLineName.Enabled = false;
            this.lblABLineName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblABLineName.Location = new System.Drawing.Point(722, 589);
            this.lblABLineName.Margin = new System.Windows.Forms.Padding(0);
            this.lblABLineName.Name = "lblABLineName";
            this.lblABLineName.Size = new System.Drawing.Size(284, 26);
            this.lblABLineName.TabIndex = 334;
            this.lblABLineName.Text = "Name";
            this.lblABLineName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurveName
            // 
            this.lblCurveName.Enabled = false;
            this.lblCurveName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurveName.Location = new System.Drawing.Point(722, 408);
            this.lblCurveName.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurveName.Name = "lblCurveName";
            this.lblCurveName.Size = new System.Drawing.Size(284, 26);
            this.lblCurveName.TabIndex = 335;
            this.lblCurveName.Text = "Name";
            this.lblCurveName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(718, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 25);
            this.label3.TabIndex = 336;
            this.label3.Text = "gsCreate";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(726, 245);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(266, 26);
            this.label4.TabIndex = 337;
            this.label4.Text = "gsSelect";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudDistance
            // 
            this.nudDistance.BackColor = System.Drawing.Color.AliceBlue;
            this.nudDistance.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDistance.Location = new System.Drawing.Point(860, 35);
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
            this.nudDistance.Size = new System.Drawing.Size(132, 52);
            this.nudDistance.TabIndex = 338;
            this.nudDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDistance.Enter += new System.EventHandler(this.nudDistance_Enter);
            // 
            // label5
            // 
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(707, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 57);
            this.label5.TabIndex = 339;
            this.label5.Text = "Tool Width (cm)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDrawSections
            // 
            this.btnDrawSections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrawSections.BackColor = System.Drawing.Color.Lavender;
            this.btnDrawSections.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDrawSections.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnDrawSections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawSections.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDrawSections.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDrawSections.Location = new System.Drawing.Point(732, 642);
            this.btnDrawSections.Name = "btnDrawSections";
            this.btnDrawSections.Size = new System.Drawing.Size(89, 63);
            this.btnDrawSections.TabIndex = 340;
            this.btnDrawSections.Text = "Off";
            this.btnDrawSections.UseVisualStyleBackColor = false;
            this.btnDrawSections.Click += new System.EventHandler(this.btnDrawSections_Click);
            // 
            // label6
            // 
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(922, 90);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 25);
            this.label6.TabIndex = 341;
            this.label6.Text = "2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormABDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1004, 709);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDrawSections);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudDistance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCurveName);
            this.Controls.Add(this.lblABLineName);
            this.Controls.Add(this.btnCancelTouch);
            this.Controls.Add(this.lblABSelected);
            this.Controls.Add(this.lblCurveSelected);
            this.Controls.Add(this.lblNumAB);
            this.Controls.Add(this.lblNumCu);
            this.Controls.Add(this.btnDeleteABLine);
            this.Controls.Add(this.btnDeleteCurve);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSelectABLine);
            this.Controls.Add(this.btnSelectCurve);
            this.Controls.Add(this.btnMakeCurve);
            this.Controls.Add(this.btnMakeABLine);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.oglSelf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormABDraw";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Click 2 points on the Boundary to Begin";
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteCurve;
        private System.Windows.Forms.Button btnDeleteABLine;
        private System.Windows.Forms.Label lblNumCu;
        private System.Windows.Forms.Label lblNumAB;
        private System.Windows.Forms.Label lblABSelected;
        private System.Windows.Forms.Label lblCurveSelected;
        private System.Windows.Forms.Button btnCancelTouch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblABLineName;
        private System.Windows.Forms.Label lblCurveName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudDistance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDrawSections;
        private System.Windows.Forms.Label label6;
    }
}