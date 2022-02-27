namespace AgOpenGPS
{
    partial class FormMap
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbTileServers = new System.Windows.Forms.ComboBox();
            this.btnClearCache = new System.Windows.Forms.Button();
            this.mapControl = new System.Windows.Forms.MapControl();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnPic = new System.Windows.Forms.Button();
            this.btnDeletePoint = new System.Windows.Forms.Button();
            this.btnAddFence = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.cboxEnableLineDraw = new System.Windows.Forms.CheckBox();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnS = new System.Windows.Forms.Button();
            this.btnN = new System.Windows.Forms.Button();
            this.btnW = new System.Windows.Forms.Button();
            this.btnE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExit.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnExit.Location = new System.Drawing.Point(743, 454);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(61, 61);
            this.btnExit.TabIndex = 234;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbTileServers
            // 
            this.cmbTileServers.AllowDrop = true;
            this.cmbTileServers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTileServers.DisplayMember = "Name";
            this.cmbTileServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTileServers.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTileServers.FormattingEnabled = true;
            this.cmbTileServers.Location = new System.Drawing.Point(540, 50);
            this.cmbTileServers.Name = "cmbTileServers";
            this.cmbTileServers.Size = new System.Drawing.Size(265, 31);
            this.cmbTileServers.TabIndex = 462;
            this.cmbTileServers.SelectedIndexChanged += new System.EventHandler(this.cmbTileServers_SelectedIndexChanged);
            // 
            // btnClearCache
            // 
            this.btnClearCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCache.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCache.Location = new System.Drawing.Point(670, 3);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(134, 32);
            this.btnClearCache.TabIndex = 461;
            this.btnClearCache.Text = "Clear cache";
            this.btnClearCache.UseVisualStyleBackColor = true;
            this.btnClearCache.Click += new System.EventHandler(this.btnClearCache_Click);
            // 
            // mapControl
            // 
            this.mapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapControl.BackColor = System.Drawing.Color.White;
            this.mapControl.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mapControl.ErrorColor = System.Drawing.Color.Red;
            this.mapControl.FitToBounds = true;
            this.mapControl.ForeColor = System.Drawing.Color.Black;
            this.mapControl.Location = new System.Drawing.Point(3, 3);
            this.mapControl.Name = "mapControl";
            this.mapControl.ShowThumbnails = true;
            this.mapControl.Size = new System.Drawing.Size(512, 512);
            this.mapControl.TabIndex = 464;
            this.mapControl.ThumbnailBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mapControl.ThumbnailForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.mapControl.ThumbnailText = "Downloading...";
            this.mapControl.TileImageAttributes = null;
            this.mapControl.ZoomLevel = 2;
            this.mapControl.Click += new System.EventHandler(this.mapControl_Click);
            this.mapControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapControl_MouseMove);
            this.mapControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.mapControl_MouseWheel);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.BackColor = System.Drawing.Color.Transparent;
            this.btnGo.FlatAppearance.BorderSize = 0;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Image = global::AgOpenGPS.Properties.Resources.FlagGrn;
            this.btnGo.Location = new System.Drawing.Point(629, 276);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(61, 61);
            this.btnGo.TabIndex = 465;
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnPic
            // 
            this.btnPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPic.BackColor = System.Drawing.Color.Transparent;
            this.btnPic.FlatAppearance.BorderSize = 0;
            this.btnPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPic.Image = global::AgOpenGPS.Properties.Resources.Webcam;
            this.btnPic.Location = new System.Drawing.Point(531, 276);
            this.btnPic.Name = "btnPic";
            this.btnPic.Size = new System.Drawing.Size(61, 61);
            this.btnPic.TabIndex = 466;
            this.btnPic.Text = "Pic";
            this.btnPic.UseVisualStyleBackColor = false;
            this.btnPic.Click += new System.EventHandler(this.btnPic_Click);
            // 
            // btnDeletePoint
            // 
            this.btnDeletePoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeletePoint.BackColor = System.Drawing.Color.Transparent;
            this.btnDeletePoint.Enabled = false;
            this.btnDeletePoint.FlatAppearance.BorderSize = 0;
            this.btnDeletePoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePoint.Image = global::AgOpenGPS.Properties.Resources.PointDelete;
            this.btnDeletePoint.Location = new System.Drawing.Point(531, 173);
            this.btnDeletePoint.Name = "btnDeletePoint";
            this.btnDeletePoint.Size = new System.Drawing.Size(61, 61);
            this.btnDeletePoint.TabIndex = 468;
            this.btnDeletePoint.UseVisualStyleBackColor = false;
            this.btnDeletePoint.Click += new System.EventHandler(this.btnDeletePoint_Click);
            // 
            // btnAddFence
            // 
            this.btnAddFence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFence.BackColor = System.Drawing.Color.Transparent;
            this.btnAddFence.Enabled = false;
            this.btnAddFence.FlatAppearance.BorderSize = 0;
            this.btnAddFence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFence.Image = global::AgOpenGPS.Properties.Resources.BoundaryOuter;
            this.btnAddFence.Location = new System.Drawing.Point(629, 173);
            this.btnAddFence.Name = "btnAddFence";
            this.btnAddFence.Size = new System.Drawing.Size(61, 61);
            this.btnAddFence.TabIndex = 470;
            this.btnAddFence.UseVisualStyleBackColor = false;
            this.btnAddFence.Click += new System.EventHandler(this.btnAddFence_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAll.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteAll.Enabled = false;
            this.btnDeleteAll.FlatAppearance.BorderSize = 0;
            this.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAll.Image = global::AgOpenGPS.Properties.Resources.BoundaryDeleteAll;
            this.btnDeleteAll.Location = new System.Drawing.Point(743, 173);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(61, 61);
            this.btnDeleteAll.TabIndex = 471;
            this.btnDeleteAll.UseVisualStyleBackColor = false;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // cboxEnableLineDraw
            // 
            this.cboxEnableLineDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxEnableLineDraw.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxEnableLineDraw.BackColor = System.Drawing.Color.Transparent;
            this.cboxEnableLineDraw.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxEnableLineDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxEnableLineDraw.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxEnableLineDraw.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxEnableLineDraw.Image = global::AgOpenGPS.Properties.Resources.Boundary;
            this.cboxEnableLineDraw.Location = new System.Drawing.Point(521, 86);
            this.cboxEnableLineDraw.Name = "cboxEnableLineDraw";
            this.cboxEnableLineDraw.Size = new System.Drawing.Size(90, 63);
            this.cboxEnableLineDraw.TabIndex = 472;
            this.cboxEnableLineDraw.UseVisualStyleBackColor = false;
            this.cboxEnableLineDraw.Click += new System.EventHandler(this.cboxEnableLineDraw_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomIn.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomIn.FlatAppearance.BorderSize = 0;
            this.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomIn.Image = global::AgOpenGPS.Properties.Resources.ZoomIn48;
            this.btnZoomIn.Location = new System.Drawing.Point(630, 454);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(60, 57);
            this.btnZoomIn.TabIndex = 473;
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomOut.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomOut.FlatAppearance.BorderSize = 0;
            this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomOut.Image = global::AgOpenGPS.Properties.Resources.ZoomOut48;
            this.btnZoomOut.Location = new System.Drawing.Point(541, 454);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(60, 57);
            this.btnZoomOut.TabIndex = 474;
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnOff
            // 
            this.btnOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOff.BackColor = System.Drawing.Color.Transparent;
            this.btnOff.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOff.FlatAppearance.BorderSize = 0;
            this.btnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOff.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOff.Image = global::AgOpenGPS.Properties.Resources.SwitchOff;
            this.btnOff.Location = new System.Drawing.Point(743, 276);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(61, 61);
            this.btnOff.TabIndex = 234;
            this.btnOff.UseVisualStyleBackColor = false;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(716, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 23);
            this.label2.TabIndex = 475;
            this.label2.Text = "Points:";
            // 
            // lblPoints
            // 
            this.lblPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPoints.BackColor = System.Drawing.Color.Transparent;
            this.lblPoints.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPoints.Location = new System.Drawing.Point(728, 118);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(42, 23);
            this.lblPoints.TabIndex = 476;
            this.lblPoints.Text = "12";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(621, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 48);
            this.label1.TabIndex = 469;
            this.label1.Text = "Draw\r\nLines";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnS
            // 
            this.btnS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnS.BackColor = System.Drawing.Color.Transparent;
            this.btnS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnS.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnS.Location = new System.Drawing.Point(603, 384);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(45, 42);
            this.btnS.TabIndex = 477;
            this.btnS.Text = "S";
            this.btnS.UseVisualStyleBackColor = false;
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // btnN
            // 
            this.btnN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnN.BackColor = System.Drawing.Color.Transparent;
            this.btnN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnN.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnN.Location = new System.Drawing.Point(525, 384);
            this.btnN.Name = "btnN";
            this.btnN.Size = new System.Drawing.Size(45, 42);
            this.btnN.TabIndex = 478;
            this.btnN.Text = "N";
            this.btnN.UseVisualStyleBackColor = false;
            this.btnN.Click += new System.EventHandler(this.btnN_Click);
            // 
            // btnW
            // 
            this.btnW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnW.BackColor = System.Drawing.Color.Transparent;
            this.btnW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnW.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnW.Location = new System.Drawing.Point(759, 384);
            this.btnW.Name = "btnW";
            this.btnW.Size = new System.Drawing.Size(45, 42);
            this.btnW.TabIndex = 479;
            this.btnW.Text = "W";
            this.btnW.UseVisualStyleBackColor = false;
            this.btnW.Click += new System.EventHandler(this.btnW_Click);
            // 
            // btnE
            // 
            this.btnE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnE.BackColor = System.Drawing.Color.Transparent;
            this.btnE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnE.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE.Location = new System.Drawing.Point(681, 384);
            this.btnE.Name = "btnE";
            this.btnE.Size = new System.Drawing.Size(45, 42);
            this.btnE.TabIndex = 480;
            this.btnE.Text = "E";
            this.btnE.UseVisualStyleBackColor = false;
            this.btnE.Click += new System.EventHandler(this.btnE_Click);
            // 
            // FormMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(809, 518);
            this.Controls.Add(this.btnE);
            this.Controls.Add(this.btnW);
            this.Controls.Add(this.btnN);
            this.Controls.Add(this.btnS);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.cboxEnableLineDraw);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnAddFence);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeletePoint);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnPic);
            this.Controls.Add(this.cmbTileServers);
            this.Controls.Add(this.btnClearCache);
            this.Controls.Add(this.btnOff);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.mapControl);
            this.HelpButton = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(825, 557);
            this.Name = "FormMap";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bing Maps for Background";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHeadland_FormClosing);
            this.Load += new System.EventHandler(this.FormHeadland_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cmbTileServers;
        private System.Windows.Forms.Button btnClearCache;
        private System.Windows.Forms.MapControl mapControl;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnPic;
        private System.Windows.Forms.Button btnDeletePoint;
        private System.Windows.Forms.Button btnAddFence;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.CheckBox cboxEnableLineDraw;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnS;
        private System.Windows.Forms.Button btnN;
        private System.Windows.Forms.Button btnW;
        private System.Windows.Forms.Button btnE;
    }
}