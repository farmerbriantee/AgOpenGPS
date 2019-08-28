using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormABCurve : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf;

        public FormABCurve(Form _mf)
        {
            mf = _mf as FormGPS;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
            mf.btnCurve.PerformClick();
            mf.curve.ResetCurveLine();
            mf.FileSaveCurveLine();
            mf.DisableYouTurnButtons();
            lblCurveExists.Text = "Curve Not Set";
        }

        private void btnABLineOk_Click(object sender, System.EventArgs e)
        {
            if (mf.curve.refList.Count < 3)
            {
                Close();
                mf.btnCurve.PerformClick();
                mf.curve.ResetCurveLine();
                mf.DisableYouTurnButtons();
            }
            else
            {
                mf.curve.isCurveSet = true;
                mf.EnableYouTurnButtons();
                Close();
            }
        }

        private void btnAPoint_Click(object sender, System.EventArgs e)
        {
            //clear out the reference list
            lblCurveExists.Text = "Curve Being Set";
            mf.curve.refList?.Clear();
            mf.curve.isOkToAddPoints = true;
            btnBPoint.Enabled = true;
            btnAPoint.Enabled = false;
            btnABLineOk.Enabled = false;
            btnPausePlay.Enabled = true;
        }

        private void btnBPoint_Click(object sender, System.EventArgs e)
        {
            mf.curve.aveLineHeading = 0;
            mf.curve.isOkToAddPoints = false;
            btnBPoint.Enabled = false;
            btnAPoint.Enabled = false;
            btnABLineOk.Enabled = true;
            btnPausePlay.Enabled = false;

            int cnt = mf.curve.refList.Count;
            if (cnt > 3)
            {
                //make sure distance isn't too big between points on Turn
                for (int i = 0; i < cnt - 1; i++)
                {
                    int j = i + 1;
                    //if (j == cnt) j = 0;
                    double distance = glm.Distance(mf.curve.refList[i], mf.curve.refList[j]);
                    if (distance > 1.2)
                    {
                        vec3 pointB = new vec3((mf.curve.refList[i].easting + mf.curve.refList[j].easting) / 2.0,
                            (mf.curve.refList[i].northing + mf.curve.refList[j].northing) / 2.0,
                            mf.curve.refList[i].heading);

                        mf.curve.refList.Insert(j, pointB);
                        cnt = mf.curve.refList.Count;
                        i = -1;
                    }
                }

                //calculate average heading of line
                double x = 0, y = 0;
                mf.curve.isCurveSet = true;
                foreach (var pt in mf.curve.refList)
                {
                    x += Math.Cos(pt.heading);
                    y += Math.Sin(pt.heading);
                }
                x /= mf.curve.refList.Count;
                y /= mf.curve.refList.Count;
                mf.curve.aveLineHeading = Math.Atan2(y, x);

                //build the tail extensions
                mf.curve.AddFirstLastPoints();
                SmoothAB(4);
                mf.curve.CalculateTurnHeadings();
                mf.EnableYouTurnButtons();
            }
            else
            {
                mf.curve.isCurveSet = false;
                mf.curve.refList?.Clear();
            }
            mf.FileSaveCurveLine();
            Close();
        }

        //for calculating for display the averaged new line
        public void SmoothAB(int smPts)
        {
            //count the reference list of original curve
            int cnt = mf.curve.refList.Count;

            //the temp array
            vec3[] arr = new vec3[cnt];

            //read the points before and after the setpoint
            for (int s = 0; s < smPts / 2; s++)
            {
                arr[s].easting = mf.curve.refList[s].easting;
                arr[s].northing = mf.curve.refList[s].northing;
                arr[s].heading = mf.curve.refList[s].heading;
            }

            for (int s = cnt - (smPts / 2); s < cnt; s++)
            {
                arr[s].easting = mf.curve.refList[s].easting;
                arr[s].northing = mf.curve.refList[s].northing;
                arr[s].heading = mf.curve.refList[s].heading;
            }

            //average them - center weighted average
            for (int i = smPts / 2; i < cnt - (smPts / 2); i++)
            {
                for (int j = -smPts / 2; j < smPts / 2; j++)
                {
                    arr[i].easting += mf.curve.refList[j + i].easting;
                    arr[i].northing += mf.curve.refList[j + i].northing;
                }
                arr[i].easting /= smPts;
                arr[i].northing /= smPts;
                arr[i].heading = mf.curve.refList[i].heading;
            }

            //make a list to draw
            mf.curve.refList?.Clear();
            for (int i = 0; i < cnt; i++)
            {
                mf.curve.refList.Add(arr[i]);
            }
        }

        private void FormABCurve_Load(object sender, EventArgs e)
        {
            if (mf.curve.refList.Count > 3)
            {
                btnBPoint.Enabled = false;
                btnAPoint.Enabled = false;
                lblCurveExists.Text = "Curve Set";
            }
            else
            {
                lblCurveExists.Text = "Curve Not Set";
            }
        }

        private void btnPausePlay_Click(object sender, EventArgs e)
        {
            if (mf.curve.isOkToAddPoints)
            {
                mf.curve.isOkToAddPoints = false;
                btnPausePlay.Image = Properties.Resources.BoundaryRecord;
                btnPausePlay.Text = "Record";
                btnBPoint.Enabled = false;
            }
            else
            {
                mf.curve.isOkToAddPoints = true;
                btnPausePlay.Image = Properties.Resources.boundaryPause;
                btnPausePlay.Text = "Pause";
                btnBPoint.Enabled = true;
            }
        }
    }
}