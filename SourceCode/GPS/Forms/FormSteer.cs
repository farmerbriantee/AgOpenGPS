using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AgOpenGPS
{
    public partial class FormSteer : Form
    {
        readonly FormGPS mf = null;
        private string[] words;

        //chart data
        private string dataSteerAngle = "0";
        private string dataP = "4";
        private string dataI = "6";
        private string dataD = "-6";
        private string dataPWM = "-10";

        //the trackbar angle for free drive
        private Int16 driveFreeSteerAngle = 0;

        //Form stuff
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
            btnLookAheadMinus.Text = mf.vehicle.goalPointLookAhead.ToString();
            btnMaxAngVelMinus.Text = mf.vehicle.maxAngularVelocity.ToString();
            btnMaxSteerMinus.Text = mf.vehicle.maxSteerAngle.ToString();
            btnMaxIntegralMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssMaxIntegral].ToString();
            btnCountsPerDegreeMinus.Text = ((double)(mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree]) / 10).ToString();

            //make sure free drive is off
            btnFreeDrive.BackColor = Color.Red;
            mf.isInFreeDriveMode = false;
            btnFreeDriveZero.Enabled = false;
            tbarFreeDriveAngle.Enabled = false;
            tbarFreeDriveAngle.Value = 0;
            driveFreeSteerAngle = 0;
            lblFreeDriveAngle.Text = "0";
        }

        private void FormSteer_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.isInFreeDriveMode = false;
        }

        //Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!mf.isInFreeDriveMode)
            {
                //normal mode
                tboxSerialFromAutoSteer.Text = mf.mc.serialRecvAutoSteerStr;
                tboxSerialToAutoSteer.Text = "32766, " + mf.mc.autoSteerData[mf.mc.sdRelay] + ", " + mf.mc.autoSteerData[mf.mc.sdSpeed]
                                        + ", " + mf.guidanceLineDistanceOff + ", " + mf.guidanceLineSteerAngle;
            }
            else
            {
                //free drive mode
                mf.mc.autoSteerData[mf.mc.sdSteerAngleHi] = (byte)((driveFreeSteerAngle * 10) >> 8);
                mf.mc.autoSteerData[mf.mc.sdSteerAngleLo] = (byte)(driveFreeSteerAngle * 10);

                tboxSerialFromAutoSteer.Text = mf.mc.serialRecvAutoSteerStr;
                tboxSerialToAutoSteer.Text = "32766, " + mf.mc.autoSteerData[mf.mc.sdRelay] + ", " + mf.mc.autoSteerData[mf.mc.sdSpeed]
                                        + ", " + mf.mc.autoSteerData[mf.mc.sdDistanceLo] + ", " + driveFreeSteerAngle;
                //tboxSerialToAutoSteer.Text = $"32766, {mf.mc.autoSteerData[mf.mc.sdRelay]}, {mf.mc.autoSteerData[mf.mc.sdSpeed]}, {mf.mc.autoSteerData[mf.mc.sdDistanceLo]}, {driveFreeSteerAngle}";
            }

            DrawChart();
        }

        //Buttons
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
            btnOMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKo].ToString();
            Properties.Settings.Default.setAS_Ko = mf.mc.autoSteerSettings[mf.mc.ssKo];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void buttonLookAheadPlus_Click(object sender, EventArgs e)
        {
            mf.vehicle.goalPointLookAhead += 0.5;
            btnLookAheadMinus.Text = mf.vehicle.goalPointLookAhead.ToString();
            Properties.Settings.Default.setVehicle_goalPointLookAhead = mf.vehicle.goalPointLookAhead;
            Properties.Settings.Default.Save();
        }

        private void btnLookAheadMinus_Click(object sender, EventArgs e)
        {
            mf.vehicle.goalPointLookAhead -= 0.5;
            if (mf.vehicle.goalPointLookAhead < 1.0) mf.vehicle.goalPointLookAhead = 1.0;
            btnLookAheadMinus.Text = mf.vehicle.goalPointLookAhead.ToString();
            Properties.Settings.Default.setVehicle_goalPointLookAhead = mf.vehicle.goalPointLookAhead;
            Properties.Settings.Default.Save();
        }

        private void btnMaxSteerPlus_Click(object sender, EventArgs e)
        {
            mf.vehicle.maxSteerAngle += 1;
            btnMaxSteerMinus.Text = mf.vehicle.maxSteerAngle.ToString();
            Properties.Settings.Default.setVehicle_maxSteerAngle = mf.vehicle.maxSteerAngle;
            Properties.Settings.Default.Save();
        }

        private void btnMaxSteerMinus_Click(object sender, EventArgs e)
        {
            mf.vehicle.maxSteerAngle -= 1;
            if (mf.vehicle.maxSteerAngle < 3) mf.vehicle.maxSteerAngle = 3;
            btnMaxSteerMinus.Text = mf.vehicle.maxSteerAngle.ToString();
            Properties.Settings.Default.setVehicle_maxSteerAngle = mf.vehicle.maxSteerAngle;
            Properties.Settings.Default.Save();
        }

        private void btnMaxAngVelPlus_Click(object sender, EventArgs e)
        {
            mf.vehicle.maxAngularVelocity += 0.1;
            btnMaxAngVelMinus.Text = mf.vehicle.maxAngularVelocity.ToString();
            Properties.Settings.Default.setVehicle_maxAngularVelocity = mf.vehicle.maxAngularVelocity;
            Properties.Settings.Default.Save();
        }

        private void btnMaxAngVelMinus_Click(object sender, EventArgs e)
        {
            mf.vehicle.maxAngularVelocity -= 0.1;
            if (mf.vehicle.maxAngularVelocity < 0.2) mf.vehicle.maxAngularVelocity = 0.2;
            btnMaxAngVelMinus.Text = mf.vehicle.maxAngularVelocity.ToString();
            Properties.Settings.Default.setVehicle_maxAngularVelocity = mf.vehicle.maxAngularVelocity;
            Properties.Settings.Default.Save();
        }

        private void btnSteerPlus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssSteerOffset] += 1;
            btnSteerMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset].ToString();
            Properties.Settings.Default.setAS_steerAngleOffset = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnSteerMinus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssSteerOffset] -= 1;
            if (mf.mc.autoSteerSettings[mf.mc.ssSteerOffset] < 1) mf.mc.autoSteerSettings[mf.mc.ssSteerOffset] = 1;
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
            if (mf.mc.autoSteerSettings[mf.mc.ssMinPWM] < 1) mf.mc.autoSteerSettings[mf.mc.ssMinPWM] = 1;
            btnMinPWMMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssMinPWM].ToString();
            Properties.Settings.Default.setAS_minSteerPWM = mf.mc.autoSteerSettings[mf.mc.ssMinPWM];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnMaxIntegralPlus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssMaxIntegral] += 1;
            btnMaxIntegralMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssMaxIntegral].ToString();
            Properties.Settings.Default.setAS_maxIntegral = mf.mc.autoSteerSettings[mf.mc.ssMaxIntegral];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnMaxIntegralMinus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssMaxIntegral] -= 1;
            if (mf.mc.autoSteerSettings[mf.mc.ssMaxIntegral] < 2) mf.mc.autoSteerSettings[mf.mc.ssMaxIntegral] = 2;
            btnMaxIntegralMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssMaxIntegral].ToString();
            Properties.Settings.Default.setAS_maxIntegral = mf.mc.autoSteerSettings[mf.mc.ssMaxIntegral];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnCountsPerDegreePlus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree] += 1;
            btnCountsPerDegreeMinus.Text = ((double)(mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree]) / 10).ToString(CultureInfo.InvariantCulture);
            Properties.Settings.Default.setAS_countsPerDegree = mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnCountsPerDegreeMinus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree] -= 1;
            if (mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree] < 1) mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree] = 1;
            btnCountsPerDegreeMinus.Text = ((double)(mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree]) / 10).ToString();
            Properties.Settings.Default.setAS_countsPerDegree = mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        //FREE DRIVE SECTION
        private void btnSteerWizard_Click(object sender, EventArgs e)
        {
            if (mf.isJobStarted)
            {
                var form = new FormTimedMessage(3000, "Ooops, Field is Open", "**** Close Field First ****");
                form.Show();
                return;
            }

            WindowState = FormWindowState.Minimized;
            Hide();

            using (var form = new FormWizardSteer(mf))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    btnCountsPerDegreeMinus.Text = ((double)(mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree]) / 10).ToString();
                    btnSteerMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset].ToString();
                    mf.AutoSteerSettingsOutToPort();
                }
                else
                {
                    btnCountsPerDegreeMinus.Text = ((double)(mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree]) / 10).ToString();
                    btnSteerMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset].ToString();
                    mf.AutoSteerSettingsOutToPort();
                }
            }

            //restore the autosteer window
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void tbarFreeDriveAngle_ValueChanged(object sender, EventArgs e)
        {
            driveFreeSteerAngle = (Int16)tbarFreeDriveAngle.Value;
            lblFreeDriveAngle.Text = Convert.ToString(driveFreeSteerAngle);
            tbarFreeDriveAngle.Value = driveFreeSteerAngle;
        }

        private void btnFreeDrive_Click(object sender, EventArgs e)
        {
            if (mf.isInFreeDriveMode)
            {
                //turn OFF free drive mode
                btnFreeDrive.BackColor = Color.Red;
                mf.isInFreeDriveMode = false;
                btnFreeDriveZero.Enabled = false;
                tbarFreeDriveAngle.Enabled = false;
                tbarFreeDriveAngle.Value = 0;
                driveFreeSteerAngle = 0;
                lblFreeDriveAngle.Text = "0";
            }
            else
            {
                //turn ON free drive mode
                btnFreeDrive.BackColor = Color.LimeGreen;
                mf.isInFreeDriveMode = true;
                btnFreeDriveZero.Enabled = true;
                tbarFreeDriveAngle.Enabled = true;
                tbarFreeDriveAngle.Value = 0;
                driveFreeSteerAngle = 0;
                lblFreeDriveAngle.Text = "0";
            }
        }

        private void btnFreeDriveZero_Click(object sender, EventArgs e)
        {
            driveFreeSteerAngle = 0;
            tbarFreeDriveAngle.Value = driveFreeSteerAngle;
            lblFreeDriveAngle.Text = Convert.ToString(driveFreeSteerAngle);
        }

        //chart
        private void DrawChart()
        {
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

            //chart data            
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

            unoChart.Series["S"].Points.AddXY(nextX, dataSteerAngle);
            unoChart.Series["P"].Points.AddXY(nextX2, dataP);
            unoChart.Series["I"].Points.AddXY(nextX3, dataI);
            unoChart.Series["D"].Points.AddXY(nextX4, dataD);
            unoChart.Series["PWM"].Points.AddXY(nextX5, dataPWM);

            //if (isScroll)
            {
                while (s.Points.Count > 100)
                {
                    s.Points.RemoveAt(0);
                }
                while (t.Points.Count > 100)
                {
                    t.Points.RemoveAt(0);
                }
                while (u.Points.Count > 100)
                {
                    u.Points.RemoveAt(0);
                }
                while (v.Points.Count > 100)
                {
                    v.Points.RemoveAt(0);
                }
                while (w.Points.Count > 100)
                {
                    w.Points.RemoveAt(0);
                }
                unoChart.ResetAutoValues();
            }
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

            if (unoChart.ChartAreas[0].AxisY.Maximum <= 51)
            {
                unoChart.ChartAreas[0].AxisY.Maximum = 60;
                unoChart.ChartAreas[0].AxisY.Minimum = -60;
            }
            unoChart.ChartAreas[0].AxisY.Minimum += 50;
            unoChart.ChartAreas[0].AxisY.Maximum -= 50;
            unoChart.ResetAutoValues();
        }
    }
}