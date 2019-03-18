using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormSimCoords : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        private double newLat, newLon;

        private void nudLatitude_ValueChanged(object sender, EventArgs e)
        {
            newLat = (double)nudLatitude.Value;
        }

        private void nudLongitude_ValueChanged(object sender, EventArgs e)
        {
            newLon = (double)nudLongitude.Value;
        }

        private void FormSimCoords_Load(object sender, EventArgs e)
        {
            nudLatitude.Value = (decimal)newLat;
            nudLongitude.Value = (decimal)newLon;
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            mf.sim.latitude = newLat;
            mf.sim.longitude = newLon;
            Properties.Settings.Default.setGPS_Latitude = newLat;
            Properties.Settings.Default.setGPS_Longitude = newLon;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public FormSimCoords(Form callingForm, double Lat, double Longi)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();
            newLat = Lat;
            newLon = Longi;
        }
    }
}