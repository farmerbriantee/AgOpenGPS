using OpenTK.Graphics.ES30;
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
        private bool isClosing;
        private int selectedItem = -1;
        private int originalLine = -1;

        private vec3 ptA;
        private vec3 ptB;
        private double aveLineHeading;
        private bool isOn = true;

        #region Track Form
        public FormABCurve(Form _mf)
        {
            mf = _mf as FormGPS;
            InitializeComponent();

            //btnPausePlay.Text = gStr.gsPause;
            this.Text = gStr.gsTracks;
        }

        private void FormABCurve_Load(object sender, EventArgs e)
        {
            panelPick.Top = 3;
            panelPick.Left = 3;
            panelChoose.Top = 3;
            panelChoose.Left = 3;
            panelABLine.Top = 3;
            panelABLine.Left = 3;

            panelABCurve.Top = 3;
            panelABCurve.Left = 3;
            panelAddName.Top = 3;
            panelAddName.Left = 3;

            panelEditName.Top = 3;
            panelEditName.Left = 3;

            panelEditName.Visible = false;
            panelChoose.Visible = false; ;
            panelPick.Visible = true;
            panelABCurve.Visible = false;
            panelAddName.Visible = false;
            panelABLine.Visible = false;

            this.Size = new System.Drawing.Size(620, 475);

            originalLine = mf.trk.idx;
            mf.trk.isOkToAddDesPoints = false;
            selectedItem = -1;

            UpdateTable();

            if (mf.bnd.bndList.Count == 0)
            {
                btnCreateOuterBndCurve.Visible = false;
                btnCreateInnerBndCurve.Visible = false;
                label8.Visible = false;
                label3.Visible = false;
            }
            if (mf.bnd.bndList.Count < 2)
            {
                btnCreateInnerBndCurve.Visible = false;
                label8.Visible = false;
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

        #endregion

        #region Functions
        private void UpdateTable()
        {
            Font backupfont = new Font(Font.FontFamily, 18F, FontStyle.Regular);
            flp.Controls.Clear();

            for (int i = 0; i < mf.trk.tracksArr.Count; i++)
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

                if (mf.trk.tracksArr[i].isVisible)
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
                    Text = mf.trk.tracksArr[i].name,
                    Name = i.ToString(),
                };
                t.Font = backupfont;
                t.Click += LineSelected_Click;


                if (mf.trk.tracksArr[i].isVisible)
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
            //count the reference list of original trk
            int cnt = mf.trk.desList.Count;

            //the temp array
            vec3[] arr = new vec3[cnt];

            //read the points before and after the setpoint
            for (int s = 0; s < smPts / 2; s++)
            {
                arr[s].easting = mf.trk.desList[s].easting;
                arr[s].northing = mf.trk.desList[s].northing;
                arr[s].heading = mf.trk.desList[s].heading;
            }

            for (int s = cnt - (smPts / 2); s < cnt; s++)
            {
                arr[s].easting = mf.trk.desList[s].easting;
                arr[s].northing = mf.trk.desList[s].northing;
                arr[s].heading = mf.trk.desList[s].heading;
            }

            //average them - center weighted average
            for (int i = smPts / 2; i < cnt - (smPts / 2); i++)
            {
                for (int j = -smPts / 2; j < smPts / 2; j++)
                {
                    arr[i].easting += mf.trk.desList[j + i].easting;
                    arr[i].northing += mf.trk.desList[j + i].northing;
                }
                arr[i].easting /= smPts;
                arr[i].northing /= smPts;
                arr[i].heading = mf.trk.desList[i].heading;
            }

            //make a list to draw
            mf.trk.desList?.Clear();
            for (int i = 0; i < cnt; i++)
            {
                mf.trk.desList.Add(arr[i]);
            }
        }

        public void CalculateTurnHeadings()
        {
            //to calc heading based on next and previous points to give an average heading.
            int cnt = mf.trk.desList.Count;
            if (cnt > 0)
            {
                vec3[] arr = new vec3[cnt];
                cnt--;
                mf.trk.desList.CopyTo(arr);
                mf.trk.desList.Clear();

                //middle points
                for (int i = 1; i < cnt; i++)
                {
                    vec3 pt3 = arr[i];
                    pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
                    if (pt3.heading < 0) pt3.heading += glm.twoPI;
                    mf.trk.desList.Add(pt3);
                }
            }
        }

        private void UpdateBndButtons()
        {
            btnCreateOuterBndCurve.Enabled = true;
            btnCreateInnerBndCurve.Enabled = true;

            for (int i = 0; i < mf.trk.tracksArr.Count; i++)
            {
                if (mf.trk.tracksArr[i].mode == (int)TrackMode.bndTrackOuter)
                {
                    btnCreateOuterBndCurve.Enabled = false;
                    break;
                }
            }
            for (int i = 0; i < mf.trk.tracksArr.Count; i++)
            {
                if (mf.trk.tracksArr[i].mode == (int)TrackMode.bndTrackInner)
                {
                    btnCreateInnerBndCurve.Enabled = false;
                    break;
                }
            }

            if (mf.bnd.bndList.Count > 0 && mf.bnd.bndList[0].fenceLine.Count < 3)
            {
                btnCreateOuterBndCurve.Enabled = false;
                btnCreateInnerBndCurve.Enabled = false;
            }
        }

        #endregion

        #region Pick
        private void btnListUse_Click(object sender, EventArgs e)
        {
            isClosing = true;
            //reset to generate new reference
            mf.trk.isTrackValid = false;

            mf.FileSaveCurveLines();

            if (selectedItem > -1)
            {
                mf.trk.idx = selectedItem;
                mf.yt.ResetYouTurn();

                Close();
            }
            else
            {
                //mf.trk.moveDistance = 0;
                //mf.trk.isOkToAddDesPoints = false;
                //mf.trk.isTrackSet = false;
                //mf.trk.tracksArr[mf.trk.idx].trackPts?.Clear();
                //mf.trk.isTrackSet = false;
                //mf.DisableYouTurnButtons();
                //mf.trk.isBtnTrackOn = false;
                //mf.btnCurve.Image = Properties.Resources.TrackOff;
                //if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
                //if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();

                //mf.trk.numCurveLineSelected = 0;
                Close();
            }
        }

        private void btnChooseTrackMethod_Click(object sender, EventArgs e)
        {
            panelPick.Visible = false;
            panelABCurve.Visible = false;
            panelAddName.Visible = false;
            UpdateBndButtons();

            panelChoose.Visible = true;
        }

        private void A_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                mf.trk.tracksArr[Convert.ToInt32(b.Name)].isVisible = !mf.trk.tracksArr[Convert.ToInt32(b.Name)].isVisible;
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

            mf.trk.tracksArr.Reverse(selectedItem - 1, 2);
            selectedItem--;
            UpdateTable();
        }

        private void btnMoveDn_Click(object sender, EventArgs e)
        {
            if (selectedItem == -1 || selectedItem == (mf.trk.tracksArr.Count - 1))
                return;

            mf.trk.tracksArr.Reverse(selectedItem, 2);
            selectedItem++;
            UpdateTable();
        }

        private void btnCancelMain_Click(object sender, EventArgs e)
        {
            isClosing = true;
            mf.trk.isTrackValid = false;
            mf.trk.isOkToAddDesPoints = false;
            mf.DisableYouTurnButtons();
            //mf.btnContourPriority.Enabled = false;
            //mf.trk.ResetTrack();
            mf.trk.isBtnTrackOn = false;
            mf.btnCurve.Image = Properties.Resources.TrackOff;
            if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
            if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();

            mf.trk.idx = -1;
            Close();
        }

        private void btnCancelTrack_Click(object sender, EventArgs e)
        {
            mf.trk.isOkToAddDesPoints = false;
            mf.trk.desList?.Clear();

            panelPick.Visible = true;
            panelABCurve.Visible = false;
            panelEditName.Visible = false;
            panelAddName.Visible = false;
            panelChoose.Visible = false;
            panelABLine.Visible = false;

            this.Size = new System.Drawing.Size(620, 475);
        }

        private void btnSwapAB_Click(object sender, EventArgs e)
        {
            if (selectedItem > -1)
            {
                mf.trk.idx = selectedItem;

                int cnt = mf.trk.tracksArr[mf.trk.idx].trackPts.Count;
                if (cnt > 0)
                {
                    mf.trk.tracksArr[mf.trk.idx].trackPts.Reverse();

                    vec3[] arr = new vec3[cnt];
                    cnt--;
                    mf.trk.tracksArr[mf.trk.idx].trackPts.CopyTo(arr);
                    mf.trk.tracksArr[mf.trk.idx].trackPts.Clear();

                    mf.trk.tracksArr[mf.trk.idx].aveHeading += Math.PI;
                    if (mf.trk.tracksArr[mf.trk.idx].aveHeading < 0) mf.trk.tracksArr[mf.trk.idx].aveHeading += glm.twoPI;
                    if (mf.trk.tracksArr[mf.trk.idx].aveHeading > glm.twoPI) mf.trk.tracksArr[mf.trk.idx].aveHeading -= glm.twoPI;

                    for (int i = 1; i < cnt; i++)
                    {
                        vec3 pt3 = arr[i];
                        pt3.heading += Math.PI;
                        if (pt3.heading > glm.twoPI) pt3.heading -= glm.twoPI;
                        if (pt3.heading < 0) pt3.heading += glm.twoPI;
                        mf.trk.tracksArr[mf.trk.idx].trackPts.Add(pt3);
                    }
                }

                mf.FileSaveCurveLines();
                UpdateTable();
                flp.Focus();

                mf.TimedMessageBox(1500, "A B Swapped", "Curve is Reversed");
            }
        }

        private void btnListDelete_Click(object sender, EventArgs e)
        {
            if (selectedItem > -1)
            {
                mf.trk.tracksArr.RemoveAt(selectedItem);

                //everything changed, so make sure its right
                if (mf.trk.idx > mf.trk.tracksArr.Count - 1) mf.trk.idx = mf.trk.tracksArr.Count - 1;

                //if there are no saved ones, empty out current trk line and turn off
                if (mf.trk.tracksArr.Count == 0)
                {
                    if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
                    if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();
                    mf.trk.idx = -1;
                    mf.trk.ResetTrack();
                    mf.yt.ResetYouTurn();
                }

                mf.FileSaveCurveLines();
            }

            selectedItem = -1;

            UpdateTable();
            flp.Focus();
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if (selectedItem > -1)
            {
                int idx = selectedItem;


                panelPick.Visible = false;
                panelAddName.Visible = true;
                this.Size = new System.Drawing.Size(270, 360);

                panelABCurve.Visible = false;
                panelAddName.Visible = true;

                textBox1.Text = mf.trk.tracksArr[idx].name + " Copy";

                aveLineHeading = mf.trk.tracksArr[idx].aveHeading;
                mf.trk.desList?.Clear();

                for (int i = 0; i < mf.trk.tracksArr[idx].trackPts.Count; i++)
                {
                    vec3 pt = new vec3(mf.trk.tracksArr[idx].trackPts[i]);
                    mf.trk.desList.Add(pt);
                }
            }
        }

        private void btnEditName_Click(object sender, EventArgs e)
        {
            if (selectedItem > -1)
            {
                int idx = selectedItem;

                textBox2.Text = mf.trk.tracksArr[idx].name;

                panelPick.Visible = false;
                panelEditName.Visible = true;
                this.Size = new System.Drawing.Size(270, 360);
            }
        }

        #endregion

        #region Curve
        private void btnAPoint_Click(object sender, System.EventArgs e)
        {
            //mf.trk.moveDistance = 0;
            //clear out the reference list
            lblCurveExists.Text = gStr.gsDriving;
            btnBPoint.Enabled = true;
            //mf.trk.ResetTrack();

            btnAPoint.Enabled = false;
            mf.trk.isOkToAddDesPoints = true;
            btnPausePlay.Enabled = true;
            btnPausePlay.Visible = true;
        }

        private void btnBPoint_Click(object sender, System.EventArgs e)
        {
            aveLineHeading = 0;
            mf.trk.isOkToAddDesPoints = false;
            panelABCurve.Visible = false;
            panelAddName.Visible = true;

            int cnt = mf.trk.desList.Count;
            if (cnt > 3)
            {
                mf.trk.tracksArr.Add(new CTrackPath());
                mf.trk.idx = mf.trk.tracksArr.Count - 1;

                //make sure distance isn't too big between points on Turn
                for (int i = 0; i < cnt - 1; i++)
                {
                    int j = i + 1;
                    //if (j == cnt) j = 0;
                    double distance = glm.Distance(mf.trk.desList[i], mf.trk.desList[j]);
                    if (distance > 2.5)
                    {
                        vec3 pointB = new vec3((mf.trk.desList[i].easting + mf.trk.desList[j].easting) / 2.0,
                            (mf.trk.desList[i].northing + mf.trk.desList[j].northing) / 2.0,
                            mf.trk.desList[i].heading);

                        mf.trk.desList.Insert(j, pointB);
                        cnt = mf.trk.desList.Count;
                        i = -1;
                    }
                }

                //make sure distance isn't too small between points on Turn
                cnt = mf.trk.desList.Count;
                for (int i = 0; i < cnt - 2; i++)
                {
                    int j = i + 2;
                    //if (j == cnt) j = 0;
                    double distance = glm.Distance(mf.trk.desList[i], mf.trk.desList[j]);
                    if (distance < 2.1)
                    {
                        mf.trk.desList.RemoveAt(i + 1);
                        cnt = mf.trk.desList.Count;
                        i = -1;
                    }
                }

                //write out the Curve Points
                foreach (vec3 item in mf.trk.desList)
                {
                    mf.trk.tracksArr[mf.trk.idx].trackPts.Add(item);
                }

                mf.trk.desList.Clear();

                double widthMinusOverlap = mf.tool.width - mf.tool.overlap;

                double distAway = widthMinusOverlap - mf.tool.offset;
                distAway *= 0.5;

                double distSqAway = (distAway * distAway) - 0.01;
                vec3 point;

                int refCount = mf.trk.tracksArr[mf.trk.idx].trackPts.Count;
                for (int i = 0; i < refCount; i++)
                {
                    point = new vec3(
                    mf.trk.tracksArr[mf.trk.idx].trackPts[i].easting - (Math.Sin(glm.PIBy2 + mf.trk.tracksArr[mf.trk.idx].trackPts[i].heading) * distAway),
                    mf.trk.tracksArr[mf.trk.idx].trackPts[i].northing - (Math.Cos(glm.PIBy2 + mf.trk.tracksArr[mf.trk.idx].trackPts[i].heading) * distAway),
                    mf.trk.tracksArr[mf.trk.idx].trackPts[i].heading);
                    bool Add = true;

                    for (int t = 0; t < refCount; t++)
                    {
                        double dist = ((point.easting - mf.trk.tracksArr[mf.trk.idx].trackPts[t].easting) * (point.easting - mf.trk.tracksArr[mf.trk.idx].trackPts[t].easting))
                            + ((point.northing - mf.trk.tracksArr[mf.trk.idx].trackPts[t].northing) * (point.northing - mf.trk.tracksArr[mf.trk.idx].trackPts[t].northing));
                        if (dist < distSqAway)
                        {
                            Add = false;
                            break;
                        }
                    }

                    if (Add)
                    {
                        if (mf.trk.desList.Count > 0)
                        {
                            double dist = ((point.easting - mf.trk.desList[mf.trk.desList.Count - 1].easting) * (point.easting - mf.trk.desList[mf.trk.desList.Count - 1].easting))
                                + ((point.northing - mf.trk.desList[mf.trk.desList.Count - 1].northing) * (point.northing - mf.trk.desList[mf.trk.desList.Count - 1].northing));
                            if (dist > 1)
                                mf.trk.desList.Add(point);
                        }
                        else mf.trk.desList.Add(point);
                    }
                }

                mf.trk.tracksArr[mf.trk.idx].trackPts.Clear();

                //calculate average heading of line
                double x = 0, y = 0;
                foreach (vec3 pt in mf.trk.desList)
                {
                    x += Math.Cos(pt.heading);
                    y += Math.Sin(pt.heading);
                }
                x /= mf.trk.desList.Count;
                y /= mf.trk.desList.Count;
                aveLineHeading = Math.Atan2(y, x);
                if (aveLineHeading < 0) aveLineHeading += glm.twoPI;

                textBox1.Text = "Cu " +
                    (Math.Round(glm.toDegrees(aveLineHeading), 1)).ToString(CultureInfo.InvariantCulture) +
                    "\u00B0 " + mf.FindDirection(aveLineHeading) + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);

                ptA = new vec3(mf.trk.desList[0]);
                ptB = new vec3(mf.trk.desList[mf.trk.desList.Count - 1]);

                //build the tail extensions
                mf.trk.AddFirstLastPoints(ref mf.trk.desList);
                SmoothAB(4);
                CalculateTurnHeadings();


                mf.trk.tracksArr[mf.trk.idx].ptA = new vec3(ptA);
                mf.trk.tracksArr[mf.trk.idx].ptB = new vec3(ptB);

                mf.trk.tracksArr[mf.trk.idx].moveDistance = 0;

                mf.trk.tracksArr[mf.trk.idx].mode = (int)TrackMode.Curve;

                mf.trk.tracksArr[mf.trk.idx].name = textBox1.Text.Trim();
                mf.trk.tracksArr[mf.trk.idx].aveHeading = aveLineHeading;

                //write out the Curve Points
                foreach (vec3 item in mf.trk.desList)
                {
                    mf.trk.tracksArr[mf.trk.idx].trackPts.Add(item);
                }

                mf.trk.desList?.Clear();
                panelABCurve.Visible = false;
                panelAddName.Visible = true;
            }
            else
            {
                mf.trk.isOkToAddDesPoints = false;
                mf.trk.desList?.Clear();

                panelPick.Visible = true;
                panelABCurve.Visible = false;
                panelAddName.Visible = false;

                this.Size = new System.Drawing.Size(620, 475);
            }

            mf.FileSaveCurveLines();
        }

        private void btnPausePlay_Click(object sender, EventArgs e)
        {
            if (mf.trk.isOkToAddDesPoints)
            {
                mf.trk.isOkToAddDesPoints = false;
                btnPausePlay.Image = Properties.Resources.BoundaryRecord;
                //btnPausePlay.Text = gStr.gsRecord;
                btnBPoint.Enabled = false;
            }
            else
            {
                mf.trk.isOkToAddDesPoints = true;
                btnPausePlay.Image = Properties.Resources.boundaryPause;
                //btnPausePlay.Text = gStr.gsPause;
                btnBPoint.Enabled = true;
            }
        }

        #endregion

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

        #region Add name
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
                mf.KeyboardToText((TextBox)sender, this);

            if (textBox1.Text.Trim() == "") textBox1.Text = "No Name " + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            panelPick.Visible = true;
            panelABCurve.Visible = false;
            panelAddName.Visible = false;

            this.Size = new System.Drawing.Size(620, 475);

            mf.trk.tracksArr[mf.trk.idx].name = textBox1.Text;
            mf.FileSaveCurveLines();
            mf.trk.desList?.Clear();
            UpdateTable();
            mf.FileSaveCurveLines();
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            textBox1.Text += DateTime.Now.ToString(" hh:mm:ss", CultureInfo.InvariantCulture);
        }

        #endregion

        #region Edit name
        private void textBox2_Click(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
                mf.KeyboardToText((TextBox)sender, this);
        }

        private void btnSaveEditName_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "") textBox2.Text = "No Name " + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);

            int idx = selectedItem;

            mf.trk.tracksArr[idx].name = textBox2.Text;

            panelEditName.Visible = false;
            panelPick.Visible = true;

            mf.FileSaveCurveLines();
            mf.trk.desList?.Clear();
            textBox2.Text = "";
            this.Size = new System.Drawing.Size(620, 475);

            UpdateTable();
            flp.Focus();
        }

        #endregion

        #region TrackMethods
        private void btnzNewLoadFromKML_Click(object sender, EventArgs e)
        {
            panelPick.Visible = false;
            panelABCurve.Visible = false;
            panelAddName.Visible = false;
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
                mf.trk.isOkToAddDesPoints = false;
                mf.trk.desList?.Clear();

                panelPick.Visible = true;
                panelABCurve.Visible = false;
                panelEditName.Visible = false;
                panelAddName.Visible = false;
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

                mf.trk.desList?.Clear();

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
                                mf.trk.desList.Add(bndPt);
                            }
                        }
                    }

                    int cnt = mf.trk.desList.Count;
                    if (cnt > 1)
                    {
                        //make sure distance isn't too big between points on Turn
                        for (int i = 0; i < cnt - 1; i++)
                        {
                            int j = i + 1;
                            //if (j == cnt) j = 0;
                            double distance = glm.Distance(mf.trk.desList[i], mf.trk.desList[j]);
                            if (distance > 1.6)
                            {
                                vec3 pointB = new vec3(
                                    (mf.trk.desList[i].easting + mf.trk.desList[j].easting) / 2.0,
                                    (mf.trk.desList[i].northing + mf.trk.desList[j].northing) / 2.0,
                                    mf.trk.desList[i].heading
                                    );

                                mf.trk.desList.Insert(j, pointB);
                                cnt = mf.trk.desList.Count;
                                i = -1;
                            }
                        }

                        CalculateTurnHeadings();

                        //build the tail extensions
                        mf.trk.AddFirstLastPoints(ref mf.trk.desList);
                        SmoothAB(4);
                        CalculateTurnHeadings();

                        panelKML.Visible = false;
                        panelAddName.Visible = true;

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


        private void btnzABLine_Click(object sender, EventArgs e)
        {
            panelPick.Visible = false;
            panelABCurve.Visible = false;
            panelAddName.Visible = false;
            panelABLine.Visible = true;
            panelChoose.Visible = false;

            btnABAPoint.Enabled = true;
            btnABBPoint.Enabled = false;
            btnABBPoint.BackColor = System.Drawing.Color.Transparent;
            nudHeading.Enabled = false;

            btnPausePlay.Enabled = false;

            mf.trk.desList?.Clear();

            this.Size = new System.Drawing.Size(270, 360);
        }

        private void btnzNewABCurve_Click(object sender, EventArgs e)
        {
            panelPick.Visible = false;
            panelABCurve.Visible = true;
            panelAddName.Visible = false;
            panelABLine.Visible = false;

            panelChoose.Visible = false;
            btnAPoint.Enabled = true;
            btnBPoint.Enabled = false;

            btnPausePlay.Enabled = false;
            mf.trk.desList?.Clear();

            this.Size = new System.Drawing.Size(270, 360);
        }

        #endregion

        #region ABLine
        private void btnABAPoint_Click(object sender, EventArgs e)
        {
            //mf.curve.moveDistance = 0;
            //clear out the reference list
            lblCurveExists.Text = gStr.gsDriving;
            btnBPoint.Enabled = true;

            btnABAPoint.Enabled = false;

            vec3 fix = new vec3(mf.pivotAxlePos);
            mf.trk.desList.Add(new vec3(fix));
            ptA = new vec3(fix);

            fix.easting += (Math.Sin(fix.heading) * 1000);
            fix.northing += (Math.Cos(fix.heading) * 1000);
            mf.trk.desList.Add(new vec3(fix));

            nudHeading.Enabled = true;
            nudHeading.Value = (decimal)(glm.toDegrees(mf.trk.desList[0].heading));


            btnABBPoint.Enabled = true;
            btnABAPoint.Enabled = false;

            btnEnter_AB.Enabled = true;
        }

        private void btnABBPoint_Click(object sender, EventArgs e)
        {
            vec3 fix = new vec3(mf.pivotAxlePos);
            ptB = new vec3(fix);

            btnABBPoint.BackColor = System.Drawing.Color.Teal;

            mf.trk.desList.Clear();
            mf.trk.desList.Add(new vec3(ptA));

            double curHeading = Math.Atan2(fix.easting - mf.trk.desList[0].easting,
               fix.northing - mf.trk.desList[0].northing);
            if (curHeading < 0) curHeading += glm.twoPI;

            fix.heading = curHeading;
            mf.trk.desList.Add(new vec3(fix));

            fix.easting += (Math.Sin(curHeading) * 1000);
            fix.northing += (Math.Cos(curHeading) * 1000);
            fix.heading = curHeading;


            nudHeading.Value = (decimal)(glm.toDegrees(curHeading));

            mf.trk.desList.Add(new vec3(fix));
        }

        private void nudHeading_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                //original A pt. 
                ptA.heading = glm.toRadians((double)nudHeading.Value);

                mf.trk.desList?.Clear();

                vec3 fix = new vec3(ptA);

                //start end of line
                fix.easting = ptA.easting + (Math.Sin(ptA.heading) * 200);
                fix.northing = ptA.northing + (Math.Cos(ptA.heading) * 200);
                fix.heading = ptA.heading;

                ptB = new vec3(fix);

                mf.trk.desList.Add(new vec3(ptA));
                mf.trk.desList.Add(new vec3(ptB));

                //end end of line.
                fix.easting += (Math.Sin(fix.heading) * 300);
                fix.northing += (Math.Cos(fix.heading) * 300);
                fix.heading = ptA.heading;
                mf.trk.desList.Add(new vec3(fix));
            }
        }

        private void btnEnter_AB_Click(object sender, EventArgs e)
        {
            mf.trk.tracksArr.Add(new CTrackPath());
            mf.trk.idx = mf.trk.tracksArr.Count - 1;

            aveLineHeading = mf.trk.desList[0].heading;
            mf.trk.tracksArr[mf.trk.idx].aveHeading = mf.trk.desList[0].heading;

            mf.trk.tracksArr[mf.trk.idx].trackPts?.Clear();

            double widthMinusOverlap = mf.tool.width - mf.tool.overlap;

            double distAway = (widthMinusOverlap - mf.tool.offset) * 0.5;

            ptA.easting -= (Math.Sin(glm.PIBy2 + ptA.heading) * distAway);
            ptA.northing -= (Math.Cos(glm.PIBy2 + ptA.heading) * distAway);

            ptB.easting -= (Math.Sin(glm.PIBy2 + ptB.heading) * distAway);
            ptB.northing -= (Math.Cos(glm.PIBy2 + ptB.heading) * distAway);


            for (int i = 0; i <= (int)(glm.Distance(ptA, ptB) / 4); i += 2)
            {
                vec3 ptC = new vec3(ptA);
                ptC.easting = (Math.Sin(aveLineHeading) * 4 * i) + ptA.easting;
                ptC.northing = (Math.Cos(aveLineHeading) * 4 * i) + ptA.northing;
                ptC.heading = aveLineHeading;
                mf.trk.tracksArr[mf.trk.idx].trackPts.Add(ptC);
            }

            mf.trk.AddFirstLastPoints(ref mf.trk.tracksArr[mf.trk.idx].trackPts);

            //create a name
            textBox1.Text = "AB "
                + (Math.Round(glm.toDegrees(aveLineHeading), 2)).ToString(CultureInfo.InvariantCulture)
                + "\u00B0 " + mf.FindDirection(aveLineHeading);

            mf.trk.tracksArr[mf.trk.idx].name = textBox1.Text;

            mf.trk.tracksArr[mf.trk.idx].ptA = ptA;
            mf.trk.tracksArr[mf.trk.idx].ptB = ptB;

            mf.trk.tracksArr[mf.trk.idx].moveDistance = 0;

            mf.trk.tracksArr[mf.trk.idx].mode = (int)TrackMode.AB;

            mf.trk.desList?.Clear();
            panelABLine.Visible = false;
            panelAddName.Visible = true;
        }
        #endregion

        #region BndCurve
        private void btnCreateOuterBndCurve_Click(object sender, EventArgs e)
        {
            mf.trk.tracksArr.Add(new CTrackPath());
            mf.trk.idx = mf.trk.tracksArr.Count - 1;

            //make the boundary list directly
            for (int i = 0; i < mf.bnd.bndList[0].fenceLine.Count; i++)
            {
                mf.trk.tracksArr[mf.trk.idx].trackPts.Add(new vec3(mf.bnd.bndList[0].fenceLine[i]));
            }
            mf.trk.tracksArr[mf.trk.idx].trackPts.Add(new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[0]));

            mf.trk.CalculateTurnHeadings();

            mf.trk.tracksArr[mf.trk.idx].aveHeading = 0;

            //create a name
            mf.trk.tracksArr[mf.trk.idx].name = "Outer Boundary Curve";
            mf.trk.tracksArr[mf.trk.idx].mode = (int)TrackMode.bndTrackOuter;

            mf.trk.tracksArr[mf.trk.idx].moveDistance = 0;

            mf.trk.tracksArr[mf.trk.idx].ptA = new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[0]);
            mf.trk.tracksArr[mf.trk.idx].ptB = new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[mf.trk.tracksArr[mf.trk.idx].trackPts.Count - 1]);

            mf.FileSaveCurveLines();
            btnCreateOuterBndCurve.Enabled = false;
            UpdateTable();

            mf.trk.isOkToAddDesPoints = false;
            mf.trk.desList?.Clear();

            panelPick.Visible = true;
            panelABCurve.Visible = false;
            panelEditName.Visible = false;
            panelAddName.Visible = false;
            panelChoose.Visible = false;
            panelABLine.Visible = false;

            this.Size = new System.Drawing.Size(620, 475);
        }

        private void btnCreateInnerBndCurve_Click(object sender, EventArgs e)
        {
            for (int q = 1; q < mf.bnd.bndList.Count; q++)
            {
                mf.trk.tracksArr.Add(new CTrackPath());
                mf.trk.idx = mf.trk.tracksArr.Count - 1;

                //make the boundary list directly
                for (int i = 0; i < mf.bnd.bndList[q].fenceLine.Count; i++)
                {
                    mf.trk.tracksArr[mf.trk.idx].trackPts.Add(new vec3(mf.bnd.bndList[q].fenceLine[i]));
                }
                mf.trk.tracksArr[mf.trk.idx].trackPts.Add(new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[0]));

                mf.trk.CalculateTurnHeadings();

                mf.trk.tracksArr[mf.trk.idx].aveHeading = 0;
                mf.trk.tracksArr[mf.trk.idx].mode = (int)TrackMode.bndTrackInner;

                //create a name
                mf.trk.tracksArr[mf.trk.idx].name = "Inner Boundary Curve " + q.ToString();

                mf.trk.tracksArr[mf.trk.idx].moveDistance = 0;

                mf.trk.tracksArr[mf.trk.idx].ptA = new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[0]);
                mf.trk.tracksArr[mf.trk.idx].ptB = new vec3(mf.trk.tracksArr[mf.trk.idx].trackPts[mf.trk.tracksArr[mf.trk.idx].trackPts.Count - 1]);
            }

            btnCreateInnerBndCurve.Enabled = false;
            mf.FileSaveCurveLines();
            UpdateTable();

            mf.trk.isOkToAddDesPoints = false;
            mf.trk.desList?.Clear();

            panelPick.Visible = true;
            panelABCurve.Visible = false;
            panelEditName.Visible = false;
            panelAddName.Visible = false;
            panelChoose.Visible = false;
            panelABLine.Visible = false;

            this.Size = new System.Drawing.Size(620, 475);

        }
        #endregion

        private void btnSelectAllOrNone_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < mf.trk.tracksArr.Count; i++)
            {
                mf.trk.tracksArr[i].isVisible = isOn;
            }

            isOn = !isOn;

            mf.FileSaveCurveLines() ;
            UpdateTable();
        }
    }
}

