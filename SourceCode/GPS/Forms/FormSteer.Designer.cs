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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label14 = new System.Windows.Forms.Label();
            this.tboxSerialFromAutoSteer = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tboxSerialToAutoSteer = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSteerMinus = new System.Windows.Forms.Button();
            this.btnSteerPlus = new System.Windows.Forms.Button();
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
            this.lblPWM = new System.Windows.Forms.Label();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnMinPWMMinus = new System.Windows.Forms.Button();
            this.btnMinPWMPlus = new System.Windows.Forms.Button();
            this.btnLookAheadMinus = new System.Windows.Forms.Button();
            this.buttonLookAheadPlus = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnMaxSteerMinus = new System.Windows.Forms.Button();
            this.btnMaxSteerPlus = new System.Windows.Forms.Button();
            this.btnMaxAngVelMinus = new System.Windows.Forms.Button();
            this.btnMaxAngVelPlus = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnMaxIntegralMinus = new System.Windows.Forms.Button();
            this.btnMaxIntegralPlus = new System.Windows.Forms.Button();
            this.btnCountsPerDegreeMinus = new System.Windows.Forms.Button();
            this.btnCountsPerDegreePlus = new System.Windows.Forms.Button();
            this.btnSteerWizard = new System.Windows.Forms.Button();
            this.tbarFreeDriveAngle = new System.Windows.Forms.TrackBar();
            this.btnFreeDriveZero = new System.Windows.Forms.Button();
            this.btnFreeDrive = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblFreeDriveAngle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.unoChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarFreeDriveAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(394, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 23);
            this.label14.TabIndex = 126;
            this.label14.Text = "Frm";
            // 
            // tboxSerialFromAutoSteer
            // 
            this.tboxSerialFromAutoSteer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxSerialFromAutoSteer.BackColor = System.Drawing.SystemColors.Control;
            this.tboxSerialFromAutoSteer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSerialFromAutoSteer.Location = new System.Drawing.Point(438, 22);
            this.tboxSerialFromAutoSteer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tboxSerialFromAutoSteer.Name = "tboxSerialFromAutoSteer";
            this.tboxSerialFromAutoSteer.ReadOnly = true;
            this.tboxSerialFromAutoSteer.Size = new System.Drawing.Size(341, 27);
            this.tboxSerialFromAutoSteer.TabIndex = 125;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(16, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 23);
            this.label15.TabIndex = 124;
            this.label15.Text = "To";
            // 
            // tboxSerialToAutoSteer
            // 
            this.tboxSerialToAutoSteer.BackColor = System.Drawing.SystemColors.Control;
            this.tboxSerialToAutoSteer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSerialToAutoSteer.Location = new System.Drawing.Point(49, 22);
            this.tboxSerialToAutoSteer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tboxSerialToAutoSteer.Name = "tboxSerialToAutoSteer";
            this.tboxSerialToAutoSteer.ReadOnly = true;
            this.tboxSerialToAutoSteer.Size = new System.Drawing.Size(321, 27);
            this.tboxSerialToAutoSteer.TabIndex = 123;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSteerMinus
            // 
            this.btnSteerMinus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSteerMinus.Location = new System.Drawing.Point(53, 250);
            this.btnSteerMinus.Name = "btnSteerMinus";
            this.btnSteerMinus.Size = new System.Drawing.Size(79, 51);
            this.btnSteerMinus.TabIndex = 176;
            this.btnSteerMinus.Text = "255";
            this.btnSteerMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSteerMinus.UseVisualStyleBackColor = true;
            this.btnSteerMinus.Click += new System.EventHandler(this.btnSteerMinus_Click);
            // 
            // btnSteerPlus
            // 
            this.btnSteerPlus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSteerPlus.Location = new System.Drawing.Point(53, 193);
            this.btnSteerPlus.Name = "btnSteerPlus";
            this.btnSteerPlus.Size = new System.Drawing.Size(79, 51);
            this.btnSteerPlus.TabIndex = 175;
            this.btnSteerPlus.Text = "Steer >0<";
            this.btnSteerPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSteerPlus.UseVisualStyleBackColor = true;
            this.btnSteerPlus.Click += new System.EventHandler(this.btnSteerPlus_Click);
            // 
            // btnOMinus
            // 
            this.btnOMinus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOMinus.Location = new System.Drawing.Point(259, 127);
            this.btnOMinus.Name = "btnOMinus";
            this.btnOMinus.Size = new System.Drawing.Size(79, 46);
            this.btnOMinus.TabIndex = 169;
            this.btnOMinus.Text = "255";
            this.btnOMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOMinus.UseVisualStyleBackColor = true;
            this.btnOMinus.Click += new System.EventHandler(this.btnOMinus_Click);
            // 
            // btnOPlus
            // 
            this.btnOPlus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOPlus.Location = new System.Drawing.Point(259, 77);
            this.btnOPlus.Name = "btnOPlus";
            this.btnOPlus.Size = new System.Drawing.Size(79, 46);
            this.btnOPlus.TabIndex = 168;
            this.btnOPlus.Text = "O";
            this.btnOPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOPlus.UseVisualStyleBackColor = true;
            this.btnOPlus.Click += new System.EventHandler(this.btnOPlus_Click);
            // 
            // btnIMinus
            // 
            this.btnIMinus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIMinus.ForeColor = System.Drawing.Color.Fuchsia;
            this.btnIMinus.Location = new System.Drawing.Point(402, 128);
            this.btnIMinus.Name = "btnIMinus";
            this.btnIMinus.Size = new System.Drawing.Size(79, 46);
            this.btnIMinus.TabIndex = 164;
            this.btnIMinus.Text = "255";
            this.btnIMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIMinus.UseVisualStyleBackColor = true;
            this.btnIMinus.Click += new System.EventHandler(this.btnIMinus_Click);
            // 
            // btnDMinus
            // 
            this.btnDMinus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDMinus.ForeColor = System.Drawing.Color.Red;
            this.btnDMinus.Location = new System.Drawing.Point(156, 127);
            this.btnDMinus.Name = "btnDMinus";
            this.btnDMinus.Size = new System.Drawing.Size(79, 46);
            this.btnDMinus.TabIndex = 163;
            this.btnDMinus.Text = "255";
            this.btnDMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDMinus.UseVisualStyleBackColor = true;
            this.btnDMinus.Click += new System.EventHandler(this.btnDMinus_Click);
            // 
            // btnPMinus
            // 
            this.btnPMinus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMinus.ForeColor = System.Drawing.Color.OliveDrab;
            this.btnPMinus.Location = new System.Drawing.Point(53, 128);
            this.btnPMinus.Name = "btnPMinus";
            this.btnPMinus.Size = new System.Drawing.Size(68, 46);
            this.btnPMinus.TabIndex = 162;
            this.btnPMinus.Text = "255";
            this.btnPMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPMinus.UseVisualStyleBackColor = true;
            this.btnPMinus.Click += new System.EventHandler(this.btnPMinus_Click);
            // 
            // btnIPlus
            // 
            this.btnIPlus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIPlus.Location = new System.Drawing.Point(402, 77);
            this.btnIPlus.Name = "btnIPlus";
            this.btnIPlus.Size = new System.Drawing.Size(79, 46);
            this.btnIPlus.TabIndex = 161;
            this.btnIPlus.Text = "I";
            this.btnIPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIPlus.UseVisualStyleBackColor = true;
            this.btnIPlus.Click += new System.EventHandler(this.btnIPlus_Click);
            // 
            // btnDPlus
            // 
            this.btnDPlus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDPlus.Location = new System.Drawing.Point(156, 77);
            this.btnDPlus.Name = "btnDPlus";
            this.btnDPlus.Size = new System.Drawing.Size(79, 46);
            this.btnDPlus.TabIndex = 160;
            this.btnDPlus.Text = "D";
            this.btnDPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDPlus.UseVisualStyleBackColor = true;
            this.btnDPlus.Click += new System.EventHandler(this.btnDPlus_Click);
            // 
            // btnPPlus
            // 
            this.btnPPlus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPPlus.Location = new System.Drawing.Point(53, 77);
            this.btnPPlus.Name = "btnPPlus";
            this.btnPPlus.Size = new System.Drawing.Size(68, 46);
            this.btnPPlus.TabIndex = 159;
            this.btnPPlus.Text = "P";
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
            chartArea2.AxisX.LabelAutoFitMaxFontSize = 8;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.LineWidth = 2;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea2.BackColor = System.Drawing.Color.Black;
            chartArea2.BorderWidth = 2;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 94F;
            chartArea2.Position.Width = 97F;
            chartArea2.Position.X = 3F;
            chartArea2.Position.Y = 6F;
            this.unoChart.ChartAreas.Add(chartArea2);
            legend2.Alignment = System.Drawing.StringAlignment.Far;
            legend2.BackColor = System.Drawing.Color.DimGray;
            legend2.DockedToChartArea = "ChartArea1";
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            legend2.Enabled = false;
            legend2.ForeColor = System.Drawing.Color.White;
            legend2.Name = "Legend1";
            this.unoChart.Legends.Add(legend2);
            this.unoChart.Location = new System.Drawing.Point(-1, 392);
            this.unoChart.Name = "unoChart";
            this.unoChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series3.BackSecondaryColor = System.Drawing.Color.White;
            series3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Color = System.Drawing.Color.Yellow;
            series3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.Name = "S";
            series3.YValuesPerPoint = 6;
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Color = System.Drawing.Color.LightBlue;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "PWM";
            this.unoChart.Series.Add(series3);
            this.unoChart.Series.Add(series4);
            this.unoChart.Size = new System.Drawing.Size(807, 247);
            this.unoChart.TabIndex = 179;
            // 
            // lblSteerAng
            // 
            this.lblSteerAng.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSteerAng.AutoSize = true;
            this.lblSteerAng.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblSteerAng.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerAng.ForeColor = System.Drawing.Color.Yellow;
            this.lblSteerAng.Location = new System.Drawing.Point(129, 392);
            this.lblSteerAng.Name = "lblSteerAng";
            this.lblSteerAng.Size = new System.Drawing.Size(68, 23);
            this.lblSteerAng.TabIndex = 180;
            this.lblSteerAng.Text = "label1";
            // 
            // lblPWM
            // 
            this.lblPWM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPWM.AutoSize = true;
            this.lblPWM.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblPWM.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPWM.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblPWM.Location = new System.Drawing.Point(306, 392);
            this.lblPWM.Name = "lblPWM";
            this.lblPWM.Size = new System.Drawing.Size(68, 23);
            this.lblPWM.TabIndex = 184;
            this.lblPWM.Text = "label5";
            // 
            // btnPlus
            // 
            this.btnPlus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.Location = new System.Drawing.Point(5, 396);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(32, 47);
            this.btnPlus.TabIndex = 185;
            this.btnPlus.Text = "^\r";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinus.Location = new System.Drawing.Point(5, 532);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(32, 47);
            this.btnMinus.TabIndex = 186;
            this.btnMinus.Text = "v";
            this.btnMinus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuto.Location = new System.Drawing.Point(5, 452);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(33, 70);
            this.btnAuto.TabIndex = 187;
            this.btnAuto.Text = "A\r\nu\r\nt\r\no";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(76, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 188;
            this.label1.Text = "Steer";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(254, 393);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 19);
            this.label5.TabIndex = 192;
            this.label5.Text = "PWM";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 13);
            this.label6.TabIndex = 193;
            this.label6.Text = "Relay, Speed, Distance, Steer Angle";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-2, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 25);
            this.label7.TabIndex = 194;
            this.label7.Text = "+";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 25);
            this.label8.TabIndex = 195;
            this.label8.Text = "-";
            // 
            // btnMinPWMMinus
            // 
            this.btnMinPWMMinus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinPWMMinus.Location = new System.Drawing.Point(506, 250);
            this.btnMinPWMMinus.Name = "btnMinPWMMinus";
            this.btnMinPWMMinus.Size = new System.Drawing.Size(79, 51);
            this.btnMinPWMMinus.TabIndex = 197;
            this.btnMinPWMMinus.Text = "255";
            this.btnMinPWMMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMinPWMMinus.UseVisualStyleBackColor = true;
            this.btnMinPWMMinus.Click += new System.EventHandler(this.btnMinPWMMinus_Click);
            // 
            // btnMinPWMPlus
            // 
            this.btnMinPWMPlus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinPWMPlus.Location = new System.Drawing.Point(506, 193);
            this.btnMinPWMPlus.Name = "btnMinPWMPlus";
            this.btnMinPWMPlus.Size = new System.Drawing.Size(79, 51);
            this.btnMinPWMPlus.TabIndex = 196;
            this.btnMinPWMPlus.Text = "Min PWM";
            this.btnMinPWMPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMinPWMPlus.UseVisualStyleBackColor = true;
            this.btnMinPWMPlus.Click += new System.EventHandler(this.btnMinPWMPlus_Click);
            // 
            // btnLookAheadMinus
            // 
            this.btnLookAheadMinus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLookAheadMinus.Location = new System.Drawing.Point(645, 250);
            this.btnLookAheadMinus.Name = "btnLookAheadMinus";
            this.btnLookAheadMinus.Size = new System.Drawing.Size(79, 51);
            this.btnLookAheadMinus.TabIndex = 199;
            this.btnLookAheadMinus.Text = "255";
            this.btnLookAheadMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLookAheadMinus.UseVisualStyleBackColor = true;
            this.btnLookAheadMinus.Click += new System.EventHandler(this.btnLookAheadMinus_Click);
            // 
            // buttonLookAheadPlus
            // 
            this.buttonLookAheadPlus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLookAheadPlus.Location = new System.Drawing.Point(645, 193);
            this.buttonLookAheadPlus.Name = "buttonLookAheadPlus";
            this.buttonLookAheadPlus.Size = new System.Drawing.Size(79, 51);
            this.buttonLookAheadPlus.TabIndex = 198;
            this.buttonLookAheadPlus.Text = "Look Ahead";
            this.buttonLookAheadPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonLookAheadPlus.UseVisualStyleBackColor = true;
            this.buttonLookAheadPlus.Click += new System.EventHandler(this.buttonLookAheadPlus_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 200;
            this.label9.Text = "Proportional";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(281, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 201;
            this.label10.Text = "Overall";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(165, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 202;
            this.label11.Text = "Derivative";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(420, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 203;
            this.label12.Text = "Integral";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(435, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(202, 13);
            this.label18.TabIndex = 207;
            this.label18.Text = "Steer Angle, PWM, Heading, Roll, Switch";
            // 
            // btnMaxSteerMinus
            // 
            this.btnMaxSteerMinus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxSteerMinus.Location = new System.Drawing.Point(156, 250);
            this.btnMaxSteerMinus.Name = "btnMaxSteerMinus";
            this.btnMaxSteerMinus.Size = new System.Drawing.Size(79, 51);
            this.btnMaxSteerMinus.TabIndex = 209;
            this.btnMaxSteerMinus.Text = "255";
            this.btnMaxSteerMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMaxSteerMinus.UseVisualStyleBackColor = true;
            this.btnMaxSteerMinus.Click += new System.EventHandler(this.btnMaxSteerMinus_Click);
            // 
            // btnMaxSteerPlus
            // 
            this.btnMaxSteerPlus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxSteerPlus.Location = new System.Drawing.Point(156, 193);
            this.btnMaxSteerPlus.Name = "btnMaxSteerPlus";
            this.btnMaxSteerPlus.Size = new System.Drawing.Size(79, 51);
            this.btnMaxSteerPlus.TabIndex = 208;
            this.btnMaxSteerPlus.Text = "Max Steer°";
            this.btnMaxSteerPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMaxSteerPlus.UseVisualStyleBackColor = true;
            this.btnMaxSteerPlus.Click += new System.EventHandler(this.btnMaxSteerPlus_Click);
            // 
            // btnMaxAngVelMinus
            // 
            this.btnMaxAngVelMinus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxAngVelMinus.Location = new System.Drawing.Point(403, 250);
            this.btnMaxAngVelMinus.Name = "btnMaxAngVelMinus";
            this.btnMaxAngVelMinus.Size = new System.Drawing.Size(79, 51);
            this.btnMaxAngVelMinus.TabIndex = 212;
            this.btnMaxAngVelMinus.Text = "255";
            this.btnMaxAngVelMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMaxAngVelMinus.UseVisualStyleBackColor = true;
            this.btnMaxAngVelMinus.Click += new System.EventHandler(this.btnMaxAngVelMinus_Click);
            // 
            // btnMaxAngVelPlus
            // 
            this.btnMaxAngVelPlus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxAngVelPlus.Location = new System.Drawing.Point(403, 193);
            this.btnMaxAngVelPlus.Name = "btnMaxAngVelPlus";
            this.btnMaxAngVelPlus.Size = new System.Drawing.Size(79, 51);
            this.btnMaxAngVelPlus.TabIndex = 211;
            this.btnMaxAngVelPlus.Text = "Safe Turn";
            this.btnMaxAngVelPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMaxAngVelPlus.UseVisualStyleBackColor = true;
            this.btnMaxAngVelPlus.Click += new System.EventHandler(this.btnMaxAngVelPlus_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 248);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 25);
            this.label13.TabIndex = 214;
            this.label13.Text = "-";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(2, 196);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(27, 25);
            this.label16.TabIndex = 213;
            this.label16.Text = "+";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(515, 59);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 13);
            this.label17.TabIndex = 217;
            this.label17.Text = "Max Integral";
            // 
            // btnMaxIntegralMinus
            // 
            this.btnMaxIntegralMinus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxIntegralMinus.ForeColor = System.Drawing.Color.Fuchsia;
            this.btnMaxIntegralMinus.Location = new System.Drawing.Point(505, 126);
            this.btnMaxIntegralMinus.Name = "btnMaxIntegralMinus";
            this.btnMaxIntegralMinus.Size = new System.Drawing.Size(79, 46);
            this.btnMaxIntegralMinus.TabIndex = 216;
            this.btnMaxIntegralMinus.Text = "255";
            this.btnMaxIntegralMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMaxIntegralMinus.UseVisualStyleBackColor = true;
            this.btnMaxIntegralMinus.Click += new System.EventHandler(this.btnMaxIntegralMinus_Click);
            // 
            // btnMaxIntegralPlus
            // 
            this.btnMaxIntegralPlus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxIntegralPlus.Location = new System.Drawing.Point(505, 75);
            this.btnMaxIntegralPlus.Name = "btnMaxIntegralPlus";
            this.btnMaxIntegralPlus.Size = new System.Drawing.Size(79, 46);
            this.btnMaxIntegralPlus.TabIndex = 215;
            this.btnMaxIntegralPlus.Text = "Max I";
            this.btnMaxIntegralPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMaxIntegralPlus.UseVisualStyleBackColor = true;
            this.btnMaxIntegralPlus.Click += new System.EventHandler(this.btnMaxIntegralPlus_Click);
            // 
            // btnCountsPerDegreeMinus
            // 
            this.btnCountsPerDegreeMinus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCountsPerDegreeMinus.Location = new System.Drawing.Point(259, 250);
            this.btnCountsPerDegreeMinus.Name = "btnCountsPerDegreeMinus";
            this.btnCountsPerDegreeMinus.Size = new System.Drawing.Size(79, 51);
            this.btnCountsPerDegreeMinus.TabIndex = 219;
            this.btnCountsPerDegreeMinus.Text = "255";
            this.btnCountsPerDegreeMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCountsPerDegreeMinus.UseVisualStyleBackColor = true;
            this.btnCountsPerDegreeMinus.Click += new System.EventHandler(this.btnCountsPerDegreeMinus_Click);
            // 
            // btnCountsPerDegreePlus
            // 
            this.btnCountsPerDegreePlus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCountsPerDegreePlus.Location = new System.Drawing.Point(259, 193);
            this.btnCountsPerDegreePlus.Name = "btnCountsPerDegreePlus";
            this.btnCountsPerDegreePlus.Size = new System.Drawing.Size(79, 51);
            this.btnCountsPerDegreePlus.TabIndex = 218;
            this.btnCountsPerDegreePlus.Text = "Counts Per Deg";
            this.btnCountsPerDegreePlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCountsPerDegreePlus.UseVisualStyleBackColor = true;
            this.btnCountsPerDegreePlus.Click += new System.EventHandler(this.btnCountsPerDegreePlus_Click);
            // 
            // btnSteerWizard
            // 
            this.btnSteerWizard.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSteerWizard.Location = new System.Drawing.Point(645, 75);
            this.btnSteerWizard.Name = "btnSteerWizard";
            this.btnSteerWizard.Size = new System.Drawing.Size(78, 77);
            this.btnSteerWizard.TabIndex = 220;
            this.btnSteerWizard.Text = "Steer Wizard";
            this.btnSteerWizard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSteerWizard.UseVisualStyleBackColor = true;
            this.btnSteerWizard.Click += new System.EventHandler(this.btnSteerWizard_Click);
            // 
            // tbarFreeDriveAngle
            // 
            this.tbarFreeDriveAngle.Location = new System.Drawing.Point(267, 346);
            this.tbarFreeDriveAngle.Maximum = 30;
            this.tbarFreeDriveAngle.Minimum = -30;
            this.tbarFreeDriveAngle.Name = "tbarFreeDriveAngle";
            this.tbarFreeDriveAngle.Size = new System.Drawing.Size(481, 45);
            this.tbarFreeDriveAngle.TabIndex = 224;
            this.tbarFreeDriveAngle.TickFrequency = 10;
            this.tbarFreeDriveAngle.ValueChanged += new System.EventHandler(this.tbarFreeDriveAngle_ValueChanged);
            // 
            // btnFreeDriveZero
            // 
            this.btnFreeDriveZero.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreeDriveZero.Location = new System.Drawing.Point(154, 325);
            this.btnFreeDriveZero.Name = "btnFreeDriveZero";
            this.btnFreeDriveZero.Size = new System.Drawing.Size(96, 51);
            this.btnFreeDriveZero.TabIndex = 226;
            this.btnFreeDriveZero.Text = "> 0 <";
            this.btnFreeDriveZero.UseVisualStyleBackColor = true;
            this.btnFreeDriveZero.Click += new System.EventHandler(this.btnFreeDriveZero_Click);
            // 
            // btnFreeDrive
            // 
            this.btnFreeDrive.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreeDrive.Location = new System.Drawing.Point(28, 325);
            this.btnFreeDrive.Name = "btnFreeDrive";
            this.btnFreeDrive.Size = new System.Drawing.Size(96, 51);
            this.btnFreeDrive.TabIndex = 228;
            this.btnFreeDrive.Text = "Drive";
            this.btnFreeDrive.UseVisualStyleBackColor = true;
            this.btnFreeDrive.Click += new System.EventHandler(this.btnFreeDrive_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(706, 325);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(22, 16);
            this.label20.TabIndex = 229;
            this.label20.Text = "30";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(277, 325);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(27, 16);
            this.label21.TabIndex = 230;
            this.label21.Text = "-30";
            // 
            // lblFreeDriveAngle
            // 
            this.lblFreeDriveAngle.AutoSize = true;
            this.lblFreeDriveAngle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreeDriveAngle.Location = new System.Drawing.Point(497, 322);
            this.lblFreeDriveAngle.Name = "lblFreeDriveAngle";
            this.lblFreeDriveAngle.Size = new System.Drawing.Size(22, 23);
            this.lblFreeDriveAngle.TabIndex = 231;
            this.lblFreeDriveAngle.Text = "0";
            // 
            // FormSteer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(806, 636);
            this.Controls.Add(this.lblFreeDriveAngle);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnFreeDrive);
            this.Controls.Add(this.btnFreeDriveZero);
            this.Controls.Add(this.tbarFreeDriveAngle);
            this.Controls.Add(this.btnSteerWizard);
            this.Controls.Add(this.btnCountsPerDegreeMinus);
            this.Controls.Add(this.btnCountsPerDegreePlus);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnMaxIntegralMinus);
            this.Controls.Add(this.btnMaxIntegralPlus);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnMaxAngVelMinus);
            this.Controls.Add(this.btnMaxAngVelPlus);
            this.Controls.Add(this.btnMaxSteerMinus);
            this.Controls.Add(this.btnMaxSteerPlus);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnLookAheadMinus);
            this.Controls.Add(this.buttonLookAheadPlus);
            this.Controls.Add(this.btnMinPWMMinus);
            this.Controls.Add(this.btnMinPWMPlus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.lblPWM);
            this.Controls.Add(this.lblSteerAng);
            this.Controls.Add(this.unoChart);
            this.Controls.Add(this.btnSteerMinus);
            this.Controls.Add(this.btnSteerPlus);
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
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSteer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auto Steer Configuration";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSteer_FormClosing);
            this.Load += new System.EventHandler(this.FormSteer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.unoChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarFreeDriveAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tboxSerialFromAutoSteer;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tboxSerialToAutoSteer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSteerMinus;
        private System.Windows.Forms.Button btnSteerPlus;
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
        private System.Windows.Forms.Label lblPWM;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnMinPWMMinus;
        private System.Windows.Forms.Button btnMinPWMPlus;
        private System.Windows.Forms.Button btnLookAheadMinus;
        private System.Windows.Forms.Button buttonLookAheadPlus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnMaxSteerMinus;
        private System.Windows.Forms.Button btnMaxSteerPlus;
        private System.Windows.Forms.Button btnMaxAngVelMinus;
        private System.Windows.Forms.Button btnMaxAngVelPlus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnMaxIntegralMinus;
        private System.Windows.Forms.Button btnMaxIntegralPlus;
        private System.Windows.Forms.Button btnCountsPerDegreeMinus;
        private System.Windows.Forms.Button btnCountsPerDegreePlus;
        private System.Windows.Forms.Button btnSteerWizard;
        private System.Windows.Forms.TrackBar tbarFreeDriveAngle;
        private System.Windows.Forms.Button btnFreeDriveZero;
        private System.Windows.Forms.Button btnFreeDrive;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblFreeDriveAngle;
    }
}