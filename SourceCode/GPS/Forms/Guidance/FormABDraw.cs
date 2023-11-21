using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormABDraw : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        private Point fixPt;

        private bool isA = true;
        private int start = 99999, end = 99999;
        private int bndSelect = 0;

        public vec3 pint = new vec3(0.0, 1.0, 0.0);

        private bool isDrawSections = false;

        public FormABDraw(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            mf.CalculateMinMax();
        }

        private void FormABDraw_Load(object sender, EventArgs e)
        {
            FixLabelsCurve();

            if (isDrawSections) btnDrawSections.Image = Properties.Resources.MappingOn;
            else btnDrawSections.Image = Properties.Resources.MappingOff;
            UpdateBndButtons();
        }

        private void FormABDraw_FormClosing(object sender, FormClosingEventArgs e)
        {
            //trk
            if (mf.trk.idx == -1)
            {
                if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
                if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();
                mf.trk.isBtnTrackOn = false;
                mf.btnGuidance.Image = Properties.Resources.TrackOff;
           }

            mf.FileSaveTracks();

            if (mf.trk.isBtnTrackOn)
            {
                if (mf.trk.idx < 0)
                {
                }
            }
        }

        private void btnVisible_Click(object sender, EventArgs e)
        {
            mf.trk.tracksArr[mf.trk.idx].isVisible = !mf.trk.tracksArr[mf.trk.idx].isVisible;
            
            if (mf.trk.tracksArr[mf.trk.idx].isVisible)
            {
                btnVisible.Image = Properties.Resources.TrackVisible;
            }
            else
            {
                btnVisible.Image = Properties.Resources.TrackInvisible;
            }
            mf.FileSaveTracks();

        }

        private void FixLabelsCurve()
        {
            lblNumCu.Text = mf.trk.tracksArr.Count.ToString();
            lblCurveSelected.Text = (mf.trk.idx+1).ToString();

            if (mf.trk.idx > -1)
            {
                tboxNameCurve.Text = mf.trk.tracksArr[mf.trk.idx].name;

                if (mf.trk.tracksArr[mf.trk.idx].isVisible)
                {
                    btnVisible.Image = Properties.Resources.TrackVisible;
                }
                else
                {
                    btnVisible.Image = Properties.Resources.TrackInvisible;
                }
                btnVisible.Enabled = true;

                tboxNameCurve.Enabled = true;
            }
            else
            {
                tboxNameCurve.Text = "***";
                tboxNameCurve.Enabled = false;
                btnVisible.Enabled = false;
            }
        }

        private void UpdateBndButtons()
        {
            btnMakeOuterBoundaryCurve.Enabled = true;
            btnMakeInnerBoundaryCurve.Enabled = true;

            if (mf.bnd.bndList.Count < 2)
            {
                btnMakeInnerBoundaryCurve.Visible = false;
                label8.Visible = false;
            }


            for (int i = 0; i < mf.trk.tracksArr.Count; i++)
            {
                if (mf.trk.tracksArr[i].mode == (int)TrackMode.bndTrackOuter)
                {
                    btnMakeOuterBoundaryCurve.Enabled = false;
                    break;
                }
            }
            for (int i = 0; i < mf.trk.tracksArr.Count; i++)
            {
                if (mf.trk.tracksArr[i].mode == (int)TrackMode.bndTrackInner)
                {
                    btnMakeInnerBoundaryCurve.Enabled = false;
                    break;
                }
            }

            if (mf.bnd.bndList[0].fenceLine.Count < 3)
            {
                btnMakeOuterBoundaryCurve.Enabled = false;
                btnMakeInnerBoundaryCurve.Enabled = false;
            }
        }

        private void btnSelectCurve_Click(object sender, EventArgs e)
        {
            if (mf.trk.tracksArr.Count > 0)
            {
                mf.trk.idx++;
                if (mf.trk.idx > (mf.trk.tracksArr.Count-1)) mf.trk.idx = 0;
            }
            else
            {
                mf.trk.idx = -1;
            }

            FixLabelsCurve();
        }

        private void btnCancelTouch_Click(object sender, EventArgs e)
        {
            isA = true;
            start = 99999; end = 99999;

            btnCancelTouch.Enabled = false;
            btnExit.Focus();
        }

        private void nudDistance_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            btnSelectCurve.Focus();
        }

        private void btnDeleteCurve_Click(object sender, EventArgs e)
        {
            if (mf.trk.tracksArr.Count > 0 && mf.trk.idx > -1)
            {
                mf.trk.tracksArr.RemoveAt(mf.trk.idx);
                mf.trk.idx--;
            }

            if (mf.trk.tracksArr.Count > 0)
            {
                if (mf.trk.idx == -1)
                {
                    mf.trk.idx++;
                }
            }
            else mf.trk.idx = -1;

            FixLabelsCurve();
            UpdateBndButtons();
        }

        private void btnDrawSections_Click(object sender, EventArgs e)
        {
            isDrawSections = !isDrawSections;
            if (isDrawSections) btnDrawSections.Image = Properties.Resources.MappingOn;
            else btnDrawSections.Image = Properties.Resources.MappingOff;
        }

        private void tboxNameCurve_Leave(object sender, EventArgs e)
        {
            if (mf.trk.idx > -1)
                mf.trk.tracksArr[mf.trk.idx].name = tboxNameCurve.Text.Trim();
        }

        private void tboxNameCurve_Enter(object sender, EventArgs e)
        {
            if (mf.trk.tracksArr[mf.trk.idx].mode == (int)(TrackMode.bndTrackOuter))
            {
                btnExit.Focus();
                return;
            }

            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((System.Windows.Forms.TextBox)sender, this);
                if (mf.trk.idx > -1)
                    mf.trk.tracksArr[mf.trk.idx].name = tboxNameCurve.Text.Trim();
                btnExit.Focus();
            }
        }

        private void btnMakeOuterBoundaryCurve_Click(object sender, EventArgs e)
        {
            mf.trk.tracksArr.Add(new CTrackPath());
            mf.trk.idx = mf.trk.tracksArr.Count - 1;

            //make the boundary list directly
            for (int i = 0; i < mf.bnd.bndList[0].fenceLine.Count; i++)
            {
                mf.trk.tracksArr[mf.trk.idx].trackPts.Add(new vec3(mf.bnd.bndList[0].fenceLine[i]));
            }
            mf.trk.tracksArr[mf.trk.idx].trackPts.Add(new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[0]));

            mf.trk.CalculateTurnHeadings();

            mf.trk.tracksArr[mf.trk.idx].aveHeading = 0;

            //create a name
            mf.trk.tracksArr[mf.trk.idx].name = "Outer Boundary Curve";
            mf.trk.tracksArr[mf.trk.idx].mode = (int)TrackMode.bndTrackOuter;

            mf.trk.tracksArr[mf.trk.idx].moveDistance = 0;

            mf.trk.tracksArr[mf.trk.idx].ptA = new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[0]);
            mf.trk.tracksArr[mf.trk.idx].ptB = new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[mf.trk.tracksArr[mf.trk.idx].trackPts.Count - 1]);

            mf.FileSaveTracks();
            start = 99999; end = 99999;

            FixLabelsCurve();
            UpdateBndButtons();

            btnExit.Focus();
        }

        private void btnMakeInnerBoundaryCurve_Click(object sender, EventArgs e)
        {
            for (int q = 1; q < mf.bnd.bndList.Count; q++)
            {
                mf.trk.tracksArr.Add(new CTrackPath());
                mf.trk.idx = mf.trk.tracksArr.Count - 1;

                //make the boundary list directly
                for (int i = 0; i < mf.bnd.bndList[q].fenceLine.Count; i++)
                {
                    mf.trk.tracksArr[mf.trk.idx].trackPts.Add(new vec3(mf.bnd.bndList[q].fenceLine[i]));
                }
                mf.trk.tracksArr[mf.trk.idx].trackPts.Add(new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[0]));

                mf.trk.CalculateTurnHeadings();

                mf.trk.tracksArr[mf.trk.idx].aveHeading = 0;
                mf.trk.tracksArr[mf.trk.idx].mode = (int)TrackMode.bndTrackInner;

                //create a name
                mf.trk.tracksArr[mf.trk.idx].name = "Inner Boundary Curve " + q.ToString();

                mf.trk.tracksArr[mf.trk.idx].moveDistance = 0;

                mf.trk.tracksArr[mf.trk.idx].ptA = new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[0]);
                mf.trk.tracksArr[mf.trk.idx].ptB = new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[mf.trk.tracksArr[mf.trk.idx].trackPts.Count - 1]);
            }

            mf.FileSaveTracks();
            start = 99999; end = 99999;

            FixLabelsCurve();
            UpdateBndButtons();

            btnExit.Focus();
        }

        private void BtnMakeCurve_Click(object sender, EventArgs e)
        {
            btnCancelTouch.Enabled = false;

            mf.trk.tracksArr.Add(new CTrackPath());
            mf.trk.idx = mf.trk.tracksArr.Count - 1;

            bool isLoop = false;
            int limit = end;

            vec3 ptA = new vec3(mf.bnd.bndList[bndSelect].fenceLine[start]);
            vec3 ptB = new vec3(mf.bnd.bndList[bndSelect].fenceLine[end]);

            if ((Math.Abs(start - end)) > (mf.bnd.bndList[bndSelect].fenceLine.Count * 0.5))
            {
                isLoop = true;
                if (start < end)
                {
                    limit = end;
                    end = 0;
                }
                else
                {
                    limit = end;
                    end = mf.bnd.bndList[bndSelect].fenceLine.Count;
                }
            }

            mf.trk.tracksArr[mf.trk.idx].trackPts?.Clear();
            vec3 pt3 = new vec3();

            if (start < end)
            {
                for (int i = start; i <= end; i++)
                {
                    //calculate the point inside the boundary
                    pt3 = mf.bnd.bndList[bndSelect].fenceLine[i];
                    mf.trk.tracksArr[mf.trk.idx].trackPts.Add(pt3);

                    if (isLoop && i == mf.bnd.bndList[bndSelect].fenceLine.Count - 1)
                    {
                        i = -1;
                        isLoop = false;
                        end = limit;
                    }
                }
            }
            else
            {
                for (int i = start; i >= end; i--)
                {
                    //calculate the point inside the boundary
                    pt3 = mf.bnd.bndList[bndSelect].fenceLine[i];
                    mf.trk.tracksArr[mf.trk.idx].trackPts.Add(pt3);

                    if (isLoop && i == 0)
                    {
                        i = mf.bnd.bndList[bndSelect].fenceLine.Count - 1;
                        isLoop = false;
                        end = limit;
                    }
                }
            }


            //who knows which way it actually goes
            mf.trk.CalculateTurnHeadings();

            //calculate average heading of line
            double x = 0, y = 0;

            foreach (vec3 pt in mf.trk.tracksArr[mf.trk.idx].trackPts)
            {
                x += Math.Cos(pt.heading);
                y += Math.Sin(pt.heading);
            }
            x /= mf.trk.tracksArr[mf.trk.idx].trackPts.Count;
            y /= mf.trk.tracksArr[mf.trk.idx].trackPts.Count;
            mf.trk.tracksArr[mf.trk.idx].aveHeading = Math.Atan2(y, x);
            if (mf.trk.tracksArr[mf.trk.idx].aveHeading < 0) mf.trk.tracksArr[mf.trk.idx].aveHeading += glm.twoPI;

            //build the tail extensions
            mf.trk.AddFirstLastPoints(ref mf.trk.tracksArr[mf.trk.idx].trackPts);
            mf.trk.SmoothTrack(4);
            mf.trk.CalculateTurnHeadings();

            //create a name
            mf.trk.tracksArr[mf.trk.idx].name = "Cu " + (Math.Round(glm.toDegrees(mf.trk.tracksArr[mf.trk.idx].aveHeading), 1)).ToString(CultureInfo.InvariantCulture)
                 + "\u00B0" + mf.FindDirection(mf.trk.tracksArr[mf.trk.idx].aveHeading) + DateTime.Now.ToString("mm:ss", CultureInfo.InvariantCulture);

            mf.trk.tracksArr[mf.trk.idx].ptA = ptA;
            mf.trk.tracksArr[mf.trk.idx].ptB = ptB;

            mf.trk.tracksArr[mf.trk.idx].moveDistance = 0;

            mf.trk.tracksArr[mf.trk.idx].mode = (int)TrackMode.Curve;

            mf.FileSaveTracks();

            start = 99999; end = 99999;

            FixLabelsCurve();
            btnExit.Focus();
        }

        private void BtnMakeABLine_Click(object sender, EventArgs e)
        {
            btnCancelTouch.Enabled = false;

            vec3 ptA = new vec3(mf.bnd.bndList[bndSelect].fenceLine[start]);
            vec3 ptB = new vec3(mf.bnd.bndList[bndSelect].fenceLine[end]);

            //calculate the AB Heading
            double abHead = Math.Atan2(
                mf.bnd.bndList[bndSelect].fenceLine[end].easting - mf.bnd.bndList[bndSelect].fenceLine[start].easting,
                mf.bnd.bndList[bndSelect].fenceLine[end].northing - mf.bnd.bndList[bndSelect].fenceLine[start].northing);
            if (abHead < 0) abHead += glm.twoPI;

            mf.trk.tracksArr.Add(new CTrackPath());
            mf.trk.idx = mf.trk.tracksArr.Count - 1;

            mf.trk.tracksArr[mf.trk.idx].aveHeading = abHead;

            mf.trk.tracksArr[mf.trk.idx].trackPts?.Clear();

            for (int i = 0; i <= (int)(glm.Distance(ptA, ptB) / 2); i++)
            {
                vec3 ptC = new vec3(ptA);
                ptC.easting = (Math.Sin(abHead) * 2 * i) + ptA.easting;
                ptC.northing = (Math.Cos(abHead) * 2 * i) + ptA.northing;
                ptC.heading = abHead;
                mf.trk.tracksArr[mf.trk.idx].trackPts.Add(ptC);
            }

            //create a name
            mf.trk.tracksArr[mf.trk.idx].name = "AB " + (Math.Round(glm.toDegrees(mf.trk.tracksArr[mf.trk.idx].aveHeading), 1)).ToString(CultureInfo.InvariantCulture)
                 + "\u00B0" + mf.FindDirection(mf.trk.tracksArr[mf.trk.idx].aveHeading) + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);

            mf.trk.tracksArr[mf.trk.idx].ptA = ptA;
            mf.trk.tracksArr[mf.trk.idx].ptB = ptB;

            mf.trk.tracksArr[mf.trk.idx].moveDistance = 0;

            mf.trk.tracksArr[mf.trk.idx].mode = (int)TrackMode.AB;

            mf.FileSaveTracks();

            FixLabelsCurve();
            start = 99999; end = 99999;
        }

        private void oglSelf_MouseDown(object sender, MouseEventArgs e)
        {
            btnCancelTouch.Enabled = true;

            Point ptt = oglSelf.PointToClient(Cursor.Position);

            //Convert to Origin in the center of window, 800 pixels
            fixPt.X = ptt.X - 350;
            fixPt.Y = (700 - ptt.Y - 350);
            vec3 plotPt = new vec3
            {
                //convert screen coordinates to field coordinates
                easting = fixPt.X * mf.maxFieldDistance / 632.0,
                northing = fixPt.Y * mf.maxFieldDistance / 632.0,
                heading = 0
            };

            plotPt.easting += mf.fieldCenterX;
            plotPt.northing += mf.fieldCenterY;

            pint.easting = plotPt.easting;
            pint.northing = plotPt.northing;

            if (isA)
            {
                double minDistA = double.MaxValue;
                start = 99999; end = 99999;

                for (int j = 0; j < mf.bnd.bndList.Count; j++)
                {
                    for (int i = 0; i < mf.bnd.bndList[j].fenceLine.Count; i++)
                    {
                        double dist = ((pint.easting - mf.bnd.bndList[j].fenceLine[i].easting) * (pint.easting - mf.bnd.bndList[j].fenceLine[i].easting))
                                        + ((pint.northing - mf.bnd.bndList[j].fenceLine[i].northing) * (pint.northing - mf.bnd.bndList[j].fenceLine[i].northing));
                        if (dist < minDistA)
                        {
                            minDistA = dist;
                            bndSelect = j;
                            start = i;
                        }
                    }
                }

                isA = false;
            }
            else
            {
                double minDistA = double.MaxValue;
                int j = bndSelect;

                for (int i = 0; i < mf.bnd.bndList[j].fenceLine.Count; i++)
                {
                    double dist = ((pint.easting - mf.bnd.bndList[j].fenceLine[i].easting) * (pint.easting - mf.bnd.bndList[j].fenceLine[i].easting))
                                    + ((pint.northing - mf.bnd.bndList[j].fenceLine[i].northing) * (pint.northing - mf.bnd.bndList[j].fenceLine[i].northing));
                    if (dist < minDistA)
                    {
                        minDistA = dist;
                        end = i;
                    }
                }

                isA = true;

                //build the lines
                if (rbtnCurve.Checked)
                {
                    mf.trk.tracksArr.Add(new CTrackPath());
                    mf.trk.idx = mf.trk.tracksArr.Count - 1;

                    bool isLoop = false;
                    int limit = end;

                    vec3 ptA = new vec3();
                    vec3 ptB = new vec3();

                    if ((Math.Abs(start - end)) > (mf.bnd.bndList[bndSelect].fenceLine.Count * 0.5))
                    {
                        if (start > end)
                        {
                            (start, end) = (end, start);
                        }

                        ptA = new vec3(mf.bnd.bndList[bndSelect].fenceLine[start]);
                        ptB = new vec3(mf.bnd.bndList[bndSelect].fenceLine[end]);

                        isLoop = true;
                        if (start < end)
                        {
                            limit = end;
                            end = 0;
                        }
                        else
                        {
                            limit = end;
                            end = mf.bnd.bndList[bndSelect].fenceLine.Count;
                        }
                    }

                    else
                    {
                        if (start < end)
                        {
                            (start, end) = (end, start);
                        }

                        ptA = new vec3(mf.bnd.bndList[bndSelect].fenceLine[start]);
                        ptB = new vec3(mf.bnd.bndList[bndSelect].fenceLine[end]);
                    }

                    mf.trk.tracksArr[mf.trk.idx].trackPts?.Clear();
                    vec3 pt3 = new vec3();

                    if (start < end)
                    {
                        for (int i = start; i <= end; i++)
                        {
                            //calculate the point inside the boundary
                            pt3 = mf.bnd.bndList[bndSelect].fenceLine[i];
                            mf.trk.tracksArr[mf.trk.idx].trackPts.Add(pt3);

                            if (isLoop && i == mf.bnd.bndList[bndSelect].fenceLine.Count - 1)
                            {
                                i = -1;
                                isLoop = false;
                                end = limit;
                            }
                        }
                    }
                    else
                    {
                        for (int i = start; i >= end; i--)
                        {
                            //calculate the point inside the boundary
                            pt3 = mf.bnd.bndList[bndSelect].fenceLine[i];
                            mf.trk.tracksArr[mf.trk.idx].trackPts.Add(pt3);

                            if (isLoop && i == 0)
                            {
                                i = mf.bnd.bndList[bndSelect].fenceLine.Count - 1;
                                isLoop = false;
                                end = limit;
                            }
                        }
                    }

                    //who knows which way it actually goes
                    mf.trk.CalculateTurnHeadings();

                    //calculate average heading of line
                    double x = 0, y = 0;

                    foreach (vec3 pt in mf.trk.tracksArr[mf.trk.idx].trackPts)
                    {
                        x += Math.Cos(pt.heading);
                        y += Math.Sin(pt.heading);
                    }
                    x /= mf.trk.tracksArr[mf.trk.idx].trackPts.Count;
                    y /= mf.trk.tracksArr[mf.trk.idx].trackPts.Count;
                    mf.trk.tracksArr[mf.trk.idx].aveHeading = Math.Atan2(y, x);
                    if (mf.trk.tracksArr[mf.trk.idx].aveHeading < 0) mf.trk.tracksArr[mf.trk.idx].aveHeading += glm.twoPI;

                    //build the tail extensions
                    //mf.trk.AddFirstLastPoints(ref mf.trk.tracksArr[mf.trk.idx].trackPts);
                    mf.trk.SmoothTrack(4);
                    mf.trk.CalculateTurnHeadings();

                    int ptCnt = mf.trk.tracksArr[mf.trk.idx].trackPts.Count - 1;

                    for (int i = 1; i < 30; i += 2)
                    {
                        vec3 pt = new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[ptCnt]);
                        pt.easting += (Math.Sin(pt.heading) * i);
                        pt.northing += (Math.Cos(pt.heading) * i);
                        mf.trk.tracksArr[mf.trk.idx].trackPts.Add(pt);
                    }

                    vec3 stat = new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[0]);

                    for (int i = 1; i < 30; i += 2)
                    {
                        vec3 pt = new vec3(stat);
                        pt.easting -= (Math.Sin(pt.heading) * i);
                        pt.northing -= (Math.Cos(pt.heading) * i);
                        mf.trk.tracksArr[mf.trk.idx].trackPts.Insert(0, pt);
                    }


                    //create a name
                    mf.trk.tracksArr[mf.trk.idx].name = "Cu " + (Math.Round(glm.toDegrees(mf.trk.tracksArr[mf.trk.idx].aveHeading), 1)).ToString(CultureInfo.InvariantCulture)
                         + "\u00B0" + mf.FindDirection(mf.trk.tracksArr[mf.trk.idx].aveHeading) + DateTime.Now.ToString("mm:ss", CultureInfo.InvariantCulture);

                    mf.trk.tracksArr[mf.trk.idx].ptA = ptA;
                    mf.trk.tracksArr[mf.trk.idx].ptB = ptB;

                    mf.trk.tracksArr[mf.trk.idx].moveDistance = 0;

                    mf.trk.tracksArr[mf.trk.idx].mode = (int)TrackMode.Curve;

                    mf.FileSaveTracks();

                    //update the arrays
                    start = 99999; end = 99999;

                    FixLabelsCurve();
                    btnExit.Focus();
                }

                else if (rbtnLine.Checked)
                {
                    vec3 ptA = new vec3(mf.bnd.bndList[bndSelect].fenceLine[start]);
                    vec3 ptB = new vec3(mf.bnd.bndList[bndSelect].fenceLine[end]);

                    //calculate the AB Heading
                    double abHead = Math.Atan2(
                        mf.bnd.bndList[bndSelect].fenceLine[end].easting - mf.bnd.bndList[bndSelect].fenceLine[start].easting,
                        mf.bnd.bndList[bndSelect].fenceLine[end].northing - mf.bnd.bndList[bndSelect].fenceLine[start].northing);
                    if (abHead < 0) abHead += glm.twoPI;

                    mf.trk.tracksArr.Add(new CTrackPath());
                    mf.trk.idx = mf.trk.tracksArr.Count - 1;

                    mf.trk.tracksArr[mf.trk.idx].aveHeading = abHead;

                    mf.trk.tracksArr[mf.trk.idx].trackPts?.Clear();

                    ptA.heading = abHead;
                    ptB.heading = abHead;

                    for (int i = 0; i <= (int)(glm.Distance(ptA, ptB) / 2); i++)
                    {
                        vec3 ptC = new vec3(ptA);
                        ptC.easting = (Math.Sin(abHead) * 2 * i) + ptA.easting;
                        ptC.northing = (Math.Cos(abHead) * 2 * i) + ptA.northing;
                        ptC.heading = abHead;
                        mf.trk.tracksArr[mf.trk.idx].trackPts.Add(ptC);
                    }

                    int ptCnt = mf.trk.tracksArr[mf.trk.idx].trackPts.Count - 1;

                    for (int i = 1; i < 30; i+=2)
                    {
                        vec3 pt = new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[ptCnt]);
                        pt.easting += (Math.Sin(pt.heading) * i);
                        pt.northing += (Math.Cos(pt.heading) * i);
                        mf.trk.tracksArr[mf.trk.idx].trackPts.Add(pt);
                    }

                    vec3 stat = new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[0]);

                    for (int i = 1; i < 30; i += 2)
                    {
                        vec3 pt = new vec3(stat);
                        pt.easting -= (Math.Sin(pt.heading) * i);
                        pt.northing -= (Math.Cos(pt.heading) * i);
                        mf.trk.tracksArr[mf.trk.idx].trackPts.Insert(0, pt);
                    }

                    //create a name
                    mf.trk.tracksArr[mf.trk.idx].name = "AB " + (Math.Round(glm.toDegrees(mf.trk.tracksArr[mf.trk.idx].aveHeading), 1)).ToString(CultureInfo.InvariantCulture)
                         + "\u00B0" + mf.FindDirection(mf.trk.tracksArr[mf.trk.idx].aveHeading) + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);

                    mf.trk.tracksArr[mf.trk.idx].ptA = ptA;
                    mf.trk.tracksArr[mf.trk.idx].ptB = ptB;

                    mf.trk.tracksArr[mf.trk.idx].moveDistance = 0;

                    mf.trk.tracksArr[mf.trk.idx].mode = (int)TrackMode.AB;

                    mf.FileSaveTracks();

                    FixLabelsCurve();
                    start = 99999; end = 99999;
                }
            }
        }

        private void oglSelf_Paint(object sender, PaintEventArgs e)
        {
            oglSelf.MakeCurrent();

            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();                  // Reset The View

            //back the camera up
            GL.Translate(0, 0, -mf.maxFieldDistance);

            //translate to that spot in the world
            GL.Translate(-mf.fieldCenterX, -mf.fieldCenterY, 0);

            GL.Color3(1, 1, 1);

            //GL.Enable(EnableCap.Blend);

            //draw all the boundaries

            GL.LineWidth(2);

            for (int j = 0; j < mf.bnd.bndList.Count; j++)
            {
                if (j == bndSelect)
                    GL.Color3(0.75f, 0.5f, 0.20f);
                else
                    GL.Color3(0.50f, 0.25f, 0.10f);

                GL.Begin(PrimitiveType.LineLoop);
                for (int i = 0; i < mf.bnd.bndList[j].fenceLineEar.Count; i++)
                {
                    GL.Vertex3(mf.bnd.bndList[j].fenceLineEar[i].easting, mf.bnd.bndList[j].fenceLineEar[i].northing, 0);
                }
                GL.End();
            }

            //the vehicle
            GL.PointSize(8.0f);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(0.95f, 0.90f, 0.0f);
            GL.Vertex3(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing, 0.0);
            GL.End();

            if (isDrawSections) DrawSections();

            //draw the line building graphics
            if (start != 99999 || end != 99999) DrawABTouchLine();

            //draw the actual built lines
            if (start == 99999 && end == 99999)
            {
                DrawBuiltLines();
            }

            GL.Disable(EnableCap.Blend);


            GL.Flush();
            oglSelf.SwapBuffers();
        }

        private void DrawBuiltLines()
        {
            if (mf.trk.tracksArr.Count > 0)
            {
                //GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0x7070);
                GL.PointSize(4);

                for (int i = 0; i < mf.trk.tracksArr.Count; i++)
                {
                    if (mf.trk.tracksArr[i].mode == (int)TrackMode.bndTrackOuter ||
                        mf.trk.tracksArr[i].mode == (int)TrackMode.bndTrackInner)
                        continue;
                    if (mf.trk.tracksArr[i].mode == (int)TrackMode.AB)
                    {
                        if (mf.trk.tracksArr[i].isVisible)
                            GL.Color3(0.973f, 0.19f, 0.10f);
                        else
                            GL.Color3(0.3f, 0.1f, 0.80f);
                    }
                    else
                    {
                        if (mf.trk.tracksArr[i].isVisible)
                            GL.Color3(0.3f, 0.99f, 0.20f);
                        else
                            GL.Color3(0.1f, 0.31f, 0.80f);
                    }

                    GL.Begin(PrimitiveType.Points);
                    foreach (vec3 item in mf.trk.tracksArr[i].trackPts)
                    {
                        GL.Vertex3(item.easting, item.northing, 0);
                    }
                    GL.End();
                }

                //GL.Disable(EnableCap.LineStipple);

                if (mf.trk.idx > -1)
                {
                    GL.LineWidth(8);

                    if (mf.trk.tracksArr[mf.trk.idx].isVisible)
                        GL.Color3(1.0f, 0.0f, 1.0f);
                    else
                        GL.Color3(0.3f, 0.3f, 0.80f);

                    GL.Begin(PrimitiveType.LineStrip);
                    foreach (vec3 item in mf.trk.tracksArr[mf.trk.idx].trackPts)
                    {
                        GL.Vertex3(item.easting, item.northing, 0);
                    }
                    GL.End();

                    GL.PointSize(20);
                    GL.Color3(0, 0, 0);
                    GL.Begin(PrimitiveType.Points);
                    {
                        GL.Vertex3(mf.trk.tracksArr[mf.trk.idx].ptA.easting,
                                    mf.trk.tracksArr[mf.trk.idx].ptA.northing,
                                    0);

                        GL.Color3(0, 0, 0);
                        GL.Vertex3(mf.trk.tracksArr[mf.trk.idx].ptB.easting,
                                    mf.trk.tracksArr[mf.trk.idx].ptB.northing,
                                    0);
                    }

                    GL.End();

                    GL.PointSize(12);
                    GL.Color3(1.0f, 0.75f, 0.350f);
                    GL.Begin(PrimitiveType.Points);
                    {
                        GL.Vertex3(mf.trk.tracksArr[mf.trk.idx].ptA.easting,
                                    mf.trk.tracksArr[mf.trk.idx].ptA.northing,
                                    0);

                        GL.Color3(0.5f, 0.5f, 1.0f);
                        GL.Vertex3(mf.trk.tracksArr[mf.trk.idx].ptB.easting,
                                    mf.trk.tracksArr[mf.trk.idx].ptB.northing,
                                    0);
                    }

                    GL.End();
                }
            }
        }

        private void DrawABTouchLine()
        {
            GL.Color3(0.65, 0.650, 0.0);
            GL.PointSize(16);
            GL.Begin(PrimitiveType.Points);

            GL.Color3(0, 0, 0);
            if (start != 99999) GL.Vertex3(mf.bnd.bndList[bndSelect].fenceLine[start].easting, mf.bnd.bndList[bndSelect].fenceLine[start].northing, 0);
            if (end != 99999) GL.Vertex3(mf.bnd.bndList[bndSelect].fenceLine[end].easting, mf.bnd.bndList[bndSelect].fenceLine[end].northing, 0);
            GL.End();

            GL.PointSize(10);
            GL.Begin(PrimitiveType.Points);

            GL.Color3(1.0f, 0.75f, 0.350f);
            if (start != 99999) GL.Vertex3(mf.bnd.bndList[bndSelect].fenceLine[start].easting, mf.bnd.bndList[bndSelect].fenceLine[start].northing, 0);

            GL.Color3(0.5f, 0.5f, 1.0f);
            if (end != 99999) GL.Vertex3(mf.bnd.bndList[bndSelect].fenceLine[end].easting, mf.bnd.bndList[bndSelect].fenceLine[end].northing, 0);
            GL.End();
        }

        private void DrawSections()
        {
            int cnt, step, patchCount;
            int mipmap = 8;

            GL.Color3(0.0, 0.0, 0.352);

            //draw patches j= # of sections
            for (int j = 0; j < mf.triStrip.Count; j++)
            {
                //every time the section turns off and on is a new patch
                patchCount = mf.triStrip[j].patchList.Count;

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (System.Collections.Generic.List<vec3> triList in mf.triStrip[j].patchList)
                    {
                        //draw the triangle in each triangle strip
                        GL.Begin(PrimitiveType.TriangleStrip);
                        cnt = triList.Count;

                        //if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                        if (cnt >= (mipmap))
                        {
                            step = mipmap;
                            for (int i = 1; i < cnt; i += step)
                            {
                                GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;
                                GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;

                                //too small to mipmap it
                                if (cnt - i <= (mipmap + 2))
                                    step = 0;
                            }
                        }
                        else { for (int i = 1; i < cnt; i++) GL.Vertex3(triList[i].easting, triList[i].northing, 0); }
                        GL.End();
                    }
                }
            } //end of section patches
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            oglSelf.Refresh();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnALength_Click(object sender, EventArgs e)
        {
            if (mf.trk.idx > -1)
            {
                //and the beginning
                vec3 start = new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[0]);

                for (int i = 1; i < 50; i+=2)
                {
                    vec3 pt = new vec3(start);
                    pt.easting -= (Math.Sin(pt.heading) * i);
                    pt.northing -= (Math.Cos(pt.heading) * i);
                    mf.trk.tracksArr[mf.trk.idx].trackPts.Insert(0, pt);
                }
            }
        }

        private void btnBLength_Click(object sender, EventArgs e)
        {
            if (mf.trk.idx > -1)
            {
                int ptCnt = mf.trk.tracksArr[mf.trk.idx].trackPts.Count - 1;

                for (int i = 1; i < 50; i+=2)
                {
                    vec3 pt = new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[ptCnt]);
                    pt.easting += (Math.Sin(pt.heading) * i);
                    pt.northing += (Math.Cos(pt.heading) * i);
                    mf.trk.tracksArr[mf.trk.idx].trackPts.Add(pt);
                }
            }
        }

        private void oglSelf_Resize(object sender, EventArgs e)
        {
            oglSelf.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            //58 degrees view
            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView(1.01f, 1.0f, 1.0f, 20000);
            GL.LoadMatrix(ref mat);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void oglSelf_Load(object sender, EventArgs e)
        {
            oglSelf.MakeCurrent();
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.ClearColor(0.22f, 0.22f, 0.22f, 1.0f);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
        }

        #region Help

        private void btnCancelTouch_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_btnCancelTouch, gStr.gsHelp);
        }

        private void nudDistance_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_nudDistance, gStr.gsHelp);
        }

        private void btnFlipOffset_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_btnFlipOffset, gStr.gsHelp);
        }

        private void btnMakeBoundaryCurve_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_btnMakeBoundaryCurve, gStr.gsHelp);
        }

        private void btnMakeCurve_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_btnMakeCurve, gStr.gsHelp);
        }

        private void btnSelectCurve_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_btnSelectCurve, gStr.gsHelp);
        }

        private void btnDeleteCurve_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_btnDeleteCurve, gStr.gsHelp);
        }

        private void btnMakeABLine_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_btnMakeABLine, gStr.gsHelp);
        }

        private void btnSelectABLine_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_btnSelectABLine, gStr.gsHelp);
        }

        private void btnDeleteABLine_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_btnDeleteABLine, gStr.gsHelp);
        }

        private void btnDrawSections_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_btnDrawSections, gStr.gsHelp);
        }

        private void btnExit_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hh_btnExit, gStr.gsHelp);
        }

        private void oglSelf_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_oglSelf, gStr.gsHelp);
        }

        private void tboxNameCurve_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_tboxNameLine, gStr.gsHelp);
        }

        private void rbtnTrackMethod_CheckedChanged(object sender, EventArgs e)
        {
            {
                var checkedButton = headingGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                //mf.headingFromSource = checkedButton.Text;

                //if (rbtnHeadingHDT.Checked)
                //{
                //    gboxSingle.Enabled = false;
                //    gboxDual.Enabled = true;
                //}
                //else
                //{
                //    gboxSingle.Enabled = true;
                //    gboxDual.Enabled = false;
                //}
            }
        }

        private void tboxNameLine_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_tboxNameLine, gStr.gsHelp);
        }

        #endregion Help
    }
}