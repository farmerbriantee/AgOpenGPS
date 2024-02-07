using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgOpenGPS.Properties;
using OpenTK.Graphics.OpenGL;

//                MessageBox.Show(gStr, gStr.gsHelp);

namespace AgOpenGPS
{
    public partial class FormConfig
    {
        #region FirstPageSummary tSum tab
        private void chkDisplaySky_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkDisplaySky, gStr.gsHelp);
        }

        private void chkDisplayDayNight_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkDisplayDayNight, gStr.gsHelp);
        }

        private void chkDisplayLightbar_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkDisplayLightbar, gStr.gsHelp);
        }

        private void chkDisplayPolygons_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkDisplayPolygons, gStr.gsHelp);
        }

        private void chkDisplayGrid_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkDisplayGrid, gStr.gsHelp);
        }

        private void chkDisplayStartFullScreen_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkDisplayStartFullScreen, gStr.gsHelp);
        }

        private void chkDisplayKeyboard_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkDisplayKeyboard, gStr.gsHelp);
        }

        private void chkDisplayLogNMEA_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkDisplayLogNMEA, gStr.gsHelp);
        }

        private void chkDisplaySpeedo_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkDisplaySpeedo, gStr.gsHelp);
        }

        private void chkDisplayExtraGuides_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkDisplayExtraGuides, gStr.gsHelp);
        }

        private void chkDisplayFloor_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkDisplayFloor, gStr.gsHelp);
        }

        private void rbtnDisplayMetric_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_rbtnDisplayMetric, gStr.gsHelp);
        }

        private void rbtnDisplayImperial_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_rbtnDisplayImperial, gStr.gsHelp);
        }

        private void lvVehicles_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_ListViewVehicles, gStr.gsHelp);
        }

        private void btnVehicleLoad_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_btnVehicleLoad, gStr.gsHelp);
        }

        private void btnVehicleSaveAs_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_btnVehicleSaveAs, gStr.gsHelp);
        }

        private void btnVehicleDelete_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_btnVehicleDelete, gStr.gsHelp);
        }

        private void tboxVehicleNameSave_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_tboxVehicleNameSave, gStr.gsHelp);
        }

        private void btnVehicleSave_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_btnVehicleSave, gStr.gsHelp);
        }
        #endregion

        #region VehicleGuidance tab vGuid
        private void nudLightbarCmPerPixel_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudLightbarCmPerPixel, gStr.gsHelp);
        }
        private void nudABLength_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudABLength, gStr.gsHelp);
        }
        private void nudLineWidth_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudLineWidth, gStr.gsHelp);
        }
        private void nudSnapDistance_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudSnapDistance, gStr.gsHelp);
        }
        private void nudGuidanceLookAhead_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudGuidanceLookAhead, gStr.gsHelp);
        }
        private void cboxAutoSteerAuto_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxAutoSteerAuto, gStr.gsHelp);
        }

        #endregion

        #region Section and Tool
        private void nudSectionWidth_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudSectionWidth, gStr.gsHelp);
        }

        private void nudDefaultSectionWidth_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudDefaultSectionWidth, gStr.gsHelp);
        }

        private void cboxNumSections_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxNumSections, gStr.gsHelp);
        }

        private void nudCutoffSpeed_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudCutoffSpeed, gStr.gsHelp);
        }

        private void nudMinCoverage_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudMinCoverage, gStr.gsHelp);
        }

        private void cboxSectionResponse_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxSectionResponse, gStr.gsHelp);
        }

        private void nudLookAhead_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudLookAheadOn, gStr.gsHelp);
        }

        private void nudLookAheadOff_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudLookAheadOff, gStr.gsHelp);
        }

        private void nudTurnOffDelay_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudTurnOffDelay, gStr.gsHelp);
        }

        private void nudOffset_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudOffset, gStr.gsHelp);
        }

        private void nudOverlap_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudOverlap, gStr.gsHelp);
        }

        #endregion

        #region Data

        private void rbtnHeadingFix_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_rbtnHeadingFix, gStr.gsHelp);
        }

        private void rbtnHeadingGPS_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_rbtnHeadingGPS, gStr.gsHelp);
        }

        private void rbtnHeadingHDT_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_rbtnHeadingHDT, gStr.gsHelp);
        }

        private void nudMinimumFrameTime_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudMinimumFrameTime, gStr.gsHelp);
        }

        private void nudAgeAlarm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudAgeAlarm, gStr.gsHelp);
        }

        private void cboxIsRTK_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxIsRTK, gStr.gsHelp);
        }

        private void cboxIsRTK_KillAutoSteer_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxIsRTK_KillAutoSteer, gStr.gsHelp);
        }

        private void nudStartSpeed_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudStartSpeed, gStr.gsHelp);
        }

        private void nudMinFixStepDistance_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudMinFixStepDistance, gStr.gsHelp);
        }

        private void nudForwardComp_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            DialogResult result2 = MessageBox.Show(gStr.hc_nudForwardComp, gStr.gsHelp,
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result2 == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=rsJMRZrcuX4");
            }
        }

        private void nudReverseComp_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            DialogResult result2 = MessageBox.Show(gStr.hc_nudReverseComp, gStr.gsHelp,
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result2 == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=rsJMRZrcuX4");
            }
        }

        private void hsbarFusion_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_hsbarFusion, gStr.gsHelp);
        }

        private void cboxIsReverseOn_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxIsReverseOn, gStr.gsHelp);
        }

        private void cboxIsDualAsIMU_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxIsDualAsIMU, gStr.gsHelp);
        }

        private void btnRemoveZeroOffset_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_btnRemoveZeroOffset, gStr.gsHelp);
        }

        private void btnZeroRoll_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_btnZeroRoll, gStr.gsHelp);
        }

        private void btnResetIMU_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_btnResetIMU, gStr.gsHelp);
        }

        private void cboxDataInvertRoll_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxDataInvertRoll, gStr.gsHelp);
        }


        #endregion

        #region UTurn
        private void nudTurnDistanceFromBoundary_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudTurnDistanceFromBoundary, gStr.gsHelp);
        }

        private void lblDistance_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_lblUTurnLegDistance, gStr.gsHelp);
        }

        private void lblSmoothing_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_lblUTurnSmoothing, gStr.gsHelp);
        }

        #endregion

        #region Arduino Steer
        private void chkInvertWAS_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkInvertWAS, gStr.gsHelp);
        }

        private void chkInvertSteer_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkInvertSteer, gStr.gsHelp);
        }

        private void chkSteerInvertRelays_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkSteerInvertRelays, gStr.gsHelp);
        }

        private void cboxDanfoss_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxDanfoss, gStr.gsHelp);
        }

        private void cboxEncoder_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxEncoder, gStr.gsHelp);
        }

        private void cboxPressureSensor_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxPressureSensor, gStr.gsHelp);
        }

        private void cboxCurrentSensor_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxCurrentSensor, gStr.gsHelp);
        }

        private void nudMaxCounts_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudMaxCounts, gStr.gsHelp);
        }

        private void cboxMotorDrive_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxMotorDrive, gStr.gsHelp);
        }

        private void cboxConv_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxConv, gStr.gsHelp);
        }

        private void cboxSteerEnable_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxSteerEnable, gStr.gsHelp);
        }

        private void pboxSendSteer_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_pboxSendSteer, gStr.gsHelp);
        }

        private void btnSendSteerConfigPGN_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_btnSendSteerConfigPGN, gStr.gsHelp);
        }

        #endregion

        #region Machine Control
        private void cboxIsHydOn_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxIsHydOn, gStr.gsHelp);
        }

        private void nudHydLiftLookAhead_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudHydLiftLookAhead, gStr.gsHelp);
        }

        private void nudRaiseTime_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudRaiseTime, gStr.gsHelp);
        }

        private void nudLowerTime_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudLowerTime, gStr.gsHelp);
        }

        private void cboxMachInvertRelays_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxMachInvertRelays, gStr.gsHelp);
        }

        private void pboxSendMachine_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_pboxSendSteer, gStr.gsHelp);
        }

        private void btnSendMachinePGN_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_btnSendSteerConfigPGN, gStr.gsHelp);
        }

        #endregion

        #region Trams
        private void nudTramWidth_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudTramWidth, gStr.gsHelp);
        }

        private void cboxTramOnBackBuffer_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxTramOnBackBuffer, gStr.gsHelp);
        }

        private void rbtnTramInner_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_rbtnTramInnerOuter, gStr.gsHelp);
        }

        private void rbtnTramOuter_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_rbtnTramInnerOuter, gStr.gsHelp);
        }


        #endregion

        private NumericUpDown nudCutoffSpeed;
        private Label lblTurnOffBelowUnits;
        private PictureBox pictureBox11;
    }
}