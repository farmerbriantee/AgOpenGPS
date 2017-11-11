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
    public partial class FormRate : Form
    {
        private readonly FormGPS mf = null;

        public FormRate(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void FormRate_Load(object sender, EventArgs e)
        {
            //get the last saved rates from setting file
            mf.rc.rate1 = Properties.Settings.Default.setRate_rate1;
            mf.rc.rate2 = Properties.Settings.Default.setRate_rate2;

            lblRate1Value.Text = ((double)mf.rc.rate1 * 0.1).ToString("N1");
            lblRate2Value.Text = ((double)mf.rc.rate2 * 0.1).ToString("N1");
            mf.rc.isRate1Selected = true;
            if (mf.rc.isRateControlOn)
            {
                btnRateOnOff.Text = "On";
                btnRateOnOff.BackColor = Color.LightGreen;
                btnRate1Dn.Enabled = true;
                btnRate1Up.Enabled = true;
                btnRate2Dn.Enabled = true;
                btnRate2Up.Enabled = true;
            }
            else
            {
                btnRateOnOff.Text = "Off";
                btnRateOnOff.BackColor = SystemColors.ButtonFace;
                btnRate1Dn.Enabled = false;
                btnRate1Up.Enabled = false;
                btnRate2Dn.Enabled = false;
                btnRate2Up.Enabled = false;
            }
        }

        private void btnRate1Up_MouseDown(object sender, MouseEventArgs e)
        {
            mf.rc.rate1++;
            lblRate1Value.Text = ((double)mf.rc.rate1*0.1).ToString("N1");
        }

        private void btnRate1Dn_MouseDown(object sender, MouseEventArgs e)
        {
            mf.rc.rate1--;
            lblRate1Value.Text = ((double)mf.rc.rate1*0.1).ToString("N1");
        }

        private void btnRate2Up_MouseDown(object sender, MouseEventArgs e)
        {
            mf.rc.rate2++;
            lblRate2Value.Text = ((double)mf.rc.rate2 * 0.1).ToString("N1");
        }

        private void btnRate2Dn_MouseDown(object sender, MouseEventArgs e)
        {
            mf.rc.rate2--;
            lblRate2Value.Text = ((double)mf.rc.rate2 * 0.1).ToString("N1");
        }

        private void btnRateOnOff_Click(object sender, EventArgs e)
        {
            if (!mf.rc.isRateControlOn) //is it already Off?
            {
                mf.rc.isRateControlOn = !mf.rc.isRateControlOn;
                btnRateOnOff.Text = "On";
                btnRateOnOff.BackColor = Color.LightGreen;
                btnRate1Dn.Enabled = true;
                btnRate1Up.Enabled = true;
                btnRate2Dn.Enabled = true;
                btnRate2Up.Enabled = true;
            }
            else
            {
                mf.rc.isRateControlOn = !mf.rc.isRateControlOn;
                btnRateOnOff.Text = "Off";
                btnRateOnOff.BackColor = SystemColors.ButtonFace;
                btnRate1Dn.Enabled = false;
                btnRate1Up.Enabled = false;
                btnRate2Dn.Enabled = false;
                btnRate2Up.Enabled = false;
            }
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.setRate_rate1 = mf.rc.rate1;
            Properties.Settings.Default.setRate_rate2 = mf.rc.rate2;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
