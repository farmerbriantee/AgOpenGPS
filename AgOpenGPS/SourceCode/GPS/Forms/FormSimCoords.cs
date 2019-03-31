using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormSimCoords : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        private double newLat, newLon;

        //private void nudLatitude_ValueChanged(object sender, EventArgs e)
        //{
        //    newLat = (double)nudLatitude.Value;
        //}

        //private void nudLongitude_ValueChanged(object sender, EventArgs e)
        //{
        //    newLon = (double)nudLongitude.Value;
        //}

        private void FormSimCoords_Load(object sender, EventArgs e)
        {
            nudLatitude.Value = (decimal)Properties.Settings.Default.setGPS_Latitude;
            nudLongitude.Value = (decimal)Properties.Settings.Default.setGPS_Longitude;

            lblLatStart.Text = mf.pn.latStart.ToString("N6");
            lblLonStart.Text = mf.pn.lonStart.ToString("N6");
            if (mf.pn.latStart == 0)
            {
                btnGetFieldFix.Enabled = false;
            }

            lblGPSLat.Text = mf.pn.latitude.ToString("N6");
            lblGPSLon.Text = mf.pn.longitude.ToString("N6");
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            mf.sim.latitude = (double)nudLatitude.Value;
            mf.sim.longitude = (double)nudLongitude.Value;

            Properties.Settings.Default.setGPS_Latitude = mf.sim.latitude;
            Properties.Settings.Default.setGPS_Longitude = mf.sim.longitude;
            Properties.Settings.Default.Save();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGetFieldFix_Click(object sender, EventArgs e)
        {
            nudLatitude.Value = (decimal)mf.pn.latStart;
            nudLongitude.Value =(decimal)mf.pn.lonStart;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nudLatitude.Value =  (decimal)mf.pn.latitude;
            nudLongitude.Value = (decimal)mf.pn.longitude;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblGPSLat.Text = mf.pn.latitude.ToString("N6");
            lblGPSLon.Text = mf.pn.longitude.ToString("N6");
        }

        public FormSimCoords(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();
            //newLat = Lat;
            //newLon = Longi;
        }
    }
}