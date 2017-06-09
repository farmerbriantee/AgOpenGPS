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
        private FormGPS mf = null;

        //public decimal ReturnValue1 { get; set; }

        public FormGPSData(Form callingForm)
        {
            mf = callingForm as FormGPS;
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
            lblZone.Text = mf.Zone;
            lblNorthing.Text = mf.FixNorthing;
            lblEasting.Text = mf.FixEasting;
            lblLatitude.Text = mf.Latitude;
            lblLongitude.Text = mf.Longitude;
            lblAltitude.Text = mf.Altitude;

            //other sat and GPS info
            lblFixQuality.Text = mf.FixQuality;
            lblSatsTracked.Text = mf.SatsTracked;
            lblStatus.Text = mf.Status;
            lblHDOP.Text = mf.HDOP;

            tboxSerialFromRelay.Text = mf.modcom.serialRecvRelayStr;
            tboxSerialToRelay.Text = mf.modcom.relaySectionControl[0].ToString();
            tboxNMEASerial.Text = mf.recvSentenceSettings;
            //tboxNMEASerial.Text = mainForm.pn.rawBuffer;

            tboxSerialFromAutoSteer.Text = mf.modcom.serialRecvAutoSteerStr;
            tboxSerialToAutoSteer.Text = mf.modcom.autoSteerControl[0] + ", " + mf.modcom.autoSteerControl[1]
                                + ", " + mf.modcom.autoSteerControl[2] + ", " + mf.modcom.autoSteerControl[3]
                                    + ", " + mf.guidanceLineDistanceOff + ", " + mf.guidanceLineHeadingDelta;
        }
 
     }
}
