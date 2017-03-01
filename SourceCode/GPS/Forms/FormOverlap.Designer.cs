namespace AgOpenGPS
{
    partial class FormOverlap
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
            this.openGLWin = new SharpGL.OpenGLControl();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tboxOverlap = new System.Windows.Forms.TextBox();
            this.tboxBase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tboxRecordedArea = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tboxPercentOverlap = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tboxActualArea = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.openGLWin)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLWin
            // 
            this.openGLWin.DrawFPS = false;
            this.openGLWin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openGLWin.FrameRate = 0;
            this.openGLWin.Location = new System.Drawing.Point(4, 8);
            this.openGLWin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openGLWin.Name = "openGLWin";
            this.openGLWin.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLWin.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLWin.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.openGLWin.Size = new System.Drawing.Size(500, 500);
            this.openGLWin.TabIndex = 0;
            this.openGLWin.OpenGLInitialized += new System.EventHandler(this.openGLWin_OpenGLInitialized);
            this.openGLWin.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLWin_OpenGLDraw);
            this.openGLWin.Resized += new System.EventHandler(this.openGLWin_Resized);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(581, 26);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(99, 43);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.Location = new System.Drawing.Point(641, 474);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 72);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tboxOverlap
            // 
            this.tboxOverlap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxOverlap.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxOverlap.Location = new System.Drawing.Point(537, 176);
            this.tboxOverlap.Name = "tboxOverlap";
            this.tboxOverlap.Size = new System.Drawing.Size(192, 33);
            this.tboxOverlap.TabIndex = 5;
            // 
            // tboxBase
            // 
            this.tboxBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxBase.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxBase.Location = new System.Drawing.Point(537, 114);
            this.tboxBase.Name = "tboxBase";
            this.tboxBase.Size = new System.Drawing.Size(192, 33);
            this.tboxBase.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(533, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Base Pixels";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(533, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Overlapped Pixels";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(533, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Recorded Area";
            // 
            // tboxRecordedArea
            // 
            this.tboxRecordedArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxRecordedArea.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxRecordedArea.Location = new System.Drawing.Point(537, 333);
            this.tboxRecordedArea.Name = "tboxRecordedArea";
            this.tboxRecordedArea.Size = new System.Drawing.Size(192, 33);
            this.tboxRecordedArea.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(533, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "% Overlap";
            // 
            // tboxPercentOverlap
            // 
            this.tboxPercentOverlap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxPercentOverlap.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxPercentOverlap.Location = new System.Drawing.Point(537, 238);
            this.tboxPercentOverlap.Name = "tboxPercentOverlap";
            this.tboxPercentOverlap.Size = new System.Drawing.Size(192, 33);
            this.tboxPercentOverlap.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(533, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 21);
            this.label5.TabIndex = 14;
            this.label5.Text = "Actual Area";
            // 
            // tboxActualArea
            // 
            this.tboxActualArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxActualArea.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxActualArea.Location = new System.Drawing.Point(537, 411);
            this.tboxActualArea.Name = "tboxActualArea";
            this.tboxActualArea.Size = new System.Drawing.Size(192, 33);
            this.tboxActualArea.TabIndex = 13;
            // 
            // FormOverlap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 558);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tboxActualArea);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tboxPercentOverlap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tboxRecordedArea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxBase);
            this.Controls.Add(this.tboxOverlap);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.openGLWin);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOverlap";
            this.ShowIcon = false;
            this.Text = "Calculate Overlap";
            this.Load += new System.EventHandler(this.FormOverlap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openGLWin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLWin;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tboxOverlap;
        private System.Windows.Forms.TextBox tboxBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tboxRecordedArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tboxPercentOverlap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tboxActualArea;

    }
}