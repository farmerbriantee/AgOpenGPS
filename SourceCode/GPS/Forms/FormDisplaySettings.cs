using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormDisplaySettings : Form
    {
        private readonly FormGPS mf = null;

        private decimal triResolution, minFixStepDistance, boundaryDistance;
        private int lightbarCmPerPixie;
        private bool isHeadingBNO, isHeadingBrick, isHeadingPAOGI, isRollDogs, isRollBrick, isRollPAOGI, isHeadingFromFix;

        public FormDisplaySettings(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        #region EntryExit

        private void FormDisplaySettings_Load(object sender, EventArgs e)
        {
            triResolution = (decimal)Properties.Settings.Default.setDisplay_triangleResolution;
            nudTriangleResolution.Value = triResolution;

            boundaryDistance = (decimal)Properties.Settings.Default.setF_boundaryTriggerDistance;
            nudBoundaryDistance.Value = boundaryDistance;

            minFixStepDistance = (decimal)Properties.Settings.Default.setF_minFixStep;
            nudMinFixStepDistance.Value = minFixStepDistance;

            tboxTinkerUID.Text = Properties.Settings.Default.setIMU_UID;

            cboxHeadingBNO.Checked = Properties.Settings.Default.setIMU_isHeadingFromBNO;
            cboxHeadingBrick.Checked = Properties.Settings.Default.setIMU_isHeadingFromBrick;
            cboxRollDogs.Checked = Properties.Settings.Default.setIMU_isRollFromDogs;
            cboxHeadingPAOGI.Checked = Properties.Settings.Default.setIMU_isHeadingFromPAOGI;
            cboxRollPAOGI.Checked = Properties.Settings.Default.setIMU_isRollFromPAOGI;

            isHeadingBNO = Properties.Settings.Default.setIMU_isHeadingFromBNO;
            isHeadingBrick = Properties.Settings.Default.setIMU_isHeadingFromBrick;
            isRollDogs = Properties.Settings.Default.setIMU_isRollFromDogs;
            isRollBrick = Properties.Settings.Default.setIMU_isRollFromBrick;
            isHeadingPAOGI = Properties.Settings.Default.setIMU_isHeadingFromPAOGI;
            isRollPAOGI = Properties.Settings.Default.setIMU_isRollFromPAOGI;

            lblRollZeroOffset.Text = ((double)Properties.Settings.Default.setIMU_rollZero / 16).ToString("N2");

            isHeadingFromFix = Properties.Settings.Default.setHeading_isFromPosition;

            cboxIsHeadingFromGPSTrue.CheckedChanged -= cboxIsHeadingFromGPSTrue_CheckedChanged;
            cboxIsHeadingFromGPSTrue.Checked = !isHeadingFromFix;
            cboxIsHeadingFromGPSTrue.CheckedChanged += cboxIsHeadingFromGPSTrue_CheckedChanged;

            nudLightbarCmPerPixel.Value = Properties.Settings.Default.setDisplay_lightbarCmPerPixel;
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            ////Display ---load the delay slides --------------------------------------------------------------------
            mf.isHeadingFromFix = isHeadingFromFix;
            Properties.Settings.Default.setHeading_isFromPosition = isHeadingFromFix;

            mf.boundaryTriggerDistance = (double)boundaryDistance;
            Properties.Settings.Default.setF_boundaryTriggerDistance = mf.boundaryTriggerDistance;

            mf.camera.triangleResolution = (double)triResolution;
            Properties.Settings.Default.setDisplay_triangleResolution = mf.camera.triangleResolution;

            mf.minFixStepDist = (double)minFixStepDistance;
            Properties.Settings.Default.setF_minFixStep = mf.minFixStepDist;

            Properties.Settings.Default.setIMU_UID = tboxTinkerUID.Text.Trim();

            Properties.Settings.Default.setIMU_isHeadingFromBNO = isHeadingBNO;
            Properties.Settings.Default.setIMU_isHeadingFromBrick = isHeadingBrick;
            Properties.Settings.Default.setIMU_isRollFromDogs = isRollDogs;
            mf.ahrs.isRollDogs = isRollDogs;
            Properties.Settings.Default.setIMU_isRollFromBrick = isRollBrick;
            mf.ahrs.isRollBrick = isRollBrick;
            Properties.Settings.Default.setIMU_isRollFromPAOGI = isRollPAOGI;
            Properties.Settings.Default.setIMU_isHeadingFromPAOGI = isHeadingPAOGI;

            Properties.Settings.Default.setDisplay_lightbarCmPerPixel = lightbarCmPerPixie;
            mf.lightbarCmPerPixel = lightbarCmPerPixie;

            Properties.Settings.Default.Save();
            Properties.Vehicle.Default.Save();

            //back to FormGPS
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            { DialogResult = DialogResult.Cancel; Close(); }
        }

        #endregion EntryExit

        #region DisplayCalcs

        private void nudMinFixStepDistance_ValueChanged(object sender, EventArgs e)
        {
            minFixStepDistance = nudMinFixStepDistance.Value;
        }

        private void nudTriangleResolution_ValueChanged(object sender, EventArgs e)
        {
            triResolution = nudTriangleResolution.Value;
        }

        private void nudLightbarCmPerPixel_ValueChanged(object sender, EventArgs e)
        {
            lightbarCmPerPixie = (int)nudLightbarCmPerPixel.Value;
        }

        private void nudBoundaryDistance_ValueChanged(object sender, EventArgs e)
        {
            boundaryDistance = nudBoundaryDistance.Value;
        }

        #endregion DisplayCalcs

        private void cboxRollDogs_CheckedChanged(object sender, EventArgs e)
        {
            isRollDogs = cboxRollDogs.Checked;
            if (isRollDogs)
            {
                isRollBrick = false;
                cboxRollPAOGI.Checked = false;
                isRollPAOGI = false;
            }
        }

        private void cboxRollPAOGI_CheckedChanged(object sender, EventArgs e)
        {
            isRollPAOGI = cboxRollPAOGI.Checked;
            if (isRollPAOGI)
            {
                cboxRollDogs.Checked = false;
                isRollDogs = false;
                isRollBrick = false;
            }
        }

        private void cboxHeadingBNO_CheckedChanged(object sender, EventArgs e)
        {
            isHeadingBNO = cboxHeadingBNO.Checked;
            if (isHeadingBNO)
            {
                cboxHeadingBrick.Checked = false;
                isHeadingBrick = false;
                cboxHeadingPAOGI.Checked = false;
                isHeadingPAOGI = false;
            }
        }

        private void cboxHeadingBrick_CheckedChanged(object sender, EventArgs e)
        {
            isHeadingBrick = cboxHeadingBrick.Checked;
            if (isHeadingBrick)
            {
                cboxHeadingBNO.Checked = false;
                isHeadingBNO = false;
                cboxHeadingPAOGI.Checked = false;
                isHeadingPAOGI = false;
            }
        }

        private void cboxHeadingPAOGI_CheckedChanged(object sender, EventArgs e)
        {
            isHeadingPAOGI = cboxHeadingPAOGI.Checked;
            if (isHeadingPAOGI)
            {
                cboxHeadingBNO.Checked = false;
                isHeadingBNO = false;
                cboxHeadingBrick.Checked = false;
                isHeadingBrick = false;
            }
        }

        private void cboxIsHeadingFromGPSTrue_CheckedChanged(object sender, EventArgs e)
        {
            isHeadingFromFix = !cboxIsHeadingFromGPSTrue.Checked;
        }

        private void btnRemoveZeroOffset_Click(object sender, EventArgs e)
        {
            mf.ahrs.rollZero = 0;
            lblRollZeroOffset.Text = "0.00";
            Properties.Settings.Default.setIMU_rollZero = 0;
            Properties.Settings.Default.Save();
        }

        private void btnZeroRoll_Click(object sender, EventArgs e)
        {
            if (mf.mc.rollRaw == 9999)
            {
                lblRollZeroOffset.Text = "***";
            }
            else
            {
                mf.ahrs.rollZero = mf.mc.rollRaw;
                lblRollZeroOffset.Text = ((double)mf.ahrs.rollZero / 16).ToString("N2");
                Properties.Settings.Default.setIMU_rollZero = mf.mc.rollRaw;
                Properties.Settings.Default.Save();
            }
        }

        private void btnRemoveZeroOffsetPitch_Click(object sender, EventArgs e)
        {
        }

        private void btnZeroPitch_Click(object sender, EventArgs e)
        {
        }
    }
}