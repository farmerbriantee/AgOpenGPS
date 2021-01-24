namespace AgOpenGPS
{
    partial class FormVehiclePicker
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
            this.cboxVeh = new System.Windows.Forms.ComboBox();
            this.lblLast = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboxVeh
            // 
            this.cboxVeh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxVeh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxVeh.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxVeh.FormattingEnabled = true;
            this.cboxVeh.Location = new System.Drawing.Point(12, 42);
            this.cboxVeh.Name = "cboxVeh";
            this.cboxVeh.Size = new System.Drawing.Size(548, 43);
            this.cboxVeh.TabIndex = 212;
            this.cboxVeh.SelectedIndexChanged += new System.EventHandler(this.cboxVeh_SelectedIndexChanged);
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLast.Location = new System.Drawing.Point(15, 9);
            this.lblLast.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(79, 23);
            this.lblLast.TabIndex = 213;
            this.lblLast.Text = "Vehicle";
            this.lblLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormVehiclePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 102);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.cboxVeh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormVehiclePicker";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Load Vehicle";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormFlags_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboxVeh;
        private System.Windows.Forms.Label lblLast;
    }
}