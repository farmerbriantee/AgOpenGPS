using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormBoundary : Form
    {
        private readonly FormGPS mf = null;

        public FormBoundary(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void UpdateChart()
        {
            if (mf.isMetric)
            {
                //outer metric
                lvLines.Items[0].SubItems[2].Text = "NA";
                if (mf.bnd.bndArr[0].isSet) lvLines.Items[0].SubItems[1].Text = Math.Round(mf.bnd.bndArr[0].area * 0.0001, 2) + " Ha";
                else lvLines.Items[0].SubItems[1].Text = "*";

                //inner metric
                for (int i = 1; i < FormGPS.MAXBOUNDARIES; i++)
                {
                    if (mf.bnd.bndArr[i].isSet)
                    {
                        lvLines.Items[i].SubItems[2].Text = mf.bnd.bndArr[i].isDriveThru.ToString();
                        lvLines.Items[i].SubItems[3].Text = mf.bnd.bndArr[i].isDriveAround.ToString();
                        lvLines.Items[i].SubItems[1].Text = Math.Round(mf.bnd.bndArr[i].area * 0.0001, 2) + " Ha";
                    }
                    else
                    {
                        lvLines.Items[i].SubItems[2].Text = "-";
                        lvLines.Items[i].SubItems[3].Text = "-";
                        lvLines.Items[i].SubItems[1].Text = "*";
                    }
                }
            }
            else
            {
                //outer
                lvLines.Items[0].SubItems[2].Text = "NA";
                if (mf.bnd.bndArr[0].isSet) lvLines.Items[0].SubItems[1].Text = Math.Round(mf.bnd.bndArr[0].area * 0.000247105, 2) + " Ac";
                else lvLines.Items[0].SubItems[1].Text = "*";

                //inner
                for (int i = 1; i < FormGPS.MAXBOUNDARIES; i++)
                {
                    if (mf.bnd.bndArr[i].isSet)
                    {
                        lvLines.Items[i].SubItems[2].Text = mf.bnd.bndArr[i].isDriveThru.ToString();
                        lvLines.Items[i].SubItems[3].Text = mf.bnd.bndArr[i].isDriveAround.ToString();
                        lvLines.Items[i].SubItems[1].Text = Math.Round(mf.bnd.bndArr[i].area * 0.000247105, 2) + " Ac";
                    }
                    else
                    {
                        lvLines.Items[i].SubItems[2].Text = "-";
                        lvLines.Items[i].SubItems[3].Text = "-";
                        lvLines.Items[i].SubItems[1].Text = "*";
                    }
                }
            }
        }

        private void FormBoundary_Load(object sender, EventArgs e)
        {
            btnLeftRight.Image = Properties.Resources.BoundaryRight;
            btnLeftRight.Enabled = false;
            btnOuter.Enabled = false;
            btnLoadBoundaryFromGE.Enabled = false;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;
            cboxDriveThru.Visible = false;
            label2.Visible = false;
            cboxDriveAround.Visible = false;
            label6.Visible = false;

            //create a 6 row by 3 column ListView
            ListViewItem itm;
            const string line = "Outer,False,False,0.0";
            string[] words = line.Split(',');
            itm = new ListViewItem(words);
            lvLines.Items.Add(itm);
            for (int i = 1; i < FormGPS.MAXBOUNDARIES; i++)
            {
                words[0] = "Inner " + i.ToString();
                itm = new ListViewItem(words);
                lvLines.Items.Add(itm);
            }

            //update the list view with real data
            UpdateChart();
        }

        private void cboxSelectBoundary_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.bnd.boundarySelected = cboxSelectBoundary.SelectedIndex;

            if (mf.bnd.boundarySelected == 0)
            {
                if (mf.bnd.bndArr[0].isSet)
                {
                    btnOuter.Enabled = false;
                    btnLoadBoundaryFromGE.Enabled = false;
                    btnGo.Enabled = false;
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnOuter.Enabled = true;
                    btnLoadBoundaryFromGE.Enabled = true;
                    btnGo.Enabled = false;
                    btnDelete.Enabled = false;
                    cboxSelectBoundary.Enabled = false;
                }
            }
            //must be an inner selected
            else if (mf.bnd.bndArr[0].isSet)
            {
                if (mf.bnd.bndArr[mf.bnd.boundarySelected].isSet)
                {
                    btnOuter.Enabled = false;
                    btnLoadBoundaryFromGE.Enabled = false;
                    btnGo.Enabled = false;
                    btnDelete.Enabled = true;
                }
                else
                {
                    cboxSelectBoundary.Enabled = false;
                    cboxDriveThru.Visible = true;
                    label2.Visible = true;
                    btnDelete.Enabled = false;
                }
            }
            else
            {
                mf.TimedMessageBox(1000, "No Outer Boundary", "Create Outer Boundary First");
            }

            UpdateChart();
        }

        private void cboxDriveThru_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.bnd.bndArr[mf.bnd.boundarySelected].isDriveThru = cboxDriveThru.SelectedIndex != 0;
            cboxDriveThru.Visible = false;
            label2.Visible = false;
            cboxDriveAround.Visible = true;
            label6.Visible = true;
            UpdateChart();
        }

        private void cboxDriveAround_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.bnd.bndArr[mf.bnd.boundarySelected].isDriveAround = cboxDriveAround.SelectedIndex != 0;
            cboxDriveAround.Visible = false;
            label6.Visible = false;

            btnOuter.Enabled = true;
            btnLoadBoundaryFromGE.Enabled = true;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;
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

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            mf.bnd.bndArr[mf.bnd.boundarySelected].isOkToAddPoints = false;
            mf.turn.BuildTurnLines();
            mf.gf.BuildGeoFenceLines();
            mf.mazeGrid.BuildMazeGridArray();
        }

        private void btnLeftRight_Click(object sender, EventArgs e)
        {
            mf.bnd.bndArr[mf.bnd.boundarySelected].isDrawRightSide = !mf.bnd.bndArr[mf.bnd.boundarySelected].isDrawRightSide;

            btnLeftRight.Image = mf.bnd.bndArr[mf.bnd.boundarySelected].isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnLeftRight.Enabled = false;
            btnOuter.Enabled = false;
            btnLoadBoundaryFromGE.Enabled = false;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;
            cboxSelectBoundary.Enabled = true;
            {
                mf.bnd.bndArr[mf.bnd.boundarySelected].ResetBoundary();
                mf.FileSaveBoundary();
            }
            btnLeftRight.Image = Properties.Resources.BoundaryRight;
            UpdateChart();
        }

        private void btnToggleDriveThru_Click(object sender, EventArgs e)
        {
            if (mf.bnd.boundarySelected != 0 && mf.bnd.bndArr[mf.bnd.boundarySelected].isSet)
            {
                mf.bnd.bndArr[mf.bnd.boundarySelected].isDriveThru = !mf.bnd.bndArr[mf.bnd.boundarySelected].isDriveThru;
                UpdateChart();

                mf.FileSaveBoundary();
            }
        }

        private void btnToggleDriveAround_Click(object sender, EventArgs e)
        {
            if (mf.bnd.boundarySelected != 0 && mf.bnd.bndArr[mf.bnd.boundarySelected].isSet)
            {
                mf.bnd.bndArr[mf.bnd.boundarySelected].isDriveAround = !mf.bnd.bndArr[mf.bnd.boundarySelected].isDriveAround;
                UpdateChart();

                mf.FileSaveBoundary();
            }
        }

        private double easting, northing, latK, lonK;

        private void ResetAllBoundary()
        {
            for (int j = 0; j < FormGPS.MAXBOUNDARIES; j++) mf.bnd.bndArr[j].ResetBoundary();
            mf.FileSaveBoundary();
            UpdateChart();
            cboxSelectBoundary.SelectedIndex = 0;
            cboxSelectBoundary.Enabled = true;

            btnLeftRight.Enabled = false;
            btnOuter.Enabled = false;
            btnLoadBoundaryFromGE.Enabled = false;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            ResetAllBoundary();
            mf.bnd.bndArr[mf.bnd.boundarySelected].isOkToAddPoints = false;
            mf.turn.BuildTurnLines();
            mf.gf.BuildGeoFenceLines();
            //Task.Run(() => mf.mazeGrid.BuildMazeGridArray());
            mf.mazeGrid.BuildMazeGridArray();
        }

        private void btnLoadMultiBoundaryFromGE_Click(object sender, EventArgs e)
        {
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
                            mf.bnd.bndArr[i].isDriveAround = true;
                        }
                        else
                        {
                            mf.TimedMessageBox(2000, "Error reading KML", "Choose or Build a Different one");
                        }
                    }

                    mf.FileSaveBoundary();
                    UpdateChart();
                    cboxSelectBoundary.Enabled = true;
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void btnLoadBoundaryFromGE_Click(object sender, EventArgs e)
        {
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
                                //reset boundary
                                mf.bnd.bndArr[mf.bnd.boundarySelected].ResetBoundary();
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
                    cboxSelectBoundary.Enabled = true;
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