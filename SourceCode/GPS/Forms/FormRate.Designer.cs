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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRate2Value = new System.Windows.Forms.Label();
            this.lblRate1Value = new System.Windows.Forms.Label();
            this.btnRate1Dn = new ProXoft.WinForms.RepeatButton();
            this.btnRate1Up = new ProXoft.WinForms.RepeatButton();
            this.btnRate2Dn = new ProXoft.WinForms.RepeatButton();
            this.btnRate2Up = new ProXoft.WinForms.RepeatButton();
            this.btnRateOnOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bntOK
            // 
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.Location = new System.Drawing.Point(351, 282);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(156, 72);
            this.bntOK.TabIndex = 4;
            this.bntOK.Text = "Save";
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 37);
            this.label1.TabIndex = 7;
            this.label1.Text = "Rate 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(371, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 37);
            this.label2.TabIndex = 8;
            this.label2.Text = "Rate 2";
            // 
            // lblRate2Value
            // 
            this.lblRate2Value.AutoSize = true;
            this.lblRate2Value.BackColor = System.Drawing.SystemColors.Control;
            this.lblRate2Value.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRate2Value.Location = new System.Drawing.Point(346, 45);
            this.lblRate2Value.Name = "lblRate2Value";
            this.lblRate2Value.Size = new System.Drawing.Size(142, 86);
            this.lblRate2Value.TabIndex = 13;
            this.lblRate2Value.Text = "xxx";
            // 
            // lblRate1Value
            // 
            this.lblRate1Value.AutoSize = true;
            this.lblRate1Value.BackColor = System.Drawing.SystemColors.Control;
            this.lblRate1Value.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRate1Value.Location = new System.Drawing.Point(81, 42);
            this.lblRate1Value.Name = "lblRate1Value";
            this.lblRate1Value.Size = new System.Drawing.Size(142, 86);
            this.lblRate1Value.TabIndex = 12;
            this.lblRate1Value.Text = "xxx";
            // 
            // btnRate1Dn
            // 
            this.btnRate1Dn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRate1Dn.Enabled = false;
            this.btnRate1Dn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRate1Dn.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnRate1Dn.Location = new System.Drawing.Point(161, 131);
            this.btnRate1Dn.Name = "btnRate1Dn";
            this.btnRate1Dn.Size = new System.Drawing.Size(80, 80);
            this.btnRate1Dn.TabIndex = 124;
            this.btnRate1Dn.UseVisualStyleBackColor = true;
            this.btnRate1Dn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRate1Dn_MouseDown);
            // 
            // btnRate1Up
            // 
            this.btnRate1Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRate1Up.Enabled = false;
            this.btnRate1Up.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRate1Up.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnRate1Up.Location = new System.Drawing.Point(48, 131);
            this.btnRate1Up.Name = "btnRate1Up";
            this.btnRate1Up.Size = new System.Drawing.Size(80, 80);
            this.btnRate1Up.TabIndex = 125;
            this.btnRate1Up.UseVisualStyleBackColor = true;
            this.btnRate1Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRate1Up_MouseDown);
            // 
            // btnRate2Dn
            // 
            this.btnRate2Dn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRate2Dn.Enabled = false;
            this.btnRate2Dn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRate2Dn.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnRate2Dn.Location = new System.Drawing.Point(427, 131);
            this.btnRate2Dn.Name = "btnRate2Dn";
            this.btnRate2Dn.Size = new System.Drawing.Size(80, 80);
            this.btnRate2Dn.TabIndex = 126;
            this.btnRate2Dn.UseVisualStyleBackColor = true;
            this.btnRate2Dn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRate2Dn_MouseDown);
            // 
            // btnRate2Up
            // 
            this.btnRate2Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRate2Up.Enabled = false;
            this.btnRate2Up.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRate2Up.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnRate2Up.Location = new System.Drawing.Point(313, 131);
            this.btnRate2Up.Name = "btnRate2Up";
            this.btnRate2Up.Size = new System.Drawing.Size(80, 80);
            this.btnRate2Up.TabIndex = 127;
            this.btnRate2Up.UseVisualStyleBackColor = true;
            this.btnRate2Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRate2Up_MouseDown);
            // 
            // btnRateOnOff
            // 
            this.btnRateOnOff.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRateOnOff.Location = new System.Drawing.Point(48, 282);
            this.btnRateOnOff.Name = "btnRateOnOff";
            this.btnRateOnOff.Size = new System.Drawing.Size(156, 72);
            this.btnRateOnOff.TabIndex = 130;
            this.btnRateOnOff.Text = "Off";
            this.btnRateOnOff.UseVisualStyleBackColor = true;
            this.btnRateOnOff.Click += new System.EventHandler(this.btnRateOnOff_Click);
            // 
            // FormRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 374);
            this.ControlBox = false;
            this.Controls.Add(this.btnRateOnOff);
            this.Controls.Add(this.btnRate2Dn);
            this.Controls.Add(this.btnRate2Up);
            this.Controls.Add(this.btnRate1Dn);
            this.Controls.Add(this.btnRate1Up);
            this.Controls.Add(this.lblRate2Value);
            this.Controls.Add(this.lblRate1Value);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bntOK);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormRate";
            this.Text = " Rate Control Setup";
            this.Load += new System.EventHandler(this.FormRate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRate2Value;
        private System.Windows.Forms.Label lblRate1Value;
        private ProXoft.WinForms.RepeatButton btnRate1Dn;
        private ProXoft.WinForms.RepeatButton btnRate1Up;
        private ProXoft.WinForms.RepeatButton btnRate2Dn;
        private ProXoft.WinForms.RepeatButton btnRate2Up;
        private System.Windows.Forms.Button btnRateOnOff;
    }
}