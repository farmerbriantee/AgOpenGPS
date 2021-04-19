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
            this.lblCurveExists = new System.Windows.Forms.Label();
            this.lvLines = new System.Windows.Forms.ListView();
            this.chField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.panelName = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddTime = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel_Name = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelPick = new System.Windows.Forms.Panel();
            this.btnSwapAB = new System.Windows.Forms.Button();
            this.btnEditName = new System.Windows.Forms.Button();
            this.btnDuplicate = new System.Windows.Forms.Button();
            this.btnCancelMain = new System.Windows.Forms.Button();
            this.btnNewCurve = new System.Windows.Forms.Button();
            this.btnListDelete = new System.Windows.Forms.Button();
            this.btnListUse = new System.Windows.Forms.Button();
            this.panelAPlus = new System.Windows.Forms.Panel();
            this.btnCancelCurve = new System.Windows.Forms.Button();
            this.btnAPoint = new System.Windows.Forms.Button();
            this.btnBPoint = new System.Windows.Forms.Button();
            this.btnPausePlay = new System.Windows.Forms.Button();
            this.panelEditName = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddTimeEdit = new System.Windows.Forms.Button();
            this.btnSaveEditName = new System.Windows.Forms.Button();
            this.btnCancelEditName = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panelName.SuspendLayout();
            this.panelPick.SuspendLayout();
            this.panelAPlus.SuspendLayout();
            this.panelEditName.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurveExists
            // 
            this.lblCurveExists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurveExists.AutoSize = true;
            this.lblCurveExists.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurveExists.ForeColor = System.Drawing.Color.Black;
            this.lblCurveExists.Location = new System.Drawing.Point(29, 34);
            this.lblCurveExists.Name = "lblCurveExists";
            this.lblCurveExists.Size = new System.Drawing.Size(91, 23);
            this.lblCurveExists.TabIndex = 87;
            this.lblCurveExists.Text = "> OFF <";
            this.lblCurveExists.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvLines
            // 
            this.lvLines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chField});
            this.lvLines.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLines.FullRowSelect = true;
            this.lvLines.GridLines = true;
            this.lvLines.HideSelection = false;
            this.lvLines.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.lvLines.LabelWrap = false;
            this.lvLines.Location = new System.Drawing.Point(6, 6);
            this.lvLines.Margin = new System.Windows.Forms.Padding(0);
            this.lvLines.MultiSelect = false;
            this.lvLines.Name = "lvLines";
            this.lvLines.Size = new System.Drawing.Size(350, 230);
            this.lvLines.TabIndex = 141;
            this.lvLines.TileSize = new System.Drawing.Size(350, 35);
            this.lvLines.UseCompatibleStateImageBehavior = false;
            this.lvLines.View = System.Windows.Forms.View.Tile;
            // 
            // chField
            // 
            this.chField.Text = "CurveLines";
            this.chField.Width = 239;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(29, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 148;
            this.label2.Text = "Status: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelName
            // 
            this.panelName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelName.Controls.Add(this.label1);
            this.panelName.Controls.Add(this.btnAddTime);
            this.panelName.Controls.Add(this.btnAdd);
            this.panelName.Controls.Add(this.btnCancel_Name);
            this.panelName.Controls.Add(this.textBox1);
            this.panelName.Location = new System.Drawing.Point(11, 360);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(241, 313);
            this.panelName.TabIndex = 434;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(48, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 29);
            this.label1.TabIndex = 424;
            this.label1.Text = "+";
            // 
            // btnAddTime
            // 
            this.btnAddTime.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAddTime.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddTime.FlatAppearance.BorderSize = 0;
            this.btnAddTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTime.Image = global::AgOpenGPS.Properties.Resources.Time;
            this.btnAddTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddTime.Location = new System.Drawing.Point(87, 133);
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(68, 69);
            this.btnAddTime.TabIndex = 150;
            this.btnAddTime.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddTime.UseVisualStyleBackColor = false;
            this.btnAddTime.Click += new System.EventHandler(this.btnAddTime_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(141, 226);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 70);
            this.btnAdd.TabIndex = 150;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel_Name
            // 
            this.btnCancel_Name.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel_Name.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel_Name.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel_Name.FlatAppearance.BorderSize = 0;
            this.btnCancel_Name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel_Name.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel_Name.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel_Name.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel_Name.Location = new System.Drawing.Point(5, 226);
            this.btnCancel_Name.Name = "btnCancel_Name";
            this.btnCancel_Name.Size = new System.Drawing.Size(88, 70);
            this.btnCancel_Name.TabIndex = 423;
            this.btnCancel_Name.UseVisualStyleBackColor = false;
            this.btnCancel_Name.Click += new System.EventHandler(this.btnCancelCurve_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.CausesValidation = false;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(17, 37);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.MaxLength = 100;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 77);
            this.textBox1.TabIndex = 145;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // panelPick
            // 
            this.panelPick.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPick.Controls.Add(this.btnSwapAB);
            this.panelPick.Controls.Add(this.btnEditName);
            this.panelPick.Controls.Add(this.btnDuplicate);
            this.panelPick.Controls.Add(this.lvLines);
            this.panelPick.Controls.Add(this.btnCancelMain);
            this.panelPick.Controls.Add(this.btnNewCurve);
            this.panelPick.Controls.Add(this.btnListDelete);
            this.panelPick.Controls.Add(this.btnListUse);
            this.panelPick.Location = new System.Drawing.Point(34, 22);
            this.panelPick.Name = "panelPick";
            this.panelPick.Size = new System.Drawing.Size(442, 313);
            this.panelPick.TabIndex = 435;
            // 
            // btnSwapAB
            // 
            this.btnSwapAB.FlatAppearance.BorderSize = 0;
            this.btnSwapAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwapAB.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwapAB.Image = global::AgOpenGPS.Properties.Resources.ABSwapPoints;
            this.btnSwapAB.Location = new System.Drawing.Point(366, 154);
            this.btnSwapAB.Name = "btnSwapAB";
            this.btnSwapAB.Size = new System.Drawing.Size(71, 63);
            this.btnSwapAB.TabIndex = 426;
            this.btnSwapAB.UseVisualStyleBackColor = true;
            this.btnSwapAB.Click += new System.EventHandler(this.btnSwapAB_Click);
            // 
            // btnEditName
            // 
            this.btnEditName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnEditName.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEditName.FlatAppearance.BorderSize = 0;
            this.btnEditName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditName.Image = global::AgOpenGPS.Properties.Resources.FileEditName;
            this.btnEditName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditName.Location = new System.Drawing.Point(366, 81);
            this.btnEditName.Name = "btnEditName";
            this.btnEditName.Size = new System.Drawing.Size(71, 63);
            this.btnEditName.TabIndex = 425;
            this.btnEditName.UseVisualStyleBackColor = false;
            this.btnEditName.Click += new System.EventHandler(this.btnEditName_Click);
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnDuplicate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDuplicate.FlatAppearance.BorderSize = 0;
            this.btnDuplicate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuplicate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDuplicate.Image = global::AgOpenGPS.Properties.Resources.FileCopy;
            this.btnDuplicate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDuplicate.Location = new System.Drawing.Point(366, 8);
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(71, 63);
            this.btnDuplicate.TabIndex = 424;
            this.btnDuplicate.UseVisualStyleBackColor = false;
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // btnCancelMain
            // 
            this.btnCancelMain.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancelMain.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelMain.FlatAppearance.BorderSize = 0;
            this.btnCancelMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelMain.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancelMain.Image = global::AgOpenGPS.Properties.Resources.SwitchOff;
            this.btnCancelMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelMain.Location = new System.Drawing.Point(125, 241);
            this.btnCancelMain.Name = "btnCancelMain";
            this.btnCancelMain.Size = new System.Drawing.Size(71, 63);
            this.btnCancelMain.TabIndex = 422;
            this.btnCancelMain.UseVisualStyleBackColor = false;
            this.btnCancelMain.Click += new System.EventHandler(this.btnCancelMain_Click);
            // 
            // btnNewCurve
            // 
            this.btnNewCurve.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNewCurve.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNewCurve.FlatAppearance.BorderSize = 0;
            this.btnNewCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewCurve.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCurve.Image = global::AgOpenGPS.Properties.Resources.AddNew;
            this.btnNewCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNewCurve.Location = new System.Drawing.Point(242, 241);
            this.btnNewCurve.Name = "btnNewCurve";
            this.btnNewCurve.Size = new System.Drawing.Size(71, 63);
            this.btnNewCurve.TabIndex = 150;
            this.btnNewCurve.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNewCurve.UseVisualStyleBackColor = false;
            this.btnNewCurve.Click += new System.EventHandler(this.btnNewCurve_Click);
            // 
            // btnListDelete
            // 
            this.btnListDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnListDelete.FlatAppearance.BorderSize = 0;
            this.btnListDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListDelete.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnListDelete.Image = global::AgOpenGPS.Properties.Resources.HideContour;
            this.btnListDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnListDelete.Location = new System.Drawing.Point(8, 241);
            this.btnListDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnListDelete.Name = "btnListDelete";
            this.btnListDelete.Size = new System.Drawing.Size(71, 63);
            this.btnListDelete.TabIndex = 142;
            this.btnListDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListDelete.UseVisualStyleBackColor = false;
            this.btnListDelete.Click += new System.EventHandler(this.btnListDelete_Click);
            // 
            // btnListUse
            // 
            this.btnListUse.BackColor = System.Drawing.Color.Transparent;
            this.btnListUse.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnListUse.FlatAppearance.BorderSize = 0;
            this.btnListUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListUse.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnListUse.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnListUse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnListUse.Location = new System.Drawing.Point(365, 239);
            this.btnListUse.Margin = new System.Windows.Forms.Padding(0);
            this.btnListUse.Name = "btnListUse";
            this.btnListUse.Size = new System.Drawing.Size(71, 63);
            this.btnListUse.TabIndex = 144;
            this.btnListUse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListUse.UseVisualStyleBackColor = false;
            this.btnListUse.Click += new System.EventHandler(this.btnListUse_Click);
            // 
            // panelAPlus
            // 
            this.panelAPlus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelAPlus.Controls.Add(this.btnCancelCurve);
            this.panelAPlus.Controls.Add(this.btnAPoint);
            this.panelAPlus.Controls.Add(this.btnBPoint);
            this.panelAPlus.Controls.Add(this.btnPausePlay);
            this.panelAPlus.Controls.Add(this.lblCurveExists);
            this.panelAPlus.Controls.Add(this.label2);
            this.panelAPlus.Location = new System.Drawing.Point(273, 360);
            this.panelAPlus.Name = "panelAPlus";
            this.panelAPlus.Size = new System.Drawing.Size(241, 313);
            this.panelAPlus.TabIndex = 436;
            // 
            // btnCancelCurve
            // 
            this.btnCancelCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancelCurve.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelCurve.FlatAppearance.BorderSize = 0;
            this.btnCancelCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancelCurve.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancelCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelCurve.Location = new System.Drawing.Point(151, 210);
            this.btnCancelCurve.Name = "btnCancelCurve";
            this.btnCancelCurve.Size = new System.Drawing.Size(82, 81);
            this.btnCancelCurve.TabIndex = 423;
            this.btnCancelCurve.UseVisualStyleBackColor = false;
            this.btnCancelCurve.Click += new System.EventHandler(this.btnCancelCurve_Click);
            // 
            // btnAPoint
            // 
            this.btnAPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAPoint.BackColor = System.Drawing.Color.Transparent;
            this.btnAPoint.FlatAppearance.BorderSize = 0;
            this.btnAPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAPoint.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnAPoint.Image = global::AgOpenGPS.Properties.Resources.LetterABlue;
            this.btnAPoint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAPoint.Location = new System.Drawing.Point(20, 60);
            this.btnAPoint.Name = "btnAPoint";
            this.btnAPoint.Size = new System.Drawing.Size(87, 98);
            this.btnAPoint.TabIndex = 63;
            this.btnAPoint.UseVisualStyleBackColor = false;
            this.btnAPoint.Click += new System.EventHandler(this.btnAPoint_Click);
            // 
            // btnBPoint
            // 
            this.btnBPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBPoint.BackColor = System.Drawing.Color.Transparent;
            this.btnBPoint.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBPoint.FlatAppearance.BorderSize = 0;
            this.btnBPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBPoint.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnBPoint.Image = global::AgOpenGPS.Properties.Resources.LetterBBlue;
            this.btnBPoint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBPoint.Location = new System.Drawing.Point(146, 60);
            this.btnBPoint.Name = "btnBPoint";
            this.btnBPoint.Size = new System.Drawing.Size(87, 98);
            this.btnBPoint.TabIndex = 64;
            this.btnBPoint.UseVisualStyleBackColor = false;
            this.btnBPoint.Click += new System.EventHandler(this.btnBPoint_Click);
            // 
            // btnPausePlay
            // 
            this.btnPausePlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPausePlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPausePlay.Enabled = false;
            this.btnPausePlay.FlatAppearance.BorderSize = 0;
            this.btnPausePlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPausePlay.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPausePlay.Image = global::AgOpenGPS.Properties.Resources.boundaryPause;
            this.btnPausePlay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPausePlay.Location = new System.Drawing.Point(25, 210);
            this.btnPausePlay.Name = "btnPausePlay";
            this.btnPausePlay.Size = new System.Drawing.Size(82, 81);
            this.btnPausePlay.TabIndex = 140;
            this.btnPausePlay.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPausePlay.UseVisualStyleBackColor = false;
            this.btnPausePlay.Click += new System.EventHandler(this.btnPausePlay_Click);
            // 
            // panelEditName
            // 
            this.panelEditName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelEditName.Controls.Add(this.label3);
            this.panelEditName.Controls.Add(this.btnAddTimeEdit);
            this.panelEditName.Controls.Add(this.btnSaveEditName);
            this.panelEditName.Controls.Add(this.btnCancelEditName);
            this.panelEditName.Controls.Add(this.textBox2);
            this.panelEditName.Location = new System.Drawing.Point(528, 360);
            this.panelEditName.Name = "panelEditName";
            this.panelEditName.Size = new System.Drawing.Size(241, 313);
            this.panelEditName.TabIndex = 437;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(48, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 29);
            this.label3.TabIndex = 424;
            this.label3.Text = "+";
            // 
            // btnAddTimeEdit
            // 
            this.btnAddTimeEdit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAddTimeEdit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddTimeEdit.FlatAppearance.BorderSize = 0;
            this.btnAddTimeEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTimeEdit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTimeEdit.Image = global::AgOpenGPS.Properties.Resources.Time;
            this.btnAddTimeEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddTimeEdit.Location = new System.Drawing.Point(87, 133);
            this.btnAddTimeEdit.Name = "btnAddTimeEdit";
            this.btnAddTimeEdit.Size = new System.Drawing.Size(68, 69);
            this.btnAddTimeEdit.TabIndex = 150;
            this.btnAddTimeEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddTimeEdit.UseVisualStyleBackColor = false;
            this.btnAddTimeEdit.Click += new System.EventHandler(this.btnAddTimeEdit_Click);
            // 
            // btnSaveEditName
            // 
            this.btnSaveEditName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSaveEditName.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSaveEditName.FlatAppearance.BorderSize = 0;
            this.btnSaveEditName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveEditName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEditName.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnSaveEditName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveEditName.Location = new System.Drawing.Point(141, 226);
            this.btnSaveEditName.Name = "btnSaveEditName";
            this.btnSaveEditName.Size = new System.Drawing.Size(88, 70);
            this.btnSaveEditName.TabIndex = 150;
            this.btnSaveEditName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveEditName.UseVisualStyleBackColor = false;
            this.btnSaveEditName.Click += new System.EventHandler(this.btnSaveEditName_Click);
            // 
            // btnCancelEditName
            // 
            this.btnCancelEditName.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelEditName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancelEditName.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelEditName.FlatAppearance.BorderSize = 0;
            this.btnCancelEditName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelEditName.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancelEditName.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancelEditName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelEditName.Location = new System.Drawing.Point(5, 226);
            this.btnCancelEditName.Name = "btnCancelEditName";
            this.btnCancelEditName.Size = new System.Drawing.Size(88, 70);
            this.btnCancelEditName.TabIndex = 423;
            this.btnCancelEditName.UseVisualStyleBackColor = false;
            this.btnCancelEditName.Click += new System.EventHandler(this.btnCancelCurve_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox2.CausesValidation = false;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(17, 37);
            this.textBox2.Margin = new System.Windows.Forms.Padding(0);
            this.textBox2.MaxLength = 100;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(204, 77);
            this.textBox2.TabIndex = 145;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            // 
            // FormABCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(819, 689);
            this.ControlBox = false;
            this.Controls.Add(this.panelEditName);
            this.Controls.Add(this.panelAPlus);
            this.Controls.Add(this.panelPick);
            this.Controls.Add(this.panelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormABCurve";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AB Curve";
            this.Load += new System.EventHandler(this.FormABCurve_Load);
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            this.panelPick.ResumeLayout(false);
            this.panelAPlus.ResumeLayout(false);
            this.panelAPlus.PerformLayout();
            this.panelEditName.ResumeLayout(false);
            this.panelEditName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBPoint;
        private System.Windows.Forms.Button btnAPoint;
        private System.Windows.Forms.Label lblCurveExists;
        private System.Windows.Forms.Button btnPausePlay;
        private System.Windows.Forms.ListView lvLines;
        private System.Windows.Forms.ColumnHeader chField;
        private System.Windows.Forms.Button btnListDelete;
        private System.Windows.Forms.Button btnListUse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNewCurve;
        private System.Windows.Forms.Button btnCancelMain;
        private System.Windows.Forms.Button btnCancelCurve;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddTime;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel_Name;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panelPick;
        private System.Windows.Forms.Panel panelAPlus;
        private System.Windows.Forms.Button btnEditName;
        private System.Windows.Forms.Button btnDuplicate;
        private System.Windows.Forms.Panel panelEditName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddTimeEdit;
        private System.Windows.Forms.Button btnSaveEditName;
        private System.Windows.Forms.Button btnCancelEditName;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnSwapAB;
    }
}
