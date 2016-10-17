namespace AgOpenGPS
{
    partial class FormABLine
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
            this.lblABHeading = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblFixHeading = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDnABHeading = new System.Windows.Forms.Button();
            this.btnUpABHeading = new System.Windows.Forms.Button();
            this.btnDeleteAB = new System.Windows.Forms.Button();
            this.btnBPoint = new System.Windows.Forms.Button();
            this.btnAPoint = new System.Windows.Forms.Button();
            this.btnABLineOk = new System.Windows.Forms.Button();
            this.btnDnABHeadingBy1 = new System.Windows.Forms.Button();
            this.btnUpABHeadingBy1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblABHeading
            // 
            this.lblABHeading.AutoSize = true;
            this.lblABHeading.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblABHeading.Location = new System.Drawing.Point(59, 250);
            this.lblABHeading.Name = "lblABHeading";
            this.lblABHeading.Size = new System.Drawing.Size(121, 38);
            this.lblABHeading.TabIndex = 63;
            this.lblABHeading.Text = "000.0";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblFixHeading
            // 
            this.lblFixHeading.AutoSize = true;
            this.lblFixHeading.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixHeading.Location = new System.Drawing.Point(113, 3);
            this.lblFixHeading.Name = "lblFixHeading";
            this.lblFixHeading.Size = new System.Drawing.Size(28, 29);
            this.lblFixHeading.TabIndex = 64;
            this.lblFixHeading.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 65;
            this.label1.Text = "Heading";
            // 
            // btnDnABHeading
            // 
            this.btnDnABHeading.Enabled = false;
            this.btnDnABHeading.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnDnABHeading.Location = new System.Drawing.Point(140, 295);
            this.btnDnABHeading.Name = "btnDnABHeading";
            this.btnDnABHeading.Size = new System.Drawing.Size(74, 80);
            this.btnDnABHeading.TabIndex = 70;
            this.btnDnABHeading.UseVisualStyleBackColor = true;
            this.btnDnABHeading.Click += new System.EventHandler(this.btnDownABHeading_Click);
            // 
            // btnUpABHeading
            // 
            this.btnUpABHeading.Enabled = false;
            this.btnUpABHeading.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnUpABHeading.Location = new System.Drawing.Point(140, 165);
            this.btnUpABHeading.Name = "btnUpABHeading";
            this.btnUpABHeading.Size = new System.Drawing.Size(74, 80);
            this.btnUpABHeading.TabIndex = 69;
            this.btnUpABHeading.UseVisualStyleBackColor = true;
            this.btnUpABHeading.Click += new System.EventHandler(this.btnUpABHeading_Click);
            // 
            // btnDeleteAB
            // 
            this.btnDeleteAB.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteAB.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnDeleteAB.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteAB.Location = new System.Drawing.Point(7, 408);
            this.btnDeleteAB.Name = "btnDeleteAB";
            this.btnDeleteAB.Size = new System.Drawing.Size(86, 87);
            this.btnDeleteAB.TabIndex = 0;
            this.btnDeleteAB.Text = "Delete";
            this.btnDeleteAB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteAB.Click += new System.EventHandler(this.btnDeleteAB_Click);
            // 
            // btnBPoint
            // 
            this.btnBPoint.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBPoint.Image = global::AgOpenGPS.Properties.Resources.LetterBBlue;
            this.btnBPoint.Location = new System.Drawing.Point(147, 48);
            this.btnBPoint.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnBPoint.Name = "btnBPoint";
            this.btnBPoint.Size = new System.Drawing.Size(90, 93);
            this.btnBPoint.TabIndex = 58;
            this.btnBPoint.UseVisualStyleBackColor = true;
            this.btnBPoint.Click += new System.EventHandler(this.btnBPoint_Click);
            // 
            // btnAPoint
            // 
            this.btnAPoint.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAPoint.Image = global::AgOpenGPS.Properties.Resources.LetterABlue;
            this.btnAPoint.Location = new System.Drawing.Point(21, 48);
            this.btnAPoint.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAPoint.Name = "btnAPoint";
            this.btnAPoint.Size = new System.Drawing.Size(90, 93);
            this.btnAPoint.TabIndex = 57;
            this.btnAPoint.UseVisualStyleBackColor = true;
            this.btnAPoint.Click += new System.EventHandler(this.btnAPoint_Click);
            // 
            // btnABLineOk
            // 
            this.btnABLineOk.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnABLineOk.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnABLineOk.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnABLineOk.Location = new System.Drawing.Point(101, 408);
            this.btnABLineOk.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnABLineOk.Name = "btnABLineOk";
            this.btnABLineOk.Size = new System.Drawing.Size(146, 87);
            this.btnABLineOk.TabIndex = 62;
            this.btnABLineOk.Text = "Save";
            this.btnABLineOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnABLineOk.UseVisualStyleBackColor = true;
            this.btnABLineOk.Click += new System.EventHandler(this.btnABLineOk_Click);
            // 
            // btnDnABHeadingBy1
            // 
            this.btnDnABHeadingBy1.Enabled = false;
            this.btnDnABHeadingBy1.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnDnABHeadingBy1.Location = new System.Drawing.Point(44, 295);
            this.btnDnABHeadingBy1.Name = "btnDnABHeadingBy1";
            this.btnDnABHeadingBy1.Size = new System.Drawing.Size(74, 80);
            this.btnDnABHeadingBy1.TabIndex = 73;
            this.btnDnABHeadingBy1.UseVisualStyleBackColor = true;
            this.btnDnABHeadingBy1.Click += new System.EventHandler(this.btnDnABHeadingBy1_Click);
            // 
            // btnUpABHeadingBy1
            // 
            this.btnUpABHeadingBy1.Enabled = false;
            this.btnUpABHeadingBy1.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnUpABHeadingBy1.Location = new System.Drawing.Point(44, 165);
            this.btnUpABHeadingBy1.Name = "btnUpABHeadingBy1";
            this.btnUpABHeadingBy1.Size = new System.Drawing.Size(74, 80);
            this.btnUpABHeadingBy1.TabIndex = 72;
            this.btnUpABHeadingBy1.UseVisualStyleBackColor = true;
            this.btnUpABHeadingBy1.Click += new System.EventHandler(this.btnUpABHeadingBy1_Click);
            // 
            // FormABLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 503);
            this.ControlBox = false;
            this.Controls.Add(this.btnDnABHeadingBy1);
            this.Controls.Add(this.btnUpABHeadingBy1);
            this.Controls.Add(this.btnDnABHeading);
            this.Controls.Add(this.btnUpABHeading);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFixHeading);
            this.Controls.Add(this.lblABHeading);
            this.Controls.Add(this.btnDeleteAB);
            this.Controls.Add(this.btnBPoint);
            this.Controls.Add(this.btnAPoint);
            this.Controls.Add(this.btnABLineOk);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormABLine";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AB Line";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormABLine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteAB;
        private System.Windows.Forms.Button btnBPoint;
        private System.Windows.Forms.Button btnAPoint;
        private System.Windows.Forms.Button btnABLineOk;
        private System.Windows.Forms.Label lblABHeading;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblFixHeading;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpABHeading;
        private System.Windows.Forms.Button btnDnABHeading;
        private System.Windows.Forms.Button btnDnABHeadingBy1;
        private System.Windows.Forms.Button btnUpABHeadingBy1;
    }
}