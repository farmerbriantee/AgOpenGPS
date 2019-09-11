namespace AgOpenGPS
{
    partial class FormJob
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
            this.btnJobOpen = new System.Windows.Forms.Button();
            this.btnJobNew = new System.Windows.Forms.Button();
            this.btnDeleteAB = new System.Windows.Forms.Button();
            this.btnJobResume = new System.Windows.Forms.Button();
            this.lblResumeDirectory = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnJobOpen
            // 
            this.btnJobOpen.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.btnJobOpen.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.btnJobOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobOpen.Location = new System.Drawing.Point(44, 360);
            this.btnJobOpen.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobOpen.Name = "btnJobOpen";
            this.btnJobOpen.Size = new System.Drawing.Size(305, 104);
            this.btnJobOpen.TabIndex = 3;
            this.btnJobOpen.Text = "Open Existing";
            this.btnJobOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobOpen.UseVisualStyleBackColor = true;
            this.btnJobOpen.Click += new System.EventHandler(this.btnJobOpen_Click);
            // 
            // btnJobNew
            // 
            this.btnJobNew.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.btnJobNew.Image = global::AgOpenGPS.Properties.Resources.FileNew;
            this.btnJobNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobNew.Location = new System.Drawing.Point(44, 224);
            this.btnJobNew.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobNew.Name = "btnJobNew";
            this.btnJobNew.Size = new System.Drawing.Size(305, 104);
            this.btnJobNew.TabIndex = 2;
            this.btnJobNew.Text = "Create New";
            this.btnJobNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobNew.UseVisualStyleBackColor = true;
            this.btnJobNew.Click += new System.EventHandler(this.btnJobNew_Click);
            // 
            // btnDeleteAB
            // 
            this.btnDeleteAB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeleteAB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeleteAB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteAB.Image = global::AgOpenGPS.Properties.Resources.back_button;
            this.btnDeleteAB.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteAB.Location = new System.Drawing.Point(240, 494);
            this.btnDeleteAB.Name = "btnDeleteAB";
            this.btnDeleteAB.Size = new System.Drawing.Size(109, 85);
            this.btnDeleteAB.TabIndex = 4;
            this.btnDeleteAB.Text = "Go Back";
            this.btnDeleteAB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnJobResume
            // 
            this.btnJobResume.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.btnJobResume.Image = global::AgOpenGPS.Properties.Resources.FilePrevious;
            this.btnJobResume.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobResume.Location = new System.Drawing.Point(44, 84);
            this.btnJobResume.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobResume.Name = "btnJobResume";
            this.btnJobResume.Size = new System.Drawing.Size(305, 108);
            this.btnJobResume.TabIndex = 1;
            this.btnJobResume.Text = "Resume Last";
            this.btnJobResume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobResume.UseVisualStyleBackColor = true;
            this.btnJobResume.Click += new System.EventHandler(this.btnJobResume_Click);
            // 
            // lblResumeDirectory
            // 
            this.lblResumeDirectory.AutoSize = true;
            this.lblResumeDirectory.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblResumeDirectory.Location = new System.Drawing.Point(39, 34);
            this.lblResumeDirectory.Name = "lblResumeDirectory";
            this.lblResumeDirectory.Size = new System.Drawing.Size(68, 23);
            this.lblResumeDirectory.TabIndex = 5;
            this.lblResumeDirectory.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Underline);
            this.label1.Location = new System.Drawing.Point(40, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Previous Field:";
            // 
            // FormJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(400, 597);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblResumeDirectory);
            this.Controls.Add(this.btnDeleteAB);
            this.Controls.Add(this.btnJobResume);
            this.Controls.Add(this.btnJobNew);
            this.Controls.Add(this.btnJobOpen);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormJob";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Start a field";
            this.Load += new System.EventHandler(this.FormJob_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJobOpen;
        private System.Windows.Forms.Button btnJobNew;
        private System.Windows.Forms.Button btnJobResume;
        private System.Windows.Forms.Button btnDeleteAB;
        private System.Windows.Forms.Label lblResumeDirectory;
        private System.Windows.Forms.Label label1;
    }
}