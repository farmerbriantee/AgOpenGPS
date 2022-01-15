using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AgOpenGPS
{
    public partial class FormCorrection : Form
    {
        private readonly FormGPS mf = null;

        //chart data
        private string roll = "0.1";
        private string east = "0";

        private bool isScroll = true;

        public FormCorrection(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawChart();
        }

        private void DrawChart()
        {
            {
                roll = (mf.ahrs.imuRoll).ToString("N2");
                east = (mf.pn.fix.easting * 10).ToString("N2");

                lblRoll.Text = (mf.ahrs.imuRoll).ToString("N2"); ;
                lblEast.Text = (mf.pn.fix.easting).ToString("N2"); ;
            }

            if (isScroll)
            {
                //chart data
                Series r = rollChart.Series["Ro"];
                Series t = rollChart.Series["Ze"];

                double nextx6 = 1;
                double nextx7 = 1;


                if (r.Points.Count > 0) nextx6 = r.Points[r.Points.Count - 1].XValue + 1;
                if (t.Points.Count > 0) nextx7 = t.Points[t.Points.Count - 1].XValue + 1;

                rollChart.Series["Ro"].Points.AddXY(nextx6, roll);
                rollChart.Series["Ze"].Points.AddXY(nextx7, east);

                while (r.Points.Count > 100)
                {
                    r.Points.RemoveAt(0);
                }
                while (t.Points.Count > 100)
                {
                    t.Points.RemoveAt(0);
                }
                rollChart.ChartAreas[0].RecalculateAxesScale();
            }
        }

        private void FormSteerGraph_Load(object sender, EventArgs e)
        {
            timer1.Interval = (int)((1 / (double)mf.fixUpdateHz) * 1000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //private void btnAuto_Click(object sender, EventArgs e)
        //{
        //    unoChart.ChartAreas[0].AxisY.Maximum = Double.NaN;
        //    unoChart.ChartAreas[0].AxisY.Minimum = Double.NaN;
        //    unoChart.ChartAreas[0].RecalculateAxesScale();
        //    unoChart.ResetAutoValues();
        //}

        //private void btnPlus_Click(object sender, EventArgs e)
        //{
        //    if (Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum) > Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum))
        //        unoChart.ChartAreas[0].AxisY.Maximum = Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum);
        //    else unoChart.ChartAreas[0].AxisY.Minimum = Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum) * -1;
        //    unoChart.ChartAreas[0].AxisY.Minimum *=1.5;
        //    unoChart.ChartAreas[0].AxisY.Maximum *=1.5;

        //    unoChart.ChartAreas[0].AxisY.Minimum = (int)unoChart.ChartAreas[0].AxisY.Minimum;
        //    unoChart.ChartAreas[0].AxisY.Maximum = (int)unoChart.ChartAreas[0].AxisY.Maximum;

        //    unoChart.ResetAutoValues();

        //}

        //private void btnMinus_Click(object sender, EventArgs e)
        //{
        //    if (Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum) > Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum))
        //        unoChart.ChartAreas[0].AxisY.Maximum = Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum);
        //    else unoChart.ChartAreas[0].AxisY.Minimum = Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum) * -1;

        //    unoChart.ChartAreas[0].AxisY.Minimum *=0.75;
        //    unoChart.ChartAreas[0].AxisY.Maximum *=0.75;

        //    if (unoChart.ChartAreas[0].AxisY.Maximum <=10)
        //    {
        //        unoChart.ChartAreas[0].AxisY.Maximum =  10;
        //        unoChart.ChartAreas[0].AxisY.Minimum = -10;
        //    }

        //    unoChart.ChartAreas[0].AxisY.Minimum = (int)unoChart.ChartAreas[0].AxisY.Minimum;
        //    unoChart.ChartAreas[0].AxisY.Maximum = (int)unoChart.ChartAreas[0].AxisY.Maximum;

        //    unoChart.ResetAutoValues();
        //}

        private void btnScroll_Click(object sender, EventArgs e)
        {
            isScroll = !isScroll;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            //roond = (int)(mf.fixedEasting);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}