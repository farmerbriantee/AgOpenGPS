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
    public partial class FormSteer : Form
    {
        private FormGPS mf = null;

        public decimal ReturnValue1 { get; set; }

        public FormSteer(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tboxSerialFromAutoSteer.Text = mf.modcom.serialRecvAutoSteerStr;
            tboxSerialToAutoSteer.Text = mf.modcom.autoSteerControl[0] + ", " + mf.modcom.autoSteerControl[1]
                                + ", " + mf.modcom.autoSteerControl[2] + ", " + mf.modcom.autoSteerControl[3]
                                    + ", " + mf.guidanceLineDistanceOff + ", " + mf.guidanceLineHeadingDelta;
        }

        //Send to Autosteer to adjust PIDO values, LSB is up or down
        private void btnPPlus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[2] += 1;
            lblPValue.Text = mf.modcom.autoSteerSettings[2].ToString();
            Properties.Settings.Default.setAS_Kp = mf.modcom.autoSteerSettings[2];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnPMinus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[2] -= 1;
            if (mf.modcom.autoSteerSettings[2] == 255) mf.modcom.autoSteerSettings[2] = 0;
            lblPValue.Text = mf.modcom.autoSteerSettings[2].ToString();
            Properties.Settings.Default.setAS_Kp = mf.modcom.autoSteerSettings[2];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnIPlus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[3] += 1;
            lblIValue.Text = mf.modcom.autoSteerSettings[3].ToString();
            Properties.Settings.Default.setAS_Ki = mf.modcom.autoSteerSettings[3];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnIMinus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[3] -= 1;
            if (mf.modcom.autoSteerSettings[3] == 255) mf.modcom.autoSteerSettings[3] = 0;
            lblIValue.Text = mf.modcom.autoSteerSettings[3].ToString();
            Properties.Settings.Default.setAS_Ki = mf.modcom.autoSteerSettings[3];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnDPlus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[4] += 1;
            lblDValue.Text = mf.modcom.autoSteerSettings[4].ToString();
            Properties.Settings.Default.setAS_Kd = mf.modcom.autoSteerSettings[4];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnDMinus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[4] -= 1;
            if (mf.modcom.autoSteerSettings[4] == 255) mf.modcom.autoSteerSettings[4] = 0;
            lblDValue.Text = mf.modcom.autoSteerSettings[4].ToString();
            Properties.Settings.Default.setAS_Kd = mf.modcom.autoSteerSettings[4];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnOPlus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[5] += 1;
            lblOValue.Text = mf.modcom.autoSteerSettings[5].ToString();
            Properties.Settings.Default.setAS_Ko = mf.modcom.autoSteerSettings[5];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnOMinus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[5] -= 1;
            if (mf.modcom.autoSteerSettings[5] == 255) mf.modcom.autoSteerSettings[5] = 0;
            lblOValue.Text = mf.modcom.autoSteerSettings[5].ToString();
            Properties.Settings.Default.setAS_Ko = mf.modcom.autoSteerSettings[5];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnMaxIntErrPlus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[6] += 1;
            lblMaxIntErr.Text = mf.modcom.autoSteerSettings[6].ToString();
            Properties.Settings.Default.setAS_maxIntError = mf.modcom.autoSteerSettings[6];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnMaxIntErrMinus_Click(object sender, EventArgs e)
        {
            mf.modcom.autoSteerSettings[6] -= 1;
            if (mf.modcom.autoSteerSettings[6] == 255) mf.modcom.autoSteerSettings[6] = 0;
            lblMaxIntErr.Text = mf.modcom.autoSteerSettings[6].ToString();
            Properties.Settings.Default.setAS_maxIntError = mf.modcom.autoSteerSettings[6];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void FormSteer_Load(object sender, EventArgs e)
        {
            lblPValue.Text = mf.modcom.autoSteerSettings[2].ToString();
            lblIValue.Text = mf.modcom.autoSteerSettings[3].ToString();
            lblDValue.Text = mf.modcom.autoSteerSettings[4].ToString();
            lblOValue.Text = mf.modcom.autoSteerSettings[5].ToString();
            lblMaxIntErr.Text = mf.modcom.autoSteerSettings[6].ToString();
        } 
    }
}
