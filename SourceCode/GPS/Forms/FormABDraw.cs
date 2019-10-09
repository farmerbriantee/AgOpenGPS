using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormABDraw : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        private double maxFieldX, maxFieldY, minFieldX, minFieldY, fieldCenterX, fieldCenterY, maxFieldDistance, gain = 1;
        private Point fixPt;

        private bool isA = true, isB = false;
        public double low = 0, high = 1;
        private int A, B, C, D, E, start=99999, end=99999;
        //list of coordinates of boundary line
        public List<vec3> turnLine = new List<vec3>();
        vec3[] arr;

        public vec2 lastABLineP2 = new vec2(0.0, 1.0);

        public FormABDraw(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            lblCurveName.Text = gStr.gsEnterCurveName;
            lblLineName.Text = gStr.gsEnterLineName;
        }


        private void BtnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click 2 Points on the boundary then Choose either AB Line or Curve \r\n " +
                            "Enter a name and Click Save if Required.\r\n" +
                            " Click new points make more lines");
        }

        public vec3 pint = new vec3(0.0, 1.0, 0.0);


        private void BtnMakeCurve_Click(object sender, EventArgs e)
        {
            mf.curve.spiralmode = false;
            mf.curve.circlemode = false;
            mf.curve.refList?.Clear();

            for (int i = start; i < end; i++)
            {
                mf.curve.refList.Add(arr[i]);
            }

            int cnt = mf.curve.refList.Count;
            if (cnt > 3)
            {
                //make sure distance isn't too big between points on Turn
                for (int i = 0; i < cnt - 1; i++)
                {
                    int j = i + 1;
                    //if (j == cnt) j = 0;
                    double distance = glm.Distance(mf.curve.refList[i], mf.curve.refList[j]);
                    if (distance > 1.2)
                    {
                        vec3 pointB = new vec3((mf.curve.refList[i].easting + mf.curve.refList[j].easting) / 2.0,
                            (mf.curve.refList[i].northing + mf.curve.refList[j].northing) / 2.0,
                            mf.curve.refList[i].heading);

                        mf.curve.refList.Insert(j, pointB);
                        cnt = mf.curve.refList.Count;
                        i = -1;
                    }
                }
                //who knows which way it actually goes
                mf.curve.CalculateTurnHeadings();

                //calculate average heading of line
                double x = 0, y = 0;
                mf.curve.isCurveSet = true;
                foreach (var pt in mf.curve.refList)
                {
                    x += Math.Cos(pt.heading);
                    y += Math.Sin(pt.heading);
                }
                x /= mf.curve.refList.Count;
                y /= mf.curve.refList.Count;
                mf.curve.aveLineHeading = Math.Atan2(y, x);


                //build the tail extensions
                mf.curve.AddFirstLastPoints();
                mf.curve.SmoothAB(4);
                mf.curve.CalculateTurnHeadings();

                mf.curve.isCurveSet = true;
                //mf.EnableYouTurnButtons();
                mf.FileSaveCurveLine();

                btnMakeABLine.Enabled = false;
                btnMakeCurve.Enabled = false;
                tboxABLineSaveName.Enabled = false;
                tboxCurveSaveName.Enabled = true;

            }
            else
            {
                mf.curve.isCurveSet = false;
                mf.curve.refList?.Clear();
            }
        }

        private void BtnSaveABCurve_Click(object sender, EventArgs e)
        {
            //get the directory and make sure it exists, create if not
            string dirField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string filename = directoryName + "\\CurveLines.txt";

            if (!File.Exists(filename))
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine("$CurveLines");
                }
            }

            //use Streamwriter to append to curveLines file
            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                try
                {
                    if (tboxCurveSaveName.Text.Length > 0)
                    {
                        //write out the ABLine
                        writer.WriteLine(tboxCurveSaveName.Text);

                        writer.WriteLine(false.ToString(CultureInfo.InvariantCulture));
                        writer.WriteLine(false.ToString(CultureInfo.InvariantCulture));
                        //write out the aveheading
                        writer.WriteLine(mf.curve.aveLineHeading.ToString(CultureInfo.InvariantCulture));

                        //write out the points of ref line
                        writer.WriteLine(mf.curve.refList.Count.ToString(CultureInfo.InvariantCulture));

                        for (int j = 0; j < mf.curve.refList.Count; j++)
                        {
                            writer.WriteLine(Math.Round(mf.curve.refList[j].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                             Math.Round(mf.curve.refList[j].northing, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                             Math.Round(mf.curve.refList[j].heading, 5).ToString(CultureInfo.InvariantCulture));
                        }
                    }
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.Message + "\n Cannot write to file.");
                    mf.WriteErrorLog("Saving Curve Line" + er.ToString());

                    return;
                }
            }

            tboxCurveSaveName.Enabled = false;
            tboxCurveSaveName.Text = "";
            start = 99999; end = 99999;

        }

        private void BtnMakeABLine_Click(object sender, EventArgs e)
        {
            mf.ABLine.refPoint1.easting = arr[A].easting;
            mf.ABLine.refPoint1.northing = arr[A].northing;

            mf.ABLine.refPoint2.easting = arr[C].easting;
            mf.ABLine.refPoint2.northing = arr[C].northing;

            //calculate the AB Heading
            mf.ABLine.abHeading = Math.Atan2(mf.ABLine.refPoint2.easting - mf.ABLine.refPoint1.easting,
                mf.ABLine.refPoint2.northing - mf.ABLine.refPoint1.northing);
            if (mf.ABLine.abHeading < 0) mf.ABLine.abHeading += glm.twoPI;

            //sin x cos z for endpoints, opposite for additional lines
            mf.ABLine.refABLineP1.easting = mf.ABLine.refPoint1.easting - (Math.Sin(mf.ABLine.abHeading) * 4000.0);
            mf.ABLine.refABLineP1.northing = mf.ABLine.refPoint1.northing - (Math.Cos(mf.ABLine.abHeading) * 4000.0);
            mf.ABLine.refABLineP2.easting = mf.ABLine.refPoint1.easting + (Math.Sin(mf.ABLine.abHeading) * 4000.0);
            mf.ABLine.refABLineP2.northing = mf.ABLine.refPoint1.northing + (Math.Cos(mf.ABLine.abHeading) * 4000.0);

            mf.ABLine.isABLineSet = false;
            mf.ABLine.isABLineLoaded = true;

            btnMakeABLine.Enabled = false;
            btnMakeCurve.Enabled = false;
            tboxABLineSaveName.Enabled = true;
            tboxCurveSaveName.Enabled = false;

            mf.FileSaveABLine();
        }

        private void BtnSaveABLine_Click(object sender, EventArgs e)
        {
            //make sure at least a global blank AB Line file exists
            string dirField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string filename = directoryName + "\\ABLines.txt";

            if (!File.Exists(filename))
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine("ABLine N S,0,0,0");
                    writer.WriteLine("ABLine E W,90,0,0");
                }
            }

            //get the file of previous AB Lines
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            filename = directoryName + "\\ABLines.txt";

            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                if (mf.ABLine.isABLineLoaded)
                {
                    if (tboxABLineSaveName.Text.Length > 0)
                    {
                        //make it culture invariant
                        string line = tboxABLineSaveName.Text.Trim()
                            + ',' + (Math.Round(glm.toDegrees(mf.ABLine.abHeading), 8)).ToString(CultureInfo.InvariantCulture)
                            + ',' + (Math.Round(mf.ABLine.refPoint1.easting, 3)).ToString(CultureInfo.InvariantCulture)
                            + ',' + (Math.Round(mf.ABLine.refPoint1.northing, 3)).ToString(CultureInfo.InvariantCulture);

                        //write out to file
                        writer.WriteLine(line);
                    }
                }
            }

            tboxABLineSaveName.Text = "";
            tboxABLineSaveName.Enabled = false;
            start = 99999; end = 99999;
        }        


        private void oglSelf_MouseDown(object sender, MouseEventArgs e)
        {
            start = 99999; end = 99999;

            btnMakeABLine.Enabled = false;
            btnMakeCurve.Enabled = false;
            tboxABLineSaveName.Enabled = false;
            tboxCurveSaveName.Enabled = true;
            btnSaveABCurve.Enabled = false;
            btnSaveABLine.Enabled = false;

            Point pt = oglSelf.PointToClient(Cursor.Position);

            //Convert to Origin in the center of window, 800 pixels
            fixPt.X = pt.X - 350;
            fixPt.Y = (700 - pt.Y - 350);
            vec3 plotPt = new vec3
            {
                //convert screen coordinates to field coordinates
                easting = ((double)fixPt.X) * (double)maxFieldDistance / 632 * gain,
                northing = ((double)fixPt.Y) * (double)maxFieldDistance / 632.0 * gain,
                heading = 0
            };

            plotPt.easting += fieldCenterX;
            plotPt.northing += fieldCenterY;

            pint.easting = plotPt.easting;
            pint.northing = plotPt.northing;

            if (isA)
            {
                double minDistA = 1000000, minDistB = 1000000;

                int ptCount = arr.Length;

                if (ptCount > 0)
                {
                    //find the closest 2 points to current fix
                    for (int t = 0; t < ptCount; t++)
                    {
                        double dist = ((pint.easting - arr[t].easting) * (pint.easting - arr[t].easting))
                                        + ((pint.northing - arr[t].northing) * (pint.northing - arr[t].northing));
                        if (dist < minDistA)
                        {
                            minDistB = minDistA;
                            B = A;
                            minDistA = dist;
                            A = t;
                        }
                        else if (dist < minDistB)
                        {
                            minDistB = dist;
                            B = t;
                        }
                    }

                    //just need to make sure the points continue ascending or heading switches all over the place
                    if (A > B) { E = A; A = B; B = E; }

                    start = A;
                }

                isA = false;
                isB = true;
            }


            else if (isB)
            {
                double minDistA = 1000000, minDistB = 1000000;

                int ptCount = arr.Length;

                if (ptCount > 0)
                {
                    //find the closest 2 points to current fix
                    for (int t = 0; t < ptCount; t++)
                    {
                        double dist = ((pint.easting - arr[t].easting) * (pint.easting - arr[t].easting))
                                        + ((pint.northing - arr[t].northing) * (pint.northing - arr[t].northing));
                        if (dist < minDistA)
                        {
                            minDistB = minDistA;
                            D = C;
                            minDistA = dist;
                            C = t;
                        }
                        else if (dist < minDistB)
                        {
                            minDistB = dist;
                            D = t;
                        }
                    }

                    //just need to make sure the points continue ascending or heading switches all over the place
                    if (C > D) { E = C; C = D; D = E; }
                }

                isB = false;
                isA = true;
                int[] dubs = new int[4];

                int A1 = Math.Abs(A-C);
                int B1 = Math.Abs(A-D);
                int C1 = Math.Abs(B-C);
                int D1 = Math.Abs(B-D);

                if (A1 <= B1 && A1 <= C1 && A1 <= D1) { start = A; end = C; }
                else if (B1 <= A1 && B1 <= C1 && B1 <= D1) { start = A; end = D; }
                else if (C1 <= B1 && C1 <= A1 && C1 <= D1) { start = B; end = C; }
                else if (D1 <= B1 && D1 <= C1 && D1 <= A1) { start = B; end = D; }


                if (start > end) { E = start; start = end; end = E; }

                btnMakeABLine.Enabled = true;
                btnMakeCurve.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormABDraw_Load(object sender, EventArgs e)
        {

            if (mf.bnd.bndArr.Count < 1) return;
            int cnt = mf.bnd.bndArr[mf.bnd.LastBoundary].bndLine.Count;
            arr = new vec3[cnt*2];

            for (int i = 0; i < cnt; i++)
            {
                arr[i].easting = mf.bnd.bndArr[mf.bnd.LastBoundary].bndLine[i].easting;
                arr[i].northing = mf.bnd.bndArr[mf.bnd.LastBoundary].bndLine[i].northing;
                arr[i].heading = mf.bnd.bndArr[mf.bnd.LastBoundary].bndLine[i].northing;
            }

            for (int i = cnt; i < cnt*2; i++)
            {
                arr[i].easting = mf.bnd.bndArr[mf.bnd.LastBoundary].bndLine[i-cnt].easting;
                arr[i].northing = mf.bnd.bndArr[mf.bnd.LastBoundary].bndLine[i-cnt].northing;
                arr[i].heading = mf.bnd.bndArr[mf.bnd.LastBoundary].bndLine[i-cnt].heading;
            }
        }

        private void oglSelf_Paint(object sender, PaintEventArgs e)
        {
            oglSelf.MakeCurrent();

            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();                  // Reset The View

            CalculateMinMax();

            //back the camera up
            GL.Translate(0, 0, -maxFieldDistance * gain);

            //translate to that spot in the world
            GL.Translate(-fieldCenterX, -fieldCenterY, 0);

            GL.Color3(0, 0.6, 0.4);

            //draw the ABLine
            if (mf.ABLine.isABLineLoaded)
            {
                //Draw reference AB line ref
                GL.LineWidth(2);
                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0x00F0);
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(0.9f, 0.915f, 0.17f);
                GL.Vertex3(mf.ABLine.refABLineP1.easting, mf.ABLine.refABLineP1.northing, 0);
                GL.Color3(0.92f, 0.95f, 0.17f);
                GL.Vertex3(mf.ABLine.refABLineP2.easting, mf.ABLine.refABLineP2.northing, 0);
                GL.End();
                GL.Disable(EnableCap.LineStipple);

            }

            if (mf.curve.isCurveSet)
            {
                int ptCount = mf.curve.refList.Count;
                if (ptCount > 0)
                {
                    GL.LineWidth(2);
                    GL.Color3(0.30f, 0.7692f, 0.760f);
                    GL.Begin(PrimitiveType.LineStrip);
                    for (int h = 0; h < ptCount; h++) GL.Vertex3(mf.curve.refList[h].easting, mf.curve.refList[h].northing, 0);
                    GL.End();
                }
            }

            //draw all the boundaries
            mf.bnd.DrawBoundaryLines();
            DrawABTouchLine();

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


        public void DrawABTouchLine()
        {
            GL.Color3(0.65, 0.650, 0.0);
            GL.PointSize(8);
            GL.Begin(PrimitiveType.Points);

            GL.Color3(0.95, 0.0, 0.0);
            if (start != 99999) GL.Vertex3(arr[A].easting, arr[A].northing, 0);

            GL.Color3(0.0, 096.0, 0.0);
            if (end != 99999) GL.Vertex3(arr[C].easting, arr[C].northing, 0);
            GL.End();

            if (end == 99999) return;

            GL.LineWidth(4.0f);
            GL.Begin(PrimitiveType.LineStrip);
            ////draw the turn line oject
            //int i = 0;
            int ptCount = arr.Length;

            if (ptCount < 1) return;

            int h = (int)(low * ptCount);
            ptCount = (int)(high * ptCount);

            for (int c = start; c < end; c++) GL.Vertex3(arr[c].easting, arr[c].northing, 0);

            GL.End();


            GL.LineWidth(2.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(0.95, 0.50, 0.0);
            if (start != 99999) GL.Vertex3(arr[A].easting, arr[A].northing, 0);

            GL.Color3(0.0, 0.460, 0.90);
            if (end != 99999) GL.Vertex3(arr[C].easting, arr[C].northing, 0);
            GL.End();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            oglSelf.Refresh();

            //if (start == 99999 || end == 99999)
            //{
            //    btnMakeABLine.Enabled = false;
            //    btnMakeCurve.Enabled = false;
            //}

            //else
            //{
            //    btnMakeABLine.Enabled = true;
            //    btnMakeCurve.Enabled = true;
            //}

            if (String.IsNullOrEmpty(tboxABLineSaveName.Text)) btnSaveABLine.Enabled = false;
            else btnSaveABLine.Enabled = true;
            if (String.IsNullOrEmpty(tboxCurveSaveName.Text)) btnSaveABCurve.Enabled = false;
            else btnSaveABCurve.Enabled = true;
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
                if (mf.bnd.bndArr.Count > 0)
                {
                    int bndCnt = mf.bnd.bndArr[mf.bnd.LastBoundary].bndLine.Count;
                    for (int i = 0; i < bndCnt; i++)
                    {
                        double x = mf.bnd.bndArr[mf.bnd.LastBoundary].bndLine[i].easting;
                        double y = mf.bnd.bndArr[mf.bnd.LastBoundary].bndLine[i].northing;

                        //also tally the max/min of field x and z
                        if (minFieldX > x) minFieldX = x;
                        if (maxFieldX < x) maxFieldX = x;
                        if (minFieldY > y) minFieldY = y;
                        if (maxFieldY < y) maxFieldY = y;
                    }
                }

                if (maxFieldX == -9999999 || minFieldX == 9999999 || maxFieldY == -9999999 || minFieldY == 9999999)
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
