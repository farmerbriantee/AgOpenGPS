namespace AgOpenGPS
{
    partial class FormEditCurve
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
            this.btnSnapToPivot = new System.Windows.Forms.Button();
            this.btnSwapAB = new System.Windows.Forms.Button();
            this.bthOK = new System.Windows.Forms.Button();
            this.btnAdjLeft = new System.Windows.Forms.Button();
            this.btnAdjRight = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCycleLinesBk = new System.Windows.Forms.Button();
            this.btnCycleLines = new System.Windows.Forms.Button();
            this.btnZeroMove = new System.Windows.Forms.Button();
            this.lblMoveDistance = new System.Windows.Forms.Label();
            this.nudSnapDistance = new AgOpenGPS.NudlessNumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSnapDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSnapToPivot
            // 
            this.btnSnapToPivot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSnapToPivot.BackColor = System.Drawing.Color.Transparent;
            this.btnSnapToPivot.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSnapToPivot.FlatAppearance.BorderSize = 0;
            this.btnSnapToPivot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnapToPivot.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSnapToPivot.Image = global::AgOpenGPS.Properties.Resources.SnapToPivot;
            this.btnSnapToPivot.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSnapToPivot.Location = new System.Drawing.Point(165, 214);
            this.btnSnapToPivot.Name = "btnSnapToPivot";
            this.btnSnapToPivot.Size = new System.Drawing.Size(72, 62);
            this.btnSnapToPivot.TabIndex = 6;
            this.btnSnapToPivot.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSnapToPivot.UseVisualStyleBackColor = false;
            this.btnSnapToPivot.Click += new System.EventHandler(this.btnSnapToPivot_Click);
            this.btnSnapToPivot.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnContourPriority_HelpRequested);
            // 
            // btnSwapAB
            // 
            this.btnSwapAB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSwapAB.FlatAppearance.BorderSize = 0;
            this.btnSwapAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwapAB.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwapAB.Image = global::AgOpenGPS.Properties.Resources.ABSwapPoints;
            this.btnSwapAB.Location = new System.Drawing.Point(31, 293);
            this.btnSwapAB.Name = "btnSwapAB";
            this.btnSwapAB.Size = new System.Drawing.Size(72, 64);
            this.btnSwapAB.TabIndex = 7;
            this.btnSwapAB.UseVisualStyleBackColor = true;
            this.btnSwapAB.Click += new System.EventHandler(this.btnSwapAB_Click);
            // 
            // bthOK
            // 
            this.bthOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bthOK.BackColor = System.Drawing.Color.Transparent;
            this.bthOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bthOK.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bthOK.FlatAppearance.BorderSize = 0;
            this.bthOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bthOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bthOK.Image = global::AgOpenGPS.Properties.Resources.FileSave;
            this.bthOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bthOK.Location = new System.Drawing.Point(165, 288);
            this.bthOK.Name = "bthOK";
            this.bthOK.Size = new System.Drawing.Size(72, 74);
            this.bthOK.TabIndex = 1;
            this.bthOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bthOK.UseVisualStyleBackColor = false;
            this.bthOK.Click += new System.EventHandler(this.bntOk_Click);
            this.bthOK.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnOK_HelpRequested);
            // 
            // btnAdjLeft
            // 
            this.btnAdjLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdjLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnAdjLeft.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnAdjLeft.FlatAppearance.BorderSize = 0;
            this.btnAdjLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjLeft.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnAdjLeft.Image = global::AgOpenGPS.Properties.Resources.SnapLeft;
            this.btnAdjLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdjLeft.Location = new System.Drawing.Point(31, 85);
            this.btnAdjLeft.Name = "btnAdjLeft";
            this.btnAdjLeft.Size = new System.Drawing.Size(72, 64);
            this.btnAdjLeft.TabIndex = 4;
            this.btnAdjLeft.UseVisualStyleBackColor = false;
            this.btnAdjLeft.Click += new System.EventHandler(this.btnAdjLeft_Click);
            // 
            // btnAdjRight
            // 
            this.btnAdjRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdjRight.BackColor = System.Drawing.Color.Transparent;
            this.btnAdjRight.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnAdjRight.FlatAppearance.BorderSize = 0;
            this.btnAdjRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjRight.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnAdjRight.Image = global::AgOpenGPS.Properties.Resources.SnapRight;
            this.btnAdjRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdjRight.Location = new System.Drawing.Point(165, 85);
            this.btnAdjRight.Name = "btnAdjRight";
            this.btnAdjRight.Size = new System.Drawing.Size(72, 64);
            this.btnAdjRight.TabIndex = 5;
            this.btnAdjRight.UseVisualStyleBackColor = false;
            this.btnAdjRight.Click += new System.EventHandler(this.btnAdjRight_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnCycleLinesBk, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSnapToPivot, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSwapAB, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCycleLines, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAdjLeft, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.bthOK, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAdjRight, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnZeroMove, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.nudSnapDistance, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMoveDistance, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 12);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(180, 300);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.53316F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.53316F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86736F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.53316F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.53316F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(268, 366);
            this.tableLayoutPanel1.TabIndex = 416;
            // 
            // btnCycleLinesBk
            // 
            this.btnCycleLinesBk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCycleLinesBk.BackColor = System.Drawing.Color.Transparent;
            this.btnCycleLinesBk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCycleLinesBk.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCycleLinesBk.FlatAppearance.BorderSize = 0;
            this.btnCycleLinesBk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCycleLinesBk.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCycleLinesBk.Image = global::AgOpenGPS.Properties.Resources.ABLineCycleBk;
            this.btnCycleLinesBk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCycleLinesBk.Location = new System.Drawing.Point(36, 11);
            this.btnCycleLinesBk.Name = "btnCycleLinesBk";
            this.btnCycleLinesBk.Size = new System.Drawing.Size(61, 56);
            this.btnCycleLinesBk.TabIndex = 417;
            this.btnCycleLinesBk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCycleLinesBk.UseVisualStyleBackColor = false;
            this.btnCycleLinesBk.Click += new System.EventHandler(this.btnCycleLinesBk_Click);
            // 
            // btnCycleLines
            // 
            this.btnCycleLines.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCycleLines.BackColor = System.Drawing.Color.Transparent;
            this.btnCycleLines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCycleLines.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCycleLines.FlatAppearance.BorderSize = 0;
            this.btnCycleLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCycleLines.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCycleLines.Image = global::AgOpenGPS.Properties.Resources.ABLineCycle;
            this.btnCycleLines.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCycleLines.Location = new System.Drawing.Point(170, 11);
            this.btnCycleLines.Name = "btnCycleLines";
            this.btnCycleLines.Size = new System.Drawing.Size(61, 56);
            this.btnCycleLines.TabIndex = 416;
            this.btnCycleLines.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCycleLines.UseVisualStyleBackColor = false;
            this.btnCycleLines.Click += new System.EventHandler(this.btnCycleLines_Click);
            // 
            // btnZeroMove
            // 
            this.btnZeroMove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnZeroMove.BackColor = System.Drawing.Color.Transparent;
            this.btnZeroMove.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnZeroMove.FlatAppearance.BorderSize = 0;
            this.btnZeroMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZeroMove.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnZeroMove.Image = global::AgOpenGPS.Properties.Resources.SteerZero;
            this.btnZeroMove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZeroMove.Location = new System.Drawing.Point(28, 221);
            this.btnZeroMove.Name = "btnZeroMove";
            this.btnZeroMove.Size = new System.Drawing.Size(77, 48);
            this.btnZeroMove.TabIndex = 534;
            this.btnZeroMove.UseVisualStyleBackColor = false;
            this.btnZeroMove.Click += new System.EventHandler(this.btnZeroMove_Click);
            // 
            // lblMoveDistance
            // 
            this.lblMoveDistance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMoveDistance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveDistance.Location = new System.Drawing.Point(17, 166);
            this.lblMoveDistance.Name = "lblMoveDistance";
            this.lblMoveDistance.Size = new System.Drawing.Size(100, 30);
            this.lblMoveDistance.TabIndex = 535;
            this.lblMoveDistance.Text = "-14.86";
            this.lblMoveDistance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudSnapDistance
            // 
            this.nudSnapDistance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nudSnapDistance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSnapDistance.Location = new System.Drawing.Point(169, 163);
            this.nudSnapDistance.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSnapDistance.Name = "nudSnapDistance";
            this.nudSnapDistance.Size = new System.Drawing.Size(64, 36);
            this.nudSnapDistance.TabIndex = 415;
            this.nudSnapDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSnapDistance.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.nudSnapDistance.Click += new System.EventHandler(this.nudSnapDistance_Click);
            // 
            // FormEditCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(272, 393);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(204, 125);
            this.Name = "FormEditCurve";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditCurve_FormClosing);
            this.Load += new System.EventHandler(this.FormEditAB_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSnapDistance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAdjRight;
        private System.Windows.Forms.Button btnAdjLeft;
        private System.Windows.Forms.Button bthOK;
        private System.Windows.Forms.Button btnSwapAB;
        public System.Windows.Forms.Button btnSnapToPivot;
        private NudlessNumericUpDown nudSnapDistance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btnCycleLinesBk;
        public System.Windows.Forms.Button btnCycleLines;
        private System.Windows.Forms.Button btnZeroMove;
        private System.Windows.Forms.Label lblMoveDistance;
    }
}