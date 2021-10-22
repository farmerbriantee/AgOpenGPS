namespace AgOpenGPS
{
    partial class FormEnterAB
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
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.nudLatitude = new System.Windows.Forms.NumericUpDown();
            this.nudLongitude = new System.Windows.Forms.NumericUpDown();
            this.nudLatitudeB = new System.Windows.Forms.NumericUpDown();
            this.nudLongitudeB = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudHeading = new System.Windows.Forms.NumericUpDown();
            this.btnChooseType = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEnterManual = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudLatitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLatitudeB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitudeB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(510, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 25);
            this.label9.TabIndex = 202;
            this.label9.Text = "( +180 to -180 )";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(215, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 25);
            this.label8.TabIndex = 201;
            this.label8.Text = "( +90 to -90)";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(457, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 25);
            this.label1.TabIndex = 200;
            this.label1.Text = "Longitude";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(160, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(252, 25);
            this.label18.TabIndex = 199;
            this.label18.Text = "Latitude";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudLatitude
            // 
            this.nudLatitude.BackColor = System.Drawing.Color.AliceBlue;
            this.nudLatitude.DecimalPlaces = 7;
            this.nudLatitude.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLatitude.Location = new System.Drawing.Point(152, 68);
            this.nudLatitude.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudLatitude.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.nudLatitude.Name = "nudLatitude";
            this.nudLatitude.ReadOnly = true;
            this.nudLatitude.Size = new System.Drawing.Size(274, 52);
            this.nudLatitude.TabIndex = 198;
            this.nudLatitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudLatitude.Click += new System.EventHandler(this.nudLatitude_Click);
            // 
            // nudLongitude
            // 
            this.nudLongitude.BackColor = System.Drawing.Color.AliceBlue;
            this.nudLongitude.DecimalPlaces = 7;
            this.nudLongitude.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLongitude.Location = new System.Drawing.Point(448, 68);
            this.nudLongitude.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudLongitude.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nudLongitude.Name = "nudLongitude";
            this.nudLongitude.ReadOnly = true;
            this.nudLongitude.Size = new System.Drawing.Size(298, 52);
            this.nudLongitude.TabIndex = 197;
            this.nudLongitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudLongitude.Click += new System.EventHandler(this.nudLongitude_Click);
            // 
            // nudLatitudeB
            // 
            this.nudLatitudeB.BackColor = System.Drawing.Color.AliceBlue;
            this.nudLatitudeB.DecimalPlaces = 7;
            this.nudLatitudeB.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLatitudeB.Location = new System.Drawing.Point(153, 239);
            this.nudLatitudeB.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudLatitudeB.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.nudLatitudeB.Name = "nudLatitudeB";
            this.nudLatitudeB.ReadOnly = true;
            this.nudLatitudeB.Size = new System.Drawing.Size(274, 52);
            this.nudLatitudeB.TabIndex = 204;
            this.nudLatitudeB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudLatitudeB.Click += new System.EventHandler(this.nudLatitudeB_Click);
            // 
            // nudLongitudeB
            // 
            this.nudLongitudeB.BackColor = System.Drawing.Color.AliceBlue;
            this.nudLongitudeB.DecimalPlaces = 7;
            this.nudLongitudeB.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLongitudeB.Location = new System.Drawing.Point(449, 239);
            this.nudLongitudeB.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudLongitudeB.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nudLongitudeB.Name = "nudLongitudeB";
            this.nudLongitudeB.ReadOnly = true;
            this.nudLongitudeB.Size = new System.Drawing.Size(298, 52);
            this.nudLongitudeB.TabIndex = 203;
            this.nudLongitudeB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudLongitudeB.Click += new System.EventHandler(this.nudLongitudeB_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(22, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 34);
            this.label2.TabIndex = 205;
            this.label2.Text = "Point A";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudHeading
            // 
            this.nudHeading.BackColor = System.Drawing.Color.AliceBlue;
            this.nudHeading.DecimalPlaces = 6;
            this.nudHeading.Enabled = false;
            this.nudHeading.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHeading.InterceptArrowKeys = false;
            this.nudHeading.Location = new System.Drawing.Point(352, 239);
            this.nudHeading.Maximum = new decimal(new int[] {
            817405951,
            838,
            0,
            655360});
            this.nudHeading.Name = "nudHeading";
            this.nudHeading.ReadOnly = true;
            this.nudHeading.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudHeading.Size = new System.Drawing.Size(230, 52);
            this.nudHeading.TabIndex = 414;
            this.nudHeading.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudHeading.Visible = false;
            this.nudHeading.Click += new System.EventHandler(this.nudHeading_Click);
            // 
            // btnChooseType
            // 
            this.btnChooseType.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnChooseType.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnChooseType.FlatAppearance.BorderSize = 2;
            this.btnChooseType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseType.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnChooseType.Location = new System.Drawing.Point(334, 153);
            this.btnChooseType.Name = "btnChooseType";
            this.btnChooseType.Size = new System.Drawing.Size(207, 53);
            this.btnChooseType.TabIndex = 419;
            this.btnChooseType.Text = "AB or A+";
            this.btnChooseType.UseVisualStyleBackColor = false;
            this.btnChooseType.Click += new System.EventHandler(this.btnChooseType_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(212, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 34);
            this.label4.TabIndex = 422;
            this.label4.Text = "Heading";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(22, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 34);
            this.label5.TabIndex = 423;
            this.label5.Text = "Point B";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEnterManual
            // 
            this.btnEnterManual.BackColor = System.Drawing.Color.Transparent;
            this.btnEnterManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEnterManual.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEnterManual.Enabled = false;
            this.btnEnterManual.FlatAppearance.BorderSize = 0;
            this.btnEnterManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnterManual.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnEnterManual.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnEnterManual.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnterManual.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEnterManual.Location = new System.Drawing.Point(664, 330);
            this.btnEnterManual.Name = "btnEnterManual";
            this.btnEnterManual.Size = new System.Drawing.Size(106, 77);
            this.btnEnterManual.TabIndex = 428;
            this.btnEnterManual.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEnterManual.UseVisualStyleBackColor = false;
            this.btnEnterManual.Click += new System.EventHandler(this.btnEnterManual_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.CausesValidation = false;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(86, 346);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.MaxLength = 100;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(384, 44);
            this.textBox1.TabIndex = 429;
            this.textBox1.Text = "Line Name Here";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(538, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 77);
            this.btnCancel.TabIndex = 430;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormEnterAB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(777, 418);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnEnterManual);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnChooseType);
            this.Controls.Add(this.nudHeading);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudLatitudeB);
            this.Controls.Add(this.nudLongitudeB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.nudLatitude);
            this.Controls.Add(this.nudLongitude);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEnterAB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter AB or A+";
            this.Load += new System.EventHandler(this.FormEnterAB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudLatitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLatitudeB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitudeB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown nudLatitude;
        private System.Windows.Forms.NumericUpDown nudLongitude;
        private System.Windows.Forms.NumericUpDown nudLatitudeB;
        private System.Windows.Forms.NumericUpDown nudLongitudeB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudHeading;
        private System.Windows.Forms.Button btnChooseType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEnterManual;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCancel;
    }
}