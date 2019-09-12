//Please, if you use this, share the improvements

using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormABLine : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        private double upDnHeading = 0;

        //the abline stored file
        private string filename = "";

        public FormABLine(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();
        }

        private void FormABLine_Load(object sender, EventArgs e)
        {
            lvLines.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            tboxABLineName.Visible = false;
            nudBasedOnPass.Visible = false;
            nudTramRepeats.Visible = false;
            btnListDelete.Visible = false;
            btnListUse.Visible = false;
            btnAddToFile.Visible = false;
            btnShow.Text = "Save";
            btnShow.Image = Properties.Resources.ArrowLeft;


            //small window
            this.Size = new System.Drawing.Size(304, 510);


            //different start based on AB line already set or not
            if (mf.ABLine.isABLineSet)
            {
                //AB line is on screen and set
                btnAPoint.Enabled = false;
                btnBPoint.Enabled = true;
                upDnHeading = Math.Round(glm.toDegrees(mf.ABLine.abHeading), 6);
                nudTramRepeats.Value = mf.ABLine.tramPassEvery;
                nudBasedOnPass.Value = mf.ABLine.passBasedOn;
                this.tboxHeading.TextChanged -= new System.EventHandler(this.tboxHeading_TextChanged);
                tboxHeading.Text = upDnHeading.ToString(CultureInfo.InvariantCulture);
                this.tboxHeading.TextChanged += new System.EventHandler(this.tboxHeading_TextChanged);
            }
            else
            {
                //no AB line
                btnAPoint.Enabled = true;
                btnBPoint.Enabled = false;
                btnABLineOk.Enabled = false;
                upDnHeading = Math.Round(glm.toDegrees(mf.fixHeading), 6);
                nudTramRepeats.Value = 0;
                nudBasedOnPass.Value = 0;
                mf.ABLine.tramPassEvery = 0;
                mf.ABLine.passBasedOn = 0;
            }

            //make sure at least a global blank AB Line file exists
            string dirField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            filename = directoryName + "\\ABLines.txt";


            if (!File.Exists(filename))
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine("ABLine N S,0,0,0");
                    writer.WriteLine("ABLine E W,90,0,0");
                }
            }

            //get the file of previous AB Lines
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            filename = directoryName + "\\ABLines.txt";

            if (!File.Exists(filename))
            {
                mf.TimedMessageBox(2000, "File Error", "Missing AB Lines File, Critical Error");
            }
            else
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    try
                    {
                        string line;
                        ListViewItem itm;

                        //read all the lines
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            string[] words = line.Split(',');
                            //listboxLines.Items.Add(line);
                            itm = new ListViewItem(words);
                            lvLines.Items.Add(itm);

                            //coords.easting = double.Parse(words[0], CultureInfo.InvariantCulture);
                            //coords.northing = double.Parse(words[1], CultureInfo.InvariantCulture);
                            //youFileList.Add(coords);
                        }
                    }
                    catch (Exception er)
                    {
                        var form = new FormTimedMessage(2000, "ABLine File is Corrupt", "Please delete it!!!");
                        form.Show();
                        mf.WriteErrorLog("FieldOpen, Loading ABLine, Corrupt ABLine File" + er);
                    }
                }

                // go to bottom of list - if there is a bottom
                if (lvLines.Items.Count > 0) lvLines.Items[lvLines.Items.Count - 1].EnsureVisible();
            }
        }

        private void BtnNewABLine_Click(object sender, EventArgs e)
        {
            this.tboxHeading.TextChanged -= new System.EventHandler(this.tboxHeading_TextChanged);
            tboxHeading.Text = "";
            this.tboxHeading.TextChanged += new System.EventHandler(this.tboxHeading_TextChanged);

            mf.ABLine.DeleteAB();
            btnAPoint.Enabled = true;
            btnBPoint.Enabled = false;
            btnABLineOk.Enabled = false;
            nudTramRepeats.Value = 0;
            nudBasedOnPass.Value = 0;
            mf.ABLine.tramPassEvery = 0;
            mf.ABLine.passBasedOn = 0;

            //save the no ABLine;
            mf.FileSaveABLine();
        }

        private void btnAPoint_Click(object sender, EventArgs e)
        {
#pragma warning disable CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
            mf.ABLine.refPoint1.easting = mf.pivotAxlePos.easting;
            mf.ABLine.refPoint1.northing = mf.pivotAxlePos.northing;
            mf.ABLine.abHeading = mf.pivotAxlePos.heading;
#pragma warning restore CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
            btnAPoint.Enabled = false;
            upDnHeading = Math.Round(glm.toDegrees(mf.fixHeading), 1);
            this.tboxHeading.TextChanged -= new System.EventHandler(this.tboxHeading_TextChanged);
            tboxHeading.Text = upDnHeading.ToString();
            this.tboxHeading.TextChanged += new System.EventHandler(this.tboxHeading_TextChanged);
            btnABLineOk.Enabled = false;
            btnShow.Enabled = false;
            mf.ABLine.SetABLineByHeading();

            ShowSavedPanel(false);
        }

        private void btnBPoint_Click(object sender, EventArgs e)
        {
            mf.ABLine.SetABLineByBPoint();
            btnABLineOk.Enabled = true;
            btnShow.Enabled = true;
            btnTurnOffAB.Enabled = true;
            upDnHeading = Math.Round(glm.toDegrees(mf.fixHeading), 3);

            //update the default
            if (mf.ABLine.tramPassEvery == 0) mf.mc.relayData[mf.mc.rdTramLine] = 0;

            this.tboxHeading.TextChanged -= new System.EventHandler(this.tboxHeading_TextChanged);
            tboxHeading.Text = glm.toDegrees(mf.ABLine.abHeading).ToString("N4");
            this.tboxHeading.TextChanged += new System.EventHandler(this.tboxHeading_TextChanged);

        }

        private void btnABLineOk_Click(object sender, EventArgs e)
        {
            //save the ABLine
            mf.FileSaveABLine();

            if (mf.ABLine.isABLineLoaded)
            {
                //save the ABLine
                mf.EnableYouTurnButtons();
            }
            else
            {
                mf.DisableYouTurnButtons();
            }

            //update the default
            mf.AB0.fieldName = mf.currentFieldDirectory;
            mf.AB0.heading = glm.toDegrees(mf.ABLine.abHeading);
            mf.AB0.X = mf.ABLine.refPoint1.easting;
            mf.AB0.Y = mf.ABLine.refPoint1.northing;
            if (mf.ABLine.tramPassEvery == 0) mf.mc.relayData[mf.mc.rdTramLine] = 0;
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFixHeading.Text = Convert.ToString(Math.Round(glm.toDegrees(mf.fixHeading), 1)) + "°";
            lblKeepGoing.Text = "";

            //make sure we go at least 3 or so meters before allowing B reference point
            if (!btnAPoint.Enabled && !btnBPoint.Enabled)
            {
                double pointAToFixDistance =
                Math.Pow(mf.ABLine.refPoint1.easting - mf.pn.fix.easting, 2)
                + Math.Pow(mf.ABLine.refPoint1.northing - mf.pn.fix.northing, 2);

                if (pointAToFixDistance > 100) btnBPoint.Enabled = true;
                else lblKeepGoing.Text = Convert.ToInt16(100 - pointAToFixDistance).ToString();
            }

            int count = lvLines.SelectedItems.Count;
            if (count > 0)
            {
                btnListDelete.Enabled = true;
                btnListUse.Enabled = true;
            }
            else
            {
                btnListDelete.Enabled = false;
                btnListUse.Enabled = false;
            }
        }

        private void nudTramRepeats_ValueChanged(object sender, EventArgs e)
        {
            mf.ABLine.tramPassEvery = (int)nudTramRepeats.Value;
        }

        private void nudBasedOnPass_ValueChanged(object sender, EventArgs e)
        {
            mf.ABLine.passBasedOn = (int)nudBasedOnPass.Value;
        }

        private void btnAddToFile_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                if (mf.ABLine.isABLineSet)
                {
                    if (tboxABLineName.Text.Length > 0)
                    {
                        //make it culture invariant
                        string line = tboxABLineName.Text.Trim()
                            + ',' + (Math.Round(glm.toDegrees(mf.ABLine.abHeading), 8)).ToString(CultureInfo.InvariantCulture)
                            + ',' + (Math.Round(mf.ABLine.refPoint1.easting, 3)).ToString(CultureInfo.InvariantCulture)
                            + ',' + (Math.Round(mf.ABLine.refPoint1.northing, 3)).ToString(CultureInfo.InvariantCulture);

                        //write out to file
                        writer.WriteLine(line);

                        //update the list box
                        ListViewItem itm;
                        string[] words = line.Split(',');
                        itm = new ListViewItem(words);
                        lvLines.Items.Add(itm);

                        // go to bottom of list - if there is a bottom
                        if (lvLines.Items.Count > 0) lvLines.Items[lvLines.Items.Count - 1].EnsureVisible();
                    }
                    else
                    {
                        //MessageBox.Show("Currently no ABCurve name\n      create ABCurve name");
                        var form2 = new FormTimedMessage(2000, "No Name Entered", "Please Enter ABLine name");
                        form2.Show();
                    }
                }
                else
                {
                    //MessageBox.Show("Currently no ABCurve name\n      create ABCurve name");
                    var form2 = new FormTimedMessage(2000, "No ABLine Active", "Please Complete an ABLine First");
                    form2.Show();
                }
                tboxABLineName.Clear();

            }
        }

        private void tboxHeading_TextChanged(object sender, EventArgs e)
        {
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, "[^0-9.]", "");
            textboxSender.SelectionStart = cursorPosition;
            string line = tboxHeading.Text.Trim();
            if (line?.Length == 0) line = "0";
            if (line == ".") line = "0";
            upDnHeading = double.Parse(line, CultureInfo.InvariantCulture);
            mf.ABLine.abHeading = glm.toRadians(Math.Round(upDnHeading, 6));
            mf.ABLine.SetABLineByHeading();
        }

        private void btnListDelete_Click(object sender, EventArgs e)
        {
            int count = lvLines.SelectedItems.Count;
            if (count > 0)
            {
                lvLines.SelectedItems[0].Remove();
            }
            using (StreamWriter writer = new StreamWriter(filename))
            {
                string words;
                count = lvLines.Items.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        words = lvLines.Items[i].SubItems[0].Text + "," +
                                lvLines.Items[i].SubItems[1].Text + "," +
                                lvLines.Items[i].SubItems[2].Text + "," +
                                lvLines.Items[i].SubItems[3].Text;
                        //out to file
                        writer.WriteLine(words);
                    }
                }
            }
        }

        private void btnListUse_Click(object sender, EventArgs e)
        {
            int count = lvLines.SelectedItems.Count;
            if (count > 0)
            {
                double temp = double.Parse(lvLines.SelectedItems[0].SubItems[1].Text, CultureInfo.InvariantCulture);
                mf.ABLine.abHeading = glm.toRadians(temp);
                temp = double.Parse(lvLines.SelectedItems[0].SubItems[2].Text, CultureInfo.InvariantCulture);
                mf.ABLine.refPoint1.easting = temp;
                temp = double.Parse(lvLines.SelectedItems[0].SubItems[3].Text, CultureInfo.InvariantCulture);
                mf.ABLine.refPoint1.northing = temp;
                mf.ABLine.SetABLineByHeading();

                //save the ABLine
                mf.FileSaveABLine();

                //update the default
                mf.AB0.fieldName = lvLines.SelectedItems[0].SubItems[0].Text;
                mf.AB0.heading = double.Parse(lvLines.SelectedItems[0].SubItems[1].Text, CultureInfo.InvariantCulture);
                mf.AB0.X = double.Parse(lvLines.SelectedItems[0].SubItems[2].Text, CultureInfo.InvariantCulture);
                mf.AB0.Y = double.Parse(lvLines.SelectedItems[0].SubItems[3].Text, CultureInfo.InvariantCulture);

                mf.EnableYouTurnButtons();
                //Go back with Line enabled
                Close();
            }

            //no item selected
            else
            {
                return;
            }
        }

        private void btnPlus90_Click(object sender, EventArgs e)
        {
            upDnHeading += 90;
            if (upDnHeading > 359.999999) upDnHeading -= 360;
            mf.ABLine.abHeading = glm.toRadians(upDnHeading);
            mf.ABLine.SetABLineByHeading();
            tboxHeading.Text = Convert.ToString(upDnHeading, CultureInfo.InvariantCulture);
            btnABLineOk.Enabled = true;
        }

        private void BtnUpABHeadingBy1_Click(object sender, EventArgs e)
        {
            upDnHeading--;
            if (upDnHeading < 0) upDnHeading = 359;
            upDnHeading = (int)upDnHeading;
            mf.ABLine.abHeading = glm.toRadians(upDnHeading);
            tboxHeading.Text = Convert.ToString(upDnHeading, CultureInfo.InvariantCulture);
            btnABLineOk.Enabled = true;
        }

        private void BtnDnABHeadingBy1_Click(object sender, EventArgs e)
        {
            if ((upDnHeading++) > 358) upDnHeading = 0;
            upDnHeading = (int)upDnHeading;
            mf.ABLine.abHeading = glm.toRadians(upDnHeading);
            tboxHeading.Text = Convert.ToString(upDnHeading, CultureInfo.InvariantCulture);
            btnABLineOk.Enabled = true;
        } 

        private void TboxHeading_Enter(object sender, EventArgs e)
        {
            tboxHeading.Text = "";
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            if (this.Size.Width < 790)
            {
                ShowSavedPanel(true);
            }
            else
            {
                ShowSavedPanel(false);
            }
        }

        private void btnTurnOffAB_Click(object sender, EventArgs e)
        {
            mf.ABLine.isABLineSet = false;
            mf.ABLine.tramPassEvery = 0;
            mf.ABLine.passBasedOn = 0;
            mf.btnABLine.Image = Properties.Resources.ABLineOff;
            mf.ABLine.isBtnABLineOn = false;
            Close();

        }

    private void ShowSavedPanel(bool showPanel)
        {
            if (showPanel)
            {
                this.Size = new System.Drawing.Size(800, 510);
                lvLines.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                tboxABLineName.Visible = true;
                nudBasedOnPass.Visible = true;
                nudTramRepeats.Visible = true;
                btnListDelete.Visible = true;
                btnListUse.Visible = true;
                btnAddToFile.Visible = true;
                btnShow.Text = "Hide";
                btnShow.Image = Properties.Resources.ArrowRight;

            }
            else   //hide the panel
            {
                this.Size = new System.Drawing.Size(304, 510);
                lvLines.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                tboxABLineName.Visible = false;
                nudBasedOnPass.Visible = false;
                nudTramRepeats.Visible = false;
                btnListDelete.Visible = false;
                btnListUse.Visible = false;
                btnAddToFile.Visible = false;
                btnShow.Text = "Save";
                btnShow.Image = Properties.Resources.ArrowLeft;

            }
        }

    }

}