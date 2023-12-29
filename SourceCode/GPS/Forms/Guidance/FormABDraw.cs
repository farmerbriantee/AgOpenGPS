using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AgOpenGPS
{
    public partial class FormABDraw : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        private Point fixPt;

        private bool isA = true;
        private int start = 99999, end = 99999;
        private int bndSelect = 0, originalLine;
        private bool isCancel = false;
        public List<CTrk> gTemp = new List<CTrk>();

        public vec3 pint = new vec3(0.0, 1.0, 0.0);

        private bool isDrawSections = false;

        public FormABDraw(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            lblCmInch.Text = mf.unitsInCm;

            nudDistance.Controls[0].Enabled = false;

            if (!mf.isMetric)
            {
                nudDistance.Maximum = (int)(nudDistance.Maximum / 2.54M);
                nudDistance.Minimum = (int)(nudDistance.Minimum / 2.54M);
            }

            mf.CalculateMinMax();
        }

        private void FormABDraw_Load(object sender, EventArgs e)
        {
            originalLine = mf.trk.idx;
            nudDistance.Value = (decimal)Math.Round(((mf.tool.width * mf.m2InchOrCm) * 0.5), 0); //
            label6.Text = Math.Round((mf.tool.width * mf.m2InchOrCm), 0).ToString();
            FixLabelsCurve();

            if (isDrawSections) btnDrawSections.Image = Properties.Resources.MappingOn;
            else btnDrawSections.Image = Properties.Resources.MappingOff;
            btnFlipOffset.Text = "In";

            for (int i = 0; i < mf.trk.gArr.Count; i++)
            {
                if (mf.trk.gArr[i].mode == 0)
                    return;
            }

            if (mf.trk.idx == -1)
            {
                if (mf.trk.gArr.Count > 0) mf.trk.idx = 0;
            }

            gTemp.Clear();

            foreach (var item in mf.trk.gArr)
            {
                gTemp.Add(item);
            }

            FixLabelsCurve();
        }

        private void FormABDraw_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isCancel)
            {
                if (mf.trk.gArr.Count == 0)
                    mf.trk.idx = -1;

                if (mf.trk.gArr.Count > 0 && mf.trk.idx == -1)
                    mf.trk.idx = mf.trk.gArr.Count - 1;

                if (mf.trk.idx == -1)
                {
                    if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
                    if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();
                }

                mf.FileSaveTracks();
            }
            else
            {
                mf.trk.gArr.Clear();

                foreach (var item in gTemp)
                {
                    mf.trk.gArr.Add(new CTrk(item));
                }

                mf.trk.idx = originalLine;
            }

            mf.curve.isCurveValid = false;
            mf.ABLine.isABValid = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            isCancel = false;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isCancel = true; 
            Close();
        }

        private void FixLabelsCurve()
        {
            lblNumCu.Text = mf.trk.gArr.Count.ToString();

            if (mf.trk.idx > -1)
            {
                tboxNameCurve.Text = mf.trk.gArr[mf.trk.idx].name;
                tboxNameCurve.Enabled = true;
                lblCurveSelected.Text = (mf.trk.idx + 1).ToString();
            }
            else
            {
                tboxNameCurve.Text = "***";
                tboxNameCurve.Enabled = false;
                lblCurveSelected.Text = "*";
            }
        }

        private void btnSelectCurve_Click(object sender, EventArgs e)
        {
            if (mf.trk.gArr.Count > 0)
            {
                mf.trk.idx++;
                if (mf.trk.idx > (mf.trk.gArr.Count - 1)) mf.trk.idx = 0;
            }
            else
            {
                mf.trk.idx = -1;
            }

            FixLabelsCurve();

            //if (mf.curve.numCurveLines > 0)
            //{
            //    mf.curve.numCurveLineSelected++;
            //    if (mf.curve.numCurveLineSelected > mf.curve.numCurveLines) mf.curve.numCurveLineSelected = 1;
            //}
            //else
            //{
            //    mf.curve.numCurveLineSelected = 0;
            //}

            //FixLabelsCurve();
        }

        private void btnCancelTouch_Click(object sender, EventArgs e)
        {
            btnMakeABLine.Enabled = false;
            btnMakeCurve.Enabled = false;

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
            if (mf.trk.idx > -1)
            {
                mf.trk.gArr.RemoveAt(mf.trk.idx);
            }

            if (mf.trk.gArr.Count > 0)
                mf.trk.idx = mf.trk.gArr.Count - 1;
            else
                mf.trk.idx = -1;

            FixLabelsCurve();
        }

        private void btnDrawSections_Click(object sender, EventArgs e)
        {
            isDrawSections = !isDrawSections;
            if (isDrawSections) btnDrawSections.Image = Properties.Resources.MappingOn;
            else btnDrawSections.Image = Properties.Resources.MappingOff;
        }

        private void btnFlipOffset_Click(object sender, EventArgs e)
        {
            nudDistance.Value *= -1;
            if (nudDistance.Value < 0) btnFlipOffset.Text = "Out";
            else btnFlipOffset.Text = "In";
        }

        private void tboxNameCurve_Leave(object sender, EventArgs e)
        {
            if (mf.trk.idx > -1)
                mf.trk.gArr[mf.trk.idx].name = tboxNameCurve.Text.Trim();
            btnExit.Focus();
        }

        private void tboxNameCurve_Enter(object sender, EventArgs e)
        {

            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((System.Windows.Forms.TextBox)sender, this);
                
                if (mf.trk.idx > -1)
                    mf.trk.gArr[mf.trk.idx].name = tboxNameCurve.Text.Trim();
                btnExit.Focus();
            }
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            if (mf.trk.idx > -1)
            {
                mf.trk.gArr[mf.trk.idx].name += DateTime.Now.ToString(" hh:mm:ss", CultureInfo.InvariantCulture);
                FixLabelsCurve();
            }
        }

        private void btnMakeBoundaryCurve_Click(object sender, EventArgs e)
        {            //count the points from the boundary
            for (int q = 0; q < mf.bnd.bndList.Count; q++)
            {
                int ptCount = mf.bnd.bndList[q].fenceLine.Count;
                mf.curve.desList?.Clear();

                //outside point
                vec3 pt3 = new vec3();

                double moveDist = (double)nudDistance.Value * mf.inchOrCm2m;
                double distSq = (moveDist) * (moveDist) * 0.999;

                //make the boundary tram outer array
                for (int i = 0; i < ptCount; i++)
                {
                    //calculate the point inside the boundary
                    pt3.easting = mf.bnd.bndList[q].fenceLine[i].easting -
                        (Math.Sin(glm.PIBy2 + mf.bnd.bndList[q].fenceLine[i].heading) * (moveDist));

                    pt3.northing = mf.bnd.bndList[q].fenceLine[i].northing -
                        (Math.Cos(glm.PIBy2 + mf.bnd.bndList[q].fenceLine[i].heading) * (moveDist));

                    pt3.heading = mf.bnd.bndList[q].fenceLine[i].heading;

                    bool Add = true;

                    for (int j = 0; j < ptCount; j++)
                    {
                        double check = glm.DistanceSquared(pt3.northing, pt3.easting,
                                            mf.bnd.bndList[q].fenceLine[j].northing, mf.bnd.bndList[q].fenceLine[j].easting);
                        if (check < distSq)
                        {
                            Add = false;
                            break;
                        }
                    }

                    if (Add)
                    {
                        if (mf.curve.desList.Count > 0)
                        {
                            double dist = ((pt3.easting - mf.curve.desList[mf.curve.desList.Count - 1].easting) * (pt3.easting - mf.curve.desList[mf.curve.desList.Count - 1].easting))
                                + ((pt3.northing - mf.curve.desList[mf.curve.desList.Count - 1].northing) * (pt3.northing - mf.curve.desList[mf.curve.desList.Count - 1].northing));
                            if (dist > 1)
                                mf.curve.desList.Add(pt3);
                        }
                        else mf.curve.desList.Add(pt3);
                    }
                }

                mf.trk.gArr.Add(new CTrk());
                //array number is 1 less since it starts at zero
                mf.trk.idx = mf.trk.gArr.Count - 1;
                
                mf.trk.gArr[mf.trk.idx].ptA = new vec2(mf.curve.desList[0].easting, mf.curve.desList[0].northing);
                mf.trk.gArr[mf.trk.idx].ptB = new vec2(mf.curve.desList[mf.curve.desList.Count - 1].easting, mf.curve.desList[mf.curve.desList.Count - 1].northing);

                pt3 = new vec3(mf.curve.desList[0]);
                mf.curve.desList.Add(pt3);

                btnCancelTouch.Enabled = false;

                int cnt = mf.curve.desList.Count;
                if (cnt > 3)
                {
                    pt3 = new vec3(mf.curve.desList[0]);
                    mf.curve.desList.Add(pt3);

                    //make sure distance isn't too big between points on Turn
                    for (int i = 0; i < cnt - 1; i++)
                    {
                        int j = i + 1;
                        //if (j == cnt) j = 0;
                        double distance = glm.Distance(mf.curve.desList[i], mf.curve.desList[j]);
                        if (distance > 1.2)
                        {
                            vec3 pointB = new vec3((mf.curve.desList[i].easting + mf.curve.desList[j].easting) / 2.0,
                                (mf.curve.desList[i].northing + mf.curve.desList[j].northing) / 2.0,
                                mf.curve.desList[i].heading);

                            mf.curve.desList.Insert(j, pointB);
                            cnt = mf.curve.desList.Count;
                            i = -1;
                        }
                    }
                    //who knows which way it actually goes
                    mf.curve.CalculateTurnHeadings();

                    //create a name
                    mf.trk.gArr[mf.trk.idx].name = "Boundary Curve";

                    if (q > 0) mf.trk.gArr[mf.trk.idx].name = "Inner Boundary Curve " + q.ToString();

                    mf.trk.gArr[mf.trk.idx].heading = 0;
                    mf.trk.gArr[mf.trk.idx].mode = (int)TrackMode.bndCurve;

                    //write out the Curve Points
                    foreach (vec3 item in mf.curve.desList)
                    {
                        mf.trk.gArr[mf.trk.idx].curvePts.Add(item);
                    }
                }
            }

            //update the arrays
            btnMakeABLine.Enabled = false;
            btnMakeCurve.Enabled = false;
            start = 99999; end = 99999;

            FixLabelsCurve();

            mf.curve.desList?.Clear();

            btnExit.Focus();
        }

        private void BtnMakeCurve_Click(object sender, EventArgs e)
        {
            btnCancelTouch.Enabled = false;

            bool isLoop = false;
            int limit = end;

            if ((Math.Abs(start - end)) > (mf.bnd.bndList[bndSelect].fenceLine.Count * 0.5))
            {
                isLoop = true;
                if (start < end)
                {
                    (end, start) = (start, end);
                }

                limit = end;
                end = mf.bnd.bndList[bndSelect].fenceLine.Count;
            }
            else //normal
            {
                if (start > end)
                {
                    (end, start) = (start, end);
                }
            }

            double moveDist = (double)nudDistance.Value * mf.inchOrCm2m;
            double distSq = (moveDist) * (moveDist) * 0.999;

            mf.curve.desList?.Clear();
            vec3 pt3 = new vec3();

            for (int i = start; i < end; i++)
            {
                //calculate the point inside the boundary
                pt3.easting = mf.bnd.bndList[bndSelect].fenceLine[i].easting -
                    (Math.Sin(glm.PIBy2 + mf.bnd.bndList[bndSelect].fenceLine[i].heading) * (moveDist));

                pt3.northing = mf.bnd.bndList[bndSelect].fenceLine[i].northing -
                    (Math.Cos(glm.PIBy2 + mf.bnd.bndList[bndSelect].fenceLine[i].heading) * (moveDist));

                pt3.heading = mf.bnd.bndList[bndSelect].fenceLine[i].heading;

                bool Add = true;

                for (int j = start; j < end; j++)
                {
                    double check = glm.DistanceSquared(pt3.northing, pt3.easting,
                                        mf.bnd.bndList[bndSelect].fenceLine[j].northing, mf.bnd.bndList[bndSelect].fenceLine[j].easting);
                    if (check < distSq)
                    {
                        Add = false;
                        break;
                    }
                }

                if (Add)
                {
                    if (mf.curve.desList.Count > 0)
                    {
                        double dist = ((pt3.easting - mf.curve.desList[mf.curve.desList.Count - 1].easting) * (pt3.easting - mf.curve.desList[mf.curve.desList.Count - 1].easting))
                            + ((pt3.northing - mf.curve.desList[mf.curve.desList.Count - 1].northing) * (pt3.northing - mf.curve.desList[mf.curve.desList.Count - 1].northing));
                        if (dist > 1)
                            mf.curve.desList.Add(pt3);
                    }
                    else mf.curve.desList.Add(pt3);
                }

                if (isLoop && i == mf.bnd.bndList[bndSelect].fenceLine.Count - 1)
                {
                    i = -1;
                    isLoop = false;
                    end = limit;
                }
            }

            mf.trk.gArr.Add(new CTrk());
            //array number is 1 less since it starts at zero
            mf.trk.idx = mf.trk.gArr.Count - 1;

            mf.trk.gArr[mf.trk.idx].ptA = 
                new vec2(mf.curve.desList[0].easting, mf.curve.desList[0].northing);
            mf.trk.gArr[mf.trk.idx].ptB = 
                new vec2(mf.curve.desList[mf.curve.desList.Count - 1].easting, 
                mf.curve.desList[mf.curve.desList.Count - 1].northing);

            int cnt = mf.curve.desList.Count;
            if (cnt > 3)
            {
                //make sure distance isn't too big between points on Turn
                for (int i = 0; i < cnt - 1; i++)
                {
                    int j = i + 1;
                    //if (j == cnt) j = 0;
                    double distance = glm.Distance(mf.curve.desList[i], mf.curve.desList[j]);
                    if (distance > 1.6)
                    {
                        vec3 pointB = new vec3((mf.curve.desList[i].easting + mf.curve.desList[j].easting) / 2.0,
                            (mf.curve.desList[i].northing + mf.curve.desList[j].northing) / 2.0,
                            mf.curve.desList[i].heading);

                        mf.curve.desList.Insert(j, pointB);
                        cnt = mf.curve.desList.Count;
                        i = -1;
                    }
                }

                //who knows which way it actually goes
                mf.curve.CalculateTurnHeadings();

                //calculate average heading of line
                double x = 0, y = 0;

                foreach (vec3 pt in mf.curve.desList)
                {
                    x += Math.Cos(pt.heading);
                    y += Math.Sin(pt.heading);
                }
                x /= mf.curve.desList.Count;
                y /= mf.curve.desList.Count;
                mf.trk.gArr[mf.trk.idx].heading = Math.Atan2(y, x);
                if (mf.trk.gArr[mf.trk.idx].heading < 0) mf.trk.gArr[mf.trk.idx].heading += glm.twoPI;

                //build the tail extensions
                mf.curve.AddFirstLastPoints(ref mf.curve.desList);
                mf.curve.SmoothAB(4);
                mf.curve.CalculateTurnHeadings();

                //array number is 1 less since it starts at zero
                mf.trk.idx = mf.trk.gArr.Count - 1;

                //create a name
                mf.trk.gArr[mf.trk.idx].name = "Cu " +
                    (Math.Round(glm.toDegrees(mf.trk.gArr[mf.trk.idx].heading), 1)).ToString(CultureInfo.InvariantCulture)
                    + "\u00B0" ;

                mf.trk.gArr[mf.trk.idx].mode = (int)TrackMode.Curve;

                //write out the Curve Points
                foreach (vec3 item in mf.curve.desList)
                {
                    mf.trk.gArr[mf.trk.idx].curvePts.Add(item);
                }

                //update the arrays
                btnMakeABLine.Enabled = false;
                btnMakeCurve.Enabled = false;
                start = 99999; end = 99999;

                FixLabelsCurve();
            }
            else
            {
            }
            btnExit.Focus();
            mf.curve.desList?.Clear();
        }

        private void BtnMakeABLine_Click(object sender, EventArgs e)
        {
            btnCancelTouch.Enabled = false;

            //if more then half way around, it crosses start finish
            if ((Math.Abs(start - end)) <= (mf.bnd.bndList[bndSelect].fenceLine.Count * 0.5))
            {
                if (start < end)
                {
                    (end, start) = (start, end);
                }
            }
            else
            {
                if (start > end)
                {
                    (end, start) = (start, end);
                }
            }

            //calculate the AB Heading
            double abHead = Math.Atan2(
                mf.bnd.bndList[bndSelect].fenceLine[end].easting - mf.bnd.bndList[bndSelect].fenceLine[start].easting,
                mf.bnd.bndList[bndSelect].fenceLine[end].northing - mf.bnd.bndList[bndSelect].fenceLine[start].northing);
            if (abHead < 0) abHead += glm.twoPI;

            double offset = ((double)nudDistance.Value * mf.inchOrCm2m);

            double headingCalc = abHead + glm.PIBy2;

            mf.trk.gArr.Add(new CTrk());

            mf.trk.idx = mf.trk.gArr.Count - 1;

            mf.trk.gArr[mf.trk.idx].heading = abHead;
            mf.trk.gArr[mf.trk.idx].mode = (int)TrackMode.AB;

            //calculate the new points for the reference line and points
            mf.trk.gArr[mf.trk.idx].ptA.easting = (Math.Sin(headingCalc) * (offset)) + mf.bnd.bndList[bndSelect].fenceLine[start].easting;
            mf.trk.gArr[mf.trk.idx].ptA.northing = (Math.Cos(headingCalc) * (offset)) + mf.bnd.bndList[bndSelect].fenceLine[start].northing;

            mf.trk.gArr[mf.trk.idx].ptB.easting = (Math.Sin(headingCalc) * (offset)) + mf.bnd.bndList[bndSelect].fenceLine[end].easting;
            mf.trk.gArr[mf.trk.idx].ptB.northing = (Math.Cos(headingCalc) * (offset)) + mf.bnd.bndList[bndSelect].fenceLine[end].northing;

            //create a name
            mf.trk.gArr[mf.trk.idx].name = "AB " + 
                (Math.Round(glm.toDegrees(mf.trk.gArr[mf.trk.idx].heading), 1)).ToString(CultureInfo.InvariantCulture) + "\u00B0" ;

            //clean up gui
            btnMakeABLine.Enabled = false;
            btnMakeCurve.Enabled = false;

            start = 99999; end = 99999;

            FixLabelsCurve();
        }

        private void oglSelf_MouseDown(object sender, MouseEventArgs e)
        {
            btnCancelTouch.Enabled = true;

            btnMakeABLine.Enabled = false;
            btnMakeCurve.Enabled = false;

            Point pt = oglSelf.PointToClient(Cursor.Position);

            //Convert to Origin in the center of window, 800 pixels
            fixPt.X = pt.X - 350;
            fixPt.Y = (700 - pt.Y - 350);
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

                btnMakeABLine.Enabled = true;
                btnMakeCurve.Enabled = true;
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

            //draw all the boundaries

            GL.LineWidth(mf.ABLine.lineWidth * 2);

            for (int j = 0; j < mf.bnd.bndList.Count; j++)
            {
                if (j == bndSelect)
                    GL.Color3(0.75f, 0.975f, 0.950f);
                else
                    GL.Color3(0.4f, 0.75f, 0.70f);

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
            if (start != 99999 || end != 99999) DrawABTouchPoints();

            //draw the actual built lines
            if (start == 99999 && end == 99999)
            {
                DrawBuiltLines();
            }

            GL.Flush();
            oglSelf.SwapBuffers();
        }

        private void DrawBuiltLines()
        {
            GL.LineStipple(1, 0x0707);
            for (int i = 0; i < mf.trk.gArr.Count; i++)
            {
                //AB Lines
                if (mf.trk.gArr[i].mode == (int)TrackMode.AB)
                {
                    GL.Enable(EnableCap.LineStipple);
                    GL.LineWidth(2);

                    if (i == mf.trk.idx)
                    {
                        GL.LineWidth(4);
                        GL.Disable(EnableCap.LineStipple);
                    }
                    GL.Color3(1.0f, 0.0f, 0.0f);

                    GL.Begin(PrimitiveType.Lines);

                    GL.Vertex3(mf.trk.gArr[i].ptA.easting - (Math.Sin(mf.trk.gArr[i].heading) * mf.ABLine.abLength), mf.trk.gArr[i].ptA.northing - (Math.Cos(mf.trk.gArr[i].heading) * mf.ABLine.abLength), 0);
                    GL.Vertex3(mf.trk.gArr[i].ptA.easting + (Math.Sin(mf.trk.gArr[i].heading) * mf.ABLine.abLength), mf.trk.gArr[i].ptA.northing + (Math.Cos(mf.trk.gArr[i].heading) * mf.ABLine.abLength), 0);

                    GL.End();

                    GL.Disable(EnableCap.LineStipple);

                    //if (mf.ABLine.numABLineSelected > 0)
                    //{
                    //    GL.Color3(1.0f, 0.0f, 0.0f);

                    //    GL.LineWidth(4);
                    //    GL.Begin(PrimitiveType.Lines);

                    //    GL.Vertex3(mf.trk.gArr[mf.ABLine.numABLineSelected - 1].ptA.easting - (Math.Sin(mf.trk.gArr[mf.ABLine.numABLineSelected - 1].heading) * mf.ABLine.abLength),
                    //        mf.trk.gArr[mf.ABLine.numABLineSelected - 1].ptA.northing - (Math.Cos(mf.trk.gArr[mf.ABLine.numABLineSelected - 1].heading) * mf.ABLine.abLength), 0);
                    //    GL.Vertex3(mf.trk.gArr[mf.ABLine.numABLineSelected - 1].ptA.easting + (Math.Sin(mf.trk.gArr[mf.ABLine.numABLineSelected - 1].heading) * mf.ABLine.abLength),
                    //        mf.trk.gArr[mf.ABLine.numABLineSelected - 1].ptA.northing + (Math.Cos(mf.trk.gArr[mf.ABLine.numABLineSelected - 1].heading) * mf.ABLine.abLength), 0);

                    //    GL.End();
                    //}

                }

                else if (mf.trk.gArr[i].mode == (int)TrackMode.Curve || mf.trk.gArr[i].mode == (int)TrackMode.bndCurve)
                {
                    GL.Enable(EnableCap.LineStipple);
                    GL.LineWidth(2);

                    if (i == mf.trk.idx)
                    {
                        GL.LineWidth(4);
                        GL.Disable(EnableCap.LineStipple);
                    }

                    GL.Color3(0.0f, 1.0f, 0.0f);
                    GL.Begin(PrimitiveType.LineStrip);
                    foreach (vec3 pts in mf.trk.gArr[i].curvePts)
                    {
                        GL.Vertex3(pts.easting, pts.northing, 0);
                    }
                    GL.End();

                    GL.Disable(EnableCap.LineStipple);

                    GL.PointSize(24);
                    GL.Color3(0, 0, 0);
                    GL.Begin(PrimitiveType.Points);

                    GL.Vertex3(mf.trk.gArr[i].curvePts[0].easting,
                                mf.trk.gArr[i].curvePts[0].northing,
                                0);

                    GL.Color3(0, 0, 0);
                    GL.Vertex3(mf.trk.gArr[i].curvePts[mf.trk.gArr[i].curvePts.Count - 1].easting,
                                mf.trk.gArr[i].curvePts[mf.trk.gArr[i].curvePts.Count - 1].northing,
                                0);

                    GL.End();

                    GL.PointSize(16);
                    GL.Color3(1.0f, 0.75f, 0.350f);
                    GL.Begin(PrimitiveType.Points);

                    GL.Vertex3(mf.trk.gArr[i].curvePts[0].easting,
                                mf.trk.gArr[i].curvePts[0].northing,
                                0);


                    GL.Color3(0.5f, 0.5f, 1.0f);
                    GL.Vertex3(mf.trk.gArr[i].curvePts[mf.trk.gArr[i].curvePts.Count - 1].easting,
                                mf.trk.gArr[i].curvePts[mf.trk.gArr[i].curvePts.Count - 1].northing,
                                0);
                    GL.End();
                }
            }
        }

        private void DrawABTouchPoints()
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            oglSelf.Refresh();

            btnMakeBoundaryCurve.Enabled = true; 
            for (int i = 0; i < mf.trk.gArr.Count; i++)
            {
                if (mf.trk.gArr[i].mode == (int)TrackMode.bndCurve)
                {
                    btnMakeBoundaryCurve.Enabled = false;
                    break;
                }
            }

            if (mf.trk.idx > -1 && mf.trk.gArr[mf.trk.idx].mode != (int)TrackMode.Curve)
            {
                btnALength.Enabled = false;
                btnBLength.Enabled = false;
            }
            else
            {
                btnALength.Enabled = true;
                btnBLength.Enabled = true;
            }
        }

        private void btnALength_Click(object sender, EventArgs e)
        {
            if (mf.trk.idx > -1 && mf.trk.gArr[mf.trk.idx].mode == (int)TrackMode.Curve)
            {
                //and the beginning
                vec3 start = new vec3(mf.trk.gArr[mf.trk.idx].curvePts[0]);

                for (int i = 1; i < 50; i++)
                {
                    vec3 pt = new vec3(start);
                    pt.easting -= (Math.Sin(pt.heading) * i);
                    pt.northing -= (Math.Cos(pt.heading) * i);
                    mf.trk.gArr[mf.trk.idx].curvePts.Insert(0, pt);
                }
            }
        }

        private void btnBLength_Click(object sender, EventArgs e)
        {
            if (mf.trk.idx > -1 && mf.trk.gArr[mf.trk.idx].mode == (int)TrackMode.Curve)
            {
                int ptCnt = mf.trk.gArr[mf.trk.idx].curvePts.Count - 1;

                for (int i = 1; i < 50; i++)
                {
                    vec3 pt = new vec3(mf.trk.gArr[mf.trk.idx].curvePts[ptCnt]);
                    pt.easting += (Math.Sin(pt.heading) * i);
                    pt.northing += (Math.Cos(pt.heading) * i);
                    mf.trk.gArr[mf.trk.idx].curvePts.Add(pt);
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
            GL.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
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

        private void tboxNameLine_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_tboxNameLine, gStr.gsHelp);
        }

        #endregion Help
    }
}