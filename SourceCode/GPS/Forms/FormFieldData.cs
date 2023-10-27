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
            //lblEastingField.Text = Math.Round(mf.pn.fix.easting, 1).ToString();
            //lblNorthingField.Text = Math.Round(mf.pn.fix.northing, 1).ToString();

            lblLatitude.Text = mf.Latitude;
            lblLongitude.Text = mf.Longitude;

            lblTimeRemaining.Text = mf.fd.TimeTillFinished;
            lblRemainPercent.Text = mf.fd.WorkedAreaRemainPercentage;

            if (mf.isMetric)
            {
                lblWorkRate.Text = mf.fd.WorkRateHectares;

                if (mf.bnd.bndList.Count > 0)
                {

                    lblTotalArea.Text = mf.fd.AreaBoundaryLessInnersHectares;
                    lblApplied.Text = mf.fd.WorkedHectares;
                    lblAcresRemain.Text = mf.fd.WorkedAreaRemainHectares;
                }
                else
                {
                    lblTotalArea.Text = "-";
                    lblAcresRemain.Text = "-";
                    lblTimeRemaining.Text = "-";
                    lblRemainPercent.Text = "-";
                    lblApplied.Text = mf.fd.WorkedHectares;
                }

            }
            else //imperial
            {
                lblWorkRate.Text = mf.fd.WorkRateAcres;

                if (mf.bnd.bndList.Count > 0)
                {
                    lblTotalArea.Text = mf.fd.AreaBoundaryLessInnersAcres;
                    lblApplied.Text = mf.fd.WorkedAcres;
                    lblAcresRemain.Text = mf.fd.WorkedAreaRemainAcres;
                }
                else
                {
                    lblTotalArea.Text =   "-";
                    lblAcresRemain.Text = "-";
                    lblTimeRemaining.Text = "-";
                    lblRemainPercent.Text = "-";
                    lblApplied.Text = mf.fd.WorkedAcres;
                }
            }
        }
    }
}





//lblLookOnLeft.Text = mf.tool.lookAheadDistanceOnPixelsLeft.ToString("N0");
//lblLookOnRight.Text = mf.tool.lookAheadDistanceOnPixelsRight.ToString("N0");
//lblLookOffLeft.Text = mf.tool.lookAheadDistanceOffPixelsLeft.ToString("N0");
//lblLookOffRight.Text = mf.tool.lookAheadDistanceOffPixelsRight.ToString("N0");

//lblLeftToolSpd.Text = (mf.tool.toolFarLeftSpeed*3.6).ToString("N1");
//lblRightToolSpd.Text = (mf.tool.toolFarRightSpeed*3.6).ToString("N1");

//lblSectSpdLeft.Text = (mf.section[0].speedPixels*0.36).ToString("N1");
//lblSectSpdRight.Text = (mf.section[mf.tool.numOfSections-1].speedPixels*0.36).ToString("N1");