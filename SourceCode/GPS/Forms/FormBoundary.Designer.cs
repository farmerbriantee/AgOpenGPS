namespace AgOpenGPS
{
    partial class FormBoundary
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
            this.Boundary = new System.Windows.Forms.Label();
            this.Thru = new System.Windows.Forms.Label();
            this.Area = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnBingMaps = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOpenGoogleEarth = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panelChoose = new System.Windows.Forms.Panel();
            this.btnCancelChoose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetKML = new System.Windows.Forms.Button();
            this.btnDriveOrExt = new System.Windows.Forms.Button();
            this.panelKML = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelKML = new System.Windows.Forms.Button();
            this.btnLoadBoundaryFromGE = new System.Windows.Forms.Button();
            this.btnLoadMultiBoundaryFromGE = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelChoose.SuspendLayout();
            this.panelKML.SuspendLayout();
            this.SuspendLayout();
            // 
            // Boundary
            // 
            this.Boundary.BackColor = System.Drawing.Color.Transparent;
            this.Boundary.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Boundary.ForeColor = System.Drawing.Color.Black;
            this.Boundary.Location = new System.Drawing.Point(33, 90);
            this.Boundary.Name = "Boundary";
            this.Boundary.Size = new System.Drawing.Size(150, 50);
            this.Boundary.TabIndex = 203;
            this.Boundary.Text = "Bounds";
            this.Boundary.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Thru
            // 
            this.Thru.BackColor = System.Drawing.Color.Transparent;
            this.Thru.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Thru.ForeColor = System.Drawing.Color.Black;
            this.Thru.Location = new System.Drawing.Point(380, 90);
            this.Thru.Name = "Thru";
            this.Thru.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Thru.Size = new System.Drawing.Size(150, 50);
            this.Thru.TabIndex = 202;
            this.Thru.Text = "Thru?";
            this.Thru.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Area
            // 
            this.Area.BackColor = System.Drawing.Color.Transparent;
            this.Area.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Area.ForeColor = System.Drawing.Color.Black;
            this.Area.Location = new System.Drawing.Point(219, 90);
            this.Area.Name = "Area";
            this.Area.Size = new System.Drawing.Size(150, 50);
            this.Area.TabIndex = 201;
            this.Area.Text = "Area\r\n2nd";
            this.Area.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Gainsboro;
            this.panelMain.Controls.Add(this.btnBingMaps);
            this.panelMain.Controls.Add(this.tableLayoutPanel1);
            this.panelMain.Controls.Add(this.btnAdd);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.Area);
            this.panelMain.Controls.Add(this.Thru);
            this.panelMain.Controls.Add(this.Boundary);
            this.panelMain.Controls.Add(this.btnOpenGoogleEarth);
            this.panelMain.Controls.Add(this.btnDeleteAll);
            this.panelMain.Controls.Add(this.btnDelete);
            this.panelMain.Location = new System.Drawing.Point(2, 2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(543, 334);
            this.panelMain.TabIndex = 417;
            // 
            // btnBingMaps
            // 
            this.btnBingMaps.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnBingMaps.FlatAppearance.BorderSize = 0;
            this.btnBingMaps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBingMaps.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBingMaps.Image = global::AgOpenGPS.Properties.Resources.bing1;
            this.btnBingMaps.Location = new System.Drawing.Point(282, 19);
            this.btnBingMaps.Name = "btnBingMaps";
            this.btnBingMaps.Size = new System.Drawing.Size(62, 63);
            this.btnBingMaps.TabIndex = 217;
            this.btnBingMaps.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBingMaps.UseVisualStyleBackColor = true;
            this.btnBingMaps.Click += new System.EventHandler(this.btnBingMaps_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.88525F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.27049F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.74475F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(26, 140);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(488, 151);
            this.tableLayoutPanel1.TabIndex = 215;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::AgOpenGPS.Properties.Resources.AddNew;
            this.btnAdd.Location = new System.Drawing.Point(377, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 63);
            this.btnAdd.TabIndex = 214;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnAdd_HelpRequested);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(472, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 63);
            this.btnCancel.TabIndex = 206;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnReturn_Click);
            this.btnCancel.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnCancel_HelpRequested);
            // 
            // btnOpenGoogleEarth
            // 
            this.btnOpenGoogleEarth.FlatAppearance.BorderSize = 0;
            this.btnOpenGoogleEarth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenGoogleEarth.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenGoogleEarth.Image = global::AgOpenGPS.Properties.Resources.GoogleEarth;
            this.btnOpenGoogleEarth.Location = new System.Drawing.Point(187, 19);
            this.btnOpenGoogleEarth.Name = "btnOpenGoogleEarth";
            this.btnOpenGoogleEarth.Size = new System.Drawing.Size(62, 63);
            this.btnOpenGoogleEarth.TabIndex = 213;
            this.btnOpenGoogleEarth.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpenGoogleEarth.UseVisualStyleBackColor = true;
            this.btnOpenGoogleEarth.Click += new System.EventHandler(this.btnOpenGoogleEarth_Click);
            this.btnOpenGoogleEarth.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnOpenGoogleEarth_HelpRequested);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.FlatAppearance.BorderSize = 0;
            this.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAll.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAll.Image = global::AgOpenGPS.Properties.Resources.BoundaryDeleteAll;
            this.btnDeleteAll.Location = new System.Drawing.Point(96, 19);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(62, 63);
            this.btnDeleteAll.TabIndex = 100;
            this.btnDeleteAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            this.btnDeleteAll.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnDeleteAll_HelpRequested);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::AgOpenGPS.Properties.Resources.BoundaryDelete;
            this.btnDelete.Location = new System.Drawing.Point(5, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 63);
            this.btnDelete.TabIndex = 65;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnDelete_HelpRequested);
            // 
            // panelChoose
            // 
            this.panelChoose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelChoose.Controls.Add(this.btnCancelChoose);
            this.panelChoose.Controls.Add(this.label4);
            this.panelChoose.Controls.Add(this.btnGetKML);
            this.panelChoose.Controls.Add(this.btnDriveOrExt);
            this.panelChoose.Location = new System.Drawing.Point(565, 5);
            this.panelChoose.Name = "panelChoose";
            this.panelChoose.Size = new System.Drawing.Size(217, 325);
            this.panelChoose.TabIndex = 419;
            // 
            // btnCancelChoose
            // 
            this.btnCancelChoose.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelChoose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancelChoose.FlatAppearance.BorderSize = 0;
            this.btnCancelChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelChoose.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancelChoose.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancelChoose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelChoose.Location = new System.Drawing.Point(139, 260);
            this.btnCancelChoose.Name = "btnCancelChoose";
            this.btnCancelChoose.Size = new System.Drawing.Size(68, 58);
            this.btnCancelChoose.TabIndex = 425;
            this.btnCancelChoose.UseVisualStyleBackColor = false;
            this.btnCancelChoose.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(66, 110);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(35, 39);
            this.label4.TabIndex = 420;
            this.label4.Text = "?";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGetKML
            // 
            this.btnGetKML.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGetKML.FlatAppearance.BorderSize = 0;
            this.btnGetKML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetKML.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetKML.Image = global::AgOpenGPS.Properties.Resources.BoundaryLoadFromGE;
            this.btnGetKML.Location = new System.Drawing.Point(41, 16);
            this.btnGetKML.Name = "btnGetKML";
            this.btnGetKML.Size = new System.Drawing.Size(81, 78);
            this.btnGetKML.TabIndex = 213;
            this.btnGetKML.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGetKML.UseVisualStyleBackColor = true;
            this.btnGetKML.Click += new System.EventHandler(this.btnGetKML_Click);
            this.btnGetKML.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnGetKML_HelpRequested);
            // 
            // btnDriveOrExt
            // 
            this.btnDriveOrExt.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDriveOrExt.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDriveOrExt.FlatAppearance.BorderSize = 0;
            this.btnDriveOrExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDriveOrExt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDriveOrExt.Image = global::AgOpenGPS.Properties.Resources.SteerRight;
            this.btnDriveOrExt.Location = new System.Drawing.Point(41, 163);
            this.btnDriveOrExt.Name = "btnDriveOrExt";
            this.btnDriveOrExt.Size = new System.Drawing.Size(81, 78);
            this.btnDriveOrExt.TabIndex = 212;
            this.btnDriveOrExt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDriveOrExt.UseVisualStyleBackColor = true;
            this.btnDriveOrExt.Click += new System.EventHandler(this.btnDriveOrExt_Click);
            this.btnDriveOrExt.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnDriveOrExt_HelpRequested);
            // 
            // panelKML
            // 
            this.panelKML.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelKML.Controls.Add(this.label5);
            this.panelKML.Controls.Add(this.label3);
            this.panelKML.Controls.Add(this.btnCancelKML);
            this.panelKML.Controls.Add(this.btnLoadBoundaryFromGE);
            this.panelKML.Controls.Add(this.btnLoadMultiBoundaryFromGE);
            this.panelKML.Location = new System.Drawing.Point(788, 5);
            this.panelKML.Name = "panelKML";
            this.panelKML.Size = new System.Drawing.Size(229, 325);
            this.panelKML.TabIndex = 419;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(144, 167);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(31, 27);
            this.label5.TabIndex = 428;
            this.label5.Text = "+";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(131, 52);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(52, 27);
            this.label3.TabIndex = 427;
            this.label3.Text = "+++";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancelKML
            // 
            this.btnCancelKML.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelKML.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancelKML.FlatAppearance.BorderSize = 0;
            this.btnCancelKML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelKML.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancelKML.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancelKML.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelKML.Location = new System.Drawing.Point(150, 260);
            this.btnCancelKML.Name = "btnCancelKML";
            this.btnCancelKML.Size = new System.Drawing.Size(68, 58);
            this.btnCancelKML.TabIndex = 426;
            this.btnCancelKML.UseVisualStyleBackColor = false;
            this.btnCancelKML.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnLoadBoundaryFromGE
            // 
            this.btnLoadBoundaryFromGE.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLoadBoundaryFromGE.FlatAppearance.BorderSize = 0;
            this.btnLoadBoundaryFromGE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadBoundaryFromGE.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadBoundaryFromGE.Image = global::AgOpenGPS.Properties.Resources.BoundaryLoadFromGE;
            this.btnLoadBoundaryFromGE.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadBoundaryFromGE.Location = new System.Drawing.Point(44, 149);
            this.btnLoadBoundaryFromGE.Name = "btnLoadBoundaryFromGE";
            this.btnLoadBoundaryFromGE.Size = new System.Drawing.Size(81, 78);
            this.btnLoadBoundaryFromGE.TabIndex = 210;
            this.btnLoadBoundaryFromGE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadBoundaryFromGE.UseVisualStyleBackColor = true;
            this.btnLoadBoundaryFromGE.Click += new System.EventHandler(this.btnLoadBoundaryFromGE_Click);
            this.btnLoadBoundaryFromGE.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnLoadBoundaryFromGE_HelpRequested);
            // 
            // btnLoadMultiBoundaryFromGE
            // 
            this.btnLoadMultiBoundaryFromGE.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLoadMultiBoundaryFromGE.FlatAppearance.BorderSize = 0;
            this.btnLoadMultiBoundaryFromGE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadMultiBoundaryFromGE.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadMultiBoundaryFromGE.Image = global::AgOpenGPS.Properties.Resources.BoundaryLoadMultiFromGE;
            this.btnLoadMultiBoundaryFromGE.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadMultiBoundaryFromGE.Location = new System.Drawing.Point(44, 23);
            this.btnLoadMultiBoundaryFromGE.Name = "btnLoadMultiBoundaryFromGE";
            this.btnLoadMultiBoundaryFromGE.Size = new System.Drawing.Size(81, 78);
            this.btnLoadMultiBoundaryFromGE.TabIndex = 211;
            this.btnLoadMultiBoundaryFromGE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadMultiBoundaryFromGE.UseVisualStyleBackColor = true;
            this.btnLoadMultiBoundaryFromGE.Click += new System.EventHandler(this.btnLoadBoundaryFromGE_Click);
            this.btnLoadMultiBoundaryFromGE.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnLoadMultiBoundaryFromGE_HelpRequested);
            // 
            // FormBoundary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(1028, 338);
            this.Controls.Add(this.panelChoose);
            this.Controls.Add(this.panelKML);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBoundary";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Boundary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBoundary_FormClosing);
            this.Load += new System.EventHandler(this.FormBoundary_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelChoose.ResumeLayout(false);
            this.panelChoose.PerformLayout();
            this.panelKML.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Label Boundary;
        private System.Windows.Forms.Label Thru;
        private System.Windows.Forms.Label Area;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLoadMultiBoundaryFromGE;
        private System.Windows.Forms.Button btnLoadBoundaryFromGE;
        private System.Windows.Forms.Button btnDriveOrExt;
        private System.Windows.Forms.Button btnOpenGoogleEarth;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelKML;
        private System.Windows.Forms.Panel panelChoose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetKML;
        private System.Windows.Forms.Button btnCancelKML;
        private System.Windows.Forms.Button btnCancelChoose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBingMaps;
    }
}