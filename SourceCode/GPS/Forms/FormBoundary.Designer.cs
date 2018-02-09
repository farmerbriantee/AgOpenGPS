namespace AgOpenGPS
{
    partial class FormBoundary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBoundary));
            this.btnLeftRight = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOuter = new System.Windows.Forms.Button();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.btnSerialOK = new System.Windows.Forms.Button();
            this.btnLoadBoundaryFromGE = new System.Windows.Forms.Button();
            this.btnOpenGoogleEarth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLeftRight
            // 
            this.btnLeftRight.Enabled = false;
            this.btnLeftRight.Image = global::AgOpenGPS.Properties.Resources.BoundaryRight;
            this.btnLeftRight.Location = new System.Drawing.Point(411, 20);
            this.btnLeftRight.Name = "btnLeftRight";
            this.btnLeftRight.Size = new System.Drawing.Size(121, 120);
            this.btnLeftRight.TabIndex = 67;
            this.btnLeftRight.UseVisualStyleBackColor = true;
            this.btnLeftRight.Click += new System.EventHandler(this.btnLeftRight_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::AgOpenGPS.Properties.Resources.BoundaryDelete;
            this.btnDelete.Location = new System.Drawing.Point(411, 164);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 120);
            this.btnDelete.TabIndex = 65;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOuter
            // 
            this.btnOuter.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOuter.Image = global::AgOpenGPS.Properties.Resources.BoundaryOuter;
            this.btnOuter.Location = new System.Drawing.Point(244, 20);
            this.btnOuter.Name = "btnOuter";
            this.btnOuter.Size = new System.Drawing.Size(121, 120);
            this.btnOuter.TabIndex = 65;
            this.btnOuter.Text = "Outer";
            this.btnOuter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOuter.UseVisualStyleBackColor = true;
            this.btnOuter.Click += new System.EventHandler(this.btnOuter_Click);
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialCancel.Image = global::AgOpenGPS.Properties.Resources.back_button;
            this.btnSerialCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSerialCancel.Location = new System.Drawing.Point(565, 164);
            this.btnSerialCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(121, 120);
            this.btnSerialCancel.TabIndex = 64;
            this.btnSerialCancel.Text = "Return";
            this.btnSerialCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            this.btnSerialCancel.Click += new System.EventHandler(this.btnSerialCancel_Click);
            // 
            // btnSerialOK
            // 
            this.btnSerialOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSerialOK.Enabled = false;
            this.btnSerialOK.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSerialOK.Image = global::AgOpenGPS.Properties.Resources.BoundaryRecord;
            this.btnSerialOK.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSerialOK.Location = new System.Drawing.Point(565, 20);
            this.btnSerialOK.Margin = new System.Windows.Forms.Padding(5);
            this.btnSerialOK.Name = "btnSerialOK";
            this.btnSerialOK.Size = new System.Drawing.Size(121, 120);
            this.btnSerialOK.TabIndex = 63;
            this.btnSerialOK.Text = "Go!";
            this.btnSerialOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSerialOK.UseVisualStyleBackColor = true;
            // 
            // btnLoadBoundaryFromGE
            // 
            this.btnLoadBoundaryFromGE.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadBoundaryFromGE.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.btnLoadBoundaryFromGE.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadBoundaryFromGE.Location = new System.Drawing.Point(12, 164);
            this.btnLoadBoundaryFromGE.Name = "btnLoadBoundaryFromGE";
            this.btnLoadBoundaryFromGE.Size = new System.Drawing.Size(121, 120);
            this.btnLoadBoundaryFromGE.TabIndex = 68;
            this.btnLoadBoundaryFromGE.Text = "Load KML";
            this.btnLoadBoundaryFromGE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadBoundaryFromGE.UseVisualStyleBackColor = true;
            this.btnLoadBoundaryFromGE.Click += new System.EventHandler(this.btnLoadBoundaryFromGE_Click);
            // 
            // btnOpenGoogleEarth
            // 
            this.btnOpenGoogleEarth.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenGoogleEarth.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenGoogleEarth.Image")));
            this.btnOpenGoogleEarth.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpenGoogleEarth.Location = new System.Drawing.Point(12, 20);
            this.btnOpenGoogleEarth.Name = "btnOpenGoogleEarth";
            this.btnOpenGoogleEarth.Size = new System.Drawing.Size(121, 120);
            this.btnOpenGoogleEarth.TabIndex = 69;
            this.btnOpenGoogleEarth.Text = "Google Earth";
            this.btnOpenGoogleEarth.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpenGoogleEarth.UseVisualStyleBackColor = true;
            this.btnOpenGoogleEarth.Click += new System.EventHandler(this.btnOpenGoogleEarth_Click);
            // 
            // FormBoundary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 302);
            this.ControlBox = false;
            this.Controls.Add(this.btnOpenGoogleEarth);
            this.Controls.Add(this.btnLoadBoundaryFromGE);
            this.Controls.Add(this.btnLeftRight);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOuter);
            this.Controls.Add(this.btnSerialCancel);
            this.Controls.Add(this.btnSerialOK);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormBoundary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Start Boundary";
            this.Load += new System.EventHandler(this.FormBoundary_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Button btnSerialOK;
        private System.Windows.Forms.Button btnOuter;
        private System.Windows.Forms.Button btnLeftRight;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLoadBoundaryFromGE;
        private System.Windows.Forms.Button btnOpenGoogleEarth;
    }
}