namespace AgOpenGPS
{
    partial class FormCorrection 
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rollChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblRoll = new System.Windows.Forms.Label();
            this.lblEast = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOst = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRollDegrees = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rollChart)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rollChart
            // 
            this.rollChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rollChart.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None;
            this.rollChart.BackColor = System.Drawing.Color.Black;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.LineWidth = 2;
            chartArea1.AxisY.MajorGrid.Interval = 2D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.Maximum = 10D;
            chartArea1.AxisY.Minimum = -10D;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.rollChart.ChartAreas.Add(chartArea1);
            this.rollChart.Location = new System.Drawing.Point(9, 8);
            this.rollChart.Margin = new System.Windows.Forms.Padding(0);
            this.rollChart.Name = "rollChart";
            this.rollChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series1.Color = System.Drawing.Color.Red;
            series1.Name = "Ro";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series2.Color = System.Drawing.Color.Lime;
            series2.Name = "Ze";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series3.Color = System.Drawing.Color.Cyan;
            series3.Name = "Oe";
            this.rollChart.Series.Add(series1);
            this.rollChart.Series.Add(series2);
            this.rollChart.Series.Add(series3);
            this.rollChart.Size = new System.Drawing.Size(810, 498);
            this.rollChart.TabIndex = 241;
            this.rollChart.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // lblRoll
            // 
            this.lblRoll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRoll.AutoSize = true;
            this.lblRoll.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblRoll.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoll.ForeColor = System.Drawing.Color.Red;
            this.lblRoll.Location = new System.Drawing.Point(535, 512);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(85, 29);
            this.lblRoll.TabIndex = 245;
            this.lblRoll.Text = "label5";
            this.lblRoll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEast
            // 
            this.lblEast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEast.AutoSize = true;
            this.lblEast.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblEast.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEast.ForeColor = System.Drawing.Color.Lime;
            this.lblEast.Location = new System.Drawing.Point(311, 512);
            this.lblEast.Name = "lblEast";
            this.lblEast.Size = new System.Drawing.Size(85, 29);
            this.lblEast.TabIndex = 247;
            this.lblEast.Text = "label5";
            this.lblEast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoEllipsis = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Chartreuse;
            this.label5.Location = new System.Drawing.Point(216, 498);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 55);
            this.label5.TabIndex = 249;
            this.label5.Text = "Corrected Easting";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(440, 501);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 46);
            this.label1.TabIndex = 250;
            this.label1.Text = "Correction Distance";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOst
            // 
            this.lblOst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOst.AutoSize = true;
            this.lblOst.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblOst.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOst.ForeColor = System.Drawing.Color.Cyan;
            this.lblOst.Location = new System.Drawing.Point(104, 513);
            this.lblOst.Name = "lblOst";
            this.lblOst.Size = new System.Drawing.Size(85, 29);
            this.lblOst.TabIndex = 251;
            this.lblOst.Text = "label5";
            this.lblOst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoEllipsis = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Cyan;
            this.label3.Location = new System.Drawing.Point(24, 513);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 29);
            this.label3.TabIndex = 252;
            this.label3.Text = "Antenna";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(5, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 29);
            this.label2.TabIndex = 253;
            this.label2.Text = "0.5";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoEllipsis = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Cyan;
            this.label4.Location = new System.Drawing.Point(5, 451);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 29);
            this.label4.TabIndex = 254;
            this.label4.Text = "-0.5";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoEllipsis = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightSalmon;
            this.label6.Location = new System.Drawing.Point(644, 502);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 47);
            this.label6.TabIndex = 256;
            this.label6.Text = "Roll Degrees";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRollDegrees
            // 
            this.lblRollDegrees.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRollDegrees.AutoSize = true;
            this.lblRollDegrees.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblRollDegrees.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRollDegrees.ForeColor = System.Drawing.Color.LightSalmon;
            this.lblRollDegrees.Location = new System.Drawing.Point(727, 510);
            this.lblRollDegrees.Name = "lblRollDegrees";
            this.lblRollDegrees.Size = new System.Drawing.Size(85, 29);
            this.lblRollDegrees.TabIndex = 255;
            this.lblRollDegrees.Text = "label5";
            this.lblRollDegrees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormCorrection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(824, 550);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblRollDegrees);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOst);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEast);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblRoll);
            this.Controls.Add(this.rollChart);
            this.Location = new System.Drawing.Point(30, 30);
            this.Name = "FormCorrection";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Roll Correction Graph";
            this.Load += new System.EventHandler(this.FormSteerGraph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rollChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart rollChart;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.Label lblEast;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOst;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRollDegrees;
    }
}