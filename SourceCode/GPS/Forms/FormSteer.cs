using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AgOpenGPS
{
    public partial class FormSteer : Form
    {
        private FormGPS mf = null;
        private string[] words;

        string dataSteerAngle = "2";
        string dataP = "4";
        string dataI = "6";
        string dataD = "-6";
        string dataPWM = "-10";

        public decimal ReturnValue1 { get; set; }

        public FormSteer(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tboxSerialFromAutoSteer.Text = mf.modcom.serialRecvAutoSteerStr;
            tboxSerialToAutoSteer.Text = mf.modcom.autoSteerControl[2] + ", " + mf.modcom.autoSteerControl[3]
                                    + ", " + mf.guidanceLineDistanceOff + ", " + mf.guidanceLineHeadingDelta;

            //just data
            words = mf.modcom.serialRecvAutoSteerStr.Split(',');
            if (words.Length < 5)
            {
                dataSteerAngle = "2";
                dataP = "4";
                dataI = "6";
                dataD = "-6";
                dataPWM = "-10";
            }

            else
            {
                dataSteerAngle = mf.modcom.serialRecvAutoSteerStr.Split(',')[0];
                dataP = mf.modcom.serialRecvAutoSteerStr.Split(',')[1];
                dataI = mf.modcom.serialRecvAutoSteerStr.Split(',')[2];
                dataD = mf.modcom.serialRecvAutoSteerStr.Split(',')[3];
                dataPWM = mf.modcom.serialRecvAutoSteerStr.Split(',')[4];

                lblSteerAng.Text = dataSteerAngle;
                lblP.Text = dataP;
                lblI.Text = dataI;
                lblD.Text = dataD;
                lblPWM.Text = dataPWM;
            }

            //if (!paused)
            {
                Series s = unoChart.Series["S"];
                Series t = unoChart.Series["P"];
                Series u = unoChart.Series["I"];
                Series v = unoChart.Series["D"];
                Series w = unoChart.Series["PWM"];
                double nextX = 1;
                double nextX2 = 1;
                double nextX3 = 1;
                double nextX4 = 1;
                double nextX5 = 1;

                if (s.Points.Count > 0) nextX = s.Points[s.Points.Count - 1].XValue + 1;
                if (t.Points.Count > 0) nextX2 = t.Points[t.Points.Count - 1].XValue + 1;
                if (u.Points.Count > 0) nextX3 = u.Points[u.Points.Count - 1].XValue + 1;
                if (v.Points.Count > 0) nextX4 = u.Points[u.Points.Count - 1].XValue + 1;
                if (w.Points.Count > 0) nextX5 = u.Points[u.Points.Count - 1].XValue + 1;

                this.unoChart.Series["S"].Points.AddXY(nextX, dataSteerAngle);
                this.unoChart.Series["P"].Points.AddXY(nextX2, dataP);
                this.unoChart.Series["I"].Points.AddXY(nextX3, dataI);
                this.unoChart.Series["D"].Points.AddXY(nextX4, dataD);
                this.unoChart.Series["PWM"].Points.AddXY(nextX5, dataPWM);

                //if (isScroll)
                {
                    while (s.Points.Count > 50)
                    {
                        s.Points.RemoveAt(0);
                    }
                    while (t.Points.Count > 50)
                    {
                        t.Points.RemoveAt(0);
                    }
                    while (u.Points.Count > 50)
                    {
                        u.Points.RemoveAt(0);
                    }
                    while (v.Points.Count > 50)
                    {
                        v.Points.RemoveAt(0);
                    }
                    while (w.Points.Count > 50)
                    {
                        w.Points.RemoveAt(0);
                    }
                    unoChart.ResetAutoValues();
                }
            }


        }

        //Send to Autosteer to adjust PIDO values, LSB is up or down
        private void btnPPlus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[2] += 1;
            lblPValue.Text = mf.modcom.autoSteerSettings[2].ToString();
            Properties.Settings.Default.setAS_Kp = mf.modcom.autoSteerSettings[2];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnPMinus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[2] -= 1;
            if (mf.modcom.autoSteerSettings[2] == 255) mf.modcom.autoSteerSettings[2] = 0;
            lblPValue.Text = mf.modcom.autoSteerSettings[2].ToString();
            Properties.Settings.Default.setAS_Kp = mf.modcom.autoSteerSettings[2];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnIPlus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[3] += 1;
            lblIValue.Text = mf.modcom.autoSteerSettings[3].ToString();
            Properties.Settings.Default.setAS_Ki = mf.modcom.autoSteerSettings[3];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnIMinus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[3] -= 1;
            if (mf.modcom.autoSteerSettings[3] == 255) mf.modcom.autoSteerSettings[3] = 0;
            lblIValue.Text = mf.modcom.autoSteerSettings[3].ToString();
            Properties.Settings.Default.setAS_Ki = mf.modcom.autoSteerSettings[3];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnDPlus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[4] += 1;
            lblDValue.Text = mf.modcom.autoSteerSettings[4].ToString();
            Properties.Settings.Default.setAS_Kd = mf.modcom.autoSteerSettings[4];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnDMinus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[4] -= 1;
            if (mf.modcom.autoSteerSettings[4] == 255) mf.modcom.autoSteerSettings[4] = 0;
            lblDValue.Text = mf.modcom.autoSteerSettings[4].ToString();
            Properties.Settings.Default.setAS_Kd = mf.modcom.autoSteerSettings[4];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnOPlus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[5] += 1;
            lblOValue.Text = mf.modcom.autoSteerSettings[5].ToString();
            Properties.Settings.Default.setAS_Ko = mf.modcom.autoSteerSettings[5];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnOMinus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[5] -= 1;
            if (mf.modcom.autoSteerSettings[5] == 255) mf.modcom.autoSteerSettings[5] = 0;
            lblOValue.Text = mf.modcom.autoSteerSettings[5].ToString();
            Properties.Settings.Default.setAS_Ko = mf.modcom.autoSteerSettings[5];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnMaxIntErrPlus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[6] += 1;
            lblMaxIntErr.Text = mf.modcom.autoSteerSettings[6].ToString();
            Properties.Settings.Default.setAS_maxIntError = mf.modcom.autoSteerSettings[6];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnMaxIntErrMinus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[6] -= 1;
            if (mf.modcom.autoSteerSettings[6] == 255) mf.modcom.autoSteerSettings[6] = 0;
            lblMaxIntErr.Text = mf.modcom.autoSteerSettings[6].ToString();
            Properties.Settings.Default.setAS_maxIntError = mf.modcom.autoSteerSettings[6];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void FormSteer_Load(object sender, EventArgs e)
        {
            lblPValue.Text = mf.modcom.autoSteerSettings[2].ToString();
            lblIValue.Text = mf.modcom.autoSteerSettings[3].ToString();
            lblDValue.Text = mf.modcom.autoSteerSettings[4].ToString();
            lblOValue.Text = mf.modcom.autoSteerSettings[5].ToString();
            lblMaxIntErr.Text = mf.modcom.autoSteerSettings[6].ToString();
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            unoChart.ChartAreas[0].AxisY.Maximum = Double.NaN;
            unoChart.ChartAreas[0].RecalculateAxesScale();
            unoChart.ResetAutoValues();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum) > Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum))
                unoChart.ChartAreas[0].AxisY.Maximum = Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum);
            else unoChart.ChartAreas[0].AxisY.Minimum = Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum) *-1;
            unoChart.ChartAreas[0].AxisY.Minimum -= 50;
            unoChart.ChartAreas[0].AxisY.Maximum += 50;
            unoChart.ResetAutoValues();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum) > Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum))
                unoChart.ChartAreas[0].AxisY.Maximum = Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum);
            else unoChart.ChartAreas[0].AxisY.Minimum = Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum) * -1;

            if (unoChart.ChartAreas[0].AxisY.Maximum < 51)
            {
                unoChart.ChartAreas[0].AxisY.Maximum = 55;
                unoChart.ChartAreas[0].AxisY.Minimum = -55;
            }
            unoChart.ChartAreas[0].AxisY.Minimum += 50;
            unoChart.ChartAreas[0].AxisY.Maximum -= 50;
            unoChart.ResetAutoValues();

        } 
    }
}
