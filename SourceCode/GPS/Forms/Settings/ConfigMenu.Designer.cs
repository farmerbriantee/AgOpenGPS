using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormConfig
    {
        private void HideSubMenu()
        {
            panelVehicleSubMenu.Visible = false;
            panelToolSubMenu.Visible = false;
            panelDataSourcesSubMenu.Visible = false;
            panelArduinoSubMenu.Visible = false;
        }

        private void ShowSubMenu(Panel subMenu, Button btn)
        {
            ClearVehicleSubBackgrounds();
            ClearToolSubBackgrounds();
            ClearMachineSubBackgrounds();
            ClearDataSubBackgrounds();
            ClearNoSubBackgrounds();

            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
                if (subMenu.Name == "panelVehicleSubMenu")
                {
                    tab1.SelectedTab = tabVConfig;
                }
                else if (subMenu.Name == "panelToolSubMenu")
                {
                    tab1.SelectedTab = tabTConfig;
                }
                else if (subMenu.Name == "panelDataSourcesSubMenu")
                {
                    tab1.SelectedTab = tabDHeading;
                }
                else if (subMenu.Name == "panelArduinoSubMenu")
                {
                    tab1.SelectedTab = tabAMachine;
                }
                else if (btn.Name == "btnUTurn") tab1.SelectedTab = tabUTurn;
                else if (btn.Name == "btnFeatureHides") tab1.SelectedTab = tabBtns;
                else if (btn.Name == "btnDisplay") tab1.SelectedTab = tabDisplay;
            }
            else
            {
                tab1.SelectedTab = tabSummary;
                subMenu.Visible = false;
            }
        }

        private void UpdateSummary()
        {
            //lblSumWheelbase.Text = Properties.Settings.Default.setVehicle_wheelbase.ToString();
            //lblSumToolWidth.Text = mf.tool.toolWidth.ToString();
            lblSumNumSections.Text = mf.tool.numOfSections.ToString();

            string snapDist = mf.isMetric ?
                Properties.Settings.Default.setAS_snapDistance.ToString() :
                (Properties.Settings.Default.setAS_snapDistance * mf.cm2CmOrIn).ToString("N1");

            lblNudgeDistance.Text = snapDist + mf.unitsInCm.ToString();
            lblUnits.Text = mf.isMetric ? "Metric" : "Imperial";

            lblCurrentVehicle.Text = Properties.Settings.Default.setVehicle_vehicleName;

            lblTramWidth.Text = (mf.isMetric ?
                (Properties.Settings.Default.setTram_tramWidth * mf.m2InchOrCm).ToString() :
                (Properties.Settings.Default.setTram_tramWidth * mf.m2InchOrCm).ToString("N1")) +
                mf.unitsInCm;

            lblToolOffset.Text = (mf.isMetric ?
                (Properties.Settings.Default.setVehicle_toolOffset * mf.m2InchOrCm).ToString() :
                (Properties.Settings.Default.setVehicle_toolOffset * mf.m2InchOrCm).ToString("N1")) +
                mf.unitsInCm;

            lblOverlap.Text = (mf.isMetric ?
                (Properties.Settings.Default.setVehicle_toolOverlap * mf.m2InchOrCm).ToString() :
                (Properties.Settings.Default.setVehicle_toolOverlap * mf.m2InchOrCm).ToString("N1")) +
                mf.unitsInCm;

            lblLookahead.Text = Properties.Settings.Default.setVehicle_toolLookAheadOn.ToString() + " sec";

            //lblSumCurrentTool.Text = Properties.Tool.Default.toolSettings.toolFileName.ToString();
            //lblSumCurrentDataSource.Text = Properties.DataSource.Default.dataSourceSettings.dataSourceFileName.ToString();
            //lblSumFixType.Text = Properties.DataSource.Default.dataSourceSettings.fixFrom.ToString();
        }

        #region No Sub menu Buttons

        private void ClearNoSubBackgrounds()
        {
            btnTram.BackColor = SystemColors.GradientInactiveCaption;
            btnUTurn.BackColor = SystemColors.GradientInactiveCaption;
            btnDisplay.BackColor = SystemColors.GradientInactiveCaption;
            btnFeatureHides.BackColor = SystemColors.GradientInactiveCaption;
        }
        private void btnTram_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            ClearNoSubBackgrounds();
            if (tab1.SelectedTab == tabTram)
            {
                tab1.SelectedTab = tabSummary;
            }
            else
            {
                tab1.SelectedTab = tabTram;
                btnTram.BackColor = SystemColors.GradientActiveCaption;
            }
        }

        private void btnUTurn_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            ClearNoSubBackgrounds();
            if (tab1.SelectedTab != tabUTurn)
            {
                tab1.SelectedTab = tabSummary;
            }
            else
            {
                tab1.SelectedTab = tabUTurn;
                btnUTurn.BackColor = SystemColors.GradientActiveCaption;
            }
        }

        private void btnFeatureHides_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            ClearNoSubBackgrounds();
            if (tab1.SelectedTab == tabBtns)
            {
                tab1.SelectedTab = tabSummary;
            }
            else
            {
                tab1.SelectedTab = tabBtns;
                btnFeatureHides.BackColor = SystemColors.GradientActiveCaption;
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            ClearNoSubBackgrounds();
            if (tab1.SelectedTab == tabDisplay)
            {
                tab1.SelectedTab = tabSummary;
            }
            else
            {
                tab1.SelectedTab = tabDisplay;
                btnDisplay.BackColor = SystemColors.GradientActiveCaption;
            }
        }

        #endregion

        #region Vehicle Sub Menu Btns
        private void btnVehicle_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelVehicleSubMenu, btnVehicle);
            btnSubVehicleType.BackColor = Color.Gold;
            lblCurrentVehicle.Text = gStr.gsCurrent + mf.vehicleFileName;
            UpdateVehicleListView();
        }

        private void ClearVehicleSubBackgrounds()
        {
            btnSubVehicleType.BackColor = Color.FloralWhite;
            btnSubAntenna.BackColor = Color.FloralWhite;
            btnSubDimensions.BackColor = Color.FloralWhite;
            btnSubGuidance.BackColor = Color.FloralWhite;
        }
        private void btnSubVehicleType_Click(object sender, EventArgs e)
        {
            ClearVehicleSubBackgrounds();
            tab1.SelectedTab = tabVConfig;
            btnSubVehicleType.BackColor = Color.Gold;
        }

        private void btnSubDimensions_Click(object sender, EventArgs e)
        {
            ClearVehicleSubBackgrounds();
            tab1.SelectedTab = tabVDimensions;
            btnSubDimensions.BackColor = Color.Gold;
        }

        private void btnSubAntenna_Click(object sender, EventArgs e)
        {
            ClearVehicleSubBackgrounds();
            tab1.SelectedTab = tabVAntenna;
            btnSubAntenna.BackColor = Color.Gold;
        }

        private void btnSubGuidance_Click(object sender, EventArgs e)
        {
            ClearVehicleSubBackgrounds();
            tab1.SelectedTab = tabVGuidance;
            btnSubGuidance.BackColor = Color.Gold;               
        }

        #endregion Region

        #region Tool Sub Menu
        private void btnTool_Click(object sender, EventArgs e)
        {
            if (mf.isJobStarted)
            {
                if (mf.autoBtnState == btnStates.Auto)
                    mf.btnSectionMasterAuto.PerformClick();

                if (mf.manualBtnState == btnStates.On)
                    mf.btnSectionMasterManual.PerformClick();
            }

            if (mf.tool.isSectionsNotZones)
            {
                //fix ManualOffOnAuto buttons
                mf.manualBtnState = btnStates.Off;
                mf.btnSectionMasterManual.Image = Properties.Resources.ManualOff;

                //fix auto button
                mf.autoBtnState = btnStates.Off;
                mf.btnSectionMasterAuto.Image = Properties.Resources.SectionMasterOff;

                //Update the button colors and text
                mf.AllSectionsAndButtonsToState(mf.autoBtnState);

                //enable disable manual buttons
                mf.LineUpIndividualSectionBtns();
            }
            else
            {
                //turn section buttons all OFF
                mf.AllZonesAndButtonsToState(btnStates.Off);

                mf.LineUpAllZoneButtons();
            }

            ShowSubMenu(panelToolSubMenu, btnTool);
            btnSubToolType.BackColor=Color.Gold;
            UpdateVehicleListView();
        }

        private void ClearToolSubBackgrounds()
        {
            btnSubToolType.BackColor = Color.FloralWhite;
            btnSubHitch.BackColor = Color.FloralWhite;
            btnSubSections.BackColor = Color.FloralWhite;
            btnSubSwitches.BackColor = Color.FloralWhite;
            btnSubToolSettings.BackColor = Color.FloralWhite;
        }

        private void btnSubToolType_Click(object sender, EventArgs e)
        {
            ClearToolSubBackgrounds();
            tab1.SelectedTab = tabTConfig;
            btnSubToolType.BackColor = Color.Gold;
        }

        private void btnSubHitch_Click(object sender, EventArgs e)
        {
            ClearToolSubBackgrounds();
            tab1.SelectedTab = tabTHitch;
            btnSubHitch.BackColor= Color.Gold;
        }

        private void btnSubSections_Click(object sender, EventArgs e)
        {
            ClearToolSubBackgrounds();
            tab1.SelectedTab = tabTSections;
            btnSubSections.BackColor= Color.Gold;
        }

        private void btnSubSwitches_Click(object sender, EventArgs e)
        {
            ClearToolSubBackgrounds();
            tab1.SelectedTab = tabTSwitches;
            btnSubSwitches .BackColor = Color.Gold;
        }

        private void btnSubToolSettings_Click(object sender, EventArgs e)
        {
            ClearToolSubBackgrounds();
            tab1.SelectedTab = tabTSettings;
            btnSubToolSettings.BackColor = Color.Gold;
        }
        #endregion

        #region SubMenu Data Sources

        private void ClearDataSubBackgrounds()
        {
            btnSubHeading.BackColor = Color.FloralWhite;
            btnSubRoll.BackColor = Color.FloralWhite;
        }
        private void btnDataSources_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelDataSourcesSubMenu, btnDataSources);
            btnSubHeading.BackColor=Color.Gold;
            UpdateVehicleListView();
        }

        private void btnSubHeading_Click(object sender, EventArgs e)
        {
            ClearDataSubBackgrounds();
            tab1.SelectedTab = tabDHeading;
            btnSubHeading.BackColor=Color.Gold;
        }

        private void btnSubRoll_Click(object sender, EventArgs e)
        {
            ClearDataSubBackgrounds();
            tab1.SelectedTab = tabDRoll;
            btnSubRoll.BackColor=Color.Gold;
        }

        #endregion

        #region Module
        private void ClearMachineSubBackgrounds()
        {
            btnMachineModule.BackColor = Color.FloralWhite;
            btnMachineRelay.BackColor = Color.FloralWhite;
        }

        private void btnArduino_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelArduinoSubMenu, btnArduino);
            btnMachineModule.BackColor = Color.Gold;
            lblCurrentVehicle.Text = gStr.gsCurrent + mf.vehicleFileName;
            UpdateVehicleListView();
        }

        private void btnMachineModule_Click(object sender, EventArgs e)
        {
            ClearMachineSubBackgrounds();
            tab1.SelectedTab = tabAMachine;
            btnMachineModule.BackColor = Color.Gold;
        }

        private void btnMachineRelay_Click(object sender, EventArgs e)
        {
            ClearMachineSubBackgrounds();
            tab1.SelectedTab = tabRelay;
            btnMachineRelay.BackColor= Color.Gold;
        }
        #endregion
    }
}
