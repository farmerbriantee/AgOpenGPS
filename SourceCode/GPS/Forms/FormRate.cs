using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormRate : Form
    {
        private readonly FormGPS mf = null;

        private readonly double setting2NUD, NUD2Setting;

        private double rate1, rate2;


        public FormRate(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();

            if (mf.isMetric)
            {
                //no conversion
                setting2NUD = 1.0;
                NUD2Setting = 1.0;
                lblVolumePerArea.Text = "Liters Per Hectare";
            }
            else
            {
                //0.106907
                setting2NUD = glm.LHa2galAc;

                //9.35396
                NUD2Setting = glm.galAc2Lha;
                lblVolumePerArea.Text = "US Gallons Per Acre";
            }
        }

        private void FormRate_Load(object sender, EventArgs e)
        {
            //get the last saved rates from setting file - always stored in L/Ha
            rate1 = Properties.Settings.Default.setRate_rate1;
            rate2 = Properties.Settings.Default.setRate_rate2;

            //Update NUD if metric or Imp
            nudRate1.ValueChanged -= nudRate1_ValueChanged;
            nudRate1.Value = (decimal)(rate1 * setting2NUD);
            nudRate1.ValueChanged += nudRate1_ValueChanged;

            nudRate2.ValueChanged -= nudRate2_ValueChanged;
            nudRate2.Value = (decimal)(rate2 * setting2NUD);
            nudRate2.ValueChanged += nudRate2_ValueChanged;

            //Always in counts/Liter
            nudCalFactor.Value = Properties.Settings.Default.setRate_FlowmeterCalNumber;

            //grab the latest volume
            lblAccumulatedVolume.Text = mf.rc.volumeActual.ToString();
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.setRate_rate1 = rate1;
            Properties.Settings.Default.setRate_rate2 = rate2;
            Properties.Settings.Default.Save();

            mf.rc.rate1 = rate1;
            mf.rc.rate2 = rate2;

            Close();
        }

        private void btnResetAccumulatedVolume_Click(object sender, EventArgs e)
        {
            mf.mc.relayRateSettings[mf.mc.rsAccumulatedVolumeHi] = (32700 >> 8);
            mf.mc.relayRateSettings[mf.mc.rsAccumulatedVolumeLo] = unchecked((byte)32700);
            Properties.Settings.Default.setRate_AccumulatedVolume = 0;
            Properties.Settings.Default.Save();

            mf.RateRelayOutToPort(mf.mc.relayRateSettings, CModuleComm.numRelayRateSettingsItems);
            mf.mc.relayRateSettings[mf.mc.rsAccumulatedVolumeHi] = 0;
            mf.mc.relayRateSettings[mf.mc.rsAccumulatedVolumeLo] = 0;
            mf.rc.volumeActual = 0;
            lblAccumulatedVolume.Text = mf.rc.volumeActual.ToString();
        }

        private void nudCalFactor_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.setRate_FlowmeterCalNumber = (uint)nudCalFactor.Value;
            Properties.Settings.Default.Save();

            mf.mc.relayRateSettings[mf.mc.rsFlowCalFactorHi] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumber >> 8);
            mf.mc.relayRateSettings[mf.mc.rsFlowCalFactorLo] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumber);
            mf.RateRelayOutToPort(mf.mc.relayRateSettings, CModuleComm.numRelayRateSettingsItems);
        }

        private void nudRate1_ValueChanged(object sender, EventArgs e)
        {
            rate1 = (double)nudRate1.Value * NUD2Setting;
        }

        private void nudRate2_ValueChanged(object sender, EventArgs e)
        {
            rate2 = (double)nudRate2.Value * NUD2Setting;
        }

        private void btnRate1Up_MouseDown(object sender, MouseEventArgs e)
        {
            nudRate1.ValueChanged -= nudRate1_ValueChanged;

            nudRate1.Value += (decimal)0.1;
            if (nudRate1.Value > nudRate1.Maximum) nudRate1.Value = nudRate1.Maximum;

            //always in L/ha
            rate1 = (double)nudRate1.Value * NUD2Setting;

            nudRate1.ValueChanged += nudRate1_ValueChanged;
        }

        private void btnRate1Dn_MouseDown(object sender, MouseEventArgs e)
        {
            nudRate1.ValueChanged -= nudRate1_ValueChanged;

            nudRate1.Value -= (decimal)0.1;
            if (nudRate1.Value < nudRate1.Minimum) nudRate1.Value = nudRate1.Minimum;

            //always in L/ha
            rate1 = (double)nudRate1.Value * NUD2Setting;

            nudRate1.ValueChanged += nudRate1_ValueChanged;
        }

        private void btnRate2Up_MouseDown(object sender, MouseEventArgs e)
        {
            nudRate2.ValueChanged -= nudRate2_ValueChanged;

            nudRate2.Value += (decimal)0.1;
            if (nudRate2.Value > nudRate2.Maximum) nudRate2.Value = nudRate2.Maximum;

            //always in L/ha
            rate2 = (double)nudRate2.Value * NUD2Setting;

            nudRate2.ValueChanged += nudRate2_ValueChanged;
        }

        private void btnRate2Dn_MouseDown(object sender, MouseEventArgs e)
        {
            nudRate2.ValueChanged -= nudRate2_ValueChanged;

            nudRate2.Value -= (decimal)0.1;
            if (nudRate2.Value < nudRate2.Minimum) nudRate2.Value = nudRate2.Minimum;

            //always in L/ha
            rate2 = (double)nudRate2.Value * NUD2Setting;

            nudRate2.ValueChanged += nudRate2_ValueChanged;
        }
    }
}
