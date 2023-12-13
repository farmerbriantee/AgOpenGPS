using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormEditTrack : Form
    {
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                //drop shadow
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }

        private readonly FormGPS mf = null;

        private double snapAdj = 0;

        public FormEditTrack(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            UpdateMoveLabel();

            this.Text = "";
        }

        private void FormEditTrack_Load(object sender, EventArgs e)
        {
            if (mf.isMetric)
            {
                nudSnapDistance.DecimalPlaces = 0;
                nudSnapDistance.Value = (int)((double)Properties.Settings.Default.setAS_snapDistance * mf.m2InchOrCm);
            }
            else
            {
                nudSnapDistance.DecimalPlaces = 1;
                nudSnapDistance.Value = (decimal)Math.Round(((double)Properties.Settings.Default.setAS_snapDistance * mf.m2InchOrCm), 1);
            }

            snapAdj = Properties.Settings.Default.setAS_snapDistance;

            Location = Properties.Settings.Default.setWindow_formEditTrackLocation;
            Size = Properties.Settings.Default.setWindow_formEditTrackSize;
            UpdateMoveLabel();
        }
        private void FormEditTrack_MouseEnter(object sender, EventArgs e)
        {
            UpdateMoveLabel();
        }
        private void FormEditTrack_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.setWindow_formEditTrackLocation = Location;
            Properties.Settings.Default.setWindow_formEditTrackSize = Size;

            Properties.Settings.Default.Save();

            if (mf.trk.idx != -1 && mf.trk.tracksArr[mf.trk.idx].trackPts.Count > 0)
            {
                //save entire list
                mf.FileSaveTracks();
            }
        }

        private void UpdateMoveLabel()
        {
            if (mf.trk.idx > -1)
            {
                if (mf.trk.tracksArr[mf.trk.idx].nudgeDistance == 0 )
                    lblOffset.Text = ((int)(mf.trk.tracksArr[mf.trk.idx].nudgeDistance * mf.m2InchOrCm * -1)).ToString() + mf.unitsInCm;
                else if (mf.trk.tracksArr[mf.trk.idx].nudgeDistance < 0)
                    lblOffset.Text = "< " + ((int)(mf.trk.tracksArr[mf.trk.idx].nudgeDistance * mf.m2InchOrCm * -1)).ToString() + mf.unitsInCm;
                else
                    lblOffset.Text = ((int)(mf.trk.tracksArr[mf.trk.idx].nudgeDistance * mf.m2InchOrCm)).ToString() + " >" + mf.unitsInCm;
                mf.Activate();
            }
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

            if (mf.trk.isBtnGuidanceOn && mf.trk.tracksArr.Count > 0)
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

            if (mf.trk.isBtnGuidanceOn && mf.trk.tracksArr.Count > 0)
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
            mf.trk.NudgeDistanceReset();
            UpdateMoveLabel();
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

        private void nudSnapDistance_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            snapAdj = (double)nudSnapDistance.Value * mf.inchOrCm2m;
            Properties.Settings.Default.setAS_snapDistance = snapAdj;
            Properties.Settings.Default.Save();
        }

        private void btnAdjRight_Click(object sender, EventArgs e)
        {
            mf.trk.NudgeTrack(snapAdj);
            UpdateMoveLabel();
        }

        private void btnAdjLeft_Click(object sender, EventArgs e)
        {
            mf.trk.NudgeTrack(-snapAdj);
            UpdateMoveLabel();
        }

        private void btnSnapToPivot_Click(object sender, EventArgs e)
        {
            mf.trk.SnapToPivot();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mf.trk.idx > -1 && mf.trk.tracksArr.Count > 0)
            {
                if (mf.trk.tracksArr[mf.trk.idx].nudgeDistance < 0)
                    lblOffset.Text = "< " + ((int)(mf.trk.tracksArr[mf.trk.idx].nudgeDistance * mf.m2InchOrCm * -1)).ToString();
                else
                    lblOffset.Text = ((int)(mf.trk.tracksArr[mf.trk.idx].nudgeDistance * mf.m2InchOrCm)).ToString() + " >";
            }
        }
    }
}
