namespace AgOpenGPS
{
    partial class FormJob
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
            this.btnJobOpen = new System.Windows.Forms.Button();
            this.btnJobNew = new System.Windows.Forms.Button();
            this.btnDeleteAB = new System.Windows.Forms.Button();
            this.btnJobResume = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lvLines = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblChoose = new System.Windows.Forms.Label();
            this.btnOpenExistingLv = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnJobOpen
            // 
            this.btnJobOpen.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.btnJobOpen.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.btnJobOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobOpen.Location = new System.Drawing.Point(45, 369);
            this.btnJobOpen.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobOpen.Name = "btnJobOpen";
            this.btnJobOpen.Size = new System.Drawing.Size(305, 99);
            this.btnJobOpen.TabIndex = 3;
            this.btnJobOpen.Text = "Open";
            this.btnJobOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobOpen.UseVisualStyleBackColor = true;
            this.btnJobOpen.Click += new System.EventHandler(this.btnJobOpen_Click);
            // 
            // btnJobNew
            // 
            this.btnJobNew.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.btnJobNew.Image = global::AgOpenGPS.Properties.Resources.FileNew;
            this.btnJobNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobNew.Location = new System.Drawing.Point(45, 242);
            this.btnJobNew.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobNew.Name = "btnJobNew";
            this.btnJobNew.Size = new System.Drawing.Size(305, 99);
            this.btnJobNew.TabIndex = 2;
            this.btnJobNew.Text = "New";
            this.btnJobNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobNew.UseVisualStyleBackColor = true;
            this.btnJobNew.Click += new System.EventHandler(this.btnJobNew_Click);
            // 
            // btnDeleteAB
            // 
            this.btnDeleteAB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeleteAB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeleteAB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteAB.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnDeleteAB.Location = new System.Drawing.Point(95, 504);
            this.btnDeleteAB.Name = "btnDeleteAB";
            this.btnDeleteAB.Size = new System.Drawing.Size(189, 85);
            this.btnDeleteAB.TabIndex = 4;
            this.btnDeleteAB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnJobResume
            // 
            this.btnJobResume.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.btnJobResume.Image = global::AgOpenGPS.Properties.Resources.FilePrevious;
            this.btnJobResume.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnJobResume.Location = new System.Drawing.Point(45, 116);
            this.btnJobResume.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJobResume.Name = "btnJobResume";
            this.btnJobResume.Size = new System.Drawing.Size(305, 99);
            this.btnJobResume.TabIndex = 1;
            this.btnJobResume.Text = "Resume";
            this.btnJobResume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJobResume.UseVisualStyleBackColor = true;
            this.btnJobResume.Click += new System.EventHandler(this.btnJobResume_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Underline);
            this.label1.Location = new System.Drawing.Point(125, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Last Field Used:";
            // 
            // lvLines
            // 
            this.lvLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLines.BackColor = System.Drawing.SystemColors.Window;
            this.lvLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName});
            this.lvLines.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLines.FullRowSelect = true;
            this.lvLines.GridLines = true;
            this.lvLines.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvLines.HideSelection = false;
            this.lvLines.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.lvLines.Location = new System.Drawing.Point(12, 84);
            this.lvLines.MultiSelect = false;
            this.lvLines.Name = "lvLines";
            this.lvLines.Size = new System.Drawing.Size(869, 396);
            this.lvLines.TabIndex = 85;
            this.lvLines.UseCompatibleStateImageBehavior = false;
            this.lvLines.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Field Name";
            this.chName.Width = 860;
            // 
            // lblChoose
            // 
            this.lblChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChoose.AutoSize = true;
            this.lblChoose.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoose.Location = new System.Drawing.Point(308, 21);
            this.lblChoose.Name = "lblChoose";
            this.lblChoose.Size = new System.Drawing.Size(230, 39);
            this.lblChoose.TabIndex = 86;
            this.lblChoose.Text = "Select a Field";
            // 
            // btnOpenExistingLv
            // 
            this.btnOpenExistingLv.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenExistingLv.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenExistingLv.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.btnOpenExistingLv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenExistingLv.Location = new System.Drawing.Point(576, 504);
            this.btnOpenExistingLv.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnOpenExistingLv.Name = "btnOpenExistingLv";
            this.btnOpenExistingLv.Size = new System.Drawing.Size(305, 85);
            this.btnOpenExistingLv.TabIndex = 87;
            this.btnOpenExistingLv.Text = "Use Selected";
            this.btnOpenExistingLv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenExistingLv.UseVisualStyleBackColor = false;
            this.btnOpenExistingLv.Click += new System.EventHandler(this.BtnOpenExistingLv_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 39);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(332, 56);
            this.textBox1.TabIndex = 88;
            // 
            // FormJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(893, 601);
            this.ControlBox = false;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnOpenExistingLv);
            this.Controls.Add(this.lblChoose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteAB);
            this.Controls.Add(this.btnJobResume);
            this.Controls.Add(this.btnJobNew);
            this.Controls.Add(this.btnJobOpen);
            this.Controls.Add(this.lvLines);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormJob";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Start a field";
            this.Load += new System.EventHandler(this.FormJob_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJobOpen;
        private System.Windows.Forms.Button btnJobNew;
        private System.Windows.Forms.Button btnJobResume;
        private System.Windows.Forms.Button btnDeleteAB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvLines;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.Label lblChoose;
        private System.Windows.Forms.Button btnOpenExistingLv;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
    }
}