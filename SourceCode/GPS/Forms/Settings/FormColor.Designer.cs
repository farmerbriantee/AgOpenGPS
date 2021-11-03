namespace AgOpenGPS
{
    partial class FormColor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormColor));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bntOK = new System.Windows.Forms.Button();
            this.btnFrameDay = new System.Windows.Forms.Button();
            this.btnFrameNight = new System.Windows.Forms.Button();
            this.btnFieldNight = new System.Windows.Forms.Button();
            this.btnFieldDay = new System.Windows.Forms.Button();
            this.btnSwap = new System.Windows.Forms.Button();
            this.btnDayText = new System.Windows.Forms.Button();
            this.btnNightText = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVehicleColor = new System.Windows.Forms.Button();
            this.hsbarOpacity = new System.Windows.Forms.HScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOpacityPercent = new System.Windows.Forms.Label();
            this.cboxIsImage = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            // 
            // bntOK
            // 
            this.bntOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.FlatAppearance.BorderSize = 0;
            this.bntOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntOK.Location = new System.Drawing.Point(511, 398);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(66, 65);
            this.bntOK.TabIndex = 0;
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // btnFrameDay
            // 
            this.btnFrameDay.BackColor = System.Drawing.Color.Transparent;
            this.btnFrameDay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFrameDay.FlatAppearance.BorderSize = 0;
            this.btnFrameDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrameDay.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnFrameDay.Image = ((System.Drawing.Image)(resources.GetObject("btnFrameDay.Image")));
            this.btnFrameDay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFrameDay.Location = new System.Drawing.Point(247, 12);
            this.btnFrameDay.Name = "btnFrameDay";
            this.btnFrameDay.Size = new System.Drawing.Size(59, 57);
            this.btnFrameDay.TabIndex = 4;
            this.btnFrameDay.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFrameDay.UseVisualStyleBackColor = false;
            this.btnFrameDay.Click += new System.EventHandler(this.btnFrameDay_Click);
            // 
            // btnFrameNight
            // 
            this.btnFrameNight.BackColor = System.Drawing.Color.Transparent;
            this.btnFrameNight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFrameNight.FlatAppearance.BorderSize = 0;
            this.btnFrameNight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrameNight.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnFrameNight.Image = ((System.Drawing.Image)(resources.GetObject("btnFrameNight.Image")));
            this.btnFrameNight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFrameNight.Location = new System.Drawing.Point(247, 181);
            this.btnFrameNight.Name = "btnFrameNight";
            this.btnFrameNight.Size = new System.Drawing.Size(59, 57);
            this.btnFrameNight.TabIndex = 5;
            this.btnFrameNight.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFrameNight.UseVisualStyleBackColor = false;
            this.btnFrameNight.Click += new System.EventHandler(this.btnFrameNight_Click);
            // 
            // btnFieldNight
            // 
            this.btnFieldNight.BackColor = System.Drawing.Color.Transparent;
            this.btnFieldNight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFieldNight.FlatAppearance.BorderSize = 0;
            this.btnFieldNight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFieldNight.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnFieldNight.Image = ((System.Drawing.Image)(resources.GetObject("btnFieldNight.Image")));
            this.btnFieldNight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFieldNight.Location = new System.Drawing.Point(164, 280);
            this.btnFieldNight.Name = "btnFieldNight";
            this.btnFieldNight.Size = new System.Drawing.Size(59, 57);
            this.btnFieldNight.TabIndex = 7;
            this.btnFieldNight.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFieldNight.UseVisualStyleBackColor = false;
            this.btnFieldNight.Click += new System.EventHandler(this.btnFieldNight_Click);
            // 
            // btnFieldDay
            // 
            this.btnFieldDay.BackColor = System.Drawing.Color.Transparent;
            this.btnFieldDay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFieldDay.FlatAppearance.BorderSize = 0;
            this.btnFieldDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFieldDay.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnFieldDay.Image = ((System.Drawing.Image)(resources.GetObject("btnFieldDay.Image")));
            this.btnFieldDay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFieldDay.Location = new System.Drawing.Point(164, 94);
            this.btnFieldDay.Name = "btnFieldDay";
            this.btnFieldDay.Size = new System.Drawing.Size(59, 57);
            this.btnFieldDay.TabIndex = 6;
            this.btnFieldDay.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFieldDay.UseVisualStyleBackColor = false;
            this.btnFieldDay.Click += new System.EventHandler(this.btnFieldDay_Click);
            // 
            // btnSwap
            // 
            this.btnSwap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSwap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSwap.FlatAppearance.BorderSize = 0;
            this.btnSwap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwap.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSwap.Image = global::AgOpenGPS.Properties.Resources.ConD_AutoDayNight;
            this.btnSwap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSwap.Location = new System.Drawing.Point(12, 388);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(121, 65);
            this.btnSwap.TabIndex = 10;
            this.btnSwap.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // btnDayText
            // 
            this.btnDayText.BackColor = System.Drawing.Color.Transparent;
            this.btnDayText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDayText.FlatAppearance.BorderSize = 0;
            this.btnDayText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDayText.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDayText.Image = ((System.Drawing.Image)(resources.GetObject("btnDayText.Image")));
            this.btnDayText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDayText.Location = new System.Drawing.Point(12, 38);
            this.btnDayText.Name = "btnDayText";
            this.btnDayText.Size = new System.Drawing.Size(59, 57);
            this.btnDayText.TabIndex = 11;
            this.btnDayText.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDayText.UseVisualStyleBackColor = false;
            this.btnDayText.Click += new System.EventHandler(this.btnDayText_Click);
            // 
            // btnNightText
            // 
            this.btnNightText.BackColor = System.Drawing.Color.Transparent;
            this.btnNightText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNightText.FlatAppearance.BorderSize = 0;
            this.btnNightText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNightText.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnNightText.Image = ((System.Drawing.Image)(resources.GetObject("btnNightText.Image")));
            this.btnNightText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNightText.Location = new System.Drawing.Point(12, 224);
            this.btnNightText.Name = "btnNightText";
            this.btnNightText.Size = new System.Drawing.Size(59, 57);
            this.btnNightText.TabIndex = 12;
            this.btnNightText.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNightText.UseVisualStyleBackColor = false;
            this.btnNightText.Click += new System.EventHandler(this.btnNightText_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(17, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "ABC123";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(17, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "ABC123";
            // 
            // btnVehicleColor
            // 
            this.btnVehicleColor.BackColor = System.Drawing.Color.Transparent;
            this.btnVehicleColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVehicleColor.FlatAppearance.BorderSize = 0;
            this.btnVehicleColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVehicleColor.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnVehicleColor.Image = ((System.Drawing.Image)(resources.GetObject("btnVehicleColor.Image")));
            this.btnVehicleColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVehicleColor.Location = new System.Drawing.Point(437, 147);
            this.btnVehicleColor.Name = "btnVehicleColor";
            this.btnVehicleColor.Size = new System.Drawing.Size(59, 57);
            this.btnVehicleColor.TabIndex = 15;
            this.btnVehicleColor.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVehicleColor.UseVisualStyleBackColor = false;
            this.btnVehicleColor.Click += new System.EventHandler(this.btnVehicleColor_Click);
            // 
            // hsbarOpacity
            // 
            this.hsbarOpacity.LargeChange = 1;
            this.hsbarOpacity.Location = new System.Drawing.Point(373, 224);
            this.hsbarOpacity.Minimum = 2;
            this.hsbarOpacity.Name = "hsbarOpacity";
            this.hsbarOpacity.Size = new System.Drawing.Size(179, 43);
            this.hsbarOpacity.TabIndex = 344;
            this.hsbarOpacity.Value = 5;
            this.hsbarOpacity.ValueChanged += new System.EventHandler(this.hsbarOpacity_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 345;
            this.label3.Text = "Opacity";
            // 
            // lblOpacityPercent
            // 
            this.lblOpacityPercent.AutoSize = true;
            this.lblOpacityPercent.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpacityPercent.ForeColor = System.Drawing.Color.Black;
            this.lblOpacityPercent.Location = new System.Drawing.Point(466, 271);
            this.lblOpacityPercent.Name = "lblOpacityPercent";
            this.lblOpacityPercent.Size = new System.Drawing.Size(63, 25);
            this.lblOpacityPercent.TabIndex = 346;
            this.lblOpacityPercent.Text = "65%";
            // 
            // cboxIsImage
            // 
            this.cboxIsImage.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsImage.BackgroundImage = global::AgOpenGPS.Properties.Resources.vehiclePageTractor;
            this.cboxIsImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cboxIsImage.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxIsImage.FlatAppearance.BorderSize = 2;
            this.cboxIsImage.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.cboxIsImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsImage.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsImage.Location = new System.Drawing.Point(373, 12);
            this.cboxIsImage.Name = "cboxIsImage";
            this.cboxIsImage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxIsImage.Size = new System.Drawing.Size(179, 116);
            this.cboxIsImage.TabIndex = 462;
            this.cboxIsImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsImage.UseVisualStyleBackColor = true;
            // 
            // FormColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BackgroundImage = global::AgOpenGPS.Properties.Resources.ColorBackGnd;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(577, 465);
            this.ControlBox = false;
            this.Controls.Add(this.cboxIsImage);
            this.Controls.Add(this.lblOpacityPercent);
            this.Controls.Add(this.btnVehicleColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hsbarOpacity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNightText);
            this.Controls.Add(this.btnDayText);
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.btnFieldNight);
            this.Controls.Add(this.btnFieldDay);
            this.Controls.Add(this.btnFrameNight);
            this.Controls.Add(this.btnFrameDay);
            this.Controls.Add(this.bntOK);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormColor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Color Set";
            this.Load += new System.EventHandler(this.FormDisplaySettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.Button btnFrameDay;
        private System.Windows.Forms.Button btnFrameNight;
        private System.Windows.Forms.Button btnFieldNight;
        private System.Windows.Forms.Button btnFieldDay;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.Button btnDayText;
        private System.Windows.Forms.Button btnNightText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVehicleColor;
        private System.Windows.Forms.HScrollBar hsbarOpacity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOpacityPercent;
        private System.Windows.Forms.CheckBox cboxIsImage;
    }
}