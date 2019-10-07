namespace AgOpenGPS
{
    partial class FormABDraw
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
            this.oglSelf = new OpenTK.GLControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMakeABLine = new System.Windows.Forms.Button();
            this.btnMakeCurve = new System.Windows.Forms.Button();
            this.lblLineName = new System.Windows.Forms.Label();
            this.tboxABLineSaveName = new System.Windows.Forms.TextBox();
            this.btnSaveABLine = new System.Windows.Forms.Button();
            this.btnSaveABCurve = new System.Windows.Forms.Button();
            this.tboxCurveSaveName = new System.Windows.Forms.TextBox();
            this.lblCurveName = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // oglSelf
            // 
            this.oglSelf.BackColor = System.Drawing.Color.Black;
            this.oglSelf.Cursor = System.Windows.Forms.Cursors.Cross;
            this.oglSelf.Location = new System.Drawing.Point(5, 6);
            this.oglSelf.Margin = new System.Windows.Forms.Padding(0);
            this.oglSelf.Name = "oglSelf";
            this.oglSelf.Size = new System.Drawing.Size(700, 700);
            this.oglSelf.TabIndex = 183;
            this.oglSelf.VSync = false;
            this.oglSelf.Load += new System.EventHandler(this.oglSelf_Load);
            this.oglSelf.Paint += new System.Windows.Forms.PaintEventHandler(this.oglSelf_Paint);
            this.oglSelf.MouseDown += new System.Windows.Forms.MouseEventHandler(this.oglSelf_MouseDown);
            this.oglSelf.Resize += new System.EventHandler(this.oglSelf_Resize);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExit.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnExit.Location = new System.Drawing.Point(881, 640);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(74, 66);
            this.btnExit.TabIndex = 234;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMakeABLine
            // 
            this.btnMakeABLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeABLine.BackColor = System.Drawing.Color.Lavender;
            this.btnMakeABLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMakeABLine.Enabled = false;
            this.btnMakeABLine.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnMakeABLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeABLine.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMakeABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineOn;
            this.btnMakeABLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeABLine.Location = new System.Drawing.Point(794, 12);
            this.btnMakeABLine.Name = "btnMakeABLine";
            this.btnMakeABLine.Size = new System.Drawing.Size(94, 95);
            this.btnMakeABLine.TabIndex = 311;
            this.btnMakeABLine.UseVisualStyleBackColor = false;
            this.btnMakeABLine.Click += new System.EventHandler(this.BtnMakeABLine_Click);
            // 
            // btnMakeCurve
            // 
            this.btnMakeCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeCurve.BackColor = System.Drawing.Color.Lavender;
            this.btnMakeCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMakeCurve.Enabled = false;
            this.btnMakeCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnMakeCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMakeCurve.Image = global::AgOpenGPS.Properties.Resources.CurveOn;
            this.btnMakeCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeCurve.Location = new System.Drawing.Point(794, 334);
            this.btnMakeCurve.Name = "btnMakeCurve";
            this.btnMakeCurve.Size = new System.Drawing.Size(94, 95);
            this.btnMakeCurve.TabIndex = 313;
            this.btnMakeCurve.UseVisualStyleBackColor = false;
            this.btnMakeCurve.Click += new System.EventHandler(this.BtnMakeCurve_Click);
            // 
            // lblLineName
            // 
            this.lblLineName.Enabled = false;
            this.lblLineName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineName.Location = new System.Drawing.Point(708, 122);
            this.lblLineName.Margin = new System.Windows.Forms.Padding(0);
            this.lblLineName.Name = "lblLineName";
            this.lblLineName.Size = new System.Drawing.Size(246, 39);
            this.lblLineName.TabIndex = 314;
            this.lblLineName.Text = "Enter Line Name";
            this.lblLineName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tboxABLineSaveName
            // 
            this.tboxABLineSaveName.Enabled = false;
            this.tboxABLineSaveName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxABLineSaveName.Location = new System.Drawing.Point(723, 159);
            this.tboxABLineSaveName.Name = "tboxABLineSaveName";
            this.tboxABLineSaveName.Size = new System.Drawing.Size(225, 30);
            this.tboxABLineSaveName.TabIndex = 312;
            this.tboxABLineSaveName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSaveABLine
            // 
            this.btnSaveABLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveABLine.BackColor = System.Drawing.Color.Lavender;
            this.btnSaveABLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveABLine.Enabled = false;
            this.btnSaveABLine.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSaveABLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveABLine.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSaveABLine.Image = global::AgOpenGPS.Properties.Resources.FileNew;
            this.btnSaveABLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveABLine.Location = new System.Drawing.Point(775, 195);
            this.btnSaveABLine.Name = "btnSaveABLine";
            this.btnSaveABLine.Size = new System.Drawing.Size(129, 76);
            this.btnSaveABLine.TabIndex = 319;
            this.btnSaveABLine.UseVisualStyleBackColor = false;
            this.btnSaveABLine.Click += new System.EventHandler(this.BtnSaveABLine_Click);
            // 
            // btnSaveABCurve
            // 
            this.btnSaveABCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveABCurve.BackColor = System.Drawing.Color.Lavender;
            this.btnSaveABCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveABCurve.Enabled = false;
            this.btnSaveABCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSaveABCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveABCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSaveABCurve.Image = global::AgOpenGPS.Properties.Resources.FileNew;
            this.btnSaveABCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveABCurve.Location = new System.Drawing.Point(775, 516);
            this.btnSaveABCurve.Name = "btnSaveABCurve";
            this.btnSaveABCurve.Size = new System.Drawing.Size(129, 76);
            this.btnSaveABCurve.TabIndex = 316;
            this.btnSaveABCurve.UseVisualStyleBackColor = false;
            this.btnSaveABCurve.Click += new System.EventHandler(this.BtnSaveABCurve_Click);
            // 
            // tboxCurveSaveName
            // 
            this.tboxCurveSaveName.Enabled = false;
            this.tboxCurveSaveName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxCurveSaveName.Location = new System.Drawing.Point(723, 474);
            this.tboxCurveSaveName.Name = "tboxCurveSaveName";
            this.tboxCurveSaveName.Size = new System.Drawing.Size(225, 30);
            this.tboxCurveSaveName.TabIndex = 314;
            this.tboxCurveSaveName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCurveName
            // 
            this.lblCurveName.Enabled = false;
            this.lblCurveName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurveName.Location = new System.Drawing.Point(709, 437);
            this.lblCurveName.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurveName.Name = "lblCurveName";
            this.lblCurveName.Size = new System.Drawing.Size(246, 39);
            this.lblCurveName.TabIndex = 317;
            this.lblCurveName.Text = "Enter Curve Name";
            this.lblCurveName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackColor = System.Drawing.Color.Lavender;
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHelp.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnHelp.Image = global::AgOpenGPS.Properties.Resources.Help;
            this.btnHelp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHelp.Location = new System.Drawing.Point(723, 640);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(73, 66);
            this.btnHelp.TabIndex = 319;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // FormABDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(964, 713);
            this.ControlBox = false;
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tboxCurveSaveName);
            this.Controls.Add(this.lblCurveName);
            this.Controls.Add(this.btnSaveABCurve);
            this.Controls.Add(this.btnSaveABLine);
            this.Controls.Add(this.tboxABLineSaveName);
            this.Controls.Add(this.btnMakeCurve);
            this.Controls.Add(this.btnMakeABLine);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.oglSelf);
            this.Controls.Add(this.lblLineName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormABDraw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Click 2 points on the Boundary to Begin";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormABDraw_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl oglSelf;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMakeABLine;
        private System.Windows.Forms.Button btnMakeCurve;
        private System.Windows.Forms.Label lblLineName;
        private System.Windows.Forms.TextBox tboxABLineSaveName;
        private System.Windows.Forms.Button btnSaveABLine;
        private System.Windows.Forms.Button btnSaveABCurve;
        private System.Windows.Forms.TextBox tboxCurveSaveName;
        private System.Windows.Forms.Label lblCurveName;
        private System.Windows.Forms.Button btnHelp;
    }
}