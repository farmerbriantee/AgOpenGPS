using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormVariables : Form
    {
        private FormGPS mf = null;
        public FormVariables(Form callingForm)
        {     
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //all the fixings and position
            lblNorthing.Text = mf.FixNorthing;
            lblEasting.Text = mf.FixEasting;
            lblLatitude.Text = mf.Latitude;
            lblLongitude.Text = mf.Longitude;
            lblAltitude.Text = mf.Altitude;
            lblHeadingDelta.Text = Convert.ToString(Math.Round(mf.fixHeadingDelta, 3));

        }
    }
}

 