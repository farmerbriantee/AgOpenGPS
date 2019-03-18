namespace AgOpenGPS
{
    partial class FormDualRate
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
            this.lblVolumePerArea = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLeftCalLabel = new System.Windows.Forms.Label();
            this.nudCalFactorRight = new System.Windows.Forms.NumericUpDown();
            this.nudCalFactorLeft = new System.Windows.Forms.NumericUpDown();
            this.groupBoxRight = new System.Windows.Forms.GroupBox();
            this.nudRateRight = new System.Windows.Forms.NumericUpDown();
            this.btnRateRightUp = new ProXoft.WinForms.RepeatButton();
            this.btnRateRightDn = new ProXoft.WinForms.RepeatButton();
            this.btnDualResetAccumulatedVolume = new System.Windows.Forms.Button();
            this.lblDualAccumulatedVolume = new System.Windows.Forms.Label();
            this.groupBoxLeft = new System.Windows.Forms.GroupBox();
            this.nudRateLeft = new System.Windows.Forms.NumericUpDown();
            this.btnRateLeftDn = new ProXoft.WinForms.RepeatButton();
            this.btnRateLeftUp = new ProXoft.WinForms.RepeatButton();
            this.bntOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalFactorRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalFactorLeft)).BeginInit();
            this.groupBoxRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRateRight)).BeginInit();
            this.groupBoxLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRateLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVolumePerArea
            // 
            this.lblVolumePerArea.AutoSize = true;
            this.lblVolumePerArea.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolumePerArea.Location = new System.Drawing.Point(263, 4);
            this.lblVolumePerArea.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVolumePerArea.Name = "lblVolumePerArea";
            this.lblVolumePerArea.Size = new System.Drawing.Size(179, 25);
            this.lblVolumePerArea.TabIndex = 144;
            this.lblVolumePerArea.Text = "Liters Per Hectare";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblLeftCalLabel);
            this.groupBox3.Controls.Add(this.nudCalFactorRight);
            this.groupBox3.Controls.Add(this.nudCalFactorLeft);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(244, 199);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Size = new System.Drawing.Size(424, 141);
            this.groupBox3.TabIndex = 143;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Flowmeter Counts / Liter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(267, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 23);
            this.label3.TabIndex = 148;
            this.label3.Text = "Right Cal";
            // 
            // lblLeftCalLabel
            // 
            this.lblLeftCalLabel.AutoSize = true;
            this.lblLeftCalLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftCalLabel.Location = new System.Drawing.Point(25, 40);
            this.lblLeftCalLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLeftCalLabel.Name = "lblLeftCalLabel";
            this.lblLeftCalLabel.Size = new System.Drawing.Size(83, 23);
            this.lblLeftCalLabel.TabIndex = 147;
            this.lblLeftCalLabel.Text = "Left Cal";
            // 
            // nudCalFactorRight
            // 
            this.nudCalFactorRight.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCalFactorRight.Location = new System.Drawing.Point(261, 67);
            this.nudCalFactorRight.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nudCalFactorRight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCalFactorRight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCalFactorRight.Name = "nudCalFactorRight";
            this.nudCalFactorRight.Size = new System.Drawing.Size(149, 65);
            this.nudCalFactorRight.TabIndex = 142;
            this.nudCalFactorRight.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // nudCalFactorLeft
            // 
            this.nudCalFactorLeft.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCalFactorLeft.Location = new System.Drawing.Point(15, 67);
            this.nudCalFactorLeft.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nudCalFactorLeft.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCalFactorLeft.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCalFactorLeft.Name = "nudCalFactorLeft";
            this.nudCalFactorLeft.Size = new System.Drawing.Size(149, 65);
            this.nudCalFactorLeft.TabIndex = 138;
            this.nudCalFactorLeft.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // groupBoxRight
            // 
            this.groupBoxRight.Controls.Add(this.nudRateRight);
            this.groupBoxRight.Controls.Add(this.btnRateRightUp);
            this.groupBoxRight.Controls.Add(this.btnRateRightDn);
            this.groupBoxRight.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRight.Location = new System.Drawing.Point(428, 39);
            this.groupBoxRight.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBoxRight.Name = "groupBoxRight";
            this.groupBoxRight.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBoxRight.Size = new System.Drawing.Size(410, 141);
            this.groupBoxRight.TabIndex = 142;
            this.groupBoxRight.TabStop = false;
            this.groupBoxRight.Text = "Rate 2 or Right Boom";
            // 
            // nudRateRight
            // 
            this.nudRateRight.DecimalPlaces = 1;
            this.nudRateRight.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRateRight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRateRight.Location = new System.Drawing.Point(20, 40);
            this.nudRateRight.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nudRateRight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRateRight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRateRight.Name = "nudRateRight";
            this.nudRateRight.Size = new System.Drawing.Size(196, 65);
            this.nudRateRight.TabIndex = 139;
            this.nudRateRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRateRight.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudRateRight.Value = new decimal(new int[] {
            88888,
            0,
            0,
            65536});
            this.nudRateRight.ValueChanged += new System.EventHandler(this.nudRateRight_ValueChanged);
            // 
            // btnRateRightUp
            // 
            this.btnRateRightUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRateRightUp.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRateRightUp.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnRateRightUp.Location = new System.Drawing.Point(242, 34);
            this.btnRateRightUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRateRightUp.Name = "btnRateRightUp";
            this.btnRateRightUp.Size = new System.Drawing.Size(62, 80);
            this.btnRateRightUp.TabIndex = 127;
            this.btnRateRightUp.UseVisualStyleBackColor = true;
            this.btnRateRightUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRateRightUp_MouseDown);
            // 
            // btnRateRightDn
            // 
            this.btnRateRightDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRateRightDn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRateRightDn.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnRateRightDn.Location = new System.Drawing.Point(325, 34);
            this.btnRateRightDn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRateRightDn.Name = "btnRateRightDn";
            this.btnRateRightDn.Size = new System.Drawing.Size(62, 80);
            this.btnRateRightDn.TabIndex = 126;
            this.btnRateRightDn.UseVisualStyleBackColor = true;
            this.btnRateRightDn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRateRightDn_MouseDown);
            // 
            // btnDualResetAccumulatedVolume
            // 
            this.btnDualResetAccumulatedVolume.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDualResetAccumulatedVolume.Location = new System.Drawing.Point(43, 286);
            this.btnDualResetAccumulatedVolume.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDualResetAccumulatedVolume.Name = "btnDualResetAccumulatedVolume";
            this.btnDualResetAccumulatedVolume.Size = new System.Drawing.Size(109, 54);
            this.btnDualResetAccumulatedVolume.TabIndex = 131;
            this.btnDualResetAccumulatedVolume.Text = "> 0 <";
            this.btnDualResetAccumulatedVolume.UseVisualStyleBackColor = true;
            this.btnDualResetAccumulatedVolume.Click += new System.EventHandler(this.btnDualResetAccumulatedVolume_Click);
            // 
            // lblDualAccumulatedVolume
            // 
            this.lblDualAccumulatedVolume.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDualAccumulatedVolume.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDualAccumulatedVolume.Location = new System.Drawing.Point(35, 233);
            this.lblDualAccumulatedVolume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDualAccumulatedVolume.Name = "lblDualAccumulatedVolume";
            this.lblDualAccumulatedVolume.Size = new System.Drawing.Size(145, 50);
            this.lblDualAccumulatedVolume.TabIndex = 13;
            this.lblDualAccumulatedVolume.Text = "999.9";
            // 
            // groupBoxLeft
            // 
            this.groupBoxLeft.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxLeft.Controls.Add(this.nudRateLeft);
            this.groupBoxLeft.Controls.Add(this.btnRateLeftDn);
            this.groupBoxLeft.Controls.Add(this.btnRateLeftUp);
            this.groupBoxLeft.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxLeft.Location = new System.Drawing.Point(11, 39);
            this.groupBoxLeft.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBoxLeft.Name = "groupBoxLeft";
            this.groupBoxLeft.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBoxLeft.Size = new System.Drawing.Size(410, 141);
            this.groupBoxLeft.TabIndex = 141;
            this.groupBoxLeft.TabStop = false;
            this.groupBoxLeft.Text = "Rate 1 or Left Boom";
            // 
            // nudRateLeft
            // 
            this.nudRateLeft.DecimalPlaces = 1;
            this.nudRateLeft.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRateLeft.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRateLeft.Location = new System.Drawing.Point(15, 40);
            this.nudRateLeft.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nudRateLeft.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRateLeft.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRateLeft.Name = "nudRateLeft";
            this.nudRateLeft.Size = new System.Drawing.Size(196, 65);
            this.nudRateLeft.TabIndex = 140;
            this.nudRateLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRateLeft.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudRateLeft.Value = new decimal(new int[] {
            88888,
            0,
            0,
            65536});
            this.nudRateLeft.ValueChanged += new System.EventHandler(this.nudRateLeft_ValueChanged);
            // 
            // btnRateLeftDn
            // 
            this.btnRateLeftDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRateLeftDn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRateLeftDn.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnRateLeftDn.Location = new System.Drawing.Point(322, 34);
            this.btnRateLeftDn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRateLeftDn.Name = "btnRateLeftDn";
            this.btnRateLeftDn.Size = new System.Drawing.Size(62, 80);
            this.btnRateLeftDn.TabIndex = 124;
            this.btnRateLeftDn.UseVisualStyleBackColor = true;
            this.btnRateLeftDn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRateLeftDn_MouseDown);
            // 
            // btnRateLeftUp
            // 
            this.btnRateLeftUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRateLeftUp.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRateLeftUp.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnRateLeftUp.Location = new System.Drawing.Point(233, 34);
            this.btnRateLeftUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRateLeftUp.Name = "btnRateLeftUp";
            this.btnRateLeftUp.Size = new System.Drawing.Size(62, 80);
            this.btnRateLeftUp.TabIndex = 125;
            this.btnRateLeftUp.UseVisualStyleBackColor = true;
            this.btnRateLeftUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRateLeftUp_MouseDown);
            // 
            // bntOK
            // 
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.Location = new System.Drawing.Point(723, 266);
            this.bntOK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(115, 72);
            this.bntOK.TabIndex = 140;
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 199);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 25);
            this.label1.TabIndex = 146;
            this.label1.Text = "Total Volume";
            // 
            // FormDualRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 351);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVolumePerArea);
            this.Controls.Add(this.btnDualResetAccumulatedVolume);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblDualAccumulatedVolume);
            this.Controls.Add(this.groupBoxRight);
            this.Controls.Add(this.groupBoxLeft);
            this.Controls.Add(this.bntOK);
            this.Name = "FormDualRate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rate and Meter Configuration";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormDualRate_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalFactorRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalFactorLeft)).EndInit();
            this.groupBoxRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRateRight)).EndInit();
            this.groupBoxLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRateLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVolumePerArea;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudCalFactorRight;
        private System.Windows.Forms.NumericUpDown nudCalFactorLeft;
        private System.Windows.Forms.GroupBox groupBoxRight;
        private System.Windows.Forms.NumericUpDown nudRateRight;
        private ProXoft.WinForms.RepeatButton btnRateRightUp;
        private ProXoft.WinForms.RepeatButton btnRateRightDn;
        private System.Windows.Forms.Button btnDualResetAccumulatedVolume;
        private System.Windows.Forms.Label lblDualAccumulatedVolume;
        private System.Windows.Forms.GroupBox groupBoxLeft;
        private System.Windows.Forms.NumericUpDown nudRateLeft;
        private ProXoft.WinForms.RepeatButton btnRateLeftDn;
        private ProXoft.WinForms.RepeatButton btnRateLeftUp;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLeftCalLabel;
        private System.Windows.Forms.Label label1;
    }
}