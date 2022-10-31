namespace AgOpenGPS
{
    partial class FormFieldJobNew
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
            this.tboxJobName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxAddTime = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboxAddDate = new System.Windows.Forms.CheckBox();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboxFields = new System.Windows.Forms.ComboBox();
            this.lblJobName = new System.Windows.Forms.Label();
            this.tboxNewFieldName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tboxJobName
            // 
            this.tboxJobName.BackColor = System.Drawing.Color.AliceBlue;
            this.tboxJobName.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxJobName.Location = new System.Drawing.Point(144, 257);
            this.tboxJobName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxJobName.Name = "tboxJobName";
            this.tboxJobName.Size = new System.Drawing.Size(634, 36);
            this.tboxJobName.TabIndex = 0;
            this.tboxJobName.Click += new System.EventHandler(this.tboxJobName_Click);
            this.tboxJobName.TextChanged += new System.EventHandler(this.tboxJobName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(308, 361);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 23);
            this.label3.TabIndex = 150;
            this.label3.Text = "+";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(151, 361);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 23);
            this.label2.TabIndex = 149;
            this.label2.Text = "+";
            // 
            // cboxAddTime
            // 
            this.cboxAddTime.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxAddTime.BackColor = System.Drawing.Color.Transparent;
            this.cboxAddTime.FlatAppearance.BorderSize = 0;
            this.cboxAddTime.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.cboxAddTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxAddTime.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxAddTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cboxAddTime.Image = global::AgOpenGPS.Properties.Resources.JobNameTime;
            this.cboxAddTime.Location = new System.Drawing.Point(339, 337);
            this.cboxAddTime.Name = "cboxAddTime";
            this.cboxAddTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxAddTime.Size = new System.Drawing.Size(86, 70);
            this.cboxAddTime.TabIndex = 2;
            this.cboxAddTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxAddTime.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnSave.Location = new System.Drawing.Point(695, 337);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 79);
            this.btnSave.TabIndex = 3;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboxAddDate
            // 
            this.cboxAddDate.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxAddDate.BackColor = System.Drawing.Color.Transparent;
            this.cboxAddDate.FlatAppearance.BorderSize = 0;
            this.cboxAddDate.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.cboxAddDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxAddDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxAddDate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cboxAddDate.Image = global::AgOpenGPS.Properties.Resources.JobNameCalendar;
            this.cboxAddDate.Location = new System.Drawing.Point(182, 337);
            this.cboxAddDate.Name = "cboxAddDate";
            this.cboxAddDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxAddDate.Size = new System.Drawing.Size(86, 70);
            this.cboxAddDate.TabIndex = 1;
            this.cboxAddDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxAddDate.UseVisualStyleBackColor = false;
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.FlatAppearance.BorderSize = 0;
            this.btnSerialCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialCancel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSerialCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSerialCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnSerialCancel.Location = new System.Drawing.Point(587, 336);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(77, 79);
            this.btnSerialCancel.TabIndex = 4;
            this.btnSerialCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSerialCancel.UseVisualStyleBackColor = false;
            this.btnSerialCancel.Click += new System.EventHandler(this.btnSerialCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(51, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 25);
            this.label4.TabIndex = 152;
            this.label4.Text = "Select Field:";
            // 
            // comboxFields
            // 
            this.comboxFields.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboxFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxFields.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboxFields.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboxFields.FormattingEnabled = true;
            this.comboxFields.Location = new System.Drawing.Point(203, 36);
            this.comboxFields.Name = "comboxFields";
            this.comboxFields.Size = new System.Drawing.Size(575, 41);
            this.comboxFields.TabIndex = 151;
            this.comboxFields.SelectedIndexChanged += new System.EventHandler(this.comboxFields_SelectedIndexChanged);
            // 
            // lblJobName
            // 
            this.lblJobName.AutoSize = true;
            this.lblJobName.BackColor = System.Drawing.Color.Transparent;
            this.lblJobName.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobName.ForeColor = System.Drawing.Color.White;
            this.lblJobName.Location = new System.Drawing.Point(67, 263);
            this.lblJobName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(57, 25);
            this.lblJobName.TabIndex = 153;
            this.lblJobName.Text = "Job:";
            // 
            // tboxNewFieldName
            // 
            this.tboxNewFieldName.BackColor = System.Drawing.Color.AliceBlue;
            this.tboxNewFieldName.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxNewFieldName.Location = new System.Drawing.Point(199, 138);
            this.tboxNewFieldName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxNewFieldName.Name = "tboxNewFieldName";
            this.tboxNewFieldName.Size = new System.Drawing.Size(579, 36);
            this.tboxNewFieldName.TabIndex = 154;
            this.tboxNewFieldName.Click += new System.EventHandler(this.tboxJobName_Click);
            this.tboxNewFieldName.TextChanged += new System.EventHandler(this.tboxNewFieldName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(67, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 25);
            this.label5.TabIndex = 155;
            this.label5.Text = "New Field:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(103, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 25);
            this.label1.TabIndex = 156;
            this.label1.Text = "Or";
            // 
            // FormNewFieldJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(797, 427);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tboxNewFieldName);
            this.Controls.Add(this.lblJobName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboxFields);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboxAddTime);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tboxJobName);
            this.Controls.Add(this.cboxAddDate);
            this.Controls.Add(this.btnSerialCancel);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormNewFieldJob";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Field ";
            this.Load += new System.EventHandler(this.FormFieldDir_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tboxJobName;
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cboxAddDate;
        private System.Windows.Forms.CheckBox cboxAddTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboxFields;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.TextBox tboxNewFieldName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
    }
}