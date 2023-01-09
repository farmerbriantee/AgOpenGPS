namespace AgOpenGPS
{
    partial class Form_Keys
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
            this.button1 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAutosteer = new System.Windows.Forms.Button();
            this.lblAutosteer = new System.Windows.Forms.Label();
            this.tboxKey = new System.Windows.Forms.TextBox();
            this.btnCycleLines = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFieldMenu = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNewFlag = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnManualSection = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAutoSection = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSnapToPivot = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnMoveLineLeft = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnMoveLineRight = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnVehicleSettings = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSteerWizard = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.button1.Location = new System.Drawing.Point(773, 557);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 70);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(581, 327);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(301, 92);
            this.label15.TabIndex = 127;
            this.label15.Text = "F11 -  Full Screen\r\n\r\nNumPad1 - Manual Section Toggle\r\nNumPad0 - Auto Section Tog" +
    "gle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(581, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 207);
            this.label1.TabIndex = 128;
            this.label1.Text = "L - Reset sim\r\n\r\nUp Arrow - Faster\r\nDn Arrow - Slower\r\nLeft Arrow - Left\r\nRight A" +
    "rrow - Right\r\n\r\n( . ) Period - Stop\r\n( / ) Forward Slash - Go Straight";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(580, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 129;
            this.label2.Text = "Simulator";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 25);
            this.label4.TabIndex = 131;
            this.label4.Text = "Auto Steer Toggle";
            // 
            // btnAutosteer
            // 
            this.btnAutosteer.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutosteer.Location = new System.Drawing.Point(205, 10);
            this.btnAutosteer.Name = "btnAutosteer";
            this.btnAutosteer.Size = new System.Drawing.Size(75, 41);
            this.btnAutosteer.TabIndex = 132;
            this.btnAutosteer.Text = "A";
            this.btnAutosteer.UseVisualStyleBackColor = true;
            this.btnAutosteer.Click += new System.EventHandler(this.btnEditShortcut_Click);
            // 
            // lblAutosteer
            // 
            this.lblAutosteer.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutosteer.Location = new System.Drawing.Point(339, 76);
            this.lblAutosteer.Name = "lblAutosteer";
            this.lblAutosteer.Size = new System.Drawing.Size(174, 86);
            this.lblAutosteer.TabIndex = 133;
            this.lblAutosteer.Text = "<- Press Button to Edit Shortcut";
            this.lblAutosteer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tboxKey
            // 
            this.tboxKey.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxKey.Location = new System.Drawing.Point(382, 165);
            this.tboxKey.Name = "tboxKey";
            this.tboxKey.Size = new System.Drawing.Size(87, 40);
            this.tboxKey.TabIndex = 134;
            this.tboxKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tboxKey.TextChanged += new System.EventHandler(this.tboxKey_TextChanged);
            // 
            // btnCycleLines
            // 
            this.btnCycleLines.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCycleLines.Location = new System.Drawing.Point(205, 68);
            this.btnCycleLines.Name = "btnCycleLines";
            this.btnCycleLines.Size = new System.Drawing.Size(75, 41);
            this.btnCycleLines.TabIndex = 135;
            this.btnCycleLines.Text = "C";
            this.btnCycleLines.UseVisualStyleBackColor = true;
            this.btnCycleLines.Click += new System.EventHandler(this.btnEditShortcut_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(81, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 25);
            this.label5.TabIndex = 131;
            this.label5.Text = "Cycle Lines";
            // 
            // btnFieldMenu
            // 
            this.btnFieldMenu.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFieldMenu.Location = new System.Drawing.Point(205, 126);
            this.btnFieldMenu.Name = "btnFieldMenu";
            this.btnFieldMenu.Size = new System.Drawing.Size(75, 41);
            this.btnFieldMenu.TabIndex = 137;
            this.btnFieldMenu.Text = "F";
            this.btnFieldMenu.UseVisualStyleBackColor = true;
            this.btnFieldMenu.Click += new System.EventHandler(this.btnEditShortcut_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(84, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 25);
            this.label6.TabIndex = 136;
            this.label6.Text = "Close Field";
            // 
            // btnNewFlag
            // 
            this.btnNewFlag.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewFlag.Location = new System.Drawing.Point(205, 184);
            this.btnNewFlag.Name = "btnNewFlag";
            this.btnNewFlag.Size = new System.Drawing.Size(75, 41);
            this.btnNewFlag.TabIndex = 139;
            this.btnNewFlag.Text = "G";
            this.btnNewFlag.UseVisualStyleBackColor = true;
            this.btnNewFlag.Click += new System.EventHandler(this.btnEditShortcut_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(99, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 25);
            this.label7.TabIndex = 138;
            this.label7.Text = "New Flag";
            // 
            // btnManualSection
            // 
            this.btnManualSection.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManualSection.Location = new System.Drawing.Point(205, 242);
            this.btnManualSection.Name = "btnManualSection";
            this.btnManualSection.Size = new System.Drawing.Size(75, 41);
            this.btnManualSection.TabIndex = 141;
            this.btnManualSection.Text = "M";
            this.btnManualSection.UseVisualStyleBackColor = true;
            this.btnManualSection.Click += new System.EventHandler(this.btnEditShortcut_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 25);
            this.label8.TabIndex = 140;
            this.label8.Text = "Manual Section";
            // 
            // btnAutoSection
            // 
            this.btnAutoSection.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSection.Location = new System.Drawing.Point(205, 300);
            this.btnAutoSection.Name = "btnAutoSection";
            this.btnAutoSection.Size = new System.Drawing.Size(75, 41);
            this.btnAutoSection.TabIndex = 143;
            this.btnAutoSection.Text = "N";
            this.btnAutoSection.UseVisualStyleBackColor = true;
            this.btnAutoSection.Click += new System.EventHandler(this.btnEditShortcut_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(64, 308);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 25);
            this.label9.TabIndex = 142;
            this.label9.Text = "Auto Section";
            // 
            // btnSnapToPivot
            // 
            this.btnSnapToPivot.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnapToPivot.Location = new System.Drawing.Point(205, 358);
            this.btnSnapToPivot.Name = "btnSnapToPivot";
            this.btnSnapToPivot.Size = new System.Drawing.Size(75, 41);
            this.btnSnapToPivot.TabIndex = 145;
            this.btnSnapToPivot.Text = "P";
            this.btnSnapToPivot.UseVisualStyleBackColor = true;
            this.btnSnapToPivot.Click += new System.EventHandler(this.btnEditShortcut_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(56, 366);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 25);
            this.label10.TabIndex = 144;
            this.label10.Text = "Snap to Pivot";
            // 
            // btnMoveLineLeft
            // 
            this.btnMoveLineLeft.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveLineLeft.Location = new System.Drawing.Point(205, 416);
            this.btnMoveLineLeft.Name = "btnMoveLineLeft";
            this.btnMoveLineLeft.Size = new System.Drawing.Size(75, 41);
            this.btnMoveLineLeft.TabIndex = 147;
            this.btnMoveLineLeft.Text = "T";
            this.btnMoveLineLeft.UseVisualStyleBackColor = true;
            this.btnMoveLineLeft.Click += new System.EventHandler(this.btnEditShortcut_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(44, 424);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(164, 25);
            this.label11.TabIndex = 146;
            this.label11.Text = "Move Line Left";
            // 
            // btnMoveLineRight
            // 
            this.btnMoveLineRight.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveLineRight.Location = new System.Drawing.Point(205, 474);
            this.btnMoveLineRight.Name = "btnMoveLineRight";
            this.btnMoveLineRight.Size = new System.Drawing.Size(75, 41);
            this.btnMoveLineRight.TabIndex = 149;
            this.btnMoveLineRight.Text = "Y";
            this.btnMoveLineRight.UseVisualStyleBackColor = true;
            this.btnMoveLineRight.Click += new System.EventHandler(this.btnEditShortcut_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(29, 482);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(179, 25);
            this.label12.TabIndex = 148;
            this.label12.Text = "Move Line Right";
            // 
            // btnVehicleSettings
            // 
            this.btnVehicleSettings.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehicleSettings.Location = new System.Drawing.Point(205, 533);
            this.btnVehicleSettings.Name = "btnVehicleSettings";
            this.btnVehicleSettings.Size = new System.Drawing.Size(75, 41);
            this.btnVehicleSettings.TabIndex = 151;
            this.btnVehicleSettings.Text = "V";
            this.btnVehicleSettings.UseVisualStyleBackColor = true;
            this.btnVehicleSettings.Click += new System.EventHandler(this.btnEditShortcut_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(21, 538);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(178, 25);
            this.label13.TabIndex = 150;
            this.label13.Text = "Vehicle Settings";
            // 
            // btnSteerWizard
            // 
            this.btnSteerWizard.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSteerWizard.Location = new System.Drawing.Point(205, 588);
            this.btnSteerWizard.Name = "btnSteerWizard";
            this.btnSteerWizard.Size = new System.Drawing.Size(75, 41);
            this.btnSteerWizard.TabIndex = 153;
            this.btnSteerWizard.Text = "W";
            this.btnSteerWizard.UseVisualStyleBackColor = true;
            this.btnSteerWizard.Click += new System.EventHandler(this.btnEditShortcut_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(52, 598);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 25);
            this.label14.TabIndex = 152;
            this.label14.Text = "Steer Wizard";
            // 
            // btnReset
            // 
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::AgOpenGPS.Properties.Resources.back_button;
            this.btnReset.Location = new System.Drawing.Point(382, 350);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(87, 69);
            this.btnReset.TabIndex = 154;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(389, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 25);
            this.label3.TabIndex = 155;
            this.label3.Text = "Reset";
            // 
            // Form_Keys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 639);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSteerWizard);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnVehicleSettings);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnMoveLineRight);
            this.Controls.Add(this.btnMoveLineLeft);
            this.Controls.Add(this.btnSnapToPivot);
            this.Controls.Add(this.btnAutoSection);
            this.Controls.Add(this.btnManualSection);
            this.Controls.Add(this.btnNewFlag);
            this.Controls.Add(this.btnFieldMenu);
            this.Controls.Add(this.btnCycleLines);
            this.Controls.Add(this.tboxKey);
            this.Controls.Add(this.lblAutosteer);
            this.Controls.Add(this.btnAutosteer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "Form_Keys";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shortcut Keys";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Keys_FormClosing);
            this.Load += new System.EventHandler(this.Form_Keys_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAutosteer;
        private System.Windows.Forms.Label lblAutosteer;
        private System.Windows.Forms.TextBox tboxKey;
        private System.Windows.Forms.Button btnCycleLines;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFieldMenu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNewFlag;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnManualSection;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAutoSection;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSnapToPivot;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnMoveLineLeft;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnMoveLineRight;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnVehicleSettings;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSteerWizard;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label3;
    }
}