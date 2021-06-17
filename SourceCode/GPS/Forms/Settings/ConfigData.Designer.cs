using System;
using System.Linq;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormConfig
    {
        #region Fix

        private void tabDFix_Enter(object sender, EventArgs e)
        {
        }

        private void tabDFix_Leave(object sender, EventArgs e)
        {

        }

        #endregion

        #region Heading
        private void tabDHeading_Enter(object sender, EventArgs e)
        {
            //heading
            if (Properties.Settings.Default.setGPS_headingFromWhichSource == "Fix") rbtnHeadingFix.Checked = true;
            else if (Properties.Settings.Default.setGPS_headingFromWhichSource == "VTG") rbtnHeadingGPS.Checked = true;
            else if (Properties.Settings.Default.setGPS_headingFromWhichSource == "Dual") rbtnHeadingHDT.Checked = true;

            if (rbtnHeadingHDT.Checked) gboxSingle.Enabled = false;

            cboxIsRTK.Checked = Properties.Settings.Default.setGPS_isRTK;
            nudMinFixStepDistance.Value = (decimal)Properties.Settings.Default.setF_minFixStep;
            nudStartSpeed.Value = (decimal)Properties.Vehicle.Default.setVehicle_startSpeed;

            if (Properties.Settings.Default.setIMU_fusionWeight > 0.2)
            {
                Properties.Settings.Default.setIMU_fusionWeight = 0.2;
                Properties.Settings.Default.Save();
                mf.ahrs.fusionWeight = 0.2;
            }

            hsbarFusion.Value = (int)(Properties.Settings.Default.setIMU_fusionWeight * 500);
            lblFusion.Text = (hsbarFusion.Value).ToString();
            lblFusionIMU.Text = (100 - hsbarFusion.Value).ToString();

            cboxIsRTK.Checked = Properties.Settings.Default.setGPS_isRTK;
            cboxIsDualAsIMU.Checked = Properties.Settings.Default.setIMU_isDualAsIMU;

            hsbarFusion.Focus();
            nudMinimumFrameTime.Value = Properties.Settings.Default.SetGPS_udpWatchMsec;
        }

        private void tabDHeading_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.setIMU_fusionWeight = (double)hsbarFusion.Value * 0.002;
            mf.ahrs.fusionWeight = (double)hsbarFusion.Value * 0.002;

            Properties.Settings.Default.setIMU_isDualAsIMU = mf.ahrs.isDualAsIMU = cboxIsDualAsIMU.Checked;

            Properties.Settings.Default.Save();
            Properties.Vehicle.Default.Save();

            Properties.Settings.Default.setGPS_isRTK = mf.isRTK = cboxIsRTK.Checked;

            Properties.Settings.Default.Save();
        }

        private void rbtnHeadingFix_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = headingGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            Properties.Settings.Default.setGPS_headingFromWhichSource = checkedButton.Text;
            mf.headingFromSource = checkedButton.Text;

            if (rbtnHeadingHDT.Checked) gboxSingle.Enabled = false;
            else gboxSingle.Enabled = true;
        }

        private void nudMinimumFrameTime_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Settings.Default.SetGPS_udpWatchMsec = ((int)nudMinimumFrameTime.Value);
                mf.udpWatchLimit = Properties.Settings.Default.SetGPS_udpWatchMsec;
            }
        }

        private void hsbarFusion_ValueChanged(object sender, EventArgs e)
        {
            lblFusion.Text = (hsbarFusion.Value).ToString();
            lblFusionIMU.Text = (100 - hsbarFusion.Value).ToString();
        }

        private void nudMinFixStepDistance_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Settings.Default.setF_minFixStep = (double)nudMinFixStepDistance.Value;
            }
            hsbarFusion.Focus();
        }

        private void nudStartSpeed_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Vehicle.Default.setVehicle_startSpeed = (double)nudStartSpeed.Value;
            }
            hsbarFusion.Focus();
        }

        #endregion

        #region Roll

        private void tabDRoll_Enter(object sender, EventArgs e)
        {
            //Roll
            lblRollZeroOffset.Text = ((double)Properties.Settings.Default.setIMU_rollZero).ToString("N2");
            hsbarRollFilter.Value = (int)(Properties.Settings.Default.setIMU_rollFilter * 100);
            hsbarSideHillComp.Value = (int)(Properties.Settings.Default.setAS_sideHillComp * 100);
            cboxDataInvertRoll.Checked = Properties.Settings.Default.setIMU_invertRoll;
        }

        private void tabDRoll_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.setIMU_rollFilter = (double)hsbarRollFilter.Value * 0.01;
            Properties.Settings.Default.setAS_sideHillComp = (double)hsbarSideHillComp.Value * 0.01;
            Properties.Settings.Default.setIMU_rollZero = mf.ahrs.rollZero;
            Properties.Settings.Default.setIMU_invertRoll = cboxDataInvertRoll.Checked;

            mf.ahrs.rollFilter = Properties.Settings.Default.setIMU_rollFilter;
            mf.ahrs.isRollInvert = Properties.Settings.Default.setIMU_invertRoll;

            Properties.Settings.Default.Save();
        }

        private void hsbarRollFilter_ValueChanged(object sender, EventArgs e)
        {
            lblRollFilterPercent.Text = hsbarRollFilter.Value.ToString();
        }
        private void hsbarSideHillComp_ValueChanged(object sender, EventArgs e)
        {
            double deg = (double)hsbarSideHillComp.Value;
            deg *= 0.01;
            lblSideHillComp.Text = (deg.ToString("N2") + "\u00B0");
        }

        private void btnZeroRoll_Click(object sender, EventArgs e)
        {
            if (mf.ahrs.imuRoll != 88888)
            {
                mf.ahrs.imuRoll += mf.ahrs.rollZero;
                mf.ahrs.rollZero = mf.ahrs.imuRoll;
                lblRollZeroOffset.Text = (mf.ahrs.rollZero).ToString("N2");
            }
            else
            {
                lblRollZeroOffset.Text = "***";
            }
        }

        private void btnRemoveZeroOffset_Click(object sender, EventArgs e)
        {
            mf.ahrs.rollZero = 0;
            lblRollZeroOffset.Text = "0.00";
        }
         
        private void btnResetIMU_Click(object sender, EventArgs e)
        {
            mf.ahrs.imuHeading = 99999;
            mf.ahrs.imuRoll = 88888;
        }

        #endregion

        #region Features On Off

        private void tabBtns_Enter(object sender, EventArgs e)
        {
            cboxFeatureTram.Checked = Properties.Settings.Default.setFeatures.isTramOn;
            cboxFeatureHeadland.Checked = Properties.Settings.Default.setFeatures.isHeadlandOn;
            cboxFeatureBoundary.Checked = Properties.Settings.Default.setFeatures.isBoundaryOn;
            cboxFeatureBoundaryContour.Checked = Properties.Settings.Default.setFeatures.isBndContourOn;
            cboxFeatureRecPath.Checked = Properties.Settings.Default.setFeatures.isRecPathOn;
            cboxFeatureABSmooth.Checked = Properties.Settings.Default.setFeatures.isABSmoothOn;
            cboxFeatureHideContour.Checked = Properties.Settings.Default.setFeatures.isHideContourOn;
            cboxFeatureWebcam.Checked = Properties.Settings.Default.setFeatures.isWebCamOn;
            cboxFeatureOffsetFix.Checked = Properties.Settings.Default.setFeatures.isOffsetFixOn;
            cboxFeatureContour.Checked = Properties.Settings.Default.setFeatures.isContourOn;
            cboxFeatureYouTurn.Checked = Properties.Settings.Default.setFeatures.isYouTurnOn;
            cboxFeatureSteerMode.Checked = Properties.Settings.Default.setFeatures.isSteerModeOn;
            cboxFeatureAgIO.Checked = Properties.Settings.Default.setFeatures.isAgIOOn;

            cboxFeatureAutoSection.Checked = Properties.Settings.Default.setFeatures.isAutoSectionOn;
            cboxFeatureManualSection.Checked = Properties.Settings.Default.setFeatures.isManualSectionOn;
            cboxFeatureCycleLines.Checked = Properties.Settings.Default.setFeatures.isCycleLinesOn;
            cboxFeatureABLine.Checked = Properties.Settings.Default.setFeatures.isABLineOn;
            cboxFeatureCurve.Checked = Properties.Settings.Default.setFeatures.isCurveOn;
            cboxFeatureAutoSteer.Checked = Properties.Settings.Default.setFeatures.isAutoSteerOn;

            cboxFeatureUTurn.Checked = Properties.Settings.Default.setFeatures.isUTurnOn;
            cboxFeatureLateral.Checked = Properties.Settings.Default.setFeatures.isLateralOn;
        }

        private void tabBtns_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.setFeatures.isTramOn = cboxFeatureTram.Checked;
            Properties.Settings.Default.setFeatures.isHeadlandOn = cboxFeatureHeadland.Checked;

            Properties.Settings.Default.setFeatures.isBoundaryOn = cboxFeatureBoundary.Checked;
            Properties.Settings.Default.setFeatures.isBndContourOn = cboxFeatureBoundaryContour.Checked;
            Properties.Settings.Default.setFeatures.isRecPathOn = cboxFeatureRecPath.Checked;
            Properties.Settings.Default.setFeatures.isABSmoothOn = cboxFeatureABSmooth.Checked;
            Properties.Settings.Default.setFeatures.isHideContourOn = cboxFeatureHideContour.Checked;
            Properties.Settings.Default.setFeatures.isWebCamOn = cboxFeatureWebcam.Checked;
            Properties.Settings.Default.setFeatures.isOffsetFixOn = cboxFeatureOffsetFix.Checked;
            Properties.Settings.Default.setFeatures.isContourOn = cboxFeatureContour.Checked;
            Properties.Settings.Default.setFeatures.isYouTurnOn = cboxFeatureYouTurn.Checked;
            Properties.Settings.Default.setFeatures.isSteerModeOn = cboxFeatureSteerMode.Checked;

            Properties.Settings.Default.setFeatures.isAgIOOn = cboxFeatureAgIO.Checked;

            Properties.Settings.Default.setFeatures.isAutoSectionOn = cboxFeatureAutoSection.Checked;
            Properties.Settings.Default.setFeatures.isManualSectionOn = cboxFeatureManualSection.Checked;
            Properties.Settings.Default.setFeatures.isCycleLinesOn = cboxFeatureCycleLines.Checked;
            Properties.Settings.Default.setFeatures.isABLineOn = cboxFeatureABLine.Checked;
            Properties.Settings.Default.setFeatures.isCurveOn = cboxFeatureCurve.Checked;

            Properties.Settings.Default.setFeatures.isAutoSteerOn = cboxFeatureAutoSteer.Checked;

            Properties.Settings.Default.setFeatures.isLateralOn = cboxFeatureLateral.Checked;
            Properties.Settings.Default.setFeatures.isUTurnOn = cboxFeatureUTurn.Checked;



            Properties.Settings.Default.Save();
        }


        #endregion
    }
}
