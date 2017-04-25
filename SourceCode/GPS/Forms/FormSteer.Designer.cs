namespace AgOpenGPS
{
    partial class FormSteer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label14 = new System.Windows.Forms.Label();
            this.tboxSerialFromAutoSteer = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tboxSerialToAutoSteer = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblMaxIntErr = new System.Windows.Forms.Label();
            this.btnMaxIntErrMinus = new System.Windows.Forms.Button();
            this.btnMaxIntErrPlus = new System.Windows.Forms.Button();
            this.lblOValue = new System.Windows.Forms.Label();
            this.lblDValue = new System.Windows.Forms.Label();
            this.lblIValue = new System.Windows.Forms.Label();
            this.lblPValue = new System.Windows.Forms.Label();
            this.btnOMinus = new System.Windows.Forms.Button();
            this.btnOPlus = new System.Windows.Forms.Button();
            this.btnIMinus = new System.Windows.Forms.Button();
            this.btnDMinus = new System.Windows.Forms.Button();
            this.btnPMinus = new System.Windows.Forms.Button();
            this.btnIPlus = new System.Windows.Forms.Button();
            this.btnDPlus = new System.Windows.Forms.Button();
            this.btnPPlus = new System.Windows.Forms.Button();
            this.unoChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.unoChart)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(6, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 23);
            this.label14.TabIndex = 126;
            this.label14.Text = "Frm";
            // 
            // tboxSerialFromAutoSteer
            // 
            this.tboxSerialFromAutoSteer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxSerialFromAutoSteer.BackColor = System.Drawing.SystemColors.Control;
            this.tboxSerialFromAutoSteer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSerialFromAutoSteer.Location = new System.Drawing.Point(65, 40);
            this.tboxSerialFromAutoSteer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tboxSerialFromAutoSteer.Name = "tboxSerialFromAutoSteer";
            this.tboxSerialFromAutoSteer.ReadOnly = true;
            this.tboxSerialFromAutoSteer.Size = new System.Drawing.Size(686, 29);
            this.tboxSerialFromAutoSteer.TabIndex = 125;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(16, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 23);
            this.label15.TabIndex = 124;
            this.label15.Text = "To";
            // 
            // tboxSerialToAutoSteer
            // 
            this.tboxSerialToAutoSteer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxSerialToAutoSteer.BackColor = System.Drawing.SystemColors.Control;
            this.tboxSerialToAutoSteer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSerialToAutoSteer.Location = new System.Drawing.Point(65, 8);
            this.tboxSerialToAutoSteer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tboxSerialToAutoSteer.Name = "tboxSerialToAutoSteer";
            this.tboxSerialToAutoSteer.ReadOnly = true;
            this.tboxSerialToAutoSteer.Size = new System.Drawing.Size(687, 29);
            this.tboxSerialToAutoSteer.TabIndex = 123;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblMaxIntErr
            // 
            this.lblMaxIntErr.AutoSize = true;
            this.lblMaxIntErr.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxIntErr.Location = new System.Drawing.Point(699, 104);
            this.lblMaxIntErr.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMaxIntErr.Name = "lblMaxIntErr";
            this.lblMaxIntErr.Size = new System.Drawing.Size(32, 37);
            this.lblMaxIntErr.TabIndex = 178;
            this.lblMaxIntErr.Text = "0";
            this.lblMaxIntErr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnMaxIntErrMinus
            // 
            this.btnMaxIntErrMinus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxIntErrMinus.Location = new System.Drawing.Point(624, 126);
            this.btnMaxIntErrMinus.Name = "btnMaxIntErrMinus";
            this.btnMaxIntErrMinus.Size = new System.Drawing.Size(73, 39);
            this.btnMaxIntErrMinus.TabIndex = 176;
            this.btnMaxIntErrMinus.Text = "W-";
            this.btnMaxIntErrMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMaxIntErrMinus.UseVisualStyleBackColor = true;
            this.btnMaxIntErrMinus.Click += new System.EventHandler(this.btnMaxIntErrMinus_Click);
            // 
            // btnMaxIntErrPlus
            // 
            this.btnMaxIntErrPlus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxIntErrPlus.Location = new System.Drawing.Point(624, 80);
            this.btnMaxIntErrPlus.Name = "btnMaxIntErrPlus";
            this.btnMaxIntErrPlus.Size = new System.Drawing.Size(73, 39);
            this.btnMaxIntErrPlus.TabIndex = 175;
            this.btnMaxIntErrPlus.Text = "W+";
            this.btnMaxIntErrPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMaxIntErrPlus.UseVisualStyleBackColor = true;
            this.btnMaxIntErrPlus.Click += new System.EventHandler(this.btnMaxIntErrPlus_Click);
            // 
            // lblOValue
            // 
            this.lblOValue.AutoSize = true;
            this.lblOValue.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOValue.Location = new System.Drawing.Point(541, 104);
            this.lblOValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOValue.Name = "lblOValue";
            this.lblOValue.Size = new System.Drawing.Size(62, 37);
            this.lblOValue.TabIndex = 174;
            this.lblOValue.Text = "255";
            this.lblOValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDValue
            // 
            this.lblDValue.AutoSize = true;
            this.lblDValue.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDValue.Location = new System.Drawing.Point(389, 104);
            this.lblDValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDValue.Name = "lblDValue";
            this.lblDValue.Size = new System.Drawing.Size(62, 37);
            this.lblDValue.TabIndex = 173;
            this.lblDValue.Text = "255";
            this.lblDValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIValue
            // 
            this.lblIValue.AutoSize = true;
            this.lblIValue.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIValue.Location = new System.Drawing.Point(236, 104);
            this.lblIValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblIValue.Name = "lblIValue";
            this.lblIValue.Size = new System.Drawing.Size(62, 37);
            this.lblIValue.TabIndex = 172;
            this.lblIValue.Text = "255";
            this.lblIValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPValue
            // 
            this.lblPValue.AutoSize = true;
            this.lblPValue.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPValue.Location = new System.Drawing.Point(84, 104);
            this.lblPValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPValue.Name = "lblPValue";
            this.lblPValue.Size = new System.Drawing.Size(62, 37);
            this.lblPValue.TabIndex = 171;
            this.lblPValue.Text = "255";
            this.lblPValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOMinus
            // 
            this.btnOMinus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOMinus.Location = new System.Drawing.Point(472, 126);
            this.btnOMinus.Name = "btnOMinus";
            this.btnOMinus.Size = new System.Drawing.Size(67, 39);
            this.btnOMinus.TabIndex = 169;
            this.btnOMinus.Text = "O-";
            this.btnOMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOMinus.UseVisualStyleBackColor = true;
            this.btnOMinus.Click += new System.EventHandler(this.btnOMinus_Click);
            // 
            // btnOPlus
            // 
            this.btnOPlus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOPlus.Location = new System.Drawing.Point(472, 80);
            this.btnOPlus.Name = "btnOPlus";
            this.btnOPlus.Size = new System.Drawing.Size(67, 39);
            this.btnOPlus.TabIndex = 168;
            this.btnOPlus.Text = "O+";
            this.btnOPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOPlus.UseVisualStyleBackColor = true;
            this.btnOPlus.Click += new System.EventHandler(this.btnOPlus_Click);
            // 
            // btnIMinus
            // 
            this.btnIMinus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIMinus.Location = new System.Drawing.Point(168, 126);
            this.btnIMinus.Name = "btnIMinus";
            this.btnIMinus.Size = new System.Drawing.Size(67, 39);
            this.btnIMinus.TabIndex = 164;
            this.btnIMinus.Text = "I-";
            this.btnIMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIMinus.UseVisualStyleBackColor = true;
            this.btnIMinus.Click += new System.EventHandler(this.btnIMinus_Click);
            // 
            // btnDMinus
            // 
            this.btnDMinus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDMinus.Location = new System.Drawing.Point(320, 126);
            this.btnDMinus.Name = "btnDMinus";
            this.btnDMinus.Size = new System.Drawing.Size(67, 39);
            this.btnDMinus.TabIndex = 163;
            this.btnDMinus.Text = "D-";
            this.btnDMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDMinus.UseVisualStyleBackColor = true;
            this.btnDMinus.Click += new System.EventHandler(this.btnDMinus_Click);
            // 
            // btnPMinus
            // 
            this.btnPMinus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMinus.Location = new System.Drawing.Point(16, 126);
            this.btnPMinus.Name = "btnPMinus";
            this.btnPMinus.Size = new System.Drawing.Size(67, 39);
            this.btnPMinus.TabIndex = 162;
            this.btnPMinus.Text = "P-";
            this.btnPMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPMinus.UseVisualStyleBackColor = true;
            this.btnPMinus.Click += new System.EventHandler(this.btnPMinus_Click);
            // 
            // btnIPlus
            // 
            this.btnIPlus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIPlus.Location = new System.Drawing.Point(168, 80);
            this.btnIPlus.Name = "btnIPlus";
            this.btnIPlus.Size = new System.Drawing.Size(67, 39);
            this.btnIPlus.TabIndex = 161;
            this.btnIPlus.Text = "I+";
            this.btnIPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIPlus.UseVisualStyleBackColor = true;
            this.btnIPlus.Click += new System.EventHandler(this.btnIPlus_Click);
            // 
            // btnDPlus
            // 
            this.btnDPlus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDPlus.Location = new System.Drawing.Point(320, 80);
            this.btnDPlus.Name = "btnDPlus";
            this.btnDPlus.Size = new System.Drawing.Size(67, 39);
            this.btnDPlus.TabIndex = 160;
            this.btnDPlus.Text = "D+";
            this.btnDPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDPlus.UseVisualStyleBackColor = true;
            this.btnDPlus.Click += new System.EventHandler(this.btnDPlus_Click);
            // 
            // btnPPlus
            // 
            this.btnPPlus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPPlus.Location = new System.Drawing.Point(16, 80);
            this.btnPPlus.Name = "btnPPlus";
            this.btnPPlus.Size = new System.Drawing.Size(67, 39);
            this.btnPPlus.TabIndex = 159;
            this.btnPPlus.Text = "P+";
            this.btnPPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPPlus.UseVisualStyleBackColor = true;
            this.btnPPlus.Click += new System.EventHandler(this.btnPPlus_Click);
            // 
            // unoChart
            // 
            this.unoChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unoChart.BackColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.LineWidth = 2;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BorderWidth = 2;
            chartArea1.Name = "ChartArea1";
            this.unoChart.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.BackColor = System.Drawing.Color.DimGray;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.Name = "Legend1";
            this.unoChart.Legends.Add(legend1);
            this.unoChart.Location = new System.Drawing.Point(10, 171);
            this.unoChart.Name = "unoChart";
            this.unoChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BackSecondaryColor = System.Drawing.Color.White;
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Color = System.Drawing.Color.Yellow;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "S";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Color = System.Drawing.Color.Lime;
            series2.Legend = "Legend1";
            series2.Name = "P";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Color = System.Drawing.Color.Fuchsia;
            series3.Legend = "Legend1";
            series3.Name = "I";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.Name = "D";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series5.Color = System.Drawing.Color.LightSkyBlue;
            series5.Legend = "Legend1";
            series5.Name = "PWM";
            this.unoChart.Series.Add(series1);
            this.unoChart.Series.Add(series2);
            this.unoChart.Series.Add(series3);
            this.unoChart.Series.Add(series4);
            this.unoChart.Series.Add(series5);
            this.unoChart.Size = new System.Drawing.Size(742, 313);
            this.unoChart.TabIndex = 179;
            this.unoChart.Text = "Arduino Serial Data";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Data from Serial In";
            this.unoChart.Titles.Add(title1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(88, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 180;
            this.label1.Text = "label1";
            // 
            // FormSteer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(764, 496);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unoChart);
            this.Controls.Add(this.lblMaxIntErr);
            this.Controls.Add(this.btnMaxIntErrMinus);
            this.Controls.Add(this.btnMaxIntErrPlus);
            this.Controls.Add(this.lblOValue);
            this.Controls.Add(this.lblDValue);
            this.Controls.Add(this.lblIValue);
            this.Controls.Add(this.lblPValue);
            this.Controls.Add(this.btnOMinus);
            this.Controls.Add(this.btnOPlus);
            this.Controls.Add(this.btnIMinus);
            this.Controls.Add(this.btnDMinus);
            this.Controls.Add(this.btnPMinus);
            this.Controls.Add(this.btnIPlus);
            this.Controls.Add(this.btnDPlus);
            this.Controls.Add(this.btnPPlus);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tboxSerialFromAutoSteer);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tboxSerialToAutoSteer);
            this.Name = "FormSteer";
            this.Text = "Auto Steer Configuration";
            this.Load += new System.EventHandler(this.FormSteer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.unoChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tboxSerialFromAutoSteer;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tboxSerialToAutoSteer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblMaxIntErr;
        private System.Windows.Forms.Button btnMaxIntErrMinus;
        private System.Windows.Forms.Button btnMaxIntErrPlus;
        private System.Windows.Forms.Label lblOValue;
        private System.Windows.Forms.Label lblDValue;
        private System.Windows.Forms.Label lblIValue;
        private System.Windows.Forms.Label lblPValue;
        private System.Windows.Forms.Button btnOMinus;
        private System.Windows.Forms.Button btnOPlus;
        private System.Windows.Forms.Button btnIMinus;
        private System.Windows.Forms.Button btnDMinus;
        private System.Windows.Forms.Button btnPMinus;
        private System.Windows.Forms.Button btnIPlus;
        private System.Windows.Forms.Button btnDPlus;
        private System.Windows.Forms.Button btnPPlus;
        private System.Windows.Forms.DataVisualization.Charting.Chart unoChart;
        private System.Windows.Forms.Label label1;
    }
}