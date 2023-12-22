namespace AgOpenGPS
{
    partial class FormEditCurve
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
            this.nudSnapDistance = new System.Windows.Forms.NumericUpDown();
            this.btnNoSave = new System.Windows.Forms.Button();
            this.btnContourPriority = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bthOK = new System.Windows.Forms.Button();
            this.btnAdjLeft = new System.Windows.Forms.Button();
            this.btnAdjRight = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNudgeHalfToolLeft = new System.Windows.Forms.Button();
            this.btnNudgeHalfToolRight = new System.Windows.Forms.Button();
            this.lblHalfToolWidth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSnapDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 414;
            this.label1.Text = "cm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudSnapDistance
            // 
            this.nudSnapDistance.BackColor = System.Drawing.Color.AliceBlue;
            this.nudSnapDistance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSnapDistance.InterceptArrowKeys = false;
            this.nudSnapDistance.Location = new System.Drawing.Point(92, 32);
            this.nudSnapDistance.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudSnapDistance.Name = "nudSnapDistance";
            this.nudSnapDistance.ReadOnly = true;
            this.nudSnapDistance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudSnapDistance.Size = new System.Drawing.Size(85, 33);
            this.nudSnapDistance.TabIndex = 411;
            this.nudSnapDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSnapDistance.Value = new decimal(new int[] {
            8888,
            0,
            0,
            0});
            this.nudSnapDistance.Click += new System.EventHandler(this.nudSnapDistance_Click);
            // 
            // btnNoSave
            // 
            this.btnNoSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNoSave.FlatAppearance.BorderSize = 0;
            this.btnNoSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoSave.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoSave.Image = global::AgOpenGPS.Properties.Resources.FileDontSave;
            this.btnNoSave.Location = new System.Drawing.Point(94, 232);
            this.btnNoSave.Name = "btnNoSave";
            this.btnNoSave.Size = new System.Drawing.Size(72, 64);
            this.btnNoSave.TabIndex = 449;
            this.btnNoSave.UseVisualStyleBackColor = true;
            this.btnNoSave.Click += new System.EventHandler(this.btnNosave_Click);
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
            this.btnContourPriority.Location = new System.Drawing.Point(192, 119);
            this.btnContourPriority.Name = "btnContourPriority";
            this.btnContourPriority.Size = new System.Drawing.Size(64, 64);
            this.btnContourPriority.TabIndex = 6;
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
            this.btnCancel.Location = new System.Drawing.Point(1, 232);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 64);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnCancel_HelpRequested);
            // 
            // bthOK
            // 
            this.bthOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bthOK.BackColor = System.Drawing.Color.Transparent;
            this.bthOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bthOK.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bthOK.FlatAppearance.BorderSize = 0;
            this.bthOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bthOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bthOK.Image = global::AgOpenGPS.Properties.Resources.FileSave;
            this.bthOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bthOK.Location = new System.Drawing.Point(193, 232);
            this.bthOK.Name = "bthOK";
            this.bthOK.Size = new System.Drawing.Size(72, 64);
            this.bthOK.TabIndex = 1;
            this.bthOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bthOK.UseVisualStyleBackColor = false;
            this.bthOK.Click += new System.EventHandler(this.bntOk_Click);
            this.bthOK.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnOK_HelpRequested);
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
            this.btnAdjLeft.Location = new System.Drawing.Point(3, 22);
            this.btnAdjLeft.Name = "btnAdjLeft";
            this.btnAdjLeft.Size = new System.Drawing.Size(72, 60);
            this.btnAdjLeft.TabIndex = 4;
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
            this.btnAdjRight.Location = new System.Drawing.Point(191, 18);
            this.btnAdjRight.Name = "btnAdjRight";
            this.btnAdjRight.Size = new System.Drawing.Size(72, 64);
            this.btnAdjRight.TabIndex = 5;
            this.btnAdjRight.UseVisualStyleBackColor = false;
            this.btnAdjRight.Click += new System.EventHandler(this.btnAdjRight_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(213, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 460;
            this.label4.Text = "Save";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(107, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 459;
            this.label3.Text = "For Now";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 458;
            this.label2.Text = "Cancel";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnNudgeHalfToolLeft.Location = new System.Drawing.Point(8, 119);
            this.btnNudgeHalfToolLeft.Name = "btnNudgeHalfToolLeft";
            this.btnNudgeHalfToolLeft.Size = new System.Drawing.Size(64, 64);
            this.btnNudgeHalfToolLeft.TabIndex = 480;
            this.btnNudgeHalfToolLeft.UseVisualStyleBackColor = false;
            this.btnNudgeHalfToolLeft.Click += new System.EventHandler(this.btnNudgeHalfToolLeft_Click);
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
            this.btnNudgeHalfToolRight.Location = new System.Drawing.Point(86, 119);
            this.btnNudgeHalfToolRight.Name = "btnNudgeHalfToolRight";
            this.btnNudgeHalfToolRight.Size = new System.Drawing.Size(64, 64);
            this.btnNudgeHalfToolRight.TabIndex = 479;
            this.btnNudgeHalfToolRight.UseVisualStyleBackColor = false;
            this.btnNudgeHalfToolRight.Click += new System.EventHandler(this.btnNudgeHalfToolRight_Click);
            // 
            // lblHalfToolWidth
            // 
            this.lblHalfToolWidth.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalfToolWidth.Location = new System.Drawing.Point(37, 100);
            this.lblHalfToolWidth.Name = "lblHalfToolWidth";
            this.lblHalfToolWidth.Size = new System.Drawing.Size(87, 19);
            this.lblHalfToolWidth.TabIndex = 481;
            this.lblHalfToolWidth.Text = "cm";
            this.lblHalfToolWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormEditCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(268, 297);
            this.Controls.Add(this.lblHalfToolWidth);
            this.Controls.Add(this.btnNudgeHalfToolLeft);
            this.Controls.Add(this.btnNudgeHalfToolRight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNoSave);
            this.Controls.Add(this.btnContourPriority);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.bthOK);
            this.Controls.Add(this.btnAdjLeft);
            this.Controls.Add(this.btnAdjRight);
            this.Controls.Add(this.nudSnapDistance);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditCurve";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit AB Line";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditCurve_FormClosing);
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
        private System.Windows.Forms.Button bthOK;
        private System.Windows.Forms.NumericUpDown nudSnapDistance;
        public System.Windows.Forms.Button btnContourPriority;
        private System.Windows.Forms.Button btnNoSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNudgeHalfToolLeft;
        private System.Windows.Forms.Button btnNudgeHalfToolRight;
        private System.Windows.Forms.Label lblHalfToolWidth;
    }
}