using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormABDraw : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        private Point fixPt;

        private bool isA = true, isMakingAB = false, isMakingCurve = false;
        public double low = 0, high = 1;
        private int A, B, C, D, E, start = 99999, end = 99999;

        private bool isDrawSections = false;

        private vec3[] arr;
        public FormABDraw(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();
            //lblPick.Text = gStr.gsSelectALine;
            //label5.Text = gStr.gsToolWidth;
            //this.Text = gStr.gsClick2Pointsontheboundary;

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
            int cnt = mf.bnd.bndList[0].fenceLine.Count;
            arr = new vec3[cnt * 2];

            for (int i = 0; i < cnt; i++)
            {
                arr[i].easting = mf.bnd.bndList[0].fenceLine[i].easting;
                arr[i].northing = mf.bnd.bndList[0].fenceLine[i].northing;
                arr[i].heading = mf.bnd.bndList[0].fenceLine[i].heading;
            }

            for (int i = cnt; i < cnt * 2; i++)
            {
                arr[i].easting = mf.bnd.bndList[0].fenceLine[i - cnt].easting;
                arr[i].northing = mf.bnd.bndList[0].fenceLine[i - cnt].northing;
                arr[i].heading = mf.bnd.bndList[0].fenceLine[i - cnt].heading;
            }

            nudDistance.Value = (decimal)Math.Round(((mf.tool.width * mf.m2InchOrCm) * 0.5), 0); // 
            label6.Text = Math.Round((mf.tool.width * mf.m2InchOrCm), 0).ToString();
            FixLabelsABLine();
            FixLabelsCurve();

            if (isDrawSections) btnDrawSections.Image = Properties.Resources.MappingOn;
            else btnDrawSections.Image = Properties.Resources.MappingOff;

        }

        private void FormABDraw_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mf.ABLine.numABLineSelected > 0)
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
        }

        private void FixLabelsCurve()
        {
            lblNumCu.Text = mf.curve.numCurveLines.ToString();
            lblCurveSelected.Text = mf.curve.numCurveLineSelected.ToString();

            if (mf.curve.numCurveLineSelected > 0)
            {
                tboxNameCurve.Text = mf.curve.curveArr[mf.curve.numCurveLineSelected - 1].Name;
                tboxNameCurve.Enabled = true;
            }
            else
            {
                tboxNameCurve.Text = "***";
                tboxNameCurve.Enabled = false;
            }
        }

        private void FixLabelsABLine()
        {
            lblNumAB.Text = mf.ABLine.numABLines.ToString();
            lblABSelected.Text = mf.ABLine.numABLineSelected.ToString();

            if (mf.ABLine.numABLineSelected > 0)
            {
                tboxNameLine.Text = mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].Name;
                tboxNameLine.Enabled = true;
            }
            else
            {
                tboxNameLine.Text = "***";
                tboxNameLine.Enabled = false;
            }
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
            btnExit.Focus();
        }

        private void nudDistance_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
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
            if (isDrawSections) btnDrawSections.Image = Properties.Resources.MappingOn;
            else btnDrawSections.Image = Properties.Resources.MappingOff;
        }

        public vec3 pint = new vec3(0.0, 1.0, 0.0);

        private void tboxNameCurve_Leave(object sender, EventArgs e)
        {
            if (mf.curve.numCurveLineSelected > 0)
                mf.curve.curveArr[mf.curve.numCurveLineSelected - 1].Name = tboxNameCurve.Text.Trim();
        }

        private void tboxNameLine_Leave(object sender, EventArgs e)
        {
            if (mf.ABLine.numABLineSelected > 0)
                mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].Name = tboxNameLine.Text.Trim();
        }

        private void btnFlipOffset_Click(object sender, EventArgs e)
        {
            nudDistance.Value *= -1;
        }

        private void tboxNameCurve_Enter(object sender, EventArgs e)
        {
            if (mf.curve.curveArr[mf.curve.numCurveLineSelected - 1].Name == "Boundary Curve")
            {
                btnExit.Focus();
                return;
            }

            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender, this);
                if (mf.curve.numCurveLineSelected > 0)
                    mf.curve.curveArr[mf.curve.numCurveLineSelected - 1].Name = tboxNameCurve.Text.Trim();
                btnExit.Focus();
            }
        }

        private void tboxNameLine_Enter(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender, this);
                if (mf.ABLine.numABLineSelected > 0)
                    mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].Name = tboxNameLine.Text.Trim();
                btnExit.Focus();
            }
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

        private void btnMakeBoundaryCurve_Click(object sender, EventArgs e)
        {            //count the points from the boundary
            int ptCount = mf.bnd.bndList[0].fenceLine.Count;
            mf.curve.refList?.Clear();

            //outside point
            vec3 pt3 = new vec3();

            double moveDist = (double)nudDistance.Value * mf.inchOrCm2m;
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
                    if (mf.curve.refList.Count > 0)
                    {
                        double dist = ((pt3.easting - mf.curve.refList[mf.curve.refList.Count - 1].easting) * (pt3.easting - mf.curve.refList[mf.curve.refList.Count - 1].easting))
                            + ((pt3.northing - mf.curve.refList[mf.curve.refList.Count - 1].northing) * (pt3.northing - mf.curve.refList[mf.curve.refList.Count - 1].northing));
                        if (dist > 1)
                            mf.curve.refList.Add(pt3);
                    }
                    else mf.curve.refList.Add(pt3);
                }
            }

            btnCancelTouch.Enabled = false;

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

                mf.curve.isCurveSet = true;

                mf.curve.aveLineHeading = 0;

                //mf.curve.SmoothAB(4);
                //mf.curve.CalculateTurnHeadings();

                mf.curve.isCurveSet = true;

                //double offset = ((double)nudDistance.Value) / 200.0;

                mf.curve.curveArr.Add(new CCurveLines());
                mf.curve.numCurveLines = mf.curve.curveArr.Count;
                mf.curve.numCurveLineSelected = mf.curve.numCurveLines;

                //array number is 1 less since it starts at zero
                int idx = mf.curve.curveArr.Count - 1;

                //create a name
                mf.curve.curveArr[idx].Name = "Boundary Curve";

                mf.curve.curveArr[idx].aveHeading = mf.curve.aveLineHeading;

                //write out the Curve Points
                foreach (vec3 item in mf.curve.refList)
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
            btnExit.Focus();
        }

        private void BtnMakeCurve_Click(object sender, EventArgs e)
        {
            btnCancelTouch.Enabled = false;

            double moveDist = (double)nudDistance.Value * mf.inchOrCm2m;
            double distSq = (moveDist) * (moveDist) * 0.999;

            mf.curve.refList?.Clear();
            vec3 pt3 = new vec3(arr[start]);

            for (int i = start; i < end; i++)
            {
                //calculate the point inside the boundary
                pt3.easting = arr[i].easting -
                    (Math.Sin(glm.PIBy2 + arr[i].heading) * (moveDist));

                pt3.northing = arr[i].northing -
                    (Math.Cos(glm.PIBy2 + arr[i].heading) * (moveDist));

                pt3.heading = arr[i].heading;

                bool Add = true;

                for (int j = start; j < end; j++)
                {
                    double check = glm.DistanceSquared(pt3.northing, pt3.easting,
                                        arr[j].northing, arr[j].easting);
                    if (check < distSq)
                    {
                        Add = false;
                        break;
                    }
                }

                if (Add)
                {
                    if (mf.curve.refList.Count > 0)
                    {
                        double dist = ((pt3.easting - mf.curve.refList[mf.curve.refList.Count - 1].easting) * (pt3.easting - mf.curve.refList[mf.curve.refList.Count - 1].easting))
                            + ((pt3.northing - mf.curve.refList[mf.curve.refList.Count - 1].northing) * (pt3.northing - mf.curve.refList[mf.curve.refList.Count - 1].northing));
                        if (dist > 1)
                            mf.curve.refList.Add(pt3);
                    }
                    else mf.curve.refList.Add(pt3);
                }
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
                    if (distance > 1.6)
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

                foreach (vec3 pt in mf.curve.refList)
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
                foreach (vec3 item in mf.curve.refList)
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
            btnExit.Focus();
        }


        private void BtnMakeABLine_Click(object sender, EventArgs e)
        {
            btnCancelTouch.Enabled = false;

            //calculate the AB Heading
            if (A < C) { B = A; A = C; C = B; }
            double abHead = Math.Atan2(arr[C].easting - arr[A].easting,
                arr[C].northing - arr[A].northing);
            if (abHead < 0) abHead += glm.twoPI;

            double offset = ((double)nudDistance.Value * mf.inchOrCm2m);

            double headingCalc = abHead + glm.PIBy2;

            mf.ABLine.lineArr.Add(new CABLines());
            mf.ABLine.numABLines = mf.ABLine.lineArr.Count;
            mf.ABLine.numABLineSelected = mf.ABLine.numABLines;

            int idx = mf.ABLine.numABLines - 1;

            mf.ABLine.lineArr[idx].heading = abHead;
            //calculate the new points for the reference line and points
            mf.ABLine.lineArr[idx].origin.easting = (Math.Sin(headingCalc) * (offset)) + arr[A].easting;
            mf.ABLine.lineArr[idx].origin.northing = (Math.Cos(headingCalc) * (offset)) + arr[A].northing;

            //if (!mf.bnd.bndArr[0].IsPointInsideBoundaryEar(mf.ABLine.lineArr[idx].origin))
            //{
            //    headingCalc = abHead - glm.PIBy2;
            //    mf.ABLine.lineArr[idx].origin.easting = (Math.Sin(headingCalc) * Math.Abs(offset)) + arr[A].easting;
            //    mf.ABLine.lineArr[idx].origin.northing = (Math.Cos(headingCalc) * Math.Abs(offset)) + arr[A].northing;
            //}

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

            //back the camera up
            GL.Translate(0, 0, -mf.maxFieldDistance);

            //translate to that spot in the world
            GL.Translate(-mf.fieldCenterX, -mf.fieldCenterY, 0);

            GL.Color3(1, 1, 1);

            //draw all the boundaries
            mf.bnd.DrawFenceLines();

            //the vehicle
            GL.PointSize(16.0f);
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

                    foreach (CABLines item in mf.ABLine.lineArr)
                    {
                        GL.Vertex3(item.origin.easting - (Math.Sin(item.heading) * mf.ABLine.abLength), item.origin.northing - (Math.Cos(item.heading) * mf.ABLine.abLength), 0);
                        GL.Vertex3(item.origin.easting + (Math.Sin(item.heading) * mf.ABLine.abLength), item.origin.northing + (Math.Cos(item.heading) * mf.ABLine.abLength), 0);
                    }

                    GL.End();
                }

                GL.Disable(EnableCap.LineStipple);

                if (mf.ABLine.numABLineSelected > 0)
                {
                    GL.Color3(1.0f, 0.0f, 0.0f);

                    GL.LineWidth(4);
                    GL.Begin(PrimitiveType.Lines);

                    GL.Vertex3(mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].origin.easting - (Math.Sin(mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].heading) * mf.ABLine.abLength),
                        mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].origin.northing - (Math.Cos(mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].heading) * mf.ABLine.abLength), 0);
                    GL.Vertex3(mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].origin.easting + (Math.Sin(mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].heading) * mf.ABLine.abLength),
                        mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].origin.northing + (Math.Cos(mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].heading) * mf.ABLine.abLength), 0);

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
                    foreach (vec3 item in mf.curve.curveArr[i].curvePts)
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
                    foreach (vec3 item in mf.curve.curveArr[mf.curve.numCurveLineSelected - 1].curvePts)
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

            bool isBounCurve = false;
            for (int i = 0; i < mf.curve.curveArr.Count; i++)
            {
                if (mf.curve.curveArr[i].Name == "Boundary Curve") isBounCurve = true;
            }

            if (isBounCurve) btnMakeBoundaryCurve.Enabled = false;
            else btnMakeBoundaryCurve.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {


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

        #endregion
    }
}