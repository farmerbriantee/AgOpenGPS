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

            lblAntennaPivot.Text = Math.Round(mf.vehicle.antennaPivot,2).ToString();
            lblHitchLength.Text = Math.Round(mf.vehicle.hitchLength,2).ToString();
            lblTrailingHitchLength.Text = Math.Round(mf.vehicle.toolTrailingHitchLength,2).ToString();
            lblToolWidth.Text = Math.Round(mf.vehicle.toolWidth,2).ToString();

            lblRequestOn.Text = mf.section[0].sectionOnRequest.ToString();
            lblRequestOff.Text = mf.section[0].sectionOffRequest.ToString();
            lblCycleOnOff.Text = mf.section[0].sectionOnOffCycle.ToString();
            lblTimerOn.Text = mf.section[0].sectionOnTimer.ToString();
            lblTimerOff.Text = mf.section[0].sectionOffTimer.ToString();

            lblHeadingFix.Text = mf.FixHeading;
            lblHeadingSection.Text = mf.FixHeadingSection;
            lblHeadingDelta.Text = (Math.Round(Math.PI - Math.Abs(Math.Abs(mf.fixHeadingSection - mf.fixHeading) - Math.PI),2)).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

 