using System;
using System.Linq;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormIMU : Form
    {
        private readonly FormGPS mf = null;

        private string headingFromWhichSource;
        private bool isHeadingFromAutoSteer, isHeadingFromBrick, isHeadingPAOGI, isHeadingFromExtUDP;
        private bool isRollFromAutoSteer, isRollFromBrick, isRollFromExtUDP, isRollFromGPS;
        private decimal minFixStepDistance;

        public FormIMU(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();

            //Languages
            this.headingGroupBox.Text = gStr.gsGPSHeadingFrom;
            this.label13.Text = gStr.gsDualAntenna;
            this.label12.Text = gStr.gsFromVTGorRMC;
            this.label11.Text = gStr.gsFixToFixCalc;
            this.btnRollZero.Text = gStr.gsRollZero;
            this.btnRemoveZeroOffset.Text = gStr.gsRemoveOffset;
            this.label10.Text = gStr.gsALLSettingsRequireRestart;

            this.groupBox6.Text = gStr.gsRollSource;
            this.cboxRollExtUDP.Text = gStr.gsExtUDPSource;
            this.cboxRollFromGPS.Text = gStr.gsFromGPS;
            this.cboxRollAutoSteer.Text = gStr.gsFromAutoSteer;

            this.groupBox7.Text = gStr.gsHeadingCorrectionSource;
            this.cboxHeadingExtUDP.Text = gStr.gsExtUDPSource;
            this.cboxHeadingPAOGI.Text = gStr.gsPAOGIReachIMU;
            this.cboxHeadingAutoSteer.Text = gStr.gsFromAutoSteer;

            this.groupBox1.Text = gStr.gsFixToFixDistance;
            this.label35.Text = gStr.gsMeters;

            this.Text = gStr.gsIMUSettings;

            nudMinFixStepDistance.Controls[0].Enabled = false;
        }

        #region EntryExit

        private void bntOK_Click(object sender, EventArgs e)
        {
            ////Display ---load the delay slides --------------------------------------------------------------------
            if (headingFromWhichSource == "Fix") Properties.Settings.Default.setGPS_headingFromWhichSource = "Fix";
            else if (headingFromWhichSource == "GPS") Properties.Settings.Default.setGPS_headingFromWhichSource = "GPS";
            else if (headingFromWhichSource == "HDT") Properties.Settings.Default.setGPS_headingFromWhichSource = "HDT";
            mf.headingFromSource = headingFromWhichSource;

            Properties.Settings.Default.setIMU_UID = tboxTinkerUID.Text.Trim();

            mf.minFixStepDist = (double)minFixStepDistance;
            Properties.Settings.Default.setF_minFixStep = mf.minFixStepDist;

            Properties.Settings.Default.setIMU_isHeadingFromAutoSteer = isHeadingFromAutoSteer;
            mf.ahrs.isHeadingFromAutoSteer = isHeadingFromAutoSteer;

            Properties.Settings.Default.setIMU_isHeadingFromBrick = isHeadingFromBrick;
            mf.ahrs.isHeadingFromBrick = isHeadingFromBrick;

            Properties.Settings.Default.setIMU_isHeadingFromPAOGI = isHeadingPAOGI;
            mf.ahrs.isHeadingFromPAOGI = isHeadingPAOGI;

            Properties.Settings.Default.setIMU_isHeadingFromExtUDP = isHeadingFromExtUDP;
            mf.ahrs.isHeadingFromExtUDP = isHeadingFromExtUDP;

            Properties.Settings.Default.setIMU_isRollFromAutoSteer = isRollFromAutoSteer;
            mf.ahrs.isRollFromAutoSteer = isRollFromAutoSteer;

            Properties.Settings.Default.setIMU_isRollFromBrick = isRollFromBrick;
            mf.ahrs.isRollFromBrick = isRollFromBrick;

            Properties.Settings.Default.setIMU_isRollFromGPS = isRollFromGPS;
            mf.ahrs.isRollFromGPS = isRollFromGPS;

            Properties.Settings.Default.setIMU_isRollFromExtUDP = isRollFromExtUDP;
            mf.ahrs.isRollFromExtUDP = isRollFromExtUDP;

            Properties.Settings.Default.Save();
            Properties.Vehicle.Default.Save();

            //back to FormGPS
            DialogResult = DialogResult.OK;
            Close();
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            { DialogResult = DialogResult.Cancel; Close(); }
        }

        private void FormDisplaySettings_Load(object sender, EventArgs e)
        {
            minFixStepDistance = (decimal)Properties.Settings.Default.setF_minFixStep;
            if (nudMinFixStepDistance.CheckValue(ref minFixStepDistance)) nudMinFixStepDistance.BackColor = System.Drawing.Color.OrangeRed;
            nudMinFixStepDistance.Value = minFixStepDistance;

            tboxTinkerUID.Text = Properties.Settings.Default.setIMU_UID;

            cboxHeadingAutoSteer.Checked = Properties.Settings.Default.setIMU_isHeadingFromAutoSteer;
            cboxHeadingBrick.Checked = Properties.Settings.Default.setIMU_isHeadingFromBrick;
            cboxHeadingPAOGI.Checked = Properties.Settings.Default.setIMU_isHeadingFromPAOGI;
            cboxHeadingExtUDP.Checked = Properties.Settings.Default.setIMU_isHeadingFromExtUDP;

            isHeadingFromAutoSteer = Properties.Settings.Default.setIMU_isHeadingFromAutoSteer;
            isHeadingFromBrick = Properties.Settings.Default.setIMU_isHeadingFromBrick;
            isHeadingPAOGI = Properties.Settings.Default.setIMU_isHeadingFromPAOGI;
            isHeadingFromExtUDP = Properties.Settings.Default.setIMU_isHeadingFromExtUDP;

            cboxRollAutoSteer.Checked = Properties.Settings.Default.setIMU_isRollFromAutoSteer;
            cboxRollFromGPS.Checked = Properties.Settings.Default.setIMU_isRollFromGPS;
            cboxRollExtUDP.Checked = Properties.Settings.Default.setIMU_isRollFromExtUDP;
            cboxRollFromBrick.Checked = Properties.Settings.Default.setIMU_isRollFromBrick;

            isRollFromAutoSteer = Properties.Settings.Default.setIMU_isRollFromAutoSteer;
            isRollFromBrick = Properties.Settings.Default.setIMU_isRollFromBrick;
            isRollFromGPS = Properties.Settings.Default.setIMU_isRollFromGPS;
            isRollFromExtUDP = Properties.Settings.Default.setIMU_isRollFromExtUDP;

            lblRollZeroOffset.Text = ((double)Properties.Settings.Default.setIMU_rollZeroX16 / 16).ToString("N2");

            headingFromWhichSource = Properties.Settings.Default.setGPS_headingFromWhichSource;
            if (headingFromWhichSource == "Fix") rbtnHeadingFix.Checked = true;
            else if (headingFromWhichSource == "GPS") rbtnHeadingGPS.Checked = true;
            else if (headingFromWhichSource == "HDT") rbtnHeadingHDT.Checked = true;
        }

        #endregion EntryExit

        private void btnRemoveZeroOffset_Click(object sender, EventArgs e)
        {
            mf.ahrs.rollZeroX16 = 0;
            lblRollZeroOffset.Text = "0.00";
            Properties.Settings.Default.setIMU_rollZeroX16 = 0;
            Properties.Settings.Default.Save();
        }

        private void btnRemoveZeroOffsetPitch_Click(object sender, EventArgs e)
        {
        }

        private void btnZeroPitch_Click(object sender, EventArgs e)
        {
        }

        private void btnZeroRoll_Click(object sender, EventArgs e)
        {
            if (mf.ahrs.rollX16 == 9999)
            {
                lblRollZeroOffset.Text = "***";
            }
            else
            {
                mf.ahrs.rollZeroX16 = mf.ahrs.rollX16;
                lblRollZeroOffset.Text = ((double)mf.ahrs.rollZeroX16 / 16).ToString("N2");
                Properties.Settings.Default.setIMU_rollZeroX16 = mf.ahrs.rollX16;
                Properties.Settings.Default.Save();
            }
        }

        private void cboxHeadingAutosteer_CheckedChanged(object sender, EventArgs e)
        {
            isHeadingFromAutoSteer = cboxHeadingAutoSteer.Checked;
            if (isHeadingFromAutoSteer)
            {
                cboxHeadingPAOGI.Checked = false;
                isHeadingPAOGI = false;
                cboxHeadingExtUDP.Checked = false;
                isHeadingFromExtUDP = false;
                cboxHeadingBrick.Checked = false;
                isHeadingFromBrick = false;
            }
        }

        private void cboxHeadingBrick_CheckedChanged(object sender, EventArgs e)
        {
            isHeadingFromBrick = cboxHeadingBrick.Checked;
            if (isHeadingFromBrick)
            {
                cboxHeadingAutoSteer.Checked = false;
                isHeadingFromAutoSteer = false;
                cboxHeadingPAOGI.Checked = false;
                isHeadingPAOGI = false;
                cboxHeadingExtUDP.Checked = false;
                isHeadingFromExtUDP = false;
            }
        }

        private void CboxHeadingExtUDP_CheckedChanged(object sender, EventArgs e)
        {
            isHeadingFromExtUDP = cboxHeadingExtUDP.Checked;
            if (isHeadingFromExtUDP)
            {
                cboxHeadingAutoSteer.Checked = false;
                isHeadingFromAutoSteer = false;
                cboxHeadingPAOGI.Checked = false;
                isHeadingPAOGI = false;
                cboxHeadingBrick.Checked = false;
                isHeadingFromBrick = false;
            }
        }

        private void NudMinFixStepDistance_ValueChanged(object sender, EventArgs e)
        {
            minFixStepDistance = nudMinFixStepDistance.Value;
        }

        private void NudMinFixStepDistance_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void cboxHeadingPAOGI_CheckedChanged(object sender, EventArgs e)
        {
            isHeadingPAOGI = cboxHeadingPAOGI.Checked;
            if (isHeadingPAOGI)
            {
                cboxHeadingAutoSteer.Checked = false;
                isHeadingFromAutoSteer = false;
                cboxHeadingExtUDP.Checked = false;
                isHeadingFromExtUDP = false;
                cboxHeadingBrick.Checked = false;
                isHeadingFromBrick = false;
            }
        }

        private void cboxRollAutoSteer_CheckedChanged(object sender, EventArgs e)
        {
            isRollFromAutoSteer = cboxRollAutoSteer.Checked;
            if (isRollFromAutoSteer)
            {
                cboxRollFromBrick.Checked = false;
                isRollFromBrick = false;
                cboxRollFromGPS.Checked = false;
                isRollFromGPS = false;
                cboxRollExtUDP.Checked = false;
                isRollFromExtUDP = false;
            }
        }

        private void CboxRollBrick_CheckedChanged(object sender, EventArgs e)
        {
            isRollFromBrick = cboxRollFromBrick.Checked;
            if (isRollFromBrick)
            {
                cboxRollAutoSteer.Checked = false;
                isRollFromAutoSteer = false;
                cboxRollFromGPS.Checked = false;
                isRollFromGPS = false;
                cboxRollExtUDP.Checked = false;
                isRollFromExtUDP = false;
            }
        }

        private void CboxRollExtUDP_CheckedChanged(object sender, EventArgs e)
        {
            isRollFromExtUDP = cboxRollExtUDP.Checked;
            if (isRollFromExtUDP)
            {
                cboxRollAutoSteer.Checked = false;
                isRollFromAutoSteer = false;
                cboxRollFromBrick.Checked = false;
                isRollFromBrick = false;
                cboxRollFromGPS.Checked = false;
                isRollFromGPS = false;
            }
        }

        private void cboxRollFromGPS_CheckedChanged(object sender, EventArgs e)
        {
            isRollFromGPS = cboxRollFromGPS.Checked;
            if (isRollFromGPS)
            {
                cboxRollAutoSteer.Checked = false;
                isRollFromAutoSteer = false;
                cboxRollFromBrick.Checked = false;
                isRollFromBrick = false;
                cboxRollExtUDP.Checked = false;
                isRollFromExtUDP = false;
            }
        }

        private void rbtnHeadingFix_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = headingGroupBox.Controls.OfType<RadioButton>()
                          .FirstOrDefault(r => r.Checked);
            headingFromWhichSource = checkedButton.Text;
        }
    }
}