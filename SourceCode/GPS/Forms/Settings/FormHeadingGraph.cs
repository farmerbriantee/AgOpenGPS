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

            this.Text = "Heading Chart";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawChart();
        }

        private void DrawChart()
        {

            dataSteerAngle = "0";

            lblSteerAng.Text = (glm.toDegrees(mf.gpsHeading)).ToString("N1");
            lblPWM.Text = (glm.toDegrees(mf.imuCorrected)).ToString("N1");

            lblDiff.Text = (glm.toDegrees(mf.gpsHeading - mf.imuCorrected)).ToString("N2");
            dataPWM = lblDiff.Text;


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