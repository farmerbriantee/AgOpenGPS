//Please, if you use this give me some credit
//Copyright BrianTee, copy right out of it.

using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AgOpenGPS
{
    public partial class FormGPSData : Form
    {
        private readonly FormGPS mf = null;
        private bool isBtnRollOn = true;
        //chart data
        private string eastValue = "0";
        private string eastAdjValue = "-1";
        private string rollValue = "1";

        public FormGPSData(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //all the fixings and position
            lblZone.Text = mf.Zone;
            if (mf.isJobStarted)
            {
                lblEasting.Text = Math.Round(mf.pn.easting, 1).ToString();
                lblNorthing.Text = Math.Round(mf.pn.northing, 1).ToString();
            }
            else
            {
                lblEasting.Text = ((int)mf.pn.actualEasting).ToString();
                lblNorthing.Text = ((int)mf.pn.actualNorthing).ToString();
            }

            lblLatitude.Text = mf.Latitude;
            lblLongitude.Text = mf.Longitude;
            lblAltitude.Text = mf.Altitude;

            //other sat and GPS info
            lblFixQuality.Text = mf.FixQuality;
            lblSatsTracked.Text = mf.SatsTracked;
            lblStatus.Text = mf.Status;
            lblHDOP.Text = mf.HDOP;

            tboxSerialFromRelay.Text = mf.mc.serialRecvRelayRateStr;
            tboxSerialToRelay.Text = mf.mc.relayRateData[0] + "," + mf.mc.relayRateData[1]
                 + "," + mf.mc.relayRateData[2] + "," + mf.mc.relayRateData[3] //relay and speed x 4
                 + "," + mf.mc.relayRateData[4] + "," + mf.mc.relayRateData[5] + "," + mf.mc.relayRateData[6]; //setpoint hi lo
            tboxNMEASerial.Text = mf.recvSentenceSettings;
            //tboxNMEASerial.Text = mainForm.pn.rawBuffer;

            tboxSerialFromAutoSteer.Text = mf.mc.serialRecvAutoSteerStr;
            tboxSerialToAutoSteer.Text = "32766, " + mf.mc.autoSteerData[mf.mc.sdRelay] + ", " + mf.mc.autoSteerData[mf.mc.sdSpeed]
                                    + ", " + mf.guidanceLineDistanceOff + ", " + mf.guidanceLineSteerAngle;

            DrawChart();
        }

        //chart gain control
        private int yMax;

        private int yMin;

        private void DrawChart()
        {
            //min,max
            yMax = (int)(mf.eastingAfterRoll + 2);
            yMin = (int)(mf.eastingAfterRoll - 2);

            #pragma warning disable CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
            eastAdjValue = mf.eastingAfterRoll.ToString("N2");
            eastValue = mf.eastingBeforeRoll.ToString("N2");
            rollValue = ((mf.rollUsed/10) + yMin + 2).ToString("N2");
            lblEast.Text = eastValue;
            lblAdjEast.Text = eastAdjValue;
            lblRoll.Text = mf.rollUsed.ToString("N2");
            #pragma warning restore CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception

            //chart data
            Series s = unoChart.Series["East"];
            Series w = unoChart.Series["AdjEast"];
            Series t = unoChart.Series["Roll"];
            double nextX = 1;
            double nextX1 = 1;
            double nextX5 = 1;
            if (isBtnRollOn)
            {
                if (s.Points.Count > 0) nextX = s.Points[s.Points.Count - 1].XValue + 1;
                if (w.Points.Count > 0) nextX5 = w.Points[w.Points.Count - 1].XValue + 1;
                if (t.Points.Count > 0) nextX1 = w.Points[t.Points.Count - 1].XValue + 1;

                unoChart.Series["East"].Points.AddXY(nextX, eastValue);
                unoChart.Series["AdjEast"].Points.AddXY(nextX5, eastAdjValue);
                unoChart.Series["Roll"].Points.AddXY(nextX1, rollValue);
            }

            while (s.Points.Count > 100) s.Points.RemoveAt(0);
            while (w.Points.Count > 100) w.Points.RemoveAt(0);
            while (t.Points.Count > 100) t.Points.RemoveAt(0);

            unoChart.ChartAreas[0].AxisY.Maximum = yMax;
            unoChart.ChartAreas[0].AxisY.Minimum = yMin;

            unoChart.ResetAutoValues();
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            isBtnRollOn = !isBtnRollOn;
        }
    }
}