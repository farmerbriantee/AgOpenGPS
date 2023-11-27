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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeleteAB = new System.Windows.Forms.Button();
            this.btnJobClose = new AgOpenGPS.RJButton();
            this.btnJobOpen = new AgOpenGPS.RJButton();
            this.btnHeadlandBuild = new AgOpenGPS.RJButton();
            this.btnHeadlandSlice = new AgOpenGPS.RJButton();
            this.btnTramline = new AgOpenGPS.RJButton();
            this.btnBoundary = new AgOpenGPS.RJButton();
            this.btnJobResume = new AgOpenGPS.RJButton();
            this.btnFromExisting = new AgOpenGPS.RJButton();
            this.btnJobNew = new AgOpenGPS.RJButton();
            this.btnFromKML = new AgOpenGPS.RJButton();
            this.btnInField = new AgOpenGPS.RJButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.Location = new System.Drawing.Point(436, 301);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 82);
            this.textBox1.TabIndex = 88;
            this.textBox1.Text = "Field To Resume";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.btnJobClose);
            this.panel1.Controls.Add(this.btnJobOpen);
            this.panel1.Controls.Add(this.btnHeadlandBuild);
            this.panel1.Controls.Add(this.btnHeadlandSlice);
            this.panel1.Controls.Add(this.btnTramline);
            this.panel1.Controls.Add(this.btnBoundary);
            this.panel1.Controls.Add(this.btnJobResume);
            this.panel1.Controls.Add(this.btnFromExisting);
            this.panel1.Controls.Add(this.btnJobNew);
            this.panel1.Controls.Add(this.btnFromKML);
            this.panel1.Controls.Add(this.btnInField);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnDeleteAB);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 719);
            this.panel1.TabIndex = 90;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Cyan;
            this.panel2.Location = new System.Drawing.Point(11, 410);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(941, 6);
            this.panel2.TabIndex = 106;
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
            this.btnDeleteAB.Location = new System.Drawing.Point(854, 623);
            this.btnDeleteAB.Name = "btnDeleteAB";
            this.btnDeleteAB.Size = new System.Drawing.Size(90, 64);
            this.btnDeleteAB.TabIndex = 4;
            this.btnDeleteAB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteAB.UseVisualStyleBackColor = false;
            // 
            // btnJobClose
            // 
            this.btnJobClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobClose.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobClose.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnJobClose.BorderRadius = 15;
            this.btnJobClose.BorderSize = 2;
            this.btnJobClose.FlatAppearance.BorderSize = 0;
            this.btnJobClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobClose.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobClose.ForeColor = System.Drawing.Color.Black;
            this.btnJobClose.Image = global::AgOpenGPS.Properties.Resources.FileClose;
            this.btnJobClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobClose.Location = new System.Drawing.Point(699, 38);
            this.btnJobClose.Name = "btnJobClose";
            this.btnJobClose.Size = new System.Drawing.Size(245, 82);
            this.btnJobClose.TabIndex = 538;
            this.btnJobClose.Text = "Close";
            this.btnJobClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobClose.TextColor = System.Drawing.Color.Black;
            this.btnJobClose.UseVisualStyleBackColor = false;
            this.btnJobClose.Click += new System.EventHandler(this.btnJobClose_Click);
            // 
            // btnJobOpen
            // 
            this.btnJobOpen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobOpen.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobOpen.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnJobOpen.BorderRadius = 15;
            this.btnJobOpen.BorderSize = 2;
            this.btnJobOpen.FlatAppearance.BorderSize = 0;
            this.btnJobOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobOpen.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobOpen.ForeColor = System.Drawing.Color.Black;
            this.btnJobOpen.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.btnJobOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobOpen.Location = new System.Drawing.Point(699, 168);
            this.btnJobOpen.Name = "btnJobOpen";
            this.btnJobOpen.Size = new System.Drawing.Size(245, 82);
            this.btnJobOpen.TabIndex = 538;
            this.btnJobOpen.Text = "Open";
            this.btnJobOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobOpen.TextColor = System.Drawing.Color.Black;
            this.btnJobOpen.UseVisualStyleBackColor = false;
            this.btnJobOpen.Click += new System.EventHandler(this.btnJobOpen_Click);
            // 
            // btnHeadlandBuild
            // 
            this.btnHeadlandBuild.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnHeadlandBuild.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnHeadlandBuild.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnHeadlandBuild.BorderRadius = 15;
            this.btnHeadlandBuild.BorderSize = 2;
            this.btnHeadlandBuild.Enabled = false;
            this.btnHeadlandBuild.FlatAppearance.BorderSize = 0;
            this.btnHeadlandBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeadlandBuild.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeadlandBuild.ForeColor = System.Drawing.Color.Black;
            this.btnHeadlandBuild.Image = global::AgOpenGPS.Properties.Resources.ABBndLines;
            this.btnHeadlandBuild.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHeadlandBuild.Location = new System.Drawing.Point(35, 577);
            this.btnHeadlandBuild.Name = "btnHeadlandBuild";
            this.btnHeadlandBuild.Size = new System.Drawing.Size(281, 96);
            this.btnHeadlandBuild.TabIndex = 538;
            this.btnHeadlandBuild.Text = "Headland\r\nBuild";
            this.btnHeadlandBuild.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHeadlandBuild.TextColor = System.Drawing.Color.Black;
            this.btnHeadlandBuild.UseVisualStyleBackColor = false;
            // 
            // btnHeadlandSlice
            // 
            this.btnHeadlandSlice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnHeadlandSlice.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnHeadlandSlice.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnHeadlandSlice.BorderRadius = 15;
            this.btnHeadlandSlice.BorderSize = 2;
            this.btnHeadlandSlice.Enabled = false;
            this.btnHeadlandSlice.FlatAppearance.BorderSize = 0;
            this.btnHeadlandSlice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeadlandSlice.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeadlandSlice.ForeColor = System.Drawing.Color.Black;
            this.btnHeadlandSlice.Image = global::AgOpenGPS.Properties.Resources.HeadlandSlice;
            this.btnHeadlandSlice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHeadlandSlice.Location = new System.Drawing.Point(35, 448);
            this.btnHeadlandSlice.Name = "btnHeadlandSlice";
            this.btnHeadlandSlice.Size = new System.Drawing.Size(281, 96);
            this.btnHeadlandSlice.TabIndex = 538;
            this.btnHeadlandSlice.Text = "Headland\r\nSlice";
            this.btnHeadlandSlice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHeadlandSlice.TextColor = System.Drawing.Color.Black;
            this.btnHeadlandSlice.UseVisualStyleBackColor = false;
            // 
            // btnTramline
            // 
            this.btnTramline.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTramline.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnTramline.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnTramline.BorderRadius = 15;
            this.btnTramline.BorderSize = 2;
            this.btnTramline.Enabled = false;
            this.btnTramline.FlatAppearance.BorderSize = 0;
            this.btnTramline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTramline.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTramline.ForeColor = System.Drawing.Color.Black;
            this.btnTramline.Image = global::AgOpenGPS.Properties.Resources.TramAll;
            this.btnTramline.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTramline.Location = new System.Drawing.Point(395, 448);
            this.btnTramline.Name = "btnTramline";
            this.btnTramline.Size = new System.Drawing.Size(281, 96);
            this.btnTramline.TabIndex = 538;
            this.btnTramline.Text = "Tramline";
            this.btnTramline.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTramline.TextColor = System.Drawing.Color.Black;
            this.btnTramline.UseVisualStyleBackColor = false;
            // 
            // btnBoundary
            // 
            this.btnBoundary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBoundary.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnBoundary.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnBoundary.BorderRadius = 15;
            this.btnBoundary.BorderSize = 2;
            this.btnBoundary.Enabled = false;
            this.btnBoundary.FlatAppearance.BorderSize = 0;
            this.btnBoundary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoundary.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoundary.ForeColor = System.Drawing.Color.Black;
            this.btnBoundary.Image = global::AgOpenGPS.Properties.Resources.Boundary;
            this.btnBoundary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoundary.Location = new System.Drawing.Point(395, 577);
            this.btnBoundary.Name = "btnBoundary";
            this.btnBoundary.Size = new System.Drawing.Size(281, 96);
            this.btnBoundary.TabIndex = 538;
            this.btnBoundary.Text = "Boundary";
            this.btnBoundary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBoundary.TextColor = System.Drawing.Color.Black;
            this.btnBoundary.UseVisualStyleBackColor = false;
            // 
            // btnJobResume
            // 
            this.btnJobResume.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobResume.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobResume.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnJobResume.BorderRadius = 15;
            this.btnJobResume.BorderSize = 2;
            this.btnJobResume.FlatAppearance.BorderSize = 0;
            this.btnJobResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobResume.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobResume.ForeColor = System.Drawing.Color.Black;
            this.btnJobResume.Image = global::AgOpenGPS.Properties.Resources.FilePrevious;
            this.btnJobResume.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobResume.Location = new System.Drawing.Point(699, 301);
            this.btnJobResume.Name = "btnJobResume";
            this.btnJobResume.Size = new System.Drawing.Size(245, 82);
            this.btnJobResume.TabIndex = 538;
            this.btnJobResume.Text = "Resume";
            this.btnJobResume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobResume.TextColor = System.Drawing.Color.Black;
            this.btnJobResume.UseVisualStyleBackColor = false;
            this.btnJobResume.Click += new System.EventHandler(this.btnJobResume_Click);
            // 
            // btnFromExisting
            // 
            this.btnFromExisting.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromExisting.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromExisting.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnFromExisting.BorderRadius = 15;
            this.btnFromExisting.BorderSize = 2;
            this.btnFromExisting.FlatAppearance.BorderSize = 0;
            this.btnFromExisting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromExisting.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFromExisting.ForeColor = System.Drawing.Color.Black;
            this.btnFromExisting.Image = global::AgOpenGPS.Properties.Resources.FileExisting;
            this.btnFromExisting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFromExisting.Location = new System.Drawing.Point(367, 38);
            this.btnFromExisting.Name = "btnFromExisting";
            this.btnFromExisting.Size = new System.Drawing.Size(245, 82);
            this.btnFromExisting.TabIndex = 538;
            this.btnFromExisting.Text = "From Existing";
            this.btnFromExisting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFromExisting.TextColor = System.Drawing.Color.Black;
            this.btnFromExisting.UseVisualStyleBackColor = false;
            this.btnFromExisting.Click += new System.EventHandler(this.btnFromExisting_Click);
            // 
            // btnJobNew
            // 
            this.btnJobNew.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobNew.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobNew.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnJobNew.BorderRadius = 15;
            this.btnJobNew.BorderSize = 2;
            this.btnJobNew.FlatAppearance.BorderSize = 0;
            this.btnJobNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobNew.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobNew.ForeColor = System.Drawing.Color.Black;
            this.btnJobNew.Image = global::AgOpenGPS.Properties.Resources.FileNew;
            this.btnJobNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobNew.Location = new System.Drawing.Point(367, 168);
            this.btnJobNew.Name = "btnJobNew";
            this.btnJobNew.Size = new System.Drawing.Size(245, 82);
            this.btnJobNew.TabIndex = 538;
            this.btnJobNew.Text = "New";
            this.btnJobNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobNew.TextColor = System.Drawing.Color.Black;
            this.btnJobNew.UseVisualStyleBackColor = false;
            this.btnJobNew.Click += new System.EventHandler(this.btnJobNew_Click);
            // 
            // btnFromKML
            // 
            this.btnFromKML.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromKML.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromKML.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnFromKML.BorderRadius = 15;
            this.btnFromKML.BorderSize = 2;
            this.btnFromKML.FlatAppearance.BorderSize = 0;
            this.btnFromKML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromKML.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFromKML.ForeColor = System.Drawing.Color.Black;
            this.btnFromKML.Image = global::AgOpenGPS.Properties.Resources.BoundaryLoadFromGE;
            this.btnFromKML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFromKML.Location = new System.Drawing.Point(35, 168);
            this.btnFromKML.Name = "btnFromKML";
            this.btnFromKML.Size = new System.Drawing.Size(245, 82);
            this.btnFromKML.TabIndex = 538;
            this.btnFromKML.Text = "From KML";
            this.btnFromKML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFromKML.TextColor = System.Drawing.Color.Black;
            this.btnFromKML.UseVisualStyleBackColor = false;
            this.btnFromKML.Click += new System.EventHandler(this.btnFromKML_Click);
            // 
            // btnInField
            // 
            this.btnInField.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnInField.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnInField.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnInField.BorderRadius = 15;
            this.btnInField.BorderSize = 2;
            this.btnInField.FlatAppearance.BorderSize = 0;
            this.btnInField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInField.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInField.ForeColor = System.Drawing.Color.Black;
            this.btnInField.Image = global::AgOpenGPS.Properties.Resources.AutoManualIsAuto;
            this.btnInField.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInField.Location = new System.Drawing.Point(35, 38);
            this.btnInField.Name = "btnInField";
            this.btnInField.Size = new System.Drawing.Size(245, 82);
            this.btnInField.TabIndex = 537;
            this.btnInField.Text = "Drive In";
            this.btnInField.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInField.TextColor = System.Drawing.Color.Black;
            this.btnInField.UseVisualStyleBackColor = false;
            this.btnInField.Click += new System.EventHandler(this.btnInField_Click);
            // 
            // FormJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(975, 727);
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
        private System.Windows.Forms.Button btnDeleteAB;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private RJButton btnInField;
        private RJButton btnJobNew;
        private RJButton btnFromKML;
        private RJButton btnJobClose;
        private RJButton btnJobResume;
        private RJButton btnFromExisting;
        private RJButton btnJobOpen;
        private RJButton btnBoundary;
        private RJButton btnHeadlandBuild;
        private RJButton btnHeadlandSlice;
        private RJButton btnTramline;
    }
}