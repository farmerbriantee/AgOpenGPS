using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AgOpenGPS
{
    public partial class FormHeadingGraph : Form
    {
        private readonly FormGPS mf = null;

        //chart data
        private string dataSteerAngle = "0";

        private string dataPWM = "-1";

        public FormHeadingGraph(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();

            this.label5.Text = gStr.gsSetPoint;
            this.label1.Text = gStr.gsActual;

            this.Text = "Heading Chart";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawChart();
        }

        private void DrawChart()
        {
            {
                //word 0 - steerangle, 1 - pwmDisplay
                dataSteerAngle = (glm.toDegrees(mf.gpsHeading)).ToString("N1");
                dataPWM = (glm.toDegrees(mf.imuCorrected)).ToString("N1");

                lblSteerAng.Text = dataSteerAngle;
                lblPWM.Text = dataPWM;

                lblDiff.Text = (glm.toDegrees(mf.gpsHeading - mf.imuCorrected)).ToString("N2");
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
                while (s.Points.Count > 100)
                {
                    s.Points.RemoveAt(0);
                }
                while (w.Points.Count > 100)
                {
                    w.Points.RemoveAt(0);
                }
                unoChart.ResetAutoValues();
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
    }
}