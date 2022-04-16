
namespace AgIO
{
    partial class FormRadioChannel
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
            this.labelName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFrequency = new System.Windows.Forms.TextBox();
            this.labelLat = new System.Windows.Forms.Label();
            this.tbLat = new System.Windows.Forms.TextBox();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.btnSerialOK = new System.Windows.Forms.Button();
            this.tbId = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.tbLon = new System.Windows.Forms.TextBox();
            this.labelLon = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(34, 51);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(48, 16);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(88, 48);
            this.tbName.MinimumSize = new System.Drawing.Size(244, 20);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(358, 23);
            this.tbName.TabIndex = 1;
            this.tbName.Click += new System.EventHandler(this.tbox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Frequency";
            // 
            // tbFrequency
            // 
            this.tbFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFrequency.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFrequency.Location = new System.Drawing.Point(88, 84);
            this.tbFrequency.MinimumSize = new System.Drawing.Size(244, 20);
            this.tbFrequency.Name = "tbFrequency";
            this.tbFrequency.Size = new System.Drawing.Size(358, 23);
            this.tbFrequency.TabIndex = 2;
            this.tbFrequency.Click += new System.EventHandler(this.tbox_Click);
            // 
            // labelLat
            // 
            this.labelLat.AutoSize = true;
            this.labelLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLat.Location = new System.Drawing.Point(20, 125);
            this.labelLat.Name = "labelLat";
            this.labelLat.Size = new System.Drawing.Size(62, 16);
            this.labelLat.TabIndex = 9;
            this.labelLat.Text = "Latitude";
            // 
            // tbLat
            // 
            this.tbLat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLat.Location = new System.Drawing.Point(88, 122);
            this.tbLat.MinimumSize = new System.Drawing.Size(244, 20);
            this.tbLat.Name = "tbLat";
            this.tbLat.Size = new System.Drawing.Size(358, 23);
            this.tbLat.TabIndex = 3;
            this.tbLat.Click += new System.EventHandler(this.tbox_Click);
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.FlatAppearance.BorderSize = 0;
            this.btnSerialCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialCancel.Image = global::AgIO.Properties.Resources.Cancel64;
            this.btnSerialCancel.Location = new System.Drawing.Point(215, 195);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(88, 62);
            this.btnSerialCancel.TabIndex = 5;
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            // 
            // btnSerialOK
            // 
            this.btnSerialOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSerialOK.FlatAppearance.BorderSize = 0;
            this.btnSerialOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialOK.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSerialOK.Image = global::AgIO.Properties.Resources.OK64;
            this.btnSerialOK.Location = new System.Drawing.Point(342, 195);
            this.btnSerialOK.Name = "btnSerialOK";
            this.btnSerialOK.Size = new System.Drawing.Size(88, 62);
            this.btnSerialOK.TabIndex = 4;
            this.btnSerialOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSerialOK.UseVisualStyleBackColor = true;
            this.btnSerialOK.Click += new System.EventHandler(this.btnSerialOK_Click);
            // 
            // tbId
            // 
            this.tbId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbId.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbId.Location = new System.Drawing.Point(88, 12);
            this.tbId.MinimumSize = new System.Drawing.Size(244, 20);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(358, 23);
            this.tbId.TabIndex = 0;
            this.tbId.Click += new System.EventHandler(this.tbox_Click);
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelId.Location = new System.Drawing.Point(62, 15);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(20, 16);
            this.labelId.TabIndex = 6;
            this.labelId.Text = "Id";
            // 
            // tbLon
            // 
            this.tbLon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLon.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLon.Location = new System.Drawing.Point(88, 158);
            this.tbLon.MinimumSize = new System.Drawing.Size(244, 20);
            this.tbLon.Name = "tbLon";
            this.tbLon.Size = new System.Drawing.Size(358, 23);
            this.tbLon.TabIndex = 10;
            // 
            // labelLon
            // 
            this.labelLon.AutoSize = true;
            this.labelLon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLon.Location = new System.Drawing.Point(7, 161);
            this.labelLon.Name = "labelLon";
            this.labelLon.Size = new System.Drawing.Size(75, 16);
            this.labelLon.TabIndex = 11;
            this.labelLon.Text = "Longitude";
            // 
            // FormRadioChannel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 269);
            this.ControlBox = false;
            this.Controls.Add(this.tbLon);
            this.Controls.Add(this.labelLon);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.btnSerialCancel);
            this.Controls.Add(this.btnSerialOK);
            this.Controls.Add(this.tbLat);
            this.Controls.Add(this.labelLat);
            this.Controls.Add(this.tbFrequency);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.labelName);
            this.MinimumSize = new System.Drawing.Size(465, 310);
            this.Name = "FormRadioChannel";
            this.ShowIcon = false;
            this.Text = "Radio Channel";
            this.Load += new System.EventHandler(this.FormRadioChannel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFrequency;
        private System.Windows.Forms.Label labelLat;
        private System.Windows.Forms.TextBox tbLat;
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Button btnSerialOK;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox tbLon;
        private System.Windows.Forms.Label labelLon;
    }
}