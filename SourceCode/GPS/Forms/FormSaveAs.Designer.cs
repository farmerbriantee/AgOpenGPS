namespace AgOpenGPS
{
    partial class FormSaveAs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSaveAs));
            this.label1 = new System.Windows.Forms.Label();
            this.tboxFieldName = new System.Windows.Forms.TextBox();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.lblTemplateChosen = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFilename = new System.Windows.Forms.Label();
            this.chkApplied = new System.Windows.Forms.CheckBox();
            this.chkHeadland = new System.Windows.Forms.CheckBox();
            this.chkGuidanceLines = new System.Windows.Forms.CheckBox();
            this.chkFlags = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboxAddTime = new System.Windows.Forms.CheckBox();
            this.cboxAddDate = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 132);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Field Name";
            // 
            // tboxFieldName
            // 
            this.tboxFieldName.BackColor = System.Drawing.Color.AliceBlue;
            this.tboxFieldName.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxFieldName.Location = new System.Drawing.Point(13, 157);
            this.tboxFieldName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxFieldName.Name = "tboxFieldName";
            this.tboxFieldName.Size = new System.Drawing.Size(486, 36);
            this.tboxFieldName.TabIndex = 0;
            this.tboxFieldName.Click += new System.EventHandler(this.tboxFieldName_Click);
            this.tboxFieldName.TextChanged += new System.EventHandler(this.tboxFieldName_TextChanged);
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.FlatAppearance.BorderSize = 0;
            this.btnSerialCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialCancel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSerialCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnSerialCancel.Location = new System.Drawing.Point(550, 285);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(88, 77);
            this.btnSerialCancel.TabIndex = 4;
            this.btnSerialCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSerialCancel.UseVisualStyleBackColor = false;
            this.btnSerialCancel.Click += new System.EventHandler(this.btnSerialCancel_Click);
            // 
            // lblTemplateChosen
            // 
            this.lblTemplateChosen.AutoSize = true;
            this.lblTemplateChosen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.lblTemplateChosen.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplateChosen.ForeColor = System.Drawing.Color.White;
            this.lblTemplateChosen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTemplateChosen.Location = new System.Drawing.Point(60, 51);
            this.lblTemplateChosen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemplateChosen.Name = "lblTemplateChosen";
            this.lblTemplateChosen.Size = new System.Drawing.Size(113, 23);
            this.lblTemplateChosen.TabIndex = 140;
            this.lblTemplateChosen.Text = "None Used";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(18, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 23);
            this.label3.TabIndex = 141;
            this.label3.Text = "Based on Field:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(659, 285);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 79);
            this.btnSave.TabIndex = 3;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.lblFilename.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilename.ForeColor = System.Drawing.Color.White;
            this.lblFilename.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFilename.Location = new System.Drawing.Point(15, 201);
            this.lblFilename.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(96, 23);
            this.lblFilename.TabIndex = 147;
            this.lblFilename.Text = "Filename";
            // 
            // chkApplied
            // 
            this.chkApplied.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkApplied.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.chkApplied.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.chkApplied.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.chkApplied.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkApplied.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkApplied.ForeColor = System.Drawing.Color.White;
            this.chkApplied.Image = global::AgOpenGPS.Properties.Resources.SectionMasterOn;
            this.chkApplied.Location = new System.Drawing.Point(682, 17);
            this.chkApplied.Name = "chkApplied";
            this.chkApplied.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkApplied.Size = new System.Drawing.Size(90, 90);
            this.chkApplied.TabIndex = 257;
            this.chkApplied.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkApplied.UseVisualStyleBackColor = false;
            // 
            // chkHeadland
            // 
            this.chkHeadland.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkHeadland.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.chkHeadland.Checked = true;
            this.chkHeadland.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHeadland.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.chkHeadland.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.chkHeadland.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHeadland.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHeadland.ForeColor = System.Drawing.Color.White;
            this.chkHeadland.Image = ((System.Drawing.Image)(resources.GetObject("chkHeadland.Image")));
            this.chkHeadland.Location = new System.Drawing.Point(548, 136);
            this.chkHeadland.Name = "chkHeadland";
            this.chkHeadland.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkHeadland.Size = new System.Drawing.Size(90, 90);
            this.chkHeadland.TabIndex = 258;
            this.chkHeadland.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkHeadland.UseVisualStyleBackColor = false;
            // 
            // chkGuidanceLines
            // 
            this.chkGuidanceLines.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkGuidanceLines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.chkGuidanceLines.Checked = true;
            this.chkGuidanceLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGuidanceLines.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.chkGuidanceLines.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.chkGuidanceLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkGuidanceLines.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGuidanceLines.ForeColor = System.Drawing.Color.White;
            this.chkGuidanceLines.Image = global::AgOpenGPS.Properties.Resources.ABLineEdit;
            this.chkGuidanceLines.Location = new System.Drawing.Point(682, 136);
            this.chkGuidanceLines.Name = "chkGuidanceLines";
            this.chkGuidanceLines.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkGuidanceLines.Size = new System.Drawing.Size(90, 90);
            this.chkGuidanceLines.TabIndex = 259;
            this.chkGuidanceLines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkGuidanceLines.UseVisualStyleBackColor = false;
            // 
            // chkFlags
            // 
            this.chkFlags.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFlags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.chkFlags.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.chkFlags.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.chkFlags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkFlags.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFlags.ForeColor = System.Drawing.Color.White;
            this.chkFlags.Image = global::AgOpenGPS.Properties.Resources.FlagRed;
            this.chkFlags.Location = new System.Drawing.Point(548, 17);
            this.chkFlags.Name = "chkFlags";
            this.chkFlags.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkFlags.Size = new System.Drawing.Size(90, 90);
            this.chkFlags.TabIndex = 260;
            this.chkFlags.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFlags.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboxAddTime);
            this.panel1.Controls.Add(this.cboxAddDate);
            this.panel1.Controls.Add(this.chkHeadland);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkFlags);
            this.panel1.Controls.Add(this.btnSerialCancel);
            this.panel1.Controls.Add(this.chkApplied);
            this.panel1.Controls.Add(this.chkGuidanceLines);
            this.panel1.Controls.Add(this.lblTemplateChosen);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 374);
            this.panel1.TabIndex = 261;
            // 
            // cboxAddTime
            // 
            this.cboxAddTime.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxAddTime.BackColor = System.Drawing.Color.Transparent;
            this.cboxAddTime.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.cboxAddTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxAddTime.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxAddTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cboxAddTime.Image = global::AgOpenGPS.Properties.Resources.JobNameTime;
            this.cboxAddTime.Location = new System.Drawing.Point(248, 257);
            this.cboxAddTime.Name = "cboxAddTime";
            this.cboxAddTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxAddTime.Size = new System.Drawing.Size(90, 90);
            this.cboxAddTime.TabIndex = 263;
            this.cboxAddTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxAddTime.UseVisualStyleBackColor = false;
            // 
            // cboxAddDate
            // 
            this.cboxAddDate.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxAddDate.BackColor = System.Drawing.Color.Transparent;
            this.cboxAddDate.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.cboxAddDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxAddDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxAddDate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cboxAddDate.Image = global::AgOpenGPS.Properties.Resources.JobNameCalendar;
            this.cboxAddDate.Location = new System.Drawing.Point(114, 257);
            this.cboxAddDate.Name = "cboxAddDate";
            this.cboxAddDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxAddDate.Size = new System.Drawing.Size(90, 90);
            this.cboxAddDate.TabIndex = 262;
            this.cboxAddDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxAddDate.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(83, 291);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 23);
            this.label2.TabIndex = 264;
            this.label2.Text = "+";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(221, 292);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 23);
            this.label4.TabIndex = 265;
            this.label4.Text = "+";
            // 
            // FormSaveAs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(801, 378);
            this.ControlBox = false;
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxFieldName);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormSaveAs";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Field Save As";
            this.Load += new System.EventHandler(this.FormSaveAs_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxFieldName;
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Label lblTemplateChosen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.CheckBox chkApplied;
        private System.Windows.Forms.CheckBox chkHeadland;
        private System.Windows.Forms.CheckBox chkGuidanceLines;
        private System.Windows.Forms.CheckBox chkFlags;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cboxAddTime;
        private System.Windows.Forms.CheckBox cboxAddDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}