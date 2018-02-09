namespace AgOpenGPS
{
    partial class FormFieldDir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFieldDir));
            this.label1 = new System.Windows.Forms.Label();
            this.tboxFieldName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.btnTemplate = new System.Windows.Forms.Button();
            this.lblTemplateChosen = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tboxFieldName
            // 
            resources.ApplyResources(this.tboxFieldName, "tboxFieldName");
            this.tboxFieldName.Name = "tboxFieldName";
            this.tboxFieldName.TextChanged += new System.EventHandler(this.tboxFieldName_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnSerialCancel
            // 
            resources.ApplyResources(this.btnSerialCancel, "btnSerialCancel");
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            this.btnSerialCancel.Click += new System.EventHandler(this.btnSerialCancel_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.BackColor = System.Drawing.Color.AliceBlue;
            resources.ApplyResources(this.btnTemplate, "btnTemplate");
            this.btnTemplate.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.UseVisualStyleBackColor = false;
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // lblTemplateChosen
            // 
            resources.ApplyResources(this.lblTemplateChosen, "lblTemplateChosen");
            this.lblTemplateChosen.Name = "lblTemplateChosen";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::AgOpenGPS.Properties.Resources.OK64;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormFieldDir
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTemplateChosen);
            this.Controls.Add(this.btnTemplate);
            this.Controls.Add(this.btnSerialCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxFieldName);
            this.Name = "FormFieldDir";
            this.Load += new System.EventHandler(this.FormFieldDir_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxFieldName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Button btnTemplate;
        private System.Windows.Forms.Label lblTemplateChosen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
    }
}