namespace AgOpenGPS
{
    partial class FormSwapAB
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
            this.lvLines = new System.Windows.Forms.ListView();
            this.chField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAngle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEasting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNorthing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAB1 = new System.Windows.Forms.Button();
            this.btnAB2 = new System.Windows.Forms.Button();
            this.btnListUse = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblHeading1 = new System.Windows.Forms.Label();
            this.lblHeading2 = new System.Windows.Forms.Label();
            this.lblField2 = new System.Windows.Forms.Label();
            this.lblField1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvLines
            // 
            this.lvLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chField,
            this.chAngle,
            this.chEasting,
            this.chNorthing});
            this.lvLines.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLines.FullRowSelect = true;
            this.lvLines.GridLines = true;
            this.lvLines.HideSelection = false;
            this.lvLines.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.lvLines.Location = new System.Drawing.Point(12, 12);
            this.lvLines.MultiSelect = false;
            this.lvLines.Name = "lvLines";
            this.lvLines.Size = new System.Drawing.Size(605, 467);
            this.lvLines.TabIndex = 85;
            this.lvLines.UseCompatibleStateImageBehavior = false;
            this.lvLines.View = System.Windows.Forms.View.Details;
            // 
            // chField
            // 
            this.chField.Text = "Field";
            this.chField.Width = 404;
            // 
            // chAngle
            // 
            this.chAngle.Text = "Angle";
            this.chAngle.Width = 339;
            // 
            // chEasting
            // 
            this.chEasting.Text = "X";
            this.chEasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chEasting.Width = 100;
            // 
            // chNorthing
            // 
            this.chNorthing.Text = "Y";
            this.chNorthing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chNorthing.Width = 100;
            // 
            // btnAB1
            // 
            this.btnAB1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAB1.BackColor = System.Drawing.Color.Transparent;
            this.btnAB1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAB1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAB1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAB1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAB1.Location = new System.Drawing.Point(776, 55);
            this.btnAB1.Name = "btnAB1";
            this.btnAB1.Size = new System.Drawing.Size(95, 88);
            this.btnAB1.TabIndex = 86;
            this.btnAB1.Text = "AB 1";
            this.btnAB1.UseVisualStyleBackColor = false;
            this.btnAB1.Click += new System.EventHandler(this.btnAB1_Click);
            // 
            // btnAB2
            // 
            this.btnAB2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAB2.BackColor = System.Drawing.Color.Transparent;
            this.btnAB2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAB2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAB2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAB2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAB2.Location = new System.Drawing.Point(776, 245);
            this.btnAB2.Name = "btnAB2";
            this.btnAB2.Size = new System.Drawing.Size(95, 88);
            this.btnAB2.TabIndex = 87;
            this.btnAB2.Text = "AB 2";
            this.btnAB2.UseVisualStyleBackColor = false;
            this.btnAB2.Click += new System.EventHandler(this.btnAB2_Click);
            // 
            // btnListUse
            // 
            this.btnListUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListUse.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnListUse.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnListUse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnListUse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnListUse.Location = new System.Drawing.Point(776, 391);
            this.btnListUse.Name = "btnListUse";
            this.btnListUse.Size = new System.Drawing.Size(95, 88);
            this.btnListUse.TabIndex = 88;
            this.btnListUse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListUse.UseVisualStyleBackColor = true;
            this.btnListUse.Click += new System.EventHandler(this.btnListUse_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblHeading1
            // 
            this.lblHeading1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeading1.AutoSize = true;
            this.lblHeading1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHeading1.Location = new System.Drawing.Point(629, 55);
            this.lblHeading1.Name = "lblHeading1";
            this.lblHeading1.Size = new System.Drawing.Size(87, 23);
            this.lblHeading1.TabIndex = 90;
            this.lblHeading1.Text = "Heading:";
            // 
            // lblHeading2
            // 
            this.lblHeading2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeading2.AutoSize = true;
            this.lblHeading2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHeading2.Location = new System.Drawing.Point(629, 245);
            this.lblHeading2.Name = "lblHeading2";
            this.lblHeading2.Size = new System.Drawing.Size(87, 23);
            this.lblHeading2.TabIndex = 91;
            this.lblHeading2.Text = "Heading:";
            // 
            // lblField2
            // 
            this.lblField2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblField2.AutoSize = true;
            this.lblField2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblField2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblField2.Location = new System.Drawing.Point(629, 210);
            this.lblField2.Name = "lblField2";
            this.lblField2.Size = new System.Drawing.Size(87, 23);
            this.lblField2.TabIndex = 92;
            this.lblField2.Text = "AB2 Field";
            // 
            // lblField1
            // 
            this.lblField1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblField1.AutoSize = true;
            this.lblField1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblField1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblField1.Location = new System.Drawing.Point(629, 19);
            this.lblField1.Name = "lblField1";
            this.lblField1.Size = new System.Drawing.Size(87, 23);
            this.lblField1.TabIndex = 93;
            this.lblField1.Text = "AB1 Field";
            // 
            // FormSwapAB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 538);
            this.ControlBox = false;
            this.Controls.Add(this.lblField1);
            this.Controls.Add(this.lblField2);
            this.Controls.Add(this.lblHeading2);
            this.Controls.Add(this.lblHeading1);
            this.Controls.Add(this.btnListUse);
            this.Controls.Add(this.btnAB2);
            this.Controls.Add(this.btnAB1);
            this.Controls.Add(this.lvLines);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(901, 540);
            this.Name = "FormSwapAB";
            this.ShowInTaskbar = false;
            this.Text = "Setup Quick AB Lines";
            this.Load += new System.EventHandler(this.FormSwapAB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvLines;
        private System.Windows.Forms.ColumnHeader chField;
        private System.Windows.Forms.ColumnHeader chAngle;
        private System.Windows.Forms.ColumnHeader chEasting;
        private System.Windows.Forms.ColumnHeader chNorthing;
        private System.Windows.Forms.Button btnAB2;
        private System.Windows.Forms.Button btnListUse;
        private System.Windows.Forms.Button btnAB1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblHeading1;
        private System.Windows.Forms.Label lblHeading2;
        private System.Windows.Forms.Label lblField2;
        private System.Windows.Forms.Label lblField1;
    }
}