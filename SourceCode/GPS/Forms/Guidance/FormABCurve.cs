using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AgOpenGPS
{
    public partial class FormABCurve : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf;
        private double aveLineHeading;
        private int originalLine = 0;
        private bool isClosing;
        private int selectedItem = -1;

        public FormABCurve(Form _mf)
        {
            mf = _mf as FormGPS;
            InitializeComponent();

            //btnPausePlay.Text = gStr.gsPause;
            this.Text = gStr.gsABCurve;
        }

        private void FormABCurve_Load(object sender, EventArgs e)
        {
            panelPick.Top = 3;
            panelPick.Left = 3;
            panelAPlus.Top = 3;
            panelAPlus.Left = 3;
            panelName.Top = 3;
            panelName.Left = 3;

            panelEditName.Top = 3;
            panelEditName.Left = 3;

            panelEditName.Visible = false;

            panelPick.Visible = true;
            panelAPlus.Visible = false;
            panelName.Visible = false;

            this.Size = new System.Drawing.Size(620,475);

            originalLine = mf.curve.numCurveLineSelected;
            mf.curve.isOkToAddDesPoints = false;
            selectedItem = -1;

            UpdateTable();
        }

        private void UpdateTable()
        {
            Font backupfont = new Font(Font.FontFamily, 18F, FontStyle.Regular);
            flp.Controls.Clear();

            for (int i = 0; i < mf.curve.curveArr.Count; i++)
            {
                //outer inner
                Button a = new Button
                {
                    Margin = new Padding(6,10,10,10),
                    Size = new Size(50, 25),
                    Name = i.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    //ForeColor = System.Drawing.SystemColors.ButtonFace
                };
                a.Click += A_Click;

                if (mf.curve.curveArr[i].isVisible)
                    a.BackColor = System.Drawing.Color.Green;
                else
                    a.BackColor = System.Drawing.Color.Red;

                //a.Font = backupfont;
                //a.FlatStyle = FlatStyle.Flat;
                //a.FlatAppearance.BorderColor = Color.Cyan;
                //a.BackColor = Color.Transparent;
                //a.FlatAppearance.MouseOverBackColor = BackColor;
                //a.FlatAppearance.MouseDownBackColor = BackColor;

                TextBox t = new TextBox
                {
                    Margin = new Padding(3),
                    Size = new Size(330, 35),
                    Text = mf.curve.curveArr[i].Name,
                    Name = i.ToString(),
                };
                t.Font = backupfont;
                t.Click += LineSelected_Click;


                if (mf.curve.curveArr[i].isVisible)
                    t.ForeColor = System.Drawing.Color.Black;
                else
                    t.ForeColor = System.Drawing.Color.Gray;

                if (i == selectedItem)
                {
                    t.BackColor = System.Drawing.Color.LightBlue;
                }
                else
                {
                    t.BackColor = System.Drawing.SystemColors.ButtonFace;
                }

                flp.Controls.Add(a);
                flp.Controls.Add(t);
            }
        }

        public void SmoothAB(int smPts)
        {
            //count the reference list of original curve
            int cnt = mf.curve.desList.Count;

            //the temp array
            vec3[] arr = new vec3[cnt];

            //read the points before and after the setpoint
            for (int s = 0; s < smPts / 2; s++)
            {
                arr[s].easting = mf.curve.desList[s].easting;
                arr[s].northing = mf.curve.desList[s].northing;
                arr[s].heading = mf.curve.desList[s].heading;
            }

            for (int s = cnt - (smPts / 2); s < cnt; s++)
            {
                arr[s].easting = mf.curve.desList[s].easting;
                arr[s].northing = mf.curve.desList[s].northing;
                arr[s].heading = mf.curve.desList[s].heading;
            }

            //average them - center weighted average
            for (int i = smPts / 2; i < cnt - (smPts / 2); i++)
            {
                for (int j = -smPts / 2; j < smPts / 2; j++)
                {
                    arr[i].easting += mf.curve.desList[j + i].easting;
                    arr[i].northing += mf.curve.desList[j + i].northing;
                }
                arr[i].easting /= smPts;
                arr[i].northing /= smPts;
                arr[i].heading = mf.curve.desList[i].heading;
            }

            //make a list to draw
            mf.curve.desList?.Clear();
            for (int i = 0; i < cnt; i++)
            {
                mf.curve.desList.Add(arr[i]);
            }
        }

        public void CalculateTurnHeadings()
        {
            //to calc heading based on next and previous points to give an average heading.
            int cnt = mf.curve.desList.Count;
            if (cnt > 0)
            {
                vec3[] arr = new vec3[cnt];
                cnt--;
                mf.curve.desList.CopyTo(arr);
                mf.curve.desList.Clear();

                //middle points
                for (int i = 1; i < cnt; i++)
                {
                    vec3 pt3 = arr[i];
                    pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
                    if (pt3.heading < 0) pt3.heading += glm.twoPI;
                    mf.curve.desList.Add(pt3);
                }
            }
        }

        private void A_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                mf.curve.curveArr[Convert.ToInt32(b.Name)].isVisible = !mf.curve.curveArr[Convert.ToInt32(b.Name)].isVisible;
                selectedItem = -1;
                UpdateTable();
            }
        }

        private void LineSelected_Click(object sender, EventArgs e)
        {
            if (sender is TextBox t)
            {
                if (selectedItem == Convert.ToInt32(t.Name))
                    selectedItem = -1;
                else
                    selectedItem = Convert.ToInt32(t.Name);

                UpdateTable();
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (selectedItem == -1 || selectedItem == 0) 
                return;

            mf.curve.curveArr.Reverse(selectedItem - 1, 2);
            selectedItem--;
            UpdateTable();
        }

        private void btnMoveDn_Click(object sender, EventArgs e)
        {
            if (selectedItem == -1 || selectedItem == (mf.curve.curveArr.Count-1))
                return;

            mf.curve.curveArr.Reverse(selectedItem, 2);
            selectedItem++;
            UpdateTable();
        }

        private void btnNewCurve_Click(object sender, EventArgs e)
        {
            panelPick.Visible = false;
            panelAPlus.Visible = true;
            panelName.Visible = false;

            btnAPoint.Enabled = true;
            btnBPoint.Enabled = false;
            btnPausePlay.Enabled = false;
            mf.curve.desList?.Clear();

            this.Size = new System.Drawing.Size(270, 360);
        }

        private void btnAPoint_Click(object sender, System.EventArgs e)
        {
            //mf.curve.moveDistance = 0;
            //clear out the reference list
            lblCurveExists.Text = gStr.gsDriving;
            btnBPoint.Enabled = true;
            //mf.curve.ResetCurveLine();

            btnAPoint.Enabled = false;
            mf.curve.isOkToAddDesPoints = true;
            btnPausePlay.Enabled = true;
            btnPausePlay.Visible = true;
        }

        private void btnBPoint_Click(object sender, System.EventArgs e)
        {
            aveLineHeading = 0;
            mf.curve.isOkToAddDesPoints = false;
            panelAPlus.Visible = false;
            panelName.Visible = true;

            int cnt = mf.curve.desList.Count;
            if (cnt > 3)
            {
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

                //calculate average heading of line
                double x = 0, y = 0;
                foreach (vec3 pt in mf.curve.desList)
                {
                    x += Math.Cos(pt.heading);
                    y += Math.Sin(pt.heading);
                }
                x /= mf.curve.desList.Count;
                y /= mf.curve.desList.Count;
                aveLineHeading = Math.Atan2(y, x);
                if (aveLineHeading < 0) aveLineHeading += glm.twoPI;

                //build the tail extensions
                mf.curve.AddFirstLastPoints(ref mf.curve.desList);
                SmoothAB(4);
                CalculateTurnHeadings();

                panelAPlus.Visible = false;
                panelName.Visible = true;

                mf.curve.desName = "Cu " +
                    (Math.Round(glm.toDegrees(aveLineHeading), 1)).ToString(CultureInfo.InvariantCulture) +
                    "\u00B0 " + mf.FindDirection(aveLineHeading);

                textBox1.Text = mf.curve.desName;
            }
            else
            {
                mf.curve.isOkToAddDesPoints = false;
                mf.curve.desList?.Clear();

                panelPick.Visible = true;
                panelAPlus.Visible = false;
                panelName.Visible = false;

                this.Size = new System.Drawing.Size(620,475);
            }
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            textBox1.Text += DateTime.Now.ToString(" hh:mm:ss", CultureInfo.InvariantCulture);
            mf.curve.desName = textBox1.Text;
        }

        private void btnPausePlay_Click(object sender, EventArgs e)
        {
            if (mf.curve.isOkToAddDesPoints)
            {
                mf.curve.isOkToAddDesPoints = false;
                btnPausePlay.Image = Properties.Resources.BoundaryRecord;
                //btnPausePlay.Text = gStr.gsRecord;
                btnBPoint.Enabled = false;
            }
            else
            {
                mf.curve.isOkToAddDesPoints = true;
                btnPausePlay.Image = Properties.Resources.boundaryPause;
                //btnPausePlay.Text = gStr.gsPause;
                btnBPoint.Enabled = true;
            }
        }

        private void btnCancelMain_Click(object sender, EventArgs e)
        {
            isClosing = true;
            mf.curve.isCurveValid = false;
            mf.curve.moveDistance = 0;
            mf.curve.isOkToAddDesPoints = false;
            mf.curve.isCurveSet = false;
            mf.curve.refList?.Clear();
            mf.curve.isCurveSet = false;
            mf.DisableYouTurnButtons();
            //mf.btnContourPriority.Enabled = false;
            //mf.curve.ResetCurveLine();
            mf.curve.isBtnCurveOn = false;
            mf.btnCurve.Image = Properties.Resources.CurveOff;
            if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
            if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();

            mf.curve.numCurveLineSelected = 0;
            Close();
        }

        private void btnCancelCurve_Click(object sender, EventArgs e)
        {
            mf.curve.isOkToAddDesPoints = false;
            mf.curve.desList?.Clear();

            panelPick.Visible = true;
            panelAPlus.Visible = false;
            panelEditName.Visible = false;
            panelName.Visible = false;

            this.Size = new System.Drawing.Size(620,475);
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
                mf.KeyboardToText((TextBox)sender, this);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (mf.curve.desList.Count > 0)
            {
                if (textBox1.Text.Length == 0) textBox2.Text = "No Name " + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);

                mf.curve.curveArr.Add(new CCurveLines());

                //array number is 1 less since it starts at zero
                int idx = mf.curve.curveArr.Count - 1;

                mf.curve.curveArr[idx].Name = textBox1.Text.Trim();
                mf.curve.curveArr[idx].aveHeading = aveLineHeading;

                //write out the Curve Points
                foreach (vec3 item in mf.curve.desList)
                {
                    mf.curve.curveArr[idx].curvePts.Add(item);
                }

                mf.FileSaveCurveLines();
                mf.curve.desList?.Clear();
            }

            panelPick.Visible = true;
            panelAPlus.Visible = false;
            panelName.Visible = false;

            this.Size = new System.Drawing.Size(620,475);

            mf.curve.desList?.Clear();
            UpdateTable();
        }

        private void btnLoadFromKML_Click(object sender, EventArgs e)
        {
            panelPick.Visible = false;
            panelAPlus.Visible = false;
            panelName.Visible = false;
            panelKML.Visible = true;

            this.Size = new System.Drawing.Size(270, 360);

            string fileAndDirectory;

            //create the dialog instance
            OpenFileDialog ofd = new OpenFileDialog
            {
                //set the filter to text KML only
                Filter = "KML files (*.KML)|*.KML",

                //the initial directory, fields, for the open dialog
                InitialDirectory = mf.fieldsDirectory + mf.currentFieldDirectory
            };

            //was a file selected
            if (ofd.ShowDialog(this) == DialogResult.Cancel)
            {
                mf.curve.isOkToAddDesPoints = false;
                mf.curve.desList?.Clear();

                panelPick.Visible = true;
                panelAPlus.Visible = false;
                panelEditName.Visible = false;
                panelName.Visible = false;
                panelKML.Visible = false;

                this.Size = new System.Drawing.Size(620, 475);

                return;
            }
            else fileAndDirectory = ofd.FileName;
            {
                double lonK = 0;
                double latK = 0;
                double easting = 0;
                double norting = 0;
                string shortName = "";

                mf.curve.desList?.Clear();

                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = true;

                try
                {
                    doc.Load(fileAndDirectory);
                    shortName = Path.GetFileName(fileAndDirectory);
                    shortName = shortName.Substring(0, shortName.Length - 4);

                    XmlElement root = doc.DocumentElement;
                    XmlNodeList elemList = root.GetElementsByTagName("coordinates");
                    XmlNodeList namelist = root.GetElementsByTagName("name");

                    if (namelist.Count > 0)
                    {
                        shortName = namelist[0].InnerText;
                    }

                    for (int i = 0; i < elemList.Count; i++)
                    {
                        int g = namelist.Count - elemList.Count;

                        string line = elemList[i].InnerText;
                        line.Trim();
                        //line = coordinates;
                        char[] delimiterChars = { ' ', '\t', '\r', '\n' };
                        string[] numberSets = line.Split(delimiterChars);

                        //at least 3 points
                        if (numberSets.Length > 1)
                        {

                            foreach (string item in numberSets)
                            {
                                string[] fix = item.Split(',');
                                if (fix.Length != 3) continue;
                                double.TryParse(fix[0], NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);
                                double.TryParse(fix[1], NumberStyles.Float, CultureInfo.InvariantCulture, out latK);

                                mf.pn.ConvertWGS84ToLocal(latK, lonK, out norting, out easting);

                                vec3 bndPt = new vec3(easting, norting, 0);
                                mf.curve.desList.Add(bndPt);
                            }
                        }
                    }

                    int cnt = mf.curve.desList.Count;
                    if (cnt > 1)
                    {
                        //make sure distance isn't too big between points on Turn
                        for (int i = 0; i < cnt - 1; i++)
                        {
                            int j = i + 1;
                            //if (j == cnt) j = 0;
                            double distance = glm.Distance(mf.curve.desList[i], mf.curve.desList[j]);
                            if (distance > 1.6)
                            {
                                vec3 pointB = new vec3(
                                    (mf.curve.desList[i].easting + mf.curve.desList[j].easting) / 2.0,
                                    (mf.curve.desList[i].northing + mf.curve.desList[j].northing) / 2.0,
                                    mf.curve.desList[i].heading
                                    );

                                mf.curve.desList.Insert(j, pointB);
                                cnt = mf.curve.desList.Count;
                                i = -1;
                            }
                        }

                        CalculateTurnHeadings();

                        //build the tail extensions
                        mf.curve.AddFirstLastPoints(ref mf.curve.desList);
                        SmoothAB(4);
                        CalculateTurnHeadings();

                        panelKML.Visible = false;
                        panelName.Visible = true;

                        textBox1.Text = shortName;
                        UpdateTable();
                        flp.Focus();
                    }
                }
                catch (System.IO.FileNotFoundException)
                {

                    Console.WriteLine("Bad or Missing Curve-KML file");
                }
            }
        }

        private void btnListDelete_Click(object sender, EventArgs e)
        {
            mf.curve.moveDistance = 0;

            if (selectedItem > -1)
            {
                mf.curve.curveArr.RemoveAt(selectedItem);

                //everything changed, so make sure its right
                mf.curve.numCurveLines = mf.curve.curveArr.Count;
                if (mf.curve.numCurveLineSelected > mf.curve.numCurveLines) mf.curve.numCurveLineSelected = mf.curve.numCurveLines;

                //if there are no saved ones, empty out current curve line and turn off
                if (mf.curve.numCurveLines == 0)
                {
                    mf.curve.ResetCurveLine();
                    if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
                    if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();
                }
                else
                {
                    selectedItem = -1;
                    mf.curve.numCurveLineSelected = 1;


                    mf.curve.aveLineHeading = mf.curve.curveArr[0].aveHeading;
                    mf.curve.refList?.Clear();
                    for (int i = 0; i < mf.curve.curveArr[0].curvePts.Count; i++)
                    {
                        mf.curve.refList.Add(mf.curve.curveArr[0].curvePts[i]);
                    }
                    mf.curve.isCurveSet = true;
                    mf.yt.ResetYouTurn();
                }

                mf.FileSaveCurveLines();
            }

            selectedItem = -1;

            UpdateTable();
            flp.Focus();
        }

        private void btnListUse_Click(object sender, EventArgs e)
        {
            isClosing = true;
            //reset to generate new reference
            mf.curve.isCurveValid = false;
            mf.curve.moveDistance = 0;

            mf.FileSaveCurveLines();

            if (selectedItem > -1)
            {

                int idx = selectedItem;
                mf.curve.numCurveLineSelected = idx + 1;


                mf.curve.aveLineHeading = mf.curve.curveArr[idx].aveHeading;
                mf.curve.refList?.Clear();
                for (int i = 0; i < mf.curve.curveArr[idx].curvePts.Count; i++)
                {
                    mf.curve.refList.Add(mf.curve.curveArr[idx].curvePts[i]);
                }
                mf.curve.isCurveSet = true;
                mf.yt.ResetYouTurn();

                Close();
            }
            else
            {
                //mf.curve.moveDistance = 0;
                //mf.curve.isOkToAddDesPoints = false;
                //mf.curve.isCurveSet = false;
                //mf.curve.refList?.Clear();
                //mf.curve.isCurveSet = false;
                //mf.DisableYouTurnButtons();
                //mf.curve.isBtnCurveOn = false;
                //mf.btnCurve.Image = Properties.Resources.CurveOff;
                //if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
                //if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();

                //mf.curve.numCurveLineSelected = 0;
                Close();
            }
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if (selectedItem > -1)
            {
                int idx = selectedItem;


                panelPick.Visible = false;
                panelName.Visible = true;
                this.Size = new System.Drawing.Size(270, 360);

                panelAPlus.Visible = false;
                panelName.Visible = true;

                textBox1.Text = mf.curve.curveArr[idx].Name + " Copy";
                mf.curve.desName = textBox1.Text;

                aveLineHeading = mf.curve.curveArr[idx].aveHeading;
                mf.curve.desList?.Clear();

                for (int i = 0; i < mf.curve.curveArr[idx].curvePts.Count; i++)
                {
                    vec3 pt = new vec3(mf.curve.curveArr[idx].curvePts[i]);
                    mf.curve.desList.Add(pt);
                }
            }
        }

        private void btnEditName_Click(object sender, EventArgs e)
        {
            if (selectedItem > -1)
            {

                int idx = selectedItem;

                textBox2.Text = mf.curve.curveArr[idx].Name;

                panelPick.Visible = false;
                panelEditName.Visible = true;
                this.Size = new System.Drawing.Size(270, 360);
            }
        }

        private void btnAddTimeEdit_Click(object sender, EventArgs e)
        {
            textBox2.Text += DateTime.Now.ToString(" hh:mm:ss", CultureInfo.InvariantCulture);
        }

        private void btnSaveEditName_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "") textBox2.Text = "No Name " + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);

            int idx = selectedItem;

            panelEditName.Visible = false;
            panelPick.Visible = true;

            mf.FileSaveCurveLines();
            mf.curve.desList?.Clear();

            this.Size = new System.Drawing.Size(700, 450);

            UpdateTable();
            flp.Focus();
        }

        private void btnSwapAB_Click(object sender, EventArgs e)
        {
            if (selectedItem > -1)
            {

                int idx = selectedItem;
                mf.curve.numCurveLineSelected = idx + 1;

                int cnt = mf.curve.curveArr[idx].curvePts.Count;
                if (cnt > 0)
                {
                    mf.curve.curveArr[idx].curvePts.Reverse();

                    vec3[] arr = new vec3[cnt];
                    cnt--;
                    mf.curve.curveArr[idx].curvePts.CopyTo(arr);
                    mf.curve.curveArr[idx].curvePts.Clear();

                    mf.curve.curveArr[idx].aveHeading += Math.PI;
                    if (mf.curve.curveArr[idx].aveHeading < 0) mf.curve.curveArr[idx].aveHeading += glm.twoPI;
                    if (mf.curve.curveArr[idx].aveHeading > glm.twoPI) mf.curve.curveArr[idx].aveHeading -= glm.twoPI;

                    for (int i = 1; i < cnt; i++)
                    {
                        vec3 pt3 = arr[i];
                        pt3.heading += Math.PI;
                        if (pt3.heading > glm.twoPI) pt3.heading -= glm.twoPI;
                        if (pt3.heading < 0) pt3.heading += glm.twoPI;
                        mf.curve.curveArr[idx].curvePts.Add(pt3);
                    }
                }

                mf.FileSaveCurveLines();
                UpdateTable();
                flp.Focus();

                mf.TimedMessageBox(1500, "A B Swapped", "Curve is Reversed");
            }
        }

        private void FormABCurve_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                e.Cancel = true;
                return;
            }
        }

        #region Help

        private void btnListDelete_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnListDelete, gStr.gsHelp);
        }

        private void btnCancelMain_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnCancel, gStr.gsHelp);
        }

        private void btnNewCurve_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnNewABLine, gStr.gsHelp);
        }

        private void btnListUse_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnListUse, gStr.gsHelp);
        }

        private void btnSwapAB_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ht_btnSwapAB, gStr.gsHelp);
        }

        private void btnEditName_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hd_tboxNameLine, gStr.gsHelp);
        }

        private void btnDuplicate_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnDuplicate, gStr.gsHelp);
        }

        private void btnAddTime_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnAddTime, gStr.gsHelp);
        }

        private void btnAddTimeEdit_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnAddTime, gStr.gsHelp);
        }

        private void btnCancel_Name_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnCancelCreate, gStr.gsHelp);
        }

        private void btnCancelCurve_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnCancelCreate, gStr.gsHelp);
        }

        private void btnCancelEditName_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnCancelCreate, gStr.gsHelp);
        }

        private void btnAdd_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnEnterContinue, gStr.gsHelp);
        }

        private void btnSaveEditName_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnEnterContinue, gStr.gsHelp);
        }

        private void btnAPoint_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hcur_btnAPoint, gStr.gsHelp);
        }

        private void btnBPoint_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hcur_btnBPoint, gStr.gsHelp);
        }

        private void btnPausePlay_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hcur_btnPausePlay, gStr.gsHelp);
        }

        private void textBox1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_textBox1, gStr.gsHelp);
        }

        private void textBox2_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_textBox1, gStr.gsHelp);
        }

        #endregion
    }
}