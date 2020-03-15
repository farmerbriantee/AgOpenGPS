namespace RateApp
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPortsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSec3 = new System.Windows.Forms.Button();
            this.btnSec2 = new System.Windows.Forms.Button();
            this.btnSec1 = new System.Windows.Forms.Button();
            this.btnSec5 = new System.Windows.Forms.Button();
            this.btnSec4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSect = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(446, 37);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialPortsMenu});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(61, 33);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // serialPortsMenu
            // 
            this.serialPortsMenu.Name = "serialPortsMenu";
            this.serialPortsMenu.Size = new System.Drawing.Size(206, 34);
            this.serialPortsMenu.Text = "Serial Ports";
            this.serialPortsMenu.Click += new System.EventHandler(this.serialPortsMenu_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(350, 37);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 23);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            // 
            // btnSec3
            // 
            this.btnSec3.Location = new System.Drawing.Point(180, 108);
            this.btnSec3.Name = "btnSec3";
            this.btnSec3.Size = new System.Drawing.Size(75, 43);
            this.btnSec3.TabIndex = 3;
            this.btnSec3.Text = "3";
            this.btnSec3.UseVisualStyleBackColor = true;
            // 
            // btnSec2
            // 
            this.btnSec2.Location = new System.Drawing.Point(98, 108);
            this.btnSec2.Name = "btnSec2";
            this.btnSec2.Size = new System.Drawing.Size(75, 43);
            this.btnSec2.TabIndex = 4;
            this.btnSec2.Text = "2";
            this.btnSec2.UseVisualStyleBackColor = true;
            // 
            // btnSec1
            // 
            this.btnSec1.Location = new System.Drawing.Point(16, 108);
            this.btnSec1.Name = "btnSec1";
            this.btnSec1.Size = new System.Drawing.Size(75, 43);
            this.btnSec1.TabIndex = 5;
            this.btnSec1.Text = "1";
            this.btnSec1.UseVisualStyleBackColor = true;
            // 
            // btnSec5
            // 
            this.btnSec5.Location = new System.Drawing.Point(344, 108);
            this.btnSec5.Name = "btnSec5";
            this.btnSec5.Size = new System.Drawing.Size(75, 43);
            this.btnSec5.TabIndex = 6;
            this.btnSec5.Text = "5";
            this.btnSec5.UseVisualStyleBackColor = true;
            // 
            // btnSec4
            // 
            this.btnSec4.Location = new System.Drawing.Point(262, 108);
            this.btnSec4.Name = "btnSec4";
            this.btnSec4.Size = new System.Drawing.Size(75, 43);
            this.btnSec4.TabIndex = 7;
            this.btnSec4.Text = "4";
            this.btnSec4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Section 1-8 byte:";
            // 
            // lblSect
            // 
            this.lblSect.AutoSize = true;
            this.lblSect.Location = new System.Drawing.Point(171, 72);
            this.lblSect.Name = "lblSect";
            this.lblSect.Size = new System.Drawing.Size(20, 23);
            this.lblSect.TabIndex = 9;
            this.lblSect.Text = "7";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "From Machine Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "From AutoSteer Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Speed:";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(84, 201);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(20, 23);
            this.lblSpeed.TabIndex = 13;
            this.lblSpeed.Text = "8";
            // 
            // FormRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 242);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSec4);
            this.Controls.Add(this.btnSec5);
            this.Controls.Add(this.btnSec1);
            this.Controls.Add(this.btnSec2);
            this.Controls.Add(this.btnSec3);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormRate";
            this.Text = "Rate Application";
            this.Load += new System.EventHandler(this.FormRate_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialPortsMenu;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSec3;
        private System.Windows.Forms.Button btnSec2;
        private System.Windows.Forms.Button btnSec1;
        private System.Windows.Forms.Button btnSec5;
        private System.Windows.Forms.Button btnSec4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSpeed;
    }
}

