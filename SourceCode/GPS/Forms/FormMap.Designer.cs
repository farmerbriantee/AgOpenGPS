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
            this.cmbTileServers = new System.Windows.Forms.ComboBox();
            this.mapControl = new System.Windows.Forms.MapControl();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblBnds = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.cboxDrawMap = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.cboxEnableLineDraw = new System.Windows.Forms.CheckBox();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnAddFence = new System.Windows.Forms.Button();
            this.btnDeletePoint = new System.Windows.Forms.Button();
            this.btnGray = new System.Windows.Forms.Button();
            this.btnBuildFieldBackground = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmbTileServers
            // 
            this.cmbTileServers.AllowDrop = true;
            this.cmbTileServers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbTileServers.DisplayMember = "Name";
            this.cmbTileServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTileServers.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTileServers.FormattingEnabled = true;
            this.cmbTileServers.Location = new System.Drawing.Point(12, 521);
            this.cmbTileServers.Name = "cmbTileServers";
            this.cmbTileServers.Size = new System.Drawing.Size(273, 31);
            this.cmbTileServers.TabIndex = 462;
            this.cmbTileServers.Tag = "";
            this.cmbTileServers.Visible = false;
            this.cmbTileServers.SelectedIndexChanged += new System.EventHandler(this.cmbTileServers_SelectedIndexChanged);
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
            this.mapControl.Size = new System.Drawing.Size(705, 638);
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
            // lblPoints
            // 
            this.lblPoints.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPoints.BackColor = System.Drawing.Color.Transparent;
            this.lblPoints.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPoints.Location = new System.Drawing.Point(38, 75);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(42, 23);
            this.lblPoints.TabIndex = 476;
            this.lblPoints.Text = "12";
            this.lblPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBnds
            // 
            this.lblBnds.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBnds.BackColor = System.Drawing.Color.Transparent;
            this.lblBnds.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBnds.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBnds.Location = new System.Drawing.Point(158, 75);
            this.lblBnds.Name = "lblBnds";
            this.lblBnds.Size = new System.Drawing.Size(42, 23);
            this.lblBnds.TabIndex = 489;
            this.lblBnds.Text = "2";
            this.lblBnds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblBnds, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnZoomIn, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnZoomOut, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.cboxDrawMap, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnGo, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.cboxEnableLineDraw, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPoints, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteAll, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddFence, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnDeletePoint, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnGray, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnBuildFieldBackground, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(707, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.86694F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.09048F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.86137F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.93346F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.11645F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.13131F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(239, 657);
            this.tableLayoutPanel1.TabIndex = 491;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(122, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 23);
            this.label1.TabIndex = 492;
            this.label1.Text = "Apply";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnZoomIn.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomIn.BackgroundImage = global::AgOpenGPS.Properties.Resources.ZoomIn48;
            this.btnZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomIn.FlatAppearance.BorderSize = 0;
            this.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomIn.Location = new System.Drawing.Point(154, 498);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(50, 47);
            this.btnZoomIn.TabIndex = 484;
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnZoomOut.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomOut.BackgroundImage = global::AgOpenGPS.Properties.Resources.ZoomOut48;
            this.btnZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomOut.FlatAppearance.BorderSize = 0;
            this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomOut.Location = new System.Drawing.Point(34, 498);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(50, 47);
            this.btnZoomOut.TabIndex = 485;
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // cboxDrawMap
            // 
            this.cboxDrawMap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxDrawMap.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxDrawMap.BackColor = System.Drawing.Color.Transparent;
            this.cboxDrawMap.FlatAppearance.BorderSize = 0;
            this.cboxDrawMap.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxDrawMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxDrawMap.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDrawMap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxDrawMap.Image = global::AgOpenGPS.Properties.Resources.MappingOff;
            this.cboxDrawMap.Location = new System.Drawing.Point(28, 248);
            this.cboxDrawMap.Name = "cboxDrawMap";
            this.cboxDrawMap.Size = new System.Drawing.Size(63, 70);
            this.cboxDrawMap.TabIndex = 482;
            this.cboxDrawMap.UseVisualStyleBackColor = false;
            this.cboxDrawMap.Click += new System.EventHandler(this.cboxDrawMap_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExit.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnExit.Location = new System.Drawing.Point(148, 583);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(61, 63);
            this.btnExit.TabIndex = 234;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGo.BackColor = System.Drawing.Color.Transparent;
            this.btnGo.FlatAppearance.BorderSize = 0;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Image = global::AgOpenGPS.Properties.Resources.FlagGrn;
            this.btnGo.Location = new System.Drawing.Point(28, 586);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(63, 57);
            this.btnGo.TabIndex = 465;
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // cboxEnableLineDraw
            // 
            this.cboxEnableLineDraw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxEnableLineDraw.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxEnableLineDraw.BackColor = System.Drawing.Color.Transparent;
            this.cboxEnableLineDraw.FlatAppearance.BorderSize = 0;
            this.cboxEnableLineDraw.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxEnableLineDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxEnableLineDraw.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxEnableLineDraw.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxEnableLineDraw.Image = global::AgOpenGPS.Properties.Resources.Boundary;
            this.cboxEnableLineDraw.Location = new System.Drawing.Point(29, 6);
            this.cboxEnableLineDraw.Name = "cboxEnableLineDraw";
            this.cboxEnableLineDraw.Size = new System.Drawing.Size(61, 59);
            this.cboxEnableLineDraw.TabIndex = 472;
            this.cboxEnableLineDraw.UseVisualStyleBackColor = false;
            this.cboxEnableLineDraw.Click += new System.EventHandler(this.cboxEnableLineDraw_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteAll.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteAll.Enabled = false;
            this.btnDeleteAll.FlatAppearance.BorderSize = 0;
            this.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAll.Image = global::AgOpenGPS.Properties.Resources.Trash;
            this.btnDeleteAll.Location = new System.Drawing.Point(148, 6);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(61, 59);
            this.btnDeleteAll.TabIndex = 471;
            this.btnDeleteAll.UseVisualStyleBackColor = false;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnAddFence
            // 
            this.btnAddFence.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddFence.BackColor = System.Drawing.Color.Transparent;
            this.btnAddFence.Enabled = false;
            this.btnAddFence.FlatAppearance.BorderSize = 0;
            this.btnAddFence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFence.Image = global::AgOpenGPS.Properties.Resources.BoundaryOuter;
            this.btnAddFence.Location = new System.Drawing.Point(148, 114);
            this.btnAddFence.Name = "btnAddFence";
            this.btnAddFence.Size = new System.Drawing.Size(61, 61);
            this.btnAddFence.TabIndex = 470;
            this.btnAddFence.UseVisualStyleBackColor = false;
            this.btnAddFence.Click += new System.EventHandler(this.btnAddFence_Click);
            // 
            // btnDeletePoint
            // 
            this.btnDeletePoint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeletePoint.BackColor = System.Drawing.Color.Transparent;
            this.btnDeletePoint.Enabled = false;
            this.btnDeletePoint.FlatAppearance.BorderSize = 0;
            this.btnDeletePoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePoint.Image = global::AgOpenGPS.Properties.Resources.PointDelete;
            this.btnDeletePoint.Location = new System.Drawing.Point(29, 114);
            this.btnDeletePoint.Name = "btnDeletePoint";
            this.btnDeletePoint.Size = new System.Drawing.Size(61, 61);
            this.btnDeletePoint.TabIndex = 468;
            this.btnDeletePoint.UseVisualStyleBackColor = false;
            this.btnDeletePoint.Click += new System.EventHandler(this.btnDeletePoint_Click);
            // 
            // btnGray
            // 
            this.btnGray.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGray.BackColor = System.Drawing.Color.Transparent;
            this.btnGray.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGray.FlatAppearance.BorderSize = 0;
            this.btnGray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGray.Image = global::AgOpenGPS.Properties.Resources.MapColor;
            this.btnGray.Location = new System.Drawing.Point(147, 248);
            this.btnGray.Name = "btnGray";
            this.btnGray.Size = new System.Drawing.Size(63, 70);
            this.btnGray.TabIndex = 483;
            this.btnGray.UseVisualStyleBackColor = false;
            this.btnGray.Visible = false;
            this.btnGray.Click += new System.EventHandler(this.btnGray_Click);
            // 
            // btnBuildFieldBackground
            // 
            this.btnBuildFieldBackground.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBuildFieldBackground.BackColor = System.Drawing.Color.Transparent;
            this.btnBuildFieldBackground.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBuildFieldBackground.FlatAppearance.BorderSize = 0;
            this.btnBuildFieldBackground.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuildFieldBackground.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuildFieldBackground.ForeColor = System.Drawing.Color.Black;
            this.btnBuildFieldBackground.Image = global::AgOpenGPS.Properties.Resources.Background;
            this.btnBuildFieldBackground.Location = new System.Drawing.Point(29, 352);
            this.btnBuildFieldBackground.Name = "btnBuildFieldBackground";
            this.btnBuildFieldBackground.Size = new System.Drawing.Size(87, 76);
            this.btnBuildFieldBackground.TabIndex = 486;
            this.btnBuildFieldBackground.UseVisualStyleBackColor = false;
            this.btnBuildFieldBackground.Click += new System.EventHandler(this.btnBuildFieldBackground_Click);
            // 
            // FormMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(949, 684);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mapControl);
            this.Controls.Add(this.cmbTileServers);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(965, 700);
            this.Name = "FormMap";
            this.ShowInTaskbar = false;
            this.Text = "Bing Maps for Background";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMap_FormClosing);
            this.Load += new System.EventHandler(this.FormMap_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cmbTileServers;
        private System.Windows.Forms.MapControl mapControl;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnDeletePoint;
        private System.Windows.Forms.Button btnAddFence;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.CheckBox cboxEnableLineDraw;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.CheckBox cboxDrawMap;
        private System.Windows.Forms.Button btnGray;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnBuildFieldBackground;
        private System.Windows.Forms.Label lblBnds;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
    }
}