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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnInField = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFromKML = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnJobOpen
            // 
            this.btnJobOpen.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnJobOpen.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnJobOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobOpen.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.btnJobOpen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnJobOpen.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.btnJobOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobOpen.Location = new System.Drawing.Point(454, 205);
            this.btnJobOpen.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobOpen.Name = "btnJobOpen";
            this.btnJobOpen.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnJobOpen.Size = new System.Drawing.Size(268, 82);
            this.btnJobOpen.TabIndex = 3;
            this.btnJobOpen.Text = "Open";
            this.btnJobOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobOpen.UseVisualStyleBackColor = false;
            this.btnJobOpen.Click += new System.EventHandler(this.btnJobOpen_Click);
            // 
            // btnJobNew
            // 
            this.btnJobNew.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnJobNew.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnJobNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobNew.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.btnJobNew.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnJobNew.Image = global::AgOpenGPS.Properties.Resources.FileNew;
            this.btnJobNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobNew.Location = new System.Drawing.Point(34, 288);
            this.btnJobNew.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobNew.Name = "btnJobNew";
            this.btnJobNew.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnJobNew.Size = new System.Drawing.Size(268, 82);
            this.btnJobNew.TabIndex = 2;
            this.btnJobNew.Text = "New";
            this.btnJobNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobNew.UseVisualStyleBackColor = false;
            this.btnJobNew.Click += new System.EventHandler(this.btnJobNew_Click);
            // 
            // btnDeleteAB
            // 
            this.btnDeleteAB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnDeleteAB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeleteAB.FlatAppearance.BorderSize = 0;
            this.btnDeleteAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeleteAB.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteAB.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnDeleteAB.Location = new System.Drawing.Point(632, 319);
            this.btnDeleteAB.Name = "btnDeleteAB";
            this.btnDeleteAB.Size = new System.Drawing.Size(90, 64);
            this.btnDeleteAB.TabIndex = 4;
            this.btnDeleteAB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteAB.UseVisualStyleBackColor = false;
            // 
            // btnJobResume
            // 
            this.btnJobResume.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnJobResume.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnJobResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobResume.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.btnJobResume.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnJobResume.Image = global::AgOpenGPS.Properties.Resources.FilePrevious;
            this.btnJobResume.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobResume.Location = new System.Drawing.Point(454, 79);
            this.btnJobResume.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobResume.Name = "btnJobResume";
            this.btnJobResume.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnJobResume.Size = new System.Drawing.Size(268, 82);
            this.btnJobResume.TabIndex = 1;
            this.btnJobResume.Text = "Resume";
            this.btnJobResume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobResume.UseVisualStyleBackColor = false;
            this.btnJobResume.Click += new System.EventHandler(this.btnJobResume_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.Location = new System.Drawing.Point(454, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 50);
            this.textBox1.TabIndex = 88;
            this.textBox1.Text = "File name goes here\r\nSecond line";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnInField
            // 
            this.btnInField.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInField.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnInField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInField.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.btnInField.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnInField.Image = global::AgOpenGPS.Properties.Resources.AutoManualIsAuto;
            this.btnInField.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInField.Location = new System.Drawing.Point(34, 26);
            this.btnInField.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnInField.Name = "btnInField";
            this.btnInField.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnInField.Size = new System.Drawing.Size(268, 82);
            this.btnInField.TabIndex = 89;
            this.btnInField.Text = "Drive In";
            this.btnInField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInField.UseVisualStyleBackColor = false;
            this.btnInField.Click += new System.EventHandler(this.btnInField_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.btnJobNew);
            this.panel1.Controls.Add(this.btnInField);
            this.panel1.Controls.Add(this.btnJobResume);
            this.panel1.Controls.Add(this.btnJobOpen);
            this.panel1.Controls.Add(this.btnFromKML);
            this.panel1.Controls.Add(this.btnDeleteAB);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 391);
            this.panel1.TabIndex = 90;
            // 
            // btnFromKML
            // 
            this.btnFromKML.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFromKML.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFromKML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromKML.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.btnFromKML.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFromKML.Image = global::AgOpenGPS.Properties.Resources.BoundaryLoadFromGE;
            this.btnFromKML.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFromKML.Location = new System.Drawing.Point(34, 157);
            this.btnFromKML.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnFromKML.Name = "btnFromKML";
            this.btnFromKML.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFromKML.Size = new System.Drawing.Size(268, 82);
            this.btnFromKML.TabIndex = 91;
            this.btnFromKML.Text = "From KML";
            this.btnFromKML.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFromKML.UseVisualStyleBackColor = false;
            this.btnFromKML.Click += new System.EventHandler(this.btnFromKML_Click);
            // 
            // FormJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(747, 399);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormJob";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Start a field";
            this.Load += new System.EventHandler(this.FormJob_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnJobOpen;
        private System.Windows.Forms.Button btnJobNew;
        private System.Windows.Forms.Button btnJobResume;
        private System.Windows.Forms.Button btnDeleteAB;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnInField;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFromKML;
    }
}