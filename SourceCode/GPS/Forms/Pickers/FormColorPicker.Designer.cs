namespace AgOpenGPS
{
    partial class FormColorPicker
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
            this.btnSave = new System.Windows.Forms.Button();
            this.colorPick = new Keypad.ColorPickerControl();
            this.btnDay = new System.Windows.Forms.Button();
            this.btnNight = new System.Windows.Forms.Button();
            this.btn01 = new System.Windows.Forms.Button();
            this.btn09 = new System.Windows.Forms.Button();
            this.btn10 = new System.Windows.Forms.Button();
            this.btn02 = new System.Windows.Forms.Button();
            this.btn12 = new System.Windows.Forms.Button();
            this.btn04 = new System.Windows.Forms.Button();
            this.btn11 = new System.Windows.Forms.Button();
            this.btn03 = new System.Windows.Forms.Button();
            this.btn14 = new System.Windows.Forms.Button();
            this.btn06 = new System.Windows.Forms.Button();
            this.btn13 = new System.Windows.Forms.Button();
            this.btn05 = new System.Windows.Forms.Button();
            this.btn15 = new System.Windows.Forms.Button();
            this.btn07 = new System.Windows.Forms.Button();
            this.btn00 = new System.Windows.Forms.Button();
            this.btn08 = new System.Windows.Forms.Button();
            this.chkUse = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.btnSave.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnSave.Location = new System.Drawing.Point(713, 426);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 65);
            this.btnSave.TabIndex = 215;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // colorPick
            // 
            this.colorPick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorPick.Location = new System.Drawing.Point(5, 6);
            this.colorPick.Name = "colorPick";
            this.colorPick.SelectedColor = System.Drawing.SystemColors.Control;
            this.colorPick.Size = new System.Drawing.Size(600, 300);
            this.colorPick.TabIndex = 216;
            this.colorPick.Text = "colorPickerControl1";
            this.colorPick.ColorPicked += new System.EventHandler(this.colorPick_ColorPicked);
            // 
            // btnDay
            // 
            this.btnDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDay.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDay.Location = new System.Drawing.Point(627, 6);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(196, 144);
            this.btnDay.TabIndex = 217;
            this.btnDay.Text = "Day";
            this.btnDay.UseVisualStyleBackColor = true;
            // 
            // btnNight
            // 
            this.btnNight.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNight.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNight.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNight.ForeColor = System.Drawing.SystemColors.Window;
            this.btnNight.Location = new System.Drawing.Point(627, 165);
            this.btnNight.Name = "btnNight";
            this.btnNight.Size = new System.Drawing.Size(196, 141);
            this.btnNight.TabIndex = 218;
            this.btnNight.Text = "Night";
            this.btnNight.UseVisualStyleBackColor = false;
            // 
            // btn01
            // 
            this.btn01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn01.BackColor = System.Drawing.Color.Coral;
            this.btn01.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn01.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn01.Location = new System.Drawing.Point(75, 22);
            this.btn01.Name = "btn01";
            this.btn01.Size = new System.Drawing.Size(64, 64);
            this.btn01.TabIndex = 219;
            this.btn01.UseVisualStyleBackColor = false;
            this.btn01.Click += new System.EventHandler(this.btn01_Click);
            // 
            // btn09
            // 
            this.btn09.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn09.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn09.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn09.Location = new System.Drawing.Point(75, 99);
            this.btn09.Name = "btn09";
            this.btn09.Size = new System.Drawing.Size(64, 64);
            this.btn09.TabIndex = 220;
            this.btn09.UseVisualStyleBackColor = true;
            this.btn09.Click += new System.EventHandler(this.btn09_Click);
            // 
            // btn10
            // 
            this.btn10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn10.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn10.Location = new System.Drawing.Point(145, 99);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(64, 64);
            this.btn10.TabIndex = 222;
            this.btn10.UseVisualStyleBackColor = true;
            this.btn10.Click += new System.EventHandler(this.btn10_Click);
            // 
            // btn02
            // 
            this.btn02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn02.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn02.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn02.Location = new System.Drawing.Point(145, 22);
            this.btn02.Name = "btn02";
            this.btn02.Size = new System.Drawing.Size(64, 64);
            this.btn02.TabIndex = 221;
            this.btn02.UseVisualStyleBackColor = true;
            this.btn02.Click += new System.EventHandler(this.btn02_Click);
            // 
            // btn12
            // 
            this.btn12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn12.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn12.Location = new System.Drawing.Point(285, 99);
            this.btn12.Name = "btn12";
            this.btn12.Size = new System.Drawing.Size(64, 64);
            this.btn12.TabIndex = 226;
            this.btn12.UseVisualStyleBackColor = true;
            this.btn12.Click += new System.EventHandler(this.btn12_Click);
            // 
            // btn04
            // 
            this.btn04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn04.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn04.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn04.Location = new System.Drawing.Point(285, 22);
            this.btn04.Name = "btn04";
            this.btn04.Size = new System.Drawing.Size(64, 64);
            this.btn04.TabIndex = 225;
            this.btn04.UseVisualStyleBackColor = true;
            this.btn04.Click += new System.EventHandler(this.btn04_Click);
            // 
            // btn11
            // 
            this.btn11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn11.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn11.Location = new System.Drawing.Point(215, 99);
            this.btn11.Name = "btn11";
            this.btn11.Size = new System.Drawing.Size(64, 64);
            this.btn11.TabIndex = 224;
            this.btn11.UseVisualStyleBackColor = true;
            this.btn11.Click += new System.EventHandler(this.btn11_Click);
            // 
            // btn03
            // 
            this.btn03.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn03.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn03.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn03.Location = new System.Drawing.Point(215, 22);
            this.btn03.Name = "btn03";
            this.btn03.Size = new System.Drawing.Size(64, 64);
            this.btn03.TabIndex = 223;
            this.btn03.UseVisualStyleBackColor = true;
            this.btn03.Click += new System.EventHandler(this.btn03_Click);
            // 
            // btn14
            // 
            this.btn14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn14.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn14.Location = new System.Drawing.Point(425, 99);
            this.btn14.Name = "btn14";
            this.btn14.Size = new System.Drawing.Size(64, 64);
            this.btn14.TabIndex = 230;
            this.btn14.UseVisualStyleBackColor = true;
            this.btn14.Click += new System.EventHandler(this.btn14_Click);
            // 
            // btn06
            // 
            this.btn06.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn06.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn06.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn06.Location = new System.Drawing.Point(425, 22);
            this.btn06.Name = "btn06";
            this.btn06.Size = new System.Drawing.Size(64, 64);
            this.btn06.TabIndex = 229;
            this.btn06.UseVisualStyleBackColor = true;
            this.btn06.Click += new System.EventHandler(this.btn06_Click);
            // 
            // btn13
            // 
            this.btn13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn13.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn13.Location = new System.Drawing.Point(355, 99);
            this.btn13.Name = "btn13";
            this.btn13.Size = new System.Drawing.Size(64, 64);
            this.btn13.TabIndex = 228;
            this.btn13.UseVisualStyleBackColor = true;
            this.btn13.Click += new System.EventHandler(this.btn13_Click);
            // 
            // btn05
            // 
            this.btn05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn05.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn05.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn05.Location = new System.Drawing.Point(355, 22);
            this.btn05.Name = "btn05";
            this.btn05.Size = new System.Drawing.Size(64, 64);
            this.btn05.TabIndex = 227;
            this.btn05.UseVisualStyleBackColor = true;
            this.btn05.Click += new System.EventHandler(this.btn05_Click);
            // 
            // btn15
            // 
            this.btn15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn15.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn15.Location = new System.Drawing.Point(495, 99);
            this.btn15.Name = "btn15";
            this.btn15.Size = new System.Drawing.Size(64, 64);
            this.btn15.TabIndex = 232;
            this.btn15.UseVisualStyleBackColor = true;
            this.btn15.Click += new System.EventHandler(this.btn15_Click);
            // 
            // btn07
            // 
            this.btn07.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn07.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn07.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn07.Location = new System.Drawing.Point(495, 22);
            this.btn07.Name = "btn07";
            this.btn07.Size = new System.Drawing.Size(64, 64);
            this.btn07.TabIndex = 231;
            this.btn07.UseVisualStyleBackColor = true;
            this.btn07.Click += new System.EventHandler(this.btn07_Click);
            // 
            // btn00
            // 
            this.btn00.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn00.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn00.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn00.Location = new System.Drawing.Point(5, 22);
            this.btn00.Name = "btn00";
            this.btn00.Size = new System.Drawing.Size(64, 64);
            this.btn00.TabIndex = 234;
            this.btn00.UseVisualStyleBackColor = true;
            this.btn00.Click += new System.EventHandler(this.btn00_Click);
            // 
            // btn08
            // 
            this.btn08.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn08.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn08.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn08.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn08.Location = new System.Drawing.Point(5, 99);
            this.btn08.Name = "btn08";
            this.btn08.Size = new System.Drawing.Size(64, 64);
            this.btn08.TabIndex = 233;
            this.btn08.UseVisualStyleBackColor = false;
            this.btn08.Click += new System.EventHandler(this.btn08_Click);
            // 
            // chkUse
            // 
            this.chkUse.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkUse.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chkUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUse.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUse.Image = global::AgOpenGPS.Properties.Resources.FileSave;
            this.chkUse.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUse.Location = new System.Drawing.Point(627, 343);
            this.chkUse.Name = "chkUse";
            this.chkUse.Size = new System.Drawing.Size(190, 65);
            this.chkUse.TabIndex = 257;
            this.chkUse.Text = "<-";
            this.chkUse.UseVisualStyleBackColor = true;
            this.chkUse.CheckedChanged += new System.EventHandler(this.chkUse_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn01);
            this.groupBox1.Controls.Add(this.btn09);
            this.groupBox1.Controls.Add(this.btn00);
            this.groupBox1.Controls.Add(this.btn02);
            this.groupBox1.Controls.Add(this.btn08);
            this.groupBox1.Controls.Add(this.btn10);
            this.groupBox1.Controls.Add(this.btn15);
            this.groupBox1.Controls.Add(this.btn03);
            this.groupBox1.Controls.Add(this.btn07);
            this.groupBox1.Controls.Add(this.btn11);
            this.groupBox1.Controls.Add(this.btn14);
            this.groupBox1.Controls.Add(this.btn04);
            this.groupBox1.Controls.Add(this.btn06);
            this.groupBox1.Controls.Add(this.btn12);
            this.groupBox1.Controls.Add(this.btn13);
            this.groupBox1.Controls.Add(this.btn05);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 322);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 169);
            this.groupBox1.TabIndex = 258;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Preset Color";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(594, 427);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 65);
            this.btnCancel.TabIndex = 259;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // FormColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(833, 500);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkUse);
            this.Controls.Add(this.btnNight);
            this.Controls.Add(this.btnDay);
            this.Controls.Add(this.colorPick);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FormColorPicker";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Color Picker";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormColorPicker_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private Keypad.ColorPickerControl colorPick;
        private System.Windows.Forms.Button btnDay;
        private System.Windows.Forms.Button btnNight;
        private System.Windows.Forms.Button btn01;
        private System.Windows.Forms.Button btn09;
        private System.Windows.Forms.Button btn10;
        private System.Windows.Forms.Button btn02;
        private System.Windows.Forms.Button btn12;
        private System.Windows.Forms.Button btn04;
        private System.Windows.Forms.Button btn11;
        private System.Windows.Forms.Button btn03;
        private System.Windows.Forms.Button btn14;
        private System.Windows.Forms.Button btn06;
        private System.Windows.Forms.Button btn13;
        private System.Windows.Forms.Button btn05;
        private System.Windows.Forms.Button btn15;
        private System.Windows.Forms.Button btn07;
        private System.Windows.Forms.Button btn00;
        private System.Windows.Forms.Button btn08;
        private System.Windows.Forms.CheckBox chkUse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
    }
}