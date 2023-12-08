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
            //nudSnapDistance.Controls[0].Visible = false;
        }

        private void FormEditAB_Load(object sender, EventArgs e)
        {
            //label1.Text = mf.unitsInCm;

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

            snapAdj = Properties.Settings.Default.setAS_snapDistance;

            //Location = Properties.Settings.Default.setWindow_curveEditLocation;
        }

        private void nudSnapDistance_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            snapAdj = (double)nudSnapDistance.Value * mf.inchOrCm2m;
            Properties.Settings.Default.setAS_snapDistance = snapAdj;
            Properties.Settings.Default.Save();
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
                mf.trk.MoveABCurve(mf.isStanleyUsed ? mf.gyd.distanceFromCurrentLinePivot : mf.trk.distanceFromCurrentLinePivot);
        }

        private void FormEditCurve_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                e.Cancel = true;
                return;
            }
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
