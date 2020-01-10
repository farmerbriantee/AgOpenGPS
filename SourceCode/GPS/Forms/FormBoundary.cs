using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormBoundary : Form
    {
        private readonly FormGPS mf = null;

        private bool Selectedreset = true;
        private int position = 0;

        private double easting, northing, latK, lonK;


        public FormBoundary(Form callingForm)
        {
            mf = callingForm as FormGPS;

            //winform initialization
            InitializeComponent();

            nudBndOffset.Controls[0].Enabled = false;

            this.Text = gStr.gsStartDeleteABoundary;

            //Column Header
            Boundary.Text = gStr.gsBounds;
            Thru.Text = gStr.gsDriveThru;
            Area.Text = gStr.gsArea;
            Around.Text = gStr.gsAround;

            //Bouton
            //btnDelete.Text = gStr.gsDelete;
            //btnSerialCancel.Text = gStr.gsSaveAndReturn;
            //btnDeleteAll.Text = gStr.gsDeleteAll;
            btnGo.Text = gStr.gsGo;
            lblOffset.Text = gStr.gsOffset;

            btnLoadBoundaryFromGE.Visible = false;
            btnLoadMultiBoundaryFromGE.Visible = false;
            btnGo.Visible = true;
            nudBndOffset.Visible = true;

            btnLeftRight.Visible = true;
            btnLoadMultiBoundaryFromGE.Enabled = true;
            btnLoadBoundaryFromGE.Enabled = false;
        }

        private void UpdateChart()
        {
            int field = 1;
            int inner = 1;

            for (int i = 0; i < mf.bnd.bndArr.Count + 1 && i < position + 9; i++)
            {
                if (i < position && i < mf.bnd.bndArr.Count)
                {
                    if (i==0)
                    {
                        field += 1;
                    }
                    else
                    {
                        inner += 1;
                    }
                }
                else
                {
                    Control aa = tableLayoutPanel1.GetControlFromPosition(0, i - position);
                    if (aa == null)
                    {
                        var a = new Button
                        {
                            Margin = new Padding(0),
                            Size = new Size(280, 40),
                            Name = string.Format("{0}", i - position),
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        a.Click += B_Click;
                        a.FlatStyle = FlatStyle.Flat;
                        a.FlatAppearance.BorderColor = BackColor;
                        a.FlatAppearance.MouseOverBackColor = BackColor;
                        a.FlatAppearance.MouseDownBackColor = BackColor;

                        aa = a;

                        var d = new Button
                        {
                            Margin = new Padding(0),
                            Size = new System.Drawing.Size(80, 40),
                            Name = string.Format("{0}", i - position),
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        d.Click += DriveThru_Click;

                        var e = new Button
                        {
                            Margin = new Padding(0),
                            Size = new System.Drawing.Size(80, 40),
                            Name = string.Format("{0}", i - position),
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        e.Click += DriveAround_Click;
                        tableLayoutPanel1.Controls.Add(a, 0, i - position);
                        tableLayoutPanel1.Controls.Add(d, 3-1, i - position);
                        tableLayoutPanel1.Controls.Add(e, 4-1, i - position);
                    }

                    if (i < mf.bnd.bndArr.Count && mf.bnd.bndArr[i].isSet)
                    {
                        tableLayoutPanel1.SetColumnSpan(aa, 1);

                        Control bb = tableLayoutPanel1.GetControlFromPosition(1, i - position);
                        if (bb == null)
                        {
                            var b = new Button
                            {
                                Margin = new Padding(0),
                                Size = new System.Drawing.Size(150, 40),
                                Name = string.Format("{0}", i - position),
                                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                            };
                            b.Click += B_Click;
                            b.FlatStyle = FlatStyle.Flat;
                            b.FlatAppearance.BorderColor = BackColor;
                            b.FlatAppearance.MouseOverBackColor = BackColor;
                            b.FlatAppearance.MouseDownBackColor = BackColor;
                            tableLayoutPanel1.Controls.Add(b, 1, i - position);
                            bb = b;
                        }
                        Control dd = tableLayoutPanel1.GetControlFromPosition(3-1, i - position);
                        dd.Visible = true;
                        Control ee = tableLayoutPanel1.GetControlFromPosition(4-1, i - position);
                        ee.Visible = true;

                        Font backupfont = new Font(aa.Font.FontFamily, 18F, FontStyle.Bold);

                        if (i == 0)
                        {
                            //cc.Text = "Field";
                            aa.Text = string.Format(gStr.gsOuter );
                            field += 1;
                            aa.Font = backupfont;
                            dd.Enabled = false;
                            ee.Enabled = false;
                            mf.bnd.bndArr[i].isDriveThru = false;
                            mf.bnd.bndArr[i].isDriveAround = false;
                            dd.Text = mf.bnd.bndArr[i].isDriveThru ? "--" : "--";
                            dd.Anchor = System.Windows.Forms.AnchorStyles.None;
                            ee.Text = mf.bnd.bndArr[i].isDriveAround ? "--" : "--";
                            ee.Anchor = System.Windows.Forms.AnchorStyles.None;
                            dd.BackColor = Color.WhiteSmoke;
                            ee.BackColor = Color.WhiteSmoke;

                        }
                        else
                        {
                            //cc.Text = "Inner";
                            aa.Text = string.Format(gStr.gsInner + " {0}", inner);
                            aa.Font = backupfont;
                            inner += 1;
                            dd.Enabled = true;
                            ee.Enabled = true;
                            dd.Text = mf.bnd.bndArr[i].isDriveThru ? "Yes" : "No";
                            dd.Anchor = System.Windows.Forms.AnchorStyles.None;
                            ee.Text = mf.bnd.bndArr[i].isDriveAround ? "Yes" : "No";
                            ee.Anchor = System.Windows.Forms.AnchorStyles.None;
                            dd.BackColor = Color.WhiteSmoke;
                            ee.BackColor = Color.WhiteSmoke;
                        }

                        if (mf.isMetric)
                        {
                            bb.Text = Math.Round(mf.bnd.bndArr[i].area * 0.0001, 2) + " Ha";
                        }
                        else
                        {
                            bb.Text = Math.Round(mf.bnd.bndArr[i].area * 0.000247105, 2) + " Ac";
                        }

                        if (Selectedreset == false && i == mf.bnd.boundarySelected)
                        {
                            aa.ForeColor = Color.Red;
                            bb.ForeColor = Color.Red;
                        }
                        else
                        {
                            aa.ForeColor = default;
                            bb.ForeColor = default;
                        }
                    }
                    else
                    {
                        Control bb = tableLayoutPanel1.GetControlFromPosition(1, i - position);
                        if (!(bb == null || bb == aa))
                        {
                            bb.Dispose();
                        }

                        tableLayoutPanel1.SetColumnSpan(aa, 2);
                        aa.Text = string.Format(gStr.gsCreateNewBoundary, i - position + 1);

                        aa.BackColor = Color.Bisque;
                        aa.Anchor = System.Windows.Forms.AnchorStyles.None;

                        Control dd = tableLayoutPanel1.GetControlFromPosition(3-1, i - position);
                        dd.Visible = false;
                        Control ee = tableLayoutPanel1.GetControlFromPosition(4-1, i - position);
                        ee.Visible = false;

                        //delete rest of buttons
                        while (true)
                        {
                            Control ff = tableLayoutPanel1.GetNextControl(ee, true);
                            if (ff == null)
                            {
                                break;
                            }
                            else
                            {
                                ff.Dispose();
                            }

                        }

                        if (Selectedreset == false && i == mf.bnd.boundarySelected)
                        {
                            aa.ForeColor = Color.DarkBlue;
                        }
                        else
                        {
                            aa.ForeColor = default;
                        }
                        break;
                    }
                }
            }
        }

        private void FormBoundary_Load(object sender, EventArgs e)
        {
            btnLeftRight.Image = mf.bnd.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
            btnLeftRight.Enabled = false;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;
            nudBndOffset.Enabled = false;

            //update the list view with real data
            UpdateChart();
            nudBndOffset.Value = (decimal)(mf.tool.toolWidth * 0.5);
        }

        void DriveThru_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                mf.bnd.bndArr[Convert.ToInt32(b.Name) + position].isDriveThru = !mf.bnd.bndArr[Convert.ToInt32(b.Name) + position].isDriveThru;
                UpdateChart();
            }
        }

        void DriveAround_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                mf.bnd.bndArr[Convert.ToInt32(b.Name) + position].isDriveAround = !mf.bnd.bndArr[Convert.ToInt32(b.Name) + position].isDriveAround;
                UpdateChart();
            }
        }

        void B_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {

                mf.bnd.boundarySelected = Convert.ToInt32(b.Name) + position;

                Selectedreset = false;

                if (mf.bnd.bndArr.Count > mf.bnd.boundarySelected && mf.bnd.bndArr[mf.bnd.boundarySelected].isSet)
                {
                    btnGo.Enabled = false;
                    nudBndOffset.Enabled = false;
                    btnDelete.Enabled = true;
                    btnLeftRight.Enabled = false;
                    btnLoadBoundaryFromGE.Enabled = false;
                    btnLoadMultiBoundaryFromGE.Enabled = false;
                }
                else
                {
                    btnGo.Enabled = true;
                    nudBndOffset.Enabled = true;
                    btnDelete.Enabled = false;
                    btnLeftRight.Enabled = true;
                    btnDeleteAll.Enabled = false;
                    btnLoadBoundaryFromGE.Enabled = true;
                    btnLoadMultiBoundaryFromGE.Enabled = false;
                }
            }
            UpdateChart();
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            mf.bnd.isOkToAddPoints = false;
            mf.turn.BuildTurnLines();
            mf.gf.BuildGeoFenceLines();
            //mf.hd.BuildSingleSpaceHeadLines();
            mf.mazeGrid.BuildMazeGridArray();
        }

        private void btnLeftRight_Click(object sender, EventArgs e)
        {
            mf.bnd.isDrawRightSide = !mf.bnd.isDrawRightSide;
            btnLeftRight.Image = mf.bnd.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnLeftRight.Enabled = false;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;
            nudBndOffset.Enabled = false;

            if (mf.bnd.bndArr.Count > mf.bnd.boundarySelected)
            {
                mf.bnd.bndArr.RemoveAt(mf.bnd.boundarySelected);
                mf.turn.turnArr.RemoveAt(mf.bnd.boundarySelected);
                mf.gf.geoFenceArr.RemoveAt(mf.bnd.boundarySelected);
            }

            mf.FileSaveBoundary();

            if (mf.bnd.boundarySelected == 0)
            {
                mf.hd.headArr[0].hdLine.Clear();
                mf.hd.isOn = false;
                mf.FileSaveHeadland();
            }

            mf.bnd.boundarySelected = -1;
            Selectedreset = true;
            mf.fd.UpdateFieldBoundaryGUIAreas();
            mf.turn.BuildTurnLines();
            mf.gf.BuildGeoFenceLines();
            mf.mazeGrid.BuildMazeGridArray();

            UpdateChart();
        }

        private void ResetAllBoundary()
        {
            position = 0;

            mf.bnd.bndArr.Clear();
            mf.turn.turnArr.Clear();
            mf.gf.geoFenceArr.Clear();

            mf.FileSaveBoundary();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            UpdateChart();

            btnLeftRight.Enabled = false;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;
            nudBndOffset.Enabled = false;
        }

        private void btnOpenGoogleEarth_Click(object sender, EventArgs e)
        {
            //save new copy of kml with selected flag and view in GoogleEarth
            mf.FileMakeCurrentKML(mf.pn.latitude, mf.pn.longitude);
            System.Diagnostics.Process.Start(mf.fieldsDirectory + mf.currentFieldDirectory + "\\CurrentPosition.KML");
        }

        private void nudBndOffset_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            mf.bnd.createBndOffset = (double)nudBndOffset.Value;
            mf.bnd.isBndBeingMade = true;
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            ResetAllBoundary();

            mf.bnd.boundarySelected = -1;
            Selectedreset = true;

            mf.bnd.isOkToAddPoints = false;
            mf.turn.BuildTurnLines();
            mf.gf.BuildGeoFenceLines();
            mf.hd.headArr[0].hdLine.Clear();
            mf.hd.isOn = false;
            mf.FileSaveHeadland();

            mf.hd.isOn = false;
            mf.mazeGrid.BuildMazeGridArray();
            mf.fd.UpdateFieldBoundaryGUIAreas();

        }

        private void btnLoadBoundaryFromGE_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Selectedreset = true;
                btnLoadBoundaryFromGE.Enabled = false;
                btnDelete.Enabled = false;

                string fileAndDirectory;
                {
                    //create the dialog instance
                    OpenFileDialog ofd = new OpenFileDialog
                    {
                        //set the filter to text KML only
                        Filter = "KML files (*.KML)|*.KML",

                        //the initial directory, fields, for the open dialog
                        InitialDirectory = mf.fieldsDirectory + mf.currentFieldDirectory
                    };

                    //was a file selected
                    if (ofd.ShowDialog() == DialogResult.Cancel) return;
                    else fileAndDirectory = ofd.FileName;
                }

                //start to read the file
                string line = null;
                string coordinates = null;
                int startIndex;
                int i = 0;

                using (System.IO.StreamReader reader = new System.IO.StreamReader(fileAndDirectory))
                {

                    if (button.Name == "btnLoadMultiBoundaryFromGE") ResetAllBoundary();
                    else i = mf.bnd.boundarySelected;

                    try
                    {
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();

                            startIndex = line.IndexOf("<coordinates>");

                            if (startIndex != -1)
                            {
                                while (true)
                                {
                                    int endIndex = line.IndexOf("</coordinates>");

                                    if (endIndex == -1)
                                    {
                                        //just add the line
                                        if (startIndex == -1) coordinates = coordinates + line.Substring(0);
                                        else coordinates = coordinates + line.Substring(startIndex + 13);
                                    }
                                    else
                                    {
                                        if (startIndex == -1) coordinates = coordinates + line.Substring(0, endIndex);
                                        else coordinates = coordinates + line.Substring(startIndex + 13, endIndex - (startIndex + 13));
                                        break;
                                    }
                                    line = reader.ReadLine();
                                    line = line.Trim();
                                    startIndex = -1;
                                }

                                line = coordinates;
                                char[] delimiterChars = { ' ', '\t', '\r', '\n' };
                                string[] numberSets = line.Split(delimiterChars);

                                //at least 3 points
                                if (numberSets.Length > 2)
                                {
                                    mf.bnd.bndArr.Add(new CBoundaryLines());
                                    mf.turn.turnArr.Add(new CTurnLines());
                                    mf.gf.geoFenceArr.Add(new CGeoFenceLines());

                                    foreach (var item in numberSets)
                                    {
                                        string[] fix = item.Split(',');
                                        double.TryParse(fix[0], NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);
                                        double.TryParse(fix[1], NumberStyles.Float, CultureInfo.InvariantCulture, out latK);
                                        double[] xy = mf.pn.DecDeg2UTM(latK, lonK);

                                        //match new fix to current position
                                        easting = xy[0] - mf.pn.utmEast;
                                        northing = xy[1] - mf.pn.utmNorth;

                                        double east = easting;
                                        double nort = northing;

                                        //fix the azimuth error
                                        easting = (Math.Cos(-mf.pn.convergenceAngle) * east) - (Math.Sin(-mf.pn.convergenceAngle) * nort);
                                        northing = (Math.Sin(-mf.pn.convergenceAngle) * east) + (Math.Cos(-mf.pn.convergenceAngle) * nort);

                                        //add the point to boundary
                                        vec3 bndPt = new vec3(easting, northing, 0);
                                        mf.bnd.bndArr[i].bndLine.Add(bndPt);
                                    }

                                    //fix the points if there are gaps bigger then
                                    mf.bnd.bndArr[i].CalculateBoundaryHeadings();
                                    mf.bnd.bndArr[i].PreCalcBoundaryLines();
                                    mf.bnd.bndArr[i].FixBoundaryLine(i, mf.tool.toolWidth);

                                    //boundary area, pre calcs etc
                                    mf.bnd.bndArr[i].CalculateBoundaryArea();
                                    mf.bnd.bndArr[i].PreCalcBoundaryLines();
                                    mf.bnd.bndArr[i].isSet = true;
                                    //if (i == 0) mf.bnd.bndArr[i].isOwnField = true;
                                    //else mf.bnd.bndArr[i].isOwnField = false;
                                    coordinates = "";
                                    i++;
                                }
                                else
                                {
                                    mf.TimedMessageBox(2000, gStr.gsErrorreadingKML, gStr.gsChooseBuildDifferentone);
                                }
                                if (button.Name == "btnLoadBoundaryFromGE")
                                {
                                    break;
                                }
                            }
                        }
                        mf.FileSaveBoundary();
                        mf.fd.UpdateFieldBoundaryGUIAreas();
                        UpdateChart();
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
        }

        private void btnDriveOrExt_Click(object sender, EventArgs e)
        {
            if (btnLoadBoundaryFromGE.Visible == true)
            {
                btnLoadBoundaryFromGE.Visible = false;
                btnLoadMultiBoundaryFromGE.Visible = false;
                btnGo.Visible = true;
                btnLeftRight.Visible = true;
                nudBndOffset.Visible = true;

            }
            else
            {
                btnLoadBoundaryFromGE.Visible = true;
                btnLoadMultiBoundaryFromGE.Visible = true;
                btnGo.Visible = false;
                btnLeftRight.Visible = false;
                nudBndOffset.Visible = false;
            }
        }
    }
}
