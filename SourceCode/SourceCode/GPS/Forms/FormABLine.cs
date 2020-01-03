//Please, if you use this, share the improvements

using System;
using System.Drawing;
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
        private bool isFullPanel;
        private int originalSelected = 0;

        public FormABLine(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();
            this.Text = gStr.gsABline;
        }

        private void FormABLine_Load(object sender, EventArgs e)
        {
            //tboxABLineName.Enabled = false;
            btnAddToFile.Enabled = false;
            btnAddAndGo.Enabled = false;
            btnAPoint.Enabled = false;
            btnBPoint.Enabled = false;
            btnUpABHeadingBy1.Enabled = false;
            btnDnABHeadingBy1.Enabled = false;
            tboxHeading.Enabled = false;
            tboxABLineName.Text = "";
            tboxABLineName.Enabled = false;
            
            //small window
            ShowFullPanel(true);

            originalSelected = mf.ABLine.numABLineSelected;

            //different start based on AB line already set or not
            if (mf.ABLine.isABLineSet)
            {
                //AB line is on screen and set
                upDnHeading = Math.Round(glm.toDegrees(mf.ABLine.abHeading), 6);
                this.tboxHeading.TextChanged -= new System.EventHandler(this.tboxHeading_TextChanged);
                tboxHeading.Text = upDnHeading.ToString(CultureInfo.InvariantCulture);
                this.tboxHeading.TextChanged += new System.EventHandler(this.tboxHeading_TextChanged);
            }
            else
            {
                //no AB line
                btnAPoint.Enabled = false;
                btnBPoint.Enabled = false;
                upDnHeading = Math.Round(glm.toDegrees(mf.fixHeading), 6);
                //mf.ABLine.tramPassEvery = 0;
                //mf.ABLine.tramBasedOn = 0;
            }

            lvLines.Clear();
            ListViewItem itm;

            foreach (var item in mf.ABLine.lineArr)
            {
                itm = new ListViewItem(item.Name);
                lvLines.Items.Add(itm);
            }

            // go to bottom of list - if there is a bottom
            if (lvLines.Items.Count > 0) lvLines.Items[lvLines.Items.Count - 1].EnsureVisible();
        }


        private void btnAPoint_Click(object sender, EventArgs e)
        {
            vec3 fix = new vec3();
            fix = mf.pivotAxlePos;

            tboxHeading.Enabled = true;
            btnNewABLine.Image = Properties.Resources.OK64;
            btnNewABLine.Text = "+";
            btnUpABHeadingBy1.Enabled = true;
            btnDnABHeadingBy1.Enabled = true;
            btnNewABLine.Enabled = true;


            mf.ABLine.moveDistance = 0;
            mf.ABLine.refPoint1.easting = fix.easting;
            mf.ABLine.refPoint1.northing = fix.northing;
            mf.ABLine.abHeading = fix.heading;
            mf.ABLine.SetABLineByHeading();

            btnAPoint.Enabled = false;
            upDnHeading = Math.Round(glm.toDegrees(mf.fixHeading), 1);
            this.tboxHeading.TextChanged -= new System.EventHandler(this.tboxHeading_TextChanged);
            tboxHeading.Text = upDnHeading.ToString();
            this.tboxHeading.TextChanged += new System.EventHandler(this.tboxHeading_TextChanged);

            ShowFullPanel(false);
        }

        private void btnBPoint_Click(object sender, EventArgs e)
        {
            mf.ABLine.SetABLineByBPoint();
            upDnHeading = Math.Round(glm.toDegrees(mf.fixHeading), 3);

            //update the default
            if (mf.ABLine.tramPassEvery == 0) mf.mc.relayData[mf.mc.rdTramLine] = 0;

            this.tboxHeading.TextChanged -= new System.EventHandler(this.tboxHeading_TextChanged);
            tboxHeading.Text = glm.toDegrees(mf.ABLine.abHeading).ToString("N4");
            this.tboxHeading.TextChanged += new System.EventHandler(this.tboxHeading_TextChanged);
            //mf.ABLine.SetABLineByHeading();

            //ShowSavedPanel(true);
            //tboxABLineName.BackColor = Color.LightGreen;
        }


        //private void btnPlus90_Click(object sender, EventArgs e)
        //{
        //    mf.ABLine.moveDistance = 0;
        //    upDnHeading += 90;
        //    if (upDnHeading > 359.999999) upDnHeading -= 360;
        //    mf.ABLine.abHeading = glm.toRadians(upDnHeading);
        //    mf.ABLine.SetABLineByHeading();
        //    tboxHeading.Text = Convert.ToString(upDnHeading, CultureInfo.InvariantCulture);
        //}

        private void BtnNewABLine_Click(object sender, EventArgs e)
        {
            //is button for adding ABLine set
            if (btnNewABLine.Text == "+")
            {
                btnNewABLine.Text = "";
                btnNewABLine.Image = Properties.Resources.AddNew;
                ShowFullPanel(true);
                tboxABLineName.BackColor = Color.LightGreen;
                //create a name
                tboxABLineName.Enabled = true;

                tboxHeading.Enabled = false;

                btnAddToFile.Enabled = true;
                btnAddAndGo.Enabled = true;

                btnAPoint.Enabled = false;
                btnBPoint.Enabled = false;
                btnUpABHeadingBy1.Enabled = false;
                btnDnABHeadingBy1.Enabled = false;
                btnNewABLine.Enabled = false;
                btnTurnOffAB.Enabled = false;
                btnNewABLine.Enabled = false;

                lvLines.Enabled = false;
                btnAddToFile.Focus();
                tboxABLineName.Text = (Math.Round(glm.toDegrees(mf.ABLine.abHeading), 1)).ToString(CultureInfo.InvariantCulture) 
                    + "\u00B0" +
                    mf.FindDirection(mf.ABLine.abHeading) + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);
            }
            else // or used to initiate a new line
            {
                this.tboxHeading.TextChanged -= new System.EventHandler(this.tboxHeading_TextChanged);
                tboxHeading.Text = "";
                this.tboxHeading.TextChanged += new System.EventHandler(this.tboxHeading_TextChanged);
                tboxHeading.Enabled = false;

                mf.ABLine.DeleteAB();
                lvLines.SelectedItems.Clear();

                btnAPoint.Enabled = true;
                btnBPoint.Enabled = false;
                btnUpABHeadingBy1.Enabled = false;
                btnDnABHeadingBy1.Enabled = false;
                btnNewABLine.Enabled = false;
                btnTurnOffAB.Enabled = false;

                //mf.ABLine.tramPassEvery = 0;
                //mf.ABLine.tramBasedOn = 0;
                mf.ABLine.isABLineSet = false;
                mf.ABLine.isABLineLoaded = false;

                ShowFullPanel(false);
            }
        }

        private void BtnUpABHeadingBy1_Click(object sender, EventArgs e)
        {
            mf.ABLine.moveDistance = 0;
            upDnHeading -= 0.1;
            upDnHeading = Math.Round(upDnHeading, 1);
            if (upDnHeading < 0)
            {
                upDnHeading += 360;
            }
            mf.ABLine.abHeading = glm.toRadians(upDnHeading);
            tboxHeading.Text = Convert.ToString(upDnHeading, CultureInfo.InvariantCulture);
        }

        private void BtnDnABHeadingBy1_Click(object sender, EventArgs e)
        {
            mf.ABLine.moveDistance = 0;

            upDnHeading += 0.1;
            upDnHeading = Math.Round(upDnHeading, 1);
            if ((upDnHeading) > 359.9)
            {
                upDnHeading -= 360;
            }
            //upDnHeading = (int)upDnHeading;
            mf.ABLine.abHeading = glm.toRadians(upDnHeading);
            tboxHeading.Text = Convert.ToString(upDnHeading, CultureInfo.InvariantCulture);
        }

        private void TboxHeading_Enter(object sender, EventArgs e)
        {
            tboxHeading.Text = "";

            using (var form = new FormNumeric(0, 360, upDnHeading))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    upDnHeading = form.ReturnValue;
                    tboxHeading.Text = upDnHeading.ToString();
                    //mf.ABLine.abHeading = glm.toRadians(Math.Round(upDnHeading, 6));
                    //mf.ABLine.SetABLineByHeading();
                }
            }

            btnTurnOffAB.Focus();

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
            //ShowSavedPanel(true);
            tboxABLineName.BackColor = Color.LightGreen;
        }

        private void btnAddToFile_Click(object sender, EventArgs e)
        {
            if (mf.ABLine.isABLineSet)
            {
                if (tboxABLineName.Text.Length > 0)
                {
                    mf.ABLine.lineArr.Add(new CABLines());
                    mf.ABLine.numABLines = mf.ABLine.lineArr.Count;
                    mf.ABLine.numABLineSelected = mf.ABLine.numABLines;

                    //index to last one. 
                    int idx = mf.ABLine.lineArr.Count - 1;

                    mf.ABLine.lineArr[idx].heading = mf.ABLine.abHeading;
                    //calculate the new points for the reference line and points
                    mf.ABLine.lineArr[idx].origin.easting = mf.ABLine.refPoint1.easting;
                    mf.ABLine.lineArr[idx].origin.northing = mf.ABLine.refPoint1.northing;

                    //sin x cos z for endpoints, opposite for additional lines
                    mf.ABLine.lineArr[idx].ref1.easting = mf.ABLine.lineArr[idx].origin.easting - (Math.Sin(mf.ABLine.lineArr[idx].heading) *   1600.0);
                    mf.ABLine.lineArr[idx].ref1.northing = mf.ABLine.lineArr[idx].origin.northing - (Math.Cos(mf.ABLine.lineArr[idx].heading) * 1600.0);
                    mf.ABLine.lineArr[idx].ref2.easting = mf.ABLine.lineArr[idx].origin.easting + (Math.Sin(mf.ABLine.lineArr[idx].heading) *   1600.0);
                    mf.ABLine.lineArr[idx].ref2.northing = mf.ABLine.lineArr[idx].origin.northing + (Math.Cos(mf.ABLine.lineArr[idx].heading) * 1600.0);


                    mf.ABLine.lineArr[idx].Name = tboxABLineName.Text.Trim();

                    //update the list box
                    ListViewItem itm;
                    itm = new ListViewItem(mf.ABLine.lineArr[idx].Name);
                    lvLines.Items.Add(itm);

                    // go to bottom of list - if there is a bottom
                    if (lvLines.Items.Count > 0) lvLines.Items[lvLines.Items.Count - 1].EnsureVisible();

                    mf.FileSaveABLines();

                    tboxABLineName.BackColor = SystemColors.ControlLight;
                    tboxABLineName.Text = "";

                    btnAddToFile.Enabled = false;
                    btnAddAndGo.Enabled = false;
                    btnNewABLine.Enabled = true;

                    tboxABLineName.Enabled = false;
                    btnTurnOffAB.Enabled = true;
                    lvLines.Enabled = false;
                    tboxABLineName.Enabled = false;
                    lvLines.Enabled = true;
                    lvLines.Focus();
                }
                else
                {
                    //MessageBox.Show("Currently no ABCurve name\n      create ABCurve name");
                    var form2 = new FormTimedMessage(2000, gStr.gsNoNameEntered, gStr.gsEnterLineName);
                    form2.Show();
                }
            }
            else
            {
                //MessageBox.Show("Currently no ABCurve name\n      create ABCurve name");
                var form2 = new FormTimedMessage(2000, gStr.gsNoABLineActive, gStr.gsPleaseCompleteABLine);
                form2.Show();
            }

            tboxABLineName.Clear();
        }

        private void btnAddAndGo_Click(object sender, EventArgs e)
        {
            if (mf.ABLine.isABLineSet)
            {
                if (tboxABLineName.Text.Length > 0)
                {
                    mf.ABLine.lineArr.Add(new CABLines());
                    mf.ABLine.numABLines = mf.ABLine.lineArr.Count;
                    mf.ABLine.numABLineSelected = mf.ABLine.numABLines;

                    //index to last one. 
                    int idx = mf.ABLine.lineArr.Count - 1;

                    mf.ABLine.lineArr[idx].heading = mf.ABLine.abHeading;
                    //calculate the new points for the reference line and points
                    mf.ABLine.lineArr[idx].origin.easting = mf.ABLine.refPoint1.easting;
                    mf.ABLine.lineArr[idx].origin.northing = mf.ABLine.refPoint1.northing;

                    //sin x cos z for endpoints, opposite for additional lines
                    mf.ABLine.lineArr[idx].ref1.easting = mf.ABLine.lineArr[idx].origin.easting - (Math.Sin(mf.ABLine.lineArr[idx].heading) *   1600.0);
                    mf.ABLine.lineArr[idx].ref1.northing = mf.ABLine.lineArr[idx].origin.northing - (Math.Cos(mf.ABLine.lineArr[idx].heading) * 1600.0);
                    mf.ABLine.lineArr[idx].ref2.easting = mf.ABLine.lineArr[idx].origin.easting + (Math.Sin(mf.ABLine.lineArr[idx].heading) *   1600.0);
                    mf.ABLine.lineArr[idx].ref2.northing = mf.ABLine.lineArr[idx].origin.northing + (Math.Cos(mf.ABLine.lineArr[idx].heading) * 1600.0);


                    mf.ABLine.lineArr[idx].Name = tboxABLineName.Text.Trim();

                    mf.FileSaveABLines();

                    //Often only 1 ABLine so just return to field
                    //if (mf.ABLine.numABLines == 1)
                    mf.ABLine.abHeading = mf.ABLine.lineArr[idx].heading;
                    mf.ABLine.refPoint1 = mf.ABLine.lineArr[idx].origin;
                    mf.ABLine.SetABLineByHeading();
                    mf.EnableYouTurnButtons();

                    Close();//Go back with Line enabled
                }
                else
                {
                    //MessageBox.Show("Currently no ABCurve name\n      create ABCurve name");
                    var form2 = new FormTimedMessage(2000, gStr.gsNoNameEntered, gStr.gsEnterLineName);
                    form2.Show();
                }
            }
            else
            {
                //MessageBox.Show("Currently no ABCurve name\n      create ABCurve name");
                var form2 = new FormTimedMessage(2000, gStr.gsNoABLineActive, gStr.gsPleaseCompleteABLine);
                form2.Show();
            }

            tboxABLineName.Clear();
        }

        private void btnListDelete_Click(object sender, EventArgs e)
        {
            if (lvLines.SelectedItems.Count > 0)
            {
                int num = lvLines.SelectedIndices[0];
                mf.ABLine.lineArr.RemoveAt(num);
                lvLines.SelectedItems[0].Remove();

                mf.ABLine.numABLines = mf.ABLine.lineArr.Count;
                if (mf.ABLine.numABLineSelected > mf.ABLine.numABLines) mf.ABLine.numABLineSelected = mf.ABLine.numABLines;

                if (mf.ABLine.numABLines == 0)
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
        }

        private void btnListUse_Click(object sender, EventArgs e)
        {
            mf.ABLine.moveDistance = 0;

            int idx = lvLines.SelectedIndices[0];
            mf.ABLine.numABLineSelected = idx + 1;

            if (lvLines.SelectedItems.Count > 0)
            {
                mf.ABLine.abHeading = mf.ABLine.lineArr[idx].heading;
                mf.ABLine.refPoint1 = mf.ABLine.lineArr[idx].origin;

                mf.ABLine.SetABLineByHeading();

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

        private void btnTurnOffAB_Click(object sender, EventArgs e)
        {
            //mf.ABLine.tramPassEvery = 0;
            //mf.ABLine.tramBasedOn = 0;
            mf.btnABLine.Image = Properties.Resources.ABLineOff;
            mf.ABLine.isBtnABLineOn = false;
            mf.ABLine.isABLineSet = false;
            mf.ABLine.isABLineLoaded = false;
            mf.ABLine.numABLineSelected = 0;
            mf.DisableYouTurnButtons();
            if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
            if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFixHeading.Text = Convert.ToString(Math.Round(glm.toDegrees(mf.fixHeading), 1)) + "°";
            lblKeepGoing.Text = "";

            if (!isFullPanel)
            {
                //make sure we go at least 3 or so meters before allowing B reference point
                if (!btnAPoint.Enabled && !btnBPoint.Enabled)
                {
                    double pointAToFixDistance =
                    Math.Pow(mf.ABLine.refPoint1.easting - mf.pn.fix.easting, 2)
                    + Math.Pow(mf.ABLine.refPoint1.northing - mf.pn.fix.northing, 2);

                    if (pointAToFixDistance > 100) btnBPoint.Enabled = true;
                    else lblKeepGoing.Text = Convert.ToInt16(100 - pointAToFixDistance).ToString();
                }
            }
            else
            {
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
        }

        private void tboxABLineName_Enter(object sender, EventArgs e)
        {
            tboxABLineName.Text = "";
        }

        private void FormABLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Width < 300) e.Cancel = true;
        }

        private void lvLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mf.ABLine.numABLineSelected = idx + 1;

            if (lvLines.SelectedItems.Count > 0)
            {
                int idx = lvLines.SelectedIndices[0];
                mf.ABLine.abHeading = mf.ABLine.lineArr[idx].heading;
                mf.ABLine.refPoint1 = mf.ABLine.lineArr[idx].origin;

                mf.ABLine.SetABLineByHeading();

            }
            //lvLines.SelectedItems.Clear();
        }

        private void ShowFullPanel(bool showPanel)
        {
            if (showPanel)
            {
                isFullPanel = true;
                this.Size = new System.Drawing.Size(438, 411);
                lvLines.Visible = true;
                label3.Visible = true;
                tboxABLineName.Visible = true;
                btnListDelete.Visible = true;
                btnListUse.Visible = true;
                btnAddToFile.Visible = true;
                btnAddAndGo.Visible = true;

                btnAPoint.Visible = false ;
                btnBPoint.Visible = false;
                btnUpABHeadingBy1.Visible = false;
                btnDnABHeadingBy1.Visible = false;
                tboxHeading.Visible = false;
            }
            else   //hide the panel
            {
                isFullPanel = false;
                this.Size = new System.Drawing.Size(313, 411);
                lvLines.Visible = false;
                label3.Visible = false;
                tboxABLineName.Visible = false;
                btnListDelete.Visible = false;
                btnListUse.Visible = false;
                btnAddToFile.Visible = false;
                btnAddAndGo.Visible = false;

                btnAPoint.Visible = true;
                btnBPoint.Visible = true;
                btnUpABHeadingBy1.Visible = true;
                btnDnABHeadingBy1.Visible = true;
                tboxHeading.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mf.ABLine.numABLines = mf.ABLine.lineArr.Count;
            if (mf.ABLine.numABLineSelected > mf.ABLine.numABLines) mf.ABLine.numABLineSelected = mf.ABLine.numABLines;


            if (mf.ABLine.numABLines < originalSelected) mf.ABLine.numABLineSelected = 0;
            else mf.ABLine.numABLineSelected = originalSelected;

            if (mf.ABLine.numABLineSelected > 0)
            {
                mf.ABLine.abHeading = mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].heading;
                mf.ABLine.refPoint1 = mf.ABLine.lineArr[mf.ABLine.numABLineSelected - 1].origin;
                mf.ABLine.SetABLineByHeading();
                Close();
            }
            else
            {
                //mf.ABLine.tramPassEvery = 0;
                //mf.ABLine.tramBasedOn = 0;
                mf.btnABLine.Image = Properties.Resources.ABLineOff;
                mf.ABLine.isBtnABLineOn = false;
                mf.ABLine.isABLineSet = false;
                mf.ABLine.isABLineLoaded = false;
                mf.ABLine.numABLineSelected = 0;
                mf.DisableYouTurnButtons();
                if (mf.isAutoSteerBtnOn) mf.btnAutoSteer.PerformClick();
                if (mf.yt.isYouTurnBtnOn) mf.btnAutoYouTurn.PerformClick();
                Close();
            }

        }
    }
}
