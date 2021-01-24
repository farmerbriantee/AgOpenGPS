namespace AgOpenGPS
{
    partial class FormToolPicker
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
            this.cboxTool = new System.Windows.Forms.ComboBox();
            this.lblLast = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboxTool
            // 
            this.cboxTool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxTool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTool.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxTool.FormattingEnabled = true;
            this.cboxTool.Location = new System.Drawing.Point(12, 47);
            this.cboxTool.Name = "cboxTool";
            this.cboxTool.Size = new System.Drawing.Size(548, 43);
            this.cboxTool.TabIndex = 212;
            this.cboxTool.SelectedIndexChanged += new System.EventHandler(this.cboxVeh_SelectedIndexChanged);
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLast.Location = new System.Drawing.Point(15, 9);
            this.lblLast.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(107, 23);
            this.lblLast.TabIndex = 215;
            this.lblLast.Text = "ToolName";
            this.lblLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormToolPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 102);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.cboxTool);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormToolPicker";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Load Tool";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormFlags_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboxTool;
        private System.Windows.Forms.Label lblLast;
    }
}