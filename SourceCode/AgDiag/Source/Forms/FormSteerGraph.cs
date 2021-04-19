using System;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Drive
{
    public partial class FormSteerGraph : Form
    {
        private readonly FormGPS mf = null;

        //chart data
        private string dataSteerAngle = "0";

        private string dataPWM = "-1";

        public FormSteerGraph(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();

            this.label5.Text = gStr.gsSetPoint;
            this.label1.Text = gStr.gsActual;

            this.Text = gStr.gsSteerChart;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawChart();
        }

        private void DrawChart()
        {
            {
                //word 0 - steerangle, 1 - pwmDisplay
                dataSteerAngle = mf.mc.actualSteerAngleChart.ToString();
                dataPWM = mf.guidanceLineSteerAngle.ToString();

                lblSteerAng.Text = mf.ActualSteerAngle;
                lblPWM.Text = mf.SetSteerAngle;
            }

            //chart data
            Series s = unoChart.Series["S"];
            Series w = unoChart.Series["PWM"];
            double nextX = 1;
            double nextX5 = 1;

            if (s.Points.Count > 0) nextX = s.Points[s.Points.Count - 1].XValue + 1;
            if (w.Points.Count > 0) nextX5 = w.Points[w.Points.Count - 1].XValue + 1;

            unoChart.Series["S"].Points.AddXY(nextX, dataSteerAngle);
            unoChart.Series["PWM"].Points.AddXY(nextX5, dataPWM);

            //if (isScroll)
            {
                while (s.Points.Count > 50)
                {
                    s.Points.RemoveAt(0);
                }
                while (w.Points.Count > 50)
                {
                    w.Points.RemoveAt(0);
                }
                unoChart.ChartAreas[0].RecalculateAxesScale();
            }

            lblGain.Text = ((int)(Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum*0.01) + Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum*0.01))).ToString();
        }

        private void FormSteerGraph_Load(object sender, EventArgs e)
        {
            timer1.Interval = (int)((1 / (double)mf.fixUpdateHz) * 1000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            unoChart.ChartAreas[0].AxisY.Maximum = Double.NaN;
            unoChart.ChartAreas[0].AxisY.Minimum = Double.NaN;
            unoChart.ChartAreas[0].RecalculateAxesScale();
            unoChart.ResetAutoValues();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum) > Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum))
                unoChart.ChartAreas[0].AxisY.Maximum = Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum);
            else unoChart.ChartAreas[0].AxisY.Minimum = Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum) * -1;
            unoChart.ChartAreas[0].AxisY.Minimum *=1.5;
            unoChart.ChartAreas[0].AxisY.Maximum *=1.5;

            unoChart.ChartAreas[0].AxisY.Minimum = (int)unoChart.ChartAreas[0].AxisY.Minimum;
            unoChart.ChartAreas[0].AxisY.Maximum = (int)unoChart.ChartAreas[0].AxisY.Maximum;

            unoChart.ResetAutoValues();

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum) > Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum))
                unoChart.ChartAreas[0].AxisY.Maximum = Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum);
            else unoChart.ChartAreas[0].AxisY.Minimum = Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum) * -1;

            unoChart.ChartAreas[0].AxisY.Minimum *=0.75;
            unoChart.ChartAreas[0].AxisY.Maximum *=0.75;

            if (unoChart.ChartAreas[0].AxisY.Maximum <=100)
            {
                unoChart.ChartAreas[0].AxisY.Maximum =  100;
                unoChart.ChartAreas[0].AxisY.Minimum = -100;
            }

            unoChart.ChartAreas[0].AxisY.Minimum = (int)unoChart.ChartAreas[0].AxisY.Minimum;
            unoChart.ChartAreas[0].AxisY.Maximum = (int)unoChart.ChartAreas[0].AxisY.Maximum;

            unoChart.ResetAutoValues();
        }
    }
}