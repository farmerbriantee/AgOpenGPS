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
            this.SuspendLayout();
            // 
            // btnJobOpen
            // 
            this.btnJobOpen.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobOpen.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.btnJobOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobOpen.Location = new System.Drawing.Point(24, 211);
            this.btnJobOpen.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobOpen.Name = "btnJobOpen";
            this.btnJobOpen.Size = new System.Drawing.Size(205, 70);
            this.btnJobOpen.TabIndex = 58;
            this.btnJobOpen.Text = "Open  ";
            this.btnJobOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobOpen.UseVisualStyleBackColor = true;
            this.btnJobOpen.Click += new System.EventHandler(this.btnJobOpen_Click);
            // 
            // btnJobNew
            // 
            this.btnJobNew.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobNew.Image = global::AgOpenGPS.Properties.Resources.FileNew;
            this.btnJobNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobNew.Location = new System.Drawing.Point(24, 112);
            this.btnJobNew.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobNew.Name = "btnJobNew";
            this.btnJobNew.Size = new System.Drawing.Size(205, 70);
            this.btnJobNew.TabIndex = 59;
            this.btnJobNew.Text = "New  ";
            this.btnJobNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobNew.UseVisualStyleBackColor = true;
            this.btnJobNew.Click += new System.EventHandler(this.btnJobNew_Click);
            // 
            // btnDeleteAB
            // 
            this.btnDeleteAB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeleteAB.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteAB.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnDeleteAB.Location = new System.Drawing.Point(120, 311);
            this.btnDeleteAB.Name = "btnDeleteAB";
            this.btnDeleteAB.Size = new System.Drawing.Size(109, 62);
            this.btnDeleteAB.TabIndex = 62;
            this.btnDeleteAB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnJobResume
            // 
            this.btnJobResume.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobResume.Image = global::AgOpenGPS.Properties.Resources.FilePrevious;
            this.btnJobResume.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobResume.Location = new System.Drawing.Point(24, 13);
            this.btnJobResume.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobResume.Name = "btnJobResume";
            this.btnJobResume.Size = new System.Drawing.Size(205, 70);
            this.btnJobResume.TabIndex = 60;
            this.btnJobResume.Text = "Resume";
            this.btnJobResume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobResume.UseVisualStyleBackColor = true;
            this.btnJobResume.Click += new System.EventHandler(this.btnJobResume_Click);
            // 
            // FormJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(255, 390);
            this.Controls.Add(this.btnDeleteAB);
            this.Controls.Add(this.btnJobResume);
            this.Controls.Add(this.btnJobNew);
            this.Controls.Add(this.btnJobOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormJob";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Start a field";
            this.Load += new System.EventHandler(this.FormJob_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnJobOpen;
        private System.Windows.Forms.Button btnJobNew;
        private System.Windows.Forms.Button btnJobResume;
        private System.Windows.Forms.Button btnDeleteAB;
    }
}