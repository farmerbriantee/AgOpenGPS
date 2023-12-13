namespace AgOpenGPS
{
    partial class FormMenuJob
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFromKML = new AgOpenGPS.RJButton();
            this.btnDeleteAB = new System.Windows.Forms.Button();
            this.btnJobResume = new AgOpenGPS.RJButton();
            this.btnJobClose = new AgOpenGPS.RJButton();
            this.btnJobOpen = new AgOpenGPS.RJButton();
            this.btnJobNew = new AgOpenGPS.RJButton();
            this.btnFromISOXML = new AgOpenGPS.RJButton();
            this.btnInField = new AgOpenGPS.RJButton();
            this.btnFromExisting = new AgOpenGPS.RJButton();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.Location = new System.Drawing.Point(348, 46);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(341, 58);
            this.textBox1.TabIndex = 88;
            this.textBox1.Text = "Field To Resume\r\nGoes here";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 535);
            this.panel1.TabIndex = 90;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel1.Controls.Add(this.btnFromKML, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnJobResume, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnJobClose, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnJobOpen, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnJobNew, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnFromISOXML, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInField, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnFromExisting, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteAB, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(692, 535);
            this.tableLayoutPanel1.TabIndex = 539;
            // 
            // btnFromKML
            // 
            this.btnFromKML.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFromKML.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromKML.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromKML.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnFromKML.BorderRadius = 10;
            this.btnFromKML.BorderSize = 2;
            this.btnFromKML.FlatAppearance.BorderSize = 0;
            this.btnFromKML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromKML.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFromKML.ForeColor = System.Drawing.Color.Black;
            this.btnFromKML.Image = global::AgOpenGPS.Properties.Resources.BoundaryLoadFromGE;
            this.btnFromKML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFromKML.Location = new System.Drawing.Point(47, 125);
            this.btnFromKML.Name = "btnFromKML";
            this.btnFromKML.Size = new System.Drawing.Size(250, 70);
            this.btnFromKML.TabIndex = 538;
            this.btnFromKML.Text = "From KML";
            this.btnFromKML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFromKML.TextColor = System.Drawing.Color.Black;
            this.btnFromKML.UseVisualStyleBackColor = false;
            this.btnFromKML.Click += new System.EventHandler(this.btnFromKML_Click);
            // 
            // btnDeleteAB
            // 
            this.btnDeleteAB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.btnDeleteAB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeleteAB.FlatAppearance.BorderSize = 0;
            this.btnDeleteAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeleteAB.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteAB.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnDeleteAB.Location = new System.Drawing.Point(495, 454);
            this.btnDeleteAB.Name = "btnDeleteAB";
            this.btnDeleteAB.Size = new System.Drawing.Size(194, 78);
            this.btnDeleteAB.TabIndex = 4;
            this.btnDeleteAB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteAB.UseVisualStyleBackColor = false;
            // 
            // btnJobResume
            // 
            this.btnJobResume.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnJobResume.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobResume.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobResume.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnJobResume.BorderRadius = 10;
            this.btnJobResume.BorderSize = 2;
            this.btnJobResume.FlatAppearance.BorderSize = 0;
            this.btnJobResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobResume.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobResume.ForeColor = System.Drawing.Color.Black;
            this.btnJobResume.Image = global::AgOpenGPS.Properties.Resources.FilePrevious;
            this.btnJobResume.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobResume.Location = new System.Drawing.Point(393, 125);
            this.btnJobResume.Name = "btnJobResume";
            this.btnJobResume.Size = new System.Drawing.Size(250, 70);
            this.btnJobResume.TabIndex = 538;
            this.btnJobResume.Text = "Resume";
            this.btnJobResume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobResume.TextColor = System.Drawing.Color.Black;
            this.btnJobResume.UseVisualStyleBackColor = false;
            this.btnJobResume.Click += new System.EventHandler(this.btnJobResume_Click);
            // 
            // btnJobClose
            // 
            this.btnJobClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnJobClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobClose.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobClose.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnJobClose.BorderRadius = 10;
            this.btnJobClose.BorderSize = 2;
            this.btnJobClose.FlatAppearance.BorderSize = 0;
            this.btnJobClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobClose.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobClose.ForeColor = System.Drawing.Color.Black;
            this.btnJobClose.Image = global::AgOpenGPS.Properties.Resources.FileClose;
            this.btnJobClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobClose.Location = new System.Drawing.Point(393, 232);
            this.btnJobClose.Name = "btnJobClose";
            this.btnJobClose.Size = new System.Drawing.Size(250, 70);
            this.btnJobClose.TabIndex = 538;
            this.btnJobClose.Text = "Close";
            this.btnJobClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobClose.TextColor = System.Drawing.Color.Black;
            this.btnJobClose.UseVisualStyleBackColor = false;
            this.btnJobClose.Click += new System.EventHandler(this.btnJobClose_Click);
            // 
            // btnJobOpen
            // 
            this.btnJobOpen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnJobOpen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobOpen.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobOpen.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnJobOpen.BorderRadius = 10;
            this.btnJobOpen.BorderSize = 2;
            this.btnJobOpen.FlatAppearance.BorderSize = 0;
            this.btnJobOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobOpen.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobOpen.ForeColor = System.Drawing.Color.Black;
            this.btnJobOpen.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.btnJobOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobOpen.Location = new System.Drawing.Point(393, 339);
            this.btnJobOpen.Name = "btnJobOpen";
            this.btnJobOpen.Size = new System.Drawing.Size(250, 70);
            this.btnJobOpen.TabIndex = 538;
            this.btnJobOpen.Text = "Open";
            this.btnJobOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobOpen.TextColor = System.Drawing.Color.Black;
            this.btnJobOpen.UseVisualStyleBackColor = false;
            this.btnJobOpen.Click += new System.EventHandler(this.btnJobOpen_Click);
            // 
            // btnJobNew
            // 
            this.btnJobNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnJobNew.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobNew.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnJobNew.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnJobNew.BorderRadius = 10;
            this.btnJobNew.BorderSize = 2;
            this.btnJobNew.FlatAppearance.BorderSize = 0;
            this.btnJobNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobNew.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobNew.ForeColor = System.Drawing.Color.Black;
            this.btnJobNew.Image = global::AgOpenGPS.Properties.Resources.FileNew;
            this.btnJobNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobNew.Location = new System.Drawing.Point(47, 446);
            this.btnJobNew.Name = "btnJobNew";
            this.btnJobNew.Size = new System.Drawing.Size(250, 70);
            this.btnJobNew.TabIndex = 538;
            this.btnJobNew.Text = "New";
            this.btnJobNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobNew.TextColor = System.Drawing.Color.Black;
            this.btnJobNew.UseVisualStyleBackColor = false;
            this.btnJobNew.Click += new System.EventHandler(this.btnJobNew_Click);
            // 
            // btnFromISOXML
            // 
            this.btnFromISOXML.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFromISOXML.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromISOXML.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromISOXML.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnFromISOXML.BorderRadius = 10;
            this.btnFromISOXML.BorderSize = 2;
            this.btnFromISOXML.FlatAppearance.BorderSize = 0;
            this.btnFromISOXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromISOXML.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFromISOXML.ForeColor = System.Drawing.Color.Black;
            this.btnFromISOXML.Image = global::AgOpenGPS.Properties.Resources.ISOXML;
            this.btnFromISOXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFromISOXML.Location = new System.Drawing.Point(47, 18);
            this.btnFromISOXML.Name = "btnFromISOXML";
            this.btnFromISOXML.Size = new System.Drawing.Size(250, 70);
            this.btnFromISOXML.TabIndex = 539;
            this.btnFromISOXML.Text = "From ISOXML";
            this.btnFromISOXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFromISOXML.TextColor = System.Drawing.Color.Black;
            this.btnFromISOXML.UseVisualStyleBackColor = false;
            // 
            // btnInField
            // 
            this.btnInField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInField.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnInField.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnInField.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnInField.BorderRadius = 10;
            this.btnInField.BorderSize = 2;
            this.btnInField.FlatAppearance.BorderSize = 0;
            this.btnInField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInField.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInField.ForeColor = System.Drawing.Color.Black;
            this.btnInField.Image = global::AgOpenGPS.Properties.Resources.AutoManualIsAuto;
            this.btnInField.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInField.Location = new System.Drawing.Point(47, 339);
            this.btnInField.Name = "btnInField";
            this.btnInField.Size = new System.Drawing.Size(250, 70);
            this.btnInField.TabIndex = 537;
            this.btnInField.Text = "Drive In";
            this.btnInField.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInField.TextColor = System.Drawing.Color.Black;
            this.btnInField.UseVisualStyleBackColor = false;
            this.btnInField.Click += new System.EventHandler(this.btnInField_Click);
            // 
            // btnFromExisting
            // 
            this.btnFromExisting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFromExisting.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromExisting.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromExisting.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnFromExisting.BorderRadius = 10;
            this.btnFromExisting.BorderSize = 2;
            this.btnFromExisting.FlatAppearance.BorderSize = 0;
            this.btnFromExisting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromExisting.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFromExisting.ForeColor = System.Drawing.Color.Black;
            this.btnFromExisting.Image = global::AgOpenGPS.Properties.Resources.FileExisting;
            this.btnFromExisting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFromExisting.Location = new System.Drawing.Point(47, 232);
            this.btnFromExisting.Name = "btnFromExisting";
            this.btnFromExisting.Size = new System.Drawing.Size(250, 70);
            this.btnFromExisting.TabIndex = 538;
            this.btnFromExisting.Text = "From Existing";
            this.btnFromExisting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFromExisting.TextColor = System.Drawing.Color.Black;
            this.btnFromExisting.UseVisualStyleBackColor = false;
            this.btnFromExisting.Click += new System.EventHandler(this.btnFromExisting_Click);
            // 
            // FormMenuJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(700, 543);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 460);
            this.Name = "FormMenuJob";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Start a field";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormJob_FormClosing);
            this.Load += new System.EventHandler(this.FormJob_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDeleteAB;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private RJButton btnInField;
        private RJButton btnJobNew;
        private RJButton btnFromKML;
        private RJButton btnJobClose;
        private RJButton btnJobResume;
        private RJButton btnFromExisting;
        private RJButton btnJobOpen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RJButton btnFromISOXML;
    }
}