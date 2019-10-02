//Please, if you use this give me some credit
//Copyright BrianTee, copy right out of it.

using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormGPSData : Form
    {
        private readonly FormGPS mf = null;

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
                lblEasting.Text = Math.Round(mf.pn.fix.easting, 1).ToString();
                lblNorthing.Text = Math.Round(mf.pn.fix.northing, 1).ToString();
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

            tboxSerialFromRelay.Text = mf.mc.serialRecvRelayStr;
            tboxSerialToRelay.Text = mf.mc.relayData[0] + "," + mf.mc.relayData[1]
                 + "," + mf.mc.relayData[2] + "," + mf.mc.relayData[3] //relay and speed x 4
                 + "," + mf.mc.relayData[4] + "," + mf.mc.relayData[5] + "," + mf.mc.relayData[6]; //setpoint hi lo
            tboxNMEASerial.Text = mf.recvSentenceSettings;
            //tboxNMEASerial.Text = mainForm.pn.rawBuffer;

            tboxSerialFromAutoSteer.Text = mf.mc.serialRecvAutoSteerStr;
            tboxSerialToAutoSteer.Text = "32766, " + mf.mc.autoSteerData[mf.mc.sdRelayLo] + ", " + mf.mc.autoSteerData[mf.mc.sdSpeed]
                                    + ", " + mf.guidanceLineDistanceOff + ", " + mf.guidanceLineSteerAngle;
        }

        private void FormGPSData_Load(object sender, EventArgs e)
        {
            //Set Language
            label4.Text = "Northing";
            lblNorthing.Text = "Northing";
            label5.Text = "Easting";
            lblEasting.Text = "Easting";
            label6.Text = "Latitude";
            lblLatitude.Text = "Latitude";
            lblLongitude.Text = "Longitude";
            label7.Text = "Longitiude";
            lblAltitude.Text = "Altitude";
            label8.Text = "Altitude";
            label1.Text = "Status";
            label2.Text = "Fix Quality";
            label3.Text = "# Satellites";
            lblStatus.Text = "Status";
            lblFixQuality.Text = "FixQual";
            lblSatsTracked.Text = "Sats";
            label11.Text = "Zone";
            lblZone.Text = "Zone";
            label13.Text = "Steer Actual, SetPoint, Heading, Roll, Sw";
            Text = "GPS Data";

        }
    }
}