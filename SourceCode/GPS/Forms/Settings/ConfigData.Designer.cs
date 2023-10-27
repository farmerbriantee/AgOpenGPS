using System;
using System.Linq;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormConfig
    {
        #region Heading
        private void tabDHeading_Enter(object sender, EventArgs e)
        {
            //heading
            if (Properties.Settings.Default.setGPS_headingFromWhichSource == "Fix") rbtnHeadingFix.Checked = true;
            //else if (Properties.Settings.Default.setGPS_headingFromWhichSource == "VTG") rbtnHeadingGPS.Checked = true;
            else if (Properties.Settings.Default.setGPS_headingFromWhichSource == "Dual") rbtnHeadingHDT.Checked = true;
            
            if (rbtnHeadingHDT.Checked)
            {
                gboxSingle.Enabled = false;
                gboxDual.Enabled = true;
                //nudDualHeadingOffset.Enabled = true;
            }
            else
            {
                gboxSingle.Enabled = true;
                gboxDual.Enabled = false;
                //nudDualHeadingOffset.Enabled=false; 
            }

            nudDualHeadingOffset.Value = (decimal)Properties.Settings.Default.setGPS_dualHeadingOffset;

            hsbarFusion.Value = (int)(Properties.Settings.Default.setIMU_fusionWeight2 * 500);
            lblFusion.Text = (hsbarFusion.Value).ToString();
            lblFusionIMU.Text = (100 - hsbarFusion.Value).ToString();

            cboxIsRTK.Checked = Properties.Settings.Default.setGPS_isRTK;
            cboxIsRTK_KillAutoSteer.Checked = Properties.Settings.Default.setGPS_isRTK_KillAutoSteer;

            cboxIsReverseOn.Checked = Properties.Settings.Default.setIMU_isReverseOn;

            if (Properties.Settings.Default.setF_minHeadingStepDistance == 1.0)
                cboxMinGPSStep.Checked = true;
            else
                cboxMinGPSStep.Checked = false;

            if (cboxMinGPSStep.Checked)
            {
                Properties.Settings.Default.setF_minHeadingStepDistance = 1.0;
                Properties.Settings.Default.setGPS_minimumStepLimit = 0.1;
                cboxMinGPSStep.Text = "10 " + gStr.gsCentimeters;
                lblHeadingDistance.Text = "100 " + gStr.gsCentimeters;
            }
            else
            {
                Properties.Settings.Default.setF_minHeadingStepDistance = 0.5;
                Properties.Settings.Default.setGPS_minimumStepLimit = 0.05;
                cboxMinGPSStep.Text = "5 " + gStr.gsCentimeters;
                lblHeadingDistance.Text = "50 " + gStr.gsCentimeters;
            }

            nudStartSpeed.Value = (decimal)Properties.Settings.Default.setVehicle_startSpeed;

            cboxIsDualAsIMU.Checked = Properties.Settings.Default.setIMU_isDualAsIMU;

            if (mf.ahrs.imuHeading != 99999)
            {
                hsbarFusion.Enabled = true;
            }
            else
            {
                hsbarFusion.Enabled = false;
            }

            //nudMinimumFrameTime.Value = Properties.Settings.Default.SetGPS_udpWatchMsec;

            //nudForwardComp.Value = (decimal)(Properties.Settings.Default.setGPS_forwardComp);
            //nudReverseComp.Value = (decimal)(Properties.Settings.Default.setGPS_reverseComp);
            //nudAgeAlarm.Value = Properties.Settings.Default.setGPS_ageAlarm;
        }

            private void tabDHeading_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.setIMU_isDualAsIMU = mf.ahrs.isDualAsIMU = cboxIsDualAsIMU.Checked;

            Properties.Settings.Default.setIMU_fusionWeight2 = (double)hsbarFusion.Value * 0.002;
            mf.ahrs.fusionWeight = (double)hsbarFusion.Value * 0.002;

            Properties.Settings.Default.setGPS_isRTK = mf.isRTK = cboxIsRTK.Checked;
            Properties.Settings.Default.setGPS_isRTK_KillAutoSteer = mf.isRTK_KillAutosteer = cboxIsRTK_KillAutoSteer.Checked;

            Properties.Settings.Default.setIMU_isReverseOn = mf.ahrs.isReverseOn = cboxIsReverseOn.Checked;

            if (cboxMinGPSStep.Checked)
            {
                Properties.Settings.Default.setF_minHeadingStepDistance = 1.0;
                Properties.Settings.Default.setGPS_minimumStepLimit = 0.1;
            }
            else
            {
                Properties.Settings.Default.setF_minHeadingStepDistance = 0.5;
                Properties.Settings.Default.setGPS_minimumStepLimit = 0.05;
            }


            Properties.Settings.Default.Save();
        }
        private void rbtnHeadingFix_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = headingGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            Properties.Settings.Default.setGPS_headingFromWhichSource = checkedButton.Text;
            mf.headingFromSource = checkedButton.Text;

            if (rbtnHeadingHDT.Checked)
            {
                gboxSingle.Enabled = false;
                gboxDual.Enabled = true;
            }
            else
            {
                gboxSingle.Enabled = true;
                gboxDual.Enabled= false;
            }
        }


        private void nudDualHeadingOffset_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Settings.Default.setGPS_dualHeadingOffset = ((double)nudDualHeadingOffset.Value);
                mf.pn.headingTrueDualOffset = Properties.Settings.Default.setGPS_dualHeadingOffset;
            }
        }

        //private void nudMinimumFrameTime_Click(object sender, EventArgs e)
        //{
        //    if (mf.KeypadToNUD((NumericUpDown)sender, this))
        //    {
        //        Properties.Settings.Default.SetGPS_udpWatchMsec = ((int)nudMinimumFrameTime.Value);
        //        mf.udpWatchLimit = Properties.Settings.Default.SetGPS_udpWatchMsec;
        //    }
        //}
        private void cboxMinGPSStep_Click(object sender, EventArgs e)
        {
            if (cboxMinGPSStep.Checked)
            {
                Properties.Settings.Default.setF_minHeadingStepDistance = 1;
                Properties.Settings.Default.setGPS_minimumStepLimit = 0.1;
                cboxMinGPSStep.Text = "10 " + gStr.gsCentimeters;
                lblHeadingDistance.Text = "100 " + gStr.gsCentimeters;
                mf.isFirstHeadingSet = false;
            }
            else
            {
                Properties.Settings.Default.setF_minHeadingStepDistance = 0.5;
                Properties.Settings.Default.setGPS_minimumStepLimit = 0.05;
                cboxMinGPSStep.Text = "5 " + gStr.gsCentimeters;
                lblHeadingDistance.Text = "50 " + gStr.gsCentimeters;
                mf.isFirstHeadingSet = false;
            }

        }

        private void nudStartSpeed_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Settings.Default.setVehicle_startSpeed = (double)nudStartSpeed.Value;
                mf.isFirstHeadingSet = false;
            }
        }

        private void hsbarFusion_ValueChanged(object sender, EventArgs e)
        {
            lblFusion.Text = (hsbarFusion.Value).ToString()+"%";
            lblFusionIMU.Text = (100 - hsbarFusion.Value).ToString()+"%";
        }

        //private void nudForwardComp_Click(object sender, EventArgs e)
        //{
        //    if (mf.KeypadToNUD((NumericUpDown)sender, this))
        //    {
        //        Properties.Settings.Default.setGPS_forwardComp = (double)nudForwardComp.Value;
        //    }
        //}

        //private void nudReverseComp_Click(object sender, EventArgs e)
        //{
        //    if (mf.KeypadToNUD((NumericUpDown)sender, this))
        //    {
        //        Properties.Settings.Default.setGPS_reverseComp = (double)nudReverseComp.Value;
        //    }
        //}

        //private void nudAgeAlarm_Click(object sender, EventArgs e)
        //{
        //    if (mf.KeypadToNUD((NumericUpDown)sender, this))
        //    {
        //        Properties.Settings.Default.setGPS_ageAlarm = (int)nudAgeAlarm.Value;
        //    }
        //}

        #endregion

        #region Roll

        private void tabDRoll_Enter(object sender, EventArgs e)
        {
            //Roll
            lblRollZeroOffset.Text = ((double)Properties.Settings.Default.setIMU_rollZero).ToString("N2");
            hsbarRollFilter.Value = (int)(Properties.Settings.Default.setIMU_rollFilter * 100);
            cboxDataInvertRoll.Checked = Properties.Settings.Default.setIMU_invertRoll;
        }

        private void tabDRoll_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.setIMU_rollFilter = (double)hsbarRollFilter.Value * 0.01;
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

        private void btnRollOffsetDown_Click(object sender, EventArgs e)
        {
            if (mf.ahrs.imuRoll != 88888)
            {
                mf.ahrs.rollZero -= 0.1;
                lblRollZeroOffset.Text = (mf.ahrs.rollZero).ToString("N2");
            }
            else
            {
                lblRollZeroOffset.Text = "***";
            }
        }

        private void btnRollOffsetUp_Click(object sender, EventArgs e)
        {
            if (mf.ahrs.imuRoll != 88888)
            {
                mf.ahrs.rollZero += 0.1;
                lblRollZeroOffset.Text = (mf.ahrs.rollZero).ToString("N2");
            }
            else
            {
                lblRollZeroOffset.Text = "***";
            }
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
            //cboxFeatureBoundaryContour.Checked = Properties.Settings.Default.setFeatures.isBndContourOn;
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

            cboxTurnSound.Checked = Properties.Settings.Default.setSound_isUturnOn;
            cboxSteerSound.Checked = Properties.Settings.Default.setSound_isAutoSteerOn;
            cboxHydLiftSound.Checked = Properties.Settings.Default.setSound_isHydLiftOn;
            cboxAutoStartAgIO.Checked = Properties.Settings.Default.setDisplay_isAutoStartAgIO;

        }

        private void tabBtns_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.setFeatures.isTramOn = cboxFeatureTram.Checked;
            Properties.Settings.Default.setFeatures.isHeadlandOn = cboxFeatureHeadland.Checked;

            Properties.Settings.Default.setFeatures.isBoundaryOn = cboxFeatureBoundary.Checked;
            //Properties.Settings.Default.setFeatures.isBndContourOn = cboxFeatureBoundaryContour.Checked;
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

            Properties.Settings.Default.setSound_isUturnOn = cboxTurnSound.Checked;
            mf.sounds.isTurnSoundOn = cboxTurnSound.Checked;
            Properties.Settings.Default.setSound_isAutoSteerOn = cboxSteerSound.Checked;
            mf.sounds.isSteerSoundOn = cboxSteerSound.Checked;
            Properties.Settings.Default.setSound_isHydLiftOn = cboxHydLiftSound.Checked;
            mf.sounds.isHydLiftSoundOn = cboxHydLiftSound.Checked;

            Properties.Settings.Default.setDisplay_isAutoStartAgIO = cboxAutoStartAgIO.Checked;
            mf.isAutoStartAgIO = cboxAutoStartAgIO.Checked;

            Properties.Settings.Default.Save();
        }


        #endregion
    }
}
