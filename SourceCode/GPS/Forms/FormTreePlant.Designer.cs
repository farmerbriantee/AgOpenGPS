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
            ((System.ComponentModel.ISupportInitialize)(this.nudTreeSpacing)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDistanceTree
            // 
            this.lblDistanceTree.AutoSize = true;
            this.lblDistanceTree.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistanceTree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDistanceTree.Location = new System.Drawing.Point(20, 95);
            this.lblDistanceTree.Name = "lblDistanceTree";
            this.lblDistanceTree.Size = new System.Drawing.Size(33, 35);
            this.lblDistanceTree.TabIndex = 305;
            this.lblDistanceTree.Text = "0";
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
            this.label12.Location = new System.Drawing.Point(139, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(183, 19);
            this.label12.TabIndex = 306;
            this.label12.Text = "Spacing (cm)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblStepDistance
            // 
            this.lblStepDistance.AutoSize = true;
            this.lblStepDistance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepDistance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblStepDistance.Location = new System.Drawing.Point(50, 49);
            this.lblStepDistance.Name = "lblStepDistance";
            this.lblStepDistance.Size = new System.Drawing.Size(45, 25);
            this.lblStepDistance.TabIndex = 308;
            this.lblStepDistance.Text = "1.2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(4, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 309;
            this.label1.Text = "Step";
            // 
            // btnZeroDistance
            // 
            this.btnZeroDistance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnZeroDistance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroDistance.Image = global::AgOpenGPS.Properties.Resources.Snap2;
            this.btnZeroDistance.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnZeroDistance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZeroDistance.Location = new System.Drawing.Point(10, 178);
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
            this.btnStop.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStop.Location = new System.Drawing.Point(230, 178);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 96);
            this.btnStop.TabIndex = 141;
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSpeed.Location = new System.Drawing.Point(50, 9);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(60, 35);
            this.lblSpeed.TabIndex = 310;
            this.lblSpeed.Text = "1.2";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTrees
            // 
            this.lblTrees.AutoSize = true;
            this.lblTrees.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrees.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTrees.Location = new System.Drawing.Point(176, 126);
            this.lblTrees.Name = "lblTrees";
            this.lblTrees.Size = new System.Drawing.Size(51, 35);
            this.lblTrees.TabIndex = 312;
            this.lblTrees.Text = "11";
            this.lblTrees.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(135, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 23);
            this.label3.TabIndex = 313;
            this.label3.Text = "Trees";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nudTreeSpacing
            // 
            this.nudTreeSpacing.BackColor = System.Drawing.Color.AliceBlue;
            this.nudTreeSpacing.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTreeSpacing.Location = new System.Drawing.Point(169, 26);
            this.nudTreeSpacing.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudTreeSpacing.Name = "nudTreeSpacing";
            this.nudTreeSpacing.Size = new System.Drawing.Size(122, 52);
            this.nudTreeSpacing.TabIndex = 314;
            this.nudTreeSpacing.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudTreeSpacing.ValueChanged += new System.EventHandler(this.NudTreeSpacing_ValueChanged);
            this.nudTreeSpacing.Enter += new System.EventHandler(this.NudTreeSpacing_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 23);
            this.label2.TabIndex = 311;
            this.label2.Text = "kmh";
            // 
            // FormTreePlant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(332, 286);
            this.ControlBox = false;
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
    }
}