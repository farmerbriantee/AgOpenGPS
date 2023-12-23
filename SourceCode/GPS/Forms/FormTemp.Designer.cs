namespace AgOpenGPS
{
    partial class FormTemp
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
            this.btnExit = new System.Windows.Forms.Button();
            this.nudDrawbarLength = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudDrawbarLength)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnExit.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExit.Location = new System.Drawing.Point(966, 631);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 79);
            this.btnExit.TabIndex = 210;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // nudDrawbarLength
            // 
            this.nudDrawbarLength.BackColor = System.Drawing.Color.AliceBlue;
            this.nudDrawbarLength.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDrawbarLength.InterceptArrowKeys = false;
            this.nudDrawbarLength.Location = new System.Drawing.Point(117, 66);
            this.nudDrawbarLength.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudDrawbarLength.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDrawbarLength.Name = "nudDrawbarLength";
            this.nudDrawbarLength.ReadOnly = true;
            this.nudDrawbarLength.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudDrawbarLength.Size = new System.Drawing.Size(124, 52);
            this.nudDrawbarLength.TabIndex = 217;
            this.nudDrawbarLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDrawbarLength.Value = new decimal(new int[] {
            51,
            0,
            0,
            0});
            // 
            // FormToolPivot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1056, 722);
            this.ControlBox = false;
            this.Controls.Add(this.nudDrawbarLength);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormToolPivot";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Flags";
            this.Load += new System.EventHandler(this.FormToolPivot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDrawbarLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NumericUpDown nudDrawbarLength;
    }
}