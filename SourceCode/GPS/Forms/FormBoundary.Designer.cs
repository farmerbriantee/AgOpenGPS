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
            this.btnLeftRight = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOuter = new System.Windows.Forms.Button();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.btnSerialOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLeftRight
            // 
            this.btnLeftRight.Enabled = false;
            this.btnLeftRight.Image = global::AgOpenGPS.Properties.Resources.BoundaryRight;
            this.btnLeftRight.Location = new System.Drawing.Point(217, 20);
            this.btnLeftRight.Name = "btnLeftRight";
            this.btnLeftRight.Size = new System.Drawing.Size(121, 110);
            this.btnLeftRight.TabIndex = 67;
            this.btnLeftRight.UseVisualStyleBackColor = true;
            this.btnLeftRight.Click += new System.EventHandler(this.btnLeftRight_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::AgOpenGPS.Properties.Resources.BoundaryDelete;
            this.btnDelete.Location = new System.Drawing.Point(217, 167);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 110);
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
            this.btnOuter.Location = new System.Drawing.Point(23, 20);
            this.btnOuter.Name = "btnOuter";
            this.btnOuter.Size = new System.Drawing.Size(121, 110);
            this.btnOuter.TabIndex = 65;
            this.btnOuter.Text = "Outer";
            this.btnOuter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOuter.UseVisualStyleBackColor = true;
            this.btnOuter.Click += new System.EventHandler(this.btnOuter_Click);
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnSerialCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSerialCancel.Location = new System.Drawing.Point(415, 167);
            this.btnSerialCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(121, 110);
            this.btnSerialCancel.TabIndex = 64;
            this.btnSerialCancel.Text = "Exit";
            this.btnSerialCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            this.btnSerialCancel.Click += new System.EventHandler(this.btnSerialCancel_Click);
            // 
            // btnSerialOK
            // 
            this.btnSerialOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSerialOK.Enabled = false;
            this.btnSerialOK.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSerialOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnSerialOK.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSerialOK.Location = new System.Drawing.Point(415, 20);
            this.btnSerialOK.Margin = new System.Windows.Forms.Padding(5);
            this.btnSerialOK.Name = "btnSerialOK";
            this.btnSerialOK.Size = new System.Drawing.Size(121, 110);
            this.btnSerialOK.TabIndex = 63;
            this.btnSerialOK.Text = "Next";
            this.btnSerialOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSerialOK.UseVisualStyleBackColor = true;
            // 
            // FormBoundary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 310);
            this.ControlBox = false;
            this.Controls.Add(this.btnLeftRight);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOuter);
            this.Controls.Add(this.btnSerialCancel);
            this.Controls.Add(this.btnSerialOK);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormBoundary";
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
    }
}