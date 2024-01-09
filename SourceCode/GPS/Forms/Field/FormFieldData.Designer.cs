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
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAreaRemain = new System.Windows.Forms.Label();
            this.lblWorkRate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalArea = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblApplied = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRemainPercent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblActualLessOverlap = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblOverlapPercent = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblActualRemain = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 6000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.AutoSize = true;
            this.lblTimeRemaining.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeRemaining.ForeColor = System.Drawing.Color.White;
            this.lblTimeRemaining.Location = new System.Drawing.Point(87, 153);
            this.lblTimeRemaining.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(18, 23);
            this.lblTimeRemaining.TabIndex = 479;
            this.lblTimeRemaining.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 478;
            this.label2.Text = "Remain:";
            // 
            // lblAreaRemain
            // 
            this.lblAreaRemain.AutoSize = true;
            this.lblAreaRemain.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaRemain.ForeColor = System.Drawing.Color.White;
            this.lblAreaRemain.Location = new System.Drawing.Point(87, 95);
            this.lblAreaRemain.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAreaRemain.Name = "lblAreaRemain";
            this.lblAreaRemain.Size = new System.Drawing.Size(18, 23);
            this.lblAreaRemain.TabIndex = 480;
            this.lblAreaRemain.Text = "-";
            // 
            // lblWorkRate
            // 
            this.lblWorkRate.AutoSize = true;
            this.lblWorkRate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkRate.ForeColor = System.Drawing.Color.White;
            this.lblWorkRate.Location = new System.Drawing.Point(58, 325);
            this.lblWorkRate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWorkRate.Name = "lblWorkRate";
            this.lblWorkRate.Size = new System.Drawing.Size(18, 23);
            this.lblWorkRate.TabIndex = 482;
            this.lblWorkRate.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 325);
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
            this.lblTotalArea.Location = new System.Drawing.Point(76, 0);
            this.lblTotalArea.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTotalArea.Name = "lblTotalArea";
            this.lblTotalArea.Size = new System.Drawing.Size(18, 23);
            this.lblTotalArea.TabIndex = 484;
            this.lblTotalArea.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(23, 0);
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
            this.lblApplied.Location = new System.Drawing.Point(87, 66);
            this.lblApplied.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblApplied.Name = "lblApplied";
            this.lblApplied.Size = new System.Drawing.Size(18, 23);
            this.lblApplied.TabIndex = 486;
            this.lblApplied.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(13, 66);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 23);
            this.label8.TabIndex = 485;
            this.label8.Text = "Applied:";
            // 
            // lblRemainPercent
            // 
            this.lblRemainPercent.AutoSize = true;
            this.lblRemainPercent.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainPercent.ForeColor = System.Drawing.Color.White;
            this.lblRemainPercent.Location = new System.Drawing.Point(87, 123);
            this.lblRemainPercent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRemainPercent.Name = "lblRemainPercent";
            this.lblRemainPercent.Size = new System.Drawing.Size(18, 23);
            this.lblRemainPercent.TabIndex = 487;
            this.lblRemainPercent.Text = "-";
            this.lblRemainPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 19);
            this.label1.TabIndex = 488;
            this.label1.Text = "_________________";
            // 
            // lblActualLessOverlap
            // 
            this.lblActualLessOverlap.AutoSize = true;
            this.lblActualLessOverlap.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualLessOverlap.ForeColor = System.Drawing.Color.White;
            this.lblActualLessOverlap.Location = new System.Drawing.Point(85, 229);
            this.lblActualLessOverlap.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblActualLessOverlap.Name = "lblActualLessOverlap";
            this.lblActualLessOverlap.Size = new System.Drawing.Size(18, 23);
            this.lblActualLessOverlap.TabIndex = 490;
            this.lblActualLessOverlap.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(9, 229);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 23);
            this.label6.TabIndex = 489;
            this.label6.Text = "Applied:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(7, 203);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 19);
            this.label7.TabIndex = 491;
            this.label7.Text = "_________________";
            // 
            // lblOverlapPercent
            // 
            this.lblOverlapPercent.AutoSize = true;
            this.lblOverlapPercent.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverlapPercent.ForeColor = System.Drawing.Color.White;
            this.lblOverlapPercent.Location = new System.Drawing.Point(86, 287);
            this.lblOverlapPercent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOverlapPercent.Name = "lblOverlapPercent";
            this.lblOverlapPercent.Size = new System.Drawing.Size(18, 23);
            this.lblOverlapPercent.TabIndex = 493;
            this.lblOverlapPercent.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(9, 287);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 23);
            this.label9.TabIndex = 492;
            this.label9.Text = "Overlap:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(51, 193);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 23);
            this.label10.TabIndex = 494;
            this.label10.Text = "Actual";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(45, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 23);
            this.label5.TabIndex = 495;
            this.label5.Text = "Worked";
            // 
            // lblActualRemain
            // 
            this.lblActualRemain.AutoSize = true;
            this.lblActualRemain.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualRemain.ForeColor = System.Drawing.Color.White;
            this.lblActualRemain.Location = new System.Drawing.Point(86, 258);
            this.lblActualRemain.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblActualRemain.Name = "lblActualRemain";
            this.lblActualRemain.Size = new System.Drawing.Size(18, 23);
            this.lblActualRemain.TabIndex = 497;
            this.lblActualRemain.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(10, 258);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 23);
            this.label12.TabIndex = 496;
            this.label12.Text = "Remain:";
            // 
            // FormFieldData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(176, 356);
            this.Controls.Add(this.lblWorkRate);
            this.Controls.Add(this.lblActualRemain);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblOverlapPercent);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblActualLessOverlap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblRemainPercent);
            this.Controls.Add(this.lblApplied);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTotalArea);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblAreaRemain);
            this.Controls.Add(this.lblTimeRemaining);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFieldData";
            this.ShowInTaskbar = false;
            this.Text = "System Data";
            this.Load += new System.EventHandler(this.FormFieldData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTimeRemaining;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAreaRemain;
        private System.Windows.Forms.Label lblWorkRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblApplied;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRemainPercent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActualLessOverlap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblOverlapPercent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblActualRemain;
        private System.Windows.Forms.Label label12;
    }
}