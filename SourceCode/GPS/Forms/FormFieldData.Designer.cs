namespace AgOpenGPS
{
    partial class FormFieldData
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
            this.label6 = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAcresRemain = new System.Windows.Forms.Label();
            this.lblWorkRate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalArea = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblApplied = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRemainPercent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(8, 208);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Lat:";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.ForeColor = System.Drawing.Color.White;
            this.lblLatitude.Location = new System.Drawing.Point(48, 208);
            this.lblLatitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(112, 23);
            this.lblLatitude.TabIndex = 12;
            this.lblLatitude.Text = "89.888888";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.ForeColor = System.Drawing.Color.White;
            this.lblLongitude.Location = new System.Drawing.Point(48, 233);
            this.lblLongitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(144, 23);
            this.lblLongitude.TabIndex = 13;
            this.lblLongitude.Text = "-128.1234567";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 233);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Lon:";
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.AutoSize = true;
            this.lblTimeRemaining.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeRemaining.ForeColor = System.Drawing.Color.White;
            this.lblTimeRemaining.Location = new System.Drawing.Point(95, 155);
            this.lblTimeRemaining.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(65, 23);
            this.lblTimeRemaining.TabIndex = 479;
            this.lblTimeRemaining.Text = "08:25";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 478;
            this.label2.Text = "Remain:";
            // 
            // lblAcresRemain
            // 
            this.lblAcresRemain.AutoSize = true;
            this.lblAcresRemain.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcresRemain.ForeColor = System.Drawing.Color.White;
            this.lblAcresRemain.Location = new System.Drawing.Point(95, 127);
            this.lblAcresRemain.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAcresRemain.Name = "lblAcresRemain";
            this.lblAcresRemain.Size = new System.Drawing.Size(73, 23);
            this.lblAcresRemain.TabIndex = 480;
            this.lblAcresRemain.Text = "135 ac";
            // 
            // lblWorkRate
            // 
            this.lblWorkRate.AutoSize = true;
            this.lblWorkRate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkRate.ForeColor = System.Drawing.Color.White;
            this.lblWorkRate.Location = new System.Drawing.Point(74, 5);
            this.lblWorkRate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWorkRate.Name = "lblWorkRate";
            this.lblWorkRate.Size = new System.Drawing.Size(112, 23);
            this.lblWorkRate.TabIndex = 482;
            this.lblWorkRate.Text = "21.5 ha/hr";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(11, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 23);
            this.label3.TabIndex = 481;
            this.label3.Text = "Rate:";
            // 
            // lblTotalArea
            // 
            this.lblTotalArea.AutoSize = true;
            this.lblTotalArea.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalArea.ForeColor = System.Drawing.Color.White;
            this.lblTotalArea.Location = new System.Drawing.Point(95, 48);
            this.lblTotalArea.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTotalArea.Name = "lblTotalArea";
            this.lblTotalArea.Size = new System.Drawing.Size(73, 23);
            this.lblTotalArea.TabIndex = 484;
            this.lblTotalArea.Text = "150 ac";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(39, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 23);
            this.label4.TabIndex = 483;
            this.label4.Text = "Total:";
            // 
            // lblApplied
            // 
            this.lblApplied.AutoSize = true;
            this.lblApplied.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplied.ForeColor = System.Drawing.Color.White;
            this.lblApplied.Location = new System.Drawing.Point(95, 75);
            this.lblApplied.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblApplied.Name = "lblApplied";
            this.lblApplied.Size = new System.Drawing.Size(61, 23);
            this.lblApplied.TabIndex = 486;
            this.lblApplied.Text = "50 ac";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(18, 75);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 23);
            this.label8.TabIndex = 485;
            this.label8.Text = "Applied:";
            // 
            // lblRemainPercent
            // 
            this.lblRemainPercent.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainPercent.ForeColor = System.Drawing.Color.White;
            this.lblRemainPercent.Location = new System.Drawing.Point(17, 155);
            this.lblRemainPercent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRemainPercent.Name = "lblRemainPercent";
            this.lblRemainPercent.Size = new System.Drawing.Size(76, 23);
            this.lblRemainPercent.TabIndex = 487;
            this.lblRemainPercent.Text = "76%";
            this.lblRemainPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 18);
            this.label1.TabIndex = 488;
            this.label1.Text = "____________________";
            // 
            // FormFieldData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(202, 269);
            this.Controls.Add(this.lblRemainPercent);
            this.Controls.Add(this.lblApplied);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTotalArea);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWorkRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblAcresRemain);
            this.Controls.Add(this.lblTimeRemaining);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFieldData";
            this.ShowInTaskbar = false;
            this.Text = "System Data";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTimeRemaining;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAcresRemain;
        private System.Windows.Forms.Label lblWorkRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblApplied;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRemainPercent;
        private System.Windows.Forms.Label label1;
    }
}