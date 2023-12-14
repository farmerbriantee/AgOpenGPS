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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnJobOpen = new System.Windows.Forms.Button();
            this.btnDeleteAB = new System.Windows.Forms.Button();
            this.btnJobClose = new System.Windows.Forms.Button();
            this.btnJobResume = new System.Windows.Forms.Button();
            this.btnInField = new System.Windows.Forms.Button();
            this.lblResumeField = new System.Windows.Forms.Label();
            this.btnFromExisting = new System.Windows.Forms.Button();
            this.btnFromKML = new System.Windows.Forms.Button();
            this.btnFromISOXML = new System.Windows.Forms.Button();
            this.btnJobNew = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 554);
            this.panel1.TabIndex = 90;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnJobOpen, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnJobClose, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnJobResume, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblResumeField, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFromExisting, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnJobNew, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnInField, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnFromKML, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnFromISOXML, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteAB, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(731, 554);
            this.tableLayoutPanel1.TabIndex = 106;
            // 
            // btnJobOpen
            // 
            this.btnJobOpen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnJobOpen.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnJobOpen.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnJobOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobOpen.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobOpen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnJobOpen.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.btnJobOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobOpen.Location = new System.Drawing.Point(406, 349);
            this.btnJobOpen.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobOpen.Name = "btnJobOpen";
            this.btnJobOpen.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnJobOpen.Size = new System.Drawing.Size(296, 71);
            this.btnJobOpen.TabIndex = 3;
            this.btnJobOpen.Text = "Open";
            this.btnJobOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobOpen.UseVisualStyleBackColor = false;
            this.btnJobOpen.Click += new System.EventHandler(this.btnJobOpen_Click);
            // 
            // btnDeleteAB
            // 
            this.btnDeleteAB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAB.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteAB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeleteAB.FlatAppearance.BorderSize = 0;
            this.btnDeleteAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeleteAB.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteAB.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnDeleteAB.Location = new System.Drawing.Point(599, 461);
            this.btnDeleteAB.Name = "btnDeleteAB";
            this.btnDeleteAB.Size = new System.Drawing.Size(129, 90);
            this.btnDeleteAB.TabIndex = 4;
            this.btnDeleteAB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteAB.UseVisualStyleBackColor = false;
            // 
            // btnJobClose
            // 
            this.btnJobClose.AllowDrop = true;
            this.btnJobClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnJobClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnJobClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnJobClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobClose.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnJobClose.Image = global::AgOpenGPS.Properties.Resources.FileClose;
            this.btnJobClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobClose.Location = new System.Drawing.Point(406, 239);
            this.btnJobClose.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobClose.Name = "btnJobClose";
            this.btnJobClose.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnJobClose.Size = new System.Drawing.Size(296, 71);
            this.btnJobClose.TabIndex = 105;
            this.btnJobClose.Text = "Close";
            this.btnJobClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobClose.UseVisualStyleBackColor = false;
            this.btnJobClose.Click += new System.EventHandler(this.btnJobClose_Click);
            // 
            // btnJobResume
            // 
            this.btnJobResume.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnJobResume.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnJobResume.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnJobResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobResume.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobResume.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnJobResume.Image = global::AgOpenGPS.Properties.Resources.FilePrevious;
            this.btnJobResume.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobResume.Location = new System.Drawing.Point(406, 129);
            this.btnJobResume.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobResume.Name = "btnJobResume";
            this.btnJobResume.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnJobResume.Size = new System.Drawing.Size(296, 71);
            this.btnJobResume.TabIndex = 1;
            this.btnJobResume.Text = "Resume";
            this.btnJobResume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobResume.UseVisualStyleBackColor = false;
            this.btnJobResume.Click += new System.EventHandler(this.btnJobResume_Click);
            // 
            // btnInField
            // 
            this.btnInField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInField.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInField.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnInField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInField.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInField.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnInField.Image = global::AgOpenGPS.Properties.Resources.AutoManualIsAuto;
            this.btnInField.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInField.Location = new System.Drawing.Point(29, 239);
            this.btnInField.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnInField.Name = "btnInField";
            this.btnInField.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnInField.Size = new System.Drawing.Size(296, 71);
            this.btnInField.TabIndex = 89;
            this.btnInField.Text = "Drive In";
            this.btnInField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInField.UseVisualStyleBackColor = false;
            this.btnInField.Click += new System.EventHandler(this.btnInField_Click);
            // 
            // lblResumeField
            // 
            this.lblResumeField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResumeField.ForeColor = System.Drawing.Color.White;
            this.lblResumeField.Location = new System.Drawing.Point(380, 0);
            this.lblResumeField.Name = "lblResumeField";
            this.lblResumeField.Size = new System.Drawing.Size(348, 110);
            this.lblResumeField.TabIndex = 106;
            this.lblResumeField.Text = "label1";
            this.lblResumeField.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnFromExisting
            // 
            this.btnFromExisting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFromExisting.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFromExisting.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFromExisting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromExisting.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFromExisting.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFromExisting.Image = global::AgOpenGPS.Properties.Resources.FileExisting;
            this.btnFromExisting.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFromExisting.Location = new System.Drawing.Point(29, 349);
            this.btnFromExisting.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnFromExisting.Name = "btnFromExisting";
            this.btnFromExisting.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFromExisting.Size = new System.Drawing.Size(296, 71);
            this.btnFromExisting.TabIndex = 104;
            this.btnFromExisting.Text = "From Existing";
            this.btnFromExisting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFromExisting.UseVisualStyleBackColor = false;
            this.btnFromExisting.Click += new System.EventHandler(this.btnFromExisting_Click);
            // 
            // btnFromKML
            // 
            this.btnFromKML.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFromKML.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFromKML.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFromKML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromKML.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFromKML.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFromKML.Image = global::AgOpenGPS.Properties.Resources.BoundaryLoadFromGE;
            this.btnFromKML.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFromKML.Location = new System.Drawing.Point(29, 129);
            this.btnFromKML.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnFromKML.Name = "btnFromKML";
            this.btnFromKML.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFromKML.Size = new System.Drawing.Size(296, 71);
            this.btnFromKML.TabIndex = 91;
            this.btnFromKML.Text = "From KML";
            this.btnFromKML.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFromKML.UseVisualStyleBackColor = false;
            this.btnFromKML.Click += new System.EventHandler(this.btnFromKML_Click);
            // 
            // btnFromISOXML
            // 
            this.btnFromISOXML.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFromISOXML.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFromISOXML.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFromISOXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromISOXML.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFromISOXML.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFromISOXML.Image = global::AgOpenGPS.Properties.Resources.ISOXML;
            this.btnFromISOXML.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFromISOXML.Location = new System.Drawing.Point(29, 19);
            this.btnFromISOXML.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnFromISOXML.Name = "btnFromISOXML";
            this.btnFromISOXML.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFromISOXML.Size = new System.Drawing.Size(296, 71);
            this.btnFromISOXML.TabIndex = 107;
            this.btnFromISOXML.Text = "ISO-XML";
            this.btnFromISOXML.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFromISOXML.UseVisualStyleBackColor = false;
            this.btnFromISOXML.Click += new System.EventHandler(this.btnFromISOXML_Click);
            // 
            // btnJobNew
            // 
            this.btnJobNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnJobNew.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnJobNew.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnJobNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobNew.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobNew.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnJobNew.Image = global::AgOpenGPS.Properties.Resources.FileNew;
            this.btnJobNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobNew.Location = new System.Drawing.Point(29, 461);
            this.btnJobNew.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobNew.Name = "btnJobNew";
            this.btnJobNew.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnJobNew.Size = new System.Drawing.Size(296, 71);
            this.btnJobNew.TabIndex = 2;
            this.btnJobNew.Text = "New";
            this.btnJobNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobNew.UseVisualStyleBackColor = false;
            this.btnJobNew.Click += new System.EventHandler(this.btnJobNew_Click);
            // 
            // FormJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(739, 562);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Location = new System.Drawing.Point(200, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 430);
            this.Name = "FormJob";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Start a field";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormJob_FormClosing);
            this.Load += new System.EventHandler(this.FormJob_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnJobOpen;
        private System.Windows.Forms.Button btnJobNew;
        private System.Windows.Forms.Button btnJobResume;
        private System.Windows.Forms.Button btnDeleteAB;
        private System.Windows.Forms.Button btnInField;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFromKML;
        private System.Windows.Forms.Button btnFromExisting;
        private System.Windows.Forms.Button btnJobClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblResumeField;
        private System.Windows.Forms.Button btnFromISOXML;
    }
}