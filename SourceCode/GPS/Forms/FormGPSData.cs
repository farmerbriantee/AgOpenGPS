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

        public decimal ReturnValue1 { get; set; }

        int pValue = 0, iValue = 0, dValue = 0, oValue = 0;

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
                                    + ", " + mf.guidanceLineDistanceOff + ", " + mf.guidanceLineHeadingDelta
                                    + ", " + mf.modcom.autoSteerControl[8];
        }

        //Send to Autosteer to adjust PIDO values, LSB is up or down
        private void btnPPlus_Click(object sender, EventArgs e)
        {
            //0000 0011
            mf.modcom.autoSteerControl[8] = (byte)3;
            pValue++;
            lblPValue.Text = pValue.ToString();
        }

        private void btnPMinus_Click(object sender, EventArgs e)
        {
            //0000 0010
            mf.modcom.autoSteerControl[8] = (byte)2;
            pValue--;
            lblPValue.Text = pValue.ToString();
        }

        private void btnIPlus_Click(object sender, EventArgs e)
        {
            //0000 0101
            mf.modcom.autoSteerControl[8] = (byte)5;
            iValue++;
            lblIValue.Text = iValue.ToString();
        }

        private void btnIMinus_Click(object sender, EventArgs e)
        {
            //0000 0100
            mf.modcom.autoSteerControl[8] = (byte)4;
            iValue--;
            lblIValue.Text = iValue.ToString();
        }

        private void btnDPlus_Click(object sender, EventArgs e)
        {
            //0000 1001
            mf.modcom.autoSteerControl[8] = (byte)11;
            dValue++;
            lblDValue.Text = dValue.ToString();
        }

        private void btnDMinus_Click(object sender, EventArgs e)
        {
            //0000 1000
            mf.modcom.autoSteerControl[8] = (byte)10;
            dValue--;
            lblDValue.Text = dValue.ToString();
        }

        private void btnOPlus_Click(object sender, EventArgs e)
        {
            //0001 0001
            mf.modcom.autoSteerControl[8] = (byte)17;
            oValue++;
            lblOValue.Text = oValue.ToString();
        }

        private void btnOMinus_Click(object sender, EventArgs e)
        {
            //0001 0000
            mf.modcom.autoSteerControl[8] = (byte)16;
            oValue--;
            lblOValue.Text = oValue.ToString();
        }
     }
}
