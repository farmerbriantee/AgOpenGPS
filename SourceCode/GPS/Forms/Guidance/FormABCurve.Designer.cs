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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormABCurve));
            this.lblCurveExists = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelName = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddTime = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel_Name = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelPick = new System.Windows.Forms.Panel();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDn = new System.Windows.Forms.Button();
            this.flp = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSwapAB = new System.Windows.Forms.Button();
            this.btnEditName = new System.Windows.Forms.Button();
            this.btnDuplicate = new System.Windows.Forms.Button();
            this.btnCancelMain = new System.Windows.Forms.Button();
            this.btnChooseTrackMethod = new System.Windows.Forms.Button();
            this.btnListDelete = new System.Windows.Forms.Button();
            this.btnListUse = new System.Windows.Forms.Button();
            this.panelABCurve = new System.Windows.Forms.Panel();
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
            this.panelKML = new System.Windows.Forms.Panel();
            this.btnCancelKML = new System.Windows.Forms.Button();
            this.panelChoose = new System.Windows.Forms.Panel();
            this.btnzABLine = new System.Windows.Forms.Button();
            this.btnzLatLonPlusHeading = new System.Windows.Forms.Button();
            this.btnzLatLon = new System.Windows.Forms.Button();
            this.btnzNewLoadFromKMLCurve = new System.Windows.Forms.Button();
            this.btnzABCurve = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1btnCancelChoose = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panelABLine = new System.Windows.Forms.Panel();
            this.btnCancel_APlus = new System.Windows.Forms.Button();
            this.btnEnter_AB = new System.Windows.Forms.Button();
            this.nudHeading = new System.Windows.Forms.NumericUpDown();
            this.btnABAPoint = new System.Windows.Forms.Button();
            this.btnABBPoint = new System.Windows.Forms.Button();
            this.panelName.SuspendLayout();
            this.panelPick.SuspendLayout();
            this.panelABCurve.SuspendLayout();
            this.panelEditName.SuspendLayout();
            this.panelKML.SuspendLayout();
            this.panelChoose.SuspendLayout();
            this.panelABLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCurveExists
            // 
            this.lblCurveExists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurveExists.AutoSize = true;
            this.lblCurveExists.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurveExists.ForeColor = System.Drawing.Color.Black;
            this.lblCurveExists.Location = new System.Drawing.Point(101, 46);
            this.lblCurveExists.Name = "lblCurveExists";
            this.lblCurveExists.Size = new System.Drawing.Size(91, 23);
            this.lblCurveExists.TabIndex = 87;
            this.lblCurveExists.Text = "> OFF <";
            this.lblCurveExists.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(23, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 148;
            this.label2.Text = "Status: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelName
            // 
            this.panelName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelName.Controls.Add(this.label11);
            this.panelName.Controls.Add(this.label1);
            this.panelName.Controls.Add(this.btnAddTime);
            this.panelName.Controls.Add(this.btnAdd);
            this.panelName.Controls.Add(this.btnCancel_Name);
            this.panelName.Controls.Add(this.textBox1);
            this.panelName.Location = new System.Drawing.Point(256, 461);
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
            this.btnAddTime.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnAddTime_HelpRequested);
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
            this.btnAdd.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnAdd_HelpRequested);
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
            this.btnCancel_Name.Click += new System.EventHandler(this.btnCancelTrack_Click);
            this.btnCancel_Name.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnCancel_Name_HelpRequested);
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
            this.textBox1.Click += new System.EventHandler(this.textBox_Click);
            this.textBox1.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.textBox1_HelpRequested);
            // 
            // panelPick
            // 
            this.panelPick.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPick.Controls.Add(this.btnMoveUp);
            this.panelPick.Controls.Add(this.btnMoveDn);
            this.panelPick.Controls.Add(this.flp);
            this.panelPick.Controls.Add(this.btnSwapAB);
            this.panelPick.Controls.Add(this.btnEditName);
            this.panelPick.Controls.Add(this.btnDuplicate);
            this.panelPick.Controls.Add(this.btnCancelMain);
            this.panelPick.Controls.Add(this.btnChooseTrackMethod);
            this.panelPick.Controls.Add(this.btnListDelete);
            this.panelPick.Controls.Add(this.btnListUse);
            this.panelPick.Location = new System.Drawing.Point(9, 5);
            this.panelPick.Name = "panelPick";
            this.panelPick.Size = new System.Drawing.Size(600, 450);
            this.panelPick.TabIndex = 435;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.FlatAppearance.BorderSize = 0;
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveUp.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnMoveUp.Location = new System.Drawing.Point(511, 10);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(78, 57);
            this.btnMoveUp.TabIndex = 430;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDn
            // 
            this.btnMoveDn.FlatAppearance.BorderSize = 0;
            this.btnMoveDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveDn.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnMoveDn.Location = new System.Drawing.Point(511, 84);
            this.btnMoveDn.Name = "btnMoveDn";
            this.btnMoveDn.Size = new System.Drawing.Size(78, 57);
            this.btnMoveDn.TabIndex = 429;
            this.btnMoveDn.UseVisualStyleBackColor = true;
            this.btnMoveDn.Click += new System.EventHandler(this.btnMoveDn_Click);
            // 
            // flp
            // 
            this.flp.AutoScroll = true;
            this.flp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flp.Location = new System.Drawing.Point(89, 8);
            this.flp.Name = "flp";
            this.flp.Size = new System.Drawing.Size(414, 421);
            this.flp.TabIndex = 428;
            // 
            // btnSwapAB
            // 
            this.btnSwapAB.FlatAppearance.BorderSize = 0;
            this.btnSwapAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwapAB.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwapAB.Image = global::AgOpenGPS.Properties.Resources.ABSwapPoints;
            this.btnSwapAB.Location = new System.Drawing.Point(7, 8);
            this.btnSwapAB.Name = "btnSwapAB";
            this.btnSwapAB.Size = new System.Drawing.Size(71, 63);
            this.btnSwapAB.TabIndex = 426;
            this.btnSwapAB.UseVisualStyleBackColor = true;
            this.btnSwapAB.Click += new System.EventHandler(this.btnSwapAB_Click);
            this.btnSwapAB.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnSwapAB_HelpRequested);
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
            this.btnEditName.Location = new System.Drawing.Point(7, 95);
            this.btnEditName.Name = "btnEditName";
            this.btnEditName.Size = new System.Drawing.Size(71, 63);
            this.btnEditName.TabIndex = 425;
            this.btnEditName.UseVisualStyleBackColor = false;
            this.btnEditName.Click += new System.EventHandler(this.btnEditName_Click);
            this.btnEditName.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnEditName_HelpRequested);
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
            this.btnDuplicate.Location = new System.Drawing.Point(7, 182);
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(71, 63);
            this.btnDuplicate.TabIndex = 424;
            this.btnDuplicate.UseVisualStyleBackColor = false;
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            this.btnDuplicate.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnDuplicate_HelpRequested);
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
            this.btnCancelMain.Location = new System.Drawing.Point(7, 269);
            this.btnCancelMain.Name = "btnCancelMain";
            this.btnCancelMain.Size = new System.Drawing.Size(71, 63);
            this.btnCancelMain.TabIndex = 422;
            this.btnCancelMain.UseVisualStyleBackColor = false;
            this.btnCancelMain.Click += new System.EventHandler(this.btnCancelMain_Click);
            this.btnCancelMain.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnCancelMain_HelpRequested);
            // 
            // btnChooseTrackMethod
            // 
            this.btnChooseTrackMethod.BackColor = System.Drawing.Color.Transparent;
            this.btnChooseTrackMethod.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnChooseTrackMethod.FlatAppearance.BorderSize = 0;
            this.btnChooseTrackMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseTrackMethod.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseTrackMethod.Image = global::AgOpenGPS.Properties.Resources.AddNew;
            this.btnChooseTrackMethod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnChooseTrackMethod.Location = new System.Drawing.Point(511, 254);
            this.btnChooseTrackMethod.Name = "btnChooseTrackMethod";
            this.btnChooseTrackMethod.Size = new System.Drawing.Size(78, 69);
            this.btnChooseTrackMethod.TabIndex = 150;
            this.btnChooseTrackMethod.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnChooseTrackMethod.UseVisualStyleBackColor = false;
            this.btnChooseTrackMethod.Click += new System.EventHandler(this.btnChooseTrackMethod_Click);
            this.btnChooseTrackMethod.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnNewCurve_HelpRequested);
            // 
            // btnListDelete
            // 
            this.btnListDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnListDelete.FlatAppearance.BorderSize = 0;
            this.btnListDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListDelete.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnListDelete.Image = global::AgOpenGPS.Properties.Resources.HideContour;
            this.btnListDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnListDelete.Location = new System.Drawing.Point(7, 356);
            this.btnListDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnListDelete.Name = "btnListDelete";
            this.btnListDelete.Size = new System.Drawing.Size(62, 63);
            this.btnListDelete.TabIndex = 142;
            this.btnListDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListDelete.UseVisualStyleBackColor = false;
            this.btnListDelete.Click += new System.EventHandler(this.btnListDelete_Click);
            this.btnListDelete.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnListDelete_HelpRequested);
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
            this.btnListUse.Location = new System.Drawing.Point(511, 357);
            this.btnListUse.Margin = new System.Windows.Forms.Padding(0);
            this.btnListUse.Name = "btnListUse";
            this.btnListUse.Size = new System.Drawing.Size(78, 63);
            this.btnListUse.TabIndex = 144;
            this.btnListUse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListUse.UseVisualStyleBackColor = false;
            this.btnListUse.Click += new System.EventHandler(this.btnListUse_Click);
            this.btnListUse.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnListUse_HelpRequested);
            // 
            // panelABCurve
            // 
            this.panelABCurve.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelABCurve.Controls.Add(this.label10);
            this.panelABCurve.Controls.Add(this.btnCancelCurve);
            this.panelABCurve.Controls.Add(this.btnAPoint);
            this.panelABCurve.Controls.Add(this.btnBPoint);
            this.panelABCurve.Controls.Add(this.btnPausePlay);
            this.panelABCurve.Controls.Add(this.lblCurveExists);
            this.panelABCurve.Controls.Add(this.label2);
            this.panelABCurve.Location = new System.Drawing.Point(9, 461);
            this.panelABCurve.Name = "panelABCurve";
            this.panelABCurve.Size = new System.Drawing.Size(241, 313);
            this.panelABCurve.TabIndex = 436;
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
            this.btnCancelCurve.Location = new System.Drawing.Point(20, 215);
            this.btnCancelCurve.Name = "btnCancelCurve";
            this.btnCancelCurve.Size = new System.Drawing.Size(82, 81);
            this.btnCancelCurve.TabIndex = 423;
            this.btnCancelCurve.UseVisualStyleBackColor = false;
            this.btnCancelCurve.Click += new System.EventHandler(this.btnCancelTrack_Click);
            this.btnCancelCurve.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnCancelCurve_HelpRequested);
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
            this.btnAPoint.Location = new System.Drawing.Point(20, 72);
            this.btnAPoint.Name = "btnAPoint";
            this.btnAPoint.Size = new System.Drawing.Size(87, 98);
            this.btnAPoint.TabIndex = 63;
            this.btnAPoint.UseVisualStyleBackColor = false;
            this.btnAPoint.Click += new System.EventHandler(this.btnAPoint_Click);
            this.btnAPoint.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnAPoint_HelpRequested);
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
            this.btnBPoint.Location = new System.Drawing.Point(146, 72);
            this.btnBPoint.Name = "btnBPoint";
            this.btnBPoint.Size = new System.Drawing.Size(87, 98);
            this.btnBPoint.TabIndex = 64;
            this.btnBPoint.UseVisualStyleBackColor = false;
            this.btnBPoint.Click += new System.EventHandler(this.btnBPoint_Click);
            this.btnBPoint.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnBPoint_HelpRequested);
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
            this.btnPausePlay.Location = new System.Drawing.Point(146, 215);
            this.btnPausePlay.Name = "btnPausePlay";
            this.btnPausePlay.Size = new System.Drawing.Size(82, 81);
            this.btnPausePlay.TabIndex = 140;
            this.btnPausePlay.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPausePlay.UseVisualStyleBackColor = false;
            this.btnPausePlay.Click += new System.EventHandler(this.btnPausePlay_Click);
            this.btnPausePlay.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnPausePlay_HelpRequested);
            // 
            // panelEditName
            // 
            this.panelEditName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelEditName.Controls.Add(this.label12);
            this.panelEditName.Controls.Add(this.label3);
            this.panelEditName.Controls.Add(this.btnAddTimeEdit);
            this.panelEditName.Controls.Add(this.btnSaveEditName);
            this.panelEditName.Controls.Add(this.btnCancelEditName);
            this.panelEditName.Controls.Add(this.textBox2);
            this.panelEditName.Location = new System.Drawing.Point(1585, 444);
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
            this.btnAddTimeEdit.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnAddTimeEdit_HelpRequested);
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
            this.btnSaveEditName.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnSaveEditName_HelpRequested);
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
            this.btnCancelEditName.Click += new System.EventHandler(this.btnCancelTrack_Click);
            this.btnCancelEditName.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.btnCancelEditName_HelpRequested);
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
            this.textBox2.Click += new System.EventHandler(this.textBox_Click);
            this.textBox2.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.textBox2_HelpRequested);
            // 
            // panelKML
            // 
            this.panelKML.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelKML.Controls.Add(this.label13);
            this.panelKML.Controls.Add(this.btnCancelKML);
            this.panelKML.Location = new System.Drawing.Point(1585, 112);
            this.panelKML.Name = "panelKML";
            this.panelKML.Size = new System.Drawing.Size(241, 313);
            this.panelKML.TabIndex = 438;
            // 
            // btnCancelKML
            // 
            this.btnCancelKML.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelKML.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancelKML.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelKML.FlatAppearance.BorderSize = 0;
            this.btnCancelKML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelKML.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancelKML.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancelKML.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelKML.Location = new System.Drawing.Point(5, 226);
            this.btnCancelKML.Name = "btnCancelKML";
            this.btnCancelKML.Size = new System.Drawing.Size(88, 70);
            this.btnCancelKML.TabIndex = 423;
            this.btnCancelKML.UseVisualStyleBackColor = false;
            this.btnCancelKML.Click += new System.EventHandler(this.btnCancelTrack_Click);
            // 
            // panelChoose
            // 
            this.panelChoose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelChoose.Controls.Add(this.btnzLatLonPlusHeading);
            this.panelChoose.Controls.Add(this.button10);
            this.panelChoose.Controls.Add(this.button1btnCancelChoose);
            this.panelChoose.Controls.Add(this.btnzLatLon);
            this.panelChoose.Controls.Add(this.btnzNewLoadFromKMLCurve);
            this.panelChoose.Controls.Add(this.button7);
            this.panelChoose.Controls.Add(this.btnzABLine);
            this.panelChoose.Controls.Add(this.btnzABCurve);
            this.panelChoose.Location = new System.Drawing.Point(615, 5);
            this.panelChoose.Name = "panelChoose";
            this.panelChoose.Size = new System.Drawing.Size(600, 450);
            this.panelChoose.TabIndex = 440;
            // 
            // btnzABLine
            // 
            this.btnzABLine.BackColor = System.Drawing.Color.Transparent;
            this.btnzABLine.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnzABLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnzABLine.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnzABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineOn;
            this.btnzABLine.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnzABLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnzABLine.Location = new System.Drawing.Point(307, 342);
            this.btnzABLine.Name = "btnzABLine";
            this.btnzABLine.Size = new System.Drawing.Size(90, 80);
            this.btnzABLine.TabIndex = 444;
            this.btnzABLine.Text = "AB Line";
            this.btnzABLine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnzABLine.UseVisualStyleBackColor = false;
            this.btnzABLine.Click += new System.EventHandler(this.btnzABLine_Click);
            // 
            // btnzLatLonPlusHeading
            // 
            this.btnzLatLonPlusHeading.BackColor = System.Drawing.Color.Transparent;
            this.btnzLatLonPlusHeading.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnzLatLonPlusHeading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnzLatLonPlusHeading.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnzLatLonPlusHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnzLatLonPlusHeading.Location = new System.Drawing.Point(307, 10);
            this.btnzLatLonPlusHeading.Name = "btnzLatLonPlusHeading";
            this.btnzLatLonPlusHeading.Size = new System.Drawing.Size(90, 80);
            this.btnzLatLonPlusHeading.TabIndex = 441;
            this.btnzLatLonPlusHeading.Text = "Lat/Lon +";
            this.btnzLatLonPlusHeading.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnzLatLonPlusHeading.UseVisualStyleBackColor = false;
            // 
            // btnzLatLon
            // 
            this.btnzLatLon.BackColor = System.Drawing.Color.Transparent;
            this.btnzLatLon.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnzLatLon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnzLatLon.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnzLatLon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnzLatLon.Location = new System.Drawing.Point(140, 10);
            this.btnzLatLon.Name = "btnzLatLon";
            this.btnzLatLon.Size = new System.Drawing.Size(90, 80);
            this.btnzLatLon.TabIndex = 438;
            this.btnzLatLon.Text = "Lat/Lon";
            this.btnzLatLon.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnzLatLon.UseVisualStyleBackColor = false;
            // 
            // btnzNewLoadFromKMLCurve
            // 
            this.btnzNewLoadFromKMLCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnzNewLoadFromKMLCurve.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnzNewLoadFromKMLCurve.FlatAppearance.BorderSize = 0;
            this.btnzNewLoadFromKMLCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnzNewLoadFromKMLCurve.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnzNewLoadFromKMLCurve.Image = global::AgOpenGPS.Properties.Resources.BoundaryLoadFromGE;
            this.btnzNewLoadFromKMLCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnzNewLoadFromKMLCurve.Location = new System.Drawing.Point(481, 182);
            this.btnzNewLoadFromKMLCurve.Name = "btnzNewLoadFromKMLCurve";
            this.btnzNewLoadFromKMLCurve.Size = new System.Drawing.Size(90, 80);
            this.btnzNewLoadFromKMLCurve.TabIndex = 443;
            this.btnzNewLoadFromKMLCurve.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnzNewLoadFromKMLCurve.UseVisualStyleBackColor = false;
            this.btnzNewLoadFromKMLCurve.Click += new System.EventHandler(this.btnzNewLoadFromKML_Click);
            // 
            // btnzABCurve
            // 
            this.btnzABCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnzABCurve.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnzABCurve.FlatAppearance.BorderSize = 0;
            this.btnzABCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnzABCurve.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnzABCurve.Image = global::AgOpenGPS.Properties.Resources.CurveOn;
            this.btnzABCurve.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnzABCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnzABCurve.Location = new System.Drawing.Point(481, 342);
            this.btnzABCurve.Name = "btnzABCurve";
            this.btnzABCurve.Size = new System.Drawing.Size(90, 80);
            this.btnzABCurve.TabIndex = 443;
            this.btnzABCurve.Text = "Curve";
            this.btnzABCurve.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnzABCurve.UseVisualStyleBackColor = false;
            this.btnzABCurve.Click += new System.EventHandler(this.btnzNewABCurve_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button10.Location = new System.Drawing.Point(307, 182);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(90, 80);
            this.button10.TabIndex = 435;
            this.button10.Text = "Inner Boundary";
            this.button10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button7.Location = new System.Drawing.Point(140, 182);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(90, 80);
            this.button7.TabIndex = 432;
            this.button7.Text = "Outer Boundary";
            this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ABLineOn.png");
            this.imageList1.Images.SetKeyName(1, "ContourOn.png");
            this.imageList1.Images.SetKeyName(2, "BoundaryCurveLine.png");
            // 
            // button1btnCancelChoose
            // 
            this.button1btnCancelChoose.BackColor = System.Drawing.Color.Transparent;
            this.button1btnCancelChoose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1btnCancelChoose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1btnCancelChoose.FlatAppearance.BorderSize = 0;
            this.button1btnCancelChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1btnCancelChoose.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.button1btnCancelChoose.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.button1btnCancelChoose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1btnCancelChoose.Location = new System.Drawing.Point(5, 352);
            this.button1btnCancelChoose.Name = "button1btnCancelChoose";
            this.button1btnCancelChoose.Size = new System.Drawing.Size(88, 70);
            this.button1btnCancelChoose.TabIndex = 423;
            this.button1btnCancelChoose.UseVisualStyleBackColor = false;
            this.button1btnCancelChoose.Click += new System.EventHandler(this.btnCancelTrack_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(71, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 16);
            this.label10.TabIndex = 446;
            this.label10.Text = "AB Curve";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(64, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 16);
            this.label11.TabIndex = 446;
            this.label11.Text = "Add Name";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(85, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 16);
            this.label12.TabIndex = 447;
            this.label12.Text = "Edit Name";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(91, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 16);
            this.label13.TabIndex = 447;
            this.label13.Text = "Load KML";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelABLine
            // 
            this.panelABLine.BackColor = System.Drawing.Color.Transparent;
            this.panelABLine.Controls.Add(this.btnCancel_APlus);
            this.panelABLine.Controls.Add(this.btnEnter_AB);
            this.panelABLine.Controls.Add(this.nudHeading);
            this.panelABLine.Controls.Add(this.btnABAPoint);
            this.panelABLine.Controls.Add(this.btnABBPoint);
            this.panelABLine.Location = new System.Drawing.Point(503, 461);
            this.panelABLine.Name = "panelABLine";
            this.panelABLine.Size = new System.Drawing.Size(241, 313);
            this.panelABLine.TabIndex = 441;
            // 
            // btnCancel_APlus
            // 
            this.btnCancel_APlus.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel_APlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel_APlus.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel_APlus.FlatAppearance.BorderSize = 0;
            this.btnCancel_APlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel_APlus.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel_APlus.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel_APlus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel_APlus.Location = new System.Drawing.Point(8, 232);
            this.btnCancel_APlus.Name = "btnCancel_APlus";
            this.btnCancel_APlus.Size = new System.Drawing.Size(63, 60);
            this.btnCancel_APlus.TabIndex = 428;
            this.btnCancel_APlus.UseVisualStyleBackColor = false;
            this.btnCancel_APlus.Click += new System.EventHandler(this.btnCancelTrack_Click);
            // 
            // btnEnter_AB
            // 
            this.btnEnter_AB.BackColor = System.Drawing.Color.Transparent;
            this.btnEnter_AB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEnter_AB.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnEnter_AB.FlatAppearance.BorderSize = 0;
            this.btnEnter_AB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter_AB.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnEnter_AB.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnEnter_AB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnter_AB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEnter_AB.Location = new System.Drawing.Point(142, 232);
            this.btnEnter_AB.Name = "btnEnter_AB";
            this.btnEnter_AB.Size = new System.Drawing.Size(88, 60);
            this.btnEnter_AB.TabIndex = 427;
            this.btnEnter_AB.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEnter_AB.UseVisualStyleBackColor = false;
            // 
            // nudHeading
            // 
            this.nudHeading.BackColor = System.Drawing.Color.AliceBlue;
            this.nudHeading.DecimalPlaces = 5;
            this.nudHeading.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHeading.InterceptArrowKeys = false;
            this.nudHeading.Location = new System.Drawing.Point(17, 109);
            this.nudHeading.Maximum = new decimal(new int[] {
            817405951,
            838,
            0,
            655360});
            this.nudHeading.Name = "nudHeading";
            this.nudHeading.ReadOnly = true;
            this.nudHeading.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudHeading.Size = new System.Drawing.Size(197, 46);
            this.nudHeading.TabIndex = 413;
            this.nudHeading.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnABAPoint
            // 
            this.btnABAPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnABAPoint.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnABAPoint.FlatAppearance.BorderSize = 0;
            this.btnABAPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnABAPoint.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnABAPoint.Image = global::AgOpenGPS.Properties.Resources.LetterABlue;
            this.btnABAPoint.Location = new System.Drawing.Point(13, 5);
            this.btnABAPoint.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnABAPoint.Name = "btnABAPoint";
            this.btnABAPoint.Size = new System.Drawing.Size(80, 78);
            this.btnABAPoint.TabIndex = 57;
            this.btnABAPoint.UseVisualStyleBackColor = true;
            this.btnABAPoint.Click += new System.EventHandler(this.btnABAPoint_Click);
            // 
            // btnABBPoint
            // 
            this.btnABBPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnABBPoint.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnABBPoint.FlatAppearance.BorderSize = 0;
            this.btnABBPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnABBPoint.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnABBPoint.Image = global::AgOpenGPS.Properties.Resources.LetterBBlue;
            this.btnABBPoint.Location = new System.Drawing.Point(156, 5);
            this.btnABBPoint.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnABBPoint.Name = "btnABBPoint";
            this.btnABBPoint.Size = new System.Drawing.Size(80, 78);
            this.btnABBPoint.TabIndex = 58;
            this.btnABBPoint.UseVisualStyleBackColor = true;
            this.btnABBPoint.Click += new System.EventHandler(this.btnABBPoint_Click);
            // 
            // FormABCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1751, 818);
            this.ControlBox = false;
            this.Controls.Add(this.panelABLine);
            this.Controls.Add(this.panelChoose);
            this.Controls.Add(this.panelKML);
            this.Controls.Add(this.panelEditName);
            this.Controls.Add(this.panelABCurve);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormABCurve_FormClosing);
            this.Load += new System.EventHandler(this.FormABCurve_Load);
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            this.panelPick.ResumeLayout(false);
            this.panelABCurve.ResumeLayout(false);
            this.panelABCurve.PerformLayout();
            this.panelEditName.ResumeLayout(false);
            this.panelEditName.PerformLayout();
            this.panelKML.ResumeLayout(false);
            this.panelKML.PerformLayout();
            this.panelChoose.ResumeLayout(false);
            this.panelABLine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudHeading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBPoint;
        private System.Windows.Forms.Button btnAPoint;
        private System.Windows.Forms.Label lblCurveExists;
        private System.Windows.Forms.Button btnPausePlay;
        private System.Windows.Forms.Button btnListDelete;
        private System.Windows.Forms.Button btnListUse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChooseTrackMethod;
        private System.Windows.Forms.Button btnCancelMain;
        private System.Windows.Forms.Button btnCancelCurve;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddTime;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel_Name;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panelPick;
        private System.Windows.Forms.Panel panelABCurve;
        private System.Windows.Forms.Button btnEditName;
        private System.Windows.Forms.Button btnDuplicate;
        private System.Windows.Forms.Panel panelEditName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddTimeEdit;
        private System.Windows.Forms.Button btnSaveEditName;
        private System.Windows.Forms.Button btnCancelEditName;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnSwapAB;
        private System.Windows.Forms.Panel panelKML;
        private System.Windows.Forms.Button btnCancelKML;
        private System.Windows.Forms.FlowLayoutPanel flp;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDn;
        private System.Windows.Forms.Panel panelChoose;
        private System.Windows.Forms.Button button1btnCancelChoose;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnzLatLonPlusHeading;
        private System.Windows.Forms.Button btnzLatLon;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnzABLine;
        private System.Windows.Forms.Button btnzABCurve;
        private System.Windows.Forms.Button btnzNewLoadFromKMLCurve;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panelABLine;
        private System.Windows.Forms.Button btnCancel_APlus;
        private System.Windows.Forms.Button btnEnter_AB;
        private System.Windows.Forms.NumericUpDown nudHeading;
        private System.Windows.Forms.Button btnABAPoint;
        private System.Windows.Forms.Button btnABBPoint;
    }
}
