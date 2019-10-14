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
    public partial class FormABPick : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        //Array of all saved lines
        public List<CurveLinePick> curveArr = new List<CurveLinePick>();

        public List<ABLinePick> lineArr = new List<ABLinePick>();

        private string filename = "";

        private double maxFieldX, maxFieldY, minFieldX, minFieldY, fieldCenterX, fieldCenterY, maxFieldDistance, gain = 1;
        private Point fixPt;

        private bool isA = true, isB = false;
        public double low = 0, high = 1;
        private int A, B, C, D, E, start=99999, end=99999;
        //list of coordinates of boundary line
        public List<vec3> turnLine = new List<vec3>();
        private vec3[] arr;

        public vec2 lastABLineP2 = new vec2(0.0, 1.0);

        public FormABPick(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            lblLineName.Text = gStr.gsEnterLineName;
        }


        private void BtnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(gStr.gsClick2Pointsontheboundary + "\r\n " +
                            gStr.gsEnternameandClickSaveifRequired + "\r\n" +
                            gStr.gsClicknewpointsmakemorelines);
        }

        public vec3 pint = new vec3(0.0, 1.0, 0.0);

        private void FormABPick_Load(object sender, EventArgs e)
        {

            int cnt = mf.bnd.bndArr[0].bndLine.Count;
            arr = new vec3[cnt*2];

            for (int i = 0; i < cnt; i++)
            {
                arr[i].easting = mf.bnd.bndArr[0].bndLine[i].easting;
                arr[i].northing = mf.bnd.bndArr[0].bndLine[i].northing;
                arr[i].heading = mf.bnd.bndArr[0].bndLine[i].northing;
            }

            for (int i = cnt; i < cnt*2; i++)
            {
                arr[i].easting = mf.bnd.bndArr[0].bndLine[i-cnt].easting;
                arr[i].northing = mf.bnd.bndArr[0].bndLine[i-cnt].northing;
                arr[i].heading = mf.bnd.bndArr[0].bndLine[i-cnt].heading;
            }

            curveArr.Clear();
            LoadCurves();
            LoadLines();

        }

        private void LoadLines()
        {
            //make sure at least a global blank AB Line file exists
            string dirField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            filename = directoryName + "\\ABLines.txt";


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

            if (!File.Exists(filename))
            {
                mf.TimedMessageBox(2000, gStr.gsFileError, gStr.gsMissingABLinesFile);
            }
            else
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    try
                    {
                        string line;

                        //read all the lines
                        for (int num = 0; !reader.EndOfStream; num++)
                        {
                            lineArr.Add(new ABLinePick());

                            line = reader.ReadLine();
                            string[] words = line.Split(',');

                            lineArr[num].Name = words[0];

                            lineArr[num].heading = glm.toRadians(double.Parse(words[1], CultureInfo.InvariantCulture));
                            lineArr[num].origin.easting = double.Parse(words[2], CultureInfo.InvariantCulture);
                            lineArr[num].origin.northing = double.Parse(words[3], CultureInfo.InvariantCulture);

                            lineArr[num].ref1.easting = lineArr[num].origin.easting - (Math.Sin(lineArr[num].heading) * 2000.0);
                            lineArr[num].ref1.northing = lineArr[num].origin.northing - (Math.Cos(lineArr[num].heading) * 2000.0);

                            lineArr[num].ref2.easting = lineArr[num].origin.easting + (Math.Sin(lineArr[num].heading) * 2000.0);
                            lineArr[num].ref2.northing = lineArr[num].origin.northing + (Math.Cos(lineArr[num].heading) * 2000.0);
                        }
                    }
                    catch (Exception er)
                    {
                        var form = new FormTimedMessage(2000, gStr.gsABLineFileIsCorrupt, gStr.gsPleasedeleteit);
                        form.Show();
                        mf.WriteErrorLog("FieldOpen, Loading ABLine, Corrupt ABLine File" + er);
                    }
                }
            }
        }

        private void LoadCurves()
        {
            //get the directory and make sure it exists, create if not
            string dirField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            filename = directoryName + "\\CurveLines.txt";

            if (!File.Exists(filename))
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine("$CurveLines");
                }
            }

            //get the file of previous AB Lines
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }
            if (!File.Exists(filename))
            {
                mf.TimedMessageBox(2000, gStr.gsFileError, gStr.gsMissingABCurveFile);
            }
            else
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    try
                    {
                        string line;
                        int num = 0;
                        Random rnd = new Random();

                        //read header $CurveLine
                        line = reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            curveArr.Add(new CurveLinePick());

                            curveArr[num].red = (byte)(rnd.Next(200, 250));
                            curveArr[num].grn = (byte)(rnd.Next(100, 250));
                            curveArr[num].blu = (byte)(rnd.Next(50, 250));

                            //read header $CurveLine
                            curveArr[num].Name = reader.ReadLine();
                            // get the average heading
                            line = reader.ReadLine();
                            curveArr[num].aveHeading = double.Parse(line, CultureInfo.InvariantCulture);

                            line = reader.ReadLine();
                            int numPoints = int.Parse(line);

                            if (numPoints > 1)
                            {
                                curveArr[num].curvePts?.Clear();

                                for (int i = 0; i < numPoints; i++)
                                {
                                    line = reader.ReadLine();
                                    string[] words = line.Split(',');
                                    vec3 vecPt = new vec3(double.Parse(words[0], CultureInfo.InvariantCulture),
                                        double.Parse(words[1], CultureInfo.InvariantCulture),
                                        double.Parse(words[2], CultureInfo.InvariantCulture));
                                    curveArr[num].curvePts.Add(vecPt);
                                }
                                num++;
                            }

                            else
                            {
                                if (curveArr.Count > 0)
                                {
                                    curveArr.RemoveAt(num);
                                }
                            }
                        }
                    }
                    catch (Exception er)
                    {
                        var form = new FormTimedMessage(2000, gStr.gsCurveLineFileIsCorrupt, gStr.gsButFieldIsLoaded);
                        form.Show();
                        mf.WriteErrorLog("Load Curve Line" + er.ToString());
                    }
                }
            }
        }

        private void oglSelf_MouseDown(object sender, MouseEventArgs e)
        {
            start = 99999; end = 99999;

            btnMakeABLine.Enabled = false;
            btnMakeCurve.Enabled = false;
            tboxABLineSaveName.Enabled = false;
            btnSaveABLine.Enabled = false;

            Point pt = oglSelf.PointToClient(Cursor.Position);

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
            //if (mf.ABLine.isABLineLoaded)
            //{
            //    //Draw reference AB line ref
            //    GL.LineWidth(2);
            //    GL.Enable(EnableCap.LineStipple);
            //    GL.LineStipple(1, 0x00F0);
            //    GL.Begin(PrimitiveType.Lines);
            //    GL.Color3(0.9f, 0.915f, 0.17f);
            //    GL.Vertex3(mf.ABLine.refABLineP1.easting, mf.ABLine.refABLineP1.northing, 0);
            //    GL.Color3(0.92f, 0.95f, 0.17f);
            //    GL.Vertex3(mf.ABLine.refABLineP2.easting, mf.ABLine.refABLineP2.northing, 0);
            //    GL.End();
            //    GL.Disable(EnableCap.LineStipple);

            //}

            //if (mf.curve.isCurveSet)
            //{
            //    int ptCount = mf.curve.refList.Count;
            //    if (ptCount > 0)
            //    {
            //        GL.LineWidth(2);
            //        GL.Color3(0.30f, 0.7692f, 0.760f);
            //        GL.Begin(PrimitiveType.LineStrip);
            //        for (int h = 0; h < ptCount; h++) GL.Vertex3(mf.curve.refList[h].easting, mf.curve.refList[h].northing, 0);
            //        GL.End();
            //    }
            //}

            int numLines = lineArr.Count;

            if (numLines > 2)
            {
                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0x00F0);
                GL.Color3(1.0f, 0.0f, 0.0f);

                for (int i = 2; i < numLines; i++)
                {

                    GL.LineWidth(4);
                    GL.Begin(PrimitiveType.Lines);

                    foreach (var item in lineArr)
                    {
                        GL.Vertex3(item.ref1.easting, item.ref1.northing, 0);
                        GL.Vertex3(item.ref2.easting, item.ref2.northing, 0);

                    }
                    GL.End();
                }

                GL.Disable(EnableCap.LineStipple);
            }



            int numCurves = curveArr.Count;

            if (numCurves > 0 )
            {
                for (int i = 0; i < numCurves; i++)
                {

                    GL.LineWidth(4);
                    GL.Color3(curveArr[i].red, curveArr[i].grn, curveArr[i].blu);
                    GL.Begin(PrimitiveType.LineStrip);
                        foreach (var item in curveArr[i].curvePts)
                        {
                            GL.Vertex3(item.easting, item.northing, 0);

                        }
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

            //if (String.IsNullOrEmpty(tboxABLineSaveName.Text)) btnSaveABLine.Enabled = false;
            //else btnSaveABLine.Enabled = true;
            //if (String.IsNullOrEmpty(tboxCurveSaveName.Text)) btnSaveABCurve.Enabled = false;
            //else btnSaveABCurve.Enabled = true;
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
                if (mf.bnd.bndArr[0].isSet)
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

    public class CurveLinePick
    {
        public List<vec3> curvePts = new List<vec3>();
        public double aveHeading = 3;
        public string Name = "aa";
        public byte red = 200;
        public byte grn = 0;
        public byte blu = 0;
    }

    public class ABLinePick
    {
        public vec2 ref1 = new vec2();
        public vec2 ref2 = new vec2();
        public vec2 origin = new vec2();
        public double heading = 0;
        public string Name = "aa";
    }

}