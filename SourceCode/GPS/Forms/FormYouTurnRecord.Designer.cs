namespace AgOpenGPS
{
    partial class FormYouTurnRecord
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
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Image = global::AgOpenGPS.Properties.Resources.boundaryStop;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStop.Location = new System.Drawing.Point(23, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(110, 110);
            this.btnStop.TabIndex = 142;
            this.btnStop.Text = "Done";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRecord.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecord.Image = global::AgOpenGPS.Properties.Resources.BoundaryRecord;
            this.btnRecord.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecord.Location = new System.Drawing.Point(242, 12);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(110, 110);
            this.btnRecord.TabIndex = 141;
            this.btnRecord.Text = "Record";
            this.btnRecord.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 32);
            this.label1.TabIndex = 143;
            this.label1.Text = "Turn RIGHT while recording";
            // 
            // FormYouTurnRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 190);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRecord);
            this.Name = "FormYouTurnRecord";
            this.Text = "YouTurn Recorder";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormYouTurnRecord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Label label1;
    }
}