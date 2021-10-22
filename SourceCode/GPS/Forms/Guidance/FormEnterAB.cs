using System;
using System.Globalization;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormEnterAB : Form
    {
        private readonly FormGPS mf = null;

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
            nudLatitudeB.Value = (decimal)mf.pn.latitude + 0.000001m;
            nudLongitude.Value = (decimal)mf.pn.longitude;
            nudLongitudeB.Value = (decimal)mf.pn.longitude + 0.000001m;
        }

        private void FormEnterAB_Load(object sender, EventArgs e)
        {
            btnEnterManual.Focus();
            textBox1.Text = "Create A New Line";
        }

        private void nudHeading_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            btnEnterManual.Focus();
            CalcHeading();
        }

        private void btnChooseType_Click(object sender, EventArgs e)
        {
            isAB = !isAB;
            if (isAB)
            {
                nudLatitudeB.Enabled = true;
                nudLongitudeB.Enabled = true;
                nudHeading.Enabled = false;
                nudLatitudeB.Visible = true;
                nudLongitudeB.Visible = true;
                nudHeading.Visible = false;
                label4.Visible = false;
                label5.Visible = true;
            }
            else
            {
                nudLatitudeB.Enabled = false;
                nudLongitudeB.Enabled = false;
                nudHeading.Enabled = true;
                nudLatitudeB.Visible = false;
                nudLongitudeB.Visible = false;
                nudHeading.Visible = true;
                label4.Visible = true;
                label5.Visible = false;
            }
            CalcHeading();
        }

        private void nudLatitude_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            btnEnterManual.Focus();
            CalcHeading();
        }

        private void nudLongitude_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            btnEnterManual.Focus();
            CalcHeading();
        }

        private void nudLatitudeB_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            btnEnterManual.Focus();
            CalcHeading();
        }

        private void nudLongitudeB_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            btnEnterManual.Focus();
            CalcHeading();
        }

        private void btnEnterManual_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Create A New Line") this.DialogResult = DialogResult.Cancel;
            Close();
        }

        public void CalcHeading()
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

                mf.ABLine.desHeading = glm.toRadians((double)nudHeading.Value);
                mf.ABLine.desPoint1.easting = east;
                mf.ABLine.desPoint1.northing = nort;
            }

            textBox1.Text = "Manual AB " +
                (Math.Round(glm.toDegrees(mf.ABLine.desHeading), 1)).ToString(CultureInfo.InvariantCulture) +
                "\u00B0 " + mf.FindDirection(mf.ABLine.desHeading);
            if (textBox1.Text != "Create A New Line") btnEnterManual.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
