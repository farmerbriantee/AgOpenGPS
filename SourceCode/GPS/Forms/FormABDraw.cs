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

        public List<CurveLinePick> curveArr = new List<CurveLinePick>();

        public List<ABLinePick> lineArr = new List<ABLinePick>();

        private double maxFieldX, maxFieldY, minFieldX, minFieldY, fieldCenterX, fieldCenterY, maxFieldDistance;
        private Point fixPt;

        private bool isA = true, isMakingAB = false, isMakingCurve = false;
        public double low = 0, high = 1;
        private int A, B, C, D, E, start = 99999, end = 99999;

        private int numABLines = 0, numCurves = 0, numABSelected = 0, numCurveSelected = 0;

        //list of coordinates of boundary line
        public List<vec3> turnLine = new List<vec3>();

        private vec3[] arr;

        private void FixLabelsCurve()
        {
            lblNumCu.Text = numCurves.ToString();
            lblCurveSelected.Text = numCurveSelected.ToString();

            if (numCurveSelected > 0)
                lblCurveName.Text = curveArr[numCurveSelected - 1].Name;
            else
                lblCurveName.Text = "***";
        }

        private void FixLabelsABLine()
        {
            lblNumAB.Text = numABLines.ToString();
            lblABSelected.Text = numABSelected.ToString();

            if (numABSelected > 0) lblABLineName.Text = lineArr[numABSelected - 1].Name;
            else lblABLineName.Text = "***";
        }

        private string FindDirection(double heading)
        {
            if (heading < 0) heading += glm.twoPI;

            heading = glm.toDegrees(heading);

            if (heading > 337.5 || heading < 22.5)
            {
                return " North ";
            }
            if (heading > 22.5 && heading < 67.5)
            {
                return " NW ";
            }
            if (heading > 67.5 && heading < 111.5)
            {
                return " East ";
            }
            if (heading > 111.5 && heading < 157.5)
            {
                return " SE ";
            }
            if (heading > 157.5 && heading < 202.5)
            {
                return " South ";
            }
            if (heading > 202.5 && heading < 247.5)
            {
                return " SW ";
            }
            if (heading > 247.5 && heading < 292.5)
            {
                return "West";
            }
            if (heading > 292.5 && heading < 337.5)
            {
                return " NW ";
            }
            return " Lost ";
        }

        private void btnSelectCurve_Click(object sender, EventArgs e)
        {
            if (numCurves > 0)
            {
                numCurveSelected++;
                if (numCurveSelected > numCurves) numCurveSelected = 1;
            }
            else
            {
                numCurveSelected = 0;
            }

            FixLabelsCurve();
        }

        private void btnSelectABLine_Click(object sender, EventArgs e)
        {
            if (numABLines > 0)
            {
                numABSelected++;
                if (numABSelected > numABLines) numABSelected = 1;
            }
            else
            {
                numABSelected = 0;
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

            LoadLines();
            LoadCurves();
            btnCancelTouch.Enabled = false;
        }

        private void btnDeleteCurve_Click(object sender, EventArgs e)
        {
            if (curveArr.Count > 0 && numCurveSelected > 0)
            {
                curveArr.RemoveAt(numCurveSelected - 1);
                numCurves--;

                string dirField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";
                string directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

                if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
                { Directory.CreateDirectory(directoryName); }

                string filename = directoryName + "\\CurveLines.txt";

                using (StreamWriter writer = new StreamWriter(filename, false))
                {
                    try
                    {
                        if (curveArr.Count > 0)
                        {
                            writer.WriteLine("$CurveLines");

                            for (int i = 0; i < curveArr.Count; i++)
                            {
                                //write out the Name
                                writer.WriteLine(curveArr[i].Name);

                                //write out the aveheading
                                writer.WriteLine(curveArr[i].aveHeading.ToString(CultureInfo.InvariantCulture));

                                //write out the points of ref line
                                writer.WriteLine(curveArr[i].curvePts.Count.ToString(CultureInfo.InvariantCulture));
                                if (curveArr[i].curvePts.Count > 0)
                                {
                                    for (int j = 0; j < curveArr[i].curvePts.Count; j++)
                                        writer.WriteLine(Math.Round(curveArr[i].curvePts[j].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                            Math.Round(curveArr[i].curvePts[j].northing, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                                Math.Round(curveArr[i].curvePts[j].heading, 5).ToString(CultureInfo.InvariantCulture));
                                }
                            }
                        }
                        else
                        {
                            writer.WriteLine("$CurveLines");
                        }
                    }
                    catch (Exception er)
                    {
                        mf.WriteErrorLog("Saving Curve Line" + er.ToString());

                        return;
                    }
                }
            }

            if (numCurves > 0) numCurveSelected = 1;
            else numCurveSelected = 0;

            FixLabelsCurve();
        }

        private void btnDeleteABLine_Click(object sender, EventArgs e)
        {
            if (lineArr.Count > 0 && numABSelected > 0)
            {
                lineArr.RemoveAt(numABSelected - 1);
                numABLines--;
                numABSelected--;

                //make sure at least a global blank AB Line file exists
                string dirField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";
                string directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

                //get the file of previous AB Lines
                if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
                { Directory.CreateDirectory(directoryName); }

                string filename = directoryName + "\\ABLines.txt";

                using (StreamWriter writer = new StreamWriter(filename, false))
                {
                    if (numABLines > 0)
                    {
                        for (int i = 0; i < numABLines; i++)
                        {
                            foreach (var item in lineArr)
                            {
                                //make it culture invariant
                                string line = item.Name
                                    + ',' + (Math.Round(glm.toDegrees(item.heading), 8)).ToString(CultureInfo.InvariantCulture)
                                    + ',' + (Math.Round(item.origin.easting, 3)).ToString(CultureInfo.InvariantCulture)
                                    + ',' + (Math.Round(item.origin.northing, 3)).ToString(CultureInfo.InvariantCulture);

                                //write out to file
                                writer.WriteLine(line);
                            }
                        }
                    }
                }
            }

            if (numABLines > 0) numABSelected = 1;
            else numABSelected = 0;

            FixLabelsABLine();

            //LoadLines();
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

            curveArr?.Clear();
            lineArr?.Clear();
            LoadCurves();
            LoadLines();
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

        private void LoadLines()
        {
            lineArr?.Clear();
            numABLines = 0;

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
                }
            }

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
                        numABLines = 0;

                        //read all the lines
                        for (int i = 0; !reader.EndOfStream; i++)
                        {

                            line = reader.ReadLine();
                            string[] words = line.Split(',');

                            if (words.Length != 4) break;

                            lineArr.Add(new ABLinePick());

                            lineArr[i].Name = words[0];


                            lineArr[i].heading = glm.toRadians(double.Parse(words[1], CultureInfo.InvariantCulture));
                            lineArr[i].origin.easting = double.Parse(words[2], CultureInfo.InvariantCulture);
                            lineArr[i].origin.northing = double.Parse(words[3], CultureInfo.InvariantCulture);

                            lineArr[i].ref1.easting = lineArr[i].origin.easting - (Math.Sin(lineArr[i].heading) * 2000.0);
                            lineArr[i].ref1.northing = lineArr[i].origin.northing - (Math.Cos(lineArr[i].heading) * 2000.0);

                            lineArr[i].ref2.easting = lineArr[i].origin.easting + (Math.Sin(lineArr[i].heading) * 2000.0);
                            lineArr[i].ref2.northing = lineArr[i].origin.northing + (Math.Cos(lineArr[i].heading) * 2000.0);
                            numABLines++;
                        }
                    }
                    catch (Exception er)
                    {
                        var form = new FormTimedMessage(2000, gStr.gsABLineFileIsCorrupt, "Please delete it!!!");
                        form.Show();
                        mf.WriteErrorLog("FieldOpen, Loading ABLine, Corrupt ABLine File" + er);
                    }
                }
            }

            if (numABLines > 0) numABSelected = 1;
            else numABSelected = 0;

            FixLabelsABLine();        }

        private void LoadCurves()
        {
            curveArr?.Clear();
            numCurves = 0;

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
                        numCurves = 0;

                        //read header $CurveLine
                        line = reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            curveArr.Add(new CurveLinePick());

                            //read header $CurveLine
                            curveArr[numCurves].Name = reader.ReadLine();
                            // get the average heading
                            line = reader.ReadLine();
                            curveArr[numCurves].aveHeading = double.Parse(line, CultureInfo.InvariantCulture);

                            line = reader.ReadLine();
                            int numPoints = int.Parse(line);

                            if (numPoints > 1)
                            {
                                curveArr[numCurves].curvePts?.Clear();

                                for (int i = 0; i < numPoints; i++)
                                {
                                    line = reader.ReadLine();
                                    string[] words = line.Split(',');
                                    vec3 vecPt = new vec3(double.Parse(words[0], CultureInfo.InvariantCulture),
                                        double.Parse(words[1], CultureInfo.InvariantCulture),
                                        double.Parse(words[2], CultureInfo.InvariantCulture));
                                    curveArr[numCurves].curvePts.Add(vecPt);
                                }
                                numCurves++;
                            }
                            else
                            {
                                if (curveArr.Count > 0)
                                {
                                    curveArr.RemoveAt(numCurves);
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

            if (numCurves > 0) numCurveSelected = 1;
            else numCurveSelected = 0;

            FixLabelsCurve();
        }

        private void BtnMakeCurve_Click(object sender, EventArgs e)
        {
            btnCancelTouch.Enabled = false;

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
                mf.FileSaveCurveLine();

                btnMakeABLine.Enabled = false;
                btnMakeCurve.Enabled = false;

                isMakingCurve = true;
                isMakingAB = false;

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
                        //write out the ABLine
                        writer.WriteLine(mf.curve.refList.Count.ToString() + "_Pts "
                            + DateTime.Now.ToString("mm_ss", CultureInfo.InvariantCulture));

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
                    catch (Exception er)
                    {
                        Console.WriteLine(er.Message + "\n Cannot write to file.");
                        mf.WriteErrorLog("Saving Curve Line" + er.ToString());
                        return;
                    }
                }

                //update the arrays
                LoadCurves();
                numCurveSelected = numCurves;

                FixLabelsCurve();

                isMakingCurve = false;
                isMakingAB = false;
                start = 99999; end = 99999;
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

            double offset = 0.5 * mf.vehicle.toolWidth;

            double headingCalc = abHead + glm.PIBy2;

            lineArr.Add(new ABLinePick());
            numABLines++;
            numABSelected = numABLines;

            int idx = numABLines - 1;

            lineArr[idx].heading = abHead;
            //calculate the new points for the reference line and points
            lineArr[idx].origin.easting = (Math.Sin(headingCalc) * Math.Abs(offset)) + arr[A].easting;
            lineArr[idx].origin.northing = (Math.Cos(headingCalc) * Math.Abs(offset)) + arr[A].northing;

            if (!mf.bnd.bndArr[0].IsPointInsideBoundary(lineArr[idx].origin))
            {
                headingCalc = abHead - glm.PIBy2;
                lineArr[idx].origin.easting = (Math.Sin(headingCalc) * Math.Abs(offset)) + arr[A].easting;
                lineArr[idx].origin.northing = (Math.Cos(headingCalc) * Math.Abs(offset)) + arr[A].northing;
            }

            //sin x cos z for endpoints, opposite for additional lines
            lineArr[idx].ref1.easting =   lineArr[idx].origin.easting - (Math.Sin(lineArr[idx].heading) * 2000.0);
            lineArr[idx].ref1.northing = lineArr[idx].origin.northing - (Math.Cos(lineArr[idx].heading) * 2000.0);
            lineArr[idx].ref2.easting =  lineArr[idx].origin.easting +  (Math.Sin(lineArr[idx].heading) * 2000.0);
            lineArr[idx].ref2.northing = lineArr[idx].origin.northing + (Math.Cos(lineArr[idx].heading) * 2000.0);

            //create a name
            lineArr[idx].Name = (Math.Round(glm.toDegrees(lineArr[idx].heading), 1)).ToString(CultureInfo.InvariantCulture) 
                + FindDirection(lineArr[idx].heading) + DateTime.Now.ToString("mm_ss", CultureInfo.InvariantCulture);

            //clean up gui
            btnMakeABLine.Enabled = false;
            btnMakeCurve.Enabled = false;
            isMakingCurve = false;
            isMakingAB = true;

            //make sure at least a global blank AB Line file exists
            string dirField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string filename = directoryName + "\\ABLines.txt";

            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                try
                {
                    //make it culture invariant
                    string line = lineArr[idx].Name.Trim()
                        + ',' + (Math.Round(glm.toDegrees(lineArr[idx].heading), 8)).ToString(CultureInfo.InvariantCulture)
                        + ',' + (Math.Round(lineArr[idx].origin.easting, 3)).ToString(CultureInfo.InvariantCulture)
                        + ',' + (Math.Round(lineArr[idx].origin.northing, 3)).ToString(CultureInfo.InvariantCulture);

                    //write out to file
                    writer.WriteLine(line);
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.Message + "\n Cannot write to file.");
                    mf.WriteErrorLog("Saving ABLines Draw append" + er.ToString());
                    return;
                }
            }

            isMakingCurve = false;
            isMakingAB = false;

            FixLabelsABLine();

            start = 99999; end = 99999;
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

            //draw the line building graphics
            if (start != 99999 || end != 99999) DrawABTouchLine();

            //draw the actual built lines
            if (start == 99999 && end == 99999) DrawBuiltLines();
            {

                ////draw the ABLine
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

                ////if (mf.curve.isCurveSet)
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
            }

            GL.Flush();
            oglSelf.SwapBuffers();
        }

        private void DrawBuiltLines()
        {
            int numLines = lineArr.Count;

            if (numLines > 0)
            {
                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0x0707);
                GL.Color3(1.0f, 0.0f, 0.0f);

                for (int i = 0; i < numLines; i++)
                {
                    GL.LineWidth(2);
                    GL.Begin(PrimitiveType.Lines);

                    foreach (var item in lineArr)
                    {
                        GL.Vertex3(item.ref1.easting, item.ref1.northing, 0);
                        GL.Vertex3(item.ref2.easting, item.ref2.northing, 0);
                    }
                    GL.End();
                }

                GL.Disable(EnableCap.LineStipple);

                if (numABSelected > 0)
                {
                    GL.Color3(1.0f, 0.0f, 0.0f);

                    GL.LineWidth(4);
                    GL.Begin(PrimitiveType.Lines);

                    foreach (var item in lineArr)
                    {
                        GL.Vertex3(lineArr[numABSelected - 1].ref1.easting, lineArr[numABSelected - 1].ref1.northing, 0);
                        GL.Vertex3(lineArr[numABSelected - 1].ref2.easting, lineArr[numABSelected - 1].ref2.northing, 0);
                    }
                    GL.End();
                }
            }

            int numCurv = curveArr.Count;

            if (numCurv > 0)
            {
                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0x7070);

                for (int i = 0; i < numCurv; i++)
                {
                    GL.LineWidth(2);
                    GL.Color3(0.0f, 1.0f, 0.0f);
                    GL.Begin(PrimitiveType.LineStrip);
                    foreach (var item in curveArr[i].curvePts)
                    {
                        GL.Vertex3(item.easting, item.northing, 0);
                    }
                    GL.End();
                }

                GL.Disable(EnableCap.LineStipple);

                if (numCurveSelected > 0)
                {
                    GL.LineWidth(4);
                    GL.Color3(0.0f, 1.0f, 0.0f);
                    GL.Begin(PrimitiveType.LineStrip);
                    foreach (var item in curveArr[numCurveSelected - 1].curvePts)
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
            if (numABSelected > 0)
            {
                mf.ABLine.refPoint1 = lineArr[numABSelected - 1].origin;
                //mf.ABLine.refPoint2 = lineArr[numABSelected - 1].ref2;
                mf.ABLine.abHeading = lineArr[numABSelected - 1].heading;
                mf.ABLine.SetABLineByHeading();
                mf.FileSaveABLine();
                mf.ABLine.isABLineSet = false;
                mf.ABLine.isABLineLoaded = true;
            }
            else
            {
                mf.ABLine.isABLineSet = false;
                mf.ABLine.isABLineLoaded = false;
            }


            //curve
            if (numCurveSelected > 0)
            {
                int aa = numCurveSelected - 1;
                mf.curve.aveLineHeading = curveArr[aa].aveHeading;

                mf.curve.refList?.Clear();

                for (int i = 0; i < curveArr[aa].curvePts.Count; i++)
                {
                    mf.curve.refList.Add(curveArr[aa].curvePts[i]);
                }
                    mf.curve.isCurveSet = true;
                    mf.FileSaveCurveLine();
            }
            else
            {
                mf.curve.isCurveSet = false;
                mf.curve.refList?.Clear();
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