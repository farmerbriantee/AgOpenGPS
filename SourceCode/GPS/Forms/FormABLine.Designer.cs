namespace AgOpenGPS
{
    partial class FormABLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormABLine));
            this.lblABHeading = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblFixHeading = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDnABHeading = new System.Windows.Forms.Button();
            this.lblKeepGoing = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudBasedOnPass = new System.Windows.Forms.NumericUpDown();
            this.nudTramRepeats = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDnABHeadingBy1 = new System.Windows.Forms.Button();
            this.btnUpABHeadingBy1 = new System.Windows.Forms.Button();
            this.btnUpABHeading = new System.Windows.Forms.Button();
            this.btnDeleteAB = new System.Windows.Forms.Button();
            this.btnBPoint = new System.Windows.Forms.Button();
            this.btnAPoint = new System.Windows.Forms.Button();
            this.btnABLineOk = new System.Windows.Forms.Button();
            this.btnRightAPointBy1 = new System.Windows.Forms.Button();
            this.btnLeftAPointBy1 = new System.Windows.Forms.Button();
            this.nudShiftCm = new System.Windows.Forms.NumericUpDown();
            this.lbl_shiftCM = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudBasedOnPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTramRepeats)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShiftCm)).BeginInit();
            this.SuspendLayout();
            // 
            // lblABHeading
            // 
            this.lblABHeading.AutoSize = true;
            this.lblABHeading.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblABHeading.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblABHeading.Location = new System.Drawing.Point(32, 104);
            this.lblABHeading.Name = "lblABHeading";
            this.lblABHeading.Size = new System.Drawing.Size(121, 38);
            this.lblABHeading.TabIndex = 63;
            this.lblABHeading.Text = "000.0";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblFixHeading
            // 
            this.lblFixHeading.AutoSize = true;
            this.lblFixHeading.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixHeading.Location = new System.Drawing.Point(93, 241);
            this.lblFixHeading.Name = "lblFixHeading";
            this.lblFixHeading.Size = new System.Drawing.Size(29, 32);
            this.lblFixHeading.TabIndex = 64;
            this.lblFixHeading.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 65;
            this.label1.Text = "Heading";
            // 
            // btnDnABHeading
            // 
            this.btnDnABHeading.Enabled = false;
            this.btnDnABHeading.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDnABHeading.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDnABHeading.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnDnABHeading.Location = new System.Drawing.Point(101, 165);
            this.btnDnABHeading.Name = "btnDnABHeading";
            this.btnDnABHeading.Size = new System.Drawing.Size(74, 69);
            this.btnDnABHeading.TabIndex = 70;
            this.btnDnABHeading.Text = "0.1";
            this.btnDnABHeading.UseVisualStyleBackColor = true;
            this.btnDnABHeading.Click += new System.EventHandler(this.btnDownABHeading_Click);
            // 
            // lblKeepGoing
            // 
            this.lblKeepGoing.AutoSize = true;
            this.lblKeepGoing.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeepGoing.Location = new System.Drawing.Point(349, 109);
            this.lblKeepGoing.Name = "lblKeepGoing";
            this.lblKeepGoing.Size = new System.Drawing.Size(23, 25);
            this.lblKeepGoing.TabIndex = 74;
            this.lblKeepGoing.Text = "?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 76;
            this.label2.Text = "Repeats Every";
            // 
            // nudBasedOnPass
            // 
            this.nudBasedOnPass.BackColor = System.Drawing.Color.MediumOrchid;
            this.nudBasedOnPass.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBasedOnPass.Location = new System.Drawing.Point(27, 161);
            this.nudBasedOnPass.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudBasedOnPass.Name = "nudBasedOnPass";
            this.nudBasedOnPass.Size = new System.Drawing.Size(98, 50);
            this.nudBasedOnPass.TabIndex = 77;
            this.nudBasedOnPass.ValueChanged += new System.EventHandler(this.nudBasedOnPass_ValueChanged);
            // 
            // nudTramRepeats
            // 
            this.nudTramRepeats.BackColor = System.Drawing.Color.Lime;
            this.nudTramRepeats.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTramRepeats.Location = new System.Drawing.Point(27, 71);
            this.nudTramRepeats.Name = "nudTramRepeats";
            this.nudTramRepeats.Size = new System.Drawing.Size(98, 50);
            this.nudTramRepeats.TabIndex = 75;
            this.nudTramRepeats.ValueChanged += new System.EventHandler(this.nudTramRepeats_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 78;
            this.label3.Text = "Starting at Pass#";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudTramRepeats);
            this.groupBox1.Controls.Add(this.nudBasedOnPass);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(185, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 219);
            this.groupBox1.TabIndex = 80;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tramline - Set to 0 to disable";
            // 
            // btnDnABHeadingBy1
            // 
            this.btnDnABHeadingBy1.Enabled = false;
            this.btnDnABHeadingBy1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDnABHeadingBy1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDnABHeadingBy1.Image = ((System.Drawing.Image)(resources.GetObject("btnDnABHeadingBy1.Image")));
            this.btnDnABHeadingBy1.Location = new System.Drawing.Point(5, 165);
            this.btnDnABHeadingBy1.Name = "btnDnABHeadingBy1";
            this.btnDnABHeadingBy1.Size = new System.Drawing.Size(74, 69);
            this.btnDnABHeadingBy1.TabIndex = 73;
            this.btnDnABHeadingBy1.Text = "1";
            this.btnDnABHeadingBy1.UseVisualStyleBackColor = true;
            this.btnDnABHeadingBy1.Click += new System.EventHandler(this.btnDnABHeadingBy1_Click);
            // 
            // btnUpABHeadingBy1
            // 
            this.btnUpABHeadingBy1.Enabled = false;
            this.btnUpABHeadingBy1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpABHeadingBy1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpABHeadingBy1.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnUpABHeadingBy1.Location = new System.Drawing.Point(5, 12);
            this.btnUpABHeadingBy1.Name = "btnUpABHeadingBy1";
            this.btnUpABHeadingBy1.Size = new System.Drawing.Size(74, 69);
            this.btnUpABHeadingBy1.TabIndex = 72;
            this.btnUpABHeadingBy1.Text = "1";
            this.btnUpABHeadingBy1.UseVisualStyleBackColor = true;
            this.btnUpABHeadingBy1.Click += new System.EventHandler(this.btnUpABHeadingBy1_Click);
            // 
            // btnUpABHeading
            // 
            this.btnUpABHeading.Enabled = false;
            this.btnUpABHeading.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpABHeading.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpABHeading.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnUpABHeading.Location = new System.Drawing.Point(101, 12);
            this.btnUpABHeading.Name = "btnUpABHeading";
            this.btnUpABHeading.Size = new System.Drawing.Size(74, 69);
            this.btnUpABHeading.TabIndex = 69;
            this.btnUpABHeading.Text = "0.1";
            this.btnUpABHeading.UseVisualStyleBackColor = true;
            this.btnUpABHeading.Click += new System.EventHandler(this.btnUpABHeading_Click);
            // 
            // btnDeleteAB
            // 
            this.btnDeleteAB.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteAB.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnDeleteAB.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteAB.Location = new System.Drawing.Point(12, 320);
            this.btnDeleteAB.Name = "btnDeleteAB";
            this.btnDeleteAB.Size = new System.Drawing.Size(86, 87);
            this.btnDeleteAB.TabIndex = 0;
            this.btnDeleteAB.Text = "Delete";
            this.btnDeleteAB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteAB.Click += new System.EventHandler(this.btnDeleteAB_Click);
            // 
            // btnBPoint
            // 
            this.btnBPoint.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBPoint.Image = global::AgOpenGPS.Properties.Resources.LetterBBlue;
            this.btnBPoint.Location = new System.Drawing.Point(354, 138);
            this.btnBPoint.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnBPoint.Name = "btnBPoint";
            this.btnBPoint.Size = new System.Drawing.Size(90, 93);
            this.btnBPoint.TabIndex = 58;
            this.btnBPoint.UseVisualStyleBackColor = true;
            this.btnBPoint.Click += new System.EventHandler(this.btnBPoint_Click);
            // 
            // btnAPoint
            // 
            this.btnAPoint.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAPoint.Image = global::AgOpenGPS.Properties.Resources.LetterABlue;
            this.btnAPoint.Location = new System.Drawing.Point(354, 15);
            this.btnAPoint.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAPoint.Name = "btnAPoint";
            this.btnAPoint.Size = new System.Drawing.Size(90, 93);
            this.btnAPoint.TabIndex = 57;
            this.btnAPoint.UseVisualStyleBackColor = true;
            this.btnAPoint.Click += new System.EventHandler(this.btnAPoint_Click);
            // 
            // btnABLineOk
            // 
            this.btnABLineOk.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnABLineOk.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnABLineOk.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnABLineOk.Location = new System.Drawing.Point(303, 320);
            this.btnABLineOk.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnABLineOk.Name = "btnABLineOk";
            this.btnABLineOk.Size = new System.Drawing.Size(141, 87);
            this.btnABLineOk.TabIndex = 62;
            this.btnABLineOk.Text = "Save";
            this.btnABLineOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnABLineOk.UseVisualStyleBackColor = true;
            this.btnABLineOk.Click += new System.EventHandler(this.btnABLineOk_Click);
            // 
            // btnRightAPointBy1
            // 
            this.btnRightAPointBy1.Enabled = false;
            this.btnRightAPointBy1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightAPointBy1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRightAPointBy1.Image = global::AgOpenGPS.Properties.Resources.ArrowRight;
            this.btnRightAPointBy1.Location = new System.Drawing.Point(370, 241);
            this.btnRightAPointBy1.Name = "btnRightAPointBy1";
            this.btnRightAPointBy1.Size = new System.Drawing.Size(74, 69);
            this.btnRightAPointBy1.TabIndex = 81;
            this.btnRightAPointBy1.Text = "right";
            this.btnRightAPointBy1.UseVisualStyleBackColor = true;
            this.btnRightAPointBy1.Click += new System.EventHandler(this.btnRightAPointBy1_Click);
            // 
            // btnLeftAPointBy1
            // 
            this.btnLeftAPointBy1.Enabled = false;
            this.btnLeftAPointBy1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAPointBy1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLeftAPointBy1.Image = global::AgOpenGPS.Properties.Resources.ArrowLeft;
            this.btnLeftAPointBy1.Location = new System.Drawing.Point(186, 241);
            this.btnLeftAPointBy1.Name = "btnLeftAPointBy1";
            this.btnLeftAPointBy1.Size = new System.Drawing.Size(74, 69);
            this.btnLeftAPointBy1.TabIndex = 82;
            this.btnLeftAPointBy1.Text = "left";
            this.btnLeftAPointBy1.UseVisualStyleBackColor = true;
            this.btnLeftAPointBy1.Click += new System.EventHandler(this.btnLeftAPointBy1_Click);
            // 
            // nudShiftCm
            // 
            this.nudShiftCm.BackColor = System.Drawing.Color.DarkOrange;
            this.nudShiftCm.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudShiftCm.Location = new System.Drawing.Point(266, 260);
            this.nudShiftCm.Name = "nudShiftCm";
            this.nudShiftCm.Size = new System.Drawing.Size(98, 50);
            this.nudShiftCm.TabIndex = 79;
            // 
            // lbl_shiftCM
            // 
            this.lbl_shiftCM.AutoSize = true;
            this.lbl_shiftCM.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_shiftCM.Location = new System.Drawing.Point(262, 237);
            this.lbl_shiftCM.Name = "lbl_shiftCM";
            this.lbl_shiftCM.Size = new System.Drawing.Size(90, 20);
            this.lbl_shiftCM.TabIndex = 80;
            this.lbl_shiftCM.Text = "Shift by x cm";
            // 
            // FormABLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(449, 412);
            this.ControlBox = false;
            this.Controls.Add(this.nudShiftCm);
            this.Controls.Add(this.btnLeftAPointBy1);
            this.Controls.Add(this.lbl_shiftCM);
            this.Controls.Add(this.btnRightAPointBy1);
            this.Controls.Add(this.lblKeepGoing);
            this.Controls.Add(this.btnDnABHeadingBy1);
            this.Controls.Add(this.btnUpABHeadingBy1);
            this.Controls.Add(this.btnDnABHeading);
            this.Controls.Add(this.btnUpABHeading);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFixHeading);
            this.Controls.Add(this.lblABHeading);
            this.Controls.Add(this.btnDeleteAB);
            this.Controls.Add(this.btnBPoint);
            this.Controls.Add(this.btnAPoint);
            this.Controls.Add(this.btnABLineOk);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormABLine";
            this.ShowIcon = false;
            this.Text = "AB Line";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormABLine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudBasedOnPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTramRepeats)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShiftCm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteAB;
        private System.Windows.Forms.Button btnBPoint;
        private System.Windows.Forms.Button btnAPoint;
        private System.Windows.Forms.Button btnABLineOk;
        private System.Windows.Forms.Label lblABHeading;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblFixHeading;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpABHeading;
        private System.Windows.Forms.Button btnDnABHeading;
        private System.Windows.Forms.Button btnDnABHeadingBy1;
        private System.Windows.Forms.Button btnUpABHeadingBy1;
        private System.Windows.Forms.Label lblKeepGoing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudBasedOnPass;
        private System.Windows.Forms.NumericUpDown nudTramRepeats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRightAPointBy1;
        private System.Windows.Forms.Button btnLeftAPointBy1;
        private System.Windows.Forms.NumericUpDown nudShiftCm;
        private System.Windows.Forms.Label lbl_shiftCM;
    }
}