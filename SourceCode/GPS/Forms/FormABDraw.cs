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

        private double maxFieldX, maxFieldY, minFieldX, minFieldY, fieldCenterX, fieldCenterY, maxFieldDistance;
        private Point fixPt;

        private bool isA = true, isMakingAB = false, isMakingCurve = false;
        public double low = 0, high = 1;
        private int A, B, C, D, E, start = 99999, end = 99999;

        private bool isDrawSections = false;

        //list of coordinates of boundary line
        public List<vec3> turnLine = new List<vec3>();

        private vec3[] arr;

        private void FixLabelsCurve()
        {
            lblNumCu.Text = mf.curve.numCurveLines.ToString();
            lblCurveSelected.Text = mf.curve.numCurveLineSelected.ToString();

            if (mf.curve.numCurveLineSelected > 0)
                lblCurveName.Text = mf.curve.curveArr[mf.curve.numCurveLineSelected - 1].Name;
            else
                lblCurveName.Text = "***";
        }

        private void FixLabelsABLine()
        {
            lblNumAB.Text = mf.ABLine.numABLines.ToString();
            lblABSelected.Text = mf.ABLine.numABLineSelected.ToString();

            if (mf.ABLine.numABLineSelected > 0) lblABLineName.Text = mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].Name;
            else lblABLineName.Text = "***";
        }

        private void btnSelectCurve_Click(object sender, EventArgs e)
        {
            if (mf.curve.numCurveLines > 0)
            {
                mf.curve.numCurveLineSelected++;
                if (mf.curve.numCurveLineSelected > mf.curve.numCurveLines) mf.curve.numCurveLineSelected = 1;
            }
            else
            {
                mf.curve.numCurveLineSelected = 0;
            }

            FixLabelsCurve();
        }

        private void btnSelectABLine_Click(object sender, EventArgs e)
        {
            if (mf.ABLine.numABLines > 0)
            {
                mf.ABLine.numABLineSelected++;
                if (mf.ABLine.numABLineSelected > mf.ABLine.numABLines) mf.ABLine.numABLineSelected = 1;
            }
            else
            {
                mf.ABLine.numABLineSelected = 0;
            }

            FixLabelsABLine();
        }

        private void btnCancelTouch_Click(object sender, EventArgs e)
        {
            btnMakeABLine.Enabled = false;
            btnMakeCurve.Enabled = false;

            isMakingAB = isMakingCurve = false;
            isA = true;
            start = 99999; end = 99999;

            btnCancelTouch.Enabled = false;
        }

        private void nudDistance_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnSelectABLine.Focus();

        }

        private void btnDeleteCurve_Click(object sender, EventArgs e)
        {
            if (mf.curve.curveArr.Count > 0 && mf.curve.numCurveLineSelected > 0)
            {
                mf.curve.curveArr.RemoveAt(mf.curve.numCurveLineSelected - 1);
                mf.curve.numCurveLines--;

            }

            if (mf.curve.numCurveLines > 0) mf.curve.numCurveLineSelected = 1;
            else mf.curve.numCurveLineSelected = 0;

            FixLabelsCurve();
        }

        private void btnDeleteABLine_Click(object sender, EventArgs e)
        {
            if (mf.ABLine.lineArr.Count > 0 && mf.ABLine.numABLineSelected > 0)
            {
                mf.ABLine.lineArr.RemoveAt(mf.ABLine.numABLineSelected - 1);
                mf.ABLine.numABLines--;
                mf.ABLine.numABLineSelected--;
            }

            if (mf.ABLine.numABLines > 0) mf.ABLine.numABLineSelected = 1;
            else mf.ABLine.numABLineSelected = 0;

            FixLabelsABLine();
        }

        private void btnDrawSections_Click(object sender, EventArgs e)
        {
            isDrawSections = !isDrawSections;
            if (isDrawSections) btnDrawSections.Text = "On";
            else btnDrawSections.Text = "Off";
        }

        public vec3 pint = new vec3(0.0, 1.0, 0.0);

        public FormABDraw(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();
            //lblPick.Text = gStr.gsSelectALine;
            label3.Text = gStr.gsCreate;
            label4.Text = gStr.gsSelect;
            label5.Text = gStr.gsToolWidth;
            this.Text = gStr.gsClick2Pointsontheboundary;

            nudDistance.Controls[0].Enabled = false;
        }

        private void FormABDraw_Load(object sender, EventArgs e)
        {
            int cnt = mf.bnd.bndArr[0].bndLine.Count;
            arr = new vec3[cnt * 2];

            for (int i = 0; i < cnt; i++)
            {
                arr[i].easting = mf.bnd.bndArr[0].bndLine[i].easting;
                arr[i].northing = mf.bnd.bndArr[0].bndLine[i].northing;
                arr[i].heading = mf.bnd.bndArr[0].bndLine[i].northing;
            }

            for (int i = cnt; i < cnt * 2; i++)
            {
                arr[i].easting = mf.bnd.bndArr[0].bndLine[i - cnt].easting;
                arr[i].northing = mf.bnd.bndArr[0].bndLine[i - cnt].northing;
                arr[i].heading = mf.bnd.bndArr[0].bndLine[i - cnt].heading;
            }

            nudDistance.Value = 0; // 
            label6.Text = Math.Round((mf.tool.toolWidth * 100),1).ToString();
            FixLabelsABLine();
            FixLabelsCurve();
        }

        private void oglSelf_MouseDown(object sender, MouseEventArgs e)
        {
            btnCancelTouch.Enabled = true;

            btnMakeABLine.Enabled = false;
            btnMakeCurve.Enabled = false;
            isMakingAB = isMakingCurve = false;

            Point pt = oglSelf.PointToClient(Cursor.Position);

            //Convert to Origin in the center of window, 800 pixels
            fixPt.X = pt.X - 350;
            fixPt.Y = (700 - pt.Y - 350);
            vec3 plotPt = new vec3
            {
                //convert screen coordinates to field coordinates
                easting = ((double)fixPt.X) * (double)maxFieldDistance / 632.0,
                northing = ((double)fixPt.Y) * (double)maxFieldDistance / 632.0,
                heading = 0
            };

            plotPt.easting += fieldCenterX;
            plotPt.northing += fieldCenterY;

            pint.easting = plotPt.easting;
            pint.northing = plotPt.northing;

            if (isA)
            {
                double minDistA = 1000000, minDistB = 1000000;
                start = 99999; end = 99999;

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
            }
            else
            {
                double minDistA = 1000000, minDistB = 1000000;

                int ptCount = arr.Length;

                if (ptCount > 0)
                {
                    //find the closest 2 points to current point
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

                isA = true;

                int[] dubs = new int[4];

                int A1 = Math.Abs(A - C);
                int B1 = Math.Abs(A - D);
                int C1 = Math.Abs(B - C);
                int D1 = Math.Abs(B - D);

                if (A1 <= B1 && A1 <= C1 && A1 <= D1) { start = A; end = C; }
                else if (B1 <= A1 && B1 <= C1 && B1 <= D1) { start = A; end = D; }
                else if (C1 <= B1 && C1 <= A1 && C1 <= D1) { start = B; end = C; }
                else if (D1 <= B1 && D1 <= C1 && D1 <= A1) { start = B; end = D; }

                if (start > end) { E = start; start = end; end = E; }

                btnMakeABLine.Enabled = true;
                btnMakeCurve.Enabled = true;
            }
        }

        private void BtnMakeCurve_Click(object sender, EventArgs e)
        {
            btnCancelTouch.Enabled = false;

            mf.curve.refList?.Clear();
            vec3 chk = new vec3(arr[start]);

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
                if (mf.curve.aveLineHeading < 0) mf.curve.aveLineHeading += glm.twoPI;

                //build the tail extensions
                mf.curve.AddFirstLastPoints();
                mf.curve.SmoothAB(4);
                mf.curve.CalculateTurnHeadings();

                mf.curve.isCurveSet = true;

                double offset = ((double)nudDistance.Value) / 200.0;

                //calculate the heading 90 degrees to ref ABLine heading
                double headingAt90 = mf.curve.aveLineHeading + glm.PIBy2;

                chk.easting = (Math.Sin(headingAt90) * Math.Abs(offset)) + chk.easting;
                chk.northing = (Math.Cos(headingAt90) * Math.Abs(offset)) + chk.northing;

                if (!mf.bnd.bndArr[0].IsPointInsideBoundary(chk)) headingAt90 = mf.curve.aveLineHeading - glm.PIBy2;

                cnt = mf.curve.refList.Count;

                vec3[] arrMove = new vec3[cnt];
                mf.curve.refList.CopyTo(arrMove);
                mf.curve.refList.Clear();

                for (int i = 0; i < cnt; i++)
                {
                    arrMove[i].easting = (Math.Sin(headingAt90) * offset) + arrMove[i].easting;
                    arrMove[i].northing = (Math.Cos(headingAt90) * offset) + arrMove[i].northing;
                    mf.curve.refList.Add(arrMove[i]);
                }

                mf.curve.curveArr.Add(new CCurveLines());
                mf.curve.numCurveLines = mf.curve.curveArr.Count;
                mf.curve.numCurveLineSelected = mf.curve.numCurveLines;

                //array number is 1 less since it starts at zero
                int idx = mf.curve.curveArr.Count - 1;

                //create a name
                mf.curve.curveArr[idx].Name = (Math.Round(glm.toDegrees(mf.curve.aveLineHeading), 1)).ToString(CultureInfo.InvariantCulture)
                     + "\u00B0" + mf.FindDirection(mf.curve.aveLineHeading) + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);

                mf.curve.curveArr[idx].aveHeading = mf.curve.aveLineHeading;

                //write out the Curve Points
                foreach (var item in mf.curve.refList)
                {
                    mf.curve.curveArr[idx].curvePts.Add(item);
                }

                mf.FileSaveCurveLines();

                //update the arrays
                btnMakeABLine.Enabled = false;
                btnMakeCurve.Enabled = false;
                isMakingCurve = false;
                isMakingAB = false;
                start = 99999; end = 99999;

                FixLabelsCurve();
            }
            else
            {
                mf.curve.isCurveSet = false;
                mf.curve.refList?.Clear();
            }
        }

        private void BtnMakeABLine_Click(object sender, EventArgs e)
        {
            btnCancelTouch.Enabled = false;

            //calculate the AB Heading
            double abHead = Math.Atan2(arr[C].easting - arr[A].easting,
                arr[C].northing - arr[A].northing);
            if (abHead < 0) abHead += glm.twoPI;

            double offset = ((double)nudDistance.Value) / 200.0;

            double headingCalc = abHead + glm.PIBy2;

            mf.ABLine.lineArr.Add(new CABLines());
            mf.ABLine.numABLines = mf.ABLine.lineArr.Count;
            mf.ABLine.numABLineSelected = mf.ABLine.numABLines;

            int idx = mf.ABLine.numABLines - 1;

            mf.ABLine.lineArr[idx].heading = abHead;
            //calculate the new points for the reference line and points
            mf.ABLine.lineArr[idx].origin.easting = (Math.Sin(headingCalc) * Math.Abs(offset)) + arr[A].easting;
            mf.ABLine.lineArr[idx].origin.northing = (Math.Cos(headingCalc) * Math.Abs(offset)) + arr[A].northing;

            if (!mf.bnd.bndArr[0].IsPointInsideBoundary(mf.ABLine.lineArr[idx].origin))
            {
                headingCalc = abHead - glm.PIBy2;
                mf.ABLine.lineArr[idx].origin.easting = (Math.Sin(headingCalc) * Math.Abs(offset)) + arr[A].easting;
                mf.ABLine.lineArr[idx].origin.northing = (Math.Cos(headingCalc) * Math.Abs(offset)) + arr[A].northing;
            }

            //sin x cos z for endpoints, opposite for additional lines
            mf.ABLine.lineArr[idx].ref1.easting =   mf.ABLine.lineArr[idx].origin.easting - (Math.Sin(mf.ABLine.lineArr[idx].heading) * 1600.0);
            mf.ABLine.lineArr[idx].ref1.northing = mf.ABLine.lineArr[idx].origin.northing - (Math.Cos(mf.ABLine.lineArr[idx].heading) * 1600.0);
            mf.ABLine.lineArr[idx].ref2.easting =  mf.ABLine.lineArr[idx].origin.easting +  (Math.Sin(mf.ABLine.lineArr[idx].heading) * 1600.0);
            mf.ABLine.lineArr[idx].ref2.northing = mf.ABLine.lineArr[idx].origin.northing + (Math.Cos(mf.ABLine.lineArr[idx].heading) * 1600.0);

            //create a name
            mf.ABLine.lineArr[idx].Name = (Math.Round(glm.toDegrees(mf.ABLine.lineArr[idx].heading), 1)).ToString(CultureInfo.InvariantCulture)
                 + "\u00B0" + mf.FindDirection(mf.ABLine.lineArr[idx].heading) + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);

            //clean up gui
            btnMakeABLine.Enabled = false;
            btnMakeCurve.Enabled = false;

            isMakingCurve = false;
            isMakingAB = false;
            start = 99999; end = 99999;

            FixLabelsABLine();
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

            GL.Color3(1, 1, 1);

            //draw all the boundaries
            mf.bnd.DrawBoundaryLines();

            if (isDrawSections) DrawSections();

            //draw the line building graphics
            if (start != 99999 || end != 99999) DrawABTouchLine();

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
            int numLines = mf.ABLine.lineArr.Count;

            if (numLines > 0)
            {
                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0x0707);
                GL.Color3(1.0f, 0.0f, 0.0f);

                for (int i = 0; i < numLines; i++)
                {
                    GL.LineWidth(2);
                    GL.Begin(PrimitiveType.Lines);

                    foreach (var item in mf.ABLine.lineArr)
                    {
                        GL.Vertex3(item.ref1.easting, item.ref1.northing, 0);
                        GL.Vertex3(item.ref2.easting, item.ref2.northing, 0);
                    }
                    GL.End();
                }

                GL.Disable(EnableCap.LineStipple);

                if (mf.ABLine.numABLineSelected > 0)
                {
                    GL.Color3(1.0f, 0.0f, 0.0f);

                    GL.LineWidth(4);
                    GL.Begin(PrimitiveType.Lines);

                    foreach (var item in mf.ABLine.lineArr)
                    {
                        GL.Vertex3(mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].ref1.easting, mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].ref1.northing, 0);
                        GL.Vertex3(mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].ref2.easting, mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].ref2.northing, 0);
                    }
                    GL.End();
                }
            }

            int numCurv = mf.curve.curveArr.Count;

            if (numCurv > 0)
            {
                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0x7070);

                for (int i = 0; i < numCurv; i++)
                {
                    GL.LineWidth(2);
                    GL.Color3(0.0f, 1.0f, 0.0f);
                    GL.Begin(PrimitiveType.LineStrip);
                    foreach (var item in mf.curve.curveArr[i].curvePts)
                    {
                        GL.Vertex3(item.easting, item.northing, 0);
                    }
                    GL.End();
                }

                GL.Disable(EnableCap.LineStipple);

                if (mf.curve.numCurveLineSelected > 0)
                {
                    GL.LineWidth(4);
                    GL.Color3(0.0f, 1.0f, 0.0f);
                    GL.Begin(PrimitiveType.LineStrip);
                    foreach (var item in mf.curve.curveArr[mf.curve.numCurveLineSelected - 1].curvePts)
                    {
                        GL.Vertex3(item.easting, item.northing, 0);
                    }
                    GL.End();
                }
            }
        }

        private void DrawABTouchLine()
        {
            GL.Color3(0.65, 0.650, 0.0);
            GL.PointSize(8);
            GL.Begin(PrimitiveType.Points);

            GL.Color3(0.95, 0.950, 0.0);
            if (start != 99999) GL.Vertex3(arr[start].easting, arr[start].northing, 0);

            GL.Color3(0.950, 096.0, 0.0);
            if (end != 99999) GL.Vertex3(arr[end].easting, arr[end].northing, 0);
            GL.End();

            if (isMakingCurve)
            {
                //draw the turn line oject
                GL.LineWidth(4.0f);
                GL.Begin(PrimitiveType.LineStrip);
                int ptCount = arr.Length;
                if (ptCount < 1) return;
                for (int c = start; c < end; c++) GL.Vertex3(arr[c].easting, arr[c].northing, 0);

                GL.End();
            }

            if (isMakingAB)
            {
                GL.LineWidth(4.0f);
                GL.Color3(0.95, 0.0, 0.0);
                GL.Begin(PrimitiveType.Lines);
                    GL.Vertex3(arr[A].easting, arr[A].northing, 0);
                    GL.Vertex3(arr[C].easting, arr[C].northing, 0);
                GL.End();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            oglSelf.Refresh();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (mf.ABLine.numABLineSelected > 0 )
            {
                mf.ABLine.refPoint1 = mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].origin;
                mf.ABLine.abHeading = mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].heading;
                mf.ABLine.SetABLineByHeading();

                if (mf.ABLine.isBtnABLineOn)
                {
                    mf.ABLine.isABLineSet = true;
                    mf.ABLine.isABLineLoaded = true;
                }
                else
                {
                    mf.ABLine.isABLineSet = false;
                }
            }
            else
            {
                mf.ABLine.DeleteAB();
                mf.ABLine.isABLineSet = false;
                mf.ABLine.isABLineLoaded = false;
            }

            mf.FileSaveABLines();


            //curve
            if (mf.curve.numCurveLineSelected > 0)
            {
                int idx = mf.curve.numCurveLineSelected - 1;
                mf.curve.aveLineHeading = mf.curve.curveArr[idx].aveHeading;
                mf.curve.refList?.Clear();
                foreach (vec3 v in mf.curve.curveArr[idx].curvePts) mf.curve.refList.Add(v);
                mf.curve.isCurveSet = true;
            }
            else
            {
                mf.curve.refList?.Clear();
                mf.curve.isCurveSet = false;
            }

            mf.FileSaveCurveLines();

            if (mf.ABLine.isBtnABLineOn)
            {
                if (mf.ABLine.numABLineSelected == 0)
                {
                    if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
                    if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();
                    mf.ABLine.isABLineSet = false;
                    mf.ABLine.isABLineLoaded = false;
                    mf.btnABLine.Image = Properties.Resources.ABLineOff;
                    mf.ABLine.isBtnABLineOn = false;
                }
            }

            if (mf.curve.isBtnCurveOn)
            {
                if (mf.curve.numCurveLineSelected == 0)
                {
                    if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
                    if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();
                    mf.curve.isCurveSet = false;
                    mf.curve.refList?.Clear();
                    mf.curve.isBtnCurveOn = false;
                    mf.btnCurve.Image = Properties.Resources.CurveOff;
                }
            }
            
            Close();
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

        private void DrawSections()
        {
            int cnt, step, patchCount;
            int mipmap = 8;

            GL.Color3(0.0, 0.0, 0.352);

            //draw patches j= # of sections
            for (int j = 0; j < mf.tool.numSuperSection; j++)
            {
                //every time the section turns off and on is a new patch
                patchCount = mf.section[j].patchList.Count;

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (var triList in mf.section[j].patchList)
                    {
                        //draw the triangle in each triangle strip
                        GL.Begin(PrimitiveType.TriangleStrip);
                        cnt = triList.Count;

                        //if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                        if (cnt >= (mipmap))
                        {
                            step = mipmap;
                            for (int i = 0; i < cnt; i += step)
                            {
                                GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;
                                GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;

                                //too small to mipmap it
                                if (cnt - i <= (mipmap + 2))
                                    step = 0;
                            }
                        }

                        else { for (int i = 0; i < cnt; i++) GL.Vertex3(triList[i].easting, triList[i].northing, 0); }
                        GL.End();

                    }
                }
            } //end of section patches

        }

        //determine mins maxs of patches and whole field.
        private void CalculateMinMax()
        {
            minFieldX = 9999999; minFieldY = 9999999;
            maxFieldX = -9999999; maxFieldY = -9999999;

            //draw patches j= # of sections
            for (int j = 0; j < mf.tool.numSuperSection; j++)
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
                    int bndCnt = mf.bnd.bndArr[0].bndLine.Count;
                    for (int i = 0; i < bndCnt; i++)
                    {
                        double x = mf.bnd.bndArr[0].bndLine[i].easting;
                        double y = mf.bnd.bndArr[0].bndLine[i].northing;

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