namespace AgOpenGPS
{
    partial class FormSimCoords
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.bntOK = new System.Windows.Forms.Button();
            this.nudLongitude = new System.Windows.Forms.NumericUpDown();
            this.nudLatitude = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLatitude)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(169, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 72);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bntOK
            // 
            this.bntOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntOK.Location = new System.Drawing.Point(282, 338);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(156, 72);
            this.bntOK.TabIndex = 4;
            this.bntOK.Text = "Save";
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // nudLongitude
            // 
            this.nudLongitude.DecimalPlaces = 7;
            this.nudLongitude.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold);
            this.nudLongitude.Location = new System.Drawing.Point(20, 187);
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
            this.nudLongitude.Size = new System.Drawing.Size(398, 65);
            this.nudLongitude.TabIndex = 48;
            this.nudLongitude.Value = new decimal(new int[] {
            1781234567,
            0,
            0,
            -2147024896});
            this.nudLongitude.ValueChanged += new System.EventHandler(this.nudLongitude_ValueChanged);
            // 
            // nudLatitude
            // 
            this.nudLatitude.DecimalPlaces = 7;
            this.nudLatitude.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold);
            this.nudLatitude.Location = new System.Drawing.Point(46, 60);
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
            this.nudLatitude.Size = new System.Drawing.Size(372, 65);
            this.nudLatitude.TabIndex = 49;
            this.nudLatitude.Value = new decimal(new int[] {
            881234567,
            0,
            0,
            -2147024896});
            this.nudLatitude.ValueChanged += new System.EventHandler(this.nudLatitude_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(41, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(216, 25);
            this.label18.TabIndex = 178;
            this.label18.Text = "Latitude ( +90 to -90)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(15, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 25);
            this.label1.TabIndex = 179;
            this.label1.Text = "Longitude (+180 to -180)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(262, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 25);
            this.label2.TabIndex = 180;
            this.label2.Text = "Restart Required!";
            // 
            // FormSimCoords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 422);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.nudLatitude);
            this.Controls.Add(this.nudLongitude);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.bntOK);
            this.Name = "FormSimCoords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Coordinates";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormSimCoords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLatitude)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.NumericUpDown nudLongitude;
        private System.Windows.Forms.NumericUpDown nudLatitude;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}