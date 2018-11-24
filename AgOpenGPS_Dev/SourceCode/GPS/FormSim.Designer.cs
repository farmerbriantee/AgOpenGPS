namespace AgOpenGPS
{
    partial class FormSim
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
            this.lblSteerAngle = new System.Windows.Forms.Label();
            this.hsbarSteerAngle = new System.Windows.Forms.HScrollBar();
            this.btnResetSim = new System.Windows.Forms.Button();
            this.btnResetSteerAngle = new System.Windows.Forms.Button();
            this.hsbarStepDistance = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // lblSteerAngle
            // 
            this.lblSteerAngle.AutoSize = true;
            this.lblSteerAngle.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSteerAngle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblSteerAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSteerAngle.Location = new System.Drawing.Point(21, 57);
            this.lblSteerAngle.Name = "lblSteerAngle";
            this.lblSteerAngle.Size = new System.Drawing.Size(19, 19);
            this.lblSteerAngle.TabIndex = 181;
            this.lblSteerAngle.Text = "0";
            // 
            // hsbarSteerAngle
            // 
            this.hsbarSteerAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hsbarSteerAngle.LargeChange = 20;
            this.hsbarSteerAngle.Location = new System.Drawing.Point(3, 49);
            this.hsbarSteerAngle.Maximum = 1000;
            this.hsbarSteerAngle.Name = "hsbarSteerAngle";
            this.hsbarSteerAngle.Size = new System.Drawing.Size(150, 34);
            this.hsbarSteerAngle.TabIndex = 184;
            this.hsbarSteerAngle.Value = 500;
            // 
            // btnResetSim
            // 
            this.btnResetSim.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnResetSim.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnResetSim.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetSim.Location = new System.Drawing.Point(176, 4);
            this.btnResetSim.Name = "btnResetSim";
            this.btnResetSim.Size = new System.Drawing.Size(57, 34);
            this.btnResetSim.TabIndex = 182;
            this.btnResetSim.Text = "Rst";
            this.btnResetSim.UseVisualStyleBackColor = false;
            // 
            // btnResetSteerAngle
            // 
            this.btnResetSteerAngle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnResetSteerAngle.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnResetSteerAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetSteerAngle.Location = new System.Drawing.Point(176, 49);
            this.btnResetSteerAngle.Name = "btnResetSteerAngle";
            this.btnResetSteerAngle.Size = new System.Drawing.Size(57, 34);
            this.btnResetSteerAngle.TabIndex = 180;
            this.btnResetSteerAngle.Text = "0";
            this.btnResetSteerAngle.UseVisualStyleBackColor = false;
            // 
            // hsbarStepDistance
            // 
            this.hsbarStepDistance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hsbarStepDistance.LargeChange = 5;
            this.hsbarStepDistance.Location = new System.Drawing.Point(3, 4);
            this.hsbarStepDistance.Maximum = 300;
            this.hsbarStepDistance.Name = "hsbarStepDistance";
            this.hsbarStepDistance.Size = new System.Drawing.Size(150, 34);
            this.hsbarStepDistance.TabIndex = 183;
            // 
            // FormSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(245, 92);
            this.Controls.Add(this.lblSteerAngle);
            this.Controls.Add(this.hsbarSteerAngle);
            this.Controls.Add(this.btnResetSim);
            this.Controls.Add(this.btnResetSteerAngle);
            this.Controls.Add(this.hsbarStepDistance);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSim";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSim";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSteerAngle;
        private System.Windows.Forms.HScrollBar hsbarSteerAngle;
        private System.Windows.Forms.Button btnResetSim;
        private System.Windows.Forms.Button btnResetSteerAngle;
        private System.Windows.Forms.HScrollBar hsbarStepDistance;
    }
}