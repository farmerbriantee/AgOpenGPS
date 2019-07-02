using System;
using System.Linq;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormDisplaySettings : Form
    {
        private readonly FormGPS mf = null;

        private decimal triResolution, minFixStepDistance, boundaryDistance, treeSpacing;
        private int lightbarCmPerPixie, snapDistance, snapDistanceSmall;
        private bool isHeadingBNO, isHeadingBrick, isHeadingPAOGI, isRollDogs, isRollBrick, isRollPAOGI;
        private string headingFromWhichSource;

        public FormDisplaySettings(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        #region EntryExit

        private void FormDisplaySettings_Load(object sender, EventArgs e)
        {
            triResolution = (decimal)Properties.Settings.Default.setDisplay_triangleResolution;
            if (nudTriangleResolution.CheckValue(ref triResolution)) nudTriangleResolution.BackColor = System.Drawing.Color.OrangeRed;
            nudTriangleResolution.Value = triResolution;

            boundaryDistance = (decimal)Properties.Settings.Default.setF_boundaryTriggerDistance;
            if (nudBoundaryDistance.CheckValue(ref boundaryDistance)) nudBoundaryDistance.BackColor = System.Drawing.Color.OrangeRed;
            nudBoundaryDistance.Value = boundaryDistance;

            minFixStepDistance = (decimal)Properties.Settings.Default.setF_minFixStep;
            if (nudMinFixStepDistance.CheckValue(ref minFixStepDistance)) nudMinFixStepDistance.BackColor = System.Drawing.Color.OrangeRed;
            nudMinFixStepDistance.Value = minFixStepDistance;

            treeSpacing = (decimal)Properties.Settings.Default.setDistance_TreeSpacing;
            nudTreeSpacing.Value = treeSpacing;

            nudLightbarCmPerPixel.Value = (Properties.Settings.Default.setDisplay_lightbarCmPerPixel);
            nudSnapDistance.Value = Properties.Settings.Default.setDisplay_snapDistance;
            nudSnapDistanceSmall.Value = Properties.Settings.Default.setDisplay_snapDistanceSmall;

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

            headingFromWhichSource = Properties.Settings.Default.setGPS_headingFromWhichSource;
            if (headingFromWhichSource == "Fix") rbtnHeadingFix.Checked = true;
            else if (headingFromWhichSource == "GPS") rbtnHeadingGPS.Checked = true;
            else if (headingFromWhichSource == "HDT") rbtnHeadingHDT.Checked = true;
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            ////Display ---load the delay slides --------------------------------------------------------------------
            if (headingFromWhichSource == "Fix") Properties.Settings.Default.setGPS_headingFromWhichSource = "Fix";
            else if (headingFromWhichSource == "GPS") Properties.Settings.Default.setGPS_headingFromWhichSource = "GPS";
            else if (headingFromWhichSource == "HDT") Properties.Settings.Default.setGPS_headingFromWhichSource = "HDT";
            mf.headingFromSource = headingFromWhichSource;

            mf.boundaryTriggerDistance = (double)boundaryDistance;
            Properties.Settings.Default.setF_boundaryTriggerDistance = mf.boundaryTriggerDistance;

            mf.triangleResolution = (double)triResolution;
            Properties.Settings.Default.setDisplay_triangleResolution = mf.triangleResolution;

            mf.minFixStepDist = (double)minFixStepDistance;
            Properties.Settings.Default.setF_minFixStep = mf.minFixStepDist;

            mf.vehicle.treeSpacing = (double)treeSpacing;
            Properties.Settings.Default.setDistance_TreeSpacing = mf.vehicle.treeSpacing;

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

            Properties.Settings.Default.setDisplay_snapDistance = snapDistance;
            Properties.Settings.Default.setDisplay_snapDistanceSmall = snapDistanceSmall;

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

         private void nudSnapDistance_ValueChanged(object sender, EventArgs e)
        {
            if (nudSnapDistanceSmall.Value > nudSnapDistance.Value) nudSnapDistanceSmall.Value = nudSnapDistance.Value;

            snapDistance = (int)nudSnapDistance.Value;
        }

        private void nudSnapDistanceSmall_ValueChanged(object sender, EventArgs e)
        {
            if (nudSnapDistanceSmall.Value > nudSnapDistance.Value) nudSnapDistanceSmall.Value = nudSnapDistance.Value;
            snapDistanceSmall = (int)nudSnapDistanceSmall.Value;
        }

        private void nudBoundaryDistance_ValueChanged(object sender, EventArgs e)
        {
            boundaryDistance = nudBoundaryDistance.Value;
        }

        #endregion DisplayCalcs

        #region Tree

        private void nudTreeSpacing_ValueChanged(object sender, EventArgs e)
        {
            treeSpacing = nudTreeSpacing.Value;
        }

        #endregion Tree

        private void rbtnHeadingFix_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = headingGroupBox.Controls.OfType<RadioButton>()
                          .FirstOrDefault(r => r.Checked);
            headingFromWhichSource = checkedButton.Text;
        }

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