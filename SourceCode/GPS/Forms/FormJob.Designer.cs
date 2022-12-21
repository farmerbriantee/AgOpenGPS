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
            this.lblLatitude = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFixQuality = new System.Windows.Forms.Label();
            this.lblSatsTracked = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.btnJobOpen.Location = new System.Drawing.Point(454, 259);
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
            this.btnJobNew.Location = new System.Drawing.Point(34, 342);
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
            this.btnDeleteAB.Location = new System.Drawing.Point(632, 373);
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
            this.btnJobResume.Location = new System.Drawing.Point(454, 133);
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
            this.textBox1.Location = new System.Drawing.Point(454, 81);
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
            this.btnInField.Location = new System.Drawing.Point(34, 80);
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
            this.panel1.Controls.Add(this.lblSatsTracked);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblAltitude);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblFixQuality);
            this.panel1.Controls.Add(this.lblLatitude);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblLongitude);
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
            this.panel1.Size = new System.Drawing.Size(759, 450);
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
            this.btnFromKML.Location = new System.Drawing.Point(34, 211);
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
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.ForeColor = System.Drawing.Color.White;
            this.lblLatitude.Location = new System.Drawing.Point(67, 44);
            this.lblLatitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(70, 18);
            this.lblLatitude.TabIndex = 93;
            this.lblLatitude.Text = "Latitude";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(38, 44);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 18);
            this.label6.TabIndex = 92;
            this.label6.Text = "Lat";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(35, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 18);
            this.label7.TabIndex = 95;
            this.label7.Text = "Lon";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.ForeColor = System.Drawing.Color.White;
            this.lblLongitude.Location = new System.Drawing.Point(67, 20);
            this.lblLongitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(82, 18);
            this.lblLongitude.TabIndex = 94;
            this.lblLongitude.Text = "Longitude";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(212, 44);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 18);
            this.label8.TabIndex = 99;
            this.label8.Text = "Alt";
            // 
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.BackColor = System.Drawing.Color.Transparent;
            this.lblAltitude.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltitude.ForeColor = System.Drawing.Color.White;
            this.lblAltitude.Location = new System.Drawing.Point(236, 44);
            this.lblAltitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(67, 18);
            this.lblAltitude.TabIndex = 98;
            this.lblAltitude.Text = "Altitude";
            this.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(184, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 97;
            this.label2.Text = "Quality";
            // 
            // lblFixQuality
            // 
            this.lblFixQuality.AutoSize = true;
            this.lblFixQuality.BackColor = System.Drawing.Color.Transparent;
            this.lblFixQuality.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixQuality.ForeColor = System.Drawing.Color.White;
            this.lblFixQuality.Location = new System.Drawing.Point(236, 20);
            this.lblFixQuality.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFixQuality.Name = "lblFixQuality";
            this.lblFixQuality.Size = new System.Drawing.Size(66, 18);
            this.lblFixQuality.TabIndex = 96;
            this.lblFixQuality.Text = "FixQual";
            this.lblFixQuality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSatsTracked
            // 
            this.lblSatsTracked.AutoSize = true;
            this.lblSatsTracked.BackColor = System.Drawing.Color.Transparent;
            this.lblSatsTracked.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatsTracked.ForeColor = System.Drawing.Color.White;
            this.lblSatsTracked.Location = new System.Drawing.Point(393, 44);
            this.lblSatsTracked.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSatsTracked.Name = "lblSatsTracked";
            this.lblSatsTracked.Size = new System.Drawing.Size(41, 18);
            this.lblSatsTracked.TabIndex = 101;
            this.lblSatsTracked.Text = "Sats";
            this.lblSatsTracked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(341, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 18);
            this.label3.TabIndex = 103;
            this.label3.Text = "# Sats";
            // 
            // FormJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(767, 458);
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
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFixQuality;
        private System.Windows.Forms.Label lblSatsTracked;
        private System.Windows.Forms.Label label3;
    }
}