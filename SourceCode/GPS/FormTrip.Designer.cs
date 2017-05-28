namespace AgOpenGPS
{
    partial class FormTrip
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
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nudSetTrip = new System.Windows.Forms.NumericUpDown();
            this.btnReset1 = new System.Windows.Forms.Button();
            this.btnUp = new ProXoft.WinForms.RepeatButton();
            this.btnDown = new ProXoft.WinForms.RepeatButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDnAlarm = new ProXoft.WinForms.RepeatButton();
            this.btnUpAlarm = new ProXoft.WinForms.RepeatButton();
            this.btnResetAlarm = new System.Windows.Forms.Button();
            this.nudAlarm = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetTrip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlarm)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Update Area";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // nudSetTrip
            // 
            this.nudSetTrip.DecimalPlaces = 1;
            this.nudSetTrip.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSetTrip.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSetTrip.Location = new System.Drawing.Point(44, 43);
            this.nudSetTrip.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSetTrip.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudSetTrip.Name = "nudSetTrip";
            this.nudSetTrip.Size = new System.Drawing.Size(175, 71);
            this.nudSetTrip.TabIndex = 5;
            this.nudSetTrip.ValueChanged += new System.EventHandler(this.nudSetTrip_ValueChanged);
            // 
            // btnReset1
            // 
            this.btnReset1.BackgroundImage = global::AgOpenGPS.Properties.Resources.ResetTrip;
            this.btnReset1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReset1.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset1.Location = new System.Drawing.Point(33, 146);
            this.btnReset1.Name = "btnReset1";
            this.btnReset1.Size = new System.Drawing.Size(186, 72);
            this.btnReset1.TabIndex = 6;
            this.btnReset1.UseVisualStyleBackColor = true;
            this.btnReset1.Click += new System.EventHandler(this.btnReset1_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.BackgroundImage = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Location = new System.Drawing.Point(236, 39);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(80, 80);
            this.btnUp.TabIndex = 120;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseDown);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.BackgroundImage = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.Location = new System.Drawing.Point(236, 143);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(80, 80);
            this.btnDown.TabIndex = 121;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseDown);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnOK.Location = new System.Drawing.Point(459, 259);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(223, 72);
            this.btnOK.TabIndex = 122;
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnDnAlarm
            // 
            this.btnDnAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDnAlarm.BackgroundImage = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnDnAlarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDnAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDnAlarm.Location = new System.Drawing.Point(602, 143);
            this.btnDnAlarm.Name = "btnDnAlarm";
            this.btnDnAlarm.Size = new System.Drawing.Size(80, 80);
            this.btnDnAlarm.TabIndex = 127;
            this.btnDnAlarm.UseVisualStyleBackColor = true;
            this.btnDnAlarm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDnAlarm_MouseDown);
            // 
            // btnUpAlarm
            // 
            this.btnUpAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpAlarm.BackgroundImage = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnUpAlarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpAlarm.Location = new System.Drawing.Point(602, 39);
            this.btnUpAlarm.Name = "btnUpAlarm";
            this.btnUpAlarm.Size = new System.Drawing.Size(80, 80);
            this.btnUpAlarm.TabIndex = 126;
            this.btnUpAlarm.UseVisualStyleBackColor = true;
            this.btnUpAlarm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUpAlarm_MouseDown);
            // 
            // btnResetAlarm
            // 
            this.btnResetAlarm.BackgroundImage = global::AgOpenGPS.Properties.Resources.ResetTrip;
            this.btnResetAlarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnResetAlarm.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetAlarm.Location = new System.Drawing.Point(400, 146);
            this.btnResetAlarm.Name = "btnResetAlarm";
            this.btnResetAlarm.Size = new System.Drawing.Size(186, 72);
            this.btnResetAlarm.TabIndex = 125;
            this.btnResetAlarm.UseVisualStyleBackColor = true;
            this.btnResetAlarm.Click += new System.EventHandler(this.btnResetAlarm_Click);
            // 
            // nudAlarm
            // 
            this.nudAlarm.DecimalPlaces = 1;
            this.nudAlarm.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAlarm.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudAlarm.Location = new System.Drawing.Point(411, 43);
            this.nudAlarm.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAlarm.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudAlarm.Name = "nudAlarm";
            this.nudAlarm.Size = new System.Drawing.Size(175, 71);
            this.nudAlarm.TabIndex = 124;
            this.nudAlarm.ValueChanged += new System.EventHandler(this.nudAlarm_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(406, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 32);
            this.label2.TabIndex = 123;
            this.label2.Text = "Set Alarm Value **";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(163, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 25);
            this.label4.TabIndex = 128;
            this.label4.Text = "** Hit Reset to Disable Alarm";
            // 
            // FormTrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 345);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDnAlarm);
            this.Controls.Add(this.btnUpAlarm);
            this.Controls.Add(this.btnResetAlarm);
            this.Controls.Add(this.nudAlarm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnReset1);
            this.Controls.Add(this.nudSetTrip);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormTrip";
            this.Text = "Trip Area Settings";
            this.Load += new System.EventHandler(this.FormTrip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSetTrip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlarm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown nudSetTrip;
        private System.Windows.Forms.Button btnReset1;
        private ProXoft.WinForms.RepeatButton btnUp;
        private ProXoft.WinForms.RepeatButton btnDown;
        private System.Windows.Forms.Button btnOK;
        private ProXoft.WinForms.RepeatButton btnDnAlarm;
        private ProXoft.WinForms.RepeatButton btnUpAlarm;
        private System.Windows.Forms.Button btnResetAlarm;
        private System.Windows.Forms.NumericUpDown nudAlarm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}