﻿namespace AgOpenGPS
{
    partial class FormFlags
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
            this.btnSouth = new ProXoft.WinForms.RepeatButton();
            this.btnNorth = new ProXoft.WinForms.RepeatButton();
            this.lblFlagSelected = new System.Windows.Forms.Label();
            this.lblLonStart = new System.Windows.Forms.Label();
            this.lblLatStart = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEasting = new System.Windows.Forms.Label();
            this.lblNorthing = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxFlagNotes = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDeleteFlag = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblDistanceToFlag = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelElevStart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSouth
            // 
            this.btnSouth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSouth.FlatAppearance.BorderSize = 0;
            this.btnSouth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSouth.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.btnSouth.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnSouth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSouth.Location = new System.Drawing.Point(256, -1);
            this.btnSouth.Margin = new System.Windows.Forms.Padding(4);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(125, 73);
            this.btnSouth.TabIndex = 195;
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSouth_MouseDown);
            // 
            // btnNorth
            // 
            this.btnNorth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNorth.FlatAppearance.BorderSize = 0;
            this.btnNorth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNorth.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.btnNorth.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnNorth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNorth.Location = new System.Drawing.Point(87, -1);
            this.btnNorth.Margin = new System.Windows.Forms.Padding(4);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(125, 73);
            this.btnNorth.TabIndex = 196;
            this.btnNorth.UseVisualStyleBackColor = true;
            this.btnNorth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnNorth_MouseDown);
            // 
            // lblFlagSelected
            // 
            this.lblFlagSelected.AutoSize = true;
            this.lblFlagSelected.BackColor = System.Drawing.Color.Transparent;
            this.lblFlagSelected.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlagSelected.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFlagSelected.Location = new System.Drawing.Point(7, 15);
            this.lblFlagSelected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlagSelected.Name = "lblFlagSelected";
            this.lblFlagSelected.Size = new System.Drawing.Size(70, 48);
            this.lblFlagSelected.TabIndex = 200;
            this.lblFlagSelected.Text = "99";
            // 
            // lblLonStart
            // 
            this.lblLonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLonStart.AutoSize = true;
            this.lblLonStart.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLonStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLonStart.Location = new System.Drawing.Point(243, 191);
            this.lblLonStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLonStart.Name = "lblLonStart";
            this.lblLonStart.Size = new System.Drawing.Size(122, 24);
            this.lblLonStart.TabIndex = 204;
            this.lblLonStart.Text = "-188.888888";
            // 
            // lblLatStart
            // 
            this.lblLatStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLatStart.AutoSize = true;
            this.lblLatStart.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLatStart.Location = new System.Drawing.Point(49, 191);
            this.lblLatStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLatStart.Name = "lblLatStart";
            this.lblLatStart.Size = new System.Drawing.Size(111, 24);
            this.lblLatStart.TabIndex = 203;
            this.lblLatStart.Text = "-99.999999";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(195, 190);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 24);
            this.label4.TabIndex = 202;
            this.label4.Text = "Lon:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(7, 190);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 24);
            this.label3.TabIndex = 201;
            this.label3.Text = "Lat:";
            // 
            // lblEasting
            // 
            this.lblEasting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEasting.AutoSize = true;
            this.lblEasting.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasting.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEasting.Location = new System.Drawing.Point(173, 249);
            this.lblEasting.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblEasting.Name = "lblEasting";
            this.lblEasting.Size = new System.Drawing.Size(75, 24);
            this.lblEasting.TabIndex = 208;
            this.lblEasting.Text = "Easting";
            // 
            // lblNorthing
            // 
            this.lblNorthing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNorthing.AutoSize = true;
            this.lblNorthing.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNorthing.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNorthing.Location = new System.Drawing.Point(39, 249);
            this.lblNorthing.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblNorthing.Name = "lblNorthing";
            this.lblNorthing.Size = new System.Drawing.Size(86, 24);
            this.lblNorthing.TabIndex = 207;
            this.lblNorthing.Text = "Northing";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(148, 249);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 24);
            this.label5.TabIndex = 206;
            this.label5.Text = "E:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(11, 249);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 24);
            this.label1.TabIndex = 205;
            this.label1.Text = "N:";
            // 
            // tboxFlagNotes
            // 
            this.tboxFlagNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxFlagNotes.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxFlagNotes.Location = new System.Drawing.Point(9, 68);
            this.tboxFlagNotes.Margin = new System.Windows.Forms.Padding(4);
            this.tboxFlagNotes.Multiline = true;
            this.tboxFlagNotes.Name = "tboxFlagNotes";
            this.tboxFlagNotes.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tboxFlagNotes.Size = new System.Drawing.Size(373, 84);
            this.tboxFlagNotes.TabIndex = 209;
            this.tboxFlagNotes.Text = "Default";
            this.tboxFlagNotes.Click += new System.EventHandler(this.tboxFlagNotes_Click);
            this.tboxFlagNotes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxFlagNotes_KeyPress);
            this.tboxFlagNotes.Leave += new System.EventHandler(this.tboxFlagNotes_Leave);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnExit.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExit.Location = new System.Drawing.Point(280, 281);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 97);
            this.btnExit.TabIndex = 210;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDeleteFlag
            // 
            this.btnDeleteFlag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteFlag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteFlag.FlatAppearance.BorderSize = 0;
            this.btnDeleteFlag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFlag.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDeleteFlag.Image = global::AgOpenGPS.Properties.Resources.FlagDelete;
            this.btnDeleteFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteFlag.Location = new System.Drawing.Point(9, 279);
            this.btnDeleteFlag.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteFlag.Name = "btnDeleteFlag";
            this.btnDeleteFlag.Size = new System.Drawing.Size(93, 97);
            this.btnDeleteFlag.TabIndex = 211;
            this.btnDeleteFlag.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteFlag.UseVisualStyleBackColor = true;
            this.btnDeleteFlag.Click += new System.EventHandler(this.btnDeleteFlag_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHeading.Location = new System.Drawing.Point(309, 249);
            this.lblHeading.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(60, 24);
            this.lblHeading.TabIndex = 214;
            this.lblHeading.Text = "359.8";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(284, 249);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 24);
            this.label6.TabIndex = 213;
            this.label6.Text = "H:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(39, 157);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 24);
            this.label2.TabIndex = 215;
            this.label2.Text = "Distance To Flag:";
            // 
            // lblDistanceToFlag
            // 
            this.lblDistanceToFlag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDistanceToFlag.AutoSize = true;
            this.lblDistanceToFlag.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistanceToFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDistanceToFlag.Location = new System.Drawing.Point(209, 156);
            this.lblDistanceToFlag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDistanceToFlag.Name = "lblDistanceToFlag";
            this.lblDistanceToFlag.Size = new System.Drawing.Size(151, 29);
            this.lblDistanceToFlag.TabIndex = 216;
            this.lblDistanceToFlag.Text = "-99.999999";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(7, 220);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 24);
            this.label7.TabIndex = 217;
            this.label7.Text = "Elev:";
            // 
            // labelElevStart
            // 
            this.labelElevStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelElevStart.AutoSize = true;
            this.labelElevStart.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelElevStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelElevStart.Location = new System.Drawing.Point(56, 220);
            this.labelElevStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelElevStart.Name = "labelElevStart";
            this.labelElevStart.Size = new System.Drawing.Size(104, 24);
            this.labelElevStart.TabIndex = 218;
            this.labelElevStart.Text = "2000.0000";
            // 
            // FormFlags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(400, 391);
            this.ControlBox = false;
            this.Controls.Add(this.labelElevStart);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblDistanceToFlag);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDeleteFlag);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tboxFlagNotes);
            this.Controls.Add(this.lblEasting);
            this.Controls.Add(this.lblNorthing);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLonStart);
            this.Controls.Add(this.lblLatStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFlagSelected);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnNorth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormFlags";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Flags";
            this.Load += new System.EventHandler(this.FormFlags_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProXoft.WinForms.RepeatButton btnSouth;
        private ProXoft.WinForms.RepeatButton btnNorth;
        private System.Windows.Forms.Label lblFlagSelected;
        private System.Windows.Forms.Label lblLonStart;
        private System.Windows.Forms.Label lblLatStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEasting;
        private System.Windows.Forms.Label lblNorthing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxFlagNotes;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDeleteFlag;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDistanceToFlag;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelElevStart;
    }
}