using System;
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

        private double easting, norting, latK, lonK;

        public FormBoundary(Form callingForm)
        {
            mf = callingForm as FormGPS;

            //winform initialization
            InitializeComponent();

            this.Text = gStr.gsStartDeleteABoundary;

            //Column Header
            Boundary.Text = "Bounds";
            Thru.Text = gStr.gsDriveThru;
            Area.Text = gStr.gsArea;
            btnDelete.Enabled = false;

        }


        private void FormBoundary_Load(object sender, EventArgs e)
        {
            this.Size = new Size(566, 377);


            //update the list view with real data
            UpdateChart();

            panelMain.Dock = DockStyle.Fill;
            panelChoose.Dock = DockStyle.Fill;
            panelKML.Dock = DockStyle.Fill;

            panelMain.Visible = true;
            panelChoose.Visible = false;
            panelKML.Visible = false;
            mf.CloseTopMosts();

        }
        private void UpdateChart()
        {
            int inner = 1;

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            Font backupfont = new Font(Font.FontFamily, 18F, FontStyle.Bold);

            for (int i = 0; i < mf.bnd.bndArr.Count && i < 6; i++)
            {
                if (mf.bnd.bndArr[i].isSet)
                {
                    //outer inner
                    Button a = new Button
                    {
                        Margin = new Padding(6),
                        Size = new Size(150, 35),
                        Name = i.ToString(),
                        TextAlign = ContentAlignment.MiddleCenter,
                        //ForeColor = System.Drawing.SystemColors.ButtonFace
                    };
                    a.Click += B_Click;
                    a.BackColor = System.Drawing.SystemColors.ButtonFace;
                    //a.Font = backupfont;
                    //a.FlatStyle = FlatStyle.Flat;
                    //a.FlatAppearance.BorderColor = Color.Cyan;
                    //a.BackColor = Color.Transparent;
                    //a.FlatAppearance.MouseOverBackColor = BackColor;
                    //a.FlatAppearance.MouseDownBackColor = BackColor;


                    //area
                    Button b = new Button
                    {
                        Margin = new Padding(6),
                        Size = new System.Drawing.Size(150, 35),
                        Name = i.ToString(),
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        //ForeColor = System.Drawing.SystemColors.ButtonFace
                    };
                    b.Click += B_Click;
                    b.BackColor = System.Drawing.SystemColors.ButtonFace;
                    //b.FlatStyle = FlatStyle.Flat;
                    //b.Font = backupfont;
                    //b.FlatAppearance.BorderColor = BackColor;
                    //b.FlatAppearance.MouseOverBackColor = BackColor;
                    //b.FlatAppearance.MouseDownBackColor = BackColor;

                    //drive thru
                    Button d = new Button
                    {
                        Margin = new Padding(6),
                        Size = new System.Drawing.Size(80, 35),
                        Name = i.ToString(),
                        TextAlign = ContentAlignment.MiddleCenter,
                        //ForeColor = System.Drawing.SystemColors.ButtonFace
                        //Font = backupfont
                    };
                    d.Click += DriveThru_Click;
                    d.BackColor = System.Drawing.SystemColors.ButtonFace;
                    d.Visible = true;

                    tableLayoutPanel1.Controls.Add(a, 0, i);
                    tableLayoutPanel1.Controls.Add(b, 1, i);
                    tableLayoutPanel1.Controls.Add(d, 2, i);

                    if (i == 0)
                    {
                        //cc.Text = "Outer";
                        mf.bnd.bndArr[i].isDriveThru = false;
                        mf.bnd.bndArr[i].isDriveAround = false;
                        a.Text = string.Format(gStr.gsOuter);
                        //a.Font = backupfont;
                        d.Text = mf.bnd.bndArr[i].isDriveThru ? "--" : "--";
                        d.Enabled = false;
                        d.Anchor = System.Windows.Forms.AnchorStyles.None;
                        a.Anchor = System.Windows.Forms.AnchorStyles.None;
                        b.Anchor = System.Windows.Forms.AnchorStyles.None;
                        //d.BackColor = Color.Transparent;
                    }
                    else
                    {
                        //cc.Text = "Inner";
                        inner += 1;
                        a.Text = string.Format(gStr.gsInner + " {0}", inner);
                        //a.Font = backupfont;
                        d.Text = mf.bnd.bndArr[i].isDriveThru ? "Yes" : "No";
                        d.Anchor = System.Windows.Forms.AnchorStyles.None;
                        a.Anchor = System.Windows.Forms.AnchorStyles.None;
                        b.Anchor = System.Windows.Forms.AnchorStyles.None;
                        //d.BackColor = Color.Transparent;
                    }

                    if (mf.isMetric)
                    {
                        b.Text = Math.Round(mf.bnd.bndArr[i].area * 0.0001, 2).ToString() + " Ha";
                    }
                    else
                    {
                        b.Text = Math.Round(mf.bnd.bndArr[i].area * 0.000247105, 2) + " Ac";
                    }

                    if (Selectedreset == false && i == mf.bnd.boundarySelected)
                    {
                        a.ForeColor = Color.OrangeRed;
                        b.ForeColor = Color.OrangeRed;
                    }
                    else
                    {
                        a.ForeColor = System.Drawing.SystemColors.ControlText;
                        b.ForeColor = System.Drawing.SystemColors.ControlText;
                    }
                }
            }
        }

        private void DriveThru_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                mf.bnd.bndArr[Convert.ToInt32(b.Name)].isDriveThru = !mf.bnd.bndArr[Convert.ToInt32(b.Name)].isDriveThru;
                UpdateChart();
                mf.turn.BuildTurnLines();
            }
        }

        private void DriveAround_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                mf.bnd.bndArr[Convert.ToInt32(b.Name)].isDriveAround = !mf.bnd.bndArr[Convert.ToInt32(b.Name)].isDriveAround;
                UpdateChart();
            }
        }

        private void B_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {

                mf.bnd.boundarySelected = Convert.ToInt32(b.Name);

                if (mf.bnd.boundarySelected == 0 && mf.bnd.bndArr.Count > 1)
                {
                    return;
                }

                Selectedreset = false;

                if (mf.bnd.bndArr.Count > mf.bnd.boundarySelected && mf.bnd.bndArr[mf.bnd.boundarySelected].isSet)
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                    btnDeleteAll.Enabled = false;
                }

            }
            UpdateChart();
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            mf.bnd.isOkToAddPoints = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result3 = MessageBox.Show(gStr.gsCompletelyDeleteBoundary,
                gStr.gsDeleteForSure,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result3 == DialogResult.Yes)
            {

                btnDelete.Enabled = false;

                if (mf.bnd.bndArr.Count > mf.bnd.boundarySelected)
                {
                    mf.bnd.bndArr.RemoveAt(mf.bnd.boundarySelected);
                    mf.turn.turnArr.RemoveAt(mf.bnd.boundarySelected);
                }

                mf.FileSaveBoundary();

                mf.bnd.boundarySelected = -1;
                Selectedreset = true;
                mf.fd.UpdateFieldBoundaryGUIAreas();
                mf.turn.BuildTurnLines();
                UpdateChart();
            }
            else
            {
                mf.TimedMessageBox(1500, gStr.gsNothingDeleted, gStr.gsActionHasBeenCancelled);
            }
        }

        private void ResetAllBoundary()
        {
            mf.bnd.bndArr.Clear();
            mf.turn.turnArr.Clear();
            mf.FileSaveBoundary();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            UpdateChart();
            mf.turn.BuildTurnLines();
            btnDelete.Enabled = false;
        }

        private void btnOpenGoogleEarth_Click(object sender, EventArgs e)
        {
            //save new copy of kml with selected flag and view in GoogleEarth

            mf.FileMakeKMLFromCurrentPosition(mf.pn.latitude, mf.pn.longitude);
            System.Diagnostics.Process.Start(mf.fieldsDirectory + mf.currentFieldDirectory + "\\CurrentPosition.KML");
            Close();

        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult result3 = MessageBox.Show(gStr.gsCompletelyDeleteBoundary,
                gStr.gsDeleteForSure,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result3 == DialogResult.Yes)
            {

                ResetAllBoundary();

                mf.bnd.boundarySelected = -1;
                Selectedreset = true;

                mf.bnd.isOkToAddPoints = false;
                mf.fd.UpdateFieldBoundaryGUIAreas();
            }
            else
            {
                mf.TimedMessageBox(1500, gStr.gsNothingDeleted, gStr.gsActionHasBeenCancelled);
            }

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            mf.bnd.isOkToAddPoints = false;

            panelMain.Visible = true;
            panelChoose.Visible = false;
            panelKML.Visible = false;

            this.Size = new System.Drawing.Size(566, 377);

            UpdateChart();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mf.bnd.boundarySelected = mf.bnd.bndArr.Count;

            Selectedreset = false;

            panelMain.Visible = false;
            panelKML.Visible = false;
            panelChoose.Visible = true;
            panelChoose.Dock = DockStyle.Fill;

            this.Size = new Size(260, 377);
        }

        private void btnLoadBoundaryFromGE_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Selectedreset = true;

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

                string coordinates = null;
                int startIndex;
                int i = 0;

                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {

                    if (button.Name == "btnLoadMultiBoundaryFromGE") ResetAllBoundary();
                    else i = mf.bnd.boundarySelected;

                    try
                    {
                        while (!reader.EndOfStream)
                        {
                            //start to read the file
                            string line = reader.ReadLine();

                            startIndex = line.IndexOf("<coordinates>");

                            if (startIndex != -1)
                            {
                                while (true)
                                {
                                    int endIndex = line.IndexOf("</coordinates>");

                                    if (endIndex == -1)
                                    {
                                        //just add the line
                                        if (startIndex == -1) coordinates += line.Substring(0);
                                        else coordinates += line.Substring(startIndex + 13);
                                    }
                                    else
                                    {
                                        if (startIndex == -1) coordinates += line.Substring(0, endIndex);
                                        else coordinates += line.Substring(startIndex + 13, endIndex - (startIndex + 13));
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

                                    foreach (string item in numberSets)
                                    {
                                        string[] fix = item.Split(',');
                                        double.TryParse(fix[0], NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);
                                        double.TryParse(fix[1], NumberStyles.Float, CultureInfo.InvariantCulture, out latK);

                                        mf.pn.ConvertWGS84ToLocal(latK, lonK, out norting, out easting);

                                        //add the point to boundary
                                        vec3 bndPt = new vec3(easting, norting, 0);
                                        mf.bnd.bndArr[i].bndLine.Add(bndPt);
                                    }

                                    //build the boundary, make sure is clockwise for outer counter clockwise for inner
                                    bool isCW = mf.bnd.bndArr[i].CalculateBoundaryArea();
                                    if (mf.bnd.boundarySelected == 0 && isCW)
                                    {
                                        mf.bnd.bndArr[i].ReverseWinding();
                                    }

                                    //inner boundaries
                                    if (mf.bnd.boundarySelected > 0 && !isCW)
                                    {
                                        mf.bnd.bndArr[i].ReverseWinding();
                                    }

                                    mf.bnd.bndArr[i].FixBoundaryLine(i);
                                    mf.bnd.bndArr[i].PreCalcBoundaryEarLines();
                                    mf.bnd.bndArr[i].PreCalcBoundaryLines();
                                    mf.bnd.bndArr[i].isSet = true;
                                    mf.fd.UpdateFieldBoundaryGUIAreas();

                                    mf.btnMakeLinesFromBoundary.Visible = true;


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
                        mf.turn.BuildTurnLines();
                        mf.btnMakeLinesFromBoundary.Visible = true;
                        mf.fd.UpdateFieldBoundaryGUIAreas();
                        UpdateChart();
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
            mf.bnd.isOkToAddPoints = false;

            panelMain.Visible = true;
            panelChoose.Visible = false;
            panelKML.Visible = false;

            this.Size = new Size(566, 377);

            UpdateChart();

        }

        private void btnDriveOrExt_Click(object sender, EventArgs e)
        {
            panelMain.Visible = false;
            panelChoose.Visible = false;
            panelKML.Visible = false;
        }

        private void btnGetKML_Click(object sender, EventArgs e)
        {
            panelMain.Visible = false;
            panelChoose.Visible = false;
            panelKML.Visible = true;
        }
    }
}
