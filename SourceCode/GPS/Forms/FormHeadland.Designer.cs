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
            this.btnDeletePoints = new System.Windows.Forms.Button();
            this.btnMakeFixedHeadland = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.nudSetDistance = new System.Windows.Forms.NumericUpDown();
            this.btnSetDistance = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnTurnOffHeadland = new System.Windows.Forms.Button();
            this.cboxToolWidths = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHeadlandWidth = new System.Windows.Forms.Label();
            this.lblWidthUnits = new System.Windows.Forms.Label();
            this.cboxIsSectionControlled = new System.Windows.Forms.CheckBox();
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
            this.nudDistance.Location = new System.Drawing.Point(751, 180);
            this.nudDistance.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudDistance.Name = "nudDistance";
            this.nudDistance.ReadOnly = true;
            this.nudDistance.Size = new System.Drawing.Size(148, 52);
            this.nudDistance.TabIndex = 338;
            this.nudDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDistance.Click += new System.EventHandler(this.nudDistance_Click);
            // 
            // btnDeletePoints
            // 
            this.btnDeletePoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeletePoints.BackColor = System.Drawing.Color.Transparent;
            this.btnDeletePoints.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDeletePoints.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnDeletePoints.FlatAppearance.BorderSize = 0;
            this.btnDeletePoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePoints.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDeletePoints.Image = global::AgOpenGPS.Properties.Resources.HeadlandDeletePoints;
            this.btnDeletePoints.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeletePoints.Location = new System.Drawing.Point(734, 421);
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
            this.btnMakeFixedHeadland.FlatAppearance.BorderSize = 0;
            this.btnMakeFixedHeadland.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeFixedHeadland.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMakeFixedHeadland.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnMakeFixedHeadland.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeFixedHeadland.Location = new System.Drawing.Point(925, 176);
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
            this.btnExit.FlatAppearance.BorderSize = 0;
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
            // nudSetDistance
            // 
            this.nudSetDistance.BackColor = System.Drawing.Color.AliceBlue;
            this.nudSetDistance.DecimalPlaces = 1;
            this.nudSetDistance.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSetDistance.Location = new System.Drawing.Point(751, 300);
            this.nudSetDistance.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudSetDistance.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.nudSetDistance.Name = "nudSetDistance";
            this.nudSetDistance.ReadOnly = true;
            this.nudSetDistance.Size = new System.Drawing.Size(148, 52);
            this.nudSetDistance.TabIndex = 457;
            this.nudSetDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSetDistance.Click += new System.EventHandler(this.nudSetDistance_Click);
            // 
            // btnSetDistance
            // 
            this.btnSetDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetDistance.BackColor = System.Drawing.Color.Transparent;
            this.btnSetDistance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSetDistance.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSetDistance.FlatAppearance.BorderSize = 0;
            this.btnSetDistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetDistance.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSetDistance.Image = global::AgOpenGPS.Properties.Resources.HeadlandTouchSave;
            this.btnSetDistance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSetDistance.Location = new System.Drawing.Point(925, 296);
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
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Image = global::AgOpenGPS.Properties.Resources.back_button;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReset.Location = new System.Drawing.Point(734, 523);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(204, 75);
            this.btnReset.TabIndex = 459;
            this.btnReset.Text = "Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnTurnOffHeadland
            // 
            this.btnTurnOffHeadland.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTurnOffHeadland.BackColor = System.Drawing.Color.Transparent;
            this.btnTurnOffHeadland.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTurnOffHeadland.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnTurnOffHeadland.FlatAppearance.BorderSize = 0;
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
            // cboxToolWidths
            // 
            this.cboxToolWidths.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            "10",
            "11",
            "12",
            "13",
            "14"});
            this.cboxToolWidths.Location = new System.Drawing.Point(751, 46);
            this.cboxToolWidths.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxToolWidths.Name = "cboxToolWidths";
            this.cboxToolWidths.Size = new System.Drawing.Size(88, 53);
            this.cboxToolWidths.TabIndex = 461;
            this.cboxToolWidths.SelectedIndexChanged += new System.EventHandler(this.cboxToolWidths_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(708, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 42);
            this.label1.TabIndex = 462;
            this.label1.Text = "#";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(708, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 42);
            this.label2.TabIndex = 463;
            this.label2.Text = "+";
            // 
            // lblHeadlandWidth
            // 
            this.lblHeadlandWidth.AutoSize = true;
            this.lblHeadlandWidth.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadlandWidth.ForeColor = System.Drawing.Color.White;
            this.lblHeadlandWidth.Location = new System.Drawing.Point(856, 46);
            this.lblHeadlandWidth.Name = "lblHeadlandWidth";
            this.lblHeadlandWidth.Size = new System.Drawing.Size(87, 39);
            this.lblHeadlandWidth.TabIndex = 464;
            this.lblHeadlandWidth.Text = "23.8";
            // 
            // lblWidthUnits
            // 
            this.lblWidthUnits.AutoSize = true;
            this.lblWidthUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidthUnits.ForeColor = System.Drawing.Color.White;
            this.lblWidthUnits.Location = new System.Drawing.Point(885, 88);
            this.lblWidthUnits.Name = "lblWidthUnits";
            this.lblWidthUnits.Size = new System.Drawing.Size(27, 24);
            this.lblWidthUnits.TabIndex = 465;
            this.lblWidthUnits.Text = "m";
            // 
            // cboxIsSectionControlled
            // 
            this.cboxIsSectionControlled.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsSectionControlled.BackColor = System.Drawing.Color.Transparent;
            this.cboxIsSectionControlled.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.cboxIsSectionControlled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsSectionControlled.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsSectionControlled.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cboxIsSectionControlled.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOff;
            this.cboxIsSectionControlled.Location = new System.Drawing.Point(875, 412);
            this.cboxIsSectionControlled.Name = "cboxIsSectionControlled";
            this.cboxIsSectionControlled.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxIsSectionControlled.Size = new System.Drawing.Size(86, 81);
            this.cboxIsSectionControlled.TabIndex = 466;
            this.cboxIsSectionControlled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsSectionControlled.UseVisualStyleBackColor = false;
            // 
            // FormHeadland
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1004, 709);
            this.ControlBox = false;
            this.Controls.Add(this.cboxIsSectionControlled);
            this.Controls.Add(this.lblWidthUnits);
            this.Controls.Add(this.lblHeadlandWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxToolWidths);
            this.Controls.Add(this.btnTurnOffHeadland);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSetDistance);
            this.Controls.Add(this.nudSetDistance);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Click 2 points on the Boundary to Begin";
            this.Load += new System.EventHandler(this.FormHeadland_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl oglSelf;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NumericUpDown nudDistance;
        private System.Windows.Forms.Button btnMakeFixedHeadland;
        private System.Windows.Forms.Button btnDeletePoints;
        private System.Windows.Forms.NumericUpDown nudSetDistance;
        private System.Windows.Forms.Button btnSetDistance;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnTurnOffHeadland;
        private System.Windows.Forms.ComboBox cboxToolWidths;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHeadlandWidth;
        private System.Windows.Forms.Label lblWidthUnits;
        private System.Windows.Forms.CheckBox cboxIsSectionControlled;
    }
}