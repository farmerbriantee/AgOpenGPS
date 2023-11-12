using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormTram : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        private bool isSaving;
        private static bool isCurve;

        public FormTram(Form callingForm, bool Curve)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            this.Text = gStr.gsTramLines;
            label3.Text = gStr.gsPasses;
            label2.Text = ((int)(0.1 * mf.m2InchOrCm)).ToString() + mf.unitsInCm;
            lblTramWidth.Text = (mf.tram.tramWidth * mf.m2FtOrM).ToString("N2") + mf.unitsFtM;
            lblSeedWidth.Text = (mf.tool.width * mf.m2FtOrM).ToString("N2") + mf.unitsFtM;

            nudPasses.Controls[0].Enabled = false;

            isCurve = Curve;
        }

        private void FormTram_Load(object sender, EventArgs e)
        {
            nudPasses.Value = Properties.Settings.Default.setTram_passes;
            nudPasses.ValueChanged += nudPasses_ValueChanged;

            lblTrack.Text = (mf.vehicle.trackWidth * mf.m2FtOrM).ToString("N2") + mf.unitsFtM;

            mf.tool.halfWidth = (mf.tool.width - mf.tool.overlap) / 2.0;
            lblToolWidthHalf.Text = (mf.tool.halfWidth * mf.m2FtOrM).ToString("N2") + mf.unitsFtM;

            //if off, turn it on because they obviously want a tram.
            mf.tram.generateMode = 0;

            if (mf.tram.tramList.Count > 0 && mf.tram.tramBndOuterArr.Count > 0)
                mf.tram.generateMode = 0;
            else if (mf.tram.tramBndOuterArr.Count == 0)
                mf.tram.generateMode = 1;
            else if (mf.tram.tramList.Count == 0)
                mf.tram.generateMode = 2;

            switch (mf.tram.generateMode)
            {
                case 0:
                    btnMode.BackgroundImage = Properties.Resources.TramAll;
                    break;
                case 1:
                    btnMode.BackgroundImage = Properties.Resources.TramLines;
                    break;
                case 2:
                    btnMode.BackgroundImage = Properties.Resources.TramOuter;
                    break;

                default:
                    break;
            }
            mf.CloseTopMosts();

            if (mf.tram.tramList.Count > 0 || mf.tram.tramBndOuterArr.Count > 0)
            {
                //don't rebuild as trams exist
            }
            else
            {
                MoveBuildTramLine(0);
            }
        }

        private void FormTram_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isSaving)
            {
                if (isCurve)
                {
                    if (mf.trk.tracksArr[mf.trk.idx].trackPts.Count > 0)
                    {
                        ////array number is 1 less since it starts at zero
                        //int idx = mf.trk.numCurveLineSelected - 1;

                        ////mf.trk.tracksArr[idx].name = textBox1.Text.Trim();
                        //if (idx >= 0)
                        //{
                        //    mf.trk.tracksArr[idx].aveHeading = mf.trk.tracksArr[mf.trk.idx].aveHeading;
                        //    mf.trk.tracksArr[idx].trackPts.Clear();
                        //    //write out the Curve Points
                        //    foreach (vec3 item in mf.trk.tracksArr[mf.trk.idx].trackPts)
                        //    {
                        //        mf.trk.tracksArr[idx].trackPts.Add(item);
                        //    }
                        //}

                        //save entire list
                        mf.FileSaveCurveLines();
                    }
                }
            }
            else
            {
                mf.tram.tramArr?.Clear();
                mf.tram.tramList?.Clear();
                mf.tram.tramBndOuterArr?.Clear();
                mf.tram.tramBndInnerArr?.Clear();

                mf.tram.displayMode = 0;
            }

            mf.FileSaveTram();
            mf.FixTramModeButton();
        }

        private void MoveBuildTramLine(double Dist)
        {
            mf.tram.displayMode = 1;

            if (isCurve)
            {
                if (Dist != 0)
                    mf.trk.MoveABCurve(Dist);
                mf.trk.BuildTram();
            }
            else
            {
                if (Dist != 0)
                    mf.ABLine.MoveABLine(Dist);
                mf.ABLine.BuildTram();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            isSaving = true;
            Close();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            MoveBuildTramLine(-0.1);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            MoveBuildTramLine(0.1);
        }

        private void btnAdjLeft_Click(object sender, EventArgs e)
        {
            MoveBuildTramLine(-mf.tool.halfWidth);
        }

        private void btnAdjRight_Click(object sender, EventArgs e)
        {
            MoveBuildTramLine(mf.tool.halfWidth);
        }

        private void nudPasses_ValueChanged(object sender, EventArgs e)
        {
            mf.tram.passes = (int)nudPasses.Value;
            Properties.Settings.Default.setTram_passes = mf.tram.passes;
            Properties.Settings.Default.Save();
            MoveBuildTramLine(0);
        }

        private void nudPasses_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
        }

        private void btnSwapAB_Click(object sender, EventArgs e)
        {
            if (isCurve)
            {
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
            else
            {
                mf.ABLine.abHeading += Math.PI;
                if (mf.ABLine.abHeading > glm.twoPI) mf.ABLine.abHeading -= glm.twoPI;

                mf.ABLine.refABLineP1.easting = mf.ABLine.refPoint1.easting - (Math.Sin(mf.ABLine.abHeading) * mf.ABLine.abLength);
                mf.ABLine.refABLineP1.northing = mf.ABLine.refPoint1.northing - (Math.Cos(mf.ABLine.abHeading) * mf.ABLine.abLength);

                mf.ABLine.refABLineP2.easting = mf.ABLine.refPoint1.easting + (Math.Sin(mf.ABLine.abHeading) * mf.ABLine.abLength);
                mf.ABLine.refABLineP2.northing = mf.ABLine.refPoint1.northing + (Math.Cos(mf.ABLine.abHeading) * mf.ABLine.abLength);

                mf.ABLine.refPoint2.easting = mf.ABLine.refABLineP2.easting;
                mf.ABLine.refPoint2.northing = mf.ABLine.refABLineP2.northing;
            }
            MoveBuildTramLine(0);
        }

        private void btnTriggerDistanceUp_MouseDown(object sender, MouseEventArgs e)
        {
            nudPasses.UpButton();
        }

        private void btnTriggerDistanceDn_MouseDown(object sender, MouseEventArgs e)
        {
            nudPasses.DownButton();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            mf.tram.generateMode++;
            if (mf.tram.generateMode > 2) mf.tram.generateMode = 0;

            switch (mf.tram.generateMode)
            {
                case 0:
                    btnMode.BackgroundImage = Properties.Resources.TramAll;
                    break;
                case 1:
                    btnMode.BackgroundImage = Properties.Resources.TramLines;
                    break;
                case 2:
                    btnMode.BackgroundImage = Properties.Resources.TramOuter;
                    break;

                default:
                    break;
            }

            MoveBuildTramLine(0);
        }

        #region Help
        private void btnAdjLeft_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ht_btnAdjHalfToolWidth, gStr.gsHelp);
        }

        private void btnAdjRight_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ht_btnAdjHalfToolWidth, gStr.gsHelp);
        }

        private void btnLeft_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ht_btnLeftRightNudge, gStr.gsHelp);
        }

        private void btnRight_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ht_btnLeftRightNudge, gStr.gsHelp);
        }

        private void btnSwapAB_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ht_btnSwapAB, gStr.gsHelp);
        }

        private void btnMode_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_btnTramDisplayMode, gStr.gsHelp);
        }

        private void nudPasses_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ht_nudPasses, gStr.gsHelp);
        }

        private void btnCancel_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ht_btnCancel, gStr.gsHelp);
        }

        private void btnExit_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ht_btnSave, gStr.gsHelp);
        }

        #endregion
    }
}


/*
            
            MessageBox.Show(gStr, gStr.gsHelp);

            DialogResult result2 = MessageBox.Show(gStr, gStr.gsHelp,
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result2 == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=rsJMRZrcuX4");
            }

*/
