namespace AgOpenGPS
{
    partial class FormHeadland
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
            this.openGLHead = new SharpGL.OpenGLControl();
            this.nudWidths = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnDeleteLastPoint = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openGLHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidths)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLHead
            // 
            this.openGLHead.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openGLHead.DrawFPS = false;
            this.openGLHead.FrameRate = 2;
            this.openGLHead.Location = new System.Drawing.Point(0, 1);
            this.openGLHead.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.openGLHead.Name = "openGLHead";
            this.openGLHead.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLHead.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLHead.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLHead.Size = new System.Drawing.Size(700, 700);
            this.openGLHead.TabIndex = 70;
            this.openGLHead.OpenGLInitialized += new System.EventHandler(this.openGLHead_OpenGLInitialized);
            this.openGLHead.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLHead_OpenGLDraw);
            this.openGLHead.Resized += new System.EventHandler(this.openGLHead_Resized);
            this.openGLHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLHead_MouseDown);
            // 
            // nudWidths
            // 
            this.nudWidths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudWidths.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWidths.Location = new System.Drawing.Point(735, 436);
            this.nudWidths.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudWidths.Name = "nudWidths";
            this.nudWidths.Size = new System.Drawing.Size(84, 65);
            this.nudWidths.TabIndex = 71;
            this.nudWidths.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidths.ValueChanged += new System.EventHandler(this.nudWidths_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(721, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 23);
            this.label1.TabIndex = 72;
            this.label1.Text = "Tool Widths";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 712);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 73;
            this.label2.Text = "Headland Area";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea.Location = new System.Drawing.Point(152, 712);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(102, 25);
            this.lblArea.TabIndex = 74;
            this.lblArea.Text = "168.8 Ac";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(347, 712);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(21, 23);
            this.lblX.TabIndex = 75;
            this.lblX.Text = "X";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(433, 712);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(21, 23);
            this.lblY.TabIndex = 76;
            this.lblY.Text = "Y";
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDone.Enabled = false;
            this.btnDone.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Image = global::AgOpenGPS.Properties.Resources.PointDone;
            this.btnDone.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDone.Location = new System.Drawing.Point(711, 207);
            this.btnDone.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(128, 88);
            this.btnDone.TabIndex = 78;
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnDeleteLastPoint
            // 
            this.btnDeleteLastPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteLastPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteLastPoint.Enabled = false;
            this.btnDeleteLastPoint.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteLastPoint.Image = global::AgOpenGPS.Properties.Resources.PointDelete;
            this.btnDeleteLastPoint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteLastPoint.Location = new System.Drawing.Point(711, 112);
            this.btnDeleteLastPoint.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDeleteLastPoint.Name = "btnDeleteLastPoint";
            this.btnDeleteLastPoint.Size = new System.Drawing.Size(128, 88);
            this.btnDeleteLastPoint.TabIndex = 79;
            this.btnDeleteLastPoint.UseVisualStyleBackColor = true;
            this.btnDeleteLastPoint.Click += new System.EventHandler(this.btnDeleteLastPoint_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStart.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Image = global::AgOpenGPS.Properties.Resources.PointStart;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStart.Location = new System.Drawing.Point(710, 17);
            this.btnStart.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(128, 88);
            this.btnStart.TabIndex = 77;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.Location = new System.Drawing.Point(708, 533);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 88);
            this.btnCancel.TabIndex = 69;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnOK.Location = new System.Drawing.Point(710, 647);
            this.btnOK.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(128, 88);
            this.btnOK.TabIndex = 68;
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormHeadland
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(851, 749);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeleteLastPoint);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudWidths);
            this.Controls.Add(this.openGLHead);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "FormHeadland";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Headland Designer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormHeadland_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openGLHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidths)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private SharpGL.OpenGLControl openGLHead;
        private System.Windows.Forms.NumericUpDown nudWidths;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnDeleteLastPoint;
    }
}