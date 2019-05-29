namespace AgOpenGPS
{
    partial class FormVRate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVRate));
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnOpenGoogleEarth = new System.Windows.Forms.Button();
            this.btnLoadKML = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.picboxVR = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxVR)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAll.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAll.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteAll.Location = new System.Drawing.Point(749, 366);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(121, 84);
            this.btnDeleteAll.TabIndex = 106;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            // 
            // btnOpenGoogleEarth
            // 
            this.btnOpenGoogleEarth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenGoogleEarth.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenGoogleEarth.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenGoogleEarth.Image")));
            this.btnOpenGoogleEarth.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpenGoogleEarth.Location = new System.Drawing.Point(749, 458);
            this.btnOpenGoogleEarth.Name = "btnOpenGoogleEarth";
            this.btnOpenGoogleEarth.Size = new System.Drawing.Size(121, 84);
            this.btnOpenGoogleEarth.TabIndex = 104;
            this.btnOpenGoogleEarth.Text = "Google Earth";
            this.btnOpenGoogleEarth.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpenGoogleEarth.UseVisualStyleBackColor = true;
            // 
            // btnLoadKML
            // 
            this.btnLoadKML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadKML.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadKML.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadKML.Image")));
            this.btnLoadKML.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadKML.Location = new System.Drawing.Point(749, 274);
            this.btnLoadKML.Name = "btnLoadKML";
            this.btnLoadKML.Size = new System.Drawing.Size(121, 84);
            this.btnLoadKML.TabIndex = 103;
            this.btnLoadKML.Text = "Load Image";
            this.btnLoadKML.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadKML.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(749, 550);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 84);
            this.btnSave.TabIndex = 101;
            this.btnSave.Text = "Save and Return";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picboxVR
            // 
            this.picboxVR.Location = new System.Drawing.Point(12, 16);
            this.picboxVR.Name = "picboxVR";
            this.picboxVR.Size = new System.Drawing.Size(717, 618);
            this.picboxVR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picboxVR.TabIndex = 107;
            this.picboxVR.TabStop = false;
            // 
            // FormVRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 650);
            this.Controls.Add(this.picboxVR);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnOpenGoogleEarth);
            this.Controls.Add(this.btnLoadKML);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormVRate";
            this.Text = "FormVRate";
            this.Load += new System.EventHandler(this.FormVRate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picboxVR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnOpenGoogleEarth;
        private System.Windows.Forms.Button btnLoadKML;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox picboxVR;
    }
}