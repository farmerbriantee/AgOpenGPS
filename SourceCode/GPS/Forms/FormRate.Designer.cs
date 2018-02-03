namespace AgOpenGPS
{
    partial class FormRate
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
            this.bntOK = new System.Windows.Forms.Button();
            this.btnRate1Dn = new ProXoft.WinForms.RepeatButton();
            this.btnRate1Up = new ProXoft.WinForms.RepeatButton();
            this.btnRate2Dn = new ProXoft.WinForms.RepeatButton();
            this.btnRate2Up = new ProXoft.WinForms.RepeatButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudRate1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudRate2 = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnResetAccumulatedVolume = new System.Windows.Forms.Button();
            this.lblAccumulatedVolume = new System.Windows.Forms.Label();
            this.nudCalFactor = new System.Windows.Forms.NumericUpDown();
            this.lblVolumePerArea = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRate1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRate2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // bntOK
            // 
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.Location = new System.Drawing.Point(536, 286);
            this.bntOK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(127, 72);
            this.bntOK.TabIndex = 4;
            this.bntOK.Text = "Save";
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // btnRate1Dn
            // 
            this.btnRate1Dn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRate1Dn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRate1Dn.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnRate1Dn.Location = new System.Drawing.Point(260, 29);
            this.btnRate1Dn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRate1Dn.Name = "btnRate1Dn";
            this.btnRate1Dn.Size = new System.Drawing.Size(62, 80);
            this.btnRate1Dn.TabIndex = 124;
            this.btnRate1Dn.UseVisualStyleBackColor = true;
            this.btnRate1Dn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRate1Dn_MouseDown);
            // 
            // btnRate1Up
            // 
            this.btnRate1Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRate1Up.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRate1Up.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnRate1Up.Location = new System.Drawing.Point(184, 29);
            this.btnRate1Up.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRate1Up.Name = "btnRate1Up";
            this.btnRate1Up.Size = new System.Drawing.Size(62, 80);
            this.btnRate1Up.TabIndex = 125;
            this.btnRate1Up.UseVisualStyleBackColor = true;
            this.btnRate1Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRate1Up_MouseDown);
            // 
            // btnRate2Dn
            // 
            this.btnRate2Dn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRate2Dn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRate2Dn.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnRate2Dn.Location = new System.Drawing.Point(260, 27);
            this.btnRate2Dn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRate2Dn.Name = "btnRate2Dn";
            this.btnRate2Dn.Size = new System.Drawing.Size(62, 80);
            this.btnRate2Dn.TabIndex = 126;
            this.btnRate2Dn.UseVisualStyleBackColor = true;
            this.btnRate2Dn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRate2Dn_MouseDown);
            // 
            // btnRate2Up
            // 
            this.btnRate2Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRate2Up.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRate2Up.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnRate2Up.Location = new System.Drawing.Point(184, 26);
            this.btnRate2Up.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRate2Up.Name = "btnRate2Up";
            this.btnRate2Up.Size = new System.Drawing.Size(62, 80);
            this.btnRate2Up.TabIndex = 127;
            this.btnRate2Up.UseVisualStyleBackColor = true;
            this.btnRate2Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRate2Up_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.nudRate1);
            this.groupBox1.Controls.Add(this.btnRate1Dn);
            this.groupBox1.Controls.Add(this.btnRate1Up);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(346, 116);
            this.groupBox1.TabIndex = 132;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rate 1";
            // 
            // nudRate1
            // 
            this.nudRate1.DecimalPlaces = 1;
            this.nudRate1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRate1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRate1.Location = new System.Drawing.Point(20, 42);
            this.nudRate1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nudRate1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRate1.Name = "nudRate1";
            this.nudRate1.Size = new System.Drawing.Size(145, 52);
            this.nudRate1.TabIndex = 140;
            this.nudRate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRate1.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudRate1.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nudRate1.ValueChanged += new System.EventHandler(this.nudRate1_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudRate2);
            this.groupBox2.Controls.Add(this.btnRate2Up);
            this.groupBox2.Controls.Add(this.btnRate2Dn);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 146);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(346, 116);
            this.groupBox2.TabIndex = 133;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rate 2";
            // 
            // nudRate2
            // 
            this.nudRate2.DecimalPlaces = 1;
            this.nudRate2.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRate2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRate2.Location = new System.Drawing.Point(20, 36);
            this.nudRate2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nudRate2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRate2.Name = "nudRate2";
            this.nudRate2.Size = new System.Drawing.Size(145, 52);
            this.nudRate2.TabIndex = 139;
            this.nudRate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRate2.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudRate2.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.nudRate2.ValueChanged += new System.EventHandler(this.nudRate2_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnResetAccumulatedVolume);
            this.groupBox3.Controls.Add(this.lblAccumulatedVolume);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(385, 14);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Size = new System.Drawing.Size(285, 116);
            this.groupBox3.TabIndex = 134;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Accumulated Volume";
            // 
            // btnResetAccumulatedVolume
            // 
            this.btnResetAccumulatedVolume.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetAccumulatedVolume.Location = new System.Drawing.Point(158, 40);
            this.btnResetAccumulatedVolume.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnResetAccumulatedVolume.Name = "btnResetAccumulatedVolume";
            this.btnResetAccumulatedVolume.Size = new System.Drawing.Size(109, 54);
            this.btnResetAccumulatedVolume.TabIndex = 131;
            this.btnResetAccumulatedVolume.Text = "> 0 <";
            this.btnResetAccumulatedVolume.UseVisualStyleBackColor = true;
            this.btnResetAccumulatedVolume.Click += new System.EventHandler(this.btnResetAccumulatedVolume_Click);
            // 
            // lblAccumulatedVolume
            // 
            this.lblAccumulatedVolume.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAccumulatedVolume.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccumulatedVolume.Location = new System.Drawing.Point(9, 43);
            this.lblAccumulatedVolume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAccumulatedVolume.Name = "lblAccumulatedVolume";
            this.lblAccumulatedVolume.Size = new System.Drawing.Size(145, 50);
            this.lblAccumulatedVolume.TabIndex = 13;
            this.lblAccumulatedVolume.Text = "999.9";
            // 
            // nudCalFactor
            // 
            this.nudCalFactor.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCalFactor.Location = new System.Drawing.Point(394, 173);
            this.nudCalFactor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nudCalFactor.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCalFactor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCalFactor.Name = "nudCalFactor";
            this.nudCalFactor.Size = new System.Drawing.Size(131, 52);
            this.nudCalFactor.TabIndex = 138;
            this.nudCalFactor.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCalFactor.ValueChanged += new System.EventHandler(this.nudCalFactor_ValueChanged);
            // 
            // lblVolumePerArea
            // 
            this.lblVolumePerArea.AutoSize = true;
            this.lblVolumePerArea.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolumePerArea.Location = new System.Drawing.Point(50, 276);
            this.lblVolumePerArea.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVolumePerArea.Name = "lblVolumePerArea";
            this.lblVolumePerArea.Size = new System.Drawing.Size(179, 25);
            this.lblVolumePerArea.TabIndex = 139;
            this.lblVolumePerArea.Text = "Liters Per Hectare";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(538, 175);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 50);
            this.label2.TabIndex = 141;
            this.label2.Text = "Flowmeter\r\nCounts / Liter\r\n";
            // 
            // FormRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 383);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblVolumePerArea);
            this.Controls.Add(this.nudCalFactor);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bntOK);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FormRate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Rate Control Setup";
            this.Load += new System.EventHandler(this.FormRate_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRate1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRate2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCalFactor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bntOK;
        private ProXoft.WinForms.RepeatButton btnRate1Dn;
        private ProXoft.WinForms.RepeatButton btnRate1Up;
        private ProXoft.WinForms.RepeatButton btnRate2Dn;
        private ProXoft.WinForms.RepeatButton btnRate2Up;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnResetAccumulatedVolume;
        private System.Windows.Forms.NumericUpDown nudCalFactor;
        private System.Windows.Forms.NumericUpDown nudRate1;
        private System.Windows.Forms.NumericUpDown nudRate2;
        private System.Windows.Forms.Label lblVolumePerArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAccumulatedVolume;
    }
}