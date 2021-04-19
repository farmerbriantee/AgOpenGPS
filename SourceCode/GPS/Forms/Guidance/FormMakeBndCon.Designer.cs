namespace AgOpenGPS
{
    partial class FormMakeBndCon
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
            this.nudPass = new System.Windows.Forms.NumericUpDown();
            this.lblHz = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.nudSpacing = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpacing)).BeginInit();
            this.SuspendLayout();
            // 
            // nudPass
            // 
            this.nudPass.BackColor = System.Drawing.Color.AliceBlue;
            this.nudPass.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPass.Location = new System.Drawing.Point(37, 69);
            this.nudPass.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudPass.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPass.Name = "nudPass";
            this.nudPass.ReadOnly = true;
            this.nudPass.Size = new System.Drawing.Size(120, 85);
            this.nudPass.TabIndex = 5;
            this.nudPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudPass.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPass.Click += new System.EventHandler(this.NudPass_Click);
            // 
            // lblHz
            // 
            this.lblHz.AutoSize = true;
            this.lblHz.BackColor = System.Drawing.Color.Transparent;
            this.lblHz.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHz.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHz.Location = new System.Drawing.Point(34, 38);
            this.lblHz.Name = "lblHz";
            this.lblHz.Size = new System.Drawing.Size(84, 25);
            this.lblHz.TabIndex = 250;
            this.lblHz.Text = "Pass #";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnOk.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnOk.Location = new System.Drawing.Point(341, 361);
            this.btnOk.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(129, 80);
            this.btnOk.TabIndex = 1;
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // nudSpacing
            // 
            this.nudSpacing.BackColor = System.Drawing.Color.AliceBlue;
            this.nudSpacing.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSpacing.Location = new System.Drawing.Point(30, 246);
            this.nudSpacing.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nudSpacing.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpacing.Name = "nudSpacing";
            this.nudSpacing.ReadOnly = true;
            this.nudSpacing.Size = new System.Drawing.Size(166, 85);
            this.nudSpacing.TabIndex = 252;
            this.nudSpacing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSpacing.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudSpacing.Click += new System.EventHandler(this.NudSpacing_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(34, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 25);
            this.label1.TabIndex = 253;
            this.label1.Text = "Spacing (cm)";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.Location = new System.Drawing.Point(225, 360);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 81);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FormMakeBndCon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = global::AgOpenGPS.Properties.Resources.MakeBoundaryContour;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudSpacing);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblHz);
            this.Controls.Add(this.nudPass);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMakeBndCon";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Make Boundary Contour";
            this.Load += new System.EventHandler(this.FormMakeBndCon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpacing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudPass;
        private System.Windows.Forms.Label lblHz;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.NumericUpDown nudSpacing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
    }
}