using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AgOpenGPS
{
    public partial class FormBuildTracks : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf;

        private double aveLineHeading;
        private int originalLine = 0;
        private bool isClosing;
        private int selectedItem = -1;

        private bool isOn = true;

        public FormBuildTracks(Form _mf)
        {
            mf = _mf as FormGPS;
            InitializeComponent();

            //btnPausePlay.Text = gStr.gsPause;
            this.Text = gStr.gsABCurve;
        }

        private void FormBuildTracks_Load(object sender, EventArgs e)
        {
            panelMain.Top = 3; panelMain.Left = 3;
            panelCurve.Top = 3; panelCurve.Left = 3;
            panelName.Top = 3; panelName.Left = 3;
            panelKML.Top = 3; panelKML.Left = 3;
            panelEditName.Top = 3; panelEditName.Left = 3;
            panelChoose.Top = 3; panelChoose.Left = 3;
            panelABLine.Top = 3; panelABLine.Left = 3;
            panelAPlus.Top = 3; panelAPlus.Left = 3;

            panelEditName.Visible = false;
            panelMain.Visible = true;
            panelCurve.Visible = false;
            panelName.Visible = false;
            panelKML.Visible = false;
            panelChoose.Visible = false;
            panelABLine.Visible = false;
            panelAPlus.Visible = false;

            this.Size = new System.Drawing.Size(620, 475);

            originalLine = mf.trk.idx;

            mf.curve.isMakingCurve = false;
            selectedItem = -1;
            Location = Properties.Settings.Default.setWindow_abCurveCreate;

            UpdateTable();
        }

        private void FormBuildTracks_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                e.Cancel = true;
                return;
            }

            Properties.Settings.Default.setWindow_abCurveCreate = Location;
        }

        #region Main Controls
        private void UpdateTable()
        {
            Font backupfont = new Font(Font.FontFamily, 18F, FontStyle.Regular);
            flp.Controls.Clear();

            for (int i = 0; i < mf.trk.gArr.Count; i++)
            {
                //outer inner
                Button a = new Button
                {
                    Margin = new Padding(6, 10, 10, 10),
                    Size = new Size(50, 25),
                    Name = i.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    //ForeColor = System.Drawing.SystemColors.ButtonFace
                };
                a.Click += A_Click;

                if (mf.trk.gArr[i].isVisible)
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
                    Text = mf.trk.gArr[i].name,
                    Name = i.ToString(),
                };
                t.Font = backupfont;
                t.Click += LineSelected_Click;

                if (mf.trk.gArr[i].isVisible)
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

        private void A_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                mf.trk.gArr[Convert.ToInt32(b.Name)].isVisible = !mf.trk.gArr[Convert.ToInt32(b.Name)].isVisible;
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

            mf.trk.gArr.Reverse(selectedItem - 1, 2);
            selectedItem--;
            UpdateTable();
        }

        private void btnMoveDn_Click(object sender, EventArgs e)
        {
            if (selectedItem == -1 || selectedItem == (mf.trk.gArr.Count - 1))
                return;

            mf.trk.gArr.Reverse(selectedItem, 2);
            selectedItem++;
            UpdateTable();
        }

        private void btnSwapAB_Click(object sender, EventArgs e)
        {
            if (selectedItem > -1)
            {
                mf.trk.idx = selectedItem;

                int cnt = mf.trk.gArr[mf.trk.idx].curvePts.Count;
                if (cnt > 0)
                {
                    mf.trk.gArr[mf.trk.idx].curvePts.Reverse();

                    vec3[] arr = new vec3[cnt];
                    cnt--;
                    mf.trk.gArr[mf.trk.idx].curvePts.CopyTo(arr);
                    mf.trk.gArr[mf.trk.idx].curvePts.Clear();

                    mf.trk.gArr[mf.trk.idx].heading += Math.PI;
                    if (mf.trk.gArr[mf.trk.idx].heading < 0) mf.trk.gArr[mf.trk.idx].heading += glm.twoPI;
                    if (mf.trk.gArr[mf.trk.idx].heading > glm.twoPI) mf.trk.gArr[mf.trk.idx].heading -= glm.twoPI;

                    for (int i = 1; i < cnt; i++)
                    {
                        vec3 pt3 = arr[i];
                        pt3.heading += Math.PI;
                        if (pt3.heading > glm.twoPI) pt3.heading -= glm.twoPI;
                        if (pt3.heading < 0) pt3.heading += glm.twoPI;
                        mf.trk.gArr[mf.trk.idx].curvePts.Add(pt3);
                    }
                }

                UpdateTable();
                flp.Focus();

                mf.TimedMessageBox(1500, "A B Swapped", "Curve is Reversed");
            }
        }

        private void btnHideShow_Click(object sender, EventArgs e)
        {
                for (int i = 0; i < mf.trk.gArr.Count; i++)
                {
                    mf.trk.gArr[i].isVisible = isOn;
                }

                isOn = !isOn;

                UpdateTable();
        }

        private void btnNewTrack_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = false;
            panelMain.Visible = false;
            panelCurve.Visible = false;
            panelName.Visible = false;
            panelABLine.Visible = false;
            panelAPlus.Visible = false;
            panelKML.Visible = false;

            mf.curve.desList?.Clear();
            panelChoose.Visible = true;
        }

        private void btnListDelete_Click(object sender, EventArgs e)
        {
            if (selectedItem > -1)
            {
                mf.trk.gArr.RemoveAt(selectedItem);
                selectedItem = -1;
            }

            selectedItem = mf.trk.idx = -1;

            UpdateTable();
            flp.Focus();
        }

        private void btnListUse_Click(object sender, EventArgs e)
        {
            isClosing = true;
            //reset to generate new reference
            mf.curve.isCurveValid = false;
            mf.curve.desList?.Clear();

            mf.FileSaveTracks();

            if (selectedItem > -1)
            {
                mf.trk.idx = selectedItem;
                mf.yt.ResetYouTurn();

                Close();
            }
            else if (mf.trk.gArr.Count > 0)
            {
                mf.trk.idx = mf.trk.gArr.Count - 1;
                mf.yt.ResetYouTurn();

                Close();
            }
            else
            {
                mf.trk.idx = -1;
                mf.DisableYouTurnButtons();
                mf.curve.isBtnTrackOn = false;
                mf.btnTrack.Image = Properties.Resources.TrackOff;
                if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
                if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();

                //mf.curve.numCurveLineSelected = 0;
                Close();
            }
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if (selectedItem > -1)
            {
                int idx = selectedItem;

                panelMain.Visible = false;
                panelName.Visible = true;
                this.Size = new System.Drawing.Size(270, 360);

                panelCurve.Visible = false;
                panelName.Visible = true;

                textBox1.Text = mf.trk.gArr[idx].name + " Copy";
                mf.curve.desName = textBox1.Text;

                aveLineHeading = mf.trk.gArr[idx].heading;
                mf.curve.desList?.Clear();

                for (int i = 0; i < mf.trk.gArr[idx].curvePts.Count; i++)
                {
                    vec3 pt = new vec3(mf.trk.gArr[idx].curvePts[i]);
                    mf.curve.desList.Add(pt);
                }
            }
        }

        private void btnEditName_Click(object sender, EventArgs e)
        {
            if (selectedItem > -1)
            {
                int idx = selectedItem;

                textBox2.Text = mf.trk.gArr[idx].name;

                panelMain.Visible = false;
                panelEditName.Visible = true;
                this.Size = new System.Drawing.Size(270, 360);
            }
        }

        #endregion

        #region Pick
        private void btnzABCurve_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = false;
            panelCurve.Visible = true;

            btnACurve.Enabled = true;
            btnBCurve.Enabled = false;
            btnPausePlay.Enabled = false;
            mf.curve.desList?.Clear();

            this.Size = new System.Drawing.Size(270, 360);
        }

        private void btnzAPlus_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = false;
            panelAPlus.Visible = true;

            btnAPlus.Enabled = true;
            mf.curve.desList?.Clear();
            nudHeading.Enabled = false;

            this.Size = new System.Drawing.Size(270, 360);
        }

        private void btnzABLine_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = false;
            panelABLine.Visible = true;

            btnALine.Enabled = true;
            btnBLine.Enabled = false;
            btnPausePlay.Enabled = false;
            mf.curve.desList?.Clear();

            this.Size = new System.Drawing.Size(270, 360);
        }

        #endregion

        #region Curve
        private void btnACurve_Click(object sender, System.EventArgs e)
        {
            lblCurveExists.Text = gStr.gsDriving;

            btnBCurve.Enabled = true;
            btnACurve.Enabled = false;

            btnPausePlay.Enabled = true;
            btnPausePlay.Visible = true;

            mf.curve.isMakingCurve = true;
        }

        private void btnBCurve_Click(object sender, System.EventArgs e)
        {
            aveLineHeading = 0;
            mf.curve.isMakingCurve = false;
            panelCurve.Visible = false;
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

                mf.trk.gArr.Add(new CTrk());
                //array number is 1 less since it starts at zero
                mf.trk.idx = mf.trk.gArr.Count - 1;

                mf.trk.gArr[mf.trk.idx].ptA =
                    new vec2(mf.curve.desList[0].easting, mf.curve.desList[0].northing);
                mf.trk.gArr[mf.trk.idx].ptB =
                    new vec2(mf.curve.desList[mf.curve.desList.Count - 1].easting,
                    mf.curve.desList[mf.curve.desList.Count - 1].northing);

                mf.trk.gArr[mf.trk.idx].mode = (int)TrackMode.Curve;

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

                mf.trk.gArr[mf.trk.idx].heading = aveLineHeading;

                //build the tail extensions
                mf.curve.AddFirstLastPoints(ref mf.curve.desList);
                SmoothAB(4);
                CalculateTurnHeadings();

                //write out the Curve Points
                foreach (vec3 item in mf.curve.desList)
                {
                    mf.trk.gArr[mf.trk.idx].curvePts.Add(item);
                }

                mf.curve.desName = "Cu-" +
                    (Math.Round(glm.toDegrees(aveLineHeading), 1)).ToString(CultureInfo.InvariantCulture) + "\u00B0 " ;

                textBox1.Text = mf.curve.desName;

                panelCurve.Visible = false;
                panelName.Visible = true;
            }
            else
            {
                mf.curve.isMakingCurve = false;
                mf.curve.desList?.Clear();

                panelMain.Visible = false;
                panelCurve.Visible = false;
                panelName.Visible = true;
                panelChoose.Visible= false;

                this.Size = new System.Drawing.Size(620, 475);
            }
        }

        private void btnPausePlayCurve_Click(object sender, EventArgs e)
        {
            if (mf.curve.isMakingCurve)
            {
                mf.curve.isMakingCurve = false;
                btnPausePlay.Image = Properties.Resources.BoundaryRecord;
                //btnPausePlay.Text = gStr.gsRecord;
                btnBCurve.Enabled = false;
            }
            else
            {
                mf.curve.isMakingCurve = true;
                btnPausePlay.Image = Properties.Resources.boundaryPause;
                //btnPausePlay.Text = gStr.gsPause;
                btnBCurve.Enabled = true;
            }
        }

        #endregion

        #region AB Line

        private void btnALine_Click(object sender, EventArgs e)
        {
            mf.ABLine.isMakingABLine = true;
            btnALine.Enabled = false;

            mf.ABLine.desPtA = new vec2(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing);

            mf.ABLine.desLineEndA.easting = mf.ABLine.desPtA.easting - (Math.Sin(mf.pivotAxlePos.heading) * 1000);
            mf.ABLine.desLineEndA.northing = mf.ABLine.desPtA.northing - (Math.Cos(mf.pivotAxlePos.heading) * 1000);


            mf.ABLine.desLineEndB.easting = mf.ABLine.desPtA.easting + (Math.Sin(mf.pivotAxlePos.heading) * 1000);
            mf.ABLine.desLineEndB.northing = mf.ABLine.desPtA.northing + (Math.Cos(mf.pivotAxlePos.heading) * 1000);

            btnBLine.Enabled = true;
            btnALine.Enabled = false;

            btnEnter_AB.Enabled = true;
        }

        private void btnBLine_Click(object sender, EventArgs e)
        {
            mf.ABLine.desPtB = new vec2(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing);

            btnBLine.BackColor = System.Drawing.Color.Teal;

            mf.ABLine.desHeading = Math.Atan2(mf.ABLine.desPtB.easting - mf.ABLine.desPtA.easting,
               mf.ABLine.desPtB.northing - mf.ABLine.desPtA.northing);
            if (mf.ABLine.desHeading < 0) mf.ABLine.desHeading += glm.twoPI;

            mf.ABLine.desLineEndA.easting = mf.ABLine.desPtA.easting - (Math.Sin(mf.ABLine.desHeading) * 1000);
            mf.ABLine.desLineEndA.northing = mf.ABLine.desPtA.northing - (Math.Cos(mf.ABLine.desHeading) * 1000);

            mf.ABLine.desLineEndB.easting = mf.ABLine.desPtA.easting + (Math.Sin(mf.ABLine.desHeading) * 1000);
            mf.ABLine.desLineEndB.northing = mf.ABLine.desPtA.northing + (Math.Cos(mf.ABLine.desHeading) * 1000);
        }

        private void btnEnter_AB_Click(object sender, EventArgs e)
        {
            mf.ABLine.isMakingABLine = false;
            mf.trk.gArr.Add(new CTrk());

            mf.trk.idx = mf.trk.gArr.Count - 1;

            mf.trk.gArr[mf.trk.idx].ptA = new vec2(mf.ABLine.desPtA);
            mf.trk.gArr[mf.trk.idx].ptB = new vec2(mf.ABLine.desPtB);

            mf.trk.gArr[mf.trk.idx].mode = (int)TrackMode.AB;

            mf.trk.gArr[mf.trk.idx].heading = mf.ABLine.desHeading;

            mf.ABLine.desName = "AB-" +
                (Math.Round(glm.toDegrees(mf.ABLine.desHeading), 1)).ToString(CultureInfo.InvariantCulture) + "\u00B0 " ;
            textBox1.Text = mf.ABLine.desName;

            panelABLine.Visible = false;
            panelName.Visible = true;

        }

        #endregion

        #region A Plus
        private void btnAPlus_Click(object sender, EventArgs e)
        {
            mf.ABLine.isMakingABLine = true;

            mf.ABLine.desPtA = new vec2(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing);

            mf.ABLine.desPtB.easting = mf.ABLine.desPtA.easting + (Math.Sin(mf.pivotAxlePos.heading) * 200);
            mf.ABLine.desPtB.northing = mf.ABLine.desPtA.northing + (Math.Cos(mf.pivotAxlePos.heading) * 200);

            mf.ABLine.desLineEndA.easting = mf.ABLine.desPtA.easting - (Math.Sin(mf.pivotAxlePos.heading) * 1000);
            mf.ABLine.desLineEndA.northing = mf.ABLine.desPtA.northing - (Math.Cos(mf.pivotAxlePos.heading) * 1000);

            mf.ABLine.desLineEndB.easting = mf.ABLine.desPtA.easting + (Math.Sin(mf.pivotAxlePos.heading) * 1000);
            mf.ABLine.desLineEndB.northing = mf.ABLine.desPtA.northing + (Math.Cos(mf.pivotAxlePos.heading) * 1000);

            mf.ABLine.desHeading = mf.pivotAxlePos.heading;

            btnEnter_AB.Enabled = true;
            nudHeading.Enabled = true;

            nudHeading.Value = (decimal)(glm.toDegrees(mf.ABLine.desHeading));
        }

        private void nudHeading_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                //original A pt. 
                mf.ABLine.desHeading = glm.toRadians((double)nudHeading.Value);

                //start end of line
                mf.ABLine.desPtB.easting = mf.ABLine.desPtA.easting + (Math.Sin(mf.ABLine.desHeading) * 200);
                mf.ABLine.desPtB.northing = mf.ABLine.desPtA.northing + (Math.Cos(mf.ABLine.desHeading) * 200);

                mf.ABLine.desLineEndA.easting = mf.ABLine.desPtA.easting - (Math.Sin(mf.ABLine.desHeading) * 1000);
                mf.ABLine.desLineEndA.northing = mf.ABLine.desPtA.northing - (Math.Cos(mf.ABLine.desHeading) * 1000);

                mf.ABLine.desLineEndB.easting = mf.ABLine.desPtA.easting + (Math.Sin(mf.ABLine.desHeading) * 1000);
                mf.ABLine.desLineEndB.northing = mf.ABLine.desPtA.northing + (Math.Cos(mf.ABLine.desHeading) * 1000);
            }
        }

        private void btnEnter_APlus_Click(object sender, EventArgs e)
        {
            mf.ABLine.isMakingABLine = false;
            mf.trk.gArr.Add(new CTrk());

            mf.trk.idx = mf.trk.gArr.Count - 1;

            mf.trk.gArr[mf.trk.idx].ptA = new vec2(mf.ABLine.desPtA);
            mf.trk.gArr[mf.trk.idx].ptB = new vec2(mf.ABLine.desPtB);

            mf.trk.gArr[mf.trk.idx].mode = (int)TrackMode.AB;

            mf.trk.gArr[mf.trk.idx].heading = mf.ABLine.desHeading;

            mf.ABLine.desName = "A+" +
                (Math.Round(glm.toDegrees(mf.ABLine.desHeading), 1)).ToString(CultureInfo.InvariantCulture) + "\u00B0 " ;
            textBox1.Text = mf.ABLine.desName;

            panelAPlus.Visible = false;
            panelName.Visible = true;
        }



        #endregion

        #region KML Curve
        private void btnLoadCurveFromKML_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = false;
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
                mf.curve.isMakingCurve = false;
                mf.ABLine.isMakingABLine = false;
                mf.curve.desList?.Clear();

                panelMain.Visible = true;
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


                        mf.trk.gArr.Add(new CTrk());
                        //array number is 1 less since it starts at zero
                        mf.trk.idx = mf.trk.gArr.Count - 1;

                        mf.trk.gArr[mf.trk.idx].ptA =
                            new vec2(mf.curve.desList[0].easting, mf.curve.desList[0].northing);
                        mf.trk.gArr[mf.trk.idx].ptB =
                            new vec2(mf.curve.desList[mf.curve.desList.Count - 1].easting,
                            mf.curve.desList[mf.curve.desList.Count - 1].northing);

                        mf.trk.gArr[mf.trk.idx].mode = (int)TrackMode.Curve;

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

                        mf.trk.gArr[mf.trk.idx].heading = aveLineHeading;

                        //build the tail extensions
                        mf.curve.AddFirstLastPoints(ref mf.curve.desList);
                        SmoothAB(4);
                        CalculateTurnHeadings();

                        //write out the Curve Points
                        foreach (vec3 item in mf.curve.desList)
                        {
                            mf.trk.gArr[mf.trk.idx].curvePts.Add(item);
                        }

                        mf.curve.desName = "Cu-" +
                            (Math.Round(glm.toDegrees(aveLineHeading), 1)).ToString(CultureInfo.InvariantCulture) + "\u00B0 " ;

                        textBox1.Text = mf.curve.desName;

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

        #endregion


        private void btnAddTime_Click(object sender, EventArgs e)
        {
            textBox1.Text += DateTime.Now.ToString(" hh:mm:ss", CultureInfo.InvariantCulture);
            mf.curve.desName = textBox1.Text;
        }

        private void btnCancelCurve_Click(object sender, EventArgs e)
        {
            mf.curve.isMakingCurve = false;
            mf.curve.desList?.Clear();

            panelMain.Visible = true;
            panelCurve.Visible = false;
            panelEditName.Visible = false;
            panelName.Visible = false;
            panelChoose.Visible = false;

            this.Size = new System.Drawing.Size(620, 475);
        }

        private void btnCancelMain_Click(object sender, EventArgs e)
        {
            isClosing = true;
            mf.curve.isCurveValid = false;
            mf.curve.isMakingCurve = false;
            mf.curve.desList?.Clear();
            mf.DisableYouTurnButtons();
            //mf.btnContourPriority.Enabled = false;
            mf.curve.isBtnTrackOn = false;
            mf.btnTrack.Image = Properties.Resources.TrackOff;
            if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
            if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();

            mf.trk.idx = -1;
            Close();
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
                mf.KeyboardToText((TextBox)sender, this);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) textBox2.Text = "No Name " + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);

            int idx = mf.trk.gArr.Count - 1;

            mf.trk.gArr[idx].name = textBox1.Text.Trim();

            panelMain.Visible = true;
            panelName.Visible = false;

            this.Size = new System.Drawing.Size(620, 475);

            mf.curve.desList?.Clear();
            UpdateTable();
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
            panelMain.Visible = true;

            mf.curve.desList?.Clear();

            this.Size = new System.Drawing.Size(700, 450);

            UpdateTable();
            flp.Focus();
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


        #endregion Help

    }
}