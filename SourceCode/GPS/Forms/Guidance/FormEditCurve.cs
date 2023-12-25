using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormEditCurve : Form
    {
        private readonly FormGPS mf = null;

        private double snapAdj = 0;
        private bool isClosing;

        public FormEditCurve(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            this.Text = gStr.gsEditABCurve;
            nudSnapDistance.Controls[0].Enabled = false;
        }

        private void FormEditAB_Load(object sender, EventArgs e)
        {
            label1.Text = mf.unitsInCm;

            if (mf.isMetric)
            {
                nudSnapDistance.DecimalPlaces = 0;
                nudSnapDistance.Value = (int)((double)Properties.Settings.Default.setAS_snapDistance * mf.cm2CmOrIn);
            }
            else
            {
                nudSnapDistance.DecimalPlaces = 1;
                nudSnapDistance.Value = (decimal)Math.Round(((double)Properties.Settings.Default.setAS_snapDistance * mf.cm2CmOrIn), 1);
            }

            snapAdj = Properties.Settings.Default.setAS_snapDistance * 0.01;

            Location = Properties.Settings.Default.setWindow_curveEditLocation;

            lblHalfToolWidth.Text = ((mf.tool.width-mf.tool.overlap) *0.5 * mf.m2InchOrCm).ToString("N0") + mf.unitsInCm;

            btnCancel.Focus();
        }

        private void nudSnapDistance_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            snapAdj = (double)nudSnapDistance.Value * mf.inchOrCm2m;
            Properties.Settings.Default.setAS_snapDistance = snapAdj * 100;
            Properties.Settings.Default.Save();
        }

        private void btnAdjRight_Click(object sender, EventArgs e)
        {
            mf.curve.MoveABCurve(snapAdj);
        }

        private void btnAdjLeft_Click(object sender, EventArgs e)
        {
            mf.curve.MoveABCurve(-snapAdj);
        }

        private void bntOk_Click(object sender, EventArgs e)
        {
            isClosing = true;
            if (mf.curve.isCurveSet && mf.curve.refCurve.curvePts.Count > 0)
            {
                //array number is 1 less since it starts at zero
                int idx = mf.curve.numCurveLineSelected - 1;

                if (idx >= 0)
                {
                    mf.trk.gArr[idx].heading = mf.curve.refCurve.heading;
                    mf.trk.gArr[idx].curvePts.Clear();
                    //write out the Curve Points
                    foreach (vec3 item in mf.curve.refCurve.curvePts)
                    {
                        mf.trk.gArr[idx].curvePts.Add(item);
                    }
                }

                //save entire list
                mf.FileSaveCurveLines();
                mf.curve.refCurve.nudgeDistance = 0;
                mf.curve.isCurveValid = false;
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isClosing = true;
            if (mf.curve.isCurveSet && mf.isJobStarted)
            {
                int last = mf.curve.numCurveLineSelected;
                mf.FileLoadCurveLines();
                if (mf.trk.gArr.Count > 0)
                {
                    mf.curve.numCurveLineSelected = last;
                    int idx = mf.curve.numCurveLineSelected - 1;
                    mf.curve.refCurve.heading = mf.trk.gArr[idx].heading;

                    mf.curve.refCurve.curvePts?.Clear();
                    for (int i = 0; i < mf.trk.gArr[idx].curvePts.Count; i++)
                    {
                        mf.curve.refCurve.curvePts.Add(mf.trk.gArr[idx].curvePts[i]);
                    }
                    mf.curve.isCurveSet = true;
                }

                mf.curve.isCurveValid = false;
            }
            Close();
        }

        private void btnSwapAB_Click(object sender, EventArgs e)
        {
            mf.curve.isCurveValid = false;
            mf.curve.lastSecond = 0;
            int cnt = mf.curve.refCurve.curvePts.Count;
            if (cnt > 0)
            {
                mf.curve.refCurve.curvePts.Reverse();

                vec3[] arr = new vec3[cnt];
                cnt--;
                mf.curve.refCurve.curvePts.CopyTo(arr);
                mf.curve.refCurve.curvePts.Clear();

                mf.curve.refCurve.heading += Math.PI;
                if (mf.curve.refCurve.heading < 0) mf.curve.refCurve.heading += glm.twoPI;
                if (mf.curve.refCurve.heading > glm.twoPI) mf.curve.refCurve.heading -= glm.twoPI;

                for (int i = 1; i < cnt; i++)
                {
                    vec3 pt3 = arr[i];
                    pt3.heading += Math.PI;
                    if (pt3.heading > glm.twoPI) pt3.heading -= glm.twoPI;
                    if (pt3.heading < 0) pt3.heading += glm.twoPI;
                    mf.curve.refCurve.curvePts.Add(pt3);
                }
            }
        }

        private void btnContourPriority_Click(object sender, EventArgs e)
        {
            if (mf.curve.isBtnCurveOn)
                mf.curve.MoveABCurve(mf.isStanleyUsed ? mf.gyd.distanceFromCurrentLinePivot : mf.curve.distanceFromCurrentLinePivot);
        }

        private void btnNudgeHalfToolRight_Click(object sender, EventArgs e)
        {
            double dist = mf.tool.width - mf.tool.overlap;

            mf.curve.MoveABCurve(dist * 0.5);
        }

        private void btnNudgeHalfToolLeft_Click(object sender, EventArgs e)
        {
            double dist = mf.tool.width - mf.tool.overlap;

            mf.curve.MoveABCurve(-dist * 0.5);
        }

        private void btnNosave_Click(object sender, EventArgs e)
        {
            isClosing = true;
            mf.curve.isCurveValid = false;
            Close();
        }

        private void FormEditCurve_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                e.Cancel = true;
                return;
            }
            Properties.Settings.Default.setWindow_curveEditLocation = Location;
            Properties.Settings.Default.Save();
        }

        private void btnCancel_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnCancel, gStr.gsHelp);
        }

        private void btnNoSave_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.he_btnNoSave, gStr.gsHelp);
        }

        private void btnOK_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.he_btnOK, gStr.gsHelp);
        }

        private void btnContourPriority_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_btnSnapToPivot, gStr.gsHelp);
        }

    }
}