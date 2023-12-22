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
            this.btnNoSave = new System.Windows.Forms.Button();
            this.btnContourPriority = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAdjLeft = new System.Windows.Forms.Button();
            this.btnAdjRight = new System.Windows.Forms.Button();
            this.tboxHeading = new System.Windows.Forms.TextBox();
            this.cboxDegrees = new System.Windows.Forms.ComboBox();
            this.nudSnapDistance = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNudgeHalfToolRight = new System.Windows.Forms.Button();
            this.btnNudgeHalfToolLeft = new System.Windows.Forms.Button();
            this.lblHalfToolWidth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSnapDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 19);
            this.label1.TabIndex = 414;
            this.label1.Text = "cm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNoSave
            // 
            this.btnNoSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNoSave.FlatAppearance.BorderSize = 0;
            this.btnNoSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoSave.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoSave.Image = global::AgOpenGPS.Properties.Resources.FileDontSave;
            this.btnNoSave.Location = new System.Drawing.Point(105, 301);
            this.btnNoSave.Name = "btnNoSave";
            this.btnNoSave.Size = new System.Drawing.Size(63, 62);
            this.btnNoSave.TabIndex = 448;
            this.btnNoSave.UseVisualStyleBackColor = true;
            this.btnNoSave.Click += new System.EventHandler(this.btnNoSave_Click);
            this.btnNoSave.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnNoSave_HelpRequested);
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
            this.btnContourPriority.Location = new System.Drawing.Point(192, 112);
            this.btnContourPriority.Name = "btnContourPriority";
            this.btnContourPriority.Size = new System.Drawing.Size(76, 67);
            this.btnContourPriority.TabIndex = 3;
            this.btnContourPriority.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContourPriority.UseVisualStyleBackColor = false;
            this.btnContourPriority.Click += new System.EventHandler(this.btnContourPriority_Click);
            this.btnContourPriority.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnContourPriority_HelpRequested);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(2, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 62);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnCancel_HelpRequested);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOK.Image = global::AgOpenGPS.Properties.Resources.FileSave;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(208, 301);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(63, 62);
            this.btnOK.TabIndex = 1;
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.bntOk_Click);
            this.btnOK.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnOK_HelpRequested);
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
            this.btnAdjLeft.Location = new System.Drawing.Point(3, 11);
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
            this.btnAdjRight.Location = new System.Drawing.Point(194, 11);
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
            this.tboxHeading.Location = new System.Drawing.Point(117, 222);
            this.tboxHeading.MaxLength = 10;
            this.tboxHeading.Name = "tboxHeading";
            this.tboxHeading.Size = new System.Drawing.Size(140, 36);
            this.tboxHeading.TabIndex = 453;
            this.tboxHeading.Text = "359.123456";
            this.tboxHeading.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxHeading.Click += new System.EventHandler(this.tboxHeading_Click);
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
            this.cboxDegrees.Location = new System.Drawing.Point(13, 222);
            this.cboxDegrees.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxDegrees.Name = "cboxDegrees";
            this.cboxDegrees.Size = new System.Drawing.Size(78, 37);
            this.cboxDegrees.TabIndex = 454;
            this.cboxDegrees.SelectedIndexChanged += new System.EventHandler(this.cboxDegrees_SelectedIndexChanged);
            // 
            // nudSnapDistance
            // 
            this.nudSnapDistance.BackColor = System.Drawing.Color.AliceBlue;
            this.nudSnapDistance.DecimalPlaces = 1;
            this.nudSnapDistance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSnapDistance.InterceptArrowKeys = false;
            this.nudSnapDistance.Location = new System.Drawing.Point(92, 31);
            this.nudSnapDistance.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudSnapDistance.Name = "nudSnapDistance";
            this.nudSnapDistance.ReadOnly = true;
            this.nudSnapDistance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudSnapDistance.Size = new System.Drawing.Size(93, 33);
            this.nudSnapDistance.TabIndex = 411;
            this.nudSnapDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSnapDistance.Value = new decimal(new int[] {
            888,
            0,
            0,
            0});
            this.nudSnapDistance.Click += new System.EventHandler(this.nudSnapDistance_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 455;
            this.label2.Text = "Cancel";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(112, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 456;
            this.label3.Text = "For Now";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(222, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 457;
            this.label4.Text = "Save";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNudgeHalfToolRight
            // 
            this.btnNudgeHalfToolRight.BackColor = System.Drawing.Color.Transparent;
            this.btnNudgeHalfToolRight.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnNudgeHalfToolRight.FlatAppearance.BorderSize = 0;
            this.btnNudgeHalfToolRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNudgeHalfToolRight.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnNudgeHalfToolRight.Image = global::AgOpenGPS.Properties.Resources.SnapRightHalf;
            this.btnNudgeHalfToolRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNudgeHalfToolRight.Location = new System.Drawing.Point(83, 112);
            this.btnNudgeHalfToolRight.Name = "btnNudgeHalfToolRight";
            this.btnNudgeHalfToolRight.Size = new System.Drawing.Size(76, 67);
            this.btnNudgeHalfToolRight.TabIndex = 477;
            this.btnNudgeHalfToolRight.UseVisualStyleBackColor = false;
            this.btnNudgeHalfToolRight.Click += new System.EventHandler(this.btnNudgeHalfToolRight_Click);
            // 
            // btnNudgeHalfToolLeft
            // 
            this.btnNudgeHalfToolLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnNudgeHalfToolLeft.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnNudgeHalfToolLeft.FlatAppearance.BorderSize = 0;
            this.btnNudgeHalfToolLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNudgeHalfToolLeft.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnNudgeHalfToolLeft.Image = global::AgOpenGPS.Properties.Resources.SnapLeftHalf;
            this.btnNudgeHalfToolLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNudgeHalfToolLeft.Location = new System.Drawing.Point(5, 112);
            this.btnNudgeHalfToolLeft.Name = "btnNudgeHalfToolLeft";
            this.btnNudgeHalfToolLeft.Size = new System.Drawing.Size(76, 67);
            this.btnNudgeHalfToolLeft.TabIndex = 478;
            this.btnNudgeHalfToolLeft.UseVisualStyleBackColor = false;
            this.btnNudgeHalfToolLeft.Click += new System.EventHandler(this.btnNudgeHalfToolLeft_Click);
            // 
            // lblHalfToolWidth
            // 
            this.lblHalfToolWidth.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalfToolWidth.Location = new System.Drawing.Point(35, 96);
            this.lblHalfToolWidth.Name = "lblHalfToolWidth";
            this.lblHalfToolWidth.Size = new System.Drawing.Size(94, 19);
            this.lblHalfToolWidth.TabIndex = 479;
            this.lblHalfToolWidth.Text = "cm";
            this.lblHalfToolWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormEditAB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(275, 367);
            this.Controls.Add(this.lblHalfToolWidth);
            this.Controls.Add(this.btnNudgeHalfToolLeft);
            this.Controls.Add(this.btnNudgeHalfToolRight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboxDegrees);
            this.Controls.Add(this.tboxHeading);
            this.Controls.Add(this.btnNoSave);
            this.Controls.Add(this.btnContourPriority);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAdjLeft);
            this.Controls.Add(this.btnAdjRight);
            this.Controls.Add(this.nudSnapDistance);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditAB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit AB Line";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditAB_FormClosing);
            this.Load += new System.EventHandler(this.FormEditAB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSnapDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdjRight;
        private System.Windows.Forms.Button btnAdjLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnContourPriority;
        private System.Windows.Forms.Button btnNoSave;
        private System.Windows.Forms.TextBox tboxHeading;
        private System.Windows.Forms.ComboBox cboxDegrees;
        private System.Windows.Forms.NumericUpDown nudSnapDistance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNudgeHalfToolRight;
        private System.Windows.Forms.Button btnNudgeHalfToolLeft;
        private System.Windows.Forms.Label lblHalfToolWidth;
    }
}