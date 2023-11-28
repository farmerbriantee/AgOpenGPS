namespace AgOpenGPS.Forms
{
    partial class FormMenuSettings
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
            this.btnConfig = new AgOpenGPS.RJButton();
            this.btnStartAgIO = new AgOpenGPS.RJButton();
            this.btnStanleyPure = new AgOpenGPS.RJButton();
            this.SuspendLayout();
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfig.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfig.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfig.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnConfig.BorderRadius = 10;
            this.btnConfig.BorderSize = 2;
            this.btnConfig.FlatAppearance.BorderSize = 0;
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfig.ForeColor = System.Drawing.Color.Black;
            this.btnConfig.Image = global::AgOpenGPS.Properties.Resources.Settings48;
            this.btnConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfig.Location = new System.Drawing.Point(676, 256);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(279, 92);
            this.btnConfig.TabIndex = 539;
            this.btnConfig.Text = "Config";
            this.btnConfig.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfig.TextColor = System.Drawing.Color.Black;
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnStartAgIO
            // 
            this.btnStartAgIO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartAgIO.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnStartAgIO.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnStartAgIO.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnStartAgIO.BorderRadius = 10;
            this.btnStartAgIO.BorderSize = 2;
            this.btnStartAgIO.FlatAppearance.BorderSize = 0;
            this.btnStartAgIO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartAgIO.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartAgIO.ForeColor = System.Drawing.Color.Black;
            this.btnStartAgIO.Image = global::AgOpenGPS.Properties.Resources.AgIO;
            this.btnStartAgIO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartAgIO.Location = new System.Drawing.Point(40, 433);
            this.btnStartAgIO.Name = "btnStartAgIO";
            this.btnStartAgIO.Size = new System.Drawing.Size(279, 92);
            this.btnStartAgIO.TabIndex = 540;
            this.btnStartAgIO.Text = "Start AgIO";
            this.btnStartAgIO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartAgIO.TextColor = System.Drawing.Color.Black;
            this.btnStartAgIO.UseVisualStyleBackColor = false;
            this.btnStartAgIO.Click += new System.EventHandler(this.btnStartAgIO_Click);
            // 
            // btnStanleyPure
            // 
            this.btnStanleyPure.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStanleyPure.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnStanleyPure.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnStanleyPure.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnStanleyPure.BorderRadius = 10;
            this.btnStanleyPure.BorderSize = 2;
            this.btnStanleyPure.FlatAppearance.BorderSize = 0;
            this.btnStanleyPure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStanleyPure.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStanleyPure.ForeColor = System.Drawing.Color.Black;
            this.btnStanleyPure.Image = global::AgOpenGPS.Properties.Resources.ModePurePursuit;
            this.btnStanleyPure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStanleyPure.Location = new System.Drawing.Point(40, 277);
            this.btnStanleyPure.Name = "btnStanleyPure";
            this.btnStanleyPure.Size = new System.Drawing.Size(279, 92);
            this.btnStanleyPure.TabIndex = 541;
            this.btnStanleyPure.Text = "Stanley / Pure";
            this.btnStanleyPure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStanleyPure.TextColor = System.Drawing.Color.Black;
            this.btnStanleyPure.UseVisualStyleBackColor = false;
            // 
            // FormMenuSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(982, 628);
            this.Controls.Add(this.btnStanleyPure);
            this.Controls.Add(this.btnStartAgIO);
            this.Controls.Add(this.btnConfig);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormMenuSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting Menu";
            this.ResumeLayout(false);

        }

        #endregion
        private RJButton btnConfig;
        private RJButton btnStartAgIO;
        private RJButton btnStanleyPure;
    }
}