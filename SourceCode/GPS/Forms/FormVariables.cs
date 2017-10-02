using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormVariables : Form
    {
        private readonly FormGPS mf;
        public FormVariables(Form _callingForm)
        {
            mf = _callingForm as FormGPS;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //all the fixings and position
            lblNorthing.Text = mf.FixNorthing;
            lblEasting.Text = mf.FixEasting;
            lblLatitude.Text = mf.Latitude;
            lblLongitude.Text = mf.Longitude;
            lblAltitude.Text = mf.Altitude;

            lblAntennaPivot.Text = Math.Round(mf.vehicle.antennaPivot,2).ToString();
            lblHitchLength.Text = Math.Round(mf.vehicle.hitchLength,2).ToString();
            lblTrailingHitchLength.Text = Math.Round(mf.vehicle.toolTrailingHitchLength,2).ToString();

            lblRequestOn.Text = mf.section[0].sectionOnRequest.ToString();
            lblRequestOff.Text = mf.section[0].sectionOffRequest.ToString();
            lblCycleOnOff.Text = mf.section[0].sectionOnOffCycle.ToString();
            lblTimerOn.Text = mf.section[0].sectionOnTimer.ToString();
            lblTimerOff.Text = mf.section[0].sectionOffTimer.ToString();

            lblHeadingFix.Text = mf.FixHeading;
            lblHeadingSection.Text = mf.FixHeadingSection;
            lblHeadingDelta.Text = (Math.Round(Math.PI - Math.Abs(Math.Abs(mf.fixHeadingTank - mf.fixHeading) - Math.PI),2)).ToString();
            lblLookaheadZero.Text = mf.LookAhead;
            lblZone.Text = mf.pn.zone.ToString();

            lblStepNum.Text = mf.StepFixNum;
            lblStepDistance.Text = mf.CurrentStepDistance;
            lblTotalStep.Text = mf.TotalStepDistance;

            //mf.UTMToLatLon(mf.pn.easting+mf.pn.utmEast,mf.pn.northing+mf.pn.utmNorth);

            //lblToLat.Text = mf.utmLat.ToString();
            //lblToLong.Text = mf.utmLon.ToString();

        }
    }
}
