using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormEditCurve : Form
    {
        private readonly FormGPS mf = null;

        private double snapAdj = 0;

        public FormEditCurve(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            this.Text = gStr.gsEditABCurve;
            //nudSnapDistance.Controls[0].Visible = false;
        }

        private void FormEditAB_Load(object sender, EventArgs e)
        {
            nudSnapDistance.DecimalPlaces = 0;
            nudSnapDistance.Value = (int)((double)Properties.Settings.Default.setAS_snapDistance * mf.cm2CmOrIn);

            snapAdj = Properties.Settings.Default.setAS_snapDistance * mf.inchOrCm2m;
            UpdateMoveLabel();

            //Location = Properties.Settings.Default.setWindow_curveEditLocation;
        }

        private void nudSnapDistance_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            snapAdj = (double)nudSnapDistance.Value * mf.inchOrCm2m;
            Properties.Settings.Default.setAS_snapDistance = (double)nudSnapDistance.Value;
            Properties.Settings.Default.Save();
        }

        private void btnAdjRight_Click(object sender, EventArgs e)
        {
            mf.trk.MoveABCurve(snapAdj);
            UpdateMoveLabel();
        }

        private void btnAdjLeft_Click(object sender, EventArgs e)
        {
            mf.trk.MoveABCurve(-snapAdj);
            UpdateMoveLabel();
        }

        private void bntOk_Click(object sender, EventArgs e)
        {
            if (mf.trk.idx != -1 && mf.trk.tracksArr[mf.trk.idx].trackPts.Count > 0)
            {
                //save entire list
                mf.FileSaveTracks();

            }
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

        private void btnSnapToPivot_Click(object sender, EventArgs e)
        {
            if (mf.trk.isBtnTrackOn)
                mf.trk.MoveABCurve(mf.trk.distanceFromCurrentLinePivot);
            UpdateMoveLabel();
        }

        private void FormEditCurve_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!isClosing)
            //{
            //    e.Cancel = true;
            //    return;
            //}
        }

        private void btnOK_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.he_btnOK, gStr.gsHelp);
        }

        private void btnContourPriority_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_btnSnapToPivot, gStr.gsHelp);
        }

        private void btnCycleLines_Click(object sender, EventArgs e)
        {

            if (mf.ct.isContourBtnOn)
            {
                mf.ct.SetLockToLine();
                return;
            }

            if (mf.trk.tracksArr.Count == 0) return;

            //reset to generate new reference
            mf.trk.isTrackValid = false;

            if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();

            if (mf.trk.isBtnTrackOn && mf.trk.tracksArr.Count > 0)
            {
                bool isVis = false;

                //make sure one is visible
                for (int i = 0; i < mf.trk.tracksArr.Count; i++)
                {
                    if (mf.trk.tracksArr[i].isVisible)
                    {
                        isVis = true;
                        break;
                    }
                }

                if (!isVis) return;

                while (isVis)
                {
                    mf.trk.idx++;

                    if (mf.trk.idx > (mf.trk.tracksArr.Count - 1)) mf.trk.idx = 0;

                    if (mf.trk.tracksArr[mf.trk.idx].isVisible) break;
                }

                mf.yt.ResetYouTurn();
                UpdateMoveLabel();
            }
        }

        private void btnCycleLinesBk_Click(object sender, EventArgs e)
        {
            if (mf.ct.isContourBtnOn)
            {
                mf.ct.SetLockToLine();
                return;
            }

            if (mf.trk.idx == -1) return;

            //reset to generate new reference
            mf.trk.isTrackValid = false;

            if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();

            if (mf.trk.isBtnTrackOn && mf.trk.tracksArr.Count > 0)
            {
                bool isVis = false;

                //make sure one is visible
                for (int i = 0; i < mf.trk.tracksArr.Count; i++)
                {
                    if (mf.trk.tracksArr[i].isVisible)
                    {
                        isVis = true;
                        break;
                    }
                }

                if (!isVis) return;

                while (isVis)
                {
                    mf.trk.idx--;

                    if (mf.trk.idx < 0) mf.trk.idx = mf.trk.tracksArr.Count - 1;

                    if (mf.trk.tracksArr[mf.trk.idx].isVisible) break;
                }
                UpdateMoveLabel();


                mf.yt.ResetYouTurn();
            }
        }

        private void btnZeroMove_Click(object sender, EventArgs e)
        {
            mf.trk.RemoveMoveDistance();
            UpdateMoveLabel();
        }

        private void UpdateMoveLabel()
        {
            lblMoveDistance.Text = ((int)(mf.trk.tracksArr[mf.trk.idx].moveDistance * mf.m2InchOrCm)).ToString();
        }
    }
}
