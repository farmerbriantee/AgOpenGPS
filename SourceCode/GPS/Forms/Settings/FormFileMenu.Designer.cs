namespace AgOpenGPS
{
    partial class FormFileMenu
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
            this.nudTrailingToolToPivotLength = new NudlessNumericUpDown();
            this.rbtnPivotBehindPos = new System.Windows.Forms.RadioButton();
            this.rbtnPivotAheadNeg = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudTrailingToolToPivotLength)).BeginInit();
            this.SuspendLayout();
            // 
            // nudTrailingToolToPivotLength
            // 
            this.nudTrailingToolToPivotLength.BackColor = System.Drawing.Color.AliceBlue;
            this.nudTrailingToolToPivotLength.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTrailingToolToPivotLength.InterceptArrowKeys = false;
            this.nudTrailingToolToPivotLength.Location = new System.Drawing.Point(339, 46);
            this.nudTrailingToolToPivotLength.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudTrailingToolToPivotLength.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudTrailingToolToPivotLength.Name = "nudTrailingToolToPivotLength";
            this.nudTrailingToolToPivotLength.ReadOnly = true;
            this.nudTrailingToolToPivotLength.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudTrailingToolToPivotLength.Size = new System.Drawing.Size(124, 52);
            this.nudTrailingToolToPivotLength.TabIndex = 211;
            this.nudTrailingToolToPivotLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudTrailingToolToPivotLength.Value = new decimal(new int[] {
            51,
            0,
            0,
            0});
            this.nudTrailingToolToPivotLength.Click += new System.EventHandler(this.nudTrailingToolToPivotLength_Click);
            // 
            // rbtnPivotBehindPos
            // 
            this.rbtnPivotBehindPos.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPivotBehindPos.BackColor = System.Drawing.Color.Transparent;
            this.rbtnPivotBehindPos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbtnPivotBehindPos.Checked = true;
            this.rbtnPivotBehindPos.FlatAppearance.BorderSize = 0;
            this.rbtnPivotBehindPos.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.rbtnPivotBehindPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPivotBehindPos.Image = global::AgOpenGPS.Properties.Resources.ToolHitchPivotOffsetNeg;
            this.rbtnPivotBehindPos.Location = new System.Drawing.Point(120, 190);
            this.rbtnPivotBehindPos.Name = "rbtnPivotBehindPos";
            this.rbtnPivotBehindPos.Size = new System.Drawing.Size(309, 152);
            this.rbtnPivotBehindPos.TabIndex = 213;
            this.rbtnPivotBehindPos.TabStop = true;
            this.rbtnPivotBehindPos.UseVisualStyleBackColor = false;
            this.rbtnPivotBehindPos.Click += new System.EventHandler(this.rbtnPivotBehindPos_Click);
            // 
            // rbtnPivotAheadNeg
            // 
            this.rbtnPivotAheadNeg.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPivotAheadNeg.BackColor = System.Drawing.Color.Transparent;
            this.rbtnPivotAheadNeg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbtnPivotAheadNeg.FlatAppearance.BorderSize = 0;
            this.rbtnPivotAheadNeg.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.rbtnPivotAheadNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPivotAheadNeg.Image = global::AgOpenGPS.Properties.Resources.ToolHitchPivotOffsetPos;
            this.rbtnPivotAheadNeg.Location = new System.Drawing.Point(498, 190);
            this.rbtnPivotAheadNeg.Name = "rbtnPivotAheadNeg";
            this.rbtnPivotAheadNeg.Size = new System.Drawing.Size(309, 152);
            this.rbtnPivotAheadNeg.TabIndex = 212;
            this.rbtnPivotAheadNeg.UseVisualStyleBackColor = false;
            this.rbtnPivotAheadNeg.Click += new System.EventHandler(this.rbtnPivotBehindPos_Click);
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
            this.btnExit.Location = new System.Drawing.Point(526, 28);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 79);
            this.btnExit.TabIndex = 210;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormToolPivot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(927, 533);
            this.ControlBox = false;
            this.Controls.Add(this.rbtnPivotBehindPos);
            this.Controls.Add(this.rbtnPivotAheadNeg);
            this.Controls.Add(this.nudTrailingToolToPivotLength);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormToolPivot";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pivot Offset";
            this.Load += new System.EventHandler(this.FormToolPivot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudTrailingToolToPivotLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private NudlessNumericUpDown nudTrailingToolToPivotLength;
        private System.Windows.Forms.RadioButton rbtnPivotBehindPos;
        private System.Windows.Forms.RadioButton rbtnPivotAheadNeg;
    }
}