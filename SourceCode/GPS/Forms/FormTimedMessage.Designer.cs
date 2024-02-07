namespace AgOpenGPS
{
    partial class FormTimedMessage
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblMessage2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.lblMessage.Location = new System.Drawing.Point(28, 23);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(115, 29);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Message";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblMessage2
            // 
            this.lblMessage2.AutoSize = true;
            this.lblMessage2.Font = new System.Drawing.Font("Tahoma", 18F);
            this.lblMessage2.Location = new System.Drawing.Point(66, 78);
            this.lblMessage2.Name = "lblMessage2";
            this.lblMessage2.Size = new System.Drawing.Size(127, 29);
            this.lblMessage2.TabIndex = 1;
            this.lblMessage2.Text = "Message 2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OldLace;
            this.panel1.Controls.Add(this.lblMessage2);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 137);
            this.panel1.TabIndex = 2;
            // 
            // FormTimedMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(394, 151);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormTimedMessage";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AgOpenGPS Message";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblMessage2;
        private System.Windows.Forms.Panel panel1;
    }
}