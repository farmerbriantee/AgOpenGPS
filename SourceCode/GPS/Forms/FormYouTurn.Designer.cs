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
            this.btnYouTurnRecord = new System.Windows.Forms.Button();
            this.lblDistance = new System.Windows.Forms.Label();
            this.lblWhenTrig = new System.Windows.Forms.Label();
            this.btnEnableAutoYouTurn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnYouTurnKeyHole = new System.Windows.Forms.Button();
            this.btnYouTurnSemiCircle = new System.Windows.Forms.Button();
            this.btnYouTurnCustom = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDistanceUp = new ProXoft.WinForms.RepeatButton();
            this.bntOK = new System.Windows.Forms.Button();
            this.btnDistanceDn = new ProXoft.WinForms.RepeatButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnYouTurnRecord
            // 
            this.btnYouTurnRecord.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYouTurnRecord.Location = new System.Drawing.Point(582, 73);
            this.btnYouTurnRecord.Name = "btnYouTurnRecord";
            this.btnYouTurnRecord.Size = new System.Drawing.Size(128, 83);
            this.btnYouTurnRecord.TabIndex = 10;
            this.btnYouTurnRecord.Text = "Record New Custom";
            this.btnYouTurnRecord.UseVisualStyleBackColor = true;
            this.btnYouTurnRecord.Click += new System.EventHandler(this.btnYouTurnRecord_Click);
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.BackColor = System.Drawing.SystemColors.Control;
            this.lblDistance.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistance.Location = new System.Drawing.Point(319, 42);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(83, 45);
            this.lblDistance.TabIndex = 126;
            this.lblDistance.Text = "XXX";
            // 
            // lblWhenTrig
            // 
            this.lblWhenTrig.AutoSize = true;
            this.lblWhenTrig.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhenTrig.Location = new System.Drawing.Point(417, 51);
            this.lblWhenTrig.Name = "lblWhenTrig";
            this.lblWhenTrig.Size = new System.Drawing.Size(132, 30);
            this.lblWhenTrig.TabIndex = 131;
            this.lblWhenTrig.Text = "Before After";
            // 
            // btnEnableAutoYouTurn
            // 
            this.btnEnableAutoYouTurn.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnableAutoYouTurn.Location = new System.Drawing.Point(15, 72);
            this.btnEnableAutoYouTurn.Name = "btnEnableAutoYouTurn";
            this.btnEnableAutoYouTurn.Size = new System.Drawing.Size(165, 92);
            this.btnEnableAutoYouTurn.TabIndex = 132;
            this.btnEnableAutoYouTurn.Text = "Auto YouTurn Off";
            this.btnEnableAutoYouTurn.UseVisualStyleBackColor = true;
            this.btnEnableAutoYouTurn.Click += new System.EventHandler(this.btnEnableAutoYouTurn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnYouTurnKeyHole);
            this.groupBox1.Controls.Add(this.btnYouTurnSemiCircle);
            this.groupBox1.Controls.Add(this.btnYouTurnRecord);
            this.groupBox1.Controls.Add(this.btnYouTurnCustom);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 198);
            this.groupBox1.TabIndex = 133;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Turn Shapes";
            // 
            // btnYouTurnKeyHole
            // 
            this.btnYouTurnKeyHole.BackColor = System.Drawing.Color.Yellow;
            this.btnYouTurnKeyHole.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYouTurnKeyHole.Image = global::AgOpenGPS.Properties.Resources.KeyHole;
            this.btnYouTurnKeyHole.Location = new System.Drawing.Point(15, 42);
            this.btnYouTurnKeyHole.Name = "btnYouTurnKeyHole";
            this.btnYouTurnKeyHole.Size = new System.Drawing.Size(150, 150);
            this.btnYouTurnKeyHole.TabIndex = 7;
            this.btnYouTurnKeyHole.Text = "Key Hole";
            this.btnYouTurnKeyHole.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnYouTurnKeyHole.UseVisualStyleBackColor = false;
            this.btnYouTurnKeyHole.Click += new System.EventHandler(this.btnYouTurnKeyHole_Click);
            // 
            // btnYouTurnSemiCircle
            // 
            this.btnYouTurnSemiCircle.BackColor = System.Drawing.Color.LimeGreen;
            this.btnYouTurnSemiCircle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYouTurnSemiCircle.Image = global::AgOpenGPS.Properties.Resources.SemiCircle;
            this.btnYouTurnSemiCircle.Location = new System.Drawing.Point(195, 42);
            this.btnYouTurnSemiCircle.Name = "btnYouTurnSemiCircle";
            this.btnYouTurnSemiCircle.Size = new System.Drawing.Size(150, 150);
            this.btnYouTurnSemiCircle.TabIndex = 9;
            this.btnYouTurnSemiCircle.Text = "Semi Circle";
            this.btnYouTurnSemiCircle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnYouTurnSemiCircle.UseVisualStyleBackColor = false;
            this.btnYouTurnSemiCircle.Click += new System.EventHandler(this.btnYouTurnSemiCircle_Click);
            // 
            // btnYouTurnCustom
            // 
            this.btnYouTurnCustom.BackColor = System.Drawing.Color.LimeGreen;
            this.btnYouTurnCustom.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYouTurnCustom.Image = global::AgOpenGPS.Properties.Resources.Custom;
            this.btnYouTurnCustom.Location = new System.Drawing.Point(410, 42);
            this.btnYouTurnCustom.Name = "btnYouTurnCustom";
            this.btnYouTurnCustom.Size = new System.Drawing.Size(150, 150);
            this.btnYouTurnCustom.TabIndex = 8;
            this.btnYouTurnCustom.Text = "Custom";
            this.btnYouTurnCustom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnYouTurnCustom.UseVisualStyleBackColor = false;
            this.btnYouTurnCustom.Click += new System.EventHandler(this.btnYouTurnCustom_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblWhenTrig);
            this.groupBox2.Controls.Add(this.btnEnableAutoYouTurn);
            this.groupBox2.Controls.Add(this.btnDistanceUp);
            this.groupBox2.Controls.Add(this.bntOK);
            this.groupBox2.Controls.Add(this.btnDistanceDn);
            this.groupBox2.Controls.Add(this.lblDistance);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(732, 204);
            this.groupBox2.TabIndex = 134;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auto YouTurn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 30);
            this.label1.TabIndex = 133;
            this.label1.Text = "When turn is triggered";
            // 
            // btnDistanceUp
            // 
            this.btnDistanceUp.BackgroundImage = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnDistanceUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDistanceUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistanceUp.Location = new System.Drawing.Point(271, 90);
            this.btnDistanceUp.Name = "btnDistanceUp";
            this.btnDistanceUp.Size = new System.Drawing.Size(71, 62);
            this.btnDistanceUp.TabIndex = 128;
            this.btnDistanceUp.UseVisualStyleBackColor = true;
            this.btnDistanceUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDistanceUp_MouseDown);
            // 
            // bntOK
            // 
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.Location = new System.Drawing.Point(570, 122);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(156, 72);
            this.bntOK.TabIndex = 129;
            this.bntOK.Text = "Save";
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // btnDistanceDn
            // 
            this.btnDistanceDn.BackgroundImage = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnDistanceDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDistanceDn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistanceDn.Location = new System.Drawing.Point(380, 90);
            this.btnDistanceDn.Name = "btnDistanceDn";
            this.btnDistanceDn.Size = new System.Drawing.Size(71, 62);
            this.btnDistanceDn.TabIndex = 127;
            this.btnDistanceDn.UseVisualStyleBackColor = true;
            this.btnDistanceDn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDistanceDn_MouseDown);
            // 
            // FormYouTurn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 454);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormYouTurn";
            this.Text = "You Turn";
            this.Load += new System.EventHandler(this.FormYouTurn_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnYouTurnRecord;
        private System.Windows.Forms.Button btnYouTurnSemiCircle;
        private System.Windows.Forms.Button btnYouTurnCustom;
        private System.Windows.Forms.Button btnYouTurnKeyHole;
        private ProXoft.WinForms.RepeatButton btnDistanceDn;
        private ProXoft.WinForms.RepeatButton btnDistanceUp;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.Label lblWhenTrig;
        private System.Windows.Forms.Button btnEnableAutoYouTurn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
    }
}