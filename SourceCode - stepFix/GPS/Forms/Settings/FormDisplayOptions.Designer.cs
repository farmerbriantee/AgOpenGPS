namespace AgOpenGPS
{
    partial class FormDisplayOptions
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
            this.chkExtraGuides = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.bntOK = new System.Windows.Forms.Button();
            this.chkCompass = new System.Windows.Forms.CheckBox();
            this.chkSky = new System.Windows.Forms.CheckBox();
            this.chkSpeedo = new System.Windows.Forms.CheckBox();
            this.chkDayNight = new System.Windows.Forms.CheckBox();
            this.chkGrid = new System.Windows.Forms.CheckBox();
            this.chkPursuitLines = new System.Windows.Forms.CheckBox();
            this.chkLogNMEA = new System.Windows.Forms.CheckBox();
            this.chkStartFullScreen = new System.Windows.Forms.CheckBox();
            this.chkPolygons = new System.Windows.Forms.CheckBox();
            this.chkUTurnOn = new System.Windows.Forms.CheckBox();
            this.unitsGroupBox = new System.Windows.Forms.GroupBox();
            this.rbtnImperial = new System.Windows.Forms.RadioButton();
            this.rbtnMetric = new System.Windows.Forms.RadioButton();
            this.unitsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkExtraGuides
            // 
            this.chkExtraGuides.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkExtraGuides.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkExtraGuides.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkExtraGuides.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExtraGuides.Location = new System.Drawing.Point(265, 14);
            this.chkExtraGuides.Name = "chkExtraGuides";
            this.chkExtraGuides.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkExtraGuides.Size = new System.Drawing.Size(192, 65);
            this.chkExtraGuides.TabIndex = 256;
            this.chkExtraGuides.Text = "Extra Guides";
            this.chkExtraGuides.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkExtraGuides.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(501, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 67);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // bntOK
            // 
            this.bntOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntOK.Location = new System.Drawing.Point(611, 382);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(161, 67);
            this.bntOK.TabIndex = 0;
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // chkCompass
            // 
            this.chkCompass.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCompass.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkCompass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCompass.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompass.Location = new System.Drawing.Point(12, 237);
            this.chkCompass.Name = "chkCompass";
            this.chkCompass.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkCompass.Size = new System.Drawing.Size(192, 65);
            this.chkCompass.TabIndex = 317;
            this.chkCompass.Text = "Compass";
            this.chkCompass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCompass.UseVisualStyleBackColor = true;
            // 
            // chkSky
            // 
            this.chkSky.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSky.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkSky.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSky.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSky.Location = new System.Drawing.Point(12, 15);
            this.chkSky.Name = "chkSky";
            this.chkSky.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSky.Size = new System.Drawing.Size(192, 65);
            this.chkSky.TabIndex = 319;
            this.chkSky.Text = "Sky";
            this.chkSky.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSky.UseVisualStyleBackColor = true;
            // 
            // chkSpeedo
            // 
            this.chkSpeedo.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSpeedo.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkSpeedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSpeedo.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSpeedo.Location = new System.Drawing.Point(12, 311);
            this.chkSpeedo.Name = "chkSpeedo";
            this.chkSpeedo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSpeedo.Size = new System.Drawing.Size(192, 65);
            this.chkSpeedo.TabIndex = 318;
            this.chkSpeedo.Text = "Speedometer";
            this.chkSpeedo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSpeedo.UseVisualStyleBackColor = true;
            // 
            // chkDayNight
            // 
            this.chkDayNight.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDayNight.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkDayNight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDayNight.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDayNight.Location = new System.Drawing.Point(12, 385);
            this.chkDayNight.Name = "chkDayNight";
            this.chkDayNight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDayNight.Size = new System.Drawing.Size(192, 65);
            this.chkDayNight.TabIndex = 321;
            this.chkDayNight.Text = "Auto Day/Night";
            this.chkDayNight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDayNight.UseVisualStyleBackColor = true;
            // 
            // chkGrid
            // 
            this.chkGrid.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkGrid.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkGrid.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGrid.Location = new System.Drawing.Point(12, 89);
            this.chkGrid.Name = "chkGrid";
            this.chkGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkGrid.Size = new System.Drawing.Size(192, 65);
            this.chkGrid.TabIndex = 320;
            this.chkGrid.Text = "Grid";
            this.chkGrid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkGrid.UseVisualStyleBackColor = true;
            // 
            // chkPursuitLines
            // 
            this.chkPursuitLines.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkPursuitLines.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkPursuitLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPursuitLines.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPursuitLines.Location = new System.Drawing.Point(265, 239);
            this.chkPursuitLines.Name = "chkPursuitLines";
            this.chkPursuitLines.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPursuitLines.Size = new System.Drawing.Size(192, 65);
            this.chkPursuitLines.TabIndex = 322;
            this.chkPursuitLines.Text = "Pursuit Line";
            this.chkPursuitLines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkPursuitLines.UseVisualStyleBackColor = true;
            // 
            // chkLogNMEA
            // 
            this.chkLogNMEA.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLogNMEA.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkLogNMEA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLogNMEA.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLogNMEA.Location = new System.Drawing.Point(265, 89);
            this.chkLogNMEA.Name = "chkLogNMEA";
            this.chkLogNMEA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkLogNMEA.Size = new System.Drawing.Size(192, 65);
            this.chkLogNMEA.TabIndex = 323;
            this.chkLogNMEA.Text = "Log NMEA";
            this.chkLogNMEA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLogNMEA.UseVisualStyleBackColor = true;
            // 
            // chkStartFullScreen
            // 
            this.chkStartFullScreen.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStartFullScreen.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkStartFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkStartFullScreen.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStartFullScreen.Location = new System.Drawing.Point(12, 163);
            this.chkStartFullScreen.Name = "chkStartFullScreen";
            this.chkStartFullScreen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkStartFullScreen.Size = new System.Drawing.Size(192, 65);
            this.chkStartFullScreen.TabIndex = 324;
            this.chkStartFullScreen.Text = "Start Full Screen";
            this.chkStartFullScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkStartFullScreen.UseVisualStyleBackColor = true;
            // 
            // chkPolygons
            // 
            this.chkPolygons.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkPolygons.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkPolygons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPolygons.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPolygons.Location = new System.Drawing.Point(265, 164);
            this.chkPolygons.Name = "chkPolygons";
            this.chkPolygons.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPolygons.Size = new System.Drawing.Size(192, 65);
            this.chkPolygons.TabIndex = 325;
            this.chkPolygons.Text = "Polygons";
            this.chkPolygons.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkPolygons.UseVisualStyleBackColor = true;
            // 
            // chkUTurnOn
            // 
            this.chkUTurnOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkUTurnOn.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkUTurnOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUTurnOn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUTurnOn.Location = new System.Drawing.Point(265, 311);
            this.chkUTurnOn.Name = "chkUTurnOn";
            this.chkUTurnOn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkUTurnOn.Size = new System.Drawing.Size(192, 65);
            this.chkUTurnOn.TabIndex = 328;
            this.chkUTurnOn.Text = "UTurn Always On";
            this.chkUTurnOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkUTurnOn.UseVisualStyleBackColor = true;
            // 
            // unitsGroupBox
            // 
            this.unitsGroupBox.Controls.Add(this.rbtnImperial);
            this.unitsGroupBox.Controls.Add(this.rbtnMetric);
            this.unitsGroupBox.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitsGroupBox.Location = new System.Drawing.Point(533, 19);
            this.unitsGroupBox.Name = "unitsGroupBox";
            this.unitsGroupBox.Size = new System.Drawing.Size(208, 221);
            this.unitsGroupBox.TabIndex = 329;
            this.unitsGroupBox.TabStop = false;
            this.unitsGroupBox.Text = "Units";
            // 
            // rbtnImperial
            // 
            this.rbtnImperial.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnImperial.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.rbtnImperial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnImperial.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnImperial.Location = new System.Drawing.Point(28, 150);
            this.rbtnImperial.Name = "rbtnImperial";
            this.rbtnImperial.Size = new System.Drawing.Size(137, 43);
            this.rbtnImperial.TabIndex = 1;
            this.rbtnImperial.Text = "Imperial";
            this.rbtnImperial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnImperial.UseVisualStyleBackColor = true;
            // 
            // rbtnMetric
            // 
            this.rbtnMetric.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnMetric.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.rbtnMetric.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnMetric.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnMetric.Location = new System.Drawing.Point(28, 61);
            this.rbtnMetric.Name = "rbtnMetric";
            this.rbtnMetric.Size = new System.Drawing.Size(137, 43);
            this.rbtnMetric.TabIndex = 0;
            this.rbtnMetric.Text = "Metric";
            this.rbtnMetric.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnMetric.UseVisualStyleBackColor = true;
            // 
            // FormDisplayOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.unitsGroupBox);
            this.Controls.Add(this.chkUTurnOn);
            this.Controls.Add(this.chkPolygons);
            this.Controls.Add(this.chkStartFullScreen);
            this.Controls.Add(this.chkLogNMEA);
            this.Controls.Add(this.chkPursuitLines);
            this.Controls.Add(this.chkDayNight);
            this.Controls.Add(this.chkGrid);
            this.Controls.Add(this.chkSky);
            this.Controls.Add(this.chkSpeedo);
            this.Controls.Add(this.chkCompass);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.bntOK);
            this.Controls.Add(this.chkExtraGuides);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDisplayOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Module Configure";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormDisplaySettings_Load);
            this.unitsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox chkExtraGuides;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.CheckBox chkCompass;
        private System.Windows.Forms.CheckBox chkSky;
        private System.Windows.Forms.CheckBox chkSpeedo;
        private System.Windows.Forms.CheckBox chkDayNight;
        private System.Windows.Forms.CheckBox chkGrid;
        private System.Windows.Forms.CheckBox chkPursuitLines;
        private System.Windows.Forms.CheckBox chkLogNMEA;
        private System.Windows.Forms.CheckBox chkStartFullScreen;
        private System.Windows.Forms.CheckBox chkPolygons;
        private System.Windows.Forms.CheckBox chkUTurnOn;
        private System.Windows.Forms.GroupBox unitsGroupBox;
        private System.Windows.Forms.RadioButton rbtnImperial;
        private System.Windows.Forms.RadioButton rbtnMetric;
    }
}