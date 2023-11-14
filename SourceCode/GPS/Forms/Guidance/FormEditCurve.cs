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
            nudMinTurnRadius.Controls[0].Enabled = false;
        }

        private void FormEditAB_Load(object sender, EventArgs e)
        {
            label1.Text = mf.unitsInCm;
            label2.Text = mf.unitsFtM;

            //btnLeft.Text = "-"+Properties.Settings.Default.setDisplay_snapDistanceSmall.ToString() + "cm";
            lblHalfWidth.Text = (mf.tool.width * 0.5 * mf.m2FtOrM).ToString("N2");

            if (mf.isMetric)
            {
                nudMinTurnRadius.DecimalPlaces = 0;
                nudMinTurnRadius.Value = (int)((double)Properties.Settings.Default.setAS_snapDistance * mf.cm2CmOrIn);
            }
            else
            {
                nudMinTurnRadius.DecimalPlaces = 1;
                nudMinTurnRadius.Value = (decimal)Math.Round(((double)Properties.Settings.Default.setAS_snapDistance * mf.cm2CmOrIn), 1);
            }


            btnCancel.Focus();
        }

        private void nudMinTurnRadius_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
        }

        private void nudMinTurnRadius_ValueChanged(object sender, EventArgs e)
        {
            snapAdj = (double)nudMinTurnRadius.Value * mf.inOrCm2Cm * 0.01;
        }

        private void btnAdjRight_Click(object sender, EventArgs e)
        {
            mf.trk.MoveABCurve(snapAdj);
        }

        private void btnAdjLeft_Click(object sender, EventArgs e)
        {
            mf.trk.MoveABCurve(-snapAdj);
        }

        private void bntOk_Click(object sender, EventArgs e)
        {
            isClosing = true;
            if (mf.trk.idx != -1 && mf.trk.tracksArr[mf.trk.idx].trackPts.Count > 0)
            {
                //save entire list
                mf.FileSaveCurveLines();

            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isClosing = true;
            //if (mf.trk.isTrackSet && mf.isJobStarted)
            //{
            //    int last = mf.trk.numCurveLineSelected;
            //    mf.FileLoadTracks();
            //    if (mf.trk.tracksArr.Count > 0)
            //    {
            //        mf.trk.numCurveLineSelected = last;
            //        int idx = mf.trk.numCurveLineSelected - 1;
            //        mf.trk.tracksArr[mf.trk.idx].aveHeading = mf.trk.tracksArr[idx].aveHeading;

            //        mf.trk.tracksArr[mf.trk.idx].trackPts?.Clear();
            //        for (int i = 0; i < mf.trk.tracksArr[idx].trackPts.Count; i++)
            //        {
            //            mf.trk.tracksArr[mf.trk.idx].trackPts.Add(mf.trk.tracksArr[idx].trackPts[i]);
            //        }
            //        mf.trk.isTrackSet = true;
            //    }

            //    mf.trk.isTrackValid = false;
            //}
            Close();
        }

        private void btnSwapAB_Click(object sender, EventArgs e)
        {
            mf.trk.isTrackValid = false;
            mf.trk.lastSecond = 0;
            int cnt = mf.trk.tracksArr[mf.trk.idx].trackPts.Count;
            if (cnt > 0)
            {
                mf.trk.tracksArr[mf.trk.idx].trackPts.Reverse();

                vec3[] arr = new vec3[cnt];
                cnt--;
                mf.trk.tracksArr[mf.trk.idx].trackPts.CopyTo(arr);
                mf.trk.tracksArr[mf.trk.idx].trackPts.Clear();

                mf.trk.tracksArr[mf.trk.idx].aveHeading += Math.PI;
                if (mf.trk.tracksArr[mf.trk.idx].aveHeading < 0) mf.trk.tracksArr[mf.trk.idx].aveHeading += glm.twoPI;
                if (mf.trk.tracksArr[mf.trk.idx].aveHeading > glm.twoPI) mf.trk.tracksArr[mf.trk.idx].aveHeading -= glm.twoPI;

                for (int i = 1; i < cnt; i++)
                {
                    vec3 pt3 = arr[i];
                    pt3.heading += Math.PI;
                    if (pt3.heading > glm.twoPI) pt3.heading -= glm.twoPI;
                    if (pt3.heading < 0) pt3.heading += glm.twoPI;
                    mf.trk.tracksArr[mf.trk.idx].trackPts.Add(pt3);
                }
            }
        }

        private void btnContourPriority_Click(object sender, EventArgs e)
        {
            if (mf.trk.isBtnTrackOn)
                mf.trk.MoveABCurve(mf.isStanleyUsed ? mf.gyd.distanceFromCurrentLinePivot : mf.trk.distanceFromCurrentLinePivot);
        }

        private void btnRightHalfWidth_Click(object sender, EventArgs e)
        {
            double dist = mf.tool.width;

            mf.trk.MoveABCurve(dist * 0.5);

        }

        private void btnLeftHalfWidth_Click(object sender, EventArgs e)
        {
            double dist = mf.tool.width;

            mf.trk.MoveABCurve(-dist * 0.5);

        }

        private void btnNosave_Click(object sender, EventArgs e)
        {
            isClosing = true;
            mf.trk.isTrackValid = false;
            Close();
        }

        private void FormEditCurve_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                e.Cancel = true;
                return;
            }
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
