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

         private void FormSteer_Load(object sender, EventArgs e)
        {
            btnPMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKp].ToString();
            btnIMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKi].ToString();
            btnDMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKd].ToString();
            btnOMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKo].ToString();
            btnSteerMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset].ToString();
            btnMinPWMMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssMinPWM].ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tboxSerialFromAutoSteer.Text = mf.mc.serialRecvAutoSteerStr;
            tboxSerialToAutoSteer.Text = "32766, " + mf.mc.autoSteerData[mf.mc.sdRelay] + ", " + mf.mc.autoSteerData[mf.mc.sdSpeed]
                                    + ", " + mf.guidanceLineDistanceOff + ", " + mf.guidanceLineHeadingDelta;

            //just data
            words = mf.mc.serialRecvAutoSteerStr.Split(',');
            if (words.Length < 5)
            {
                dataSteerAngle = "0";
                dataP = "1";
                dataI = "2";
                dataD = "-1";
                dataPWM = "-2";
            }

            else
            {
                dataSteerAngle = mf.mc.serialRecvAutoSteerStr.Split(',')[0];
                dataP = mf.mc.serialRecvAutoSteerStr.Split(',')[1];
                dataI = mf.mc.serialRecvAutoSteerStr.Split(',')[2];
                dataD = mf.mc.serialRecvAutoSteerStr.Split(',')[3];
                dataPWM = mf.mc.serialRecvAutoSteerStr.Split(',')[4];

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
            mf.mc.autoSteerSettings[mf.mc.ssKp] += 1;
            btnPMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKp].ToString();
            Properties.Settings.Default.setAS_Kp = mf.mc.autoSteerSettings[mf.mc.ssKp];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnPMinus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssKp] -= 1;
            //if (mf.mc.autoSteerSettings[mf.mc.ssKp] == 255) mf.mc.autoSteerSettings[mf.mc.ssKp] = 0;
            btnPMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKp].ToString();
            Properties.Settings.Default.setAS_Kp = mf.mc.autoSteerSettings[mf.mc.ssKp];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnIPlus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssKi] += 1;
            btnIMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKi].ToString();
            Properties.Settings.Default.setAS_Ki = mf.mc.autoSteerSettings[mf.mc.ssKi];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnIMinus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssKi] -= 1;
            //if (mf.mc.autoSteerSettings[mf.mc.ssKi] == 255) mf.mc.autoSteerSettings[mf.mc.ssKi] = 0;
            btnIMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKi].ToString();
            Properties.Settings.Default.setAS_Ki = mf.mc.autoSteerSettings[mf.mc.ssKi];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnDPlus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssKd] += 1;
            btnDMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKd].ToString();
            Properties.Settings.Default.setAS_Kd = mf.mc.autoSteerSettings[mf.mc.ssKd];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnDMinus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssKd] -= 1;
            //if (mf.mc.autoSteerSettings[mf.mc.ssKd] == 255) mf.mc.autoSteerSettings[mf.mc.ssKd] = 0;
            btnDMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKd].ToString();
            Properties.Settings.Default.setAS_Kd = mf.mc.autoSteerSettings[mf.mc.ssKd];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnOPlus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssKo] += 1;
            btnOMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKo].ToString();
            Properties.Settings.Default.setAS_Ko = mf.mc.autoSteerSettings[mf.mc.ssKo];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnOMinus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssKo] -= 1;
            //if (mf.mc.autoSteerSettings[mf.mc.ssKo] == 255) mf.mc.autoSteerSettings[mf.mc.ssKo] = 0;
            btnOMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKo].ToString();
            Properties.Settings.Default.setAS_Ko = mf.mc.autoSteerSettings[mf.mc.ssKo];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnSteerPlus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssSteerOffset] += 1;
            //if (mf.modcom.autoSteerSettings[6] == 255) mf.modcom.autoSteerSettings[6] = 0;
            btnSteerMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset].ToString();
            Properties.Settings.Default.setAS_steerAngleOffset = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnSteerMinus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssSteerOffset] -= 1;
            //if (mf.modcom.autoSteerSettings[mf.mc.ssSteerOffset] == 0) mf.modcom.autoSteerSettings[mf.mc.ssSteerOffset] = 255;
            btnSteerMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset].ToString();
            Properties.Settings.Default.setAS_steerAngleOffset = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnMinPWMPlus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssMinPWM] += 1;
            btnMinPWMMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssMinPWM].ToString();
            Properties.Settings.Default.setAS_minSteerPWM = mf.mc.autoSteerSettings[mf.mc.ssMinPWM];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();

        }

        private void btnMinPWMMinus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssMinPWM] -= 1;
            btnMinPWMMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssMinPWM].ToString();
            Properties.Settings.Default.setAS_minSteerPWM = mf.mc.autoSteerSettings[mf.mc.ssMinPWM];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();

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