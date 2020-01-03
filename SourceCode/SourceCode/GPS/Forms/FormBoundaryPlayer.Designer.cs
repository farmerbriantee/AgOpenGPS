namespace AgOpenGPS
{
    partial class FormBoundaryPlayer
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
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblArea = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnDeleteLast = new System.Windows.Forms.Button();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPausePlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F);
            this.label1.Location = new System.Drawing.Point(15, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 29);
            this.label1.TabIndex = 141;
            this.label1.Text = "Area:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblArea
            // 
            this.lblArea.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.lblArea.Location = new System.Drawing.Point(-2, 172);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(104, 29);
            this.lblArea.TabIndex = 142;
            this.lblArea.Text = "999";
            this.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.lblPoints.Location = new System.Drawing.Point(254, 88);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(58, 29);
            this.lblPoints.TabIndex = 146;
            this.lblPoints.Text = "999";
            this.lblPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F);
            this.label2.Location = new System.Drawing.Point(172, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 29);
            this.label2.TabIndex = 148;
            this.label2.Text = "Points:";
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Transparent;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnRestart.Image = global::AgOpenGPS.Properties.Resources.BoundaryDelete;
            this.btnRestart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRestart.Location = new System.Drawing.Point(12, 5);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(68, 70);
            this.btnRestart.TabIndex = 147;
            this.btnRestart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnDeleteLast
            // 
            this.btnDeleteLast.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteLast.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnDeleteLast.Image = global::AgOpenGPS.Properties.Resources.PointDelete;
            this.btnDeleteLast.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteLast.Location = new System.Drawing.Point(143, 5);
            this.btnDeleteLast.Name = "btnDeleteLast";
            this.btnDeleteLast.Size = new System.Drawing.Size(68, 70);
            this.btnDeleteLast.TabIndex = 144;
            this.btnDeleteLast.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteLast.UseVisualStyleBackColor = false;
            this.btnDeleteLast.Click += new System.EventHandler(this.btnDeleteLast_Click);
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPoint.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnAddPoint.Image = global::AgOpenGPS.Properties.Resources.PointAdd;
            this.btnAddPoint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddPoint.Location = new System.Drawing.Point(274, 5);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(68, 70);
            this.btnAddPoint.TabIndex = 143;
            this.btnAddPoint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddPoint.UseVisualStyleBackColor = false;
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnStop.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnStop.Location = new System.Drawing.Point(260, 134);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(89, 89);
            this.btnStop.TabIndex = 140;
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPausePlay
            // 
            this.btnPausePlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPausePlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPausePlay.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPausePlay.Image = global::AgOpenGPS.Properties.Resources.BoundaryRecord;
            this.btnPausePlay.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPausePlay.Location = new System.Drawing.Point(122, 134);
            this.btnPausePlay.Name = "btnPausePlay";
            this.btnPausePlay.Size = new System.Drawing.Size(89, 89);
            this.btnPausePlay.TabIndex = 139;
            this.btnPausePlay.Text = "Record";
            this.btnPausePlay.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPausePlay.UseVisualStyleBackColor = false;
            this.btnPausePlay.Click += new System.EventHandler(this.btnPausePlay_Click);
            // 
            // FormBoundaryPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 231);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.btnDeleteLast);
            this.Controls.Add(this.btnAddPoint);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPausePlay);
            this.Font = new System.Drawing.Font("Tahoma", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormBoundaryPlayer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stop Record Pause Boundary";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormBoundaryPlayer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPausePlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Button btnAddPoint;
        private System.Windows.Forms.Button btnDeleteLast;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label label2;
    }
}