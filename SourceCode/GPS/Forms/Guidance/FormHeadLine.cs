using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace AgOpenGPS
{
    public partial class FormHeadLine : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        private Point fixPt;

        private bool isA = true;
        private int start = 99999, end = 99999;
        private int bndSelect = 0;

        public vec3 pint = new vec3(0.0, 1.0, 0.0);

        public FormHeadLine(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            mf.CalculateMinMax();
        }

        private void FormHeadLine_Load(object sender, EventArgs e)
        {
            mf.hdl.idx = -1;
            label3.Text = mf.unitsFtM;
        }

        private void FormHeadLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            //hdl
            if (mf.hdl.idx == -1)
            {
                if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
                if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();
            }

            if (mf.hdl.sliceArr.Count > 0)
            {
                mf.hdl.idx = 0;
            }
            else mf.hdl.idx = -1;
        }

        private void oglSelf_MouseDown(object sender, MouseEventArgs e)
        {
            mf.hdl.sliceArr?.Clear();

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
                    mf.hdl.sliceArr.Add(new CHeadPath());
                    mf.hdl.idx = mf.hdl.sliceArr.Count - 1;

                    bool isLoop = false;
                    int limit = end;


                    if ((Math.Abs(start - end)) > (mf.bnd.bndList[bndSelect].fenceLine.Count * 0.5))
                    {
                        if (start < end)
                        {
                            (start, end) = (end, start);
                        }

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
                        if (start > end)
                        {
                            (start, end) = (end, start);
                        }
                    }

                    mf.hdl.sliceArr[mf.hdl.idx].trackPts?.Clear();
                    vec3 pt3 = new vec3();

                    if (start < end)
                    {
                        for (int i = start; i <= end; i++)
                        {
                            //calculate the point inside the boundary
                            pt3 = mf.bnd.bndList[bndSelect].fenceLine[i];
                            mf.hdl.sliceArr[mf.hdl.idx].trackPts.Add(pt3);

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
                            mf.hdl.sliceArr[mf.hdl.idx].trackPts.Add(pt3);

                            if (isLoop && i == 0)
                            {
                                i = mf.bnd.bndList[bndSelect].fenceLine.Count - 1;
                                isLoop = false;
                                end = limit;
                            }
                        }
                    }

                    //who knows which way it actually goes
                    mf.hdl.CalculateHeadings(ref mf.hdl.sliceArr[mf.hdl.idx].trackPts);

                    int ptCnt = mf.hdl.sliceArr[mf.hdl.idx].trackPts.Count - 1;

                    for (int i = 1; i < 50; i++)
                    {
                        vec3 pt = new vec3(mf.hdl.sliceArr[mf.hdl.idx].trackPts[ptCnt]);
                        pt.easting += (Math.Sin(pt.heading) * i);
                        pt.northing += (Math.Cos(pt.heading) * i);
                        mf.hdl.sliceArr[mf.hdl.idx].trackPts.Add(pt);
                    }

                    vec3 stat = new vec3(mf.hdl.sliceArr[mf.hdl.idx].trackPts[0]);

                    for (int i = 1; i < 50; i++)
                    {
                        vec3 pt = new vec3(stat);
                        pt.easting -= (Math.Sin(pt.heading) * i);
                        pt.northing -= (Math.Cos(pt.heading) * i);
                        mf.hdl.sliceArr[mf.hdl.idx].trackPts.Insert(0, pt);
                    }

                    mf.hdl.sliceArr[mf.hdl.idx].mode = (int)TrackMode.Curve;

                    //update the arrays
                    start = 99999; end = 99999;

                    btnExit.Focus();
                }

                else if (rbtnLine.Checked)
                {
                    if ((Math.Abs(start - end)) > (mf.bnd.bndList[bndSelect].fenceLine.Count * 0.5))
                    {
                        if (start < end)
                        {
                            (start, end) = (end, start);
                        }
                    }

                    else
                    {
                        if (start > end)
                        {
                            (start, end) = (end, start);
                        }
                    }

                    vec3 ptA = new vec3(mf.bnd.bndList[bndSelect].fenceLine[start]);
                    vec3 ptB = new vec3(mf.bnd.bndList[bndSelect].fenceLine[end]);

                    //calculate the AB Heading
                    double abHead = Math.Atan2(
                        mf.bnd.bndList[bndSelect].fenceLine[end].easting - mf.bnd.bndList[bndSelect].fenceLine[start].easting,
                        mf.bnd.bndList[bndSelect].fenceLine[end].northing - mf.bnd.bndList[bndSelect].fenceLine[start].northing);
                    if (abHead < 0) abHead += glm.twoPI;

                    if (mf.hdl.idx < mf.hdl.sliceArr.Count - 1)
                    {
                        mf.hdl.idx++;
                        mf.hdl.sliceArr.Insert(mf.hdl.idx, new CHeadPath());
                    }
                    else
                    {
                        mf.hdl.sliceArr.Add(new CHeadPath());
                        mf.hdl.idx = mf.hdl.sliceArr.Count - 1;
                    }

                    mf.hdl.sliceArr[mf.hdl.idx].trackPts?.Clear();

                    ptA.heading = abHead;
                    ptB.heading = abHead;

                    for (int i = 0; i <= (int)(glm.Distance(ptA, ptB)); i++)
                    {
                        vec3 ptC = new vec3(ptA);
                        ptC.easting = (Math.Sin(abHead) * i) + ptA.easting;
                        ptC.northing = (Math.Cos(abHead) * i) + ptA.northing;
                        ptC.heading = abHead;
                        mf.hdl.sliceArr[mf.hdl.idx].trackPts.Add(ptC);
                    }

                    int ptCnt = mf.hdl.sliceArr[mf.hdl.idx].trackPts.Count - 1;

                    for (int i = 1; i < 30; i++)
                    {
                        vec3 pt = new vec3(mf.hdl.sliceArr[mf.hdl.idx].trackPts[ptCnt]);
                        pt.easting += (Math.Sin(pt.heading) * i);
                        pt.northing += (Math.Cos(pt.heading) * i);
                        mf.hdl.sliceArr[mf.hdl.idx].trackPts.Add(pt);
                    }

                    vec3 stat = new vec3(mf.hdl.sliceArr[mf.hdl.idx].trackPts[0]);

                    for (int i = 1; i < 30; i++)
                    {
                        vec3 pt = new vec3(stat);
                        pt.easting -= (Math.Sin(pt.heading) * i);
                        pt.northing -= (Math.Cos(pt.heading) * i);
                        mf.hdl.sliceArr[mf.hdl.idx].trackPts.Insert(0, pt);
                    }

                    mf.hdl.sliceArr[mf.hdl.idx].mode = (int)TrackMode.AB;

                    start = 99999; end = 99999;
                }

                //Move the line
                if (nudSetDistance.Value != 0)
                    btnSetLineDistance_Click(this,e);
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

            GL.LineWidth(1);

            for (int j = 0; j < mf.bnd.bndList.Count; j++)
            {
                if (j == bndSelect)
                    GL.Color3(0.25f, 0.5f, 0.20f);
                else
                    GL.Color3(0.50f, 0.25f, 0.10f);

                GL.Begin(PrimitiveType.LineStrip);
                for (int i = 0; i < mf.bnd.bndList[j].fenceLine.Count; i++)
                {
                    GL.Vertex3(mf.bnd.bndList[j].fenceLine[i].easting, mf.bnd.bndList[j].fenceLine[i].northing, 0);
                }
                GL.End();
            }

            //the vehicle
            GL.PointSize(8.0f);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(0.95f, 0.90f, 0.0f);
            GL.Vertex3(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing, 0.0);
            GL.End();

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
            if (mf.hdl.sliceArr.Count == 0) btnSlice.Enabled = false;
            else btnSlice.Enabled = true;

            GL.LineWidth(4);
            GL.Color3(0.93f, 0.599f, 0.50f);
            GL.Begin(PrimitiveType.LineStrip);

            for (int i = 0; i < mf.bnd.bndList[0].hdLine.Count; i++)
            {
                GL.Vertex3(mf.bnd.bndList[0].hdLine[i].easting, mf.bnd.bndList[0].hdLine[i].northing, 0);
            }
            GL.End();

            if (mf.hdl.sliceArr.Count > 0)
            {
                //GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0x7070);
                GL.PointSize(2);

                for (int i = 0; i < mf.hdl.sliceArr.Count; i++)
                {
                    if (mf.hdl.sliceArr[i].mode == (int)TrackMode.AB)
                    {
                        GL.Color3(0.973f, 0.19f, 0.10f);
                    }
                    else
                    {
                        GL.Color3(0.3f, 0.99f, 0.20f);
                    }

                    GL.Begin(PrimitiveType.Points);
                    foreach (vec3 item in mf.hdl.sliceArr[i].trackPts)
                    {
                        GL.Vertex3(item.easting, item.northing, 0);
                    }
                    GL.End();
                }

                //GL.Disable(EnableCap.LineStipple);

                if (mf.hdl.idx > -1)
                {
                    GL.LineWidth(2);
                    GL.Color3(1.0f, 0.0f, 1.0f);

                    GL.Begin(PrimitiveType.LineStrip);
                    foreach (vec3 item in mf.hdl.sliceArr[mf.hdl.idx].trackPts)
                    {
                        GL.Vertex3(item.easting, item.northing, 0);
                    }
                    GL.End();

                    GL.PointSize(8);
                    GL.Color3(1.0f, 1.0f, 1.0f);
                    GL.Begin(PrimitiveType.Points);
                    GL.Vertex3(mf.hdl.sliceArr[mf.hdl.idx].trackPts[0].easting, mf.hdl.sliceArr[mf.hdl.idx].trackPts[0].northing, 0);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            oglSelf.Refresh();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            mf.FileSaveHeadland();
            Close();
        }

        private void btnALength_Click(object sender, EventArgs e)
        {
            if (mf.hdl.idx > -1)
            {
                //and the beginning
                vec3 start = new vec3(mf.hdl.sliceArr[mf.hdl.idx].trackPts[0]);

                for (int i = 1; i < 10; i++)
                {
                    vec3 pt = new vec3(start);
                    pt.easting -= (Math.Sin(pt.heading) * i);
                    pt.northing -= (Math.Cos(pt.heading) * i);
                    mf.hdl.sliceArr[mf.hdl.idx].trackPts.Insert(0, pt);
                }
            }
        }

        private void btnBLength_Click(object sender, EventArgs e)
        {
            if (mf.hdl.idx > -1)
            {
                int ptCnt = mf.hdl.sliceArr[mf.hdl.idx].trackPts.Count - 1;

                for (int i = 1; i < 10; i++)
                {
                    vec3 pt = new vec3(mf.hdl.sliceArr[mf.hdl.idx].trackPts[ptCnt]);
                    pt.easting += (Math.Sin(pt.heading) * i);
                    pt.northing += (Math.Cos(pt.heading) * i);
                    mf.hdl.sliceArr[mf.hdl.idx].trackPts.Add(pt);
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

        private void btnSetLineDistance_Click(object sender, EventArgs e)
        {
            //mf.bnd.bndList[0].hdLine?.Clear();
            mf.hdl.desList?.Clear();

            if (mf.hdl.sliceArr.Count < 1 || mf.hdl.idx == -1) return;

            double distAway = (double)nudSetDistance.Value * mf.ftOrMtoM;
            mf.hdl.sliceArr[mf.hdl.idx].moveDistance += distAway;

            double distSqAway = (distAway * distAway) - 0.01;
            vec3 point;

            int refCount = mf.hdl.sliceArr[mf.hdl.idx].trackPts.Count;
            for (int i = 0; i < refCount; i++)
            {
                point = new vec3(
                mf.hdl.sliceArr[mf.hdl.idx].trackPts[i].easting - (Math.Sin(glm.PIBy2 + mf.hdl.sliceArr[mf.hdl.idx].trackPts[i].heading) * distAway),
                mf.hdl.sliceArr[mf.hdl.idx].trackPts[i].northing - (Math.Cos(glm.PIBy2 + mf.hdl.sliceArr[mf.hdl.idx].trackPts[i].heading) * distAway),
                mf.hdl.sliceArr[mf.hdl.idx].trackPts[i].heading);
                bool Add = true;

                for (int t = 0; t < refCount; t++)
                {
                    double dist = ((point.easting - mf.hdl.sliceArr[mf.hdl.idx].trackPts[t].easting) * (point.easting - mf.hdl.sliceArr[mf.hdl.idx].trackPts[t].easting))
                        + ((point.northing - mf.hdl.sliceArr[mf.hdl.idx].trackPts[t].northing) * (point.northing - mf.hdl.sliceArr[mf.hdl.idx].trackPts[t].northing));
                    if (dist < distSqAway)
                    {
                        Add = false;
                        break;
                    }
                }

                if (Add)
                {
                    if (mf.hdl.desList.Count > 0)
                    {
                        double dist = ((point.easting - mf.hdl.desList[mf.hdl.desList.Count - 1].easting) * (point.easting - mf.hdl.desList[mf.hdl.desList.Count - 1].easting))
                            + ((point.northing - mf.hdl.desList[mf.hdl.desList.Count - 1].northing) * (point.northing - mf.hdl.desList[mf.hdl.desList.Count - 1].northing));
                        if (dist > 1)
                            mf.hdl.desList.Add(point);
                    }
                    else mf.hdl.desList.Add(point);
                }
            }

            mf.hdl.sliceArr[mf.hdl.idx].trackPts.Clear();

            for (int i = 0; i < mf.hdl.desList.Count; i++)
            {                
                mf.hdl.sliceArr[mf.hdl.idx].trackPts.Add(new vec3(mf.hdl.desList[i]));
            }

            mf.hdl.desList?.Clear();
        }

        private void nudSetDistance_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            btnExit.Focus();
        }

        // Returns 1 if the lines intersect, otherwis
        public double iE = 0, iN = 0;
        public List<int> crossings = new List<int>(1);

        private void btnBndLoop_Click(object sender, EventArgs e)
        {
            int ptCount = mf.bnd.bndList[0].fenceLine.Count;

            if (nudSetDistance.Value == 0)
            {
                mf.hdl.desList.Clear();

                mf.bnd.bndList[0].hdLine?.Clear();

                for (int i = 0; i < ptCount; i++)
                {
                    mf.bnd.bndList[0].hdLine.Add(new vec3(mf.bnd.bndList[0].fenceLine[i]));
                }
            }
            else
            {
                mf.hdl.desList?.Clear();

                //outside point
                vec3 pt3 = new vec3();

                double moveDist = (double)nudSetDistance.Value * mf.m2FtOrM;
                double distSq = (moveDist) * (moveDist) * 0.999;

                //make the boundary tram outer array
                for (int i = 0; i < ptCount; i++)
                {
                    //calculate the point inside the boundary
                    pt3.easting = mf.bnd.bndList[0].fenceLine[i].easting -
                        (Math.Sin(glm.PIBy2 + mf.bnd.bndList[0].fenceLine[i].heading) * (moveDist));

                    pt3.northing = mf.bnd.bndList[0].fenceLine[i].northing -
                        (Math.Cos(glm.PIBy2 + mf.bnd.bndList[0].fenceLine[i].heading) * (moveDist));

                    pt3.heading = mf.bnd.bndList[0].fenceLine[i].heading;

                    bool Add = true;

                    for (int j = 0; j < ptCount; j++)
                    {
                        double check = glm.DistanceSquared(pt3.northing, pt3.easting,
                                            mf.bnd.bndList[0].fenceLine[j].northing, mf.bnd.bndList[0].fenceLine[j].easting);
                        if (check < distSq)
                        {
                            Add = false;
                            break;
                        }
                    }

                    if (Add)
                    {
                        if (mf.hdl.desList.Count > 0)
                        {
                            double dist = ((pt3.easting - mf.hdl.desList[mf.hdl.desList.Count - 1].easting) * (pt3.easting - mf.hdl.desList[mf.hdl.desList.Count - 1].easting))
                                + ((pt3.northing - mf.hdl.desList[mf.hdl.desList.Count - 1].northing) * (pt3.northing - mf.hdl.desList[mf.hdl.desList.Count - 1].northing));
                            if (dist > 1)
                                mf.hdl.desList.Add(pt3);
                        }
                        else mf.hdl.desList.Add(pt3);
                    }
                }

                pt3 = new vec3(mf.hdl.desList[0]);
                mf.hdl.desList.Add(pt3);

                //btnCancelTouch.Enabled = false;

                int cnt = mf.hdl.desList.Count;
                if (cnt > 3)
                {
                    pt3 = new vec3(mf.hdl.desList[0]);
                    mf.hdl.desList.Add(pt3);

                    //make sure distance isn't too big between points on Turn
                    for (int i = 0; i < cnt - 1; i++)
                    {
                        int j = i + 1;
                        //if (j == cnt) j = 0;
                        double distance = glm.Distance(mf.hdl.desList[i], mf.hdl.desList[j]);
                        if (distance > 1.2)
                        {
                            vec3 pointB = new vec3((mf.hdl.desList[i].easting + mf.hdl.desList[j].easting) / 2.0,
                                (mf.hdl.desList[i].northing + mf.hdl.desList[j].northing) / 2.0,
                                mf.hdl.desList[i].heading);

                            mf.hdl.desList.Insert(j, pointB);
                            cnt = mf.hdl.desList.Count;
                            i = -1;
                        }
                    }
                    //who knows which way it actually goes
                    mf.hdl.CalculateHeadings(ref mf.hdl.desList);

                    mf.bnd.bndList[0].hdLine.Clear();

                    //write out the Curve Points
                    foreach (vec3 item in mf.hdl.desList)
                    {
                        mf.bnd.bndList[0].hdLine.Add(item);
                    }
                }

            }

            mf.FileSaveHeadland();
            
        }

        private void btnSlice_Click(object sender, EventArgs e)
        {
            int startBnd = 0, endBnd = 0, startLine = 0, endLine = 0;
            int isStart = 0;

            if (mf.hdl.sliceArr.Count == 0 || mf.hdl.idx == -1) return;

            //save a backup
            mf.hdl.backupList?.Clear();
            foreach (var item in mf.bnd.bndList[0].hdLine)
            {
                mf.hdl.backupList.Add(item);
            }
                
            for (int i = 0; i < mf.hdl.sliceArr[0].trackPts.Count - 2; i++)
            {

                for (int k = 0; k < mf.bnd.bndList[0].hdLine.Count - 2; k++)
                {
                    int res = GetLineIntersection(
                    mf.hdl.sliceArr[mf.hdl.idx].trackPts[i].easting,
                    mf.hdl.sliceArr[mf.hdl.idx].trackPts[i].northing,
                    mf.hdl.sliceArr[mf.hdl.idx].trackPts[i + 1].easting,
                    mf.hdl.sliceArr[mf.hdl.idx].trackPts[i + 1].northing,

                    mf.bnd.bndList[0].hdLine[k].easting,
                    mf.bnd.bndList[0].hdLine[k].northing,
                    mf.bnd.bndList[0].hdLine[k + 1].easting,
                    mf.bnd.bndList[0].hdLine[k + 1].northing,
                    ref iE, ref iN);
                    if (res == 1)
                    {
                        if (isStart == 0)
                        {                            
                            startBnd = k+1;
                            startLine = i+1;
                        }
                        else
                        {
                            endBnd = k+1;
                            endLine = i;
                        }                        
                        isStart++;
                    }
                }
            }

            if (isStart < 2)
            {
                mf.TimedMessageBox(2000, "Error", "Crossings not Found");
                return;
            }

            //overlaps start finish
            if ((Math.Abs(startBnd - endBnd)) > (mf.bnd.bndList[bndSelect].fenceLine.Count * 0.5))
            {
                if (startBnd < endBnd)
                {
                    (startBnd, endBnd) = (endBnd, startBnd);
                }

                mf.hdl.desList?.Clear();

                //first bnd segment
                for (int i = endBnd; i < startBnd; i++)
                {
                    mf.hdl.desList.Add(mf.bnd.bndList[0].hdLine[i]);
                }

                for (int i = startLine; i < endLine; i++)
                {
                    mf.hdl.desList.Add(mf.hdl.sliceArr[mf.hdl.idx].trackPts[i]);
                }

                //build headline from desList
                mf.bnd.bndList[0].hdLine.Clear();

                foreach (var item in mf.hdl.desList)
                {
                    mf.bnd.bndList[0].hdLine.Add(item);
                }
            }
            // completely in between start finish
            else
            {
                if (startBnd > endBnd)
                {
                    (startBnd, endBnd) = (endBnd, startBnd);
                }

                mf.hdl.desList?.Clear();

                //first bnd segment
                for (int i = 0; i < startBnd; i++)
                {
                    mf.hdl.desList.Add(mf.bnd.bndList[0].hdLine[i]);
                }

                //line segment
                for (int i = startLine; i < endLine; i++)
                {
                    mf.hdl.desList.Add(mf.hdl.sliceArr[mf.hdl.idx].trackPts[i]);
                }

                //final bnd segment
                for (int i = endBnd; i < mf.bnd.bndList[0].hdLine.Count; i++)
                {
                    mf.hdl.desList.Add(mf.bnd.bndList[0].hdLine[i]);
                }

                //build headline from desList
                mf.bnd.bndList[0].hdLine.Clear();

                foreach (var item in mf.hdl.desList)
                {
                    mf.bnd.bndList[0].hdLine.Add(item);
                }
            }

            mf.hdl.desList?.Clear();
            mf.hdl.sliceArr?.Clear();
        }

        private void btnDeletePoints_Click(object sender, EventArgs e)
        {
            start = 99999; end = 99999;
            isA = true;
            mf.hdl.desList?.Clear();
            mf.hdl.sliceArr?.Clear();

            int ptCount = mf.bnd.bndList[0].fenceLine.Count;

            mf.bnd.bndList[0].hdLine?.Clear();

            for (int i = 0; i < ptCount; i++)
            {
                mf.bnd.bndList[0].hdLine.Add(new vec3(mf.bnd.bndList[0].fenceLine[i]));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nudSetDistance.Value = 0;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            mf.bnd.bndList[0].hdLine?.Clear();
            foreach (var item in mf.hdl.backupList)
            {
                mf.bnd.bndList[0].hdLine.Add(item);
            }
        }

        public int GetLineIntersection(double p0x, double p0y, double p1x, double p1y,
        double p2x, double p2y, double p3x, double p3y, ref double iEast, ref double iNorth)
        {
            double s1x, s1y, s2x, s2y;
            s1x = p1x - p0x;
            s1y = p1y - p0y;

            s2x = p3x - p2x;
            s2y = p3y - p2y;

            double s, t;
            s = (-s1y * (p0x - p2x) + s1x * (p0y - p2y)) / (-s2x * s1y + s1x * s2y);

            if (s >= 0 && s <= 1)
            {
                //check oher side
                t = (s2x * (p0y - p2y) - s2y * (p0x - p2x)) / (-s2x * s1y + s1x * s2y);
                if (t >= 0 && t <= 1)
                {
                    // Collision detected
                    iEast = p0x + (t * s1x);
                    iNorth = p0y + (t * s1y);
                    return 1;
                }
            }

            return 0; // No collision
        }


        private void oglSelf_Load(object sender, EventArgs e)
        {
            oglSelf.MakeCurrent();
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.ClearColor(0.22f, 0.22f, 0.22f, 1.0f);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
        }
    }
}