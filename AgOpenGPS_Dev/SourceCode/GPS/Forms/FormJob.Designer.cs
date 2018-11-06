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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJob));
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
            resources.ApplyResources(this.btnJobOpen, "btnJobOpen");
            this.btnJobOpen.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.btnJobOpen.Name = "btnJobOpen";
            this.btnJobOpen.UseVisualStyleBackColor = true;
            this.btnJobOpen.Click += new System.EventHandler(this.btnJobOpen_Click);
            // 
            // btnJobNew
            // 
            resources.ApplyResources(this.btnJobNew, "btnJobNew");
            this.btnJobNew.Image = global::AgOpenGPS.Properties.Resources.FileNew;
            this.btnJobNew.Name = "btnJobNew";
            this.btnJobNew.UseVisualStyleBackColor = true;
            this.btnJobNew.Click += new System.EventHandler(this.btnJobNew_Click);
            // 
            // btnDeleteAB
            // 
            resources.ApplyResources(this.btnDeleteAB, "btnDeleteAB");
            this.btnDeleteAB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeleteAB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteAB.Image = global::AgOpenGPS.Properties.Resources.back_button;
            this.btnDeleteAB.Name = "btnDeleteAB";
            // 
            // btnJobResume
            // 
            resources.ApplyResources(this.btnJobResume, "btnJobResume");
            this.btnJobResume.Image = global::AgOpenGPS.Properties.Resources.FilePrevious;
            this.btnJobResume.Name = "btnJobResume";
            this.btnJobResume.UseVisualStyleBackColor = true;
            this.btnJobResume.Click += new System.EventHandler(this.btnJobResume_Click);
            // 
            // lblResumeDirectory
            // 
            resources.ApplyResources(this.lblResumeDirectory, "lblResumeDirectory");
            this.lblResumeDirectory.Name = "lblResumeDirectory";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // FormJob
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblResumeDirectory);
            this.Controls.Add(this.btnDeleteAB);
            this.Controls.Add(this.btnJobResume);
            this.Controls.Add(this.btnJobNew);
            this.Controls.Add(this.btnJobOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormJob";
            this.ShowIcon = false;
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