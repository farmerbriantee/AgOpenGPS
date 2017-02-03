//Please, if you use this give me some credit
//Copyright BrianTee, copy right out of it.

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
    public partial class FormGPSData : Form
    {
        private FormGPS mainForm = null;

        public decimal ReturnValue1 { get; set; }

        public FormGPSData(Form callingForm)
        {
            mainForm = callingForm as FormGPS;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.ReturnValue1 = numeric1.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //all the fixings and position
            lblNorthing.Text = mainForm.FixNorthing;
            lblEasting.Text = mainForm.FixEasting;
            lblLatitude.Text = mainForm.Latitude;
            lblLongitude.Text = mainForm.Longitude;
            lblAltitude.Text = mainForm.Altitude;

            //other sat and GPS info
            lblFixQuality.Text = mainForm.FixQuality;
            lblSatsTracked.Text = mainForm.SatsTracked;
            lblStatus.Text = mainForm.Status;
            lblHDOP.Text = mainForm.HDOP;

        }
    }
}
