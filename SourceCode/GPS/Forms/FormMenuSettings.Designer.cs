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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConfigUTurn = new AgOpenGPS.RJButton();
            this.btnStartAgIO = new AgOpenGPS.RJButton();
            this.btnStanleyPure = new AgOpenGPS.RJButton();
            this.btnConfigGuidance = new AgOpenGPS.RJButton();
            this.btnConfgTool = new AgOpenGPS.RJButton();
            this.btnConfig = new AgOpenGPS.RJButton();
            this.btnDisplay = new AgOpenGPS.RJButton();
            this.btnDeleteAB = new System.Windows.Forms.Button();
            this.btnSteerSettings = new AgOpenGPS.RJButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnConfigUTurn, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStartAgIO, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnConfigGuidance, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnConfgTool, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteAB, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnConfig, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnDisplay, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSteerSettings, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnStanleyPure, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(755, 512);
            this.tableLayoutPanel1.TabIndex = 547;
            // 
            // btnConfigUTurn
            // 
            this.btnConfigUTurn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfigUTurn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfigUTurn.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfigUTurn.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnConfigUTurn.BorderRadius = 10;
            this.btnConfigUTurn.BorderSize = 2;
            this.btnConfigUTurn.FlatAppearance.BorderSize = 0;
            this.btnConfigUTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigUTurn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigUTurn.ForeColor = System.Drawing.Color.Black;
            this.btnConfigUTurn.Image = global::AgOpenGPS.Properties.Resources.Con_UTurnMenu;
            this.btnConfigUTurn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigUTurn.Location = new System.Drawing.Point(522, 18);
            this.btnConfigUTurn.Name = "btnConfigUTurn";
            this.btnConfigUTurn.Size = new System.Drawing.Size(213, 92);
            this.btnConfigUTurn.TabIndex = 544;
            this.btnConfigUTurn.Text = "U Turn";
            this.btnConfigUTurn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfigUTurn.TextColor = System.Drawing.Color.Black;
            this.btnConfigUTurn.UseVisualStyleBackColor = false;
            this.btnConfigUTurn.Click += new System.EventHandler(this.btnConfigUTurn_Click);
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
            this.btnStartAgIO.Location = new System.Drawing.Point(19, 402);
            this.btnStartAgIO.Name = "btnStartAgIO";
            this.btnStartAgIO.Size = new System.Drawing.Size(213, 92);
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
            this.btnStanleyPure.Location = new System.Drawing.Point(270, 146);
            this.btnStanleyPure.Name = "btnStanleyPure";
            this.btnStanleyPure.Size = new System.Drawing.Size(213, 92);
            this.btnStanleyPure.TabIndex = 541;
            this.btnStanleyPure.Text = "Mode";
            this.btnStanleyPure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStanleyPure.TextColor = System.Drawing.Color.Black;
            this.btnStanleyPure.UseVisualStyleBackColor = false;
            // 
            // btnConfigGuidance
            // 
            this.btnConfigGuidance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfigGuidance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfigGuidance.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfigGuidance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnConfigGuidance.BorderRadius = 10;
            this.btnConfigGuidance.BorderSize = 2;
            this.btnConfigGuidance.FlatAppearance.BorderSize = 0;
            this.btnConfigGuidance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigGuidance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigGuidance.ForeColor = System.Drawing.Color.Black;
            this.btnConfigGuidance.Image = global::AgOpenGPS.Properties.Resources.ConS_ModulesSteer;
            this.btnConfigGuidance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigGuidance.Location = new System.Drawing.Point(522, 146);
            this.btnConfigGuidance.Name = "btnConfigGuidance";
            this.btnConfigGuidance.Size = new System.Drawing.Size(213, 92);
            this.btnConfigGuidance.TabIndex = 545;
            this.btnConfigGuidance.Text = "Guidance";
            this.btnConfigGuidance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfigGuidance.TextColor = System.Drawing.Color.Black;
            this.btnConfigGuidance.UseVisualStyleBackColor = false;
            this.btnConfigGuidance.Click += new System.EventHandler(this.btnConfigGuidance_Click);
            // 
            // btnConfgTool
            // 
            this.btnConfgTool.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfgTool.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfgTool.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfgTool.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnConfgTool.BorderRadius = 10;
            this.btnConfgTool.BorderSize = 2;
            this.btnConfgTool.FlatAppearance.BorderSize = 0;
            this.btnConfgTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfgTool.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfgTool.ForeColor = System.Drawing.Color.Black;
            this.btnConfgTool.Image = global::AgOpenGPS.Properties.Resources.ConS_ImplementSection;
            this.btnConfgTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfgTool.Location = new System.Drawing.Point(522, 274);
            this.btnConfgTool.Name = "btnConfgTool";
            this.btnConfgTool.Size = new System.Drawing.Size(213, 92);
            this.btnConfgTool.TabIndex = 542;
            this.btnConfgTool.Text = "Tool \r\nSections";
            this.btnConfgTool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfgTool.TextColor = System.Drawing.Color.Black;
            this.btnConfgTool.UseVisualStyleBackColor = false;
            this.btnConfgTool.Click += new System.EventHandler(this.btnConfgTool_Click);
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
            this.btnConfig.Location = new System.Drawing.Point(270, 402);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(213, 92);
            this.btnConfig.TabIndex = 539;
            this.btnConfig.Text = "Config";
            this.btnConfig.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfig.TextColor = System.Drawing.Color.Black;
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDisplay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDisplay.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnDisplay.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDisplay.BorderRadius = 10;
            this.btnDisplay.BorderSize = 2;
            this.btnDisplay.FlatAppearance.BorderSize = 0;
            this.btnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplay.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplay.ForeColor = System.Drawing.Color.Black;
            this.btnDisplay.Image = global::AgOpenGPS.Properties.Resources.NavigationSettings;
            this.btnDisplay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisplay.Location = new System.Drawing.Point(19, 18);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(213, 92);
            this.btnDisplay.TabIndex = 546;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDisplay.TextColor = System.Drawing.Color.Black;
            this.btnDisplay.UseVisualStyleBackColor = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnDeleteAB
            // 
            this.btnDeleteAB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteAB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.btnDeleteAB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeleteAB.FlatAppearance.BorderSize = 0;
            this.btnDeleteAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeleteAB.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteAB.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnDeleteAB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteAB.Location = new System.Drawing.Point(538, 419);
            this.btnDeleteAB.Name = "btnDeleteAB";
            this.btnDeleteAB.Size = new System.Drawing.Size(180, 57);
            this.btnDeleteAB.TabIndex = 547;
            this.btnDeleteAB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteAB.UseVisualStyleBackColor = false;
            // 
            // btnSteerSettings
            // 
            this.btnSteerSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSteerSettings.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSteerSettings.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.btnSteerSettings.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSteerSettings.BorderRadius = 10;
            this.btnSteerSettings.BorderSize = 2;
            this.btnSteerSettings.FlatAppearance.BorderSize = 0;
            this.btnSteerSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSteerSettings.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSteerSettings.ForeColor = System.Drawing.Color.Black;
            this.btnSteerSettings.Image = global::AgOpenGPS.Properties.Resources.AutoSteerOn;
            this.btnSteerSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSteerSettings.Location = new System.Drawing.Point(270, 274);
            this.btnSteerSettings.Name = "btnSteerSettings";
            this.btnSteerSettings.Size = new System.Drawing.Size(213, 92);
            this.btnSteerSettings.TabIndex = 548;
            this.btnSteerSettings.Text = "Steer";
            this.btnSteerSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSteerSettings.TextColor = System.Drawing.Color.Black;
            this.btnSteerSettings.UseVisualStyleBackColor = false;
            this.btnSteerSettings.Click += new System.EventHandler(this.btnSteerSettings_Click);
            // 
            // FormMenuSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(755, 512);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(680, 420);
            this.Name = "FormMenuSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting Menu";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private RJButton btnConfig;
        private RJButton btnStartAgIO;
        private RJButton btnStanleyPure;
        private RJButton btnConfgTool;
        private RJButton btnConfigUTurn;
        private RJButton btnConfigGuidance;
        private RJButton btnDisplay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnDeleteAB;
        private RJButton btnSteerSettings;
    }
}