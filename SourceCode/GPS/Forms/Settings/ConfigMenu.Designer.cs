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
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
                if (subMenu.Name == "panelVehicleSubMenu") tab1.SelectedTab = tabVConfig;
                else if (subMenu.Name == "panelToolSubMenu") tab1.SelectedTab = tabTConfig;
                else if (subMenu.Name == "panelDataSourcesSubMenu") tab1.SelectedTab = tabDHeading;
                else if (subMenu.Name == "panelArduinoSubMenu") tab1.SelectedTab = tabASteer;
                else if (btn.Name == "btnUTurn") tab1.SelectedTab = tabUTurn;
                else if (btn.Name == "btnFeatureHides") tab1.SelectedTab = tabBtns;
            }
            else
            {
                tab1.SelectedTab = tabSummary;
                subMenu.Visible = false;
            }
        }

        #region Top Menu Btns

        private void btnHome_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabSummary;
            HideSubMenu();
            UpdateSummary();
        }

        private void UpdateSummary()
        {
            //lblSumWheelbase.Text = Properties.Vehicle.Default.setVehicle_wheelbase.ToString();
            //lblSumToolWidth.Text = mf.tool.toolWidth.ToString();
            //lblSumNumSections.Text = mf.tool.numOfSections.ToString();

            lblCurrentVehicle.Text = Properties.Vehicle.Default.setVehicle_vehicleName;
            //lblSumCurrentTool.Text = Properties.Tool.Default.toolSettings.toolFileName.ToString();
            //lblSumCurrentDataSource.Text = Properties.DataSource.Default.dataSourceSettings.dataSourceFileName.ToString();
            //lblSumFixType.Text = Properties.DataSource.Default.dataSourceSettings.fixFrom.ToString();
        }

        private void btnTool_Click(object sender, EventArgs e)
        {
            if (mf.isJobStarted)
            {
                if (mf.autoBtnState == FormGPS.btnStates.Auto)
                    mf.btnSectionOffAutoOn.PerformClick();

                if (mf.manualBtnState == FormGPS.btnStates.On)
                    mf.btnManualOffOn.PerformClick();
            }

            //turn section buttons all OFF
            for (int j = 0; j < FormGPS.MAXSECTIONS; j++)
            {
                mf.section[j].isAllowedOn = false;
                mf.section[j].manBtnState = FormGPS.manBtn.On;
            }

            //fix ManualOffOnAuto buttons
            mf.manualBtnState = FormGPS.btnStates.Off;
            mf.btnManualOffOn.Image = Properties.Resources.ManualOff;

            //fix auto button
            mf.autoBtnState = FormGPS.btnStates.Off;
            mf.btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOff;

            //Update the button colors and text
            mf.ManualAllBtnsUpdate();

            //enable disable manual buttons
            mf.LineUpManualBtns();

            ShowSubMenu(panelToolSubMenu, btnTool);
            //tab1.SelectedTab = tabSummary;
            UpdateVehicleListView();
            UpdateSummary();
        }

        private void btnDataSources_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelDataSourcesSubMenu, btnDataSources);
            //tab1.SelectedTab = tabSummary;
            //lblCurrentData.Text = gStr.gsCurrent + mf.dataSourceFileName;
            UpdateVehicleListView();
            UpdateSummary();
        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelVehicleSubMenu, btnVehicle);
            //tab1.SelectedTab = tabSummary;
            lblCurrentVehicle.Text = gStr.gsCurrent + mf.vehicleFileName;
            UpdateVehicleListView();
            UpdateSummary();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTram_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            tab1.SelectedTab = tabTram;
        }

        private void btnUTurn_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            tab1.SelectedTab = tabUTurn;
        }

        private void btnFeatureHides_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            tab1.SelectedTab = tabBtns;
        }

        private void btnArduino_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelArduinoSubMenu, btnArduino);
            //tab1.SelectedTab = tabSummary;

            lblCurrentVehicle.Text = gStr.gsCurrent + mf.vehicleFileName;
            UpdateVehicleListView();
            UpdateSummary();
        }


        #endregion

        #region Vehicle Sub Menu Btns
        private void btnSubVehicleType_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabVConfig;
        }

        private void btnSubDimensions_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabVDimensions;
        }

        private void btnSubAntenna_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabVAntenna;
        }

        private void btnSubGuidance_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabVGuidance;
        }

        private void btnSubBrand_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabVBrand;
        }


        #endregion Region

        #region Tool Sub Menu
        private void btnSubToolType_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabTConfig;
        }

        private void btnSubHitch_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabTHitch;
        }

        private void btnSubSections_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabTSections;
        }

        private void btnSubSwitches_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabTSwitches;
        }

        private void btnSubToolSettings_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabTSettings;
        }
        #endregion

        #region SubMenu Data Sources
        private void btnSubRoll_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabDRoll;
        }

        private void btnSubHeading_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabDHeading;
        }

        #endregion

        #region Module

        private void btnSteerModule_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabASteer;
        }

        private void btnMachineModule_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabAMachine;
        }


        #endregion

    }
}
