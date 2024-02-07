namespace AgOpenGPS
{
    partial class FormWebCam
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.webCameraControl1 = new WebEye.Controls.WinForms.WebCameraControl.WebCameraControl();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 234);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 27);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopButton.BackgroundImage = global::AgOpenGPS.Properties.Resources.Stop;
            this.stopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.stopButton.Enabled = false;
            this.stopButton.FlatAppearance.BorderSize = 0;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.Location = new System.Drawing.Point(319, 229);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 37);
            this.stopButton.TabIndex = 13;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click_1);
            // 
            // webCameraControl1
            // 
            this.webCameraControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webCameraControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.webCameraControl1.Location = new System.Drawing.Point(0, 0);
            this.webCameraControl1.Name = "webCameraControl1";
            this.webCameraControl1.Size = new System.Drawing.Size(398, 229);
            this.webCameraControl1.TabIndex = 10;
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startButton.BackgroundImage = global::AgOpenGPS.Properties.Resources.Play;
            this.startButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.startButton.Enabled = false;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(226, 229);
            this.startButton.Margin = new System.Windows.Forms.Padding(2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 37);
            this.startButton.TabIndex = 12;
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click_1);
            // 
            // FormWebCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(398, 268);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.webCameraControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormWebCam";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WebCam";
            this.Load += new System.EventHandler(this.FormWebCam_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private WebEye.Controls.WinForms.WebCameraControl.WebCameraControl webCameraControl1;
    }
}