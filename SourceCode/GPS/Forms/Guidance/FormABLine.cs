//Please, if you use this, share the improvements

using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AgOpenGPS
{
    public partial class FormABLine : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        private bool isClosing;
        private int selectedItem = -1;

        private double easting, norting, latK, lonK;

        public FormABLine(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();
            this.Text = gStr.gsABline;
        }

        private void FormABLine_Load(object sender, EventArgs e)
        {

            panelPick.Top = 3; panelPick.Left = 3;
            panelAPlus.Top = 3; panelAPlus.Left = 3;
            panelName.Top = 3; panelName.Left = 3;
            panelKML.Top = 3; panelKML.Left = 3;
            panelEditName.Top = 3; panelEditName.Left = 3;

            panelPick.Visible = true;
            panelAPlus.Visible = false;
            panelName.Visible = false;
            panelEditName.Visible = false;
            panelKML.Visible = false;

            this.Size = new System.Drawing.Size(620, 475);

            mf.ABLine.isABLineBeingSet = false;
            selectedItem = -1;

            Location = Properties.Settings.Default.setWindow_abLineCreate;

            UpdateTable();
        }

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
                };
                a.Click += A_Click;

                if (mf.trk.gArr[i].isVisible)
                    a.BackColor = System.Drawing.Color.Green;
                else
                    a.BackColor = System.Drawing.Color.Red;

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

        private void btnCancel_APlus_Click(object sender, EventArgs e)
        {
            panelPick.Visible = true;
            panelAPlus.Visible = false;
            panelEditName.Visible = false;
            panelName.Visible = false;
            panelKML.Visible = false;

            this.Size = new System.Drawing.Size(620, 475);

            mf.ABLine.isABLineBeingSet = false;
            btnBPoint.BackColor = System.Drawing.Color.Transparent;
        }

        private void btnAPoint_Click(object sender, EventArgs e)
        {
            vec3 fix = new vec3(mf.pivotAxlePos);

            mf.ABLine.desPointA.easting = fix.easting + Math.Cos(fix.heading) * mf.tool.offset;
            mf.ABLine.desPointA.northing = fix.northing - Math.Sin(fix.heading) * mf.tool.offset;
            if (fix.heading >= glm.twoPI) fix.heading -= glm.twoPI;
            mf.ABLine.desHeading = fix.heading;

            mf.ABLine.desPointB.easting = 99999;
            mf.ABLine.desPointB.northing = 99999;

            nudHeading.Enabled = true;

            nudHeading.Value = (decimal)(glm.toDegrees(mf.ABLine.desHeading));

            BuildDesLine();

            btnBPoint.Enabled = true;
            btnAPoint.Enabled = false;

            btnEnter_APlus.Enabled = true;
            mf.ABLine.isABLineBeingSet = true;
        }

        private void btnBPoint_Click(object sender, EventArgs e)
        {
            vec3 fix = new vec3(mf.pivotAxlePos);

            btnBPoint.BackColor = System.Drawing.Color.Teal;

            mf.ABLine.desPointB.easting = fix.easting + Math.Cos(fix.heading) * mf.tool.offset;
            mf.ABLine.desPointB.northing = fix.northing - Math.Sin(fix.heading) * mf.tool.offset;

            // heading based on AB points
            mf.ABLine.desHeading = Math.Atan2(mf.ABLine.desPointB.easting - mf.ABLine.desPointA.easting,
                mf.ABLine.desPointB.northing - mf.ABLine.desPointA.northing);
            if (mf.ABLine.desHeading < 0) mf.ABLine.desHeading += glm.twoPI;

            nudHeading.Value = (decimal)(glm.toDegrees(mf.ABLine.desHeading));

            BuildDesLine();
        }

        private void nudHeading_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                BuildDesLine();
            }
        }

        private void BuildDesLine()
        {
            mf.ABLine.desHeading = glm.toRadians((double)nudHeading.Value);

            //sin x cos z for endpoints, opposite for additional lines
            mf.ABLine.desPtA.easting = mf.ABLine.desPointA.easting - (Math.Sin(mf.ABLine.desHeading) * mf.ABLine.abLength);
            mf.ABLine.desPtA.northing = mf.ABLine.desPointA.northing - (Math.Cos(mf.ABLine.desHeading) * mf.ABLine.abLength);
            mf.ABLine.desPtB.easting = mf.ABLine.desPointA.easting + (Math.Sin(mf.ABLine.desHeading) * mf.ABLine.abLength);
            mf.ABLine.desPtB.northing = mf.ABLine.desPointA.northing + (Math.Cos(mf.ABLine.desHeading) * mf.ABLine.abLength);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender, this);
                btnAdd.Focus();
            }
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            textBox1.Text += DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);
            mf.ABLine.desName = textBox1.Text;
        }

        private void btnEnter_APlus_Click(object sender, EventArgs e)
        {
            panelAPlus.Visible = false;
            panelName.Visible = true;

            mf.ABLine.desName = "AB " +
                (Math.Round(glm.toDegrees(mf.ABLine.desHeading), 1)).ToString(CultureInfo.InvariantCulture) +
                "\u00B0 " + mf.FindDirection(mf.ABLine.desHeading);

            textBox1.Text = mf.ABLine.desName;
        }

        private void BtnNewABLine_Click(object sender, EventArgs e)
        {
            panelPick.Visible = false;
            panelAPlus.Visible = true;
            panelName.Visible = false;

            btnAPoint.Enabled = true;
            btnBPoint.Enabled = false;
            nudHeading.Enabled = false;

            btnEnter_APlus.Enabled = false;

            this.Size = new System.Drawing.Size(270, 360);
        }

        private void btnEditName_Click(object sender, EventArgs e)
        {
            if (selectedItem > -1)
            {
                int idx = selectedItem;

                textBox2.Text = mf.trk.gArr[idx].name;

                panelPick.Visible = false;
                panelEditName.Visible = true;
                this.Size = new System.Drawing.Size(270, 360);
            }
        }

        private void btnLoadFromKML_Click(object sender, EventArgs e)
        {
            panelPick.Visible = false;
            panelAPlus.Visible = false;
            panelName.Visible = false;
            panelKML.Visible = true;

            this.Size = new System.Drawing.Size(270, 360);

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
                if (ofd.ShowDialog(this) == DialogResult.Cancel) return;
                else fileAndDirectory = ofd.FileName;
            }

            string coordinates = null;
            int startIndex;

            using (StreamReader reader = new StreamReader(fileAndDirectory))
            {
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

                            //2 points
                            if (numberSets.Length == 2)
                            {
                                string[] fix = numberSets[0].Split(',');
                                double.TryParse(fix[0], NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);
                                double.TryParse(fix[1], NumberStyles.Float, CultureInfo.InvariantCulture, out latK);

                                mf.pn.ConvertWGS84ToLocal(latK, lonK, out norting, out easting);

                                mf.ABLine.desPointA.easting = easting;
                                mf.ABLine.desPointA.northing = norting;

                                fix = numberSets[1].Split(',');
                                double.TryParse(fix[0], NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);
                                double.TryParse(fix[1], NumberStyles.Float, CultureInfo.InvariantCulture, out latK);

                                mf.pn.ConvertWGS84ToLocal(latK, lonK, out norting, out easting);

                                mf.ABLine.desPointB.easting = easting;
                                mf.ABLine.desPointB.northing = norting;

                                // heading based on AB points
                                mf.ABLine.desHeading = Math.Atan2(mf.ABLine.desPointB.easting - mf.ABLine.desPointA.easting,
                                    mf.ABLine.desPointB.northing - mf.ABLine.desPointA.northing);
                                if (mf.ABLine.desHeading < 0) mf.ABLine.desHeading += glm.twoPI;

                                mf.ABLine.desName = "AB " +
                                    (Math.Round(glm.toDegrees(mf.ABLine.desHeading), 1)).ToString(CultureInfo.InvariantCulture) +
                                    "\u00B0 " + mf.FindDirection(mf.ABLine.desHeading);

                                textBox1.Text = mf.ABLine.desName;

                                coordinates = "";

                                panelKML.Visible = false;
                                panelName.Visible = true;
                            }
                            else
                            {
                                mf.TimedMessageBox(2000, gStr.gsErrorreadingKML, gStr.gsMissingABLinesFile);
                            }
                        }
                    }
                    //mf.FileSaveBoundary();
                    //mf.bnd.BuildTurnLines();
                    //mf.btnABDraw.Visible = true;
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void btnSaveEditName_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "") textBox2.Text = "No Name " + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);

            int idx = selectedItem;

            panelEditName.Visible = false;
            panelPick.Visible = true;

            mf.trk.gArr[idx].name = textBox2.Text.Trim();
            mf.FileSaveABLines();

            this.Size = new System.Drawing.Size(620, 475);

            UpdateTable();
            flp.Focus();
            mf.ABLine.isABLineBeingSet = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mf.trk.gArr.Add(new CTrk());

            //index to last one.
            int idx = mf.trk.gArr.Count - 1;

            mf.trk.gArr[idx].heading = mf.ABLine.desHeading;
            //calculate the new points for the reference line and points
            mf.trk.gArr[idx].ptA.easting = mf.ABLine.desPointA.easting;
            mf.trk.gArr[idx].ptA.northing = mf.ABLine.desPointA.northing;

            //name
            if (textBox2.Text.Trim() == "") textBox2.Text = "No Name " + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);

            mf.trk.gArr[idx].name = textBox1.Text.Trim();

            mf.FileSaveABLines();

            panelPick.Visible = true;
            panelAPlus.Visible = false;
            panelName.Visible = false;

            this.Size = new System.Drawing.Size(620, 475);

            UpdateTable();
            mf.ABLine.isABLineBeingSet = false;
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

                mf.ABLine.desHeading = mf.trk.gArr[idx].heading;

                //calculate the new points for the reference line and points
                mf.ABLine.desPointA.easting = mf.trk.gArr[idx].ptA.easting;
                mf.ABLine.desPointA.northing = mf.trk.gArr[idx].ptA.northing;

                mf.ABLine.desName = mf.trk.gArr[idx].name + " Copy";

                textBox1.Text = mf.ABLine.desName;
            }
        }

        private void btnListUse_Click(object sender, EventArgs e)
        {
            isClosing = true;
            mf.ABLine.moveDistance = 0;
            //reset to generate new reference
            mf.ABLine.isABValid = false;

            if (selectedItem > -1)
            {
                int idx = selectedItem;

                mf.ABLine.abHeading = mf.trk.gArr[idx].heading;
                mf.ABLine.refPtA = mf.trk.gArr[idx].ptA;

                mf.ABLine.SetABLineByHeading();

                mf.EnableYouTurnButtons();

                //Go back with Line enabled
                Close();
            }

            else if (mf.trk.gArr.Count > 0)
            {
                int idx = mf.trk.gArr.Count-1;

                mf.ABLine.abHeading = mf.trk.gArr[idx].heading;
                mf.ABLine.refPtA = mf.trk.gArr[idx].ptA;

                mf.ABLine.SetABLineByHeading();

                mf.EnableYouTurnButtons();

                //Go back with Line enabled
                Close();
            }

            //no item selected
            else
            {
                mf.btnABLine.Image = Properties.Resources.ABLineOff;
                mf.ABLine.isBtnABLineOn = false;
                mf.ABLine.isABLineSet = false;
                mf.DisableYouTurnButtons();
                if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
                if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();
                Close();
            }
        }

        private void btnSwapAB_Click(object sender, EventArgs e)
        {
            if (selectedItem > -1)
            {
                int idx = selectedItem;
                mf.ABLine.isABValid = false;

                mf.trk.gArr[idx].heading += Math.PI;
                if (mf.trk.gArr[idx].heading > glm.twoPI) mf.trk.gArr[idx].heading -= glm.twoPI;

                mf.FileSaveABLines();

                UpdateTable();
                flp.Focus();

                mf.TimedMessageBox(1500, "A B Swapped", "Line is Reversed");

            }
        }

        private void btnListDelete_Click(object sender, EventArgs e)
        {
            if (selectedItem > -1)
            {
                mf.trk.gArr.RemoveAt(selectedItem);

                {
                    mf.ABLine.DeleteAB();
                    if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
                    if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();
                }
                mf.FileSaveABLines();
            }
            else
            {
                if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
                if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();
            }

            selectedItem = -1;
            UpdateTable();
            flp.Focus();
        }

        private void FormABLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                e.Cancel = true;
                return;
            }

            Properties.Settings.Default.setWindow_abLineCreate = Location;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isClosing = true;

            mf.btnABLine.Image = Properties.Resources.ABLineOff;
            mf.ABLine.isBtnABLineOn = false;
            mf.ABLine.isABLineSet = false;
            mf.DisableYouTurnButtons();
            if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
            if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();
            Close();
            mf.ABLine.isABValid = false;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender, this);
                btnSaveEditName.Focus();
            }
        }

        private void btnAddTimeEdit_Click(object sender, EventArgs e)
        {
            textBox2.Text += DateTime.Now.ToString(" hh:mm:ss", CultureInfo.InvariantCulture);
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            using (var form = new FormEnterAB(mf))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    panelAPlus.Visible = false;
                    panelName.Visible = true;

                    mf.ABLine.desName = "AB m " +
                        (Math.Round(glm.toDegrees(mf.ABLine.desHeading), 1)).ToString(CultureInfo.InvariantCulture) +
                        "\u00B0 " + mf.FindDirection(mf.ABLine.desHeading);

                    textBox1.Text = mf.ABLine.desName;

                    //sin x cos z for endpoints, opposite for additional lines
                    mf.ABLine.desPtA.easting = mf.ABLine.desPointA.easting - (Math.Sin(mf.ABLine.desHeading) * mf.ABLine.abLength);
                    mf.ABLine.desPtA.northing = mf.ABLine.desPointA.northing - (Math.Cos(mf.ABLine.desHeading) * mf.ABLine.abLength);
                    mf.ABLine.desPtB.easting = mf.ABLine.desPointA.easting + (Math.Sin(mf.ABLine.desHeading) * mf.ABLine.abLength);
                    mf.ABLine.desPtB.northing = mf.ABLine.desPointA.northing + (Math.Cos(mf.ABLine.desHeading) * mf.ABLine.abLength);
                }
                else
                {
                    btnCancel_APlus.PerformClick();
                }
            }
        }

        private bool isOn = true;
        private void btnHideShow_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mf.trk.gArr.Count; i++)
            {
                mf.trk.gArr[i].isVisible = isOn;
            }

            isOn = !isOn;

            UpdateTable();
        }

        #region Help

        private void btnListDelete_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnListDelete, gStr.gsHelp);
        }

        private void btnCancel_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnCancel, gStr.gsHelp);
        }

        private void btnNewABLine_HelpRequested(object sender, HelpEventArgs hlpevent)
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

        private void btnAPoint_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnAPoint, gStr.gsHelp);
        }

        private void btnBPoint_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnBPoint, gStr.gsHelp);
        }

        private void nudHeading_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_nudHeading, gStr.gsHelp);
        }

        private void btnManual_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnManual, gStr.gsHelp);
        }

        private void textBox1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_textBox1, gStr.gsHelp);
        }

        private void btnAddTime_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnAddTime, gStr.gsHelp);
        }

        private void btnCancel_APlus_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnCancelCreate, gStr.gsHelp);
        }

        private void btnCancel_Name_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnCancelCreate, gStr.gsHelp);
        }

        private void btnCancelEditName_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnCancelCreate, gStr.gsHelp);
        }

        private void btnEnter_APlus_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnEnterContinue, gStr.gsHelp);
        }

        private void btnAdd_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnEnterContinue, gStr.gsHelp);
        }

        private void btnSaveEditName_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_btnEnterContinue, gStr.gsHelp);
        }

        private void textBox2_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.ha_textBox1, gStr.gsHelp);
        }

        #endregion Help
    }
}