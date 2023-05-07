//Please, if you use this give me some credit
//Copyright BrianTee, copy right out of it.

using System;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace AgOpenGPS
{
    public partial class FormFieldData : Form
    {
        private readonly FormGPS mf = null;

        public FormFieldData(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblTram.Text = mf.tram.controlByte.ToString();

            //lblFrameTime.Text = mf.frameTime.ToString("N1");
            //lblTimeSlice.Text = (1 / mf.timeSliceOfLastFix).ToString("N3");
            //lblHz.Text = mf.gpsHz.ToString("N1");

            lblEastingField.Text = Math.Round(mf.pn.fix.easting, 1).ToString();
            lblNorthingField.Text = Math.Round(mf.pn.fix.northing, 1).ToString();

            lblLatitude.Text = mf.Latitude;
            lblLongitude.Text = mf.Longitude;

            lblTimeRemaining.Text = mf.fd.TimeTillFinished;

            if (mf.isMetric)
            {
                lblWorkRate.Text = mf.fd.WorkRateHectares;
                //fieldStatusStripText.Text = fd.WorkedAreaRemainHectares + "\r\n"+
                //                               fd.WorkedAreaRemainPercentage +"\r\n" +
                //                               fd.TimeTillFinished + "\r\n" +
                //                               fd.WorkRateHectares;
                if (mf.bnd.bndList.Count > 0)
                {

                    lblAcresRemain.Text = mf.fd.WorkedAreaRemainHectares;
                    //lblAcresRemain.Text = mf.fd.WorkedAreaRemainHectares;
                    //lblFieldStatus.Text = fd.AreaBoundaryLessInnersHectares + "   " +
                    //                       +"   " +
                    //                      fd.WorkedAreaRemainPercentage + "    " +
                    //                      fd.WorkedHectares;
                }
                //else
                    //lblFieldStatus.Text = fd.WorkedHectares;

            }
            else //imperial
            {
                lblWorkRate.Text = mf.fd.WorkRateAcres;

                if (mf.bnd.bndList.Count > 0)
                {
                    lblAcresRemain.Text = mf.fd.WorkedAreaRemainAcres;

                    //lblFieldStatus.Text = fd.AreaBoundaryLessInnersAcres + "   " +
                    //                        fd.WorkedAreaRemainAcres + "   " +
                    //                        fd.WorkedAreaRemainPercentage + "   " +
                    //                        fd.WorkedAcres;
                }
                //else
                //    lblFieldStatus.Text = fd.WorkedAcres;
            }
        }

        //private void FormGPSData_Load(object sender, EventArgs e)
        //{
        //    //lblSunrise.Text = mf.sunrise.ToString("HH:mm");
        //    //lblVersion.Text = Application.ProductVersion.ToString(CultureInfo.InvariantCulture);
        //    //lblSunset.Text = mf.sunset.ToString("HH:mm");
        //}

        //private void FormGPSData_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    mf.isGPSSentencesOn = false;
        //}
    }
}


//lblAreaAppliedMinusOverlap.Text = ((fd.actualAreaCovered * glm.m2ac).ToString("N2"));
//lblAreaMinusActualApplied.Text = (((mf.fd.areaBoundaryOuterLessInner - mf.fd.actualAreaCovered) * glm.m2ac).ToString("N2"));
//lblOverlapPercent.Text = (fd.overlapPercent.ToString("N2")) + "%";
//lblAreaOverlapped.Text = (((fd.workedAreaTotal - fd.actualAreaCovered) * glm.m2ac).ToString("N3"));

//lblAreaAppliedMinusOverlap.Text = ((fd.actualAreaCovered * glm.m2ha).ToString("N2"));
//lblAreaMinusActualApplied.Text = (((mf.fd.areaBoundaryOuterLessInner - mf.fd.actualAreaCovered) * glm.m2ha).ToString("N2"));
//lblOverlapPercent.Text = (fd.overlapPercent.ToString("N2")) + "%";
//lblAreaOverlapped.Text = (((fd.workedAreaTotal - fd.actualAreaCovered) * glm.m2ha).ToString("N3"));


//lblLookOnLeft.Text = mf.tool.lookAheadDistanceOnPixelsLeft.ToString("N0");
//lblLookOnRight.Text = mf.tool.lookAheadDistanceOnPixelsRight.ToString("N0");
//lblLookOffLeft.Text = mf.tool.lookAheadDistanceOffPixelsLeft.ToString("N0");
//lblLookOffRight.Text = mf.tool.lookAheadDistanceOffPixelsRight.ToString("N0");

//lblLeftToolSpd.Text = (mf.tool.toolFarLeftSpeed*3.6).ToString("N1");
//lblRightToolSpd.Text = (mf.tool.toolFarRightSpeed*3.6).ToString("N1");

//lblSectSpdLeft.Text = (mf.section[0].speedPixels*0.36).ToString("N1");
//lblSectSpdRight.Text = (mf.section[mf.tool.numOfSections-1].speedPixels*0.36).ToString("N1");