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
            this.lblKeepGoing = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudBasedOnPass = new System.Windows.Forms.NumericUpDown();
            this.nudTramRepeats = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDnABHeadingBy1 = new System.Windows.Forms.Button();
            this.btnUpABHeadingBy1 = new System.Windows.Forms.Button();
            this.btnDeleteAB = new System.Windows.Forms.Button();
            this.btnBPoint = new System.Windows.Forms.Button();
            this.btnAPoint = new System.Windows.Forms.Button();
            this.btnABLineOk = new System.Windows.Forms.Button();
            this.btnAddToFile = new System.Windows.Forms.Button();
            this.tboxHeading = new System.Windows.Forms.TextBox();
            this.btnDnABHeading = new System.Windows.Forms.Button();
            this.btnUpABHeading = new System.Windows.Forms.Button();
            this.lvLines = new System.Windows.Forms.ListView();
            this.chField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAngle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEasting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNorthing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnListDelete = new System.Windows.Forms.Button();
            this.btnListUse = new System.Windows.Forms.Button();
            this.btnPlus90 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudBasedOnPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTramRepeats)).BeginInit();
            this.SuspendLayout();
            // 
            // lblABHeading
            // 
            resources.ApplyResources(this.lblABHeading, "lblABHeading");
            this.lblABHeading.BackColor = System.Drawing.SystemColors.Control;
            this.lblABHeading.Name = "lblABHeading";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblFixHeading
            // 
            resources.ApplyResources(this.lblFixHeading, "lblFixHeading");
            this.lblFixHeading.Name = "lblFixHeading";
            // 
            // lblKeepGoing
            // 
            resources.ApplyResources(this.lblKeepGoing, "lblKeepGoing");
            this.lblKeepGoing.Name = "lblKeepGoing";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // nudBasedOnPass
            // 
            resources.ApplyResources(this.nudBasedOnPass, "nudBasedOnPass");
            this.nudBasedOnPass.BackColor = System.Drawing.Color.MediumOrchid;
            this.nudBasedOnPass.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudBasedOnPass.Name = "nudBasedOnPass";
            this.nudBasedOnPass.ValueChanged += new System.EventHandler(this.nudBasedOnPass_ValueChanged);
            // 
            // nudTramRepeats
            // 
            resources.ApplyResources(this.nudTramRepeats, "nudTramRepeats");
            this.nudTramRepeats.BackColor = System.Drawing.Color.Lime;
            this.nudTramRepeats.Name = "nudTramRepeats";
            this.nudTramRepeats.ValueChanged += new System.EventHandler(this.nudTramRepeats_ValueChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // btnDnABHeadingBy1
            // 
            resources.ApplyResources(this.btnDnABHeadingBy1, "btnDnABHeadingBy1");
            this.btnDnABHeadingBy1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDnABHeadingBy1.Name = "btnDnABHeadingBy1";
            this.btnDnABHeadingBy1.UseVisualStyleBackColor = true;
            this.btnDnABHeadingBy1.Click += new System.EventHandler(this.btnDnABHeadingBy1_Click);
            // 
            // btnUpABHeadingBy1
            // 
            resources.ApplyResources(this.btnUpABHeadingBy1, "btnUpABHeadingBy1");
            this.btnUpABHeadingBy1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpABHeadingBy1.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnUpABHeadingBy1.Name = "btnUpABHeadingBy1";
            this.btnUpABHeadingBy1.UseVisualStyleBackColor = true;
            this.btnUpABHeadingBy1.Click += new System.EventHandler(this.btnUpABHeadingBy1_Click);
            // 
            // btnDeleteAB
            // 
            resources.ApplyResources(this.btnDeleteAB, "btnDeleteAB");
            this.btnDeleteAB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteAB.Image = global::AgOpenGPS.Properties.Resources.back_button;
            this.btnDeleteAB.Name = "btnDeleteAB";
            this.btnDeleteAB.Click += new System.EventHandler(this.btnDeleteAB_Click);
            // 
            // btnBPoint
            // 
            resources.ApplyResources(this.btnBPoint, "btnBPoint");
            this.btnBPoint.Image = global::AgOpenGPS.Properties.Resources.LetterBBlue;
            this.btnBPoint.Name = "btnBPoint";
            this.btnBPoint.UseVisualStyleBackColor = true;
            this.btnBPoint.Click += new System.EventHandler(this.btnBPoint_Click);
            // 
            // btnAPoint
            // 
            resources.ApplyResources(this.btnAPoint, "btnAPoint");
            this.btnAPoint.Image = global::AgOpenGPS.Properties.Resources.LetterABlue;
            this.btnAPoint.Name = "btnAPoint";
            this.btnAPoint.UseVisualStyleBackColor = true;
            this.btnAPoint.Click += new System.EventHandler(this.btnAPoint_Click);
            // 
            // btnABLineOk
            // 
            resources.ApplyResources(this.btnABLineOk, "btnABLineOk");
            this.btnABLineOk.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnABLineOk.Name = "btnABLineOk";
            this.btnABLineOk.UseVisualStyleBackColor = true;
            this.btnABLineOk.Click += new System.EventHandler(this.btnABLineOk_Click);
            // 
            // btnAddToFile
            // 
            resources.ApplyResources(this.btnAddToFile, "btnAddToFile");
            this.btnAddToFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddToFile.Image = global::AgOpenGPS.Properties.Resources.FileNew;
            this.btnAddToFile.Name = "btnAddToFile";
            this.btnAddToFile.Click += new System.EventHandler(this.btnAddToFile_Click);
            // 
            // tboxHeading
            // 
            resources.ApplyResources(this.tboxHeading, "tboxHeading");
            this.tboxHeading.Name = "tboxHeading";
            this.tboxHeading.TextChanged += new System.EventHandler(this.tboxHeading_TextChanged);
            // 
            // btnDnABHeading
            // 
            resources.ApplyResources(this.btnDnABHeading, "btnDnABHeading");
            this.btnDnABHeading.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDnABHeading.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnDnABHeading.Name = "btnDnABHeading";
            this.btnDnABHeading.UseVisualStyleBackColor = true;
            this.btnDnABHeading.Click += new System.EventHandler(this.btnDownABHeading_Click);
            // 
            // btnUpABHeading
            // 
            resources.ApplyResources(this.btnUpABHeading, "btnUpABHeading");
            this.btnUpABHeading.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpABHeading.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnUpABHeading.Name = "btnUpABHeading";
            this.btnUpABHeading.UseVisualStyleBackColor = true;
            this.btnUpABHeading.Click += new System.EventHandler(this.btnUpABHeading_Click);
            // 
            // lvLines
            // 
            resources.ApplyResources(this.lvLines, "lvLines");
            this.lvLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chField,
            this.chAngle,
            this.chEasting,
            this.chNorthing});
            this.lvLines.FullRowSelect = true;
            this.lvLines.GridLines = true;
            this.lvLines.HideSelection = false;
            this.lvLines.MultiSelect = false;
            this.lvLines.Name = "lvLines";
            this.lvLines.UseCompatibleStateImageBehavior = false;
            this.lvLines.View = System.Windows.Forms.View.Details;
            // 
            // chField
            // 
            resources.ApplyResources(this.chField, "chField");
            // 
            // chAngle
            // 
            resources.ApplyResources(this.chAngle, "chAngle");
            // 
            // chEasting
            // 
            resources.ApplyResources(this.chEasting, "chEasting");
            // 
            // chNorthing
            // 
            resources.ApplyResources(this.chNorthing, "chNorthing");
            // 
            // btnListDelete
            // 
            resources.ApplyResources(this.btnListDelete, "btnListDelete");
            this.btnListDelete.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnListDelete.Name = "btnListDelete";
            this.btnListDelete.UseVisualStyleBackColor = true;
            this.btnListDelete.Click += new System.EventHandler(this.btnListDelete_Click);
            // 
            // btnListUse
            // 
            resources.ApplyResources(this.btnListUse, "btnListUse");
            this.btnListUse.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnListUse.Name = "btnListUse";
            this.btnListUse.UseVisualStyleBackColor = true;
            this.btnListUse.Click += new System.EventHandler(this.btnListUse_Click);
            // 
            // btnPlus90
            // 
            resources.ApplyResources(this.btnPlus90, "btnPlus90");
            this.btnPlus90.Name = "btnPlus90";
            this.btnPlus90.UseVisualStyleBackColor = true;
            this.btnPlus90.Click += new System.EventHandler(this.btnPlus90_Click);
            // 
            // FormABLine
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ControlBox = false;
            this.Controls.Add(this.btnPlus90);
            this.Controls.Add(this.btnListUse);
            this.Controls.Add(this.btnListDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvLines);
            this.Controls.Add(this.nudTramRepeats);
            this.Controls.Add(this.tboxHeading);
            this.Controls.Add(this.nudBasedOnPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddToFile);
            this.Controls.Add(this.lblKeepGoing);
            this.Controls.Add(this.btnDnABHeadingBy1);
            this.Controls.Add(this.btnUpABHeadingBy1);
            this.Controls.Add(this.btnDnABHeading);
            this.Controls.Add(this.btnUpABHeading);
            this.Controls.Add(this.lblFixHeading);
            this.Controls.Add(this.lblABHeading);
            this.Controls.Add(this.btnDeleteAB);
            this.Controls.Add(this.btnBPoint);
            this.Controls.Add(this.btnAPoint);
            this.Controls.Add(this.btnABLineOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormABLine";
            this.ShowIcon = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormABLine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudBasedOnPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTramRepeats)).EndInit();
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
        private System.Windows.Forms.Button btnDnABHeadingBy1;
        private System.Windows.Forms.Button btnUpABHeadingBy1;
        private System.Windows.Forms.Label lblKeepGoing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudBasedOnPass;
        private System.Windows.Forms.NumericUpDown nudTramRepeats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddToFile;
        private System.Windows.Forms.TextBox tboxHeading;
        private System.Windows.Forms.Button btnDnABHeading;
        private System.Windows.Forms.Button btnUpABHeading;
        private System.Windows.Forms.ListView lvLines;
        private System.Windows.Forms.ColumnHeader chField;
        private System.Windows.Forms.ColumnHeader chAngle;
        private System.Windows.Forms.Button btnListDelete;
        private System.Windows.Forms.Button btnListUse;
        private System.Windows.Forms.ColumnHeader chEasting;
        private System.Windows.Forms.ColumnHeader chNorthing;
        private System.Windows.Forms.Button btnPlus90;
    }
}