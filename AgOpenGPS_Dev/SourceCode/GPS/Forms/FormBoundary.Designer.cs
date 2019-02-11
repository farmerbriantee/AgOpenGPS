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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBoundary));
            this.btnLeftRight = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOuter = new System.Windows.Forms.Button();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnLoadBoundaryFromGE = new System.Windows.Forms.Button();
            this.btnOpenGoogleEarth = new System.Windows.Forms.Button();
            this.cboxSelectBoundary = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxDriveThru = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lvLines = new System.Windows.Forms.ListView();
            this.chField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAngle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAround = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEasting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnToggleDriveThru = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cboxDriveAround = new System.Windows.Forms.ComboBox();
            this.btnToggleDriveAround = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLoadMultiBoundaryFromGE = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLeftRight
            // 
            this.btnLeftRight.Enabled = false;
            this.btnLeftRight.Image = ((System.Drawing.Image)(resources.GetObject("btnLeftRight.Image")));
            this.btnLeftRight.Location = new System.Drawing.Point(685, 14);
            this.btnLeftRight.Name = "btnLeftRight";
            this.btnLeftRight.Size = new System.Drawing.Size(121, 109);
            this.btnLeftRight.TabIndex = 67;
            this.btnLeftRight.UseVisualStyleBackColor = true;
            this.btnLeftRight.Click += new System.EventHandler(this.btnLeftRight_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(684, 333);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 109);
            this.btnDelete.TabIndex = 65;
            this.btnDelete.Text = "Delete 1";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOuter
            // 
            this.btnOuter.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOuter.Image = ((System.Drawing.Image)(resources.GetObject("btnOuter.Image")));
            this.btnOuter.Location = new System.Drawing.Point(526, 14);
            this.btnOuter.Name = "btnOuter";
            this.btnOuter.Size = new System.Drawing.Size(121, 109);
            this.btnOuter.TabIndex = 65;
            this.btnOuter.Text = "Create";
            this.btnOuter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOuter.UseVisualStyleBackColor = true;
            this.btnOuter.Click += new System.EventHandler(this.btnOuter_Click);
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnSerialCancel.Image")));
            this.btnSerialCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSerialCancel.Location = new System.Drawing.Point(832, 333);
            this.btnSerialCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(121, 109);
            this.btnSerialCancel.TabIndex = 64;
            this.btnSerialCancel.Text = "Return";
            this.btnSerialCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            this.btnSerialCancel.Click += new System.EventHandler(this.btnSerialCancel_Click);
            // 
            // btnGo
            // 
            this.btnGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGo.Enabled = false;
            this.btnGo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
            this.btnGo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGo.Location = new System.Drawing.Point(833, 14);
            this.btnGo.Margin = new System.Windows.Forms.Padding(5);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(121, 109);
            this.btnGo.TabIndex = 63;
            this.btnGo.Text = "Go!";
            this.btnGo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGo.UseVisualStyleBackColor = true;
            // 
            // btnLoadBoundaryFromGE
            // 
            this.btnLoadBoundaryFromGE.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadBoundaryFromGE.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadBoundaryFromGE.Image")));
            this.btnLoadBoundaryFromGE.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadBoundaryFromGE.Location = new System.Drawing.Point(685, 180);
            this.btnLoadBoundaryFromGE.Name = "btnLoadBoundaryFromGE";
            this.btnLoadBoundaryFromGE.Size = new System.Drawing.Size(121, 109);
            this.btnLoadBoundaryFromGE.TabIndex = 68;
            this.btnLoadBoundaryFromGE.Text = "Load 1";
            this.btnLoadBoundaryFromGE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadBoundaryFromGE.UseVisualStyleBackColor = true;
            this.btnLoadBoundaryFromGE.Click += new System.EventHandler(this.btnLoadBoundaryFromGE_Click);
            // 
            // btnOpenGoogleEarth
            // 
            this.btnOpenGoogleEarth.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenGoogleEarth.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenGoogleEarth.Image")));
            this.btnOpenGoogleEarth.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpenGoogleEarth.Location = new System.Drawing.Point(526, 180);
            this.btnOpenGoogleEarth.Name = "btnOpenGoogleEarth";
            this.btnOpenGoogleEarth.Size = new System.Drawing.Size(121, 109);
            this.btnOpenGoogleEarth.TabIndex = 69;
            this.btnOpenGoogleEarth.Text = "Google Earth";
            this.btnOpenGoogleEarth.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpenGoogleEarth.UseVisualStyleBackColor = true;
            this.btnOpenGoogleEarth.Click += new System.EventHandler(this.btnOpenGoogleEarth_Click);
            // 
            // cboxSelectBoundary
            // 
            this.cboxSelectBoundary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSelectBoundary.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSelectBoundary.FormattingEnabled = true;
            this.cboxSelectBoundary.Items.AddRange(new object[] {
            "Outer",
            "Inner 1",
            "Inner 2",
            "Inner 3",
            "Inner 4",
            "Inner 5"});
            this.cboxSelectBoundary.Location = new System.Drawing.Point(17, 43);
            this.cboxSelectBoundary.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxSelectBoundary.Name = "cboxSelectBoundary";
            this.cboxSelectBoundary.Size = new System.Drawing.Size(163, 43);
            this.cboxSelectBoundary.TabIndex = 73;
            this.cboxSelectBoundary.SelectedIndexChanged += new System.EventHandler(this.cboxSelectBoundary_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.TabIndex = 74;
            this.label1.Text = "Select Boundary";
            // 
            // cboxDriveThru
            // 
            this.cboxDriveThru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDriveThru.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDriveThru.FormattingEnabled = true;
            this.cboxDriveThru.Items.AddRange(new object[] {
            "False",
            "True"});
            this.cboxDriveThru.Location = new System.Drawing.Point(238, 43);
            this.cboxDriveThru.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxDriveThru.Name = "cboxDriveThru";
            this.cboxDriveThru.Size = new System.Drawing.Size(107, 43);
            this.cboxDriveThru.TabIndex = 75;
            this.cboxDriveThru.SelectedIndexChanged += new System.EventHandler(this.cboxDriveThru_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(234, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 25);
            this.label2.TabIndex = 76;
            this.label2.Text = "Drive Thru?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(157, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 25);
            this.label3.TabIndex = 90;
            this.label3.Text = "Area";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(304, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 91;
            this.label4.Text = "Thru";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 25);
            this.label5.TabIndex = 92;
            this.label5.Text = "Bounds";
            // 
            // lvLines
            // 
            this.lvLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chField,
            this.chAngle,
            this.chAround,
            this.chEasting});
            this.lvLines.Enabled = false;
            this.lvLines.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLines.GridLines = true;
            this.lvLines.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvLines.LabelWrap = false;
            this.lvLines.Location = new System.Drawing.Point(17, 146);
            this.lvLines.MultiSelect = false;
            this.lvLines.Name = "lvLines";
            this.lvLines.Scrollable = false;
            this.lvLines.ShowGroups = false;
            this.lvLines.Size = new System.Drawing.Size(491, 255);
            this.lvLines.TabIndex = 93;
            this.lvLines.UseCompatibleStateImageBehavior = false;
            this.lvLines.View = System.Windows.Forms.View.Details;
            // 
            // chField
            // 
            this.chField.Text = "Line";
            this.chField.Width = 110;
            // 
            // chAngle
            // 
            this.chAngle.Text = "Drive Thru";
            this.chAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chAngle.Width = 165;
            // 
            // chAround
            // 
            this.chAround.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chAround.Width = 100;
            // 
            // chEasting
            // 
            this.chEasting.Text = "Area";
            this.chEasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chEasting.Width = 100;
            // 
            // btnToggleDriveThru
            // 
            this.btnToggleDriveThru.Location = new System.Drawing.Point(80, 407);
            this.btnToggleDriveThru.Name = "btnToggleDriveThru";
            this.btnToggleDriveThru.Size = new System.Drawing.Size(171, 35);
            this.btnToggleDriveThru.TabIndex = 94;
            this.btnToggleDriveThru.Text = "Toggle Drive Thru";
            this.btnToggleDriveThru.UseVisualStyleBackColor = true;
            this.btnToggleDriveThru.Click += new System.EventHandler(this.btnToggleDriveThru_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(397, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 25);
            this.label6.TabIndex = 96;
            this.label6.Text = "Go Around?";
            // 
            // cboxDriveAround
            // 
            this.cboxDriveAround.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDriveAround.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDriveAround.FormattingEnabled = true;
            this.cboxDriveAround.Items.AddRange(new object[] {
            "False",
            "True"});
            this.cboxDriveAround.Location = new System.Drawing.Point(401, 43);
            this.cboxDriveAround.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxDriveAround.Name = "cboxDriveAround";
            this.cboxDriveAround.Size = new System.Drawing.Size(107, 43);
            this.cboxDriveAround.TabIndex = 95;
            this.cboxDriveAround.SelectedIndexChanged += new System.EventHandler(this.cboxDriveAround_SelectedIndexChanged);
            // 
            // btnToggleDriveAround
            // 
            this.btnToggleDriveAround.Location = new System.Drawing.Point(286, 407);
            this.btnToggleDriveAround.Name = "btnToggleDriveAround";
            this.btnToggleDriveAround.Size = new System.Drawing.Size(171, 35);
            this.btnToggleDriveAround.TabIndex = 97;
            this.btnToggleDriveAround.Text = "Toggle Drive By";
            this.btnToggleDriveAround.UseVisualStyleBackColor = true;
            this.btnToggleDriveAround.Click += new System.EventHandler(this.btnToggleDriveAround_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(403, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 25);
            this.label7.TabIndex = 98;
            this.label7.Text = "Around";
            // 
            // btnLoadMultiBoundaryFromGE
            // 
            this.btnLoadMultiBoundaryFromGE.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadMultiBoundaryFromGE.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadMultiBoundaryFromGE.Image")));
            this.btnLoadMultiBoundaryFromGE.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadMultiBoundaryFromGE.Location = new System.Drawing.Point(832, 180);
            this.btnLoadMultiBoundaryFromGE.Name = "btnLoadMultiBoundaryFromGE";
            this.btnLoadMultiBoundaryFromGE.Size = new System.Drawing.Size(121, 109);
            this.btnLoadMultiBoundaryFromGE.TabIndex = 99;
            this.btnLoadMultiBoundaryFromGE.Text = "Load Multi";
            this.btnLoadMultiBoundaryFromGE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadMultiBoundaryFromGE.UseVisualStyleBackColor = true;
            this.btnLoadMultiBoundaryFromGE.Click += new System.EventHandler(this.btnLoadMultiBoundaryFromGE_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAll.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteAll.Location = new System.Drawing.Point(525, 333);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(121, 109);
            this.btnDeleteAll.TabIndex = 100;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // FormBoundary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 449);
            this.ControlBox = false;
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnLoadMultiBoundaryFromGE);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnToggleDriveAround);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboxDriveAround);
            this.Controls.Add(this.btnToggleDriveThru);
            this.Controls.Add(this.lvLines);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboxDriveThru);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxSelectBoundary);
            this.Controls.Add(this.btnOpenGoogleEarth);
            this.Controls.Add(this.btnLoadBoundaryFromGE);
            this.Controls.Add(this.btnLeftRight);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOuter);
            this.Controls.Add(this.btnSerialCancel);
            this.Controls.Add(this.btnGo);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormBoundary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Start or Delete A Boundary";
            this.Load += new System.EventHandler(this.FormBoundary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnOuter;
        private System.Windows.Forms.Button btnLeftRight;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLoadBoundaryFromGE;
        private System.Windows.Forms.Button btnOpenGoogleEarth;
        private System.Windows.Forms.ComboBox cboxSelectBoundary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxDriveThru;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lvLines;
        private System.Windows.Forms.ColumnHeader chField;
        private System.Windows.Forms.ColumnHeader chAngle;
        private System.Windows.Forms.ColumnHeader chEasting;
        private System.Windows.Forms.Button btnToggleDriveThru;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboxDriveAround;
        private System.Windows.Forms.ColumnHeader chAround;
        private System.Windows.Forms.Button btnToggleDriveAround;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLoadMultiBoundaryFromGE;
        private System.Windows.Forms.Button btnDeleteAll;
    }
}