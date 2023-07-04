namespace AgOpenGPS
{
    partial class FormTreePlant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTreePlant));
            this.lblDistanceTree = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.lblStepDistance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnZeroDistance = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblTrees = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudTreeSpacing = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nudRadius = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudTreeSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDistanceTree
            // 
            this.lblDistanceTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDistanceTree.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistanceTree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDistanceTree.Location = new System.Drawing.Point(98, 56);
            this.lblDistanceTree.Name = "lblDistanceTree";
            this.lblDistanceTree.Size = new System.Drawing.Size(92, 35);
            this.lblDistanceTree.TabIndex = 305;
            this.lblDistanceTree.Text = "0";
            this.lblDistanceTree.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(242, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 19);
            this.label12.TabIndex = 306;
            this.label12.Text = "Spacing (cm)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStepDistance
            // 
            this.lblStepDistance.AutoSize = true;
            this.lblStepDistance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepDistance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblStepDistance.Location = new System.Drawing.Point(12, 186);
            this.lblStepDistance.Name = "lblStepDistance";
            this.lblStepDistance.Size = new System.Drawing.Size(45, 25);
            this.lblStepDistance.TabIndex = 308;
            this.lblStepDistance.Text = "1.2";
            this.lblStepDistance.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 35);
            this.label1.TabIndex = 309;
            this.label1.Text = "Dist";
            // 
            // btnZeroDistance
            // 
            this.btnZeroDistance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnZeroDistance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroDistance.ForeColor = System.Drawing.Color.Black;
            this.btnZeroDistance.Image = ((System.Drawing.Image)(resources.GetObject("btnZeroDistance.Image")));
            this.btnZeroDistance.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnZeroDistance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZeroDistance.Location = new System.Drawing.Point(132, 291);
            this.btnZeroDistance.Name = "btnZeroDistance";
            this.btnZeroDistance.Size = new System.Drawing.Size(108, 96);
            this.btnZeroDistance.TabIndex = 142;
            this.btnZeroDistance.Text = "Begin";
            this.btnZeroDistance.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnZeroDistance.UseVisualStyleBackColor = false;
            this.btnZeroDistance.Click += new System.EventHandler(this.btnZeroDistance_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnStop.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnStop.Image = global::AgOpenGPS.Properties.Resources.SwitchOff;
            this.btnStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStop.Location = new System.Drawing.Point(262, 291);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 96);
            this.btnStop.TabIndex = 141;
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSpeed.Location = new System.Drawing.Point(104, 9);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(86, 35);
            this.lblSpeed.TabIndex = 310;
            this.lblSpeed.Text = "1.2";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTrees
            // 
            this.lblTrees.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrees.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTrees.Location = new System.Drawing.Point(83, 114);
            this.lblTrees.Name = "lblTrees";
            this.lblTrees.Size = new System.Drawing.Size(107, 35);
            this.lblTrees.TabIndex = 312;
            this.lblTrees.Text = "11";
            this.lblTrees.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(5, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 35);
            this.label3.TabIndex = 313;
            this.label3.Text = "Trees";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nudTreeSpacing
            // 
            this.nudTreeSpacing.BackColor = System.Drawing.Color.AliceBlue;
            this.nudTreeSpacing.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTreeSpacing.Location = new System.Drawing.Point(231, 39);
            this.nudTreeSpacing.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudTreeSpacing.Name = "nudTreeSpacing";
            this.nudTreeSpacing.Size = new System.Drawing.Size(121, 52);
            this.nudTreeSpacing.TabIndex = 314;
            this.nudTreeSpacing.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudTreeSpacing.ValueChanged += new System.EventHandler(this.NudTreeSpacing_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 35);
            this.label2.TabIndex = 311;
            this.label2.Text = "Speed";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(275, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 65);
            this.button1.TabIndex = 315;
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nudRadius
            // 
            this.nudRadius.BackColor = System.Drawing.Color.AliceBlue;
            this.nudRadius.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRadius.Location = new System.Drawing.Point(246, 227);
            this.nudRadius.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudRadius.Name = "nudRadius";
            this.nudRadius.Size = new System.Drawing.Size(106, 52);
            this.nudRadius.TabIndex = 317;
            this.nudRadius.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRadius.ValueChanged += new System.EventHandler(this.nudRadius_ValueChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(240, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 19);
            this.label4.TabIndex = 316;
            this.label4.Text = "Radius (cm)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AgOpenGPS.Properties.Resources.SwitchOff;
            this.pictureBox1.InitialImage = global::AgOpenGPS.Properties.Resources.SwitchOn;
            this.pictureBox1.Location = new System.Drawing.Point(196, 227);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 318;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Image = global::AgOpenGPS.Properties.Resources.FlagDeleteAll;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(12, 291);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 96);
            this.button2.TabIndex = 319;
            this.button2.Text = "CLEAR";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormTreePlant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(362, 399);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.nudRadius);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.nudTreeSpacing);
            this.Controls.Add(this.lblStepDistance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTrees);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblDistanceTree);
            this.Controls.Add(this.btnZeroDistance);
            this.Controls.Add(this.btnStop);
            this.ForeColor = System.Drawing.Color.Lime;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTreePlant";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tree Plant Control";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormTreePlant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudTreeSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnZeroDistance;
        private System.Windows.Forms.Label lblDistanceTree;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblStepDistance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblTrees;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudTreeSpacing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nudRadius;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
    }
}