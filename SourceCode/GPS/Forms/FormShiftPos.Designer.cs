namespace AgOpenGPS
{
    partial class FormShiftPos
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
            this.nudNorth = new System.Windows.Forms.NumericUpDown();
            this.nudEast = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSouth = new ProXoft.WinForms.RepeatButton();
            this.btnNorth = new ProXoft.WinForms.RepeatButton();
            this.btnEast = new ProXoft.WinForms.RepeatButton();
            this.btnWest = new ProXoft.WinForms.RepeatButton();
            this.bntOK = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudNorth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEast)).BeginInit();
            this.SuspendLayout();
            // 
            // nudNorth
            // 
            this.nudNorth.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold);
            this.nudNorth.Location = new System.Drawing.Point(10, 132);
            this.nudNorth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudNorth.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.nudNorth.Name = "nudNorth";
            this.nudNorth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudNorth.Size = new System.Drawing.Size(135, 65);
            this.nudNorth.TabIndex = 154;
            this.nudNorth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNorth.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudNorth.ValueChanged += new System.EventHandler(this.nudNorth_ValueChanged);
            // 
            // nudEast
            // 
            this.nudEast.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold);
            this.nudEast.Location = new System.Drawing.Point(173, 132);
            this.nudEast.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudEast.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.nudEast.Name = "nudEast";
            this.nudEast.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudEast.Size = new System.Drawing.Size(135, 65);
            this.nudEast.TabIndex = 155;
            this.nudEast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudEast.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEast.ValueChanged += new System.EventHandler(this.nudEast_ValueChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(44, 24);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(57, 23);
            this.label27.TabIndex = 156;
            this.label27.Text = "North";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(207, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 158;
            this.label2.Text = "West";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(209, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 23);
            this.label3.TabIndex = 159;
            this.label3.Text = "East";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(43, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 23);
            this.label4.TabIndex = 160;
            this.label4.Text = "South";
            // 
            // btnSouth
            // 
            this.btnSouth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSouth.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.btnSouth.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnSouth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSouth.Location = new System.Drawing.Point(36, 211);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(72, 72);
            this.btnSouth.TabIndex = 192;
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSouth_MouseDown);
            // 
            // btnNorth
            // 
            this.btnNorth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNorth.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.btnNorth.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnNorth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNorth.Location = new System.Drawing.Point(36, 50);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(72, 72);
            this.btnNorth.TabIndex = 193;
            this.btnNorth.UseVisualStyleBackColor = true;
            this.btnNorth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnNorth_MouseDown);
            // 
            // btnEast
            // 
            this.btnEast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEast.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.btnEast.Image = global::AgOpenGPS.Properties.Resources.ArrowRight;
            this.btnEast.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEast.Location = new System.Drawing.Point(197, 211);
            this.btnEast.Name = "btnEast";
            this.btnEast.Size = new System.Drawing.Size(72, 72);
            this.btnEast.TabIndex = 194;
            this.btnEast.UseVisualStyleBackColor = true;
            this.btnEast.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEast_MouseDown);
            // 
            // btnWest
            // 
            this.btnWest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnWest.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.btnWest.Image = global::AgOpenGPS.Properties.Resources.ArrowLeft;
            this.btnWest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnWest.Location = new System.Drawing.Point(197, 50);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(72, 72);
            this.btnWest.TabIndex = 195;
            this.btnWest.UseVisualStyleBackColor = true;
            this.btnWest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnWest_MouseDown);
            // 
            // bntOK
            // 
            this.bntOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntOK.Location = new System.Drawing.Point(164, 333);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(144, 66);
            this.bntOK.TabIndex = 196;
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // btnZero
            // 
            this.btnZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZero.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZero.Location = new System.Drawing.Point(25, 333);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(93, 66);
            this.btnZero.TabIndex = 227;
            this.btnZero.Text = "> 0 <";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // FormShiftPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 411);
            this.Controls.Add(this.btnZero);
            this.Controls.Add(this.bntOK);
            this.Controls.Add(this.btnEast);
            this.Controls.Add(this.btnWest);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnNorth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.nudEast);
            this.Controls.Add(this.nudNorth);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormShiftPos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shift GPS Position (cm)";
            this.Load += new System.EventHandler(this.FormShiftPos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNorth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown nudNorth;
        private System.Windows.Forms.NumericUpDown nudEast;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ProXoft.WinForms.RepeatButton btnSouth;
        private ProXoft.WinForms.RepeatButton btnNorth;
        private ProXoft.WinForms.RepeatButton btnEast;
        private ProXoft.WinForms.RepeatButton btnWest;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.Button btnZero;
    }
}