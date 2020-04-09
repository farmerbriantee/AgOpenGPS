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
            this.label1 = new System.Windows.Forms.Label();
            this.tboxFieldName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.lblTemplateChosen = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tboxTask = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tboxVehicle = new System.Windows.Forms.TextBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.chkApplied = new System.Windows.Forms.CheckBox();
            this.chkHeadland = new System.Windows.Forms.CheckBox();
            this.chkGuidanceLines = new System.Windows.Forms.CheckBox();
            this.chkFlags = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 67);
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
            this.tboxFieldName.Location = new System.Drawing.Point(13, 94);
            this.tboxFieldName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxFieldName.Name = "tboxFieldName";
            this.tboxFieldName.Size = new System.Drawing.Size(486, 36);
            this.tboxFieldName.TabIndex = 0;
            this.tboxFieldName.Click += new System.EventHandler(this.tboxFieldName_Click);
            this.tboxFieldName.TextChanged += new System.EventHandler(this.tboxFieldName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label2.Location = new System.Drawing.Point(290, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "** Date will be added";
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSerialCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnSerialCancel.Location = new System.Drawing.Point(539, 299);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(88, 77);
            this.btnSerialCancel.TabIndex = 4;
            this.btnSerialCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            this.btnSerialCancel.Click += new System.EventHandler(this.btnSerialCancel_Click);
            // 
            // lblTemplateChosen
            // 
            this.lblTemplateChosen.AutoSize = true;
            this.lblTemplateChosen.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplateChosen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTemplateChosen.Location = new System.Drawing.Point(18, 28);
            this.lblTemplateChosen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemplateChosen.Name = "lblTemplateChosen";
            this.lblTemplateChosen.Size = new System.Drawing.Size(113, 23);
            this.lblTemplateChosen.TabIndex = 140;
            this.lblTemplateChosen.Text = "None Used";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(18, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 23);
            this.label3.TabIndex = 141;
            this.label3.Text = "Based on Field:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnSave.Location = new System.Drawing.Point(655, 299);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 79);
            this.btnSave.TabIndex = 3;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tboxTask
            // 
            this.tboxTask.BackColor = System.Drawing.Color.AliceBlue;
            this.tboxTask.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxTask.Location = new System.Drawing.Point(13, 202);
            this.tboxTask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxTask.Name = "tboxTask";
            this.tboxTask.Size = new System.Drawing.Size(339, 36);
            this.tboxTask.TabIndex = 1;
            this.tboxTask.Click += new System.EventHandler(this.tboxTask_Click);
            this.tboxTask.TextChanged += new System.EventHandler(this.tboxTask_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(18, 177);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 23);
            this.label4.TabIndex = 144;
            this.label4.Text = "Enter Task";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(18, 246);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 23);
            this.label5.TabIndex = 146;
            this.label5.Text = "Enter Vehicle Used";
            // 
            // tboxVehicle
            // 
            this.tboxVehicle.BackColor = System.Drawing.Color.AliceBlue;
            this.tboxVehicle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxVehicle.Location = new System.Drawing.Point(13, 271);
            this.tboxVehicle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxVehicle.Name = "tboxVehicle";
            this.tboxVehicle.Size = new System.Drawing.Size(339, 36);
            this.tboxVehicle.TabIndex = 2;
            this.tboxVehicle.Click += new System.EventHandler(this.tboxVehicle_Click);
            this.tboxVehicle.TextChanged += new System.EventHandler(this.tboxVehicle_TextChanged);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilename.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFilename.Location = new System.Drawing.Point(13, 136);
            this.lblFilename.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(96, 23);
            this.lblFilename.TabIndex = 147;
            this.lblFilename.Text = "Filename";
            // 
            // chkApplied
            // 
            this.chkApplied.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkApplied.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkApplied.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkApplied.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkApplied.Location = new System.Drawing.Point(596, 20);
            this.chkApplied.Name = "chkApplied";
            this.chkApplied.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkApplied.Size = new System.Drawing.Size(192, 45);
            this.chkApplied.TabIndex = 257;
            this.chkApplied.Text = "Applied";
            this.chkApplied.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkApplied.UseVisualStyleBackColor = true;
            // 
            // chkHeadland
            // 
            this.chkHeadland.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkHeadland.Checked = true;
            this.chkHeadland.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHeadland.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkHeadland.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHeadland.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHeadland.Location = new System.Drawing.Point(596, 224);
            this.chkHeadland.Name = "chkHeadland";
            this.chkHeadland.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkHeadland.Size = new System.Drawing.Size(192, 45);
            this.chkHeadland.TabIndex = 258;
            this.chkHeadland.Text = "Headland";
            this.chkHeadland.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkHeadland.UseVisualStyleBackColor = true;
            // 
            // chkGuidanceLines
            // 
            this.chkGuidanceLines.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkGuidanceLines.Checked = true;
            this.chkGuidanceLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGuidanceLines.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkGuidanceLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkGuidanceLines.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGuidanceLines.Location = new System.Drawing.Point(596, 156);
            this.chkGuidanceLines.Name = "chkGuidanceLines";
            this.chkGuidanceLines.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkGuidanceLines.Size = new System.Drawing.Size(192, 45);
            this.chkGuidanceLines.TabIndex = 259;
            this.chkGuidanceLines.Text = "Guidance Lines";
            this.chkGuidanceLines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkGuidanceLines.UseVisualStyleBackColor = true;
            // 
            // chkFlags
            // 
            this.chkFlags.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFlags.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkFlags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkFlags.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFlags.Location = new System.Drawing.Point(596, 88);
            this.chkFlags.Name = "chkFlags";
            this.chkFlags.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkFlags.Size = new System.Drawing.Size(192, 45);
            this.chkFlags.TabIndex = 260;
            this.chkFlags.Text = "Flags";
            this.chkFlags.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFlags.UseVisualStyleBackColor = true;
            // 
            // FormSaveAs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(807, 388);
            this.ControlBox = false;
            this.Controls.Add(this.chkFlags);
            this.Controls.Add(this.chkGuidanceLines);
            this.Controls.Add(this.chkHeadland);
            this.Controls.Add(this.chkApplied);
            this.Controls.Add(this.lblTemplateChosen);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tboxVehicle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tboxTask);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSerialCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxFieldName);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormSaveAs";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Field Save As";
            this.Load += new System.EventHandler(this.FormSaveAs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxFieldName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Label lblTemplateChosen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tboxTask;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tboxVehicle;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.CheckBox chkApplied;
        private System.Windows.Forms.CheckBox chkHeadland;
        private System.Windows.Forms.CheckBox chkGuidanceLines;
        private System.Windows.Forms.CheckBox chkFlags;
    }
}