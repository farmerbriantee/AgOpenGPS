namespace AgOpenGPS
{
    partial class FormEditAB
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
            this.label1 = new System.Windows.Forms.Label();
            this.nudMinTurnRadius = new System.Windows.Forms.NumericUpDown();
            this.lblHalfSnapFtM = new System.Windows.Forms.Label();
            this.lblHalfWidth = new System.Windows.Forms.Label();
            this.btnNoSave = new System.Windows.Forms.Button();
            this.btnLeftHalfWidth = new System.Windows.Forms.Button();
            this.btnRightHalfWidth = new System.Windows.Forms.Button();
            this.btnContourPriority = new System.Windows.Forms.Button();
            this.btnSwapAB = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bntOK = new System.Windows.Forms.Button();
            this.btnAdjLeft = new System.Windows.Forms.Button();
            this.btnAdjRight = new System.Windows.Forms.Button();
            this.tboxHeading = new System.Windows.Forms.TextBox();
            this.cboxDegrees = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinTurnRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 19);
            this.label1.TabIndex = 414;
            this.label1.Text = "cm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudMinTurnRadius
            // 
            this.nudMinTurnRadius.BackColor = System.Drawing.Color.AliceBlue;
            this.nudMinTurnRadius.DecimalPlaces = 1;
            this.nudMinTurnRadius.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinTurnRadius.InterceptArrowKeys = false;
            this.nudMinTurnRadius.Location = new System.Drawing.Point(81, 104);
            this.nudMinTurnRadius.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudMinTurnRadius.Name = "nudMinTurnRadius";
            this.nudMinTurnRadius.ReadOnly = true;
            this.nudMinTurnRadius.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudMinTurnRadius.Size = new System.Drawing.Size(88, 33);
            this.nudMinTurnRadius.TabIndex = 411;
            this.nudMinTurnRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMinTurnRadius.Value = new decimal(new int[] {
            888,
            0,
            0,
            0});
            this.nudMinTurnRadius.ValueChanged += new System.EventHandler(this.nudMinTurnRadius_ValueChanged);
            this.nudMinTurnRadius.Enter += new System.EventHandler(this.nudMinTurnRadius_Enter);
            // 
            // lblHalfSnapFtM
            // 
            this.lblHalfSnapFtM.AutoSize = true;
            this.lblHalfSnapFtM.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalfSnapFtM.Location = new System.Drawing.Point(106, 6);
            this.lblHalfSnapFtM.Name = "lblHalfSnapFtM";
            this.lblHalfSnapFtM.Size = new System.Drawing.Size(38, 19);
            this.lblHalfSnapFtM.TabIndex = 452;
            this.lblHalfSnapFtM.Text = "(m)";
            this.lblHalfSnapFtM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHalfWidth
            // 
            this.lblHalfWidth.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalfWidth.Location = new System.Drawing.Point(86, 28);
            this.lblHalfWidth.Name = "lblHalfWidth";
            this.lblHalfWidth.Size = new System.Drawing.Size(81, 27);
            this.lblHalfWidth.TabIndex = 451;
            this.lblHalfWidth.Text = "3.88";
            this.lblHalfWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNoSave
            // 
            this.btnNoSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNoSave.FlatAppearance.BorderSize = 0;
            this.btnNoSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoSave.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoSave.Image = global::AgOpenGPS.Properties.Resources.FileDontSave;
            this.btnNoSave.Location = new System.Drawing.Point(93, 332);
            this.btnNoSave.Name = "btnNoSave";
            this.btnNoSave.Size = new System.Drawing.Size(63, 62);
            this.btnNoSave.TabIndex = 448;
            this.btnNoSave.UseVisualStyleBackColor = true;
            this.btnNoSave.Click += new System.EventHandler(this.btnNoSave_Click);
            // 
            // btnLeftHalfWidth
            // 
            this.btnLeftHalfWidth.BackColor = System.Drawing.Color.Transparent;
            this.btnLeftHalfWidth.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnLeftHalfWidth.FlatAppearance.BorderSize = 0;
            this.btnLeftHalfWidth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeftHalfWidth.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnLeftHalfWidth.Image = global::AgOpenGPS.Properties.Resources.SnapLeftHalf;
            this.btnLeftHalfWidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLeftHalfWidth.Location = new System.Drawing.Point(3, -5);
            this.btnLeftHalfWidth.Name = "btnLeftHalfWidth";
            this.btnLeftHalfWidth.Size = new System.Drawing.Size(76, 67);
            this.btnLeftHalfWidth.TabIndex = 8;
            this.btnLeftHalfWidth.UseVisualStyleBackColor = false;
            this.btnLeftHalfWidth.Click += new System.EventHandler(this.btnLeftHalfWidth_Click);
            // 
            // btnRightHalfWidth
            // 
            this.btnRightHalfWidth.BackColor = System.Drawing.Color.Transparent;
            this.btnRightHalfWidth.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnRightHalfWidth.FlatAppearance.BorderSize = 0;
            this.btnRightHalfWidth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRightHalfWidth.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnRightHalfWidth.Image = global::AgOpenGPS.Properties.Resources.SnapRightHalf;
            this.btnRightHalfWidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRightHalfWidth.Location = new System.Drawing.Point(172, -5);
            this.btnRightHalfWidth.Name = "btnRightHalfWidth";
            this.btnRightHalfWidth.Size = new System.Drawing.Size(76, 67);
            this.btnRightHalfWidth.TabIndex = 9;
            this.btnRightHalfWidth.UseVisualStyleBackColor = false;
            this.btnRightHalfWidth.Click += new System.EventHandler(this.btnRightHalfWidth_Click);
            // 
            // btnContourPriority
            // 
            this.btnContourPriority.BackColor = System.Drawing.Color.Transparent;
            this.btnContourPriority.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnContourPriority.FlatAppearance.BorderSize = 0;
            this.btnContourPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContourPriority.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnContourPriority.Image = global::AgOpenGPS.Properties.Resources.SnapToPivot;
            this.btnContourPriority.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnContourPriority.Location = new System.Drawing.Point(149, 171);
            this.btnContourPriority.Name = "btnContourPriority";
            this.btnContourPriority.Size = new System.Drawing.Size(76, 67);
            this.btnContourPriority.TabIndex = 3;
            this.btnContourPriority.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContourPriority.UseVisualStyleBackColor = false;
            this.btnContourPriority.Click += new System.EventHandler(this.btnContourPriority_Click);
            // 
            // btnSwapAB
            // 
            this.btnSwapAB.FlatAppearance.BorderSize = 0;
            this.btnSwapAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwapAB.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwapAB.Image = global::AgOpenGPS.Properties.Resources.ABSwapPoints;
            this.btnSwapAB.Location = new System.Drawing.Point(28, 171);
            this.btnSwapAB.Name = "btnSwapAB";
            this.btnSwapAB.Size = new System.Drawing.Size(76, 67);
            this.btnSwapAB.TabIndex = 5;
            this.btnSwapAB.UseVisualStyleBackColor = true;
            this.btnSwapAB.Click += new System.EventHandler(this.btnSwapAB_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.back_button;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(0, 332);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 62);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bntOK
            // 
            this.bntOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bntOK.BackColor = System.Drawing.Color.Transparent;
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bntOK.FlatAppearance.BorderSize = 0;
            this.bntOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.FileSave;
            this.bntOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntOK.Location = new System.Drawing.Point(186, 332);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(63, 62);
            this.bntOK.TabIndex = 1;
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = false;
            this.bntOK.Click += new System.EventHandler(this.bntOk_Click);
            // 
            // btnAdjLeft
            // 
            this.btnAdjLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnAdjLeft.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnAdjLeft.FlatAppearance.BorderSize = 0;
            this.btnAdjLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjLeft.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnAdjLeft.Image = global::AgOpenGPS.Properties.Resources.SnapLeft;
            this.btnAdjLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdjLeft.Location = new System.Drawing.Point(3, 80);
            this.btnAdjLeft.Name = "btnAdjLeft";
            this.btnAdjLeft.Size = new System.Drawing.Size(76, 67);
            this.btnAdjLeft.TabIndex = 6;
            this.btnAdjLeft.UseVisualStyleBackColor = false;
            this.btnAdjLeft.Click += new System.EventHandler(this.btnAdjLeft_Click);
            // 
            // btnAdjRight
            // 
            this.btnAdjRight.BackColor = System.Drawing.Color.Transparent;
            this.btnAdjRight.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnAdjRight.FlatAppearance.BorderSize = 0;
            this.btnAdjRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjRight.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnAdjRight.Image = global::AgOpenGPS.Properties.Resources.SnapRight;
            this.btnAdjRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdjRight.Location = new System.Drawing.Point(172, 80);
            this.btnAdjRight.Name = "btnAdjRight";
            this.btnAdjRight.Size = new System.Drawing.Size(76, 67);
            this.btnAdjRight.TabIndex = 7;
            this.btnAdjRight.UseVisualStyleBackColor = false;
            this.btnAdjRight.Click += new System.EventHandler(this.btnAdjRight_Click);
            // 
            // tboxHeading
            // 
            this.tboxHeading.BackColor = System.Drawing.Color.AliceBlue;
            this.tboxHeading.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxHeading.Location = new System.Drawing.Point(108, 267);
            this.tboxHeading.MaxLength = 10;
            this.tboxHeading.Name = "tboxHeading";
            this.tboxHeading.Size = new System.Drawing.Size(140, 36);
            this.tboxHeading.TabIndex = 453;
            this.tboxHeading.Text = "359.123456";
            this.tboxHeading.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxHeading.Enter += new System.EventHandler(this.tboxHeading_Enter);
            // 
            // cboxDegrees
            // 
            this.cboxDegrees.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxDegrees.BackColor = System.Drawing.Color.Lavender;
            this.cboxDegrees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDegrees.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboxDegrees.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDegrees.FormattingEnabled = true;
            this.cboxDegrees.Items.AddRange(new object[] {
            "0",
            "90",
            "180",
            "270"});
            this.cboxDegrees.Location = new System.Drawing.Point(9, 266);
            this.cboxDegrees.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxDegrees.Name = "cboxDegrees";
            this.cboxDegrees.Size = new System.Drawing.Size(78, 37);
            this.cboxDegrees.TabIndex = 454;
            this.cboxDegrees.SelectedIndexChanged += new System.EventHandler(this.cboxDegrees_SelectedIndexChanged);
            // 
            // FormEditAB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(252, 398);
            this.ControlBox = false;
            this.Controls.Add(this.cboxDegrees);
            this.Controls.Add(this.tboxHeading);
            this.Controls.Add(this.lblHalfSnapFtM);
            this.Controls.Add(this.lblHalfWidth);
            this.Controls.Add(this.btnNoSave);
            this.Controls.Add(this.btnLeftHalfWidth);
            this.Controls.Add(this.btnRightHalfWidth);
            this.Controls.Add(this.btnContourPriority);
            this.Controls.Add(this.btnSwapAB);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.bntOK);
            this.Controls.Add(this.btnAdjLeft);
            this.Controls.Add(this.btnAdjRight);
            this.Controls.Add(this.nudMinTurnRadius);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEditAB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit AB Line";
            this.Load += new System.EventHandler(this.FormEditAB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMinTurnRadius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdjRight;
        private System.Windows.Forms.Button btnAdjLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.Button btnSwapAB;
        private System.Windows.Forms.NumericUpDown nudMinTurnRadius;
        public System.Windows.Forms.Button btnContourPriority;
        private System.Windows.Forms.Button btnLeftHalfWidth;
        private System.Windows.Forms.Button btnRightHalfWidth;
        private System.Windows.Forms.Button btnNoSave;
        private System.Windows.Forms.Label lblHalfSnapFtM;
        private System.Windows.Forms.Label lblHalfWidth;
        private System.Windows.Forms.TextBox tboxHeading;
        private System.Windows.Forms.ComboBox cboxDegrees;
    }
}