//Please, if you use this, share the improvements

using System;
using System.Globalization;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormABLine : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        private int originalLine = 0;
        private bool isClosing;

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
            //btnAddToFile.Enabled = false;
            //btnAddAndGo.Enabled = false;
            //btnAPoint.Enabled = false;
            //btnBPoint.Enabled = false;
            //cboxHeading.Enabled = false;
            //tboxHeading.Enabled = false;
            //tboxABLineName.Text = "";
            //tboxABLineName.Enabled = false;

            //small window
            //ShowFullPanel(true);

            panelPick.Top = 3;
            panelPick.Left = 3;
            panelAPlus.Top = 3;
            panelAPlus.Left = 3;
            panelName.Top = 3;
            panelName.Left = 3;

            panelEditName.Top = 3;
            panelEditName.Left = 3;

            panelPick.Visible = true;
            panelAPlus.Visible = false;
            panelName.Visible = false;
            panelEditName.Visible = false;

            this.Size = new System.Drawing.Size(470, 360);

            originalLine = mf.ABLine.numABLineSelected;

            mf.ABLine.isABLineBeingSet = false;
            UpdateLineList();
            if (lvLines.Items.Count > 0 && originalLine > 0)
            {
                lvLines.Items[originalLine - 1].EnsureVisible();
                lvLines.Items[originalLine - 1].Selected = true;
                lvLines.Select();
            }
        }

        private void UpdateLineList()
        {
            lvLines.Clear();
            ListViewItem itm;

            foreach (CABLines item in mf.ABLine.lineArr)
            {
                itm = new ListViewItem(item.Name);
                lvLines.Items.Add(itm);
            }

            // go to bottom of list - if there is a bottom
            if (lvLines.Items.Count > 0)
            {
                lvLines.Items[lvLines.Items.Count - 1].EnsureVisible();
                lvLines.Items[lvLines.Items.Count - 1].Selected = true;
                lvLines.Select();
            }
        }

        private void btnCancel_APlus_Click(object sender, EventArgs e)
        {
            panelPick.Visible = true;
            panelAPlus.Visible = false;
            panelEditName.Visible = false;
            panelName.Visible = false;

            this.Size = new System.Drawing.Size(470, 360);

            UpdateLineList();
            mf.ABLine.isABLineBeingSet = false;
            btnBPoint.BackColor = System.Drawing.Color.Transparent;
        }

        private void btnAPoint_Click(object sender, EventArgs e)
        {
            vec3 fix = new vec3(mf.pivotAxlePos);

            mf.ABLine.desPoint1.easting = fix.easting + Math.Cos(fix.heading) * mf.tool.offset;
            mf.ABLine.desPoint1.northing = fix.northing - Math.Sin(fix.heading) * mf.tool.offset;
            mf.ABLine.desHeading = fix.heading;

            mf.ABLine.desPoint2.easting = 99999;
            mf.ABLine.desPoint2.northing = 99999;

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

            mf.ABLine.desPoint2.easting = fix.easting + Math.Cos(fix.heading) * mf.tool.offset;
            mf.ABLine.desPoint2.northing = fix.northing - Math.Sin(fix.heading) * mf.tool.offset;

            // heading based on AB points
            mf.ABLine.desHeading = Math.Atan2(mf.ABLine.desPoint2.easting - mf.ABLine.desPoint1.easting,
                mf.ABLine.desPoint2.northing - mf.ABLine.desPoint1.northing);
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
            mf.ABLine.desP1.easting = mf.ABLine.desPoint1.easting - (Math.Sin(mf.ABLine.desHeading) * mf.ABLine.abLength);
            mf.ABLine.desP1.northing = mf.ABLine.desPoint1.northing - (Math.Cos(mf.ABLine.desHeading) * mf.ABLine.abLength);
            mf.ABLine.desP2.easting = mf.ABLine.desPoint1.easting + (Math.Sin(mf.ABLine.desHeading) * mf.ABLine.abLength);
            mf.ABLine.desP2.northing = mf.ABLine.desPoint1.northing + (Math.Cos(mf.ABLine.desHeading) * mf.ABLine.abLength);
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
            lvLines.SelectedItems.Clear();
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
            if (lvLines.SelectedItems.Count > 0)
            {
                int idx = lvLines.SelectedIndices[0];
                textBox2.Text = mf.ABLine.lineArr[idx].Name;

                panelPick.Visible = false;
                panelEditName.Visible = true;
                this.Size = new System.Drawing.Size(270, 360);
            }
        }

        private void btnSaveEditName_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "") textBox2.Text = "No Name " + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);

            int idx = lvLines.SelectedIndices[0];

            panelEditName.Visible = false;
            panelPick.Visible = true;

            mf.ABLine.lineArr[idx].Name = textBox2.Text.Trim();
            mf.FileSaveABLines();

            this.Size = new System.Drawing.Size(470, 360);

            UpdateLineList();
            lvLines.Focus();
            mf.ABLine.isABLineBeingSet = false;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            mf.ABLine.lineArr.Add(new CABLines());
            mf.ABLine.numABLines = mf.ABLine.lineArr.Count;
            mf.ABLine.numABLineSelected = mf.ABLine.numABLines;

            //index to last one. 
            int idx = mf.ABLine.lineArr.Count - 1;

            mf.ABLine.lineArr[idx].heading = mf.ABLine.desHeading;
            //calculate the new points for the reference line and points
            mf.ABLine.lineArr[idx].origin.easting = mf.ABLine.desPoint1.easting;
            mf.ABLine.lineArr[idx].origin.northing = mf.ABLine.desPoint1.northing;

            //name
            if (textBox2.Text.Trim() == "") textBox2.Text = "No Name " + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);

            mf.ABLine.lineArr[idx].Name = textBox1.Text.Trim();

            mf.FileSaveABLines();

            panelPick.Visible = true;
            panelAPlus.Visible = false;
            panelName.Visible = false;

            this.Size = new System.Drawing.Size(470, 360);

            UpdateLineList();
            lvLines.Focus();
            mf.ABLine.isABLineBeingSet = false;
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if (lvLines.SelectedItems.Count > 0)
            {
                int idx = lvLines.SelectedIndices[0];


                panelPick.Visible = false;
                panelName.Visible = true;
                this.Size = new System.Drawing.Size(270, 360);

                panelAPlus.Visible = false;
                panelName.Visible = true;

                mf.ABLine.desHeading = mf.ABLine.lineArr[idx].heading;

                //calculate the new points for the reference line and points                
                mf.ABLine.desPoint1.easting = mf.ABLine.lineArr[idx].origin.easting;
                mf.ABLine.desPoint1.northing = mf.ABLine.lineArr[idx].origin.northing;

                mf.ABLine.desName = mf.ABLine.lineArr[idx].Name + " Copy";

                textBox1.Text = mf.ABLine.desName;
            }

        }

        private void btnListUse_Click(object sender, EventArgs e)
        {
            isClosing = true;
            mf.ABLine.moveDistance = 0;
            //reset to generate new reference
            mf.ABLine.isABValid = false;

            if (lvLines.SelectedItems.Count > 0)
            {
                int idx = lvLines.SelectedIndices[0];
                mf.ABLine.numABLineSelected = idx + 1;

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
        private void btnSwapAB_Click(object sender, EventArgs e)
        {
            if (lvLines.SelectedItems.Count > 0)
            {
                mf.ABLine.isABValid = false;
                int idx = lvLines.SelectedIndices[0];


                mf.ABLine.lineArr[idx].heading += Math.PI;
                if (mf.ABLine.lineArr[idx].heading > glm.twoPI) mf.ABLine.lineArr[idx].heading -= glm.twoPI;


                mf.FileSaveABLines();

                UpdateLineList();
                lvLines.Focus();
            }
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
            UpdateLineList();
            lvLines.Focus();

        }

        private void FormABLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                e.Cancel = true;
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isClosing = true;

            mf.btnABLine.Image = Properties.Resources.ABLineOff;
            mf.ABLine.isBtnABLineOn = false;
            mf.ABLine.isABLineSet = false;
            mf.ABLine.isABLineLoaded = false;
            mf.ABLine.numABLineSelected = 0;
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
                    mf.ABLine.desP1.easting = mf.ABLine.desPoint1.easting - (Math.Sin(mf.ABLine.desHeading) * mf.ABLine.abLength);
                    mf.ABLine.desP1.northing = mf.ABLine.desPoint1.northing - (Math.Cos(mf.ABLine.desHeading) * mf.ABLine.abLength);
                    mf.ABLine.desP2.easting = mf.ABLine.desPoint1.easting + (Math.Sin(mf.ABLine.desHeading) * mf.ABLine.abLength);
                    mf.ABLine.desP2.northing = mf.ABLine.desPoint1.northing + (Math.Cos(mf.ABLine.desHeading) * mf.ABLine.abLength);
                }
                else
                {
                    btnCancel_APlus.PerformClick();
                }
            }
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

        #endregion
    }
}
