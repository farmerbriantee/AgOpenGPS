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
            this.lblSteerAng = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.lblI = new System.Windows.Forms.Label();
            this.lblD = new System.Windows.Forms.Label();
            this.lblPWM = new System.Windows.Forms.Label();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.tboxSerialFromAutoSteer.Size = new System.Drawing.Size(795, 29);
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
            this.tboxSerialToAutoSteer.Size = new System.Drawing.Size(796, 29);
            this.tboxSerialToAutoSteer.TabIndex = 123;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
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
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 94F;
            chartArea1.Position.Width = 97F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 6F;
            this.unoChart.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.BackColor = System.Drawing.Color.DimGray;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.Name = "Legend1";
            this.unoChart.Legends.Add(legend1);
            this.unoChart.Location = new System.Drawing.Point(0, 171);
            this.unoChart.Name = "unoChart";
            this.unoChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BackSecondaryColor = System.Drawing.Color.White;
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series1.Color = System.Drawing.Color.Yellow;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "S";
            series1.YValuesPerPoint = 6;
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
            this.unoChart.Size = new System.Drawing.Size(870, 243);
            this.unoChart.TabIndex = 179;
            // 
            // lblSteerAng
            // 
            this.lblSteerAng.AutoSize = true;
            this.lblSteerAng.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblSteerAng.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerAng.ForeColor = System.Drawing.Color.Yellow;
            this.lblSteerAng.Location = new System.Drawing.Point(101, 175);
            this.lblSteerAng.Name = "lblSteerAng";
            this.lblSteerAng.Size = new System.Drawing.Size(68, 23);
            this.lblSteerAng.TabIndex = 180;
            this.lblSteerAng.Text = "label1";
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblP.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP.ForeColor = System.Drawing.Color.Lime;
            this.lblP.Location = new System.Drawing.Point(274, 175);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(68, 23);
            this.lblP.TabIndex = 181;
            this.lblP.Text = "label2";
            // 
            // lblI
            // 
            this.lblI.AutoSize = true;
            this.lblI.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblI.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblI.ForeColor = System.Drawing.Color.Violet;
            this.lblI.Location = new System.Drawing.Point(447, 175);
            this.lblI.Name = "lblI";
            this.lblI.Size = new System.Drawing.Size(68, 23);
            this.lblI.TabIndex = 182;
            this.lblI.Text = "label3";
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblD.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblD.ForeColor = System.Drawing.Color.Red;
            this.lblD.Location = new System.Drawing.Point(620, 175);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(68, 23);
            this.lblD.TabIndex = 183;
            this.lblD.Text = "label4";
            // 
            // lblPWM
            // 
            this.lblPWM.AutoSize = true;
            this.lblPWM.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblPWM.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPWM.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblPWM.Location = new System.Drawing.Point(793, 175);
            this.lblPWM.Name = "lblPWM";
            this.lblPWM.Size = new System.Drawing.Size(68, 23);
            this.lblPWM.TabIndex = 184;
            this.lblPWM.Text = "label5";
            // 
            // btnPlus
            // 
            this.btnPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.Location = new System.Drawing.Point(8, 184);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(28, 64);
            this.btnPlus.TabIndex = 185;
            this.btnPlus.Text = "^\r";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinus.Location = new System.Drawing.Point(8, 338);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(28, 64);
            this.btnMinus.TabIndex = 186;
            this.btnMinus.Text = "v";
            this.btnMinus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuto.Location = new System.Drawing.Point(8, 261);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(28, 64);
            this.btnAuto.TabIndex = 187;
            this.btnAuto.Text = "A\r\nu\r\nt\r\no";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 188;
            this.label1.Text = "Steer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(247, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 16);
            this.label2.TabIndex = 189;
            this.label2.Text = "P";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(425, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 16);
            this.label3.TabIndex = 190;
            this.label3.Text = "I";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(591, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 16);
            this.label4.TabIndex = 191;
            this.label4.Text = "D";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(736, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 192;
            this.label5.Text = "PWM";
            // 
            // FormSteer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(873, 414);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.lblPWM);
            this.Controls.Add(this.lblD);
            this.Controls.Add(this.lblI);
            this.Controls.Add(this.lblP);
            this.Controls.Add(this.lblSteerAng);
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
            this.TopMost = true;
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
        private System.Windows.Forms.Label lblSteerAng;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Label lblI;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.Label lblPWM;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}