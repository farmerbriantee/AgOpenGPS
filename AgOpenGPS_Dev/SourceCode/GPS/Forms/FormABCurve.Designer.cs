namespace AgOpenGPS
{
    partial class FormABCurve
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBPoint = new System.Windows.Forms.Button();
            this.btnAPoint = new System.Windows.Forms.Button();
            this.btnABLineOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(153, 23);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 90);
            this.btnCancel.TabIndex = 86;
            this.btnCancel.Text = "Delete";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBPoint
            // 
            this.btnBPoint.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBPoint.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnBPoint.Image = global::AgOpenGPS.Properties.Resources.LetterBBlue;
            this.btnBPoint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBPoint.Location = new System.Drawing.Point(15, 179);
            this.btnBPoint.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnBPoint.Name = "btnBPoint";
            this.btnBPoint.Size = new System.Drawing.Size(86, 90);
            this.btnBPoint.TabIndex = 64;
            this.btnBPoint.UseVisualStyleBackColor = true;
            this.btnBPoint.Click += new System.EventHandler(this.btnBPoint_Click);
            // 
            // btnAPoint
            // 
            this.btnAPoint.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnAPoint.Image = global::AgOpenGPS.Properties.Resources.LetterABlue;
            this.btnAPoint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAPoint.Location = new System.Drawing.Point(15, 23);
            this.btnAPoint.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAPoint.Name = "btnAPoint";
            this.btnAPoint.Size = new System.Drawing.Size(86, 90);
            this.btnAPoint.TabIndex = 63;
            this.btnAPoint.UseVisualStyleBackColor = true;
            this.btnAPoint.Click += new System.EventHandler(this.btnAPoint_Click);
            // 
            // btnABLineOk
            // 
            this.btnABLineOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnABLineOk.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnABLineOk.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnABLineOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnABLineOk.Location = new System.Drawing.Point(153, 180);
            this.btnABLineOk.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnABLineOk.Name = "btnABLineOk";
            this.btnABLineOk.Size = new System.Drawing.Size(86, 90);
            this.btnABLineOk.TabIndex = 65;
            this.btnABLineOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnABLineOk.UseVisualStyleBackColor = true;
            this.btnABLineOk.Click += new System.EventHandler(this.btnABLineOk_Click);
            // 
            // FormABCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 303);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBPoint);
            this.Controls.Add(this.btnAPoint);
            this.Controls.Add(this.btnABLineOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormABCurve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AB Curve";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormABCurve_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBPoint;
        private System.Windows.Forms.Button btnAPoint;
        private System.Windows.Forms.Button btnABLineOk;
        private System.Windows.Forms.Button btnCancel;
    }
}