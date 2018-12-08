using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace AgOpenGPS
{
    public partial class FormSelf : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        private double maxFieldX, maxFieldY, minFieldX, minFieldY, fieldCenterX, fieldCenterY, maxFieldDistance;
        private Point fixPt;

        private void oglSelf_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = oglSelf.PointToClient(Cursor.Position);
            //lblX.Text = (pt.X - 400).ToString();
            //lblY.Text = ((800 - pt.Y) - 400).ToString();

            //Convert to Origin in the center of window, 800 pixels
            fixPt.X = pt.X - 400;
            fixPt.Y = (800 - pt.Y - 400);
            vec3 plotPt = new vec3
            {
                //convert screen coordinates to field coordinates
                easting = ((double)fixPt.X) * (double)maxFieldDistance / 780.0,
                northing = ((double)fixPt.Y) * (double)maxFieldDistance / 780.0,
                heading = 0
            };

            plotPt.easting += fieldCenterX;
            plotPt.northing += fieldCenterY;

            lblX.Text = plotPt.easting.ToString();
            lblY.Text = plotPt.northing.ToString();

            ////if (isDrawingHeadland)
            ////{
            ////    //make sure point is in boundary
            ////    if (mf.boundz.IsPointInsideBoundary(plotPt)) mf.hl.hlLine.Add(plotPt);
            ////    else mf.TimedMessageBox(2000, "Outside of boundary", "Click inside the boundary!");
            ////}

            //if (isDrawingStart)
            //{
            //    if (mf.bndArr[mf.bnd.boundarySelected].IsPointInsideBoundary(plotPt))
            //    {
            //        mf.genPath.startInfieldPoint.easting = plotPt.easting;
            //        mf.genPath.startInfieldPoint.northing = plotPt.northing;
            //        isDrawingStart = false;
            //        doneDrawingPtAndDirection = true;
            //    }
            //    else
            //    {
            //        mf.TimedMessageBox(2000, "Outside of boundary", "Click inside the boundary!");
            //    }
            //}

            //if (isDrawingHeading)
            //{
            //    if (mf.bndArr[mf.bnd.boundarySelected].IsPointInsideBoundary(plotPt))
            //    {
            //        doneDrawingPtAndDirection = false;
            //        mf.genPath.headingInfieldPoint.easting = plotPt.easting;
            //        mf.genPath.headingInfieldPoint.northing = plotPt.northing;
            //        mf.genPath.startInfieldPoint.heading = Math.Atan2(mf.genPath.headingInfieldPoint.easting - mf.genPath.startInfieldPoint.easting,
            //            mf.genPath.headingInfieldPoint.northing - mf.genPath.startInfieldPoint.northing);
            //        if (mf.genPath.startInfieldPoint.heading < 0) mf.genPath.startInfieldPoint.heading += glm.twoPI;

            //        isDrawingHeading = false;
            //        mf.genPath.isStartInfieldPointSet = true;

            //        btnOK.Enabled = true;
            //        btnCancel.Enabled = true;
            //        btnStartPt.Enabled = true;
            //        lblStartEasting.Text = "East: " + mf.genPath.startInfieldPoint.easting.ToString("N1");
            //        lblStartNorthing.Text = "North: " + mf.genPath.startInfieldPoint.northing.ToString("N1");
            //        lblStartHeading.Text = "Dir:" + (glm.toDegrees(mf.genPath.startInfieldPoint.heading)).ToString("N1");
            //    }
            //    else
            //    {
            //        mf.TimedMessageBox(2000, "Outside of boundary", "Click inside the boundary!");
            //    }
            //}

            //if (doneDrawingPtAndDirection) isDrawingHeading = true;

        }

        private void oglSelf_Paint(object sender, PaintEventArgs e)
        {
            oglSelf.MakeCurrent();

            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();                  // Reset The View

            CalculateMinMax();

            //back the camera up
            GL.Translate(0, 0, -maxFieldDistance);

            //translate to that spot in the world 
            GL.Translate(-fieldCenterX, -fieldCenterY, 0);

            GL.Color3(0, 0.6, 0.4);

            //draw patches j= # of sections
            for (int j = 0; j < mf.vehicle.numSuperSection; j++)
            {
                //every time the section turns off and on is a new patch
                int patchCount = mf.section[j].patchList.Count;

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (var triList in mf.section[j].patchList)
                    {

                        {
                            //draw the triangle in each triangle strip
                            GL.Begin(PrimitiveType.TriangleStrip);
                            int count2 = triList.Count;
                            int mipmap = 16;

                            //if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                            if (count2 >= (mipmap + 2))
                            {
                                int step = mipmap;
                                for (int i = 0; i < count2; i += step)
                                {
                                    GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;
                                    GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;

                                    //too small to mipmap it
                                    if (count2 - i <= (mipmap + 2)) step = 0;
                                }
                            }

                            else { for (int i = 0; i < count2; i++) GL.Vertex3(triList[i].easting, triList[i].northing, 0); }
                            GL.End();
                        }
                    }
                }
            } //end of section patches

            //draw the ABLine
            if (mf.ABLine.isABLineSet | mf.ABLine.isABLineBeingSet)
            {
                //Draw reference AB line
                GL.LineWidth(1);
                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0x00F0);

                GL.Begin(PrimitiveType.Lines);
                GL.Color3(0.9f, 0.5f, 0.7f);
                GL.Vertex3(mf.ABLine.refABLineP1.easting, mf.ABLine.refABLineP1.northing, 0);
                GL.Vertex3(mf.ABLine.refABLineP2.easting, mf.ABLine.refABLineP2.northing, 0);
                GL.End();
                GL.Disable(EnableCap.LineStipple);

                //raw current AB Line
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(0.9f, 0.0f, 0.0f);
                GL.Vertex3(mf.ABLine.currentABLineP1.easting, mf.ABLine.currentABLineP1.northing, 0.0);
                GL.Vertex3(mf.ABLine.currentABLineP2.easting, mf.ABLine.currentABLineP2.northing, 0.0);
                GL.End();
            }

            //draw curve if there is one
            if (mf.curve.isCurveSet)
            {
                int ptC = mf.curve.curList.Count;
                if (ptC > 0)
                {
                    GL.LineWidth(2);
                    GL.Color3(0.95f, 0.2f, 0.0f);
                    GL.Begin(PrimitiveType.LineStrip);
                    for (int h = 0; h < ptC; h++) GL.Vertex3(mf.curve.curList[h].easting, mf.curve.curList[h].northing, 0);
                    GL.End();
                }
            }

            //draw all the boundaries
            mf.bnd.DrawBoundaryLines();

            //GL.PointSize(8.0f);
            //GL.Begin(PrimitiveType.Points);
            //GL.Color3(0.95f, 0.90f, 0.0f);
            //GL.Vertex3(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing, 0.0);
            //GL.End();
            //GL.PointSize(1.0f);

            GL.Flush();
            oglSelf.SwapBuffers();

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
            GL.ClearColor(0.23122f, 0.2318f, 0.2315f, 1.0f);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            oglSelf.Refresh();
        }


        public FormSelf(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

        }


        //determine mins maxs of patches and whole field.
        private void CalculateMinMax()
        {
            minFieldX = 9999999; minFieldY = 9999999;
            maxFieldX = -9999999; maxFieldY = -9999999;

            //draw patches j= # of sections
            for (int j = 0; j < mf.vehicle.numSuperSection; j++)
            {
                //every time the section turns off and on is a new patch
                int patchCount = mf.section[j].patchList.Count;

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (var triList in mf.section[j].patchList)
                    {
                        int count2 = triList.Count;
                        for (int i = 0; i < count2; i += 3)
                        {
                            double x = triList[i].easting;
                            double y = triList[i].northing;

                            //also tally the max/min of field x and z
                            if (minFieldX > x) minFieldX = x;
                            if (maxFieldX < x) maxFieldX = x;
                            if (minFieldY > y) minFieldY = y;
                            if (maxFieldY < y) maxFieldY = y;
                        }
                    }
                }

                //min max of the boundary
                int bndCnt = mf.bnd.bndArr[mf.bnd.boundarySelected].bndLine.Count;
                if (bndCnt > 0)
                {
                    for (int i = 0; i < bndCnt; i++)
                    {
                        double x = mf.bnd.bndArr[mf.bnd.boundarySelected].bndLine[i].easting;
                        double y = mf.bnd.bndArr[mf.bnd.boundarySelected].bndLine[i].northing;

                        //also tally the max/min of field x and z
                        if (minFieldX > x) minFieldX = x;
                        if (maxFieldX < x) maxFieldX = x;
                        if (minFieldY > y) minFieldY = y;
                        if (maxFieldY < y) maxFieldY = y;
                    }
                }

                if (maxFieldX == -9999999 | minFieldX == 9999999 | maxFieldY == -9999999 | minFieldY == 9999999)
                {
                    maxFieldX = 0; minFieldX = 0; maxFieldY = 0; minFieldY = 0;
                }
                else
                {
                    //the largest distancew across field
                    double dist = Math.Abs(minFieldX - maxFieldX);
                    double dist2 = Math.Abs(minFieldY - maxFieldY);

                    if (dist > dist2) maxFieldDistance = dist;
                    else maxFieldDistance = dist2;

                    if (maxFieldDistance < 100) maxFieldDistance = 100;
                    if (maxFieldDistance > 19900) maxFieldDistance = 19900;
                    //lblMax.Text = ((int)maxFieldDistance).ToString();

                    fieldCenterX = (maxFieldX + minFieldX) / 2.0;
                    fieldCenterY = (maxFieldY + minFieldY) / 2.0;
                }

                //if (isMetric)
                //{
                //    lblFieldWidthEastWest.Text = Math.Abs((maxFieldX - minFieldX)).ToString("N0") + " m";
                //    lblFieldWidthNorthSouth.Text = Math.Abs((maxFieldY - minFieldY)).ToString("N0") + " m";
                //}
                //else
                //{
                //    lblFieldWidthEastWest.Text = Math.Abs((maxFieldX - minFieldX) * glm.m2ft).ToString("N0") + " ft";
                //    lblFieldWidthNorthSouth.Text = Math.Abs((maxFieldY - minFieldY) * glm.m2ft).ToString("N0") + " ft";
                //}
            }
        }

    }
}
