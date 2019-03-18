using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormDualRate : Form
    {
        private readonly FormGPS mf = null;
        private readonly double setting2NUD, NUD2Setting;
        private double rateLeft, rateRight;

        public FormDualRate(Form callingForm)
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

        private void FormDualRate_Load(object sender, EventArgs e)
        {
            //get the last saved rates from setting file - always stored in L/Ha
            rateLeft = Properties.Settings.Default.setRate_rateLeft;
            rateRight = Properties.Settings.Default.setRate_rateRight;

            if (mf.rcd.isSingleFlowMeter)
            {
                groupBoxLeft.Text = "Rate 1";
                groupBoxRight.Text = "Rate 2";
                nudCalFactorRight.Enabled = false;
                lblLeftCalLabel.Text = "Meter Cal";
            }
            else
            {
                groupBoxLeft.Text = "Left Rate";
                groupBoxRight.Text = "Right Rate";
            }

            //Update NUD if metric or Imp
            nudRateLeft.ValueChanged -= nudRateLeft_ValueChanged;
            nudRateLeft.Value = (decimal)(rateLeft * setting2NUD);
            nudRateLeft.ValueChanged += nudRateLeft_ValueChanged;

            nudRateRight.ValueChanged -= nudRateRight_ValueChanged;
            nudRateRight.Value = (decimal)(rateRight * setting2NUD);
            nudRateRight.ValueChanged += nudRateRight_ValueChanged;

            //Always in counts/Liter
            nudCalFactorLeft.Value = Properties.Settings.Default.setRate_FlowmeterCalNumberLeft;
            nudCalFactorRight.Value = Properties.Settings.Default.setRate_FlowmeterCalNumberRight;

            //grab the latest volume
            if (mf.isMetric) lblDualAccumulatedVolume.Text = mf.rcd.dualVolumeActual.ToString();
            else lblDualAccumulatedVolume.Text = Math.Round((mf.rcd.dualVolumeActual * glm.L2Gal), 0).ToString();
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.setRate_rateLeft = rateLeft;
            Properties.Settings.Default.setRate_rateRight = rateRight;

            Properties.Settings.Default.setRate_FlowmeterCalNumberLeft = (uint)nudCalFactorLeft.Value;
            Properties.Settings.Default.Save();

            Properties.Settings.Default.setRate_FlowmeterCalNumberRight = (uint)nudCalFactorRight.Value;
            Properties.Settings.Default.Save();

            Properties.Settings.Default.Save();
            mf.rcd.rateLeft = rateLeft;
            mf.rcd.rateRight = rateRight;
            mf.rcd.isRate1Selected = true;

            mf.mc.relayRateSettings[mf.mc.rsFlowCalFactorLeftHi] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberLeft >> 8);
            mf.mc.relayRateSettings[mf.mc.rsFlowCalFactorLeftLo] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberLeft);
            mf.mc.relayRateSettings[mf.mc.rsFlowCalFactorRightHi] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberRight >> 8);
            mf.mc.relayRateSettings[mf.mc.rsFlowCalFactorRightLo] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberRight);
            mf.RateRelayOutToPort(mf.mc.relayRateSettings, CModuleComm.numRelayRateSettingsItems);

            Close();
        }

        private void btnDualResetAccumulatedVolume_Click(object sender, EventArgs e)
        {
            //sending 32700 resets accumulated counts in module
            mf.mc.relayRateSettings[mf.mc.rsDualAccumulatedVolumeHi] = (32700 >> 8);
            mf.mc.relayRateSettings[mf.mc.rsDualAccumulatedVolumeLo] = unchecked((byte)32700);
            Properties.Settings.Default.setRate_DualAccumulatedVolume = 0;
            Properties.Settings.Default.Save();

            //make sure current flowCal is set
            mf.mc.relayRateSettings[mf.mc.rsFlowCalFactorLeftHi] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberLeft >> 8);
            mf.mc.relayRateSettings[mf.mc.rsFlowCalFactorLeftLo] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberLeft);

            mf.mc.relayRateSettings[mf.mc.rsFlowCalFactorRightHi] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberRight >> 8);
            mf.mc.relayRateSettings[mf.mc.rsFlowCalFactorRightLo] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberRight);
            mf.RateRelayOutToPort(mf.mc.relayRateSettings, CModuleComm.numRelayRateSettingsItems);

            mf.mc.relayRateSettings[mf.mc.rsDualAccumulatedVolumeHi] = 0;
            mf.mc.relayRateSettings[mf.mc.rsDualAccumulatedVolumeLo] = 0;
            mf.rcd.dualVolumeActual = 0;
            lblDualAccumulatedVolume.Text = mf.rcd.dualVolumeActual.ToString();
        }

        private void btnRateLeftUp_MouseDown(object sender, MouseEventArgs e)
        {
            nudRateLeft.ValueChanged -= nudRateLeft_ValueChanged;

            nudRateLeft.Value += (decimal)0.1;
            if (nudRateLeft.Value > nudRateLeft.Maximum) nudRateLeft.Value = nudRateLeft.Maximum;

            //always in L/ha
            rateLeft = (double)nudRateLeft.Value * NUD2Setting;

            nudRateLeft.ValueChanged += nudRateLeft_ValueChanged;
        }

        private void btnRateLeftDn_MouseDown(object sender, MouseEventArgs e)
        {
            nudRateLeft.ValueChanged -= nudRateLeft_ValueChanged;

            nudRateLeft.Value -= (decimal)0.1;
            if (nudRateLeft.Value < nudRateLeft.Minimum) nudRateLeft.Value = nudRateLeft.Minimum;

            //always in L/ha
            rateLeft = (double)nudRateLeft.Value * NUD2Setting;

            nudRateLeft.ValueChanged += nudRateLeft_ValueChanged;
        }

        private void btnRateRightUp_MouseDown(object sender, MouseEventArgs e)
        {
            nudRateRight.ValueChanged -= nudRateRight_ValueChanged;

            nudRateRight.Value += (decimal)0.1;
            if (nudRateRight.Value > nudRateRight.Maximum) nudRateRight.Value = nudRateRight.Maximum;

            //always in L/ha
            rateRight = (double)nudRateRight.Value * NUD2Setting;

            nudRateRight.ValueChanged += nudRateRight_ValueChanged;
        }

        private void btnRateRightDn_MouseDown(object sender, MouseEventArgs e)
        {
            nudRateRight.ValueChanged -= nudRateRight_ValueChanged;

            nudRateRight.Value -= (decimal)0.1;
            if (nudRateRight.Value < nudRateRight.Minimum) nudRateRight.Value = nudRateRight.Minimum;

            //always in L/ha
            rateRight = (double)nudRateRight.Value * NUD2Setting;

            nudRateRight.ValueChanged += nudRateRight_ValueChanged;
        }

        private void nudRateLeft_ValueChanged(object sender, EventArgs e)
        {
            rateLeft = (double)nudRateLeft.Value * NUD2Setting;
        }

        private void nudRateRight_ValueChanged(object sender, EventArgs e)
        {
            rateRight = (double)nudRateRight.Value * NUD2Setting;
        }
    }
}