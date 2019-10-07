namespace AgOpenGPS
{
    partial class FormABCurve
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
            this.lblCurveExists = new System.Windows.Forms.Label();
            this.lvLines = new System.Windows.Forms.ListView();
            this.chField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblEnterCurveName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMulti = new System.Windows.Forms.Button();
            this.btnPausePlay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBPoint = new System.Windows.Forms.Button();
            this.btnAPoint = new System.Windows.Forms.Button();
            this.btnListUse = new System.Windows.Forms.Button();
            this.btnAddToFile = new System.Windows.Forms.Button();
            this.btnListDelete = new System.Windows.Forms.Button();
            this.btnABLineOk = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblCurveExists
            // 
            this.lblCurveExists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurveExists.AutoSize = true;
            this.lblCurveExists.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurveExists.Location = new System.Drawing.Point(482, 14);
            this.lblCurveExists.Name = "lblCurveExists";
            this.lblCurveExists.Size = new System.Drawing.Size(98, 25);
            this.lblCurveExists.TabIndex = 87;
            this.lblCurveExists.Text = "> OFF <";
            this.lblCurveExists.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvLines
            // 
            this.lvLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chField});
            this.lvLines.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLines.FullRowSelect = true;
            this.lvLines.GridLines = true;
            this.lvLines.HideSelection = false;
            this.lvLines.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.lvLines.LabelWrap = false;
            this.lvLines.Location = new System.Drawing.Point(121, 121);
            this.lvLines.Margin = new System.Windows.Forms.Padding(0);
            this.lvLines.MultiSelect = false;
            this.lvLines.Name = "lvLines";
            this.lvLines.Size = new System.Drawing.Size(246, 258);
            this.lvLines.TabIndex = 141;
            this.lvLines.TileSize = new System.Drawing.Size(240, 40);
            this.lvLines.UseCompatibleStateImageBehavior = false;
            this.lvLines.View = System.Windows.Forms.View.Tile;
            this.lvLines.Visible = false;
            // 
            // chField
            // 
            this.chField.Text = "CurveLines";
            this.chField.Width = 239;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.CausesValidation = false;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(120, 54);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.MaxLength = 100;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 40);
            this.textBox1.TabIndex = 145;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            // 
            // lblEnterCurveName
            // 
            this.lblEnterCurveName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEnterCurveName.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterCurveName.Location = new System.Drawing.Point(120, 14);
            this.lblEnterCurveName.Margin = new System.Windows.Forms.Padding(0);
            this.lblEnterCurveName.Name = "lblEnterCurveName";
            this.lblEnterCurveName.Size = new System.Drawing.Size(246, 39);
            this.lblEnterCurveName.TabIndex = 146;
            this.lblEnterCurveName.Text = "Enter Curve Name";
            this.lblEnterCurveName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEnterCurveName.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(399, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 148;
            this.label2.Text = "Status: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMulti
            // 
            this.btnMulti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMulti.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnMulti.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMulti.Image = global::AgOpenGPS.Properties.Resources.ArrowRight;
            this.btnMulti.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMulti.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMulti.Location = new System.Drawing.Point(397, 167);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(90, 90);
            this.btnMulti.TabIndex = 147;
            this.btnMulti.Text = "Show";
            this.btnMulti.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMulti.UseVisualStyleBackColor = false;
            this.btnMulti.Click += new System.EventHandler(this.BtnMulti_Click);
            // 
            // btnPausePlay
            // 
            this.btnPausePlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPausePlay.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPausePlay.Enabled = false;
            this.btnPausePlay.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPausePlay.Image = global::AgOpenGPS.Properties.Resources.boundaryPause;
            this.btnPausePlay.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPausePlay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPausePlay.Location = new System.Drawing.Point(536, 167);
            this.btnPausePlay.Name = "btnPausePlay";
            this.btnPausePlay.Size = new System.Drawing.Size(90, 90);
            this.btnPausePlay.TabIndex = 140;
            this.btnPausePlay.Text = "Pause";
            this.btnPausePlay.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPausePlay.UseVisualStyleBackColor = false;
            this.btnPausePlay.Click += new System.EventHandler(this.btnPausePlay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(397, 288);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 90);
            this.btnCancel.TabIndex = 86;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBPoint
            // 
            this.btnBPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBPoint.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBPoint.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnBPoint.Image = global::AgOpenGPS.Properties.Resources.LetterBBlue;
            this.btnBPoint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBPoint.Location = new System.Drawing.Point(536, 44);
            this.btnBPoint.Name = "btnBPoint";
            this.btnBPoint.Size = new System.Drawing.Size(90, 90);
            this.btnBPoint.TabIndex = 64;
            this.btnBPoint.UseVisualStyleBackColor = true;
            this.btnBPoint.Click += new System.EventHandler(this.btnBPoint_Click);
            // 
            // btnAPoint
            // 
            this.btnAPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAPoint.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnAPoint.Image = global::AgOpenGPS.Properties.Resources.LetterABlue;
            this.btnAPoint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAPoint.Location = new System.Drawing.Point(397, 44);
            this.btnAPoint.Name = "btnAPoint";
            this.btnAPoint.Size = new System.Drawing.Size(90, 90);
            this.btnAPoint.TabIndex = 63;
            this.btnAPoint.UseVisualStyleBackColor = true;
            this.btnAPoint.Click += new System.EventHandler(this.btnAPoint_Click);
            // 
            // btnListUse
            // 
            this.btnListUse.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnListUse.Image = global::AgOpenGPS.Properties.Resources.FileUse;
            this.btnListUse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnListUse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnListUse.Location = new System.Drawing.Point(9, 278);
            this.btnListUse.Margin = new System.Windows.Forms.Padding(0);
            this.btnListUse.Name = "btnListUse";
            this.btnListUse.Size = new System.Drawing.Size(90, 90);
            this.btnListUse.TabIndex = 144;
            this.btnListUse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListUse.UseVisualStyleBackColor = true;
            this.btnListUse.Visible = false;
            this.btnListUse.Click += new System.EventHandler(this.btnListUse_Click);
            // 
            // btnAddToFile
            // 
            this.btnAddToFile.BackColor = System.Drawing.Color.Transparent;
            this.btnAddToFile.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAddToFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddToFile.Image = global::AgOpenGPS.Properties.Resources.FileNew;
            this.btnAddToFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddToFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddToFile.Location = new System.Drawing.Point(10, 10);
            this.btnAddToFile.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddToFile.Name = "btnAddToFile";
            this.btnAddToFile.Size = new System.Drawing.Size(90, 90);
            this.btnAddToFile.TabIndex = 143;
            this.btnAddToFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddToFile.UseVisualStyleBackColor = false;
            this.btnAddToFile.Visible = false;
            this.btnAddToFile.Click += new System.EventHandler(this.btnAddToFile_Click);
            // 
            // btnListDelete
            // 
            this.btnListDelete.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnListDelete.Image = global::AgOpenGPS.Properties.Resources.FileDelete;
            this.btnListDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnListDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnListDelete.Location = new System.Drawing.Point(9, 144);
            this.btnListDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnListDelete.Name = "btnListDelete";
            this.btnListDelete.Size = new System.Drawing.Size(90, 90);
            this.btnListDelete.TabIndex = 142;
            this.btnListDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListDelete.UseVisualStyleBackColor = true;
            this.btnListDelete.Visible = false;
            this.btnListDelete.Click += new System.EventHandler(this.btnListDelete_Click);
            // 
            // btnABLineOk
            // 
            this.btnABLineOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnABLineOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnABLineOk.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnABLineOk.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnABLineOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnABLineOk.Location = new System.Drawing.Point(536, 288);
            this.btnABLineOk.Name = "btnABLineOk";
            this.btnABLineOk.Size = new System.Drawing.Size(90, 90);
            this.btnABLineOk.TabIndex = 65;
            this.btnABLineOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnABLineOk.UseVisualStyleBackColor = true;
            this.btnABLineOk.Click += new System.EventHandler(this.btnABLineOk_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FormABCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 400);
            this.ControlBox = false;
            this.Controls.Add(this.lblCurveExists);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMulti);
            this.Controls.Add(this.btnPausePlay);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBPoint);
            this.Controls.Add(this.btnAPoint);
            this.Controls.Add(this.lblEnterCurveName);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnListUse);
            this.Controls.Add(this.btnAddToFile);
            this.Controls.Add(this.btnListDelete);
            this.Controls.Add(this.lvLines);
            this.Controls.Add(this.btnABLineOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormABCurve";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AB Curve";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormABCurve_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBPoint;
        private System.Windows.Forms.Button btnAPoint;
        private System.Windows.Forms.Button btnABLineOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCurveExists;
        private System.Windows.Forms.Button btnPausePlay;
        private System.Windows.Forms.ListView lvLines;
        private System.Windows.Forms.ColumnHeader chField;
        private System.Windows.Forms.Button btnListDelete;
        private System.Windows.Forms.Button btnAddToFile;
        private System.Windows.Forms.Button btnListUse;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblEnterCurveName;
        private System.Windows.Forms.Button btnMulti;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}
