using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormABCurve : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf;

        private string filename = "";
        public List<CurveLines> curveArrs = new List<CurveLines>();
        
        public FormABCurve(Form _mf)
        {
            mf = _mf as FormGPS;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            mf.btnCurve.PerformClick();
            mf.curve.ResetCurveLine();
            mf.FileSaveCurveLine();
            //mf.DisableYouTurnButtons();

            lblCurveExists.Text = "Curve Not Set";


            mf.btnContour.Enabled = true;
            mf.btnABLine.Enabled = true;
            mf.curve.isOkToAddPoints = false;
            mf.curve.isCurveSet = false;
            mf.DisableYouTurnButtons();
            mf.btnContourPriority.Enabled = false;
            //curve.ResetCurveLine();
            mf.curve.isCurveBtnOn = false;

            mf.btnCurve.Image = mf.curve.isCurveBtnOn ? Properties.Resources.CurveOn : Properties.Resources.CurveOff;


            Close();
        }

        private void btnABLineOk_Click(object sender, System.EventArgs e)
        {
            if (mf.curve.refList.Count < 3)
            {
                Close();
                mf.btnCurve.PerformClick();
                mf.curve.ResetCurveLine();
                mf.DisableYouTurnButtons();
            }
            else
            {
                mf.curve.isCurveSet = true;
                mf.EnableYouTurnButtons();
                Close();
            }
        }

        private void btnAPoint_Click(object sender, System.EventArgs e)
        {
            //clear out the reference list
            lblCurveExists.Text = "Curve Being Set";
            mf.curve.refList?.Clear();
            mf.curve.isOkToAddPoints = true;
            btnBPoint.Enabled = true;
            btnAPoint.Enabled = false;
            btnABLineOk.Enabled = false;
            btnPausePlay.Enabled = true;
        }

        private void btnBPoint_Click(object sender, System.EventArgs e)
        {
            mf.curve.aveLineHeading = 0;
            mf.curve.isOkToAddPoints = false;
            btnBPoint.Enabled = false;
            btnAPoint.Enabled = true;
            btnABLineOk.Enabled = true;
            btnPausePlay.Enabled = false;

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
                SmoothAB(4);
                mf.curve.CalculateTurnHeadings();
                mf.EnableYouTurnButtons();
            }
            else
            {
                mf.curve.isCurveSet = false;
                mf.curve.refList?.Clear();
            }
            mf.FileSaveCurveLine();
            //Close();
        }

        //for calculating for display the averaged new line
        public void SmoothAB(int smPts)
        {
            //count the reference list of original curve
            int cnt = mf.curve.refList.Count;

            //the temp array
            vec3[] arr = new vec3[cnt];

            //read the points before and after the setpoint
            for (int s = 0; s < smPts / 2; s++)
            {
                arr[s].easting = mf.curve.refList[s].easting;
                arr[s].northing = mf.curve.refList[s].northing;
                arr[s].heading = mf.curve.refList[s].heading;
            }

            for (int s = cnt - (smPts / 2); s < cnt; s++)
            {
                arr[s].easting = mf.curve.refList[s].easting;
                arr[s].northing = mf.curve.refList[s].northing;
                arr[s].heading = mf.curve.refList[s].heading;
            }

            //average them - center weighted average
            for (int i = smPts / 2; i < cnt - (smPts / 2); i++)
            {
                for (int j = -smPts / 2; j < smPts / 2; j++)
                {
                    arr[i].easting += mf.curve.refList[j + i].easting;
                    arr[i].northing += mf.curve.refList[j + i].northing;
                }
                arr[i].easting /= smPts;
                arr[i].northing /= smPts;
                arr[i].heading = mf.curve.refList[i].heading;
            }

            //make a list to draw
            mf.curve.refList?.Clear();
            for (int i = 0; i < cnt; i++)
            {
                mf.curve.refList.Add(arr[i]);
            }
        }

        private void FormABCurve_Load(object sender, EventArgs e)
        {
            btnPausePlay.Enabled = false;
            btnAPoint.Enabled = true;
            btnBPoint.Enabled = false;
            mf.curve.isOkToAddPoints = false;
            
            if (mf.curve.refList.Count > 3)
            {
                lblCurveExists.Text = "Curve Set";
                btnABLineOk.Enabled = true;
            }
            else
            {
                mf.curve.ResetCurveLine();
                lblCurveExists.Text = "Curve Not Set";
                btnABLineOk.Enabled = false;
            }
            curveArrs?.Clear();
            FormABCurve_LoadCurves();
        }
        
        private void FormABCurve_LoadCurves()
        {

            string dirField = mf.ablinesDirectory;

            //string dirField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";
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
                mf.TimedMessageBox(2000, "File Error", "Missing CurveLines File, Critical Error");
            }
            else
            {
                using (StreamReader reader = new StreamReader(filename))
                {

                    try
                    {
                        ListViewItem itm;
                        string line;
                        int num = 0;

                        //read header $CurveLine
                        line = reader.ReadLine();


                        while (!reader.EndOfStream)
                        {

                            curveArrs.Add(new CurveLines());

                            //read header $CurveLine
                            curveArrs[num].Name = reader.ReadLine();
                            // get the average heading
                            line = reader.ReadLine();
                            curveArrs[num].Heading = double.Parse(line, CultureInfo.InvariantCulture);

                            line = reader.ReadLine();
                            int numPoints = int.Parse(line);


                            if (numPoints > 1)
                            {
                                itm = new ListViewItem(curveArrs[num].Name);
                                lvLines.Items.Add(itm);

                                curveArrs[num].curveArr?.Clear();

                                for (int i = 0; i < numPoints; i++)
                                {
                                    line = reader.ReadLine();
                                    string[] words = line.Split(',');
                                    vec3 vecPt = new vec3(double.Parse(words[0], CultureInfo.InvariantCulture), double.Parse(words[1], CultureInfo.InvariantCulture), double.Parse(words[2], CultureInfo.InvariantCulture));
                                    curveArrs[num].curveArr.Add(vecPt);
                                }
                                num = num + 1;
                            }
                            else
                            {
                                if (curveArrs.Count > 0)
                                {
                                    curveArrs.RemoveAt(num);
                                }
                            }

                        }
                    }

                    catch (Exception er)
                    {
                        var form = new FormTimedMessage(4000, "Curve Line File is Corrupt", "But Field is Loaded");
                        form.Show();
                        mf.WriteErrorLog("Load Curve Line" + er.ToString());

                    }

                }

                // go to bottom of list - if there is a bottom
                if (lvLines.Items.Count > 0) lvLines.Items[lvLines.Items.Count - 1].EnsureVisible();
            }
        }

        private void btnPausePlay_Click(object sender, EventArgs e)
        {
            if (mf.curve.isOkToAddPoints)
            {
                mf.curve.isOkToAddPoints = false;
                btnPausePlay.Image = Properties.Resources.BoundaryRecord;
                btnPausePlay.Text = "Record";
                btnBPoint.Enabled = false;
            }
            else
            {
                mf.curve.isOkToAddPoints = true;
                btnPausePlay.Image = Properties.Resources.boundaryPause;
                btnPausePlay.Text = "Pause";
                btnBPoint.Enabled = true;
            }
        }

        private void btnListUse_Click(object sender, EventArgs e)
        {
            int count = lvLines.SelectedItems.Count;


            if (count > 0)
            {

                int aa = lvLines.SelectedIndices[0];

                mf.curve.aveLineHeading = curveArrs[aa].Heading;


                mf.curve.refList?.Clear();

                for (int i = 0; i < curveArrs[aa].curveArr.Count; i++)
                {
                    mf.curve.refList.Add(curveArrs[aa].curveArr[i]);

                }
                if (mf.curve.refList.Count > 2)
                {
                    lblCurveExists.Text = "Curve Set";
                    btnABLineOk.Enabled = true;
                }
                //can go back to Mainform without seeing ABLine form.
                //DialogResult = DialogResult.Yes;
                //Close();
            }

            //no item selected
            else
            {
                return;
            }
        }

        private void btnAddToFile_Click(object sender, EventArgs e)
        {


            string dirField = mf.ablinesDirectory;

            //string dirField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            filename = directoryName + "\\CurveLines.txt";


            //use Streamwriter to create and overwrite existing curveLines file
            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                try
                {
                    if (mf.curve.refList.Count > 0)
                    {
                        if (textBox1.Text.Length > 0)
                        {
                            curveArrs.Add(new CurveLines());
                            curveArrs[curveArrs.Count - 1].Name = textBox1.Text;
                            curveArrs[curveArrs.Count - 1].Heading = mf.curve.aveLineHeading;

                            ListViewItem itm = new ListViewItem(curveArrs[curveArrs.Count - 1].Name);
                            lvLines.Items.Add(itm);

                            //write out the ABLine
                            writer.WriteLine(textBox1.Text);

                            //write out the aveheading
                            writer.WriteLine(mf.curve.aveLineHeading.ToString(CultureInfo.InvariantCulture));

                            //write out the points of ref line
                            writer.WriteLine(mf.curve.refList.Count.ToString(CultureInfo.InvariantCulture));

                            for (int j = 0; j < mf.curve.refList.Count; j++)
                            {
                                curveArrs[curveArrs.Count - 1].curveArr.Add(mf.curve.refList[j]);
                                writer.WriteLine(Math.Round(mf.curve.refList[j].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                        Math.Round(mf.curve.refList[j].northing, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                            Math.Round(mf.curve.refList[j].heading, 5).ToString(CultureInfo.InvariantCulture));
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Currently no ABCurve name\n      create ABCurve name");
                            var form2 = new FormTimedMessage(4000, "Currently no ABCurve name", "create ABCurve name");
                            form2.Show();
                        }
                        textBox1.Clear();
                    }
                    else
                    {
                        var form2 = new FormTimedMessage(4000, "Currently no ABCurve line", "Start a ABCurve line First");
                        form2.Show();
                    }
                }

                catch (Exception er)
                {
                    Console.WriteLine(er.Message + "\n Cannot write to file.");
                    mf.WriteErrorLog("Saving Curve Line" + er.ToString());

                    return;
                }

            }
        }


        private void btnListDelete_Click(object sender, EventArgs e)
        {
            string dirField = mf.ablinesDirectory;

            //string dirField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            filename = directoryName + "\\CurveLines.txt";

            int count = lvLines.SelectedItems.Count;
            if (count > 0)
            {
                int num = lvLines.SelectedIndices[0];
                curveArrs.RemoveAt(num);
                lvLines.SelectedItems[0].Remove();
            }
            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                try
                {
                    writer.WriteLine("$CurveLines");
                    for (int i = 0; i < curveArrs.Count; i++)
                    {

                        //curveArrs[i].curveArr

                        //write out the Name
                        writer.WriteLine(curveArrs[i].Name);

                        //write out the aveheading
                        writer.WriteLine(curveArrs[i].Heading.ToString(CultureInfo.InvariantCulture));

                        //write out the points of ref line
                        writer.WriteLine(curveArrs[i].curveArr.Count.ToString(CultureInfo.InvariantCulture));
                        if (curveArrs[i].curveArr.Count > 0)
                        {
                            for (int j = 0; j < curveArrs[i].curveArr.Count; j++)
                                writer.WriteLine(Math.Round(curveArrs[i].curveArr[j].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                    Math.Round(curveArrs[i].curveArr[j].northing, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                        Math.Round(curveArrs[i].curveArr[j].heading, 5).ToString(CultureInfo.InvariantCulture));
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
        }
    }
    public class CurveLines
    {
        public double Heading = 3;
        public string Name = "aa";
        public List<vec3> curveArr = new List<vec3>();
    }
}
