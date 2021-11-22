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
            MessageBox.Show(gStr.hc_nudGuidanceLookAhead, gStr.gsHelp);
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

        private void nudOverlap_ValueChanged(object sender, EventArgs e)
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
            MessageBox.Show(gStr.hc_nudForwardComp, gStr.gsHelp);
        }

        private void nudReverseComp_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudReverseComp, gStr.gsHelp);
        }        
        
        private void hsbarFusion_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_hsbarFusion, gStr.gsHelp);
        }

        #endregion

    }
}