using SharpGL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormHeadland : Form
    {
        private readonly FormGPS mf = null;

        private double maxFieldX, maxFieldY, minFieldX, minFieldY, fieldCenterX, fieldCenterY, maxFieldDistance;
        private double heading, oneSide, distance;
        private double headWidths;

        public FormHeadland(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void FormHeadland_Load(object sender, EventArgs e)
        {
            nudWidths.ValueChanged -= nudWidths_ValueChanged;
            headWidths = Properties.Vehicle.Default.set_youToolWidths;
            nudWidths.Value = (decimal)headWidths;
            nudWidths.ValueChanged += nudWidths_ValueChanged;

            if (mf.hl.isSet)
            {
            }
            else
            {
                //create a single tool width headland
                BuildHeadland();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mf.hl.ResetHeadland();
        }

        private Point fixPt;

        private void openGLHead_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDrawingHeadland)
            {
                //OpenGL has line 0 at bottom, Windows at top, so convert
                Point pt = openGLHead.PointToClient(Cursor.Position);
                vec2 plotPt;
                lblX.Text = (pt.X - 350).ToString();
                lblY.Text = ((700 - pt.Y) - 350).ToString();

                //Convert to Origin in the center of window, 700 pixels
                fixPt.X = pt.X - 350;
                fixPt.Y = ((700 - pt.Y) - 350);

                //convert screen coordinates to field coordinates
                plotPt.easting = ((double)fixPt.X) * (double)maxFieldDistance / 670.0;
                plotPt.easting += fieldCenterX;
                plotPt.northing = ((double)fixPt.Y) * (double)maxFieldDistance / 670.0;
                plotPt.northing += fieldCenterY;

                //make sure point is in boundary
                if (mf.boundz.IsPointInsideBoundary(plotPt)) mf.hl.ptList.Add(plotPt);
                else mf.TimedMessageBox(2000, "Outside of boundary", "Paint inside the box!");

                //fix up the area label
                double area = mf.hl.CalculateHeadlandArea();
                if (mf.isMetric) lblArea.Text = Math.Round(area * 0.0001, 1) + " Ha";
                else lblArea.Text = Math.Round(area * 0.000247105, 1) + " Ac";
            }
        }

        private bool isDrawingHeadland;

        private void btnStart_Click(object sender, EventArgs e)
        {
            //clear the headland point list
            mf.hl.ptList.Clear();
            isDrawingHeadland = true;

            btnStart.Enabled = false;
            btnDeleteLastPoint.Enabled = true;
            btnDone.Enabled = true;

            btnOK.Enabled = false;
            btnCancel.Enabled = false;
            nudWidths.Enabled = false;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            isDrawingHeadland = false;
            FixHeadlandList();

            //pre calculate all the constants and multiples
            mf.hl.PreCalcHeadlandLines();

            //area calc
            double area = mf.hl.CalculateHeadlandArea();
            if (mf.isMetric) lblArea.Text = Math.Round(area * 0.0001, 1) + " Ha";
            else lblArea.Text = Math.Round(area * 0.000247105, 1) + " Ac";

            btnStart.Enabled = true;
            btnDeleteLastPoint.Enabled = false;
            btnDone.Enabled = false;

            btnOK.Enabled = true;
            btnCancel.Enabled = true;
            nudWidths.Enabled = true;
        }

        private void btnDeleteLastPoint_Click(object sender, EventArgs e)
        {
            int ptCnt = mf.hl.ptList.Count;
            if (ptCnt > 0)
            {
                mf.hl.ptList.RemoveAt(ptCnt - 1);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
        }

        private void nudWidths_ValueChanged(object sender, EventArgs e)
        {
            headWidths = (double)nudWidths.Value;
            Properties.Vehicle.Default.set_youToolWidths = (double)nudWidths.Value;
            Properties.Vehicle.Default.Save();
            BuildHeadland();
        }

        private vec2 point, point2;

        private void BuildHeadland()
        {
            //count the points from the boundary
            int ptCount = mf.boundz.ptList.Count;

            //first find out which side is inside the boundary
            heading = Math.Atan2(mf.boundz.ptList[3].easting - mf.boundz.ptList[4].easting
                                        , mf.boundz.ptList[3].northing - mf.boundz.ptList[4].northing);
            oneSide = glm.PIBy2;
            point2.easting = mf.boundz.ptList[3].easting - (Math.Sin(oneSide + heading) * 2.0);
            point2.northing = mf.boundz.ptList[3].northing - (Math.Cos(oneSide + heading) * 2.0);

            if (!mf.boundz.IsPointInsideBoundary(point2)) oneSide *= -1.0;

            //grab an array
            vec4[] bnd = new vec4[ptCount];
            vec2[] hlnd = new vec2[ptCount];

            //clear the headland point list
            mf.hl.ptList.Clear();

            //determine how wide a headland space
            double totalHeadWidth = mf.vehicle.toolWidth * (double)nudWidths.Value;
            bnd[0].x = mf.boundz.ptList[0].easting;
            bnd[0].y = mf.boundz.ptList[0].northing;

            for (int i = 1; i < ptCount - 1; i++)
            {
                bnd[i].x = mf.boundz.ptList[i].easting;
                bnd[i].y = mf.boundz.ptList[i].northing;

                bnd[i - 1].k = Math.Atan2(bnd[i - 1].x - bnd[i].x, bnd[i - 1].y - bnd[i].y);

                point.easting = bnd[i - 1].x - (Math.Sin(bnd[i - 1].k + oneSide) * totalHeadWidth);
                point.northing = bnd[i - 1].y - (Math.Cos(bnd[i - 1].k + oneSide) * totalHeadWidth);

                //only add if inside actual field boundary
                if (mf.boundz.IsPointInsideBoundary(point)) mf.hl.ptList.Add(point);
            }

            int headCount = mf.hl.ptList.Count;

            //remove the points too close to boundary
            for (int i = 0; i < ptCount; i++)
            {
                for (int j = 0; j < headCount; j++)
                {
                    //make sure distance between headland and boundary is not less then width
                    distance = mf.pn.Distance(mf.boundz.ptList[i].northing, mf.boundz.ptList[i].easting
                                    , mf.hl.ptList[j].northing, mf.hl.ptList[j].easting);
                    if (distance < (totalHeadWidth * 0.98))
                    {
                        mf.hl.ptList.RemoveAt(j);
                        headCount = mf.hl.ptList.Count;
                        j = 0;
                    }
                }
            }

            //fix the gaps and overlaps
            FixHeadlandList();

            //pre calculate all the constants and multiples
            mf.hl.PreCalcHeadlandLines();

            //Enable the save ok button
            btnOK.Enabled = true;

            double area = mf.hl.CalculateHeadlandArea();
            if (mf.isMetric) lblArea.Text = Math.Round(area * 0.0001, 1) + " Ha";
            else lblArea.Text = Math.Round(area * 0.000247105, 1) + " Ac";
        }

        private void FixHeadlandList()
        {
            //make sure distance isn't too small between points on headland
            int headCount = mf.hl.ptList.Count;
            double spacing = mf.vehicle.toolWidth * 0.5;
            for (int i = 0; i < headCount - 1; i++)
            {
                distance = mf.pn.Distance(mf.hl.ptList[i].northing, mf.hl.ptList[i].easting
                                , mf.hl.ptList[i + 1].northing, mf.hl.ptList[i + 1].easting);
                if (distance < spacing)
                {
                    mf.hl.ptList.RemoveAt(i + 1);
                    headCount = mf.hl.ptList.Count;
                    i = 0;
                }
            }

            //make sure distance isn't too big between points on headland
            headCount = mf.hl.ptList.Count;
            for (int i = 0; i < headCount; i++)
            {
                int j = i + 1;
                if (j == headCount) j = 0;
                distance = mf.pn.Distance(mf.hl.ptList[i].northing, mf.hl.ptList[i].easting
                                , mf.hl.ptList[j].northing, mf.hl.ptList[j].easting);
                if (distance > (spacing))
                {
                    point.easting = (mf.hl.ptList[i].easting + mf.hl.ptList[j].easting) / 2.0;
                    point.northing = (mf.hl.ptList[i].northing + mf.hl.ptList[j].northing) / 2.0;

                    mf.hl.ptList.Insert(j, point);
                    headCount = mf.hl.ptList.Count;
                    i = 0;
                }
            }

            //line is built
            mf.hl.isSet = true;
        }

        private void openGLHead_Resized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL glh = openGLHead.OpenGL;

            glh.MatrixMode(OpenGL.GL_PROJECTION);

            //  Set the clear color.
            glh.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            //  Load the identity.
            glh.LoadIdentity();

            //  Create a perspective transformation.
            glh.Perspective(55f, 1, 1, 20000);

            //  Set the modelview matrix.
            glh.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void openGLHead_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL glh = openGLHead.OpenGL;

            glh.Enable(OpenGL.GL_CULL_FACE);
            glh.CullFace(OpenGL.GL_BACK);
        }

        private void openGLHead_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL glh = openGLHead.OpenGL;
            glh.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);	// Clear The Screen And The Depth Buffer
            glh.LoadIdentity();                  // Reset The View

            CalculateMinMax();

            //back the camera up
            glh.Translate(0, 0, -maxFieldDistance);

            //rotate camera so heading matched fix heading in the world
            //glh.Rotate(glm.toDegrees(fixHeadingSection), 0, 0, 1);

            //translate to that spot in the world
            glh.Translate(-fieldCenterX, -fieldCenterY, 0);

            //calculate the frustum for the section control window
            mf.CalcFrustum(glh);

            //to draw or not the triangle patch
            bool isDraw;

            glh.Color(0.2f, 0.5f, 0.4f);

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
                        isDraw = false;
                        int count2 = triList.Count;
                        for (int i = 0; i < count2; i += 3)
                        {
                            //determine if point is in frustum or not since 2d only 4 planes required
                            if ((mf.frustum[0] * triList[i].easting) + (mf.frustum[1] * triList[i].northing) + mf.frustum[3] <= 0)
                                continue;//right
                            if ((mf.frustum[4] * triList[i].easting) + (mf.frustum[5] * triList[i].northing) + mf.frustum[7] <= 0)
                                continue;//left
                            if ((mf.frustum[16] * triList[i].easting) + (mf.frustum[17] * triList[i].northing) + mf.frustum[19] <= 0)
                                continue;//bottom
                            if ((mf.frustum[20] * triList[i].easting) + (mf.frustum[21] * triList[i].northing) + mf.frustum[23] <= 0)
                                continue;//top

                            //point is in frustum so draw the entire patch
                            isDraw = true;
                            break;
                        }

                        if (isDraw)
                        {
                            //draw the triangle in each triangle strip
                            glh.Begin(OpenGL.GL_TRIANGLE_STRIP);
                            count2 = triList.Count;
                            const int mipmap = 8;

                            //if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                            if (count2 >= (mipmap + 2))
                            {
                                int step = mipmap;
                                for (int i = 0; i < count2; i += step)
                                {
                                    glh.Vertex(triList[i].easting, triList[i].northing, 0); i++;
                                    glh.Vertex(triList[i].easting, triList[i].northing, 0); i++;

                                    //too small to mipmap it
                                    if (count2 - i <= (mipmap + 2)) step = 0;
                                }
                            }
                            else { for (int i = 0; i < count2; i++) glh.Vertex(triList[i].easting, triList[i].northing, 0); }
                            glh.End();
                        }
                    }
                }
            } //end of section patches

            glh.PointSize(8.0f);
            glh.Begin(OpenGL.GL_POINTS);

            glh.Color(0.05f, 0.90f, 0.60f);
            #pragma warning disable CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
            glh.Vertex(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing, 0.0);
            #pragma warning restore CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception

            glh.End();

            //set pointsize
            glh.PointSize(4.0f);

            ////draw the outside boundary
            int ptCount = mf.boundz.ptList.Count;
            if (ptCount > 0)
            {
                glh.Color(0.98f, 0.2f, 0.90f);
                glh.Begin(OpenGL.GL_POINTS);
                for (int h = 0; h < ptCount; h++) glh.Vertex(mf.boundz.ptList[h].easting, mf.boundz.ptList[h].northing, 0);
                glh.End();
            }

            ////draw the headland line so far
            ptCount = mf.hl.ptList.Count;
            if (ptCount > 0)
            {
                glh.Color(0.9038f, 0.9892f, 0.10f);
                glh.Begin(OpenGL.GL_POINTS);
                for (int h = 0; h < ptCount; h++) glh.Vertex(mf.hl.ptList[h].easting, mf.hl.ptList[h].northing, 0);
                glh.End();
            }

            //plot the touch points so far
            if (isDrawingHeadland)
            {
                ////draw the headland line so far
                ptCount = mf.hl.ptList.Count;
                if (ptCount > 0)
                {
                    glh.Color(0.08f, 0.9892f, 0.2710f);
                    glh.Begin(OpenGL.GL_LINE_STRIP);
                    for (int h = 0; h < ptCount; h++) glh.Vertex(mf.hl.ptList[h].easting, mf.hl.ptList[h].northing, 0);
                    glh.End();

                    glh.Color(0.978f, 0.392f, 0.10f);
                    //the "close the loop" line
                    glh.Begin(OpenGL.GL_LINE_STRIP);
                    glh.Vertex(mf.hl.ptList[ptCount - 1].easting, mf.hl.ptList[ptCount - 1].northing, 0);
                    glh.Vertex(mf.hl.ptList[0].easting, mf.hl.ptList[0].northing, 0);
                    glh.End();
                }
            }

            glh.PointSize(1.0f);
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
                int bndCnt = mf.boundz.ptList.Count;
                if (bndCnt > 0)
                {
                    for (int i = 0; i < bndCnt; i ++)
                    {
                        double x = mf.boundz.ptList[i].easting;
                        double y = mf.boundz.ptList[i].northing;

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

                    if (dist > dist2) maxFieldDistance = (dist);
                    else maxFieldDistance = (dist2);

                    if (maxFieldDistance < 200) maxFieldDistance = 200;
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
    }//end of form
}