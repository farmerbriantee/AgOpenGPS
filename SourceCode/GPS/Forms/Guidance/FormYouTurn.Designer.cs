namespace AgOpenGPS
{
    partial class FormYouTurn
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDistanceDn = new ProXoft.WinForms.RepeatButton();
            this.btnDistanceUp = new ProXoft.WinForms.RepeatButton();
            this.lblDistance = new System.Windows.Forms.Label();
            this.lblWhenTrig = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.btnTriggerDistanceDn = new ProXoft.WinForms.RepeatButton();
            this.btnTriggerDistanceUp = new ProXoft.WinForms.RepeatButton();
            this.lblTriggerDistance = new System.Windows.Forms.Label();
            this.tabYouTurn = new System.Windows.Forms.TabPage();
            this.btnGeoFenceDistanceDn = new ProXoft.WinForms.RepeatButton();
            this.btnGeoFenceDistanceUp = new ProXoft.WinForms.RepeatButton();
            this.label49 = new System.Windows.Forms.Label();
            this.lblGeoFenceDistance = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.cboxRowWidth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIsUsingDubins = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnYouTurnWideReturn = new System.Windows.Forms.Button();
            this.btnYouTurnKeyHole = new System.Windows.Forms.Button();
            this.btnYouTurnSemiCircle = new System.Windows.Forms.Button();
            this.btnYouTurnRecord = new System.Windows.Forms.Button();
            this.btnYouTurnCustom = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabYouTurn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.Location = new System.Drawing.Point(910, 439);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 111);
            this.btnCancel.TabIndex = 130;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnOK.Location = new System.Drawing.Point(910, 577);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 109);
            this.btnOK.TabIndex = 129;
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDistanceDn
            // 
            this.btnDistanceDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDistanceDn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistanceDn.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnDistanceDn.Location = new System.Drawing.Point(681, 512);
            this.btnDistanceDn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDistanceDn.Name = "btnDistanceDn";
            this.btnDistanceDn.Size = new System.Drawing.Size(59, 69);
            this.btnDistanceDn.TabIndex = 145;
            this.btnDistanceDn.UseVisualStyleBackColor = true;
            this.btnDistanceDn.Click += new System.EventHandler(this.btnDistanceDn_Click);
            // 
            // btnDistanceUp
            // 
            this.btnDistanceUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDistanceUp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistanceUp.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnDistanceUp.Location = new System.Drawing.Point(774, 512);
            this.btnDistanceUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDistanceUp.Name = "btnDistanceUp";
            this.btnDistanceUp.Size = new System.Drawing.Size(59, 69);
            this.btnDistanceUp.TabIndex = 146;
            this.btnDistanceUp.UseVisualStyleBackColor = true;
            this.btnDistanceUp.Click += new System.EventHandler(this.btnDistanceUp_Click);
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.BackColor = System.Drawing.SystemColors.Control;
            this.lblDistance.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistance.Location = new System.Drawing.Point(710, 456);
            this.lblDistance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(95, 45);
            this.lblDistance.TabIndex = 144;
            this.lblDistance.Text = "XXX";
            // 
            // lblWhenTrig
            // 
            this.lblWhenTrig.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhenTrig.Location = new System.Drawing.Point(642, 372);
            this.lblWhenTrig.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWhenTrig.Name = "lblWhenTrig";
            this.lblWhenTrig.Size = new System.Drawing.Size(229, 68);
            this.lblWhenTrig.TabIndex = 147;
            this.lblWhenTrig.Text = "UTurn Length";
            this.lblWhenTrig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(326, 372);
            this.label48.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(229, 68);
            this.label48.TabIndex = 161;
            this.label48.Text = "UTurn Distance";
            this.label48.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnTriggerDistanceDn
            // 
            this.btnTriggerDistanceDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTriggerDistanceDn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTriggerDistanceDn.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnTriggerDistanceDn.Location = new System.Drawing.Point(369, 512);
            this.btnTriggerDistanceDn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTriggerDistanceDn.Name = "btnTriggerDistanceDn";
            this.btnTriggerDistanceDn.Size = new System.Drawing.Size(59, 69);
            this.btnTriggerDistanceDn.TabIndex = 158;
            this.btnTriggerDistanceDn.UseVisualStyleBackColor = true;
            this.btnTriggerDistanceDn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTriggerDistanceDn_MouseDown);
            // 
            // btnTriggerDistanceUp
            // 
            this.btnTriggerDistanceUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTriggerDistanceUp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTriggerDistanceUp.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnTriggerDistanceUp.Location = new System.Drawing.Point(459, 512);
            this.btnTriggerDistanceUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTriggerDistanceUp.Name = "btnTriggerDistanceUp";
            this.btnTriggerDistanceUp.Size = new System.Drawing.Size(59, 69);
            this.btnTriggerDistanceUp.TabIndex = 159;
            this.btnTriggerDistanceUp.UseVisualStyleBackColor = true;
            this.btnTriggerDistanceUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTriggerDistanceUp_MouseDown);
            // 
            // lblTriggerDistance
            // 
            this.lblTriggerDistance.AutoSize = true;
            this.lblTriggerDistance.BackColor = System.Drawing.SystemColors.Control;
            this.lblTriggerDistance.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTriggerDistance.Location = new System.Drawing.Point(394, 456);
            this.lblTriggerDistance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTriggerDistance.Name = "lblTriggerDistance";
            this.lblTriggerDistance.Size = new System.Drawing.Size(95, 45);
            this.lblTriggerDistance.TabIndex = 160;
            this.lblTriggerDistance.Text = "XXX";
            // 
            // tabYouTurn
            // 
            this.tabYouTurn.BackColor = System.Drawing.Color.AliceBlue;
            this.tabYouTurn.Controls.Add(this.btnGeoFenceDistanceDn);
            this.tabYouTurn.Controls.Add(this.btnGeoFenceDistanceUp);
            this.tabYouTurn.Controls.Add(this.label49);
            this.tabYouTurn.Controls.Add(this.lblGeoFenceDistance);
            this.tabYouTurn.Controls.Add(this.btnTriggerDistanceDn);
            this.tabYouTurn.Controls.Add(this.btnTriggerDistanceUp);
            this.tabYouTurn.Controls.Add(this.label46);
            this.tabYouTurn.Controls.Add(this.label48);
            this.tabYouTurn.Controls.Add(this.btnDistanceUp);
            this.tabYouTurn.Controls.Add(this.lblTriggerDistance);
            this.tabYouTurn.Controls.Add(this.lblWhenTrig);
            this.tabYouTurn.Controls.Add(this.cboxRowWidth);
            this.tabYouTurn.Controls.Add(this.lblDistance);
            this.tabYouTurn.Controls.Add(this.label1);
            this.tabYouTurn.Controls.Add(this.btnIsUsingDubins);
            this.tabYouTurn.Controls.Add(this.btnDistanceDn);
            this.tabYouTurn.Controls.Add(this.groupBox1);
            this.tabYouTurn.Location = new System.Drawing.Point(4, 64);
            this.tabYouTurn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabYouTurn.Name = "tabYouTurn";
            this.tabYouTurn.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabYouTurn.Size = new System.Drawing.Size(894, 615);
            this.tabYouTurn.TabIndex = 0;
            this.tabYouTurn.Text = "U Turn";
            // 
            // btnGeoFenceDistanceDn
            // 
            this.btnGeoFenceDistanceDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGeoFenceDistanceDn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeoFenceDistanceDn.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnGeoFenceDistanceDn.Location = new System.Drawing.Point(49, 512);
            this.btnGeoFenceDistanceDn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGeoFenceDistanceDn.Name = "btnGeoFenceDistanceDn";
            this.btnGeoFenceDistanceDn.Size = new System.Drawing.Size(59, 69);
            this.btnGeoFenceDistanceDn.TabIndex = 163;
            this.btnGeoFenceDistanceDn.UseVisualStyleBackColor = true;
            this.btnGeoFenceDistanceDn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnGeoFenceDistanceDn_MouseDown);
            // 
            // btnGeoFenceDistanceUp
            // 
            this.btnGeoFenceDistanceUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGeoFenceDistanceUp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeoFenceDistanceUp.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnGeoFenceDistanceUp.Location = new System.Drawing.Point(136, 512);
            this.btnGeoFenceDistanceUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGeoFenceDistanceUp.Name = "btnGeoFenceDistanceUp";
            this.btnGeoFenceDistanceUp.Size = new System.Drawing.Size(59, 69);
            this.btnGeoFenceDistanceUp.TabIndex = 164;
            this.btnGeoFenceDistanceUp.UseVisualStyleBackColor = true;
            this.btnGeoFenceDistanceUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnGeoFenceDistanceUp_MouseDown);
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(5, 372);
            this.label49.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(240, 68);
            this.label49.TabIndex = 166;
            this.label49.Text = "GeoFence Distance";
            this.label49.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblGeoFenceDistance
            // 
            this.lblGeoFenceDistance.AutoSize = true;
            this.lblGeoFenceDistance.BackColor = System.Drawing.SystemColors.Control;
            this.lblGeoFenceDistance.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeoFenceDistance.Location = new System.Drawing.Point(78, 456);
            this.lblGeoFenceDistance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGeoFenceDistance.Name = "lblGeoFenceDistance";
            this.lblGeoFenceDistance.Size = new System.Drawing.Size(95, 45);
            this.lblGeoFenceDistance.TabIndex = 165;
            this.lblGeoFenceDistance.Text = "XXX";
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(199, 260);
            this.label46.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(132, 75);
            this.label46.TabIndex = 157;
            this.label46.Text = "Dubins/\r\nPattern";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboxRowWidth
            // 
            this.cboxRowWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxRowWidth.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxRowWidth.FormattingEnabled = true;
            this.cboxRowWidth.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cboxRowWidth.Location = new System.Drawing.Point(484, 264);
            this.cboxRowWidth.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxRowWidth.Name = "cboxRowWidth";
            this.cboxRowWidth.Size = new System.Drawing.Size(52, 47);
            this.cboxRowWidth.TabIndex = 65;
            this.cboxRowWidth.SelectedIndexChanged += new System.EventHandler(this.cboxRowWidth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(540, 255);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 65);
            this.label1.TabIndex = 11;
            this.label1.Text = "Skips";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnIsUsingDubins
            // 
            this.btnIsUsingDubins.BackColor = System.Drawing.Color.PaleGreen;
            this.btnIsUsingDubins.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIsUsingDubins.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIsUsingDubins.Location = new System.Drawing.Point(104, 255);
            this.btnIsUsingDubins.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnIsUsingDubins.Name = "btnIsUsingDubins";
            this.btnIsUsingDubins.Size = new System.Drawing.Size(91, 84);
            this.btnIsUsingDubins.TabIndex = 131;
            this.btnIsUsingDubins.Text = "Dubins";
            this.btnIsUsingDubins.UseVisualStyleBackColor = false;
            this.btnIsUsingDubins.Click += new System.EventHandler(this.btnIsUsingDubins_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnYouTurnWideReturn);
            this.groupBox1.Controls.Add(this.btnYouTurnKeyHole);
            this.groupBox1.Controls.Add(this.btnYouTurnSemiCircle);
            this.groupBox1.Controls.Add(this.btnYouTurnRecord);
            this.groupBox1.Controls.Add(this.btnYouTurnCustom);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(164, 30);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(576, 140);
            this.groupBox1.TabIndex = 133;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Turn Patterns";
            // 
            // btnYouTurnWideReturn
            // 
            this.btnYouTurnWideReturn.BackColor = System.Drawing.Color.Silver;
            this.btnYouTurnWideReturn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYouTurnWideReturn.Image = global::AgOpenGPS.Properties.Resources.WideReturn;
            this.btnYouTurnWideReturn.Location = new System.Drawing.Point(246, 39);
            this.btnYouTurnWideReturn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnYouTurnWideReturn.Name = "btnYouTurnWideReturn";
            this.btnYouTurnWideReturn.Size = new System.Drawing.Size(83, 84);
            this.btnYouTurnWideReturn.TabIndex = 149;
            this.btnYouTurnWideReturn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnYouTurnWideReturn.UseVisualStyleBackColor = false;
            this.btnYouTurnWideReturn.Click += new System.EventHandler(this.btnYouTurnWideReturn_Click);
            // 
            // btnYouTurnKeyHole
            // 
            this.btnYouTurnKeyHole.BackColor = System.Drawing.Color.Silver;
            this.btnYouTurnKeyHole.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYouTurnKeyHole.Image = global::AgOpenGPS.Properties.Resources.KeyHole;
            this.btnYouTurnKeyHole.Location = new System.Drawing.Point(10, 40);
            this.btnYouTurnKeyHole.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnYouTurnKeyHole.Name = "btnYouTurnKeyHole";
            this.btnYouTurnKeyHole.Size = new System.Drawing.Size(83, 84);
            this.btnYouTurnKeyHole.TabIndex = 7;
            this.btnYouTurnKeyHole.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnYouTurnKeyHole.UseVisualStyleBackColor = false;
            this.btnYouTurnKeyHole.Click += new System.EventHandler(this.btnYouTurnKeyHole_Click);
            // 
            // btnYouTurnSemiCircle
            // 
            this.btnYouTurnSemiCircle.BackColor = System.Drawing.Color.Silver;
            this.btnYouTurnSemiCircle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYouTurnSemiCircle.Image = global::AgOpenGPS.Properties.Resources.SemiCircle;
            this.btnYouTurnSemiCircle.Location = new System.Drawing.Point(128, 39);
            this.btnYouTurnSemiCircle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnYouTurnSemiCircle.Name = "btnYouTurnSemiCircle";
            this.btnYouTurnSemiCircle.Size = new System.Drawing.Size(83, 84);
            this.btnYouTurnSemiCircle.TabIndex = 9;
            this.btnYouTurnSemiCircle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnYouTurnSemiCircle.UseVisualStyleBackColor = false;
            this.btnYouTurnSemiCircle.Click += new System.EventHandler(this.btnYouTurnSemiCircle_Click);
            // 
            // btnYouTurnRecord
            // 
            this.btnYouTurnRecord.BackColor = System.Drawing.Color.Transparent;
            this.btnYouTurnRecord.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYouTurnRecord.Image = global::AgOpenGPS.Properties.Resources.BoundaryRecord;
            this.btnYouTurnRecord.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnYouTurnRecord.Location = new System.Drawing.Point(481, 39);
            this.btnYouTurnRecord.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnYouTurnRecord.Name = "btnYouTurnRecord";
            this.btnYouTurnRecord.Size = new System.Drawing.Size(83, 84);
            this.btnYouTurnRecord.TabIndex = 10;
            this.btnYouTurnRecord.Text = "Record";
            this.btnYouTurnRecord.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnYouTurnRecord.UseVisualStyleBackColor = false;
            this.btnYouTurnRecord.Click += new System.EventHandler(this.btnYouTurnRecord_Click);
            // 
            // btnYouTurnCustom
            // 
            this.btnYouTurnCustom.BackColor = System.Drawing.Color.Silver;
            this.btnYouTurnCustom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYouTurnCustom.Image = global::AgOpenGPS.Properties.Resources.Custom;
            this.btnYouTurnCustom.Location = new System.Drawing.Point(381, 39);
            this.btnYouTurnCustom.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnYouTurnCustom.Name = "btnYouTurnCustom";
            this.btnYouTurnCustom.Size = new System.Drawing.Size(83, 84);
            this.btnYouTurnCustom.TabIndex = 8;
            this.btnYouTurnCustom.Text = "Custom";
            this.btnYouTurnCustom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnYouTurnCustom.UseVisualStyleBackColor = false;
            this.btnYouTurnCustom.Click += new System.EventHandler(this.btnYouTurnCustom_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabYouTurn);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(220, 60);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(902, 683);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // FormYouTurn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 698);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FormYouTurn";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "U Turn";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormYouTurn_Load);
            this.tabYouTurn.ResumeLayout(false);
            this.tabYouTurn.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label48;
        private ProXoft.WinForms.RepeatButton btnTriggerDistanceDn;
        private ProXoft.WinForms.RepeatButton btnTriggerDistanceUp;
        private ProXoft.WinForms.RepeatButton btnDistanceDn;
        private System.Windows.Forms.Label lblTriggerDistance;
        private ProXoft.WinForms.RepeatButton btnDistanceUp;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label lblWhenTrig;
        private System.Windows.Forms.TabPage tabYouTurn;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.ComboBox cboxRowWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIsUsingDubins;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnYouTurnWideReturn;
        private System.Windows.Forms.Button btnYouTurnKeyHole;
        private System.Windows.Forms.Button btnYouTurnSemiCircle;
        private System.Windows.Forms.Button btnYouTurnRecord;
        private System.Windows.Forms.Button btnYouTurnCustom;
        private System.Windows.Forms.TabControl tabControl1;
        private ProXoft.WinForms.RepeatButton btnGeoFenceDistanceDn;
        private ProXoft.WinForms.RepeatButton btnGeoFenceDistanceUp;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label lblGeoFenceDistance;
    }
}