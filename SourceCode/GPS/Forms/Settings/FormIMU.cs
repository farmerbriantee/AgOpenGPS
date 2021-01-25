using System;
using System.Linq;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormIMU : Form
    {
        private readonly FormGPS mf = null;

        private decimal minFixStepDistance;

        public FormIMU(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();

            //Languages

            groupBox4.Text = gStr.gsFixFrom;

            this.headingGroupBox.Text = gStr.gsGPSHeadingFrom;
            this.label13.Text = gStr.gsDualAntenna;
            this.label12.Text = gStr.gsFromVTGorRMC;
            this.label11.Text = gStr.gsFixToFixCalc;
            this.btnRollZero.Text = gStr.gsRollZero;
            this.btnRemoveZeroOffset.Text = gStr.gsRemoveOffset;
            this.label10.Text = gStr.gsALLSettingsRequireRestart;

            this.groupBox6.Text = gStr.gsRollSource;
            this.rbtnRollAVR.Text = gStr.gsFromGPS;
            this.rbtnRollAutoSteer.Text = gStr.gsFromAutoSteer;
            rbtnRollOGI.Text = "OGI";

            this.groupBoxHeadingCorrection.Text = gStr.gsHeadingCorrectionSource;
            this.rbtnHeadingCorrAutoSteer.Text = gStr.gsFromAutoSteer;
            //rbtnHeadingCorrUDP.Text = "UDP";
            rbtnHeadingCorrNone.Text = gStr.gsNone;
            rbtnRollNone.Text = gStr.gsNone;

            this.groupBox1.Text = gStr.gsFixToFixDistance;
            this.label35.Text = gStr.gsMeters;
            this.lblSimGGA.Text = gStr.gsUseGGAForSimulator;

            this.Text = gStr.gsDataSources;

            tabHeading.Text = gStr.gsHeading;
            tabFix.Text = gStr.gsFix;
            tabRoll.Text = gStr.gsRoll;

            nudMinFixStepDistance.Controls[0].Enabled = false;


        }

        #region EntryExit

        private void bntOK_Click(object sender, EventArgs e)
        {
            ////Display ---load the delay slides --------------------------------------------------------------------
            Properties.Settings.Default.setIMU_UID = tboxTinkerUID.Text.Trim();

            mf.minFixStepDist = (double)minFixStepDistance;
            Properties.Settings.Default.setF_minFixStep = mf.minFixStepDist;

            Properties.Settings.Default.setIMU_isHeadingCorrectionFromAutoSteer = rbtnHeadingCorrAutoSteer.Checked;
            mf.ahrs.isHeadingCorrectionFromAutoSteer =  rbtnHeadingCorrAutoSteer.Checked;

            Properties.Settings.Default.setIMU_isHeadingCorrectionFromBrick =  rbtnHeadingCorrBrick.Checked;
            mf.ahrs.isHeadingCorrectionFromBrick = rbtnHeadingCorrBrick.Checked;

            //Properties.Settings.Default.setIMU_isHeadingCorrectionFromExtUDP = rbtnHeadingCorrUDP.Checked;
            //mf.ahrs.isHeadingCorrectionFromExtUDP = rbtnHeadingCorrUDP.Checked;


            Properties.Settings.Default.setIMU_isRollFromAutoSteer = rbtnRollAutoSteer.Checked;
            mf.ahrs.isRollFromAutoSteer = rbtnRollAutoSteer.Checked;

            Properties.Settings.Default.setIMU_isRollFromAVR = rbtnRollAVR.Checked;
            mf.ahrs.isRollFromAVR = rbtnRollAVR.Checked;

            Properties.Settings.Default.setIMU_isRollFromOGI = rbtnRollOGI.Checked;
            mf.ahrs.isRollFromOGI = rbtnRollOGI.Checked;

            Properties.Settings.Default.setGPS_isRTK = cboxIsRTK.Checked;
            mf.isRTK = cboxIsRTK.Checked;

            Properties.Settings.Default.setIMU_fusionWeight = (double)(hsbarFusion.Value) * 0.01;
            mf.ahrs.fusionWeight = (double)(hsbarFusion.Value) * 0.01;

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

            //heading correction
            rbtnHeadingCorrAutoSteer.Checked = Properties.Settings.Default.setIMU_isHeadingCorrectionFromAutoSteer;
            rbtnHeadingCorrBrick.Checked = Properties.Settings.Default.setIMU_isHeadingCorrectionFromBrick;
            //rbtnHeadingCorrUDP.Checked = Properties.Settings.Default.setIMU_isHeadingCorrectionFromExtUDP;
            if (!rbtnHeadingCorrAutoSteer.Checked && !rbtnHeadingCorrBrick.Checked)
                rbtnHeadingCorrNone.Checked = true;   //&& !rbtnHeadingCorrUDP.Checked

            //Roll
            rbtnRollAutoSteer.Checked = Properties.Settings.Default.setIMU_isRollFromAutoSteer;
            rbtnRollAVR.Checked = Properties.Settings.Default.setIMU_isRollFromAVR;
            rbtnRollOGI.Checked = Properties.Settings.Default.setIMU_isRollFromOGI;
            if (!rbtnRollAutoSteer.Checked && !rbtnRollAVR.Checked && !rbtnRollOGI.Checked) rbtnRollNone.Checked = true;

            lblRollZeroOffset.Text = ((double)Properties.Settings.Default.setIMU_rollZeroX16 / 16).ToString("N2");

            //Fix
            if (Properties.Settings.Default.setGPS_fixFromWhichSentence == "GGA") rbtnGGA.Checked = true;
            else if (Properties.Settings.Default.setGPS_fixFromWhichSentence == "RMC") rbtnRMC.Checked = true;
            else if (Properties.Settings.Default.setGPS_fixFromWhichSentence == "OGI") rbtnOGI.Checked = true;

            //heading
            if (Properties.Settings.Default.setGPS_headingFromWhichSource == "Fix") rbtnHeadingFix.Checked = true;
            else if (Properties.Settings.Default.setGPS_headingFromWhichSource == "GPS") rbtnHeadingGPS.Checked = true;
            else if (Properties.Settings.Default.setGPS_headingFromWhichSource == "Dual") rbtnHeadingHDT.Checked = true;

            cboxIsRTK.Checked = Properties.Settings.Default.setGPS_isRTK;

            hsbarFusion.Value = (int)(Properties.Settings.Default.setIMU_fusionWeight * 100);
            lblFusion.Text = (hsbarFusion.Value).ToString();
            lblFusionIMU.Text = (50 - hsbarFusion.Value).ToString();
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
            if ((mf.ahrs.isRollFromAutoSteer || mf.ahrs.isRollFromAVR || mf.ahrs.isRollFromOGI))
            {
                mf.ahrs.rollZeroX16 = mf.ahrs.rollX16;
                lblRollZeroOffset.Text = ((double)mf.ahrs.rollZeroX16 / 16).ToString("N2");
                Properties.Settings.Default.setIMU_rollZeroX16 = mf.ahrs.rollX16;
                Properties.Settings.Default.Save();
            }
            else
            {
                lblRollZeroOffset.Text = "***";
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

        private void rbtnGGA_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = groupBox4.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            Properties.Settings.Default.setGPS_fixFromWhichSentence = checkedButton.Text;
            Properties.Settings.Default.Save();
            mf.pn.fixFrom = checkedButton.Text;
        }

        private void rbtnHeadingFix_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = headingGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            Properties.Settings.Default.setGPS_headingFromWhichSource = checkedButton.Text;
            Properties.Settings.Default.Save();
            mf.headingFromSource = checkedButton.Text;
        }

        private void tboxTinkerUID_Click(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender);
                btnCancel.Focus();
            }
        }

        private void hsbarFusion_ValueChanged(object sender, EventArgs e)
        {
            lblFusion.Text = (hsbarFusion.Value).ToString();
            lblFusionIMU.Text = (50 - hsbarFusion.Value).ToString();

        }
    }
}