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
            this.lblSpacing = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblStepDistance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnZeroDistance = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTrees = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDistanceTree
            // 
            this.lblDistanceTree.AutoSize = true;
            this.lblDistanceTree.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistanceTree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDistanceTree.Location = new System.Drawing.Point(12, 112);
            this.lblDistanceTree.Name = "lblDistanceTree";
            this.lblDistanceTree.Size = new System.Drawing.Size(32, 33);
            this.lblDistanceTree.TabIndex = 305;
            this.lblDistanceTree.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblSpacing
            // 
            this.lblSpacing.AutoSize = true;
            this.lblSpacing.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSpacing.Location = new System.Drawing.Point(199, 7);
            this.lblSpacing.Name = "lblSpacing";
            this.lblSpacing.Size = new System.Drawing.Size(45, 25);
            this.lblSpacing.TabIndex = 307;
            this.lblSpacing.Text = "1.2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(103, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 19);
            this.label12.TabIndex = 306;
            this.label12.Text = "Spacing (cm)";
            // 
            // lblStepDistance
            // 
            this.lblStepDistance.AutoSize = true;
            this.lblStepDistance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepDistance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblStepDistance.Location = new System.Drawing.Point(198, 35);
            this.lblStepDistance.Name = "lblStepDistance";
            this.lblStepDistance.Size = new System.Drawing.Size(45, 25);
            this.lblStepDistance.TabIndex = 308;
            this.lblStepDistance.Text = "1.2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(125, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 309;
            this.label1.Text = "Step (cm)";
            // 
            // btnZeroDistance
            // 
            this.btnZeroDistance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnZeroDistance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroDistance.Image = global::AgOpenGPS.Properties.Resources.Snap2;
            this.btnZeroDistance.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnZeroDistance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZeroDistance.Location = new System.Drawing.Point(12, 12);
            this.btnZeroDistance.Name = "btnZeroDistance";
            this.btnZeroDistance.Size = new System.Drawing.Size(91, 96);
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
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStop.Location = new System.Drawing.Point(180, 98);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(74, 81);
            this.btnStop.TabIndex = 141;
            this.btnStop.Text = "Done";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSpeed.Location = new System.Drawing.Point(23, 150);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(57, 33);
            this.lblSpeed.TabIndex = 310;
            this.lblSpeed.Text = "1.2";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(73, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 19);
            this.label2.TabIndex = 311;
            this.label2.Text = "kmh";
            // 
            // lblTrees
            // 
            this.lblTrees.AutoSize = true;
            this.lblTrees.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrees.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTrees.Location = new System.Drawing.Point(134, 61);
            this.lblTrees.Name = "lblTrees";
            this.lblTrees.Size = new System.Drawing.Size(57, 33);
            this.lblTrees.TabIndex = 312;
            this.lblTrees.Text = "1.2";
            this.lblTrees.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(192, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 19);
            this.label3.TabIndex = 313;
            this.label3.Text = "Trees";
            // 
            // FormTreePlant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(260, 183);
            this.ControlBox = false;
            this.Controls.Add(this.lblStepDistance);
            this.Controls.Add(this.lblSpacing);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTrees);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblDistanceTree);
            this.Controls.Add(this.btnZeroDistance);
            this.Controls.Add(this.btnStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTreePlant";
            this.Text = "Tree Plant Control";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormTreePlant_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnZeroDistance;
        private System.Windows.Forms.Label lblDistanceTree;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblSpacing;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblStepDistance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTrees;
        private System.Windows.Forms.Label label3;
    }
}