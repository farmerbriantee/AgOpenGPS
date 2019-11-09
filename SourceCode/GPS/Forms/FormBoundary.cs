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
        private bool MultipleFieldLocked = true;
        private readonly FormGPS mf = null;
        private int position = 0;
        private bool scroll = false;
        private double viewableRatio = 0;
        private double contentHeight = 0;
        private int oldY = 0;
        private double thumbHeight = 0;
        private int scrollmaxheight = 0;
        private int startscroll = 0;
        private int items = 0;
        private int rowheight = 0;


        public FormBoundary(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
            scrollmaxheight = button4.Size.Height;
            startscroll = button4.Location.Y;

            rowheight = (int)tableLayoutPanel1.RowStyles[0].Height;
            items = (int)(tableLayoutPanel1.Height / rowheight + 0.5)-1;

        }


        void UpdateScroll(double pos)
        {
            contentHeight = (mf.bnd.bndArr.Count+1) * rowheight;
            viewableRatio = tableLayoutPanel1.Size.Height / contentHeight;
            if (viewableRatio >= 1)
            {
                button4.Size = new Size(rowheight, scrollmaxheight);
                button4.Location = new Point(552, startscroll);
            }
            else
            {
                thumbHeight = (scrollmaxheight * viewableRatio < rowheight*2) ? rowheight*2 : (scrollmaxheight * viewableRatio);
                button4.Size = new Size(40, (int)(thumbHeight + 0.5));
                if (pos < 0)
                {
                    button4.Location = new Point(552, (int)(startscroll + position * ((scrollmaxheight - thumbHeight) / (mf.bnd.bndArr.Count - items)) + 0.5));
                }
                else
                {
                    button4.Location = new Point(552, (int)(startscroll + pos));
                }
            }
        }

        private void UpdateChart()
        {
            int field = 1;
            int inner = 1;

            for (int i = 0; i < mf.bnd.bndArr.Count + 1 && i < position+9; i++)
            {
                if (i < position && i < mf.bnd.bndArr.Count)
                {
                    if (mf.bnd.bndArr[i].isOwnField)
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
                        var a = new Button();
                        a.Margin = new Padding(0);
                        a.Size = new Size(280, 40);
                        a.Name = string.Format("{0}", i - position);
                        a.TextAlign = ContentAlignment.MiddleCenter;
                        a.Click += b_Click;
                        a.FlatStyle = FlatStyle.Flat;
                        a.FlatAppearance.BorderColor = BackColor;
                        a.FlatAppearance.MouseOverBackColor = BackColor;
                        a.FlatAppearance.MouseDownBackColor = BackColor;

                        aa = a;

                        var c = new Button();
                        c.Margin = new Padding(0);
                        c.Size = new System.Drawing.Size(95, 40);
                        c.Name = string.Format("{0}", i - position);
                        a.TextAlign = ContentAlignment.MiddleCenter;
                        c.Click += OwnField_Click;

                        var d = new Button();
                        d.Margin = new Padding(0);
                        d.Size = new System.Drawing.Size(80, 40);
                        d.Name = string.Format("{0}", i - position);
                        a.TextAlign = ContentAlignment.MiddleCenter;
                        d.Click += DriveThru_Click;

                        var e = new Button();
                        e.Margin = new Padding(0);
                        e.Size = new System.Drawing.Size(80, 40);
                        e.Name = string.Format("{0}", i - position);
                        a.TextAlign = ContentAlignment.MiddleCenter;
                        e.Click += DriveAround_Click;
                        tableLayoutPanel1.Controls.Add(a, 0, i - position);
                        tableLayoutPanel1.Controls.Add(c, 2, i - position);
                        tableLayoutPanel1.Controls.Add(d, 3, i - position);
                        tableLayoutPanel1.Controls.Add(e, 4, i - position);
                    }

                    if (i < mf.bnd.bndArr.Count && mf.bnd.bndArr[i].isSet)
                    {
                        tableLayoutPanel1.SetColumnSpan(aa, 1);

                        Control bb = tableLayoutPanel1.GetControlFromPosition(1, i - position);
                        if (bb == null)
                        {
                            var b = new Button();
                            b.Margin = new Padding(0);
                            b.Size = new System.Drawing.Size(150, 40);
                            b.Name = string.Format("{0}", i - position);
                            b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            b.Click += b_Click;
                            b.FlatStyle = FlatStyle.Flat;
                            b.FlatAppearance.BorderColor = BackColor;
                            b.FlatAppearance.MouseOverBackColor = BackColor;
                            b.FlatAppearance.MouseDownBackColor = BackColor;
                            tableLayoutPanel1.Controls.Add(b, 1, i - position);
                            bb = b;
                        }
                        Control cc = tableLayoutPanel1.GetControlFromPosition(2, i - position);
                        cc.Visible = true;
                        Control dd = tableLayoutPanel1.GetControlFromPosition(3, i - position);
                        dd.Visible = true;
                        Control ee = tableLayoutPanel1.GetControlFromPosition(4, i - position);
                        ee.Visible = true;

                        Font backupfont = new Font(aa.Font.FontFamily, 18F, FontStyle.Bold);

                        // LOCK MultipleField
                        if (MultipleFieldLocked)
                        {
                            cc.Enabled = false;
                        }
                        else
                        {
                            cc.Enabled = true;
                        }
                        // LOCK MultipleField

                        if (mf.bnd.bndArr[i].isOwnField)
                        {
                            cc.Text = "Field";
                            aa.Text = string.Format("Field {0}", field);
                            field += 1;
                            aa.Font = backupfont;
                            dd.Enabled = false;
                            ee.Enabled = false;
                            mf.bnd.bndArr[i].isDriveThru = false;
                            mf.bnd.bndArr[i].isDriveAround = false;
                        }
                        else
                        {
                            cc.Text = "Inner";
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

                        dd.Text = mf.bnd.bndArr[i].isDriveThru ? "Yes" : "No";
                        ee.Text = mf.bnd.bndArr[i].isDriveAround ? "Yes" : "No";

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
                        Control bb = tableLayoutPanel1.GetControlFromPosition(1, i - position);
                        if (!(bb == null || bb == aa))
                        {
                            bb.Dispose();
                        }

                        tableLayoutPanel1.SetColumnSpan(aa, 2);
                        aa.Text = string.Format("1. Create Boundary", i - position + 1);


                        Control cc = tableLayoutPanel1.GetControlFromPosition(2, i - position);
                        cc.Visible = false;
                        Control dd = tableLayoutPanel1.GetControlFromPosition(3, i - position);
                        dd.Visible = false;
                        Control ee = tableLayoutPanel1.GetControlFromPosition(4, i - position);
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
            UpdateScroll(-1);
        }

        private void btnOuter_Click(object sender, EventArgs e)
        {
            btnLeftRight.Enabled = true;
            btnLoadBoundaryFromGE.Enabled = false;
            btnLoadMultiBoundaryFromGE.Enabled = false;
            btnOuter.Enabled = false;
            btnGo.Enabled = true;

            UpdateChart();
        }


        void DriveThru_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b != null)
            {
                mf.bnd.bndArr[Convert.ToInt32(b.Name) + position].isDriveThru = !mf.bnd.bndArr[Convert.ToInt32(b.Name) + position].isDriveThru;
                UpdateChart();
            }
        }


        void OwnField_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b != null)
            {
                mf.bnd.bndArr[Convert.ToInt32(b.Name) + position].isOwnField = !mf.bnd.bndArr[Convert.ToInt32(b.Name) + position].isOwnField;
                //MultipleFieldLocked = true;
                UpdateChart();
            }
        }
        void DriveAround_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b != null)
            {
                mf.bnd.bndArr[Convert.ToInt32(b.Name) + position].isDriveAround = !mf.bnd.bndArr[Convert.ToInt32(b.Name) + position].isDriveAround;
                UpdateChart();
            }
        }

        void b_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b != null)
            {

                mf.bnd.boundarySelected = Convert.ToInt32(b.Name) + position;

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
            if (mf.bnd.bndArr.Count - 10 < 0) position = 0;
            else if (position > mf.bnd.bndArr.Count-10) position--;

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

            UpdateChart();
            UpdateScroll(-1);
        }

        private double easting, northing, latK, lonK;

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
            UpdateScroll(-1);

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

        private void button1_Click(object sender, EventArgs e)
        {
            MultipleFieldLocked = !MultipleFieldLocked;
            UpdateChart();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (position + items < mf.bnd.bndArr.Count) position++;
            UpdateChart();
            UpdateScroll(-1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (position > 0) position--;
            UpdateChart();
            UpdateScroll(-1);
        }
        void MouseWheel_scroll(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (position > 0) position -= (e.Delta / 120);
            }
            else
            {
                if (position + items < mf.bnd.bndArr.Count) position -= (e.Delta / 120);
            }
            UpdateChart();
            UpdateScroll(-1);
        }

        void Mouse_Down(object sender, MouseEventArgs e)
        {
            
            oldY = MousePosition.Y;
            scroll = true;
        }

        void Mouse_Up(object sender, MouseEventArgs e)
        {
            scroll = false;
        }

        void Mouse_Leave(object sender, EventArgs e)
        {
            scroll = false;
        }

        void Mouse_Move(object sender, MouseEventArgs e)
        {
            if (scroll == true && viewableRatio < 1)
            {
                if (!(oldY == MousePosition.Y))
                {
                    if (button4.Location.Y + (MousePosition.Y - oldY) > startscroll)
                    {
                        if ((button4.Location.Y + (MousePosition.Y - oldY)) < (startscroll + scrollmaxheight - thumbHeight))
                        {

                            position = (int)(((button4.Location.Y + MousePosition.Y - oldY) - startscroll) / ((scrollmaxheight - thumbHeight) / (mf.bnd.bndArr.Count - items)) + 0.5);



                            UpdateScroll((button4.Location.Y + (MousePosition.Y - oldY) - startscroll));
                        }
                        else
                        {
                            position = mf.bnd.bndArr.Count - items;
                            UpdateScroll(scrollmaxheight - thumbHeight);
                        }
                    }
                    else
                    {
                        position = 0;
                        UpdateScroll(0);
                    }
                    UpdateChart();
                    oldY = MousePosition.Y;
                }


            }
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

                            if (i == 0) mf.bnd.bndArr[i].isOwnField = true;
                            else mf.bnd.bndArr[i].isOwnField = false;
                        }
                        else
                        {
                            mf.TimedMessageBox(2000, "Error reading KML", "Choose or Build a Different one");
                        }
                    }

                    mf.FileSaveBoundary();
                    UpdateChart();
                    UpdateScroll(-1);
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
                                if (mf.bnd.boundarySelected == 0) mf.bnd.bndArr[mf.bnd.boundarySelected].isOwnField = true;
                                else mf.bnd.bndArr[mf.bnd.boundarySelected].isOwnField = false;

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
                    UpdateScroll(-1);
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
