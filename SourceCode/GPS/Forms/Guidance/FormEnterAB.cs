using System;
using System.Globalization;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormEnterAB : Form
    {
        private readonly FormGPS mf = null;

        private int originalLine = 0;

        private bool isAB = true;


        public FormEnterAB(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            this.Text = gStr.gsEditABLine;
            nudLatitude.Controls[0].Enabled = false;
            nudLongitude.Controls[0].Enabled = false;
            nudLatitudeB.Controls[0].Enabled = false;
            nudLatitudeB.Controls[0].Enabled = false;
            nudHeading.Controls[0].Enabled = false;

            nudLatitude.Value = (decimal)mf.pn.latitude;
            nudLatitudeB.Value = (decimal)mf.pn.latitude;
            nudLongitude.Value = (decimal)mf.pn.longitude;
            nudLongitudeB.Value = (decimal)mf.pn.longitude;
        }

        private void FormEnterAB_Load(object sender, EventArgs e)
        {

            label1.Text = mf.unitsInCm;
            btnCancel.Focus();

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

        private void bntOk_Click(object sender, EventArgs e)
        {
            mf.FileSaveABLines();
            mf.ABLine.moveDistance = 0;
            mf.ABLine.isABValid = false;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNewABLine_Click(object sender, EventArgs e)
        {
            double east, nort;

            if (isAB)
            {

                mf.pn.ConvertWGS84ToLocal((double)nudLatitude.Value, (double)nudLongitude.Value, out nort, out east);

                mf.ABLine.desPoint1.easting = east;
                mf.ABLine.desPoint1.northing = nort;

                mf.pn.ConvertWGS84ToLocal((double)nudLatitudeB.Value, (double)nudLongitudeB.Value, out nort, out east);
                mf.ABLine.desPoint2.easting = east;
                mf.ABLine.desPoint2.northing = nort;

                // heading based on AB points
                mf.ABLine.desHeading = Math.Atan2(mf.ABLine.desPoint2.easting - mf.ABLine.desPoint1.easting,
                    mf.ABLine.desPoint2.northing - mf.ABLine.desPoint1.northing);
                if (mf.ABLine.desHeading < 0) mf.ABLine.desHeading += glm.twoPI;

                nudHeading.Value = (decimal)(glm.toDegrees(mf.ABLine.desHeading));
            }
            else
            {
                mf.pn.ConvertWGS84ToLocal((double)nudLatitude.Value, (double)nudLongitude.Value, out nort, out east);

                mf.ABLine.desPoint1.easting = east;
                mf.ABLine.desPoint1.northing = nort;

            }

            //
            mf.ABLine.desHeading = glm.toRadians((double)nudHeading.Value);

            mf.ABLine.lineArr.Add(new CABLines());
            mf.ABLine.numABLines = mf.ABLine.lineArr.Count;
            mf.ABLine.numABLineSelected = mf.ABLine.numABLines;

            //index to last one. 
            int idx = mf.ABLine.lineArr.Count - 1;

            if (idx >= 0)
            {
                mf.ABLine.lineArr[idx].heading = mf.ABLine.abHeading;
                //calculate the new points for the reference line and points
                mf.ABLine.lineArr[idx].origin.easting = mf.ABLine.desPoint1.easting;
                mf.ABLine.lineArr[idx].origin.northing = mf.ABLine.desPoint1.northing;
                if (textBox1.Text.Trim() == "") textBox1.Text = "No Name "
                        + DateTime.Now.ToString("hh:mm:ss", CultureInfo.InvariantCulture);
                mf.ABLine.lineArr[idx].Name = "AB " 
                    + (Math.Round(glm.toDegrees(mf.ABLine.desHeading), 1)).ToString(CultureInfo.InvariantCulture) 
                    + "\u00B0 " + mf.FindDirection(mf.ABLine.desHeading) + " " + textBox1.Text.Trim();
            }

            UpdateLineList();
        }

        private void nudHeading_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            btnCancel.Focus();
        }

        private void btnChooseType_Click(object sender, EventArgs e)
        {
            isAB = !isAB;
            if (isAB)
            {
                nudLatitudeB.Enabled = true;
                nudLongitudeB.Enabled = true;
                nudHeading.Enabled = false;
                btnChooseType.Text = "AB";
            }
            else
            {
                nudLatitudeB.Enabled = false;
                nudLongitudeB.Enabled = false;
                nudHeading.Enabled = true;
                btnChooseType.Text = "A+";
            }
        }

        private void nudLatitude_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            btnCancel.Focus();
        }

        private void nudLongitude_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            btnCancel.Focus();
        }

        private void nudLatitudeB_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            btnCancel.Focus();
        }

        private void nudLongitudeB_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            btnCancel.Focus();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender, this);
                btnCancel.Focus();
            }
        }
    }
}
