namespace AgOpenGPS
{
    partial class FormSelf
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
            this.oglSelf = new OpenTK.GLControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPasses = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBuildLine = new System.Windows.Forms.Label();
            this.tbox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // oglSelf
            // 
            this.oglSelf.BackColor = System.Drawing.Color.Black;
            this.oglSelf.Cursor = System.Windows.Forms.Cursors.Cross;
            this.oglSelf.Location = new System.Drawing.Point(0, 0);
            this.oglSelf.Margin = new System.Windows.Forms.Padding(0);
            this.oglSelf.Name = "oglSelf";
            this.oglSelf.Size = new System.Drawing.Size(800, 800);
            this.oglSelf.TabIndex = 183;
            this.oglSelf.VSync = false;
            this.oglSelf.Load += new System.EventHandler(this.oglSelf_Load);
            this.oglSelf.Paint += new System.Windows.Forms.PaintEventHandler(this.oglSelf_Paint);
            this.oglSelf.MouseDown += new System.Windows.Forms.MouseEventHandler(this.oglSelf_MouseDown);
            this.oglSelf.Resize += new System.EventHandler(this.oglSelf_Resize);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblX.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblX.Location = new System.Drawing.Point(833, 10);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(18, 19);
            this.lblX.TabIndex = 184;
            this.lblX.Text = "1";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblY.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblY.Location = new System.Drawing.Point(833, 38);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(18, 19);
            this.lblY.TabIndex = 185;
            this.lblY.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(803, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 19);
            this.label1.TabIndex = 187;
            this.label1.Text = "Y:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(803, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 19);
            this.label2.TabIndex = 186;
            this.label2.Text = "X:";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExit.Location = new System.Drawing.Point(977, 766);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 34);
            this.btnExit.TabIndex = 234;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(803, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 236;
            this.label3.Text = "Passes:";
            // 
            // lblPasses
            // 
            this.lblPasses.AutoSize = true;
            this.lblPasses.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblPasses.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPasses.Location = new System.Drawing.Point(863, 72);
            this.lblPasses.Name = "lblPasses";
            this.lblPasses.Size = new System.Drawing.Size(18, 19);
            this.lblPasses.TabIndex = 235;
            this.lblPasses.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(803, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 19);
            this.label4.TabIndex = 238;
            this.label4.Text = "Line:";
            // 
            // lblBuildLine
            // 
            this.lblBuildLine.AutoSize = true;
            this.lblBuildLine.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblBuildLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblBuildLine.Location = new System.Drawing.Point(863, 100);
            this.lblBuildLine.Name = "lblBuildLine";
            this.lblBuildLine.Size = new System.Drawing.Size(18, 19);
            this.lblBuildLine.TabIndex = 237;
            this.lblBuildLine.Text = "1";
            // 
            // tbox1
            // 
            this.tbox1.AcceptsReturn = true;
            this.tbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox1.Location = new System.Drawing.Point(807, 151);
            this.tbox1.Multiline = true;
            this.tbox1.Name = "tbox1";
            this.tbox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbox1.Size = new System.Drawing.Size(260, 466);
            this.tbox1.TabIndex = 239;
            this.tbox1.WordWrap = false;
            // 
            // FormSelf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 821);
            this.ControlBox = false;
            this.Controls.Add(this.tbox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblBuildLine);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPasses);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.oglSelf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSelf";
            this.Load += new System.EventHandler(this.FormSelf_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl oglSelf;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPasses;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblBuildLine;
        private System.Windows.Forms.TextBox tbox1;
    }
}