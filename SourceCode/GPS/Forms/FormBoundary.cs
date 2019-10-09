using System;
using System.Globalization;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormBoundary : Form
    {
        private bool Selectedreset = true;
        private readonly FormGPS mf = null;

        public FormBoundary(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void UpdateChart()
        {

            int field = 1;
            int inner = 1;
            tableLayoutPanel1.HorizontalScroll.Maximum = 0;
            tableLayoutPanel1.AutoScroll = true;


            
            for (int i = 0; i < mf.bnd.bndArr.Count + 1; i++)
            {
                Control aa = tableLayoutPanel1.GetControlFromPosition(0, i);
                if (aa == null)
                {
                    var a = new Button();
                    a.Margin = new Padding(0);
                    a.Size = new Size(280, 40);
                    a.Name = string.Format("{0}", i);
                    a.TextAlign = ContentAlignment.MiddleCenter;
                    a.Click += b_Click;

                    a.FlatStyle = FlatStyle.Flat;
                    a.FlatAppearance.BorderColor = BackColor;
                    a.FlatAppearance.MouseOverBackColor = BackColor;
                    a.FlatAppearance.MouseDownBackColor = BackColor;

                    aa = a;

                    var c = new Button();
                    c.Margin = new Padding(0);
                    c.Size = new System.Drawing.Size(85, 40);
                    c.Name = string.Format("{0}", i);
                    a.TextAlign = ContentAlignment.MiddleCenter;
                    c.Click += OwnField_Click;

                    var d = new Button();
                    d.Margin = new Padding(0);
                    d.Size = new System.Drawing.Size(85, 40);
                    d.Name = string.Format("{0}", i);
                    a.TextAlign = ContentAlignment.MiddleCenter;
                    d.Click += DriveThru_Click;

                    var e = new Button();
                    e.Margin = new Padding(0);
                    e.Size = new System.Drawing.Size(85, 40);
                    e.Name = string.Format("{0}", i);
                    a.TextAlign = ContentAlignment.MiddleCenter;
                    e.Click += DriveAround_Click;
                    tableLayoutPanel1.Controls.Add(a, 0, i);
                    tableLayoutPanel1.Controls.Add(c, 2, i);
                    tableLayoutPanel1.Controls.Add(d, 3, i);
                    tableLayoutPanel1.Controls.Add(e, 4, i);
                }






                if (i < mf.bnd.bndArr.Count && mf.bnd.bndArr[i].isSet)
                {
                    tableLayoutPanel1.SetColumnSpan(aa, 1);

                    Control bb = tableLayoutPanel1.GetControlFromPosition(1, i);
                    if (bb == null)
                    {
                        var b = new Button();
                        b.Margin = new Padding(0);
                        b.Size = new System.Drawing.Size(150, 40);
                        b.Name = string.Format("{0}", i);
                        b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        b.Click += b_Click;
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderColor = BackColor;
                        b.FlatAppearance.MouseOverBackColor = BackColor;
                        b.FlatAppearance.MouseDownBackColor = BackColor;

                        tableLayoutPanel1.Controls.Add(b, 1, i);
                        bb = b;
                    }
                    Control cc = tableLayoutPanel1.GetControlFromPosition(2, i);
                    cc.Visible = true;
                    Control dd = tableLayoutPanel1.GetControlFromPosition(3, i);
                    dd.Visible = true;
                    Control ee = tableLayoutPanel1.GetControlFromPosition(4, i);
                    ee.Visible = true;


                    Font backupfont = new Font(aa.Font.FontFamily, 18F, FontStyle.Bold);




                    // LOCK MultipleField

                    cc.Enabled = false;

                    // LOCK MultipleField




                    if (mf.bnd.bndArr[i].isOwnField)
                    {
                        cc.Text = "true";
                        aa.Text = string.Format("field {0}", field);
                        field += 1;
                        aa.Font = backupfont;
                        dd.Enabled = false;
                        ee.Enabled = false;
                    }
                    else
                    {
                        cc.Text = "false";
                        aa.Text = string.Format("Inner {0}", inner);
                        aa.Font = backupfont;
                        inner += 1;
                        dd.Enabled = true;
                        ee.Enabled = true;
                    }

                    if (mf.isMetric)
                    {
                        bb.Text = Math.Round(mf.bnd.bndArr[i].area * 0.0001, 2) + " Ha";
                    }
                    else
                    {
                        bb.Text = Math.Round(mf.bnd.bndArr[i].area * 0.000247105, 2) + " Ac";
                    }

                    dd.Text = mf.bnd.bndArr[i].isDriveThru.ToString();
                    ee.Text = mf.bnd.bndArr[i].isDriveAround.ToString();

                    if (Selectedreset == false && i == mf.bnd.boundarySelected)
                    {
                        aa.ForeColor = Color.Red;
                        bb.ForeColor = Color.Red;
                    }
                    else
                    {
                        aa.ForeColor = default(Color);
                        bb.ForeColor = default(Color);
                    }
                }
                else
                {
                    tableLayoutPanel1.SetColumnSpan(aa, 2);
                    aa.Text = string.Format("Create new Field", i + 1);

                    Control cc = tableLayoutPanel1.GetControlFromPosition(2, i);
                    cc.Visible = false;
                    Control dd = tableLayoutPanel1.GetControlFromPosition(3, i);
                    dd.Visible = false;
                    Control ee = tableLayoutPanel1.GetControlFromPosition(4, i);
                    ee.Visible = false;

                    if (Selectedreset == false && i == mf.bnd.boundarySelected)
                    {
                        aa.ForeColor = Color.Red;
                    }
                    else
                    {
                        aa.ForeColor = default(Color);
                    }
                    break;
                }
            }
        }

        private void FormBoundary_Load(object sender, EventArgs e)
        {
            btnLeftRight.Image = mf.bnd.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
            btnLeftRight.Enabled = false;
            btnOuter.Enabled = false;
            btnLoadBoundaryFromGE.Enabled = false;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;

            //update the list view with real data
            UpdateChart();
        }

        private void btnOuter_Click(object sender, EventArgs e)
        {
            btnLeftRight.Enabled = true;
            btnLoadBoundaryFromGE.Enabled = false;
            btnOuter.Enabled = false;
            btnGo.Enabled = true;

            UpdateChart();
        }


        void DriveThru_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b != null)
            {
                mf.bnd.bndArr[Convert.ToInt32(b.Name)].isDriveThru = !mf.bnd.bndArr[Convert.ToInt32(b.Name)].isDriveThru;
                UpdateChart();
            }
        }


        void OwnField_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b != null)
            {
                mf.bnd.bndArr[Convert.ToInt32(b.Name)].isOwnField = !mf.bnd.bndArr[Convert.ToInt32(b.Name)].isOwnField;
            
                UpdateChart();
            }
        }
        void DriveAround_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b != null)
            {
                mf.bnd.bndArr[Convert.ToInt32(b.Name)].isDriveAround = !mf.bnd.bndArr[Convert.ToInt32(b.Name)].isDriveAround;
                UpdateChart();
            }
        }

        void b_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b != null)
            {
                
                mf.bnd.boundarySelected = Convert.ToInt32(b.Name);

                Selectedreset = false;

                if (mf.bnd.bndArr.Count > mf.bnd.boundarySelected && mf.bnd.bndArr[mf.bnd.boundarySelected].isSet)
                {
                    btnOuter.Enabled = false;
                    btnLoadBoundaryFromGE.Enabled = false;
                    btnGo.Enabled = false;
                    btnDelete.Enabled = true;

                    btnLeftRight.Image = mf.bnd.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
                    btnLeftRight.Enabled = false;

                }
                else
                {
                    btnOuter.Enabled = true;
                    btnLoadBoundaryFromGE.Enabled = true;
                    btnGo.Enabled = false;
                    btnDelete.Enabled = false;
                    btnLeftRight.Image = mf.bnd.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
                    btnLeftRight.Enabled = false;
                }

            }
            UpdateChart();
        }
        
        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            mf.bnd.isOkToAddPoints = false;
            mf.turn.BuildTurnLines();
            mf.gf.BuildGeoFenceLines();
            mf.mazeGrid.BuildMazeGridArray();
        }

        private void btnLeftRight_Click(object sender, EventArgs e)
        {
            mf.bnd.isDrawRightSide = !mf.bnd.isDrawRightSide;
            btnLeftRight.Image = mf.bnd.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnLeftRight.Image = mf.bnd.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
            btnLeftRight.Enabled = false;
            btnOuter.Enabled = false;
            btnLoadBoundaryFromGE.Enabled = false;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;
            if (mf.bnd.bndArr.Count > mf.bnd.boundarySelected)
            {
                mf.bnd.bndArr.RemoveAt(mf.bnd.boundarySelected);
                mf.turn.turnArr.RemoveAt(mf.bnd.boundarySelected);
                mf.gf.geoFenceArr.RemoveAt(mf.bnd.boundarySelected);
            }
            mf.FileSaveBoundary();
            mf.bnd.boundarySelected = -1;
            Selectedreset = true;

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            UpdateChart();
        }

        private double easting, northing, latK, lonK;

        private void ResetAllBoundary()
        {
            mf.bnd.bndArr.Clear();
            mf.turn.turnArr.Clear();
            mf.gf.geoFenceArr.Clear();
            
            mf.FileSaveBoundary();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            
            UpdateChart();
            
            btnLeftRight.Image = mf.bnd.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
            btnLeftRight.Enabled = false;
            btnOuter.Enabled = false;
            btnLoadBoundaryFromGE.Enabled = false;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            ResetAllBoundary();
            
            mf.bnd.boundarySelected = -1;
            Selectedreset = true;

            mf.turn.BuildTurnLines();
            mf.gf.BuildGeoFenceLines();
            mf.mazeGrid.BuildMazeGridArray();
        }

        private void btnLoadMultiBoundaryFromGE_Click(object sender, EventArgs e)
        {
            Selectedreset = true;
            
            btnLeftRight.Image = mf.bnd.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
            btnLeftRight.Enabled = false;
            btnOuter.Enabled = false;
            btnLoadBoundaryFromGE.Enabled = false;
            btnGo.Enabled = false;
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
            int index;

            using (System.IO.StreamReader reader = new System.IO.StreamReader(fileAndDirectory))
            {
                int bndCount = 0;

                ResetAllBoundary();

                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    index = line.IndexOf("<coordinates>");

                    if (index != -1) bndCount++;
                }

                reader.DiscardBufferedData();
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                reader.BaseStream.Position = 0;

                if (bndCount > 0)
                {
                }

                try
                {
                    for (int i = 0; i < bndCount; i++)
                    {
                        //step thru the file till first boundary
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            index = line.IndexOf("<coord");
                            if (index != -1) break;
                        }

                        line = reader.ReadLine();
                        line = line.Trim();
                        char[] delimiterChars = { ' ', '\t', '\r', '\n' };
                        string[] numberSets = line.Split(delimiterChars);

                        //at least 3 points
                        if (numberSets.Length > 2)
                        {
                            mf.bnd.bndArr.Add(new CBoundaryLines());
                            mf.turn.turnArr.Add(new CTurnLines());
                            mf.gf.geoFenceArr.Add(new CGeoFenceLines());
                            //reset boundary
                            foreach (var item in numberSets)
                            {
                                string[] fix = item.Split(',');
                                double.TryParse(fix[0], NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);
                                double.TryParse(fix[1], NumberStyles.Float, CultureInfo.InvariantCulture, out latK);
                                double[] xy = mf.pn.DecDeg2UTM(latK, lonK);

                                //match new fix to current position
                                easting = xy[0] - mf.pn.utmEast;
                                northing = xy[1] - mf.pn.utmNorth;

                                //fix the azimuth error
                                easting = (Math.Cos(-mf.pn.convergenceAngle) * easting) - (Math.Sin(-mf.pn.convergenceAngle) * northing);
                                northing = (Math.Sin(-mf.pn.convergenceAngle) * easting) + (Math.Cos(-mf.pn.convergenceAngle) * northing);

                                //add the point to boundary
                                CBndPt bndPt = new CBndPt(easting, northing, 0);
                                mf.bnd.bndArr[i].bndLine.Add(bndPt);
                            }

                            //fix the points if there are gaps bigger then
                            mf.bnd.bndArr[i].CalculateBoundaryHeadings();
                            mf.bnd.bndArr[i].PreCalcBoundaryLines();
                            mf.bnd.bndArr[i].FixBoundaryLine(i, mf.vehicle.toolWidth);

                            //boundary area, pre calcs etc
                            mf.bnd.bndArr[i].CalculateBoundaryArea();
                            mf.bnd.bndArr[i].PreCalcBoundaryLines();
                            mf.bnd.bndArr[i].isSet = true;
                        }
                        else
                        {
                            mf.TimedMessageBox(2000, "Error reading KML", "Choose or Build a Different one");
                        }
                    }

                    mf.FileSaveBoundary();
                    UpdateChart();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void btnLoadBoundaryFromGE_Click(object sender, EventArgs e)
        {
            Selectedreset = true;

            btnLeftRight.Image = mf.bnd.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
            btnLeftRight.Enabled = false;
            btnOuter.Enabled = false;
            btnLoadBoundaryFromGE.Enabled = false;
            btnGo.Enabled = false;
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
            int index;

            using (System.IO.StreamReader reader = new System.IO.StreamReader(fileAndDirectory))
            {
                //int count = 0;

                //while (!reader.EndOfStream)
                //{
                //    line = reader.ReadLine();
                //    index = line.IndexOf("<coordinates>");

                //    if (index != -1) count++;
                //}

                //reader.DiscardBufferedData();
                //reader.BaseStream.Seek(0, SeekOrigin.Begin);
                //reader.BaseStream.Position = 0;

                bool done = false;
                try
                {
                    while (!reader.EndOfStream && !done)
                    {
                        line = reader.ReadLine();
                        index = line.IndexOf("coord");

                        if (index != -1)
                        {
                            line = reader.ReadLine();
                            line = line.Trim();
                            char[] delimiterChars = { ' ', '\t', '\r', '\n' };
                            string[] numberSets = line.Split(delimiterChars);
                            done = true;

                            //at least 3 points
                            if (numberSets.Length > 2)
                            {
                                mf.bnd.bndArr.Add(new CBoundaryLines());
                                mf.turn.turnArr.Add(new CTurnLines());
                                mf.gf.geoFenceArr.Add(new CGeoFenceLines());
                                //reset boundary
                                //mf.bnd.bndArr[mf.bnd.boundarySelected].ResetBoundary();
                                foreach (var item in numberSets)
                                {
                                    string[] fix = item.Split(',');
                                    double.TryParse(fix[0], NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);
                                    double.TryParse(fix[1], NumberStyles.Float, CultureInfo.InvariantCulture, out latK);
                                    double[] xy = mf.pn.DecDeg2UTM(latK, lonK);

                                    //match new fix to current position
                                    easting = xy[0] - mf.pn.utmEast;
                                    northing = xy[1] - mf.pn.utmNorth;

                                    //fix the azimuth error
                                    easting = (Math.Cos(-mf.pn.convergenceAngle) * easting) - (Math.Sin(-mf.pn.convergenceAngle) * northing);
                                    northing = (Math.Sin(-mf.pn.convergenceAngle) * easting) + (Math.Cos(-mf.pn.convergenceAngle) * northing);

                                    //add the point to boundary
                                    CBndPt bndPt = new CBndPt(easting, northing, 0);
                                    mf.bnd.bndArr[mf.bnd.boundarySelected].bndLine.Add(bndPt);
                                }

                                //fix the points if there are gaps bigger then
                                mf.bnd.bndArr[mf.bnd.boundarySelected].CalculateBoundaryHeadings();
                                mf.bnd.bndArr[mf.bnd.boundarySelected].PreCalcBoundaryLines();
                                mf.bnd.bndArr[mf.bnd.boundarySelected].FixBoundaryLine(mf.bnd.boundarySelected, mf.vehicle.toolWidth);

                                //boundary area, pre calcs etc
                                mf.bnd.bndArr[mf.bnd.boundarySelected].CalculateBoundaryArea();
                                mf.bnd.bndArr[mf.bnd.boundarySelected].PreCalcBoundaryLines();
                                mf.bnd.bndArr[mf.bnd.boundarySelected].isSet = true;

                                {
                                    mf.FileSaveBoundary();
                                }
                            }
                            else
                            {
                                mf.TimedMessageBox(2000, "Error reading KML", "Choose or Build a Different one");
                            }
                        }
                    }

                    UpdateChart();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void btnOpenGoogleEarth_Click(object sender, EventArgs e)
        {
            //save new copy of kml with selected flag and view in GoogleEarth
            mf.FileMakeCurrentKML(mf.pn.latitude, mf.pn.longitude);
            System.Diagnostics.Process.Start(mf.fieldsDirectory + mf.currentFieldDirectory + "\\CurrentPosition.KML");
        }
    }
}
