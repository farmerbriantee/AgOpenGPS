namespace AgOpenGPS
{
    partial class FormTram
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nudSnapAdj = new System.Windows.Forms.NumericUpDown();
            this.nudEqWidth = new System.Windows.Forms.NumericUpDown();
            this.nudWheelSpacing = new System.Windows.Forms.NumericUpDown();
            this.lblSmallSnapRight = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudPasses = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudOffset = new System.Windows.Forms.NumericUpDown();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMode = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnTriggerDistanceDn = new ProXoft.WinForms.RepeatButton();
            this.btnTriggerDistanceUp = new ProXoft.WinForms.RepeatButton();
            this.btnSwapAB = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdjLeft = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdjRight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSnapAdj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEqWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWheelSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // nudSnapAdj
            // 
            this.nudSnapAdj.BackColor = System.Drawing.Color.AliceBlue;
            this.nudSnapAdj.DecimalPlaces = 2;
            this.nudSnapAdj.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSnapAdj.InterceptArrowKeys = false;
            this.nudSnapAdj.Location = new System.Drawing.Point(78, 32);
            this.nudSnapAdj.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudSnapAdj.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudSnapAdj.Name = "nudSnapAdj";
            this.nudSnapAdj.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudSnapAdj.Size = new System.Drawing.Size(105, 36);
            this.nudSnapAdj.TabIndex = 414;
            this.nudSnapAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSnapAdj.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.nudSnapAdj.ValueChanged += new System.EventHandler(this.nudSnapAdj_ValueChanged);
            this.nudSnapAdj.Enter += new System.EventHandler(this.nudSnapAdj_Enter);
            // 
            // nudEqWidth
            // 
            this.nudEqWidth.BackColor = System.Drawing.Color.AliceBlue;
            this.nudEqWidth.DecimalPlaces = 2;
            this.nudEqWidth.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudEqWidth.InterceptArrowKeys = false;
            this.nudEqWidth.Location = new System.Drawing.Point(10, 156);
            this.nudEqWidth.Maximum = new decimal(new int[] {
            3999,
            0,
            0,
            131072});
            this.nudEqWidth.Minimum = new decimal(new int[] {
            95,
            0,
            0,
            131072});
            this.nudEqWidth.Name = "nudEqWidth";
            this.nudEqWidth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudEqWidth.Size = new System.Drawing.Size(108, 40);
            this.nudEqWidth.TabIndex = 422;
            this.nudEqWidth.Tag = "";
            this.nudEqWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudEqWidth.Value = new decimal(new int[] {
            2390,
            0,
            0,
            131072});
            this.nudEqWidth.ValueChanged += new System.EventHandler(this.nudEqWidth_ValueChanged);
            this.nudEqWidth.Enter += new System.EventHandler(this.nudEqWidth_Enter);
            // 
            // nudWheelSpacing
            // 
            this.nudWheelSpacing.BackColor = System.Drawing.Color.AliceBlue;
            this.nudWheelSpacing.DecimalPlaces = 2;
            this.nudWheelSpacing.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWheelSpacing.InterceptArrowKeys = false;
            this.nudWheelSpacing.Location = new System.Drawing.Point(9, 243);
            this.nudWheelSpacing.Maximum = new decimal(new int[] {
            425,
            0,
            0,
            131072});
            this.nudWheelSpacing.Minimum = new decimal(new int[] {
            55,
            0,
            0,
            131072});
            this.nudWheelSpacing.Name = "nudWheelSpacing";
            this.nudWheelSpacing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudWheelSpacing.Size = new System.Drawing.Size(108, 40);
            this.nudWheelSpacing.TabIndex = 423;
            this.nudWheelSpacing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudWheelSpacing.Value = new decimal(new int[] {
            17,
            0,
            0,
            65536});
            this.nudWheelSpacing.ValueChanged += new System.EventHandler(this.nudWheelSpacing_ValueChanged);
            this.nudWheelSpacing.Enter += new System.EventHandler(this.nudWheelSpacing_Enter);
            // 
            // lblSmallSnapRight
            // 
            this.lblSmallSnapRight.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSmallSnapRight.Location = new System.Drawing.Point(5, 126);
            this.lblSmallSnapRight.Name = "lblSmallSnapRight";
            this.lblSmallSnapRight.Size = new System.Drawing.Size(104, 29);
            this.lblSmallSnapRight.TabIndex = 424;
            this.lblSmallSnapRight.Text = "Width (m)";
            this.lblSmallSnapRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 30);
            this.label1.TabIndex = 425;
            this.label1.Text = "Track (m)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(79, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 431;
            this.label5.Text = "1/2 W (m)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudPasses
            // 
            this.nudPasses.BackColor = System.Drawing.Color.AliceBlue;
            this.nudPasses.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPasses.InterceptArrowKeys = false;
            this.nudPasses.Location = new System.Drawing.Point(82, 329);
            this.nudPasses.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudPasses.Name = "nudPasses";
            this.nudPasses.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudPasses.Size = new System.Drawing.Size(82, 40);
            this.nudPasses.TabIndex = 433;
            this.nudPasses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudPasses.Value = new decimal(new int[] {
            777,
            0,
            0,
            0});
            this.nudPasses.ValueChanged += new System.EventHandler(this.nudPasses_ValueChanged);
            this.nudPasses.Enter += new System.EventHandler(this.nudPasses_Enter);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 24);
            this.label3.TabIndex = 435;
            this.label3.Text = "Passes";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(148, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 24);
            this.label7.TabIndex = 437;
            this.label7.Text = "Offset";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Visible = false;
            // 
            // nudOffset
            // 
            this.nudOffset.BackColor = System.Drawing.Color.AliceBlue;
            this.nudOffset.DecimalPlaces = 2;
            this.nudOffset.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudOffset.InterceptArrowKeys = false;
            this.nudOffset.Location = new System.Drawing.Point(143, 243);
            this.nudOffset.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudOffset.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.nudOffset.Name = "nudOffset";
            this.nudOffset.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudOffset.Size = new System.Drawing.Size(100, 40);
            this.nudOffset.TabIndex = 436;
            this.nudOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudOffset.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.nudOffset.Visible = false;
            this.nudOffset.ValueChanged += new System.EventHandler(this.nudOffset_ValueChanged);
            this.nudOffset.Enter += new System.EventHandler(this.nudOffset_Enter);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel3.Location = new System.Drawing.Point(2, 376);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(245, 5);
            this.panel3.TabIndex = 458;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(99, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 26);
            this.label2.TabIndex = 459;
            this.label2.Text = "10 cm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMode
            // 
            this.btnMode.FlatAppearance.BorderSize = 0;
            this.btnMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMode.Image = global::AgOpenGPS.Properties.Resources.TramOff;
            this.btnMode.Location = new System.Drawing.Point(158, 222);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(72, 62);
            this.btnMode.TabIndex = 460;
            this.btnMode.UseVisualStyleBackColor = true;
            this.btnMode.Click += new System.EventHandler(this.btnMode_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnLeft.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnLeft.FlatAppearance.BorderSize = 0;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.Image = global::AgOpenGPS.Properties.Resources.SnapLeft;
            this.btnLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLeft.Location = new System.Drawing.Point(19, 78);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(70, 39);
            this.btnLeft.TabIndex = 456;
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.Transparent;
            this.btnRight.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.Image = global::AgOpenGPS.Properties.Resources.SnapRight;
            this.btnRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRight.Location = new System.Drawing.Point(161, 78);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(70, 39);
            this.btnRight.TabIndex = 457;
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnTriggerDistanceDn
            // 
            this.btnTriggerDistanceDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTriggerDistanceDn.FlatAppearance.BorderSize = 0;
            this.btnTriggerDistanceDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTriggerDistanceDn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTriggerDistanceDn.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnTriggerDistanceDn.Location = new System.Drawing.Point(18, 319);
            this.btnTriggerDistanceDn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTriggerDistanceDn.Name = "btnTriggerDistanceDn";
            this.btnTriggerDistanceDn.Size = new System.Drawing.Size(48, 54);
            this.btnTriggerDistanceDn.TabIndex = 439;
            this.btnTriggerDistanceDn.UseVisualStyleBackColor = true;
            this.btnTriggerDistanceDn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTriggerDistanceDn_MouseDown);
            // 
            // btnTriggerDistanceUp
            // 
            this.btnTriggerDistanceUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTriggerDistanceUp.FlatAppearance.BorderSize = 0;
            this.btnTriggerDistanceUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTriggerDistanceUp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTriggerDistanceUp.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnTriggerDistanceUp.Location = new System.Drawing.Point(177, 319);
            this.btnTriggerDistanceUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTriggerDistanceUp.Name = "btnTriggerDistanceUp";
            this.btnTriggerDistanceUp.Size = new System.Drawing.Size(48, 54);
            this.btnTriggerDistanceUp.TabIndex = 440;
            this.btnTriggerDistanceUp.UseVisualStyleBackColor = true;
            this.btnTriggerDistanceUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTriggerDistanceUp_MouseDown);
            // 
            // btnSwapAB
            // 
            this.btnSwapAB.FlatAppearance.BorderSize = 0;
            this.btnSwapAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwapAB.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwapAB.Image = global::AgOpenGPS.Properties.Resources.ABSwapPoints;
            this.btnSwapAB.Location = new System.Drawing.Point(158, 135);
            this.btnSwapAB.Name = "btnSwapAB";
            this.btnSwapAB.Size = new System.Drawing.Size(72, 62);
            this.btnSwapAB.TabIndex = 438;
            this.btnSwapAB.UseVisualStyleBackColor = true;
            this.btnSwapAB.Click += new System.EventHandler(this.btnSwapAB_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.SwitchOff;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(19, 396);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(58, 58);
            this.btnCancel.TabIndex = 421;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdjLeft
            // 
            this.btnAdjLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnAdjLeft.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnAdjLeft.FlatAppearance.BorderSize = 0;
            this.btnAdjLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjLeft.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnAdjLeft.Image = global::AgOpenGPS.Properties.Resources.ArrowLeft;
            this.btnAdjLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdjLeft.Location = new System.Drawing.Point(-1, 12);
            this.btnAdjLeft.Name = "btnAdjLeft";
            this.btnAdjLeft.Size = new System.Drawing.Size(76, 45);
            this.btnAdjLeft.TabIndex = 416;
            this.btnAdjLeft.UseVisualStyleBackColor = false;
            this.btnAdjLeft.Click += new System.EventHandler(this.btnAdjLeft_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExit.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnExit.Location = new System.Drawing.Point(147, 398);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 58);
            this.btnExit.TabIndex = 234;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdjRight
            // 
            this.btnAdjRight.BackColor = System.Drawing.Color.Transparent;
            this.btnAdjRight.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnAdjRight.FlatAppearance.BorderSize = 0;
            this.btnAdjRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjRight.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnAdjRight.Image = global::AgOpenGPS.Properties.Resources.ArrowRight;
            this.btnAdjRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdjRight.Location = new System.Drawing.Point(181, 12);
            this.btnAdjRight.Name = "btnAdjRight";
            this.btnAdjRight.Size = new System.Drawing.Size(76, 45);
            this.btnAdjRight.TabIndex = 415;
            this.btnAdjRight.UseVisualStyleBackColor = false;
            this.btnAdjRight.Click += new System.EventHandler(this.btnAdjRight_Click);
            // 
            // FormTram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(256, 466);
            this.ControlBox = false;
            this.Controls.Add(this.btnMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnTriggerDistanceDn);
            this.Controls.Add(this.btnTriggerDistanceUp);
            this.Controls.Add(this.btnSwapAB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudOffset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudPasses);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudWheelSpacing);
            this.Controls.Add(this.nudEqWidth);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdjLeft);
            this.Controls.Add(this.nudSnapAdj);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdjRight);
            this.Controls.Add(this.lblSmallSnapRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTram";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AB Line Tramline";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormTram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSnapAdj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEqWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWheelSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdjLeft;
        private System.Windows.Forms.Button btnAdjRight;
        private System.Windows.Forms.NumericUpDown nudSnapAdj;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudEqWidth;
        private System.Windows.Forms.NumericUpDown nudWheelSpacing;
        private System.Windows.Forms.Label lblSmallSnapRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudPasses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudOffset;
        private System.Windows.Forms.Button btnSwapAB;
        private ProXoft.WinForms.RepeatButton btnTriggerDistanceDn;
        private ProXoft.WinForms.RepeatButton btnTriggerDistanceUp;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMode;
    }
}