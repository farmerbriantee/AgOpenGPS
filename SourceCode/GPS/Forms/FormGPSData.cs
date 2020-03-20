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
            tboxNMEASerial.Text = mf.recvSentenceSettings;
            lblSpeed.Text = mf.pn.speed.ToString();

            lblLookOnLeft.Text = mf.tool.lookAheadDistanceOnPixelsLeft.ToString("N0");
            lblLookOnRight.Text = mf.tool.lookAheadDistanceOnPixelsRight.ToString("N0");
            lblLookOffLeft.Text = mf.tool.lookAheadDistanceOffPixelsLeft.ToString("N0");
            lblLookOffRight.Text = mf.tool.lookAheadDistanceOffPixelsRight.ToString("N0");

            lblLeftToolSpd.Text = (mf.tool.toolFarLeftSpeed*3.6).ToString("N1");
            lblRightToolSpd.Text = (mf.tool.toolFarRightSpeed*3.6).ToString("N1");

            lblSectSpdLeft.Text = (mf.section[0].speedPixels*0.36).ToString("N1");
            lblSectSpdRight.Text = (mf.section[mf.tool.numOfSections-1].speedPixels*0.36).ToString("N1");
        }
    }
}